<%@ WebHandler Language="C#" Class="JQGridMD_02_CDHMGJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_CDHMGJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public void ProcessRequest (HttpContext context) {
        string oper = "vnn";
        if (Security.id_taikhoan(context) != "")
           oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
        switch (oper)
        {
            case "edit":
                this.edit(context);
                break;
            case "del":
                this.del(context);
                break;
			case "add":
                this.add(context);
                break;
			case "CA_01_DathangNCCkhac":
                this.CA_01_DathangNCCkhac(context);
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
	
	public void CA_01_DathangNCCkhac(HttpContext context)
	{
		EntityContext db = new EntityContext();
		string msg = "";
		string ma_dtkd = context.Request.Form["ma_dtkd"];
		string check_ = context.Request.Form["check_hieuluc"];
		string c_kehoachdathang_id = "";
		string[] vnn = context.Request.Form["id_sp"].Split(',');
		decimal soluong = decimal.Parse(context.Request.Form["soluong"]);
		md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s=>s.ma_dtkd == ma_dtkd).Take(1).FirstOrDefault();
		if(dtkd == null){
			msg = "<div style='color:red'>Lỗi: Không tìm thấy đối tác \"" + ma_dtkd + "\".</div>";
		}
		
		if(msg.Length <= 0)
		{
			int i = 0;
			string id_c_kehoachdathang_dhncc = "";
			foreach(c_kehoachdathang_dhncc_cdh cdh_ncc in db.c_kehoachdathang_dhncc_cdh.Where(s=>vnn.Contains(s.c_kehoachdathang_dhncc_cdh_id))){
				c_kehoachdathang_dhncc dncc = db.c_kehoachdathang_dhncc.Where(s=>s.c_kehoachdathang_dhncc_id == cdh_ncc.c_kehoachdathang_dhncc_id).Take(1).FirstOrDefault();
				if(check_ == "true")
				{
					soluong = cdh_ncc.soluong.Value;
				}
				if(dncc.chungtu != " "){
					md_doitackinhdoanh dtkd_dncc = db.md_doitackinhdoanh.Where(s=>s.md_doitackinhdoanh_id == dncc.md_doitackinhdoanh_id).Take(1).FirstOrDefault();
					msg = "<div style='color:red'>Lỗi: Dòng đặt hàng NCC \"" + dtkd_dncc.ma_dtkd + "\" đã tạo đơn mua hàng.</div>";
					break;
				}
				else if(cdh_ncc.soluong.Value < soluong)
				{
					md_sanpham sp_dncc = db.md_sanpham.Where(s=>s.md_sanpham_id == cdh_ncc.md_sanpham_id).Take(1).FirstOrDefault();
					msg = "<div style='color:red'>Lỗi: Dòng " + sp_dncc.ma_sanpham + " chỉ có thể đặt tối đa là: "+ cdh_ncc.soluong.Value +".</div>";
					break;
				}
				else {
					c_kehoachdathang_id = dncc.c_kehoachdathang_id;
					
					if(i == 0){
						c_kehoachdathang_dhncc dncc_check = db.c_kehoachdathang_dhncc.Where(s=>s.c_kehoachdathang_id == dncc.c_kehoachdathang_id & 
						s.md_doitackinhdoanh_id == dtkd.md_doitackinhdoanh_id & s.chungtu == " ").Take(1).FirstOrDefault();
						if(dncc_check == null){
							id_c_kehoachdathang_dhncc = Helper.getNewId();
							c_kehoachdathang_dhncc dncc_new = Clone(dncc); 
							dncc_new.c_kehoachdathang_dhncc_id = id_c_kehoachdathang_dhncc;
							dncc_new.md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id;
							dncc_new.banggia = dtkd.md_banggia_id;
							db.c_kehoachdathang_dhncc.Add(dncc_new);
						}
						else {
							id_c_kehoachdathang_dhncc = dncc_check.c_kehoachdathang_dhncc_id;
						}
						//i = 1;
					}
					//--
					c_kehoachdathang_dhncc_cdh cdh_ncc_check = db.c_kehoachdathang_dhncc_cdh.Where(s=>s.c_kehoachdathang_dhncc_id == id_c_kehoachdathang_dhncc
					& s.md_sanpham_id == cdh_ncc.md_sanpham_id).Take(1).FirstOrDefault();
					if(cdh_ncc_check == null){
						c_kehoachdathang_dhncc_cdh cdh_ncc_new = Clone(cdh_ncc); 
						cdh_ncc_new.c_kehoachdathang_dhncc_cdh_id = Helper.getNewId();
						cdh_ncc_new.c_kehoachdathang_dhncc_id = id_c_kehoachdathang_dhncc;
						cdh_ncc_new.soluong = soluong;
						db.c_kehoachdathang_dhncc_cdh.Add(cdh_ncc_new);
					}
					else {
						cdh_ncc_check.soluong += soluong;					
					}
					//--
						cdh_ncc.soluong -= soluong;		
						i = 1;
				}
			}
			
			if(msg.Length <= 0){
				msg = "<div style='color:blue'>Đặt hàng nhà cung cấp \""+ ma_dtkd +"\" thành công.</div>";
				db.SaveChanges();
				foreach(c_kehoachdathang_dhncc dncc in db.c_kehoachdathang_dhncc.Where(s=>s.c_kehoachdathang_id == c_kehoachdathang_id)){
					var c_kehoachdathang_dhncc_cdhs = db.c_kehoachdathang_dhncc_cdh.Where(s=>s.c_kehoachdathang_dhncc_id == dncc.c_kehoachdathang_dhncc_id);
					decimal tong_soluong = c_kehoachdathang_dhncc_cdhs.Select(s=>s.soluong.Value).Sum();
					if(tong_soluong <= 0)
						db.c_kehoachdathang_dhncc.Remove(dncc);
					else {
						foreach(c_kehoachdathang_dhncc_cdh dncc_dh in db.c_kehoachdathang_dhncc_cdh.Where(s => s.soluong <= 0)){
							db.c_kehoachdathang_dhncc_cdh.Remove(dncc_dh);
						}
					}
				}
				db.SaveChanges();
			}
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
                string ten_table = "c_kehoachdathang_dhncc_cdh";
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
            string object_ = db.c_kehoachdathang_dhncc_cdh.Where(p => p.c_kehoachdathang_dhncc_cdh_id == id).Select(s => s.c_kehoachdathang_dhncc_cdh_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            
            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_kehoachdathang_dhncc_cdh";
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
            string ten_table = "c_kehoachdathang_dhncc_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
string object_ = db.c_kehoachdathang_dhncc_cdh.Where(p => p.c_kehoachdathang_dhncc_cdh_id == id_del_).Select(s => s.c_kehoachdathang_dhncc_cdh_id).Take(1).FirstOrDefault();
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
