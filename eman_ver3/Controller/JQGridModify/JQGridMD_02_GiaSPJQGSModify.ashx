<%@ WebHandler Language="C#" Class="JQGridMD_02_GiaSanPhamModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_GiaSanPhamModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest(HttpContext context)
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
                string bangGiaID = "";
                string id = context.Request.Form["id_parent"];
                string ma_sanpham = context.Request.Form["md_sanpham_id"];
                string donvitinh = context.Request.Form["md_donvitinhsanpham_id"];
                var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Take(1).FirstOrDefault();

                if (sp == null)
                {
                    msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" không tồn tại.";
                }
                else
                {
                    var pbg = db.md_phienbangia.Where(s => s.md_phienbangia_id == id).FirstOrDefault();
                    if (pbg == null)
                        msg = "false#Lỗi: Phiên bản giá không tồn tại.";
                    else
                    {
                        bangGiaID = pbg.md_banggia_id;
                        string chk_sp = db.md_giasanpham.
                                Where(s => s.md_sanpham_id == sp.md_sanpham_id &
                                s.md_phienbangia_id == id &
                                s.md_donvitinhsanpham_id == donvitinh
                                ).Select(s => s.md_sanpham_id).Take(1).FirstOrDefault();
                        if (chk_sp != null & chk_sp != "")
                        {
                            msg = "false#Lỗi: Mã \"" + ma_sanpham + "\" với đơn vị tính đã tồn tại.";
                        }
                    }
                }

                if (msg.Length <= 0)
                {
                    var gsp = new md_giasanpham();
                    gsp.md_giasanpham_id = id_new;
                    gsp.md_banggia_id = bangGiaID;
                    gsp.md_phienbangia_id = id;
                    gsp.md_sanpham_id = sp.md_sanpham_id;
                    gsp.gia = decimal.Parse(context.Request.Form["gia"]);
                    gsp.md_donvitinhsanpham_id = context.Request.Form["md_donvitinhsanpham_id"];
                    gsp.ngaytao = DateTime.Now;
                    gsp.ngaycapnhat = DateTime.Now;
                    gsp.nguoitao = Security.id_taikhoan(context);
                    gsp.nguoicapnhat = gsp.nguoitao;
                    gsp.mota = context.Request.Form["mota"];
                    gsp.hoatdong = true;
                    db.md_giasanpham.Add(gsp);
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
                string ma_sanpham = context.Request.Form["md_sanpham_id"];
                string donvitinh = context.Request.Form["md_donvitinhsanpham_id"];
                var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Take(1).FirstOrDefault();
                var object_ = db.md_giasanpham.Where(p => p.md_giasanpham_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if (sp == null)
                {
                    msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" không tồn tại.";
                }
                else
                {
                    string chk_sp = db.md_giasanpham.
                            Where(s =>
                            s.md_sanpham_id == sp.md_sanpham_id &
                            s.md_phienbangia_id == id &
                            s.md_donvitinhsanpham_id == donvitinh &
                            s.md_sanpham_id != object_.md_sanpham_id)
                            .Select(s => s.md_sanpham_id).Take(1).FirstOrDefault();
                    if (chk_sp != null & chk_sp != "")
                    {
                        msg = "false#Lỗi: Mã \"" + ma_sanpham + "\" với đơn vị tính đã tồn tại.";
                    }
                }

                if (msg.Length <= 0)
                {
                    var giaChoDuyet = context.Request.Form["giachoduyet"].ToNullableDecimal();
                    if(giaChoDuyet != null)
                    {
                        var sxss = db.md_giasanpham_giaodich.Where(s => s.md_phienbangia_id == object_.md_phienbangia_id & s.sapxepso != null).ToList();
                        int? sapxepsoMax = null;
                        if(sxss.Count > 0)
                            sapxepsoMax = sxss.Max(s => s.sapxepso.GetValueOrDefault(0));

                        var gd = db.md_giasanpham_giaodich.Where(s => s.md_giasanpham_id == object_.md_giasanpham_id & s.trangthai == Helper.CHODUYET).FirstOrDefault();
                        var add = gd == null;
                        if(add)
                        {
                            gd = new md_giasanpham_giaodich();
                            gd.md_giasanpham_giaodich_id = Helper.getNewId();
                            gd.md_giasanpham_id = object_.md_giasanpham_id;
                            gd.md_banggia_id = object_.md_banggia_id;
                            gd.md_phienbangia_id = object_.md_phienbangia_id;
                            gd.md_donvitinhsanpham_id = object_.md_donvitinhsanpham_id;
                            gd.md_sanpham_id = object_.md_sanpham_id;
                            gd.trangthai = Helper.CHODUYET;
                            gd.ngaydenghi = DateTime.Now;
                            gd.hoatdong = true;
                        }
                        gd.sapxepso = sapxepsoMax.GetValueOrDefault(0) + 1;
                        gd.giacu = object_.gia;
                        gd.giamoi = giaChoDuyet;
                        gd = Helper.setDefaultValueWhenInsertOrUpdate(gd, userTK, !add);

                        if(add)
                        {
                            db.md_giasanpham_giaodich.Add(gd);
                        }

                        var gdlqs = db.md_giasanpham_giaodich.Where(s => s.md_phienbangia_id == object_.md_phienbangia_id & s.md_sanpham_id == object_.md_sanpham_id).ToList();
                        foreach(var gdlq in gdlqs)
                        {
                            gdlq.sapxepso = gd.sapxepso;
                        }
                    }

                    VNN_Function.SetFormValue(object_.nameof(s => s.md_sanpham_id), Helper.VNN_notpost);
                    VNN_Function.SetFormValue(object_.nameof(s => s.md_banggia_id), Helper.VNN_notpost);
                    VNN_Function.SetFormValue(object_.nameof(s => s.md_phienbangia_id), Helper.VNN_notpost);
                    VNN_Function.SetFormValue(object_.nameof(s => s.md_donvitinhsanpham_id), Helper.VNN_notpost);
                    VNN_Function.SetFormValue(object_.nameof(s => s.gia), Helper.VNN_notpost);
                    object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
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

                var object_ = db.md_giasanpham.Where(p => p.md_giasanpham_id == id_del).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần xóa";
                }
                else
                {
                    var pbg001s = db.md_vanchuyennoibo.Where(s => s.phienbangiaNC == object_.md_phienbangia_id).Take(1).Count();
                    var pbg002s = db.md_xuatkhonb.Where(s => s.phienbangiaNC == object_.md_phienbangia_id).Take(1).Count();
                    var pbg003s = db.c_donmuahang.Where(s => s.md_phienbangia_id == object_.md_phienbangia_id).Take(1).Count();
                    if(pbg001s > 0)
                        msg = "Lỗi:Phiên bảng giá đã được áp dụng cho phiếu chuyển kho";
                    else if(pbg002s > 0)
                        msg = "Lỗi:Phiên bảng giá đã được áp dụng cho phiếu xuất kho nội bộ";
                    else if(pbg003s > 0)
                        msg = "Lỗi:Phiên bảng giá đã được áp dụng cho đơn mua hàng hóa vật tư";
                }

                if (msg.Length <= 0)
                {
                    foreach(var gd in db.md_giasanpham_giaodich.Where(s=>
                        s.md_giasanpham_id == object_.md_giasanpham_id
                        & s.trangthai == Helper.CHODUYET).ToList())
                    {
                        db.md_giasanpham_giaodich.Remove(gd);
                    }
                    var pbg = db.md_phienbangia.Where(s => s.md_phienbangia_id == object_.md_phienbangia_id).Select(s=>s.ten_phienbangia).FirstOrDefault();
                    var sp = db.md_sanpham.Where(s => s.md_sanpham_id == object_.md_sanpham_id).Select(s=>s.ma_sanpham).FirstOrDefault();
                    VNN_Function.Write_log(context, ma_module, null, oper, "PBG:" + pbg + ", MSP:" + sp, db);
                    db.md_giasanpham.Remove(object_);
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
                msg = string.Format("true#{0}", "Xóa giá sản phẩm thành công");
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
