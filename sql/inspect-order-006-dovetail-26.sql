-- Read-only inspection of supplier purchase orders for specific PO.
WITH targetplan AS (
 SELECT c_kehoachdathang_id FROM dbo.c_kehoachdathang
 WHERE LTRIM(RTRIM(donhang_thamchieu))=N'006/DOVETAIL-26'
)
SELECT TOP (50)
 p.sochungtu,
 p.so_donmuahang,
 p.md_trangthai_id AS trangthai_mua_hang,
 CONVERT(nvarchar(19),p.ngaytao,120) AS ngaytao,
 CONVERT(nvarchar(19),p.ngayhieuluc,120) AS ngayhieuluc,
 CASE WHEN EXISTS (SELECT 1 FROM targetplan k WHERE k.c_kehoachdathang_id=p.c_kehoachdathang_dhncc_id)
      THEN N'LIEN_KET_KE_HOACH'
      WHEN LTRIM(RTRIM(p.donhang_thamchieu))=N'006/DOVETAIL-26'
      THEN N'THAM_CHIEU_PO'
      ELSE N'THAM_CHIEU_CHUNG_TU' END AS loai_lien_ket
FROM dbo.c_donmuahang p
WHERE EXISTS (SELECT 1 FROM targetplan k WHERE k.c_kehoachdathang_id=p.c_kehoachdathang_dhncc_id)
   OR LTRIM(RTRIM(p.donhang_thamchieu))=N'006/DOVETAIL-26'
   OR CHARINDEX(N'006/DOVETAIL-26',COALESCE(p.sctdathang,N''))>0
ORDER BY p.ngaytao,p.sochungtu