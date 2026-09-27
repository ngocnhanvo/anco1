# Anco1 Agent Guide

This repository contains the Anco1 system. The primary runtime application is the legacy ASP.NET WebForms application under `eman_ver3`.

Before making a non-trivial code change, read this file and the relevant documents in `docs/knowledge-base/`.

## Required reading order

1. `docs/knowledge-base/README.md`
2. `docs/knowledge-base/ARCHITECTURE.md`
3. `docs/knowledge-base/CONVENTIONS.md`
4. `docs/knowledge-base/BUSINESS_LOGIC.md` for the affected domain
5. `docs/knowledge-base/DECISIONS.md` when a task may affect established design choices

## Repository map

- `eman_ver3/`: main runtime WebForms application.
- `DataAccess/InfoDB/`: supporting C# data-access/library project referenced by the website solution.
- `GenerateModels/`: support/model-generation project; not the main runtime application.
- `Publish_GenerateModels/`: generated/published artifacts related to model generation; treat as support output rather than application business code unless the task explicitly targets it.
- `Report/`: separate C# report project included in the solution.
- `packages/`: legacy NuGet package directory checked into the repository.

## Working rules

- Inspect the current source before editing. Do not rely only on this documentation, DalatHoa, or prior chat context.
- Anco1 is structurally very similar to DalatHoa, but business rules must not be copied from DalatHoa without verification in Anco1.
- Current source code and the current database/schema are authoritative for executable behavior.
- Follow the existing WebForms, Entity Framework, jqGrid, ASPX, JavaScript, and legacy .NET Framework conventions unless a different design is explicitly approved.
- Preserve existing user changes. Fetch/read the current target file immediately before modifying it and make the smallest required edit.
- Do not invent business rules from names alone. Trace the complete relevant data flow and cross-module effects.
- Knowledge marked `Inferred` must be verified before consequential changes.
- Do not perform broad architectural rewrites as part of a local feature/fix unless explicitly approved.

## Knowledge-base maintenance

Every future task should leave durable knowledge behind when it establishes something that another agent would otherwise need to rediscover.

Update the appropriate file in `docs/knowledge-base/` when a task establishes a durable:

- architecture fact,
- implementation convention,
- business rule,
- cross-module dependency,
- or technical/product decision.

Do not add temporary debugging notes, speculative guesses, duplicated source code, or one-off implementation trivia.

Use the labels defined in `docs/knowledge-base/README.md`:

- **Confirmed**: explicitly confirmed by the project owner or established from authoritative current code/database behavior.
- **Inferred**: reasonable conclusion that still needs verification.

When possible, attach stable pointers such as file path, class, method, handler, table, or trigger name instead of copying implementation code into the knowledge base.
