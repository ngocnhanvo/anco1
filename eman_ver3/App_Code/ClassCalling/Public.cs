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