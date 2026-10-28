-- Read-only verification of deletion handler and other transfers tied to target plan.
WITH kh AS (
 SELECT c_kehoachdathang_id,c_danhsachdathang_id FROM dbo.c_kehoachdathang
 WHERE LTRIM(RTRIM(donhang_thamchieu))=N'006/DOVETAIL-26'
),
rows AS (
 SELECT 1 AS ord,N'AUDIT_ACTION' AS nhom,
 CAST(CONVERT(nvarchar(19),lg.ngaytao,120) AS nvarchar(100)) AS thoi_diem,
 CAST(COALESCE(m.ma_module,N'MODULE_UNKNOWN') AS nvarchar(180)) AS module,
 CAST(COALESCE(c.ma_case,N'CASE_UNKNOWN') AS nvarchar(180)) AS hanh_dong,
 CAST(LEFT(COALESCE(lg.mota,N''),240) AS nvarchar(500)) AS chi_tiet
 FROM dbo.ad_log lg
 LEFT JOIN dbo.ad_module m ON m.ad_module_id=lg.ad_module_id
 LEFT JOIN dbo.ad_case c ON c.ad_case_id=lg.ad_case_id
 WHERE lg.ngaytao>='2026-10-21T09:10:00' AND lg.ngaytao<'2026-10-21T09:20:00'
 AND lg.mota LIKE N'%PVC/01386/26%'
 UNION ALL
 SELECT 2,N'ALL_PVC_OF_PLAN',
 CAST(CONVERT(nvarchar(19),v.ngayhieuluc,120) AS nvarchar(100)),
 CAST(v.sochungtu AS nvarchar(180)),
 CAST(v.loaichuyen AS nvarchar(180)),
 CAST(CONCAT(N'Status=',COALESCE(v.md_trangthai_id,N''),
    N' KH=',COALESCE(v.c_doichieuhangton_id,N''),
    N' Ref=',COALESCE(v.donhang_thamchieu,N''),
    N' NgayTao=',COALESCE(CONVERT(nvarchar(19),v.ngaytao,120),N'')) AS nvarchar(500))
 FROM dbo.md_vanchuyennoibo v WHERE EXISTS
 (SELECT 1 FROM kh WHERE kh.c_kehoachdathang_id=v.c_doichieuhangton_id)
 UNION ALL
 SELECT 3,N'ORDER_LOG_28_OCT',
 CAST(CONVERT(nvarchar(19),lg.ngaytao,120) AS nvarchar(100)),
 CAST(COALESCE(m.ma_module,N'') AS nvarchar(180)),
 CAST(COALESCE(c.ma_case,N'') AS nvarchar(180)),
 CAST(LEFT(COALESCE(lg.mota,N''),180) AS nvarchar(500))
 FROM dbo.ad_log lg
 LEFT JOIN dbo.ad_module m ON m.ad_module_id=lg.ad_module_id
 LEFT JOIN dbo.ad_case c ON c.ad_case_id=lg.ad_case_id
 WHERE lg.ngaytao>='2026-10-28T14:10:00' AND lg.ngaytao<'2026-10-28T14:12:00'
 AND lg.mota LIKE N'%006/DOVETAIL-26%'
)
SELECT TOP (100) ord,nhom,thoi_diem,module,hanh_dong,chi_tiet FROM rows ORDER BY ord,thoi_diem