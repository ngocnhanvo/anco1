<%@ WebHandler Language="C#" Class="JQGridMD_00_PVCNoiBoModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_PVCNoiBoModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_XuLyVanChuyen":
                this.CA_01_XuLyVanChuyen(context);
                break;
            case "CA_01_XacNhanVCNB":
                this.CA_01_XacNhanVCNB(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_XacNhanVCNB(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        var pub = new Public();
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            foreach (var vcnb in db.md_vanchuyennoibo.Where(s => vnn.Contains(s.md_vanchuyennoibo_id)).ToList())
            {
                if (vcnb.md_trangthai_id != "SOANTHAO")
                    msg = string.Format(@"Lỗi: phiếu ""{0}"" đã được xác nhận.<br>", vcnb.sochungtu);
                else
                    vcnb.md_trangthai_id = "DANHAN";

                db.SaveChanges();
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"<div class='nhan-thanhcong'>Xác nhận phiếu vận chuyển thành công.</div>");
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

    public void CA_01_XuLyVanChuyen(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        var pub = new Public();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');


        if (vnn.Count() <= 0)
        {
            msg = "<div style='color:red'>Lỗi:Không tìm được phiếu vận chuyển nào.</div>";
        }
        else
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var vcnb in db.md_vanchuyennoibo.Where(s => vnn.Contains(s.md_vanchuyennoibo_id)).ToList())
                    {
                        var lsxtsx = new List<md_lenhsanxuat>();
                        if (vcnb.md_trangthai_id != "DANHAN")
                        {
                            msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" cần ở trạng thái ""Đã Xác Nhận"".</div>", vcnb.sochungtu);
                            break;
                        }
                        else if (string.IsNullOrEmpty(vcnb.tukho))
                        {
                            msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" chưa chọn ""Từ kho"".</div>", vcnb.sochungtu);
                            break;
                        }
                        else if (string.IsNullOrEmpty(vcnb.denkho))
                        {
                            msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" chưa chọn ""Đến kho"".</div>", vcnb.sochungtu);
                            break;
                        }

                        var slChuyen = db.md_vanchuyennoibo_cdvc
                                   .Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id).Sum(s => s.soluong_dichchuyen);
                        if (slChuyen <= 0)
                        {
                            msg = string.Format(@"<div style='color:red'>Phiếu ""{0}"" phải có ít nhất 1 dòng hàng có SL thực chuyển lớn hơn 0.</div>", vcnb.sochungtu);
                            break;
                        }

                        var vcnb_cdvcs = db.md_vanchuyennoibo_cdvc.Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id);
                        int tong_sl_dachuyenhet = vcnb_cdvcs.Where(s => s.dachuyenhet == true).Count();

                        var khoSPDic = new Dictionary<string, decimal>();
                        foreach (var vcnb_cdvc in vcnb_cdvcs.Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id).OrderBy(s => s.denkho).ToList())
                        {
                            //start Xuat kho
                            string[] arr_tukho = vcnb.tukho.Split(',');
                            decimal sl_dichchuyen_thucte = vcnb_cdvc.soluong_dichchuyen.Value;
                            //xuất kho
                            var lstSPId = new List<string>();
                            if (vcnb.loaichuyen == "VANCNBCTKGH")
                            {
                                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                                var lsxto = Extension.getLSXToId2(vcnb_cdvc.lsx_to, db);
                                var tsx = lsxto.tsx;
                                var lsxSp = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                            s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                            & s.macuoi.Contains(sp.ma_sanpham));

                                tsx.ngaygiao = vcnb.ngaychuyen;
                                foreach (var cai in lsxSp.ToList())
                                {
                                    cai.sl_danhapkho += vcnb_cdvc.soluong_dichchuyen;
                                    cai.sl_dagiao = cai.sl_dagiao.GetValueOrDefault(0) + vcnb_cdvc.soluong_dichchuyen;
                                    if (cai.sl_chiato < cai.sl_dagiao)
                                        cai.sl_layton = cai.sl_dagiao - cai.sl_chiato;
                                    else
                                        cai.sl_layton = 0;

                                    lstSPId.Add(cai.md_sanpham_id);
                                }
                                db.SaveChanges();

                                var ddhpx = db.md_dondathangphanxuong_cdh.Where(s =>
                                    s.md_dondathangphanxuong_id == lsxto.lsx.md_dondathangphanxuong_id
                                    & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                                if (ddhpx != null)
                                {
                                    ddhpx.sl_hoanthanh += vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);
                                    db.SaveChanges();
                                }

                                lsxtsx.Add(lsxto.lsx);
                            }
                            else
                            {
                                lstSPId.Add(vcnb_cdvc.md_sanpham_id);
                            }

                            foreach (var kho_sp in db.md_kho_sanpham.Where(s => s.md_kho_id == vcnb.tukho & lstSPId.Contains(s.md_sanpham_id)).ToList())
                            {
                                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == kho_sp.md_sanpham_id).FirstOrDefault();
                                decimal sl_kho_sp = kho_sp.soluong.GetValueOrDefault(0);
                                decimal sl_xuatkho = sl_dichchuyen_thucte;

                                var itemSP = khoSPDic.Where(s => s.Key == sp.md_sanpham_id).FirstOrDefault();
                                if (itemSP.Key == null)
                                {
                                    khoSPDic.Add(sp.md_sanpham_id, sl_kho_sp);
                                }
                                itemSP = khoSPDic.Where(s => s.Key == sp.md_sanpham_id).FirstOrDefault();

                                if (sl_kho_sp < sl_dichchuyen_thucte)
                                {
                                    msg += "<div style='color:red'>Lỗi: dòng \"" + sp.ma_sanpham + "\" số lượng trong kho chỉ còn : " + itemSP.Value.DropTrailingZeros() + ".</div>";
                                    break;
                                }


                                if (sl_xuatkho > 0)
                                {
                                    //Lisch su xuat kho
                                    var kho_gd = new md_kho_giaodich
                                    {
                                        md_kho_giaodich_id = Helper.getNewId(),
                                        md_kho_id = kho_sp.md_kho_id,
                                        md_sanpham_id = kho_sp.md_sanpham_id,
                                        soluong_dichchuyen = sl_xuatkho,
                                        ngaychuyen = vcnb.ngaychuyen.Value,
                                        kieuchuyen = "Xuất kho",
                                        dongnhapxuat = " ",
                                        dongkiemkho = " ",
                                        dongvanchuyen = vcnb.sochungtu,
                                        dongsanxuat = " ",
                                        md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
                                        sapxep = "",
                                        mota = vcnb_cdvc.tenhang,
                                        nguoitao = us.ad_user_id,
                                        vaitrotao = us.ad_role_id,
                                        bophantao = us.md_phongban_id,
                                        value_nguoitao = us.ma_user,
                                        value_vaitrotao = us.ten_role,
                                        value_bophantao = us.ten_phongban,
                                        nguoicapnhat = us.ad_user_id,
                                        vaitrocapnhat = us.ad_role_id,
                                        bophancapnhat = us.md_phongban_id,
                                        value_nguoicapnhat = us.ma_user,
                                        value_vaitrocapnhat = us.ten_role,
                                        value_bophancapnhat = us.ten_phongban,
                                        ngaytao = DateTime.Now,
                                        ngaycapnhat = DateTime.Now,
                                        hoatdong = true
                                    };
                                    db.md_kho_giaodich.Add(kho_gd);
                                    add_kho_hsd(db, null, kho_sp.md_sanpham_id, sl_dichchuyen_thucte, vcnb, 0, us, kho_sp.md_kho_sanpham_id);
                                }
                                //Cap nhat lai kho_gd
                                kho_sp.soluong = kho_sp.soluong.Value - sl_xuatkho;
                                db.SaveChanges();
                            }
                            //end Xuat kho

                            //Nhap Kho
                            if (sl_dichchuyen_thucte > 0)
                            {
                                md_kho_sanpham kho_sp_nhapkho = db.md_kho_sanpham.Where(s => s.md_kho_id == vcnb.denkho & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).Take(1).FirstOrDefault();
                                string khospId = Helper.getNewId();
                                if (kho_sp_nhapkho == null)
                                {
                                    kho_sp_nhapkho = new md_kho_sanpham
                                    {
                                        md_kho_sanpham_id = khospId,
                                        md_kho_id = vcnb.denkho,
                                        md_sanpham_id = vcnb_cdvc.md_sanpham_id,
                                        soluong = vcnb_cdvc.soluong_dichchuyen.Value,
                                        nguoitao = us.ad_user_id,
                                        vaitrotao = us.ad_role_id,
                                        bophantao = us.md_phongban_id,
                                        value_nguoitao = us.ma_user,
                                        value_vaitrotao = us.ten_role,
                                        value_bophantao = us.ten_phongban,
                                        nguoicapnhat = us.ad_user_id,
                                        vaitrocapnhat = us.ad_role_id,
                                        bophancapnhat = us.md_phongban_id,
                                        value_nguoicapnhat = us.ma_user,
                                        value_vaitrocapnhat = us.ten_role,
                                        value_bophancapnhat = us.ten_phongban,
                                        ngaytao = DateTime.Now,
                                        ngaycapnhat = DateTime.Now,
                                        hoatdong = true
                                    };
                                    db.md_kho_sanpham.Add(kho_sp_nhapkho);
                                }
                                else
                                {
                                    kho_sp_nhapkho.soluong = kho_sp_nhapkho.soluong.GetValueOrDefault(0) + vcnb_cdvc.soluong_dichchuyen.Value;
                                }
                                //Lich su kho
                                md_kho_giaodich kho_gd_nhapkho = new md_kho_giaodich
                                {
                                    md_kho_giaodich_id = Helper.getNewId(),
                                    md_kho_id = vcnb.denkho,
                                    md_sanpham_id = vcnb_cdvc.md_sanpham_id,
                                    soluong_dichchuyen = vcnb_cdvc.soluong_dichchuyen.Value,
                                    md_donvitinhsanpham_id = vcnb_cdvc.md_donvitinhsanpham_id,
                                    ngaychuyen = vcnb.ngaychuyen.Value,
                                    kieuchuyen = "Nhập kho",
                                    dongnhapxuat = " ",
                                    dongkiemkho = " ",
                                    dongvanchuyen = vcnb.sochungtu,
                                    dongsanxuat = " ",
                                    sapxep = "",
                                    mota = vcnb_cdvc.tenhang,
                                    nguoitao = us.ad_user_id,
                                    vaitrotao = us.ad_role_id,
                                    bophantao = us.md_phongban_id,
                                    value_nguoitao = us.ma_user,
                                    value_vaitrotao = us.ten_role,
                                    value_bophantao = us.ten_phongban,
                                    nguoicapnhat = us.ad_user_id,
                                    vaitrocapnhat = us.ad_role_id,
                                    bophancapnhat = us.md_phongban_id,
                                    value_nguoicapnhat = us.ma_user,
                                    value_vaitrocapnhat = us.ten_role,
                                    value_bophancapnhat = us.ten_phongban,
                                    ngaytao = DateTime.Now,
                                    ngaycapnhat = DateTime.Now,
                                    hoatdong = true
                                };
                                db.md_kho_giaodich.Add(kho_gd_nhapkho);
                                add_kho_hsd(db, null, vcnb_cdvc.md_sanpham_id, sl_dichchuyen_thucte, vcnb, 1, us, kho_sp_nhapkho.md_kho_sanpham_id);
                                //end Nhap kho

                                //Start Cap nhat don van chuyen
                                vcnb_cdvc.soluong_dachuyen = vcnb_cdvc.soluong_dichchuyen;
                                //End Cap nhat don van chuyen
                                db.SaveChanges();
                            }
                        }

                        foreach (var item in lsxtsx.Distinct())
                        {
                            int countSLHT = db.md_dondathangphanxuong_cdh.Where(s =>
                                s.md_dondathangphanxuong_id == item.md_dondathangphanxuong_id
                            ).ToList().Where(s =>
                                s.tong_sl_dat -
                                s.sl_giamhanngach.GetValueOrDefault(0) -
                                s.sl_hoanthanh.GetValueOrDefault(0) > 0
                            ).Count();

                            if (countSLHT <= 0)
                            {
                                var dhpx = db.md_dondathangphanxuong.Where(s =>
                                    s.md_dondathangphanxuong_id == item.md_dondathangphanxuong_id).FirstOrDefault();
                                if (dhpx != null)
                                {
                                    var tsxs = db.md_lenhsanxuat_tosx.Where(s =>
                                        s.md_lenhsanxuat_id == item.md_lenhsanxuat_id)
                                        .Select(s => s.md_lenhsanxuat_tosx_id).ToList();

                                    var LHTTSX = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                        tsxs.Contains(s.md_lenhsanxuat_tosx_id)
                                    )
                                    .Where(s => s.sl_dagiao != s.sl_dahoanthanh)
                                    .ToList();

                                    if (LHTTSX.Count <= 0)
                                    {
                                        var countLHTTSX = LHTTSX.Where(s => s.sl_chiato - s.sl_dagiao.GetValueOrDefault(0) > 0).Count();
                                        if (countLHTTSX <= 0)
                                        {
                                            dhpx.md_trangthai_id = "KETTHUC";
                                            item.md_trangthai_id = "HOANTHANH";
                                            item.ngayhoanthanh = vcnb.ngaychuyen;
                                        }
                                    }
                                }
                                db.SaveChanges();
                            }
                        }

                        //-----
                        if (vcnb.loaichuyen == "VANCNB")
                        {
                            foreach (var cdvc in db.md_vanchuyennoibo_cdvc.
                                                    Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id).ToList())
                            {
                                //Cap nhat du kien lay hang ton
                                foreach (var dklht in
                                        db.c_doichieuhangton_dklht.
                                            Where(s => s.c_doichieuhangton_id == vcnb.c_doichieuhangton_id &
                                            s.md_sanpham_id == cdvc.md_sanpham_id).ToList())
                                {
                                    dklht.sl_dalay = dklht.sl_dalay + cdvc.soluong_dachuyen;
                                }
                                //Cap nhat lai cac dong van chuyen
                                foreach (var check_xk in
                                        db.md_vanchuyennoibo.Where(s =>
                                            s.md_vanchuyennoibo_id != vcnb.md_vanchuyennoibo_id &
                                            s.c_doichieuhangton_id == vcnb.c_doichieuhangton_id &
                                            s.tukho == vcnb.tukho &
                                            s.md_trangthai_id == "SOANTHAO").ToList())
                                {
                                    foreach (var ck_dh in
                                            db.md_vanchuyennoibo_cdvc.Where(s =>
                                                s.md_vanchuyennoibo_id == check_xk.md_vanchuyennoibo_id &
                                                s.md_sanpham_id == cdvc.md_sanpham_id).ToList())
                                    {
                                        ck_dh.soluong_toida = ck_dh.soluong_toida - cdvc.soluong_dachuyen;
                                    }
                                }
                            }
                        }

                        if (msg.Length <= 0)
                        {
                            vcnb.md_trangthai_id = "HIEULUC";
                            db.SaveChanges();
                            pub.capnhatGiuCho_VCNB(vcnb.sochungtu, vcnb.chungtuthamchieu, vcnb.tukho, vcnb.md_vanchuyennoibo_id, vcnb.md_trangthai_id, db);
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception ex) { msg = string.Format(@"<div style='color:red'>{0}.</div>", ex.Message); }
                if (msg.Length <= 0)
                {
                    msg = "<div style='color:blue'>Vận chuyển hàng hóa thành công.</div>";
                    transaction.Commit();
                }
                else
                    transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public string add_kho_hsd(EntityContext db, DateTime? nhh, string SpId, decimal? sldc, md_vanchuyennoibo px, int type, User_TK us, string khospId)
    {
        string id_new = Helper.getNewId();
        var check_khospHSD = db.md_kho_sanpham_hansudung.
                Where(s =>
                    s.md_sanpham_id == SpId &
                    s.ngay_hethan.Equals(nhh) &
                    s.md_kho_sanpham_id == khospId).FirstOrDefault();
        var spHSD = check_khospHSD;
        if (check_khospHSD == null)
        {
            spHSD = new md_kho_sanpham_hansudung();
            spHSD.md_kho_sanpham_hansudung_id = id_new;
            spHSD.soluong = type == 0 ? 0 : sldc;
            spHSD.ngay_hethan = nhh;
        }
        else
        {
            id_new = spHSD.md_kho_sanpham_hansudung_id;
            spHSD.soluong = type == 0 ? spHSD.soluong - sldc : spHSD.soluong + sldc;
        }
        spHSD.md_kho_sanpham_id = khospId;
        spHSD.md_sanpham_id = SpId;
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
        return id_new;
    }

    public void add(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg1 = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string loaichuyen = context.Request.Form["loaichuyen"];
        string tukho = context.Request.Form["tukho"];
        string denkho = context.Request.Form["denkho"];
        string sctdathang = context.Request.Form["sctdathang"];
        string chungtuthamchieu = context.Request["chungtuthamchieu"];
        string[] pvcnbs = chungtuthamchieu.Split(new[] { "\n" }, StringSplitOptions.None);
        string chungtu_lenhsx = context.Request.Form["chungtu_lenhsx"];
        string md_lenhsanxuat_tosx_id = context.Request.Form["md_lenhsanxuat_tosx_id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                denkho = db.md_kho.Where(s => s.md_kho_id == denkho).Select(s => s.md_kho_id).FirstOrDefault();
                tukho = db.md_kho.Where(s => s.md_kho_id == tukho).Select(s => s.md_kho_id).FirstOrDefault();
                DateTime ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
                if (ngaychuyen.IsDate() == false)
                    msg = "Ngày chuyển có giá trị sai";
                else if (tukho == denkho)
                {
                    msg1 = "Kho chuyển không được giống với kho đến";
                }
                else if (string.IsNullOrEmpty(tukho) | string.IsNullOrEmpty(denkho))
                {
                    msg1 = "Bạn phải chọn Kho chuyển và kho đến";
                }

                if (msg.Length <= 0)
                {
                    if (loaichuyen == "VANCNB")
                    {
                        if (string.IsNullOrEmpty(chungtuthamchieu))
                        {
                            msg = @"Bạn phải phiếu xuất kho trong trường ""Thừa kế từ""";
                        }
                        else
                        {
                            foreach (var a in db.md_vanchuyennoibo.Where(s => pvcnbs.Contains(s.sochungtu)).ToList())
                            {
                                string sochungtu = VNN_VariablePublic.sochungtu(db, "PVC", 1);
                                var vcnb = new md_vanchuyennoibo();
                                vcnb.md_vanchuyennoibo_id = Helper.getNewId();
                                vcnb.md_trangthai_id = "SOANTHAO";
                                vcnb.sochungtu = sochungtu;
                                vcnb.c_doichieuhangton_id = " ";
                                vcnb.tukho = a.tukho;
                                vcnb.denkho = a.denkho;
                                vcnb.loaichuyen = loaichuyen;
                                vcnb.chungtuthamchieu = a.sochungtu;
                                vcnb.ngaychuyen = ngaychuyen;
                                vcnb.nguoitao = us.ad_user_id;
                                vcnb.nguoicapnhat = us.ad_user_id;
                                vcnb.value_nguoitao = us.ma_user;
                                vcnb.value_nguoicapnhat = us.ma_user;
                                vcnb.ngaytao = DateTime.Now;
                                vcnb.ngaycapnhat = DateTime.Now;
                                db.md_vanchuyennoibo.Add(vcnb);

                                foreach (var b in db.md_vanchuyennoibo_cdvc.Where(s => s.md_vanchuyennoibo_id == a.md_vanchuyennoibo_id).ToList())
                                {
                                    var slgc = db.md_kho_giucho.Where(s => s.md_sanpham_id == b.md_sanpham_id
                                        & s.md_kho_id == vcnb.tukho & s.sctlienquan == a.sochungtu).FirstOrDefault();

                                    var vcnb_cdh = new md_vanchuyennoibo_cdvc();
                                    vcnb_cdh.md_vanchuyennoibo_cdvc_id = Helper.getNewId();
                                    vcnb_cdh.md_vanchuyennoibo_id = vcnb.md_vanchuyennoibo_id;
                                    vcnb_cdh.md_sanpham_id = b.md_sanpham_id;
                                    vcnb_cdh.md_donvitinhsanpham_id = b.md_donvitinhsanpham_id;
                                    vcnb_cdh.soluong_toida = slgc.soluong_giucho;
                                    vcnb_cdh.soluong_dachuyen = 0;
                                    vcnb_cdh.soluong_dichchuyen = vcnb_cdh.soluong_toida;
                                    vcnb_cdh.nguoitao = us.ad_user_id;
                                    vcnb_cdh.nguoicapnhat = us.ad_user_id;
                                    vcnb_cdh.value_nguoitao = us.ma_user;
                                    vcnb_cdh.value_nguoicapnhat = us.ma_user;
                                    vcnb_cdh.ngaytao = DateTime.Now;
                                    vcnb_cdh.ngaycapnhat = DateTime.Now;
                                    db.md_vanchuyennoibo_cdvc.Add(vcnb_cdh);
                                }
                                db.SaveChanges();
                            }
                        }
                    }
                    else if (msg1.Length > 0)
                    {
                        msg = msg1;
                    }
                    else if (loaichuyen == "VANCNBTC")
                    {
                        string sochungtu = VNN_VariablePublic.sochungtu(db, "PVC", 1);
                        var vcnb = new md_vanchuyennoibo();
                        id_new = Helper.getNewId();
                        vcnb.md_vanchuyennoibo_id = id_new;
                        vcnb.md_trangthai_id = "SOANTHAO";
                        vcnb.sochungtu = sochungtu;
                        vcnb.c_doichieuhangton_id = " ";
                        vcnb.tukho = context.Request.Form["tukho"];
                        vcnb.denkho = context.Request.Form["denkho"];
                        vcnb.loaichuyen = loaichuyen;
                        vcnb.chungtuthamchieu = "";
                        vcnb.sctdathang = context.Request.Form["sctdathang"];
                        vcnb.donhang_thamchieu = context.Request.Form["donhang_thamchieu"];
                        vcnb.ngaychuyen = ngaychuyen;
                        vcnb.nguoitao = us.ad_user_id;
                        vcnb.nguoicapnhat = us.ad_user_id;
                        vcnb.value_nguoitao = us.ma_user;
                        vcnb.value_nguoicapnhat = us.ma_user;
                        vcnb.ngaytao = DateTime.Now;
                        vcnb.ngaycapnhat = DateTime.Now;
                        db.md_vanchuyennoibo.Add(vcnb);
                        db.SaveChanges();
                    }
                    else if (loaichuyen == "VANCNBCTKGH")
                    {
                        string sochungtu = VNN_VariablePublic.sochungtu(db, "PVC", 1);
                        var vcnb = new md_vanchuyennoibo();
                        id_new = Helper.getNewId();
                        vcnb.md_vanchuyennoibo_id = id_new;
                        vcnb.md_trangthai_id = "SOANTHAO";
                        vcnb.sochungtu = sochungtu;
                        vcnb.c_doichieuhangton_id = " ";
                        vcnb.tukho = context.Request.Form["tukho"];
                        vcnb.denkho = context.Request.Form["denkho"];
                        vcnb.loaichuyen = loaichuyen;
                        vcnb.chungtuthamchieu = "";
                        vcnb.chungtu_lenhsx = chungtu_lenhsx;
                        vcnb.md_lenhsanxuat_tosx_id = md_lenhsanxuat_tosx_id;
                        vcnb.ngaychuyen = ngaychuyen;
                        vcnb.nguoitao = us.ad_user_id;
                        vcnb.nguoicapnhat = us.ad_user_id;
                        vcnb.value_nguoitao = us.ma_user;
                        vcnb.value_nguoicapnhat = us.ma_user;
                        vcnb.ngaytao = DateTime.Now;
                        vcnb.ngaycapnhat = DateTime.Now;
                        vcnb.banggiaNC = context.Request.Form["banggiaNC"];
                        vcnb.phienbangiaNC = context.Request.Form["phienbangiaNC"];
                        bool AddPhieuXK = false;
                        var arrTSX = md_lenhsanxuat_tosx_id.Split(new string[] { "\n" }, StringSplitOptions.None);

                        foreach (var lsxTSXId in arrTSX.OrderByDescending(s => s))
                        {
                            var tsx = Extension.getLSXToId(lsxTSXId, db);
                            var kho = Helper.layKhoCuaTo(tsx.md_phanxuong_id, tsx.md_phanxuong_to_id, db);

                            if (kho.md_kho_id == tukho)
                            {
                                var ddhPXId = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id).Select(s => s.md_dondathangphanxuong_id).FirstOrDefault();
                                var slcl = new List<Dictionary<string, object>>();
                                foreach (var dhpx_cdh in db.md_dondathangphanxuong_cdh.Where(s => s.md_dondathangphanxuong_id == ddhPXId).ToList())
                                {
                                    var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dhpx_cdh.md_sanpham_id).FirstOrDefault();
                                    if (sp != null)
                                    {
                                        var sltd = dhpx_cdh.tong_sl_dat - dhpx_cdh.sl_giamhanngach.GetValueOrDefault(0) - dhpx_cdh.sl_hoanthanh.GetValueOrDefault(0);
                                        var lsxSp = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                            s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                            & s.macuoi.Contains(sp.ma_sanpham));

                                        decimal slnn = -1;
                                        foreach (var cai in lsxSp.ToList())
                                        {
                                            string str_sldc = slcl != null ? slcl.Where(s => s["md_sanpham_id"] + "" == cai.md_sanpham_id)
                                                    .Select(s => s["soluong"] + "").FirstOrDefault() : "0";
                                            var sldc = !string.IsNullOrEmpty(str_sldc) ? decimal.Parse(str_sldc) : 0;
                                            var sldc2 = cai.sl_dahoanthanh.GetValueOrDefault(0)
                                                        - cai.sl_danhapkho.GetValueOrDefault(0)
                                                        - sldc;
                                            if (sldc2 < slnn | slnn == -1)
                                            {
                                                slnn = sldc2;
                                            }
                                            slcl.Add(new Dictionary<string, object>() {
                                                { "md_sanpham_id", cai.md_sanpham_id },
                                                { "soluong", 0 }
                                            });
                                        }

                                        foreach (var itemSLTH in slcl)
                                        {
                                            itemSLTH["soluong"] = slnn;
                                        }

                                        var cdh = new md_vanchuyennoibo_cdvc();
                                        cdh.md_vanchuyennoibo_cdvc_id = Helper.getNewId();
                                        cdh.md_vanchuyennoibo_id = vcnb.md_vanchuyennoibo_id;
                                        cdh.md_sanpham_id = sp.md_sanpham_id;
                                        cdh.soluong_toida = sltd;
                                        cdh.soluong_dachuyen = 0;
                                        cdh.soluong_dichchuyen = slnn;
                                        cdh.ngay_hethan = null;
                                        cdh.md_donvitinhsanpham_id = dhpx_cdh.md_donvitinhsanpham_id;
                                        cdh.lsx_to = lsxTSXId;

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
                                        db.md_vanchuyennoibo_cdvc.Add(cdh);
                                        db.SaveChanges();
                                        AddPhieuXK = true;
                                    }
                                }
                            }
                        }

                        if (AddPhieuXK == true)
                            db.md_vanchuyennoibo.Add(vcnb);
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
                msg = "true#Tạo phiếu vận chuyển thành công#" + id_new;
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
        string tukho = context.Request.Form["tukho"];
        string denkho = context.Request.Form["denkho"];
        string id = context.Request.Form["id"];
        try
        {
            var ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
            var object_ = db.md_vanchuyennoibo.Where(p => p.md_vanchuyennoibo_id == id).Take(1).FirstOrDefault();
            denkho = db.md_kho.Where(s => s.md_kho_id == denkho).Select(s => s.md_kho_id).FirstOrDefault();
            tukho = db.md_kho.Where(s => s.md_kho_id == tukho).Select(s => s.md_kho_id).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.md_trangthai_id == "HIEULUC")
            {
                msg = "false#Lỗi:Dòng " + object_.sochungtu + " đã Hiệu lực";
            }
            else if (tukho == denkho)
            {
                msg = "false#Lỗi: Kho chuyển không được giống với kho đến";
            }
            else if (string.IsNullOrEmpty(tukho) | string.IsNullOrEmpty(denkho))
            {
                msg = "false#Lỗi:Bạn phải chọn Kho chuyển và kho đến";
            }
            else if (ngaychuyen.IsDate() == false)
            {
                msg = "false#Lỗi:Ngày chuyển không đúng định dạng";
            }

            if (msg.Length <= 0)
            {
                if (object_.loaichuyen == "VANCNBCTKGH")
                    object_.denkho = denkho;
                object_.ngaychuyen = ngaychuyen;
                object_.ngaycapnhat = DateTime.Now;
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
        var db = new EntityContext();
        var pub = new Public();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string[] id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < id_del.Length; i++)
            {
                var id_del_ = id_del[i];
                var object_ = db.md_vanchuyennoibo.Where(p => p.md_vanchuyennoibo_id == id_del_).Take(1).FirstOrDefault();
                var dcht = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg += string.Format(@"Lỗi dòng {0}:Không tìm thấy đối tượng cần xóa.", i + 1);
                }
                else if (object_.md_trangthai_id == "HIEULUC")
                {
                    msg += string.Format(@"Lỗi dòng {0}: Dòng {1} đã hiệu lực, không thể xóa.", i + 1, object_.sochungtu);
                }
                else
                {
                    object_.md_trangthai_id = "SOANTHAO";
                }
            }

            if (msg.Length <= 0)
            {
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = @"true#Trả trạng thái về ""Soạn Thảo"" thành công.";
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
}