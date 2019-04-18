<%@ WebHandler Language="C#" Class="JQGridMD_00_DVTSPModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
public class JQGridMD_00_DVTSPModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest (HttpContext context) {
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
            case "CA01GetDVTSP_MD00DVTJQGS":
                this.CA01GetDVTSP_MD00DVTJQGS(context);
                break;
            default:
                break;
        }
    }
    public void CA01GetDVTSP_MD00DVTJQGS(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string str =VNN_VariablePublic.connectString_Anco(db);
        SqlConnection cnn = new SqlConnection(str);
        SqlCommand cmd = new SqlCommand(@"select 
		  [md_donvitinhsanpham_id]
		  ,[ma_edi]
		  ,[ten_dvt]
		  ,[ngaytao]
		  ,[nguoitao]
		  ,[ngaycapnhat]
		  ,[nguoicapnhat]
		  ,[mota]
		  ,[hoatdong]
		from md_donvitinhsanpham where hoatdong = 1 order by md_donvitinhsanpham_id", cnn);
        cmd.CommandTimeout = 50000;
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        int count_col = 0;
        foreach (System.Data.DataColumn col in dt.Columns)
        {
            count_col++;
        }

        db.md_donvitinhsanpham.RemoveRange(db.md_donvitinhsanpham);
        db.SaveChanges();
        foreach (System.Data.DataRow row in dt.Rows)
        {
            string sql_insert = "insert into md_donvitinhsanpham values(";
            for (int i = 0; i < count_col; i++)
            {
                sql_insert += "N'" + row[i].ToString().Replace("'", "''") + "',";
            }
            sql_insert = sql_insert.Remove(sql_insert.Length - 1) + ")";
            Mbg.Data.SqlClient.SqlHelper.ExcuteNonQuery(sql_insert);
        }
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.QueryString["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_donvitinhsanpham";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;
            }
        }
        catch(Exception ex)
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
            string id = context.Request.Form["id"];
            string object_ = db.md_donvitinhsanpham.Where(p => p.md_donvitinhsanpham_id == id).Select(s => s.md_donvitinhsanpham_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_donvitinhsanpham";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";
            }
        }
        catch(Exception ex)
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
            string ten_table = "md_donvitinhsanpham";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = "";
                var id_del_ = id_del[i];
                string object_ = db.md_donvitinhsanpham.Where(p => p.md_donvitinhsanpham_id == id_del_).Select(s => s.md_donvitinhsanpham_id).Take(1).FirstOrDefault();
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
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table , action, column_ex, db);
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