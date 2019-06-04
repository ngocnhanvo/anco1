<%@ WebHandler Language="C#" Class="JQGridSelectOptionHTML" %>
using System;
using System.Web;
using System.Linq;
using DataAcess;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public class JQGridSelectOptionHTML : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string oper = "vnn";
        if (Security.id_taikhoan(context) != "")
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
        switch (oper)
        {
            case "selKho":
                this.selKho(context);
                break;
        }
    }

    public void selKho(HttpContext context)
    {
        var db = new EntityContext();
        string str = "<select>";
        str += context.Request.QueryString["firstnull"] == "true" ? string.Format(@"<option value=""""></option>") : "";
        foreach (var cn in db.md_kho.Where(s => s.hoatdong == true).ToList().OrderBy(s=> Regex.Replace(s.ma_kho, "[^0-9]", "")))
        {
            str += string.Format(@"<option value=""{0}"" loaikho=""{2}"">{1}</option>", cn.md_kho_id, cn.ten_kho,
                cn.vattu == true ? "KVT" : 
                    (!string.IsNullOrEmpty(cn.md_phanxuong_id) & !string.IsNullOrEmpty(cn.md_to_id) ? "KSX" : 
                        (cn.hangton == true ? "KTTP" : "KTP")
                    )
                );
        }
        str += "</select>";
        context.Response.Write(str);
    }

    public bool IsReusable
    {
        get { return false; }
    }
}
