<%@ WebHandler Language="C#" Class="JQGridMD_01_CDCDHJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_CDCDHJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
        try
        {
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_kehoachdathang_cdhcd";
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
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        string md_px_id = context.Request.Form["md_phanxuong_id"];
        decimal sl_phanphoi = decimal.Parse(context.Request.Form["sl_phanphoi"]);
        try
        {

            if (md_dtk_id != "")
            {
                md_dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
            }
            string id = context.Request.Form["id"];
            var object_ = db.c_kehoachdathang_cdhcd.Where(p => p.c_kehoachdathang_cdhcd_id == id)
                    .Take(1)
                    .FirstOrDefault();
			
			c_kehoachdathang kh = null;
            if (object_ == null){
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa.";
            }
			else if(sl_phanphoi < 0){
				msg = "false#Lỗi: Số lượng cần sản xuất không được âm.";
			}
			else if((string.IsNullOrEmpty(md_dtk_id) | md_dtk_id == "") & (md_px_id == null | md_px_id == "")){
				msg = "false#Lỗi: Không thể bỏ trống cả 2 dữ liêu: Đối tác kinh doanh và phân xưởng sản xuất.";
			}
			else if(sl_phanphoi > object_.sl_candat){
				msg = "false#Lỗi: Số lượng cần đặt: " + object_.sl_candat + " (Lấy ít hơn hoặc bằng với số lượng này).";
			}
			else {
				kh = db.c_kehoachdathang.FirstOrDefault(s => s.c_kehoachdathang_id == object_.c_kehoachdathang_id);
				if(kh.trangthai != "SOANTHAO")
					msg = "false#Lỗi: Dòng kế hoạch đặt hàng \"" + kh.ten_kh + "\" đã hiệu lực.";
			}
			
			if (msg.Length <= 0) {
				 
				//DK: Neu doi tac kinh doanh hoac phan xuong san xuat = null thi so luong phan phoi = sl can dat
				/*if (string.IsNullOrEmpty(md_dtk_id) & md_px_id != null & md_px_id != "") {
					VNN_Function.SetFormValue("sl_phanphoi", object_.sl_candat.ToString());
				} else if (string.IsNullOrEmpty(md_px_id) & md_dtk_id != null & md_dtk_id != "") {
					VNN_Function.SetFormValue("sl_phanphoi", object_.sl_candat.ToString());
				}*/
				string action = "edit";
				string[] column_ex = { };
				VNN_Function.SetFormValue("md_doitackinhdoanh_id", md_dtk_id);
				string ten_table = "c_kehoachdathang_cdhcd";
				VNN_Function.SetFormValue("md_sanpham_id", "VNN_notpost");
				VNN_Function.SetFormValue("sl_phanphoi", sl_phanphoi+"");
				VNN_Function.Set_DefaultvalueColumn(context, action);
				VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
				VNN_Function.loaddulieu_Auto(db, ma_module);
				//--sua sl_phanphoi va sl_candat
				kh.xulykehoach = false;
				db.SaveChanges();
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
            string ten_table = "c_kehoachdathang_cdhcd";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.c_kehoachdathang_cdhcd.Where(p => p.c_kehoachdathang_cdhcd_id == id_del_).Select(s => s.c_kehoachdathang_cdhcd_id).Take(1).FirstOrDefault();
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
