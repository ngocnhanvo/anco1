<%@ WebHandler Language="C#" Class="JQGridMD_01_DKXemDuLieuModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DKXemDuLieuModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            string id = context.Request.QueryString["id"];
            string moduleId = context.Request.Form["ad_module_id"];
            var mod = db.ad_module.Where(s => s.ad_module_id == moduleId).Take(1).FirstOrDefault();
            var object_ = new ad_role_where();
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
            string moduleId = context.Request.Form["ad_module_id"];
            var mod = db.ad_module.Where(s => s.ad_module_id == moduleId).FirstOrDefault();
            var object_ = db.ad_role_where.Where(p => p.ad_role_where_id == id).FirstOrDefault();
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
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        var db = new EntityContext();
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string[] id_del = context.Request.Form["id"].Split(',');
            int count = id_del.Length;
            for (int i = 0; i < count; i++)
            {
                msg_del = "";
                var id_del_ = id_del[i];
                var object_ = db.ad_role_where.Where(p => p.ad_role_where_id == id_del_).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }

                if (msg_del.Length <= 0)
                {
                    db.ad_role_where.Remove(object_);
                }
            }
            
            if (msg.Length <= 0)
            {
                msg = "true#Xóa thành công.";
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = "false#" + msg;
            }
        }
        catch (Exception ex)
        {
            msg = "false#Lỗi: " + ex.Message;
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
