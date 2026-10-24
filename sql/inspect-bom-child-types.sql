-- Read-only inspection of current BOM component types by product status.
WITH newest_bom AS (
    SELECT b.md_sanpham_id, b.md_sanpham_bom_id,
           ROW_NUMBER() OVER (
             PARTITION BY b.md_sanpham_id
             ORDER BY b.ngay_hieuluc DESC, b.md_sanpham_bom_id DESC
           ) AS rn
    FROM dbo.md_sanpham_bom AS b
    WHERE ISNULL(b.ten_phienban, N'') <> N''
),
typed_components AS (
    SELECT COALESCE(parent.trangthai,N'(null)') AS parent_status,
           CASE
             WHEN child.ban_thanhpham=1 AND ISNULL(child.vattu,0)=0 THEN N'BTP'
             WHEN child.ban_thanhpham=1 AND child.vattu=1 THEN N'MIX'
             WHEN child.vattu=1 THEN N'DIRECT_MATERIAL'
             WHEN child.sanpham=1 THEN N'PRODUCT'
             ELSE N'OTHER'
           END AS component_type,
           parent.md_sanpham_id AS parent_id
    FROM newest_bom AS b
    INNER JOIN dbo.md_sanpham AS parent ON parent.md_sanpham_id=b.md_sanpham_id
    INNER JOIN dbo.md_sanpham_bom_vattu AS bvt ON bvt.md_sanpham_bom_id=b.md_sanpham_bom_id
    INNER JOIN dbo.md_sanpham AS child ON child.md_sanpham_id=bvt.md_sanpham_id
    WHERE b.rn=1
)
SELECT TOP (100) parent_status, component_type,
       COUNT_BIG(*) AS bom_component_rows,
       COUNT(DISTINCT parent_id) AS parent_products
FROM typed_components
GROUP BY parent_status, component_type
ORDER BY parent_status, bom_component_rows DESC
