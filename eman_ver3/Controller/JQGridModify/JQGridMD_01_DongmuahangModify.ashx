<%@ WebHandler Language="C#" Class="JQGridMD_01_DongmuahangModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DongmuahangModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string oper = "vnn";
        if (Security.id_taikhoan(context) != "")
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
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
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_donmuahang_cdmh";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            string thue = context.Request.Form["thue"];
            string co_ngayhethan = context.Request.Form["co_ngayhethan"];
            decimal sl_dadat = decimal.Parse(context.Request.Form["sl_dadat"]);
            decimal dongiamua = decimal.Parse(context.Request.Form["dongiamua"]);
            decimal giachuan = decimal.Parse(context.Request.Form["giachuan"]);
            decimal sl_duyet = decimal.Parse(context.Request.Form["sl_duyet"]);
            decimal thanhtien = 0, sl_thaythe = 0, sl_thaythe2 = 0, saiso = 0;
            var object_ = db.c_donmuahang_cdmh.Where(p => p.c_donmuahang_cdmh_id == id).Take(1).FirstOrDefault();
            c_donmuahang dmh = null;
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if(dongiamua > giachuan)
            {
                msg = "false#\"Đơn giá mua\" không thể lớn hơn \"Giá chuẩn\".";
            }
            else if(sl_dadat > sl_duyet)
            {
                msg = "false#\"Số lượng mua\" không thể lớn hơn \"Số lượng kế hoạch\".";
            }
            else
            {
                dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).Take(1).FirstOrDefault();
                if(dmh == null) {
                    msg = "false#Không tìm thấy đơn mua hàng.";
                }
                else if(dmh.md_trangthai_id != "SOANTHAO") {
                    msg = "false#Đơn mua hàng không phải trạng thái 'Soạn Thảo', không thể sửa.";
                }

                VNN_Function.SetFormValue("ngay_hethan", "VNN_notpost");
            }

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

                        if (sl_thaythe2 + sl_thaythe - saiso > cdh_obj.sl_duyet.Value)
                        {
                            decimal check_sl = cdh_obj.sl_duyet.Value - sl_thaythe2;
                            string ten_dvt = db.md_donvitinhsanpham.Where(s => s.md_donvitinhsanpham_id == sp_obj.md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
                            string msgDT = "";
                            msgDT += @"chỉ có thể nhập số lượng tối đa là: ""{0}""";
                            msgDT += @"<br> + Số lượng đang muốn nhập: ""{1}"" ({2})";
                            msgDT += @"<br> + Độ sai lệch cho phép: ""{3}""";
                            msgDT = string.Format(msgDT, cdh_obj.sl_duyet.Value.DropTrailingZeros(),
                                sl_thaythe.DropTrailingZeros(), ten_dvt, saiso.DropTrailingZeros());
                            msg += string.Format(@"false#Lỗi:Mặt hàng ""{0}"" {1}", sp_obj.ma_sanpham, msgDT);
                        }
                    }
                }

                if (dmh != null)
                {
                    string donvitinh = "VND";
                    md_dongtien dt = null;
                    dt = db.md_dongtien.Where(s => s.md_dongtien_id == dmh.md_dongtien_id).Take(1).FirstOrDefault();
                    if (dt != null) { donvitinh = dt.ma_iso; }
                    if (msg.Length <= 0)
                    {
                        thanhtien = dongiamua * sl_dadat;
                        if (donvitinh == "VND")
                            thanhtien = Math.Round(thanhtien, 0);
                        string action = "edit";
                        string[] column_ex = { "sl_dadat2", "saiso" };
                        string ten_table = "c_donmuahang_cdmh";
                        VNN_Function.SetFormValue("thanhtien", thanhtien.ToString());
                        VNN_Function.SetFormValue("sl_dadat2", sl_thaythe.ToString());
                        VNN_Function.SetFormValue("saiso", saiso.ToString());
                        VNN_Function.SetFormValue("md_sanpham_id", "VNN_notpost");
                        VNN_Function.SetFormValue("md_donvitinhsanpham_id", "VNN_notpost");
                        VNN_Function.Set_DefaultvalueColumn(context, action);
                        VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                        VNN_Function.loaddulieu_Auto(db, ma_module);
                        msg = "true#Cập nhật thành công.";
                        db = new EntityContext();
                        //Khai bao bien
                        c_donmuahang_thue dmh_thue = db.c_donmuahang_thue.Where(s => s.md_thue_sanpham_id == object_.thue & s.c_donmuahang_id == object_.c_donmuahang_id).Take(1).FirstOrDefault();
                        c_donmuahang_thue dmh_thue_new = db.c_donmuahang_thue.Where(s => s.md_thue_sanpham_id == thue & s.c_donmuahang_id == object_.c_donmuahang_id).Take(1).FirstOrDefault();
                        md_thue_sanpham thue_sp = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == object_.thue).FirstOrDefault();
                        md_thue_sanpham thue_sp_new = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == thue).FirstOrDefault();
                        decimal gt_thue = 0, gt_thue_new = 0;
                        if (thue_sp != null)
                            gt_thue = thue_sp.giatri.Value;
                        if (thue_sp_new != null)
                            gt_thue_new = thue_sp_new.giatri.Value;
                        decimal tong_tien_thue = (thanhtien * gt_thue / 100), tong_tien_chiu_thue = thanhtien + tong_tien_thue;
                        decimal tong_tien_thue_new = (thanhtien * gt_thue_new / 100), tong_tien_chiu_thue_new = thanhtien + tong_tien_thue_new;
                        //Xu ly thue
                        if (dmh_thue_new == null)
                        {
                            if (thue != "")
                            {
                                string id_news = Helper.getNewId();
                                dmh_thue_new = new c_donmuahang_thue();
                                //--
                                dmh_thue_new.tong_tien_thue = tong_tien_thue_new;
                                dmh_thue_new.tong_tien_chiu_thue = tong_tien_chiu_thue_new;
                                //--
                                dmh_thue_new.c_donmuahang_thue_id = id_news;
                                dmh_thue_new.c_donmuahang_id = object_.c_donmuahang_id;
                                dmh_thue_new.md_thue_sanpham_id = thue;
                                dmh_thue_new.doanhnghiep = "";
                                dmh_thue_new.tochuc = "";

                                dmh_thue_new.nguoitao = us.ad_user_id;
                                dmh_thue_new.vaitrotao = us.ad_role_id;
                                dmh_thue_new.bophantao = us.md_phongban_id;
                                dmh_thue_new.value_nguoitao = us.ma_user;
                                dmh_thue_new.value_vaitrotao = us.ten_role;
                                dmh_thue_new.value_bophantao = us.ten_phongban;

                                dmh_thue_new.nguoicapnhat = us.ad_user_id;
                                dmh_thue_new.vaitrocapnhat = us.ad_role_id;
                                dmh_thue_new.bophancapnhat = us.md_phongban_id;
                                dmh_thue_new.value_nguoicapnhat = us.ma_user;
                                dmh_thue_new.value_vaitrocapnhat = us.ten_role;
                                dmh_thue_new.value_bophancapnhat = us.ten_phongban;

                                dmh_thue_new.ngaytao = DateTime.Now;
                                dmh_thue_new.ngaycapnhat = DateTime.Now;
                                dmh_thue_new.mota = "";
                                dmh_thue_new.hoatdong = true;
                                db.c_donmuahang_thue.Add(dmh_thue_new);
                            }

                            if (dmh_thue != null)
                            {
                                dmh_thue.tong_tien_thue = dmh_thue.tong_tien_thue - tong_tien_thue;
                                dmh_thue.tong_tien_chiu_thue = dmh_thue.tong_tien_chiu_thue - tong_tien_chiu_thue;
                            }
                        }
                        else
                        {
                            //updte thue moi
                            if (dmh_thue_new == dmh_thue)
                            {
                                tong_tien_thue = (object_.thanhtien.Value * gt_thue / 100);
                                tong_tien_chiu_thue = object_.thanhtien.Value + tong_tien_thue;
                            }

                            dmh_thue_new.tong_tien_thue += tong_tien_thue_new;
                            dmh_thue_new.tong_tien_chiu_thue += tong_tien_chiu_thue_new;
                            //update thue cu
                            if (dmh_thue != null)
                            {
                                dmh_thue.tong_tien_thue = dmh_thue.tong_tien_thue - tong_tien_thue;
                                dmh_thue.tong_tien_chiu_thue = dmh_thue.tong_tien_chiu_thue - tong_tien_chiu_thue;
                            }
                        }
                        db.SaveChanges();
                        db.c_donmuahang_thue.RemoveRange(db.c_donmuahang_thue.Where(s => s.tong_tien_chiu_thue <= 0));
                        db.SaveChanges();

                        //Start cap nhat don mua hang
                        dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).Take(1).FirstOrDefault();
                        decimal tong_tienhang = decimal.Parse("0.00");
                        try { tong_tienhang = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.thanhtien.Value).Sum(); } catch { }
                        decimal tong_tienthue = decimal.Parse("0.00");
                        try { tong_tienthue = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.tong_tien_thue.Value).Sum(); } catch { }
                        decimal tong_tatca = tong_tienhang + tong_tienthue;

                        if (donvitinh == "VND")
                        {
                            tong_tienhang = Math.Round(tong_tienhang, 0);
                            tong_tatca = Math.Round(tong_tatca, 0);
                        }
                        var tth = VNN_ConvertMoney.convert((double)tong_tienhang, donvitinh).FirstOrDefault();
                        var ttc = VNN_ConvertMoney.convert((double)tong_tatca, donvitinh).FirstOrDefault();

                        dmh.tong_tienhang = (decimal)tth.Value;
                        dmh.tong_tatca = (decimal)ttc.Value;
                        dmh.chu_tong_tienhang = tth.Key;
                        dmh.chu_tong_tatca = ttc.Key;
                        db.SaveChanges();
                        //End cap nhat don mua hang
                    }
                }
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        db.Dispose();
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "",  msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "c_donmuahang_cdmh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                c_donmuahang_cdmh object_ = db.c_donmuahang_cdmh.Where(p => p.c_donmuahang_cdmh_id == id_del_).Take(1).FirstOrDefault();
                c_donmuahang c = db.c_donmuahang.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (c.md_trangthai_id == "HIEULUC")
                {
                    msg_del = "false#Đơn hàng đã hiệu lực !";
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    string action = "del";
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_.c_donmuahang_cdmh_id);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                }
            }
            VNN_Function.loaddulieu_Auto(db, ma_module);
            if (msg.Length <= 0)
            {
                msg = "true#Xóa thành công.";
            }
            else
            {
                msg = "false#" + msg;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.ToUpper().Contains("REFERENCE"))
            {
                msg = "false#Lỗi: Đang được sử dụng, không thể xóa";
            }
            else
            {
                msg = "false#Lỗi: " + ex.Message;
            }
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