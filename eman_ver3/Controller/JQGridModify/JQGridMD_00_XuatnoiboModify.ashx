<%@ WebHandler Language="C#" Class="JQGridMD_00_XuatnoiboModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_XuatnoiboModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_XuatKhoNB":
                this.CA_01_XuatKhoNB(context);
                break;
            case "CA_01_TaodongxuatkhotuPNK":
                this.CA_01_TaodongxuatkhotuPNK(context);
                break;
            case "CA_01_XacNhanPXKNB":
                this.CA_01_XacNhanPXKNB(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_XacNhanPXKNB(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        var pub = new Public();
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            foreach (var xknb in db.md_xuatkhonb.Where(s => vnn.Contains(s.md_xuatkhonb_id)).ToList())
            {
                if (xknb.trangthai != "SOANTHAO")
                    msg = string.Format(@"Lỗi: phiếu ""{0}"" đã được xác nhận.", xknb.sochungtu);
                else
                {
                    if (xknb.bosung == 3)
                    {
                        if (string.IsNullOrEmpty(xknb.chungtu_lenhsx))
                            msg = string.Format(@"Lỗi: phiếu ""{0}"" chưa chọn lệnh sản xuất.", xknb.sochungtu);
                        else if (string.IsNullOrEmpty(xknb.md_lenhsanxuat_tosx_id))
                            msg = string.Format(@"Lỗi: phiếu ""{0}"" chưa chọn tổ sản xuất.", xknb.sochungtu);
                    }

                    if (msg.Length <= 0)
                        xknb.trangthai = "DANHAN";
                }
                db.SaveChanges();
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"<div class='nhan-thanhcong'>Xác nhận phiếu xuất kho thành công.</div>");
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"<div style='color:red'>Lỗi: {0}</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_TaodongxuatkhotuPNK(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string[] arr_id_phieunhap = context.Request.Form["id_phieunhap"].Split(',');
        string id = context.Request.Form["id"];
        string msg = "";
        foreach (md_xuatkhonb_cdh xknb_cdh in db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == id))
        {
            db.md_xuatkhonb_cdh.Remove(xknb_cdh);
        }
        db.SaveChanges();

        foreach (md_nhapkhonb nknb in db.md_nhapkhonb.Where(s => arr_id_phieunhap.Contains(s.md_nhapkhonb_id)).ToList())
        {
            foreach (md_nhapkhonb_cdh nknb_cdh in db.md_nhapkhonb_cdh.Where(s => s.md_nhapkhonb_id == nknb.md_nhapkhonb_id).ToList())
            {
                md_xuatkhonb_cdh check_nknb_cdh = db.md_xuatkhonb_cdh.Where(s => s.md_sanpham_id == nknb_cdh.md_sanpham_id & s.md_xuatkhonb_id == id).Take(1).FirstOrDefault();
                md_xuatkhonb_cdh xknb_cdh = null;
                if (check_nknb_cdh == null)
                {
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == nknb_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                    xknb_cdh = new md_xuatkhonb_cdh();
                    xknb_cdh.md_xuatkhonb_cdh_id = Helper.getNewId();
                    xknb_cdh.md_xuatkhonb_id = id;
                    xknb_cdh.md_sanpham_id = nknb_cdh.md_sanpham_id;
                    xknb_cdh.tong_sl_xuat = nknb_cdh.sl_danhap;
                    xknb_cdh.sl_daxuat = 0;
                    xknb_cdh.sl_xuat = 0;
                    xknb_cdh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id;
                    xknb_cdh.tenhang = sp.mota_tiengviet;
                }
                else
                {
                    xknb_cdh = check_nknb_cdh;
                    xknb_cdh.tong_sl_xuat += nknb_cdh.sl_danhap;
                }

                xknb_cdh.value_nguoicapnhat = us.ma_user;
                xknb_cdh.value_vaitrocapnhat = us.ten_role;
                xknb_cdh.value_bophancapnhat = us.ten_phongban;
                xknb_cdh.ngaycapnhat = DateTime.Now;
                xknb_cdh.nguoicapnhat = us.ad_user_id;
                xknb_cdh.vaitrocapnhat = us.ad_role_id;
                xknb_cdh.bophancapnhat = us.md_phongban_id;
                xknb_cdh.hoatdong = true;

                if (check_nknb_cdh == null)
                {
                    xknb_cdh.ngaytao = DateTime.Now;
                    xknb_cdh.nguoitao = us.ad_user_id;
                    xknb_cdh.vaitrotao = us.ad_role_id;
                    xknb_cdh.bophantao = us.md_phongban_id;
                    xknb_cdh.value_nguoitao = us.ma_user;
                    xknb_cdh.value_vaitrotao = us.ten_role;
                    xknb_cdh.value_bophantao = us.ten_phongban;
                    db.md_xuatkhonb_cdh.Add(xknb_cdh);
                }

                nknb.md_xuatkhonb_id = id;
                db.SaveChanges();
            }
        }
        msg = "<div style='color:blue'>Tạo dòng hàng từ phiếu nhập kho thành công.</div>";
        context.Response.Write(msg);
    }

    public void CA_01_XuatKhoNB(HttpContext context)
    {
        var db = new EntityContext();
        var pub = new Public();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PXKNB", 1);
        int count_slxuat = 0;
        bool commit = true;
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                //Xu Ly xuat kho
                foreach (var xk in db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == id).ToList())
                {
                    if (xk.trangthai == "HIEULUC")
                    {
                        msg = "<div style='color:red'>Lỗi: dòng \"" + xk.sochungtu + "\" đã hiệu lực.</div>";
                        break;
                    }
                    else if (xk.trangthai != "DANHAN")
                    {
                        msg = string.Format(@"<div style='color:red'>Lỗi: dòng ""{0}"" cần ở trạng thái ""Đã Xác Nhận"".</div>", xk.sochungtu);
                    }
                    else
                    {
                        //--
                        //var check_kho = db.md_xuatkhonb_cdh.Where(s => s.check_kho == true & s.md_xuatkhonb_id == xk.md_xuatkhonb_id);
                        //var check_ma = db.md_xuatkhonb_cdh.Where(s => s.md_sanpham_id != null & s.md_xuatkhonb_id == xk.md_xuatkhonb_id);
                        var md_xuatkhonb_cdhs = db.md_xuatkhonb_cdh.
                                Where(s => s.md_xuatkhonb_id == xk.md_xuatkhonb_id).ToList();
                        foreach (var dh in md_xuatkhonb_cdhs)
                        {
                            var kho = db.md_kho_sanpham.Where(s => s.md_kho_id == xk.tukho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                            decimal nhanvoi = 1;
                            if (dh.check_kho != true)
                            {
                                if (string.IsNullOrEmpty(xk.tukho))
                                {
                                    msg += "<div style='color:red'>Lỗi: dòng \"" + xk.sochungtu + "\" chưa chọn kho.</div>";
                                }
                                else if (kho == null)
                                {
                                    if (dh.sl_thucxuat > 0)
                                    {
                                        count_slxuat++;
                                        msg += "<div style='color:red'>Lỗi: \"" + sp.ma_sanpham + "\" không có trong kho.</div>";
                                    }
                                }
                                else if (dh.sl_thucxuat - dh.ghino.GetValueOrDefault(0) > (dh.tong_sl_xuat - dh.sl_daxuat))
                                {
                                    msg += string.Format(@"<div style='color:red'>
                                    Lỗi: Số lượng xuất của ""{0}"" phải nhỏ hơn ""{1}"".
                                </div>", sp.ma_sanpham, dh.tong_sl_xuat - dh.sl_daxuat);
                                }
                                else if (kho.soluong < dh.sl_thucxuat)
                                {
                                    string tendvt = db.md_donvitinhsanpham.
                                            Where(s => s.md_donvitinhsanpham_id == sp.md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
                                    msg += string.Format(@"<div style='color:red'>
                                    Lỗi: ""{0}"" số lượng trong kho chỉ còn: ""{1} {2}"".</div>",
                                        sp.ma_sanpham, kho.soluong.Value.DropTrailingZeros(), tendvt);
                                }
                            }

                            if (msg.Length <= 0 & dh.sl_thucxuat > 0)
                            {
                                count_slxuat++;
                                decimal sl_xuat = dh.sl_thucxuat.GetValueOrDefault(0) > dh.tong_sl_xuat.GetValueOrDefault(0)
                                        ? dh.tong_sl_xuat.GetValueOrDefault(0) : dh.sl_thucxuat.GetValueOrDefault(0)
                                        , sl_xuat2 = dh.sl_thucxuat.GetValueOrDefault(0);
                                //--cap nhat so luong xuat
                                string xk_id = edit_xuat(db, dh, us);
                                db.SaveChanges();
                                //--cap nhat vao kho
                                string khospId = xuat_kho(db, dh, xk, nhanvoi, us);
                                db.SaveChanges();
                                //--cap nhat han su dung
                                msg += add_kho_hsd(db, dh, xk, us, khospId);
                                db.SaveChanges();
                                //--tao lich su nhap kho
                                add_kho_ls(db, dh, xk, nhanvoi, us);
                                db.SaveChanges();

                                decimal sl_xuat_cuoi = sl_xuat * nhanvoi;
                                decimal sl_xuat_cuoi2 = sl_xuat_cuoi;
                                if (sl_xuat2 > 0)
                                {
                                    bool ghino = true;
                                    decimal? truno = dh.truno;
                                    if (new int[] { 0, 3, 4 }.Contains(xk.bosung.GetValueOrDefault(-1)))
                                    {
                                        var arrLSX = dh.lsx_to.Split(',');
                                        foreach (var lsxTo in arrLSX.OrderByDescending(s => s))
                                        {
                                            string[] arr = lsxTo.Split(new[] { " --- " }, StringSplitOptions.None);
                                            string sctLSX = arr[0];
                                            string tentoLSX = arr[1];
                                            var lsx = db.md_lenhsanxuat.Where(s => s.sochungtu == sctLSX).FirstOrDefault();
                                            string toId = db.md_phanxuong_to.Where(s => s.md_phanxuong_id == lsx.md_phanxuong_id &
                                            s.ten_to == tentoLSX).Select(s => s.md_to_id).FirstOrDefault();
                                            var lsxTSX = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                                                                & s.md_phanxuong_to_id == toId).FirstOrDefault();

                                            if (xk.bosung == 0 | xk.bosung == 3)
                                            {
                                                foreach (var ddhpx_cdh in db.md_lenhsanxuat_tosx_vattu.
                                                        Where(s =>
                                                        s.md_lenhsanxuat_tosx_id == lsxTSX.md_lenhsanxuat_tosx_id
                                                        & s.md_sanpham_id == sp.md_sanpham_id).ToList())
                                                {
                                                    decimal tslhn = ddhpx_cdh.soluong.Value - ddhpx_cdh.sl_hanngach.Value - ddhpx_cdh.sl_giamhanngach.GetValueOrDefault(0);
                                                    //xuat thieu du
                                                    if (tslhn >= sl_xuat_cuoi)
                                                    {
                                                        ddhpx_cdh.sl_hanngach += sl_xuat_cuoi;
                                                        sl_xuat_cuoi = 0;
                                                    }
                                                    //xuat du
                                                    else
                                                    {
                                                        ddhpx_cdh.sl_hanngach += tslhn;
                                                        sl_xuat_cuoi = sl_xuat_cuoi - tslhn;
                                                    }

                                                    //--ghi nợ / có
                                                    if (ghino == true)
                                                    {
                                                        add_kho_no(db, dh, xk, lsxTo, us, lsx.md_phanxuong_id, tentoLSX, dh.ghino);
                                                        ghino = false;
                                                    }

                                                    var ck_dh = db.md_xuatkhonb_cdh.Where(s =>
                                                       s.md_xuatkhonb_id != xk.md_xuatkhonb_id
                                                       & s.md_sanpham_id == dh.md_sanpham_id
                                                       & s.lsx_to.Contains(lsxTo)
                                                       & db.md_xuatkhonb.Where(t => t.md_xuatkhonb_id == s.md_xuatkhonb_id & t.trangthai != "HIEULUC").Count() > 0).FirstOrDefault();
                                                    if (ck_dh != null)
                                                    {
                                                        ck_dh.tong_sl_xuat = (ck_dh.tong_sl_xuat - dh.sl_daxuat).GetValueOrDefault(0).Set0WhenlessThan0();
                                                        ck_dh.sl_xuat = 0;
                                                        ck_dh.sl_xuat2 = 0;
                                                        if (ck_dh.truno > 0)
                                                        {
                                                            if (ck_dh.truno > ck_dh.tong_sl_xuat)
                                                                ck_dh.truno = ck_dh.tong_sl_xuat;
                                                        }

                                                        if (ck_dh.sl_thucxuat.GetValueOrDefault(0) > 0)
                                                            ck_dh.ghino = (ck_dh.sl_thucxuat - ck_dh.tong_sl_xuat + ck_dh.truno).GetValueOrDefault(0).Set0WhenlessThan0();
                                                        else
                                                            ck_dh.ghino = (ck_dh.sl_muonxuat - ck_dh.tong_sl_xuat + ck_dh.truno).GetValueOrDefault(0).Set0WhenlessThan0();
                                                    }
                                                    db.SaveChanges();
                                                }
                                            }
                                            else if (xk.bosung == 4)
                                            {
                                                string khoNext = db.md_kho.Where(s =>
                                                    s.md_phanxuong_id == lsxTSX.md_phanxuong_id
                                                    & s.md_to_id == lsxTSX.md_phanxuong_to_id).Select(s => s.md_kho_id).FirstOrDefault();
                                                string KSPID = nhap_kho(db, dh, khoNext, nhanvoi, us);
                                                add_nhapkho_hsd(db, dh, khoNext, us, KSPID);
                                                add_nhapkho_ls(db, dh, khoNext, xk.ngaychuyen, xk.sochungtu, 1, us);
                                                db.SaveChanges();
                                                foreach (var ddhpx_cdh in db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                                        s.md_lenhsanxuat_tosx_id == lsxTSX.md_lenhsanxuat_tosx_id
                                                        & s.md_sanpham_id == sp.md_sanpham_id).ToList())
                                                {
                                                    decimal tslhn = ddhpx_cdh.sl_chiato.Value - ddhpx_cdh.sl_dahoanthanh.Value;
                                                    //xuat thieu du
                                                    if (tslhn >= sl_xuat_cuoi)
                                                    {
                                                        ddhpx_cdh.sl_dahoanthanh += sl_xuat_cuoi;
                                                        sl_xuat_cuoi = 0;
                                                    }
                                                    //xuat du
                                                    else
                                                    {
                                                        ddhpx_cdh.sl_dahoanthanh += tslhn;
                                                        sl_xuat_cuoi = sl_xuat_cuoi - tslhn;
                                                    }

                                                    var ck_dh = db.md_xuatkhonb_cdh.Where(s =>
                                                       s.md_xuatkhonb_id != xk.md_xuatkhonb_id
                                                       & s.md_sanpham_id == dh.md_sanpham_id
                                                       & s.lsx_to == dh.lsx_to
                                                       & db.md_xuatkhonb.Where(t => t.md_xuatkhonb_id == s.md_xuatkhonb_id & t.trangthai == "SOANTHAO").Count() > 0).FirstOrDefault();
                                                    if (ck_dh != null)
                                                    {
                                                        ck_dh.tong_sl_xuat = (ck_dh.tong_sl_xuat - dh.sl_daxuat).GetValueOrDefault(0).Set0WhenlessThan0();
                                                        ck_dh.sl_xuat = 0;
                                                        ck_dh.sl_xuat2 = 0;
                                                    }
                                                    db.SaveChanges();
                                                }
                                            }
                                        }

                                        db.SaveChanges();
                                        msg_success += "<div style='color:blue'>Dòng \"" + xk.sochungtu + " của \"" + sp.ma_sanpham + "\" đã xuất kho thành công, số lượng xuất là: \"" + sl_xuat2.DropTrailingZeros() + "\"</div>";
                                    }
                                    else if (xk.bosung == 2)
                                    {
                                        var ldg = db.md_lenhdonggoi.FirstOrDefault(s => s.sochungtu == xk.lenhdonggoi);
                                        foreach (var ddhpx_cdh in db.md_lenhdonggoi_vattu.
                                                        Where(s =>
                                                        s.md_sanpham_id == sp.md_sanpham_id
                                                        & s.md_lenhdonggoi_id == ldg.md_lenhdonggoi_id).ToList())
                                        {
                                            decimal tslhn = ddhpx_cdh.soluong.GetValueOrDefault(0) - ddhpx_cdh.soluong_dagiao.GetValueOrDefault(0);
                                            if (tslhn >= sl_xuat_cuoi)
                                            {
                                                ddhpx_cdh.soluong_dagiao = ddhpx_cdh.soluong_dagiao.GetValueOrDefault(0) + sl_xuat_cuoi;
                                                sl_xuat_cuoi = 0;
                                            }
                                            else
                                            {
                                                ddhpx_cdh.soluong_dagiao = ddhpx_cdh.soluong_dagiao.GetValueOrDefault(0) + tslhn;
                                                sl_xuat_cuoi = sl_xuat_cuoi - tslhn;
                                            }

                                            //--ghi nợ / có
                                            if (ghino == true)
                                            {
                                                add_kho_no(db, dh, xk, null, us, null, xk.xuatden, dh.ghino);
                                                ghino = false;
                                            }

                                            var ck_dh = db.md_xuatkhonb_cdh.Where(s =>
                                                    s.md_xuatkhonb_id != xk.md_xuatkhonb_id
                                                    & s.md_sanpham_id == dh.md_sanpham_id
                                                    & db.md_xuatkhonb.Where(t => 
                                                        t.md_xuatkhonb_id == s.md_xuatkhonb_id 
                                                        & t.trangthai != "HIEULUC"
                                                        & t.lenhdonggoi == ldg.sochungtu
                                                    ).Count() > 0
                                                ).FirstOrDefault();
                                            if (ck_dh != null)
                                            {
                                                ck_dh.tong_sl_xuat = (ck_dh.tong_sl_xuat - dh.sl_daxuat).GetValueOrDefault(0).Set0WhenlessThan0();
                                                ck_dh.sl_xuat = 0;
                                                ck_dh.sl_xuat2 = 0;
                                                if (ck_dh.truno > 0)
                                                {
                                                    if (ck_dh.truno > ck_dh.tong_sl_xuat)
                                                        ck_dh.truno = ck_dh.tong_sl_xuat;
                                                }

                                                if (ck_dh.sl_thucxuat.GetValueOrDefault(0) > 0)
                                                    ck_dh.ghino = (ck_dh.sl_thucxuat - ck_dh.tong_sl_xuat + ck_dh.truno).GetValueOrDefault(0).Set0WhenlessThan0();
                                                else
                                                    ck_dh.ghino = (ck_dh.sl_muonxuat - ck_dh.tong_sl_xuat + ck_dh.truno).GetValueOrDefault(0).Set0WhenlessThan0();
                                            }
                                            db.SaveChanges();
                                        }

                                        db.SaveChanges();
                                        msg_success += "<div style='color:blue'>Dòng \"" + xk.sochungtu + " của \"" + sp.ma_sanpham + "\" đã xuất kho thành công, số lượng xuất là: \"" + sl_xuat2.DropTrailingZeros() + "\"</div>";
                                    }
                                    else
                                    {
                                        msg_success += "<div style='color:blue'>Dòng \"" + xk.sochungtu + " của \"" + sp.ma_sanpham + "\" đã xuất kho thành công, số lượng xuất là: \"" + sl_xuat2.DropTrailingZeros() + "\"</div>";
                                    }
                                }
                            }
                        }

                        if (count_slxuat <= 0 & msg == "")
                        {
                            msg += "<div style='color:red'>Lỗi: Dòng \"" + xk.sochungtu + " phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.</div>";
                        }
                    }

                    //Kiem tra de chuyen thanh Hieu Luc
                    if (msg.Length <= 0)
                    {
                        msg = msg_success + msg;
                        xk.trangthai = "HIEULUC";
                        db.SaveChanges();
                        if (xk.bosung == 3)
                        {
                            pub.capnhatGiuCho_XKVatTuTon(xk.sochungtu, xk.chungtuthamchieu, xk.tukho, xk.md_xuatkhonb_id, xk.trangthai, db);
                            db.SaveChanges();
                        }
                    }
                    else
                    {
                        commit = false;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.Message;
                commit = false;
            }

            if (commit == true)
                transaction.Commit();
            else
                transaction.Rollback();
        }
        context.Response.Write(msg);
    }
    //--update soan thao
    public string update_soanthao(EntityContext db, string md_sanpham_id, string md_dondathangphanxuong_id, string md_xuatkhonb_id, decimal sl_daxuat)
    {
        string[] arr_xknb = new string[100];
        arr_xknb[0] = md_xuatkhonb_id;
        int i = 1;
        foreach (var check_xk in db.md_xuatkhonb.
                Where(s => s.md_xuatkhonb_id != md_xuatkhonb_id &
                s.md_lenhsanxuat_tosx_id.Contains(md_dondathangphanxuong_id) &
                s.trangthai == "SOANTHAO" & s.bosung == 0).OrderBy(s => s.sochungtu).ToList())
        {
            arr_xknb[i] = check_xk.md_xuatkhonb_id;
            i++;
            foreach (var ck_dh in db.md_xuatkhonb_cdh.
                    Where(s => s.md_xuatkhonb_id == check_xk.md_xuatkhonb_id &
                    s.md_sanpham_id == md_sanpham_id & s.sl_daxuat <= 0 & s.tong_sl_xuat > 0).
                    OrderBy(s => s.md_sanpham_id).ToList())
            {
                ck_dh.tong_sl_xuat = ck_dh.tong_sl_xuat - sl_daxuat;
                if (ck_dh.tong_sl_xuat <= 0)
                    ck_dh.tong_sl_xuat = 0;

                ck_dh.sl_xuat = ck_dh.sl_xuat - sl_daxuat;
                if (ck_dh.sl_xuat <= 0)
                    ck_dh.sl_xuat = 0;
            }
        }
        return "";
    }
    //--cap nhat so luong xuat
    public string edit_xuat(EntityContext db, md_xuatkhonb_cdh dh, User_TK us)
    {
        string id_new = dh.md_xuatkhonb_id;
        md_xuatkhonb xk = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == dh.md_xuatkhonb_id).FirstOrDefault();
        decimal? slXuatHN = dh.sl_thucxuat > dh.tong_sl_xuat ? dh.tong_sl_xuat : dh.sl_thucxuat;
        decimal sl_daxuat = dh.sl_daxuat.Value + slXuatHN.Value;
        if (dh.tong_sl_xuat.Value <= sl_daxuat)
        {
            sl_daxuat = dh.tong_sl_xuat.Value;
            dh.check_kho = true;
        }

        dh.sl_daxuat = sl_daxuat;
        dh.ngaycapnhat = DateTime.Now;
        xk.ngaycapnhat = DateTime.Now;
        return xk.md_xuatkhonb_id;
    }
    //xuat kho
    public string xuat_kho(EntityContext db, md_xuatkhonb_cdh dh, md_xuatkhonb px, decimal nhanvoi, User_TK us)
    {
        string id_new = dh.md_xuatkhonb_id;
        md_kho_sanpham check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == px.tukho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;

        id_new = sp.md_kho_sanpham_id;
        sp.soluong = sp.soluong - dh.sl_thucxuat;
        sp.ngaycapnhat = DateTime.Now;
        return id_new;
    }

    public string add_kho_hsd(EntityContext db, md_xuatkhonb_cdh dh, md_xuatkhonb px, User_TK us, string khospId)
    {
        string msg = "";
        var spid = db.md_kho_sanpham.
                Where(s => s.md_sanpham_id == dh.md_sanpham_id &
                s.md_kho_id == px.tukho).Select(s => s.md_kho_sanpham_id).FirstOrDefault();
        decimal tsl = dh.sl_thucxuat.GetValueOrDefault(0);
        if (string.IsNullOrEmpty(px.baotri_vattu))
        {
            foreach (var item in db.md_kho_sanpham_hansudung.
                Where(s => s.md_kho_sanpham_id == spid & s.soluong > 0).OrderBy(s => s.ngay_hethan).ToList())
            {
                decimal soTru = item.soluong.GetValueOrDefault(0) - tsl;
                if (soTru >= 0)
                {
                    item.soluong = soTru;
                    break;
                }
                else
                    item.soluong = 0;
                tsl = Math.Abs(soTru);
            }
        }
        else
        {
            string btvtId = db.md_baotrivthh.Where(s => s.sochungtu == px.baotri_vattu).Select(s => s.md_baotrivthh_id).FirstOrDefault();
            var hsd = db.md_baotrivthh_cdh.
                    Where(s => s.md_baotrivthh_id == btvtId & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
            if (hsd != null)
            {
                var ksphsd = db.md_kho_sanpham_hansudung.
                        Where(s => s.md_kho_sanpham_id == spid & s.ngay_hethan == hsd.hansudung).FirstOrDefault();
                if (ksphsd == null)
                    msg = "Lỗi.";
                else
                {
                    ksphsd.soluong -= dh.sl_thucxuat;
                    hsd.soluong_daxk += dh.sl_thucxuat;
                }
            }
        }
        return msg;
    }

    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_xuatkhonb_cdh dh, md_xuatkhonb px, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_giaodich giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = px.tukho;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = dh.sl_thucxuat;
        giao.ngaychuyen = px.ngaychuyen;
        giao.kieuchuyen = "Xuất kho";
        giao.dongnhapxuat = px.sochungtu;
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
        return "";
    }
    //-- Ghi nợ, có LST
    public string add_kho_no(EntityContext db, md_xuatkhonb_cdh dh, md_xuatkhonb px, string lsx_to, User_TK us, string pxId, string tento, decimal? ghino)
    {
        if (ghino != 0)
        {
            string id_new = Helper.getNewId();
            var giao = new md_kho_ghino();
            giao.md_kho_ghino_id = id_new;
            giao.md_kho_id = px.tukho;
            giao.md_sanpham_id = dh.md_sanpham_id;
            giao.md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id;
            giao.soluong_no = ghino;
            giao.ngayno = px.ngaychuyen;
            giao.lsx_to = lsx_to;
            giao.sctlienquan = px.sochungtu;
            giao.lydo = "";
            giao.md_phanxuong_id = pxId;
            giao.tosx = tento;
            giao.md_to_id = px.md_to_id;
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
            db.md_kho_ghino.Add(giao);
        }
        return "";
    }

    public string nhap_kho(EntityContext db, md_xuatkhonb_cdh dh, string khoId, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_sanpham check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == khoId & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;
        if (check_khosp == null)
        {
            sp = new md_kho_sanpham();
            sp.md_kho_sanpham_id = id_new;
            sp.soluong = dh.sl_thucxuat;
        }
        else
        {
            id_new = sp.md_kho_sanpham_id;
            sp.soluong += dh.sl_thucxuat;
        }
        sp.md_kho_id = khoId;
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

    public string add_nhapkho_hsd(EntityContext db, md_xuatkhonb_cdh dh, string khoId, User_TK us, string khospId)
    {
        string id_new = Helper.getNewId(), msg = "";
        var check_khospHSD = db.md_kho_sanpham_hansudung.
                Where(s =>
                    s.md_sanpham_id == dh.md_sanpham_id &
                    s.ngay_hethan.Value == null &
                    s.md_kho_sanpham_id == khospId).FirstOrDefault();
        var spHSD = check_khospHSD;
        if (check_khospHSD == null)
        {
            spHSD = new md_kho_sanpham_hansudung();
            spHSD.md_kho_sanpham_hansudung_id = id_new;
            spHSD.soluong = dh.sl_thucxuat;
            spHSD.ngay_hethan = null;
        }
        else
        {
            id_new = spHSD.md_kho_sanpham_hansudung_id;
            spHSD.soluong = dh.sl_thucxuat + spHSD.soluong;
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

        return msg;
    }

    //--tao lich su nhap kho
    public string add_nhapkho_ls(EntityContext db, md_xuatkhonb_cdh dh, string khoId, DateTime? ngaychuyen, string sochungtu, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_giaodich giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = khoId;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = dh.sl_thucxuat;
        giao.ngaychuyen = ngaychuyen.Value;
        giao.kieuchuyen = "Nhập kho";
        giao.dongnhapxuat = sochungtu;
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
        return "";
    }

    public void add(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string loaichuyen = context.Request.Form["bosung"];
        string tukho = context.Request.Form["tukho"];
        string denkho = context.Request.Form["denkho"];
        string sctdathang = context.Request.Form["sctdathang"];
        string[] pvcnbs = context.Request["chungtuthamchieu"].Split(new[] { "\n" }, StringSplitOptions.None);

        string id = context.Request.Form["id"];
        string bosung = context.Request.Form["bosung"];
        string chungtu_lenhsx = context.Request.Form["chungtu_lenhsx"];
        string md_lenhsanxuat_tosx_id = context.Request.Form["md_lenhsanxuat_tosx_id"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                DateTime ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
                if (ngaychuyen == DateTime.MinValue | ngaychuyen == DateTime.MinValue.AddDays(1))
                    msg = "Ngày xuất kho có giá trị sai";
                else if (loaichuyen == "0" | loaichuyen == "3")
                {
                    if (string.IsNullOrEmpty(chungtu_lenhsx))
                        msg = string.Format(@"Lỗi: Bạn chưa chọn lệnh sản xuất.");
                    else if (string.IsNullOrEmpty(md_lenhsanxuat_tosx_id))
                        msg = string.Format(@"Lỗi: Bạn chưa chọn tổ sản xuất.");
                }
                if (msg.Length <= 0)
                {
                    var arrTSX = md_lenhsanxuat_tosx_id.Split(new string[] { "\n" }, StringSplitOptions.None);
                    if (loaichuyen == "3")
                    {
                        foreach (var a in db.md_xuatkhonb.Where(s => pvcnbs.Contains(s.sochungtu)).ToList())
                        {
                            string sochungtu = VNN_VariablePublic.sochungtu(db, "PXKNB", 1);
                            var vcnb = new md_xuatkhonb();
                            id_new = Helper.getNewId();
                            vcnb.md_xuatkhonb_id = id_new;
                            vcnb.trangthai = "SOANTHAO";
                            vcnb.sochungtu = sochungtu;
                            vcnb.tukho = a.tukho;
                            vcnb.bosung = int.Parse(loaichuyen);
                            vcnb.chungtuthamchieu = a.sochungtu;
                            vcnb.chungtu_lenhsx = chungtu_lenhsx;
                            vcnb.md_lenhsanxuat_tosx_id = md_lenhsanxuat_tosx_id;
                            vcnb.ngaychuyen = ngaychuyen;
                            vcnb.nguoitao = us.ad_user_id;
                            vcnb.nguoicapnhat = us.ad_user_id;
                            vcnb.value_nguoitao = us.ma_user;
                            vcnb.value_nguoicapnhat = us.ma_user;
                            vcnb.ngaytao = DateTime.Now;
                            vcnb.ngaycapnhat = DateTime.Now;

                            bool AddPhieuXK = false;
                            foreach (var item in db.md_kho_giucho.Where(s =>
                             (s.sctlienquan == vcnb.sochungtu | s.sctlienquan == vcnb.chungtuthamchieu)
                             & s.md_kho_id == vcnb.tukho).ToList())
                            {
                                var tslVT = item.soluong_giucho;
                                foreach (var lsxTSXId in arrTSX)
                                {
                                    var tsx = Extension.getLSXToId(lsxTSXId, db);
                                    var vattu = db.md_lenhsanxuat_tosx_vattu.Where(s =>
                                        s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                        & s.md_sanpham_id == item.md_sanpham_id).FirstOrDefault();

                                    if (vattu != null)
                                    {
                                        decimal? sltd = vattu.soluong - vattu.sl_giamhanngach.GetValueOrDefault(0) - vattu.sl_hanngach.GetValueOrDefault(0);
                                        decimal? sltd2 = tslVT < sltd ? tslVT : sltd;
                                        var vcnb_cdh = new md_xuatkhonb_cdh();
                                        vcnb_cdh.md_xuatkhonb_cdh_id = Helper.getNewId();
                                        vcnb_cdh.md_xuatkhonb_id = vcnb.md_xuatkhonb_id;
                                        vcnb_cdh.md_sanpham_id = item.md_sanpham_id;
                                        vcnb_cdh.md_donvitinhsanpham_id = item.md_donvitinhsanpham_id;
                                        vcnb_cdh.md_donvitinhsanpham_id2 = item.md_donvitinhsanpham_id;
                                        vcnb_cdh.tong_sl_xuat = sltd2;
                                        vcnb_cdh.sl_daxuat = 0;
                                        vcnb_cdh.sl_xuat = sltd2;
                                        vcnb_cdh.sl_xuat2 = sltd2;
                                        vcnb_cdh.sl_toida_trongLSXTo = item.soluong_giucho;
                                        vcnb_cdh.sl_toida_trongLSXTo2 = sltd;
                                        vcnb_cdh.lsx_to = lsxTSXId;
                                        vcnb_cdh.nguoitao = us.ad_user_id;
                                        vcnb_cdh.nguoicapnhat = us.ad_user_id;
                                        vcnb_cdh.value_nguoitao = us.ma_user;
                                        vcnb_cdh.value_nguoicapnhat = us.ma_user;
                                        vcnb_cdh.ngaytao = DateTime.Now;
                                        vcnb_cdh.ngaycapnhat = DateTime.Now;
                                        db.md_xuatkhonb_cdh.Add(vcnb_cdh);
                                        db.SaveChanges();
                                        tslVT = (tslVT - sltd2).GetValueOrDefault(0).Set0WhenlessThan0().GetValueOrDefault(0);
                                        AddPhieuXK = true;
                                    }
                                }
                            }
                            if (AddPhieuXK == true)
                                db.md_xuatkhonb.Add(vcnb);
                            db.SaveChanges();
                        }
                    }
                    #region Xuất vật tư
                    else if (loaichuyen == "0")
                    {
                        if (string.IsNullOrEmpty(tukho))
                            msg = string.Format(@"Lỗi: Bạn chưa chọn kho.");
                        else
                        {
                            string sochungtu = VNN_VariablePublic.sochungtu(db, "PXKNB", 1);
                            var vcnb = new md_xuatkhonb();
                            id_new = Helper.getNewId();
                            vcnb.md_xuatkhonb_id = id_new;
                            vcnb.trangthai = "SOANTHAO";
                            vcnb.sochungtu = sochungtu;
                            vcnb.tukho = tukho;
                            vcnb.bosung = int.Parse(loaichuyen);
                            vcnb.chungtuthamchieu = null;
                            vcnb.chungtu_lenhsx = chungtu_lenhsx;
                            vcnb.md_lenhsanxuat_tosx_id = md_lenhsanxuat_tosx_id;
                            vcnb.ngaychuyen = ngaychuyen;
                            vcnb.nguoitao = us.ad_user_id;
                            vcnb.nguoicapnhat = us.ad_user_id;
                            vcnb.value_nguoitao = us.ma_user;
                            vcnb.value_nguoicapnhat = us.ma_user;
                            vcnb.ngaytao = DateTime.Now;
                            vcnb.ngaycapnhat = DateTime.Now;

                            bool AddPhieuXK = false;
                            foreach (string tsxId in arrTSX)
                            {
                                var lsxTSX = Extension.getLSXToId(tsxId, db);
                                if (lsxTSX != null)
                                {
                                    foreach (var dhpx_vt in db.md_lenhsanxuat_tosx_vattu.Where(s => s.md_lenhsanxuat_tosx_id == lsxTSX.md_lenhsanxuat_tosx_id).ToList())
                                    {
                                        var sltd = dhpx_vt.soluong - dhpx_vt.sl_hanngach - dhpx_vt.sl_giamhanngach.GetValueOrDefault(0);
                                        if (sltd > 0)
                                        {
                                            var cdh_ = db.md_xuatkhonb_cdh.Where(s =>
                                                s.md_sanpham_id == dhpx_vt.md_sanpham_id
                                                & s.md_xuatkhonb_id == vcnb.md_xuatkhonb_id
                                                & s.lsx_to == tsxId).FirstOrDefault();
                                            var cdh = cdh_;

                                            if (cdh_ == null)
                                            {
                                                cdh = new md_xuatkhonb_cdh();
                                                cdh.md_xuatkhonb_cdh_id = Helper.getNewId();
                                                cdh.md_xuatkhonb_id = vcnb.md_xuatkhonb_id;
                                                cdh.md_sanpham_id = dhpx_vt.md_sanpham_id;
                                                cdh.tong_sl_xuat = sltd;
                                            }
                                            else
                                            {
                                                cdh.tong_sl_xuat += sltd;
                                            }
                                            cdh.lsx_to = tsxId;
                                            cdh.sl_daxuat = 0;
                                            cdh.sl_xuat = cdh.tong_sl_xuat;
                                            cdh.sl_xuat2 = cdh.tong_sl_xuat;
                                            cdh.sl_toida_trongLSXTo = cdh.tong_sl_xuat;
                                            cdh.sl_toida_trongLSXTo2 = cdh.tong_sl_xuat;
                                            cdh.saiso = 0;
                                            cdh.md_donvitinhsanpham_id = dhpx_vt.md_donvitinhsanpham_id;
                                            cdh.md_donvitinhsanpham_id2 = dhpx_vt.md_donvitinhsanpham_id;
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
                                            if (cdh_ == null)
                                                db.md_xuatkhonb_cdh.Add(cdh);

                                            db.SaveChanges();
                                            AddPhieuXK = true;
                                        }
                                    }
                                }
                            }

                            if (AddPhieuXK == true)
                                db.md_xuatkhonb.Add(vcnb);
                            db.SaveChanges();
                        }
                    }
                    #endregion
                    else if (loaichuyen == "4")
                    {
                        string sochungtu = VNN_VariablePublic.sochungtu(db, "PXKNB", 1);
                        var vcnb = new md_xuatkhonb();
                        id_new = Helper.getNewId();
                        vcnb.md_xuatkhonb_id = id_new;
                        vcnb.trangthai = "SOANTHAO";
                        vcnb.sochungtu = sochungtu;
                        vcnb.tukho = tukho;
                        vcnb.bosung = int.Parse(loaichuyen);
                        vcnb.chungtuthamchieu = null;
                        vcnb.chungtu_lenhsx = chungtu_lenhsx;
                        vcnb.md_lenhsanxuat_tosx_id = md_lenhsanxuat_tosx_id;
                        vcnb.ngaychuyen = ngaychuyen;
                        vcnb.nguoitao = us.ad_user_id;
                        vcnb.nguoicapnhat = us.ad_user_id;
                        vcnb.value_nguoitao = us.ma_user;
                        vcnb.value_nguoicapnhat = us.ma_user;
                        vcnb.ngaytao = DateTime.Now;
                        vcnb.ngaycapnhat = DateTime.Now;
                        vcnb.banggiaNC = context.Request.Form["banggiaNC"];
                        vcnb.phienbangiaNC = context.Request.Form["phienbangiaNC"];
                        bool AddPhieuXK = false;
                        foreach (string tsxId in arrTSX)
                        {
                            var lsxTSX = Extension.getLSXToId(tsxId, db);
                            var lsxTSX_prev = Extension.getLSXToId_Prev(lsxTSX, db);
                            var kho = db.md_kho.Where(s =>
                                s.md_phanxuong_id == lsxTSX_prev.md_phanxuong_id
                                & s.md_to_id == lsxTSX_prev.md_phanxuong_to_id).FirstOrDefault();
                            if (kho != null & lsxTSX != null)
                            {
                                if (kho.md_kho_id == tukho)
                                {
                                    foreach (var dhpx_vtPrev in db.md_lenhsanxuat_tosx_cdh.
                                            Where(s => s.md_lenhsanxuat_tosx_id == lsxTSX_prev.md_lenhsanxuat_tosx_id).ToList())
                                    {
                                        var dhpx_vt = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                            s.md_lenhsanxuat_tosx_id == lsxTSX.md_lenhsanxuat_tosx_id
                                            & s.md_sanpham_id == dhpx_vtPrev.md_sanpham_id).FirstOrDefault();

                                        decimal tong_sl_xuat = dhpx_vtPrev.sl_dahoanthanh.GetValueOrDefault(0)
                                                - dhpx_vt.sl_dahoanthanh.GetValueOrDefault(0)
                                                - dhpx_vtPrev.sl_giamhanngach.GetValueOrDefault(0);

                                        if (tong_sl_xuat > 0)
                                        {
                                            var cdh_ = db.md_xuatkhonb_cdh.Where(s =>
                                            s.md_sanpham_id == dhpx_vtPrev.md_sanpham_id
                                            & s.md_xuatkhonb_id == vcnb.md_xuatkhonb_id
                                            & s.lsx_to == tsxId).FirstOrDefault();
                                            var cdh = cdh_;

                                            if (cdh_ == null)
                                            {
                                                cdh = new md_xuatkhonb_cdh();
                                                cdh.md_xuatkhonb_cdh_id = Helper.getNewId();
                                                cdh.md_xuatkhonb_id = vcnb.md_xuatkhonb_id;
                                                cdh.md_sanpham_id = dhpx_vtPrev.md_sanpham_id;
                                                cdh.tong_sl_xuat = tong_sl_xuat;
                                            }
                                            else
                                            {
                                                cdh.tong_sl_xuat += tong_sl_xuat;
                                            }
                                            cdh.sl_daxuat = 0;
                                            cdh.sl_xuat = 0;
                                            cdh.sl_xuat2 = 0;
                                            cdh.saiso = 0;
                                            cdh.md_donvitinhsanpham_id = dhpx_vtPrev.md_donvitinhsanpham_id;
                                            cdh.md_donvitinhsanpham_id2 = dhpx_vtPrev.md_donvitinhsanpham_id;
                                            cdh.check_kho = false;
                                            cdh.lsx_to = tsxId;
                                            cdh.sl_toida_trongLSXTo = cdh.tong_sl_xuat;
                                            cdh.sl_toida_trongLSXTo2 = cdh.tong_sl_xuat;
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
                                            if (cdh_ == null)
                                                db.md_xuatkhonb_cdh.Add(cdh);
                                            db.SaveChanges();
                                            AddPhieuXK = true;
                                        }
                                    }
                                }
                            }
                        }

                        if (AddPhieuXK == true)
                            db.md_xuatkhonb.Add(vcnb);
                        db.SaveChanges();

                        if (AddPhieuXK == false)
                        {
                            msg = "Không có dòng xuất kho cho các lệnh sản xuất đã chọn.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = "true#Tạo phiếu xuất kho thành công#" + id_new;
                transaction.Commit();
            }
            else
            {
                msg = "false#" + msg;
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string chungtu_lenhsx = context.Request.Form["chungtu_lenhsx"];
        string md_lenhsanxuat_tosx_id = context.Request.Form["md_lenhsanxuat_tosx_id"];
        string loaichuyen = context.Request.Form["bosung"];
        string tukho = context.Request.Form["tukho"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                DateTime ngaychuyen = VNN_Config.setDateTime(context.Request.Form["ngaychuyen"]);
                string id = context.Request.Form["id"];
                var object_ = db.md_xuatkhonb.Where(p => p.md_xuatkhonb_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg = @"Lỗi:Phiếu xuất kho đã Hiệu Lực";
                }
                else if (ngaychuyen == DateTime.MinValue | ngaychuyen == DateTime.MinValue.AddDays(1))
                    msg = "Lỗi: Ngày xuất kho có giá trị sai";

                else if (loaichuyen == "0" | loaichuyen == "3")
                {
                    if (string.IsNullOrEmpty(chungtu_lenhsx))
                        msg = string.Format(@"Lỗi: Bạn chưa chọn lệnh sản xuất.");
                    else if (string.IsNullOrEmpty(md_lenhsanxuat_tosx_id))
                        msg = string.Format(@"Lỗi: Bạn chưa chọn tổ sản xuất.");
                }

                if (msg.Length <= 0)
                {
                    var arrTSX = md_lenhsanxuat_tosx_id.Split(new string[] { "\n" }, StringSplitOptions.None);
                    object_.bosung = int.Parse(loaichuyen);
                    object_.chungtu_lenhsx = chungtu_lenhsx;
                    object_.md_lenhsanxuat_tosx_id = md_lenhsanxuat_tosx_id;
                    object_.ngaychuyen = ngaychuyen;
                    object_.nguoitao = us.ad_user_id;
                    object_.nguoicapnhat = us.ad_user_id;
                    object_.value_nguoitao = us.ma_user;
                    object_.value_nguoicapnhat = us.ma_user;
                    object_.ngaytao = DateTime.Now;
                    object_.ngaycapnhat = DateTime.Now;

                    if (loaichuyen == "3")
                    {
                        db.md_xuatkhonb_cdh.RemoveRange(db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == object_.md_xuatkhonb_id));

                        foreach (var item in db.md_kho_giucho.Where(s =>
                             (s.sctlienquan == object_.sochungtu | s.sctlienquan == object_.chungtuthamchieu)
                             & s.md_kho_id == object_.tukho).ToList())
                        {
                            var tslVT = item.soluong_giucho;
                            foreach (var lsxTSXId in arrTSX)
                            {
                                var tsx = Extension.getLSXToId(lsxTSXId, db);
                                var vattu = db.md_lenhsanxuat_tosx_vattu.Where(s =>
                                    s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                    & s.md_sanpham_id == item.md_sanpham_id).FirstOrDefault();

                                if (vattu != null)
                                {
                                    decimal? sltd = vattu.soluong - vattu.sl_giamhanngach.GetValueOrDefault(0) - vattu.sl_hanngach.GetValueOrDefault(0);
                                    decimal? sltd2 = tslVT < sltd ? tslVT : sltd;
                                    var vcnb_cdh = new md_xuatkhonb_cdh();
                                    vcnb_cdh.md_xuatkhonb_cdh_id = Helper.getNewId();
                                    vcnb_cdh.md_xuatkhonb_id = object_.md_xuatkhonb_id;
                                    vcnb_cdh.md_sanpham_id = item.md_sanpham_id;
                                    vcnb_cdh.md_donvitinhsanpham_id = item.md_donvitinhsanpham_id;
                                    vcnb_cdh.md_donvitinhsanpham_id2 = item.md_donvitinhsanpham_id;
                                    vcnb_cdh.tong_sl_xuat = sltd2;
                                    vcnb_cdh.sl_daxuat = 0;
                                    vcnb_cdh.sl_xuat = sltd2;
                                    vcnb_cdh.sl_xuat2 = sltd2;
                                    vcnb_cdh.sl_toida_trongLSXTo = item.soluong_giucho;
                                    vcnb_cdh.sl_toida_trongLSXTo2 = sltd;
                                    vcnb_cdh.lsx_to = lsxTSXId;
                                    vcnb_cdh.nguoitao = us.ad_user_id;
                                    vcnb_cdh.nguoicapnhat = us.ad_user_id;
                                    vcnb_cdh.value_nguoitao = us.ma_user;
                                    vcnb_cdh.value_nguoicapnhat = us.ma_user;
                                    vcnb_cdh.ngaytao = DateTime.Now;
                                    vcnb_cdh.ngaycapnhat = DateTime.Now;
                                    db.md_xuatkhonb_cdh.Add(vcnb_cdh);
                                    tslVT = (tslVT - sltd2).GetValueOrDefault(0).Set0WhenlessThan0().GetValueOrDefault(0);
                                }
                            }
                        }
                        db.SaveChanges();
                    }
                    else if (loaichuyen == "4")
                    {
                        object_.banggiaNC = context.Request.Form["banggiaNC"];
                        object_.phienbangiaNC = context.Request.Form["phienbangiaNC"];
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
                msg = "true#Cập nhật thành công.";
                transaction.Commit();
            }
            else
            {
                msg = "false#" + msg;
                transaction.Rollback();
            }
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
                var object_ = db.md_xuatkhonb.Where(p => p.md_xuatkhonb_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg += string.Format(@"Lỗi dòng {0}:Không tìm thấy đối tượng cần xóa.", i + 1);
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg += string.Format(@"Lỗi dòng {0}: Dòng {1} đã hiệu lực, không thể xóa.", i + 1, object_.sochungtu);
                }
                else
                {
                    object_.trangthai = "SOANTHAO";
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