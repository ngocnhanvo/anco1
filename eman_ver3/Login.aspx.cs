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
            var taikhoan = txtTaiKhoan.Text.removeAllSpaceOrTrimText(true);
            var pass = txtMatKhau.Text.removeAllSpaceOrTrimText(true);
            if (string.IsNullOrWhiteSpace(taikhoan))
            {
                lblCaption.Text = "Chưa nhập tài khoản.";
            }
            else if(string.IsNullOrWhiteSpace(pass))
            {
                lblCaption.Text = "Chưa nhập mật khẩu.";
            }
            else
            {
                var db = new EntityContext();
                var usss = db.ad_autoload.FirstOrDefault();
                pass = Security.EncodeMd5Hash(pass);
                var us = db.ad_user.Where(s =>
                    s.ma_user == taikhoan
                    & s.matkhau == pass
                ).FirstOrDefault();

                if (us == null)
                {
                    lblCaption.Text = "Thông tin đăng nhập không đúng.";
                }
                else if (!us.hoatdong.GetValueOrDefault(false))
                {
                    lblCaption.Text = "Tài khoản đã bị khóa.";
                }
                else
                {
                    var userJSon = new Dictionary<string, object>();
                    userJSon["ad_user_id"] = us.ad_user_id;
                    userJSon["ma_user"] = us.ma_user;
                    userJSon["mauBackground"] = us.mauBackground;
                    userJSon["chuyenCachInBTSangPDF"] = us.chuyenCachInBTSangPDF;
                    userJSon["tuDongNhanDienCachIn"] = us.tuDongNhanDienCachIn;
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
        }
        catch (Exception ex)
        {
            lblCaption.Text = ex.Message;
        }
    }
}