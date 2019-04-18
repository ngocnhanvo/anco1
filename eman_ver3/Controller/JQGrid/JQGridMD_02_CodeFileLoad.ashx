<%@ WebHandler Language="C#" Class="JQGridMD_02_CodeFileLoad" %>
using System;
using System.Web;
using System.Linq;
using DataAcess;
using System.IO;
public class JQGridMD_02_CodeFileLoad : IHttpHandler , System.Web.SessionState.IRequiresSessionState {
    public void ProcessRequest(HttpContext context){
        string oper = "vnn";
        if (Security.id_taikhoan(context) != "")
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];

        if (oper != "vnn")
        {
            EntityContext db = new EntityContext();
            string id = context.Request.QueryString["id"];
            string ma_module = context.Request.QueryString["ma_module"];
            string kq_start = "<table style=\"margin: 15px 0 0 13px;\">", kq_end = "</table>", kq = "";
            ad_module mod_get = db.ad_module.Where(s => s.ad_module_id == id).Take(1).FirstOrDefault();
            string filepath = "";
            string hamxuly = "";
            if (mod_get != null)
                hamxuly = "Controller/JQGridModify/JQGrid" + ma_module + "Modify.ashx?ma_module=" + mod_get.ma_module + "&oper=download";
            //Aspx
            filepath = Security.UrlBase() + mod_get.url;
            filepath = context.Server.MapPath(filepath);
            if (File.Exists(filepath))
            {
                kq += "<tr height = \"40px\">";
                kq += "<td style=\"width:35px\">";
                kq += "<img alt=\"\" src=\"images/mime/aspx.png\" class=\"img_codefile\"/>";
                kq += "</td>";
                kq += "<td>";
                kq += "<span>" + mod_get.ma_module + ".aspx</span><br>";
                kq += "<a class=\"a_codefile\">(Giao diện)</a>";
                kq += "</td>";
                kq += "<td onclick=\"modify_code_edit(\'" + mod_get.ma_module + "\',\'interface\')\" title=\"edit file\" style=\"width:24px\"><span class=\"a_codefile glyphicon glyphicon-pencil\"></span></td>";
                kq += "<td onclick=\"modify_code(\'" + hamxuly + "&type=interface\')\" title=\"download file\" style=\"width:20px\"><span class=\"a_codefile glyphicon glyphicon-save\"></span></td>";
                kq += "</tr>";
            }
            //JQGridLoad
            filepath = Security.UrlBase() + "Controller/JQGrid/JQGrid" + mod_get.ma_module + "Load.ashx";
            filepath = context.Server.MapPath(filepath);
            if (File.Exists(filepath))
            {
                kq += "<tr height = \"40px\">";
                kq += "<td style=\"width:35px\">";
                kq += "<img alt=\"\" src=\"images/mime/ashx.png\" class=\"img_codefile\"/>";
                kq += "</td>";
                kq += "<td>";
                kq += "<span>JQGrid" + mod_get.ma_module + "Load.ashx</span><br>";
                kq += "<a class=\"a_codefile\">(Hàm xử lý giao diện)</a>";
                kq += "</td>";
                kq += "<td onclick=\"modify_code_edit(\'" + mod_get.ma_module + "\',\'load\')\" title=\"edit file\" style=\"width:24px\"><span class=\"a_codefile glyphicon glyphicon-pencil\"></span></td>";
                kq += "<td onclick=\"modify_code(\'" + hamxuly + "&type=load\')\" title=\"download file\" style=\"width:20px\"><span class=\"a_codefile glyphicon glyphicon-save\"></span></td>";
                kq += "</tr>";
            }
            //JS
            filepath = Security.UrlBase() + "js/Module_script/" + mod_get.ma_module + ".js";
            filepath = context.Server.MapPath(filepath);
            if (File.Exists(filepath))
            {
                kq += "<tr height = \"40px\">";
                kq += "<td style=\"width:35px\">";
                kq += "<img alt=\"\" src=\"images/mime/javascript.png\" class=\"img_codefile\"/>";
                kq += "</td>";
                kq += "<td>";
                kq += "<span>" + mod_get.ma_module + ".js </span><br>";
                kq += "<a class=\"a_codefile\">(Chức năng)</a>";
                kq += "</td>";
                kq += "<td onclick=\"modify_code_edit(\'"+ mod_get.ma_module +"\',\'case\')\" title=\"edit file\" style=\"width:24px\"><span class=\"a_codefile glyphicon glyphicon-pencil\"></span></td>";
                kq += "<td onclick=\"modify_code(\'" + hamxuly + "&type=case\')\" title=\"download file\" style=\"width:20px\"><span class=\"a_codefile glyphicon glyphicon-save\"></span></td>";
                kq += "</tr>";
            }
            //JQGridModify
            filepath = Security.UrlBase() + "Controller/JQGridModify/JQGrid" + mod_get.ma_module + "Modify.ashx";
            filepath = context.Server.MapPath(filepath);
            if (File.Exists(filepath))
            {
                kq += "<tr height = \"40px\">";
                kq += "<td style=\"width:35px\">";
                kq += "<img alt=\"\" src=\"images/mime/ashx.png\" class=\"img_codefile\"/>";
                kq += "</td>";
                kq += "<td>";
                kq += "<span>JQGrid" + mod_get.ma_module + "Modify.ashx</span><br>";
                kq += "<a class=\"a_codefile\">(Hàm xử lý chức năng)</a>";
                kq += "</td>";
                kq += "<td onclick=\"modify_code_edit(\'" + mod_get.ma_module + "\',\'modify\')\" title=\"edit file\" style=\"width:24px\"><span class=\"a_codefile glyphicon glyphicon-pencil\"></span></td>";
                kq += "<td onclick=\"modify_code(\'" + hamxuly + "&type=modify\')\" title=\"download file\" style=\"width:20px\"><span class=\"a_codefile glyphicon glyphicon-save\"></span></td>";
                kq += "</tr>";
            }
            //Bin
            filepath = Security.UrlBase() + "Download_Bin/ClassLibrary1.dll";
            filepath = context.Server.MapPath(filepath);
            if (File.Exists(filepath))
            {
                kq += "<tr height = \"40px\">";
                kq += "<td style=\"width:35px\">";
                kq += "<img alt=\"\" src=\"images/mime/dll.png\" class=\"img_codefile\"/>";
                kq += "</td>";
                kq += "<td>";
                kq += "<span>ClassLibrary1.dll</span><br>";
                kq += "<a class=\"a_codefile\">(Thư viện Code)</a>";
                kq += "</td>";
                kq += "<td title=\"library file\" style=\"width:24px\"><span></span></td>";
                kq += "<td onclick=\"modify_code(\'" + hamxuly + "&type=bin\')\" title=\"download file\" style=\"width:20px\"><span class=\"a_codefile glyphicon glyphicon-save\"></span></td>";
                kq += "</tr>";
            }
            //Linq
            filepath = Security.UrlBase() + "App_Code/Linq.designer.cs";
            filepath = context.Server.MapPath(filepath);
            if (File.Exists(filepath))
            {
                kq += "<tr height = \"40px\">";
                kq += "<td style=\"width:35px\">";
                kq += "<img alt=\"\" src=\"images/mime/dbml.png\" class=\"img_codefile\"/>";
                kq += "</td>";
                kq += "<td>";
                kq += "<span>Linq.designer.cs</span><br>";
                kq += "<a class=\"a_codefile\">(Thư viện Linq)</a>";
                kq += "</td>";
                kq += "<td title=\"library file\" style=\"width:24px\"><span></span></td>";
                kq += "<td onclick=\"modify_code(\'" + hamxuly + "&type=linq\')\" title=\"download file\" style=\"width:20px\"><span class=\"a_codefile glyphicon glyphicon-save\"></span></td>";
                kq += "</tr>";
            }
            kq = kq_start + kq + kq_end;
            context.Response.Write(kq);
        }

    }
    public bool IsReusable {
        get { return false; }
    }
}
