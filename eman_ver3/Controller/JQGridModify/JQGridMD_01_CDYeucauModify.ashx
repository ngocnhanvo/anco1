<%@ WebHandler Language="C#" Class="JQGridMD_01_CDYeucauModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_CDYeucauModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest (HttpContext context) {
        string oper = "vnn";
        if (Security.id_taikhoan(context) != "")
           oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
        
		if(kiemtra(context) == true) {
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
		else {
			context.Response.Write("false#Lỗi:Chỉ có thể thực hiện chức năng này đối với yêu cầu tự tạo.");
		}
    }
	
	public bool kiemtra(HttpContext context) {
		EntityContext db = new EntityContext();
		bool check = true;
		string id = context.Request.Form["id_parent"];
		string action = context.Request.Form["oper"];
		//-----------
		if(action != "del")
		{
			c_yeucaumuavt ob = db.c_yeucaumuavt.Where(s => s.c_yeucaumuavt_id == id).FirstOrDefault();
			if(ob.c_nhucauvattu_id != null)
			{	
				check = false;
			}
		}		
		return check;
	}

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
		string ma_sanpham = context.Request.Form["md_sanpham_id"];
		decimal soluong_yeucau = decimal.Parse(context.Request.Form["soluong_yeucau"]);
        //try
        {
			md_sanpham sp = db.md_sanpham.Where(s=>s.ma_sanpham == ma_sanpham).Take(1).FirstOrDefault();
            string id = context.Request.Form["id_parent"];
			c_yeucaumuavt ob = db.c_yeucaumuavt.Where(s => s.c_yeucaumuavt_id == id).FirstOrDefault();
			if(ob.md_trangthai_id == "HIEULUC")
			{
				msg = "false#Lỗi:Không thể xóa đối tượng đã 'Hiệu Lực' ";
			}
			else if(sp == null) {
				msg = "false#Lỗi: Mã hàng \""+ ma_sanpham +"\" không tồn tại.";
			}
			else if(soluong_yeucau <= 0) {
				msg = "false#Lỗi: Số lượng yêu cầu phải lớn hơn 0.";
			}
			else if(db.c_yeucaumuavt_cdh.Where(s=>s.md_sanpham_id == sp.md_sanpham_id & s.c_yeucaumuavt_id == id).Count() > 0) {
				msg = "false#Lỗi: Mã hàng \""+ ma_sanpham +"\" đã được thêm trước đó.";
			}
			
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "c_yeucaumuavt_id","md_sanpham_id"};
                string ten_table = "c_yeucaumuavt_cdh";
				VNN_Function.SetFormValue("c_yeucaumuavt_id", id);
				VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
				VNN_Function.SetFormValue("md_donvitinhsanpham_id", sp.md_donvitinhsanpham_id );
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;

            }
        }
        //catch(Exception ex)
        {
            //msg = "false#" + ex.Message;
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
            c_yeucaumuavt_cdh object_ = db.c_yeucaumuavt_cdh.Where(p => p.c_yeucaumuavt_cdh_id == id).Take(1).FirstOrDefault();
			
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa.";
            }
            else {
				c_yeucaumuavt ycmvt = db.c_yeucaumuavt.Where(p => p.c_yeucaumuavt_id.Equals(object_.c_yeucaumuavt_id)).Take(1).FirstOrDefault();
				if(ycmvt.md_trangthai_id == "HIEULUC") {
					msg = "false#Lỗi:Yêu cầu mua \""+ ycmvt.sochungtu +"\" đã hiệu lực, không thể chỉnh sửa.";
				}
			}
            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_yeucaumuavt_cdh";
				VNN_Function.SetFormValue("md_sanpham_id","VNN_notpost");
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
            string ten_table = "c_yeucaumuavt_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                c_yeucaumuavt_cdh object_ = db.c_yeucaumuavt_cdh.Where(p => p.c_yeucaumuavt_cdh_id == id_del_).FirstOrDefault();
				c_yeucaumuavt ob = db.c_yeucaumuavt.Where(s => s.c_yeucaumuavt_id == object_.c_yeucaumuavt_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
				else if(ob.c_nhucauvattu_id != null)
				{
					msg_del = "Lỗi:hỉ có thể thực hiện chức năng này đối với yêu cầu tự tạo";
                    msg += msg_del + "\n";
				}
				else if(ob.md_trangthai_id == "HIEULUC")
				{
					msg_del = "Lỗi:Không thể xóa đối tượng đã 'Hiệu Lực' " + i;
                    msg += msg_del + "\n";
				}
                if (msg_del.Length <= 0)
                {
                    string action = "del";
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_.c_yeucaumuavt_cdh_id);
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
