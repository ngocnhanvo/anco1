<%@ WebHandler Language="C#" Class="JQGridMD_01_CDYeucauModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_CDYeucauModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        decimal soluong_yeucau = decimal.Parse(context.Request.Form["soluong_yeucau"]);

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                md_sanpham sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Take(1).FirstOrDefault();
                string id = context.Request.Form["id_parent"];
                c_yeucaumuavt ob = db.c_yeucaumuavt.Where(s => s.c_yeucaumuavt_id == id).FirstOrDefault();
                if (ob.md_trangthai_id == "HIEULUC")
                {
                    msg = "Lỗi:Không thể xóa đối tượng đã 'Hiệu Lực'.";
                }
                else if (sp == null)
                {
                    msg = "Lỗi: Mã hàng \"" + ma_sanpham + "\" không tồn tại.";
                }
                else if (soluong_yeucau <= 0)
                {
                    msg = "Lỗi: Số lượng yêu cầu phải lớn hơn 0.";
                }
                else if (db.c_yeucaumuavt_cdh.Where(s => s.md_sanpham_id == sp.md_sanpham_id & s.c_yeucaumuavt_id == id).Count() > 0)
                {
                    msg = "Lỗi: Mã hàng \"" + ma_sanpham + "\" đã được thêm trước đó.";
                }
                else
                {
                    var object_ = new c_yeucaumuavt_cdh();
                    object_.c_yeucaumuavt_cdh_id = id_new;
                    object_.c_yeucaumuavt_id = id;
                    object_.md_sanpham_id = sp.md_sanpham_id;
                    VNN_Function.SetFormValue(object_.nameof(s => s.md_donvitinhsanpham_id), sp.md_donvitinhsanpham_id);
                    object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                    object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    db.c_yeucaumuavt_cdh.Add(object_);
                    db.SaveChanges();
                }
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
                var object_ = db.c_yeucaumuavt_cdh.Where(p => p.c_yeucaumuavt_cdh_id == id).Take(1).FirstOrDefault();

                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa.";
                }
                else
                {
                    var ycmvt = db.c_yeucaumuavt.Where(p => p.c_yeucaumuavt_id.Equals(object_.c_yeucaumuavt_id)).Take(1).FirstOrDefault();
                    if (ycmvt.md_trangthai_id == "HIEULUC")
                    {
                        msg = "Lỗi:Yêu cầu mua \"" + ycmvt.sochungtu + "\" đã hiệu lực, không thể chỉnh sửa.";
                    }
                }
                if (msg.Length <= 0)
                {
                    VNN_Function.SetFormValue(object_.nameof(s=>s.md_sanpham_id), "VNN_notpost");
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
        string msg = "",  msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.c_yeucaumuavt_cdh.Where(p => p.c_yeucaumuavt_cdh_id == id_del_).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else
                    {
                        var ob = db.c_yeucaumuavt.Where(s => s.c_yeucaumuavt_id == object_.c_yeucaumuavt_id).FirstOrDefault();
                        if (ob.c_nhucauvattu_id != null)
                        {
                            msg += string.Format(@"<br><b>{0}</b>: Chỉ có thể thực hiện chức năng này đối với yêu cầu tự tạo", ob.sochungtu);
                        }
                        else if (ob.md_trangthai_id == "HIEULUC")
                        {
                            msg += string.Format(@"<br><b>{0}</b>: Đã được Hiệu Lực", ob.sochungtu);
                        }
                        else
                        {
                            db.c_yeucaumuavt_cdh.Remove(object_);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Xóa thành công");
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
