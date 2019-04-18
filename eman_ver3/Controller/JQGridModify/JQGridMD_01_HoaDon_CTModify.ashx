<%@ WebHandler Language="C#" Class="JQGridMD_01_HoaDon_CTModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_HoaDon_CTModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest (HttpContext context) {
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
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        try
        {
            string md_sanpham_id = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Select(s => s.md_sanpham_id).FirstOrDefault();
            string id = context.Request.Form["id"];
            md_hoadon hd_ = db.md_hoadon.Where(s => s.md_hoadon_id == id).Take(1).FirstOrDefault();
            if (hd_.md_trangthai_id == "HIEULUC")
            {
                msg = "false#Lỗi:Mã hóa đơn đã 'Hiệu lực' không thể sửa";
            }


            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_hoadon_chitiet";
                VNN_Function.SetFormValue("md_sanpham_id",md_sanpham_id);
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;


                hd_.tong_tienhang = 0;
                hd_.tong_vat = 0;
                hd_.tong_tatca = 0;
                db.SaveChanges();

                db = new EntityContext();
                md_hoadon hd = db.md_hoadon.Where(s => s.md_hoadon_id == id).Take(1).FirstOrDefault();
                string md_dongtien_id = db.c_donmuahang.Where(s => s.sochungtu == hd.sct_thamchieu).Select( s => s.md_dongtien_id).FirstOrDefault();
                string donvitinh = db.md_dongtien.Where(s => s.md_dongtien_id == md_dongtien_id).Select(s => s.ma_iso).FirstOrDefault();

                foreach(md_hoadon_chitiet dh_c in db.md_hoadon_chitiet.Where(s => id == s.md_hoadon_id))
                {
                    hd.tong_tienhang += dh_c.thanhtien;
                    hd.tong_vat += dh_c.tong_vat;
                    hd.tong_tatca += dh_c.tong_tatca;
                }

                var cttc = VNN_ConvertMoney.convert(Convert.ToDouble(hd.tong_tatca), donvitinh).FirstOrDefault();
                hd.chu_tong_tatca = cttc.Key;
                db.SaveChanges();
            }
        }
        catch(Exception ex)
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
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        try
        {
            string id = context.Request.Form["id"];
            string md_sanpham_id = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Select(s => s.md_sanpham_id).FirstOrDefault();
            md_hoadon_chitiet object_ = db.md_hoadon_chitiet.Where(p => p.md_hoadon_chitiet_id == id).Take(1).FirstOrDefault();
            md_hoadon hd_ = db.md_hoadon.Where(s => s.md_hoadon_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (hd_.md_trangthai_id == "HIEULUC")
            {
                msg = "false#Lỗi:Mã hóa đơn đã 'Hiệu lực' không thể sửa";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_hoadon_chitiet";
                VNN_Function.SetFormValue("md_sanpham_id",md_sanpham_id);
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";


                hd_.tong_tienhang = 0;
                hd_.tong_vat = 0;
                hd_.tong_tatca = 0;
                db.SaveChanges();

                db = new EntityContext();
                md_hoadon hd = db.md_hoadon.Where(s => s.md_hoadon_id == id).Take(1).FirstOrDefault();
                string md_dongtien_id = db.c_donmuahang.Where(s => s.sochungtu == hd.sct_thamchieu).Select( s => s.md_dongtien_id).FirstOrDefault();
                string donvitinh = db.md_dongtien.Where(s => s.md_dongtien_id == md_dongtien_id).Select(s => s.ma_iso).FirstOrDefault();

                foreach(md_hoadon_chitiet dh_c in db.md_hoadon_chitiet.Where(s => id == s.md_hoadon_id))
                {
                    hd.tong_tienhang += dh_c.thanhtien;
                    hd.tong_vat += dh_c.tong_vat;
                    hd.tong_tatca += dh_c.tong_tatca;
                }
                var cttc = VNN_ConvertMoney.convert(Convert.ToDouble(hd.tong_tatca), donvitinh).FirstOrDefault();
                hd.chu_tong_tatca = cttc.Key;
                db.SaveChanges();
            }
        }
        catch(Exception ex)
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
            string ten_table = "md_hoadon_chitiet";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_hoadon_chitiet object_ = db.md_hoadon_chitiet.Where(p => p.md_hoadon_chitiet_id == id_del_).Take(1).FirstOrDefault();
                md_hoadon hd_ = db.md_hoadon.Where(s => s.md_hoadon_id == object_.md_hoadon_id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if(hd_.md_trangthai_id == "HIEULUC")
                {
                    msg_del = "Lỗi:Hóa đơn \"" + hd_.maso + "\" đã \"Hiệu lực\" không thể xóa" + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    db.md_hoadon_chitiet.Remove(object_);
                }


                hd_.tong_tienhang = 0;
                hd_.tong_vat = 0;
                hd_.tong_tatca = 0;
                db.SaveChanges();

                db = new EntityContext();
                md_hoadon hd = db.md_hoadon.Where(s => s.md_hoadon_id == object_.md_hoadon_id).Take(1).FirstOrDefault();
                string md_dongtien_id = db.c_donmuahang.Where(s => s.sochungtu == hd.sct_thamchieu).Select( s => s.md_dongtien_id).FirstOrDefault();
                string donvitinh = db.md_dongtien.Where(s => s.md_dongtien_id == md_dongtien_id).Select(s => s.ma_iso).FirstOrDefault();

                foreach(md_hoadon_chitiet dh_c in db.md_hoadon_chitiet.Where(s => object_.md_hoadon_id == s.md_hoadon_id))
                {
                    hd.tong_tienhang += dh_c.thanhtien;
                    hd.tong_vat += dh_c.tong_vat;
                    hd.tong_tatca += dh_c.tong_tatca;
                }
                var cttc = VNN_ConvertMoney.convert(Convert.ToDouble(hd.tong_tatca), donvitinh).FirstOrDefault();
                hd.chu_tong_tatca = cttc.Key;
                db.SaveChanges();
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
