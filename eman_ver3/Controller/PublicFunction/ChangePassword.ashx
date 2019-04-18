<%@ WebHandler Language="C#" Class="ChangePassword" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAcess;
public class ChangePassword : IHttpHandler, System.Web.SessionState.IRequiresSessionState {

    public void ProcessRequest (HttpContext context) {
        EntityContext db = new EntityContext();
        string ck = context.Session["user_login"].ToString();
        String oldPassword= context.Request.Form["oldpassword"];
        String newPassword= context.Request.Form["newpassword"];
        String confirmPassword= context.Request.Form["confirm"];
        ad_user tk = db.ad_user.SingleOrDefault(p => p.ad_user_id.Equals(ck));

        if (tk != null)
        {
            if(tk.ma_user != "giamdoc" & tk.ma_user != "vanthu" & tk.ma_user != "truongphong" & tk.ma_user != "nhanvien")
            {
                if (tk.matkhau.Equals(Security.EncodeMd5Hash(oldPassword)))
                {
                    if (newPassword.Equals(confirmPassword))
                    {
                        tk.matkhau = Security.EncodeMd5Hash(newPassword);
                        db.SaveChanges();
                        context.Response.Write("Thay đổi mật khẩu thành công.");
                    }
                    else {
                        context.Response.Write("Xác nhận mật khẩu không đúng.");
                    }
                }
                else {
                    context.Response.Write("Sai mật khẩu cũ.");
                }
            }
            else
            {
                context.Response.Write("Tài khoản này là tài khoản demo, bạn không thể thay đổi mật khẩu.");
            }
        }
        else {
            context.Response.Write("Tài khoản không tồn tại.");
        }
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}