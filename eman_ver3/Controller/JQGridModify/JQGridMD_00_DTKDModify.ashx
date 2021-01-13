<%@ WebHandler Language="C#" Class="JQGridMD_00_DTKDModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
public class JQGridMD_00_DTKDModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public string oper = "vnn";
    public void ProcessRequest (HttpContext context) {
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
            case "CA_01_UpdateDTKD":
                this.CA_01_UpdateDTKD(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_UpdateDTKD(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string str =VNN_VariablePublic.connectString_Anco(db);
        string start = context.Request.Form["start"];
        string end = context.Request.Form["end"];
        SqlConnection cnn = new SqlConnection(str);
        SqlCommand cmd = new SqlCommand(@"select * from (select *, ROW_NUMBER() over (order by md_doitackinhdoanh_id) as rownum 
		from md_doitackinhdoanh) P where P.rownum >= " + start +" and P.rownum <= " + end, cnn);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);

        int count_col=0;
        string sql_column = "(";
        foreach (System.Data.DataColumn col in dt.Columns)
        {
            if(col.ColumnName != "rownum"){
                count_col++;
                sql_column += col.ColumnName + ",";
            }
        }

        if(sql_column != "(") { sql_column += "anco_check" + ")"; }

        foreach (System.Data.DataRow row in dt.Rows)
        {
            string md_doitackinhdoanh_id = row[0].ToString();
            md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == md_doitackinhdoanh_id).FirstOrDefault();
            if (dtkd == null)
            {
                string sql_insert = "insert into md_doitackinhdoanh" + sql_column + " values(";
                for (int i = 0; i < count_col; i++)
                {
                    string cell_value = row[i].ToString();
                    if(cell_value == null | cell_value == "") {
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
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.QueryString["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_doitackinhdoanh";
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
            string object_ = db.md_doitackinhdoanh.Where(p => p.md_doitackinhdoanh_id == id).Select(s => s.md_doitackinhdoanh_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_doitackinhdoanh";
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id_del = context.Request.Form["id"];

                var object_ = db.md_doitackinhdoanh.Where(p => p.md_doitackinhdoanh_id == id_del).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần xóa";
                }
                else
                {
                    var pbg001s = db.c_danhsachdathang.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();
                    var pbg002s = db.c_donmuahang.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();
                    var pbg003s = db.md_xuatban.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();
                    var pbg004s = db.md_nhapkho_ncc.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();

                    if(pbg001s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong đơn hàng";
                    else if(pbg002s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong đơn mua hàng hóa vật tư";
                    else if(pbg003s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong xuất bán";
                    else if(pbg004s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong nhập kho từ NCC";
                }

                if (msg.Length <= 0)
                {
                    VNN_Function.Write_log(context, ma_module, null, oper, "MĐT:" + object_.ma_dtkd + ", TĐT:" + object_.ten_dtkd, db);
                    db.md_doitackinhdoanh.Remove(object_);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if(msg.Length <= 0)
            {
                transaction.Commit();
                msg = string.Format("true#{0}", "Xóa đối tác kinh doanh thành công");
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format("false#{0}", msg);
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