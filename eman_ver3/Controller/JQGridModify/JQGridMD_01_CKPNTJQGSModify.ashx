<%@ WebHandler Language="C#" Class="JQGridMD_01_CKPNTJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_CKPNTJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
        try
        {
            string id = context.Request.Form["id"];
            string idpr = context.Request.Form["id_parent"];

            if(db.c_danhsachdathang.Where(s=>s.c_danhsachdathang_id == idpr).Count() <= 0)
            {
                msg = "false#Không tìm thấy đơn hàng.";
            }

            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = {"c_danhsachdathang_id" };
                VNN_Function.SetFormValue("c_danhsachdathang_id", idpr);
                string ten_table = "c_phidathang";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;
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
        try
        {
            string id = context.Request.Form["id"];
            string object_ = db.c_phidathang.Where(p => p.c_phidathang_id == id).Select(s => s.c_phidathang_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_phidathang";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string[] id_del = context.Request.Form["id"].Split(',');
                for (int i = 0; i < id_del.Length; i++)
                {
                    var id_del_ = id_del[i];
                    var object_ = db.c_phidathang.Where(p => p.c_phidathang_id == id_del_).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format("Lỗi dòng {1}:Không tìm thấy đối tượng cần xóa.<br>", "", i + 1);
                    }

                    if (msg.Length <= 0)
                    {
                        db.c_phidathang.Remove(object_);
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "Lỗi: " + ex.Message;
            }

            if(msg.Length <= 0)
            {
                msg = "true#Xóa thành công";
                transaction.Commit();
            }
            else
            {
                msg = "false#" + msg;
                transaction.Rollback();
            }
        }
        VNN_Function.loaddulieu_Auto(db, ma_module);
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