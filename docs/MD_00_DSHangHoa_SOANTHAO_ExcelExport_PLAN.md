# Kế hoạch triển khai Excel export — MD_00_DSHangHoa_SOANTHAO

**Case:** `CA01ExportHHVG_MD00DSHangHoaSOANTHAO`  
**Trạng thái 24/10/2026:** **Đã code xuất Excel `.xls` 37 cột trên GitHub `master`**, truy vấn SQL đã kiểm chứng (18 hàng SOANTHAO). **Đã kiểm tra cú pháp JavaScript và cấu trúc 37 cột; chưa thử WebForms tạo/tải file thực tế.** File: `docs/sql/MD_00_DSHangHoa_SOANTHAO_ExportHHVG_DRAFT.sql`.  
**Mẫu thực tế đã kiểm tra:** `Danh sách hàng hóa-23_10_2026 13_18_02.xls` (SHA-256 `b72f0981b6425930ea983c7f7ebea228e61e7cfe9eb594621de06507fff85aa5`).  
**Quy tắc repo:** đọc `AGENTS.md` + `docs/knowledge-base/`; chỉ code tại GitHub, Azure DevOps chỉ đồng bộ sau kiểm thử và yêu cầu phát hành riêng.  

> **Điều chỉnh 24/10/2026:** người dùng xác nhận bỏ hoàn toàn 4 cột ẩn AA–AD gốc. Từ đây mọi file xuất chỉ có **37 cột**; bản SQL nháp để duyệt xem trong `docs/sql/MD_00_DSHangHoa_SOANTHAO_ExportHHVG_DRAFT.sql` (không áp phân quyền thực tế, không chạy xuất file).

> **Bổ sung 24/10/2026:** người dùng xác nhận `Mã thô` lấy qua `md_sanpham_bom` và `md_sanpham_bom_vattu`, nhóm đóng gói lấy từ `md_donggoi_ancotrading` và `md_donggoisanpham_ancotrading`. SQL nháp đã xử lý BOM bằng `OUTER APPLY` để giữ một dòng/sản phẩm, và bổ sung câu khảo sát schema/foreign keys hai bảng đóng gói. Hai bảng đóng gói đã được đối chiếu từ schema và dữ liệu thực; SQL đã lấy đủ thông tin đóng gói.

> **Kiểm chứng 24/10/2026 từ các CSV được chủ dự án cung cấp:**
> - `Results1.csv`: cấu hình `ad_module`, gồm `select_sql`, `from_sql`, `where_sql`, `orderby_sql` thực của `MD_00_DSHangHoa_SOANTHAO`.
> - `Results2.csv`: danh sách `ad_column`; xác nhận `sp.v2` là CBM mặc định, `kd.ten_tv` là tên kiểu dáng, `cn.ten_tv` là tên chức năng, cũng như nhãn nhà cung cấp/kho/xưởng/thuế.
> - `Results3.csv`: danh sách tên cột/tên bảng (từ `sys.tables` và `sys.columns`), **không phải** kết quả foreign keys hoặc giá trị dữ liệu mẫu. Xác nhận các trường thực tế tại `md_donggoi_ancotrading`: `sl_inner`, `dvt_inner`, `l1/w1/h1`, `sl_outer`, `dvt_outer`, `l2_mix/w2_mix/h2_mix`, `soluonggoi_ctn_20`, `soluonggoi_ctn`, `soluonggoi_ctn_40hc`, `ngayxacnhan`, `trangthai`, `mota`; cùng `md_donggoisanpham_ancotrading`: `md_sanpham_id`, `md_donggoi_id`, `macdinh`, `hoatdong`.
> - JOIN đóng gói hiện **dự kiến** qua `ds.md_donggoi_id = p.md_donggoi_id`, chọn bản `macdinh=1` đang hoạt động và cập nhật gần nhất. Dữ liệu SOANTHAO đã kiểm tra 18/18 sản phẩm có một liên kết mặc định/đang hoạt động, JOIN không nhân dòng; database không khai báo FK cho hai bảng này. `SL Cont 40` đang lấy `soluonggoi_ctn` (có giá trị thực tế); cần thống nhất ngữ nghĩa nhãn.

> **Kết quả kiểm chứng SQL Server 24/10/2026 (GitHub Actions, SELECT read-only):**
> - `sql/inspect-packaging-review.sql`: tập SOANTHAO có 18 sản phẩm và 18 link đóng gói; 18/18 link khớp cấu hình, còn hoạt động và là mặc định; 0 orphan, 0 bản ghi mặc định trùng, 0 `md_donggoi_id` trùng vật lý trong bảng đóng gói. Hai bảng không khai báo foreign keys trong `sys.foreign_keys`.
> - `sql/inspect-product-export-preview.sql`: SQL xuất 37 cột trả về 18 hàng, 18 mã khác nhau; Inner/Outer/Cont/ngày xác nhận/trạng thái/ghi chú có dữ liệu; cột `Mã thô` rỗng do **0 sản phẩm SOANTHAO có BOM**; `sp.v2` đang NULL ở cả 18 hàng; các giá trị `Định khoản` đến `Thuế` cũng đang NULL theo dữ liệu này.
> - `sql/inspect-packaging-units.sql`: ID ở `dvt_inner`/`dvt_outer` được giải đúng bằng **`md_donvitinh.md_donvitinh_id`** (không phải `md_donvitinhsanpham`); đã kiểm tra 30 mã ĐVT đang sử dụng trên toàn bộ bảng đóng gói.
> - `sql/inspect-bom-child-types.sql`: BOM hiệu lực phiên bản mới nhất hiện có trên sản phẩm trạng thái DHD; trong tập đó có 8.998 sản phẩm cha chứa BTP trực tiếp. Không đồng nghĩa hàng SOANTHAO có BOM.
> - Đã sửa SQL và query preview trả tên ĐVT Inner/Outer thay vì GUID. Những số lượng sản phẩm là snapshot database tại thời điểm kiểm thử, không phải quy tắc nghiệp vụ cố định.

> **Kiểm tra đầy đủ dữ liệu ngày 24/10/2026 (GitHub Actions: [raw-field audit](https://github.com/ngocnhanvo/anco1/actions/runs/40077255258), [NCC audit](https://github.com/ngocnhanvo/anco1/actions/runs/40077401500)):**
> - File kết quả SQL 37 cột có 18 dòng; **27 cột có ít nhất một giá trị**, **10 cột đều trống**: Mã thô, Thể Tích, Ghi chú, Định khoản, Nhóm VTHH, NCC mặc định, Kho SX, Kho tồn, Xưởng SX, Thuế.
> - **Mã thô:** cách lấy từ BOM đã được chủ dự án xác nhận đúng; 18 hàng SOANTHAO chưa có BOM.
> - **8 cột trống do dữ liệu gốc chưa nhập:** `sp.v2`, `sp.ghichu`, `sp.dinhkhoan`, `sp.md_nhomnangluc_id`, `sp.khomacdinh`, `sp.khoton`, `sp.phongbanId`, `sp.md_thue_sanpham_id` đều có **0/18 giá trị**.
> - **NCC mặc định là trường hợp cần xử lý riêng:** `sp.nhacungung` có **18/18 giá trị**, cả 18 dùng cùng một ID, nhưng **0/18** tìm thấy bản ghi tại `md_doitackinhdoanh` bằng `md_doitackinhdoanh_id`, `ma_dtkd` hoặc `ten_dtkd`. Đây là tham chiếu NCC không giải được thành tên/mã bằng bảng tra cứu hiện tại; **không được giả định cột đã hoàn tất**.
> - Câu SQL 37 cột đã chạy thành công trên DB thực tế, đủ 18 hàng, nhưng chưa nên xem mapping NCC là hoàn chỉnh trước khi xác minh nguồn tra cứu/khắc phục tham chiếu. Các trường NULL gốc không phải thiếu JOIN.

## 1. Hiện trạng đã xác nhận từ source

- JS: `eman_ver3/js/Module_script/MD_00_DSHangHoa_SOANTHAO.js` đã chuyển sang popup preview và POST tải Blob `.xls`, không yêu cầu `selrow`, lấy theo toàn bộ kết quả lọc mọi trang.
- Handler: `eman_ver3/Controller/JQGridModify/JQGridMD_00_DSHangHoa_SOANTHAOModify.ashx` đã có switch case xuất; `mode=preview` trả JSON/snapshot, `mode=download` trả NPOI binary `.xls`, không dùng `savefile` hoặc Session để giữ workbook.
- jqGrid Load: `eman_ver3/Controller/JQGrid/JQGridMD_00_DSHangHoa_SOANTHAOLoad.ashx` tạo danh sách từ `VNN_Config.Select_sql` + `ad_module.from_sql/where_sql` + `ad_role_where` + bộ lọc `Helper.getFilter/getFilterP`, sau đó mới phân trang. Phần export phải lấy cùng tập dữ liệu nhưng không áp giới hạn trang.
- Đã có tiền lệ tạo HSSFWorkbook/NPOI trong `JQGridMD_00_DSHangHoaModify.ashx` (`CA_01_ExportHH`, `EXport_EXHH`, `SaveFile`); **tham khảo API/chức năng, không sao chép truy vấn hoặc danh sách cột 22 cột vì mẫu mới khác**.

## 2. Đặc tả Excel từ file mẫu (đã xác nhận từ cấu trúc .xls)

- File định dạng **Excel 97-2003 `.xls`**, sheet tên `Sheet1`. Mẫu có **3 dòng**: 1 header + 2 dòng dữ liệu minh họa.
- Mẫu gốc có **41 cột A:AO**. **Theo yêu cầu mới: file xuất chỉ còn 37 cột A:AK**, bỏ hoàn toàn 4 cột ẩn AA:AD của mẫu gốc; dữ liệu bắt đầu từ dòng 2.
- Header cao khoảng **62.4 pt**, dòng dữ liệu **13.8 pt**. Cột A và B rộng khoảng 15.9 ký tự; C 28.1; D 7.8; E:G 7.0; H 12.4; I:J 10.9; K:L 15.7; M 18.8; AH:AI 12.4; AJ:AL 15.7; AM 18.8; AN:AO 9.3.
- **Bỏ hoàn toàn các cột ẩn trong file xuất:** `vd`, `vn`, `vl`, `ghichu_vachngan`. Các cột mẫu gốc AE:AO được dồn trái thành AA:AK.
- Mẫu biểu hiện 3 dạng giá trị: **text**, **số thực** (L/W/H, trọng lượng, diện tích, thể tích), **trống thực sự**. `Bán TP` đang xuất chuỗi `0` (cần chuẩn hóa 0/1 khi triển khai). Ngày đóng gói cần xác định định dạng từ DB/config nếu có giá trị thực tế (hai dòng mẫu đang trống).
- Mẫu không có bảng tổng hợp/công thức cần tính; chỉ danh sách hàng hóa.

### Thứ tự **37 cột xuất** bắt buộc (không lấy theo vị trí thay đổi bởi UI cá nhân)

| Cột | Tiêu đề mẫu | Nguồn/mapping kế hoạch |
|---|---|---|
| A | Mã hàng | `md_sanpham.ma_sanpham` |
| B | Mã thô | **Nguồn đã xác nhận:** `md_sanpham_bom` → `md_sanpham_bom_vattu` → `md_sanpham` mã vật tư con. SQL nháp chọn BOM còn hiệu lực gần nhất, ưu tiên BTP thuần (`ban_thanhpham=1`, `vattu=0/NULL`), ghép các mã nếu nhiều; cần duyệt cách chọn kết quả cuối |
| C | Mô Tả Tiếng Việt | `md_sanpham.mota_tiengviet` |
| D | ĐVT | Join `md_donvitinhsanpham`, giá trị hiển thị `ten_dvt` |
| E | L(cm) | `md_sanpham.l_cm` |
| F | W(cm) | `md_sanpham.w_cm` |
| G | H(cm) | `md_sanpham.h_cm` |
| H | Khối lượng (kg) | `md_sanpham.trongluong` |
| I | Diện Tích | `md_sanpham.dientich` |
| J | Thể Tích | `sp.v2` theo cột `CBM mặc định` trong `ad_column` (cần xác minh giá trị thực với mẫu) |
| K | Tên kiểu dáng | `md_kieudang_ancotrading kd` → `kd.ten_tv` theo cấu hình `ad_module` |
| L | Tên chức năng | `md_chucnang_ancotrading cn` → `cn.ten_tv` theo cấu hình `ad_module` |
| M | Ghi chú | `md_sanpham.ghichu` |
| N | SL Inner | `md_donggoi_ancotrading.sl_inner` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| O | DVT Inner | `md_donggoi_ancotrading.dvt_inner` (GUID) → `md_donvitinh.md_donvitinh_id` → `ten_dvt` (đã đối chiếu 30 mã ĐVT thực tế) |
| P | l1 | `md_donggoi_ancotrading.l1` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| Q | w1 | `md_donggoi_ancotrading.w1` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| R | h1 | `md_donggoi_ancotrading.h1` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| S | SL Outer | `md_donggoi_ancotrading.sl_outer` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| T | DVT Outer | `md_donggoi_ancotrading.dvt_outer` (GUID) → `md_donvitinh.md_donvitinh_id` → `ten_dvt` (đã đối chiếu 30 mã ĐVT thực tế) |
| U | l2 | `md_donggoi_ancotrading.l2_mix` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| V | w2 | `md_donggoi_ancotrading.w2_mix` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| W | h2 | `md_donggoi_ancotrading.h2_mix` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| X | SL Cont 20 | `md_donggoi_ancotrading.soluonggoi_ctn_20` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| Y | SL Cont 40 | `md_donggoi_ancotrading.soluonggoi_ctn` qua bảng liên kết `md_donggoisanpham_ancotrading` (chờ kiểm tra ngữ nghĩa dữ liệu) |
| Z | SL Cont 40 hc | `md_donggoi_ancotrading.soluonggoi_ctn_40hc` qua bảng liên kết `md_donggoisanpham_ancotrading` (đã xác nhận tồn tại cột) |
| AA | Ngày xác nhận ĐG | `md_donggoi_ancotrading.ngayxacnhan` qua bảng liên kết `md_donggoisanpham_ancotrading` (chờ kiểm tra ngữ nghĩa dữ liệu) |
| AB | trạng thái ĐG | `md_donggoi_ancotrading.trangthai` qua bảng liên kết `md_donggoisanpham_ancotrading` (chờ kiểm tra ngữ nghĩa dữ liệu) |
| AC | Ghi chú ĐG | `md_donggoi_ancotrading.mota` qua bảng liên kết `md_donggoisanpham_ancotrading` (chờ kiểm tra ngữ nghĩa dữ liệu) |
| AD | Định khoản | `md_sanpham.dinhkhoan` |
| AE | Nhóm VTHH | Xác định chính xác mã/nhãn từ `md_nhomnangluc_id` hoặc cấu hình SQL |
| AF | NCC mặc định | `md_sanpham.nhacungung` (18/18 có ID) nhưng JOIN `md_doitackinhdoanh` hiện không tìm thấy bản ghi (0/18); cần sửa dữ liệu tham chiếu hoặc chốt nguồn lookup khác trước khi xuất mã NCC |
| AG | Kho SX | `md_sanpham.khomacdinh`, join `md_kho.ten_kho` |
| AH | Kho tồn | `md_sanpham.khoton`, join `md_kho.ten_kho` |
| AI | Xưởng SX | `md_sanpham.phongbanId`, join bảng phòng ban, xác định giá trị hiển thị |
| AJ | Thuế | `md_sanpham.md_thue_sanpham_id`, join tên thuế |
| AK | Bán TP | `md_sanpham.ban_thanhpham`, biểu diễn 0/1 |

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
- Ưu tiên dựa trên projection cấu hình thực tế để lấy dữ liệu hiển thị giống jqGrid; khi điền 37 cột cần mapping tường minh và kiểm thử quan hệ 1:N không làm nhân bản mã hàng. Với BOM dùng OUTER APPLY; với đóng gói phải xác định bản ghi đúng/ưu tiên phiên bản trước khi JOIN.
- Tạo Excel bằng **NPOI HSSFWorkbook** hiện có, tái hiện đúng **37 header liên tiếp, không xuất 4 cột ẩn gốc**, kiểu dữ liệu và kích thước cột; dữ liệu text an toàn với Excel, không dựng công thức từ text nhập vào.
- `.xls` giới hạn 65.536 dòng/sheet (gồm 1 header): tự chia sheet khi quá giới hạn, hoặc chọn `.xlsx` nếu có yêu cầu đổi định dạng; không được cắt mất dữ liệu im lặng.
- Chỉ ghi đúng số byte của MemoryStream ra Response; đảm bảo MIME và Content-Disposition UTF-8 filename hợp lệ. Tránh lưu `HSSFWorkbook` trong Session dùng chung giữa các lượt xuất, vì có thể ghi đè/chồng trạng thái khi tải đồng thời.
- Nếu dữ liệu rất lớn: timeout hợp lý, lấy theo batch/streaming và giải phóng tài nguyên, không khóa giao diện vô thời hạn.

## Đã triển khai trên GitHub, chờ kiểm thử WebForms thực tế

- [x] Handler + UI case có kiểm tra đăng nhập, `PhanQuyen_ChucNang`, cùng module SQL, `ad_role_where` và lọc jqGrid.
- [x] Xuất theo mọi trang, không cần chọn dòng; preview số dòng và snapshot trước khi tải.
- [x] SELECT 37 cột bằng `SqlParameter` theo lô 300 ID; giữ đúng thứ tự ID được cấp quyền.
- [x] NPOI `.xls`, định dạng cột tiêu đề/số/ngày/NULL, tạo sheet mới sau 65.535 dòng dữ liệu, trả bytes trực tiếp.
- [x] Kiểm tra cú pháp JS và kiểm tra tĩnh số tiêu đề/độ rộng 37, cấu trúc truy vấn, quyền server.
- [ ] Kiểm thử WebForms có phiên đăng nhập hợp lệ, tải/mở `.xls` thực, không lọc/lọc/0 dòng/nhiều trang, dữ liệu mẫu, phân quyền.
- [ ] Chỉ phát hành Azure DevOps sau kiểm thử và yêu cầu riêng của chủ dự án.

Chức năng chủ động từ chối `where_ex` tùy ý của browser để tránh truy vấn ngoài quyền; không đồng bộ Azure ở bước triển khai GitHub này.
## 5. Các bước thực hiện dự kiến

1. **Đã nhận schema CSV**: xác nhận cấu hình SQL module, nhãn cột và các trường AncoTrading. Còn cần kiểm tra FK/thực tế nhiều dòng đóng gói, thứ tự chọn `macdinh`, bản BOM thích hợp và giá trị `SL Cont 40`.
2. **Tạo truy vấn read-only** lấy toàn bộ kết quả lọc theo quyền và thứ tự sort; kiểm tra chính xác số dòng, không nhân bản.
3. **Viết export NPOI** (.xls) tái hiện header, kích thước, ẩn cột và kiểu dữ liệu của mẫu; đối chiếu hai mã hàng minh họa trong sample; bỏ 4 cột ẩn gốc.
4. **Hoàn thiện case JavaScript**: lọc toàn bộ, popup xác nhận, download, icon, lỗi.
5. **Kiểm thử**: 0/1/nhiều dòng, lọc nhiều điều kiện, qua nhiều trang, đúng quyền role, không lọc, loại bỏ cột ẩn, nhiều BOM/đóng gói không nhân dòng, Unicode, số thập phân, Null vs 0, Excel mở sạch, >65.535 dòng, tải đồng thời, không ghi dữ liệu DB.
6. **Rà soát diff + cập nhật knowledge** sau khi xác thực mapping. Commit/test trên GitHub trước. **Không tự đồng bộ Azure DevOps**; chỉ phát hành qua workflow PR riêng theo chính sách dự án khi chủ dự án yêu cầu.

## 6. Tiêu chí hoàn tất

- Xuất file `.xls` mở đúng trên Excel, sheet(s) có **37 cột A:AK, không có 4 cột ẩn gốc**; tiêu đề theo thứ tự đã duyệt.
- Hàng xuất khớp 100% bộ lọc/role trên jqGrid ở mọi trang (cùng thời điểm truy vấn), không rò dữ liệu ngoài phạm vi được cấp quyền.
- Không sai kiểu dữ liệu, không biến mã thành số, không bỏ bản ghi hoặc nhân đôi do join.
- Người dùng nhận file tải xuống với một thao tác xác nhận; handler trả lỗi rõ ràng; không chỉnh sửa DB.
- Kết quả được kiểm thử thủ công trên Anco1 và chủ dự án xác nhận trước khi phát hành Azure.
