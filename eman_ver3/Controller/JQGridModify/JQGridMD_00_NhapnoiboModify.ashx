<%@ WebHandler Language="C#" Class="JQGridMD_00_NhapnoiboModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_NhapnoiboModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_NhapKho":
                this.CA_01_NhapKho(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_NhapKho(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNKNB", 1);
        int count_slnhap = 0;
        using (var transaction = db.Database.BeginTransaction())
        {
            bool commit = true;
            try
            {
                //Xu Ly nhap kho
                foreach (var nk in db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id == id).ToList())
                {
                    if (nk.trangthai == "HIEULUC")
                    {
                        msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" đã hiệu lực.</div>", nk.sochungtu);
                        break;
                    }
                    List<NNNB> md_nhapkhonb_cdhs = new List<NNNB>();
                    if (string.IsNullOrEmpty(nk.baotri_vattu))
                    {
                        //tach bom
                        md_nhapkhonb_cdhs = (from a in db.md_nhapkhonb_cdh
                                             join b in db.md_sanpham_bom on a.md_sanpham_id equals b.md_sanpham_id
                                             join e in db.md_sanpham_bom_vattu on b.md_sanpham_bom_id equals e.md_sanpham_bom_id
                                             join d in db.md_sanpham on e.md_sanpham_id equals d.md_sanpham_id
                                             where a.md_nhapkhonb_id == nk.md_nhapkhonb_id & b.trangthai == "HIEULUC"
                                             select new { a.md_nhapkhonb_cdh_id, d.ma_sanpham, e.md_sanpham_id }).
                                                Select(s=> new NNNB() {
                                                    md_nhapkhonb_cdh_id = s.md_nhapkhonb_cdh_id,
                                                    ma_sanpham = s.ma_sanpham,
                                                    md_sanpham_id = s.md_sanpham_id
                                                }).ToList();
                    }
                    else
                    {
                        md_nhapkhonb_cdhs = (from a in db.md_nhapkhonb_cdh
                                             join d in db.md_sanpham on a.md_sanpham_id equals d.md_sanpham_id
                                             select new { a.md_nhapkhonb_cdh_id, d.ma_sanpham, d.md_sanpham_id })
                                             .Select(s=> new NNNB() {
                                                    md_nhapkhonb_cdh_id = s.md_nhapkhonb_cdh_id,
                                                    ma_sanpham = s.ma_sanpham,
                                                    md_sanpham_id = s.md_sanpham_id
                                                }).ToList();
                    }

                    //kiem tra phieu nhap kho la tu tao tay hay thua ke tu lenh san xuat
                    var lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == nk.md_lenhsanxuat_id).Take(1).FirstOrDefault();
                    List<string> arr_lenhsanxuat_tosx_id = db.md_lenhsanxuat_tosx.
                            Where(s => s.md_lenhsanxuat_id == nk.md_lenhsanxuat_id).
                            Select(s => s.md_lenhsanxuat_tosx_id).ToList();

                    var md_lenhsanxuat_tosx_cdhs = db.md_lenhsanxuat_tosx_cdh.
                            Where(s => arr_lenhsanxuat_tosx_id.Contains(s.md_lenhsanxuat_tosx_id));
                    if (nk.md_lenhsanxuat_tosx_id != null)
                    {
                        md_lenhsanxuat_tosx_cdhs = md_lenhsanxuat_tosx_cdhs.Where(s => s.md_lenhsanxuat_tosx_id == nk.md_lenhsanxuat_tosx_id);
                    }

                    foreach (var dh1 in md_nhapkhonb_cdhs.OrderBy(s => s.ma_sanpham).ToList())
                    {
                        var dh = db.md_nhapkhonb_cdh.FirstOrDefault(s => s.md_nhapkhonb_cdh_id == dh1.md_nhapkhonb_cdh_id);
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                        /// phan khac
                        decimal nhanvoi = 1;
                        if (nk.denkho == null & nk.denkho == null | nk.denkho == "" & nk.denkho == "")
                        {
                            msg += string.Format(@"<div style='color:red'>
                            Lỗi: dòng ""{0}"" chưa có kho hoặc phân xưởng đến.
                        </div>", nk.sochungtu);
                        }
                        else if (dh.sl_nhap < 0)
                        {
                            msg += string.Format(@"<div style='color:red'>
                            Lỗi: ""{0}"" Số lượng nhập phải lớn hơn 0.
                        </div>", sp.ma_sanpham);
                        }

                        if (msg.Length <= 0 & dh.sl_nhap > 0)
                        {
                            count_slnhap = 1;
                            decimal sl_nhap = dh.sl_nhap.Value;
                            //--cap nhat so luong xuat
                            edit_nhap(db, dh, us);
                            db.SaveChanges();
                            //--cap nhat vao kho
                            string khospId = nhap_kho(db, dh, nk, nhanvoi, us);
                            db.SaveChanges();
                            //--cap nhat vao kho hạn sử dụng
                            msg += add_kho_hsd(db, dh, nk, us, khospId);
                            db.SaveChanges();
                            //--tao lich su nhap kho
                            add_kho_ls(db, dh, nk, nhanvoi, us);
                            db.SaveChanges();
                            //--cap nhat lenh san xuat
                            decimal sl_nhap_cuoi = sl_nhap * nhanvoi;
                            decimal sl_nhap_cuoi2 = sl_nhap_cuoi;
                            if (sl_nhap > 0)
                            {
                                foreach (var lsx_to_cdh in md_lenhsanxuat_tosx_cdhs.
                                        Where(s => s.md_sanpham_id == sp.md_sanpham_id).ToList())
                                {
                                    sl_nhap = sl_nhap_cuoi2;
                                    if (sl_nhap_cuoi2 > lsx_to_cdh.sl_chiato.Value)
                                    {
                                        sl_nhap_cuoi2 = sl_nhap_cuoi2 - lsx_to_cdh.sl_chiato.Value;
                                        sl_nhap = lsx_to_cdh.sl_chiato.Value;
                                    }
                                    var tsx = db.md_lenhsanxuat_tosx.FirstOrDefault(s => s.md_lenhsanxuat_tosx_id == lsx_to_cdh.md_lenhsanxuat_tosx_id);
                                    lsx_to_cdh.sl_danhapkho += sl_nhap;
                                    lsx_to_cdh.sl_nhapkho = 0;
                                    var ddhpx_th = new md_dondathangphanxuong_tinhhinh
                                    {
                                        md_dondathangphanxuong_tinhhinh_id = Helper.getNewId(),
                                        md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id,
                                        md_sanpham_id = sp.md_sanpham_id,
                                        md_to_id = tsx.md_phanxuong_to_id,
                                        sl_dat = dh.tong_sl_dat,
                                        macuoi = lsx_to_cdh.macuoi,
                                        noigiaohang = lsx_to_cdh.noigiaohang,
                                        sl_hoanthanh = sl_nhap,
                                        md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id,
                                        ngayhoanthanh = nk.ngaychuyen,
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
                                        hoatdong = true,
                                        ngaytao = DateTime.Now,
                                        ngaycapnhat = DateTime.Now
                                    };
                                    db.md_dondathangphanxuong_tinhhinh.Add(ddhpx_th);
                                }

                                foreach (var ddhpx_cdh in db.md_dondathangphanxuong_cdh.
                                        Where(s => s.md_dondathangphanxuong_id == lsx.md_dondathangphanxuong_id &
                                        s.md_sanpham_id == sp.md_sanpham_id).ToList())
                                {
                                    ddhpx_cdh.sl_hoanthanh += sl_nhap_cuoi;
                                }
                                msg_success += string.Format(@"<div style='color:blue'>
                                Dòng ""{0}"" của ""{1}"" đã nhập kho thành công, số lượng nhập là: ""{2}""
                            </div>", nk.sochungtu, sp.ma_sanpham, sl_nhap.DropTrailingZeros());
                            }
                        }
                    }
                    if (count_slnhap <= 0 & msg == "")
                    {
                        msg += string.Format(@"<div style='color:red'>
                        Dòng ""{0}"" phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.
                    </div>", nk.sochungtu);
                    }
                    //Kiem tra de chuyen thanh Hieu Luc
                    if (msg.Length <= 0)
                    {
                        msg = msg_success + msg;
                        nk.trangthai = "HIEULUC";
                        db.SaveChanges();

                        var lsx_nht = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == nk.md_lenhsanxuat_id).FirstOrDefault();
                        var dmh = db.md_dondathangphanxuong.Where(s => s.md_dondathangphanxuong_id == lsx_nht.md_dondathangphanxuong_id).FirstOrDefault();
                        dmh.phieunhapkho = "Đã nhập kho";
                        int danhaphet = 1, codong = 0;
                        foreach (var cdh in db.md_dondathangphanxuong_cdh.
                                Where(s => s.md_dondathangphanxuong_id == lsx_nht.md_dondathangphanxuong_id).ToList())
                        {
                            if (cdh.sl_hoanthanh.Value < cdh.tong_sl_dat.Value)
                            {
                                danhaphet = 0;
                            }
                            codong = 1;
                        }

                        if (codong == 1 & danhaphet == 1)
                        {
                            dmh.md_trangthai_id = "KETTHUC";
                            lsx_nht.md_trangthai_id = "HOANTHANH";
                            db.SaveChanges();
                        }
                    }
                    else
                        commit = false;
                }
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.Message;
            }
            if (commit == true)
                transaction.Commit();
            else
                transaction.Rollback();
        }
        context.Response.Write(msg);
    }
    //--cap nhat so luong xuat
    public string edit_nhap(EntityContext db, md_nhapkhonb_cdh dh, User_TK us)
    {
        string id_new = dh.md_nhapkhonb_id;
        md_nhapkhonb nk = db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id == dh.md_nhapkhonb_id).FirstOrDefault();
        decimal sl_danhap = dh.sl_danhap.Value + dh.sl_nhap.Value;
        if (dh.tong_sl_dat <= dh.sl_danhap + dh.sl_nhap)
        {
            sl_danhap = dh.tong_sl_dat.Value;
            dh.check_kho = true;
        }

        dh.sl_danhap = dh.sl_nhap + dh.sl_danhap;
        dh.ngaycapnhat = DateTime.Now;
        nk.ngaycapnhat = DateTime.Now;
        foreach (md_nhapkhonb check_xk in db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id != nk.md_nhapkhonb_id & s.md_lenhsanxuat_tosx_id == nk.md_lenhsanxuat_tosx_id & s.trangthai == "SOANTHAO"))
        {
            foreach (md_nhapkhonb_cdh ck_dh in db.md_nhapkhonb_cdh.Where(s => s.md_nhapkhonb_id == check_xk.md_nhapkhonb_id & s.md_sanpham_id == dh.md_sanpham_id))
            {
                ck_dh.tong_sl_dat = ck_dh.tong_sl_dat - sl_danhap;
                ck_dh.sl_nhap = 0;
            }
        }
        return id_new;
    }

    //nhap kho
    public string nhap_kho(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb nk, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_sanpham check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == nk.denkho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;
        if (check_khosp == null)
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

        sp.nguoitao = us.ad_user_id;
        sp.vaitrotao = us.ad_role_id;
        sp.bophantao = us.md_phongban_id;
        sp.value_nguoitao = us.ma_user;
        sp.value_vaitrotao = us.ten_role;
        sp.value_bophantao = us.ten_phongban;
        sp.nguoicapnhat = us.ad_user_id;
        sp.vaitrocapnhat = us.ad_role_id;
        sp.bophancapnhat = us.md_phongban_id;
        sp.value_nguoicapnhat = us.ma_user;
        sp.value_vaitrocapnhat = us.ten_role;
        sp.value_bophancapnhat = us.ten_phongban;
        sp.hoatdong = true;

        //Kiem tra
        if (check_khosp == null)
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

    public string add_kho_hsd(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb px, User_TK us, string khospId)
    {
        string id_new = Helper.getNewId(), msg = "";
        var check_khospHSD = db.md_kho_sanpham_hansudung.
                Where(s =>
                    s.md_sanpham_id == dh.md_sanpham_id &
                    s.ngay_hethan.Value == dh.ngay_hethan.Value &
                    s.md_kho_sanpham_id == khospId).FirstOrDefault();
        var spHSD = check_khospHSD;
        if (check_khospHSD == null)
        {
            spHSD = new md_kho_sanpham_hansudung();
            spHSD.md_kho_sanpham_hansudung_id = id_new;
            spHSD.soluong = dh.sl_nhap;
            spHSD.ngay_hethan = dh.ngay_hethan;
        }
        else
        {
            id_new = spHSD.md_kho_sanpham_hansudung_id;
            spHSD.soluong = dh.sl_nhap + spHSD.soluong;
        }
        spHSD.md_kho_sanpham_id = khospId;
        spHSD.md_sanpham_id = dh.md_sanpham_id;
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

        string btvtId = db.md_baotrivthh.Where(s => s.sochungtu == px.baotri_vattu).Select(s => s.md_baotrivthh_id).FirstOrDefault();
        var hsd = db.md_baotrivthh_cdh.
                Where(s => s.md_baotrivthh_id == btvtId & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        if (hsd != null)
            hsd.soluong_dank += dh.sl_nhap;
        else
            msg = "Lỗi";
        return msg;
    }

    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb nk, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_giaodich giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = nk.denkho;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = dh.sl_nhap * nhanvoi;
        giao.ngaychuyen = nk.ngaychuyen;
        giao.kieuchuyen = "Nhập kho";
        giao.dongnhapxuat = nk.sochungtu;
        giao.md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id;

        giao.nguoitao = us.ad_user_id;
        giao.vaitrotao = us.ad_role_id;
        giao.bophantao = us.md_phongban_id;
        giao.value_nguoitao = us.ma_user;
        giao.value_vaitrotao = us.ten_role;
        giao.value_bophantao = us.ten_phongban;
        giao.nguoicapnhat = us.ad_user_id;
        giao.vaitrocapnhat = us.ad_role_id;
        giao.bophancapnhat = us.md_phongban_id;
        giao.value_nguoicapnhat = us.ma_user;
        giao.value_vaitrocapnhat = us.ten_role;
        giao.value_bophancapnhat = us.ten_phongban;
        giao.hoatdong = true;
        giao.ngaytao = DateTime.Now;
        giao.ngaycapnhat = DateTime.Now;
        db.md_kho_giaodich.Add(giao);
        dh.sl_nhap = 0;
        return "";
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_lenhsanxuat_id = context.Request.Form["md_lenhsanxuat_id"];
        string loainhapkho = context.Request.Form["bosung"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNKNB", 1);
        string baotri_vattu = context.Request.Form["baotri_vattu"];
        string lenhsanxuat_id = "";
        md_lenhsanxuat lsx = null;
        try
        {
            if (md_lenhsanxuat_id != null & md_lenhsanxuat_id != "" & md_lenhsanxuat_id != " ")
            {
                lsx = db.md_lenhsanxuat.Where(s => s.sochungtu == md_lenhsanxuat_id).FirstOrDefault();
                if (lsx != null)
                {
                    lenhsanxuat_id = lsx.md_lenhsanxuat_id;
                }
                else
                    msg = "false#Lỗi: Lệnh sản xuất \"" + md_lenhsanxuat_id + "\" đã nhập không tồn tại";
            }
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                if (lsx == null & loainhapkho == "0")
                {
                    msg = "false#Phải chọn 1 lệnh sản xuất.";
                }
                else
                {
                    string lsxId = "";
                    if (lsx != null)
                        lsxId = lsx.md_lenhsanxuat_id;
                    string check_lsx_kho = db.md_nhapkhonb.Where(s => s.md_lenhsanxuat_id == lsxId & s.trangthai == "SOANTHAO").Select(s => s.sochungtu).FirstOrDefault();
                    if (check_lsx_kho != null & check_lsx_kho != "")
                    {
                        msg = "false#Phiếu nhập kho \"" + check_lsx_kho + "\" chưa hiệu lực.";
                    }
                    else
                    {
                        string action = "add";
                        string[] column_ex = { "md_lenhsanxuat_tosx_id" };
                        string ten_table = "md_nhapkhonb";
                        VNN_Function.SetFormValue("md_lenhsanxuat_id", lsxId);
                        VNN_Function.SetFormValue("sochungtu", sochungtu);
                        VNN_Function.Set_DefaultvalueColumn(context, action);
                        VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                        msg = "true#Thêm thành công." + "#" + id_new;
                        if (loainhapkho == "0")
                        {
                            foreach (var dhpx_cdh in db.md_dondathangphanxuong_cdh.
                                    Where(s => s.md_dondathangphanxuong_id == lsx.md_dondathangphanxuong_id).ToList())
                            {
                                decimal tong_sl_dat = dhpx_cdh.tong_sl_dat.Value - dhpx_cdh.sl_hoanthanh.Value - dhpx_cdh.sl_giamhanngach.GetValueOrDefault(0);
                                if (tong_sl_dat > 0)
                                {
                                    var cdh = new md_nhapkhonb_cdh();
                                    cdh.md_nhapkhonb_cdh_id = Helper.getNewId();
                                    cdh.md_nhapkhonb_id = id_new;
                                    cdh.md_sanpham_id = dhpx_cdh.md_sanpham_id;
                                    cdh.tong_sl_dat = tong_sl_dat;
                                    cdh.sl_danhap = 0;
                                    cdh.sl_nhap = 0;
                                    cdh.ngay_hethan = null;
                                    cdh.md_donvitinhsanpham_id = dhpx_cdh.md_donvitinhsanpham_id;
                                    cdh.check_kho = false;

                                    cdh.nguoitao = us.ad_user_id;
                                    cdh.vaitrotao = us.ad_role_id;
                                    cdh.bophantao = us.md_phongban_id;
                                    cdh.value_nguoitao = us.ma_user;
                                    cdh.value_vaitrotao = us.ten_role;
                                    cdh.value_bophantao = us.ten_phongban;
                                    cdh.nguoicapnhat = us.ad_user_id;
                                    cdh.vaitrocapnhat = us.ad_role_id;
                                    cdh.bophancapnhat = us.md_phongban_id;
                                    cdh.value_nguoicapnhat = us.ma_user;
                                    cdh.value_vaitrocapnhat = us.ten_role;
                                    cdh.value_bophancapnhat = us.ten_phongban;
                                    cdh.ngaytao = DateTime.Now;
                                    cdh.ngaycapnhat = DateTime.Now;
                                    cdh.mota = "";
                                    cdh.hoatdong = true;
                                    db.md_nhapkhonb_cdh.Add(cdh);
                                }
                            }
                            db.SaveChanges();
                        }
                        else
                        {
                            string bthhvtId = db.md_baotrivthh.Where(s => s.sochungtu == baotri_vattu).
                                    Select(s => s.md_baotrivthh_id).FirstOrDefault();
                            foreach (var dhpx_cdh in db.md_baotrivthh_cdh.
                                    Where(s => s.md_baotrivthh_id == bthhvtId).ToList())
                            {
                                decimal tong_sl_dat = dhpx_cdh.soluong_daht.GetValueOrDefault(0) - dhpx_cdh.soluong_dank.GetValueOrDefault(0);
                                if (tong_sl_dat > 0)
                                {
                                    var cdh = new md_nhapkhonb_cdh();
                                    cdh.md_nhapkhonb_cdh_id = Helper.getNewId();
                                    cdh.md_nhapkhonb_id = id_new;
                                    cdh.md_sanpham_id = dhpx_cdh.md_sanpham_id;
                                    cdh.tong_sl_dat = tong_sl_dat;
                                    cdh.sl_danhap = 0;
                                    cdh.sl_nhap = 0;
                                    cdh.ngay_hethan = dhpx_cdh.hansudung;
                                    cdh.md_donvitinhsanpham_id = dhpx_cdh.md_donvitinhsanpham_id;
                                    cdh.check_kho = false;

                                    cdh.nguoitao = us.ad_user_id;
                                    cdh.vaitrotao = us.ad_role_id;
                                    cdh.bophantao = us.md_phongban_id;
                                    cdh.value_nguoitao = us.ma_user;
                                    cdh.value_vaitrotao = us.ten_role;
                                    cdh.value_bophantao = us.ten_phongban;
                                    cdh.nguoicapnhat = us.ad_user_id;
                                    cdh.vaitrocapnhat = us.ad_role_id;
                                    cdh.bophancapnhat = us.md_phongban_id;
                                    cdh.value_nguoicapnhat = us.ma_user;
                                    cdh.value_vaitrocapnhat = us.ten_role;
                                    cdh.value_bophancapnhat = us.ten_phongban;
                                    cdh.ngaytao = DateTime.Now;
                                    cdh.ngaycapnhat = DateTime.Now;
                                    cdh.mota = "";
                                    cdh.hoatdong = true;
                                    db.md_nhapkhonb_cdh.Add(cdh);
                                }
                            }
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        string md_lenhsanxuat_id = context.Request.Form["md_lenhsanxuat_id"];
        try
        {
            string id = context.Request.Form["id"];
            md_nhapkhonb object_ = db.md_nhapkhonb.Where(p => p.md_nhapkhonb_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.trangthai != "SOANTHAO")
            {
                msg = "false#Lỗi:Đối tượng đã nhập kho";
            }

            if (md_lenhsanxuat_id != null & md_lenhsanxuat_id != "")
            {
                md_lenhsanxuat lsx = db.md_lenhsanxuat.Where(s => s.sochungtu == md_lenhsanxuat_id).FirstOrDefault();
                md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
            }
            else
            {
                msg = "false#Không tìm thấy lệnh sản xuất \"" + md_lenhsanxuat_id + "\"";
            }


            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_nhapkhonb";
                VNN_Function.SetFormValue("md_lenhsanxuat_id", md_lenhsanxuat_id);
                VNN_Function.SetFormValue("sochungtu", "VNN_notpost");
                VNN_Function.SetFormValue("nhaptu", "VNN_notpost");
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
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
        EntityContext db = new EntityContext();
        string msg = "", msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "md_nhapkhonb";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_nhapkhonb object_ = db.md_nhapkhonb.Where(p => p.md_nhapkhonb_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "Lỗi:Đối tượng đã hiệu lực " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "CHUACHUYENHET")
                {
                    msg_del = "Lỗi:Đối tượng trong trạng thái Chưa Chuyển Hết";
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    /* foreach (md_lenhsanxuat_tosx_cdh lsx_to_cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == object_.md_lenhsanxuat_tosx_id))
                     {
                         md_nhapkhonb_cdh nknb_cdh = db.md_nhapkhonb_cdh.Where(s => s.md_nhapkhonb_id == object_.md_nhapkhonb_id & s.md_sanpham_id == lsx_to_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                         if (nknb_cdh != null)
                             lsx_to_cdh.sl_dahoanthanh -= nknb_cdh.tong_sl_dat;
                     }*/
                    db.md_nhapkhonb.Remove(object_);
                }
            }
            VNN_Function.loaddulieu_Auto(db, ma_module);
            if (msg.Length <= 0)
            {
                msg = "true#Xóa thành công.";
            }
            else
            {
                msg = "false#" + msg;
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.ToUpper().Contains("REFERENCE"))
            {
                msg = "false#Lỗi: Đang được sử dụng, không thể xóa";
            }
            else
            {
                msg = "false#Lỗi: " + ex.Message;
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

    public class NNNB
    {
        public string md_nhapkhonb_cdh_id { get; set; }
        public string ma_sanpham { get; set; }
        public string md_sanpham_id { get; set; }
    }
}