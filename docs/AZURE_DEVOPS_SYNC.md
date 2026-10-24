# Anco1: tự động đồng bộ GitHub → Azure DevOps (mã nguồn, không mirror)

## Nguồn và đích

- Development/source of truth: [GitHub ngocnhanvo/anco1](https://github.com/ngocnhanvo/anco1), nhánh `master`.
- Azure DevOps destination: `https://dev.azure.com/vongocnhancd10cntt2/Anco1/_git/Anco1`; nhánh mặc định được đọc động qua Azure API.
- Mốc lịch sử loại trừ cố định: `1e614269073c8f60bdfcdbfc1570ecd7588a2d20`. Mốc này và mọi commit trước đó **không bao giờ được đồng bộ lại**.

## Cơ chế tự động — yêu cầu ngày 24/10/2026

1. Mỗi khi có `push` lên GitHub `master` chứa file trong các khu vực `eman_ver3/`, `DataAccess/`, `GenerateModels/`, `Report/`, `Anco1.sln`, `packages/`, workflow tự chạy.
2. Script chỉ tính **chênh lệch nguồn được phép** từ cursor `ANCO1_SYNC_TO` của PR Azure đã hoàn tất gần nhất (hoặc baseline ở lần đầu). Không đẩy lịch sử GitHub.
3. Nếu có thay đổi, script tạo nhánh mới từ **HEAD nhánh mặc định Azure**, thử `git apply --3way --index`. Xung đột thì dừng, không ghi đè Azure.
4. Tạo Azure Pull Request và **yêu cầu auto-complete** khi các chính sách bắt buộc Azure đã thỏa. Không bypass branch policies, không push/force-push vào `master` Azure.
5. Nếu PR đồng bộ trước còn mở, lần chạy tự động không tạo PR trùng. Workflow định kỳ mỗi giờ (`23 * * * *` UTC) giúp gom các commit tiếp theo sau khi PR trước hoàn tất.
6. Không có source change mới: workflow báo không có gì để chuyển.

`workflow_dispatch` **vẫn giữ** hai chế độ thủ công `preview` và `create-pr` cho việc kiểm tra/chẩn đoán; ở chế độ thủ công, PR không được tự bật auto-complete.

### Điều kiện để hoàn toàn tự động

- GitHub Actions secret `AZURE_DEVOPS_PAT` phải còn hiệu lực và có quyền Code Read & write, tạo nhánh/PR/cập nhật PR/hoàn tất PR theo cấu hình Azure.
- Azure có thể yêu cầu review/build/policy. **Auto-complete chờ các điều kiện bắt buộc; không tự lách chúng.** Khi cần duyệt người thì PR vẫn chờ.
- Nếu Azure từ chối auto-complete do quyền hoặc cấu hình, xem log và khắc phục quyền/chính sách trên Azure. Không tự hạ mức bảo vệ.
- Kết quả run ở [GitHub Actions](https://github.com/ngocnhanvo/anco1/actions/workflows/azure-devops-sync.yml), các PR ở `https://dev.azure.com/vongocnhancd10cntt2/Anco1/_git/Anco1/pullrequests`.

## Điều kiện an toàn

- Chỉ chuyển file mã nguồn theo allowlist trong `scripts/azure_devops_sync.py`; không mang tài liệu knowledge, CI config, secret hay các thay đổi workflow vào Azure payload.
- Không `git push --force`, không ghi trực tiếp nhánh mặc định Azure, không sửa lại lịch sử cũ.
- Một PR đang mở không được coi là đã triển khai; cursor chỉ tiến sau PR có `status=completed`.
- Lượt chạy GitHub bị xếp hàng/đã cũ được bỏ qua an toàn nếu cursor Azure đã tiến xa hơn.
- `AZURE_DEVOPS_PAT` chỉ được đọc từ GitHub Actions Secrets, không commit hoặc tiết lộ giá trị.

## Một lần xử lý khác biệt nền lịch sử cho Excel SOANTHAO

- Hai file Excel (`JQGridMD_00_DSHangHoa_SOANTHAOModify.ashx` và `MD_00_DSHangHoa_SOANTHAO.js`) có khác biệt nền với Azure do tính năng DHD cũ nằm ngoài mốc baseline.
- Nếu bản vá Git 3-way xung đột **ở đúng hai file này trong lần đầu tiên**, hệ thống sẽ thử phương án `scripts/azure_devops_excel_bootstrap.py` để đưa **riêng chức năng xuất Excel mới** vào Azure.
- Trước khi thay, script xác minh block JS cũ trên Azure trùng với block tại baseline GitHub, kiểm tra duy nhất các điểm chèn case/handler, và xác nhận helper Excel hoạt động độc lập với DHD. Chỉ hai file được stage; các nội dung khác của Azure được giữ nguyên.
- Không áp dụng phương án đặc biệt cho file khác, commit khác hoặc sau khi cursor baseline đã tiến. Nếu kiểm chứng thất bại, workflow dừng và báo lỗi, không ép ghi đè.
- Các bản vá sau lần đầu vẫn dùng `git apply --index --3way` với dữ liệu blob gốc được nạp vào bản sao Azure tạm thời, nhằm giữ nguyên những thay đổi riêng của Azure.

## Vị trí triển khai

- `.github/workflows/azure-devops-sync.yml` — trigger push, catch-up lịch định kỳ, chạy thủ công, concurrency.
- `scripts/azure_devops_sync.py` — diff post-baseline, apply 3-way, tạo PR, yêu cầu auto-complete, cursor.
- `scripts/azure_devops_excel_bootstrap.py` — phương án ghép một lần, có kiểm tra điểm neo, cho hai file Excel riêng.
