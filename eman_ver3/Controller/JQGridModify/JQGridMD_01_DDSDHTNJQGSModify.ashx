<%@ WebHandler Language="C#" Class="JQGridMD_01_DDSDHModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
using System.Collections.Generic;

public class JQGridMD_01_DDSDHModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA01UpdateDDSAncotradingMD01DDSDHJQGS_MD01DDSDHTNJQGS":
                this.CA01UpdateDDSAncotradingMD01DDSDHJQGS_MD01DDSDHTNJQGS(context);
                break;

            default:
                break;
        }
    }

    public void CA01UpdateDDSAncotradingMD01DDSDHJQGS_MD01DDSDHTNJQGS(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string str = VNN_VariablePublic.connectString_Anco(db);
        string start = context.Request.Form["start"];
        string end = context.Request.Form["end"];
        SqlConnection cnn = new SqlConnection(str);

        SqlCommand cmd = new SqlCommand(@"select * from (select *, ROW_NUMBER() over (order by ngaytao) as rownum 
		from c_dongdsdh where hoatdong = 1 and md_doitackinhdoanh_id = 'e36c38e0982d1b0372708eaa0c6162ed') P where P.rownum >= " + start + " and P.rownum <= " + end, cnn);
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
            string c_dongdsdh_id = row[0].ToString();
            c_dongdsdh dsdh = db.c_dongdsdh.Where(s => s.c_dongdsdh_id == c_dongdsdh_id).FirstOrDefault();
            if (dsdh == null)
            {
                string sql_insert = "insert into c_dongdsdh" + sql_column + " values(";
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
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        int sl_dathang = int.Parse(context.Request.Form["sl_dathang"]);
        try
        {
            decimal cbm = decimal.Parse(context.Request.Form["v2"]);
            decimal gianhap = decimal.Parse(context.Request.Form["gianhap"]);
            string id = context.Request.Form["id_parent"];
            string dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == "VINHGIA").Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
            md_sanpham sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
            int ddsdh = db.c_dongdsdh.Where(s => s.md_sanpham_id == sp.md_sanpham_id & s.c_danhsachdathang_id == id).Count();
            c_danhsachdathang dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == id).FirstOrDefault();
            md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dsdh.md_doitackinhdoanh_id).FirstOrDefault();
            if (dtkd != null)
            {
                md_phienbangia pbg = db.md_phienbangia.Where(s => s.md_banggia_id == dtkd.md_banggia_id & s.md_trangthai_id == "HIEULUC").FirstOrDefault();
            }

            if (dsdh.trangthai == "HIEULUC")
            {
                msg = string.Format(@"false#Lỗi:Đơn hàng ""{0}"" đã ""Hiệu lực"".", dsdh.sochungtu);
            }
            else if (dsdh.trangthai == "HUYBO")
            {
                msg = string.Format(@"false#Lỗi:Đơn hàng ""{0}"" đã ""Hủy"".", dsdh.sochungtu);
            }
            else if (dsdh.trangthai == "KETTHUC")
            {
                msg = string.Format(@"false#Lỗi:Đơn hàng ""{0}"" đã ""Kết thúc"".", dsdh.sochungtu);
            }
            else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count() > 0)
            {
                msg = string.Format(@"false#Lỗi:Đơn hàng ""{0}"" đã tạo phiếu giảm hạn ngạch.", dsdh.sochungtu);
            }
            else if (ddsdh > 0)
            {
                msg = "false#Lỗi:Sản phẩm đã tồn tại.";
            }
            else if (sl_dathang <= 0)
            {
                msg = "false#Lỗi:Số lượng đặt hàng phải lớn hơn 0";
            }
            else if (cbm <= 0)
            {
                msg = "false#Lỗi:CBM phải lớn hơn 0";
            }

            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "c_danhsachdathang_id", "sl_conlai", "sl_dagiao", "md_doitackinhdoanh_id", "sl_hanngach" };
                VNN_Function.SetFormValue("c_danhsachdathang_id", id);
                VNN_Function.SetFormValue("sl_conlai", sl_dathang.ToString());
                VNN_Function.SetFormValue("gianhap", gianhap.ToString());
                VNN_Function.SetFormValue("sl_dagiao", "0");
                VNN_Function.SetFormValue("sl_hanngach", "0");
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", dtk_id);
                VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
                string ten_table = "c_dongdsdh";
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
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        int sl_dathang = int.Parse(context.Request.Form["sl_dathang"]);
        string dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == "ANCO1").Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
        try
        {
            decimal gianhap = decimal.Parse(context.Request.Form["gianhap"]);
            decimal cbm = decimal.Parse(context.Request.Form["v2"]);
            string id = context.Request.Form["id"];
            string id_parent = context.Request.Form["id_parent"];
            md_sanpham sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
            c_dongdsdh object_ = db.c_dongdsdh.Where(p => p.c_dongdsdh_id == id).FirstOrDefault();
            c_danhsachdathang dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == id_parent).FirstOrDefault();
            md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dsdh.md_doitackinhdoanh_id).FirstOrDefault();
            if (dtkd != null)
            {
                md_phienbangia pbg = db.md_phienbangia.Where(s => s.md_banggia_id == dtkd.md_banggia_id & s.md_trangthai_id == "HIEULUC").FirstOrDefault();
            }

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (dsdh.trangthai == "HIEULUC")
            {
                msg = string.Format(@"false#Lỗi:Đơn hàng ""{0}"" đã ""Hiệu lực"".", dsdh.sochungtu);
            }
            else if (dsdh.trangthai == "HUYBO")
            {
                msg = string.Format(@"false#Lỗi:Đơn hàng ""{0}"" đã ""Hủy"".", dsdh.sochungtu);
            }
            else if (dsdh.trangthai == "KETTHUC")
            {
                msg = string.Format(@"false#Lỗi:Đơn hàng ""{0}"" đã ""Kết thúc"".", dsdh.sochungtu);
            }
            else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count() > 0)
            {
                msg = string.Format(@"false#Lỗi:Đơn hàng ""{0}"" đã tạo phiếu giảm hạn ngạch.", dsdh.sochungtu);
            }
            else if (sl_dathang <= 0)
            {
                msg = "false#Lỗi:Số lượng đặt hàng phải lớn hơn 0";
            }
            else if (cbm <= 0)
            {
                msg = "false#Lỗi:CBM phải lớn hơn 0";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { "c_danhsachdathang_id", "sl_conlai", "sl_dagiao", "md_doitackinhdoanh_id" };
                VNN_Function.SetFormValue("sl_conlai", sl_dathang.ToString());
                VNN_Function.SetFormValue("gianhap", gianhap.ToString());
                VNN_Function.SetFormValue("sl_dagiao", "0");
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", dtk_id);
                VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
                string ten_table = "c_dongdsdh";
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
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            List<string> id_del = context.Request.Form["id"].Split(',').ToList();

            for (int i = 0; i < id_del.Count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                c_dongdsdh object_ = db.c_dongdsdh.Where(p => p.c_dongdsdh_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "<br>";
                }
                else
                {
                    c_danhsachdathang dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).FirstOrDefault();
                    if (dsdh.trangthai == "HIEULUC")
                    {
                        msg_del = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã ""Hiệu lực"".", dsdh.sochungtu);
                        msg += msg_del + "<br>";
                    }
                    else if (dsdh.trangthai == "HUYBO")
                    {
                        msg_del = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã ""Hủy"".", dsdh.sochungtu);
                        msg += msg_del + "<br>";
                    }
                    else if (dsdh.trangthai == "KETTHUC")
                    {
                        msg_del = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã ""Kết thúc"".", dsdh.sochungtu);
                        msg += msg_del + "<br>";
                    }
                    else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count() > 0)
                    {
                        msg_del = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã tạo phiếu giảm hạn ngạch.", dsdh.sochungtu);
                        msg += msg_del + "<br>";
                    }
                }
                if (msg_del.Length <= 0)
                {
                    db.c_dongdsdh.Remove(object_);
                }
            }

            if (msg.Length <= 0)
            {
                VNN_Function.loaddulieu_Auto(db, ma_module);
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