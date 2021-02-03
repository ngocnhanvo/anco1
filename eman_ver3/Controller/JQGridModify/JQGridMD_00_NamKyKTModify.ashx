<%@ WebHandler Language="C#" Class="JQGridMD_00_NamKyKTModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_NamKyKTModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_Tao12kychoNam":
                this.CA_01_Tao12kychoNam(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_Tao12kychoNam(HttpContext context)
    {
        string msg = "", id = context.Request.Form["id"];
        var ntc = db.md_namtaichinh.FirstOrDefault(s=>s.md_namtaichinh_id == id);
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

                var ntc_ky = new md_namtaichinh_ky {
                    md_namtaichinh_ky_id = Helper.getNewId(),
                    md_namtaichinh_id = ntc.md_namtaichinh_id,

                    ma_ky = "Ky"+ i + "-" + ntc.giatri,
                    ten_ky = "Kỳ " + i,
                    soky = i,
                    loaiky = "CHUAN",

                    ngaybatdau = DateTime.ParseExact(ngaybatdau, "dd/MM/yyyy HH:mm", null),
                    ngayketthuc = DateTime.ParseExact(ngayketthuc, "dd/MM/yyyy HH:mm", null),

                    nguoitao = userTK.ad_user_id,
                    vaitrotao = userTK.ad_role_id,
                    bophantao = userTK.md_phongban_id,
                    value_nguoitao = userTK.ma_user,
                    value_vaitrotao = userTK.ten_role,
                    value_bophantao = userTK.ten_phongban,

                    nguoicapnhat = userTK.ad_user_id,
                    vaitrocapnhat = userTK.ad_role_id,
                    bophancapnhat = userTK.md_phongban_id,
                    value_nguoicapnhat = userTK.ma_user,
                    value_vaitrocapnhat = userTK.ten_role,
                    value_bophancapnhat = userTK.ten_phongban,
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
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                if (msg.Length <= 0)
                {
                    var object_ = new md_namtaichinh();
                    object_.md_namtaichinh_id = id_new;
                    object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                    object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    db.md_namtaichinh.Add(object_);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
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
                var object_ = db.md_namtaichinh.Where(p => p.md_namtaichinh_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
                }

                if (msg.Length <= 0)
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
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.md_namtaichinh.Where(p => p.md_namtaichinh_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else
                    {
                        var checkUse = db.md_modongky.Where(s => s.md_namtaichinh_id == object_.md_namtaichinh_id).Count();
                        if (checkUse > 0)
                            msg += string.Format(@"<br><b>{0}</b>: Có liên kết với Mở Đóng Kỳ.", object_.ten_namtaichinh);
                        else
                        {
                            VNN_Function.Write_log(context, ma_module, null, oper, "NTC:" + object_.ten_namtaichinh, db);
                            db.md_namtaichinh.Remove(object_);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if(msg.Length <= 0)
            {
                msg = @"true#Xóa năm tài chính đã chọn thành công.";
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
