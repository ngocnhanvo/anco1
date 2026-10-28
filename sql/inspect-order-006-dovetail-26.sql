-- Read-only timing evidence for the last transition to processed BTP stage.
WITH khplan AS (
 SELECT k.c_kehoachdathang_id,k.c_danhsachdathang_id,k.trangthai,k.trangthaiSav,k.ngaybatdausx,k.ngaytao,k.ngaycapnhat,k.xulykehoach,k.tinhNCVT,k.nhomKH
 FROM dbo.c_kehoachdathang AS k WHERE LTRIM(RTRIM(k.donhang_thamchieu))=N'006/DOVETAIL-26'
),
order_lines AS (
 SELECT c.*,l.c_kehoachdathang_id FROM dbo.md_lenhsanxuat_tosx_cdh c JOIN dbo.md_lenhsanxuat l
 ON l.md_lenhsanxuat_id=c.md_lenhsanxuat_id WHERE EXISTS (SELECT 1 FROM khplan p WHERE p.c_kehoachdathang_id=l.c_kehoachdathang_id)
)
SELECT TOP (10)
 p.trangthai AS kh_trangthai,p.trangthaiSav AS kh_trangthaiSav,
 CONVERT(nvarchar(19),p.ngaybatdausx,120) AS kh_ngaybatdausx,
 CONVERT(nvarchar(19),p.ngaytao,120) AS kh_ngaytao,
 CONVERT(nvarchar(19),p.ngaycapnhat,120) AS kh_ngaycapnhat,
 CONVERT(nvarchar(19),d.ngaybatdau,120) AS dh_ngaybatdau,
 CAST(p.xulykehoach AS nvarchar(8)) AS xulykehoach,
 CAST(p.tinhNCVT AS nvarchar(8)) AS tinhNCVT,
 p.nhomKH,
 (SELECT COUNT(*) FROM order_lines c WHERE NULLIF(LTRIM(RTRIM(c.lsxCT)),N'') IS NOT NULL) AS dong_da_gan_lsx,
 (SELECT COUNT(*) FROM order_lines c WHERE c.stt=9998 AND (c.sl_layton IS NOT NULL OR c.sl_nhapkho IS NOT NULL)) AS dong_co_thong_tin_layton_btp
FROM khplan p JOIN dbo.c_danhsachdathang d ON p.c_danhsachdathang_id=d.c_danhsachdathang_id