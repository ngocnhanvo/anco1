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

#### Excel templates: merged-cell wrap comments

**Status: Confirmed from source (2026-10-10); Windows Excel Interop rendering still requires manual verification**

- A template cell comment `wrapN` (e.g. `wrap7`) marks a text placeholder whose printable area spans `N` columns. `ExcelExportData.cs` reads this comment and sets `lstTextReplace.wrap_Mer` / `column_Mer`.
- `ExcelConverter.cs` handles this only in the Excel Interop path: it measures the combined width in points, applies the replacement text and formatting to a single unmerged cell on a temporary worksheet, calls `AutoFit` there, and assigns the resulting height (never below the original height) to the source row. The temporary worksheet must be deleted before saving/exporting.
- The production order printing view `View/Print/MD_00_LenhSanXuatKH/lenhSanXuat.aspx.cs` uses this path for `inPDF=2/3` (Excel/PDF from the XLS template); DevExpress viewer routes `inPDF=0/1` do not use the XLS `wrapN` mechanism.

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

### Finished-product stock take and BOM deduction

**Status: Confirmed by project owner and current code on 2026-10-03**

The finished-product stock-take flow after BOM calculation is:

- `MD_01_KHLayTon / CA_01_TinhLayTonThanhPham2KH` calculates available TP stock across configured `KHOTONTP` warehouses for the production-plan TP rows (`md_lenhsanxuat_tosx.stt == 9999`).
- The user chooses the planned stock-take quantity (`sl_dklt`).
- `MD_01_KHLayTon / CA_01_LayTonThanhPhamKH2` creates `VANCNBTC` internal-transfer requests. When one TP is distributed across multiple source warehouses, the requested quantity is split into separate `md_vanchuyennoibo` documents per warehouse.
- `MD_00_PVCNoiBo / CA_01_XuLyVanChuyen` makes each transfer effective, moves the actual quantity from the source warehouse to the destination warehouse, and reduces downstream BOM/production requirements through `Public.HieuLucPhieuVanChuyen` and `Public.truVatTuSauKhiLayTon`.

Critical quantity rule:

- `md_lenhsanxuat_tosx_dklhttp.sl_layton1` is the **cumulative** actual TP quantity already approved/taken from stock.
- BOM reduction for each effective PVC must use only the **incremental actual quantity on that PVC**, never the cumulative `sl_layton1` value.
- Example: 32 TP require one unit of BTP `74-11003` each. If 6 TP are taken from stock as two PVCs of 5 and 1, remaining BTP demand is `32 - (5 + 1) = 26`. The second PVC must reduce BOM by 1, not by cumulative 6; otherwise the system incorrectly reduces by `5 + 6 = 11` and leaves only 21.
- The cumulative `sl_layton1` must still end at 6 after both PVCs are approved.

Current implementation protection:

- `eman_ver3/Controller/JQGridModify/JQGridMD_00_PVCNoiBoModify.ashx` (`CA_01_XuLyVanChuyen`) preserves the prior cumulative `sl_layton1`, lets the shared effect logic process only the current PVC quantity for BOM deduction, then restores the prior cumulative amount within the same database transaction before commit.
- `eman_ver3/App_Code/ClassCalling/Public.cs` (`HieuLucPhieuVanChuyen`, `truVatTuSauKhiLayTon`) remains the shared inventory/BOM effect path and must not be changed back to deduct cumulative stock-take quantities.

Status transition:

- For a TP stock-take group spanning multiple PVCs, the production plan/order advances to `DaXLTTP` only after all PVC document numbers referenced by `phieulayhttp` are `HIEULUC`.

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
- inventory posting rules beyond the verified TP stock-take flow above,
- warehouse transfer behavior beyond the verified TP stock-take flow above,
- relationships between Anco1 and any AncoTrading-specific entities.

When a future task establishes any of these, add a compact rule with status, implementation pointers, and dependencies rather than copying large code blocks.


### Bulk activation of draft products

**Status: Confirmed by project owner (2026-10-13), implemented in current source; requires runtime acceptance testing**

- Module `MD_00_DSHangHoa_SOANTHAO`, case `CA_01_ChuyenTrangThaiST`: users can filter the jqGrid and activate **all matching rows across all pages**, not just checked/current-page rows.
- Only `md_sanpham` records still in `SOANTHAO` are changed. Activation sets `trangthai = "DHD"` and `hoatdong = true`, and updates standard audit fields.
- The action requires a nonempty jqGrid filter and case-level permission. The server evaluates the module SQL and role-level restrictions, previews match/eligible counts, rechecks the set before execution, and commits the batch in one database transaction.
- Records outside the filter and records already in other states are not changed; a stale preview aborts rather than silently applying to a different set.
- Implementation: `eman_ver3/js/Module_script/MD_00_DSHangHoa_SOANTHAO.js` and `eman_ver3/Controller/JQGridModify/JQGridMD_00_DSHangHoa_SOANTHAOModify.ashx`.


### Draft product Excel export: BOM raw code and AncoTrading packaging

**Status: Confirmed by owner plus direct read-only SQL Server inspection (2026-10-24); the business interpretation of Mã thô and whether multiple defaults should be combined remains for product review.**

- Module `MD_00_DSHangHoa_SOANTHAO`, case `CA01ExportHHVG_MD00DSHangHoaSOANTHAO`: Excel `Mã thô` must come from BOM relations `md_sanpham_bom` and `md_sanpham_bom_vattu` joined to `md_sanpham` for child codes, not from splitting `ma_sanpham` or treating `ma_sanphamcu` as the raw code.
- Current SQL **review draft** chooses the newest BOM with nonempty `ten_phienban` (`ngay_hieuluc DESC`, BOM ID tie-break), as used by `BaoCaoBOMHHVT2.aspx.cs`, and concatenates distinct direct BTP child codes. Verify whether `Mã thô` needs direct BTP versus recursively expanded raw material before production.
- All packaging data for this Excel comes from **`md_donggoi_ancotrading` and `md_donggoisanpham_ancotrading`** (confirmed source tables); do not confuse these with `md_donggoi` / sales-order line packaging data.
- SQL Server metadata provided in `Results3.csv` confirms `md_donggoi_ancotrading` fields `sl_inner`, `dvt_inner`, `l1/w1/h1`, `sl_outer`, `dvt_outer`, `l2_mix/w2_mix/h2_mix`, `soluonggoi_ctn_20`, `soluonggoi_ctn`, `soluonggoi_ctn_40hc`, `ngayxacnhan`, `trangthai`, `mota`; and `md_donggoisanpham_ancotrading` fields `md_sanpham_id`, `md_donggoi_id`, `macdinh`, `hoatdong`. Direct SQL Server inspection confirms the linkage via `ds.md_donggoi_id = p.md_donggoi_id`: all 18 draft products in the verified snapshot had exactly one active/default matching package. No FK is declared for these tables (`sys.foreign_keys=0`), so source and data checks must enforce cardinality. The export uses single-row `OUTER APPLY`, prioritizing `macdinh=1` then latest metadata, rather than a raw one-to-many JOIN.
- **Packaging UOM dictionary verified against SQL Server**: `md_donggoi_ancotrading.dvt_inner` and `.dvt_outer` store GUIDs referencing **`md_donvitinh.md_donvitinh_id`**, not `md_donvitinhsanpham`. Export must select `md_donvitinh.ten_dvt`; representative actual labels include `pc/bun`, `set/bun`, `pcs/pal`, `sets/pal`. The source offers `md_donvitinh` EF mapping; 30 distinct packaging UOM role+ID pairs were tested and resolved.
- **Draft BOM snapshot**: no `md_sanpham_bom` is attached to the 18 SOANTHAO products checked, so `Mã thô` is blank for every draft row. Latest BOM component counts on DHD products show direct BTP children do exist (8,998 parent products); empty SOANTHAO raw-code output is a data condition, not evidence of a broken SQL JOIN. Exact raw-code business definition still needs verification if it is intended to include recursively expanded materials.
- The actual module's `ad_column` configuration maps `Thể Tích` provisionally to `sp.v2` (named `CBM mặc định`), `Tên kiểu dáng` to `md_kieudang_ancotrading.ten_tv`, and `Tên chức năng` to `md_chucnang_ancotrading.ten_tv`. The actual `ad_module.where_sql` restricts draft results to `vattu=0`, `(sanpham=1 OR ban_thanhpham=1)`, and `trangthai='SOANTHAO'`; exporter must additionally preserve per-role and jqGrid filtering.
- **Verified source-null audit (2026-10-24, 18 SOANTHAO rows):** `sp.v2`, `sp.ghichu`, `sp.dinhkhoan`, `sp.md_nhomnangluc_id`, `sp.khomacdinh`, `sp.khoton`, `sp.phongbanId`, and `sp.md_thue_sanpham_id` were NULL/empty in every row. Their corresponding Excel cells are legitimately empty in this data snapshot; this is not a SQL join failure.
- **Unresolved NCC reference (2026-10-24):** `sp.nhacungung` is populated in all 18 draft products (same 32-character ID), but `md_doitackinhdoanh` has no matching row on ID, `ma_dtkd`, or `ten_dtkd` for that value. Consequently the draft query emits blank `NCC mặc định` despite populated source. Do not silently treat this as validated; investigate the correct dictionary or repair orphaned reference data before considering export complete. The check is read-only, and no database update was performed.
- The owner removed four hidden Excel columns `vd`, `vn`, `vl`, `ghichu_vachngan`. Output must contain **37 columns**.
- SQL draft and schema inspection queries: `docs/sql/MD_00_DSHangHoa_SOANTHAO_ExportHHVG_DRAFT.sql`; implementation plan: `docs/MD_00_DSHangHoa_SOANTHAO_ExcelExport_PLAN.md`.
