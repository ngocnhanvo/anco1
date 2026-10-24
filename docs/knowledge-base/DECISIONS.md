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

**Status: Updated at the explicit request of the project owner on 2026-10-24. Supersedes the earlier manual-only rule.**

Decision:
- GitHub `ngocnhanvo/anco1` (`master`) remains the development source of truth; Azure DevOps `vongocnhancd10cntt2/Anco1/_git/Anco1` is the receiving repository.
- **Automatic synchronization** now runs on GitHub `master` pushes affecting code paths plus an hourly catch-up check. Routine sync no longer requires manually running `workflow_dispatch`; manual preview/create-pr remain available for diagnosis.
- The irreversible historical exclusion cutoff remains `1e614269073c8f60bdfcdbfc1570ecd7588a2d20`. This commit and all earlier GitHub commits are excluded. Only changed source paths in the allowlist `scripts/azure_devops_sync.py` are eligible (not docs, knowledge, CI, workflow changes or synchronization scripts).
- The sync bot **creates an incremental Azure Pull Request from the current Azure default branch**, then enables PR auto-complete if Azure accepts it. Auto-complete must honor required Azure branch policies and reviews; **no policy bypass** is permitted.
- **Never** mirror/overwrite Azure history, force-push, or push directly into Azure's default branch. Conflicts abort synchronization. Only completed Azure PRs advance the source cursor; PRs that remain open must not result in duplicate PRs or premature cursor advancement.
- Concurrent pushes are serialized; scheduled retries pick up source changes that arrive while an earlier PR remains open. Stale runs must not regress the cursor.
- Keep the Azure credential exclusively in GitHub Actions secret `AZURE_DEVOPS_PAT` with the necessary code/PR permissions.

Implementation:
- `.github/workflows/azure-devops-sync.yml`
- `scripts/azure_devops_sync.py`
- `docs/AZURE_DEVOPS_SYNC.md`

Consequence:
- This is **automatic source synchronization**, not an application build/deploy to IIS or FTP. The Azure default branch advances only once its PR completes under the Azure branch policies.
