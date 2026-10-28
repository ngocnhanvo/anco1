<%@ WebHandler Language="C#" Class="JQGridMD_00_PVCNoiBoModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
using Newtonsoft.Json;

public class JQGridMD_00_PVCNoiBoModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    EntityContext db;
    EntityFunction entityFunc;
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest(HttpContext context)
    {
        if (Security.id_taikhoan(context) != "")
        {
            db = new EntityContext();
            entityFunc = new EntityFunction();
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
            userTK = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context), db);
        }

        switch (oper)
        {
            case "add":
                this.add(context);
                break;
            case "edit":
                this.edit(context);
                break;
            case "del":
                this.del(context);
                break;
            case "CA_01_XuLyVanChuyen":
                this.CA_01_XuLyVanChuyen(context);
                break;
            case "CA_01_XacNhanVCNB":
                this.CA_01_XacNhanVCNB(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_XacNhanVCNB(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void CA_01_XuLyVanChuyen(HttpContext context)
    {
        var pub = new Public();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        var rows = context.Request.Form["rows"];
        var chkHL0 = context.Request.Form["chkHL0"] == "1";
        var msgErrs = new List<Public.BaoLoiKhiHieuLuc>();

        var vcnb = db.md_vanchuyennoibo.Where(s => s.md_vanchuyennoibo_id == id).FirstOrDefault();
        if (vcnb == null)
        {
            msg = $@"Không tìm thấy phiếu vận chuyển";
            goto EndEventHandler;
        }
        if (vcnb.md_trangthai_id != Helper.DANHAN)
        {
            msg = $@"Dòng ""{vcnb.sochungtu}"" cần ở trạng thái ""Đã Xác Nhận""";
            goto EndEventHandler;
        }

        string ngaychuyenStr = context.Request.Form["ngaychuyen"];
        var ngaychuyen = VNN_Config.setDateTime(ngaychuyenStr);
        if (!ngaychuyen.IsDate())
        {
            msg = $@"Lỗi: Giá trị ngày chuyển kho bị sai.";
            goto EndEventHandler;
        }
        vcnb.ngaychuyen = ngaychuyen;

        var vcnb_cdvcs = db.md_vanchuyennoibo_cdvc.Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id).ToList();
        var dongHangs = JsonConvert.DeserializeObject<List<md_vanchuyennoibo_cdvc>>(rows);
        foreach (var dh in vcnb_cdvcs)
        {
            var dongHang = dongHangs.Where(s => s.md_vanchuyennoibo_cdvc_id == dh.md_vanchuyennoibo_cdvc_id).FirstOrDefault();
            if (dongHang != null)
            {
                dh.soluong_dichchuyen = dongHang.soluong_dichchuyen;
            }
        }

        msg = pub.HieuLucPhieuVanChuyen(db, userTK, ma_module, id, context.Request.Form["koCapnhatDLSX"], vcnb, vcnb_cdvcs, chkHL0);
        msgErrs = pub.msgErrsPL.Clone();

        EndEventHandler:;

        if (msg.Length <= 0 & msgErrs.Count <= 0)
        {
            msg = $@"<div style='color:blue'>Hiệu lực phiếu chuyển kho thành công</div>";
        }
        else
        {
            if (msgErrs.Count > 0)
                msg = "Thiếu thông tin";

            var result = new
            {
                msg = $@"<div error style='color:red'>{msg}</div>",
                json = msgErrs
            };

            msg = JsonConvert.SerializeObject(result);
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string tukho = context.Request.Form["tukho"];
        string denkho = context.Request.Form["denkho"];
        string id = context.Request.Form["id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
                var object_ = db.md_vanchuyennoibo.Where(p => p.md_vanchuyennoibo_id == id).Take(1).FirstOrDefault();
                denkho = db.md_kho.Where(s => s.md_kho_id == denkho).Select(s => s.md_kho_id).FirstOrDefault();
                tukho = db.md_kho.Where(s => s.md_kho_id == tukho).Select(s => s.md_kho_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg = string.Format(@"Lỗi:Không tìm thấy đối tượng cần sửa.");
                }
                else if (object_.md_trangthai_id == "HIEULUC")
                {
                    msg = string.Format(@"Lỗi:Dòng {0} đã Hiệu lực", object_.sochungtu);
                }
                else if (tukho == denkho)
                {
                    msg = string.Format(@"Lỗi: Kho chuyển không được giống với kho đến");
                }
                else if (string.IsNullOrEmpty(tukho) | string.IsNullOrEmpty(denkho))
                {
                    msg = string.Format(@"Lỗi:Bạn phải chọn Kho chuyển và kho đến");
                }
                else if (ngaychuyen.IsDate() == false)
                {
                    msg = string.Format(@"Lỗi:Ngày chuyển không đúng định dạng");
                }

                if (msg.Length <= 0)
                {
                    if (object_.loaichuyen == "VANCNBCTKGH")
                        object_.denkho = denkho;
                    object_.ngaychuyen = ngaychuyen;
                    object_.ngaycapnhat = DateTime.Now;
                    object_.mota = context.Request.Form["mota"];
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Cập nhật thành công");
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format(@"false#{0}", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    // Phiếu lấy tồn phải được hoàn tác trước khi phát hành LSX chi tiết hoặc đơn mua hàng.
    // Chỉ kiểm tra các chứng từ liên kết với kế hoạch của phiếu, không dùng LSX chính
    // (md_lenhsanxuat) vì LSX chính đã được tạo từ bước lập kế hoạch.
    private static bool CoPhieuTrongDanhSach(string danhSach, string soPhieu)
    {
        return !string.IsNullOrWhiteSpace(danhSach)
            && danhSach.Split(',').Any(s => string.Equals(s.Trim(), soPhieu, StringComparison.OrdinalIgnoreCase));
    }

    public void del(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        var ids = (context.Request.Form["id"] ?? "").Split(',')
            .Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                if (ids.Count <= 0)
                    msg = "<br>Chưa chọn phiếu cần trả/xóa.";

                var phieus = db.md_vanchuyennoibo
                    .Where(s => ids.Contains(s.md_vanchuyennoibo_id)).ToList();

                // Kiểm tra tất cả phiếu trước khi thay đổi bất kỳ dữ liệu nào.
                // Nếu 1 phiếu bị chặn thì cả thao tác xóa nhiều phiếu phải thất bại.
                foreach (var id in ids)
                {
                    var phieu = phieus.FirstOrDefault(s => s.md_vanchuyennoibo_id == id);
                    if (phieu == null)
                    {
                        msg += string.Format("<br><b>{0}</b>: Không tìm thấy phiếu cần trả/xóa.",
                            HttpUtility.HtmlEncode(id));
                        continue;
                    }
                    if (phieu.md_trangthai_id == Helper.HIEULUC)
                    {
                        msg += string.Format("<br><b>{0}</b>: Phiếu đã Hiệu Lực, không thể trả/xóa.",
                            HttpUtility.HtmlEncode(phieu.sochungtu));
                        continue;
                    }

                    // Các phiếu PVC lấy TP/BTP được gắn trực tiếp với kế hoạch, hoặc
                    // nằm trong danh sách phiếu lấy của một tổ thuộc LSX chính.
                    var toLayTP = db.md_lenhsanxuat_tosx
                        .Where(s => s.phieulayhttp.Contains(phieu.sochungtu)).ToList()
                        .Where(s => CoPhieuTrongDanhSach(s.phieulayhttp, phieu.sochungtu)).ToList();
                    var toLayTho = db.md_lenhsanxuat_tosx
                        .Where(s => s.phieulayht.Contains(phieu.sochungtu)).ToList()
                        .Where(s => CoPhieuTrongDanhSach(s.phieulayht, phieu.sochungtu)).ToList();

                    var lsxChinhIds = toLayTP.Concat(toLayTho)
                        .Select(s => s.md_lenhsanxuat_id).Distinct().ToList();
                    var khIds = db.md_lenhsanxuat
                        .Where(s => lsxChinhIds.Contains(s.md_lenhsanxuat_id))
                        .Select(s => s.c_kehoachdathang_id).ToList()
                        .Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();

                    if (phieu.loaichuyen == "VANCNBTC"
                        && !string.IsNullOrWhiteSpace(phieu.c_doichieuhangton_id)
                        && db.c_kehoachdathang.Any(s => s.c_kehoachdathang_id == phieu.c_doichieuhangton_id)
                        && !khIds.Contains(phieu.c_doichieuhangton_id))
                    {
                        khIds.Add(phieu.c_doichieuhangton_id);
                    }

                    if (khIds.Count <= 0)
                        continue;

                    var lsxChiTiet = new List<md_lenhsanxuat2>();
                    foreach (var khId in khIds)
                    {
                        // c_kehoachdathang_id trên LSX2 có thể chứa nhiều ID phân cách bằng dấu phẩy.
                        var ungVien = db.md_lenhsanxuat2
                            .Where(s => s.c_kehoachdathang_id.Contains(khId)).ToList();
                        foreach (var lsx in ungVien)
                        {
                            if (lsx.c_kehoachdathang_id.Split(',')
                                .Any(s => s.Trim() == khId)
                                && !lsxChiTiet.Any(s => s.md_lenhsanxuat2_id == lsx.md_lenhsanxuat2_id))
                            {
                                lsxChiTiet.Add(lsx);
                            }
                        }
                    }

                    var donMuaHang = db.c_donmuahang
                        .Where(s => khIds.Contains(s.c_kehoachdathang_dhncc_id))
                        .OrderBy(s => s.sochungtu).ToList();

                    if (lsxChiTiet.Count > 0 || donMuaHang.Count > 0)
                    {
                        var dsLSX = string.Join(", ", lsxChiTiet
                            .Select(s => s.sochungtu).Where(s => !string.IsNullOrWhiteSpace(s))
                            .Distinct().OrderBy(s => s).Select(HttpUtility.HtmlEncode));
                        var dsDMH = string.Join(", ", donMuaHang
                            .Select(s => s.sochungtu).Where(s => !string.IsNullOrWhiteSpace(s))
                            .Distinct().OrderBy(s => s).Select(HttpUtility.HtmlEncode));

                        msg += string.Format(
                            "<br><b>{0} ({1})</b>: Không thể trả/xóa phiếu lấy tồn vì kế hoạch đã phát sinh chứng từ đặt sản xuất hoặc mua hàng." +
                            "{2}{3}<br>Việc xóa phiếu lấy tồn có thể làm sai số lượng sản xuất/mua hàng đã tính sau khi trừ tồn." +
                            " Hãy hủy/hoàn tác và xóa hợp lệ các chứng từ liên quan trước, sau đó mới thực hiện lại.",
                            HttpUtility.HtmlEncode(phieu.sochungtu),
                            HttpUtility.HtmlEncode(phieu.donhang_thamchieu),
                            lsxChiTiet.Count > 0 ? "<br>Lệnh sản xuất: <b>" + dsLSX + "</b>" : "",
                            donMuaHang.Count > 0 ? "<br>Đơn mua hàng: <b>" + dsDMH + "</b>" : "");
                    }
                }

                if (msg.Length <= 0)
                {
                    foreach (var phieu in phieus)
                    {
                        var tsxs = db.md_lenhsanxuat_tosx
                            .Where(s => s.phieulayhttp.Contains(phieu.sochungtu)).ToList()
                            .Where(s => CoPhieuTrongDanhSach(s.phieulayhttp, phieu.sochungtu)).ToList();
                        var tsxThos = db.md_lenhsanxuat_tosx
                            .Where(s => s.phieulayht.Contains(phieu.sochungtu)).ToList()
                            .Where(s => CoPhieuTrongDanhSach(s.phieulayht, phieu.sochungtu)).ToList();

                        if (tsxs.Count <= 0 && tsxThos.Count <= 0)
                        {
                            phieu.md_trangthai_id = Helper.SOANTHAO;
                        }
                        else
                        {
                            foreach (var tsx in tsxs)
                            {
                                var arr = tsx.phieulayhttp.Split(',')
                                    .Where(s => !string.Equals(s.Trim(), phieu.sochungtu, StringComparison.OrdinalIgnoreCase)
                                        && !string.IsNullOrWhiteSpace(s)).OrderBy(s => s).ToList();
                                tsx.phieulayhttp = string.Join(",", arr);
                                if (string.IsNullOrWhiteSpace(tsx.phieulayhttp))
                                {
                                    var khdhid = db.md_lenhsanxuat
                                        .Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id)
                                        .Select(s => s.c_kehoachdathang_id).FirstOrDefault();
                                    var khdh = db.c_kehoachdathang
                                        .Where(s => s.c_kehoachdathang_id == khdhid).FirstOrDefault();
                                    if (khdh != null)
                                        khdh.trangthai = Helper.SOANTHAO;
                                }
                            }

                            foreach (var tsx in tsxThos)
                            {
                                var arr = tsx.phieulayht.Split(',')
                                    .Where(s => !string.Equals(s.Trim(), phieu.sochungtu, StringComparison.OrdinalIgnoreCase)
                                        && !string.IsNullOrWhiteSpace(s)).OrderBy(s => s).ToList();
                                tsx.phieulayht = string.Join(",", arr);
                                if (string.IsNullOrWhiteSpace(tsx.phieulayht))
                                {
                                    var khdhid = db.md_lenhsanxuat
                                        .Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id)
                                        .Select(s => s.c_kehoachdathang_id).FirstOrDefault();
                                    var khdh = db.c_kehoachdathang
                                        .Where(s => s.c_kehoachdathang_id == khdhid).FirstOrDefault();
                                    if (khdh != null)
                                        khdh.trangthai = Helper.DaXLTTP;
                                }
                            }
                            db.md_vanchuyennoibo.Remove(phieu);
                        }
                        VNN_Function.Write_log(context, ma_module, null, oper,
                            "PVCNB:" + phieu.sochungtu + " DHTC:" + phieu.donhang_thamchieu, db);
                    }

                    db.SaveChanges();
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                msg += "<br>" + HttpUtility.HtmlEncode(ex.Message);
                transaction.Rollback();
            }
        }

        if (msg.Length <= 0)
        {
            msg = "true#Trả phiếu đã chọn về \"Soạn Thảo\" thành công";
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        else
        {
            msg = "false#" + msg;
        }
        context.Response.Write(msg);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}