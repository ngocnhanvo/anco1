<%@ WebHandler Language="C#" Class="JQGridMD_00_PVCNoiBoModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_PVCNoiBoModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    EntityContext db;
    EntityFunction entityFunc;
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest(HttpContext context)
    {
        if (Security.id_taikhoan(context) != "")
        {
            db = new EntityContext();
            entityFunc = new EntityFunction();
            oper = context.Request.QueryString["oper"] == null ? context.Request.Form["oper"] : context.Request.QueryString["oper"];
            userTK = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context), db);
        }

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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');

        var koCapnhatDLSX = context.Request.Form["koCapnhatDLSX"] == "true";

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

                        vcnb.ngayhieuluc = DateTime.Now;
                        var vcnb_cdvcs = db.md_vanchuyennoibo_cdvc.Where(s => s.md_vanchuyennoibo_id == vcnb.md_vanchuyennoibo_id);

                        var khoSPDic = new Dictionary<string, decimal>();
                        foreach (var vcnb_cdvc in vcnb_cdvcs.OrderBy(s => s.denkho).ToList())
                        {
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
                                            //foreach(var ctVKCDT in db.md_hanngachPXTo_chuyenvekhoton.Where(s =>
                                            //s.md_hanngachPXTo_chitiet_id == ctHN.md_hanngachPXTo_chitiet_id
                                            //& s.stt < cTVK.stt)) {
                                            //    ctVKCDT.sldachuyen = ctVKCDT.sldachuyen.GetValueOrDefault(0) + (int)vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);
                                            //}
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
                                        cdhLSX.sl_nhapkho = cdhLSX.sl_nhapkho.GetValueOrDefault(0) + vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);

                                        var tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == cdhLSX.md_lenhsanxuat_tosx_id).FirstOrDefault();
                                        toSXId = tsx.md_lenhsanxuat_tosx_id;

                                        var tsx2 = db.md_lenhsanxuat_tosx.Where(s =>
                                            s.stt > tsx.stt
                                            & s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id
                                        ).OrderBy(s => s.stt).Take(1).FirstOrDefault();

                                        string lsxTsxIdTiepTheo = tsx2 == null ? tsx.md_lenhsanxuat_tosx_id : tsx2.md_lenhsanxuat_tosx_id;
                                        toSXId2 = lsxTsxIdTiepTheo;

                                        var dhCDTT = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                            s.md_sanpham_id == cdhLSX.md_sanpham_id
                                            & s.md_lenhsanxuat_tosx_id == lsxTsxIdTiepTheo
                                        ).FirstOrDefault();

                                        if (dhCDTT != null)
                                            dhCDTT.sl_dahoanthanh = dhCDTT.sl_dahoanthanh.GetValueOrDefault(0) + vcnb_cdvc.soluong_dachuyen.GetValueOrDefault(0);
                                    }
                                }
                            }
                            //start Xuat kho
                            string[] arr_tukho = vcnb.tukho.Split(',');
                            decimal sl_dichchuyen_thucte = vcnb_cdvc.soluong_dichchuyen.Value;
                            var spMain = db.md_sanpham.Where(s => s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                            //xuất kho
                            var lstSPId = new List<string>();
                            if (vcnb.loaichuyen == "VANCNBCTKGH")
                            {
                                sanxuat = 3;
                                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == vcnb_cdvc.md_sanpham_id).FirstOrDefault();
                                var lsxto = Extension.getLSXToId2(vcnb_cdvc.lsx_to, db);
                                var tsx = lsxto.tsx;
                                toSXId = tsx.md_lenhsanxuat_tosx_id;
                                lsx = lsxto.lsx.sochungtu;
                                var lsxSp = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                            s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                            & s.macuoi.Contains(sp.ma_sanpham));

                                tsx.ngaygiao = vcnb.ngaychuyen;
                                var tsxsInLSX = db.md_lenhsanxuat_tosx.Where(t => t.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id).Select(s=>s.md_lenhsanxuat_tosx_id).ToList();
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
                                        md_to_id = khoXuat.md_to_id,
                                        md_to_id2 = khoXuat.md_to_id,
                                        lsx = lsx,
                                        sanxuat = sanxuat,
                                        tosxId = toSXId,
                                        tosxId2 = toSXId2,
                                        gianhancong = vcnb_cdvc.gianhancong,
                                        pbgNC = vcnb.phienbangiaNC,

                                        mota = vcnb_cdvc.tenhang,
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
                                    db.md_kho_giaodich.Add(kho_gd);
                                    //add_kho_hsd(db, null, kho_sp.md_sanpham_id, sl_dichchuyen_thucte, vcnb, 0, userTK, kho_sp.md_kho_sanpham_id);
                                    coXuatKho = true;
                                }
                                //Cap nhat lai kho_gd
                                kho_sp.soluong = kho_sp.soluong.Value - sl_xuatkho;
                                db.SaveChanges();
                            }
                            //end Xuat kho

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
                            //pub.capnhatGiuCho_VCNB(vcnb.sochungtu, vcnb.chungtuthamchieu, vcnb.tukho, vcnb.md_vanchuyennoibo_id, vcnb.md_trangthai_id, db);
                            //db.SaveChanges();
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string tukho = context.Request.Form["tukho"];
        string denkho = context.Request.Form["denkho"];
        string id = context.Request.Form["id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
                var object_ = db.md_vanchuyennoibo.Where(p => p.md_vanchuyennoibo_id == id).Take(1).FirstOrDefault();
                denkho = db.md_kho.Where(s => s.md_kho_id == denkho).Select(s => s.md_kho_id).FirstOrDefault();
                tukho = db.md_kho.Where(s => s.md_kho_id == tukho).Select(s => s.md_kho_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg = string.Format(@"Lỗi:Không tìm thấy đối tượng cần sửa.");
                }
                else if (object_.md_trangthai_id == "HIEULUC")
                {
                    msg = string.Format(@"Lỗi:Dòng {0} đã Hiệu lực", object_.sochungtu);
                }
                else if (tukho == denkho)
                {
                    msg = string.Format(@"Lỗi: Kho chuyển không được giống với kho đến");
                }
                else if (string.IsNullOrEmpty(tukho) | string.IsNullOrEmpty(denkho))
                {
                    msg = string.Format(@"Lỗi:Bạn phải chọn Kho chuyển và kho đến");
                }
                else if (ngaychuyen.IsDate() == false)
                {
                    msg = string.Format(@"Lỗi:Ngày chuyển không đúng định dạng");
                }

                if (msg.Length <= 0)
                {
                    if (object_.loaichuyen == "VANCNBCTKGH")
                        object_.denkho = denkho;
                    object_.ngaychuyen = ngaychuyen;
                    object_.ngaycapnhat = DateTime.Now;
                    object_.mota = context.Request.Form["mota"];
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Cập nhật thành công");
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format(@"false#{0}", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.md_vanchuyennoibo.Where(p => p.md_vanchuyennoibo_id == id_del_).Take(1).FirstOrDefault();
                    var dcht = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần trả.", id_del_);
                    }
                    else if (object_.md_trangthai_id == "HIEULUC")
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Đã được ""Hiệu Lực"".", object_.sochungtu, object_.donhang_thamchieu);
                    }
                    else
                    {
                        VNN_Function.Write_log(context, ma_module, null, oper, "PVCNB:" + object_.sochungtu + " DHTC:" + object_.donhang_thamchieu , db);
                        object_.md_trangthai_id = "SOANTHAO";
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
                msg = string.Format(@"true#Trả phiếu đã chọn về ""Soạn Thảo"" thành công");
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = string.Format(@"false#{0}", msg.Substring(4));
                transaction.Rollback();
            }
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