-- Aggregate audit of 9 blank export columns (and their lookup joins).
-- READ ONLY: no product data values returned, only per-field counts.
WITH sp AS (
    SELECT md_sanpham_id, ma_sanphamcu, v2, ghichu, dinhkhoan,
           md_nhomnangluc_id, nhacungung, khomacdinh, khoton,
           phongbanId, md_thue_sanpham_id
    FROM dbo.md_sanpham
    WHERE ISNULL(vattu,0)=0
      AND (ISNULL(sanpham,0)=1 OR ISNULL(ban_thanhpham,0)=1)
      AND trangthai=N'SOANTHAO'
), audited AS (
    SELECT sp.*,
           cl.md_chungloai_id AS cl_found,
           dtkd.md_doitackinhdoanh_id AS vendor_found,
           khoSX.md_kho_id AS wh_sx_found,
           khoTon.md_kho_id AS wh_ton_found,
           dept.md_phongban_id AS dept_found,
           tax.md_thue_sanpham_id AS tax_found
    FROM sp
    LEFT JOIN dbo.md_chungloai cl ON cl.md_chungloai_id=sp.md_nhomnangluc_id
    LEFT JOIN dbo.md_doitackinhdoanh dtkd ON dtkd.md_doitackinhdoanh_id=sp.nhacungung
    LEFT JOIN dbo.md_kho khoSX ON khoSX.md_kho_id=sp.khomacdinh
    LEFT JOIN dbo.md_kho khoTon ON khoTon.md_kho_id=sp.khoton
    LEFT JOIN dbo.ad_department dept ON dept.md_phongban_id=sp.phongbanId
    LEFT JOIN dbo.md_thue_sanpham tax ON tax.md_thue_sanpham_id=sp.md_thue_sanpham_id
), metrics AS (
    SELECT N'00 total draft products' AS field_name, COUNT_BIG(*) AS nonnull_count FROM audited
    UNION ALL SELECT N'01 sp.v2', COUNT_BIG(*) FROM audited WHERE v2 IS NOT NULL
    UNION ALL SELECT N'02 sp.ghichu', COUNT_BIG(*) FROM audited WHERE NULLIF(LTRIM(RTRIM(ghichu)),N'') IS NOT NULL
    UNION ALL SELECT N'03 sp.dinhkhoan', COUNT_BIG(*) FROM audited WHERE NULLIF(LTRIM(RTRIM(dinhkhoan)),N'') IS NOT NULL
    UNION ALL SELECT N'04 sp.md_nhomnangluc_id', COUNT_BIG(*) FROM audited WHERE NULLIF(LTRIM(RTRIM(md_nhomnangluc_id)),N'') IS NOT NULL
    UNION ALL SELECT N'05 join md_chungloai', COUNT_BIG(*) FROM audited WHERE cl_found IS NOT NULL
    UNION ALL SELECT N'06 sp.nhacungung', COUNT_BIG(*) FROM audited WHERE NULLIF(LTRIM(RTRIM(nhacungung)),N'') IS NOT NULL
    UNION ALL SELECT N'07 join md_doitackinhdoanh', COUNT_BIG(*) FROM audited WHERE vendor_found IS NOT NULL
    UNION ALL SELECT N'08 sp.khomacdinh', COUNT_BIG(*) FROM audited WHERE NULLIF(LTRIM(RTRIM(khomacdinh)),N'') IS NOT NULL
    UNION ALL SELECT N'09 join md_kho for Kho SX', COUNT_BIG(*) FROM audited WHERE wh_sx_found IS NOT NULL
    UNION ALL SELECT N'10 sp.khoton', COUNT_BIG(*) FROM audited WHERE NULLIF(LTRIM(RTRIM(khoton)),N'') IS NOT NULL
    UNION ALL SELECT N'11 join md_kho for Kho ton', COUNT_BIG(*) FROM audited WHERE wh_ton_found IS NOT NULL
    UNION ALL SELECT N'12 sp.phongbanId', COUNT_BIG(*) FROM audited WHERE NULLIF(LTRIM(RTRIM(phongbanId)),N'') IS NOT NULL
    UNION ALL SELECT N'13 join ad_department', COUNT_BIG(*) FROM audited WHERE dept_found IS NOT NULL
    UNION ALL SELECT N'14 sp.md_thue_sanpham_id', COUNT_BIG(*) FROM audited WHERE NULLIF(LTRIM(RTRIM(md_thue_sanpham_id)),N'') IS NOT NULL
    UNION ALL SELECT N'15 join md_thue_sanpham', COUNT_BIG(*) FROM audited WHERE tax_found IS NOT NULL
    UNION ALL SELECT N'16 sp.ma_sanphamcu (not exported as Ma tho)', COUNT_BIG(*) FROM audited WHERE NULLIF(LTRIM(RTRIM(ma_sanphamcu)),N'') IS NOT NULL
)
SELECT field_name, nonnull_count FROM metrics ORDER BY field_name
