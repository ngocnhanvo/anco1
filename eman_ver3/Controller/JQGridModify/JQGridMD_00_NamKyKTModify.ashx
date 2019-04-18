<%@ WebHandler Language="C#" Class="JQGridMD_00_NamKyKTModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_NamKyKTModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
			case "CA_01_Tao12kychoNam":
                this.CA_01_Tao12kychoNam(context);
                break;
            default:
                break;
        }
    }
	
	public void CA_01_Tao12kychoNam(HttpContext context)
	{
		EntityContext db = new EntityContext();
        string msg = "", id = context.Request.Form["id"];
		User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
		md_namtaichinh ntc = db.md_namtaichinh.FirstOrDefault(s=>s.md_namtaichinh_id == id);
		if(ntc == null) {
			msg = "<div style='color:red'>Lỗi: Không tìm thấy năm tài chính đã chọn.</div>";
		}
		else if(db.md_namtaichinh_ky.Where(s=>s.md_namtaichinh_id == ntc.md_namtaichinh_id).Count() > 0) {
			msg = "<div style='color:red'>Lỗi: Năm tài chính \""+ ntc.giatri +"\" đã từng tạo kỳ.</div>";
		}
		else {
			for(int i=1; i<= 12; i++) {
				String ngaybatdau = String.Format("0{0}/0{1}/{2} 00:00", 1, i, ntc.giatri);
				String ngayketthuc = String.Format("{0}/0{1}/{2} 23:59", DateTime.DaysInMonth(ntc.giatri.Value, i), i, ntc.giatri.Value);
				if(i > 9)
				{
					ngaybatdau = String.Format("0{0}/{1}/{2} 00:00", 1, i, ntc.giatri);
					ngayketthuc = String.Format("{0}/{1}/{2} 23:59", DateTime.DaysInMonth(ntc.giatri.Value, i), i, ntc.giatri.Value);
				}
				
				md_namtaichinh_ky ntc_ky = new md_namtaichinh_ky{
					md_namtaichinh_ky_id = Helper.getNewId(),
					md_namtaichinh_id = ntc.md_namtaichinh_id,
					
					ma_ky = "Ky"+ i + "-" + ntc.giatri,
					ten_ky = "Kỳ " + i,
					soky = i,
					loaiky = "CHUAN",

					ngaybatdau = DateTime.ParseExact(ngaybatdau, "dd/MM/yyyy HH:mm", null),
					ngayketthuc = DateTime.ParseExact(ngayketthuc, "dd/MM/yyyy HH:mm", null),
					
					nguoitao = us.ad_user_id,
					vaitrotao = us.ad_role_id,
					bophantao = us.md_phongban_id,
					value_nguoitao = us.ma_user,
					value_vaitrotao = us.ten_role,
					value_bophantao = us.ten_phongban,

					nguoicapnhat = us.ad_user_id,
					vaitrocapnhat = us.ad_role_id,
					bophancapnhat = us.md_phongban_id,
					value_nguoicapnhat = us.ma_user,
					value_vaitrocapnhat = us.ten_role,
					value_bophancapnhat = us.ten_phongban,
					ngaytao = DateTime.Now,
					ngaycapnhat = DateTime.Now,
					hoatdong = true
				};
				db.md_namtaichinh_ky.Add(ntc_ky);
			}
			db.SaveChanges();
			msg = "<div style='color:blue'>Tạo 12 kỳ cho năm \""+ ntc.giatri +"\" thành công.</div>";
		}
		context.Response.Write(msg);
	}
	
    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_namtaichinh";
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
            md_namtaichinh object_ = db.md_namtaichinh.Where(p => p.md_namtaichinh_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            
            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_namtaichinh";
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
            string ten_table = "md_namtaichinh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                md_namtaichinh object_ = db.md_namtaichinh.Where(p => p.md_namtaichinh_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                     db.md_namtaichinh.Remove(object_);
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
