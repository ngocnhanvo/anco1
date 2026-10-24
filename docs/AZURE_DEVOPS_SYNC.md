# Anco1: GitHub -> Azure DevOps (manual, incremental release)

## Source and destination

- Development: `https://github.com/ngocnhanvo/anco1`, branch `master`.
- Destination: `https://dev.azure.com/vongocnhancd10cntt2/Anco1/_git/Anco1`.
- Fixed *exclusive* cutoff: `1e614269073c8f60bdfcdbfc1570ecd7588a2d20`.
- This commit and all older GitHub commits are **never** included in an Azure release.
- Previously committed DHD status-transition changes are therefore not included in the first new release.

## Initial permissions

Create an Azure DevOps PAT (scope `Code: Read & write`) restricted to the correct organization. The identity must have permission to create branches and pull requests in the Anco1 Azure Repos repository.

Add it to GitHub repository **Settings > Secrets and variables > Actions** as the secret `AZURE_DEVOPS_PAT`. Never commit a token or send it in chat.

## Release procedure

1. Finish and test new source commits on GitHub `master`.
2. Run **Actions > Anco1 - approved GitHub changes to Azure DevOps > Run workflow**.
3. Select `preview`, verify the source commit range and affected file count.
4. Run again with `create-pr` after the owner approves the release.
5. Review the new Azure DevOps pull request, check for unrelated modifications, and merge there.
6. The next run discovers the last **completed** Azure sync PR and uses its GitHub source SHA as the next cursor.

The workflow skips documentation, CI files, and sync infrastructure itself. Source code paths are allowlisted in `scripts/azure_devops_sync.py`.

A pending Azure sync PR blocks another release. Divergent source files or patch conflicts stop the job. There is **no force push** and **no automatic merge** of Azure's default branch.

If GitHub has no eligible source changes after the cutoff or the last completed sync PR, the workflow reports that there is nothing to transfer. It does not copy earlier files to create an artificial delta.

## Troubleshooting

- `Missing GitHub Actions secret AZURE_DEVOPS_PAT`: add or renew the secret.
- `Azure sync PR is still active`: merge or abandon that PR first.
- `git operation failed` while applying the patch: inspect conflicts in the Azure destination. Do not force overwrite; reconcile the target and retry.
- Empty release: there are no new eligible source-code changes since the last approved sync cursor.

Implementation:
- `.github/workflows/azure-devops-sync.yml`
- `scripts/azure_devops_sync.py`
