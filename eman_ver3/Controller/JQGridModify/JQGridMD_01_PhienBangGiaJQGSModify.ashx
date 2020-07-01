<%@ WebHandler Language="C#" Class="JQGridMD_01_PhienBangGiaJQGSModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.IO;
public class JQGridMD_01_PhienBangGiaJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_ExportPBanGia":
                this.CA_01_ExportPBanGia(context);
                break;
            case "select_phienbangia":
                this.select_phienbangia(context);
                break;
            case "CA_01_CapNhatLaiGSP":
                this.CA_01_CapNhatLaiGSP(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_CapNhatLaiGSP(HttpContext context)
    {
        var db = new EntityContext();
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                var pbg = db.md_phienbangia.Where(s => s.md_phienbangia_id == id).FirstOrDefault();
                if (pbg == null)
                    msg = "Không tìm thấy phiên bản giá";
                else if (pbg.hoatdong == false)
                    msg = "Phiên bản giá không hoạt động";
                else if (
                    db.md_banggia.Where(s =>
                        s.md_banggia_id == pbg.md_banggia_id
                        & s.tuychon == "NHANCONG"
                        & !string.IsNullOrEmpty(s.md_to_id)).Count() <= 0)
                    msg = "Phiên bản giá không thuộc bảng giá nhân công";
                else
                {
                    var ngaygoihan = DateTime.Now.AddDays(-120);
                    var xnbIds = db.md_xuatkhonb
                            .Where(s => s.phienbangiaNC == id & s.ngaytao >= ngaygoihan)
                            .Select(s => s.md_xuatkhonb_id).ToList();
                    foreach (var cdh in db.md_xuatkhonb_cdh.Where(s =>
                        xnbIds.Contains(s.md_xuatkhonb_id)
                        & db.c_danhsachdathang.Where(t => t.so_po == s.tenhang & t.trangthai != "KETTHUC").Count() > 0
                    ).ToList())
                    {
                        var gsp = db.md_giasanpham
                                .Where(s =>
                                    s.md_phienbangia_id == id
                                    & s.md_sanpham_id == cdh.md_sanpham_id
                                    & s.md_donvitinhsanpham_id == cdh.md_donvitinhsanpham_id
                                    & s.gia != cdh.gianhancong)
                                .FirstOrDefault();

                        if (gsp != null)
                        {
                            cdh.gianhancong = gsp.gia.GetValueOrDefault(0);
                            var lsx = db.md_lenhsanxuat.Where(s => cdh.lsx_to.StartsWith(s.sochungtu)).FirstOrDefault();
                            if (lsx != null)
                            {
                                var tsx = db.md_lenhsanxuat_tosx.Where(s =>
                                    s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                                    & s.md_phanxuong_to_id == cdh.tuto).FirstOrDefault();
                                if (tsx != null)
                                {
                                    var cdhLSX = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                        s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                        & s.md_sanpham_id == cdh.md_sanpham_id
                                    ).FirstOrDefault();
                                    if (cdhLSX != null)
                                        cdhLSX.gianhancong = cdh.gianhancong;
                                }
                            }
                        }
                    }

                    var vcnbIds = db.md_vanchuyennoibo
                            .Where(s => s.phienbangiaNC == id & s.ngaytao >= ngaygoihan)
                            .Select(s => s.md_vanchuyennoibo_id).ToList();
                    foreach (var cdh in db.md_vanchuyennoibo_cdvc.Where(s =>
                        vcnbIds.Contains(s.md_vanchuyennoibo_id)
                    ).ToList())
                    {
                        var gsp = db.md_giasanpham
                                .Where(s =>
                                    s.md_phienbangia_id == id
                                    & s.md_sanpham_id == cdh.md_sanpham_id
                                    & s.md_donvitinhsanpham_id == cdh.md_donvitinhsanpham_id
                                    & s.gia != cdh.gianhancong)
                                .FirstOrDefault();

                        if (gsp != null)
                        {
                            cdh.gianhancong = gsp.gia.GetValueOrDefault(0);
                        }
                    }
					
					foreach (var cdh in db.md_vanchuyennoibo_dalayton.Where(s =>
                        vcnbIds.Contains(s.md_vanchuyennoibo_id)
                    ).ToList())
                    {
                        var gsp = db.md_giasanpham
                                .Where(s =>
                                    s.md_phienbangia_id == id
                                    & s.md_sanpham_id == cdh.md_sanpham_id
                                    & s.md_donvitinhsanpham_id == cdh.md_donvitinhsanpham_id
                                    & s.gia != cdh.gianhancong)
                                .FirstOrDefault();

                        if (gsp != null)
                        {
                            cdh.gianhancong = gsp.gia.GetValueOrDefault(0);
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex + "";
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"<div style='color:blue'>Cập nhật giá cho phiếu XK thành công</div>");
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"<div style='color:red' class='error'>Lỗi {0}</div>", msg);
                transaction.Rollback();
            }
        }

        context.Response.Write(msg);
    }

    public void select_phienbangia(HttpContext context)
    {
        var db = new EntityContext();
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "";
        string id = context.Request.QueryString["id"];
        str += firstnull ? string.Format("<option value=\"\"></option>") : "";
        var lstPBG = new List<string>();
        foreach (md_phienbangia object_ in db.md_phienbangia.OrderByDescending(s => s.ngay_hieuluc))
        {
            //if (!lstPBG.Contains(object_.md_banggia_id))
            {
                if (object_.hoatdong == true)
                {
                    str += string.Format("<option bg='{2}' value='{0}'>{1}</option>", object_.md_phienbangia_id, object_.ten_phienbangia, object_.md_banggia_id);
                    lstPBG.Add(object_.md_banggia_id);
                }
                else
                    str += string.Format("<option bg='{2}' class='notsel_option' value='{0}'>{1}</option>", object_.md_phienbangia_id, object_.ten_phienbangia, object_.md_banggia_id);
            }
        }
        context.Response.Write("<select>" + str + "</select>");
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_trangthai_id = context.Request.Form["md_trangthai_id"];
        try
        {
            string id = context.Request.Form["id_parent"];
            string ten_pbg = context.Request.Form["ten_phienbangia"];

            if (db.md_phienbangia.Where(s => s.ten_phienbangia == ten_pbg).Count() > 0)
            {
                msg = "false#Lỗi: đã tồn tại phiên bản giá \"" + ten_pbg + "\"";
            }

            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "md_banggia_id" };
                string ten_table = "md_phienbangia";
                VNN_Function.SetFormValue("md_banggia_id", id);
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;
                /*db = new EntityContext();
				if(md_trangthai_id == "HIEULUC"){
					foreach(md_phienbangia pbg in db.md_phienbangia.Where(
					s=>s.md_phienbangia_id != id_new & s.md_trangthai_id == "HIEULUC" & s.md_banggia_id == id)){
						pbg.md_trangthai_id = "SOANTHAO";
					}
				}
				db.SaveChanges();*/
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
        string ma_module = context.Request.QueryString["ma_module"];
        string md_trangthai_id = context.Request.Form["md_trangthai_id"];
        try
        {
            string id = context.Request.Form["id"];
            string ten_pbg = context.Request.Form["ten_phienbangia"];


            md_phienbangia object_ = db.md_phienbangia.Where(p => p.md_phienbangia_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (db.md_phienbangia.Where(s => s.ten_phienbangia == ten_pbg).Count() > 0 & object_.ten_phienbangia != ten_pbg)
            {
                msg = "false#Lỗi: đã tồn tại phiên bản giá \"" + ten_pbg + "\"";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_phienbangia";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";
                /*db = new EntityContext();
				if(md_trangthai_id == "HIEULUC"){
					foreach(md_phienbangia pbg in db.md_phienbangia.Where(
					s=>s.md_phienbangia_id != object_.md_phienbangia_id & s.md_trangthai_id == "HIEULUC" & s.md_banggia_id == object_.md_banggia_id)){
						pbg.md_trangthai_id = "SOANTHAO";
					}
				}
				db.SaveChanges();*/
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
            string ten_table = "md_phienbangia";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            string id = "";
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_phienbangia object_ = db.md_phienbangia.Where(p => p.md_phienbangia_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    id = object_.md_banggia_id;
                    db.md_phienbangia.Remove(object_);
                }
            }
            if (msg.Length <= 0)
            {
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Xóa thành công.";
                var pbgs = db.md_phienbangia.Where(s => s.md_banggia_id == id);
                foreach (md_phienbangia pbg in pbgs)
                {
                    pbg.md_trangthai_id = "SOANTHAO";
                }
                md_phienbangia pbg_edit = pbgs.OrderByDescending(s => s.ngay_hieuluc).Take(1).FirstOrDefault();
                if (pbg_edit != null)
                    pbg_edit.md_trangthai_id = "HIEULUC";

                db.SaveChanges();
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

    public void CA_01_ExportPBanGia(HttpContext context)
    {

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
