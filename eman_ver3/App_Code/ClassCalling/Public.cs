using System;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Text;

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
}