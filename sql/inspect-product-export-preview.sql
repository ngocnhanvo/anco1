-- Anco1: 37-column export preview with real draft-products, read-only.
-- No jqGrid role filter, review use only; LIMIT 100.
SELECT TOP (100)
    sp.ma_sanpham                                   AS [Mã hàng],             -- A
    maTho.ma_tho                                    AS [Mã thô],              -- B
    sp.mota_tiengviet                               AS [Mô Tả Tiếng Việt],    -- C
    dvt_sp.ten_dvt                                  AS [ĐVT],                 -- D
    sp.l_cm                                         AS [L(cm)],               -- E
    sp.w_cm                                         AS [W(cm)],               -- F
    sp.h_cm                                         AS [H(cm)],               -- G
    sp.trongluong                                   AS [Khối lượng (kg)],     -- H
    sp.dientich                                     AS [Diện Tích],           -- I
    sp.v2                                           AS [Thể Tích],            -- J
    kd.ten_tv                                       AS [Tên kiểu dáng],       -- K
    cn.ten_tv                                       AS [Tên chức năng],       -- L
    sp.ghichu                                      AS [Ghi chú],             -- M
    dg.sl_inner                                     AS [SL Inner],            -- N
    dg.dvt_inner                                    AS [DVT Inner],           -- O
    dg.l1                                           AS [l1],                  -- P
    dg.w1                                           AS [w1],                  -- Q
    dg.h1                                           AS [h1],                  -- R
    dg.sl_outer                                     AS [SL Outer],            -- S
    dg.dvt_outer                                    AS [DVT Outer],           -- T
    dg.l2_mix                                       AS [l2],                  -- U
    dg.w2_mix                                       AS [w2],                  -- V
    dg.h2_mix                                       AS [h2],                  -- W
    dg.soluonggoi_ctn_20                            AS [SL Cont 20],         -- X
    dg.soluonggoi_ctn                               AS [SL Cont 40],         -- Y
    dg.soluonggoi_ctn_40hc                          AS [SL Cont 40 hc],      -- Z
    dg.ngayxacnhan                                 AS [Ngày xác nhận ĐG],   -- AA
    dg.trangthai                                    AS [trạng thái ĐG],       -- AB
    dg.ghi_chu_dg                                   AS [Ghi chú ĐG],          -- AC
    sp.dinhkhoan                                    AS [Định khoản],         -- AD
    cl.code_cl                                      AS [Nhóm VTHH],          -- AE
    dtkd.ma_dtkd                                    AS [NCC mặc định],        -- AF
    kmd.ten_kho                                     AS [Kho SX],              -- AG
    kton.ten_kho                                    AS [Kho tồn],             -- AH
    pb.ten_phongban                                 AS [Xưởng SX],           -- AI
    thue.ten_thue_sanpham                           AS [Thuế],                -- AJ
    CASE WHEN sp.ban_thanhpham = 1 THEN 1 ELSE 0 END AS [Bán TP]              -- AK
FROM dbo.md_sanpham AS sp
LEFT JOIN dbo.md_donvitinhsanpham AS dvt_sp
    ON dvt_sp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
LEFT JOIN dbo.ad_department AS pb
    ON pb.md_phongban_id = sp.phongbanId
LEFT JOIN dbo.md_kho AS kmd
    ON kmd.md_kho_id = sp.khomacdinh
LEFT JOIN dbo.md_kho AS kton
    ON kton.md_kho_id = sp.khoton
LEFT JOIN dbo.md_thue_sanpham AS thue
    ON thue.md_thue_sanpham_id = sp.md_thue_sanpham_id
LEFT JOIN dbo.md_doitackinhdoanh AS dtkd
    ON dtkd.md_doitackinhdoanh_id = sp.nhacungung
LEFT JOIN dbo.md_chungloai AS cl
    ON cl.md_chungloai_id = sp.md_nhomnangluc_id
LEFT JOIN dbo.md_kieudang_ancotrading AS kd
    ON kd.md_kieudang_id = sp.md_kieudang_id
LEFT JOIN dbo.md_chucnang_ancotrading AS cn
    ON cn.md_chucnang_id = sp.md_chucnang_id

-- Phiên bản BOM theo quy tắc đang dùng tại BaoCaoBOMHHVT2: ngay_hieuluc DESC,
-- md_sanpham_bom_id DESC; không ép ngày phải <= GETDATE() để khớp code hiện hành.
OUTER APPLY (
    SELECT TOP (1) b.md_sanpham_bom_id
    FROM dbo.md_sanpham_bom AS b
    WHERE b.md_sanpham_id = sp.md_sanpham_id
      AND ISNULL(b.ten_phienban, N'') <> N''
    ORDER BY b.ngay_hieuluc DESC, b.md_sanpham_bom_id DESC
) AS bomMoiNhat
OUTER APPLY (
    SELECT STUFF((
        SELECT N', ' + x.ma_sanpham
        FROM (
            SELECT DISTINCT vt.ma_sanpham
            FROM dbo.md_sanpham_bom_vattu AS bvt
            INNER JOIN dbo.md_sanpham AS vt
                ON vt.md_sanpham_id = bvt.md_sanpham_id
            WHERE bvt.md_sanpham_bom_id = bomMoiNhat.md_sanpham_bom_id
              AND vt.ban_thanhpham = 1
              AND ISNULL(vt.vattu, 0) = 0
              AND NULLIF(LTRIM(RTRIM(vt.ma_sanpham)), N'') IS NOT NULL
        ) AS x
        ORDER BY x.ma_sanpham
        FOR XML PATH(''), TYPE
    ).value('.', 'nvarchar(max)'), 1, 2, N'') AS ma_tho
) AS maTho

-- Không JOIN thẳng bảng đóng gói 1:N: giữ đúng 1 dòng hàng hóa/ma_sanpham.
-- md_donggoisanpham_ancotrading.md_donggoi_id là khóa tham chiếu dự kiến;
-- cần so với FK/dữ liệu thực để xác nhận quan hệ này.
OUTER APPLY (
    SELECT TOP (1)
        p.sl_inner, p.dvt_inner, p.l1, p.w1, p.h1,
        p.sl_outer, p.dvt_outer, p.l2_mix, p.w2_mix, p.h2_mix,
        p.soluonggoi_ctn_20, p.soluonggoi_ctn, p.soluonggoi_ctn_40hc,
        p.ngayxacnhan, p.trangthai, p.mota AS ghi_chu_dg
    FROM dbo.md_donggoisanpham_ancotrading AS ds
    INNER JOIN dbo.md_donggoi_ancotrading AS p
        ON p.md_donggoi_id = ds.md_donggoi_id
    WHERE ds.md_sanpham_id = sp.md_sanpham_id
      AND ISNULL(ds.hoatdong, 1) = 1
      AND ISNULL(p.hoatdong, 1) = 1
    ORDER BY CASE WHEN ds.macdinh = 1 THEN 0 ELSE 1 END,
             ISNULL(ds.ngaycapnhat, ds.ngaytao) DESC,
             ds.md_donggoisanpham_ancotrading_id DESC,
             p.md_donggoi_ancotrading_id DESC
) AS dg
WHERE ISNULL(sp.vattu, 0) = 0
  AND (ISNULL(sp.sanpham, 0) = 1 OR ISNULL(sp.ban_thanhpham, 0) = 1)
  AND sp.trangthai = N'SOANTHAO'
ORDER BY SUBSTRING(sp.ma_sanpham, 0, 12) ASC,
         LEN(sp.ma_sanpham), sp.ma_sanpham, sp.md_sanpham_id
