-- ANCO1 | Read-only lookup of NCC mặc định for one requested product code.
-- No output of passwords, other product/customer information, or modifications.
SELECT TOP (5)
    requested.ma_sanpham AS ma_hang_tra_cuu,
    CASE WHEN sp.md_sanpham_id IS NULL THEN N'NOT_FOUND' ELSE N'FOUND' END AS ket_qua_tim_san_pham,
    sp.trangthai AS trang_thai,
    sp.md_sanpham_id AS san_pham_id,
    sp.nhacungung AS ma_luu_tai_nhacungung,
    CASE WHEN NULLIF(LTRIM(RTRIM(sp.nhacungung)), N'') IS NULL
         THEN N'KHONG_CO_GIA_TRI'
         WHEN vendorById.md_doitackinhdoanh_id IS NOT NULL THEN N'CO_NCC_THEO_ID'
         WHEN vendorByCode.md_doitackinhdoanh_id IS NOT NULL THEN N'CO_NCC_THEO_MA'
         WHEN vendorByName.md_doitackinhdoanh_id IS NOT NULL THEN N'CO_NCC_THEO_TEN'
         ELSE N'CO_GIA_TRI_NHUNG_KHONG_KHOP_NCC'
    END AS tinh_trang_ncc_mac_dinh,
    vendorById.ma_dtkd AS ma_ncc_theo_id,
    vendorById.ten_dtkd AS ten_ncc_theo_id,
    vendorByCode.ma_dtkd AS ma_ncc_theo_ma,
    vendorByCode.ten_dtkd AS ten_ncc_theo_ma,
    vendorByName.ma_dtkd AS ma_ncc_theo_ten,
    vendorByName.ten_dtkd AS ten_ncc_theo_ten
FROM (VALUES (N'51-60000-01-82')) AS requested(ma_sanpham)
LEFT JOIN dbo.md_sanpham AS sp
    ON sp.ma_sanpham = requested.ma_sanpham
LEFT JOIN dbo.md_doitackinhdoanh AS vendorById
    ON vendorById.md_doitackinhdoanh_id = sp.nhacungung
LEFT JOIN dbo.md_doitackinhdoanh AS vendorByCode
    ON vendorByCode.ma_dtkd = sp.nhacungung
LEFT JOIN dbo.md_doitackinhdoanh AS vendorByName
    ON vendorByName.ten_dtkd = sp.nhacungung
ORDER BY sp.md_sanpham_id
