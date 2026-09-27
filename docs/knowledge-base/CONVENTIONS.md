# Conventions

These conventions describe how to work safely inside Anco1's existing legacy architecture.

## General change strategy

**Status: Confirmed**

- Prefer minimal, local changes over broad refactors.
- Inspect the current target file immediately before editing it.
- Preserve existing user changes and formatting unless the task requires otherwise.
- Follow the current module's established style before introducing a different pattern.
- Do not modernize unrelated code as part of a feature/fix.
- DalatHoa may be used as an architectural reference, not as a source of unverified Anco1 business rules.

## Layer responsibilities

**Status: Confirmed at architectural level**

- `Controller/JQGrid`: read/query/search/sort/paging behavior for jqGrid modules.
- `Controller/JQGridModify`: add/edit/delete and custom mutation actions.
- `Controller/JQGridCustom`: custom jqGrid-oriented actions outside the normal read/modify split.
- `js/Module_script`: module-specific client behavior.
- `js/Custom_Grid_script`: reusable grid/client helpers shared by multiple modules.
- `View/Menu/Content/Module`: ASPX views for application modules.
- `App_Code/ClassCalling`: shared server-side helpers/functions/configuration.
- `App_Code/EntityFramework`: context/entities mapping the database.
- `DataAccess/InfoDB`: shared data-access/library code referenced by the website.

When adding logic, place it in the narrowest layer that matches its responsibility. Avoid putting one-module behavior into shared helpers unless reuse is real and intentional.

## jqGrid module workflow

**Status: Confirmed at convention level**

When changing a jqGrid screen, trace all relevant parts instead of editing only the visible layer:

1. ASPX view markup/configuration.
2. Module JavaScript.
3. Shared grid JavaScript if used.
4. Read controller under `Controller/JQGrid`.
5. Mutation controller under `Controller/JQGridModify`.
6. Custom handler under `Controller/JQGridCustom` when applicable.
7. Shared/module server code and Entity Framework mappings.
8. `InfoDB` and database-side behavior such as triggers/functions/procedures when applicable.

A UI symptom may originate from server-side data or database side effects, and a server-side mutation may require client refresh/state handling.

## Shared-code caution

**Status: Confirmed**

Changes in shared locations have potentially wide effects:

- `App_Code/ClassCalling`
- `App_Code/EntityFramework`
- `DataAccess/InfoDB`
- `js/Custom_Grid_script`
- shared public/controller helpers
- SQL triggers/functions/procedures

Before changing shared code, identify current consumers and confirm the requested behavior should apply to all of them.

## Database and generated models

**Status: Confirmed**

- Do not infer business meaning from a column/property name alone.
- Trace where the field is read, written, recalculated, and synchronized.
- Entity classes under `App_Code/EntityFramework/Objects` may be generated or regenerated; determine whether a change belongs in generation tooling/schema instead of hand-editing generated output.
- `GenerateModels` is support tooling, not the main application.
- Database backups/artifacts are not source code and should not be reintroduced into Git history unless explicitly needed.

## Business-rule changes

**Status: Confirmed**

For a change that affects business behavior:

1. Identify the authoritative Anco1 rule from current code/database or project-owner confirmation.
2. Trace all code paths that can trigger the behavior.
3. Make the narrowest consistent change.
4. Check reverse synchronization or dependent modules.
5. Update `BUSINESS_LOGIC.md` when durable knowledge is established.

## Testing and validation

**Status: Confirmed as working practice**

Validation should match the blast radius of the change:

- local UI changes: verify the affected module and relevant browser behavior;
- controller changes: verify success and rejection/validation paths;
- shared helpers: verify known consumers;
- pricing/order/payment/production/inventory changes: verify dependent calculations and reverse/synchronization paths where they exist;
- SQL-side changes: verify relevant INSERT/UPDATE/DELETE semantics and unrelated records;
- report changes: verify data selection plus rendered/exported output.

If the project owner explicitly performs manual testing, do not block implementation on unrelated automated-test work. Still inspect the final diff and clearly note unverified runtime behavior.
