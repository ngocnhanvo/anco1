-- Read-only packaging unit-of-measure lookup for draft products
SELECT TOP (100) u.unit_role,
       u.unit_id,
       dvt.ten_dvt AS unit_name,
       COUNT_BIG(*) AS used_in_packaging
FROM (
    SELECT N'Inner' AS unit_role, p.dvt_inner AS unit_id
    FROM dbo.md_donggoi_ancotrading AS p
    UNION ALL
    SELECT N'Outer' AS unit_role, p.dvt_outer AS unit_id
    FROM dbo.md_donggoi_ancotrading AS p
) AS u
LEFT JOIN dbo.md_donvitinhsanpham AS dvt
  ON dvt.md_donvitinhsanpham_id = u.unit_id
WHERE u.unit_id IS NOT NULL
GROUP BY u.unit_role, u.unit_id, dvt.ten_dvt
ORDER BY u.unit_role, COUNT_BIG(*) DESC
