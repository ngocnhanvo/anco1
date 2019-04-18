<%@ WebHandler Language="C#" Class="JQGridMD_00_VtroPquyenModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_VtroPquyenModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "selectoption":
                this.SelectOption(context);
                break;
			case "CA_01_CopyVaiTro":
                this.CA_01_CopyVaiTro(context);
                break;
            default:
                break;
        }
    }
	public static T Clone<T>(T source)
    {
        var dcs = new System.Runtime.Serialization.DataContractSerializer(typeof(T));
        using (var ms = new System.IO.MemoryStream())
        {
            dcs.WriteObject(ms, source);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            return (T)dcs.ReadObject(ms);
        }
    }
	
	public void CA_01_CopyVaiTro(HttpContext context)
	{
		EntityContext db = new EntityContext();
		User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", id_new = Helper.getNewId();
		string sel_vaitro_copy = context.Request.Form["sel_vaitro_copy"];
		string id = context.Request.Form["id"];
		string[] arr_id = id.Split(',');
		ad_role role_cp = db.ad_role.FirstOrDefault(s=>s.ad_role_id == sel_vaitro_copy);
		if(role_cp != null) {
			foreach(string id_ in arr_id){
				ad_role role = db.ad_role.FirstOrDefault(s=>s.ad_role_id == id_);
				if(role != null) {
					foreach(ad_role_mmc r_m in db.ad_role_mmc.Where(s=>s.ad_role_id == role.ad_role_id)){
						db.ad_role_mmc.Remove(r_m);
					}
					
					foreach(ad_role_where r_m in db.ad_role_where.Where(s=>s.ad_role_id == role.ad_role_id)){
						db.ad_role_where.Remove(r_m);
					}
					db.SaveChanges();
					
					foreach(ad_role_mmc r_m in db.ad_role_mmc.Where(s=>s.ad_role_id == sel_vaitro_copy)){
						ad_role_mmc r_m_new = Clone(r_m);
						r_m_new.ad_role_mmc_id = Helper.getNewId();
						r_m_new.ad_role_id = role.ad_role_id;
						db.ad_role_mmc.Add(r_m_new);
					}
					
					foreach(ad_role_where r_w in db.ad_role_where.Where(s=>s.ad_role_id == sel_vaitro_copy)){
						ad_role_where r_w_new = Clone(r_w);
						r_w_new.ad_role_where_id = Helper.getNewId();
						r_w_new.ad_role_id = role.ad_role_id;
						db.ad_role_where.Add(r_w_new);
					}
					db.SaveChanges();
					msg += "<div class='nhan-thanhcong' style='color:blue'>\""+ role.ten_role +"\" đã copy lại vai trò \""+ role_cp.ten_role +"\"";
				}
			}
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
            string ma_role = context.Request.Form["ma_role"];
            string loai_thuake = context.Request.Form["loai_thuake"];
            if (ma_role.Length <= 0)
            {
                msg = "false#Mã vai trò không thể bỏ trống!";
            }
            else if (db.ad_role.SingleOrDefault(p => p.ten_role.Equals(ma_role)) != null)
            {
                msg = "false#Mã vai trò này đã tồn tại!";
            }
            
            if(msg.Length <= 0)
            {
                ad_role vtr = new ad_role
                {
                    ad_role_id = id_new,
                    ma_role = ma_role,
                    ten_role = context.Request.Form["ten_role"],
                    role_thuake = (loai_thuake == "update_0") ? context.Request.Form["role_thuake"] : "",
                    
                    ngaytao = DateTime.Now,
                    nguoitao = Security.id_taikhoan(context),
                    ngaycapnhat = DateTime.Now,
                    nguoicapnhat = Security.id_taikhoan(context),
                    mota = context.Request.Form["mota"],
                    hoatdong = true
                };
                db.ad_role.Add(vtr);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công!"+ "#" + id_new;
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
            string loai_thuake = context.Request.Form["loai_thuake"];
            string id = context.Request.Form["id"];
            ad_role vtr = db.ad_role.SingleOrDefault(p => p.ad_role_id == id);
            if (vtr != null)
            {
                vtr.ten_role = context.Request.Form["ten_role"];
                vtr.ma_role = context.Request.Form["ma_role"];
                vtr.role_thuake = (loai_thuake == "update_0") ? context.Request.Form["role_thuake"] : "";
                vtr.ngaytao = DateTime.Now;
                vtr.nguoitao = Security.id_taikhoan(context);
                vtr.ngaycapnhat = DateTime.Now;
                vtr.nguoicapnhat = Security.id_taikhoan(context);
                vtr.mota = context.Request.Form["mota"];
                vtr.hoatdong = true;
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công!";
            }
            else
            {
                msg = "false#Không tìm thấy đối tượng.";
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
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
string object_ = db.ad_role.Where(p => p.ad_role_id == id_del_).Select(s => s.ad_role_id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }

                if (msg_del.Length <= 0)
                {
                    string action = context.Request.Params["oper"];
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, "ad_role", action, column_ex, db);
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

    public void SelectOption(HttpContext context)
    {
        EntityContext db = new EntityContext();
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "";
        str += "<select>";
        str += firstnull ? string.Format("<option value=\"\"></option>") : "";
        foreach (var ccv in db.ad_role.OrderBy(p => p.ten_role))
        {
            str += string.Format("<option value=\"{0}\">{1}</option>", ccv.ad_role_id, ccv.ten_role);
        }
        str += "</select>";
        context.Response.Write(str);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
