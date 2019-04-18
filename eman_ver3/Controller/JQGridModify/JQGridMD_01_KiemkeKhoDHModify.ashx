<%@ WebHandler Language="C#" Class="JQGridMD_01_KiemkeKhoDHModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_KiemkeKhoDHModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_CapnhatSLDD":
                this.CA_01_CapnhatSLDD(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_CapnhatSLDD(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";

        if (msg.Length <= 0)
        {
            foreach (md_kiemke_cdh nknb_cdh in db.md_kiemke_cdh.Where(s => vnn.Contains(s.md_kiemke_cdh_id)))
            {
                md_kiemke kk = db.md_kiemke.Where(s => s.md_kiemke_id == nknb_cdh.md_kiemke_id).FirstOrDefault();
                if (kk.ma_kiemke == "O")
                {
                    msg = "<div style='color:red'>Biên bản \"" + kk.ten_kiemke + "\" đã kiểm kê kho.</div>" + "\n";
                    break;
                }

                if (msg.Length <= 0)
                {
                    decimal sltd = (decimal)nknb_cdh.sl_sosach;
                    if (sel_val == "0")
                    {
                        nknb_cdh.sl_demduoc = sltd;
                    }
                    else
                    {
                        nknb_cdh.sl_demduoc = slvc_case;
                    } 
                }
            }
        }
        if (msg == "")
        {
            msg = "<div style='color:blue'>Cập nhật số lượng đếm được thành công</div>" + "\n";
            db.SaveChanges();
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_sanpham = context.Request.Form["ma_sanpham"];
		string id = context.Request.Form["id_parent"];
        md_sanpham sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
		if(sp == null) {
		    msg = "false#Lỗi: Mã sản phẩm \"" + ma_sanpham + "\" không tồn tại!";
		}
		else {
			md_kiemke_cdh dh = db.md_kiemke_cdh.Where(s => s.md_kiemke_id == id & s.md_sanpham_id == sp.md_sanpham_id).FirstOrDefault();
			if (dh != null)
				msg = "false#Lỗi: Mã sản phẩm \"" + sp.ma_sanpham + "\" đã tồn tại!";
		}

        try
        {
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "md_kiemke_id", "md_sanpham_id" };
                string ten_table = "md_kiemke_cdh";
                VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
                VNN_Function.SetFormValue("md_kiemke_id", id);
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
            string id = context.Request.Form["id"];
            md_kiemke_cdh object_ = db.md_kiemke_cdh.Where(p => p.md_kiemke_cdh_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_kiemke_cdh";
                VNN_Function.SetFormValue("md_sanpham_id", "VNN_notpost");
                VNN_Function.SetFormValue("md_donvitinhsanpham_id", "VNN_notpost");
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
            string ten_table = "md_kiemke_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                md_kiemke_cdh object_ = db.md_kiemke_cdh.Where(p => p.md_kiemke_cdh_id == id_del_).Take(1).FirstOrDefault();
                md_kiemke kk = db.md_kiemke.Where(s => s.md_kiemke_id == object_.md_kiemke_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (kk.ma_kiemke == "O")
                {
                    msg_del = "Lỗi:Biên bản \"" + kk.ten_kiemke + "\" đã kiểm kê." + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    db.md_kiemke_cdh.Remove(object_);
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
