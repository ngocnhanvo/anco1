using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using DataAcess;

public partial class Login : System.Web.UI.Page, System.Web.SessionState.IRequiresSessionState
{
    public ADmin_JSON json = new ADmin_JSON();
    ad_systemconfig ttc = null;
    public string logo = "";
    public bool xacthuc2buoc = false;
    string duongdan = Security.UrlBase();

    public void taitrang()
    {
        xacthuc2buoc = false;

        foreach (var key in Session.Keys)
        {
            if (key.ToString() == "login")
                xacthuc2buoc = true;
        }

        if (xacthuc2buoc)
        {
            var dateLG = DateTime.Parse(Session["time"].ToString());
            var total = 120 - (DateTime.Now - dateLG).TotalSeconds;
            if (total <= 0)
            {
                Session.Remove("login");
                Session.Remove("time");
                xacthuc2buoc = false;
            }
        }

        if (xacthuc2buoc)
        {
            trMaTaiKhoan1.Style.Add("display", "none");
            trMaTaiKhoan2.Style.Add("display", "none");
            trMatKhau1.Style.Add("display", "none");
            trMatKhau2.Style.Add("display", "none");
            trMaXacThuc1.Style.Remove("display");
            trMaXacThuc2.Style.Remove("display");
            trMaXacThuc3.Style.Add("display", "none");
            trMaXacThuc4.Style.Remove("display");
        }
        else
        {
            trMaTaiKhoan1.Style.Remove("display");
            trMaTaiKhoan2.Style.Remove("display");
            trMatKhau1.Style.Remove("display");
            trMatKhau2.Style.Remove("display");
            trMaXacThuc1.Style.Add("display", "none");
            trMaXacThuc2.Style.Add("display", "none");
            trMaXacThuc3.Style.Remove("display");
            trMaXacThuc4.Style.Add("display", "none");
        }
    }

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

        lblCaption.Text = "";
        taitrang();
    }

    protected void btnVerify_Click(object sender, EventArgs e)
    {
        try
        {
            string token = Session["login"].ToString();
            var tokenJS = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(token);
            var db = new EntityContext();
            string aduserid = tokenJS["ad_user_id"];
            var us = db.ad_user.Where(s => s.ad_user_id == aduserid).FirstOrDefault();
            if (txtMaXacThuc.Text.removeAllSpaceOrTrimText(true) == us.googlePass)
            {
                Session.Remove("login");
                Session.Remove("time");
                FormsAuthentication.SetAuthCookie(token, true);
                Response.Redirect(duongdan);
            }
            else
            {
                lblCaption.Text = "Mã xác thực không hợp lệ.";
            }
        }
        catch (Exception ex)
        {
            lblCaption.Text = ex.Message;
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string userId = Security.id_taikhoan(Context);
        try
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
                    userJSon["googleAuthenticator"] = "123456";
                    foreach (ad_user_role tk_vtr in db.ad_user_role.Where(s => s.ad_user_id == us.ad_user_id & s.macdinh == true).ToList())
                    {
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

                        string uniqueUserKey = Convert.ToString(Guid.NewGuid()).Replace("-", "").Substring(0, 10);
                        var ngay = DateTime.Now.ToString("dd");
                        var thang = DateTime.Now.ToString("MM");
                        var nam = DateTime.Now.ToString("yyyy");
                        var gio = DateTime.Now.ToString("HH");
                        var phut = DateTime.Now.ToString("mm");
                        string tieude = $"Mã đăng nhập Anco1 được cấp vào ngày {ngay} tháng {thang} năm {nam} lúc {gio} giờ {phut} phút";
                        string noidung = $"Mã đăng nhập của bạn là: <b>{uniqueUserKey}</b>";
                        gm.Send(us.email, tieude, noidung, "");
                        Session.Add("login", token);
                        Session.Add("time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        //Session["login"] = token;
                        //Session["time"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        Session.Timeout = 2;
                        us.googlePass = uniqueUserKey;
                        db.SaveChanges();
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(token, true);
                        Response.Redirect(duongdan);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblCaption.Text = ex.Message;
        }

        taitrang();
    }
}