<%@ WebHandler Language="C#" Class="JQGridMD_01_DHModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DHModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_CapnhatSLNKTPX":
                this.CA_01_CapnhatSLNKTPX(context);
                break;
            default:
                break;
        }
    }
	
	public void CA_01_CapnhatSLNKTPX(HttpContext context)
	{
        EntityContext db = new EntityContext();
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        foreach (md_nhapkho_px_dh nk_px_dh in db.md_nhapkho_px_dh.Where(s => vnn.Contains(s.md_nhapkho_px_dh_id)))
        {
            decimal sltd = nk_px_dh.tong_sl_dat.Value - nk_px_dh.sl_danhap.Value;
            if (sel_val == "0")
            {
                nk_px_dh.sl_nhap = sltd;
            }
            else {
                if (slvc_case <= sltd)
                {
                    nk_px_dh.sl_nhap = slvc_case;
                }
                else
                {
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == nk_px_dh.md_sanpham_id).Take(1).FirstOrDefault();
                    msg = "<div style='color:red'>Lỗi: Dòng \"" + sp.ma_sanpham + "\" chỉ có thể chuyển tối đa là: " + VNN_VariablePublic.autoRound(sltd, 4) + "</div>";
                    break;
                }
            }
        }
        if (msg == "")
        {
            msg = "<div style='color:blue'>Cập nhật số lượng nhập kho thành công</div>";
            db.SaveChanges();
        }
        context.Response.Write(msg);
	}
	
    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_nhapkho_px_dh";
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
        decimal sl_nhap = decimal.Parse(context.Request.Form["sl_nhap"]);
        try
        {
            string id = context.Request.Form["id"];
            md_nhapkho_px_dh object_ = db.md_nhapkho_px_dh.Where(p => p.md_nhapkho_px_dh_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (sl_nhap < 0)
            {
                msg = "false#Số lượng nhập phải lớn hớn 0";
            }
            else if (sl_nhap > object_.tong_sl_dat)
            {
                msg = "false#SL nhập phải nhỏ hoặc bằng với SL đặt hàng";
            }
            else if (sl_nhap + object_.sl_danhap > object_.tong_sl_dat)
            {
                msg = "false#Vượt quá mức SL đăt hàng : " + (object_.tong_sl_dat - sl_nhap + object_.sl_danhap);
            }

            foreach (md_nhapkho_px px in db.md_nhapkho_px.Where(s => s.md_nhapkho_px_id == object_.md_nhapkho_px_id))
            {
                if (px.trangthai == "HIEULUC")
                {
                        msg = "false#Đơn hàng đã hiệu lực !";
                }
                else
                {
                        if (msg.Length <= 0)
                    {
                        string action = "edit";
                        string[] column_ex = { };
                        string ten_table = "md_nhapkho_px_dh";
                        VNN_Function.SetFormValue("md_sanpham_id", "VNN_notpost");
                        VNN_Function.Set_DefaultvalueColumn(context, action);
                        VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                        VNN_Function.loaddulieu_Auto(db, ma_module);
                        msg = "true#Cập nhật thành công.";
                    }
                }
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
            string ten_table = "md_nhapkho_px_dh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.md_nhapkho_px_dh.Where(p => p.md_nhapkho_px_dh_id == id_del_).Select(s => s.md_nhapkho_px_dh_id).Take(1).FirstOrDefault();
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