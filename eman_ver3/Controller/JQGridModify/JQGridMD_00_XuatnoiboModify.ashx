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
            default:
                break;
        }
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
        EntityContext db = new EntityContext();
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
                    var vattu = db.md_kho.Where(s => s.md_kho_id == xk.tukho).Select(s=>s.vattu).FirstOrDefault();
                    if (xk.trangthai == "HIEULUC")
                    {
                        msg = "<div style='color:red'>Lỗi: dòng \"" + xk.sochungtu + "\" đã hiệu lực.</div>";
                        break;
                    }
                    else if (xk.trangthai == "SOANTHAO")
                    {
                        msg_success += string.Format(@"
                                <div style='color:blue'>Dòng ""{0}"" đã xác nhận thành công</div>
                            ", xk.sochungtu);
                    }
                    else if (xk.trangthai == "DANHAN")
                    {
                        //--
                        //var check_kho = db.md_xuatkhonb_cdh.Where(s => s.check_kho == true & s.md_xuatkhonb_id == xk.md_xuatkhonb_id);
                        //var check_ma = db.md_xuatkhonb_cdh.Where(s => s.md_sanpham_id != null & s.md_xuatkhonb_id == xk.md_xuatkhonb_id);
                        string soluong_xuat = "0";
                        var md_xuatkhonb_cdhs = db.md_xuatkhonb_cdh.
                                Where(s => s.md_xuatkhonb_id == xk.md_xuatkhonb_id).ToList();
                        foreach (var dh in md_xuatkhonb_cdhs)
                        {
                            var kho = db.md_kho_sanpham.Where(s => s.md_kho_id == xk.tukho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                            decimal nhanvoi = 1;
                            if (dh.check_kho != true)
                            {
                                if (xk.tukho == null & xk.xuatden == null | xk.tukho == "" & xk.xuatden == "")
                                {
                                    msg += "<div style='color:red'>Lỗi: dòng \"" + xk.sochungtu + "\" chưa có kho hoặc phân xưởng đến.</div>";
                                }
                                else if (kho == null)
                                {
                                    if (dh.sl_xuat2 > 0)
                                    {
                                        count_slxuat++;
                                        msg += "<div style='color:red'>Lỗi: \"" + sp.ma_sanpham + "\" không có trong kho.</div>";
                                    }
                                }
                                else if (dh.sl_xuat2 < 0)
                                {
                                    msg += "<div style='color:red'>Lỗi: Số lượng xuất của \"" + sp.ma_sanpham + "\" phải lớn hơn 0 .</div>";
                                }
                                else if (dh.sl_xuat2 > (dh.tong_sl_xuat - dh.sl_daxuat))
                                {
                                    msg += string.Format(@"<div style='color:red'>
                                    Lỗi: Số lượng xuất của ""{0}"" phải nhỏ hơn ""{1}"".
                                </div>", sp.ma_sanpham, dh.tong_sl_xuat - dh.sl_daxuat);
                                }
                                else if (kho.soluong < dh.sl_xuat2)
                                {
                                    string tendvt = db.md_donvitinhsanpham.
                                            Where(s => s.md_donvitinhsanpham_id == sp.md_donvitinhsanpham_id).Select(s => s.ten_dvt).FirstOrDefault();
                                    msg += string.Format(@"<div style='color:red'>
                                    Lỗi: ""{0}"" số lượng trong kho chỉ còn: ""{1} {2}"".</div>",
                                        sp.ma_sanpham, kho.soluong.Value.DropTrailingZeros(), tendvt);
                                }
                            }

                            if (msg.Length <= 0 & dh.sl_xuat2 > 0)
                            {
                                count_slxuat++;
                                decimal sl_xuat = dh.sl_xuat2.Value, sl_xuat2 = sl_xuat;
                                soluong_xuat = "" + dh.sl_xuat2.Value.DropTrailingZeros();
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
                                if (sl_xuat > 0)
                                {
                                    if (1 == 1)
                                    {
                                        string[] _tosx = xk.md_lenhsanxuat_tosx_id.Replace("\n", ",").Split(',');
                                        foreach (string a in _tosx)
                                        {
                                            string[] arr = a.Split(new[] { " --- " }, StringSplitOptions.None);
                                            string sctLSX = arr[0];
                                            string tentoLSX = arr[1];
                                            var lsx = db.md_lenhsanxuat.Where(s => s.sochungtu == sctLSX).FirstOrDefault();
                                            string toId = db.md_phanxuong_to.Where(s => s.md_phanxuong_id == lsx.md_phanxuong_id &
                                            s.ten_to == tentoLSX).Select(s => s.md_to_id).FirstOrDefault();
                                            var lsxTSX = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                                                & s.md_phanxuong_to_id == toId).FirstOrDefault();

                                            if (vattu.GetValueOrDefault(false) == true)
                                            {
                                                foreach (var ddhpx_cdh in db.md_lenhsanxuat_tosx_vattu.
                                                        Where(s => s.md_lenhsanxuat_tosx_id == lsxTSX.md_lenhsanxuat_tosx_id &
                                                        s.md_sanpham_id == sp.md_sanpham_id).ToList())
                                                {
                                                    decimal tslhn = ddhpx_cdh.soluong.Value - ddhpx_cdh.sl_hanngach.Value;
                                                    //xuat thieu du
                                                    if (tslhn >= sl_xuat_cuoi)
                                                    {
                                                        ddhpx_cdh.sl_hanngach += sl_xuat_cuoi;
                                                        update_soanthao(db, sp.md_sanpham_id, a, xk_id, sl_xuat_cuoi);
                                                        sl_xuat_cuoi = 0;
                                                    }
                                                    //xuat du
                                                    else
                                                    {
                                                        ddhpx_cdh.sl_hanngach += tslhn;
                                                        update_soanthao(db, sp.md_sanpham_id, a, xk_id, tslhn);
                                                        sl_xuat_cuoi = sl_xuat_cuoi - tslhn;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                foreach (var ddhpx_cdh in db.md_lenhsanxuat_tosx_cdh.
                                                        Where(s => s.md_lenhsanxuat_tosx_id == lsxTSX.md_lenhsanxuat_tosx_id &
                                                        s.md_sanpham_id == sp.md_sanpham_id).ToList())
                                                {
                                                    decimal tslhn = ddhpx_cdh.sl_chiato.Value - ddhpx_cdh.sl_dahoanthanh.Value;
                                                    //xuat thieu du
                                                    if (tslhn >= sl_xuat_cuoi)
                                                    {
                                                        ddhpx_cdh.sl_dahoanthanh += sl_xuat_cuoi;
                                                        update_soanthao(db, sp.md_sanpham_id, a, xk_id, sl_xuat_cuoi);
                                                        sl_xuat_cuoi = 0;
                                                    }
                                                    //xuat du
                                                    else
                                                    {
                                                        ddhpx_cdh.sl_dahoanthanh += tslhn;
                                                        update_soanthao(db, sp.md_sanpham_id, a, xk_id, tslhn);
                                                        sl_xuat_cuoi = sl_xuat_cuoi - tslhn;
                                                    }
                                                }
                                            }
                                            db.SaveChanges();
                                        }
                                    }
                                    msg_success += "<div style='color:blue'>Dòng \"" + xk.sochungtu + " của \"" + sp.ma_sanpham + "\" đã xuất kho thành công, số lượng xuất là: \"" + sl_xuat2.DropTrailingZeros() + "\"</div>";
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
                        xk.trangthai = xk.trangthai == "DANHAN" ? "HIEULUC" : "DANHAN";
                        db.SaveChanges();
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
                Where(s => !arr_xknb.Contains(s.md_xuatkhonb_id) &
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
        string msg = "";
        md_xuatkhonb xk = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == dh.md_xuatkhonb_id).FirstOrDefault();
        decimal sl_daxuat = dh.sl_daxuat.Value + dh.sl_xuat2.Value;
        if (dh.tong_sl_xuat.Value <= sl_daxuat)
        {
            sl_daxuat = dh.tong_sl_xuat.Value;
            dh.check_kho = true;
        }

        dh.sl_daxuat = dh.sl_xuat2 + dh.sl_daxuat;
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
        sp.soluong = sp.soluong - (dh.sl_xuat2);
        sp.ngaycapnhat = DateTime.Now;
        return id_new;
    }

    public string add_kho_hsd(EntityContext db, md_xuatkhonb_cdh dh, md_xuatkhonb px, User_TK us, string khospId)
    {
        string msg = "";
        var spid = db.md_kho_sanpham.
                Where(s => s.md_sanpham_id == dh.md_sanpham_id &
                s.md_kho_id == px.tukho).Select(s => s.md_kho_sanpham_id).FirstOrDefault();
        decimal tsl = dh.sl_xuat2.GetValueOrDefault(0);
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
                    ksphsd.soluong -= dh.sl_xuat2;
                    hsd.soluong_daxk += dh.sl_xuat2;
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
        giao.soluong_dichchuyen = dh.sl_xuat2;
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
        dh.sl_xuat = 0;
        dh.sl_xuat2 = 0;
        return "";
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];

        string sochungtu = VNN_VariablePublic.sochungtu(db, "PXKNB", 1);
        string id = context.Request.Form["id"];
        string bosung = context.Request.Form["bosung"];
        string md_lenhsanxuat_id = "";
        string tukho = context.Request.Form["tukho"];
        //-
        string chungtu_lenhsx = context.Request.Form["chungtu_lenhsx"];
        chungtu_lenhsx = chungtu_lenhsx.Replace("\n", ",");
        string[] _lenhsx = chungtu_lenhsx.Split(',');
        string[] _tosx = context.Request.Form["md_lenhsanxuat_tosx_id"].Replace("\n", ",").Split(',');
        //--
        if (chungtu_lenhsx.Length > 0)
        {
            for (int j = 0; j < _lenhsx.Count(); j++)
            {
                string _lenhsxJ = _lenhsx[j];
                var lsx_ = db.md_lenhsanxuat.Where(s => s.sochungtu == _lenhsxJ).FirstOrDefault();
                md_lenhsanxuat_id += lsx_.md_lenhsanxuat_id + ",";
            }
            if (md_lenhsanxuat_id != "")
                md_lenhsanxuat_id = md_lenhsanxuat_id.Substring(0, md_lenhsanxuat_id.Length - 1);

            VNN_Function.SetFormValue("chungtu_lenhsx", chungtu_lenhsx.Replace(",", "\n"));
        }

        if (string.IsNullOrEmpty(tukho))
        {
            msg = "false#Bạn chưa chọn Kho.";
        }

        if (msg.Length <= 0)
        {
            try
            {
                string action = "add";
                string[] column_ex = { "md_lenhsanxuat_id" };
                string ten_table = "md_xuatkhonb";
                VNN_Function.SetFormValue("md_lenhsanxuat_id", md_lenhsanxuat_id);
                VNN_Function.SetFormValue("sochungtu", sochungtu);
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;

                if (bosung == "0")
                {
                    if (_tosx.Length == 0)
                    {
                        msg = "false#Phải chọn 1 tổ sản xuất.";
                    }
                    else
                    {
                        foreach (string a in _tosx)
                        {
                            string[] arr = a.Split(new[] { " --- " }, StringSplitOptions.None);
                            string sctLSX = arr[0];
                            string tentoLSX = arr[1];
                            var lsx = db.md_lenhsanxuat.Where(s => s.sochungtu == sctLSX).FirstOrDefault();
                            string toId = db.md_phanxuong_to.Where(s => s.md_phanxuong_id == lsx.md_phanxuong_id &
                            s.ten_to == tentoLSX).Select(s => s.md_to_id).FirstOrDefault();
                            var lsxTSX = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.md_phanxuong_to_id == toId).FirstOrDefault();
                            var vattu = db.md_kho.Where(s => s.md_kho_id == tukho).Select(s=>s.vattu).FirstOrDefault();
                            if (lsxTSX != null)
                            {
                                if (vattu.GetValueOrDefault(false) == true)
                                {
                                    foreach (var dhpx_vt in db.md_lenhsanxuat_tosx_vattu.Where(s => s.md_lenhsanxuat_tosx_id == lsxTSX.md_lenhsanxuat_tosx_id).ToList())
                                    {
                                        decimal tong_sl_xuat = dhpx_vt.soluong.Value - dhpx_vt.sl_hanngach.Value;
                                        if (tong_sl_xuat > 0)
                                        {
                                            var cdh_ = db.md_xuatkhonb_cdh.Where(s => s.md_sanpham_id == dhpx_vt.md_sanpham_id & s.md_xuatkhonb_id == id_new).FirstOrDefault();
                                            var cdh = cdh_;
                                            if (cdh_ == null)
                                            {
                                                cdh = new md_xuatkhonb_cdh();
                                                cdh.md_xuatkhonb_cdh_id = Helper.getNewId();
                                                cdh.md_xuatkhonb_id = id_new;
                                                cdh.md_sanpham_id = dhpx_vt.md_sanpham_id;
                                                cdh.tong_sl_xuat = dhpx_vt.soluong - dhpx_vt.sl_hanngach - dhpx_vt.sl_giamhanngach.GetValueOrDefault(0);
                                            }
                                            else
                                            {
                                                cdh.tong_sl_xuat += dhpx_vt.soluong - dhpx_vt.sl_hanngach - dhpx_vt.sl_giamhanngach.GetValueOrDefault(0);
                                            }
                                            cdh.sl_daxuat = 0;
                                            cdh.sl_xuat = 0;
                                            cdh.sl_xuat2 = 0;
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
                                        }
                                        db.SaveChanges();
                                    }
                                }
                                else
                                {
                                    foreach (var dhpx_vt in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == lsxTSX.md_lenhsanxuat_tosx_id).ToList())
                                    {
                                        decimal tong_sl_xuat = dhpx_vt.sl_chiato.Value - dhpx_vt.sl_dahoanthanh.Value;
                                        if (tong_sl_xuat > 0)
                                        {
                                            var cdh_ = db.md_xuatkhonb_cdh.Where(s => s.md_sanpham_id == dhpx_vt.md_sanpham_id & s.md_xuatkhonb_id == id_new).FirstOrDefault();
                                            var cdh = cdh_;
                                            if (cdh_ == null)
                                            {
                                                cdh = new md_xuatkhonb_cdh();
                                                cdh.md_xuatkhonb_cdh_id = Helper.getNewId();
                                                cdh.md_xuatkhonb_id = id_new;
                                                cdh.md_sanpham_id = dhpx_vt.md_sanpham_id;
                                                cdh.tong_sl_xuat = tong_sl_xuat - dhpx_vt.sl_giamhanngach.GetValueOrDefault(0);
                                            }
                                            else
                                            {
                                                cdh.tong_sl_xuat += tong_sl_xuat - dhpx_vt.sl_giamhanngach.GetValueOrDefault(0);
                                            }
                                            cdh.sl_daxuat = 0;
                                            cdh.sl_xuat = 0;
                                            cdh.sl_xuat2 = 0;
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
                                        }
                                        db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
                else if (bosung == "2")
                {
                    string sctBTVTHH = context.Request.Form["baotri_vattu"];
                    string idBTHHVT = db.md_baotrivthh.Where(s => s.sochungtu == sctBTVTHH).Select(s => s.md_baotrivthh_id).FirstOrDefault();
                    var bthhvts = db.md_baotrivthh_cdh.Where(s => s.md_baotrivthh_id == idBTHHVT);
                    var kq = bthhvts.GroupBy(s => new { s.md_sanpham_id, s.md_donvitinhsanpham_id }).Select(
                        cl => new
                        {
                            cl.Key.md_sanpham_id,
                            cl.Key.md_donvitinhsanpham_id,
                            soluong_baotri = cl.Sum(s => s.soluong_baotri),
                            soluong_daxk = cl.Sum(s => s.soluong_daxk)
                        });

                    foreach (var dh in kq.ToList())
                    {
                        var cdh = new md_xuatkhonb_cdh();
                        cdh.md_xuatkhonb_cdh_id = Helper.getNewId();
                        cdh.md_xuatkhonb_id = id_new;
                        cdh.md_sanpham_id = dh.md_sanpham_id;
                        cdh.tong_sl_xuat = dh.soluong_baotri - dh.soluong_daxk;
                        cdh.sl_daxuat = 0;
                        cdh.sl_xuat = 0;
                        cdh.sl_xuat2 = 0;
                        cdh.saiso = 0;
                        cdh.md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id;
                        cdh.md_donvitinhsanpham_id2 = dh.md_donvitinhsanpham_id;
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
                        db.md_xuatkhonb_cdh.Add(cdh);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.Message;
            }
        }
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string chungtu_lenhsx = context.Request.Form["chungtu_lenhsx"];
        string md_lenhsanxuat_id = "";
        string bosung = context.Request.Form["bosung"];
        string tukho = context.Request.Form["tukho"];

        if (string.IsNullOrEmpty(tukho))
        {
            msg = "false#Bạn chưa chọn Kho.";
        }

        if (msg.Length <= 0)
        {
            try
            {

                string id = context.Request.Form["id"];
                var object_ = db.md_xuatkhonb.Where(p => p.md_xuatkhonb_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if (object_.trangthai != "SOANTHAO")
                {
                    msg = "false#Lỗi:Đối tượng đã xuất kho";
                }

                if (bosung != "True")
                {
                    if (!string.IsNullOrEmpty(chungtu_lenhsx))
                    {
                        var lsx = db.md_lenhsanxuat.Where(s => s.sochungtu == chungtu_lenhsx).FirstOrDefault();
                        if (lsx != null)
                            md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
                    }
                    else
                        msg = string.Format(@"false#Không tìm thấy lệnh sản xuất ""{0}""", chungtu_lenhsx);
                }

                if (msg.Length <= 0)
                {
                    string action = "edit";
                    string[] column_ex = { "md_lenhsanxuat_id" };
                    string ten_table = "md_xuatkhonb";
                    VNN_Function.SetFormValue("md_lenhsanxuat_id", md_lenhsanxuat_id);
                    VNN_Function.SetFormValue("chungtu_lenhsx", chungtu_lenhsx);
                    VNN_Function.SetFormValue("sochungtu", "VNN_notpost");
                    VNN_Function.SetFormValue("xuatden", "VNN_notpost");
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
            string ten_table = "md_xuatkhonb";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_xuatkhonb object_ = db.md_xuatkhonb.Where(p => p.md_xuatkhonb_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + ",";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "Lỗi:\"" + object_.sochungtu + "\" đã hiệu lực ";
                    msg += msg_del + ",";
                }
                else if (db.md_vanchuyennoibo.Where(s => s.chungtuthamchieu == object_.sochungtu).Count() > 0)
                {
                    msg_del = "Lỗi:\"" + object_.sochungtu + "\" có phiếu vận chuyển nội bộ đang sử dụng, không thể xóa dòng này.";
                    msg += msg_del + ",";
                }

                if (msg_del.Length <= 0)
                {
                    foreach (md_lenhsanxuat dmh in db.md_lenhsanxuat.Where(s => s.phieuXK == object_.sochungtu))
                    {
                        dmh.phieuXK = " ";
                    }

                    foreach (md_lenhsanxuat_tosx_cdh lsx_to_cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == object_.md_lenhsanxuat_tosx_id))
                    {
                        md_xuatkhonb_sanpham xknb_sp = db.md_xuatkhonb_sanpham.Where(s => s.md_xuatkhonb_id == object_.md_xuatkhonb_id & s.md_sanpham_id == lsx_to_cdh.md_sanpham_id).FirstOrDefault();
                        if (xknb_sp != null)
                            lsx_to_cdh.sl_tinhvattu += xknb_sp.soluong;
                    }

                    foreach (md_nhapkhonb nknb in db.md_nhapkhonb.Where(s => s.md_xuatkhonb_id == object_.md_xuatkhonb_id))
                    {
                        nknb.md_xuatkhonb_id = null;
                    }
                    db.md_xuatkhonb.Remove(object_);
                }
            }

            if (msg.Length <= 0)
            {
                VNN_Function.loaddulieu_Auto(db, ma_module);
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
}