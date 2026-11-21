-- Narrow, read-only diagnostic. No order identifiers or supplier identifiers in output.
WITH target AS (
    SELECT md_sanpham_id, sanpham, ban_thanhpham, vattu, phongbanId, nhacungung, hoatdong
    FROM dbo.md_sanpham
    WHERE ma_sanpham = N'42-04600-CW-16'
)
SELECT TOP (20)
    CAST(ISNULL(t.sanpham,0) AS int) AS IsFinished,
    CAST(ISNULL(t.ban_thanhpham,0) AS int) AS IsSemiFinished,
    CAST(ISNULL(t.vattu,0) AS int) AS IsMaterial,
    CAST(ISNULL(t.hoatdong,0) AS int) AS IsActive,
    CASE WHEN NULLIF(LTRIM(RTRIM(t.phongbanId)),N'') IS NULL THEN 0 ELSE 1 END AS HasWorkshop,
    CASE WHEN NULLIF(LTRIM(RTRIM(t.nhacungung)),N'') IS NULL THEN 0 ELSE 1 END AS HasDefaultSupplier,
    CASE WHEN b.md_sanpham_bom_id IS NULL THEN 0 ELSE 1 END AS HasSelectedBom,
    CAST(ISNULL(b.bom_donggoi,0) AS int) AS IsPackagingBom,
    CAST(ISNULL(b.bom_tam,0) AS int) AS IsTemporaryBom,
    CAST(ISNULL(b.hoatdong,0) AS int) AS IsActiveBom,
    (SELECT COUNT(*) FROM dbo.md_sanpham_bom h WHERE h.md_sanpham_id=t.md_sanpham_id) AS TotalBomVersions,
    (SELECT COUNT(*) FROM dbo.md_sanpham_bom_vattu d INNER JOIN dbo.md_sanpham c ON c.md_sanpham_id=d.md_sanpham_id WHERE d.md_sanpham_bom_id=b.md_sanpham_bom_id AND d.sanphamId=t.md_sanpham_id) AS SelectedBomRows,
    (SELECT COUNT(*) FROM dbo.md_sanpham_bom_vattu d INNER JOIN dbo.md_sanpham c ON c.md_sanpham_id=d.md_sanpham_id WHERE d.md_sanpham_bom_id=b.md_sanpham_bom_id AND d.sanphamId=t.md_sanpham_id AND d.soluong>0) AS PositiveBomRows,
    (SELECT COUNT(*) FROM dbo.md_sanpham_bom_vattu d WHERE d.md_sanpham_id=t.md_sanpham_id AND d.soluong>0) AS PositiveParentReferences
FROM target t
OUTER APPLY (
    SELECT TOP (1) h.md_sanpham_bom_id,h.bom_donggoi,h.bom_tam,h.hoatdong
    FROM dbo.md_sanpham_bom h
    WHERE h.md_sanpham_id=t.md_sanpham_id AND h.ngay_hieuluc<=GETDATE()
    ORDER BY h.ngay_hieuluc DESC
) b
