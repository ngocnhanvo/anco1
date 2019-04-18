<%@ WebHandler Language="C#" Class="JQGridMD_00_ChiPhiNVLLoad" %>
using System;
using System.Web;
using System.Linq;
using DataAcess;
public class JQGridMD_00_ChiPhiNVLLoad : IHttpHandler , System.Web.SessionState.IRequiresSessionState {
   public void ProcessRequest(HttpContext context){
        if(Security.id_taikhoan(context) != "") {
            EntityContext db = new EntityContext();
        }
    }
    public bool IsReusable {
        get { return false; }
    }
}
