using System;
using System.Linq;
using DataAcess;
public partial class _Default : System.Web.UI.Page , System.Web.SessionState.IRequiresSessionState
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //EntityContext db = new EntityContext();
        string ad_userID = Security.id_taikhoan(Context);
        if (ad_userID == "")
        {
            Response.Redirect(Security.UrlBase() + "Login.aspx");
        }
    }
}
