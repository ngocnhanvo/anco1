-- Review vendor references on SOANTHAO products, read-only.
SELECT TOP (30)
   sp.nhacungung AS raw_nhacungung,
   COUNT_BIG(*) AS draft_product_count,
   MAX(LEN(sp.nhacungung)) AS reference_len,
   MAX(CASE WHEN byId.md_doitackinhdoanh_id IS NOT NULL THEN 1 ELSE 0 END) AS matched_by_id,
   MAX(CASE WHEN byCode.md_doitackinhdoanh_id IS NOT NULL THEN 1 ELSE 0 END) AS matched_by_code,
   MAX(CASE WHEN byName.md_doitackinhdoanh_id IS NOT NULL THEN 1 ELSE 0 END) AS matched_by_name,
   MAX(byCode.ma_dtkd) AS vendor_code_if_matched,
   MAX(byName.ma_dtkd) AS vendor_code_if_matched_by_name
FROM dbo.md_sanpham AS sp
LEFT JOIN dbo.md_doitackinhdoanh AS byId
 ON byId.md_doitackinhdoanh_id=sp.nhacungung
LEFT JOIN dbo.md_doitackinhdoanh AS byCode
 ON byCode.ma_dtkd=sp.nhacungung
LEFT JOIN dbo.md_doitackinhdoanh AS byName
 ON byName.ten_dtkd=sp.nhacungung
WHERE ISNULL(sp.vattu,0)=0
 AND (ISNULL(sp.sanpham,0)=1 OR ISNULL(sp.ban_thanhpham,0)=1)
 AND sp.trangthai=N'SOANTHAO'
GROUP BY sp.nhacungung
ORDER BY draft_product_count DESC,sp.nhacungung
