# Decisions

This file records durable technical/product decisions for Anco1 so future agents do not accidentally reverse them.

## Preserve the legacy architecture for local work

**Status: Confirmed**

Decision:
- For ordinary feature work and bug fixes, preserve the current ASP.NET WebForms + jqGrid + Entity Framework + SQL Server architecture.
- Do not introduce broad framework migrations or architectural rewrites unless explicitly approved.

Reason:
- The system has many interconnected modules and shared helpers. Local changes should minimize blast radius.

## Use DalatHoa as an architectural reference only

**Status: Confirmed**

Decision:
- DalatHoa may be used to understand navigation patterns, layer responsibilities, jqGrid/WebForms conventions, and documentation style.
- Anco1 business behavior must be verified independently from Anco1 code/database or confirmed by the project owner.

Reason:
- The two systems share a strong structural lineage but have different domain data and business rules.

## Keep durable AI knowledge in-repository

**Status: Confirmed**

Decision:
- `AGENTS.md` and `docs/knowledge-base/` are the durable onboarding/technical-memory entry points for future AI agents and maintainers.
- Significant future discoveries about architecture, conventions, business rules, dependencies, or deliberate design choices should be added there.

Reason:
- Important project knowledge should not exist only in chat history.

## Do not store database backup archives in Git history

**Status: Confirmed by repository maintenance work on 2026-09-27**

Decision:
- Legacy `.bak` and `.rar` database/archive files that are not part of source operation should not be committed into repository history.

Context:
- The repository history imported from the previous Azure DevOps source contained database/archive files exceeding GitHub file-size limits. The history was rewritten to remove `*.bak` and `*.rar` before pushing the cleaned history to GitHub.

Consequence:
- Future source changes should avoid reintroducing these backup/archive artifacts. Database/schema context should be handled deliberately rather than by committing large backup files.

## Azure DevOps release synchronization

**Status: Confirmed by project owner (2026-10-24)**

Decision:
- GitHub `ngocnhanvo/anco1` is the development repository; Azure DevOps `vongocnhancd10cntt2/Anco1/_git/Anco1` is the destination repository.
- Never mirror or overwrite Azure with GitHub history. The irreversible exclusion baseline for old GitHub commits is `1e614269073c8f60bdfcdbfc1570ecd7588a2d20` (the last DHD dialog-icon fix). That commit and all earlier commits are excluded.
- Only source-code changes after that baseline are eligible; exclude workflow/synchronization implementation and knowledge notes from the payload. Exact allowlist is in `scripts/azure_devops_sync.py`.
- Delivery requires deliberate `workflow_dispatch` of `.github/workflows/azure-devops-sync.yml`, with `preview` before `create-pr` recommended. GitHub pushes alone must not release automatically.
- Azure's default branch is discovered dynamically. Apply the incremental source patch against it on an isolated branch; if conflicts arise, stop rather than overwrite.
- Create an Azure DevOps pull request; never push directly or force-push to its default branch. Human PR review/merge remains required.
- After a successfully completed Azure sync PR, use its `ANCO1_SYNC_TO` SHA as the next incremental source cursor. Do not treat open, abandoned, or failed PRs as completed.
- Keep Azure access credential exclusively in GitHub Actions secret `AZURE_DEVOPS_PAT` with repository Code (Read & write) permission; never store the secret in the repository or a chat.

Implementation:
- `.github/workflows/azure-devops-sync.yml`
- `scripts/azure_devops_sync.py`

Consequence:
- The previously completed DHD feature is *not* synchronized retroactively by this workflow. A future new source commit after the baseline is required before a nonempty first release.
