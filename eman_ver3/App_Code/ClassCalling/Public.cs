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

    private class lsxTSX
    {
        public md_lenhsanxuat lsx { get; set; }
        public md_lenhsanxuat_tosx tsx { get; set; }
    }

    public string tinhBomTrongTSX(EntityContext db, md_lenhsanxuat_tosx tsx)
    {
        var cdhsServer = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).ToList();
        var cdhs = db.md_lenhsanxuat_tosx_cdh.Local.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id).ToList();

        db.md_lenhsanxuat_tosx_vattu.RemoveRange(db.md_lenhsanxuat_tosx_vattu.Where(s => s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id));

        foreach (var cdh in cdhs)
        {
            
            var bomSPs = (from a in db.md_sanpham_bom_vattu
                          join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                          join c in db.md_kho on b.khomacdinh equals c.md_kho_id
                          where
                             a.md_sanpham_bom_id == cdh.bomId
                             & a.sanphamId == cdh.md_sanpham_id
                          select new { a, c.ma_kho, b.ban_thanhpham }).ToList();

            if (bomSPs.Count > 0)
            {
                foreach (var vattuspT in bomSPs.Where(s => s.a.soluong > 0))
                {
                    var vattusp = vattuspT.a;
                    System.Linq.Expressions.Expression<Func<md_lenhsanxuat_tosx_vattu, bool>> conditionBSP =
                        s => s.md_sanpham_id == vattusp.md_sanpham_id
                            & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id;

                    var toSXVTs = db.md_lenhsanxuat_tosx_vattu.Where(conditionBSP).ToList();

                    var toSXVTsLocal = db.md_lenhsanxuat_tosx_vattu.Local.AsQueryable().Where(conditionBSP).ToList();

                    var vtlsxto = toSXVTsLocal.FirstOrDefault();
                    var addVTLSX = vtlsxto == null;
                    if (addVTLSX)
                    {
                        vtlsxto = new md_lenhsanxuat_tosx_vattu();
                        vtlsxto.md_lenhsanxuat_tosx_vattu_id = Helper.getNewId();
                        vtlsxto.md_lenhsanxuat_tosx_id = cdh.md_lenhsanxuat_tosx_id;
                        vtlsxto.md_sanpham_id = vattusp.md_sanpham_id;
                        vtlsxto.md_donvitinhsanpham_id = vattusp.md_donvitinhsanpham_id;
                        vtlsxto.sl_hanngach = 0;
                        vtlsxto.sl_giamhanngach = 0;
                        vtlsxto.soluong = 0;
                        vtlsxto.hoatdong = !vattuspT.ban_thanhpham.GetValueOrDefault(false);
                    }
                    vtlsxto.soluong = vtlsxto.soluong.GetValueOrDefault(0) +
                        (decimal)vattusp.soluong.GetValueOrDefault(0) *
                        cdh.sl_chiato.GetValueOrDefault(0);

                    if (addVTLSX)
                        db.md_lenhsanxuat_tosx_vattu.Add(vtlsxto);
                }
            }
        }
        return "";
    }

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

    private string kiemtraBomVaGia(EntityContext db, md_lenhsanxuat_tosx item1, bool kiemtragia, string msgEX)
    {
        var bgncs = layBGGiaNhanCongs(db);
        var pbgnc = layPBGGiaNhanCong(db, bgncs);
        string pbgId = pbgnc == null ? "" : pbgnc.md_phienbangia_id;

        System.Linq.Expressions.Expression<Func<md_lenhsanxuat_tosx_cdh, bool>> conditionLSXTSXCDH =
                s => s.md_lenhsanxuat_tosx_id == item1.md_lenhsanxuat_tosx_id;

        var lsxTSXCDH = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == item1.md_lenhsanxuat_tosx_id).ToList();

        var lsxTSXCDHLocal = db.md_lenhsanxuat_tosx_cdh.Local.Where(s => s.md_lenhsanxuat_tosx_id == item1.md_lenhsanxuat_tosx_id).ToList();

        db.md_lenhsanxuat_tosx_vattu.RemoveRange(db.md_lenhsanxuat_tosx_vattu.Where(s => s.md_lenhsanxuat_tosx_id == item1.md_lenhsanxuat_tosx_id));

        db.md_lenhsanxuat_tosx_vattuBackup.RemoveRange(db.md_lenhsanxuat_tosx_vattuBackup.Where(s => s.md_lenhsanxuat_tosx_id == item1.md_lenhsanxuat_tosx_id));

        foreach (var item2 in lsxTSXCDHLocal)
        {
            var giasp = db.md_giasanpham.Where(s =>
                s.md_sanpham_id == item2.md_sanpham_id
                & s.md_donvitinhsanpham_id == item2.md_donvitinhsanpham_id
                & s.md_phienbangia_id == pbgId
                ).FirstOrDefault();

            if (giasp == null)
            {
                if (kiemtragia == true)
                {
                    var sp = db.md_sanpham.Where(s => s.md_sanpham_id == item2.md_sanpham_id).FirstOrDefault();
                    string err = string.Format(@"<br class='error'>HHVT ""{0}"" chưa có giá cho ""{1}"""
                        , sp.ma_sanpham
                        , db.ad_department.Where(s => s.md_phongban_id == item1.phongbanId).Select(s => s.ten_phongban).FirstOrDefault());
                    msgEX += err;
                }
            }
            else
            {
                item2.gianhancong = giasp.gia;
                item2.pbgId = giasp.md_phienbangia_id;
            }


            var spBom = db.md_sanpham_bom.
                        Where(s =>
                        s.md_sanpham_id == item2.md_sanpham_id &
                        s.phongbanId == item1.phongbanId &
                        s.ngay_hieuluc <= DateTime.Now
                        ).OrderByDescending(s => s.ngay_hieuluc).Take(1).FirstOrDefault();

            string bomSpId = spBom == null ? "" : spBom.md_sanpham_bom_id;

            var bomSPs = (from a in db.md_sanpham_bom_vattu
                          join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                          join c in db.md_kho on b.khomacdinh equals c.md_kho_id
                          where
                             a.md_sanpham_bom_id == bomSpId
                             & a.sanphamId == item2.md_sanpham_id
                          select new { a, b.ban_thanhpham, c.ma_kho }).ToList();

            item2.noigiaohang = bomSpId;
            item2.bomId = bomSpId;

            if (bomSPs.Count > 0)
            {
                foreach (var vattuspT in bomSPs.Where(s => s.a.soluong > 0))
                {
                    var vattusp = vattuspT.a;
                    System.Linq.Expressions.Expression<Func<md_lenhsanxuat_tosx_vattu, bool>> conditionBSP =
                        s => s.md_sanpham_id == vattusp.md_sanpham_id
                            & s.md_lenhsanxuat_tosx_id == item2.md_lenhsanxuat_tosx_id;

                    var toSXVTs = db.md_lenhsanxuat_tosx_vattu.Where(conditionBSP).ToList();

                    var toSXVTsLocal = db.md_lenhsanxuat_tosx_vattu.Local.AsQueryable().Where(conditionBSP).ToList();

                    var vtlsxto = toSXVTsLocal.FirstOrDefault();
                    var addVTLSX = vtlsxto;
                    if (addVTLSX == null)
                    {
                        vtlsxto = new md_lenhsanxuat_tosx_vattu();
                        vtlsxto.md_lenhsanxuat_tosx_vattu_id = Helper.getNewId();
                        vtlsxto.md_lenhsanxuat_tosx_id = item2.md_lenhsanxuat_tosx_id;
                        vtlsxto.md_sanpham_id = vattusp.md_sanpham_id;
                        vtlsxto.md_donvitinhsanpham_id = vattusp.md_donvitinhsanpham_id;
                        vtlsxto.sl_hanngach = 0;
                        vtlsxto.sl_giamhanngach = 0;
                        vtlsxto.hoatdong = !vattuspT.ban_thanhpham.GetValueOrDefault(false);
                    }
                    vtlsxto.soluong = vtlsxto.soluong.GetValueOrDefault(0) +
                        (decimal)vattusp.soluong.GetValueOrDefault(0) *
                        item2.sl_chiato.GetValueOrDefault(0);

                    if (addVTLSX == null)
                        db.md_lenhsanxuat_tosx_vattu.Add(vtlsxto);

                    var vtbk = new md_lenhsanxuat_tosx_vattuBackup();
                    vtbk.md_lenhsanxuat_tosx_vattuBackup_id = Helper.getNewId();
                    vtbk.md_lenhsanxuat_tosx_id = item2.md_lenhsanxuat_tosx_id;
                    vtbk.sp = item2.md_sanpham_id;
                    vtbk.vt = vattusp.md_sanpham_id;
                    vtbk.ngaytao = DateTime.Now;
                    vtbk.soluong = (decimal)vattusp.soluong.GetValueOrDefault(0);
                    vtbk.md_donvitinhsanpham_id = vattusp.md_donvitinhsanpham_id;
                    db.md_lenhsanxuat_tosx_vattuBackup.Add(vtbk);
                }
            }
            else
            {
                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == item2.md_sanpham_id).FirstOrDefault();

                string err = string.Format(@"<br class='error'>HHVT ""{0}"" chưa có BOM cho ""{1}""",
                    sp.ma_sanpham,
                    db.ad_department.Where(s => s.md_phongban_id == item1.phongbanId).Select(s => s.ten_phongban).FirstOrDefault());
                if (!msgEX.Contains(err))
                {
                    msgEX += err;
                }
            }
        }

        return msgEX;
    }

    public string taoDongHangXuongTron(EntityContext db, User_TK userTK, string tsxDucId, string tsxTronId, string msgEx)
    {
        //Xuong Tron
        var DuclsxTSXCDHServer = db.md_lenhsanxuat_tosx_vattu.Where(s => s.md_lenhsanxuat_tosx_id == tsxDucId & s.hoatdong == false).ToList();

        var DuclsxTSXCDH = db.md_lenhsanxuat_tosx_vattu.Local.Where(s => s.md_lenhsanxuat_tosx_id == tsxDucId & s.hoatdong == false).ToList();

        var bomGiaSavs = new List<md_lenhsanxuat_tosx_cdh>();
        bomGiaSavs.AddRange(db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tsxTronId).ToList());

        db.md_lenhsanxuat_tosx_cdh.RemoveRange(db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tsxTronId));

        foreach (var vtduc in DuclsxTSXCDH)
        {
            var TronlsxTSXCDHServer = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tsxTronId & s.md_sanpham_id == vtduc.md_sanpham_id).FirstOrDefault();

            var TronlsxTSXCDH = db.md_lenhsanxuat_tosx_cdh.Local.Where(s => s.md_lenhsanxuat_tosx_id == tsxTronId & s.md_sanpham_id == vtduc.md_sanpham_id).FirstOrDefault();
            
            var add = TronlsxTSXCDH == null;

            if (add)
            {
                var itemSav = bomGiaSavs.Where(s => s.md_lenhsanxuat_tosx_id == tsxTronId & s.md_sanpham_id == vtduc.md_sanpham_id).FirstOrDefault();

                TronlsxTSXCDH = new md_lenhsanxuat_tosx_cdh();
                TronlsxTSXCDH.md_lenhsanxuat_tosx_cdh_id = Helper.getNewId();
                TronlsxTSXCDH.md_lenhsanxuat_tosx_id = tsxTronId;
                TronlsxTSXCDH.md_sanpham_id = vtduc.md_sanpham_id;
                TronlsxTSXCDH.noigiaohang = "";
                TronlsxTSXCDH.sl_hoanthanh = 0;
                TronlsxTSXCDH.sl_nhapkho = 0;
                TronlsxTSXCDH.sl_danhapkho = 0;
                TronlsxTSXCDH.macuoi = "";
                TronlsxTSXCDH.bomId = itemSav == null ? "" : itemSav.bomId;
                TronlsxTSXCDH.pbgId = itemSav == null ? "" : itemSav.pbgId;
                TronlsxTSXCDH.gianhancong = itemSav == null ? 0 : itemSav.gianhancong;
                TronlsxTSXCDH.md_donvitinhsanpham_id = vtduc.md_donvitinhsanpham_id;
                TronlsxTSXCDH = Helper.setDefaultValueWhenInsertOrUpdate(TronlsxTSXCDH, userTK, false);
                TronlsxTSXCDH.hoatdong = true;
            }

            decimal? sltd = vtduc.soluong - vtduc.sl_hanngach.GetValueOrDefault(0);
            TronlsxTSXCDH.sl_dat = TronlsxTSXCDH.sl_dat.GetValueOrDefault(0) + sltd;
            TronlsxTSXCDH.sl_chiato = TronlsxTSXCDH.sl_chiato.GetValueOrDefault(0) + sltd;
            TronlsxTSXCDH.sl_chiato2 = TronlsxTSXCDH.sl_chiato;
            TronlsxTSXCDH.sl_tinhvattu = TronlsxTSXCDH.sl_tinhvattu.GetValueOrDefault(0) + sltd;
            TronlsxTSXCDH.sl_dahoanthanh = 0;

            if (add)
            {
                db.md_lenhsanxuat_tosx_cdh.Add(TronlsxTSXCDH);
            }
        }

        return msgEx;
    }

    public string kiemTraBomVaGiaTatCaCongDoan(EntityContext db, User_TK userTK, bool kiemtragia, string msgEX, List<md_lenhsanxuat_tosx> tsxs)
    {
        var TSXHT = tsxs.Where(s => s.stt == 9999).FirstOrDefault();
        var tsxHTT = tsxs.Where(s => s.stt == 9998).FirstOrDefault();
        //var tsxDuc = tsxs.Where(s => s.stt == 1).FirstOrDefault();
        var tsxTron = tsxs.Where(s => s.stt == 0).FirstOrDefault();
        //hoan tat
        if (TSXHT != null)
        {
            msgEX += kiemtraBomVaGia(db, TSXHT, kiemtragia, msgEX);
            if(tsxHTT != null)
                taoDongHangXuongTron(db, userTK, TSXHT.md_lenhsanxuat_tosx_id, tsxHTT.md_lenhsanxuat_tosx_id, msgEX);
        }
        //hoan tat tho
        if (tsxHTT != null)
        {
            msgEX += kiemtraBomVaGia(db, tsxHTT, kiemtragia, msgEX);
            taoDongHangXuongTron(db, userTK, tsxHTT.md_lenhsanxuat_tosx_id, tsxTron.md_lenhsanxuat_tosx_id, msgEX);
        }
        //duc
        //if (tsxDuc != null)
        //{
        //    msgEX += kiemtraBomVaGia(db, tsxDuc, kiemtragia, msgEX);
        //    taoDongHangXuongTron(db, userTK, tsxDuc.md_lenhsanxuat_tosx_id, tsxTron.md_lenhsanxuat_tosx_id, msgEX);
        //}
        //tron
        if (tsxTron != null)
        {
            msgEX += kiemtraBomVaGia(db, tsxTron, kiemtragia, msgEX);
        }
        return msgEX;
    }

    public string TaoLenhSanXuat(EntityContext db, md_dondathangphanxuong object_, User_TK userTK, bool kiemtragia)
    {
        var lsxId = Helper.getNewId();
        var pbids = new List<string>();
        string sochungtu = VNN_VariablePublic.sochungtu(db, "LSX", 1);
        string msgEX = "";

        var px_to_ = db.md_phanxuong_to.
                Where(s => s.md_phanxuong_id == object_.md_phanxuong_id).OrderBy(s => s.sapxep).ToList();
        var tdt = "";
        var countPXT = px_to_.Count;

        var lsxExist = db.md_lenhsanxuat.Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).FirstOrDefault();
        if (lsxExist == null)
        {
            lsxExist = new md_lenhsanxuat();
            lsxExist.md_lenhsanxuat_id = lsxId;
            lsxExist.md_dondathangphanxuong_id = object_.md_dondathangphanxuong_id;
            lsxExist.md_phanxuong_id = object_.md_phanxuong_id;
            lsxExist.md_trangthai_id = Helper.CHUAHOANTHANH;
            lsxExist.sochungtu = sochungtu;
            lsxExist.ngaylap = DateTime.Now;
            lsxExist.ngayketthuc = object_.ngayketthuc;
            lsxExist.ngaydkgiaotp = object_.ngayketthuc;
            lsxExist.phieuXK = Helper.CHUAHOANTHANH;

            lsxExist = Helper.setDefaultValueWhenInsertOrUpdate(lsxExist, userTK, false);
            lsxExist.hoatdong = true;

            if (countPXT == 1)
                lsxExist.md_trangthai_id = Helper.CHUAHOANTHANH;
            db.md_lenhsanxuat.Add(lsxExist);
        }
        
        foreach (var px_to in px_to_.Select((s, index) => new { s.md_phanxuong_id, s.md_to_id, s.phongbanId, s.sapxep, index }))
        {
            var tosx = db.md_lenhsanxuat_tosx.Where(s =>
                s.md_lenhsanxuat_id == lsxExist.md_lenhsanxuat_id
                & s.md_phanxuong_to_id == px_to.md_to_id).FirstOrDefault();

            if (tosx == null)
            {
                tosx = new md_lenhsanxuat_tosx();
                tosx.md_lenhsanxuat_tosx_id = Helper.getNewId();
                tosx.md_lenhsanxuat_id = lsxExist.md_lenhsanxuat_id;
                tosx.md_phanxuong_to_id = px_to.md_to_id;
                tosx.md_phanxuong_id = px_to.md_phanxuong_id;
                tosx.ngaybatdausx = object_.ngay_hieuluc;
                tosx.ngaydkht = lsxExist.ngayketthuc;
                tosx.check_hoanthanh = false;
                tosx.sapxep = px_to.sapxep;
                tosx.stt = px_to.index + 1 == countPXT ? 9999 : (px_to.index + 2 == countPXT ? 9998 : px_to.index);
                tosx.phongbanId = px_to.phongbanId;
                tosx = Helper.setDefaultValueWhenInsertOrUpdate(tosx, userTK, false);
                tosx.hoatdong = true;
                db.md_lenhsanxuat_tosx.Add(tosx);
            }
            tdt = px_to.index == 0 ? px_to.md_to_id : tdt;
            pbids.Add(px_to.phongbanId);
        }
        
        var lsxTSX = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsxId).ToList();

        var lsxTSXLocal = db.md_lenhsanxuat_tosx.Local.Where(s => s.md_lenhsanxuat_id == lsxId).ToList();

        foreach (var px_to in lsxTSXLocal.OrderBy(s => s.sapxep).ToList())
        {
            db.md_lenhsanxuat_tosx_cdh.RemoveRange(db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == px_to.md_lenhsanxuat_tosx_id));

            var cdhPXs = db.md_dondathangphanxuong_cdh.Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).ToList();

            var cdhPXsLocal = db.md_dondathangphanxuong_cdh.Local.Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).ToList();

            foreach (var dhpx_cdh in cdhPXsLocal)
            {
                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dhpx_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                if (sp.ma_sanpham.Length >= 10)
                {
                    string ma_caiTemp = sp.ma_sanpham.Substring(0, 9) + "{0}" + sp.ma_sanpham.Substring(11);
                    string bo = sp.ma_sanpham.Substring(9, 2);

                    string bo_lon =
                        db.md_sanpham
                        .Where(s => s.ma_sanpham.StartsWith(sp.ma_sanpham.Substring(0, 9) + "S") & s.hoatdong == true)
                        .OrderByDescending(s => s.ngaytao)
                        .Select(s => s.ma_sanpham.Substring(9, 2)).FirstOrDefault();

                    string mdBoId = db.md_bo.Where(s => s.ma_bo == bo & s.ma_bo_cha == bo_lon).Select(s => s.md_bo_id).FirstOrDefault();
                    var bocais = db.md_bo_chitiet.Where(s => s.md_bo_id == mdBoId).OrderByDescending(s => s.md_bo_detail).Select(s => s.md_bo_detail).ToList();
                    if (bocais.Count <= 0)
                        bocais.Add(bo);

                    foreach (var bocai in bocais)
                    {
                        string ma_cai = string.Format(ma_caiTemp, bocai);
                        string ma_bo = string.Format(ma_caiTemp, bo);

                        var spCai = db.md_sanpham.
                                Where(s => s.ma_sanpham == ma_cai & s.hoatdong == true).
                                Select(s => new { s.md_sanpham_id, s.md_donvitinhsanpham_id, s.ma_sanpham, s.khomacdinh }).
                                FirstOrDefault();

                        bool update = false;

                        if (spCai == null)
                        {
                            msgEX = string.Format(@"<br class='error'>Mã bộ {0} thiếu mã cái {1}, hãy kiểm tra dữ liệu gốc hàng hóa.", ma_bo, ma_cai);
                        }
                        else
                        {
                            var khomd = db.md_kho.Where(s => s.md_kho_id == spCai.khomacdinh).FirstOrDefault();
                            if (khomd == null)
                            {
                                msgEX = string.Format(@"<br class='error'>Mã cái {0} phải có kho mặc định.", ma_cai);
                            }
                            else if (!pbids.Contains(khomd.md_to_id))
                            {
                                msgEX = string.Format(@"<br class='error'>Mã cái {0} phải có kho mặc định là kho sản xuất.", ma_cai);
                            }
                            else if (khomd.md_to_id == px_to.phongbanId)
                            {
                                update = true;
                            }
                        }

                        if (update)
                        {
                            System.Linq.Expressions.Expression<Func<md_lenhsanxuat_tosx_cdh, bool>> conditionLSXTSXCDH =
                                s => s.md_sanpham_id == spCai.md_sanpham_id &
                                        s.md_lenhsanxuat_tosx_id == px_to.md_lenhsanxuat_tosx_id;

                            var lsxTSXCDH = db.md_lenhsanxuat_tosx_cdh.Where(conditionLSXTSXCDH).ToList();

                            var lsxTSXCDHLocal = db.md_lenhsanxuat_tosx_cdh.Local.AsQueryable().Where(conditionLSXTSXCDH).ToList();

                            var lsx_tosx_cdh = lsxTSXCDHLocal.FirstOrDefault();

                            var addLSX = lsx_tosx_cdh;

                            if (lsx_tosx_cdh == null)
                            {
                                lsx_tosx_cdh = new md_lenhsanxuat_tosx_cdh();
                                lsx_tosx_cdh.md_lenhsanxuat_tosx_cdh_id = Helper.getNewId();
                                lsx_tosx_cdh.md_lenhsanxuat_tosx_id = px_to.md_lenhsanxuat_tosx_id;
                                lsx_tosx_cdh.md_sanpham_id = spCai.md_sanpham_id;
                                lsx_tosx_cdh.noigiaohang = dhpx_cdh.noigiaohang;
                                lsx_tosx_cdh.sl_hoanthanh = 0;
                                lsx_tosx_cdh.sl_nhapkho = 0;
                                lsx_tosx_cdh.sl_danhapkho = 0;
                                lsx_tosx_cdh.macuoi = ma_bo;
                                lsx_tosx_cdh.md_donvitinhsanpham_id = spCai.md_donvitinhsanpham_id;
                                lsx_tosx_cdh = Helper.setDefaultValueWhenInsertOrUpdate(lsx_tosx_cdh, userTK, false);
                                lsx_tosx_cdh.hoatdong = true;
                                //lsx_tosx_cdh.nhanphoisoi = nhanPS.GetValueOrDefault(true);
                            }

                            decimal? sltd = dhpx_cdh.tong_sl_dat - dhpx_cdh.sl_hoanthanh.GetValueOrDefault(0) - dhpx_cdh.sl_giamhanngach.GetValueOrDefault(0);

                            lsx_tosx_cdh.sl_dat = lsx_tosx_cdh.sl_dat.GetValueOrDefault(0) + sltd;
                            lsx_tosx_cdh.sl_chiato = lsx_tosx_cdh.sl_chiato.GetValueOrDefault(0) + sltd;
                            lsx_tosx_cdh.sl_chiato2 = lsx_tosx_cdh.sl_chiato;
                            lsx_tosx_cdh.sl_tinhvattu = lsx_tosx_cdh.sl_tinhvattu.GetValueOrDefault(0) + sltd;
                            lsx_tosx_cdh.sl_dahoanthanh = 0;
                            if (!lsx_tosx_cdh.macuoi.Contains(ma_bo))
                                lsx_tosx_cdh.macuoi += "," + ma_bo;
                            if (addLSX == null)
                            {
                                db.md_lenhsanxuat_tosx_cdh.Add(lsx_tosx_cdh);
                            }
                        }
                    }
                }
                else
                {
                    var lsx_tosx_cdh = new md_lenhsanxuat_tosx_cdh();
                    lsx_tosx_cdh.md_lenhsanxuat_tosx_cdh_id = Helper.getNewId();
                    lsx_tosx_cdh.md_lenhsanxuat_tosx_id = px_to.md_lenhsanxuat_tosx_id;
                    lsx_tosx_cdh.md_sanpham_id = sp.md_sanpham_id;
                    lsx_tosx_cdh.noigiaohang = dhpx_cdh.noigiaohang;
                    lsx_tosx_cdh.sl_hoanthanh = 0;
                    lsx_tosx_cdh.sl_nhapkho = 0;
                    lsx_tosx_cdh.sl_danhapkho = 0;
                    lsx_tosx_cdh.macuoi = sp.ma_sanpham;
                    lsx_tosx_cdh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id;
                    lsx_tosx_cdh = Helper.setDefaultValueWhenInsertOrUpdate(lsx_tosx_cdh, userTK, false);
                    lsx_tosx_cdh.hoatdong = true;
                    decimal? sltd = dhpx_cdh.tong_sl_dat - dhpx_cdh.sl_hoanthanh.GetValueOrDefault(0) - dhpx_cdh.sl_giamhanngach.GetValueOrDefault(0);

                    lsx_tosx_cdh.sl_dat = lsx_tosx_cdh.sl_dat.GetValueOrDefault(0) + sltd;
                    lsx_tosx_cdh.sl_chiato = lsx_tosx_cdh.sl_chiato.GetValueOrDefault(0) + sltd;
                    lsx_tosx_cdh.sl_chiato2 = lsx_tosx_cdh.sl_chiato;
                    lsx_tosx_cdh.sl_tinhvattu = lsx_tosx_cdh.sl_tinhvattu.GetValueOrDefault(0) + sltd;
                    lsx_tosx_cdh.sl_dahoanthanh = 0;
                    db.md_lenhsanxuat_tosx_cdh.Add(lsx_tosx_cdh);
                }
            }
        }

        msgEX += kiemTraBomVaGiaTatCaCongDoan(db, userTK, kiemtragia, msgEX, lsxTSXLocal);

        return msgEX;
    }

    public string LapKeHoachDatHang(EntityContext db, User_TK userTK, List<string> vnn)
    {
        string msg = "", msg_success = "";
        List<string> khdhids = new List<string>();
        try
        {
            foreach (var dcht in db.c_doichieuhangton.Where(s => vnn.Contains(s.c_doichieuhangton_id)).ToList())
            {
                if (dcht.kehoach != null & dcht.kehoach != "" & dcht.kehoach != " ")
                {
                    msg += "<div style='color:red'>Lỗi: dòng " + dcht.ten_donhang + " đã được lập kế hoạch.</div>";
                }
                else if (dcht.doichieuht != true)
                {
                    msg += "<div style='color:red'>Lỗi: dòng " + dcht.ten_donhang + " Chưa được đối chiếu hàng tồn.</div>";
                }
                else if (db.c_kehoachdathang.Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id).Take(1).Count() <= 0)
                {
                    var ds = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == dcht.c_danhsachdathang_id).FirstOrDefault();
                    //Tạo kế hoạch đặt hàng
                    dcht.kehoach = dcht.ten_donhang;
                    ds.md_trangthai_id = "CHUAXULY";
                    string id_khdh = Helper.getNewId();
                    khdhids.Add(id_khdh);
                    var kh = new c_kehoachdathang();
                    kh.c_kehoachdathang_id = id_khdh;
                    kh.xulykehoach = false;
                    kh.c_doichieuhangton_id = dcht.c_doichieuhangton_id;
                    kh.mota = dcht.mota;
                    kh.ngaybatdausx = ds.ngaybatdau;
                    kh.sodonhang = dcht.so_donhang;
                    kh.ten_kh = dcht.ten_donhang;
                    kh.ngaykehoach = dcht.ngaykehoach;
                    kh.donhang_thamchieu = dcht.donhang_thamchieu;
                    kh.trangthai = Helper.SOANTHAO;
                    kh = Helper.setDefaultValueWhenInsertOrUpdate(kh, userTK, false);
                    kh.hoatdong = true;
                    db.c_kehoachdathang.Add(kh);
                    //Tạo dòng hàng trong kế hoạch đặt hàng
                    foreach (var dkdh in db.c_doichieuhangton_dkdh.Where(s => s.c_doichieuhangton_id == dcht.c_doichieuhangton_id).ToList())
                    {
                        if (dkdh.sl_dat > 0)
                        {
                            decimal sl_phanphoi = 0;
                            string nhacungung = "";
                            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dkdh.md_sanpham_id).Take(1).FirstOrDefault();
                            if (sp.muangoai.GetValueOrDefault(false) != true)
                            {
                                sl_phanphoi = dkdh.sl_dat.Value;
                            }

                            if (sp.nhacungung == null || sp.nhacungung == "" || sp.nhacungung == " ")
                            {
                                var dtkd_ht = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == "MUA NGOAI").FirstOrDefault();
                                if (dtkd_ht != null)
                                {
                                    nhacungung = dtkd_ht.md_doitackinhdoanh_id;
                                }
                            }
                            else
                            {
                                nhacungung = sp.nhacungung;
                            }

                            var cdhcd = new c_kehoachdathang_cdhcd
                            {
                                c_kehoachdathang_cdhcd_id = Helper.getNewId(),
                                c_kehoachdathang_id = id_khdh,
                                md_sanpham_id = dkdh.md_sanpham_id,
                                md_donvitinhsanpham_id = dkdh.md_donvitinhsanpham_id,
                                macuoi = dkdh.macuoi,
                                sl_giamhanngach = 0,
                                sl_candat = dkdh.sl_dat,
                                sl_phanphoi = sl_phanphoi,
                                md_doitackinhdoanh_id = nhacungung,
                                md_phanxuong_id = sp.md_phanxuong_id,
                                noigiaohang = sp.noigiaohang,
                                hoatdong = true
                            };
                            cdhcd = Helper.setDefaultValueWhenInsertOrUpdate(cdhcd, userTK, false);
                            db.c_kehoachdathang_cdhcd.Add(cdhcd);
                        }
                    }
                    msg_success += "<div style='color:blue'>Dòng " + dcht.ten_donhang + " đã lập kế hoạch thành công.</div>";
                    db.SaveChanges();
                }
            }

            db.SaveChanges();

            xuLyKeHoachDatHang(db, userTK, string.Join(",", khdhids), "MD_00_KHDHJQGS", "7");
        }
        catch (Exception ex)
        {
            msg += string.Format(@"<div style='color:red'>Lỗi: {0}.</div>", ex.Message);
        }

        if (msg.Length <= 0)
        {
            msg = msg_success;
        }

        return msg;
    }

    public string xuLyKeHoachDatHang(EntityContext db, User_TK userTK, string id, string ma_module, string thoigianht)
    {
        string msg = "", msg_success = "";
        string[] vnn = id.Split(',');

        try
        {
            var candat = from a in db.c_kehoachdathang_cdhcd
                         join b in db.c_kehoachdathang on a.c_kehoachdathang_id equals b.c_kehoachdathang_id
                         join c in db.md_sanpham on a.md_sanpham_id equals c.md_sanpham_id
                         join e in db.c_doichieuhangton on b.c_doichieuhangton_id equals e.c_doichieuhangton_id
                         select new
                         {
                             a.md_phanxuong_id,
                             a.md_sanpham_id,
                             a.macuoi,
                             a.noigiaohang,
                             a.sl_phanphoi,
                             a.sl_candat,
                             a.md_doitackinhdoanh_id,
                             b.c_kehoachdathang_id,
                             b.donhang_thamchieu,
                             b.sodonhang,
                             b.mota,
                             c.md_donvitinhsanpham_id,
                             e.ngayhoanthanh
                         };

            foreach (var khdh in db.c_kehoachdathang.Where(s => vnn.Contains(s.c_kehoachdathang_id) & s.hoatdong == true).ToList())
            {
                if (khdh.trangthai != Helper.SOANTHAO)
                {
                    msg += string.Format(@"<div style='color:red'>Dòng {0} không phải trạng thái 'Soạn Thảo'.</div>", khdh.ten_kh);
                }
                else if (db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id
                     & db.c_nhucauvattu_dhpx.Where(t => t.md_dondathangphanxuong_id == s.c_kehoachdathang_dhcpx_id).Count() > 0).Count() > 0)
                {
                    msg += string.Format(@"<div style='color:red'>Dòng {0} đã tạo nhu cầu mua vật tư.</div>", khdh.ten_kh);
                }

                foreach (var dhcpx1 in db.c_kehoachdathang_cdhcd.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).ToList())
                {
                    if (dhcpx1.md_phanxuong_id == "@md_phanxuong_id" | string.IsNullOrEmpty(dhcpx1.md_phanxuong_id))
                    {
                        dhcpx1.md_phanxuong_id = "";
                    }

                    if (dhcpx1.md_doitackinhdoanh_id == "@md_doitackinhdoanh_id" | string.IsNullOrEmpty(dhcpx1.md_doitackinhdoanh_id))
                    {
                        dhcpx1.md_doitackinhdoanh_id = "";
                    }

                    string pxId = dhcpx1.md_phanxuong_id.Trim(), dtkdId = dhcpx1.md_doitackinhdoanh_id.Trim();

                    var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dhcpx1.md_sanpham_id).FirstOrDefault();
                    if (dhcpx1.sl_phanphoi == dhcpx1.sl_candat & pxId.Length < 1)
                    {
                        msg += string.Format(@"
                                <div style='color:red'>Dòng {0} không thể bỏ trống ""Phân xưởng sản xuất"".</div>",
                        sp == null ? "(unknown)" : sp.ma_sanpham);
                    }
                    else if (dhcpx1.sl_phanphoi == 0 & dtkdId.Length < 1)
                    {
                        msg += string.Format(@"
                                <div style='color:red'>Dòng {0} không thể bỏ trống ""Đối tác kinh doanh"".</div>",
                        sp == null ? "(unknown)" : sp.ma_sanpham);
                    }
                    else if (dhcpx1.sl_phanphoi != dhcpx1.sl_candat & (pxId.Length < 1 | dtkdId.Length < 1))
                    {
                        msg += string.Format(@"
                                <div style='color:red'>Dòng {0} không thể bỏ trống ""Phân xưởng sản xuất"" và ""Đối tác kinh doanh"".</div>",
                        sp == null ? "(unknown)" : sp.ma_sanpham);
                    }
                    else if (pxId.Length < 1 & dtkdId.Length < 1)
                    {

                        msg += string.Format(@"
                                <div style='color:red'>Dòng {0} không thể bỏ trống một trong 2 dữ liêu: Đối tác kinh doanh và phân xưởng sản xuất.</div>",
                        sp == null ? "(unknown)" : sp.ma_sanpham);
                    }
                }

                if (msg.Length <= 0)
                {
                    del_kehoachdathang(db, khdh.c_kehoachdathang_id);
                    //start
                    foreach (var item in candat.Where(s =>
                        s.c_kehoachdathang_id == khdh.c_kehoachdathang_id &
                        !string.IsNullOrEmpty(s.md_phanxuong_id) & s.sl_phanphoi > 0).ToList())
                    {
                        //--Them moi dong dat hang cho phan xuong
                        add_phanxuong(db, khdh.c_kehoachdathang_id, item.md_phanxuong_id,
                        item.donhang_thamchieu, item.ngayhoanthanh.Value, item.mota, item.sodonhang, thoigianht,
                        1, userTK);
                    }
                    //end

                    //start
                    foreach (var dhcpx in db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).ToList())
                    {
                        foreach (var item in candat.Where(s =>
                            s.md_phanxuong_id == dhcpx.md_phanxuong_id &
                            s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id &
                            s.sl_phanphoi > 0).ToList())
                        {
                            //--Them moi cac dong hang cua phan xuong
                            add_phanxuong_cdh(db, dhcpx.c_kehoachdathang_id, dhcpx.c_kehoachdathang_dhcpx_id,
                                item.md_sanpham_id, item.macuoi, item.md_donvitinhsanpham_id, item.sl_phanphoi.Value, item.mota,
                                item.noigiaohang, 1, userTK, item.sodonhang);
                        }
                        var count = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id);
                        if (count.Count() == 0)
                        {
                            db.c_kehoachdathang_dhcpx.Remove(dhcpx);
                        }
                    }
                    //end
                    khdh.xulykehoach = true;
                    var dc = db.c_doichieuhangton.FirstOrDefault(s => s.c_doichieuhangton_id == khdh.c_doichieuhangton_id);
                    var ds = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == dc.c_danhsachdathang_id).FirstOrDefault();
                    ds.md_trangthai_id = "DAXULY";
                    db.SaveChanges();
                    if (msg.Length <= 0)
                    {
                        int dem_sl = db.c_kehoachdathang_cdhcd.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).Count();
                        if (dem_sl <= 0)
                        {
                            khdh.trangthai = "DAHET";
                            khdh.xulykehoach = false;
                        }
                    }
                    db.SaveChanges();

                    msg_success += "<div style='color:blue'>Dòng \"" + khdh.ten_kh + "\" đã xử lý kế hoạch đặt hàng thành công.</div>";
                }
            }
        }
        catch (Exception ex)
        {
            msg += string.Format(@"<div style='color:red'>Lỗi: {0}</div>", ex + "");
        }

        if (msg.Length <= 0)
        {
            msg = msg_success;
        }
        
        return msg;
    }

    //them cac dong hang cua phan xuong
    private string add_phanxuong_cdh(EntityContext db, string c_kehoachdathang_id, string c_kehoachdathang_dhcpx_id, string md_sanpham_id, string macuoi,
    string md_donvitinhsanpham_id, decimal sl_phanphoi, string mota, string noigiaohang, int i, User_TK us, string sodonhang)
    {
        string id_new = Helper.getNewId();
        var dhcpx = db.c_kehoachdathang_dhcpx_cdh.FirstOrDefault(s => s.md_sanpham_id == md_sanpham_id & s.c_kehoachdathang_dhcpx_id == c_kehoachdathang_dhcpx_id);
        var add = dhcpx == null;
        if (add)
        {
            dhcpx = new c_kehoachdathang_dhcpx_cdh();
            dhcpx.c_kehoachdathang_dhcpx_cdh_id = Helper.getNewId();
        }
        else
        {
            id_new = dhcpx.c_kehoachdathang_dhcpx_cdh_id;
        }

        dhcpx.c_kehoachdathang_id = c_kehoachdathang_id;
        dhcpx.c_kehoachdathang_dhcpx_id = c_kehoachdathang_dhcpx_id;
        dhcpx.md_sanpham_id = md_sanpham_id;
        dhcpx.macuoi = macuoi;
        dhcpx.md_donvitinhsanpham_id = md_donvitinhsanpham_id;
        dhcpx.noigiaohang = noigiaohang;
        dhcpx.mota = mota;
        dhcpx.soluong = sl_phanphoi;
        dhcpx = Helper.setDefaultValueWhenInsertOrUpdate(dhcpx, us, false);
        dhcpx.hoatdong = true;
        
        if (add)
        {
            dhcpx.ngaytao = DateTime.Now;
            dhcpx.ngaycapnhat = DateTime.Now;
            db.c_kehoachdathang_dhcpx_cdh.Add(dhcpx);
        }
        else
        {
            dhcpx.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();
        return id_new;
    }
    //them dat hang cho phan xuong
    private string add_phanxuong(EntityContext db, string c_kehoachdathang_id, string md_phanxuong_id, string donhang_thamchieu, DateTime ngayhoanthanh, string mota, string sodonhang, string thoigianht, int i, User_TK us)
    {
        string id_new = Helper.getNewId();
        var dhcpx = db.c_kehoachdathang_dhcpx.FirstOrDefault(s => s.md_phanxuong_id == md_phanxuong_id & s.c_kehoachdathang_id == c_kehoachdathang_id);
        var add = dhcpx == null;
        if (add)
        {
            dhcpx = new c_kehoachdathang_dhcpx();
            dhcpx.c_kehoachdathang_dhcpx_id = Helper.getNewId();
            dhcpx.dongdathang = " ";
        }
        else
        {
            id_new = dhcpx.c_kehoachdathang_dhcpx_id;
        }

        dhcpx.md_phanxuong_id = md_phanxuong_id;
        dhcpx.c_kehoachdathang_id = c_kehoachdathang_id;
        dhcpx.donhang = donhang_thamchieu;
        dhcpx.ngayHTcham = ngayhoanthanh;
        dhcpx.sctdathang = sodonhang;
        var dsdh = db.c_danhsachdathang.Where(s => s.sochungtu == dhcpx.sctdathang).FirstOrDefault();
        dhcpx.hdlh = dsdh.huongdanlamhang;
        dhcpx.hdlhchung = dsdh.huongdanlamhangchung;
        dhcpx.c_danhsachdathang_id = dsdh.c_danhsachdathang_id;
        dhcpx.tinh_ncvt = false;

        dhcpx = Helper.setDefaultValueWhenInsertOrUpdate(dhcpx, us, false);
        dhcpx.hoatdong = true;

        //Kiem tra
        if (add)
        {
            dhcpx.ngaytao = DateTime.Now;
            dhcpx.ngaycapnhat = DateTime.Now;
            db.c_kehoachdathang_dhcpx.Add(dhcpx);
        }
        else
        {
            dhcpx.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();
        return id_new;
    }

    //Xoa cac du lieu lien quan den lap ke hoach de doi chieu lai 
    private void del_kehoachdathang(EntityContext db, string kehoachdathang_id)
    {
        db.c_kehoachdathang_dhcpx.RemoveRange(db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == kehoachdathang_id));
        db.c_kehoachdathang_dhncc.RemoveRange(db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_id == kehoachdathang_id));
        db.SaveChanges();
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

    public string getBOMHieuLuc(string spId, EntityContext db)
    {
        string bomId = (from a in db.md_sanpham_bom
                        where a.md_sanpham_id == spId
                        & string.IsNullOrEmpty(a.md_phanxuong_id)
                        & string.IsNullOrEmpty(a.md_to_id)
                        & (a.bom_donggoi == null | a.bom_donggoi == false)
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

    public string CA_01_TDDHPX(EntityContext db, User_TK userTK, string ma_module, string id, string kiemtragiaStr)
    {
        string msg = "", msg_success = "";
        string[] vnn = id.Split(',');
        md_dondathangphanxuong id_px = null;
        bool kiemtragia = (kiemtragiaStr + "").ToLower() == "true";

        try
        {
            foreach (var dhcpx in db.c_kehoachdathang_dhcpx.Where(s => vnn.Contains(s.c_kehoachdathang_dhcpx_id)).ToList())
            {
                if (dhcpx.md_phanxuong_id == "" || dhcpx.md_phanxuong_id == null || dhcpx.md_phanxuong_id == " ")
                {
                    msg = "<div class='error' style='color:red'>Dòng " + dhcpx.donhang + " chưa có phân xưởng không thể tạo</div>";
                    break;
                }
                //khai bao
                var px = db.md_phanxuong.FirstOrDefault(s => s.md_phanxuong_id == dhcpx.md_phanxuong_id);
                var c_kehoachdathang_dhcpx_cdhs = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id);
                var ddhpxExist = db.md_dondathangphanxuong.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).Take(1).FirstOrDefault();

                if (msg.Length <= 0)
                {
                    if (ddhpxExist == null)
                    {
                        //--them dong don dat hang phan xuong
                        id_px = add_px(db, dhcpx, 1, userTK);

                        //start
                        foreach (var dhcpx_cdh in c_kehoachdathang_dhcpx_cdhs.ToList())
                        {
                            add_px_cd(db, id_px.md_dondathangphanxuong_id, dhcpx_cdh.md_sanpham_id, dhcpx_cdh.noigiaohang, dhcpx_cdh.soluong.Value, dhcpx_cdh.md_donvitinhsanpham_id, dhcpx_cdh.mota, 1, userTK, dhcpx.c_danhsachdathang_id, dhcpx_cdh.c_kehoachdathang_dhcpx_id);
                        }
                        //end             
                    }
                    
                    msg += TaoLenhSanXuat(db, id_px, userTK, kiemtragia);
                }
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }

        if (msg.Length <= 0)
        {
            msg = msg_success;
        }

        return msg;
    }
    //cac dong
    public string add_px_cd(EntityContext db, string md_dondathangphanxuong_id, string md_sanpham_id, string noigiaohang, decimal soluong, string md_donvitinhsanpham_id, string mota, int i, User_TK us, string c_danhsachdathang_id, string c_kehoachdathang_dhcpx_id)
    {
        string id_new = Helper.getNewId();
        //kiem tra
        var check_pxServer = db.md_dondathangphanxuong_cdh.Where(s => s.md_sanpham_id == md_sanpham_id & s.md_dondathangphanxuong_id == md_dondathangphanxuong_id).FirstOrDefault();
        var cdh = db.md_dondathangphanxuong_cdh.Local.Where(s => s.md_sanpham_id == md_sanpham_id & s.md_dondathangphanxuong_id == md_dondathangphanxuong_id).FirstOrDefault();
        var add = cdh == null;

        var dhcpxServer = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.md_sanpham_id == md_sanpham_id & s.md_donvitinhsanpham_id == md_donvitinhsanpham_id & s.c_kehoachdathang_dhcpx_id == c_kehoachdathang_dhcpx_id).FirstOrDefault();
        var dhcpx = db.c_kehoachdathang_dhcpx_cdh.Local.Where(s => s.md_sanpham_id == md_sanpham_id & s.md_donvitinhsanpham_id == md_donvitinhsanpham_id & s.c_kehoachdathang_dhcpx_id == c_kehoachdathang_dhcpx_id).FirstOrDefault();
        if (add)
        {
            cdh = new md_dondathangphanxuong_cdh();
            cdh.md_dondathangphanxuong_cdh_id = Helper.getNewId();
            cdh.c_danhsachdathang_id = c_danhsachdathang_id;
        }
        else
        {
            id_new = cdh.md_dondathangphanxuong_id;
        }
        cdh.md_dondathangphanxuong_id = md_dondathangphanxuong_id;
        cdh.md_sanpham_id = md_sanpham_id;
        cdh.tong_sl_dat = soluong;
        cdh.hanngach = cdh.tong_sl_dat;
        cdh.sl_chiato = 0;
        cdh.sl_hoanthanh = 0;
        cdh.md_donvitinhsanpham_id = md_donvitinhsanpham_id;
        cdh.noigiaohang = noigiaohang;
        cdh.macuoi = dhcpx.macuoi;
        cdh.hoatdong = true;
        
        if (add)
        {
            cdh = Helper.setDefaultValueWhenInsertOrUpdate(cdh, us, false);
            db.md_dondathangphanxuong_cdh.Add(cdh);
        }
        else
        {
            cdh = Helper.setDefaultValueWhenInsertOrUpdate(cdh, us, true);
        }
        return id_new;
    }

    //them dong don dat hang
    public md_dondathangphanxuong add_px(EntityContext db, c_kehoachdathang_dhcpx dhcpx, int i, User_TK us)
    {
        int dem_sct = 0;
        dem_sct++;
        string sochungtu = VNN_VariablePublic.sochungtu(db, "DDHPX", dem_sct);
        c_kehoachdathang_dhcpx a = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).FirstOrDefault();
        a.dongdathang = sochungtu;
        string id_new = Helper.getNewId();
        //kiem tra
        var check_pxServer = db.md_dondathangphanxuong.Where(s => s.md_phanxuong_id == dhcpx.md_phanxuong_id & s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).FirstOrDefault();
        var ddh = db.md_dondathangphanxuong.Local.Where(s => s.md_phanxuong_id == dhcpx.md_phanxuong_id & s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).FirstOrDefault();
        var add = ddh == null;

        if (add)
        {
            ddh = new md_dondathangphanxuong();
            ddh.md_dondathangphanxuong_id = id_new;
        }
        else
        {
            id_new = ddh.md_dondathangphanxuong_id;
        }

        int so_ngay = 0;
        var ngaydksxesServer = from aa in db.md_dondathangphanxuong_cdh
                               join bb in db.md_sanpham on aa.md_sanpham_id equals bb.md_sanpham_id
                               join cc in db.md_chungloai on bb.md_nhomnangluc_id equals cc.md_chungloai_id
                               where aa.md_dondathangphanxuong_id == ddh.md_dondathangphanxuong_id
                               select new { cc.songaysx };

        var ngaydksxes = from aa in db.md_dondathangphanxuong_cdh.Local
                         join bb in db.md_sanpham on aa.md_sanpham_id equals bb.md_sanpham_id
                         join cc in db.md_chungloai on bb.md_nhomnangluc_id equals cc.md_chungloai_id
                         where aa.md_dondathangphanxuong_id == ddh.md_dondathangphanxuong_id
                         select new { cc.songaysx };

        if (dhcpx.donhang.Contains("_SR-"))
        {
            ddh.ngay_hieuluc = dhcpx.ngayHTcham.Value.AddDays(-15);
        }
        else
        {
            if (ngaydksxes.Count() > 0)
            {
                var dsnsx = ngaydksxes.OrderByDescending(s => s.songaysx).FirstOrDefault();
                if (dsnsx != null)
                {
                    ddh.ngay_hieuluc = dhcpx.ngayHTcham.Value.AddDays(0 - dsnsx.songaysx.Value);
                    so_ngay = dsnsx.songaysx.Value;
                }
            }
            else
                ddh.ngay_hieuluc = dhcpx.ngayHTcham.Value.AddDays(-40);
        }
        ddh.md_trangthai_id = Helper.SOANTHAO;
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

        //Kiem tra
        if (add)
        {
            ddh = Helper.setDefaultValueWhenInsertOrUpdate(ddh, us, false);
            db.md_dondathangphanxuong.Add(ddh);
        }
        else
        {
            ddh = Helper.setDefaultValueWhenInsertOrUpdate(ddh, us, true);
        }
        return ddh;
    }

    public string tinhHangTonKhoTheoLSX(EntityContext db, User_TK us, string id)
    {
        var ksp = from a in db.md_kho_sanpham
                  join b in db.md_kho on a.md_kho_id equals b.md_kho_id
                  join c in db.md_sanpham on a.md_sanpham_id equals c.md_sanpham_id
                  where b.hangton == true & (b.vattu ?? false) == false
                  select new { a.md_kho_id, b.md_phanxuong_id, b.md_to_id, a.md_sanpham_id, c.ma_sanpham, a.soluong };

        string msg = "";
        var tinhhangtonTP = false;
        try
        {
            var tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).FirstOrDefault();
            var lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id).FirstOrDefault();

            if (lsx.md_trangthai_id != Helper.CHUAHOANTHANH)
            {
                msg = @"Chỉ có thể tính hàng tồn khi LSX ở trạng thái ""Đang xử lý""";
            }
            else if (!string.IsNullOrEmpty(tsx.phieulayht))
            {
                msg = @"Đã lấy hàng tồn, không được tính lại.";
            }
            else
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
                            s.md_phanxuong_id == tsx.md_phanxuong_id
                            & s.md_phanxuong_to_id == tsx.md_phanxuong_to_id
                            & s.md_lenhsanxuat_tosx_id != tsx.md_lenhsanxuat_tosx_id
                            & (string.IsNullOrEmpty(s.phieulayhttp) | s.phieulayhttp == " ")
                            ).
                        Select(s=>s.md_lenhsanxuat_tosx_id).
                        ToList();

                    db.md_lenhsanxuat_tosx_dklhttp.RemoveRange(db.md_lenhsanxuat_tosx_dklhttp.Where(s => s.md_lenhsanxuat_tosx_id == id));
                    db.md_lenhsanxuat_tosx_dklht.RemoveRange(db.md_lenhsanxuat_tosx_dklht.Where(s => s.md_lenhsanxuat_tosx_id == id));
                    foreach (var cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == id).ToList())
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).FirstOrDefault();
                        var lht = new md_lenhsanxuat_tosx_dklhttp();
                        lht.md_lenhsanxuat_tosx_dklhttp_id = Helper.getNewId();
                        lht.md_lenhsanxuat_tosx_id = cdh.md_lenhsanxuat_tosx_id;
                        lht.md_sanpham_id = cdh.md_sanpham_id;
                        lht.macuoi = cdh.macuoi;
                        lht.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id;
                        var kspSLT = ksp.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & string.IsNullOrEmpty(s.md_phanxuong_id) & string.IsNullOrEmpty(s.md_to_id)).ToList().Sum(s => s.soluong.GetValueOrDefault(0));
                        lht.sl_lsx = cdh.sl_chiato;
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
                    var tsxIds = db.md_lenhsanxuat_tosx.
                        Where(s =>
                            s.md_phanxuong_id == tsx.md_phanxuong_id
                            & s.md_phanxuong_to_id == tsx.md_phanxuong_to_id
                            & s.md_lenhsanxuat_tosx_id != tsx.md_lenhsanxuat_tosx_id
                            & (string.IsNullOrEmpty(s.phieulayht) | s.phieulayht == " ")
                            ).
                        Select(s => s.md_lenhsanxuat_tosx_id).
                        ToList();

                    db.md_lenhsanxuat_tosx_dklht.RemoveRange(db.md_lenhsanxuat_tosx_dklht.Where(s => s.md_lenhsanxuat_tosx_id == id));
                    db.md_lenhsanxuat_tosx_tonkho.RemoveRange(db.md_lenhsanxuat_tosx_tonkho.Where(s => s.md_lenhsanxuat_tosx_id == id));
                    foreach (var cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == id).ToList())
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).FirstOrDefault();
                        var lht = new md_lenhsanxuat_tosx_dklht();
                        lht.md_lenhsanxuat_tosx_dklht_id = Helper.getNewId();
                        lht.md_lenhsanxuat_tosx_id = cdh.md_lenhsanxuat_tosx_id;
                        lht.md_sanpham_id = cdh.md_sanpham_id;
                        lht.macuoi = cdh.macuoi;
                        lht.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id;
                        var kspSLT = ksp.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.md_to_id == tsx.phongbanId).ToList().Sum(s => s.soluong.GetValueOrDefault(0));
                        lht.sl_lsx = cdh.sl_chiato;
                        lht.sl_tonkho = kspSLT;

                        var sl_ctlt = lht.sl_tonkho > lht.sl_lsx ? lht.sl_lsx : lht.sl_tonkho;

                        var sl_dadklt = db.md_lenhsanxuat_tosx_dklht.Where(s =>
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
                        db.md_lenhsanxuat_tosx_dklht.Add(lht);
                    }

                    tsx.tinhhangton = true;
                }

                db.SaveChanges();
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

    public Dictionary<string, int> layHangTonKhoTheoLSX(EntityContext db, User_TK us, string id, md_lenhsanxuat_tosx tsx)
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
            if(tsx == null)
                tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).FirstOrDefault();

            var lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id).FirstOrDefault();
            var dhpx = db.md_dondathangphanxuong.Where(s => s.md_dondathangphanxuong_id == lsx.md_dondathangphanxuong_id).FirstOrDefault();
            var kho = db.md_kho.Where(s => s.md_to_id == tsx.phongbanId & (s.hangton ?? false) == false & s.hoatdong == true).FirstOrDefault();
            var khoTonTho = db.md_kho.Where(s => s.md_to_id == tsx.phongbanId & (s.hangton ?? false) == true & s.hoatdong == true).FirstOrDefault();
            var khoTonTP = db.md_kho.Where(s => s.ma_kho == Helper.KHOTONTP).FirstOrDefault();

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

            string toLayHTId = "", toLayHT = "";
            var tsx2Server = db.md_lenhsanxuat_tosx.Where(s =>
                    s.stt > tsx.stt
                    & s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                ).OrderBy(s => s.stt).Take(1).FirstOrDefault();

            var tsx2 = db.md_lenhsanxuat_tosx.Local.Where(s =>
                    s.stt > tsx.stt
                    & s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                ).OrderBy(s => s.stt).Take(1).FirstOrDefault();


            if (lsx.md_trangthai_id != Helper.CHUAHOANTHANH)
            {
                msg = @"Chỉ có thể tính hàng tồn khi LSX ở trạng thái ""Đang xử lý"".";
            }
            else if (layhangtonTP & tsx.tinhhangtontp.GetValueOrDefault(false) == false)
            {
                msg = @"LSX chưa tính hàng tồn thành phẩm.";
            }
            else if (!layhangtonTP & tsx.tinhhangton.GetValueOrDefault(false) == false)
            {
                msg = @"LSX chưa tính hàng tồn.";
            }
            else if (!string.IsNullOrEmpty(tsx.phieulayht))
            {
                msg = @"LSX đã lấy hàng tồn cho tổ.";
            }
            else if (tsx.stt == 9998)
            {
                if (string.IsNullOrEmpty(tsx2.phieulayhttp))
                {
                    msg = @"LSX chưa xử lý hàng tồn ở công đoạn hoàn tất";
                }
            }

            if (msg.Length <= 0)
            {
                string lsxTsxIdTiepTheo = tsx2 == null ? "" : tsx2.md_lenhsanxuat_tosx_id;
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
                            & s.sl_layton > 0
                        ).ToList();

                        var lhts = db.md_lenhsanxuat_tosx_dklhttp.Local.Where(s =>
                            s.md_sanpham_id == cdh.md_sanpham_id
                            & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                            & s.sl_layton > 0
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
                            & s.sl_layton > 0
                        ).ToList();

                        var lhts = db.md_lenhsanxuat_tosx_dklht.Local.Where(s =>
                            s.md_sanpham_id == cdh.md_sanpham_id
                            & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                            & s.sl_layton > 0
                        ).ToList();

                        if(lhts.Count > 0)
                            listLHT.AddRange(lhts);
                    }
                }

                if (msg.Length <= 0)
                {
                    if (layhangtonTP)
                    {
                        if (listLHTTP.Sum(s => s.sl_layton.GetValueOrDefault(0)) > 0)
                        {
                            string sochungtu = VNN_VariablePublic.sochungtu(db, "PVC", 1);
                            var vcnb = new md_vanchuyennoibo();
                            vcnb.md_vanchuyennoibo_id = Helper.getNewId();
                            vcnb.md_trangthai_id = Helper.DANHAN;
                            vcnb.sochungtu = sochungtu;
                            vcnb.c_doichieuhangton_id = " ";
                            vcnb.tukho = khoTonTP.md_kho_id;
                            vcnb.denkho = kho.md_kho_id;
                            vcnb.loaichuyen = "VANCNBTC";
                            vcnb.loaichuyen_id = Helper.CHUAHOANTHANH;
                            vcnb.chungtuthamchieu = "";
                            vcnb.ketoan = true;
                            vcnb.sctdathang = dhpx.sctdathang;
                            vcnb.donhang_thamchieu = dhpx.donhang_thamchieu;
                            vcnb.ngaydenghi = DateTime.Now;
                            vcnb.ngaychuyen = DateTime.Now;
                            vcnb.hoatdong = true;
                            vcnb = Helper.setDefaultValueWhenInsertOrUpdate(vcnb, us, false);
                            db.md_vanchuyennoibo.Add(vcnb);

                            foreach (var lht in listLHTTP.Distinct().Where(s => s.sl_layton > 0))
                            {
                                var cdvc = new md_vanchuyennoibo_cdvc();
                                cdvc.md_vanchuyennoibo_cdvc_id = Helper.getNewId();
                                cdvc.md_vanchuyennoibo_id = vcnb.md_vanchuyennoibo_id;
                                cdvc.md_sanpham_id = lht.md_sanpham_id;
                                cdvc.md_donvitinhsanpham_id = lht.md_donvitinhsanpham_id;
                                cdvc.lsxId = lsx.md_lenhsanxuat_id;
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

                            idsTP.Add(vcnb.md_vanchuyennoibo_id);

                            tsx.tolaytontpId = toLayHTId;
                            tsx.phieulayhttp = string.Join(",", sochungtu);
                            db.SaveChanges();
                        }
                        else
                        {
                            tsx.phieulayhttp = "-";
                            tsx.tolaytontpId = "";
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        if (listLHT.Sum(s => s.sl_layton.GetValueOrDefault(0)) > 0)
                        {
                            string sochungtu = VNN_VariablePublic.sochungtu(db, "PVC", 1);

                            var vcnb = new md_vanchuyennoibo();
                            vcnb.md_vanchuyennoibo_id = Helper.getNewId();
                            vcnb.md_trangthai_id = Helper.DANHAN;
                            vcnb.sochungtu = sochungtu;
                            vcnb.c_doichieuhangton_id = " ";
                            vcnb.tukho = khoTonTho.md_kho_id;
                            vcnb.denkho = kho.md_kho_id;
                            vcnb.loaichuyen = "VANCNBTC";
                            vcnb.loaichuyen_id = Helper.CHUAHOANTHANH;
                            vcnb.chungtuthamchieu = "";
                            vcnb.ketoan = true;
                            vcnb.sctdathang = dhpx.sctdathang;
                            vcnb.donhang_thamchieu = dhpx.donhang_thamchieu;
                            vcnb.ngaydenghi = DateTime.Now;
                            vcnb.ngaychuyen = DateTime.Now;
                            vcnb.hoatdong = true;
                            vcnb = Helper.setDefaultValueWhenInsertOrUpdate(vcnb, us, false);
                            db.md_vanchuyennoibo.Add(vcnb);

                            foreach (var lht in listLHT.Distinct().Where(s => s.sl_layton > 0))
                            {
                                var cdvc = new md_vanchuyennoibo_cdvc();
                                cdvc.md_vanchuyennoibo_cdvc_id = Helper.getNewId();
                                cdvc.md_vanchuyennoibo_id = vcnb.md_vanchuyennoibo_id;
                                cdvc.md_sanpham_id = lht.md_sanpham_id;
                                cdvc.md_donvitinhsanpham_id = lht.md_donvitinhsanpham_id;
                                cdvc.lsxId = lsx.md_lenhsanxuat_id;
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
                            tsx.phieulayht = sochungtu;
                            tsx.tolaytonId = toLayHTId;
                            tsx.tolayton = toLayHT;
                            ids.Add(vcnb.md_vanchuyennoibo_id);
                            db.SaveChanges();
                        }
                        else
                        {
                            tsx.phieulayht = "-";
                            tsx.tolaytonId = "";
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            msg = ex + "";
        }

        if (msg.Length <= 0)
        {
            if (layhangtonTP)
                msg = string.Format("<div style='color:blue'>Lấy hàng tồn TP thành công.</div>");
            else
                msg = string.Format("<div style='color:blue'>Lấy hàng tồn thành công.</div>");

            if (ids.Count > 0)
            {
                HieuLucPhieuVanChuyen(db, us, "", string.Join(",", ids), "false");
            }

            if (idsTP.Count > 0)
            {
                HieuLucPhieuVanChuyen(db, us, "", string.Join(",", idsTP), "false");
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
            var khtid = id_parent.Substring(0, 32);

            var kht = db.c_kehoachdathangtong.Where(s => s.c_kehoachdathangtong_id == khtid).FirstOrDefault();
            if (kht == null)
            {
                if (lsxs == null)
                    lsxs = new List<md_lenhsanxuat>();
            }
            else
            {
                lsxs = db.md_lenhsanxuat.Where(s => s.nhomKH == kht.ten_kh & s.md_trangthai_id == Helper.CHUAHOANTHANH).ToList();
            }

            foreach (var lsx in lsxs)
            {
                var tsxHT = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id & s.stt == 9999 & !string.IsNullOrEmpty(s.phieulayhttp) & s.phieulayhttp != " ").FirstOrDefault();
                if (tsxHT != null)
                {
                    var tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id & s.stt == 9998 & (string.IsNullOrEmpty(s.phieulayht) | s.phieulayht == " ")).FirstOrDefault();

                    if (tsx != null)
                    {
                        msg += tinhHangTonKhoTheoLSX(db, userTK, tsx.md_lenhsanxuat_tosx_id);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

        return msg;
    }

    public string HieuLucPhieuVanChuyen(EntityContext db, User_TK userTK, string ma_module, string id, string koCapnhatDLSXStr)
    {
        string msg = "";
        string[] vnn = id.Split(',');

        var koCapnhatDLSX = koCapnhatDLSXStr == "true";

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
                        var khoXuat = db.md_kho.Where(s => s.md_kho_id == vcnb.tukho).FirstOrDefault();
                        var khoNhan = db.md_kho.Where(s => s.md_kho_id == vcnb.denkho).FirstOrDefault();

                        var lsxtsx = new List<md_lenhsanxuat>();
                        if (vcnb.md_trangthai_id != Helper.DANHAN)
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

                        vcnb.ngayhieuluc = DateTime.Now;
                        var vcnb_cdvcs = db.md_vanchuyennoibo_cdvc.Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id);

                        var khoSPDic = new Dictionary<string, decimal>();
                        foreach (var vcnb_cdvc in vcnb_cdvcs.OrderBy(s => s.denkho).ToList())
                        {
                            var spMain = db.md_sanpham.Where(s => s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                            vcnb_cdvc.soluong_dachuyen = vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);

                            string toSXId = "", toSXId2 = "", lsx = "";
                            int sanxuat = 0;
                            if (vcnb.loaichuyen == "VANCNBTC" & vcnb_cdvc.soluong_dichchuyen > 0)
                            {
                                var cdhLSX = db.md_lenhsanxuat_tosx_cdh.Where(s =>
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

                                if (cdhLSX != null & chuyenVeKT == false & !vcnb.laytonTP.GetValueOrDefault(false))
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
                            string[] arr_tukho = vcnb.tukho.Split(',');
                            decimal sl_dichchuyen_thucte = vcnb_cdvc.soluong_dichchuyen.Value;
                            //xuất kho
                            var lstSPId = new List<string>();
                            if (vcnb.loaichuyen == "VANCNBCTKGH")
                            {
                                sanxuat = 3;
                                var lsxto = Extension.getLSXToId2(vcnb_cdvc.lsx_to, db);
                                var tsx = lsxto.tsx;
                                toSXId = tsx.md_lenhsanxuat_tosx_id;
                                lsx = lsxto.lsx.sochungtu;
                                var lsxSp = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                            s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                            & s.macuoi.Contains(spMain.ma_sanpham));

                                tsx.ngaygiao = vcnb.ngaychuyen;
                                var tsxsInLSX = db.md_lenhsanxuat_tosx.Where(t => t.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id).Select(s => s.md_lenhsanxuat_tosx_id).ToList();
                                if (sl_dichchuyen_thucte > 0)
                                {
                                    foreach (var cai in lsxSp.ToList())
                                    {
                                        var cdhsInLSX = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                            s.md_sanpham_id == cai.md_sanpham_id
                                            & tsxsInLSX.Contains(s.md_lenhsanxuat_tosx_id)).ToList();

                                        foreach (var cdhInLsx in cdhsInLSX)
                                        {
                                            cdhInLsx.sl_danhapkho = cdhInLsx.sl_danhapkho.GetValueOrDefault(0) + vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);
                                            cdhInLsx.ngayhoanthanh = vcnb.ngaychuyen;
                                        }
                                        cai.sl_dagiao = cai.sl_dagiao.GetValueOrDefault(0) + vcnb_cdvc.soluong_dichchuyen;
                                        if (cai.sl_chiato < cai.sl_dagiao)
                                            cai.sl_layton = cai.sl_dagiao - cai.sl_chiato;
                                        else
                                            cai.sl_layton = 0;

                                        lstSPId.Add(cai.md_sanpham_id);
                                    }
                                    db.SaveChanges();
                                }

                                var ddhpx = db.md_dondathangphanxuong_cdh.Where(s =>
                                    s.md_dondathangphanxuong_id == lsxto.lsx.md_dondathangphanxuong_id
                                    & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                                if (ddhpx != null)
                                {
                                    ddhpx.sl_hoanthanh += vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);
                                    ddhpx.sl_tamhoanthanh = ddhpx.sl_tamhoanthanh.GetValueOrDefault(0)
                                            - vcnb_cdvc.soluong_muonchuyen.GetValueOrDefault(0)
                                            + vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);

                                    var ddsdh = db.c_dongdsdh.Where(s =>
                                    s.c_danhsachdathang_id == ddhpx.c_danhsachdathang_id
                                    & s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                                    if (ddsdh != null)
                                    {
                                        ddsdh.sl_nhaphang = ddsdh.sl_nhaphang.GetValueOrDefault(0) + vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);
                                        if(lsxto.lsx.sxton.GetValueOrDefault(false))
                                        {
                                            ddsdh.sl_conlai = ddsdh.sl_conlai.GetValueOrDefault(0) - ddsdh.sl_nhaphang.GetValueOrDefault(0);
                                        }
                                    }
                                    db.SaveChanges();
                                }

                                lsxtsx.Add(lsxto.lsx);
                            }
                            else
                            {
                                if (sl_dichchuyen_thucte > 0)
                                    lstSPId.Add(vcnb_cdvc.md_sanpham_id);
                            }

                            var coXuatKho = false;
                            foreach (var kho_sp in db.md_kho_sanpham.Where(s => s.md_kho_id == vcnb.tukho & lstSPId.Contains(s.md_sanpham_id)).ToList())
                            {
                                var lhtServer = db.md_vanchuyennoibo_dalayton.Where(s =>
                                   s.md_sanpham_id == kho_sp.md_sanpham_id
                                   & s.md_vanchuyennoibo_id == vcnb_cdvc.md_vanchuyennoibo_id).FirstOrDefault();

                                var lht = db.md_vanchuyennoibo_dalayton.Local.Where(s =>
                                    s.md_sanpham_id == kho_sp.md_sanpham_id
                                    & s.md_vanchuyennoibo_id == vcnb_cdvc.md_vanchuyennoibo_id).FirstOrDefault();

                                if (lht != null)
                                {
                                    var sllt = lht.tongsoluong.GetValueOrDefault(0) - lht.sldalay.GetValueOrDefault(0);
                                    var slDaLuuLT = lht.soluong_layton.GetValueOrDefault(0);
                                    decimal slCongThem = 0;
                                    if (slDaLuuLT + sl_dichchuyen_thucte > sllt)
                                    {
                                        lht.soluong_layton = sllt;
                                        slCongThem = sllt - slDaLuuLT;
                                    }
                                    else
                                    {
                                        lht.soluong_layton = slDaLuuLT + sl_dichchuyen_thucte;
                                        slCongThem = sl_dichchuyen_thucte;
                                    }
                                    lht.mota = "DLT";

                                    foreach (var lhtCp in db.md_vanchuyennoibo_dalayton.Where(s =>
                                         s.md_sanpham_id == kho_sp.md_sanpham_id
                                         & s.lsx == lht.lsx
                                         & s.mota != "DLT"
                                         & s.md_vanchuyennoibo_dalayton_id != lht.md_vanchuyennoibo_dalayton_id).ToList())
                                    {
                                        lhtCp.sldalay = lhtCp.sldalay.GetValueOrDefault() + slCongThem;
                                    }
                                }

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
                                    var kho_gd = new md_kho_giaodich();
                                    kho_gd.md_kho_giaodich_id = Helper.getNewId();
                                    kho_gd.md_kho_id = kho_sp.md_kho_id;
                                    kho_gd.md_sanpham_id = kho_sp.md_sanpham_id;
                                    kho_gd.soluong_dichchuyen = sl_xuatkho;
                                    kho_gd.ngaychuyen = vcnb.ngaychuyen.Value;
                                    kho_gd.kieuchuyen = "Xuất kho";
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
                                    coXuatKho = true;
                                }

                                kho_sp.soluong = kho_sp.soluong.Value - sl_xuatkho;
                                db.SaveChanges();
                            }

                            //Nhap Kho
                            if (!coXuatKho & sl_dichchuyen_thucte > 0)
                                msg = string.Format("Không có hàng {0}", spMain.ma_sanpham);
                            else if (sl_dichchuyen_thucte > 0)
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
                                    sanxuat = sanxuat,
                                    mota = vcnb_cdvc.tenhang,
                                    hoatdong = true
                                };
                                kho_gd_nhapkho = Helper.setDefaultValueWhenInsertOrUpdate(kho_gd_nhapkho, userTK, false);
                                db.md_kho_giaodich.Add(kho_gd_nhapkho);
                                //add_kho_hsd(db, null, vcnb_cdvc.md_sanpham_id, sl_dichchuyen_thucte, vcnb, 1, userTK, kho_sp_nhapkho.md_kho_sanpham_id);
                                //end Nhap kho

                                foreach (var lhtCp in db.md_vanchuyennoibo_dalayton.Where(s =>
                                             s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id
                                             & s.mota != "DLT").ToList())
                                {
                                    lhtCp.soluong_layton = 0;
                                    lhtCp.mota = "DLT";
                                }
                            }
                        }

                        var dsdhSXTons = new List<c_danhsachdathang>();
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
                                    var dsdhSXTon = db.c_danhsachdathang.Where(s => s.sochungtu == dhpx.sctdathang & (s.sanxuatton ?? false) == true).FirstOrDefault();
                                    if (dsdhSXTon != null)
                                    {
                                        if(dsdhSXTons.Where(s => s.c_danhsachdathang_id == dsdhSXTon.c_danhsachdathang_id).Count() <= 0)
                                            dsdhSXTons.Add(dsdhSXTon);
                                    }

                                    var tsxs = db.md_lenhsanxuat_tosx.Where(s =>
                                        s.md_lenhsanxuat_id == item.md_lenhsanxuat_id)
                                        .Select(s => s.md_lenhsanxuat_tosx_id).ToList();

                                    var LHTTSX = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                        tsxs.Contains(s.md_lenhsanxuat_tosx_id)
                                    )
                                    .Where(s => s.sl_dagiao < s.sl_dahoanthanh)
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

                        foreach(var dsdhSXTon in dsdhSXTons)
                        {
                            var donghangsServer = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdhSXTon.c_danhsachdathang_id).ToList();
                            var donghangs = db.c_dongdsdh.Local.Where(s => s.c_danhsachdathang_id == dsdhSXTon.c_danhsachdathang_id).ToList();
                            var daHT = donghangs.Where(s => s.sl_conlai.GetValueOrDefault(0) - s.sl_thuhoi.GetValueOrDefault(0) > 0).Count() <= 0;
                            if (daHT)
                                dsdhSXTon.trangthai = Helper.KETTHUC;
                        }

                        if (msg.Length <= 0)
                        {
                            vcnb.md_trangthai_id = Helper.HIEULUC;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception ex) { msg = string.Format(@"<div style='color:red'>{0}.</div>", ex); }
                if (msg.Length <= 0)
                {
                    msg = "<div style='color:blue'>Vận chuyển hàng hóa thành công.</div>";
                    transaction.Commit();
                }
                else
                    transaction.Rollback();
            }
        }
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
        else if(!string.IsNullOrWhiteSpace(sctLT))
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
                    cdh.sl_chiato2 = cdh.sl_chiato - sllt;
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

        if(xoaTonTP)
        {
            var tsxPrev = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id & s.stt == 9998).FirstOrDefault();
            if(tsxPrev != null)
            {
                db.md_lenhsanxuat_tosx_dklht.RemoveRange(db.md_lenhsanxuat_tosx_dklht.Where(s => s.md_lenhsanxuat_tosx_id == tsxPrev.md_lenhsanxuat_tosx_id));
            }
        }

        return msg;
    }
}