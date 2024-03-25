using System;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
using System.Data;

public class Public
{
    public string urlData { get; set; }

    public Public()
    {

    }

    public class BaoLoiKhiHieuLuc
    {
        public string msp { get; set; }
        public string loi { get; set; }
    }

    public class BaoLoiKhiTaoDHSX
    {
        public md_lenhsanxuat_tosx_cdh cdh { get; set; }
        public List<BaoLoiKhiHieuLuc> msgBLHLs { get; set; }
    }

    private class lsxTSX
    {
        public md_lenhsanxuat lsx { get; set; }
        public md_lenhsanxuat_tosx tsx { get; set; }
    }

    public List<Public.BaoLoiKhiHieuLuc> msgErrsPL { get; set; }

    public List<md_banggia> layBGGiaNhanCongs(EntityContext db)
    {
        return db.md_banggia.Where(s => s.tuychon == Helper.NHANCONG & s.hoatdong == true).ToList();
    }

    public md_phienbangia layPBGGiaNhanCong(EntityContext db, List<md_banggia> bgncs)
    {
        var bgIds = bgncs.Select(s => s.md_banggia_id).ToList();
        return db.md_phienbangia
                   .Where(s =>
                        bgIds.Contains(s.md_banggia_id)
                        & s.hoatdong == true
                        & s.ngay_hieuluc <= DateTime.Now)
                   .OrderByDescending(s => s.ngay_hieuluc)
                   .FirstOrDefault();
    }

    private List<BaoLoiKhiHieuLuc> kiemtraBomVaGia(
        EntityContext db,
        md_lenhsanxuat lsx,
        md_dondathangphanxuong_cdh cdhPX,
        md_sanpham spcha2,
        md_sanpham spcha1,
        md_sanpham sp,
        md_phienbangia pbgnc,
        User_TK userTK,
        string maSPDH,
        decimal soluongBOM,
        bool kiemtragia,
        int stt,
        List<BaoLoiKhiHieuLuc> msgBLHLs = null,
        md_sanpham spchaBS = null
        )
    {
        if (msgBLHLs == null)
            msgBLHLs = new List<BaoLoiKhiHieuLuc>();
        string pbgId = pbgnc == null ? "" : pbgnc.md_phienbangia_id;
        string msgEX = "";
        var giasp = db.md_giasanpham.Where(s =>
            s.md_sanpham_id == sp.md_sanpham_id
            & s.md_donvitinhsanpham_id == sp.md_donvitinhsanpham_id
            & s.md_phienbangia_id == pbgId
            ).FirstOrDefault();

        var hhtronCuoi = sp.vattu.GetValueOrDefault(false);
        var cdh = db.md_lenhsanxuat_tosx_cdh.Local.Where(s =>
            s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id &
            s.md_lenhsanxuat_tosx_id == spcha1.phongbanId + sp.phongbanId &
            s.md_sanpham_id == sp.md_sanpham_id &
            s.macuoi == spcha1.ma_sanpham &
            s.mathaydoi == spcha2.ma_sanpham
            ).FirstOrDefault();
        var add = cdh == null;
        if (add)
        {
            cdh = new md_lenhsanxuat_tosx_cdh();
            cdh.md_lenhsanxuat_tosx_cdh_id = Helper.getNewId();
            cdh.md_lenhsanxuat_tosx_id = spcha1.phongbanId + sp.phongbanId;
            cdh.xuongChinh = spcha1.phongbanId;
            cdh.xuongPhu = sp.phongbanId;
            cdh.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
            cdh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id;
            cdh.md_sanpham_id = sp.md_sanpham_id;
            cdh.sp1 = sp.ma_sanpham;
            cdh.macuoi = spcha1.ma_sanpham;
            cdh.mathaydoi = spcha2.ma_sanpham;
            cdh.mabo = maSPDH;
            cdh.sl_dat = cdhPX.tong_sl_dat.GetValueOrDefault(0) * soluongBOM;
            cdh.sl_giamhanngach = cdhPX.sl_giamhanngach.GetValueOrDefault(0);
            cdh.sl_chiato = cdh.sl_dat - cdh.sl_giamhanngach;
            cdh.stt = stt;
            cdh = Helper.setDefaultValueWhenInsertOrUpdate(cdh, userTK, false);
        }
        else
        {
            cdh.sl_dat = cdh.sl_dat.GetValueOrDefault(0) + cdhPX.tong_sl_dat.GetValueOrDefault(0) * soluongBOM;
            cdh.sl_giamhanngach = cdh.sl_giamhanngach.GetValueOrDefault(0) + cdhPX.sl_giamhanngach.GetValueOrDefault(0);
            cdh.sl_chiato = cdh.sl_dat - cdh.sl_giamhanngach;
            if (!cdh.mabo.Contains(spcha1.ma_sanpham))
                cdh.mabo += $",{maSPDH}";
        }

        if (giasp == null)
        {
            if (kiemtragia == true)
            {
                msgEX += $@"<br class='error'>HHVT ""{sp.ma_sanpham}"" chưa có giá nhân công";
                foreach (var item in msgBLHLs.Where(s => string.IsNullOrWhiteSpace(s.loi) & s.msp == maSPDH))
                {
                    item.loi += $"{sp.ma_sanpham} chưa có giá nhân công";
                }
            }
        }
        else
        {
            cdh.gianhancong = giasp.gia;
            cdh.pbgId = giasp.md_phienbangia_id;
        }


        var spBom = db.md_sanpham_bom.
                    Where(s =>
                    s.md_sanpham_id == sp.md_sanpham_id
                    & s.ngay_hieuluc <= DateTime.Now
                    ).OrderByDescending(s => s.ngay_hieuluc).Take(1).FirstOrDefault();

        string bomSpId = spBom == null ? "" : spBom.md_sanpham_bom_id;

        var bomSPs = (from a in db.md_sanpham_bom_vattu
                      join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                      join c in db.md_kho on b.khomacdinh equals c.md_kho_id
                      where
                         a.md_sanpham_bom_id == bomSpId
                         & a.sanphamId == sp.md_sanpham_id
                      select new { a, b, b.ban_thanhpham, b.vattu, b.phongbanId, sp.md_donvitinhsanpham_id, c.ma_kho }).ToList();

        cdh.noigiaohang = bomSpId;
        cdh.bomId = bomSpId;

        if (bomSPs.Count > 0)
        {
            if (add & spchaBS == null)
                db.md_lenhsanxuat_tosx_cdh.Add(cdh);

            bomSPs = bomSPs.Where(s => s.a.soluong > 0).ToList();
            foreach (var vattuspT in bomSPs)
            {
                var vattusp = vattuspT.a;
                var bomVT = db.md_sanpham_bom.
                    Where(s =>
                    s.md_sanpham_id == vattusp.md_sanpham_id
                    & s.ngay_hieuluc <= DateTime.Now
                    ).OrderByDescending(s => s.ngay_hieuluc).Take(1).FirstOrDefault();

                if (bomVT == null | !sp.vattu.GetValueOrDefault(false))
                {
                    var sp1 = spchaBS == null ? sp.ma_sanpham : spchaBS.ma_sanpham;
                    var toSXVTsServer = db.md_lenhsanxuat_tosx_vattu.Where(s =>
                            s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.md_sanpham_id == vattusp.md_sanpham_id
                            & s.md_lenhsanxuat_tosx_id == cdh.xuongChinh + cdh.xuongPhu
                            & s.sp1 == sp1
                            & s.sp2 == spcha1.ma_sanpham
                            & s.sp3 == spcha2.ma_sanpham
                            ).ToList();

                    var toSXVTs = db.md_lenhsanxuat_tosx_vattu.Local.Where(s =>
                            s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.md_sanpham_id == vattusp.md_sanpham_id
                            & s.md_lenhsanxuat_tosx_id == cdh.xuongChinh + cdh.xuongPhu
                            & s.sp1 == sp1
                            & s.sp2 == spcha1.ma_sanpham
                            & s.sp3 == spcha2.ma_sanpham
                            ).ToList();

                    var vtlsxto = toSXVTs.FirstOrDefault();
                    var addVT = vtlsxto == null;
                    if (addVT)
                    {
                        vtlsxto = new md_lenhsanxuat_tosx_vattu();
                        vtlsxto.md_lenhsanxuat_tosx_vattu_id = Helper.getNewId();
                        vtlsxto.md_lenhsanxuat_tosx_id = cdh.xuongChinh + cdh.xuongPhu;
                        vtlsxto.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
                        vtlsxto.md_sanpham_id = vattusp.md_sanpham_id;
                        vtlsxto.sp1 = sp1;
                        vtlsxto.sp2 = spcha1.ma_sanpham;
                        vtlsxto.sp3 = spcha2.ma_sanpham;
                        vtlsxto.md_donvitinhsanpham_id = vattusp.md_donvitinhsanpham_id;
                        vtlsxto.sl_hanngach = 0;
                        vtlsxto.sl_giamhanngach = 0;
                        vtlsxto.vattu = vattuspT.vattu.GetValueOrDefault(false);
                        vtlsxto.bantp = vattuspT.ban_thanhpham.GetValueOrDefault(false);
                        vtlsxto.hoatdong = !vattuspT.ban_thanhpham.GetValueOrDefault(false);
                        vtlsxto.soluong = (decimal)vattusp.soluong.GetValueOrDefault(0) * cdh.sl_chiato.GetValueOrDefault(0);
                    }
                    else
                    {
                        if (add)
                            vtlsxto.soluong = vtlsxto.soluong.GetValueOrDefault(0) + (decimal)vattusp.soluong.GetValueOrDefault(0) * cdh.sl_chiato.GetValueOrDefault(0);
                        else
                            vtlsxto.soluong = (decimal)vattusp.soluong.GetValueOrDefault(0) * cdh.sl_chiato.GetValueOrDefault(0);
                    }

                    if (addVT)
                        db.md_lenhsanxuat_tosx_vattu.Add(vtlsxto);


                    var vtbkServer = db.md_lenhsanxuat_tosx_vattuBackup.Where(s =>
                            s.sp == cdh.md_sanpham_id
                            & s.vt == vattusp.md_sanpham_id
                            & s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.md_lenhsanxuat_tosx_id == cdh.xuongChinh + cdh.xuongPhu
                            & s.sp1 == sp1
                            & s.sp2 == spcha1.ma_sanpham
                            & s.sp3 == spcha2.ma_sanpham).FirstOrDefault();

                    var vtbk = db.md_lenhsanxuat_tosx_vattuBackup.Local.Where(s =>
                            s.sp == cdh.md_sanpham_id
                            & s.vt == vattusp.md_sanpham_id
                            & s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.md_lenhsanxuat_tosx_id == cdh.xuongChinh + cdh.xuongPhu
                            & s.sp1 == sp1
                            & s.sp2 == spcha1.ma_sanpham
                            & s.sp3 == spcha2.ma_sanpham).FirstOrDefault();
                    var addVTBK = vtbk == null;
                    if (addVTBK)
                    {
                        vtbk = new md_lenhsanxuat_tosx_vattuBackup();
                        vtbk.md_lenhsanxuat_tosx_vattuBackup_id = Helper.getNewId();
                        vtbk.md_lenhsanxuat_tosx_id = cdh.xuongChinh + cdh.xuongPhu;
                        vtbk.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
                        vtbk.sp = spchaBS == null ? cdh.md_sanpham_id : spchaBS.md_sanpham_id;
                        vtbk.vt = vattusp.md_sanpham_id;
                        vtbk.sp1 = sp1;
                        vtbk.sp2 = spcha1.ma_sanpham;
                        vtbk.sp3 = spcha2.ma_sanpham;
                        vtbk.ngaytao = DateTime.Now;
                        if (spchaBS == null)
                        {
                            vtbk.sp = cdh.md_sanpham_id;
                            vtbk.soluong = (decimal)vattusp.soluong.GetValueOrDefault(0);
                        }
                        else
                        {
                            vtbk.sp = spchaBS.md_sanpham_id;
                            vtbk.soluong = (decimal)vattusp.soluong.GetValueOrDefault(0) * soluongBOM;
                        }

                        vtbk.md_donvitinhsanpham_id = vattusp.md_donvitinhsanpham_id;
                        db.md_lenhsanxuat_tosx_vattuBackup.Add(vtbk);
                    }
                }
            }
            stt = stt - 1;
            var btps = bomSPs.Where(s => (s.ban_thanhpham ?? false) == true).ToList();
            foreach (var btp in btps)
            {
                if (string.IsNullOrWhiteSpace(btp.b.phongbanId))
                {
                    foreach (var item in msgBLHLs.Where(s => string.IsNullOrWhiteSpace(s.loi) & s.msp == maSPDH))
                    {
                        item.loi = $@"""{btp.b.ma_sanpham}"" không thể bỏ trống ""Phân xưởng sản xuất""";
                    }
                }
                else
                {
                    var slct = (decimal)btp.a.soluong.GetValueOrDefault(0);
                    if (hhtronCuoi)
                    {
                        stt = stt + 1;
                        if (spchaBS == null)
                        {
                            spchaBS = sp;
                        }
                        else
                            slct = (decimal)btp.a.soluong.GetValueOrDefault(0) * soluongBOM;

                        msgBLHLs = kiemtraBomVaGia(db, lsx, cdhPX, spcha2, spcha1, btp.b, pbgnc, userTK, maSPDH, slct, kiemtragia, stt, msgBLHLs, spchaBS);
                    }
                    else
                    {
                        msgBLHLs = kiemtraBomVaGia(db, lsx, cdhPX, spcha2, sp, btp.b, pbgnc, userTK, maSPDH, slct, kiemtragia, stt, msgBLHLs);
                    }
                }
            }
        }
        else if (!sp.vattu.GetValueOrDefault(false))
        {
            string err = $@"<br class='error'>HHVT ""{sp.ma_sanpham}"" chưa có BOM";

            if (!msgEX.Contains(err))
            {
                msgEX += err;
            }

            foreach (var item in msgBLHLs.Where(s => string.IsNullOrWhiteSpace(s.loi) & s.msp == maSPDH))
            {
                item.loi += $"{sp.ma_sanpham} chưa có BOM";
            }
        }

        return msgBLHLs;
    }

    public List<Public.BaoLoiKhiHieuLuc> TaoLenhSanXuat(EntityContext db, md_dondathangphanxuong object_, c_kehoachdathang khdh, User_TK userTK, bool kiemtragia, List<Public.BaoLoiKhiHieuLuc> msgBLHLs = null)
    {
        if (msgBLHLs == null)
            msgBLHLs = new List<BaoLoiKhiHieuLuc>();

        var pbids = new List<string>();
        string sochungtu = VNN_VariablePublic.sochungtu(db, "LSX", 1);

        var lsx = new md_lenhsanxuat();
        lsx.md_lenhsanxuat_id = Helper.getNewId();
        lsx.md_dondathangphanxuong_id = object_.md_dondathangphanxuong_id;
        lsx.c_kehoachdathang_id = object_.c_kehoachdathang_id;
        lsx.md_phanxuong_id = object_.md_phanxuong_id;
        lsx.donhang_thamchieu = object_.donhang_thamchieu;
        lsx.sxton = khdh.sanxuatton.GetValueOrDefault(false);
        lsx.dhtron = khdh.donhangtron.GetValueOrDefault(false);
        lsx.md_trangthai_id = Helper.CHUAHOANTHANH;
        lsx.sochungtu = sochungtu;
        lsx.ngaylap = DateTime.Now;
        lsx.ngayketthuc = object_.ngayhoanthanh;
        lsx.ngaydkgiaotp = object_.ngayketthuc;
        lsx.phieuXK = Helper.CHUAHOANTHANH;
        lsx = Helper.setDefaultValueWhenInsertOrUpdate(lsx, userTK, false);
        lsx.hoatdong = true;
        db.md_lenhsanxuat.Add(lsx);

        var cdhPXs = db.md_dondathangphanxuong_cdh.Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).ToList();
        var cdhPXsLocal = db.md_dondathangphanxuong_cdh.Local.Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).ToList();
        var bgncs = layBGGiaNhanCongs(db);
        var pbgnc = layPBGGiaNhanCong(db, bgncs);

        foreach (var dhpx_cdh in cdhPXsLocal)
        {
            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dhpx_cdh.md_sanpham_id).Take(1).FirstOrDefault();

            string ma_caiTemp = sp.ma_sanpham, bo = sp.ma_sanpham;

            var bocais = new List<string>();
            if (sp.ma_sanpham.Length >= 11)
            {
                ma_caiTemp = sp.ma_sanpham.Substring(0, 9) + "{0}" + sp.ma_sanpham.Substring(11);
                bo = sp.ma_sanpham.Substring(9, 2);

                string bo_lon =
                    db.md_sanpham
                    .Where(s => s.ma_sanpham.StartsWith(sp.ma_sanpham.Substring(0, 9) + "S") & s.hoatdong == true)
                    .OrderByDescending(s => s.ngaytao)
                    .Select(s => s.ma_sanpham.Substring(9, 2)).FirstOrDefault();

                string mdBoId = db.md_bo.Where(s => s.ma_bo == bo & s.ma_bo_cha == bo_lon).Select(s => s.md_bo_id).FirstOrDefault();
                bocais = db.md_bo_chitiet.Where(s => s.md_bo_id == mdBoId).OrderByDescending(s => s.md_bo_detail).Select(s => s.md_bo_detail).ToList();
            }

            if (bocais.Count <= 0)
                bocais.Add(bo);

            foreach (var bocai in bocais)
            {
                string ma_cai = string.Format(ma_caiTemp, bocai);
                string ma_bo = string.Format(ma_caiTemp, bo);

                var spCai = db.md_sanpham.Where(s => s.ma_sanpham == ma_cai & s.hoatdong == true).FirstOrDefault();

                bool update = false;

                if (spCai == null)
                {
                    foreach (var item in msgBLHLs.Where(s => string.IsNullOrWhiteSpace(s.loi) & s.msp == sp.ma_sanpham))
                    {
                        item.loi += $"Thiếu mã cái {ma_cai}, hãy kiểm tra dữ liệu gốc hàng hóa";
                    }
                }
                else
                {
                    var khomd = db.md_kho.Where(s => s.md_kho_id == spCai.khomacdinh).FirstOrDefault();
                    if (khomd == null)
                    {
                        foreach (var item in msgBLHLs.Where(s => string.IsNullOrWhiteSpace(s.loi) & s.msp == sp.ma_sanpham))
                        {
                            item.loi += $"{ma_cai} phải có kho mặc định";
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(spCai.phongbanId))
                    {
                        foreach (var item in msgBLHLs.Where(s => string.IsNullOrWhiteSpace(s.loi) & s.msp == sp.ma_sanpham))
                        {
                            item.loi = $@"""{spCai.ma_sanpham}"" không thể bỏ trống ""Phân xưởng sản xuất""";
                        }
                    }
                    else
                        update = true;
                }

                if (update)
                {
                    var laVT = spCai.vattu.GetValueOrDefault(false);
                    var laBTP = !spCai.vattu.GetValueOrDefault(false) & spCai.ban_thanhpham.GetValueOrDefault(false);
                    var laTP = !spCai.vattu.GetValueOrDefault(false) & !spCai.ban_thanhpham.GetValueOrDefault(false) & sp.sanpham.GetValueOrDefault(false);
                    int stt = laVT ? 9997 : (laBTP ? 9998 : 9999);
                    msgBLHLs = kiemtraBomVaGia(db, lsx, dhpx_cdh, spCai, spCai, spCai, pbgnc, userTK, sp.ma_sanpham, 1, kiemtragia, stt, msgBLHLs);
                }
            }
        }

        var cdhLSXs = db.md_lenhsanxuat_tosx_cdh.Local.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id).ToList();
        var vtLSXs = db.md_lenhsanxuat_tosx_vattu.Local.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id).ToList();
        var vtBKLSXs = db.md_lenhsanxuat_tosx_vattuBackup.Local.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id).ToList();
        var qtsxs = cdhLSXs.Select(s => new
        {
            s.md_lenhsanxuat_tosx_id,
            s.xuongChinh,
            s.xuongPhu,
            s.md_lenhsanxuat_id,
            s.stt
        }).Distinct().ToList();
        foreach (var qtsx in qtsxs)
        {
            var tsx = new md_lenhsanxuat_tosx();
            tsx.md_lenhsanxuat_tosx_id = Helper.getNewId();
            tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
            tsx.xuongChinh = qtsx.xuongChinh;
            tsx.xuongPhu = qtsx.xuongPhu;
            tsx.md_phanxuong_id = tsx.xuongChinh;
            tsx.md_phanxuong_to_id = tsx.xuongPhu;
            tsx.phongbanId = tsx.xuongChinh;
            tsx.stt = qtsx.stt;
            tsx = Helper.setDefaultValueWhenInsertOrUpdate(tsx, userTK, false);
            tsx.hoatdong = true;
            db.md_lenhsanxuat_tosx.Add(tsx);

            var cdhLSXTSXs = cdhLSXs.Where(s => s.md_lenhsanxuat_tosx_id == qtsx.xuongChinh + qtsx.xuongPhu).ToList();
            foreach (var cdhLSXTSX in cdhLSXTSXs)
            {
                cdhLSXTSX.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id;
            }

            var vtLSXTSXs = vtLSXs.Where(s => s.md_lenhsanxuat_tosx_id == qtsx.xuongChinh + qtsx.xuongPhu).ToList();
            foreach (var vtLSXTSX in vtLSXTSXs)
            {
                vtLSXTSX.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id;
            }

            var vtBKLSXTSXs = vtBKLSXs.Where(s => s.md_lenhsanxuat_tosx_id == qtsx.xuongChinh + qtsx.xuongPhu).ToList();
            foreach (var vtBKLSXTSX in vtBKLSXTSXs)
            {
                vtBKLSXTSX.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id;
            }
        }

        return msgBLHLs;
    }

    public List<BaoLoiKhiHieuLuc> xuLyKeHoachDatHang(EntityContext db, User_TK userTK, c_kehoachdathang khdh, List<c_kehoachdathang_cdhcd> cdhcds, c_danhsachdathang dsdh, string ma_module, string thoigianht, List<BaoLoiKhiHieuLuc> msgBLHLs)
    {
        string msg = "", msg_success = "";
        try
        {
            var dhcpx = new c_kehoachdathang_dhcpx();
            dhcpx.c_kehoachdathang_dhcpx_id = Helper.getNewId();
            dhcpx.dongdathang = "";
            dhcpx.md_phanxuong_id = "";
            dhcpx.c_kehoachdathang_id = khdh.c_kehoachdathang_id;
            dhcpx.donhang = khdh.donhang_thamchieu;
            dhcpx.ngayHTcham = khdh.hangiaohangPO;
            dhcpx.sctdathang = khdh.sodonhang;
            dhcpx.hdlh = dsdh.huongdanlamhang;
            dhcpx.hdlhchung = dsdh.huongdanlamhangchung;
            dhcpx.c_danhsachdathang_id = dsdh.c_danhsachdathang_id;
            dhcpx.tinh_ncvt = false;

            dhcpx = Helper.setDefaultValueWhenInsertOrUpdate(dhcpx, userTK, false);
            dhcpx.hoatdong = true;
            db.c_kehoachdathang_dhcpx.Add(dhcpx);

            foreach (var item in cdhcds)
            {
                var dhcpxCDH = new c_kehoachdathang_dhcpx_cdh();
                dhcpxCDH.c_kehoachdathang_dhcpx_cdh_id = Helper.getNewId();
                dhcpxCDH.c_kehoachdathang_id = item.c_kehoachdathang_id;
                dhcpxCDH.c_kehoachdathang_dhcpx_id = dhcpx.c_kehoachdathang_dhcpx_id;
                dhcpxCDH.md_sanpham_id = item.md_sanpham_id;
                dhcpxCDH.macuoi = item.macuoi;
                dhcpxCDH.md_donvitinhsanpham_id = item.md_donvitinhsanpham_id;
                dhcpxCDH.noigiaohang = item.noigiaohang;
                dhcpxCDH.mota = "";
                dhcpxCDH.soluong = item.sl_candat;
                dhcpxCDH = Helper.setDefaultValueWhenInsertOrUpdate(dhcpxCDH, userTK, false);
                dhcpxCDH.hoatdong = true;
                db.c_kehoachdathang_dhcpx_cdh.Add(dhcpxCDH);
            }

            khdh.xulykehoach = true;

            msg_success += "<div style='color:blue'>Dòng \"" + khdh.ten_kh + "\" đã xử lý kế hoạch đặt hàng thành công.</div>";
        }
        catch (Exception ex)
        {
            foreach (var item in msgBLHLs.Where(s => string.IsNullOrWhiteSpace(s.loi)))
            {
                item.loi = $"KHDH: {ex.ToString()}";
            }
        }

        if (msg.Length <= 0)
        {
            msg = msg_success;
        }

        return msgBLHLs;
    }

    public void capnhatGiuCho_VCNB(string sct, string sctlq, string khoId, string vcnbId, string trangthai, EntityContext db)
    {
        var sctlqs = new List<string> { sct, sctlq };
        foreach (var giucho in db.md_kho_giucho.Where(s => sctlqs.Contains(s.sctlienquan) & s.md_kho_id == khoId).ToList())
        {
            var dvc = db.md_vanchuyennoibo_cdvc.Where(s =>
                s.md_vanchuyennoibo_id == vcnbId &
                s.md_sanpham_id == giucho.md_sanpham_id).FirstOrDefault();

            if (dvc != null)
            {
                if (trangthai == "SOANTHAO")
                    giucho.soluong_giucho = giucho.soluong_giucho - dvc.soluong_toida;
                else
                    giucho.soluong_giucho = giucho.soluong_giucho - dvc.soluong_dachuyen;
            }
            if (giucho.soluong_giucho <= 0)
                db.md_kho_giucho.Remove(giucho);
        }
    }

    public void capnhatGiuCho_XKVatTuTon(string sct, string sctlq, string khoId, string vcnbId, string trangthai, EntityContext db)
    {
        var sctlqs = new List<string> { sct, sctlq };
        foreach (var giucho in db.md_kho_giucho.Where(s => sctlqs.Contains(s.sctlienquan) & s.md_kho_id == khoId).ToList())
        {
            var dvc = db.md_xuatkhonb_cdh.Where(s =>
                s.md_xuatkhonb_id == vcnbId &
                s.md_sanpham_id == giucho.md_sanpham_id).FirstOrDefault();

            if (dvc != null)
            {
                if (trangthai == Helper.SOANTHAO)
                    giucho.soluong_giucho = giucho.soluong_giucho - dvc.tong_sl_xuat;
                else
                    giucho.soluong_giucho = giucho.soluong_giucho - dvc.sl_daxuat;
            }
            if (giucho.soluong_giucho <= 0)
                db.md_kho_giucho.Remove(giucho);
        }
    }

    public string getBOMHieuLuc(string spId, EntityContext db, DateTime? ngaydonhang = null)
    {
        if (ngaydonhang == null)
            ngaydonhang = DateTime.Now;
        string bomId = (from a in db.md_sanpham_bom
                        where a.md_sanpham_id == spId
                        & string.IsNullOrEmpty(a.md_phanxuong_id)
                        & !string.IsNullOrEmpty(a.md_to_id)
                        & (a.bom_donggoi == null | a.bom_donggoi == false)
                        & a.ngay_hieuluc <= ngaydonhang
                        orderby a.ngay_hieuluc descending
                        select a.md_sanpham_bom_id).FirstOrDefault();
        return bomId;
    }

    public string getBOMDongGoi(string spId, EntityContext db)
    {
        string bomId = (from a in db.md_sanpham_bom
                        where a.md_sanpham_id == spId
                        & string.IsNullOrEmpty(a.md_phanxuong_id)
                        & string.IsNullOrEmpty(a.md_to_id)
                        & a.bom_donggoi == true
                        orderby a.ngay_hieuluc descending
                        select a.md_sanpham_bom_id).FirstOrDefault();
        return bomId;
    }

    public decimal getGiaBanSP(string sanphamId, string khachhang, EntityContext db)
    {
        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == sanphamId).FirstOrDefault();
        if (sp == null)
            return -1;

        var tuychon = sp.ban_thanhpham.GetValueOrDefault(false) ? Helper.NHANCONG : Helper.BANTP;
        var giaBanSP = from a in db.md_giasanpham
                       join b in db.md_phienbangia on a.md_phienbangia_id equals b.md_phienbangia_id
                       join c in db.md_banggia on b.md_banggia_id equals c.md_banggia_id
                       where a.md_sanpham_id == sanphamId
                       & c.lienket_bg == (tuychon == Helper.NHANCONG ? c.lienket_bg : khachhang)
                       & c.tuychon == tuychon
                       & c.hoatdong == true
                       & b.ngay_hieuluc <= DateTime.Now
                       orderby b.ngay_hieuluc descending
                       select a.gia;

        return giaBanSP.Take(1).FirstOrDefault().GetValueOrDefault(0);
    }

    public List<Public.BaoLoiKhiHieuLuc> CA_01_TDDHPX(EntityContext db, User_TK userTK, string ma_module, c_kehoachdathang khdh, string kiemtragiaStr, List<Public.BaoLoiKhiHieuLuc> msgBLHLs = null)
    {
        if (msgBLHLs == null)
            msgBLHLs = new List<BaoLoiKhiHieuLuc>();

        bool kiemtragia = (kiemtragiaStr + "").ToLower() == "true";

        try
        {
            var dhcpx = db.c_kehoachdathang_dhcpx.Local.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).FirstOrDefault();
            var cdhs = db.c_kehoachdathang_dhcpx_cdh.Local.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).ToList();

            string sochungtu = VNN_VariablePublic.sochungtu(db, "DDHPX", 1);
            string id_new = Helper.getNewId();
            var ddh = new md_dondathangphanxuong();
            ddh.md_dondathangphanxuong_id = id_new;
            ddh.md_trangthai_id = Helper.SOANTHAO;
            ddh.c_kehoachdathang_id = dhcpx.c_kehoachdathang_id;
            ddh.c_kehoachdathang_dhcpx_id = dhcpx.c_kehoachdathang_dhcpx_id;
            ddh.md_phanxuong_id = dhcpx.md_phanxuong_id;
            ddh.donhang_thamchieu = dhcpx.donhang;
            ddh.ngayhoanthanh = dhcpx.ngayHTcham;
            ddh.ngayketthuc = dhcpx.ngayHTcham;
            ddh.sochungtu = sochungtu;
            ddh.yeucaumuavattu = " ";
            ddh.sctdathang = dhcpx.sctdathang;
            ddh.hdlh = dhcpx.hdlh;
            ddh.hdlhchung = dhcpx.hdlhchung;
            ddh.hoatdong = true;
            ddh = Helper.setDefaultValueWhenInsertOrUpdate(ddh, userTK, false);
            db.md_dondathangphanxuong.Add(ddh);

            foreach (var cdh in cdhs)
            {
                var cdhPX = new md_dondathangphanxuong_cdh();
                cdhPX.md_dondathangphanxuong_cdh_id = Helper.getNewId();
                cdhPX.md_dondathangphanxuong_id = ddh.md_dondathangphanxuong_id;
                cdhPX.md_sanpham_id = cdh.md_sanpham_id;
                cdhPX.tong_sl_dat = cdh.soluong;
                cdhPX.hanngach = cdhPX.tong_sl_dat;
                cdhPX.sl_chiato = 0;
                cdhPX.sl_hoanthanh = 0;
                cdhPX.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id;
                cdhPX.noigiaohang = cdh.noigiaohang;
                cdhPX.macuoi = cdh.macuoi;
                cdhPX.hoatdong = true;
                cdhPX = Helper.setDefaultValueWhenInsertOrUpdate(cdhPX, userTK, false);
                db.md_dondathangphanxuong_cdh.Add(cdhPX);
            }

            msgBLHLs = TaoLenhSanXuat(db, ddh, khdh, userTK, kiemtragia, msgBLHLs);
        }
        catch (Exception ex)
        {
            foreach (var item in msgBLHLs.Where(s => string.IsNullOrWhiteSpace(s.loi)))
            {
                item.loi += ex.ToString();
            }
        }

        return msgBLHLs;
    }

    public string tinhHangTonKhoTheoLSX(EntityContext db, User_TK us, string id, List<md_lenhsanxuat_tosx> tsxs = null)
    {
        var ksp = from a in db.md_kho_sanpham
                  join b in db.md_kho on a.md_kho_id equals b.md_kho_id
                  join c in db.md_sanpham on a.md_sanpham_id equals c.md_sanpham_id
                  where b.hangton == true
                  select new { a.md_kho_id, b.md_phanxuong_id, b.md_to_id, a.md_sanpham_id, c.ma_sanpham, a.soluong, c.sanpham };

        string msg = "";
        var tinhhangtonTP = false;
        try
        {
            if (tsxs == null)
            {
                var tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).FirstOrDefault();
                tsxs.Add(tsx);
            }

            foreach (var tsx in tsxs)
            {
                var chophepVT = tsx.stt == 9997;

                if (string.IsNullOrEmpty(tsx.phieulayht))
                {
                    if (tsx.stt == 9999)
                    {
                        if (string.IsNullOrWhiteSpace(tsx.phieulayhttp))
                        {
                            tinhhangtonTP = true;
                        }
                    }

                    if (tinhhangtonTP)
                    {
                        var tsxIds = db.md_lenhsanxuat_tosx.
                            Where(s =>
                                s.xuongChinh == tsx.xuongChinh
                                & s.xuongPhu == tsx.xuongPhu
                                & s.md_lenhsanxuat_tosx_id != tsx.md_lenhsanxuat_tosx_id
                                & (string.IsNullOrEmpty(s.phieulayhttp) | s.phieulayhttp == " ")
                                ).
                            Select(s => s.md_lenhsanxuat_tosx_id).
                            ToList();

                        db.md_lenhsanxuat_tosx_dklhttp.RemoveRange(db.md_lenhsanxuat_tosx_dklhttp.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id));
                        db.md_lenhsanxuat_tosx_dklht.RemoveRange(db.md_lenhsanxuat_tosx_dklht.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id));
                        foreach (var cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).ToList())
                        {
                            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).FirstOrDefault();
                            var lht = new md_lenhsanxuat_tosx_dklhttp();
                            lht.md_lenhsanxuat_tosx_dklhttp_id = Helper.getNewId();
                            lht.md_lenhsanxuat_tosx_id = cdh.md_lenhsanxuat_tosx_id;
                            lht.md_sanpham_id = cdh.md_sanpham_id;
                            lht.macuoi = cdh.macuoi;
                            lht.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id;
                            var kspSLT = ksp.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.sanpham == true).ToList().Sum(s => s.soluong.GetValueOrDefault(0));
                            lht.sl_lsx = cdh.sl_chiato.GetValueOrDefault(0) - cdh.sl_chiato2.GetValueOrDefault(0);
                            lht.sl_tonkho = kspSLT;

                            var sl_ctlt = lht.sl_tonkho > lht.sl_lsx ? lht.sl_lsx : lht.sl_tonkho;

                            var sl_dadklt = db.md_lenhsanxuat_tosx_dklhttp.Where(s =>
                                tsxIds.Contains(s.md_lenhsanxuat_tosx_id)
                                & s.md_sanpham_id == sp.md_sanpham_id).ToList().Sum(s => s.sl_layton.GetValueOrDefault(0));

                            sl_ctlt = sl_ctlt >= sl_dadklt ? sl_ctlt - sl_dadklt : 0;

                            lht.sl_layton = sl_ctlt;
                            lht.ngaytao = DateTime.Now;
                            lht.ngaycapnhat = DateTime.Now;
                            lht.nguoitao = us.ad_user_id;
                            lht.nguoicapnhat = us.ad_user_id;
                            lht.value_nguoitao = us.ma_user;
                            lht.value_nguoicapnhat = us.ma_user;
                            db.md_lenhsanxuat_tosx_dklhttp.Add(lht);
                        }

                        tsx.tinhhangtontp = true;
                        tsx.tinhhangton = false;
                    }
                    else
                    {
                        db.md_lenhsanxuat_tosx_dklht.RemoveRange(db.md_lenhsanxuat_tosx_dklht.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id));
                        db.md_lenhsanxuat_tosx_tonkho.RemoveRange(db.md_lenhsanxuat_tosx_tonkho.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id));
                        foreach (var cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).ToList())
                        {
                            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).FirstOrDefault();
                            
                            if (!sp.vattu.GetValueOrDefault(false) | chophepVT)
                            {
                                var lht = new md_lenhsanxuat_tosx_dklht();
                                lht.md_lenhsanxuat_tosx_dklht_id = Helper.getNewId();
                                lht.md_lenhsanxuat_tosx_id = cdh.md_lenhsanxuat_tosx_id;
                                lht.md_sanpham_id = cdh.md_sanpham_id;
                                lht.macuoi = cdh.macuoi;
                                lht.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id;
                                var kspSLT = ksp.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).ToList().Sum(s => s.soluong.GetValueOrDefault(0));
                                lht.sl_lsx = cdh.sl_chiato.GetValueOrDefault(0) - cdh.sl_chiato2.GetValueOrDefault(0);
                                lht.sl_tonkho = kspSLT;

                                var dadkltServer = db.md_lenhsanxuat_tosx_dklht.Where(s =>
                                    s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                    & s.md_sanpham_id == sp.md_sanpham_id).ToList();

                                var dadklt = db.md_lenhsanxuat_tosx_dklht.Local.Where(s =>
                                    s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                    & s.md_sanpham_id == sp.md_sanpham_id).ToList();

                                var sl_dadklt = dadklt.Sum(s => s.sl_layton.GetValueOrDefault(0));

                                var sl_ctlt = lht.sl_tonkho - sl_dadklt;

                                var sl_lt = lht.sl_lsx >= sl_ctlt ? sl_ctlt : lht.sl_lsx;

                                lht.sl_layton = sl_lt;
                                lht.ngaytao = DateTime.Now;
                                lht.ngaycapnhat = DateTime.Now;
                                lht.nguoitao = us.ad_user_id;
                                lht.nguoicapnhat = us.ad_user_id;
                                lht.value_nguoitao = us.ma_user;
                                lht.value_nguoicapnhat = us.ma_user;
                                db.md_lenhsanxuat_tosx_dklht.Add(lht);
                            }
                        }

                        tsx.tinhhangton = true;
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
            if (tinhhangtonTP)
                msg = string.Format("<div class='hangtonTP' style='color:blue'>Tính hàng tồn thành phẩm thành công.</div>");
            else
                msg = string.Format("<div style='color:blue'>Tính hàng tồn thành công.</div>");
        }
        else
        {
            msg = string.Format("<div class='error' style='color:red'>Lỗi:{0}.</div>", msg);
        }

        return msg;
    }

    public Dictionary<string, int> layHangTonKhoTheoLSX(EntityContext db, User_TK us, string id
        , md_lenhsanxuat_tosx tsxA, List<md_lenhsanxuat_tosx> tsxs = null, c_kehoachdathang khdh = null, bool? layTho = null)
    {
        string msg = "";
        var idsTP = new List<string>();
        var ids = new List<string>();
        var idsTHTonTP = new List<string>();
        var idsTHTon = new List<string>();
        var khotpIds = new List<string>();
        var khotps = new List<md_kho>();
        var khotpsIds = new List<string>();
        var layhangtonTP = false;

        try
        {


            if (tsxs == null)
            {
                tsxs = new List<md_lenhsanxuat_tosx>();

                if (tsxA == null)
                {
                    tsxA = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).FirstOrDefault();
                }
                tsxs.Add(tsxA);
            }

            string phongbanId = "";
            var khoTonTho = db.md_kho.Where(s => s.ma_kho == Helper.KHOTONTHO).FirstOrDefault();
            var khoTonTP = db.md_kho.Where(s => s.ma_kho == Helper.KHOTONTP).FirstOrDefault();
            var KhoThoChoHoanThien = db.md_kho.Where(s => s.ma_kho == Helper.KhoThoChoHoanThien).FirstOrDefault();
            var KhoHangSauHoanThien = db.md_kho.Where(s => s.ma_kho == Helper.KhoHangSauHoanThien).FirstOrDefault();
            md_vanchuyennoibo vcnb = null;
            var vcnbs = new List<md_vanchuyennoibo>();
            var taoPVC = false;
            foreach (var tsx in tsxs.OrderBy(s => s.phongbanId))
            {
                if (phongbanId != tsx.phongbanId)
                {
                    phongbanId = tsx.phongbanId;
                    string sochungtu = VNN_VariablePublic.sochungtu(db, "PVC", 1);
                    vcnb = new md_vanchuyennoibo();
                    vcnb.md_vanchuyennoibo_id = Helper.getNewId();
                    vcnb.md_trangthai_id = Helper.DANHAN;
                    vcnb.sochungtu = sochungtu;
                    vcnb.c_doichieuhangton_id = " ";
                    vcnb.tukho = layTho.GetValueOrDefault(false) ? khoTonTho.md_kho_id : khoTonTP.md_kho_id;
                    vcnb.denkho = layTho.GetValueOrDefault(false) ? KhoThoChoHoanThien.md_kho_id : KhoHangSauHoanThien.md_kho_id;
                    vcnb.loaichuyen = "VANCNBTC";
                    vcnb.loaichuyen_id = Helper.CHUAHOANTHANH;
                    vcnb.chungtuthamchieu = "";
                    vcnb.laytonTPhoacBTP = true;
                    vcnb.ketoan = !layTho.GetValueOrDefault(false);
                    vcnb.sctdathang = khdh.sodonhang;
                    vcnb.donhang_thamchieu = khdh.donhang_thamchieu;
                    vcnb.ngaydenghi = DateTime.Now;
                    vcnb.ngaychuyen = DateTime.Now;
                    vcnb.hoatdong = true;
                    vcnb = Helper.setDefaultValueWhenInsertOrUpdate(vcnb, us, false);
                }

                if (tsx.stt == 9999)
                {
                    if (string.IsNullOrWhiteSpace(tsx.phieulayhttp))
                    {
                        layhangtonTP = true;
                    }
                }

                if (layhangtonTP)
                {
                    khotps = db.md_kho.Where(s => string.IsNullOrEmpty(s.md_to_id) & s.hangton == true & (s.vattu ?? false) == false & s.hoatdong == true).ToList();
                    khotpsIds = khotps.Select(s => s.md_kho_id).ToList();
                }

                if (msg.Length <= 0)
                {
                    var listLHTTP = new List<md_lenhsanxuat_tosx_dklhttp>();
                    var listLHT = new List<md_lenhsanxuat_tosx_dklht>();


                    if (tsx.md_lenhsanxuat_tosx_id != tsx.md_lenhsanxuat_tosx_id)
                    {
                        if (layhangtonTP)
                        {
                            if (string.IsNullOrEmpty(tsx.phieulayhttp) & tsx.tinhhangtontp == true)
                                idsTHTonTP.Add(tsx.md_lenhsanxuat_tosx_id);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(tsx.phieulayht) & tsx.tinhhangton == true)
                                idsTHTon.Add(tsx.md_lenhsanxuat_tosx_id);
                        }
                    }

                    var cdhsServer = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).ToList();
                    var cdhs = db.md_lenhsanxuat_tosx_cdh.Local.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).ToList();

                    if (layhangtonTP)
                    {
                        foreach (var cdh in cdhs)
                        {
                            var lhtsServer = db.md_lenhsanxuat_tosx_dklhttp.Where(s =>
                                s.md_sanpham_id == cdh.md_sanpham_id
                                & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                            //& s.sl_layton > 0
                            ).ToList();

                            var lhts = db.md_lenhsanxuat_tosx_dklhttp.Local.Where(s =>
                                s.md_sanpham_id == cdh.md_sanpham_id
                                & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                            //& s.sl_layton > 0
                            ).ToList();

                            if (lhts.Count > 0)
                                listLHTTP.AddRange(lhts);
                        }
                    }
                    else
                    {
                        foreach (var cdh in cdhs)
                        {
                            var lhtsServer = db.md_lenhsanxuat_tosx_dklht.Where(s =>
                                s.md_sanpham_id == cdh.md_sanpham_id
                                & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                            //& s.sl_layton > 0
                            ).ToList();

                            var lhts = db.md_lenhsanxuat_tosx_dklht.Local.Where(s =>
                                s.md_sanpham_id == cdh.md_sanpham_id
                                & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                            //& s.sl_layton > 0
                            ).ToList();

                            if (lhts.Count > 0)
                                listLHT.AddRange(lhts);
                        }
                    }

                    if (msg.Length <= 0)
                    {
                        if (layhangtonTP)
                        {
                            if (listLHTTP.Sum(s => s.sl_layton.GetValueOrDefault(0)) > 0)
                            {
                                taoPVC = true;
                                vcnbs.Add(vcnb);
                                foreach (var lht in listLHTTP.Distinct().Where(s => s.sl_layton > 0))
                                {
                                    var cdvc = new md_vanchuyennoibo_cdvc();
                                    cdvc.md_vanchuyennoibo_cdvc_id = Helper.getNewId();
                                    cdvc.md_vanchuyennoibo_id = vcnb.md_vanchuyennoibo_id;
                                    cdvc.md_sanpham_id = lht.md_sanpham_id;
                                    cdvc.md_donvitinhsanpham_id = lht.md_donvitinhsanpham_id;
                                    cdvc.lsxId = tsx.md_lenhsanxuat_id;
                                    cdvc.tukho = tsx.md_lenhsanxuat_tosx_id;
                                    cdvc.soluong_dachuyen = 0;
                                    cdvc.soluong_toida = lht.sl_layton;
                                    cdvc.soluong_muonchuyen = lht.sl_layton;
                                    cdvc.soluong_dichchuyen = lht.sl_layton;
                                    cdvc.tenhang = khdh.donhang_thamchieu;
                                    cdvc.chuyenton = true;
                                    cdvc.hoatdong = true;
                                    cdvc = Helper.setDefaultValueWhenInsertOrUpdate(cdvc, us, false);
                                    cdvc.mota = lht.mota;
                                    db.md_vanchuyennoibo_cdvc.Add(cdvc);
                                }

                                idsTP.Add(vcnb.md_vanchuyennoibo_id);

                                //tsx.tolaytontpId = toLayHTId;
                                tsx.phieulayhttp = vcnb.sochungtu;
                                db.SaveChanges();
                            }
                            else
                            {
                                foreach (var lht in listLHTTP)
                                    lht.sl_layton1 = 0;
                                tsx.phieulayhttp = "";
                                tsx.tolaytontpId = "";
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            if (listLHT.Sum(s => s.sl_layton.GetValueOrDefault(0)) > 0)
                            {
                                taoPVC = true;
                                vcnbs.Add(vcnb);
                                foreach (var lht in listLHT.Distinct().Where(s => s.sl_layton > 0))
                                {
                                    var cdvcServer = db.md_vanchuyennoibo_cdvc.Where(s =>
                                        s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id
                                        & s.md_sanpham_id == lht.md_sanpham_id).FirstOrDefault();

                                    var cdvc = db.md_vanchuyennoibo_cdvc.Local.Where(s =>
                                        s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id
                                        & s.md_sanpham_id == lht.md_sanpham_id).FirstOrDefault();

                                    var addCDVC = cdvc == null;
                                    if (addCDVC)
                                    {
                                        cdvc = new md_vanchuyennoibo_cdvc();
                                        cdvc.md_vanchuyennoibo_cdvc_id = Helper.getNewId();
                                        cdvc.md_vanchuyennoibo_id = vcnb.md_vanchuyennoibo_id;
                                        cdvc.md_sanpham_id = lht.md_sanpham_id;
                                        cdvc.md_donvitinhsanpham_id = lht.md_donvitinhsanpham_id;
                                        cdvc.lsxId = tsx.md_lenhsanxuat_id;
                                        cdvc.tukho = tsx.md_lenhsanxuat_tosx_id;
                                        cdvc.soluong_dachuyen = 0;
                                        cdvc.soluong_toida = lht.sl_layton;
                                        cdvc.soluong_muonchuyen = lht.sl_layton;
                                        cdvc.soluong_dichchuyen = lht.sl_layton;
                                        cdvc.chuyenton = true;
                                        cdvc.hoatdong = true;
                                        cdvc = Helper.setDefaultValueWhenInsertOrUpdate(cdvc, us, false);
                                        cdvc.mota = lht.mota;
                                        db.md_vanchuyennoibo_cdvc.Add(cdvc);
                                    }
                                    else
                                    {
                                        cdvc.soluong_toida = cdvc.soluong_toida.GetValueOrDefault(0) + lht.sl_layton;
                                        cdvc.soluong_muonchuyen = cdvc.soluong_muonchuyen.GetValueOrDefault(0) + lht.sl_layton;
                                        cdvc.soluong_dichchuyen = cdvc.soluong_dichchuyen.GetValueOrDefault(0) + lht.sl_layton;
                                    }
                                }
                                tsx.phieulayht = vcnb.sochungtu;
                                //tsx.tolaytonId = toLayHTId;
                                //tsx.tolayton = toLayHT;
                                ids.Add(vcnb.md_vanchuyennoibo_id);
                                db.SaveChanges();
                            }
                            else
                            {
                                foreach (var lht in listLHT)
                                    lht.sl_layton1 = 0;
                                tsx.phieulayht = "";
                                tsx.tolaytonId = "";
                                db.SaveChanges();
                            }
                        }
                    }
                }
            }

            if (taoPVC)
            {
                db.md_vanchuyennoibo.AddRange(vcnbs.Distinct());
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = ex + "";
        }

        if (msg.Length <= 0)
        {
            if (layhangtonTP)
                msg = string.Format("<div style='color:blue'>Xử lý tồn TP thành công.</div>");
            else
                msg = string.Format("<div style='color:blue'>Xử lý tồn BTP thành công.</div>");

            if (ids.Count > 0)
            {
                //HieuLucPhieuVanChuyen(db, us, "", string.Join(",", ids), "false");
            }

            if (idsTP.Count > 0)
            {
                //HieuLucPhieuVanChuyen(db, us, "", string.Join(",", idsTP), "false");
            }
        }
        else
        {
            msg = string.Format("<div class='error' style='color:red'>Lỗi:{0}.</div>", msg);
        }

        var dic = new Dictionary<string, int>();
        dic.Add(msg, 0);
        return dic;
    }

    public string tinhLayTonTho(EntityContext db, User_TK userTK, string id_parent, string ma_module, string msg, List<md_lenhsanxuat> lsxs = null)
    {
        try
        {
            if (lsxs == null)
                lsxs = new List<md_lenhsanxuat>();

            var msgs = new List<string>();
            foreach (var lsx in lsxs)
            {
                var stt = lsx.dhtron.GetValueOrDefault(false) ? 9997 : 9998;
                var tsxs = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id & s.stt == stt & (string.IsNullOrEmpty(s.phieulayht) | s.phieulayht == " ")).ToList();
                msgs.Add(tinhHangTonKhoTheoLSX(db, userTK, "", tsxs));
            }
            msg = string.Join("", msgs.Distinct().ToList());
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        return msg;
    }

    public string truVatTuSauKhiLayTon(EntityContext db, md_lenhsanxuat_tosx tsx, string spid, decimal sldc, string sp1, string sp2, string sp3)
    {
        var tsxPrevs = db.md_lenhsanxuat_tosx.Where(s =>
                s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id
                & s.xuongChinh == tsx.xuongPhu
                )
                .OrderByDescending(s => s.stt).ToList();

        var vtbks = db.md_lenhsanxuat_tosx_vattuBackup.Where(s =>
            s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
            & s.sp == spid
            & s.sp1 == sp1
            & s.sp2 == sp2
            & s.sp3 == sp3
            ).ToList();
        foreach (var vtbk in vtbks)
        {
            if (vtbk.vt == "2b8aa116502f4e3492725a34e35bc39e")
            {
                var ok = true;
            }
            var sltru = vtbk.soluong * sldc;
            var vtlsxServer = db.md_lenhsanxuat_tosx_vattu.Where(s =>
                s.md_sanpham_id == vtbk.vt
                & s.sp1 == sp1
                & s.sp2 == sp2
                & s.sp3 == sp3
                & s.md_lenhsanxuat_tosx_id == vtbk.md_lenhsanxuat_tosx_id).FirstOrDefault();
            var vtlsx = db.md_lenhsanxuat_tosx_vattu.Local.Where(s =>
                s.md_sanpham_id == vtbk.vt
                & s.sp1 == sp1
                & s.sp2 == sp2
                & s.sp3 == sp3
                & s.md_lenhsanxuat_tosx_id == vtbk.md_lenhsanxuat_tosx_id).FirstOrDefault();
            if (vtlsx != null)
            {
                vtlsx.soluong = vtlsx.soluong.GetValueOrDefault(0) - sltru;
                foreach (var tsxPrev in tsxPrevs)
                {
                    var cdhPrevServer = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                    s.md_lenhsanxuat_tosx_id == tsxPrev.md_lenhsanxuat_tosx_id
                    & s.md_sanpham_id == vtlsx.md_sanpham_id
                    & s.macuoi == sp1
                    & s.mathaydoi == sp2).FirstOrDefault();
                    var cdhPrev = db.md_lenhsanxuat_tosx_cdh.Local.Where(s =>
                    s.md_lenhsanxuat_tosx_id == tsxPrev.md_lenhsanxuat_tosx_id
                    & s.md_sanpham_id == vtlsx.md_sanpham_id
                    & s.macuoi == sp1
                    & s.mathaydoi == sp2).FirstOrDefault();
                    if (cdhPrev != null)
                    {
                        var sp1_1 = db.md_sanpham.Where(s => s.md_sanpham_id == cdhPrev.md_sanpham_id).Select(s => s.ma_sanpham).FirstOrDefault();
                        var sp2_1 = db.md_sanpham.Where(s => s.md_sanpham_id == spid).Select(s => s.ma_sanpham).FirstOrDefault();
                        cdhPrev.sl_chiato2 = cdhPrev.sl_chiato2.GetValueOrDefault(0) + sltru;
                        truVatTuSauKhiLayTon(db, tsxPrev, vtlsx.md_sanpham_id, sltru.GetValueOrDefault(0), sp1_1, sp2_1, sp3);
                    }
                }
            }
        }
        return "";
    }

    public string truVatTuSauKhiDatNCC(EntityContext db, md_lenhsanxuat_tosx tsx, string spid, decimal sldc, string sp1, string sp2, string sp3)
    {
        var tsxPrevs = db.md_lenhsanxuat_tosx.Where(s =>
                s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id
                & s.xuongChinh == tsx.xuongPhu
                )
                .OrderByDescending(s => s.stt).ToList();

        var vtbks = db.md_lenhsanxuat_tosx_vattuBackup.Where(s =>
            s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
            & s.sp == spid
            & s.sp1 == sp1
            & s.sp2 == sp2
            & s.sp3 == sp3).Distinct().ToList();
        foreach (var vtbk in vtbks)
        {
            var sltru = vtbk.soluong * sldc;
            var vtlsxServer = db.md_lenhsanxuat_tosx_vattu.Where(s =>
                s.md_sanpham_id == vtbk.vt
                & s.sp1 == sp1
                & s.sp2 == sp2
                & s.sp3 == sp3
                & s.md_lenhsanxuat_tosx_id == vtbk.md_lenhsanxuat_tosx_id).FirstOrDefault();
            var vtlsx = db.md_lenhsanxuat_tosx_vattu.Local.Where(s =>
                s.md_sanpham_id == vtbk.vt
                & s.sp1 == sp1
                & s.sp2 == sp2
                & s.sp3 == sp3
                & s.md_lenhsanxuat_tosx_id == vtbk.md_lenhsanxuat_tosx_id).FirstOrDefault();
            if (vtlsx != null)
            {
                vtlsx.soluong = vtlsx.soluong.GetValueOrDefault(0) - sltru;
                foreach (var tsxPrev in tsxPrevs)
                {
                    var cdhPrevServer = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                    s.md_lenhsanxuat_tosx_id == tsxPrev.md_lenhsanxuat_tosx_id
                    & s.md_sanpham_id == vtlsx.md_sanpham_id
                    & s.macuoi == sp1
                    & s.mathaydoi == sp2).FirstOrDefault();
                    var cdhPrev = db.md_lenhsanxuat_tosx_cdh.Local.Where(s =>
                    s.md_lenhsanxuat_tosx_id == tsxPrev.md_lenhsanxuat_tosx_id
                    & s.md_sanpham_id == vtlsx.md_sanpham_id
                    & s.macuoi == sp1
                    & s.mathaydoi == sp2).FirstOrDefault();
                    if (cdhPrev != null)
                    {
                        var sp1_1 = db.md_sanpham.Where(s => s.md_sanpham_id == cdhPrev.md_sanpham_id).Select(s => s.ma_sanpham).FirstOrDefault();
                        var sp2_1 = db.md_sanpham.Where(s => s.md_sanpham_id == spid).Select(s => s.ma_sanpham).FirstOrDefault();
                        cdhPrev.sl_datncc2 = cdhPrev.sl_datncc2.GetValueOrDefault(0) + sltru;
                        truVatTuSauKhiLayTon(db, tsxPrev, vtlsx.md_sanpham_id, sltru.GetValueOrDefault(0), sp1_1, sp2_1, sp3);
                    }
                }
            }
        }
        return "";
    }

    public string HieuLucPhieuVanChuyen(
        EntityContext db,
        User_TK userTK,
        string ma_module,
        string id,
        string koCapnhatDLSXStr,
        md_vanchuyennoibo vcnb = null,
        List<md_vanchuyennoibo_cdvc> vcnb_cdvcs = null
        )
    {
        string msg = "";

        var koCapnhatDLSX = koCapnhatDLSXStr == "true";

        if (msgErrsPL == null)
        {
            msgErrsPL = new List<BaoLoiKhiHieuLuc>();
        }

        try
        {
            if (vcnb == null)
                vcnb = db.md_vanchuyennoibo.Where(s => s.md_vanchuyennoibo_id == id).FirstOrDefault();

            if (vcnb == null)
            {
                msg = $@"Không tìm thấy phiếu vận chuyển";
                goto EndEventHandler;
            }
            if (vcnb.md_trangthai_id != Helper.DANHAN)
            {
                msg = $@"Dòng ""{vcnb.sochungtu}"" cần ở trạng thái ""Đã Xác Nhận""";
                goto EndEventHandler;
            }

            var khoXuat = db.md_kho.Where(s => s.md_kho_id == vcnb.tukho).FirstOrDefault();
            var khoNhan = db.md_kho.Where(s => s.md_kho_id == vcnb.denkho).FirstOrDefault();

            if (khoXuat == null)
            {
                msg = $@"Lỗi: dòng ""{vcnb.sochungtu}"" không xác định được ""Kho xuất""";
                goto EndEventHandler;
            }
            if (khoNhan == null)
            {
                msg = $@"Lỗi: dòng ""{vcnb.sochungtu}"" không xác định được ""Kho nhập""";
                goto EndEventHandler;
            }

            if (vcnb_cdvcs == null)
                vcnb_cdvcs = db.md_vanchuyennoibo_cdvc.Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id).ToList();

            var slChuyen = vcnb_cdvcs.Sum(s => s.soluong_dichchuyen.GetValueOrDefault(0));
            if (slChuyen <= 0)
            {
                msg = $@"Phiếu ""{vcnb.sochungtu}"" phải có ít nhất 1 dòng hàng có SL thực chuyển lớn hơn 0";
                goto EndEventHandler;
            }

            var giaoHang = vcnb.loaichuyen == "VANCNBCTKGH";
            vcnb.ngayhieuluc = DateTime.Now;

            c_danhsachdathang dsdh = null;
            string dsdhId = "", lsxId = "", tsxId = "";
            md_lenhsanxuat_tosx tsxInLSX = null;
            if (giaoHang)
            {
                dsdh = db.c_danhsachdathang.Where(s => s.so_po == vcnb.donhang_thamchieu).FirstOrDefault();
                dsdhId = dsdh == null ? "" : dsdh.c_danhsachdathang_id;
                lsxId = db.md_lenhsanxuat.Where(s => s.donhang_thamchieu == vcnb.donhang_thamchieu).Select(s => s.md_lenhsanxuat_id).FirstOrDefault();
                tsxInLSX = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsxId & s.hoatdong == true).OrderByDescending(s => s.stt).FirstOrDefault();
                tsxId = tsxInLSX == null ? "" : tsxInLSX.md_lenhsanxuat_tosx_id;
            }

            var khoSPDic = new Dictionary<string, decimal>();
            bool layTonTP = false, layTonBTP = false;
            foreach (var vcnb_cdvc in vcnb_cdvcs)
            {
                var spMain = db.md_sanpham.Where(s => s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                vcnb_cdvc.soluong_dachuyen = vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);

                string toSXId = "", toSXId2 = "", lsx = "";
                int sanxuat = 0;
                if (vcnb.loaichuyen == "VANCNBTC" & vcnb_cdvc.soluong_dichchuyen > 0)
                {
                    if (vcnb.laytonTPhoacBTP.GetValueOrDefault(false))
                    {
                        var tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == vcnb_cdvc.tukho).FirstOrDefault();
                        layTonTP = tsx.phieulayhttp == vcnb.sochungtu;
                        layTonBTP = tsx.phieulayht == vcnb.sochungtu;
                        if (layTonTP | layTonBTP)
                        {
                            var khdhid = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id).Select(s => s.c_kehoachdathang_id).FirstOrDefault();
                            var khdh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == khdhid).FirstOrDefault();
                            if (khdh != null)
                            {
                                if (layTonTP)
                                {
                                    var dklhttp = db.md_lenhsanxuat_tosx_dklhttp.Where(s =>
                                    s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                    & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                                    if (dklhttp != null)
                                    {
                                        dklhttp.sl_layton1 = vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);
                                        truVatTuSauKhiLayTon(db, tsx, vcnb_cdvc.md_sanpham_id, dklhttp.sl_layton1.GetValueOrDefault(0), spMain.ma_sanpham, spMain.ma_sanpham, spMain.ma_sanpham);
                                    }
                                    khdh.trangthai = Helper.DaXLTTP;
                                }
                                else if (layTonBTP)
                                {
                                    var sldcSav = vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);
                                    var dklhtbtps = db.md_lenhsanxuat_tosx_dklht.Where(s =>
                                    s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                    & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).ToList();
                                    foreach (var dklhtbtp in dklhtbtps)
                                    {
                                        if (sldcSav > 0)
                                        {
                                            var sllsx = dklhtbtp.sl_layton.GetValueOrDefault(0);
                                            var sldc = sldcSav > sllsx ? sllsx : sldcSav;
                                            sldcSav = sldcSav - sldc;
                                            dklhtbtp.sl_layton1 = sldc;
                                            truVatTuSauKhiLayTon(db, tsx, vcnb_cdvc.md_sanpham_id, sldc, spMain.ma_sanpham, dklhtbtp.macuoi, dklhtbtp.macuoi);

                                            var cdhBTPServer = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                                s.md_lenhsanxuat_tosx_id == vcnb_cdvc.tukho
                                                & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id
                                                & s.macuoi == dklhtbtp.macuoi
                                                & s.mathaydoi == dklhtbtp.macuoi).FirstOrDefault();
                                            var cdhBTP = db.md_lenhsanxuat_tosx_cdh.Local.Where(s =>
                                                s.md_lenhsanxuat_tosx_id == vcnb_cdvc.tukho
                                                 & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id
                                                & s.macuoi == dklhtbtp.macuoi
                                                & s.mathaydoi == dklhtbtp.macuoi).FirstOrDefault();

                                            if (cdhBTP != null)
                                            {
                                                sanxuat = 4;
                                                cdhBTP.sl_chiato = cdhBTP.sl_chiato.GetValueOrDefault(0) - sldc;
                                                cdhBTP.sl_nhapkho = cdhBTP.sl_nhapkho.GetValueOrDefault(0) + sldc;
                                                cdhBTP.sl_dahoanthanh = cdhBTP.sl_dahoanthanh.GetValueOrDefault(0) + sldc;
                                            }
                                        }
                                    }
                                    khdh.trangthai = Helper.DaXLTBTP;
                                }
                            }
                        }
                    }

                    var cdhLSXServer = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                        s.md_lenhsanxuat_tosx_id == vcnb_cdvc.tukho
                        & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                    var cdhLSX = db.md_lenhsanxuat_tosx_cdh.Local.Where(s =>
                        s.md_lenhsanxuat_tosx_id == vcnb_cdvc.tukho
                        & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();

                    var ctHN = db.md_hanngachPXTo_chitiet.Where(s => s.md_hanngachPXTo_chitiet_id == vcnb_cdvc.denkho).FirstOrDefault();

                    var chuyenVeKT = false;
                    if (ctHN != null)
                    {
                        if (vcnb.laytonTP.GetValueOrDefault(false))
                            ctHN.sllaytonTP = ctHN.sllaytonTP.GetValueOrDefault(0) - (int)vcnb_cdvc.soluong_toida.GetValueOrDefault(0) + (int)vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);
                        else
                        {
                            ctHN.sllayton = ctHN.sllayton.GetValueOrDefault(0) + (int)vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);

                            var cTVK = db.md_hanngachPXTo_chuyenvekhoton.Where(s =>
                                s.md_hanngachPXTo_chitiet_id == ctHN.md_hanngachPXTo_chitiet_id
                                & s.toId == khoXuat.md_to_id).FirstOrDefault();

                            if (cTVK != null)
                            {
                                cTVK.sldachuyen = cTVK.sldachuyen.GetValueOrDefault(0) + (int)vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);
                                if (khoNhan.md_to_id != khoXuat.md_to_id)
                                    cTVK.slchuyen = cTVK.slchuyen.GetValueOrDefault(0) + (int)vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);

                                var dhCTVK = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                    s.md_lenhsanxuat_tosx_id == cTVK.tosxId & s.md_sanpham_id == cTVK.md_sanpham_id).FirstOrDefault();
                                if (dhCTVK != null)
                                    dhCTVK.sl_nkton = dhCTVK.sl_nkton.GetValueOrDefault(0) + vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);

                                chuyenVeKT = true;
                            }
                        }
                    }

                    if (cdhLSX != null & chuyenVeKT == false & !vcnb.laytonTP.GetValueOrDefault(false) & !layTonBTP)
                    {
                        if (koCapnhatDLSX)
                        {
                            sanxuat = 6;
                        }
                        else
                        {
                            sanxuat = 4;
                            cdhLSX.sl_chiato = cdhLSX.sl_chiato.GetValueOrDefault(0) - vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);
                            cdhLSX.sl_nhapkho = cdhLSX.sl_nhapkho.GetValueOrDefault(0) + vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);
                            cdhLSX.sl_dahoanthanh = cdhLSX.sl_dahoanthanh.GetValueOrDefault(0) + vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);
                        }
                    }
                }
                //start Xuat kho
                decimal sl_dichchuyen_thucte = vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);
                //xuất kho
                var lstSPId = new List<string>();
                if (giaoHang)
                {
                    sanxuat = 3;
                    var cais = db.md_lenhsanxuat_tosx_cdh.Where(
                            s =>
                                s.md_lenhsanxuat_tosx_id == tsxId
                                & s.mabo.Contains(spMain.ma_sanpham)
                            ).ToList();

                    foreach (var cai in cais)
                    {
                        cai.sl_dagiao = cai.sl_dagiao.GetValueOrDefault(0) + sl_dichchuyen_thucte;
                        lstSPId.Add(cai.md_sanpham_id);
                    }
                    var ddsdhServer = db.c_dongdsdh.Where(s =>
                    s.c_danhsachdathang_id == dsdhId
                    & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                    var ddsdh = db.c_dongdsdh.Local.Where(s =>
                    s.c_danhsachdathang_id == dsdhId
                    & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                    if (ddsdh != null)
                    {
                        ddsdh.sl_nhaphang = ddsdh.sl_nhaphang.GetValueOrDefault(0) + vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);
                        if (dsdh.sanxuatton.GetValueOrDefault(false))
                        {
                            ddsdh.sl_conlai = ddsdh.sl_conlai.GetValueOrDefault(0) - ddsdh.sl_nhaphang.GetValueOrDefault(0);
                        }
                    }
                }
                else
                {
                    if (sl_dichchuyen_thucte > 0)
                        lstSPId.Add(vcnb_cdvc.md_sanpham_id);
                }

                var kspsServer = db.md_kho_sanpham.Where(s => s.md_kho_id == vcnb.tukho & lstSPId.Contains(s.md_sanpham_id)).ToList();
                var ksps = db.md_kho_sanpham.Local.Where(s => s.md_kho_id == vcnb.tukho & lstSPId.Contains(s.md_sanpham_id)).ToList();
                if (ksps.Count <= 0)
                {
                    msg += $@"<br>Lỗi: dòng ""{spMain.ma_sanpham}"", trong kho không chứa mã hàng nào liên quan đến mã hàng này.";
                    msgErrsPL.Add(new Public.BaoLoiKhiHieuLuc()
                    {
                        msp = spMain.ma_sanpham,
                        loi = $"Kho không chứa mã hàng nào liên quan đến mã hàng này."
                    });
                }
                else
                {
                    foreach (var kho_sp in ksps)
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
                            msg += $@"<br>Lỗi: dòng ""{sp.ma_sanpham}"" số lượng trong kho chỉ còn : ""{itemSP.Value.DropTrailingZeros()}"".";

                            msgErrsPL.Add(new Public.BaoLoiKhiHieuLuc()
                            {
                                msp = spMain.ma_sanpham,
                                loi = $"Số lượng trong kho thiếu: ${itemSP.Value.DropTrailingZeros()}"
                            });
                        }

                        if (sl_xuatkho > 0)
                        {
                            var kho_gd = new md_kho_giaodich();
                            kho_gd.md_kho_giaodich_id = Helper.getNewId();
                            kho_gd.md_kho_id = kho_sp.md_kho_id;
                            kho_gd.md_sanpham_id = kho_sp.md_sanpham_id;
                            kho_gd.soluong_dichchuyen = sl_xuatkho;
                            kho_gd.ngaychuyen = vcnb.ngaychuyen.Value;
                            kho_gd.kieuchuyen = Helper.XuatKho;
                            kho_gd.dongnhapxuat = " ";
                            kho_gd.dongkiemkho = " ";
                            kho_gd.dongvanchuyen = vcnb.sochungtu;
                            kho_gd.dongsanxuat = " ";
                            kho_gd.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id;
                            kho_gd.sapxep = "";
                            kho_gd.md_to_id = khoXuat.md_to_id;
                            kho_gd.md_to_id2 = khoXuat.md_to_id;
                            kho_gd.lsx = lsx;
                            kho_gd.sanxuat = sanxuat;
                            kho_gd.tosxId = toSXId;
                            kho_gd.tosxId2 = toSXId2;
                            kho_gd.gianhancong = vcnb_cdvc.gianhancong;
                            kho_gd.pbgNC = vcnb.phienbangiaNC;
                            kho_gd.mota = vcnb_cdvc.tenhang;
                            kho_gd.hoatdong = true;

                            kho_gd = Helper.setDefaultValueWhenInsertOrUpdate(kho_gd, userTK, false);
                            db.md_kho_giaodich.Add(kho_gd);
                        }

                        kho_sp.soluong = kho_sp.soluong.Value - sl_xuatkho;
                    }
                }

                //Nhap Kho
                if (sl_dichchuyen_thucte > 0)
                {
                    var kho_sp_nhapkhoServer = db.md_kho_sanpham.Where(s => s.md_kho_id == vcnb.denkho & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).Take(1).FirstOrDefault();
                    var kho_sp_nhapkho = db.md_kho_sanpham.Local.Where(s => s.md_kho_id == vcnb.denkho & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).Take(1).FirstOrDefault();
                    string khospId = Helper.getNewId();
                    if (kho_sp_nhapkho == null)
                    {
                        kho_sp_nhapkho = new md_kho_sanpham
                        {
                            md_kho_sanpham_id = khospId,
                            md_kho_id = vcnb.denkho,
                            md_sanpham_id = vcnb_cdvc.md_sanpham_id,
                            soluong = vcnb_cdvc.soluong_dichchuyen.Value,
                            hoatdong = true
                        };
                        kho_sp_nhapkho = Helper.setDefaultValueWhenInsertOrUpdate(kho_sp_nhapkho, userTK, false);
                        db.md_kho_sanpham.Add(kho_sp_nhapkho);
                    }
                    else
                    {
                        kho_sp_nhapkho.soluong = kho_sp_nhapkho.soluong.GetValueOrDefault(0) + vcnb_cdvc.soluong_dichchuyen.Value;
                    }
                    //Lich su kho
                    var kho_gd_nhapkho = new md_kho_giaodich
                    {
                        md_kho_giaodich_id = Helper.getNewId(),
                        md_kho_id = vcnb.denkho,
                        md_sanpham_id = vcnb_cdvc.md_sanpham_id,
                        soluong_dichchuyen = vcnb_cdvc.soluong_dichchuyen.Value,
                        md_donvitinhsanpham_id = vcnb_cdvc.md_donvitinhsanpham_id,
                        ngaychuyen = vcnb.ngaychuyen.Value,
                        kieuchuyen = Helper.NhapKho,
                        dongnhapxuat = vcnb.sochungtu,
                        dongkiemkho = vcnb.sochungtu,
                        dongvanchuyen = vcnb.sochungtu,
                        dongsanxuat = vcnb.sochungtu,
                        sapxep = "",
                        sanxuat = sanxuat,
                        mota = vcnb_cdvc.tenhang,
                        hoatdong = true
                    };
                    kho_gd_nhapkho = Helper.setDefaultValueWhenInsertOrUpdate(kho_gd_nhapkho, userTK, false);
                    db.md_kho_giaodich.Add(kho_gd_nhapkho);
                    //end Nhap kho
                }
            }


            if (giaoHang)
            {
                var lsx2s = db.md_lenhsanxuat2.Where(s => s.c_danhsachdathang_id.Contains(dsdhId)).ToList();
                foreach (var lsx2 in lsx2s)
                {
                    var cdhLsxsServer = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                    s.lsxCT == lsx2.sochungtu & s.stt == tsxInLSX.stt).ToList();
                    var cdhLsxs = db.md_lenhsanxuat_tosx_cdh.Local.Where(s =>
                    s.lsxCT == lsx2.sochungtu & s.stt == tsxInLSX.stt).ToList();
                    var daHT = cdhLsxs.Where(s =>
                        s.sl_danhapkho.GetValueOrDefault(0) +
                        s.sl_nhapkho.GetValueOrDefault(0) -
                        s.sl_dagiao.GetValueOrDefault(0) > 0).Count() <= 0;
                    if (daHT & cdhLsxs.Count > 0)
                        lsx2.trangthai = Helper.KETTHUC;
                }

                if (dsdh.sanxuatton.GetValueOrDefault(false))
                {
                    var donghangsServer = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdhId).ToList();
                    var donghangs = db.c_dongdsdh.Local.Where(s => s.c_danhsachdathang_id == dsdhId).ToList();
                    var daHT = donghangs.Where(s => s.sl_conlai.GetValueOrDefault(0) - s.sl_thuhoi.GetValueOrDefault(0) > 0).Count() <= 0;
                    if (daHT & donghangs.Count > 0)
                        dsdh.trangthai = Helper.KETTHUC;
                }
            }

            if (msg.Length <= 0)
            {
                vcnb.md_trangthai_id = Helper.HIEULUC;
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = ex.ToString();
        }

    EndEventHandler:;
        return msg;
    }

    public string xoaLayTonThanhPhamVaHangTho(EntityContext db, User_TK userTK, System.Web.HttpContext context, md_lenhsanxuat lsx, md_lenhsanxuat_tosx tsx, string oper, string ma_module)
    {
        string msg = "", sctLT = "";
        bool xoaTonTP = false;
        if (tsx.stt == 9999)
        {
            if (!string.IsNullOrEmpty(tsx.phieulayhttp))
            {
                xoaTonTP = true;
            }
        }

        sctLT = xoaTonTP ? tsx.phieulayhttp : tsx.phieulayht;

        if (tsx.phieulayhttp == "-")
        {
            tsx.phieulayhttp = "";
            db.md_lenhsanxuat_tosx_dklhttp.RemoveRange(db.md_lenhsanxuat_tosx_dklhttp.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id));
        }
        else if (tsx.phieulayht == "-")
        {
            tsx.phieulayht = "";
            db.md_lenhsanxuat_tosx_dklht.RemoveRange(db.md_lenhsanxuat_tosx_dklht.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id));
        }
        else if (!string.IsNullOrWhiteSpace(sctLT))
        {
            var lhttps = new List<md_lenhsanxuat_tosx_dklhttp>();
            var lhts = new List<md_lenhsanxuat_tosx_dklht>();
            foreach (var cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).ToList())
            {
                decimal sllt = 0;
                if (xoaTonTP)
                {
                    if (lhttps.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).Count() <= 0)
                    {
                        var lhtSav = db.md_lenhsanxuat_tosx_dklhttp.Where(s =>
                            s.md_sanpham_id == cdh.md_sanpham_id
                            & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                            & s.sl_layton > 0
                        ).FirstOrDefault();

                        if (lhtSav != null)
                            lhttps.Add(lhtSav);
                    }

                    var lht = lhttps.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).FirstOrDefault();
                    if (lht != null)
                        sllt = lht.sl_layton.GetValueOrDefault(0);
                }
                else
                {
                    if (lhts.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).Count() <= 0)
                    {
                        var lhtSav = db.md_lenhsanxuat_tosx_dklht.Where(s =>
                            s.md_sanpham_id == cdh.md_sanpham_id
                            & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                            & s.sl_layton > 0
                        ).FirstOrDefault();

                        if (lhtSav != null)
                            lhts.Add(lhtSav);
                    }

                    var lht = lhts.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).FirstOrDefault();
                    if (lht != null)
                        sllt = lht.sl_layton.GetValueOrDefault(0);
                }

                if (sllt > 0)
                {
                    cdh.sl_chiato = cdh.sl_chiato.GetValueOrDefault(0) + sllt;
                    //cdh.sl_chiato2 = cdh.sl_chiato - sllt;
                    cdh.sl_dahoanthanh = cdh.sl_dahoanthanh.GetValueOrDefault(0) - sllt;
                    cdh.sl_nhapkho = cdh.sl_nhapkho.GetValueOrDefault(0) - sllt;
                }
            }

            var tblNhapXuat = db.md_vanchuyennoibo.Where(s =>
                    s.sochungtu == sctLT
                    & s.loaichuyen == "VANCNBTC"
                    & s.md_trangthai_id == Helper.HIEULUC
                ).FirstOrDefault();

            var sctId = tblNhapXuat.md_vanchuyennoibo_id;
            var khoIdNhap = db.md_kho.Where(s => s.md_kho_id == tblNhapXuat.denkho).FirstOrDefault();
            var khoIdXuat = db.md_kho.Where(s => s.md_kho_id == tblNhapXuat.tukho).FirstOrDefault();

            if (string.IsNullOrEmpty(sctId))
                msg = "Không tìn thấy phiếu" + sctLT;
            else if (khoIdNhap == null)
                msg = "Không tìn thấy kho nhập (đến kho)";
            else if (khoIdXuat == null)
                msg = "Không tìn thấy kho nhập (từ kho)";
            else
            {
                foreach (var dhvc in db.md_vanchuyennoibo_cdvc.Where(s =>
                        s.md_vanchuyennoibo_id == sctId).ToList())
                {
                    var khoSPNhap = db.md_kho_sanpham.Where(s =>
                    s.md_kho_id == khoIdNhap.md_kho_id
                    & s.md_sanpham_id == dhvc.md_sanpham_id).FirstOrDefault();

                    var khoSPXuat = db.md_kho_sanpham.Where(s =>
                    s.md_kho_id == khoIdXuat.md_kho_id
                    & s.md_sanpham_id == dhvc.md_sanpham_id).FirstOrDefault();

                    khoSPNhap.soluong = khoSPNhap.soluong.GetValueOrDefault(0) - dhvc.soluong_dachuyen.GetValueOrDefault(0);
                    khoSPXuat.soluong = khoSPXuat.soluong.GetValueOrDefault(0) + dhvc.soluong_dachuyen.GetValueOrDefault(0);

                    if (khoSPNhap.soluong < 0)
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dhvc.md_sanpham_id).FirstOrDefault();
                        msg = "Số lượng sp " + sp.ma_sanpham + " trong kho " + khoIdNhap.ten_kho + " nhỏ hơn số lượng đã từng được chuyển (" + dhvc.soluong_dachuyen.GetValueOrDefault(0).DropTrailingZeros() + ")";
                        break;
                    }
                }
            }

            if (msg.Length <= 0)
            {
                if (xoaTonTP)
                {
                    tsx.phieulayhttp = "";
                    db.md_lenhsanxuat_tosx_dklhttp.RemoveRange(db.md_lenhsanxuat_tosx_dklhttp.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id));
                }
                else
                {
                    tsx.phieulayht = "";
                    db.md_lenhsanxuat_tosx_dklht.RemoveRange(db.md_lenhsanxuat_tosx_dklht.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id));
                }
                tsx.tolayton = "";
                db.md_kho_giaodich.RemoveRange(db.md_kho_giaodich.Where(s => s.dongvanchuyen == sctLT));
                db.md_vanchuyennoibo.Remove(tblNhapXuat);

                VNN_Function.Write_log(context, ma_module, "", oper, "PLHT:" + sctLT, db, true, userTK);

                if (lsx.md_trangthai_id == Helper.KHDXL)
                    lsx.md_trangthai_id = Helper.CHUAHOANTHANH;
            }
        }

        if (xoaTonTP)
        {
            var tsxPrev = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id & s.stt == 9998).FirstOrDefault();
            if (tsxPrev != null)
            {
                db.md_lenhsanxuat_tosx_dklht.RemoveRange(db.md_lenhsanxuat_tosx_dklht.Where(s => s.md_lenhsanxuat_tosx_id == tsxPrev.md_lenhsanxuat_tosx_id));
            }
        }

        return msg;
    }
}