<%@ WebHandler Language="C#" Class="JQGridMD_01_TKtrongVaiTroModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_TKtrongVaiTroModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string oper = "vnn";
        string cookie = Security.id_taikhoan(context);
        if (cookie != "")
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];

        switch (oper)
        {
            case "addmutil":
                this.addmutil(context);
                break;
            case "get_whereex":
                this.get_whereex(context);
                break;
            default:
                break;
        }
    }

    public void addmutil(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string chuoi_TK = context.Request.Form["ad_user_id"];
            string chuoi_TK_bo = context.Request.Form["ad_user_id2"];
            string id = context.Request.QueryString["id"];
            int dem = chuoi_TK.Split('#').Count();
            int dem2 = chuoi_TK_bo.Split('#').Count();

            for (int i = 0; i < dem - 1; i++)
            {
                ad_user tk = db.ad_user.SingleOrDefault(p => p.ad_user_id == chuoi_TK.Split('#')[i]);
                if (tk.ad_role_id != id)
                {
                    tk.ad_role_id = id;
                    msg += "<div class='nhan-thanhcong'>Bổ nhiệm chức vụ cho \"" + tk.ma_user + "\" thành công</div>";
                }
            }

            for (int i = 0; i < dem2 - 1; i++)
            {
                ad_user tk = db.ad_user.SingleOrDefault(p => p.ad_user_id == chuoi_TK_bo.Split('#')[i]);
                if (tk.ad_role_id == id)
                {
                    tk.ad_role_id = null;
                    msg += "<div class='nhan-thanhcong' style='color:red'>Tước bỏ chức vụ cuả \"" + tk.ma_user + "\" thành công</div>";
                }
            }
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        catch (Exception ex)
        {
            msg = "<div class='nhan-thanhcong' style='color:red'>" + ex.Message + "</div>";
        }
        context.Response.Write(msg);
    }

    public void get_whereex(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string kq = "";
        context.Response.Write(kq);
    }
    
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
