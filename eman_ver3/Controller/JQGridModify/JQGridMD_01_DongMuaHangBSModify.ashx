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
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        string co_ngayhethan = context.Request.Form["co_ngayhethan"];
        string donvitinhId = context.Request.Form["md_donvitinhsanpham_id"];
        try
        {
            var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
            string id_parent = context.Request.Form["id_parent"];
            string thue = context.Request.Form["thue"];
            decimal dongiamua = decimal.Parse(context.Request.Form["dongiamua"]);
            decimal thanhtien = 0, sl_thaythe = 0, sl_thaythe2 = 0, saiso = 0;
            decimal sl_dadat = decimal.Parse(context.Request.Form["sl_dadat"]);
            decimal giachuan = 0;
            thanhtien = dongiamua * sl_dadat;
            DateTime? ngayhethan = null;
            var dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == id_parent & s.bosung == true).FirstOrDefault();

            if (dmh == null)
            {
                msg = "false#Lỗi: Chưa có đơn mua hàng";
            }
            else if (sl_dadat <= 0)
            {
                msg = "false#Lỗi: Số lượng đặt phải lớn hơn 0";
            }
            else
            {
                var pbg = db.md_phienbangia.Where(s => s.md_banggia_id == dmh.md_banggia_id & s.md_trangthai_id == "HIEULUC").FirstOrDefault();
                if (pbg != null)
                {
                    var gsp = db.md_giasanpham.
                            Where(s =>
                                s.md_sanpham_id == sp.md_sanpham_id &
                                s.md_phienbangia_id == pbg.md_phienbangia_id &
                                s.md_donvitinhsanpham_id == donvitinhId).FirstOrDefault();
                    if (gsp != null)
                    {
                        if (dongiamua <= 0)
                            dongiamua = (decimal)gsp.gia.Value;

                        giachuan = (decimal)gsp.gia.Value;
                        thanhtien = dongiamua * sl_dadat;
                    }
                }
                if (dongiamua <= 0)
                    msg = "false#Bảng giá của đơn mua hàng \"" + dmh.sochungtu + "\" không có giá cho sản phẩm \"" + sp.ma_sanpham + "\".";
                else if (dongiamua > giachuan)
                    msg = @"false#Giá mua không thể lớn hơn giá chuẩn.";
                var check = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id & s.md_sanpham_id == sp.md_sanpham_id).FirstOrDefault();
                if (check != null)
                    msg = "false#Lỗi: Mã sản phẩm đã tồn tại";

                var sp_obj = db.md_sanpham.Where(s => s.md_sanpham_id == sp.md_sanpham_id).FirstOrDefault();
                if (sp_obj != null)
                {
                    var dvt = db.md_donvitinhsanpham_cddv.
                        Where(s => s.md_sanpham_id == sp_obj.ma_sanpham & s.md_donvitinhsanpham_id == donvitinhId).FirstOrDefault();
                    if (dvt != null)
                    {
                        sl_thaythe = dvt.nhanvoi.GetValueOrDefault(0) * sl_dadat;
                        sl_thaythe2 = dvt.nhanvoi.GetValueOrDefault(0) * 0;
                        saiso = dvt.chiacho.GetValueOrDefault(0) * sl_dadat;
                        if (saiso > dvt.saiso_toida.GetValueOrDefault(9999999))
                            saiso = dvt.saiso_toida.GetValueOrDefault(9999999);
                    }
                    else if (donvitinhId == sp_obj.md_donvitinhsanpham_id)
                    {
                        sl_thaythe = sl_dadat;
                        sl_thaythe2 = 0;
                        saiso = 0;
                    }
                    else
                    {
                        string tendvt = db.md_donvitinhsanpham.Where(s => s.md_donvitinhsanpham_id == donvitinhId).Select(s => s.ten_dvt).FirstOrDefault();
                        msg = string.Format(@"false#Lỗi: Mã sản phẩm ""{0}"" không có đơn vị tính ""{1}""",
                            sp_obj.ma_sanpham,
                            tendvt);
                    }
                }
            }

            if (msg.Length <= 0)
            {

                //them Don dat hang
                var cdmh = new c_donmuahang_cdmh();
                cdmh.c_donmuahang_id = id_parent;
                cdmh.c_donmuahang_cdmh_id = Helper.getNewId();
                cdmh.md_sanpham_id = sp.md_sanpham_id;
                cdmh.md_donvitinhsanpham_id = donvitinhId;
                cdmh.sl_dadat = sl_dadat;
                cdmh.sl_dadat2 = sl_thaythe;
                cdmh.saiso = saiso;
                cdmh.sl_hanngach = 0;
                cdmh.dongiamua = dongiamua;
                cdmh.giachuan = giachuan;
                cdmh.thue = thue;
                cdmh.thanhtien = thanhtien;
                cdmh.ngay_hethan = ngayhethan;
                cdmh.nguoitao = us.ad_user_id;
                cdmh.vaitrotao = us.ad_role_id;
                cdmh.bophantao = us.md_phongban_id;
                cdmh.value_nguoitao = us.ma_user;
                cdmh.value_vaitrotao = us.ten_role;
                cdmh.value_bophantao = us.ten_phongban;

                cdmh.nguoicapnhat = us.ad_user_id;
                cdmh.vaitrocapnhat = us.ad_role_id;
                cdmh.bophancapnhat = us.md_phongban_id;
                cdmh.value_nguoicapnhat = us.ma_user;
                cdmh.value_vaitrocapnhat = us.ten_role;
                cdmh.value_bophancapnhat = us.ten_phongban;
                cdmh.ngaytao = DateTime.Now;
                cdmh.ngaycapnhat = DateTime.Now;
                cdmh.mota = "";
                cdmh.hoatdong = true;
                db.c_donmuahang_cdmh.Add(cdmh);

                //--
                var thue_sp = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == cdmh.thue).FirstOrDefault();
                decimal gt_thue = 0;
                if (thue_sp != null)
                    gt_thue = thue_sp.giatri.Value;
                decimal tong_tien_thue = (thanhtien * gt_thue / 100), tong_tien_chiu_thue = thanhtien + tong_tien_thue;

                c_donmuahang_thue check_thue = db.c_donmuahang_thue.Where(s => s.md_thue_sanpham_id == cdmh.thue & s.c_donmuahang_id == cdmh.c_donmuahang_id).FirstOrDefault();

                c_donmuahang_thue dmh_thue_new = check_thue;
                //--
                if (dmh_thue_new == null)
                {
                    dmh_thue_new = new c_donmuahang_thue();
                    dmh_thue_new.c_donmuahang_thue_id = Helper.getNewId();
                    dmh_thue_new.tong_tien_thue = tong_tien_thue;
                    dmh_thue_new.tong_tien_chiu_thue = tong_tien_chiu_thue;
                }
                else
                {
                    dmh_thue_new.tong_tien_thue += tong_tien_thue;
                    dmh_thue_new.tong_tien_chiu_thue += tong_tien_chiu_thue;
                }
                //--
                dmh_thue_new.md_thue_sanpham_id = cdmh.thue;
                dmh_thue_new.c_donmuahang_id = cdmh.c_donmuahang_id;
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

                dmh_thue_new.mota = "";
                dmh_thue_new.hoatdong = true;
                if (check_thue == null)
                {
                    dmh_thue_new.ngaytao = DateTime.Now;
                    dmh_thue_new.ngaycapnhat = DateTime.Now;
                    if (cdmh.thue != "")
                    {
                        db.c_donmuahang_thue.Add(dmh_thue_new);
                    }
                }
                else
                {
                    dmh_thue_new.ngaycapnhat = DateTime.Now;
                }
                //--

                db.SaveChanges();
                db.c_donmuahang_thue.RemoveRange(db.c_donmuahang_thue.Where(s => s.tong_tien_chiu_thue <= 0));
                db.SaveChanges();

                //Start cap nhat don mua hang             
                dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == cdmh.c_donmuahang_id).Take(1).FirstOrDefault();
                decimal tong_tienhang = decimal.Parse("0.00");
                try { tong_tienhang = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.thanhtien.Value).Sum(); } catch { }
                decimal tong_tienthue = decimal.Parse("0.00");
                try { tong_tienthue = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.tong_tien_thue.Value).Sum(); } catch { }
                decimal tong_tatca = tong_tienhang + tong_tienthue;
                string donvitinh = "VND";
                md_dongtien dt = db.md_dongtien.Where(s => s.md_dongtien_id == dmh.md_dongtien_id).Take(1).FirstOrDefault();
                if (dt != null) { donvitinh = dt.ma_iso; }
                var tth = VNN_ConvertMoney.convert((double)tong_tienhang, donvitinh).FirstOrDefault();
                var ttc = VNN_ConvertMoney.convert((double)tong_tatca, donvitinh).FirstOrDefault();
                dmh.chu_tong_tienhang = tth.Key;
                dmh.chu_tong_tatca = ttc.Key;
                dmh.tong_tienhang = (decimal)tth.Value;
                dmh.tong_tatca = (decimal)ttc.Value;
                db.SaveChanges();
                //End cap nhat don mua hang
            }
            if (msg == "")
            {
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
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            string thue = context.Request.Form["thue"];
            string co_ngayhethan = context.Request.Form["co_ngayhethan"];
            decimal dongiamua = decimal.Parse(context.Request.Form["dongiamua"]);
            decimal sl_dadat = decimal.Parse(context.Request.Form["sl_dadat"]);
            decimal thanhtien = 0, sl_thaythe = 0, sl_thaythe2 = 0, saiso = 0;
            var object_ = db.c_donmuahang_cdmh.Where(p => p.c_donmuahang_cdmh_id == id).Take(1).FirstOrDefault();
            c_donmuahang dmh = null;
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if(dongiamua > object_.giachuan)
            {
                msg = @"false#Giá mua không thể lớn hơn giá chuẩn.";
            }
            else
            {
                dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).Take(1).FirstOrDefault();
                if (dmh == null)
                {
                    msg = "false#Không tìm thấy đơn mua hàng.";
                }
                else if (dmh.md_trangthai_id == "HIEULUC")
                {
                    msg = "false#Đơn mua hàng đã hiệu lực, không thể sửa.";
                }

                thanhtien = dongiamua * sl_dadat;

                var sp_obj = db.md_sanpham.Where(s => s.md_sanpham_id == object_.md_sanpham_id).FirstOrDefault();
                if (sp_obj != null)
                {
                    var dvt = db.md_donvitinhsanpham_cddv.
                        Where(s => s.md_sanpham_id == sp_obj.ma_sanpham & s.md_donvitinhsanpham_id == object_.md_donvitinhsanpham_id).FirstOrDefault();
                    if (dvt != null)
                    {
                        sl_thaythe = dvt.nhanvoi.GetValueOrDefault(0) * sl_dadat;
                        sl_thaythe2 = dvt.nhanvoi.GetValueOrDefault(0) * 0;
                        saiso = dvt.chiacho.GetValueOrDefault(0) * sl_dadat;
                        if (saiso > dvt.saiso_toida.GetValueOrDefault(9999999))
                            saiso = dvt.saiso_toida.GetValueOrDefault(9999999);
                    }
                    else if (object_.md_donvitinhsanpham_id == sp_obj.md_donvitinhsanpham_id)
                    {
                        sl_thaythe = sl_dadat;
                        sl_thaythe2 = 0;
                        saiso = 0;
                    }
                    else
                    {
                        string tendvt = db.md_donvitinhsanpham.Where(s => s.md_donvitinhsanpham_id == object_.md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
                        msg = string.Format(@"false#Lỗi: Mã sản phẩm ""{0}"" không có đơn vị tính ""{1}""",
                            sp_obj.ma_sanpham,
                            tendvt);
                    }
                }
            }
            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { "sl_dadat2", "saiso" };
                string ten_table = "c_donmuahang_cdmh";
                VNN_Function.SetFormValue("sl_dadat2", sl_thaythe.ToString());
                VNN_Function.SetFormValue("saiso", saiso.ToString());
                VNN_Function.SetFormValue("thanhtien", thanhtien.ToString());
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
                string donvitinh = "VND";
                md_dongtien dt = db.md_dongtien.Where(s => s.md_dongtien_id == dmh.md_dongtien_id).Take(1).FirstOrDefault();
                if (dt != null) { donvitinh = dt.ma_iso; }

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
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "c_donmuahang_cdmh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            decimal tong_tienhang_update = 0, tong_tatca_update = 0;
            string c_donmuahang_id = "";
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                c_donmuahang_cdmh object_ = db.c_donmuahang_cdmh.Where(p => p.c_donmuahang_cdmh_id == id_del_).Take(1).FirstOrDefault();
                md_thue_sanpham thue_sp = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == object_.thue).FirstOrDefault();
                c_donmuahang c = db.c_donmuahang.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).FirstOrDefault();
                decimal gt_thue = 0;
                c_donmuahang_id = object_.c_donmuahang_id;
                if (thue_sp != null)
                    gt_thue = thue_sp.giatri.Value;

                decimal tong_tien_thue = ((decimal)object_.thanhtien * gt_thue / 100), tong_tien_chiu_thue = (decimal)object_.thanhtien + tong_tien_thue;


                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (c.md_trangthai_id == "HIEULUC")
                {
                    msg_del = "Lỗi:Đơn hàng đã hiệu lực !";
                    msg += msg_del + "\n";
                }

                if (msg_del.Length <= 0)
                {
                    c_donmuahang_thue d = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id & s.md_thue_sanpham_id == object_.thue).FirstOrDefault();
                    if (d != null)
                    {
                        d.tong_tien_thue = d.tong_tien_thue - tong_tien_thue;
                        d.tong_tien_chiu_thue = d.tong_tien_chiu_thue - tong_tien_chiu_thue;
                    }
                    tong_tienhang_update += object_.thanhtien.Value;
                    tong_tatca_update += tong_tien_chiu_thue;
                    db.c_donmuahang_cdmh.Remove(object_);
                }
            }

            if (msg.Length <= 0)
            {
                c_donmuahang c = db.c_donmuahang.Where(s => s.c_donmuahang_id == c_donmuahang_id).FirstOrDefault();
                string donvitinh = "VND";
                md_dongtien dt = db.md_dongtien.Where(s => s.md_dongtien_id == c.md_dongtien_id).Take(1).FirstOrDefault();
                if (dt != null) { donvitinh = dt.ma_iso; }
                if (c != null)
                {
                    var tth = VNN_ConvertMoney.convert((double)(c.tong_tienhang - tong_tienhang_update), donvitinh).FirstOrDefault();
                    var ttc = VNN_ConvertMoney.convert((double)(c.tong_tatca - tong_tatca_update), donvitinh).FirstOrDefault();
                    c.tong_tienhang = (decimal)tth.Value;
                    c.tong_tatca = (decimal)ttc.Value;
                    c.chu_tong_tienhang = tth.Key;
                    c.chu_tong_tatca = tth.Key;
                }
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Xóa thành công.";
                db.c_donmuahang_thue.RemoveRange(db.c_donmuahang_thue.Where(s => s.tong_tien_chiu_thue <= 0));
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