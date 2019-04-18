<%@ WebHandler Language="C#" Class="JQGridMD_02_XVTBSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_XVTBSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            default:
                break;
        }
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
		string ma_sanpham = context.Request.Form["md_sanpham_id"];
        try
        {
            string id = context.Request.Form["id"];
			md_sanpham sp = db.md_sanpham.Where(s=>s.ma_sanpham == ma_sanpham).Take(1).FirstOrDefault();
			if(sp == null) {
				msg = "false#Lỗi: Không tìm thấy hàng hóa/vật tư \""+ ma_sanpham +"\".";
			}
			
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "md_lenhsanxuat_tosx_id", "bosung", "sl_daxuat" };
                string ten_table = "md_lenhsanxuat_vattu";
                VNN_Function.Set_DefaultvalueColumn(context, action);
				VNN_Function.SetFormValue("md_lenhsanxuat_tosx_id", id);
				VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
				VNN_Function.SetFormValue("bosung", "true");
				VNN_Function.SetFormValue("sl_daxuat", "0");
				VNN_Function.SetFormValue("md_donvitinhsanpham_id", sp.md_donvitinhsanpham_id);
				VNN_Function.SetFormValue("mota_tiengviet", sp.mota_tiengviet);
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
			decimal soluong = decimal.Parse(context.Request.Form["soluong"]);
            string id = context.Request.Form["id"];
            md_lenhsanxuat_vattu object_ = db.md_lenhsanxuat_vattu.Where(p => p.md_lenhsanxuat_vattu_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if(soluong > object_.sl_daxuat)
			{
				msg = "false#Lỗi:Số lượng điều chỉnh tối đa là: \""+ object_.sl_daxuat +"\"";	
			}
			
            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_lenhsanxuat_vattu";
                VNN_Function.SetFormValue("md_sanpham_id", "VNN_notpost");
                VNN_Function.SetFormValue("md_donvitinhsanpham_id", "VNN_notpost");
				VNN_Function.SetFormValue("mota_tiengviet", "VNN_notpost");
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
            string ten_table = "md_lenhsanxuat_vattu";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                md_lenhsanxuat_vattu object_ = db.md_lenhsanxuat_vattu.Where(p => p.md_lenhsanxuat_vattu_id == id_del_).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
				/*else if(object_.sl_daxuat > 0)
				{
				    msg_del = "Lỗi: Không thể xóa đòng đã xuất kho " + i;
                    msg += msg_del + "\n";
				}*/
				
                if (msg_del.Length <= 0)
                {
                    db.md_lenhsanxuat_vattu.Remove(object_);
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