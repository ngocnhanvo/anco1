<%@ WebHandler Language="C#" Class="JQGridMD_01_KDLHTJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_KDLHTJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
			c_doichieuhangton dcht = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == id).FirstOrDefault();
			
			if(dcht.phieuhangton != null & dcht.phieuhangton != "")
			{
				msg = "false#Lỗi:Đã lập kế hoạch đặt hàng không thể sửa ";
			}
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_doichieuhangton_dklht";
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
        string module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        decimal sl_lay = decimal.Parse(context.Request.Form["sl_lay"]);
        try
        {
            //string id = context.Request.Form["id_parent"];
            c_doichieuhangton_dklht object_ = db.c_doichieuhangton_dklht.Where(p => p.c_doichieuhangton_dklht_id == id).Take(1).FirstOrDefault();
            c_doichieuhangton dcht = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).FirstOrDefault();
			
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
			else if(dcht.phieuhangton != null & dcht.phieuhangton != "" & dcht.phieuhangton != " ")
			{
				msg = "false#Lỗi:Đã lập kế hoạch đặt hàng không thể sửa ";
			}
            if (msg.Length <= 0)
            {
				foreach (c_doichieuhangton_dkdh dkdh in db.c_doichieuhangton_dkdh.Where(s => s.md_sanpham_id == object_.md_sanpham_id & s.c_doichieuhangton_id == object_.c_doichieuhangton_id)) {
					if (sl_lay > object_.sl_conlai) {
					msg = "false#Số lượng hàng trong kho tồn: " + object_.sl_conlai + " (Lấy ít hơn hoặc bằng với số lượng này)";
					} else if (sl_lay > dkdh.sl_dathang_cp) {
						msg = "false#Số lượng hàng cần đặt : " + dkdh.sl_dathang_cp + " (Lấy ít hơn hoặc bằng với số lượng này)";;
					}
					else {
						object_.sl_lay = sl_lay;
						dkdh.sl_conlai = sl_lay;
						dkdh.sl_dat = dkdh.sl_dathang_cp.Value - sl_lay;
						msg = "true#Cập nhật thành công.";
					}
				}
				db.SaveChanges();
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
            string ten_table = "c_doichieuhangton_dklht";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
string object_ = db.c_doichieuhangton_dklht.Where(p => p.c_doichieuhangton_dklht_id == id_del_).Select(s => s.c_doichieuhangton_dklht_id).Take(1).FirstOrDefault();
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
