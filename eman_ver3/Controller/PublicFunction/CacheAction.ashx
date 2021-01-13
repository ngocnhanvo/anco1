<%@ WebHandler Language="C#" Class="CacheAction" %>
using System;
using System.Web;
using System.Linq;
public class CacheAction : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string oper = context.Request.Params["oper"];
        string modules = context.Request.Form["modules"];
        modules = modules == null ? "" : modules;

        if (oper == "clear")
        {
            var json = new ADmin_JSON();
            json.modules = modules.Split(',').AsEnumerable().ToList();
            json.ClearCache(context);
        }
        else if (oper == "loginForCaching")
        {

        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}