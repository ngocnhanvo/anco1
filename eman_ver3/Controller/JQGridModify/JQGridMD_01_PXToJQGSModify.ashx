<%@ WebHandler Language="C#" Class="JQGridMD_01_PXToModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_PXToModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest (HttpContext context)
    {
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
            case "CA_01_CapNhatTenToSXMoi":
                this.CA_01_CapNhatTenToSXMoi(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_CapNhatTenToSXMoi(HttpContext context)
    {
        string msg = "", msgSuccess = "";
        string tenToSXCu = context.Request.Form["tenToSXCu"];
        string id = context.Request.Form["id"];
        int demNKNB = 0, demXKNB = 0, demCKNB = 0;
        md_phanxuong_to tosx = null;
        try
        {
            tenToSXCu = tenToSXCu.Trim();
            tosx = db.md_phanxuong_to.Where(s => s.md_to_id == id).FirstOrDefault();
            if(tosx == null)
            {
                msg = @"Không tìm thấy ""Tổ sản xuất"" đã chọn.";
            }
            else if(tenToSXCu.Replace(" ","").Length < 2)
            {
                msg = @"Tên ""Tổ sản xuất cũ"" phải có ít nhất 2 kí tự trở lên (không tính khoảng trắng).";
            }
            else if(tenToSXCu == tosx.ten_to)
            {
                msg = @"Tên ""Tổ sản xuất cũ"" phải khác tên ""Tổ sản xuất hiện tại"".";
            }
            else
            {
                var biDanh_tenToSXCu = "--- " + tenToSXCu;
                //Nhập kho nội bộ
                var nknbDHs = db.md_nhapkhonb_cdh.Where(s => s.lsx_to.EndsWith(biDanh_tenToSXCu) & s.lsx_to.Length > 16).ToList();
                foreach (var dh in nknbDHs)
                {
                    dh.lsx_to = dh.lsx_to.Replace(tenToSXCu, tosx.ten_to);
                    demNKNB++;
                }
                //Xuất kho nội bộ
                var xknbDHs = db.md_xuatkhonb_cdh.Where(s => s.lsx_to.EndsWith(biDanh_tenToSXCu) & s.lsx_to.Length > 16).ToList();
                foreach (var dh in xknbDHs)
                {
                    dh.lsx_to = dh.lsx_to.Replace(tenToSXCu, tosx.ten_to);
                    demXKNB++;
                }
                //Chuyển kho nội bộ
                var vcnbDHs = db.md_vanchuyennoibo_cdvc.Where(s => s.lsx_to.EndsWith(biDanh_tenToSXCu) & s.lsx_to.Length > 16).ToList();
                foreach(var dh in vcnbDHs)
                {
                    dh.lsx_to = dh.lsx_to.Replace(tenToSXCu, tosx.ten_to);
                    demCKNB++;
                }
            }
        }
        catch(Exception ex)
        {
            msg = ex.Message;
        }

        if(msg.Length <= 0)
        {
            if (demNKNB > 0)
                msgSuccess += string.Format(@"<br>--> {0} dòng hàng trong module nhập kho nội bộ", demNKNB);
            if (demXKNB > 0)
                msgSuccess += string.Format(@"<br>--> {0} dòng hàng trong module xuất kho nội bộ", demXKNB);
            if (demCKNB > 0)
                msgSuccess += string.Format(@"<br>--> {0} dòng hàng trong module chuyển kho nội bộ", demCKNB);

            if (msgSuccess.Length > 0)
            {
                tosx.ten_to_cu = tosx.ten_to;
                db.SaveChanges();
                msg = string.Format(@"<div style='color:blue'>Cập nhật tên tổ thành công.{0}</div>", msgSuccess);
            }
            else
            {
                msg = string.Format(@"<div style='color:black'>Không có dòng hàng nào được cập nhật.</div>");
            }
        }
        else
        {
            msg = string.Format(@"<div style='color:red'>{0}</div>", msg);
        }

        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        string msg = "",id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id_parent = context.Request.Form["id_parent"];
            string sapxep = VNN_Config.load_number(context.Request.Form["sapxep"], 10);
            string cdoan = context.Request.Form["ten_to"];
            string xuong = context.Request.Form["xuong"];
            var congdoan = db.ad_department.Where(s => s.md_phongban_id == cdoan).FirstOrDefault();
            var phanxuong = db.ad_department.Where(s => s.md_phongban_id == xuong).FirstOrDefault();
            if(congdoan == null)
            {
                msg = "Không tìm thấy công đoạn";
            }
            else if(xuong == null)
            {
                msg = "Không tìm thấy phân xưởng";
            }
            else
            {
                var pxin = db.md_phanxuong_to.Where(s => s.md_phanxuong_id == id_parent & s.phongbanId == congdoan.md_phongban_id).FirstOrDefault();
                if (pxin != null)
                    msg = "Đã tồn tại công đoạn này trong quy trình";
            }

            if (msg.Length <= 0)
            {
                var object_ = new md_phanxuong_to();
                object_.md_to_id = id_new;
                object_.md_phanxuong_id = id_parent;
                VNN_Function.SetFormValue(object_.nameof(s => s.sapxep), sapxep);
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                object_.ma_to = congdoan.ma_phongban;
                object_.ten_to = congdoan.ten_phongban;
                object_.phongbanId = congdoan.md_phongban_id;
                object_.phongbanId2 = phanxuong.md_phongban_id;
                db.md_phanxuong_to.Add(object_);
                db.SaveChanges();

                VNN_Function.SortColumn("md_phanxuong_to", sapxep, "md_phanxuong_id", id_parent, "ma_to", object_.ma_to, null);
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            string sapxep = VNN_Config.load_number(context.Request.Form["sapxep"], 10);

            string cdoan = context.Request.Form["ten_to"];
            string xuong = context.Request.Form["xuong"];
            var congdoan = db.ad_department.Where(s => s.md_phongban_id == cdoan).FirstOrDefault();
            var phanxuong = db.ad_department.Where(s => s.md_phongban_id == xuong).FirstOrDefault();
                
            var object_ = db.md_phanxuong_to.Where(p => p.md_to_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "Không tìm thấy đối tượng cần sửa ";
            }
            else if(congdoan == null)
            {
                msg = "Không tìm thấy công đoạn";
            }
            else if(xuong == null)
            {
                msg = "Không tìm thấy phân xưởng";
            }
            else
            {
                var pxin = db.md_phanxuong_to.Where(s => s.md_phanxuong_id == object_.md_phanxuong_id & s.phongbanId == congdoan.md_phongban_id & s.md_to_id != object_.md_to_id).FirstOrDefault();
                if (pxin != null)
                    msg = "Đã tồn tại công đoạn này trong quy trình";
            }

            if (msg.Length <= 0)
            {
                VNN_Function.SetFormValue(object_.nameof(s => s.sapxep), sapxep);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                object_.ma_to = congdoan.ma_phongban;
                object_.ten_to = congdoan.ten_phongban;
                object_.phongbanId = congdoan.md_phongban_id;
                object_.phongbanId2 = phanxuong.md_phongban_id;
                db.SaveChanges();

                VNN_Function.SortColumn("md_phanxuong_to", sapxep, "md_phanxuong_id", object_.md_phanxuong_id, "ma_to", object_.ma_to, null);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "Cập nhật thành công.";
            }
        }
        catch(Exception ex)
        {
            msg = ex.Message;
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