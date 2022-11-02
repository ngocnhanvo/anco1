<%@ WebHandler Language="C#" Class="JQGridMD_00_DTKDModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
public class JQGridMD_00_DTKDModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest (HttpContext context) {
        if (Security.id_taikhoan(context) != "")
        {
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
            userTK = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context), db);
        }

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
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var object_ = new md_doitackinhdoanh();
                object_.md_doitackinhdoanh_id = id_new;
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
				object_.hoatdong = true;
                db.md_doitackinhdoanh.Add(object_);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Thêm mới thành công#{0}", id_new);
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format(@"false#{0}", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                var object_ = db.md_doitackinhdoanh.Where(p => p.md_doitackinhdoanh_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else
                {
                    object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Cập nhật thành công");
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format(@"false#{0}", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id_del = context.Request.Form["id"];

                var object_ = db.md_doitackinhdoanh.Where(p => p.md_doitackinhdoanh_id == id_del).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần xóa";
                }
                else
                {
                    var pbg001s = db.c_danhsachdathang.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();
                    var pbg002s = db.c_donmuahang.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();
                    var pbg003s = db.md_xuatban.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();
                    var pbg004s = db.md_nhapkho_ncc.Where(s => s.md_doitackinhdoanh_id == object_.md_doitackinhdoanh_id).Take(1).Count();

                    if(pbg001s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong đơn hàng";
                    else if(pbg002s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong đơn mua hàng hóa vật tư";
                    else if(pbg003s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong xuất bán";
                    else if(pbg004s > 0)
                        msg = "Lỗi:Đối tác kinh doanh đã được sử dụng trong nhập kho từ NCC";
                }

                if (msg.Length <= 0)
                {
                    VNN_Function.Write_log(context, ma_module, null, oper, "MĐT:" + object_.ma_dtkd + ", TĐT:" + object_.ten_dtkd, db);
                    db.md_doitackinhdoanh.Remove(object_);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if(msg.Length <= 0)
            {
                transaction.Commit();
                msg = string.Format("true#{0}", "Xóa đối tác kinh doanh thành công");
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format("false#{0}", msg);
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