# Architecture

## Scope

This document maps the current Anco1 architecture so future agents can identify the correct layer before changing code. It documents the legacy system as it exists; it is not a redesign proposal.

## Repository-level structure

### `eman_ver3/`

**Status: Confirmed**

Primary runtime application. It is a legacy ASP.NET WebForms website targeting .NET Framework 4.6.1 in the solution. The application uses server-side C#, Entity Framework-style mappings, jqGrid-oriented handlers/controllers, ASPX views, JavaScript module helpers, printing/report utilities, and additional legacy libraries.

### `DataAccess/InfoDB/`

**Status: Confirmed**

Supporting C# class library referenced by the website solution as `InfoDB.dll`. Treat changes here as shared data-access/infrastructure changes rather than local UI changes.

### `GenerateModels/`

**Status: Confirmed**

Support/model-generation project. It is not the main runtime application.

### `Publish_GenerateModels/`

**Status: Inferred**

Appears to contain generated/published output associated with the model-generation tooling. Verify its current role before editing or deleting contents.

### `Report/`

**Status: Confirmed**

Separate C# project included in `Anco1.sln`, used for reporting-related functionality.

### `packages/`

**Status: Confirmed**

Legacy NuGet package directory committed to the repository. Do not assume modern PackageReference conventions.

## Solution composition

**Status: Confirmed**

`Anco1.sln` contains:

- Web Site project `eman_ver3`
- `GenerateModels`
- solution folder `DataAccess`
- `DataAccess/InfoDB/InfoDB.csproj`
- `Report/Report.csproj`

The website references `InfoDB.dll`. Because this is a legacy Web Site project rather than a modern SDK-style ASP.NET application, changes to build/runtime behavior should preserve the existing solution conventions unless redesign is explicitly requested.

## Main application layers

### `eman_ver3/App_Code/ClassCalling/`

**Status: Confirmed**

Shared server-side helper layer. Current files include helpers/utilities such as `Helper.cs`, `HelperEntity.cs`, `EntityFunction.cs`, conversion utilities, JSON/update helpers, mail helpers, SQL helpers, and other shared functions.

A change here may affect many modules. Prefer module-local logic unless behavior is intentionally shared.

### `eman_ver3/App_Code/EntityFramework/`

**Status: Confirmed**

Contains Entity Framework context/mapping/entity classes used by the application. Persistence changes must be traced together with consuming handlers/controllers and database-side logic.

### `eman_ver3/App_Code/JQGrid/`

**Status: Confirmed**

Shared server-side jqGrid support classes/helpers.

### `eman_ver3/App_Code/Module/`

**Status: Confirmed by structure; exact responsibilities vary by module**

Contains module-oriented server-side application code. Inspect the relevant module before assuming responsibility boundaries.

### `eman_ver3/Controller/JQGrid/`

**Status: Confirmed by architectural similarity and current structure**

Primary read/query side for jqGrid-oriented screens: row retrieval, filtering, sorting, paging, and related operations.

### `eman_ver3/Controller/JQGridModify/`

**Status: Confirmed by architectural similarity and current structure**

Primary mutation side for jqGrid-oriented screens: add, edit, delete, and custom modifying actions.

### `eman_ver3/Controller/JQGridCustom/`

**Status: Confirmed by structure; exact semantics must be inspected per task**

Contains custom jqGrid handlers that do not fit the normal read/modify split.

### `eman_ver3/Controller/PublicFunction/`

**Status: Confirmed by structure**

HTTP-facing/shared function handlers. Because these can be reused across modules, trace callers before changing behavior.

### `eman_ver3/js/Module_script/`

**Status: Confirmed**

Module-specific browser-side logic.

### `eman_ver3/js/Custom_Grid_script/`

**Status: Confirmed**

Reusable client-side jqGrid helpers shared across modules. Changes here have potentially wide blast radius.

### `eman_ver3/js/Public_script/` and `eman_ver3/js/VNN_script/`

**Status: Confirmed by structure**

Shared browser-side scripts/utilities. Inspect actual consumers before modifying.

### `eman_ver3/View/Menu/Content/Module/`

**Status: Confirmed**

Main ASPX module view directory. Current modules visibly cover domains such as price lists, receivables/debt reporting, production planning, production reports, inventory in/out/stock reporting, and material/product maintenance.

### `eman_ver3/View/Print/` and reporting areas

**Status: Confirmed by structure**

Printing/report output is spread across the WebForms app plus the separate `Report` project and report-related helpers. When modifying reports, trace both view/template logic and the supporting project/helper code.

## Typical feature flow

**Status: Confirmed at architectural level**

A common jqGrid feature flow is:

```text
ASPX module view
    ↓
module JavaScript / shared grid JavaScript
    ↓
Controller/JQGrid           -> read/search/sort/paging
Controller/JQGridModify     -> add/edit/delete/custom mutation
Controller/JQGridCustom     -> module-specific custom HTTP actions when applicable
    ↓
App_Code shared/module logic / Entity Framework / InfoDB
    ↓
SQL Server database
```

Not every feature follows this exact route. Always locate the actual call chain for the target module.

## Relationship to DalatHoa

**Status: Confirmed by repository comparison**

Anco1 and DalatHoa share the same broad legacy architecture: WebForms under `eman_ver3`, jqGrid controllers, module JavaScript, shared grid helpers, ASPX module views, Entity Framework mappings, and shared helper code.

This similarity is useful for navigation and implementation conventions only. Business rules, entity sets, status flows, pricing behavior, order logic, production logic, and database-side behavior must be verified independently in Anco1.

## Change-risk guidance

### Lower/local risk

Usually includes:

- view-only presentation changes,
- module-specific JavaScript,
- narrowly scoped handler/controller conditions.

### Higher/shared risk

Usually includes:

- `App_Code/ClassCalling`,
- `App_Code/EntityFramework`,
- `DataAccess/InfoDB`,
- `js/Custom_Grid_script`,
- shared controller helpers,
- SQL triggers/functions/procedures,
- order/pricing/payment/production/inventory synchronization,
- report infrastructure shared by multiple modules.

For higher-risk changes, trace upstream callers and downstream effects before editing.

## Architectural principle for future work

Preserve the existing local pattern unless redesign is explicitly approved. A feature request in one WebForms/jqGrid module should not silently introduce a new architecture, ORM abstraction, service framework, frontend state-management system, or broad refactor.
