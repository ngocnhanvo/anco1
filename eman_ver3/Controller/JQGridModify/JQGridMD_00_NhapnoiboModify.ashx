<%@ WebHandler Language="C#" Class="JQGridMD_00_NhapnoiboModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_NhapnoiboModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_XacNhanPNKNB":
                this.CA_01_XacNhanPNKNB(context);
                break;
            case "CA_01_NhapKho":
                this.CA_01_NhapKho(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_XacNhanPNKNB(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        var pub = new Public();
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            foreach (var nknb in db.md_nhapkhonb.Where(s => vnn.Contains(s.md_nhapkhonb_id)).ToList())
            {
                if (nknb.trangthai != "SOANTHAO")
                    msg = string.Format(@"Lỗi: phiếu ""{0}"" đã được xác nhận.", nknb.sochungtu);
                else
                {
                    if (nknb.bosung == 0)
                    {
                        if (string.IsNullOrEmpty(nknb.chungtu_lenhsx))
                            msg = string.Format(@"Lỗi: phiếu ""{0}"" chưa chọn lệnh sản xuất.", nknb.sochungtu);
                        else if (string.IsNullOrEmpty(nknb.md_lenhsanxuat_tosx_id))
                            msg = string.Format(@"Lỗi: phiếu ""{0}"" chưa chọn tổ sản xuất.", nknb.sochungtu);
                    }

                    if (msg.Length <= 0)
                        nknb.trangthai = "DANHAN";
                }
                db.SaveChanges();
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"<div class='nhan-thanhcong'>Xác nhận phiếu nhập kho thành công.</div>");
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"<div style='color:red'>Lỗi: {0}</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_NhapKho(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNKNB", 1);
        int count_slnhap = 0;
        using (var transaction = db.Database.BeginTransaction())
        {
            bool commit = true;
            try
            {
                //Xu Ly nhap kho
                foreach (var nk in db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id == id).ToList())
                {
                    var md_nhapkhonb_cdhs = (from a in db.md_nhapkhonb_cdh
                                             join d in db.md_sanpham on a.md_sanpham_id equals d.md_sanpham_id
                                             where a.md_nhapkhonb_id == nk.md_nhapkhonb_id
                                             select new { a.md_nhapkhonb_cdh_id, d.ma_sanpham, d.md_sanpham_id, a.sl_nhap })
                                                 .Select(s => new NNNB()
                                                 {
                                                     md_nhapkhonb_cdh_id = s.md_nhapkhonb_cdh_id,
                                                     ma_sanpham = s.ma_sanpham,
                                                     md_sanpham_id = s.md_sanpham_id,
                                                     sl_nhap = s.sl_nhap
                                                 }).ToList();

                    if (nk.trangthai == "HIEULUC")
                    {
                        msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" đã hiệu lực.</div>", nk.sochungtu);
                        break;
                    }
                    else if (nk.trangthai != "DANHAN")
                    {
                        msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" cần ở trạng thái ""Đã Xác Nhận"".</div>", nk.sochungtu);
                    }
                    else
                    {
                        foreach (var dh1 in md_nhapkhonb_cdhs.OrderBy(s => s.ma_sanpham).ToList())
                        {
                            var dh = db.md_nhapkhonb_cdh.FirstOrDefault(s => s.md_nhapkhonb_cdh_id == dh1.md_nhapkhonb_cdh_id);
                            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                            /// phan khac
                            decimal nhanvoi = 1;
                            if (string.IsNullOrEmpty(nk.denkho))
                            {
                                msg += string.Format(@"
                                <div style='color:red'>
                                    Lỗi: dòng ""{0}"" chưa có kho hoặc phân xưởng đến.
                                </div>", nk.sochungtu);
                            }
                            else if (dh.sl_nhap < 0)
                            {
                                msg += string.Format(@"
                                <div style='color:red'>
                                    Lỗi: ""{0}"" Số lượng nhập phải lớn hơn 0.
                                </div>", sp.ma_sanpham);
                            }

                            if (msg.Length <= 0 & dh.sl_nhap > 0)
                            {
                                var lsxTSX = Extension.getLSXToId(dh.lsx_to, db);
                                count_slnhap = 1;
                                decimal sl_nhap = dh.sl_nhap.Value;
                                //--cap nhat so luong xuat
                                edit_nhap(db, dh, us);
                                db.SaveChanges();
                                //--cap nhat vao kho
                                string khospId = nhap_kho(db, dh, nk, nhanvoi, us);
                                db.SaveChanges();
                                //--cap nhat vao kho hạn sử dụng
                                msg += add_kho_hsd(db, dh, nk, us, khospId);
                                db.SaveChanges();
                                //--tao lich su nhap kho
                                add_kho_ls(db, dh, nk, nhanvoi, us, lsxTSX);
                                db.SaveChanges();
                                //--cap nhat lenh san xuat
                                decimal sl_nhap_cuoi = sl_nhap * nhanvoi;
                                decimal sl_nhap_cuoi2 = sl_nhap_cuoi;
                                if (sl_nhap > 0)
                                {
                                    foreach (var lsx_to_cdh in db.md_lenhsanxuat_tosx_cdh.
                                            Where(s =>
                                            s.md_sanpham_id == sp.md_sanpham_id &
                                            s.md_lenhsanxuat_tosx_id == lsxTSX.md_lenhsanxuat_tosx_id).ToList())
                                    {
                                        sl_nhap = sl_nhap_cuoi2;
                                        var sltd = lsx_to_cdh.sl_chiato.GetValueOrDefault(0) - lsx_to_cdh.sl_dahoanthanh.GetValueOrDefault(0);
                                        if (sl_nhap_cuoi2 > sltd)
                                        {
                                            sl_nhap_cuoi2 = sl_nhap_cuoi2 - sltd;
                                            sl_nhap = sltd;
                                        }

                                        lsx_to_cdh.sl_dahoanthanh += sl_nhap;
                                        //lsx_to_cdh.sl_nhapkho = 0;
                                    }

                                    var ck_dh = db.md_nhapkhonb_cdh.Where(s =>
                                        s.md_nhapkhonb_id != nk.md_nhapkhonb_id
                                        & s.md_sanpham_id == dh.md_sanpham_id
                                        & s.lsx_to == dh.lsx_to
                                        & db.md_nhapkhonb.Where(t=>t.md_nhapkhonb_id == s.md_nhapkhonb_id & t.trangthai == "SOANTHAO").Count() > 0).FirstOrDefault();
                                    if (ck_dh != null)
                                    {
                                        ck_dh.tong_sl_dat = (ck_dh.tong_sl_dat - dh.sl_danhap).GetValueOrDefault(0).Set0WhenlessThan0();
                                        ck_dh.sl_nhap = 0;
                                    }
                                    msg_success += string.Format(@"
                                    <div style='color:blue'>
                                        Dòng ""{0}"" của ""{1}"" đã nhập kho thành công, số lượng nhập là: ""{2}""
                                    </div>", nk.sochungtu, sp.ma_sanpham, sl_nhap.DropTrailingZeros());
                                }
                            }
                        }
                        if (count_slnhap <= 0 & msg == "")
                        {
                            msg += string.Format(@"<div style='color:red'>
                            Dòng ""{0}"" phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.
                        </div>", nk.sochungtu);
                        }
                    }

                    //Kiem tra de chuyen thanh Hieu Luc
                    if (msg.Length <= 0)
                    {
                        msg = msg_success + msg;
                        nk.trangthai = nk.trangthai == "DANHAN" ? "HIEULUC" : "DANHAN";
                        db.SaveChanges();
                    }
                    else
                        commit = false;
                }
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.Message;
                commit = false;
            }

            if (commit == true)
                transaction.Commit();
            else
                transaction.Rollback();
        }
        context.Response.Write(msg);
    }
    //--cap nhat so luong xuat
    public string edit_nhap(EntityContext db, md_nhapkhonb_cdh dh, User_TK us)
    {
        string id_new = dh.md_nhapkhonb_id;
        decimal sl_danhap = dh.sl_danhap.Value + dh.sl_nhap.Value;
        if (dh.tong_sl_dat <= dh.sl_danhap + dh.sl_nhap)
        {
            sl_danhap = dh.tong_sl_dat.Value;
            dh.check_kho = true;
        }

        dh.sl_danhap = sl_danhap;
        dh.ngaycapnhat = DateTime.Now;
        return id_new;
    }

    //nhap kho
    public string nhap_kho(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb nk, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_sanpham check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == nk.denkho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;
        if (check_khosp == null)
        {
            sp = new md_kho_sanpham();
            sp.md_kho_sanpham_id = id_new;
            sp.soluong = (dh.sl_nhap * nhanvoi);
        }
        else
        {
            id_new = sp.md_kho_sanpham_id;
            sp.soluong += (dh.sl_nhap * nhanvoi);
        }
        sp.md_kho_id = nk.denkho;
        sp.md_sanpham_id = dh.md_sanpham_id;

        sp.nguoitao = us.ad_user_id;
        sp.vaitrotao = us.ad_role_id;
        sp.bophantao = us.md_phongban_id;
        sp.value_nguoitao = us.ma_user;
        sp.value_vaitrotao = us.ten_role;
        sp.value_bophantao = us.ten_phongban;
        sp.nguoicapnhat = us.ad_user_id;
        sp.vaitrocapnhat = us.ad_role_id;
        sp.bophancapnhat = us.md_phongban_id;
        sp.value_nguoicapnhat = us.ma_user;
        sp.value_vaitrocapnhat = us.ten_role;
        sp.value_bophancapnhat = us.ten_phongban;
        sp.hoatdong = true;

        //Kiem tra
        if (check_khosp == null)
        {
            sp.ngaytao = DateTime.Now;
            sp.ngaycapnhat = DateTime.Now;
            db.md_kho_sanpham.Add(sp);
        }
        else
        {
            sp.ngaycapnhat = DateTime.Now;
        }
        return id_new;
    }

    public string add_kho_hsd(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb px, User_TK us, string khospId)
    {
        string id_new = Helper.getNewId(), msg = "";
        var check_khospHSD = db.md_kho_sanpham_hansudung.
                Where(s =>
                    s.md_sanpham_id == dh.md_sanpham_id &
                    s.ngay_hethan.Value == dh.ngay_hethan.Value &
                    s.md_kho_sanpham_id == khospId).FirstOrDefault();
        var spHSD = check_khospHSD;
        if (check_khospHSD == null)
        {
            spHSD = new md_kho_sanpham_hansudung();
            spHSD.md_kho_sanpham_hansudung_id = id_new;
            spHSD.soluong = dh.sl_nhap;
            spHSD.ngay_hethan = dh.ngay_hethan;
        }
        else
        {
            id_new = spHSD.md_kho_sanpham_hansudung_id;
            spHSD.soluong = dh.sl_nhap + spHSD.soluong;
        }
        spHSD.md_kho_sanpham_id = khospId;
        spHSD.md_sanpham_id = dh.md_sanpham_id;
        spHSD.nguoitao = us.ad_user_id;
        spHSD.vaitrotao = us.ad_role_id;
        spHSD.bophantao = us.md_phongban_id;
        spHSD.value_nguoitao = us.ma_user;
        spHSD.value_vaitrotao = us.ten_role;
        spHSD.value_bophantao = us.ten_phongban;
        spHSD.nguoicapnhat = us.ad_user_id;
        spHSD.vaitrocapnhat = us.ad_role_id;
        spHSD.bophancapnhat = us.md_phongban_id;
        spHSD.value_nguoicapnhat = us.ma_user;
        spHSD.value_vaitrocapnhat = us.ten_role;
        spHSD.value_bophancapnhat = us.ten_phongban;
        spHSD.hoatdong = true;
        if (check_khospHSD == null)
        {
            spHSD.ngaytao = DateTime.Now;
            spHSD.ngaycapnhat = DateTime.Now;
            db.md_kho_sanpham_hansudung.Add(spHSD);
        }
        else
        {
            spHSD.ngaycapnhat = DateTime.Now;
        }

        string btvtId = db.md_baotrivthh.Where(s => s.sochungtu == px.baotri_vattu).Select(s => s.md_baotrivthh_id).FirstOrDefault();
        var hsd = db.md_baotrivthh_cdh.
                Where(s => s.md_baotrivthh_id == btvtId & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        if (hsd != null)
            hsd.soluong_dank += dh.sl_nhap;

        return msg;
    }

    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb nk, decimal nhanvoi, User_TK us, md_lenhsanxuat_tosx tsx)
    {
        string id_new = Helper.getNewId();
        md_kho_giaodich giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = nk.denkho;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = dh.sl_nhap * nhanvoi;
        giao.ngaychuyen = nk.ngaychuyen;
        giao.kieuchuyen = "Nhập kho";
        giao.dongnhapxuat = nk.sochungtu;
        giao.md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id;
        giao.mota = dh.tenhang;
        giao.md_to_id = nk.md_to_id;
        giao.sanxuat = 1;
        giao.lsx = dh.lsx_to.Substring(0, 13);
        giao.tosxId = tsx.md_lenhsanxuat_tosx_id;
        giao.nguoitao = us.ad_user_id;
        giao.vaitrotao = us.ad_role_id;
        giao.bophantao = us.md_phongban_id;
        giao.value_nguoitao = us.ma_user;
        giao.value_vaitrotao = us.ten_role;
        giao.value_bophantao = us.ten_phongban;
        giao.nguoicapnhat = us.ad_user_id;
        giao.vaitrocapnhat = us.ad_role_id;
        giao.bophancapnhat = us.md_phongban_id;
        giao.value_nguoicapnhat = us.ma_user;
        giao.value_vaitrocapnhat = us.ten_role;
        giao.value_bophancapnhat = us.ten_phongban;
        giao.hoatdong = true;
        giao.ngaytao = DateTime.Now;
        giao.ngaycapnhat = DateTime.Now;
        db.md_kho_giaodich.Add(giao);
        return "";
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string loaichuyen = context.Request.Form["bosung"];
        string baotri_vattu = context.Request.Form["baotri_vattu"];
        string denkho = context.Request.Form["denkho"];
        string chungtu_lenhsx = context.Request.Form["chungtu_lenhsx"];
        string md_lenhsanxuat_tosx_id = context.Request.Form["md_lenhsanxuat_tosx_id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                DateTime ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
                if (ngaychuyen == DateTime.MinValue | ngaychuyen == DateTime.MinValue.AddDays(1))
                    msg = "Ngày nhập kho có giá trị sai";
                else if (string.IsNullOrEmpty(denkho))
                    msg = string.Format(@"Lỗi: Bạn chưa chọn Kho.");
                else if (loaichuyen == "0")
                {
                    if (string.IsNullOrEmpty(chungtu_lenhsx))
                        msg = string.Format(@"Lỗi: Bạn chưa chọn lệnh sản xuất.");
                    else if (string.IsNullOrEmpty(md_lenhsanxuat_tosx_id))
                        msg = string.Format(@"Lỗi: Bạn chưa chọn tổ sản xuất.");
                }

                if (msg.Length <= 0)
                {
                    string sochungtu = VNN_VariablePublic.sochungtu(db, "PNKNB", 1);
                    var vcnb = new md_nhapkhonb();
                    vcnb.md_nhapkhonb_id = id_new;
                    vcnb.trangthai = "SOANTHAO";
                    vcnb.sochungtu = sochungtu;
                    vcnb.denkho = denkho;
                    vcnb.bosung = int.Parse(loaichuyen);
                    vcnb.chungtu_lenhsx = chungtu_lenhsx;
                    vcnb.md_lenhsanxuat_tosx_id = md_lenhsanxuat_tosx_id;
                    vcnb.ngaychuyen = ngaychuyen;
                    vcnb.nguoitao = us.ad_user_id;
                    vcnb.nguoicapnhat = us.ad_user_id;
                    vcnb.value_nguoitao = us.ma_user;
                    vcnb.value_nguoicapnhat = us.ma_user;
                    vcnb.ngaytao = DateTime.Now;
                    vcnb.ngaycapnhat = DateTime.Now;

                    bool AddPhieuXK = false;
                    var arrTSX = md_lenhsanxuat_tosx_id.Split(new string[] { "\n" }, StringSplitOptions.None);
                    if (loaichuyen == "0")
                    {
                        foreach (var lsxTSXId in arrTSX)
                        {
                            var tsx = Extension.getLSXToId(lsxTSXId, db);
                            var kho = Helper.layKhoCuaTo(tsx.md_phanxuong_id, tsx.md_phanxuong_to_id, db);

                            if (kho.md_kho_id == denkho)
                            {
                                foreach (var dhpx_cdh in db.md_lenhsanxuat_tosx_cdh.
                                        Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).ToList())
                                {
                                    decimal tong_sl_dat = dhpx_cdh.sl_chiato.Value - dhpx_cdh.sl_dahoanthanh.GetValueOrDefault(0) - dhpx_cdh.sl_giamhanngach.GetValueOrDefault(0);
                                    if (tong_sl_dat > 0)
                                    {
                                        var cdh = new md_nhapkhonb_cdh();
                                        cdh.md_nhapkhonb_cdh_id = Helper.getNewId();
                                        cdh.md_nhapkhonb_id = vcnb.md_nhapkhonb_id;
                                        cdh.md_sanpham_id = dhpx_cdh.md_sanpham_id;
                                        cdh.tong_sl_dat = tong_sl_dat;
                                        cdh.sl_danhap = 0;
                                        cdh.sl_nhap = 0;
                                        cdh.ngay_hethan = null;
                                        cdh.md_donvitinhsanpham_id = dhpx_cdh.md_donvitinhsanpham_id;
                                        cdh.lsx_to = lsxTSXId;
                                        cdh.sl_toida_trongLSXTo = tong_sl_dat;
                                        cdh.sl_toida_trongLSXTo2 = tong_sl_dat;

                                        cdh.nguoitao = us.ad_user_id;
                                        cdh.vaitrotao = us.ad_role_id;
                                        cdh.bophantao = us.md_phongban_id;
                                        cdh.value_nguoitao = us.ma_user;
                                        cdh.value_vaitrotao = us.ten_role;
                                        cdh.value_bophantao = us.ten_phongban;
                                        cdh.nguoicapnhat = us.ad_user_id;
                                        cdh.vaitrocapnhat = us.ad_role_id;
                                        cdh.bophancapnhat = us.md_phongban_id;
                                        cdh.value_nguoicapnhat = us.ma_user;
                                        cdh.value_vaitrocapnhat = us.ten_role;
                                        cdh.value_bophancapnhat = us.ten_phongban;
                                        cdh.ngaytao = DateTime.Now;
                                        cdh.ngaycapnhat = DateTime.Now;
                                        cdh.mota = "";
                                        cdh.hoatdong = true;
                                        db.md_nhapkhonb_cdh.Add(cdh);
                                        db.SaveChanges();
                                        AddPhieuXK = true;
                                    }
                                }
                            }
                        }

                        if (AddPhieuXK == true)
                            db.md_nhapkhonb.Add(vcnb);
                        db.SaveChanges();
                    }
                    else
                    {
                        string bthhvtId = db.md_baotrivthh.Where(s => s.sochungtu == baotri_vattu).
                                Select(s => s.md_baotrivthh_id).FirstOrDefault();
                        foreach (var dhpx_cdh in db.md_baotrivthh_cdh.
                                Where(s => s.md_baotrivthh_id == bthhvtId).ToList())
                        {
                            decimal tong_sl_dat = dhpx_cdh.soluong_daht.GetValueOrDefault(0) - dhpx_cdh.soluong_dank.GetValueOrDefault(0);
                            if (tong_sl_dat > 0)
                            {
                                var cdh = new md_nhapkhonb_cdh();
                                cdh.md_nhapkhonb_cdh_id = Helper.getNewId();
                                cdh.md_nhapkhonb_id = id_new;
                                cdh.md_sanpham_id = dhpx_cdh.md_sanpham_id;
                                cdh.tong_sl_dat = tong_sl_dat;
                                cdh.sl_danhap = 0;
                                cdh.sl_nhap = 0;
                                cdh.ngay_hethan = dhpx_cdh.hansudung;
                                cdh.md_donvitinhsanpham_id = dhpx_cdh.md_donvitinhsanpham_id;
                                cdh.check_kho = false;

                                cdh.nguoitao = us.ad_user_id;
                                cdh.vaitrotao = us.ad_role_id;
                                cdh.bophantao = us.md_phongban_id;
                                cdh.value_nguoitao = us.ma_user;
                                cdh.value_vaitrotao = us.ten_role;
                                cdh.value_bophantao = us.ten_phongban;
                                cdh.nguoicapnhat = us.ad_user_id;
                                cdh.vaitrocapnhat = us.ad_role_id;
                                cdh.bophancapnhat = us.md_phongban_id;
                                cdh.value_nguoicapnhat = us.ma_user;
                                cdh.value_vaitrocapnhat = us.ten_role;
                                cdh.value_bophancapnhat = us.ten_phongban;
                                cdh.ngaytao = DateTime.Now;
                                cdh.ngaycapnhat = DateTime.Now;
                                cdh.mota = "";
                                cdh.hoatdong = true;
                                db.md_nhapkhonb_cdh.Add(cdh);
                            }
                        }
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
                msg = "true#Thêm thành công." + "#" + id_new;
                transaction.Commit();
            }
            else
            {
                msg = "false#" + msg;
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        string md_lenhsanxuat_id = context.Request.Form["md_lenhsanxuat_id"];
        string id = context.Request.Form["id"];
        try
        {
            var ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
            md_nhapkhonb object_ = db.md_nhapkhonb.Where(p => p.md_nhapkhonb_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = @"false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.trangthai == "HIEULUC")
            {
                msg = @"false#Lỗi:Phiếu nhập kho đã ""Hiệu Lực""";
            }
            else if (ngaychuyen.IsDate() == false)
            {
                msg = "Lỗi: Ngày nhập kho không đúng định dạng";
            }

            if (msg.Length <= 0)
            {
                object_.ngaychuyen = ngaychuyen;
                object_.mota = context.Request.Form["mota"];
                VNN_Function.loaddulieu_Auto(db, ma_module);
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
        EntityContext db = new EntityContext();
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                var object_ = db.md_nhapkhonb.Where(p => p.md_nhapkhonb_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "Lỗi:Đối tượng đã hiệu lực " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "CHUACHUYENHET")
                {
                    msg_del = "Lỗi:Đối tượng trong trạng thái Chưa Chuyển Hết";
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    object_.trangthai = "SOANTHAO";
                }
            }
            VNN_Function.loaddulieu_Auto(db, ma_module);
            if (msg.Length <= 0)
            {
                msg = "true#Trả về bên đề nghị thành công.";
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

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    public class NNNB
    {
        public string md_nhapkhonb_cdh_id { get; set; }
        public string ma_sanpham { get; set; }
        public string md_sanpham_id { get; set; }
        public decimal? sl_nhap { get; set; }
    }
}