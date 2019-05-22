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

    public void capnhatGiuCho_VCNB(string sct, string sctlq, string vcnbId, string trangthai, EntityContext db)
    {
        var sctlqs = new List<string> { sct, sctlq };
        foreach (var giucho in db.md_kho_giucho.Where(s => sctlqs.Contains(s.sctlienquan)).ToList())
        {
            var dvc = db.md_vanchuyennoibo_cdvc.Where(s =>
                s.md_vanchuyennoibo_id == vcnbId &
                s.md_sanpham_id == giucho.md_sanpham_id).FirstOrDefault();

            if (dvc != null)
            {
                if(trangthai == "SOANTHAO")
                    giucho.soluong_giucho = giucho.soluong_giucho - dvc.soluong_toida;
                else
                    giucho.soluong_giucho = giucho.soluong_giucho - dvc.soluong_dachuyen;
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
        tbl.Columns.Add("tong_cbmcandat");
        tbl.Columns.Add("cbm_candat");
        tbl.Columns.Add("thoigiandukien");
        tbl.Columns.Add("tuanthu");
        tbl.Columns.Add("thoigianyeucau");
        tbl.Columns.Add("tgantoan_dh");
        tbl.Columns.Add("tgnhan_dh");
        tbl.Columns.Add("result_nhandh");
        tbl.Columns.Add("result");
        tbl.Columns.Add("slconlai");
        tbl.Columns.Add("nam");

        var tgantoan_dh = (dsdh.hangiaohang_po - dsdh.ngaylap).Value.TotalDays;
        var nnl = from dgh in db.c_dongdsdh
                  join sp in db.md_sanpham on dgh.md_sanpham_id equals sp.md_sanpham_id
                  where dgh.c_danhsachdathang_id == dsdh.c_danhsachdathang_id
                  select new {
                      nhomnangluc_id = db.md_chungloai.Where(s=>s.md_chungloai_id == sp.md_nhomnangluc_id).Take(1).Select(s=>s.code_cl).FirstOrDefault(),
                      cbmdat = dgh.v2 * dgh.sl_conlai
                  };

        var nnl_group = nnl.GroupBy(n => n.nhomnangluc_id).Select(s => new { nhomnangluc_id = s.Key, cbmdat = s.Sum(t => t.cbmdat) });
        foreach(var item in nnl_group.ToList())
        {
            int thoigianlamhang = 0;
            var ngaydonhang = DateTime.Now.AddDays(thoigianlamhang);
            var ngayyeucau = dsdh.hangiaohang_po == null ? DateTime.Now : dsdh.hangiaohang_po;
            var tuandonhang = Helper.Week_(ngaydonhang);
            tuandonhang = tuandonhang > 52 ? 52 : tuandonhang;
            var nam = ngaydonhang.Year;
            var tuannangluc_id = db.md_nangluc.Where(s => s.tuan == tuandonhang & s.nam == nam & s.hehang == item.nhomnangluc_id)
                .Select(s => s.md_nangluc_id).FirstOrDefault();

            var count_nnl = db.md_nangluc.Where(s => s.md_nangluc_id == tuannangluc_id).Count();
            string dauma = db.md_nangluc.Where(s => s.md_nangluc_id == tuannangluc_id).Select(s => s.hehang).FirstOrDefault();
            string tenhehang = item.nhomnangluc_id;
            if (count_nnl == 0)
            {
                if (!string.IsNullOrEmpty(dauma))
                {
                    var row = tbl.NewRow();
                    row["dauma"] = dauma;
                    row["hehang"] = tenhehang;
                    row["tong_cbmcandat"] = item.cbmdat;
                    row["cbm_candat"] = 0;
                    row["thoigiandukien"] = DateTime.Now.AddDays(thoigianlamhang);
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
            var tuanthu = tuandonhang;
            var ngaydukien = Helper.FirstDateOfWeekISO8601(nam, tuanthu).AddDays(7);
            var slconlai_tuan = db.md_nangluc.Where(s => s.md_nangluc_id == tuannangluc_id).Select(s => s.soluongconlai).FirstOrDefault();
            var tgnhan_dh = 0;
            var sl_dcdat = item.cbmdat;
            var sl_dcdatcp = sl_dcdat;
            var count_loop = 0;
            
            if (slconlai_tuan < 0)
            {
                var row = tbl.NewRow();
                row["dauma"] = dauma;
                row["hehang"] = tenhehang;
                row["tong_cbmcandat"] = item.cbmdat;
                row["cbm_candat"] = slconlai_tuan;
                row["thoigiandukien"] = ngaydukien;
                row["tuanthu"] = tuanthu;
                row["thoigianyeucau"] = ngayyeucau;
                row["tgantoan_dh"] = tgantoan_dh;
                row["tgnhan_dh"] = tgnhan_dh;
                row["result_nhandh"] = true;
                row["result"] = ngaydukien  >= ngayyeucau ? false : true;
                row["slconlai"] = 0;
                row["nam"] = nam;
                tbl.Rows.Add(row);
            }
            else
            {
                while(sl_dcdat > 0 & !string.IsNullOrEmpty(dauma))
                {
                    tuannangluc_id = db.md_nangluc
                        .Where(s => s.tuan == tuandonhang & s.nam == nam & s.hehang == item.nhomnangluc_id)
                        .Select(s => s.md_nangluc_id).FirstOrDefault();

                    dauma = db.md_nangluc.Where(s => s.md_nangluc_id == tuannangluc_id).Select(s => s.hehang).FirstOrDefault();
                    ngaydukien = Helper.FirstDateOfWeekISO8601(nam, tuanthu).AddDays(7);

                    if (slconlai_tuan <= sl_dcdat)
                    {
                        if(slconlai_tuan > 0 & sl_dcdat > 0)
                        {
                            var row = tbl.NewRow();
                            row["dauma"] = dauma;
                            row["hehang"] = tenhehang;
                            row["tong_cbmcandat"] = item.cbmdat;
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
                            if (tuanthu < 52)
                                tuanthu = tuanthu + 1;
                            else
                            {
                                tuanthu = 1;
                                nam += 1;
                            }

                            slconlai_tuan = db.md_nangluc
                                .Where(s => s.hehang == item.nhomnangluc_id &
                                s.tuan == tuanthu & s.nam == nam).Select(s => s.soluongconlai).FirstOrDefault();
                        }

                        if(slconlai_tuan > sl_dcdat & sl_dcdat > 0 & slconlai_tuan > 0)
                        {
                            var row = tbl.NewRow();
                            row["dauma"] = dauma;
                            row["hehang"] = tenhehang;
                            row["tong_cbmcandat"] = item.cbmdat;
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

                            sl_dcdat = 0;
                        }

                        if(slconlai_tuan == 0 & sl_dcdat > 0)
                        {
                            if (tuanthu < 52)
                                tuanthu = tuanthu + 1;
                            else
                            {
                                tuanthu = 1;
                                nam += 1;
                            }
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
        }
        return tbl;
    }
}