-- ANCO1 | SQL REVIEW ONLY — không gắn vào handler xuất Excel trước khi được duyệt.
-- Module MD_00_DSHangHoa_SOANTHAO / Case CA01ExportHHVG_MD00DSHangHoaSOANTHAO
-- Mẫu xuất còn 37 cột A:AK; đã LOẠI BỎ HOÀN TOÀN 4 cột ẩn gốc AA:AD
-- (vd, vn, vl, ghichu_vachngan). Các cột cũ AE:AO dồn về AA:AK.
-- KHÔNG có INSERT/UPDATE/DELETE. Script này chỉ xem dữ liệu/mapping.
-- LƯU Ý: Chưa có quyền DB runtime để xác nhận ad_module/ad_column và bảng đóng gói.
-- Mã thô: chọn BOM hiệu lực mới nhất (ngay_hieuluc <= GETDATE(), ten_phienban khác rỗng).
-- Vật tư con là BTP không phải hỗn hợp (ban_thanhpham=1, vattu=0/NULL).
-- Nếu không có BOM phù hợp/BTP: NULL; nếu có nhiều BTP: các mã ngăn cách bằng ', '.
-- Các trường ĐÓNG GÓI được người dùng xác nhận nằm ở
-- dbo.md_donggoi_ancotrading và dbo.md_donggoisanpham_ancotrading.
-- Source GitHub không lưu entity/DDL của hai bảng này, vì vậy các cột đóng gói
-- còn là NULL có kiểu dữ liệu, KHÔNG đoán tên trường hay khóa JOIN.
-- Chạy phần khảo sát metadata ở cuối file để chốt các trường đóng gói trước khi nối.
-- Chưa xác minh SQL này trên DB thực tế. Đây là bản REVIEW, không phải SQL production.

DECLARE @TrangThai nvarchar(30) = N'SOANTHAO';

SELECT TOP (100)  -- chỉ xem trước; khi tích hợp exporter sẽ bỏ TOP và dùng filter/role của jqGrid
    sp.ma_sanpham AS [Mã hàng],  -- A: md_sanpham.ma_sanpham — xác nhận
    maTho.ma_tho AS [Mã thô],  -- B: từ BOM hiện hành -> các BTP (ban_thanhpham = 1, vattu = 0/NULL); không tách chuỗi mã
    sp.mota_tiengviet AS [Mô Tả Tiếng Việt],  -- C: md_sanpham.mota_tiengviet — xác nhận
    dvt.ten_dvt AS [ĐVT],  -- D: md_donvitinhsanpham — xác nhận
    sp.l_cm AS [L(cm)],  -- E: md_sanpham.l_cm — xác nhận
    sp.w_cm AS [W(cm)],  -- F: md_sanpham.w_cm — xác nhận
    sp.h_cm AS [H(cm)],  -- G: md_sanpham.h_cm — xác nhận
    sp.trongluong AS [Khối lượng (kg)],  -- H: md_sanpham.trongluong — xác nhận
    sp.dientich AS [Diện Tích],  -- I: md_sanpham.dientich — xác nhận
    CAST(NULL AS decimal(18,4)) AS [Thể Tích],  -- J: TODO: công thức/SQL nguồn; không tự suy diễn đơn vị
    hinh.ten_hinhdang AS [Tên kiểu dáng],  -- K: CẦN ĐỐI CHIẾU FK: sp.md_kieudang_id -> md_sanphamhinhdang_id
    CAST(NULL AS nvarchar(255)) AS [Tên chức năng],  -- L: TODO: tên bảng/mapping md_chucnang_id chưa có EF entity tương ứng
    sp.ghichu AS [Ghi chú],  -- M: md_sanpham.ghichu — xác nhận
    CAST(NULL AS decimal(18,4)) AS [SL Inner],  -- N: TODO: dữ liệu đóng gói
    CAST(NULL AS nvarchar(100)) AS [DVT Inner],  -- O: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [l1],  -- P: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [w1],  -- Q: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [h1],  -- R: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [SL Outer],  -- S: TODO: dữ liệu đóng gói
    CAST(NULL AS nvarchar(100)) AS [DVT Outer],  -- T: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [l2],  -- U: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [w2],  -- V: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [h2],  -- W: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [SL Cont 20],  -- X: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [SL Cont 40],  -- Y: TODO: dữ liệu đóng gói
    CAST(NULL AS decimal(18,4)) AS [SL Cont 40 hc],  -- Z: TODO: dữ liệu đóng gói
    CAST(NULL AS datetime) AS [Ngày xác nhận ĐG],  -- AA: TODO: ngày xác nhận đóng gói
    CAST(NULL AS nvarchar(100)) AS [trạng thái ĐG],  -- AB: TODO: trạng thái đóng gói
    CAST(NULL AS nvarchar(1000)) AS [Ghi chú ĐG],  -- AC: TODO: ghi chú đóng gói
    sp.dinhkhoan AS [Định khoản],  -- AD: md_sanpham.dinhkhoan — xác nhận
    nhom.code_cl AS [Nhóm VTHH],  -- AE: mapping theo import SOANTHAO: sp.md_nhomnangluc_id -> md_chungloai_id; kiểm tra tên hiển thị
    ncc.ma_dtkd AS [NCC mặc định],  -- AF: nhacungung -> mã NCC; kiểm tra tên/mã hiển thị trên mẫu
    khoSX.ten_kho AS [Kho SX],  -- AG: khomacdinh -> md_kho.ten_kho; kiểm tra tên/mã hiển thị
    khoTon.ten_kho AS [Kho tồn],  -- AH: khoton -> md_kho.ten_kho; kiểm tra tên/mã hiển thị
    xuong.ten_phongban AS [Xưởng SX],  -- AI: phongbanId -> ad_department.ten_phongban
    thue.ten_thue_sanpham AS [Thuế],  -- AJ: md_thue_sanpham.ten_thue_sanpham — xác nhận
    CAST(CASE WHEN sp.ban_thanhpham = 1 THEN 1 ELSE 0 END AS int) AS [Bán TP]  -- AK: 0/1; NULL được biểu diễn là 0 — xác nhận mong muốn
FROM dbo.md_sanpham AS sp
-- Chọn phiên bản BOM hợp lệ gần nhất theo ngày hiệu lực tại lúc chạy.
-- Không JOIN BOM trực tiếp để tránh một sản phẩm bị nhân thành nhiều hàng.
OUTER APPLY (
    SELECT TOP (1) b.md_sanpham_bom_id
    FROM dbo.md_sanpham_bom AS b
    WHERE b.md_sanpham_id = sp.md_sanpham_id
      AND b.ngay_hieuluc <= GETDATE()
      AND NULLIF(LTRIM(RTRIM(b.ten_phienban)), N'') IS NOT NULL
    ORDER BY b.ngay_hieuluc DESC, b.md_sanpham_bom_id DESC
) AS bomHienHanh
-- Lấy các BTP (mã thô) thuộc BOM đã chọn, tránh lặp mã và giữ 1 dòng/sản phẩm.
-- Nếu một BOM chứa nhiều BTP: ghép các mã phân cách ', ' để không mất dữ liệu.
OUTER APPLY (
    SELECT STUFF((
        SELECT N', ' + q.ma_sanpham
        FROM (
            SELECT DISTINCT vt.ma_sanpham
            FROM dbo.md_sanpham_bom_vattu AS bvt
            INNER JOIN dbo.md_sanpham AS vt
                    ON vt.md_sanpham_id = bvt.md_sanpham_id
            WHERE bvt.md_sanpham_bom_id = bomHienHanh.md_sanpham_bom_id
              AND vt.ban_thanhpham = 1
              AND ISNULL(vt.vattu, 0) = 0
              AND NULLIF(vt.ma_sanpham, N'') IS NOT NULL
        ) AS q
        ORDER BY q.ma_sanpham
        FOR XML PATH(''), TYPE
    ).value('.', 'nvarchar(max)'), 1, 2, N'') AS ma_tho
) AS maTho
LEFT JOIN dbo.md_donvitinhsanpham AS dvt
       ON dvt.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
LEFT JOIN dbo.md_sanphamhinhdang AS hinh   -- cần xác minh FK 'kiểu dáng' tại DB
       ON hinh.md_sanphamhinhdang_id = sp.md_kieudang_id
LEFT JOIN dbo.md_chungloai AS nhom        -- cùng logic ghi md_nhomnangluc_id trong ImportHHVG
       ON nhom.md_chungloai_id = sp.md_nhomnangluc_id
LEFT JOIN dbo.md_doitackinhdoanh AS ncc
       ON ncc.md_doitackinhdoanh_id = sp.nhacungung
LEFT JOIN dbo.md_kho AS khoSX
       ON khoSX.md_kho_id = sp.khomacdinh
LEFT JOIN dbo.md_kho AS khoTon
       ON khoTon.md_kho_id = sp.khoton
LEFT JOIN dbo.ad_department AS xuong
       ON xuong.md_phongban_id = sp.phongbanId
LEFT JOIN dbo.md_thue_sanpham AS thue
       ON thue.md_thue_sanpham_id = sp.md_thue_sanpham_id
WHERE sp.trangthai = @TrangThai
ORDER BY sp.ma_sanpham, sp.md_sanpham_id;

-- ===========================================================================
-- CÁC TRUY VẤN KIỂM TRA MAPPING / CẤU HÌNH (đọc-only; chạy trên DB thực tế)
-- ===========================================================================

-- 1. Cấu hình chính xác của module jqGrid:
SELECT m.ma_module, m.thuake, m.select_sql, m.from_sql, m.where_sql,
       m.groupby_sql, m.orderby_sql, m.procedure_sql
FROM dbo.ad_module AS m
WHERE m.ma_module = N'MD_00_DSHangHoa_SOANTHAO';

-- 2. Định nghĩa từng cột jqGrid (ưu tiên xác minh mã thô, thể tích, đóng gói):
SELECT c.ma_column, c.label, c.ten_column, c.index_cot, c.mota,
       c.hidden, c.hoatdong, c.sapxep
FROM dbo.ad_column AS c
WHERE c.ma_module = N'MD_00_DSHangHoa_SOANTHAO'
ORDER BY c.sapxep, c.ma_column;

-- 3. Trường/tên bảng có thể chứa mapping đóng gói, kiểu dáng, chức năng:
SELECT t.name AS table_name, c.name AS column_name
FROM sys.tables AS t
JOIN sys.columns AS c ON c.object_id = t.object_id
WHERE t.name LIKE N'%donggoi%' OR t.name LIKE N'%quycach%'
   OR t.name LIKE N'%chucnang%' OR t.name LIKE N'%kieudang%'
   OR c.name LIKE N'%inner%' OR c.name LIKE N'%outer%'
   OR c.name LIKE N'%cont%' OR c.name LIKE N'%donggoi%'
   OR c.name LIKE N'%tho%' OR c.name LIKE N'%the_tich%'
ORDER BY t.name, c.column_id;

-- 4. Ví dụ giá trị gốc để hiểu cấu trúc quycachdonggoi (không giả định JSON/CSV):
SELECT TOP (10) sp.ma_sanpham, sp.ma_sanphamcu, sp.quycachdonggoi,
       sp.md_kieudang_id, sp.md_chucnang_id, sp.md_nhomnangluc_id
FROM dbo.md_sanpham AS sp
WHERE sp.trangthai = @TrangThai
ORDER BY sp.ma_sanpham;


-- 5. Hai bảng đóng gói đã được xác nhận là nguồn dữ liệu:
-- Kiểm tra cấu trúc, chỉ đọc metadata; không suy diễn khóa liên kết.
SELECT t.name AS table_name,
       c.column_id, c.name AS column_name, ty.name AS sql_type,
       c.max_length, c.is_nullable,
       CASE WHEN pk.column_id IS NULL THEN 0 ELSE 1 END AS is_primary_key
FROM sys.tables AS t
JOIN sys.columns AS c ON c.object_id = t.object_id
JOIN sys.types AS ty ON ty.user_type_id = c.user_type_id
LEFT JOIN (
    SELECT ic.object_id, ic.column_id
    FROM sys.indexes AS i
    JOIN sys.index_columns AS ic
      ON ic.object_id = i.object_id AND ic.index_id = i.index_id
    WHERE i.is_primary_key = 1
) AS pk ON pk.object_id = c.object_id AND pk.column_id = c.column_id
WHERE t.name IN (N'md_donggoi_ancotrading', N'md_donggoisanpham_ancotrading')
ORDER BY t.name, c.column_id;

-- 6. Khóa ngoại thực tế liên kết hai bảng trên và tới md_sanpham:
SELECT fk.name AS fk_name,
       OBJECT_NAME(fk.parent_object_id) AS child_table,
       pc.name AS child_column,
       OBJECT_NAME(fk.referenced_object_id) AS parent_table,
       rc.name AS parent_column
FROM sys.foreign_keys AS fk
JOIN sys.foreign_key_columns AS fkc
  ON fkc.constraint_object_id = fk.object_id
JOIN sys.columns AS pc
  ON pc.object_id = fkc.parent_object_id
 AND pc.column_id = fkc.parent_column_id
JOIN sys.columns AS rc
  ON rc.object_id = fkc.referenced_object_id
 AND rc.column_id = fkc.referenced_column_id
WHERE OBJECT_NAME(fk.parent_object_id) IN
    (N'md_donggoi_ancotrading', N'md_donggoisanpham_ancotrading')
   OR OBJECT_NAME(fk.referenced_object_id) IN
    (N'md_donggoi_ancotrading', N'md_donggoisanpham_ancotrading')
ORDER BY child_table, fk_name, fkc.constraint_column_id;

-- 7. Đọc mẫu nội dung từng bảng để nhận diện Inner, Outer, Cont, trạng thái:
-- SELECT TOP (5) * FROM dbo.md_donggoi_ancotrading;
-- SELECT TOP (5) * FROM dbo.md_donggoisanpham_ancotrading;
-- (Bỏ '--' ở hai dòng trên khi chạy DB thử; dữ liệu có thể nhạy cảm.)

-- 8. Kiểm tra mã thô và BOM được chọn cho vài sản phẩm:
SELECT TOP (20) sp.ma_sanpham AS ma_hang,
       bom.md_sanpham_bom_id, bom.ten_phienban, bom.ngay_hieuluc,
       bvt.md_sanpham_id AS vat_tu_id,
       vt.ma_sanpham AS ma_tho,
       vt.ban_thanhpham, vt.vattu
FROM dbo.md_sanpham AS sp
OUTER APPLY (
    SELECT TOP (1) b.md_sanpham_bom_id, b.ten_phienban, b.ngay_hieuluc
    FROM dbo.md_sanpham_bom AS b
    WHERE b.md_sanpham_id = sp.md_sanpham_id
      AND b.ngay_hieuluc <= GETDATE()
      AND NULLIF(LTRIM(RTRIM(b.ten_phienban)), N'') IS NOT NULL
    ORDER BY b.ngay_hieuluc DESC, b.md_sanpham_bom_id DESC
) AS bom
LEFT JOIN dbo.md_sanpham_bom_vattu AS bvt
  ON bvt.md_sanpham_bom_id = bom.md_sanpham_bom_id
LEFT JOIN dbo.md_sanpham AS vt
  ON vt.md_sanpham_id = bvt.md_sanpham_id
WHERE sp.trangthai = @TrangThai
ORDER BY sp.ma_sanpham, vt.ma_sanpham;

-- SAU KHI DUYỆT: lấy chính SQL cấu hình, where theo role và filter jqGrid tại
-- server, KHÔNG dùng WHERE này như cơ chế phân quyền production; bỏ TOP (100).
