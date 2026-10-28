-- Diagnose database-side status writers without exposing stored procedure bodies.
SELECT TOP (100)
    CAST(N'TRIGGER' AS nvarchar(50)) AS loai,
    CAST(OBJECT_SCHEMA_NAME(tr.object_id)+N'.'+tr.name AS nvarchar(300)) AS ten,
    CAST(parent.name AS nvarchar(150)) AS bang_nguon,
    CAST(CASE WHEN mod.definition IS NULL THEN N'NO_DEFINITION' ELSE N'VISIBLE' END AS nvarchar(40)) AS truy_cap,
    CAST(CASE WHEN mod.definition LIKE N'%DaXLTBTP%' THEN 1 ELSE 0 END AS int) AS viet_DaXLTBTP,
    CAST(CASE WHEN mod.definition LIKE N'%DATSX%' THEN 1 ELSE 0 END AS int) AS viet_DATSX,
    CAST(CASE WHEN mod.definition LIKE N'%c_kehoachdathang%' THEN 1 ELSE 0 END AS int) AS tham_chieu_kehoach,
    CAST(CASE WHEN mod.definition LIKE N'%md_trangthai_id%' THEN 1 ELSE 0 END AS int) AS tham_chieu_trangthai
FROM sys.triggers AS tr
JOIN sys.tables AS parent ON parent.object_id=tr.parent_id
LEFT JOIN sys.sql_modules AS mod ON mod.object_id=tr.object_id
WHERE parent.name IN (N'c_kehoachdathang',N'c_danhsachdathang',N'md_lenhsanxuat2',N'md_vanchuyennoibo',N'md_lenhsanxuat_tosx_cdh',N'md_dondathangphanxuong')
   OR mod.definition LIKE N'%DaXLTBTP%'
   OR mod.definition LIKE N'%DATSX%'
ORDER BY parent.name,tr.name