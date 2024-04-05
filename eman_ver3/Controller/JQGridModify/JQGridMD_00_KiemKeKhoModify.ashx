<%@ WebHandler Language="C#" Class="JQGridMD_00_KiemKeKhoModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using DataAcess;
using System.Collections.Generic;

public class JQGridMD_00_KiemKeKhoModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    public HelperEntity helperEntity = new HelperEntity();
    public User_TK userTK = null;
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
            case "CA_01_KiemKe":
                this.CA_01_KiemKe(context);
                break;
            case "CA_01_ExportBBKK":
                this.CA_01_ExportBBKK(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_KiemKe(HttpContext context)
    {
        string msg = "";
        string id = context.Request.Form["id"];
        string ngay_dichchuyen = context.Request.Form["ngay_dichchuyen"];
        var msgErrs = new List<Public.BaoLoiKhiHieuLuc>();
        try
        {
            var nkk = VNN_Config.setDateTime(ngay_dichchuyen);
            var kk = db.md_kiemke.Where(s => s.md_kiemke_id == id).FirstOrDefault();
            if (kk == null)
            {
                msg = $@"Không tìm thấy phiếu kiểm kê đã chọn";
                goto EndEventHandler;
            }
            if (kk.ma_kiemke != Helper.DANHAN)
            {
                msg = $@"Phiếu phải ở trạng thái ""Đã Xác Nhận""";
                goto EndEventHandler;
            }
            if (!nkk.IsDate())
            {
                msg = "Ngày kiểm kê có giá trị sai";
                goto EndEventHandler;
            }
            var cdhs = db.md_kiemke_cdh.Where(s => s.md_kiemke_id == kk.md_kiemke_id & s.sl_sosach != null).ToList();
            if (cdhs.Count <= 0)
            {
                msg = $@"Không có dòng hàng cần kiểm kê";
                goto EndEventHandler;
            }

            //var msgErrs = new lis
            foreach (var cdh in cdhs)
            {
                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).FirstOrDefault();

                var kho_hh = db.md_kho_sanpham.Where(s =>
                    s.md_kho_id == kk.md_kho_id
                    & s.md_sanpham_id == sp.md_sanpham_id
                    ).FirstOrDefault();

                var chophepNhap0 = kho_hh == null;

                if (!chophepNhap0)
                {
                    if (kho_hh.soluong.GetValueOrDefault(0) != cdh.sl_demduoc.GetValueOrDefault(0))
                    {
                        msg = $@"Hàng ""{sp.ma_sanpham}"" có số lượng trên máy khác với số lượng tồn kho hiện tại.";
                        msgErrs.Add(new Public.BaoLoiKhiHieuLuc()
                        {
                            msp = sp.ma_sanpham,
                            loi = $@"""SL trên máy"" khác ""SL trên máy thực tế"""
                        });
                    }
                    else
                    {
                        //Xuất SL hiện có
                        if (cdh.sl_demduoc.GetValueOrDefault(0) > 0)
                        {
                            helperEntity.obj = new HelperEntity.objLSNX();
                            helperEntity.obj.spId = cdh.md_sanpham_id;
                            helperEntity.obj.dvtSpId = sp.md_donvitinhsanpham_id;
                            helperEntity.obj.slDichChuyen = cdh.sl_demduoc.GetValueOrDefault(0);
                            helperEntity.obj.dongNhapXuat = kk.sochungtu;
                            helperEntity.obj.sctDonHang = "";
                            helperEntity.obj.giaTriVND = 0;
                            helperEntity.obj.khoId = kk.md_kho_id;
                            helperEntity.obj.kieuchuyen = helperEntity.kieuXuatKho;
                            helperEntity.obj.ngayChuyen = kk.ngay_kiemke;
                            helperEntity.obj.theoKg = false;
                            helperEntity.obj.laphieuKK = true;
                            helperEntity.themHoacSuaLichSuNhapXuatKho(db, userTK);
                            kho_hh.soluong = 0;
                        }
                    }
                }

                if (msg.Length <= 0)
                {
                    //Nhập SL thực tế
                    if (cdh.sl_sosach.GetValueOrDefault(0) > 0 | chophepNhap0)
                    {
                        helperEntity.obj = new HelperEntity.objLSNX()
                        {
                            spId = cdh.md_sanpham_id,
                            dvtSpId = sp.md_donvitinhsanpham_id,
                            slDichChuyen = cdh.sl_sosach.GetValueOrDefault(0),
                            dongNhapXuat = kk.sochungtu,
                            sctDonHang = "",
                            giaTriVND = 0,

                            khoId = kk.md_kho_id,
                            kieuchuyen = helperEntity.kieuNhapKho,
                            ngayChuyen = kk.ngay_kiemke,
                            theoKg = false,
                            laphieuKK = true
                        };
                        helperEntity.themHoacSuaLichSuNhapXuatKho(db, userTK);

                        if (chophepNhap0)
                        {
                            kho_hh = new md_kho_sanpham();
                            kho_hh.md_kho_sanpham_id = Helper.getNewId();
                            kho_hh.md_kho_id = kk.md_kho_id;
                            kho_hh.md_sanpham_id = sp.md_sanpham_id;
                            kho_hh.soluong = cdh.sl_sosach.GetValueOrDefault(0);
                            kho_hh = Helper.setDefaultValueWhenInsertOrUpdate(kho_hh, userTK, false);
                            db.md_kho_sanpham.Add(kho_hh);
                        }
                        else
                        {
                            kho_hh.soluong = cdh.sl_sosach.GetValueOrDefault(0);
                        }
                    }
                }
            }

            if (msg.Length <= 0 & msgErrs.Count <= 0)
            {
                kk.ma_kiemke = Helper.HIEULUC;
                kk.ngayhieuluc = DateTime.Now;
                kk.ngay_kiemke = nkk;
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

    EndEventHandler:;

        if (msg.Length <= 0 & msgErrs.Count <= 0)
        {
            msg = $@"<div style='color:blue'>Hiệu lực phiếu kiểm kê thành công</div>";
        }
        else
        {
            if (msgErrs.Count > 0)
                msg = $@"Thiếu thông tin";

            var result = new
            {
                msg = $@"<div error style='color:red'>{msg}</div>",
                json = msgErrs
            };

            msg = Newtonsoft.Json.JsonConvert.SerializeObject(result);
        }

        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));

        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string kho = context.Request.Form["md_kho_id"];
        string ngay_kiemke = context.Request.Form["ngay_kiemke"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "BBKK", 1);
        DateTime nkk = VNN_Config.setDateTime(ngay_kiemke);
        try
        {
            md_kiemke kk = db.md_kiemke.Where(s => s.ngay_kiemke > nkk & s.md_kho_id == kho).OrderByDescending(p => p.ngay_kiemke).FirstOrDefault();
            if (kk != null)
            {
                msg = "false#Lỗi:Ngày kiểm kê phải lớn hơn ngày \"" + kk.ngay_kiemke.Value.ToString("dd/MM/yyyy") + "\".";
            }
            kk = db.md_kiemke.Where(s => s.ngay_kiemke <= nkk & s.md_kho_id == kho & s.ma_kiemke == "X").OrderByDescending(p => p.ngay_kiemke).FirstOrDefault();
            if (kk != null)
            {
                msg = "false#Lỗi:Biên bản \"" + kk.ten_kiemke + "\" chưa thực thi.";
            }
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "ma_kiemke" };
                string ten_table = "md_kiemke";
                VNN_Function.SetFormValue("ma_kiemke", "X");
                VNN_Function.SetFormValue("sochungtu", sochungtu);
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);

                foreach (md_kho_sanpham kho_sp in db.md_kho_sanpham.Where(s => s.md_kho_id == kho))
                {
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == kho_sp.md_sanpham_id).FirstOrDefault();

                    md_kiemke_cdh kk_cdh = new md_kiemke_cdh();
                    kk_cdh.md_kiemke_cdh_id = Helper.getNewId();
                    kk_cdh.md_kiemke_id = id_new;
                    kk_cdh.md_sanpham_id = kho_sp.md_sanpham_id;
                    kk_cdh.ma_sanpham = sp.ma_sanpham;
                    kk_cdh.sl_demduoc = kho_sp.soluong;
                    kk_cdh.sl_sosach = kho_sp.soluong;
                    kk_cdh.mota_tiengviet = sp.mota_tiengviet;
                    kk_cdh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id;
                    kk_cdh.md_kho_id = kho;
                    kk_cdh.nguoitao = us.ad_user_id;
                    kk_cdh.vaitrotao = us.ad_role_id;
                    kk_cdh.bophantao = us.md_phongban_id;
                    kk_cdh.value_nguoitao = us.ma_user;
                    kk_cdh.value_vaitrotao = us.ten_role;
                    kk_cdh.value_bophantao = us.ten_phongban;
                    kk_cdh.nguoicapnhat = us.ad_user_id;
                    kk_cdh.vaitrocapnhat = us.ad_role_id;
                    kk_cdh.bophancapnhat = us.md_phongban_id;
                    kk_cdh.value_nguoicapnhat = us.ma_user;
                    kk_cdh.value_vaitrocapnhat = us.ten_role;
                    kk_cdh.value_bophancapnhat = us.ten_phongban;
                    kk_cdh.hoatdong = true;
                    kk_cdh.ngaytao = DateTime.Now;
                    kk_cdh.ngaycapnhat = DateTime.Now;
                    db.md_kiemke_cdh.Add(kk_cdh);
                }
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string kho = context.Request.Form["md_kho_id"];
        try
        {
            string id = context.Request.Form["id"];
            var ngay_kiemke = VNN_Config.setDateTime(context.Request.Form["ngay_kiemke"]);
            var object_ = db.md_kiemke.Where(p => p.md_kiemke_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.ma_kiemke == "HIEULUC")
            {
                msg = "false#Lỗi:Biên bản \"" + object_.ten_kiemke + "\" đã kiểm kê.";
            }
            else if (db.md_kho.Where(s => s.md_kho_id == kho).Count() <= 0)
            {
                msg = string.Format("false#Lỗi: Kho đang chọn không tồn tại.");
            }
            else if (ngay_kiemke.IsDate() == false)
            {
                msg = string.Format("false#Lỗi: Ngày kiểm kê không đúng định dạng.");
            }

            if (msg.Length <= 0)
            {
                object_.ngay_kiemke = ngay_kiemke;
                object_.mota = context.Request.Form["mota"];
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                db.SaveChanges();
                msg = "true#Cập nhật thành công.";
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string[] id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < id_del.Length; i++)
            {
                var id_del_ = id_del[i];
                var object_ = db.md_kiemke.Where(p => p.md_kiemke_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg += string.Format(@"Lỗi dòng {0}:Không tìm thấy đối tượng cần xóa<br>", i + 1);
                }
                else if (object_.ma_kiemke != Helper.DANHAN)
                {
                    msg += string.Format(@"Lỗi dòng {0}:""{1}"" đã hiệu lực<br>", i, object_.ten_kiemke);
                }
                else
                {
                    object_.ma_kiemke = Helper.SOANTHAO;
                }
            }

            if (msg.Length <= 0)
            {
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = @"true#Trả về trạng thái ""Soạn Thảo"" thành công.";
            }
            else
            {
                msg = "false#" + msg;
            }
        }
        catch (Exception ex)
        {
            msg = "false#Lỗi: " + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void CA_01_ExportBBKK(HttpContext context)
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