using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using DataAcess;
public partial class Login : System.Web.UI.Page, System.Web.SessionState.IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string userId = Security.id_taikhoan(Context);
        //if (userId != "")
        //{
        //    var db = new EntityContext();
        //    db.Configuration.AutoDetectChangesEnabled = false;
        //    db.Configuration.LazyLoadingEnabled = false;
        //    int tk = db.ad_user.Where(p => p.ad_user_id == userId).Take(1).Count();
        //    if (tk > 0)
        //    {
        //        Response.Redirect(Security.UrlBase(), true);
        //    }
        //}
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string duongdan = Security.UrlBase();
        string userId = Security.id_taikhoan(Context);
        try
        {
            if (!txtTaiKhoan.Text.Equals("") & !txtMatKhau.Text.Equals(""))
            {
                var db = new EntityContext();
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                string pass = Security.EncodeMd5Hash(txtMatKhau.Text);
                var us = db.ad_user.Where(s => s.ma_user == txtTaiKhoan.Text & s.matkhau == pass).Select(s => new { s.ad_user_id }).FirstOrDefault();

                if (us != null)
                {
                    Dictionary<string, object> userJSon = new Dictionary<string, object>();
                    userJSon["ad_user_id"] = us.ad_user_id;
                    foreach (ad_user_role tk_vtr in db.ad_user_role.Where(s => s.ad_user_id == us.ad_user_id & s.macdinh == true).ToList())
                    {
                        userJSon["user_role"] = tk_vtr.ad_role_id;
                        userJSon["user_part"] = tk_vtr.md_phongban_id;
                    }
                    string token = Newtonsoft.Json.JsonConvert.SerializeObject(userJSon);
                    FormsAuthentication.SetAuthCookie(token, true);
                    Response.Redirect(Security.UrlBase());
                }
            }
            else
            {
                lblCaption.Text = "Bạn chưa nhập đầy đủ thông tin.";
            }
        }
        catch (Exception ex)
        {
            lblCaption.Text = "false#" + ex.Message;
        }
    }
}