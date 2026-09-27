# Business Logic

This file records durable Anco1 business behavior as it becomes verified. Anco1 is structurally similar to DalatHoa, but business logic must be established from Anco1 itself.

## Current domain map

### Pricing / price lists

**Status: Confirmed by current module structure**

The application contains multiple price-list screens such as `MD_00_BangGiaJQGS.aspx`, `MD_00_BangGia2JQGS.aspx`, and `MD_00_BangGia3JQGS.aspx`. This indicates pricing is a first-class business domain with multiple views/workflows.

**Important:** Exact rules for price selection, versioning, customer-specific pricing, transaction pricing, or fallback behavior are not yet documented here. Trace the relevant module JavaScript, JQGrid/JQGridModify handlers, Entity Framework objects, and shared pricing helpers before changing pricing behavior.

### Receivables / debt

**Status: Confirmed by current module structure**

The repository includes debt/receivables reporting such as `MD_00_BCcongnoHD.aspx` and entity/configuration names related to debt handling. Treat debt/payment changes as cross-module financial behavior until proven local.

### Production planning and production

**Status: Confirmed by current module structure**

The application contains production planning/reporting modules such as `MD_00_BaoCaoKeHoach.aspx` and `MD_00_BaoCaoSanXuat.aspx`, along with production-oriented entity names. Changes involving production orders, workshop allocation, capacity, or production status may affect multiple screens and reports.

### Inventory / material and product maintenance

**Status: Confirmed by current module structure**

The application contains inventory and material/product maintenance modules including `MD_00_BaoCaoXNTon.aspx` and `MD_00_BaoTriVatTuHangHoa.aspx`. Inventory changes should be checked for downstream effects on reports, orders, and production.

### Reports / printing

**Status: Confirmed**

Reporting is implemented across WebForms views/helpers and a separate `Report` project. A report change can involve data selection, server-side formatting, print/export helpers, and dedicated report project code.

### Product / BOM classification and expansion

**Status: Confirmed by project owner and database examples on 2026-09-27**

Product classification used by current BOM work:

- `sanpham = 1`: thành phẩm (TP).
- `ban_thanhpham = 1` and `vattu = 0` or `NULL`: bán thành phẩm (BTP).
- `ban_thanhpham = 1` and `vattu = 1`: hỗn hợp trộn.
- `vattu = 1`: vật tư trực tiếp; a direct material cannot contain another BOM.
- Legacy flags `khuon`, `son`, `muangoai` are no longer used for this classification.

BOM rules:

- TP, BTP, and hỗn hợp trộn may have BOMs; direct materials do not.
- A record may have multiple `md_sanpham_bom` versions. The applicable version is the one with the latest `ngay_hieuluc` (with deterministic ID ordering used as a tie-breaker in the report implementation).
- A TP BOM may contain BTP, hỗn hợp trộn, and direct materials.
- A BTP BOM may contain hỗn hợp trộn and direct materials.
- A hỗn hợp trộn BOM may contain another hỗn hợp trộn and direct materials.
- A hỗn hợp trộn without an applicable BOM is treated as a terminal material even though `ban_thanhpham = 1`.

BOM HHVT matrix report rule:

- The report does not expand BTP through the TP row. Each TP row contains only its own terminal direct/mixed-material requirements.
- Hỗn hợp trộn is recursively expanded until terminal material; quantities are multiplied along the mixture path and duplicate terminal material paths are summed.
- TP rows that reference the same BTP are grouped together. That BTP is emitted once as a representative row at the end of the TP group.
- The representative BTP row is calculated independently for one unit; its quantities are not multiplied by the number of TP rows that reference it.
- The output matrix places MAHH vertically and the union of material codes horizontally.

Implementation pointer:
- `eman_ver3/View/Print/MD_00_Baocaoketoan/BaoCaoBOMHHVT2.aspx.cs` (`CreateSql`, `BuildMatrix`, `BuildMatrixLayout`).

## Previously observed Anco1-specific logic

### Product price retrieval

**Status: Confirmed from prior project work; implementation must be re-read before further edits**

The application has a `getGiaSanPham(HttpContext context)` handler flow that reads `c_donhang_id` and `md_sanpham_id`, delegates pricing work to `UserUtils.get_giasanpham(...)`, and serializes the returned dictionary-like data to the HTTP response.

Where implemented:
- Locate the current handler containing `getGiaSanPham` before editing.
- Locate current `UserUtils.get_giasanpham` implementation and all callers.

Dependencies / effects:
- Sales/order entry behavior may depend on the exact response shape.
- Preserve backward compatibility of the JSON/text contract unless the client-side consumer is updated together.

### Order-line synchronization

**Status: Confirmed from prior project work; verify current database before consequential changes**

A database trigger named `dbo.updateDongDonHangWhenDonHangChanged` has been part of the Anco1 data flow and runs `AFTER UPDATE`. This means some order changes may have SQL-side downstream synchronization rather than being fully implemented in WebForms/C#.

Where implemented:
- SQL Server trigger `dbo.updateDongDonHangWhenDonHangChanged` in the relevant database.

Dependencies / effects:
- When modifying order header or order-line behavior, inspect this trigger and related SQL objects before assuming the C# code is the only source of side effects.

### Shared calculation SQL

**Status: Confirmed from prior project work; verify current database before edits**

The database has included function/procedure logic named `anco1410.f_tinhCBMMaHang` used in the project's SQL-side business layer.

Where implemented:
- SQL Server object `anco1410.f_tinhCBMMaHang`.

Rule:
- Do not replace or duplicate this calculation in application code without first tracing current callers and understanding the SQL-side contract.

## Knowledge gaps to fill during future work

The following areas are intentionally not guessed yet:

- exact order lifecycle/status transitions,
- exact customer/product price precedence,
- price version rules,
- payment/debt synchronization rules,
- production-order lifecycle,
- inventory posting rules,
- warehouse transfer behavior,
- relationships between Anco1 and any AncoTrading-specific entities.

When a future task establishes any of these, add a compact rule with status, implementation pointers, and dependencies rather than copying large code blocks.
