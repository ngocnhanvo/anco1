<%@ WebHandler Language="C#" Class="JQGridMD_01_DDSDHModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
using System.Collections.Generic;

public class JQGridMD_01_DDSDHModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    User_TK userTK = null;
    Public pub = new Public();

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
            case "selectBOM":
                this.selectBOM(context);
                break;

            default:
                break;
        }
    }

    public void selectBOM(HttpContext context)
    {
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "<select>";

        str += firstnull ? string.Format(@"<option px="""" value=""""></option>") : "";
        foreach (var cn in db.md_sanpham_bom.Where(s =>
            string.IsNullOrEmpty(s.md_phanxuong_id) & string.IsNullOrEmpty(s.md_to_id))
                .OrderBy(s => s.trangthai).ToList())
        {
            str += string.Format(@"<option sp=""{2}"" value=""{0}"">{1}</option>", cn.md_sanpham_bom_id, cn.ten_phienban, cn.md_sanpham_id);
        }
        str += "</select>";
        context.Response.Write(str);
    }

    public void add(HttpContext context)
    {
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        string ten_phienban = context.Request.Form["md_sanpham_bom_id"];
        int sl_dathang = int.Parse(context.Request.Form["sl_dathang"]);

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                decimal cbm = decimal.Parse(context.Request.Form["v2"]);

                string id = context.Request.Form["id_parent"];
                var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
                int ddsdh = db.c_dongdsdh.Where(s => s.md_sanpham_id == sp.md_sanpham_id & s.c_danhsachdathang_id == id).Count();
                var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == id).FirstOrDefault();
                var bom_sp = db.md_sanpham_bom.Where(s => s.md_sanpham_id == sp.md_sanpham_id & s.ten_phienban == ten_phienban).FirstOrDefault();

                if (dsdh.trangthai == "HIEULUC")
                {
                    msg = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã ""Hiệu lực"".", dsdh.sochungtu);
                }
                else if (dsdh.trangthai == "HUYBO")
                {
                    msg = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã ""Hủy"".", dsdh.sochungtu);
                }
                else if (dsdh.trangthai == "KETTHUC")
                {
                    msg = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã ""Kết thúc"".", dsdh.sochungtu);
                }
                else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count() > 0)
                {
                    msg = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã tạo phiếu giảm hạn ngạch.", dsdh.sochungtu);
                }
                else if (ddsdh > 0)
                {
                    msg = "Lỗi:Sản phẩm đã tồn tại.";
                }
                else if (sl_dathang <= 0)
                {
                    msg = "Lỗi:Số lượng đặt hàng phải lớn hơn 0";
                }
                else if (cbm <= 0)
                {
                    msg = "Lỗi:CBM phải lớn hơn 0";
                }
                else if (bom_sp == null)
                {
                    var bom = pub.getBOMHieuLuc(sp.md_sanpham_id, db);
                    if (string.IsNullOrEmpty(bom))
                        msg = string.Format(@"HHVT {0} không có BOM", sp.ma_sanpham);
                    else
                        ten_phienban = bom;
                }

                if (msg.Length <= 0)
                {
                    //var strGN = string.Format(@"select isnull([dbo].[GET_GiaBanSP](N'{0}', N'{1}'),0)", sp.ma_sanpham, dsdh.khachhang);
                    var gianhap = pub.getGiaBanSP(sp.md_sanpham_id, dsdh.khachhang, db);

                    var object_ = new c_dongdsdh();
                    object_.c_dongdsdh_id = id_new;
                    object_.c_danhsachdathang_id = id;
                    VNN_Function.SetFormValue(object_.nameof(s=>s.sl_conlai), sl_dathang.ToString());
                    VNN_Function.SetFormValue(object_.nameof(s=>s.gianhap), gianhap.ToString());
                    VNN_Function.SetFormValue(object_.nameof(s=>s.sl_dagiao), "0");
                    VNN_Function.SetFormValue(object_.nameof(s=>s.sl_hanngach), "0");
                    VNN_Function.SetFormValue(object_.nameof(s=>s.sl_giamhanngach), "0");
                    VNN_Function.SetFormValue(object_.nameof(s=>s.md_sanpham_id), sp.md_sanpham_id);
                    VNN_Function.SetFormValue(object_.nameof(s=>s.md_sanpham_bom_id), bom_sp == null ? ten_phienban : bom_sp.md_sanpham_bom_id);
                    object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                    object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    db.c_dongdsdh.Add(object_);
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
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        string ten_phienban = context.Request.Form["md_sanpham_bom_id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                int sl_dathang = int.Parse(context.Request.Form["sl_dathang"]);
                decimal gianhap = decimal.Parse(context.Request.Form["gianhap"]);
                decimal cbm = decimal.Parse(context.Request.Form["v2"]);
                string id = context.Request.Form["id"];
                string id_parent = context.Request.Form["id_parent"];
                var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
                var object_ = db.c_dongdsdh.Where(p => p.c_dongdsdh_id == id).FirstOrDefault();
                var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == id_parent).FirstOrDefault();
                var bom_sp = db.md_sanpham_bom.Where(s =>
                    s.md_sanpham_id == sp.md_sanpham_id &
                    s.ten_phienban == ten_phienban &
                    string.IsNullOrEmpty(s.md_phanxuong_id) &
                    string.IsNullOrEmpty(s.md_to_id)).FirstOrDefault();

                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if (dsdh.trangthai == "HIEULUC")
                {
                    msg = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã ""Hiệu lực"".", dsdh.sochungtu);
                }
                else if (dsdh.trangthai == "HUYBO")
                {
                    msg = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã ""Hủy"".", dsdh.sochungtu);
                }
                else if (dsdh.trangthai == "KETTHUC")
                {
                    msg = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã ""Kết thúc"".", dsdh.sochungtu);
                }
                else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count() > 0)
                {
                    msg = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã tạo phiếu giảm hạn ngạch.", dsdh.sochungtu);
                }
                else if (sl_dathang <= 0)
                {
                    msg = "Lỗi:Số lượng đặt hàng phải lớn hơn 0";
                }
                else if (cbm <= 0)
                {
                    msg = "Lỗi:CBM phải lớn hơn 0";
                }
                else if (bom_sp == null)
                {
                    msg = string.Format(@"HHVT {0} không có BOM", sp.ma_sanpham);
                }

                if (msg.Length <= 0)
                {
                    VNN_Function.SetFormValue(object_.nameof(s => s.sl_conlai), sl_dathang.ToString());
                    VNN_Function.SetFormValue(object_.nameof(s => s.gianhap), gianhap.ToString());
                    VNN_Function.SetFormValue(object_.nameof(s => s.sl_dagiao), "0");
                    VNN_Function.SetFormValue(object_.nameof(s => s.md_sanpham_id), sp.md_sanpham_id);
                    VNN_Function.SetFormValue(object_.nameof(s => s.md_sanpham_bom_id), bom_sp.md_sanpham_bom_id);
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
                var ids = context.Request.Form["id"].Split(',').Where(s=>!string.IsNullOrWhiteSpace(s)).ToList();

                foreach (var id_del_ in ids)
                {
                    var object_ = db.c_dongdsdh.Where(p => p.c_dongdsdh_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else
                    {
                        var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).FirstOrDefault();
                        if (dsdh.trangthai == "HIEULUC")
                        {
                            msg += string.Format(@"<br><b>{0}</b>: Đã ""Hiệu lực"".", dsdh.sochungtu);
                        }
                        else if (dsdh.trangthai == "HUYBO")
                        {
                            msg += string.Format(@"<br><b>{0}</b>: Đã ""Hủy"".", dsdh.sochungtu);
                        }
                        else if (dsdh.trangthai == "KETTHUC")
                        {
                            msg += string.Format(@"<br><b>{0}</b>: Đã ""Kết thúc"".", dsdh.sochungtu);
                        }
                        else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Count() > 0)
                        {
                            msg += string.Format(@"<br><b>{0}</b>: Đã tạo phiếu giảm hạn ngạch.", dsdh.sochungtu);
                        }
                        else
                        {
                            db.c_dongdsdh.Remove(object_);
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