# Kế hoạch triển khai Excel export — MD_00_DSHangHoa_SOANTHAO

**Case:** `CA01ExportHHVG_MD00DSHangHoaSOANTHAO`  
**Trạng thái:** Chỉ lập kế hoạch, **chưa triển khai chức năng**.  
**Mẫu thực tế đã kiểm tra:** `Danh sách hàng hóa-23_10_2026 13_18_02.xls` (SHA-256 `b72f0981b6425930ea983c7f7ebea228e61e7cfe9eb594621de06507fff85aa5`).  
**Quy tắc repo:** đọc `AGENTS.md` + `docs/knowledge-base/`; chỉ code tại GitHub, Azure DevOps chỉ đồng bộ sau kiểm thử và yêu cầu phát hành riêng.  

## 1. Hiện trạng đã xác nhận từ source

- JS: `eman_ver3/js/Module_script/MD_00_DSHangHoa_SOANTHAO.js`, hàm `CA01ExportHHVG_MD00DSHangHoaSOANTHAO` đã có popup xác nhận nhưng **bắt buộc `selrow`**, gửi POST chỉ có `id`, sau đó gọi `oper=savefile`.
- Handler: `eman_ver3/Controller/JQGridModify/JQGridMD_00_DSHangHoa_SOANTHAOModify.ashx` hiện **không có switch case** cho `CA01ExportHHVG_MD00DSHangHoaSOANTHAO` và `savefile`, không có phương thức xuất Excel cho case này.
- jqGrid Load: `eman_ver3/Controller/JQGrid/JQGridMD_00_DSHangHoa_SOANTHAOLoad.ashx` tạo danh sách từ `VNN_Config.Select_sql` + `ad_module.from_sql/where_sql` + `ad_role_where` + bộ lọc `Helper.getFilter/getFilterP`, sau đó mới phân trang. Phần export phải lấy cùng tập dữ liệu nhưng không áp giới hạn trang.
- Đã có tiền lệ tạo HSSFWorkbook/NPOI trong `JQGridMD_00_DSHangHoaModify.ashx` (`CA_01_ExportHH`, `EXport_EXHH`, `SaveFile`); **tham khảo API/chức năng, không sao chép truy vấn hoặc danh sách cột 22 cột vì mẫu mới khác**.

## 2. Đặc tả Excel từ file mẫu (đã xác nhận từ cấu trúc .xls)

- File định dạng **Excel 97-2003 `.xls`**, sheet tên `Sheet1`. Mẫu có **3 dòng**: 1 header + 2 dòng dữ liệu minh họa.
- Có **41 cột A:AO**, mỗi cột có tiêu đề tại dòng 1; dữ liệu bắt đầu từ dòng 2.
- Header cao khoảng **62.4 pt**, dòng dữ liệu **13.8 pt**. Cột A và B rộng khoảng 15.9 ký tự; C 28.1; D 7.8; E:G 7.0; H 12.4; I:J 10.9; K:L 15.7; M 18.8; AH:AI 12.4; AJ:AL 15.7; AM 18.8; AN:AO 9.3.
- **AA:AD có nội dung header, nhưng đang ẩn**, phải giữ cấu trúc và thuộc tính ẩn nếu tái hiện chính xác.
- Mẫu biểu hiện 3 dạng giá trị: **text**, **số thực** (L/W/H, trọng lượng, diện tích, thể tích), **trống thực sự**. `Bán TP` đang xuất chuỗi `0` (cần chuẩn hóa 0/1 khi triển khai). Ngày đóng gói cần xác định định dạng từ DB/config nếu có giá trị thực tế (hai dòng mẫu đang trống).
- Mẫu không có bảng tổng hợp/công thức cần tính; chỉ danh sách hàng hóa.

### Thứ tự cột bắt buộc (không lấy theo vị trí thay đổi bởi UI cá nhân)

| Cột | Tiêu đề mẫu | Nguồn/mapping kế hoạch |
|---|---|---|
| A | Mã hàng | `md_sanpham.ma_sanpham` |
| B | Mã thô | **Cần đối chiếu `ad_column` / SQL**; không tự cho rằng là `ma_sanphamcu` |
| C | Mô Tả Tiếng Việt | `md_sanpham.mota_tiengviet` |
| D | ĐVT | Join `md_donvitinhsanpham`, giá trị hiển thị `ten_dvt` |
| E | L(cm) | `md_sanpham.l_cm` |
| F | W(cm) | `md_sanpham.w_cm` |
| G | H(cm) | `md_sanpham.h_cm` |
| H | Khối lượng (kg) | `md_sanpham.trongluong` |
| I | Diện Tích | `md_sanpham.dientich` |
| J | Thể Tích | **Cần kiểm tra SQL biểu thức** (không thấy trường trực tiếp trong entity `md_sanpham`) |
| K | Tên kiểu dáng | Join theo `md_kieudang_id`; xác định cột mô tả trong DB |
| L | Tên chức năng | Join theo `md_chucnang_id`; xác định cột mô tả trong DB |
| M | Ghi chú | `md_sanpham.ghichu` |
| N | SL Inner | **Cần kiểm tra projection/bảng đóng gói** |
| O | DVT Inner | **Cần kiểm tra projection/bảng đóng gói** |
| P | l1 | **Cần kiểm tra projection/bảng đóng gói** |
| Q | w1 | **Cần kiểm tra projection/bảng đóng gói** |
| R | h1 | **Cần kiểm tra projection/bảng đóng gói** |
| S | SL Outer | **Cần kiểm tra projection/bảng đóng gói** |
| T | DVT Outer | **Cần kiểm tra projection/bảng đóng gói** |
| U | l2 | **Cần kiểm tra projection/bảng đóng gói** |
| V | w2 | **Cần kiểm tra projection/bảng đóng gói** |
| W | h2 | **Cần kiểm tra projection/bảng đóng gói** |
| X | SL Cont 20 | **Cần kiểm tra projection/bảng đóng gói** |
| Y | SL Cont 40 | **Cần kiểm tra projection/bảng đóng gói** |
| Z | SL Cont 40 hc | **Cần kiểm tra projection/bảng đóng gói** |
| AA | vd | **Cần xác định mapping; cột ẩn** |
| AB | vn | **Cần xác định mapping; cột ẩn** |
| AC | vl | **Cần xác định mapping; cột ẩn** |
| AD | ghichu_vachngan | **Cần xác định mapping; cột ẩn** |
| AE | Ngày xác nhận ĐG | **Cần xác định mapping/ngữ nghĩa và định dạng ngày** |
| AF | trạng thái ĐG | **Cần xác định mapping từ dữ liệu đóng gói** |
| AG | Ghi chú ĐG | **Cần xác định mapping từ dữ liệu đóng gói** |
| AH | Định khoản | `md_sanpham.dinhkhoan` |
| AI | Nhóm VTHH | Xác định chính xác mã/nhãn từ `md_nhomnangluc_id` hoặc cấu hình SQL |
| AJ | NCC mặc định | `md_sanpham.nhacungung`, join lấy mã/tên hiển thị theo mẫu |
| AK | Kho SX | `md_sanpham.khomacdinh`, join `md_kho.ten_kho` |
| AL | Kho tồn | `md_sanpham.khoton`, join `md_kho.ten_kho` |
| AM | Xưởng SX | `md_sanpham.phongbanId`, join bảng phòng ban, xác định giá trị hiển thị |
| AN | Thuế | `md_sanpham.md_thue_sanpham_id`, join tên thuế |
| AO | Bán TP | `md_sanpham.ban_thanhpham`, biểu diễn 0/1 |

**Không được triển khai mapping chưa xác thực bằng giả định.** Trước khi code cần lấy SQL module thực tế và `ad_column`/bảng liên quan trong database để chốt các cột còn thiếu. Tên hiển thị không nhất thiết bằng tên field/entity.

## 3. Luồng UI đề xuất

1. Khi người dùng nhấn case xuất Excel, lấy trạng thái bộ lọc jqGrid đang áp dụng: `_search`, `filters`, `sidx`, `sord`, module/context; giữ nguyên khả năng lọc nhiều điều kiện.
2. **Mặc định xuất tất cả hàng hóa khớp bộ lọc trên mọi trang**, không chỉ `selrow` hay những dòng được tick. Nếu jqGrid chưa lọc thì export toàn bộ dữ liệu được phép xem trong module và popup phải cảnh báo số lượng lớn. Đây là lựa chọn triển khai đề xuất, chưa phải một điều kiện nghiệp vụ đã được chủ dự án chốt riêng.
3. Popup: tiêu đề case từ `get_Forminfor`, thông báo số dòng dự kiến, nút `Xuất Excel` / `Thoát` với icon đúng chuẩn qua `Logo_Center`.
4. Khi xác nhận, thực thi download bằng POST/form/iframe hay phương thức download tương thích WebForms; trả về **tệp binary .xls trực tiếp** thay vì HTML giả thành công. Giữ nguyên filter trong request, chặn nhấn lặp.
5. Thông báo rõ trạng thái 0 dòng/lỗi/permission. Không biến đổi trạng thái hàng hóa hoặc dữ liệu trong DB.

## 4. Thiết kế server

- Bổ sung duy nhất case `CA01ExportHHVG_MD00DSHangHoaSOANTHAO` trong `JQGridMD_00_DSHangHoa_SOANTHAOModify.ashx`; quyền `Security.id_taikhoan` + `Security.PhanQuyen_ChucNang(context, maModule, maCase)`.
- Tạo hàm đọc **read-only** tái sử dụng cùng module SQL/where_role/filter của jqGrid Load, bỏ paging; whitelist trường/operator lọc và áp toàn bộ điều kiện role/module ở server. **Không nhận SQL thô từ browser**, không dùng trực tiếp string `where_ex` tùy ý cho truy vấn xuất hàng loạt.
- Ưu tiên dựa trên projection cấu hình thực tế để lấy dữ liệu hiển thị giống jqGrid; nếu cần thêm join để điền 41 cột, định nghĩa mapping tường minh và kiểm thử quan hệ 1:N không làm nhân bản mã hàng.
- Tạo Excel bằng **NPOI HSSFWorkbook** hiện có, tái hiện 41 header + kiểu dữ liệu + chiều rộng/chiều cao + 4 cột ẩn của mẫu; dữ liệu text an toàn với Excel, không dựng công thức từ text nhập vào.
- `.xls` giới hạn 65.536 dòng/sheet (gồm 1 header): tự chia sheet khi quá giới hạn, hoặc chọn `.xlsx` nếu có yêu cầu đổi định dạng; không được cắt mất dữ liệu im lặng.
- Chỉ ghi đúng số byte của MemoryStream ra Response; đảm bảo MIME và Content-Disposition UTF-8 filename hợp lệ. Tránh lưu `HSSFWorkbook` trong Session dùng chung giữa các lượt xuất, vì có thể ghi đè/chồng trạng thái khi tải đồng thời.
- Nếu dữ liệu rất lớn: timeout hợp lý, lấy theo batch/streaming và giải phóng tài nguyên, không khóa giao diện vô thời hạn.

## 5. Các bước thực hiện dự kiến

1. **Khảo sát DB/config**: chốt SQL `ad_module`, `ad_column`, trạng thái/sort/filter và mapping 41 cột (đặc biệt B, J, N:AG, AI:AJ).
2. **Tạo truy vấn read-only** lấy toàn bộ kết quả lọc theo quyền và thứ tự sort; kiểm tra chính xác số dòng, không nhân bản.
3. **Viết export NPOI** (.xls) tái hiện header, kích thước, ẩn cột và kiểu dữ liệu của mẫu; đối chiếu hai mã hàng minh họa trong sample.
4. **Hoàn thiện case JavaScript**: lọc toàn bộ, popup xác nhận, download, icon, lỗi.
5. **Kiểm thử**: 0/1/nhiều dòng, lọc nhiều điều kiện, qua nhiều trang, đúng quyền role, không lọc, cột ẩn, Unicode, số thập phân, Null vs 0, Excel mở sạch, >65.535 dòng, tải đồng thời, không ghi dữ liệu DB.
6. **Rà soát diff + cập nhật knowledge** sau khi xác thực mapping. Commit/test trên GitHub trước. **Không tự đồng bộ Azure DevOps**; chỉ phát hành qua workflow PR riêng theo chính sách dự án khi chủ dự án yêu cầu.

## 6. Tiêu chí hoàn tất

- Xuất file `.xls` mở đúng trên Excel, sheet(s) giữ nguyên 41 cột và 4 cột ẩn; tiêu đề theo thứ tự mẫu.
- Hàng xuất khớp 100% bộ lọc/role trên jqGrid ở mọi trang (cùng thời điểm truy vấn), không rò dữ liệu ngoài phạm vi được cấp quyền.
- Không sai kiểu dữ liệu, không biến mã thành số, không bỏ bản ghi hoặc nhân đôi do join.
- Người dùng nhận file tải xuống với một thao tác xác nhận; handler trả lỗi rõ ràng; không chỉnh sửa DB.
- Kết quả được kiểm thử thủ công trên Anco1 và chủ dự án xác nhận trước khi phát hành Azure.
