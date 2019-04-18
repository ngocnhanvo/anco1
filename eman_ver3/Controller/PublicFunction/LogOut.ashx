<%@ WebHandler Language="C#" Class="LogOut" %>

using System;
using System.Web;

public class LogOut : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{

        public void ProcessRequest (HttpContext context) {
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			System.Web.Security.FormsAuthentication.SignOut();
            context.Response.Redirect(Security.UrlBase() + "Login.aspx");
        }
 
        public bool IsReusable {
            get {
                return false;
            }
        }
    
}