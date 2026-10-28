-- Read-only status trace for the single PO 006/DOVETAIL-26; no customer, product, user, or quantity data exported.
WITH target AS (
    SELECT d.c_danhsachdathang_id, d.so_po, d.sochungtu,
           d.trangthai, d.md_trangthai_id, d.ngayhieuluc, d.ngaytao, d.ngaycapnhat
    FROM dbo.c_danhsachdathang AS d
    WHERE LTRIM(RTRIM(d.so_po)) = N'006/DOVETAIL-26'
),
plans AS (
    SELECT k.c_kehoachdathang_id, k.c_danhsachdathang_id, k.sodonhang,
           k.donhang_thamchieu, k.trangthai, k.trangthaiSav, k.xulykehoach,
           k.nhomKH, k.ngaytao, k.ngaycapnhat
    FROM dbo.c_kehoachdathang AS k
    WHERE EXISTS (SELECT 1 FROM target AS d WHERE d.c_danhsachdathang_id = k.c_danhsachdathang_id)
       OR LTRIM(RTRIM(k.donhang_thamchieu)) = N'006/DOVETAIL-26'
),
workshop AS (
    SELECT p.md_dondathangphanxuong_id, p.c_kehoachdathang_id,
           p.sochungtu, p.donhang_thamchieu, p.md_trangthai_id,
           p.ngaytao, p.ngaycapnhat
    FROM dbo.md_dondathangphanxuong AS p
    WHERE EXISTS (SELECT 1 FROM plans AS k WHERE k.c_kehoachdathang_id = p.c_kehoachdathang_id)
       OR LTRIM(RTRIM(p.donhang_thamchieu)) = N'006/DOVETAIL-26'
),
production AS (
    SELECT l.md_lenhsanxuat_id, l.md_dondathangphanxuong_id,
           l.c_kehoachdathang_id, l.donhang_thamchieu, l.sochungtu,
           l.md_trangthai_id, l.ngaytao, l.ngaycapnhat
    FROM dbo.md_lenhsanxuat AS l
    WHERE EXISTS (SELECT 1 FROM plans AS k WHERE k.c_kehoachdathang_id = l.c_kehoachdathang_id)
       OR EXISTS (SELECT 1 FROM workshop AS p WHERE p.md_dondathangphanxuong_id = l.md_dondathangphanxuong_id)
       OR LTRIM(RTRIM(l.donhang_thamchieu)) = N'006/DOVETAIL-26'
),
records AS (
    SELECT 1 AS thu_tu, N'DON_HANG' AS loai,
           CAST(d.so_po AS nvarchar(200)) AS chungtu,
           CAST(d.trangthai AS nvarchar(100)) AS trangthai,
           CAST(d.md_trangthai_id AS nvarchar(100)) AS trangthai_phu,
           CONVERT(nvarchar(19), d.ngaytao, 120) AS ngaytao,
           CONVERT(nvarchar(19), d.ngaycapnhat, 120) AS ngaycapnhat,
           CONCAT(N'SoChungTu=', COALESCE(d.sochungtu,N''), N'; NgayHieuLuc=',COALESCE(CONVERT(nvarchar(19),d.ngayhieuluc,120),N'')) AS thongtin
    FROM target AS d
    UNION ALL
    SELECT 2, N'KE_HOACH', CAST(k.donhang_thamchieu AS nvarchar(200)),
           CAST(k.trangthai AS nvarchar(100)), CAST(k.trangthaiSav AS nvarchar(100)),
           CONVERT(nvarchar(19),k.ngaytao,120),CONVERT(nvarchar(19),k.ngaycapnhat,120),
           CONCAT(N'XuLyKeHoach=', CASE WHEN k.xulykehoach=1 THEN N'1' WHEN k.xulykehoach=0 THEN N'0' ELSE N'NULL' END,
                  N'; NhomKH=',COALESCE(k.nhomKH,N''),N'; SoDonHang=',COALESCE(k.sodonhang,N''))
    FROM plans AS k
    UNION ALL
    SELECT 3, N'DON_PHAN_XUONG', CAST(p.sochungtu AS nvarchar(200)),
           CAST(p.md_trangthai_id AS nvarchar(100)), N'',
           CONVERT(nvarchar(19),p.ngaytao,120),CONVERT(nvarchar(19),p.ngaycapnhat,120),
           CONCAT(N'ThamChieu=',COALESCE(p.donhang_thamchieu,N''))
    FROM workshop AS p
    UNION ALL
    SELECT 4, N'LENH_SAN_XUAT', CAST(l.sochungtu AS nvarchar(200)),
           CAST(l.md_trangthai_id AS nvarchar(100)), N'',
           CONVERT(nvarchar(19),l.ngaytao,120),CONVERT(nvarchar(19),l.ngaycapnhat,120),
           CONCAT(N'SoToSX=',(SELECT COUNT(*) FROM dbo.md_lenhsanxuat_tosx AS t WHERE t.md_lenhsanxuat_id=l.md_lenhsanxuat_id AND (t.stt IS NULL OR t.stt<>9999)),
                  N'; ToSXCheckHoanThanh=',(SELECT COUNT(*) FROM dbo.md_lenhsanxuat_tosx AS t WHERE t.md_lenhsanxuat_id=l.md_lenhsanxuat_id AND t.check_hoanthanh=1))
    FROM production AS l
    UNION ALL
    SELECT 5, N'LENH_SAN_XUAT_CHI_TIET', CAST(l2.sochungtu AS nvarchar(200)),
           CAST(l2.trangthai AS nvarchar(100)), N'',
           CONVERT(nvarchar(19),l2.ngayhoanthanh,120),N'',
           N''
    FROM dbo.md_lenhsanxuat2 AS l2
    WHERE EXISTS (SELECT 1 FROM target AS d WHERE d.c_danhsachdathang_id = l2.c_danhsachdathang_id)
       OR EXISTS (SELECT 1 FROM plans AS k WHERE k.c_kehoachdathang_id = l2.c_kehoachdathang_id)
)
SELECT TOP (200) loai,chungtu,trangthai,trangthai_phu,ngaytao,ngaycapnhat,thongtin
FROM records
ORDER BY thu_tu,chungtu