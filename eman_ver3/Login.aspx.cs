using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using DataAcess;
using Google.Authenticator;

public partial class Login : System.Web.UI.Page, System.Web.SessionState.IRequiresSessionState
{
    public ADmin_JSON json = new ADmin_JSON();
    ad_systemconfig ttc = null;
    public string logo = "";
    public bool xacthuc2buoc = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        ttc = json.ad_systemconfigJSON().FirstOrDefault();
        string url_server = Request.Url.Host;
        string urlBalse = Security.UrlBase();
        logo = ttc == null ? urlBalse + " images/logo/imagenotfound.jpg" : urlBalse + ttc.logo + "?ver1";

        var chk = Helper.checkBrower(Context);
        if (!chk.ok)
        {
            lblCaption.Text = $@"Trình duyệt ""{chk.userAgent}"" không được hỗ trợ.{Environment.NewLine}Chỉ hỗ trợ các trình duyệt ""{Helper.trinhDuyets}""";
        }

        xacthuc2buoc = Session["login"] != null;
        if (xacthuc2buoc)
        {
            trMaTaiKhoan1.Style.Add("display", "none");
            trMaTaiKhoan2.Style.Add("display", "none");
            trMatKhau1.Style.Add("display", "none");
            trMatKhau2.Style.Add("display", "none");
            trMaXacThuc1.Style.Remove("display");
            trMaXacThuc2.Style.Remove("display");
        }
        else
        {
            trMaTaiKhoan1.Style.Remove("display");
            trMaTaiKhoan2.Style.Remove("display");
            trMatKhau1.Style.Remove("display");
            trMatKhau2.Style.Remove("display");
            trMaXacThuc1.Style.Add("display", "none");
            trMaXacThuc2.Style.Add("display", "none");
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string duongdan = Security.UrlBase();
        string userId = Security.id_taikhoan(Context);
        try
        {
            if (xacthuc2buoc)
            {
                string token = Session["login"].ToString();
                var tokenJS = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(token);
                var db = new EntityContext();
                string aduserid = tokenJS["ad_user_id"];
                var us = db.ad_user.Where(s => s.ad_user_id == aduserid).FirstOrDefault();
                if(txtMaXacThuc.Text.removeAllSpaceOrTrimText(true) == us.googlePass)
                {
                    Session["login"] = null;
                    FormsAuthentication.SetAuthCookie(token, true);
                    Response.Redirect(duongdan);
                }
                else
                {
                    lblCaption.Text = "Mã xác thực không hợp lệ.";
                }
            }
            else
            {
                var taikhoan = txtTaiKhoan.Text.removeAllSpaceOrTrimText(true);
                var pass = txtMatKhau.Text.removeAllSpaceOrTrimText(true);
                if (string.IsNullOrWhiteSpace(taikhoan))
                {
                    lblCaption.Text = "Chưa nhập tài khoản.";
                }
                else if (string.IsNullOrWhiteSpace(pass))
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
                        //var user = new User_TK();
                        //user.ad_user_id = us.ad_user_id;
                        //user.ma_user = us.ma_user;
                        //user.mauBackground = us.mauBackground;
                        //user.chuyenCachInBTSangPDF = us.chuyenCachInBTSangPDF;
                        //user.tuDongNhanDienCachIn = us.tuDongNhanDienCachIn;
                        //user.googleAuthenticator = us.googleAuthenticator;
                        var userJSon = new Dictionary<string, object>();
                        userJSon["ad_user_id"] = us.ad_user_id;
                        userJSon["ma_user"] = us.ma_user;
                        userJSon["mauBackground"] = us.mauBackground;
                        userJSon["chuyenCachInBTSangPDF"] = us.chuyenCachInBTSangPDF;
                        userJSon["tuDongNhanDienCachIn"] = us.tuDongNhanDienCachIn;
                        userJSon["googleAuthenticator"] = "123456";
                        foreach (ad_user_role tk_vtr in db.ad_user_role.Where(s => s.ad_user_id == us.ad_user_id & s.macdinh == true).ToList())
                        {
                            //user.user_role = us.ad_role_id;
                            //user.user_part = us.md_phongban_id;
                            userJSon["user_role"] = tk_vtr.ad_role_id;
                            userJSon["user_part"] = tk_vtr.md_phongban_id;
                        }

                        bool canXacThucGG = us.googleAuthenticator.GetValueOrDefault(false);
                        string token = Newtonsoft.Json.JsonConvert.SerializeObject(userJSon);

                        if (canXacThucGG)
                        {
                            var gm = new GoogleMail(null);
                            gm.Email = ttc.taikhoanemail;
                            gm.Password = ttc.passemail;
                            gm.Smtp = ttc.emailserver;
                            gm.Port = ttc.port.ToNullableInt().GetValueOrDefault(25);
                            gm.SSL = ttc.website == "1";

                            String uniqueUserKey = Convert.ToString(Guid.NewGuid()).Replace("-", "").Substring(0, 10);
                            string tieude = $"OTP đăng nhập Anco1 vào ngày {DateTime.Now.ToString("dd")} tháng {DateTime.Now.ToString("MM")} năm {DateTime.Now.ToString("yyyy")}";
                            string noidung = $"Mật khẩu của bạn là: <b>{uniqueUserKey}</b>";
                            gm.Send(us.email, tieude, noidung, "");
                            Session["login"] = token;
                            Session.Timeout = 2;
                            us.googlePass = uniqueUserKey;
                            db.SaveChanges();
                            Response.Redirect(duongdan);
                        }
                        else
                        {
                            FormsAuthentication.SetAuthCookie(token, true);
                            Response.Redirect(duongdan);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblCaption.Text = ex.Message;
        }
    }
}