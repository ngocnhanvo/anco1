<%@ WebHandler Language="C#" Class="JQGridMD_00_FormatterModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_FormatterModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string oper = "vnn";
        if (Security.id_taikhoan(context) != "")
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
        switch (oper)
        {
            case "add":
                this.add(context);
                break;
            case "edit":
                this.edit(context);
                break;
            case "del":
                this.del(context);
                break;
            case "load_noidung":
                this.load_noidung(context);
                break;
            default:
                break;
        }
    }

    public void load_noidung(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_formatter = context.Request.QueryString["ma_formatter"];
        try
        {
            string filepath = Security.UrlBase() + "js/VNN_script/User_GridFormatter.js";
            filepath = context.Server.MapPath(filepath);
            string str_start = "//start " + ma_formatter;
            str_start += "\nfunction " + ma_formatter + "(cellvalue, options, rowObject) {";
            string str_end = "\n}\n//end " + ma_formatter;
            string w = System.IO.File.ReadAllText(filepath, System.Text.Encoding.Unicode);
            msg = VNN_Function.FindString(w, str_start, str_end);
            msg = ReplaceFirst(msg, "\n", "");
            msg = ReplaceFirst(msg, "\t", "");
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public string ReplaceFirst(string text, string search, string replace)
    {
        int pos = text.IndexOf(search);
        if (pos >= 0)
        {
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
        return text;
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_formatter = context.Request.Form["ma_formatter"];
        string code = context.Request.Form["mota"];

        code = VNN_VariablePublic.DecodeHTML(code);
        try
        {
            string id = context.Request.QueryString["id"];
            var tbl = db.ad_formatter.Where(s => s.ma_formatter == ma_formatter);
            if (tbl.Count() > 0)
            {
                msg = "false#" + "Lỗi: Mã Formatter đã tồn tại";
            }

            if (msg.Length <= 0)
            {
                string action = context.Request.Params["oper"];
                string[] column_ex = { };
                string ten_table = "ad_formatter";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.SetFormValue("mota", code);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;

                string filepath = Security.UrlBase() + "js/VNN_script/User_GridFormatter.js";
                filepath = context.Server.MapPath(filepath);
                string w = System.IO.File.ReadAllText(filepath, System.Text.Encoding.Unicode);
                string str_new = "//Add function at here (don't remove this line, please)";
                str_new += "\n//start " + ma_formatter;

                str_new += "\nfunction " + ma_formatter + "(cellvalue, options, rowObject) {";
                str_new += "\n\t" + code.Replace("\n", "\n\t");

                str_new += "\n}\n//end " + ma_formatter;

                string str_replace = "//Add function at here (don't remove this line, please)";
                w = w.Replace(str_replace, str_new);
                System.IO.File.WriteAllText(filepath, w, System.Text.Encoding.Unicode);
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_formatter = context.Request.Form["ma_formatter"];
        string code = context.Request.Form["mota"];
        code = VNN_VariablePublic.DecodeHTML(code);
        try
        {
            string id = context.Request.Form["id"];
            string object_ = db.ad_formatter.Where(p => p.ad_formatter_id == id).Select(s => s.ad_formatter_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = context.Request.Params["oper"];
                string ten_table = "ad_formatter";
                string[] column_ex = { };
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.SetFormValue("mota", code);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";
                string filepath = Security.UrlBase() + "js/VNN_script/User_GridFormatter.js";
                filepath = context.Server.MapPath(filepath);
                string str_start = "//start " + ma_formatter;
                string str_end = "//end " + ma_formatter;
                string w = System.IO.File.ReadAllText(filepath, System.Text.Encoding.Unicode);
                string str_replace = str_start + VNN_Function.FindString(w, str_start, str_end) + str_end;
                string str_new = "";
                str_new += "//start " + ma_formatter;
                str_new += "\nfunction " + ma_formatter + "(cellvalue, options, rowObject) {";
                str_new += "\n\t" + code.Replace("\n", "\n\t");
                str_new += "\n}\n//end " + ma_formatter;
                w = w.Replace(str_replace, str_new);
                System.IO.File.WriteAllText(filepath, w, System.Text.Encoding.Unicode);
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "ad_formatter";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = "";
                var id_del_ = id_del[i];
                ad_formatter object_ = db.ad_formatter.Where(p => p.ad_formatter_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    string action = context.Request.Params["oper"];
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_.ad_formatter_id);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                }

                string filepath = Security.UrlBase() + "js/VNN_script/User_GridFormatter.js";
                filepath = context.Server.MapPath(filepath);
                string str_start = "//start " + object_.ma_formatter;
                string str_end = "//end " + object_.ma_formatter + "\n";
                string w = System.IO.File.ReadAllText(filepath, System.Text.Encoding.Unicode);
                string str_replace = str_start + VNN_Function.FindString(w, str_start, str_end) + str_end;
                w = w.Replace(str_replace, "");
                System.IO.File.WriteAllText(filepath, w, System.Text.Encoding.Unicode);
            }
            VNN_Function.loaddulieu_Auto(db, ma_module);
            if (msg.Length <= 0)
            {
                msg = "true#Xóa thành công.";
            }
            else
            {
                msg = "false#" + msg;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.ToUpper().Contains("REFERENCE"))
            {
                msg = "false#Lỗi: Đang được sử dụng, không thể xóa";
            }
            else
            {
                msg = "false#Lỗi: " + ex.Message;
            }
        }
        context.Response.Write(msg);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}