using DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JQGridMD_00_DonMuaHangModify
/// </summary>
public class JQGridMD_00_DonMuaHangClass
{
    public JQGridMD_00_DonMuaHangClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void TinhThueDonHang(c_donmuahang object_, User_TK userTK, string md_phienbangia_id, string md_phienbangia_id2, EntityContext db)
    {
        decimal dongiamua = 0;
        db.c_donmuahang_thue.RemoveRange(db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id));
        db.SaveChanges();

        foreach (var cdmh1 in db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).OrderBy(s => s.md_sanpham_id).ToList())
        {
            //var gsp = db.md_giasanpham.Where(s => s.md_sanpham_id == cdmh1.md_sanpham_id & s.md_phienbangia_id == md_phienbangia_id).FirstOrDefault();
            var thue_sp = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == cdmh1.thue).FirstOrDefault();
            dongiamua = cdmh1.dongiamua.GetValueOrDefault(0);
            //if (md_phienbangia_id2 != md_phienbangia_id)
            //{
            //    cdmh1.dongiamua = dongiamua;
            //    cdmh1.giachuan = dongiamua;
            //}
            //else
            //{
            //    dongiamua = (decimal)cdmh1.dongiamua.Value;
            //}

            string md_thue_sanpham_id = "";
            if (thue_sp != null)
                md_thue_sanpham_id = thue_sp.md_thue_sanpham_id;
            cdmh1.thue = md_thue_sanpham_id;
            cdmh1.thanhtien = Math.Floor(dongiamua * cdmh1.sl_dadat.Value);
            dongiamua = 0;

            cdmh1.nguoicapnhat = userTK.ad_user_id;
            cdmh1.vaitrocapnhat = userTK.ad_role_id;
            cdmh1.bophancapnhat = userTK.md_phongban_id;
            cdmh1.ngaycapnhat = DateTime.Now;


            //Tinh thue
            var thue = new c_donmuahang_thue();
            //--
            decimal gt_thue = 0;
            if (thue_sp != null)
            {
                gt_thue = thue_sp.giatri.Value;
            }
            thue.tong_tien_thue = cdmh1.thanhtien * gt_thue / 100;
            thue.tong_tien_chiu_thue = cdmh1.thanhtien + thue.tong_tien_thue;
            //--
            thue.c_donmuahang_thue_id = Helper.getNewId();
            thue.c_donmuahang_id = cdmh1.c_donmuahang_id;
            thue.md_thue_sanpham_id = cdmh1.thue;
            thue.doanhnghiep = "";
            thue.tochuc = "";

            thue.nguoitao = userTK.ad_user_id;
            thue.vaitrotao = userTK.ad_role_id;
            thue.bophantao = userTK.md_phongban_id;
            thue.value_nguoitao = userTK.ma_user;
            thue.value_vaitrotao = userTK.ten_role;
            thue.value_bophantao = userTK.ten_phongban;

            thue.nguoicapnhat = userTK.ad_user_id;
            thue.vaitrocapnhat = userTK.ad_role_id;
            thue.bophancapnhat = userTK.md_phongban_id;
            thue.value_nguoicapnhat = userTK.ma_user;
            thue.value_vaitrocapnhat = userTK.ten_role;
            thue.value_bophancapnhat = userTK.ten_phongban;

            thue.ngaytao = DateTime.Now;
            thue.ngaycapnhat = DateTime.Now;
            thue.mota = "";
            thue.hoatdong = true;

            if (cdmh1.thue != "")
            {
                db.c_donmuahang_thue.Add(thue);
            }
        }
        db.SaveChanges();
        //Start cap nhat Thue trong don mua hang
        var c_donmuahang_thues = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id);
        List<string> id_notdel = new List<string>();
        foreach (var thue_donhang_list in c_donmuahang_thues.Select(s => new { s.md_thue_sanpham_id, s.c_donmuahang_id }).Distinct().ToList())
        {
            var c_donmuahang_thueschild = c_donmuahang_thues.Where(s => s.md_thue_sanpham_id == thue_donhang_list.md_thue_sanpham_id);
            var dmh_thue = c_donmuahang_thueschild.Take(1).FirstOrDefault();

            dmh_thue.tong_tien_thue = c_donmuahang_thueschild.Select(s => s.tong_tien_thue).Sum();
            dmh_thue.tong_tien_chiu_thue = c_donmuahang_thueschild.Select(s => s.tong_tien_chiu_thue).Sum();
            id_notdel.Add(dmh_thue.c_donmuahang_thue_id);
        }

        foreach (var dong_thue in c_donmuahang_thues.Where(s => !id_notdel.Contains(s.c_donmuahang_thue_id)).ToList())
        {
            db.c_donmuahang_thue.Remove(dong_thue);
        }
        db.SaveChanges();
        //Start cap nhat don mua hang
        decimal tong_tienhang = decimal.Parse("0.00");
        try { tong_tienhang = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).Select(s => s.thanhtien.Value).Sum(); } catch { }
        decimal tong_tienthue = decimal.Parse("0.00");
        try { tong_tienthue = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).Select(s => s.tong_tien_thue.Value).Sum(); } catch { }
        decimal tong_tatca = tong_tienhang + Math.Floor(tong_tienthue);
        //--
        string donvitinh = "VND";
        var dt = db.md_dongtien.Where(s => s.md_dongtien_id == object_.md_dongtien_id).Take(1).FirstOrDefault();
        if (dt != null) { donvitinh = dt.ma_iso; }
        //--
        var tth = VNN_ConvertMoney.convert((double)tong_tienhang, donvitinh).FirstOrDefault();
        var ttc = VNN_ConvertMoney.convert((double)tong_tatca, donvitinh).FirstOrDefault();
        object_.tong_tienhang = (decimal)tth.Value;
        object_.tong_tatca = (decimal)ttc.Value;
        object_.chu_tong_tienhang = tth.Key;
        object_.chu_tong_tatca = ttc.Key;
        db.SaveChanges();
    }
}