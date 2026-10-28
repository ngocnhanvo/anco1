-- Verify only the permissions required for a scoped, rollback-only reproduction.
SELECT
 DB_NAME() AS connected_database,
 DB_USER() AS connected_user,
 HAS_PERMS_BY_NAME(N'dbo.c_danhsachdathang',N'OBJECT',N'SELECT') AS po_select,
 HAS_PERMS_BY_NAME(N'dbo.c_danhsachdathang',N'OBJECT',N'UPDATE') AS po_update,
 HAS_PERMS_BY_NAME(N'dbo.c_kehoachdathang',N'OBJECT',N'UPDATE') AS plan_update,
 HAS_PERMS_BY_NAME(N'dbo.md_lenhsanxuat_tosx',N'OBJECT',N'UPDATE') AS team_update,
 HAS_PERMS_BY_NAME(N'dbo.md_vanchuyennoibo',N'OBJECT',N'INSERT') AS pvc_insert,
 HAS_PERMS_BY_NAME(N'dbo.md_vanchuyennoibo',N'OBJECT',N'DELETE') AS pvc_delete,
 (SELECT COUNT(*) FROM dbo.c_kehoachdathang WHERE LTRIM(RTRIM(donhang_thamchieu))=N'006/DOVETAIL-26') AS matching_plans,
 (SELECT COUNT(*) FROM dbo.md_vanchuyennoibo WHERE sochungtu=N'PVC/01386/26') AS original_pvc_exists,
 (SELECT COUNT(*) FROM dbo.md_vanchuyennoibo WHERE sochungtu=N'PVC/01359/26') AS effective_pvc_exists