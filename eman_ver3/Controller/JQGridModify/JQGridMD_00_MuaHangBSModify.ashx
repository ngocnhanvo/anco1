<%@ WebHandler Language="C#" Class="JQGridMD_00_DonMuaHangModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_DonMuaHangModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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

    //--tao phieu nhap kho
    public string add_ncc(EntityContext db, c_donmuahang dmh, string id, string sochungtu, User_TK us)
    {
        string id_new = Helper.getNewId();
        string ten_dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dmh.md_doitackinhdoanh_id).Select(s => s.ten_dtkd).Take(1).FirstOrDefault();
        md_doitackinhdoanh dtkds = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dmh.md_doitackinhdoanh_id).FirstOrDefault();
        md_nhapkho_ncc check_ncc = db.md_nhapkho_ncc.Where(s => s.c_donmuahang_id == id).FirstOrDefault();
        md_nhapkho_ncc ncc = check_ncc;
        if (check_ncc == null)
        {
            ncc = new md_nhapkho_ncc();
            ncc.md_nhapkho_ncc_id = id_new;
            ncc.c_donmuahang_id = id;
            ncc.ten_dtkd = " - " + ten_dtkd;
            ncc.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id;
            ncc.sochungtu = sochungtu;
            ncc.donhang_thamchieu = dmh.donhang_thamchieu;
            ncc.nguoidung = " - " + dtkds.daidien;
        }
        else
        {
            id_new = ncc.md_nhapkho_ncc_id;

            if (!ncc.md_doitackinhdoanh_id.Contains(dmh.md_doitackinhdoanh_id))
            {
                ncc.ten_dtkd = ncc.ten_dtkd + "<br>" + " - " + ten_dtkd;
                ncc.md_doitackinhdoanh_id = ncc.md_doitackinhdoanh_id + "," + dmh.md_doitackinhdoanh_id;
            }

            if (!ncc.donhang_thamchieu.Contains(dmh.donhang_thamchieu))
            {
                ncc.donhang_thamchieu = ncc.donhang_thamchieu + "<br>" + dmh.donhang_thamchieu;
            }
            if (!ncc.nguoidung.Contains(dtkds.daidien))
            {
                ncc.nguoidung = ncc.nguoidung + "<br>" + " - " + dtkds.daidien;
            }
        }
        ncc.trangthai = "SOANTHAO";
        ncc.ngaychuyen = DateTime.Now;

        ncc.nguoitao = us.ad_user_id;
        ncc.vaitrotao = us.ad_role_id;
        ncc.bophantao = us.md_phongban_id;
        ncc.value_nguoitao = us.ma_user;
        ncc.value_vaitrotao = us.ten_role;
        ncc.value_bophantao = us.ten_phongban;
        ncc.nguoicapnhat = us.ad_user_id;
        ncc.vaitrocapnhat = us.ad_role_id;
        ncc.bophancapnhat = us.md_phongban_id;
        ncc.value_nguoicapnhat = us.ma_user;
        ncc.value_vaitrocapnhat = us.ten_role;
        ncc.value_bophancapnhat = us.ten_phongban;
        ncc.hoatdong = true;
        if (check_ncc == null)
        {
            db.md_nhapkho_ncc.Add(ncc);
            ncc.ngaycapnhat = DateTime.Now;
            ncc.ngaytao = DateTime.Now;
        }
        else
        {
            ncc.ngaycapnhat = DateTime.Now;
        }

        db.SaveChanges();
        return id_new;
    }

    //--tao noi dung phieu nhap kho
    public string add_ncc_dh(EntityContext db, c_donmuahang_cdmh cdmh, c_donmuahang dmh, string id, User_TK us)
    {
        string id_new = Helper.getNewId();

        md_nhapkho_ncc ncc = db.md_nhapkho_ncc.Where(s => s.c_donmuahang_id == id).FirstOrDefault();
        string[] nht = ncc.c_donmuahang_id.Split(',');
        md_nhapkho_ncc_dh check_dh = db.md_nhapkho_ncc_dh.Where(s => s.md_nhapkho_ncc_id == ncc.md_nhapkho_ncc_id & s.md_sanpham_id == cdmh.md_sanpham_id).FirstOrDefault();
        md_nhapkho_ncc_dh ncc_dh = check_dh;

        if (ncc_dh == null)
        {
            ncc_dh = new md_nhapkho_ncc_dh();
            ncc_dh.md_nhapkho_ncc_dh_id = id_new;
            ncc_dh.md_nhapkho_ncc_id = ncc.md_nhapkho_ncc_id;
            ncc_dh.tong_sl_dat = cdmh.sl_dadat;
            ncc_dh.sl_nhap = cdmh.sl_dadat;
        }
        else
        {
            id_new = ncc_dh.md_nhapkho_ncc_dh_id;
            ncc_dh.tong_sl_dat = ncc_dh.tong_sl_dat + cdmh.sl_dadat;
            ncc_dh.sl_nhap = ncc_dh.sl_nhap + cdmh.sl_dadat;

        }
        ncc_dh.md_sanpham_id = cdmh.md_sanpham_id;
        md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdmh.md_sanpham_id).FirstOrDefault();
        ncc_dh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id;
        ncc_dh.mota_tiengviet = sp.mota_tiengviet;
        ncc_dh.mota_tienganh = sp.mota_tienganh;
        ncc_dh.khoden = sp.khomacdinh;
        ncc_dh.sl_danhap = 0;
        ncc_dh.check_kho = false;

        md_doitackinhdoanh dtkds = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dmh.md_doitackinhdoanh_id).FirstOrDefault();
        ncc_dh.mota = "Từ " + dtkds.ten_dtkd;

        ncc_dh.nguoitao = us.ad_user_id;
        ncc_dh.vaitrotao = us.ad_role_id;
        ncc_dh.bophantao = us.md_phongban_id;
        ncc_dh.value_nguoitao = us.ma_user;
        ncc_dh.value_vaitrotao = us.ten_role;
        ncc_dh.value_bophantao = us.ten_phongban;
        ncc_dh.nguoicapnhat = us.ad_user_id;
        ncc_dh.vaitrocapnhat = us.ad_role_id;
        ncc_dh.bophancapnhat = us.md_phongban_id;
        ncc_dh.value_nguoicapnhat = us.ma_user;
        ncc_dh.value_vaitrocapnhat = us.ten_role;
        ncc_dh.value_bophancapnhat = us.ten_phongban;
        ncc_dh.hoatdong = true;

        if (check_dh == null)
        {
            db.md_nhapkho_ncc_dh.Add(ncc_dh);
            ncc.ngaycapnhat = DateTime.Now;
            ncc.ngaytao = DateTime.Now;
        }
        else
        {
            ncc.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();
        return id_new;
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];

        string sochungtu = VNN_VariablePublic.sochungtu(db, "DMH", 1);
        string ma_dtkd = context.Request.Form["md_doitackinhdoanh_id"];
        string md_banggia_id = context.Request.Form["md_banggia_id"];
        string i = "1";
        bool tr = true;
        //string md_dongtien_id = context.Request.Form["md_dongtien_id"];
        try
        {
            md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == ma_dtkd).FirstOrDefault();
            md_banggia bg = db.md_banggia.Where(s => s.md_banggia_id == md_banggia_id).FirstOrDefault();
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "c_kehoachdathang_dhncc_id", "bosung" };
                string ten_table = "c_donmuahang";
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", dtkd.md_doitackinhdoanh_id);
                VNN_Function.SetFormValue("c_kehoachdathang_dhncc_id", i);
                VNN_Function.SetFormValue("bosung", tr.ToString());
                VNN_Function.SetFormValue("sochungtu", sochungtu);
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
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_dtkd = context.Request.Form["md_doitackinhdoanh_id"];
        try
        {
            string id = context.Request.Form["id"]; 
            md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == ma_dtkd).FirstOrDefault();
            c_donmuahang object_ = db.c_donmuahang.Where(p => p.c_donmuahang_id == id).Take(1).FirstOrDefault();
            //c_donmuahang_cdmh cdmh = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).FirstOrDefault();
            int count = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).Count();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (count <= 0)
            {
                msg = "false#Lỗi:Đối tượng chưa có mặc hàng cần mua.";
            }
            else if (object_.tong_tienhang <= 0 & object_.tong_tatca <= 0)
            {
                msg = "false#Lỗi:Đối tượng chưa có tổng tiền hàng.";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_donmuahang";
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", dtkd.md_doitackinhdoanh_id);
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";
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
        string msg = "",  msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "c_donmuahang";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                c_donmuahang object_ = db.c_donmuahang.Where(p => p.c_donmuahang_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.md_trangthai_id == "HIEULUC")
                {
                    msg_del = "Lỗi:Đơn mua hàng \"" + object_.sochungtu + "\"đã hiệu lực.";
                    msg += msg_del + "\n";
                }
                else if (object_.phieunhapkho != " " & object_.phieunhapkho != "" & object_.phieunhapkho != null)
                {
                    msg_del = "Lỗi:Đơn mua hàng \"" + object_.sochungtu + "\"đã tạo phiếu nhập kho.";
                    msg += msg_del + "\n";
                }

                if (msg_del.Length <= 0)
                {
                    db.c_donmuahang.Remove(object_);
                    ////Cap nhat ke hoach dat hang NCC
                    //c_kehoachdathang_dhncc dhncc = db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_dhncc_id == object_.c_kehoachdathang_dhncc_id).Take(1).FirstOrDefault();
                    //dhncc.chungtu = " ";
                    //db.SaveChanges();

                    //db = new EntityContext();
                    //var c_kehoachdathang_dhcpxes = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id);
                    //var c_kehoachdathang_dhnccs = db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id);
                    //if (
                    //    c_kehoachdathang_dhcpxes.Count() == c_kehoachdathang_dhcpxe.Where(s => s.dongdathang == " ").Count() &
                    //    c_kehoachdathang_dhnccs.Count() == c_kehoachdathang_dhncc.Where(s => s.chungtu == " ").Count()
                    //)
                    //{
                    //    c_kehoachdathang khdh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id).FirstOrDefault();
                    //    if (khdh != null)
                    //        khdh.trangthai = "SOANTHAO";
                    //}
                    //db.SaveChanges();
                }
            }

            if (msg.Length <= 0)
            {
                VNN_Function.loaddulieu_Auto(db, ma_module);
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