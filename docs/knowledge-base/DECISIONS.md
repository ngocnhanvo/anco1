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
