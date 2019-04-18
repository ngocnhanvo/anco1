<%@ WebHandler Language="C#" Class="JQGridMD_01_CDKHVattuModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_CDKHVattuModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
			case "CA_01_DuyetSoluongKHMVT":
                this.CA_01_DuyetSoluongKHMVT(context);
                break;
			case "CA_01_khmvt_DOINCC":
                this.CA_01_khmvt_DOINCC(context);
                break;
            default:
                break;
        }
    }
	
	public void CA_01_khmvt_DOINCC(HttpContext context)
	{
		EntityContext db = new EntityContext();
		string msg = "";
        string md_doitackinhdoanh_id = context.Request.Form["md_doitackinhdoanh_id"];
		string[] vnn = context.Request.Form["id"].Split(',');
		md_doitackinhdoanh_id = db.md_doitackinhdoanh.Where(s=>s.ma_dtkd == md_doitackinhdoanh_id).Select(s=>s.md_doitackinhdoanh_id).FirstOrDefault();
		foreach(c_kehoachmuavt_cdh khmvt_cdh in db.c_kehoachmuavt_cdh.Where(s=>vnn.Contains(s.c_kehoachmuavt_cdh_id)))
		{
			khmvt_cdh.md_doitackinhdoanh_id = md_doitackinhdoanh_id;
		}
		db.SaveChanges();
		msg = "Cập nhật các dòng hàng thành công.";
		context.Response.Write(msg);
	}
	
	public void CA_01_DuyetSoluongKHMVT(HttpContext context)
	{
		EntityContext db = new EntityContext();
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        foreach (c_kehoachmuavt_cdh khmvt_cdh in db.c_kehoachmuavt_cdh.Where(s => vnn.Contains(s.c_kehoachmuavt_cdh_id)))
        {
			c_kehoachmuavt khmvt = db.c_kehoachmuavt.Where(s=>s.c_kehoachmuavt_id == khmvt_cdh.c_kehoachmuavt_id).Take(1).FirstOrDefault();
			if(khmvt.c_donmuavattu_id != " "){
				msg = "<div style='color:red'>lỗi: Kế hoạch \"" + khmvt.sochungtu + "\" đã tạo đơn mua vật tư, không thể chỉnh sửa.</div>";
                break;
			}
            else if (sel_val == "0")
            {
                khmvt_cdh.sl_duyet = khmvt_cdh.sl_denghi.Value;
            }
			else if (sel_val == "2")
			{
				khmvt_cdh.sl_duyet = khmvt_cdh.sl_can.Value;
			}
            else {
                // if (slvc_case <= khmvt_cdh.sl_denghi.Value)
                // {
                    // khmvt_cdh.sl_duyet = slvc_case;
                // }
				khmvt_cdh.sl_duyet = slvc_case;
                /*else
                {
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == khmvt_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                    msg = "<div style='color:red'>lỗi: Dòng \"" + sp.ma_sanpham + "\" chỉ có duyệt tối đa là: " + Math.Round(khmvt_cdh.sl_denghi.Value, 4) + "</div>";
                    break;
                }*/
            }
        }
        if (msg == "")
        {
            msg = "<div style='color:blue'>Duyệt số lượng cần mua thành công.</div>";
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
                string ten_table = "c_kehoachmuavt_cdh";
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
        string mota_tiengviet = context.Request.Form["mota_tiengviet"];
        try
        {
            string id = context.Request.Form["id"];
            c_kehoachmuavt_cdh object_ = db.c_kehoachmuavt_cdh.Where(p => p.c_kehoachmuavt_cdh_id == id).Take(1).FirstOrDefault();
            
			if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
			else 
			{
				c_kehoachmuavt khmvt = db.c_kehoachmuavt.Where(s=>s.c_kehoachmuavt_id == object_.c_kehoachmuavt_id).Take(1).FirstOrDefault();
				if(khmvt.c_donmuavattu_id != " ")
					msg = "false#Lỗi: Kế hoạch \"" + khmvt.sochungtu + "\" đã tạo đơn mua vật tư, không thể chỉnh sửa.</div>";
			}
            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_kehoachmuavt_cdh";
                VNN_Function.SetFormValue("md_sanpham_id", "VNN_notpost");
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
            string ten_table = "c_kehoachmuavt_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.c_kehoachmuavt_cdh.Where(p => p.c_kehoachmuavt_cdh_id == id_del_).Select(s => s.c_kehoachmuavt_cdh_id).Take(1).FirstOrDefault();
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