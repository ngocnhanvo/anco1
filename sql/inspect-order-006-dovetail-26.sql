-- Read-only targeted comparison: older TP stock take vs later transfer from audit.
WITH target AS (
 SELECT v.md_vanchuyennoibo_id,v.sochungtu,v.loaichuyen,
  v.md_trangthai_id,v.laytonTP,v.layTonTPhoacBTP,
  v.c_doichieuhangton_id,v.donhang_thamchieu,
  v.chungtuthamchieu,v.chungtu_lenhsx,v.sctdathang,
  v.ngaytao,v.ngayhieuluc,v.ngaycapnhat
 FROM dbo.md_vanchuyennoibo AS v WHERE v.sochungtu IN (N'PVC/01359/26',N'PVC/01386/26')
),
rows AS (
 SELECT 1 AS ord,v.sochungtu,CAST(v.md_trangthai_id AS nvarchar(80)) AS trangthai,
   CAST(v.loaichuyen AS nvarchar(80)) AS loai,
   CONVERT(nvarchar(19),v.ngaytao,120) AS ngaytao,CONVERT(nvarchar(19),v.ngayhieuluc,120) AS ngayhieuluc,
   CONCAT(N'LayTonTP=',COALESCE(CAST(v.laytonTP AS nvarchar(10)),N'NULL'),
     N' LayTonTPBTP=',COALESCE(CAST(v.layTonTPhoacBTP AS nvarchar(10)),N'NULL'),
     N' KHLink=',COALESCE(v.c_doichieuhangton_id,N''),
     N' DH=',COALESCE(v.donhang_thamchieu,N''),
     N' CTThamChieu=',COALESCE(v.chungtuthamchieu,N''),
     N' LSX=',COALESCE(v.chungtu_lenhsx,N''),
     N' SoCTDH=',COALESCE(v.sctdathang,N'')) AS chi_tiet
 FROM target v
 UNION ALL
 SELECT 2,v.sochungtu,N'CDVC',N'DONG_CHUYEN',N'',N'',
   CONCAT(N'SoDong=',COUNT(*),
   N' SLThucChuyen=',COALESCE(CONVERT(nvarchar(100),SUM(COALESCE(c.soluong_dichchuyen,0))),N'0'),
   N' SoDongCoLSX=',SUM(CASE WHEN NULLIF(LTRIM(RTRIM(COALESCE(c.lsxId,N''))),N'') IS NOT NULL THEN 1 ELSE 0 END))
 FROM target v JOIN dbo.md_vanchuyennoibo_cdvc c ON c.md_vanchuyennoibo_id=v.md_vanchuyennoibo_id
 GROUP BY v.sochungtu
)
SELECT ord,sochungtu,trangthai,loai,ngaytao,ngayhieuluc,chi_tiet FROM rows ORDER BY ord,sochungtu