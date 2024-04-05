<%@ WebHandler Language="C#" Class="JQGridMD_00_NhapnoiboModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_NhapnoiboModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public class maHHVT_SLThieu_LaBTP
    {
        public string vtID { get; set; }
        public string maHH { get; set; }
        public string maVT { get; set; }
        public string donhang { get; set; }
        public string background { get; set; }
        public decimal SLCan { get; set; }
        public decimal SLCo { get; set; }
        public decimal SLThieu { get; set; }
        public bool LaBTP { get; set; }
    }

    public class NNNB
    {
        public md_nhapkhonb_cdh cdh { get; set; }
        public string md_nhapkhonb_cdh_id { get; set; }
        public string ma_sanpham { get; set; }
        public string tenhang { get; set; }
        public string bomId { get; set; }
        public string cdhTsxLsxId { get; set; }
        public string lsx_to { get; set; }
        public string md_sanpham_id { get; set; }
        public decimal? sl_nhap1 { get; set; }
        public decimal? sl_nhap2 { get; set; }
    }

    public HelperEntity helperEntity = new HelperEntity();
    EntityContext db;
    EntityFunction entityFunc;
    User_TK userTK = null;
    Public pub = new Public();

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
            case "CA_01_NhapKho":
                this.CA_01_NhapKho(context);
                break;
            case "CA_01_TraPNKVeBenDeNghi":
                this.CA_01_TraPNKVeBenDeNghi(context);
                break;
            default:
                break;
        }

        db.Dispose();
    }

    public void CA_01_TraPNKVeBenDeNghi(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

        try
        {
            foreach (var id_del_ in ids)
            {
                var object_ = db.md_nhapkhonb.Where(p => p.md_nhapkhonb_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg += $@"<br><b>{id_del_}</b>: Không tìm thấy đối tượng cần xóa.";
                }
                else if (object_.trangthai != Helper.DANHAN)
                {
                    msg += $@"<br><b>{object_.sochungtu}</b>: không ở trạng thái ""Đã Xác Nhận"".";
                }
                else
                {
                    VNN_Function.Write_log(context, ma_module, null, oper, "PNKNB:" + object_.sochungtu, db);
                    object_.trangthai = Helper.SOANTHAO;
                    var ksds = db.md_kho_dasudung.Where(s => s.sctlienquan == object_.chungtu_lenhsx & s.md_phanxuong_id == object_.nhaptu).ToList();
                    foreach(var ksd in ksds)
                    {
                        ksd.soluong_dadung = ksd.soluong_dadung2;
                    }
                }
            }

            if (msg.Length <= 0)
                db.SaveChanges();
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

        if (msg.Length <= 0)
        {
            msg = $@"<div style='color:blue'>Xóa phiếu đề nghị nhập kho đã chọn thành công.</div>";
            VNN_Function.loaddulieu_Auto(db, ma_module);
        }
        else
        {
            msg = $@"<div error style='color:red'>{msg.Substring(4)}</div>";
        }

        context.Response.Write(msg);
    }

    public void CA_01_NhapKho(HttpContext context)
    {
        string msg = "", msg_success = "", fmtErr = "<div style='color:red'>{0}</div>";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');

        try
        {
            var bgncs = pub.layBGGiaNhanCongs(db);
            var pbgnc = pub.layPBGGiaNhanCong(db, bgncs);

            //if (pbgnc == null)
            //{
            //    msg = string.Format(fmtErr, string.Format(@"Lỗi: Không tìm thấy phiên bản giá nhân công."));
            //    goto EndEventHandler;
            //}

            var ngayKCS = VNN_Config.setDateTime(context.Request.Form["ngayKCS"]);
            if (!ngayKCS.IsDate())
            {
                msg = string.Format(fmtErr, string.Format(@"Lỗi: Ngày nhập kho có giá trị sai."));
                goto EndEventHandler;
            }

            //Xu Ly nhap kho
            var nk = db.md_nhapkhonb.Where(s => vnn.Contains(s.md_nhapkhonb_id)).FirstOrDefault();
            if (nk == null)
            {
                msg = string.Format(fmtErr, string.Format(@"Lỗi: Không tìm thấy phiếu nhập kho này."));
                goto EndEventHandler;
            }
            else if (nk.trangthai == Helper.HIEULUC)
            {
                msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" đã hiệu lực.</div>", nk.sochungtu);
                goto EndEventHandler;
            }
            else if (nk.trangthai != Helper.DANHAN)
            {
                msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" cần ở trạng thái ""Đã Xác Nhận"".</div>", nk.sochungtu);
                goto EndEventHandler;
            }
            else if (string.IsNullOrEmpty(nk.denkho))
            {
                msg = string.Format(fmtErr, string.Format(@"Dòng ""{0}"" chưa có kho hoặc phân xưởng đến.", nk.sochungtu));
                goto EndEventHandler;
            }

            var md_nhapkhonb_cdhs = (from a in db.md_nhapkhonb_cdh
                                     join d in db.md_sanpham on a.md_sanpham_id equals d.md_sanpham_id
                                     where a.md_nhapkhonb_id == nk.md_nhapkhonb_id & (a.sl_nhap ?? 0) > 0
                                     orderby a.tenhang, d.ma_sanpham
                                     select new NNNB
                                     {
                                         cdh = a,
                                         md_nhapkhonb_cdh_id = a.md_nhapkhonb_cdh_id,
                                         ma_sanpham = d.ma_sanpham,
                                         md_sanpham_id = d.md_sanpham_id,
                                         sl_nhap1 = a.sl_muonnhap,
                                         sl_nhap2 = a.sl_nhap,
                                         bomId = a.bomId,
                                         cdhTsxLsxId = a.cdhTsxLsxId,
                                         lsx_to = a.lsx_to,
                                         tenhang = a.tenhang
                                     })
                                    .ToList();

            if (md_nhapkhonb_cdhs.Sum(s => s.sl_nhap2.GetValueOrDefault(0)) <= 0)
            {
                msg = string.Format(fmtErr, string.Format(@"Lỗi: phải có ít nhất 1 dòng có số lượng nhập kho lớn hơn 0."));
                goto EndEventHandler;
            }

            var vts = new List<md_lenhsanxuat_tosx_vattu>();
            var cdhSXsAll = new List<md_lenhsanxuat_tosx_cdh>();
            var lsxIds = new List<string>();
            var vtErrs = new List<maHHVT_SLThieu_LaBTP>();
            foreach (var dh1 in md_nhapkhonb_cdhs)
            {
                var sp1 = dh1.ma_sanpham;
                var cdhids = dh1.lsx_to.Split(',').ToList();
                var cdhSXs = db.md_lenhsanxuat_tosx_cdh.Where(s => cdhids.Contains(s.md_lenhsanxuat_tosx_cdh_id)).ToList()
                        .OrderBy(s => cdhids.IndexOf(s.md_lenhsanxuat_tosx_cdh_id)).ToList();
                cdhSXsAll.AddRange(cdhSXs);
                var slmuonNhap = dh1.sl_nhap2.GetValueOrDefault(0);

                //foreach (var cdhSX in cdhSXs)
                //{
                //    if (slmuonNhap > 0)
                //    {
                //        var slSanXuat = cdhSX.sl_chiato.GetValueOrDefault(0) -
                //                cdhSX.sl_chiato2.GetValueOrDefault(0) -
                //                cdhSX.sl_datncc.GetValueOrDefault(0) -
                //                cdhSX.sl_datncc2.GetValueOrDefault(0) -
                //                cdhSX.sl_danhapkho.GetValueOrDefault(0);

                //        var slmuonNhap2 = slmuonNhap > slSanXuat ? slSanXuat : slmuonNhap;
                //        slmuonNhap = slmuonNhap - slmuonNhap2;

                //        var bomSPs = db.md_lenhsanxuat_tosx_vattuBackup
                //            .Join(db.md_sanpham, a => a.vt, b => b.md_sanpham_id, (a, b) => new { a, b })
                //            .Where(s =>
                //                s.a.md_lenhsanxuat_tosx_id == cdhSX.md_lenhsanxuat_tosx_id
                //                & s.a.sp == dh1.md_sanpham_id
                //                & s.a.sp1 == cdhSX.sp1
                //                & s.a.sp2 == cdhSX.macuoi
                //                & s.a.sp3 == cdhSX.mathaydoi
                //                & (s.a.soluong ?? 0) > 0
                //                )
                //            .GroupBy(s => new { s.a.vt, s.b.ma_sanpham, s.a.sp, s.a.sp1, s.a.sp2, s.a.sp3, s.a.md_lenhsanxuat_tosx_id })
                //            .Select(s => new
                //            {
                //                idVT = s.Key.vt,
                //                maVT = s.Key.ma_sanpham,
                //                s.Key.sp,
                //                s.Key.sp1,
                //                s.Key.sp2,
                //                s.Key.sp3,
                //                s.Key.md_lenhsanxuat_tosx_id,
                //                soluong = s.Max(t => t.a.soluong)
                //            })
                //            .Distinct()
                //            .OrderBy(s => new { s.maVT, s.sp1, s.sp2, s.sp3 })
                //            .ToList();

                //        foreach (var vtB in bomSPs)
                //        {
                //            var slth = vtB.soluong.GetValueOrDefault(0) * slmuonNhap2;

                //            var vt2Server = db.md_lenhsanxuat_tosx_vattu.Where(s => s.md_lenhsanxuat_tosx_id == vtB.md_lenhsanxuat_tosx_id & s.md_sanpham_id == vtB.idVT & s.sp1 == sp1 & s.sp2 == vtB.sp2 & s.sp3 == vtB.sp3).FirstOrDefault();
                //            var vt2 = db.md_lenhsanxuat_tosx_vattu.Local.Where(s => s.md_lenhsanxuat_tosx_id == vtB.md_lenhsanxuat_tosx_id & s.md_sanpham_id == vtB.idVT & s.sp1 == sp1 & s.sp2 == vtB.sp2 & s.sp3 == vtB.sp3).FirstOrDefault();

                //            var msgErr = new maHHVT_SLThieu_LaBTP();
                //            msgErr.vtID = vtB.idVT;
                //            msgErr.maHH = dh1.ma_sanpham;
                //            msgErr.maVT = vtB.maVT;
                //            msgErr.donhang = dh1.tenhang;
                //            msgErr.SLCan = slth;
                //            msgErr.SLCo = vt2.sl_hanngach.GetValueOrDefault(0);
                //            msgErr.background = "";
                //            msgErr.LaBTP = vt2.bantp.GetValueOrDefault(false);
                //            vtErrs.Add(msgErr);
                //        }
                //    }
                //}
            }

            //var vtsGroup =
            //vtErrs
            //.GroupBy(s => new { s.vtID, s.maVT, s.LaBTP })
            //.Select(s => new
            //{
            //    s.Key.vtID,
            //    s.Key.maVT,
            //    s.Key.LaBTP,
            //    SLCan = s.Sum(t => t.SLCan),
            //    SLCo = s.Sum(t => t.SLCo),
            //    SLDaDung = db.md_kho_dasudung.Where(t => t.md_sanpham_id == s.Key.vtID & t.sctlienquan == nk.chungtu_lenhsx & t.md_phanxuong_id == nk.nhaptu).ToList().Sum(t => t.soluong_dadung2.GetValueOrDefault(0)),
            //    SLtruNo = db.md_kho_ghino.Where(t => t.md_sanpham_id == s.Key.vtID & t.sctlienquan == nk.chungtu_lenhsx & t.md_phanxuong_id == nk.nhaptu & t.soluong_no < 0).ToList().Sum(t => 0 - t.soluong_no.GetValueOrDefault(0))
            //})
            //.ToList();

            //var msgErrsUni = vtsGroup.Where(s => s.SLCan > s.SLCo + s.SLtruNo - s.SLDaDung).OrderBy(s => s.LaBTP).ToList();
            //if (msgErrsUni.Count > 0)
            //{
            //    string TrVTTs = "";
            //    foreach (var a in msgErrsUni)
            //    {
            //        string TrVTT = $@"
            //        <tr style='color:red;background-color:beige;'>
            //            <td style='padding:4px'>{a.maVT}</td>
            //            <td style='padding:4px'>{a.SLCan.DropTrailingZeros()}</td>
            //            <td style='padding:4px'>{(a.SLCo + a.SLtruNo - a.SLDaDung).DropTrailingZeros()}</td>
            //            <td style='padding:4px'>{(a.SLCan - (a.SLCo + a.SLtruNo - a.SLDaDung)).DropTrailingZeros()}</td>
            //        </tr>
            //    ";

            //        TrVTTs += TrVTT;
            //    }

            //    msg = $@"
            //    <table style='width:100%; text-align:center; background-color:#CCC;'>
            //        <tr>
            //            <th style='padding:4px'>Mã vật tư</th>
            //            <th style='padding:4px'>SL cần</th>
            //            <th style='padding:4px'>SL đã có</th>
            //            <th style='padding:4px'>SL còn thiếu</th>
            //        </tr>
            //        {TrVTTs}
            //    </table>";
            //}
            //else
            //{
            //    foreach (var vt in vtsGroup)
            //    {
            //        var vtddServer = db.md_kho_dasudung.Where(s =>
            //            s.md_sanpham_id == vt.vtID
            //            & s.sctlienquan == nk.chungtu_lenhsx
            //            & s.md_phanxuong_id == nk.nhaptu).FirstOrDefault();

            //        var vtdd = db.md_kho_dasudung.Local.Where(s =>
            //            s.md_sanpham_id == vt.vtID
            //            & s.sctlienquan == nk.chungtu_lenhsx
            //            & s.md_phanxuong_id == nk.nhaptu).FirstOrDefault();

            //        if (vtdd == null)
            //        {
            //            vtdd = new md_kho_dasudung();
            //            vtdd.md_kho_dasudung_id = Helper.getNewId();
            //            vtdd.md_phanxuong_id = nk.nhaptu;
            //            vtdd.md_sanpham_id = vt.vtID;
            //            vtdd.sctlienquan = nk.chungtu_lenhsx;
            //            vtdd.soluong_dadung2 = vt.SLCan;
            //            vtdd.soluong_dadung = vtdd.soluong_dadung2;
            //            vtdd.lsx_to = vt.maVT;
            //            vtdd = Helper.setDefaultValueWhenInsertOrUpdate(vtdd, userTK, false);
            //            db.md_kho_dasudung.Add(vtdd);
            //        }
            //        else
            //        {
            //            vtdd.soluong_dadung2 = vtdd.soluong_dadung2.GetValueOrDefault(0) + vt.SLCan;
            //            vtdd.soluong_dadung = vtdd.soluong_dadung2;
            //        }
            //    }
            //}

            if (msg.Length <= 0)
            {
                foreach (var dh1 in md_nhapkhonb_cdhs)
                {
                    var dh = dh1.cdh;
                    var cdhids = dh1.lsx_to.Split(',').ToList();
                    if (dh.sl_nhap > 0)
                    {
                        decimal sl_nhap = dh.sl_nhap.Value;
                        //--cap nhat so luong xuat
                        dh.sl_danhap = sl_nhap;

                        if (pbgnc != null)
                        {
                            var giasp = db.md_giasanpham.Where(s =>
                                s.md_sanpham_id == dh.md_sanpham_id
                                & s.md_donvitinhsanpham_id == dh.md_donvitinhsanpham_id
                                & s.md_phienbangia_id == pbgnc.md_phienbangia_id
                                ).FirstOrDefault();

                            if (giasp != null)
                                dh.gianhancong = giasp.gia.GetValueOrDefault(0);
                        }
                        //--cap nhat vao kho
                        string khospId = nhap_kho(db, dh, nk, 1, userTK);
                        //--tao lich su nhap kho
                        helperEntity.obj = new HelperEntity.objLSNX();
                        helperEntity.obj.spId = dh.md_sanpham_id;
                        helperEntity.obj.dvtSpId = dh.md_donvitinhsanpham_id;
                        helperEntity.obj.slDichChuyen = dh.sl_nhap.GetValueOrDefault(0);
                        helperEntity.obj.dongNhapXuat = nk.sochungtu;
                        helperEntity.obj.sctDonHang = nk.donhang_thamchieu;
                        helperEntity.obj.giaTriVND = 0;
                        helperEntity.obj.khoId = nk.denkho;
                        helperEntity.obj.kieuchuyen = helperEntity.kieuNhapKho;
                        helperEntity.obj.ngayChuyen = ngayKCS;
                        helperEntity.obj.theoKg = false;
                        helperEntity.obj.laphieuKK = true;
                        helperEntity.themHoacSuaLichSuNhapXuatKho(db, userTK);
                        //--cap nhat lenh san xuat
                        if (sl_nhap > 0)
                        {
                            var sl_nhapSav = sl_nhap;
                            var cdhSXs = cdhSXsAll.Where(s => cdhids.Contains(s.md_lenhsanxuat_tosx_cdh_id)).ToList();
                            foreach (var cdhLSX in cdhSXs)
                            {
                                if (sl_nhapSav > 0)
                                {
                                    var sltd = cdhLSX.sl_chiato.GetValueOrDefault(0) - cdhLSX.sl_chiato2.GetValueOrDefault(0)
                                        - cdhLSX.sl_datncc.GetValueOrDefault(0) - cdhLSX.sl_datncc2.GetValueOrDefault(0)
                                        - cdhLSX.sl_danhapkho.GetValueOrDefault(0);
                                    var sln = sl_nhapSav > sltd ? sltd : sl_nhapSav;
                                    cdhLSX.sl_danhapkho = cdhLSX.sl_danhapkho.GetValueOrDefault(0) + sln;
                                    sl_nhapSav = sl_nhapSav - sln;
                                    lsxIds.Add(cdhLSX.md_lenhsanxuat_id);
                                }
                            }

                            msg_success += string.Format(@"
                                <div style='color:blue'>
                                    Dòng ""{0}"" của ""{1}"" đã nhập kho thành công, số lượng nhập là: ""{2}""
                                </div>", nk.sochungtu, dh1.ma_sanpham, sl_nhap.DropTrailingZeros());
                        }
                    }
                }


                msg = msg_success + msg;
                nk.trangthai = Helper.HIEULUC;
                nk.ngaychuyen = ngayKCS;
                nk.ngayhieuluc = DateTime.Now;

                if (pbgnc != null)
                {
                    nk.banggiaNC = pbgnc.md_banggia_id;
                    nk.phienbangiaNC = pbgnc.md_phienbangia_id;
                }
                db.SaveChanges();

                var updated = false;
                lsxIds = lsxIds.Distinct().ToList();
                var lsxsTron = db.md_lenhsanxuat.Where(s => lsxIds.Contains(s.md_lenhsanxuat_id) & (s.dhtron ?? false) == true).ToList();
                foreach (var lsx in lsxsTron)
                {
                    var tsxs = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id).ToList();
                    var tsxIds = tsxs.Select(s => s.md_lenhsanxuat_tosx_id).ToList();
                    var cdh = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                        tsxIds.Contains(s.md_lenhsanxuat_tosx_id) &
                        (s.sl_chiato ?? 0) - (s.sl_chiato2 ?? 0) - (s.sl_datncc ?? 0) - (s.sl_datncc2 ?? 0) - (s.sl_danhapkho ?? 0) > 0
                        ).Count() <= 0;
                    if (cdh)
                    {
                        updated = true;
                        var dsdh = db.c_danhsachdathang.Where(s => s.so_po == lsx.donhang_thamchieu).FirstOrDefault();
                        if (dsdh != null)
                        {
                            dsdh.trangthai = Helper.KETTHUC;
                            dsdh.md_trangthai_id = Helper.ChoDG;
                            var dsdhDHs = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).ToList();
                            foreach (var dsdhDH in dsdhDHs)
                            {
                                dsdhDH.sl_nhaphang = dsdhDH.sl_dathang.GetValueOrDefault(0) - dsdhDH.sl_giamhanngach.GetValueOrDefault(0);
                                dsdhDH.sl_conlai = 0;
                            }
                        }
                    }
                }

                var lsxDaHoanThanh = cdhSXsAll.Where(s =>
                    s.sl_danhapkho.GetValueOrDefault(0) -
                    s.sl_chiato.GetValueOrDefault(0) -
                    s.sl_chiato2.GetValueOrDefault(0) -
                    s.sl_datncc.GetValueOrDefault(0) -
                    s.sl_datncc2.GetValueOrDefault(0) < 0).Count() <= 0;

                if(lsxDaHoanThanh)
                {
                    var lsx2 = db.md_lenhsanxuat2.Where(s => s.sochungtu == nk.chungtu_lenhsx).FirstOrDefault();
                    if (lsx2 != null)
                    {
                        lsx2.trangthai = Helper.KETTHUC;
                        updated = true;
                    }
                }

                if (updated)
                    db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = $@"<div style='color:red'>{ex.ToString()}</div>";
        }

    EndEventHandler:;
        context.Response.Write(msg);
    }

    //nhap kho
    public string nhap_kho(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb nk, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        var spServer = db.md_kho_sanpham.Where(s => s.md_kho_id == nk.denkho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        var sp = db.md_kho_sanpham.Local.Where(s => s.md_kho_id == nk.denkho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        var add = sp == null;
        if (add)
        {
            sp = new md_kho_sanpham();
            sp.md_kho_sanpham_id = id_new;
            sp.soluong = (dh.sl_nhap * nhanvoi);
        }
        else
        {
            id_new = sp.md_kho_sanpham_id;
            sp.soluong += (dh.sl_nhap * nhanvoi);
        }
        sp.md_kho_id = nk.denkho;
        sp.md_sanpham_id = dh.md_sanpham_id;

        sp = Helper.setDefaultValueWhenInsertOrUpdate(sp, us, false);
        sp.hoatdong = true;

        //Kiem tra
        if (add)
        {
            sp.ngaytao = DateTime.Now;
            sp.ngaycapnhat = DateTime.Now;
            db.md_kho_sanpham.Add(sp);
        }
        else
        {
            sp.ngaycapnhat = DateTime.Now;
        }
        return id_new;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}