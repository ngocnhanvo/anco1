SELECT TOP (200)
    t.name AS table_name, c.column_id, c.name AS column_name,
    ty.name AS sql_type, c.is_nullable
FROM sys.tables AS t
JOIN sys.columns AS c ON c.object_id = t.object_id
JOIN sys.types AS ty ON ty.user_type_id = c.user_type_id
WHERE t.name IN (N'md_donggoi_ancotrading', N'md_donggoisanpham_ancotrading')
ORDER BY t.name, c.column_id
