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

    public string TaoLenhSanXuat(EntityContext db, md_dondathangphanxuong object_, User_TK userTK, bool kiemtragia)
    {
        var lsxId = Helper.getNewId();
        var lsxTsxIds = new Dictionary<string, string>();
        string sochungtu = VNN_VariablePublic.sochungtu(db, "LSX", 1);
        string msgEX = "";

        var px_to_ = db.md_phanxuong_to.
                Where(s => s.md_phanxuong_id == object_.md_phanxuong_id).OrderBy(s => s.sapxep).ToList();
        var tdt = "";
        var countPXT = px_to_.Count;

        var lsx = new md_lenhsanxuat();
        lsx.md_lenhsanxuat_id = lsxId;
        lsx.md_dondathangphanxuong_id = object_.md_dondathangphanxuong_id;
        lsx.md_phanxuong_id = object_.md_phanxuong_id;
        lsx.md_trangthai_id = "CHUAHOANTHANH";
        lsx.sochungtu = sochungtu;
        lsx.ngaylap = DateTime.Now;
        lsx.ngayketthuc = object_.ngayketthuc;
        lsx.ngaydkgiaotp = object_.ngayketthuc;
        lsx.phieuXK = "CHUAHOANTHANH";

        lsx.nguoitao = userTK.ad_user_id;
        lsx.vaitrotao = userTK.ad_role_id;
        lsx.bophantao = userTK.md_phongban_id;
        lsx.value_nguoitao = userTK.ma_user;
        lsx.value_vaitrotao = userTK.ten_role;
        lsx.value_bophantao = userTK.ten_phongban;
        lsx.nguoicapnhat = userTK.ad_user_id;
        lsx.vaitrocapnhat = userTK.ad_role_id;
        lsx.bophancapnhat = userTK.md_phongban_id;
        lsx.value_nguoicapnhat = userTK.ma_user;
        lsx.value_vaitrocapnhat = userTK.ten_role;
        lsx.value_bophancapnhat = userTK.ten_phongban;
        lsx.ngaytao = DateTime.Now;
        lsx.ngaycapnhat = DateTime.Now;
        lsx.hoatdong = true;

        if (countPXT == 1)
            lsx.md_trangthai_id = "CHUAHOANTHANH";
        db.md_lenhsanxuat.Add(lsx);

        foreach (var px_to in px_to_.Select((s, index) => new { s.md_phanxuong_id, s.md_to_id, s.phongbanId, s.sapxep, index }))
        {
            var tosx = new md_lenhsanxuat_tosx();
            tosx.md_lenhsanxuat_tosx_id = Helper.getNewId();
            tosx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
            tosx.md_phanxuong_to_id = px_to.md_to_id;
            tosx.md_phanxuong_id = px_to.md_phanxuong_id;
            tosx.ngaybatdausx = object_.ngay_hieuluc;
            tosx.ngaydkht = lsx.ngayketthuc;
            tosx.check_hoanthanh = false;
            tosx.sapxep = px_to.sapxep;
            tosx.stt = px_to.index + 1 == countPXT ? 9999 : px_to.index;
            tosx.phongbanId = px_to.phongbanId;
            tosx.nguoitao = userTK.ad_user_id;
            tosx.vaitrotao = userTK.ad_role_id;
            tosx.bophantao = userTK.md_phongban_id;
            tosx.value_nguoitao = userTK.ma_user;
            tosx.value_vaitrotao = userTK.ten_role;
            tosx.value_bophantao = userTK.ten_phongban;
            tosx.nguoicapnhat = userTK.ad_user_id;
            tosx.vaitrocapnhat = userTK.ad_role_id;
            tosx.bophancapnhat = userTK.md_phongban_id;
            tosx.value_nguoicapnhat = userTK.ma_user;
            tosx.value_vaitrocapnhat = userTK.ten_role;
            tosx.value_bophancapnhat = userTK.ten_phongban;
            tosx.ngaytao = DateTime.Now;
            tosx.ngaycapnhat = DateTime.Now;
            tosx.hoatdong = true;
            db.md_lenhsanxuat_tosx.Add(tosx);
            //db.SaveChanges();
            tdt = px_to.index == 0 ? px_to.md_to_id : tdt;
            lsxTsxIds.Add(tosx.md_lenhsanxuat_tosx_id, px_to.phongbanId);
        }

        System.Linq.Expressions.Expression<Func<md_lenhsanxuat_tosx, bool>> condition = s => s.md_lenhsanxuat_id == lsxId;

        var lsxTSX = db.md_lenhsanxuat_tosx.Where(condition).ToList();

        var lsxTSXLocal = db.md_lenhsanxuat_tosx.Local.AsQueryable().Where(condition).ToList();

        foreach (var px_to in lsxTSXLocal.OrderBy(s => s.sapxep).ToList())
        {
            System.Linq.Expressions.Expression<Func<md_dondathangphanxuong_cdh, bool>> conditionCDHPX =
                    s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id;

            var cdhPXs = db.md_dondathangphanxuong_cdh.Where(conditionCDHPX).ToList();

            var cdhPXsLocal = db.md_dondathangphanxuong_cdh.Local.AsQueryable().Where(conditionCDHPX).ToList();

            foreach (var dhpx_cdh in cdhPXsLocal)
            {
                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dhpx_cdh.md_sanpham_id).Take(1).FirstOrDefault();
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
                            Select(s => new { s.md_sanpham_id, s.md_donvitinhsanpham_id, s.ma_sanpham }).
                            FirstOrDefault();

                    if (spCai == null)
                        msgEX = string.Format(@"Mã bộ {0} thiếu mã cái {1}, hãy kiểm tra dữ liệu gốc hàng hóa.", ma_bo, ma_cai);

                    System.Linq.Expressions.Expression<Func<md_lenhsanxuat_tosx_cdh, bool>> conditionLSXTSXCDH =
                        s => s.md_sanpham_id == spCai.md_sanpham_id &
                                s.md_lenhsanxuat_tosx_id == px_to.md_lenhsanxuat_tosx_id;

                    var lsxTSXCDH = db.md_lenhsanxuat_tosx_cdh.Where(conditionLSXTSXCDH).ToList();

                    var lsxTSXCDHLocal = db.md_lenhsanxuat_tosx_cdh.Local.AsQueryable().Where(conditionLSXTSXCDH).ToList();

                    var lsx_tosx_cdh = lsxTSXCDHLocal.FirstOrDefault();

                    var addLSX = lsx_tosx_cdh;

                    if (lsx_tosx_cdh == null)
                    {
                        var nhanPS = (bool?)Mbg.Data.SqlClient.SqlHelper.ExecuteScalar(
                        string.Format(@"
                                        select top 1 nhanphoisoi 
                                        from md_nhanphoisoi
                                        where N'{0}' like ma_sp
                                            and md_to_id = N'{1}'
                                    ", ma_cai, px_to.md_phanxuong_to_id));

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
                        lsx_tosx_cdh.nguoitao = userTK.ad_user_id;
                        lsx_tosx_cdh.vaitrotao = userTK.ad_role_id;
                        lsx_tosx_cdh.bophantao = userTK.md_phongban_id;
                        lsx_tosx_cdh.value_nguoitao = userTK.ma_user;
                        lsx_tosx_cdh.value_vaitrotao = userTK.ten_role;
                        lsx_tosx_cdh.value_bophantao = userTK.ten_phongban;

                        lsx_tosx_cdh.nguoicapnhat = userTK.ad_user_id;
                        lsx_tosx_cdh.vaitrocapnhat = userTK.ad_role_id;
                        lsx_tosx_cdh.bophancapnhat = userTK.md_phongban_id;
                        lsx_tosx_cdh.value_nguoicapnhat = userTK.ma_user;
                        lsx_tosx_cdh.value_vaitrocapnhat = userTK.ten_role;
                        lsx_tosx_cdh.value_bophancapnhat = userTK.ten_phongban;

                        lsx_tosx_cdh.ngaytao = DateTime.Now;
                        lsx_tosx_cdh.ngaycapnhat = DateTime.Now;
                        lsx_tosx_cdh.mota = "";
                        lsx_tosx_cdh.hoatdong = true;
                        lsx_tosx_cdh.nhanphoisoi = nhanPS.GetValueOrDefault(true);
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

        foreach (var item1 in lsxTsxIds)
        {
            var bgIds = db.md_banggia
                    .Where(s => s.phongbanId == item1.Value & s.tuychon == "NHANCONG" & s.hoatdong == true)
                    .Select(s => s.md_banggia_id).ToList();
            string pbgId = db.md_phienbangia
                       .Where(s => bgIds.Contains(s.md_banggia_id) & s.hoatdong == true)
                       .OrderByDescending(s => s.ngay_hieuluc).Select(s => s.md_phienbangia_id)
                       .FirstOrDefault();

            System.Linq.Expressions.Expression<Func<md_lenhsanxuat_tosx_cdh, bool>> conditionLSXTSXCDH =
                    s => s.md_lenhsanxuat_tosx_id == item1.Key;

            var lsxTSXCDH = db.md_lenhsanxuat_tosx_cdh.Where(conditionLSXTSXCDH).ToList();

            var lsxTSXCDHLocal = db.md_lenhsanxuat_tosx_cdh.Local.AsQueryable().Where(conditionLSXTSXCDH).ToList();

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
                        string err = string.Format(@"<br>HHVT ""{0}"" chưa có giá cho ""{1}""",
                            db.md_sanpham.Where(s => s.md_sanpham_id == item2.md_sanpham_id).Select(s => s.ma_sanpham).FirstOrDefault(),
                            db.md_phanxuong_to.Where(s => s.phongbanId == item1.Value).Select(s => s.ten_to).FirstOrDefault());
                        msgEX += err;
                    }
                }
                else
                {
                    item2.gianhancong = giasp.gia;
                }


                var spBom = db.md_sanpham_bom.
                            Where(s => s.md_sanpham_id == item2.md_sanpham_id &
                            s.phongbanId == item1.Value).OrderByDescending(s => s.ngay_hieuluc).Take(1).FirstOrDefault();
                string bomSpId = spBom == null ? "" : spBom.md_sanpham_bom_id;
                var bomSP = db.md_sanpham_bom_vattu.Where(s =>
                    s.md_sanpham_bom_id == bomSpId
                    & s.sanphamId == item2.md_sanpham_id
                    ).ToList();

                item2.noigiaohang = bomSpId;

                if (bomSP.Count > 0)
                {
                    foreach (var vattusp in bomSP.Where(s => s.soluong > 0))
                    {
                        System.Linq.Expressions.Expression<Func<md_lenhsanxuat_tosx_vattu, bool>> conditionBSP=
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
                        vtbk.soluong = (decimal)vattusp.soluong.GetValueOrDefault(0);
                        vtbk.md_donvitinhsanpham_id = vattusp.md_donvitinhsanpham_id;
                        db.md_lenhsanxuat_tosx_vattuBackup.Add(vtbk);
                        //db.SaveChanges();
                    }
                }
                else
                {
                    string err = string.Format(@"<br>HHVT ""{0}"" chưa có BOM cho ""{1}""",
                        db.md_sanpham.Where(s => s.md_sanpham_id == item2.md_sanpham_id).Select(s => s.ma_sanpham).FirstOrDefault(),
                        db.md_phanxuong_to.Where(s => s.phongbanId == item1.Value).Select(s => s.ten_to).FirstOrDefault());
                    if (!msgEX.Contains(err))
                    {
                        msgEX += err;
                    }
                }
            }
        }

        return msgEX;
    }

    public string LapKeHoachDatHang(EntityContext db, User_TK userTK, List<string> vnn)
    {
        string msg = "", msg_success = "";
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
                else
                {
                    var ds = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == dcht.c_danhsachdathang_id).FirstOrDefault();
                    //Tạo kế hoạch đặt hàng
                    dcht.kehoach = dcht.ten_donhang;
                    ds.md_trangthai_id = "CHUAXULY";
                    string id_khdh = Helper.getNewId();
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
                    kh.trangthai = "SOANTHAO";
                    kh.nguoitao = userTK.ad_user_id;
                    kh.vaitrotao = userTK.ad_role_id;
                    kh.bophantao = userTK.md_phongban_id;
                    kh.value_nguoitao = userTK.ma_user;
                    kh.value_vaitrotao = userTK.ten_role;
                    kh.value_bophantao = userTK.ten_phongban;
                    kh.nguoicapnhat = userTK.ad_user_id;
                    kh.vaitrocapnhat = userTK.ad_role_id;
                    kh.bophancapnhat = userTK.md_phongban_id;
                    kh.value_nguoicapnhat = userTK.ma_user;
                    kh.value_vaitrocapnhat = userTK.ten_role;
                    kh.value_bophancapnhat = userTK.ten_phongban;
                    kh.ngaytao = DateTime.Now;
                    kh.ngaycapnhat = DateTime.Now;
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

                                nguoitao = userTK.ad_user_id,
                                vaitrotao = userTK.ad_role_id,
                                bophantao = userTK.md_phongban_id,
                                value_nguoitao = userTK.ma_user,
                                value_vaitrotao = userTK.ten_role,
                                value_bophantao = userTK.ten_phongban,
                                nguoicapnhat = userTK.ad_user_id,
                                vaitrocapnhat = userTK.ad_role_id,
                                bophancapnhat = userTK.md_phongban_id,
                                value_nguoicapnhat = userTK.ma_user,
                                value_vaitrocapnhat = userTK.ten_role,
                                value_bophancapnhat = userTK.ten_phongban,
                                ngaytao = DateTime.Now,
                                ngaycapnhat = DateTime.Now,
                                hoatdong = true
                            };
                            db.c_kehoachdathang_cdhcd.Add(cdhcd);
                        }
                    }
                    msg_success += "<div style='color:blue'>Dòng " + dcht.ten_donhang + " đã lập kế hoạch thành công.</div>";
                    db.SaveChanges();
                }
            }
            db.SaveChanges();
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

    public string add_px_vattu(EntityContext db, c_kehoachdathang_dhcpx_cdh cdh, int i, User_TK us)
    {
        string id_new = Helper.getNewId();
        foreach (var bom_vattu in db.md_sanpham_bom_vattu.Where(s => s.md_sanpham_bom_id == cdh.md_sanpham_bom_id & s.soluong > 0).ToList())
        {
            //kiem tra          
            var check_px = db.c_kehoachdathang_dhcpx_vattu.Where(s =>
                s.md_sanpham_id == bom_vattu.md_sanpham_id &
                s.c_kehoachdathang_dhcpx_id == cdh.c_kehoachdathang_dhcpx_id).FirstOrDefault();
            var vattu = check_px;

            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == bom_vattu.md_sanpham_id).FirstOrDefault();
            if (sp.vattu == true)
            {
                if (vattu == null)
                {
                    vattu = new c_kehoachdathang_dhcpx_vattu();
                    vattu.c_kehoachdathang_dhcpx_vattu_id = Helper.getNewId();
                    vattu.soluong = (decimal)bom_vattu.soluong.GetValueOrDefault(0) * cdh.soluong;
                    vattu.sl_hanngach = 0;
                }
                else
                {
                    id_new = vattu.c_kehoachdathang_dhcpx_vattu_id;
                    vattu.soluong = vattu.soluong + ((decimal)bom_vattu.soluong.GetValueOrDefault(0) * cdh.soluong);
                }

                vattu.md_sanpham_id = bom_vattu.md_sanpham_id;
                vattu.c_kehoachdathang_id = cdh.c_kehoachdathang_id;
                vattu.c_kehoachdathang_dhcpx_id = cdh.c_kehoachdathang_dhcpx_id;
                vattu.md_donvitinhsanpham_id = bom_vattu.md_donvitinhsanpham_id;

                vattu.nguoitao = us.ad_user_id;
                vattu.vaitrotao = us.ad_role_id;
                vattu.bophantao = us.md_phongban_id;
                vattu.value_nguoitao = us.ma_user;
                vattu.value_vaitrotao = us.ten_role;
                vattu.value_bophantao = us.ten_phongban;
                vattu.nguoicapnhat = us.ad_user_id;
                vattu.vaitrocapnhat = us.ad_role_id;
                vattu.bophancapnhat = us.md_phongban_id;
                vattu.value_nguoicapnhat = us.ma_user;
                vattu.value_vaitrocapnhat = us.ten_role;
                vattu.value_bophancapnhat = us.ten_phongban;
                vattu.hoatdong = true;

                //Kiem tra
                if (check_px == null)
                {
                    vattu.ngaytao = DateTime.Now;
                    vattu.ngaycapnhat = DateTime.Now;
                    db.c_kehoachdathang_dhcpx_vattu.Add(vattu);
                }
                else
                {
                    vattu.ngaycapnhat = DateTime.Now;
                }
                db.SaveChanges();
            }
        }
        return id_new;
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
                if (trangthai == "SOANTHAO")
                    giucho.soluong_giucho = giucho.soluong_giucho - dvc.tong_sl_xuat;
                else
                    giucho.soluong_giucho = giucho.soluong_giucho - dvc.sl_daxuat;
            }
            if (giucho.soluong_giucho <= 0)
                db.md_kho_giucho.Remove(giucho);
        }
    }

    public DataTable TinhNangLuc(c_danhsachdathang dsdh, EntityContext db)
    {
        var tbl = new DataTable();
        tbl.Columns.Add("dauma");
        tbl.Columns.Add("hehang");
        tbl.Columns.Add("tong_cbmcandat").DataType = typeof(decimal);
        tbl.Columns.Add("cbm_candat").DataType = typeof(decimal);
        tbl.Columns.Add("thoigiandukien").DataType = typeof(DateTime);
        tbl.Columns.Add("tuanthu").DataType = typeof(int);
        tbl.Columns.Add("thoigianyeucau").DataType = typeof(DateTime);
        tbl.Columns.Add("tgantoan_dh").DataType = typeof(int);
        tbl.Columns.Add("tgnhan_dh").DataType = typeof(int);
        tbl.Columns.Add("result_nhandh").DataType = typeof(bool);
        tbl.Columns.Add("result").DataType = typeof(bool);
        tbl.Columns.Add("slconlai").DataType = typeof(decimal);
        tbl.Columns.Add("nam").DataType = typeof(int);
        bool ancoChk = dsdh.anco_check.GetValueOrDefault(false);
        var tgantoan_dh = (dsdh.hangiaohang_po - dsdh.ngaylap).Value.TotalDays;

        var nnl = from dgh in db.c_dongdsdh
                  join sp in db.md_sanpham on dgh.md_sanpham_id equals sp.md_sanpham_id
                  where dgh.c_danhsachdathang_id == dsdh.c_danhsachdathang_id
                  select new
                  {
                      nhomnangluc_id = db.md_chungloai.Where(s => s.md_chungloai_id == sp.md_nhomnangluc_id).Take(1).Select(s => s.code_cl).FirstOrDefault(),
                      cbmdat = ancoChk == true ? dgh.v2 : dgh.v2 * (dgh.sl_dathang - dgh.sl_giamhanngach)
                  };
        string dauma = "", tenhehang = "";
        var nnl_group = nnl.GroupBy(n => n.nhomnangluc_id).Select(s => new { nhomnangluc_id = s.Key, cbmdat = s.Sum(t => t.cbmdat) });
        int tuanthu = 0, nam = 0;
        decimal? tongCBM = 0;
        var ngaydonhang = dsdh.ngaybatdau.Value;
        var ngayyeucau = dsdh.anco_check == true ? dsdh.ngayhoanthanh : dsdh.hangiaohang_po;

        foreach (var item in nnl_group.ToList())
        {
            tongCBM = item.cbmdat.GetValueOrDefault(0);
            int thoigianlamhang = 0;

            var tuandonhang = Helper.Week_(ngaydonhang);
            tuandonhang = tuandonhang > 52 ? 52 : tuandonhang;
            nam = ngaydonhang.Year;
            var tuannangluc_id = db.md_nangluc.Where(s => s.tuan == tuandonhang & s.nam == nam & s.hehang == item.nhomnangluc_id)
                .Select(s => s.md_nangluc_id).FirstOrDefault();

            var count_nnl = db.md_nangluc.Where(s => s.md_nangluc_id == tuannangluc_id).Count();
            dauma = db.md_nangluc.Where(s => s.md_nangluc_id == tuannangluc_id).Select(s => s.hehang).FirstOrDefault();
            tenhehang = item.nhomnangluc_id;
            if (count_nnl == 0)
            {
                if (!string.IsNullOrEmpty(tenhehang))
                {
                    var row = tbl.NewRow();
                    row["dauma"] = tenhehang;
                    row["hehang"] = tenhehang;
                    row["tong_cbmcandat"] = tongCBM;
                    row["cbm_candat"] = 0;
                    row["thoigiandukien"] = ngaydonhang;
                    row["tuanthu"] = Math.Round((double)(tuandonhang + thoigianlamhang) / 7, 0);
                    row["thoigianyeucau"] = ngayyeucau;
                    row["tgantoan_dh"] = 0;
                    row["tgnhan_dh"] = 0;
                    row["result_nhandh"] = true;
                    row["result"] = false;
                    row["slconlai"] = 0;
                    row["nam"] = nam;
                    tbl.Rows.Add(row);
                }
            }
            tuanthu = tuandonhang;
            var ngaydukien = Helper.FirstDateOfWeekISO8601(nam, tuanthu).AddDays(7);
            var slconlai_tuan = db.md_nangluc.Where(s => s.md_nangluc_id == tuannangluc_id).Select(s => s.soluongconlai).FirstOrDefault();
            var tgnhan_dh = 0;
            var sl_dcdat = item.cbmdat;
            var sl_dcdatcp = sl_dcdat;
            var count_loop = 0;

            if (slconlai_tuan >= tongCBM)
            {
                var row = tbl.NewRow();
                row["dauma"] = dauma;
                row["hehang"] = tenhehang;
                row["tong_cbmcandat"] = tongCBM;
                row["cbm_candat"] = item.cbmdat.GetValueOrDefault(0);
                row["thoigiandukien"] = ngaydukien;
                row["tuanthu"] = tuanthu;
                row["thoigianyeucau"] = ngayyeucau;
                row["tgantoan_dh"] = tgantoan_dh;
                row["tgnhan_dh"] = tgnhan_dh;
                row["result_nhandh"] = true;
                row["result"] = ngaydukien >= ngayyeucau ? false : true;
                row["slconlai"] = 0;
                row["nam"] = nam;
                tbl.Rows.Add(row);
            }
            else
            {
                while (sl_dcdat > 0 & ngaydukien <= ngayyeucau)
                {
                    dauma = item.nhomnangluc_id;
                    ngaydukien = Helper.FirstDateOfWeekISO8601(nam, tuanthu).AddDays(7);
                    slconlai_tuan = db.md_nangluc
                               .Where(s => s.hehang == dauma &
                               s.tuan == tuanthu & s.nam == nam).Select(s => s.soluongconlai).FirstOrDefault();

                    if (slconlai_tuan.GetValueOrDefault(0) <= sl_dcdat)
                    {
                        if (slconlai_tuan > 0 & sl_dcdat > 0)
                        {
                            var row = tbl.NewRow();
                            row["dauma"] = dauma;
                            row["hehang"] = tenhehang;
                            row["tong_cbmcandat"] = tongCBM;
                            row["cbm_candat"] = slconlai_tuan;
                            row["thoigiandukien"] = ngaydukien;
                            row["tuanthu"] = tuanthu;
                            row["thoigianyeucau"] = ngayyeucau;
                            row["tgantoan_dh"] = tgantoan_dh;
                            row["tgnhan_dh"] = tgnhan_dh;
                            row["result_nhandh"] = true;
                            row["result"] = ngaydukien >= ngayyeucau ? false : true;
                            row["slconlai"] = 0;
                            row["nam"] = nam;
                            tbl.Rows.Add(row);

                            sl_dcdat = sl_dcdat - slconlai_tuan;
                        }
                    }
                    else
                    {
                        var row = tbl.NewRow();
                        row["dauma"] = dauma;
                        row["hehang"] = tenhehang;
                        row["tong_cbmcandat"] = tongCBM;
                        row["cbm_candat"] = sl_dcdat;
                        row["thoigiandukien"] = ngaydukien;
                        row["tuanthu"] = tuanthu;
                        row["thoigianyeucau"] = ngayyeucau;
                        row["tgantoan_dh"] = tgantoan_dh;
                        row["tgnhan_dh"] = tgnhan_dh;
                        row["result_nhandh"] = true;
                        row["result"] = ngaydukien >= ngayyeucau ? false : true;
                        row["slconlai"] = 0;
                        row["nam"] = nam;
                        tbl.Rows.Add(row);

                        sl_dcdat = 0;
                    }


                    if (tuanthu < 52)
                        tuanthu = tuanthu + 1;
                    else
                    {
                        tuanthu = 1;
                        nam += 1;
                    }

                    if (sl_dcdatcp == sl_dcdat)
                    {
                        count_loop = count_loop + 1;
                    }
                    else
                    {
                        sl_dcdatcp = sl_dcdat;
                        count_loop = 0;
                    }

                    if (count_loop > 50)
                        sl_dcdat = 0;
                }
            }
        }

        if (tbl.Rows.Count <= 0)
        {
            var row = tbl.NewRow();
            row["dauma"] = dauma;
            row["hehang"] = tenhehang;
            row["tong_cbmcandat"] = tongCBM;
            row["cbm_candat"] = 0;
            row["thoigiandukien"] = ngaydonhang;
            row["tuanthu"] = tuanthu - 1;
            row["thoigianyeucau"] = ngayyeucau;
            row["tgantoan_dh"] = 0;
            row["tgnhan_dh"] = 0;
            row["result_nhandh"] = true;
            row["result"] = false;
            row["slconlai"] = 0;
            row["nam"] = nam;
            tbl.Rows.Add(row);
        }
        return tbl;
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
        
        var giaBanSP = from a in db.md_giasanpham
                       join b in db.md_phienbangia on a.md_phienbangia_id equals b.md_phienbangia_id
                       join c in db.md_banggia on b.md_banggia_id equals c.md_banggia_id
                        where a.md_sanpham_id == sanphamId
                        & c.lienket_bg == khachhang
                        & c.tuychon == "BANTP"
                        & c.hoatdong == true
                        orderby b.ngay_hieuluc descending
                        select a.gia;


        return giaBanSP.Take(1).FirstOrDefault().GetValueOrDefault(0);
    }
}