#!/usr/bin/env python3
"""Send only post-baseline Anco1 source diffs to Azure via incremental PRs.

GitHub master pushes create Azure PRs automatically and request auto-completion
after Azure's required branch policies pass. Neither old GitHub history nor
Azure default-branch history is rewritten. In-flight sync PRs block duplicate
PRs; scheduled checks catch up after they complete.
"""
import base64
import json
import os
import pathlib
import re
import subprocess
import sys
import tempfile
import urllib.parse
import urllib.request

BASELINE = "1e614269073c8f60bdfcdbfc1570ecd7588a2d20"
AZURE_ORG = "vongocnhancd10cntt2"
AZURE_PROJECT = "Anco1"
AZURE_REPO = "Anco1"
ALLOWED_PATHS = (
    "eman_ver3/", "DataAccess/", "GenerateModels/",
    "Report/", "Anco1.sln", "packages/",
)
MARKER = re.compile(r"ANCO1_SYNC_FROM=([a-f0-9]{40})\s+ANCO1_SYNC_TO=([a-f0-9]{40})")
MAX_PATCH_BYTES = 50 * 1024 * 1024


def git(*args, cwd=None, input_bytes=None):
    result = subprocess.run(["git", *args], cwd=cwd, input=input_bytes,
                            stdout=subprocess.PIPE, stderr=subprocess.PIPE)
    if result.returncode:
        error = result.stderr.decode("utf-8", "replace").strip()
        raise RuntimeError("git operation failed: " + error[:1500])
    return result.stdout


def ancestor(old, new):
    result = subprocess.run(["git", "merge-base", "--is-ancestor", old, new],
                            stdout=subprocess.DEVNULL, stderr=subprocess.DEVNULL)
    return result.returncode == 0


def api(endpoint, authorization, method="GET", payload=None):
    base = "https://dev.azure.com/{}/{}/_apis/git/repositories/{}".format(
        urllib.parse.quote(AZURE_ORG), urllib.parse.quote(AZURE_PROJECT),
        urllib.parse.quote(AZURE_REPO))
    url = base + endpoint
    request_data = None if payload is None else json.dumps(payload).encode("utf-8")
    req = urllib.request.Request(url, data=request_data, method=method)
    req.add_header("Authorization", authorization)
    req.add_header("Accept", "application/json")
    if request_data is not None:
        req.add_header("Content-Type", "application/json")
    with urllib.request.urlopen(req, timeout=45) as response:
        return json.load(response)


def list_prs(auth, status):
    params = urllib.parse.urlencode({
        "searchCriteria.status": status,
        "$top": "100",
        "api-version": "7.1",
    })
    return api("/pullrequests?" + params, auth).get("value", [])


def find_last_completed(auth, target_ref, head):
    candidates = []
    for item in list_prs(auth, "completed"):
        if item.get("targetRefName") != target_ref:
            continue
        marker = MARKER.search(item.get("description") or "")
        if not marker:
            continue
        frm, to = marker.groups()
        if ancestor(BASELINE, to) and ancestor(to, head) and ancestor(frm, to):
            count = int(git("rev-list", "--count", BASELINE + ".." + to).decode().strip())
            candidates.append((count, to))
    return max(candidates)[1] if candidates else BASELINE


def active_sync_pr(auth, target_ref):
    for item in list_prs(auth, "active"):
        if (item.get("targetRefName") == target_ref
                and MARKER.search(item.get("description") or "")):
            return item
    return None


def request_auto_complete(auth, pr):
    """Have Azure merge only after required policies pass. Never bypass them."""
    identity_id = (pr.get("createdBy") or {}).get("id")
    pr_id = pr.get("pullRequestId")
    if not identity_id or not pr_id:
        raise RuntimeError("Azure PR did not provide a valid creator identity for auto-complete.")
    completion = {
        "autoCompleteSetBy": {"id": identity_id},
        "completionOptions": {
            "mergeStrategy": "noFastForward",
            "deleteSourceBranch": True,
            "bypassPolicy": False,
        },
    }
    updated = api("/pullrequests/{}?api-version=7.1".format(pr_id),
                  auth, method="PATCH", payload=completion)
    if updated.get("status") == "completed":
        print("Azure PR #{} already merged.".format(pr_id))
    elif updated.get("autoCompleteSetBy"):
        print("Auto-complete enabled on Azure PR #{} (required branch policies respected).".format(pr_id))
    else:
        raise RuntimeError("Azure did not confirm PR auto-complete; check branch policies and PAT permissions.")


def preload_source_patch_blobs(root, start, head):
    """Make 3-way merge base objects available in the temporary Azure clone.

    Azure history is unrelated to the rewritten GitHub history, so Azure's
    object database does not contain the preimage blobs referenced by a
    GitHub-generated patch. This adds only those blob objects to the TEMPORARY
    clone. It does not change Azure branches or working-tree files.
    """
    raw = git("diff", "--raw", "--no-renames", "--abbrev=40",
              start, head, "--", *ALLOWED_PATHS)
    count = 0
    for line in raw.decode("utf-8", "surrogateescape").splitlines():
        header, separator, _path = line.partition("\t")
        if not separator:
            raise RuntimeError("Unexpected Git raw diff format.")
        fields = header.split()
        if len(fields) < 5:
            raise RuntimeError("Unexpected Git raw diff header.")
        old_blob = fields[2]
        if not re.fullmatch(r"[a-f0-9]{40}", old_blob):
            raise RuntimeError("Unexpected Git diff source blob ID.")
        if old_blob == "0" * 40:
            continue
        data = git("cat-file", "blob", old_blob)
        imported = git("-C", str(root), "hash-object", "-w", "--stdin",
                       input_bytes=data).decode("ascii").strip()
        if imported != old_blob:
            raise RuntimeError("Blob identity changed during temporary merge-base import.")
        count += 1
    print("Preloaded {} source base blobs into ephemeral Azure clone for safe 3-way apply.".format(count))


def main():
    head = os.environ.get("GITHUB_SHA", "").strip()
    pat = os.environ.get("AZURE_DEVOPS_PAT", "").strip()
    mode = os.environ.get("SYNC_MODE", "preview").strip()
    automatic = os.environ.get("SYNC_AUTO_COMPLETE", "false").strip().lower() == "true"
    if not re.fullmatch(r"[a-f0-9]{40}", head):
        raise RuntimeError("GITHUB_SHA must be a 40-character SHA.")
    if os.environ.get("GITHUB_REF") != "refs/heads/master":
        raise RuntimeError("Only GitHub master can be released to Azure.")
    if not ancestor(BASELINE, head):
        raise RuntimeError("GitHub master does not descend from the fixed sync baseline.")
    if mode not in ("preview", "create-pr"):
        raise RuntimeError("SYNC_MODE must be preview or create-pr.")
    if not pat:
        raise RuntimeError("Missing GitHub Actions secret AZURE_DEVOPS_PAT; Azure is unchanged.")

    auth = "Basic " + base64.b64encode((":" + pat).encode("utf-8")).decode("ascii")
    # Git CLI reads the auth header from an environment variable; never put PAT in a URL.
    os.environ["AZURE_GIT_AUTH_HEADER"] = "AUTHORIZATION: " + auth
    repo_info = api("?api-version=7.1", auth)
    target_ref = repo_info.get("defaultBranch")
    if not target_ref or not target_ref.startswith("refs/heads/"):
        raise RuntimeError("Azure repository has no recognized default branch.")
    target_branch = target_ref[len("refs/heads/"):]

    active = active_sync_pr(auth, target_ref)
    if active:
        message = ("Azure sync PR #{} is still active: {}. "
                   "No duplicate branch/PR will be created; the scheduled retry "
                   "will sync subsequent commits after this PR completes.").format(
                       active.get("pullRequestId"), active.get("status"))
        if not automatic:
            raise RuntimeError(message)
        print(message)
        # A queued run may have created the PR before auto-complete was configured.
        # Safely enable it without creating a second branch or PR.
        if not active.get("autoCompleteSetBy"):
            request_auto_complete(auth, active)
        return
    start = find_last_completed(auth, target_ref, head)
    if not ancestor(start, head):
        if automatic and ancestor(head, start):
            print("Skipped obsolete queued GitHub revision; Azure cursor is already newer.")
            return
        raise RuntimeError("Last completed Azure release is not an ancestor of GitHub HEAD.")

    patch = git("diff", "--binary", "--no-ext-diff", "--no-renames",
                start, head, "--", *ALLOWED_PATHS)
    changed = git("diff", "--name-only", "--no-renames",
                  start, head, "--", *ALLOWED_PATHS).decode("utf-8", "replace").splitlines()
    print("Source: {} -> {}".format(start, head))
    print("Azure target:", target_ref)
    print("Changed source files:", len(changed))
    for name in changed[:150]:
        print(" ", name)
    if len(changed) > 150:
        print(" ... and {} more".format(len(changed) - 150))
    if not patch:
        print("No new source code after the cursor. Historical commits were not sent.")
        return
    if len(patch) > MAX_PATCH_BYTES:
        raise RuntimeError("Patch exceeds 50 MiB. Split this release into smaller batches.")

    remote_url = "https://dev.azure.com/{}/{}/_git/{}".format(
        AZURE_ORG, AZURE_PROJECT, AZURE_REPO)
    with tempfile.TemporaryDirectory(prefix="anco1-azure-") as temp:
        root = pathlib.Path(temp) / "azure"
        git("--config-env=http.extraheader=AZURE_GIT_AUTH_HEADER",
            "clone", "--no-checkout", remote_url, str(root))
        # Start exactly at the remote target. No mirroring, resetting or force pushing Azure.
        git("-C", str(root), "switch", "--detach", "origin/" + target_branch)
        branch = "github-sync/anco1-" + head[:12] + "-" + os.environ.get("GITHUB_RUN_ID", "manual")
        git("-C", str(root), "switch", "-c", branch)
        preload_source_patch_blobs(root, start, head)
        try:
            git("-C", str(root), "apply", "--index", "--3way", "-",
                input_bytes=patch)
            print("Generic safe 3-way patch applied.")
        except RuntimeError:
            # The two-file Excel export was built on top of a previous GitHub
            # DHD feature excluded from the Azure baseline. Never import that
            # excluded DHD code and never replace full Azure source files.
            # The guarded bridge copies ONLY the new, standalone Excel feature
            # after checking the old JS block matches the known baseline.
            if start != BASELINE or set(changed) != {
                "eman_ver3/Controller/JQGridModify/JQGridMD_00_DSHangHoa_SOANTHAOModify.ashx",
                "eman_ver3/js/Module_script/MD_00_DSHangHoa_SOANTHAO.js",
            }:
                raise
            print("Git patch conflicts with excluded old DHD history; "
                  "trying a one-time guarded Excel-only integration.")
            git("-C", str(root), "reset", "--hard", "HEAD")
            from azure_devops_excel_bootstrap import apply_guarded_excel_only
            apply_guarded_excel_only(root, pathlib.Path.cwd(), BASELINE, changed)
        status = git("-C", str(root), "diff", "--cached", "--name-only").decode().strip()
        if not status:
            print("Diff is already present in Azure; nothing to release.")
            return
        print("Azure patch applied without conflicts.")
        if mode == "preview":
            print("Preview mode: Azure remains unchanged; rerun with create-pr to publish.")
            return

        git("-C", str(root), "-c", "user.name=Anco1 Sync Bot",
            "-c", "user.email=anco1-sync@users.noreply.github.com",
            "commit", "-m", "sync: Anco1 approved GitHub changes {}..{}".format(start[:12], head[:12]))
        git("-C", str(root), "--config-env=http.extraheader=AZURE_GIT_AUTH_HEADER",
            "push", "origin", "HEAD:refs/heads/" + branch)
        desc = ("Incremental Anco1 source changes from GitHub master.\n\n"
                "From: https://github.com/{}/commit/{}\n"
                "To: https://github.com/{}/commit/{}\n\n"
                "ANCO1_SYNC_FROM={}\nANCO1_SYNC_TO={}\n\n"
                "No old history, no force push; Azure branch policies are respected.").format(
                    os.environ.get("GITHUB_REPOSITORY", "ngocnhanvo/anco1"), start,
                    os.environ.get("GITHUB_REPOSITORY", "ngocnhanvo/anco1"), head,
                    start, head)
        pr = api("/pullrequests?api-version=7.1", auth, method="POST", payload={
            "sourceRefName": "refs/heads/" + branch,
            "targetRefName": target_ref,
            "title": "Anco1: automatic GitHub source sync {}..{}".format(start[:12], head[:12]),
            "description": desc,
            "isDraft": False,
        })
        pr_id = pr.get("pullRequestId")
        print("Created Azure PR #{}".format(pr_id))
        print("https://dev.azure.com/{}/{}/_git/{}/pullrequest/{}".format(
            AZURE_ORG, AZURE_PROJECT, AZURE_REPO, pr_id))
        if automatic:
            request_auto_complete(auth, pr)
        else:
            print("Manual PR mode: review/merge remains a separate Azure operation.")


if __name__ == "__main__":
    try:
        main()
    except Exception as exc:
        print("Azure sync blocked: {}".format(exc), file=sys.stderr)
        sys.exit(1)
