<%@ WebHandler Language="C#" Class="JQGridMD_01_DKXemDuLieuModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DKXemDuLieuModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.QueryString["id"];
            ad_module mod = db.ad_module.Where(s => s.ad_module_id == context.Request.Form["ad_module_id"]).Take(1).FirstOrDefault();
            ad_role_where object_ = new ad_role_where();
            //start truyền các giá trị cần thêm
            object_.ad_role_where_id = id_new;
            object_.ad_role_id = id;
            object_.ad_menu_id = mod.ad_menu_id;
            object_.ad_module_id = mod.ad_module_id;
            object_.ma_module = mod.ma_module;
            object_.where_sql = context.Request.Form["where_sql"];
            object_.nguoitao = Security.id_taikhoan(context);
            object_.vaitrotao = Security.id_vaitro(context);
            object_.bophantao = Security.id_phongban(context);
            object_.nguoicapnhat = Security.id_taikhoan(context);
            object_.vaitrocapnhat = Security.id_vaitro(context);
            object_.bophancapnhat = Security.id_taikhoan(context);
            object_.mota = "";
            object_.hoatdong = true;
            //#end truyền các giá trị cần thêm
            db.ad_role_where.Add(object_);
            db.SaveChanges();
            msg = "true#Thêm thành công";
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
            string id = context.Request.QueryString["id"];
            ad_module mod = db.ad_module.Where(s => s.ad_module_id == context.Request.Form["ad_module_id"]).Take(1).FirstOrDefault();
            ad_role_where object_ = db.ad_role_where.SingleOrDefault(p=>p.ad_role_where_id == id);
            if (object_ != null)
            {
                //start truyền các giá trị cần sửa
                object_.ad_role_id = id;
                object_.ad_menu_id = mod.ad_menu_id;
                object_.ad_module_id = mod.ad_module_id;
                object_.ma_module = mod.ma_module;
                object_.where_sql = context.Request.Form["where_sql"];
                object_.nguoicapnhat = Security.id_taikhoan(context);
                object_.vaitrocapnhat = Security.id_vaitro(context);
                object_.bophancapnhat = Security.id_taikhoan(context);
                object_.mota = "";
                object_.hoatdong = bool.Parse(context.Request.Form["hoatdong"]);
                //#end truyền các giá trị cần sửa
                db.SaveChanges();
                msg = "true#Cập nhật thành công";
            }
            else
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
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
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
string object_ = db.ad_role_where.Where(p => p.ad_role_where_id == id_del_).Select(s => s.ad_role_where_id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }

                if (msg_del.Length <= 0)
                {
                    string action = context.Request.Params["oper"];
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, "ad_role_where", action, column_ex, db);
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
