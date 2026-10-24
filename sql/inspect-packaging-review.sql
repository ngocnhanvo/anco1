-- ANCO1 packaging/BOM review | aggregate metrics only, read-only
-- This is one SELECT, restricted to the draft-product module filter.
WITH draft AS (
    SELECT sp.md_sanpham_id FROM dbo.md_sanpham AS sp
    WHERE ISNULL(sp.vattu, 0) = 0
      AND (ISNULL(sp.sanpham, 0) = 1 OR ISNULL(sp.ban_thanhpham, 0) = 1)
      AND sp.trangthai = N'SOANTHAO'
),
links AS (
    SELECT ds.md_donggoisanpham_ancotrading_id, ds.md_sanpham_id,
           ds.md_donggoi_id, ds.hoatdong, ds.macdinh,
           p.md_donggoi_ancotrading_id, p.hoatdong AS pkg_active,
           p.trangthai AS pkg_status
    FROM dbo.md_donggoisanpham_ancotrading AS ds
    INNER JOIN draft AS d ON d.md_sanpham_id = ds.md_sanpham_id
    LEFT JOIN dbo.md_donggoi_ancotrading AS p
      ON p.md_donggoi_id = ds.md_donggoi_id
),
metrics AS (
    SELECT N'01 draft products' AS metric, COUNT_BIG(*) AS quantity FROM draft
    UNION ALL SELECT N'02 links to draft products', COUNT_BIG(*) FROM links
    UNION ALL SELECT N'03 joined link rows', COUNT_BIG(*) FROM links WHERE md_donggoi_ancotrading_id IS NOT NULL
    UNION ALL SELECT N'04 orphan link rows', COUNT_BIG(*) FROM links WHERE md_donggoi_ancotrading_id IS NULL
    UNION ALL SELECT N'05 active joined links', COUNT_BIG(*) FROM links WHERE ISNULL(hoatdong,1)=1 AND ISNULL(pkg_active,1)=1 AND md_donggoi_ancotrading_id IS NOT NULL
    UNION ALL SELECT N'06 default joined links', COUNT_BIG(*) FROM links WHERE macdinh=1 AND md_donggoi_ancotrading_id IS NOT NULL
    UNION ALL SELECT N'07 active default joined links', COUNT_BIG(*) FROM links WHERE macdinh=1 AND ISNULL(hoatdong,1)=1 AND ISNULL(pkg_active,1)=1 AND md_donggoi_ancotrading_id IS NOT NULL
    UNION ALL SELECT N'08 products with matching packaging', COUNT_BIG(*) FROM (SELECT md_sanpham_id FROM links WHERE md_donggoi_ancotrading_id IS NOT NULL GROUP BY md_sanpham_id) g
    UNION ALL SELECT N'09 products with active default package', COUNT_BIG(*) FROM (SELECT md_sanpham_id FROM links WHERE macdinh=1 AND ISNULL(hoatdong,1)=1 AND ISNULL(pkg_active,1)=1 AND md_donggoi_ancotrading_id IS NOT NULL GROUP BY md_sanpham_id) g
    UNION ALL SELECT N'10 products with multiple active defaults', COUNT_BIG(*) FROM (SELECT md_sanpham_id FROM links WHERE macdinh=1 AND ISNULL(hoatdong,1)=1 AND ISNULL(pkg_active,1)=1 AND md_donggoi_ancotrading_id IS NOT NULL GROUP BY md_sanpham_id HAVING COUNT(*)>1) g
    UNION ALL SELECT N'11 packaging keys having multiple physical rows', COUNT_BIG(*) FROM (SELECT md_donggoi_id FROM dbo.md_donggoi_ancotrading GROUP BY md_donggoi_id HAVING COUNT(*)>1) g
    UNION ALL SELECT N'12 default links with inactive package', COUNT_BIG(*) FROM links WHERE macdinh=1 AND ISNULL(pkg_active,1)<>1 AND md_donggoi_ancotrading_id IS NOT NULL
    UNION ALL SELECT N'13 linked package HIEULUC', COUNT_BIG(*) FROM links WHERE pkg_status=N'HIEULUC'
    UNION ALL SELECT N'14 linked package other status', COUNT_BIG(*) FROM links WHERE pkg_status IS NOT NULL AND pkg_status<>N'HIEULUC'
    UNION ALL SELECT N'15 declared packaging foreign keys', COUNT_BIG(*) FROM sys.foreign_keys fk WHERE OBJECT_NAME(fk.parent_object_id) IN (N'md_donggoi_ancotrading',N'md_donggoisanpham_ancotrading') OR OBJECT_NAME(fk.referenced_object_id) IN (N'md_donggoi_ancotrading',N'md_donggoisanpham_ancotrading')
    UNION ALL SELECT N'16 draft products with nonempty BOM name', COUNT_BIG(*) FROM (SELECT b.md_sanpham_id FROM dbo.md_sanpham_bom b INNER JOIN draft d ON d.md_sanpham_id=b.md_sanpham_id WHERE ISNULL(b.ten_phienban,N'')<>N'' GROUP BY b.md_sanpham_id) g
    UNION ALL SELECT N'17 draft products with any BOM', COUNT_BIG(*) FROM (SELECT b.md_sanpham_id FROM dbo.md_sanpham_bom b INNER JOIN draft d ON d.md_sanpham_id=b.md_sanpham_id GROUP BY b.md_sanpham_id) g
    UNION ALL SELECT N'18 draft products with default link but no joined package', COUNT_BIG(*) FROM (SELECT md_sanpham_id FROM links WHERE macdinh=1 AND md_donggoi_ancotrading_id IS NULL GROUP BY md_sanpham_id) g
    UNION ALL SELECT N'19 link rows with NULL default flag', COUNT_BIG(*) FROM links WHERE macdinh IS NULL
    UNION ALL SELECT N'20 package rows with nonnull container quantity', COUNT_BIG(*) FROM dbo.md_donggoi_ancotrading WHERE soluonggoi_ctn IS NOT NULL OR soluonggoi_ctn_20 IS NOT NULL OR soluonggoi_ctn_40hc IS NOT NULL
)
SELECT metric, quantity FROM metrics ORDER BY metric
