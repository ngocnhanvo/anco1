-- Read-only, targeted chronology of production orders and BTP stock transfer for 006/DOVETAIL-26.
WITH target AS (
    SELECT c_danhsachdathang_id,sochungtu,so_po FROM dbo.c_danhsachdathang
    WHERE LTRIM(RTRIM(so_po)) = N'006/DOVETAIL-26'
),
plans AS (
    SELECT k.c_kehoachdathang_id,k.trangthai,k.nhomKH
    FROM dbo.c_kehoachdathang AS k
    WHERE EXISTS (SELECT 1 FROM target AS d WHERE d.c_danhsachdathang_id=k.c_danhsachdathang_id)
       OR LTRIM(RTRIM(k.donhang_thamchieu))=N'006/DOVETAIL-26'
),
lsx AS (
    SELECT l.md_lenhsanxuat_id,l.sochungtu FROM dbo.md_lenhsanxuat AS l
    WHERE EXISTS (SELECT 1 FROM plans AS k WHERE l.c_kehoachdathang_id=k.c_kehoachdathang_id)
),
teams AS (
    SELECT t.md_lenhsanxuat_tosx_id,t.stt,t.phieulayht,t.phieulayhttp,t.md_lenhsanxuat_id
    FROM dbo.md_lenhsanxuat_tosx AS t
    WHERE EXISTS (SELECT 1 FROM lsx AS l WHERE t.md_lenhsanxuat_id=l.md_lenhsanxuat_id)
),
transfers AS (
    SELECT DISTINCT v.md_vanchuyennoibo_id,v.sochungtu,v.md_trangthai_id,
           v.laytonTP,v.laytonTPhoacBTP,v.ngaytao,v.ngaycapnhat,v.ngayhieuluc,
           v.donhang_thamchieu
    FROM dbo.md_vanchuyennoibo AS v
    WHERE LTRIM(RTRIM(v.donhang_thamchieu))=N'006/DOVETAIL-26'
       OR EXISTS (
           SELECT 1 FROM teams AS t
           WHERE CHARINDEX(N','+v.sochungtu+N',',N','+COALESCE(t.phieulayht,N'')+N',')>0
              OR CHARINDEX(N','+v.sochungtu+N',',N','+COALESCE(t.phieulayhttp,N'')+N',')>0
       )
),
result_rows AS (
    SELECT 1 AS ord,N'LENH_CHI_TIET' AS loai,CAST(x.sochungtu AS nvarchar(200)) AS chungtu,
           CAST(x.trangthai AS nvarchar(100)) AS trangthai,
           CONVERT(nvarchar(19),x.ngaytao,120) AS ngaytao,
           CONVERT(nvarchar(19),x.ngaycapnhat,120) AS ngaycapnhat,
           CONCAT(N'Nhom=',COALESCE(x.donhang,N''),N' | KH=',COALESCE(x.c_kehoachdathang_id,N''),
                  N' | HanHoanThanh=',COALESCE(CONVERT(nvarchar(19),x.ngayhoanthanh,120),N'')) AS thongtin
    FROM dbo.md_lenhsanxuat2 AS x
    WHERE EXISTS (SELECT 1 FROM target AS d WHERE CHARINDEX(d.c_danhsachdathang_id,COALESCE(x.c_danhsachdathang_id,N''))>0)
       OR EXISTS (SELECT 1 FROM plans AS k WHERE CHARINDEX(k.c_kehoachdathang_id,COALESCE(x.c_kehoachdathang_id,N''))>0)
    UNION ALL
    SELECT 2,N'PHIEU_VAN_CHUYEN',CAST(v.sochungtu AS nvarchar(200)),
           CAST(v.md_trangthai_id AS nvarchar(100)),
           CONVERT(nvarchar(19),v.ngaytao,120),
           CONVERT(nvarchar(19),v.ngayhieuluc,120),
           CONCAT(N'LayTonTP=',CASE WHEN v.laytonTP=1 THEN N'1' ELSE N'0' END,
                  N' | LayTonTPhoacBTP=',CASE WHEN v.laytonTPhoacBTP=1 THEN N'1' ELSE N'0' END,
                  N' | ThamChieu=',COALESCE(v.donhang_thamchieu,N''))
    FROM transfers AS v
    UNION ALL
    SELECT 3,N'TO_SAN_XUAT',CAST(l.sochungtu AS nvarchar(200)),
           CAST(t.stt AS nvarchar(100)),
           N'',N'',
           CONCAT(N'LayBTP=',COALESCE(t.phieulayht,N''),N' | LayTP=',COALESCE(t.phieulayhttp,N''))
    FROM teams AS t JOIN lsx AS l ON t.md_lenhsanxuat_id=l.md_lenhsanxuat_id
    UNION ALL
    SELECT 4,N'PHAN_BO_LSX',CAST(l.sochungtu AS nvarchar(200)),
           N'',N'',N'',
           CONCAT(N'SoDongDaCoLSXCT=',(SELECT COUNT(*) FROM dbo.md_lenhsanxuat_tosx_cdh AS c WHERE c.md_lenhsanxuat_id=l.md_lenhsanxuat_id AND NULLIF(LTRIM(RTRIM(c.lsxCT)),N'') IS NOT NULL),
                  N' | SoDongChuaCoLSXCT=',(SELECT COUNT(*) FROM dbo.md_lenhsanxuat_tosx_cdh AS c WHERE c.md_lenhsanxuat_id=l.md_lenhsanxuat_id AND NULLIF(LTRIM(RTRIM(c.lsxCT)),N'') IS NULL))
    FROM lsx AS l
)
SELECT TOP(200) loai,chungtu,trangthai,ngaytao,ngaycapnhat,thongtin
FROM result_rows
ORDER BY ord,chungtu