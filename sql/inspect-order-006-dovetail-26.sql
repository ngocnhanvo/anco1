-- Read-only verification of database principal capabilities; no table mutation.
SELECT
 DB_NAME() AS connected_database,
 USER_NAME() AS connected_user,
 IS_MEMBER(N'db_datawriter') AS datawriter_role,
 IS_MEMBER(N'db_owner') AS owner_role,
 IS_SRVROLEMEMBER(N'sysadmin') AS server_admin_role,
 (SELECT COUNT(*) FROM sys.database_permissions p
     WHERE p.grantee_principal_id=USER_ID()
       AND p.state IN ('G','W')
       AND p.type IN ('UP','IN','DL')) AS direct_write_grants,
 (SELECT COUNT(*) FROM dbo.c_kehoachdathang WHERE LTRIM(RTRIM(donhang_thamchieu))=N'006/DOVETAIL-26') AS matching_plans,
 (SELECT COUNT(*) FROM dbo.md_vanchuyennoibo WHERE sochungtu=N'PVC/01386/26') AS old_pvc_exists,
 (SELECT COUNT(*) FROM dbo.md_vanchuyennoibo WHERE sochungtu=N'PVC/01359/26') AS effective_pvc_exists