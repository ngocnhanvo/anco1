<%@ WebHandler Language="C#" Class="JQGridMD_02_GiaSanPhamModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_GiaSanPhamModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            string id = context.Request.Form["id_parent"];
            string ma_sanpham = context.Request.Form["md_sanpham_id"];
            string donvitinh = context.Request.Form["md_donvitinhsanpham_id"];
            var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Take(1).FirstOrDefault();

            if (sp == null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" không tồn tại.";
            }
            else
            {
                string chk_sp = db.md_giasanpham.
                        Where(s => s.md_sanpham_id == sp.md_sanpham_id &
                        s.md_phienbangia_id == id &
                        s.md_donvitinhsanpham_id == donvitinh
                        ).Select(s => s.md_sanpham_id).Take(1).FirstOrDefault();
                if (chk_sp != null & chk_sp != "")
                {
                    msg = "false#Lỗi: Mã \"" + ma_sanpham + "\" với đơn vị tính đã tồn tại.";
                }
            }

            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "md_phienbangia_id" };
                string ten_table = "md_giasanpham";
                VNN_Function.SetFormValue("md_phienbangia_id", id);
                VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
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
        try
        {
            string id = context.Request.Form["id"];
            string ma_sanpham = context.Request.Form["md_sanpham_id"];
            string donvitinh = context.Request.Form["md_donvitinhsanpham_id"];
            var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Take(1).FirstOrDefault();
            var object_ = db.md_giasanpham.Where(p => p.md_giasanpham_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (sp == null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" không tồn tại.";
            }
            else
            {
                string chk_sp = db.md_giasanpham.
                        Where(s => 
                        s.md_sanpham_id == sp.md_sanpham_id &
                        s.md_phienbangia_id == id &
                        s.md_donvitinhsanpham_id == donvitinh &
                        s.md_sanpham_id != object_.md_sanpham_id)
                        .Select(s => s.md_sanpham_id).Take(1).FirstOrDefault();
                if (chk_sp != null & chk_sp != "")
                {
                    msg = "false#Lỗi: Mã \"" + ma_sanpham + "\" với đơn vị tính đã tồn tại.";
                }
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_giasanpham";
                VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
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
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "md_giasanpham";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.md_giasanpham.Where(p => p.md_giasanpham_id == id_del_).Select(s => s.md_giasanpham_id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    string action = "del";
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_);
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
