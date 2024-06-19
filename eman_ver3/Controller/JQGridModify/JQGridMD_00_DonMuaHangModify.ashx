<%@ WebHandler Language="C#" Class="JQGridMD_00_DonMuaHangModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_DonMuaHangModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public Public pub = new Public();
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    public JQGridMD_00_DonMuaHangClass classFunc = new JQGridMD_00_DonMuaHangClass();
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest(HttpContext context)
    {
        if (Security.id_taikhoan(context) != "")
        {
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
            case "CA_01_TPNKMG2":
                this.CA_01_TPNKMG2(context);
                break;
            case "CA_01_TPNKMG":
                this.CA_01_TPNKMG(context);
                break;
            case "CA_01_KetThucDonMuHang":
                this.CA_01_KetThucDonMuHang(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_KetThucDonMuHang(HttpContext context)
    {
        string id = context.Request.Form["id"];
        string msg = "";
        try
        {
            var dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == id).FirstOrDefault();
            if (dmh == null)
            {
                msg = $@"Không tìm thấy đơn mua hàng";
                goto EndEventHandler;
            }

            if (dmh.md_trangthai_id != Helper.HIEULUC)
            {
                msg = $@"Đơn mua hàng không ở trạng thái ""Hiệu Lực""";
                goto EndEventHandler;
            }

            dmh.md_trangthai_id = Helper.KETTHUC;
            //dmh.ngaycapnhat = DateTime.Now;
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

    EndEventHandler:;

        if (msg.Length <= 0)
        {
            msg = $@"<div style='color:blue'>Xác nhận đơn mua hàng thành công</div>";
        }
        else
        {
            msg = $@"<div style='color:red' error>{msg}</div>";
        }
        context.Response.Write(msg);
    }


    public void CA_01_TPNKMG(HttpContext context)
    {
        string id = context.Request.Form["id"];
        string msg = "";
        try
        {
            var dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == id).FirstOrDefault();
            if (dmh == null)
            {
                msg = $@"Không tìm thấy đơn mua hàng";
                goto EndEventHandler;
            }

            if (dmh.md_trangthai_id != Helper.SOANTHAO)
            {
                msg = $@"Đơn mua hàng không ở trạng thái ""Soạn Thảo""";
                goto EndEventHandler;
            }

            dmh.md_trangthai_id = Helper.DANHAN;
            dmh.ngayxacnhan = DateTime.Now;
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

    EndEventHandler:;

        if (msg.Length <= 0)
        {
            msg = $@"<div style='color:blue'>Xác nhận đơn mua hàng thành công</div>";
        }
        else
        {
            msg = $@"<div style='color:red' error>{msg}</div>";
        }
        context.Response.Write(msg);
    }

    public void CA_01_TPNKMG2(HttpContext context)
    {
        string id = context.Request.Form["id"];
        string msg = "";
        try
        {
            var dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == id).FirstOrDefault();
            if (dmh == null)
            {
                msg = $@"Không tìm thấy đơn mua hàng";
                goto EndEventHandler;
            }

            if (dmh.md_trangthai_id != Helper.DANHAN)
            {
                msg = $@"Đơn mua hàng không ở trạng thái ""Đã Xác Nhận""";
                goto EndEventHandler;
            }

            dmh.md_trangthai_id = Helper.HIEULUC;
            dmh.ngayhieuluc = DateTime.Now;

            var khmvt = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == dmh.c_kehoachmuavt_id & s.c_donmuavattu_id.Contains(dmh.sochungtu)).FirstOrDefault();
            if (khmvt != null)
            {
                foreach (var cdh in db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).ToList())
                {
                    var cd = db.c_kehoachmuavt_cdh.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.c_kehoachmuavt_id == khmvt.c_kehoachmuavt_id).FirstOrDefault();
                    cd.sl_conlai = cd.sl_conlai.GetValueOrDefault(0) + cdh.sl_dadat2.GetValueOrDefault(0);
                }

                var khmvtDHsServer = db.c_kehoachmuavt_cdh.Where(s => s.c_kehoachmuavt_id == khmvt.c_kehoachmuavt_id & s.sl_conlai < s.sl_duyet).ToList();
                var khmvtDHs = db.c_kehoachmuavt_cdh.Local.Where(s => s.c_kehoachmuavt_id == khmvt.c_kehoachmuavt_id & s.sl_conlai < s.sl_duyet).ToList();

                if (khmvtDHs.Count <= 0)
                {
                    khmvt.md_trangthai_id = Helper.KETTHUC;
                }
            }
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

    EndEventHandler:;

        if (msg.Length <= 0)
        {
            msg = $@"<div style='color:blue'>Xác nhận đơn mua hàng thành công</div>";
        }
        else
        {
            msg = $@"<div style='color:red' error>{msg}</div>";
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id_parent = context.Request.Form["id_parent"];
                var object_ = new c_donmuahang();
                object_.c_donmuahang_id = id_new;
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                db.c_donmuahang.Add(object_);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Thêm mới thành công#{0}", id_new);
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

    //nht
    public void edit(HttpContext context)
    {
        string msg = "", msg_err = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_trangthai_id = context.Request.Form["md_trangthai_id"];
        string ma_dtkd = context.Request.Form["md_doitackinhdoanh_id"];
        string md_banggia_id = context.Request.Form["md_banggia_id"];
        string md_phienbangia_id = context.Request.Form["md_phienbangia_id"];
        string md_doitackinhdoanh_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == ma_dtkd).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
        string id_parent = context.Request.Form["id_parent"];
        string id = context.Request.Form["id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var object_ = db.c_donmuahang.Where(p => p.c_donmuahang_id == id).Take(1).FirstOrDefault();
                int count = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).Count();

                if (object_ == null)
                {
                    msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if (count <= 0 & md_trangthai_id == "HIEULUC")
                {
                    msg = "false#Lỗi:Đối tượng chưa có HHVT cần mua.";
                }
                else if (object_.tong_tienhang <= 0 & object_.tong_tatca <= 0 & md_trangthai_id == "HIEULUC")
                {
                    msg = "false#Lỗi:Đối tượng chưa có tổng tiền hàng.";
                }
                else if (md_doitackinhdoanh_id == null)
                {
                    msg = "false#Lỗi:Không tồn tại đối tác kinh doanh \"" + ma_dtkd + "\".";
                }

                var tts = new string[] { Helper.DANHAN, Helper.HIEULUC };
                if (tts.Contains(object_.md_trangthai_id))
                {
                    var ngaythanhtoan = VNN_Config.setDateTime(context.Request.Form["ngaythanhtoan"]);
                    if (ngaythanhtoan.IsDate() == true)
                        object_.ngaythanhtoan = ngaythanhtoan;
                    else
                        msg = "false#Lỗi: Ngày thanh toán không đúng định dạng.";

                    object_.diadiem_giaohang = context.Request.Form["diadiem_giaohang"];
                    object_.md_dieukienthanhtoan_id = context.Request.Form["md_dieukienthanhtoan_id"];
                    object_.hinhthucthanhtoan = context.Request.Form["hinhthucthanhtoan"];
                    if (msg.Length <= 0)
                        msg = @"true#Đã cập nhật thông tin";
                }
                else if (object_.md_trangthai_id == Helper.SOANTHAO)
                {
                    foreach (var dmh_st in db.c_donmuahang.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id & s.c_kehoachmuavt_id == object_.c_kehoachmuavt_id).ToList())
                    {
                        foreach (var cdh_st in db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh_st.c_donmuahang_id).ToList())
                        {
                            var cdh_obj = db.c_kehoachmuavt_cdh.Where(s => s.c_kehoachmuavt_id == dmh_st.c_kehoachmuavt_id & s.md_sanpham_id == cdh_st.md_sanpham_id).FirstOrDefault();
                            if (cdh_obj != null)
                            {
                                var sp_obj = db.md_sanpham.Where(s => s.md_sanpham_id == cdh_obj.md_sanpham_id).FirstOrDefault();
                                if (
                                    (cdh_obj.sl_conlai + cdh_st.sl_dadat2.GetValueOrDefault(0) - cdh_st.saiso.GetValueOrDefault(0))
                                    > cdh_obj.sl_duyet2.GetValueOrDefault(0)
                                )
                                {
                                    decimal check_sl = cdh_obj.sl_duyet2.Value - cdh_obj.sl_conlai.Value;
                                    msg_err += string.Format(@"Mã sản phẩm <b>{0}</b> vượt quá SL cho phép (SL còn lại:""{1}"") <br>",
                                        sp_obj.ma_sanpham, check_sl.DropTrailingZeros());
                                }
                            }
                        }
                    }

                    if (msg_err.Length > 0 & msg.Length <= 0)
                        msg = "false#Lỗi:" + msg_err;

                    if (msg.Length <= 0)
                    {
                        var bg = db.md_banggia.Where(s => s.md_banggia_id == md_banggia_id).Take(1).FirstOrDefault();

                        if (msg.Length <= 0)
                        {
                            object_.md_dongtien_id = bg.md_dongtien_id;
                            VNN_Function.SetFormValue(object_.nameof(s => s.md_trangthai_id), Helper.VNN_notpost);
                            VNN_Function.SetFormValue(object_.nameof(s => s.md_doitackinhdoanh_id), Helper.VNN_notpost);
                            VNN_Function.SetFormValue(object_.nameof(s => s.md_banggia_id), Helper.VNN_notpost);
                            VNN_Function.SetFormValue(object_.nameof(s => s.md_phienbangia_id), Helper.VNN_notpost);

                            VNN_Function.SetFormValue(object_.nameof(s => s.huongdan_lamhang), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.phieunhapkho), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.donhang_thamchieu), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.sctkehoach), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.md_dongtien_id), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.c_kehoachmuavt_id), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.tong_tienhang), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.chu_tong_tienhang), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.tong_tatca), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.chu_tong_tatca), "VNN_notpost");
                            object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                            object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                            db.SaveChanges();
                        }
                    }
                }

                object_.mota = context.Request.Form["mota"];
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.Message;
            }

            if (msg.LastIndexOf("false#") <= -1)
            {
                msg = "true#Cập nhật thành công";
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];


        try
        {
            var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

            foreach (var id_del_ in ids)
            {
                var object_ = db.c_donmuahang.Where(p => p.c_donmuahang_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                }
                else if (object_.md_trangthai_id == Helper.HIEULUC)
                {
                    msg += string.Format(@"<br><b>{0} ({1})</b>: Không thể xóa khi đẫ ""Hiệu Lực"".", object_.sochungtu, object_.so_donmuahang);
                }
                else if (!string.IsNullOrWhiteSpace(object_.phieunhapkho))
                {
                    msg += string.Format(@"<br><b>{0} ({1})</b>: Đã tạo phiếu nhập kho.", object_.sochungtu, object_.so_donmuahang);
                }
                else
                {
                    if (object_.md_trangthai_id == Helper.DANHAN)
                    {
                        object_.md_trangthai_id = Helper.SOANTHAO;
                        db.SaveChanges();
                    }
                    else
                    {
                        string sct = object_.sochungtu;
                        string c_kehoachdathang_dhncc_id = object_.c_kehoachdathang_dhncc_id;
                        string c_kehoachmuavt_id = object_.c_kehoachmuavt_id;
                        VNN_Function.Write_log(context, ma_module, null, oper, "MĐMH:" + object_.sochungtu + ", TĐMH:" + object_.so_donmuahang, db);
                        db.c_donmuahang.Remove(object_);

                        //Cap nhat ke hoach dat hang NCC
                        var cdmhs = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).ToList();
                        var cdmhIds = cdmhs.Select(s => s.md_sanpham_id).ToList();
                        var khmvtt = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == c_kehoachmuavt_id).Take(1).FirstOrDefault();
                        var kh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == c_kehoachdathang_dhncc_id).Take(1).FirstOrDefault();

                        if (khmvtt != null)
                        {
                            khmvtt.c_donmuavattu_id = khmvtt.c_donmuavattu_id.Replace("," + sct, "").Replace(sct + ",", "").Replace(sct, "");
                            if (khmvtt.c_donmuavattu_id == "") { khmvtt.c_donmuavattu_id = " "; }
                            db.SaveChanges();
                        }
                        else if (kh != null)
                        {
                            if (kh.trangthai != Helper.DATSX & kh.trangthai != Helper.DATHET)
                            {
                                msg = $@"Kế hoạch {kh.donhang_thamchieu} phải ở trạng thái ""Đặt SX"" hoặc ""Đã đặt hết""";
                                goto EndEventHandler;
                            }

                            var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == kh.c_danhsachdathang_id).FirstOrDefault();
                            if (dsdh == null)
                            {
                                msg = $@"Kế hoạch {kh.donhang_thamchieu} không liên kết với đơn hàng";
                                goto EndEventHandler;
                            }

                            var lsx = db.md_lenhsanxuat.Where(s => s.c_kehoachdathang_id == kh.c_kehoachdathang_id).OrderBy(s => s.ngayketthuc).FirstOrDefault();
                            if (lsx == null)
                            {
                                msg = $@"Kế hoạch {kh.donhang_thamchieu} không liên kết với LSX";
                                goto EndEventHandler;
                            }

                            var tsxs = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id & s.stt >= 9998).OrderByDescending(s => s.stt).ToList();
                            foreach (var tsx in tsxs)
                            {
                                var cdhs = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                    s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                    & s.sl_datncc > 0
                                    & cdmhIds.Contains(s.md_sanpham_id)).ToList();

                                if (lsx.md_trangthai_id != Helper.CHUAHOANTHANH & cdhs.Count > 0)
                                {
                                    msg += string.Format(@"<br>Đã triển khai sản xuất.");
                                    goto EndEventHandler;
                                }

                                foreach (var cdh in cdhs)
                                {
                                    var masp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).Select(s => s.ma_sanpham).FirstOrDefault();
                                    pub.truVatTuSauKhiDatNCC(db, tsx, cdh.md_sanpham_id, 0 - cdh.sl_datncc.GetValueOrDefault(0), masp, cdh.macuoi, cdh.mathaydoi);
                                    cdh.sl_datncc = null;
                                    cdh.sl_datncc2 = null;
                                }
                            }

                            var cdhsSX = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                                & !string.IsNullOrEmpty(s.lsxCT)).ToList();

                            if (cdhsSX.Count > 0)
                                kh.trangthai = Helper.DATSX;
                            else
                            {
                                var cdhsMNServer = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                    s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                                    & string.IsNullOrEmpty(s.xuongPhu)).ToList();

                                var cdhsMN = db.md_lenhsanxuat_tosx_cdh.Local.Where(s =>
                                    s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                                    & string.IsNullOrEmpty(s.xuongPhu)).ToList();

                                if (cdhsMN.Sum(s => s.sl_datncc.GetValueOrDefault(0)) > 0)
                                {
                                    kh.trangthai = Helper.DATSX;
                                }
                                else
                                {
                                    kh.trangthai = Helper.DaXLTBTP;
                                }
                            }

                            dsdh.md_trangthai_id = kh.trangthai;
                            db.SaveChanges();
                        }
                        else
                        {
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

    EndEventHandler:;

        if (msg.Length <= 0)
        {
            msg = string.Format(@"true#Xóa các đơn mua hàng đã chọn thành công");
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        else
        {
            if (msg.StartsWith("<br>"))
                msg = msg.Substring(4);
            msg = string.Format(@"false#{0}", msg);
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