<%@ WebHandler Language="C#" Class="JQGridMD_00_DVTSPModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
public class JQGridMD_00_DVTSPModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.QueryString["id"];
                var object_ = new md_donvitinhsanpham();
                object_.md_donvitinhsanpham_id = id_new;
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                db.md_donvitinhsanpham.Add(object_);
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
                var object_ = db.md_donvitinhsanpham.Where(p => p.md_donvitinhsanpham_id == id).Take(1).FirstOrDefault();
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

                var object_ = db.md_donvitinhsanpham.Where(p => p.md_donvitinhsanpham_id == id_del).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần xóa";
                }
                else
                {
                    var pbg001s = db.md_giasanpham.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg002s = db.md_sanpham_bom_vattu.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg003s = db.md_donvitinhsanpham_cddv.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg003_1s = db.md_sanpham.Where(s => s.md_donvitinhsanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();

                    var pbg004s = db.c_dongdsdh.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg005s = db.c_donmuahang_cdmh.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg006s = db.c_nhucauvattu_ycmvt.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg007s = db.c_yeucaumuavt_cdh.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg008s = db.md_lenhsanxuat_tosx_vattu.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg008_1s = db.c_kehoachdathang_dhcpx_vattu.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();

                    var pbg009s = db.md_lenhdonggoi_dh.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg010s = db.md_lenhdonggoi_vattu.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg011s = db.md_xuatban_cdh.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg012s = db.md_nhapkhoton_cdh.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();
                    var pbg013s = db.md_xuatkhonb_cdh.Where(s => s.md_sanpham_id == object_.md_donvitinhsanpham_id).Take(1).Count();

                    if(pbg001s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong bảng giá";
                    else if(pbg002s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong BOM";
                    else if(pbg003s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong chuyển đổi đơn vị tính";
                    else if(pbg003_1s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong hàng hóa hoặc vật tư";
                    else if(pbg004s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong đơn hàng";
                    else if(pbg005s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong đơn mua hàng hóa vật tư";
                    else if(pbg006s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong nhu cầu vật tư";
                    else if(pbg007s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong yêu cầu mua vật tư";
                    else if(pbg008s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong lệnh sản xuất";
                    else if(pbg008_1s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong kế hoạch đặt hàng";
                    else if(pbg009s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong lệnh đóng gói";
                    else if(pbg010s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong lệnh đóng gói";
                    else if(pbg011s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong xuất kế toán";
                    else if(pbg012s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong nhập kế toán";
                    else if(pbg013s > 0)
                        msg = "Lỗi:ĐVT đã được sử dụng trong xuất kho nội bộ";
                }

                if (msg.Length <= 0)
                {
                    VNN_Function.Write_log(context, ma_module, null, oper, "MĐVT:" + object_.ma_edi + ", TĐVT:" + object_.ten_dvt, db);
                    db.md_donvitinhsanpham.Remove(object_);
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
                msg = string.Format("true#{0}", "Xóa đơn vị tính thành công");
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