<%@ WebHandler Language="C#" Class="JQGridMD_01_PXToModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_PXToModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public string oper = "vnn";
    public void ProcessRequest (HttpContext context) {
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
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id_parent = context.Request.Form["id_parent"];
            string sapxep = VNN_Config.load_number(context.Request.Form["sapxep"], 10);
            string ma_to = context.Request.Form["ma_to"];
            string ten_to = context.Request.Form["ten_to"];
            string phongbanId = context.Request.Form["phongbanId"];

            if(db.md_phanxuong_to.Where(p => p.ma_to == ma_to).Count() > 0)
            {
                msg = string.Format(@"false#Lỗi:Mã tổ ""{0}"" đã tồn tại", ma_to);
            }
            else if(db.md_phanxuong_to.Where(p => p.ten_to == ten_to &
                p.md_phanxuong_id ==id_parent).Count() > 0)
            {
                msg = string.Format(@"false#Lỗi:Tên tổ ""{0}"" đã tồn tại", ma_to);
            }

            if (msg.Length <= 0)
            {
                var pb = db.ad_department.Where(s => s.md_phongban_id == phongbanId).FirstOrDefault();
                if (pb == null)
                    msg = string.Format(@"false#Lỗi: Không tìm thấy phân xưởng đã chọn");
                else
                {
                    string action = context.Request.Params["oper"];
                    string[] column_ex = { "md_phanxuong_id", "ma_to", "ten_to" };
                    VNN_Function.SetFormValue("md_phanxuong_id", id_parent);
                    string ten_table = "md_phanxuong_to";
                    VNN_Function.SetFormValue("ma_to", pb.ma_phongban);
                    VNN_Function.SetFormValue("ten_to", pb.ten_phongban);
                    VNN_Function.SetFormValue("sapxep", sapxep);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                    VNN_Function.SortColumn(ten_table, sapxep, "md_phanxuong_id", id_parent, "phongbanId", pb.md_phongban_id, null);
                    VNN_Function.loaddulieu_Auto(db, ma_module);
                    msg = "true#Thêm thành công." + "#" + id_new;
                }
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
        string ma_to = context.Request.Form["ma_to"];
        string ten_to = context.Request.Form["ten_to"];
        string phongbanId = context.Request.Form["phongbanId"];
        try
        {
            string id = context.Request.Form["id"];
            var object_ = db.md_phanxuong_to.Where(p => p.md_to_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if(db.md_phanxuong_to.Where(p => p.ma_to == ma_to & p.md_to_id != object_.md_to_id).Count() > 0)
            {
                msg = string.Format(@"false#Lỗi:Mã tổ ""{0}"" đã tồn tại", ma_to);
            }
            else if(db.md_phanxuong_to.Where(p => p.ten_to == ten_to &
                p.md_phanxuong_id == object_.md_phanxuong_id &
                p.md_to_id != object_.md_to_id).Count() > 0)
            {
                msg = string.Format(@"false#Lỗi:Tên tổ ""{0}"" đã tồn tại", ma_to);
            }

            if (msg.Length <= 0)
            {
                var pb = db.ad_department.Where(s => s.md_phongban_id == phongbanId).FirstOrDefault();
                if (pb == null)
                    msg = string.Format(@"false#Lỗi: Không tìm thấy phân xưởng đã chọn");
                else
                {
                    string sapxep = VNN_Config.load_number(context.Request.Form["sapxep"], 10);
                    string action = "edit";
                    string[] column_ex = { "ma_to", "ten_to" };
                    string ten_table = "md_phanxuong_to";
                    VNN_Function.SetFormValue("ma_to", pb.ma_phongban);
                    VNN_Function.SetFormValue("ten_to", pb.ten_phongban);
                    VNN_Function.SetFormValue("sapxep", sapxep);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                    VNN_Function.SortColumn(ten_table, sapxep, "md_phanxuong_id", object_.md_phanxuong_id, "phongbanId", pb.md_phongban_id, null);
                    VNN_Function.loaddulieu_Auto(db, ma_module);
                    msg = "true#Cập nhật thành công.";
                }
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.md_phanxuong_to.Where(p => p.md_to_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else
                    {
                        VNN_Function.Write_log(context, ma_module, null, oper, "Tổ:" + object_.ten_to, db);
                        db.md_phanxuong_to.Remove(object_);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Xóa tổ đã chọn thành công");
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format(@"false#{0}", msg.Substring(4));
                transaction.Rollback();
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