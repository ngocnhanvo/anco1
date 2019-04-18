<%@ WebHandler Language="C#" Class="JQGridMD_00_CangBienModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
using DataAcess;

public class JQGridMD_00_CangBienModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_UpdateCB":
                this.CA_01_UpdateCB(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_UpdateCB(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string str = VNN_VariablePublic.connectString_Anco(db);
        string start = context.Request.Form["start"];
        string end = context.Request.Form["end"];
        SqlConnection cnn = new SqlConnection(str);

        SqlCommand cmd = new SqlCommand(@"select * from md_cangbien where hoatdong = 1", cnn);
        cmd.CommandTimeout = 50000;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        int count_col = 0;
        string sql_column = "(";
        foreach (System.Data.DataColumn col in dt.Columns)
        {
            if (col.ColumnName != "rownum")
            {
                count_col++;
                sql_column += col.ColumnName + ",";
            }
        }
        if (sql_column != "(") { sql_column += "anco_check" + ")"; }

        foreach (System.Data.DataRow row in dt.Rows)
        {
            string md_cangbien2 = row[0].ToString();
            md_cangbien spid = db.md_cangbien.Where(s => s.md_cangbien_id == md_cangbien2).FirstOrDefault();
            if (spid == null)
            {
                string sql_insert = "insert into md_cangbien" + sql_column + " values(";
                for (int i = 0; i < count_col; i++)
                {
                    string cell_value = row[i].ToString();
                    if (cell_value == null | cell_value == "")
                    {
                        sql_insert += "NULL,";
                    }
                    else
                    {
                        sql_insert += "N'" + cell_value.Replace("'", "''") + "',";
                    }
                }
                sql_insert += "1)";
                Mbg.Data.SqlClient.SqlHelper.ExcuteNonQuery(sql_insert);
            }
        }
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id_parent = context.Request.Form["id_parent"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_cangbien";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;
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
        try
        {
            string id_parent = context.Request.Form["id_parent"];
            string id = context.Request.Form["id"];
            string object_ = db.md_cangbien.Where(p => p.md_cangbien_id == id ).Select(s => s.md_cangbien_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_cangbien";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";
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
        string msg = "",  msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "md_cangbien";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = "";
                var id_del_ = id_del[i];
                string object_ = db.md_cangbien.Where(p => p.md_cangbien_id == id_del_).Select(s => s.md_cangbien_id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    string action = "del";
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                }
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
