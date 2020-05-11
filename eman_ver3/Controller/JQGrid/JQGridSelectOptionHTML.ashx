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
            case "selBoPhanToPX":
                this.selBoPhanToPX(context);
                break;
            case "selBoPhanLay":
                this.selBoPhanLay(context);
                break;
        }
    }

    public void selKho(HttpContext context)
    {
        var db = new EntityContext();
        string str = "<select>";
        str += context.Request.QueryString["firstnull"] == "true" ? string.Format(@"<option value=""""></option>") : "";
        foreach (var cn in db.md_kho.Where(s => s.hoatdong == true).ToList().OrderBy(s=> int.Parse(Regex.Replace(s.ma_kho, "[^0-9]", ""))))
        {
            str += string.Format(@"<option value=""{0}"" loaikho=""{2}"">{1}</option>",
                cn.md_kho_id,
                cn.ten_kho,
                cn.vattu == true ? "KVT" :
                    !string.IsNullOrEmpty(cn.md_phanxuong_id) & !string.IsNullOrEmpty(cn.md_to_id) & cn.hangton.GetValueOrDefault(false) == false ? "KSX" :
                        !string.IsNullOrEmpty(cn.md_phanxuong_id) & !string.IsNullOrEmpty(cn.md_to_id) & cn.hangton.GetValueOrDefault(false) == true ? "KTSX" :
                            cn.hangton == true ? "KTTP" : cn.ma_kho.StartsWith("KHODG") ? "KDG" : "KTP"
            );
        }
        str += "</select>";
        context.Response.Write(str);
    }

    public void selBoPhanToPX(HttpContext context)
    {
        string sql = string.Format(@"
            select * from (
	            select md_to_id as id, ten_to as value, 1 as orderby, ROW_NUMBER() over (ORDER BY md_phanxuong_id, sapxep) as Num
	            from md_phanxuong_to
	            union
	            select md_phongban_id as id, ten_phongban as value, 2 as orderby, ROW_NUMBER() over (ORDER BY ten_phongban) + 999 as Num
	            from ad_department
            )A
            order by A.orderby, A.Num 
        ");

        var dt = Mbg.Data.SqlClient.SqlHelper.GetData(sql);

        string str = "<select>";
        str += context.Request.QueryString["firstnull"] == "true" ? string.Format(@"<option value=""""></option>") : "";
        foreach (System.Data.DataRow row in dt.Rows)
        {
            str += string.Format(@"<option value=""{0}"">{1}</option>", row["id"] + "", row["value"] + "");
        }
        str += "</select>";
        context.Response.Write(str);
    }

    public void selBoPhanLay(HttpContext context)
    {
        var db = new EntityContext();
        string id = context.Request.QueryString["id"];
        var cdhs = db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == id).Select(s => s.md_kho_id).Distinct();
        var bophanlay = db.md_phanxuong_to.Where(s => cdhs.Contains(s.md_to_id)).Select(s=>new { id = s.md_to_id, ten = s.ten_to });
        var bophanlay2 = db.ad_department.Where(s => cdhs.Contains(s.md_phongban_id)).Select(s=>new { id = s.md_phongban_id, ten = s.ten_phongban });
        var bophanlayAll = bophanlay.Union(bophanlay2);
        string str = "";
        foreach (var cn in bophanlayAll.ToList())
        {
            str += string.Format(@"<option value=""{0}"">{1}</option>"
                , cn.id
                , cn.ten           
            );
        }
        context.Response.Write(str);
    }

    public bool IsReusable
    {
        get { return false; }
    }
}
