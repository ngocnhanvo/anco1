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
        string msg = "";
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

                        var vcnb_cdvcs = db.md_vanchuyennoibo_cdvc.Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id & s.soluong_dichchuyen > 0);

                        var khoSPDic = new Dictionary<string, decimal>();
                        foreach (var vcnb_cdvc in vcnb_cdvcs.OrderBy(s => s.denkho).ToList())
                        {
                            vcnb_cdvc.soluong_dachuyen = vcnb_cdvc.soluong_dichchuyen.GetValueOrDefault(0);
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
                                var lht = db.md_vanchuyennoibo_dalayton.Where(s =>
                                    s.md_sanpham_id == kho_sp.md_sanpham_id
                                    & s.md_vanchuyennoibo_id == vcnb_cdvc.md_vanchuyennoibo_id).FirstOrDefault();
                                if (lht != null)
                                {
                                    var tongSLdaLT = db.md_vanchuyennoibo_dalayton.Where(s =>
                                        s.md_sanpham_id == lht.md_sanpham_id
                                        & s.lsx == lht.lsx
                                        & s.mota == "DLT").Sum(s=>s.soluong_layton);
                                    tongSLdaLT = tongSLdaLT == null ? 0 : tongSLdaLT.GetValueOrDefault(0);
                                    var sllt = lht.soluong_layton.GetValueOrDefault(0) - tongSLdaLT.GetValueOrDefault(0);
                                    lht.soluong_layton = sl_dichchuyen_thucte > sllt ? sllt : sl_dichchuyen_thucte;
                                    lht.mota = "DLT";
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
        string msg = "";
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