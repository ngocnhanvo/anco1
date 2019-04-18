<%@ WebHandler Language="C#" Class="JQGridMD_02_CodeFileModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_CodeFileModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest (HttpContext context) {
        string oper = "vnn";
        if (Security.id_taikhoan(context) != "")
           oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
        switch (oper)
        {
            case "download":
                this.download(context);
                break;
            case "load_modify":
                this.load_modify(context);
                break;
            case "save_modify":
                this.save_modify(context);
                break;
        }
    }

    public void download(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string type = context.Request.QueryString["type"];
        string mimetype = "";
        string path = "";
        string ten_taptin = "";
        try
        {
            if (type == "load")
            {
                mimetype = "ashx";
                path = Security.UrlBase() + "Controller/JQGrid/JQGrid"+ ma_module +"Load.ashx";
                ten_taptin = "JQGrid"+ ma_module +"Load.ashx";
            }
            else if (type == "modify")
            {
                mimetype = "ashx";
                path = Security.UrlBase() + "Controller/JQGridModify/JQGrid" + ma_module + "Modify.ashx";
                ten_taptin = "JQGrid" + ma_module + "Modify.ashx";
            }
            else if (type == "interface")
            {
                mimetype = "aspx";
                path = Security.UrlBase() + "View/Menu/Content/Module/" + ma_module + ".aspx";
                ten_taptin = ma_module + ".aspx";
            }
            else if (type == "case")
            {
                mimetype = "js";
                path = Security.UrlBase() + "js/Module_script/" + ma_module + ".js";
                ten_taptin = ma_module + ".js";
            }
            else if (type == "bin")
            {
                mimetype = "dll";
                path = Security.UrlBase() + "Download_Bin/ClassLibrary1.dll";
                ten_taptin = "ClassLibrary1.dll";
            }
            else if (type == "linq")
            {
                mimetype = "cs";
                path = Security.UrlBase() + "App_Code/Linq.designer.cs";
                ten_taptin = "Linq.designer.cs";
            }
            context.Response.Clear();
            context.Response.Buffer = true;
            context.Response.ContentType = mimetype;
            context.Response.AddHeader("Content-Disposition", "attachment;filename=" + ten_taptin);
            context.Response.Charset = "";
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.WriteFile(context.Server.MapPath(path));
            context.Response.End();
        }
        catch(Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void load_modify(HttpContext context)
    {
        string ma_module = context.Request.QueryString["ma_module"];
        string type = context.Request.QueryString["type"];
        string path = "";
        if (type == "load")
        {
            path = Security.UrlBase() + "Controller/JQGrid/JQGrid" + ma_module + "Load.ashx";
        }
        else if (type == "modify")
        {
            path = Security.UrlBase() + "Controller/JQGridModify/JQGrid" + ma_module + "Modify.ashx";
        }
        else if (type == "interface")
        {
            path = Security.UrlBase() + "View/Menu/Content/Module/" + ma_module + ".aspx";
        }
        else if (type == "case")
        {
            path = Security.UrlBase() + "js/Module_script/" + ma_module + ".js";
        }
        path = context.Server.MapPath(path);
        string w = System.IO.File.ReadAllText(path, System.Text.Encoding.Unicode);
        context.Response.Write(w);
    }

    public void save_modify(HttpContext context)
    {
        try
        {
            string ma_module = context.Request.QueryString["ma_module"];
            string type = context.Request.QueryString["type"];
            string path = "", value = context.Request.Form["value_code"];
            if (type == "load")
            {
                path = Security.UrlBase() + "Controller/JQGrid/JQGrid" + ma_module + "Load.ashx";
            }
            else if (type == "modify")
            {
                path = Security.UrlBase() + "Controller/JQGridModify/JQGrid" + ma_module + "Modify.ashx";
            }
            else if (type == "interface")
            {
                path = Security.UrlBase() + "View/Menu/Content/Module/" + ma_module + ".aspx";
            }
            else if (type == "case")
            {
                path = Security.UrlBase() + "js/Module_script/" + ma_module + ".js";
            }
            path = context.Server.MapPath(path);
            string w = System.IO.File.ReadAllText(path, System.Text.Encoding.Unicode);
            w = w.Replace(w, value);
            System.IO.File.WriteAllText(path, w, System.Text.Encoding.Unicode);
            context.Response.Write("true[(##)]" + w);
        }
        catch (Exception ex)
        {
            context.Response.Write("false[(##)]"+ ex.Message);
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
