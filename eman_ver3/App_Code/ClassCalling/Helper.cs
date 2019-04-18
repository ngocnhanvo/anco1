using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for Helper
/// </summary>
public static class Helper
{
    public static string getNewId()
    {
        return Guid.NewGuid().ToString().Replace("-", "");
    }

    public static string getConnectStrings(string ten_connectstring)
    {
        return System.Web.Configuration.WebConfigurationManager.ConnectionStrings[ten_connectstring].ConnectionString;
    }

    public static string getFilter(HttpContext context)
    {
        string filter = "";
        jqGridHelper.Filter f = new jqGridHelper.Filter();
        bool _search = bool.Parse(context.Request.QueryString["_search"]);
        if (_search)
        {
            String _filters = context.Request.QueryString["filters"];
            if (_filters != null & _filters != "")
            {
                f = jqGridHelper.Filter.CreateFilter(_filters);
                filter = f.ToScript();
            }
        }
        return filter;
    }

    public static int getPage(HttpContext context)
    {
        int kq = 1;
        if (VNN_Validate.check_number(context.Request.QueryString["page"], "int"))
        {
            kq = int.Parse(context.Request.QueryString["page"]);
        }
        return kq;
    }
}