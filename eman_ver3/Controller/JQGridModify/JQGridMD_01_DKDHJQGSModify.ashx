<%@ WebHandler Language="C#" Class="JQGridMD_01_DKDHJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DKDHJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
                string ten_table = "c_doichieuhangton_dkdh";
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
        decimal sl_dat = decimal.Parse(context.Request.Form["sl_dat"]);
        decimal sl_conlai = decimal.Parse(context.Request.Form["sl_conlai"]);
        decimal sl_conlai2 = decimal.Parse(context.Request.Form["sl_conlai2"]);
        try
        {
            //string id = context.Request.Form["id_parent"];
            c_doichieuhangton_dkdh object_ =
                db.c_doichieuhangton_dkdh.Where(p => p.c_doichieuhangton_dkdh_id == id)
                    .Take(1)
                    .FirstOrDefault();
            c_doichieuhangton dc = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (dc.kehoach != " " & dc.kehoach != null)
            {
                msg = "false#Lỗi: \"" + dc.ten_donhang + "\" đã lập kế hoạch";
            }
            else if (sl_conlai > sl_conlai2)
            {
                msg = "false#Lỗi: Không thể vượt quá số lượng tồn kho hiện có : \"" + sl_conlai2 + "\"";
            }
            if (msg.Length <= 0)
            {
                c_doichieuhangton_dklht dklht = db.c_doichieuhangton_dklht.FirstOrDefault(
                s => s.c_doichieuhangton_id == dc.c_doichieuhangton_id & s.md_sanpham_id == object_.md_sanpham_id);
                if (dklht != null)
                    dklht.sl_lay = sl_conlai;

                object_.sl_conlai = sl_conlai;
                object_.sl_dat = sl_dat;
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
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "c_doichieuhangton_dkdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.c_doichieuhangton_dkdh.Where(p => p.c_doichieuhangton_dkdh_id == id_del_).Select(s => s.c_doichieuhangton_dkdh_id).Take(1).FirstOrDefault();
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
