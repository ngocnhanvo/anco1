WITH target AS (
    SELECT TOP (20)
        d.c_danhsachdathang_id,
        d.sochungtu,
        d.so_po,
        d.trangthai,
        d.md_trangthai_id,
        d.trangthaiHDLH,
        d.isgui_hdlh,
        d.huongdanlamhang,
        d.huongdanlamhangchung,
        d.huongdanlamhang2,
        d.huongdanlamhangchung2,
        d.ngaycapnhat,
        d.value_nguoicapnhat
    FROM c_danhsachdathang d
    WHERE d.sochungtu = N'003B/WINHAUS-26'
       OR d.so_po = N'003B/WINHAUS-26'
)
SELECT
    N'ORDER' AS record_type,
    t.c_danhsachdathang_id AS record_id,
    t.sochungtu,
    t.so_po,
    CAST(NULL AS nvarchar(200)) AS loai,
    t.trangthaiHDLH AS hdlh_status,
    CAST(NULL AS bit) AS viewed,
    CAST(NULL AS datetime) AS ngaytao,
    t.ngaycapnhat,
    CAST(NULL AS datetime) AS ngayxacnhan,
    t.value_nguoicapnhat AS actor,
    CAST(t.huongdanlamhang AS nvarchar(max)) AS noi_dung_1,
    CAST(t.huongdanlamhangchung AS nvarchar(max)) AS noi_dung_2,
    CAST(t.huongdanlamhang2 AS nvarchar(max)) AS noi_dung_cho_1,
    CAST(t.huongdanlamhangchung2 AS nvarchar(max)) AS noi_dung_cho_2,
    CAST(t.trangthai AS nvarchar(200)) AS order_lifecycle,
    CAST(t.md_trangthai_id AS nvarchar(200)) AS order_stage,
    CAST(t.isgui_hdlh AS nvarchar(20)) AS object_type_or_flag
FROM target t
UNION ALL
SELECT
    N'GHI_CHU',
    g.md_ghichuhdlh_id,
    t.sochungtu,
    t.so_po,
    g.loai,
    g.trangthai,
    g.viewed,
    g.ngaytao,
    g.ngaycapnhat,
    g.ngayxacnhan,
    COALESCE(g.value_nguoicapnhat, g.value_nguoitao),
    CAST(g.ghichu AS nvarchar(max)),
    CAST(g.mota AS nvarchar(max)),
    CAST(NULL AS nvarchar(max)),
    CAST(NULL AS nvarchar(max)),
    CAST(NULL AS nvarchar(200)),
    CAST(NULL AS nvarchar(200)),
    CAST(g.doituong_dinhkem AS nvarchar(200))
FROM md_ghichuhdlh g
INNER JOIN target t ON t.c_danhsachdathang_id = g.lienket
UNION ALL
SELECT
    N'TAP_TIN',
    f.md_taptin_id,
    t.sochungtu,
    t.so_po,
    CAST(f.tentaptin AS nvarchar(200)),
    f.trangthai,
    f.viewed,
    f.ngaytao,
    f.ngaycapnhat,
    f.ngayxacnhan,
    COALESCE(f.value_nguoicapnhat, f.value_nguoitao),
    CAST(f.tentaptin AS nvarchar(max)),
    CAST(f.path AS nvarchar(max)),
    CAST(NULL AS nvarchar(max)),
    CAST(NULL AS nvarchar(max)),
    CAST(NULL AS nvarchar(200)),
    CAST(NULL AS nvarchar(200)),
    CAST(f.doituong_dinhkem AS nvarchar(200))
FROM md_taptin f
INNER JOIN target t ON t.c_danhsachdathang_id = f.lienket
WHERE f.doituong_dinhkem IN (N'HDLH', N'HDLHTC')