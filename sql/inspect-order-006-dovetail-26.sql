-- Read-only reconciliation against CA01TaoLenhLSX_MD01KeHoachYCSXDH eligibility logic.
WITH k AS (
    SELECT p.c_kehoachdathang_id,p.c_danhsachdathang_id,p.donhang_thamchieu,p.trangthai
    FROM dbo.c_kehoachdathang AS p
    WHERE LTRIM(RTRIM(p.donhang_thamchieu))=N'006/DOVETAIL-26'
),
lines AS (
    SELECT c.*,l.c_kehoachdathang_id
    FROM dbo.md_lenhsanxuat_tosx_cdh AS c
    JOIN dbo.md_lenhsanxuat AS l ON l.md_lenhsanxuat_id=c.md_lenhsanxuat_id
    WHERE EXISTS (SELECT 1 FROM k WHERE k.c_kehoachdathang_id=l.c_kehoachdathang_id)
),
stat AS (
    SELECT COUNT(*) AS tongdong,
      SUM(CASE WHEN NULLIF(LTRIM(RTRIM(c.lsxCT)),N'') IS NOT NULL THEN 1 ELSE 0 END) AS da_gan_LSX,
      SUM(CASE WHEN (c.hoatdong=1) AND NULLIF(LTRIM(RTRIM(c.lsxCT)),N'') IS NULL
                    AND NULLIF(LTRIM(RTRIM(c.xuongPhu)),N'') IS NOT NULL
                    AND (COALESCE(c.sl_chiato,0)-COALESCE(c.sl_chiato2,0))>0 THEN 1 ELSE 0 END) AS con_dat_sx,
      SUM(CASE WHEN (c.hoatdong=1) AND NULLIF(LTRIM(RTRIM(c.lsxCT)),N'') IS NULL
                    AND NULLIF(LTRIM(RTRIM(c.xuongPhu)),N'') IS NULL
                    AND (COALESCE(c.sl_chiato,0)-COALESCE(c.sl_chiato2,0)-COALESCE(c.sl_datncc,0)-COALESCE(c.sl_datncc2,0))>0 THEN 1 ELSE 0 END) AS con_dat_ncc
    FROM lines AS c
)
SELECT k.donhang_thamchieu AS po,k.trangthai AS trangthai_KH,d.md_trangthai_id AS trangthai_DH,
       s.tongdong,s.da_gan_LSX,s.con_dat_sx,s.con_dat_ncc,
       CASE WHEN s.con_dat_sx>0 OR s.con_dat_ncc>0 THEN N'DATSX'
            WHEN s.da_gan_LSX>0 THEN N'DATHET'
            ELSE N'CHUA_CO_LSX' END AS trangthai_du_kien_sau_tao_LSX
FROM k 
JOIN dbo.c_danhsachdathang AS d ON d.c_danhsachdathang_id=k.c_danhsachdathang_id
CROSS JOIN stat AS s