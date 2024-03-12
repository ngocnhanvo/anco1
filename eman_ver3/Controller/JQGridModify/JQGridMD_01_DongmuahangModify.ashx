<%@ WebHandler Language="C#" Class="JQGridMD_01_DongmuahangModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DongmuahangModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
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
            default:
                break;
        }
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

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                string thue = context.Request.Form["thue"];
                string co_ngayhethan = context.Request.Form["co_ngayhethan"];
                decimal sl_dadat = decimal.Parse(context.Request.Form["sl_dadat"]);
                decimal dongiamua = decimal.Parse(context.Request.Form["dongiamua"]);
                decimal giachuan = dongiamua;
                decimal sl_duyet = decimal.Parse(context.Request.Form["sl_duyet"]);
                decimal thanhtien = 0, sl_thaythe = 0, sl_thaythe2 = 0, saiso = 0;
                var object_ = db.c_donmuahang_cdmh.Where(p => p.c_donmuahang_cdmh_id == id).Take(1).FirstOrDefault();
                c_donmuahang dmh = null;
                if (object_ == null)
                {
                    msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
                    goto EndEventHandler;
                }

                if (dongiamua > giachuan)
                {
                    msg = "false#\"Đơn giá mua\" không thể lớn hơn \"Giá chuẩn\".";
                    goto EndEventHandler;
                }

                if (sl_dadat > sl_duyet)
                {
                    msg = "false#\"Số lượng mua\" không thể lớn hơn \"Số lượng kế hoạch\".";
                    goto EndEventHandler;
                }

                dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).Take(1).FirstOrDefault();
                if (dmh == null)
                {
                    msg = "false#Không tìm thấy đơn mua hàng.";
                    goto EndEventHandler;
                }

                if (dmh.md_trangthai_id != Helper.SOANTHAO)
                {
                    msg = "false#Đơn mua hàng không phải trạng thái 'Soạn Thảo', không thể sửa.";
                    goto EndEventHandler;
                }

                var kh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dmh.c_kehoachdathang_dhncc_id).FirstOrDefault();
                if(kh != null)
                {
                    if(object_.sl_dadat.GetValueOrDefault(0) != sl_dadat)
                    {
                        msg = $"false#Không thể sửa <b>số lượng đặt</b> khi có liên kết với đơn hàng <b>{kh.donhang_thamchieu}</b>.";
                        goto EndEventHandler;
                    }
                }

                VNN_Function.SetFormValue(object_.nameof(s=>s.ngay_hethan), Helper.VNN_notpost);

                if (msg.Length <= 0)
                {
                    var cdh_obj = db.c_kehoachmuavt_cdh.FirstOrDefault(s => s.c_kehoachmuavt_id == dmh.c_kehoachmuavt_id & s.md_sanpham_id == object_.md_sanpham_id);
                    if (cdh_obj != null)
                    {
                        var sp_obj = db.md_sanpham.Where(s => s.md_sanpham_id == cdh_obj.md_sanpham_id).FirstOrDefault();
                        if (sp_obj != null)
                        {
                            var dvt = db.md_donvitinhsanpham_cddv.
                                Where(s => s.md_sanpham_id == sp_obj.ma_sanpham & s.md_donvitinhsanpham_id == object_.md_donvitinhsanpham_id).FirstOrDefault();
                            if (dvt != null)
                            {
                                sl_thaythe = dvt.nhanvoi.GetValueOrDefault(0) * sl_dadat;
                                sl_thaythe2 = dvt.nhanvoi.GetValueOrDefault(0) * cdh_obj.sl_conlai.GetValueOrDefault(0);
                                saiso = dvt.chiacho.GetValueOrDefault(0) * sl_dadat;
                                if (saiso > dvt.saiso_toida.GetValueOrDefault(9999999))
                                    saiso = dvt.saiso_toida.GetValueOrDefault(9999999);
                            }
                            else if (object_.md_donvitinhsanpham_id == sp_obj.md_donvitinhsanpham_id)
                            {
                                sl_thaythe = sl_dadat;
                                sl_thaythe2 = cdh_obj.sl_conlai.GetValueOrDefault(0);
                                saiso = 0;
                            }
                            else
                            {
                                string tendvt = db.md_donvitinhsanpham.Where(s => s.md_donvitinhsanpham_id == object_.md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
                                msg += string.Format(@"
                            <div style='color:red'>
                                Lỗi: Mã sản phẩm ""{0}"" không có đơn vị tính ""{1}""
                            </div>",
                                    sp_obj.ma_sanpham,
                                    tendvt);
                            }

                            var sltd = cdh_obj.sl_duyet2.Value - sl_thaythe2;
                            if (sl_thaythe - saiso > sltd)
                            {
                                decimal check_sl = cdh_obj.sl_duyet2.Value - sl_thaythe2;
                                string ten_dvt = db.md_donvitinhsanpham.Where(s => s.md_donvitinhsanpham_id == sp_obj.md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
                                string msgDT = "";
                                msgDT += @"Số lượng tối đa có thể mua là: <b>{0}</b> ({2})";
                                msgDT += @"<br> + Số lượng đang muốn mua: <b>{1}</b> ({2})";
                                msgDT += @"<br> + Độ sai lệch cho phép: <b>{3}</b>";
                                msgDT = string.Format(msgDT, sltd.DropTrailingZeros(),
                                    sl_thaythe.DropTrailingZeros(), ten_dvt, saiso.DropTrailingZeros());
                                msg += string.Format(@"false#Lỗi: {1}", sp_obj.ma_sanpham, msgDT);
                            }
                        }
                    }

                    if (dmh != null)
                    {
                        string donvitinh = "VND";
                        var dt = db.md_dongtien.Where(s => s.md_dongtien_id == dmh.md_dongtien_id).Take(1).FirstOrDefault();
                        if (dt != null) { donvitinh = dt.ma_iso; }
                        if (msg.Length <= 0)
                        {
                            thanhtien = dongiamua * sl_dadat;
                            if (donvitinh == "VND")
                                thanhtien = Math.Round(thanhtien, 0);

                            VNN_Function.SetFormValue(object_.nameof(s=>s.thanhtien), thanhtien.ToString());
                            VNN_Function.SetFormValue(object_.nameof(s=>s.sl_dadat2), sl_thaythe.ToString());
                            VNN_Function.SetFormValue(object_.nameof(s=>s.saiso), saiso.ToString());
                            VNN_Function.SetFormValue(object_.nameof(s=>s.md_sanpham_id), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s=>s.md_donvitinhsanpham_id), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s=>s.c_donmuahang_id), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s=>s.dongiamua), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s=>s.giachuan), "VNN_notpost");
                            object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                            object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                            db.SaveChanges();

                            classFunc.TinhThueDonHang(dmh, userTK, dmh.md_phienbangia_id, dmh.md_phienbangia_id, db);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.ToString();
            }

        EndEventHandler:;

            if (msg.LastIndexOf("false#") <= -1)
            {
                msg = "true#Cập nhật thành công.";
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