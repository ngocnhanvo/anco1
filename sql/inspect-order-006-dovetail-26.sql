-- Read-only audit trail for the targeted purchase order and its production documents.
WITH matched AS (
 SELECT TOP (120)
   a.ngaytao,
   a.ad_module_id,
   a.ad_case_id,
   CASE WHEN a.mota LIKE N'%006/DOVETAIL-26%' THEN N'PO'
        WHEN a.mota LIKE N'%DSDH/2922/26%' THEN N'ORDER'
        WHEN a.mota LIKE N'%PVC/01359/26%' THEN N'TRANSFER'
        WHEN a.mota LIKE N'%LSX/00871/26%' THEN N'LSX-871'
        WHEN a.mota LIKE N'%LSX/00872/26%' THEN N'LSX-872'
        WHEN a.mota LIKE N'%LSX/00413/26%' THEN N'LSX-413' ELSE N'OTHER' END AS match_type,
   CAST(LEFT(COALESCE(a.mota,N''),180) AS nvarchar(180)) AS mo_ta_ngan
 FROM dbo.ad_log AS a
 WHERE (a.ngaytao >= '2026-10-14' AND a.ngaytao < '2026-10-29')
   AND (a.mota LIKE N'%006/DOVETAIL-26%' OR a.mota LIKE N'%DSDH/2922/26%'
     OR a.mota LIKE N'%PVC/01359/26%' OR a.mota LIKE N'%LSX/00871/26%'
     OR a.mota LIKE N'%LSX/00872/26%' OR a.mota LIKE N'%LSX/00413/26%')
 ORDER BY a.ngaytao DESC
)
SELECT CONVERT(nvarchar(19),ngaytao,120) AS thoi_diem, ad_module_id, ad_case_id, match_type, mo_ta_ngan
FROM matched
ORDER BY ngaytao ASC