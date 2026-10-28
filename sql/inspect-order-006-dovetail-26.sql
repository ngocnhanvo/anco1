-- Verify the dependency guard against the remaining stock-taking PVC from the same PO.
WITH kh AS (
 SELECT k.c_kehoachdathang_id,k.c_danhsachdathang_id
 FROM dbo.c_kehoachdathang k
 WHERE LTRIM(RTRIM(k.donhang_thamchieu))=N'006/DOVETAIL-26'
),
original_pvc AS (
 SELECT v.sochungtu,v.loaichuyen,v.c_doichieuhangton_id,v.md_trangthai_id
 FROM dbo.md_vanchuyennoibo v WHERE v.sochungtu=N'PVC/01359/26'
)
SELECT
 v.sochungtu AS pvc_hien_co,
 v.loaichuyen,
 v.md_trangthai_id AS pvc_trangthai,
 CASE WHEN v.c_doichieuhangton_id=k.c_kehoachdathang_id THEN N'LINK_PLAN' ELSE N'NOT_LINKED' END AS lien_ket_ke_hoach,
 (SELECT COUNT(*) FROM dbo.md_lenhsanxuat2 l
     WHERE CHARINDEX(k.c_kehoachdathang_id,COALESCE(l.c_kehoachdathang_id,N''))>0) AS so_lsx_chi_tiet,
 (SELECT COUNT(*) FROM dbo.c_donmuahang m
     WHERE m.c_kehoachdathang_dhncc_id=k.c_kehoachdathang_id) AS so_don_mua_hang,
 (SELECT STRING_AGG(l.sochungtu,N', ') FROM dbo.md_lenhsanxuat2 l
     WHERE CHARINDEX(k.c_kehoachdathang_id,COALESCE(l.c_kehoachdathang_id,N''))>0) AS danh_sach_lsx,
 (SELECT STRING_AGG(m.sochungtu,N', ') FROM dbo.c_donmuahang m
     WHERE m.c_kehoachdathang_dhncc_id=k.c_kehoachdathang_id) AS danh_sach_dmh
FROM original_pvc v
JOIN kh k ON k.c_kehoachdathang_id=v.c_doichieuhangton_id