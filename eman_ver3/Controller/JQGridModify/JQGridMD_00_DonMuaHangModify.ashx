<%@ WebHandler Language="C#" Class="JQGridMD_00_DonMuaHangModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_DonMuaHangModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_TPNKMG2":
                this.CA_01_TPNKMG2(context);
                break;
            case "CA_01_XacNhanNhapkho":
                this.CA_01_XacNhanNhapkho(context);
                break;
            case "CA_01_KetThucDonMuHang":
                this.CA_01_KetThucDonMuHang(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_KetThucDonMuHang(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        try
        {
            c_donmuahang object_ = db.c_donmuahang.Where(p => p.c_donmuahang_id == id).Take(1).FirstOrDefault();

            object_.md_trangthai_id = "KETTHUC";
            msg_success = "<div style='color:blue'> Kết thúc đơn hàng thành công.</div>";

            if (msg.Length <= 0)
            {
                db.SaveChanges();
                msg = msg_success;
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }


    public void CA_01_XacNhanNhapkho(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string id = context.Request.QueryString["id"];
        c_donmuahang nk_ncc = db.c_donmuahang.Where(s => s.c_donmuahang_id == id).Take(1).FirstOrDefault();
        if (nk_ncc != null)
        {
            if (nk_ncc.phieuXNNK == null | nk_ncc.phieuXNNK == "")
            {
                nk_ncc.phieuXNNK = nk_ncc.sochungtu.Replace("PNK", "XNNK");
                db.SaveChanges();
            }
        }
    }

    public void CA_01_TPNKMG2(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string id = context.Request.Form["id"];
        string khoNH = context.Request.Form["kho"];
        string msg = "";
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        var dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == id).Take(1).FirstOrDefault();
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNKNCC", 1);

        //check nhap kho
        int countx = 0;
        int m = db.md_nhapkho_ncc.Where(s => s.c_donmuahang_id == id & s.trangthai == "SOANTHAO").Count();
        countx += m;

        if (dmh == null)
        {
            msg = "<div style='color:red'>Lỗi: Không tìm thấy đơn mua hàng đã chọn.</div>";
        }
        else if (dmh.md_trangthai_id != "HIEULUC" & dmh.md_trangthai_id != "CHUAXONG")
        {
            msg = "<div style='color:red'>Lỗi: Đơn mua hàng chưa \"Hiệu lực\" hoặc \"Đã nhập hết\".</div>";
        }
        else if (countx > 0)
        {
            msg = "<div style='color:red'>Phiếu nhập kho trước chưa Hiệu Lực, không thể tạo phiếu mới.</div>" + countx;
        }
        else
        {
            var dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dmh.md_doitackinhdoanh_id).Take(1).FirstOrDefault();
            string add_master = "";
            foreach (var dmh_cdmh in db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).ToList())
            {
                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dmh_cdmh.md_sanpham_id).FirstOrDefault();
                decimal tile = dmh_cdmh.sl_dadat2.GetValueOrDefault(0) / dmh_cdmh.sl_dadat.Value;

                decimal slthaythe = dmh_cdmh.sl_dadat.Value - dmh_cdmh.sl_hanngach.GetValueOrDefault(0);
                if (tile > 0)
                    slthaythe = slthaythe * tile;

                if (sp != null)
                {
                    if (add_master == "")
                    {
                        add_master = Helper.getNewId();
                        var nk_ncc = new md_nhapkho_ncc
                        {
                            md_nhapkho_ncc_id = add_master,
                            c_donmuahang_id = dmh.c_donmuahang_id,
                            sochungtu = sochungtu,
                            donhang_thamchieu = dmh.donhang_thamchieu,
                            ngaydenghi = DateTime.Now,
                            kho = khoNH,
                            trangthai = "SOANTHAO",
                            check_hieuluc = false,
                            md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id,
                            ten_dtkd = dtkd.ten_dtkd,
                            sctdathang = dmh.sctdathang,
                            nguoidung = dtkd.daidien,
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
                            hoatdong = true
                        };
                        db.md_nhapkho_ncc.Add(nk_ncc);
                    }

                    var tslDat = dmh_cdmh.sl_dadat.Value - dmh_cdmh.sl_hanngach.GetValueOrDefault(0);
                    var nk_ncc_dh = new md_nhapkho_ncc_dh
                    {
                        md_nhapkho_ncc_dh_id = Helper.getNewId(),
                        md_nhapkho_ncc_id = add_master,
                        md_sanpham_id = sp.md_sanpham_id,
                        md_donvitinhsanpham_id = dmh_cdmh.md_donvitinhsanpham_id,
                        mota_tiengviet = sp.mota_tiengviet,
                        mota_tienganh = sp.mota_tienganh,
                        khoden = sp.khoton,
                        tong_sl_dat = tslDat,
                        tong_sl_dat2 = slthaythe,
                        sl_danhap = 0,
                        sl_danhap2 = 0,
                        sl_nhap = 0,
                        sl_nhap2 = 0,
                        sl_muonnhap = tslDat,
                        sl_muonnhap2 = slthaythe,
                        giatriVND = dmh_cdmh.dongiamua.GetValueOrDefault(0).NgoaiTeToiVND(dmh.md_dongtien_id, dmh.ngaydonhang, db),
                        ngay_hethan = null,
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
                        hoatdong = true
                    };
                    db.md_nhapkho_ncc_dh.Add(nk_ncc_dh);
                }
            }
        }

        if (msg.Length <= 0)
        {
            if (dmh.phieunhapkho == " ")
                dmh.phieunhapkho = "Đã tạo phiếu";
            msg = "<div style='color:blue'>Tạo phiếu nhập kho từ NCC: \"" + sochungtu + "\" thành công</div>";
            db.SaveChanges();
        }
        context.Response.Write(msg);
    }

    //--tao phieu nhap kho
    public string add_ncc(EntityContext db, c_donmuahang dmh, string kho, string id, string sochungtu, User_TK us)
    {
        string id_new = Helper.getNewId();
        string ten_dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dmh.md_doitackinhdoanh_id).Select(s => s.ten_dtkd).Take(1).FirstOrDefault();
        md_doitackinhdoanh dtkds = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dmh.md_doitackinhdoanh_id).FirstOrDefault();
        md_nhapkho_ncc check_ncc = db.md_nhapkho_ncc.Where(s => s.c_donmuahang_id == id).FirstOrDefault();
        md_nhapkho_ncc ncc = check_ncc;
        if (check_ncc == null)
        {
            ncc = new md_nhapkho_ncc();
            ncc.md_nhapkho_ncc_id = id_new;
            ncc.c_donmuahang_id = id;
            ncc.ten_dtkd = " - " + ten_dtkd;
            ncc.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id;
            ncc.sochungtu = sochungtu;
            ncc.donhang_thamchieu = dmh.donhang_thamchieu;
            ncc.nguoidung = " - " + dtkds.daidien;
        }
        else
        {
            id_new = ncc.md_nhapkho_ncc_id;

            if (!ncc.md_doitackinhdoanh_id.Contains(dmh.md_doitackinhdoanh_id))
            {
                ncc.ten_dtkd = ncc.ten_dtkd + "<br>" + " - " + ten_dtkd;
                ncc.md_doitackinhdoanh_id = ncc.md_doitackinhdoanh_id + "," + dmh.md_doitackinhdoanh_id;
            }

            if (!ncc.donhang_thamchieu.Contains(dmh.donhang_thamchieu))
            {
                ncc.donhang_thamchieu = ncc.donhang_thamchieu + "<br>" + dmh.donhang_thamchieu;
            }
            if (!ncc.nguoidung.Contains(dtkds.daidien))
            {
                ncc.nguoidung = ncc.nguoidung + "<br>" + " - " + dtkds.daidien;
            }
        }
        ncc.trangthai = "SOANTHAO";
        ncc.ngaychuyen = DateTime.Now;
        ncc.kho = kho;

        ncc.nguoitao = us.ad_user_id;
        ncc.vaitrotao = us.ad_role_id;
        ncc.bophantao = us.md_phongban_id;
        ncc.value_nguoitao = us.ma_user;
        ncc.value_vaitrotao = us.ten_role;
        ncc.value_bophantao = us.ten_phongban;
        ncc.nguoicapnhat = us.ad_user_id;
        ncc.vaitrocapnhat = us.ad_role_id;
        ncc.bophancapnhat = us.md_phongban_id;
        ncc.value_nguoicapnhat = us.ma_user;
        ncc.value_vaitrocapnhat = us.ten_role;
        ncc.value_bophancapnhat = us.ten_phongban;
        ncc.hoatdong = true;
        if (check_ncc == null)
        {
            db.md_nhapkho_ncc.Add(ncc);
            ncc.ngaycapnhat = DateTime.Now;
            ncc.ngaytao = DateTime.Now;
        }
        else
        {
            ncc.ngaycapnhat = DateTime.Now;
        }

        db.SaveChanges();
        return id_new;
    }

    //--tao noi dung phieu nhap kho
    public string add_ncc_dh(EntityContext db, c_donmuahang_cdmh cdmh, c_donmuahang dmh, string id, User_TK us)
    {
        string id_new = Helper.getNewId();

        md_nhapkho_ncc ncc = db.md_nhapkho_ncc.Where(s => s.c_donmuahang_id == id).FirstOrDefault();
        string[] nht = ncc.c_donmuahang_id.Split(',');
        md_nhapkho_ncc_dh check_dh = db.md_nhapkho_ncc_dh.Where(s => s.md_nhapkho_ncc_id == ncc.md_nhapkho_ncc_id & s.md_sanpham_id == cdmh.md_sanpham_id).FirstOrDefault();
        md_nhapkho_ncc_dh ncc_dh = check_dh;

        if (ncc_dh == null)
        {
            ncc_dh = new md_nhapkho_ncc_dh();
            ncc_dh.md_nhapkho_ncc_dh_id = id_new;
            ncc_dh.md_nhapkho_ncc_id = ncc.md_nhapkho_ncc_id;
            ncc_dh.tong_sl_dat = cdmh.sl_dadat;
            ncc_dh.sl_nhap = cdmh.sl_dadat;
        }
        else
        {
            id_new = ncc_dh.md_nhapkho_ncc_dh_id;
            ncc_dh.tong_sl_dat = ncc_dh.tong_sl_dat + cdmh.sl_dadat;
            ncc_dh.sl_nhap = ncc_dh.sl_nhap + cdmh.sl_dadat;

        }
        ncc_dh.md_sanpham_id = cdmh.md_sanpham_id;
        md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdmh.md_sanpham_id).FirstOrDefault();
        ncc_dh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id;
        ncc_dh.mota_tiengviet = sp.mota_tiengviet;
        ncc_dh.mota_tienganh = sp.mota_tienganh;
        //ncc_dh.khoden = sp.khomacdinh;
        ncc_dh.sl_danhap = 0;
        ncc_dh.check_kho = false;

        md_doitackinhdoanh dtkds = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dmh.md_doitackinhdoanh_id).FirstOrDefault();
        ncc_dh.mota = "Từ " + dtkds.ten_dtkd;

        ncc_dh.nguoitao = us.ad_user_id;
        ncc_dh.vaitrotao = us.ad_role_id;
        ncc_dh.bophantao = us.md_phongban_id;
        ncc_dh.value_nguoitao = us.ma_user;
        ncc_dh.value_vaitrotao = us.ten_role;
        ncc_dh.value_bophantao = us.ten_phongban;
        ncc_dh.nguoicapnhat = us.ad_user_id;
        ncc_dh.vaitrocapnhat = us.ad_role_id;
        ncc_dh.bophancapnhat = us.md_phongban_id;
        ncc_dh.value_nguoicapnhat = us.ma_user;
        ncc_dh.value_vaitrocapnhat = us.ten_role;
        ncc_dh.value_bophancapnhat = us.ten_phongban;
        ncc_dh.hoatdong = true;

        if (check_dh == null)
        {
            db.md_nhapkho_ncc_dh.Add(ncc_dh);
            ncc.ngaycapnhat = DateTime.Now;
            ncc.ngaytao = DateTime.Now;
        }
        else
        {
            ncc.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();
        return id_new;

    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id_parent = context.Request.Form["id_parent"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_donmuahang";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Thêm thành công." + "#" + id_new;
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    //nht
    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_er = "", msg_err = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_trangthai_id = context.Request.Form["md_trangthai_id"];
        string ma_dtkd = context.Request.Form["md_doitackinhdoanh_id"];
        string md_banggia_id = context.Request.Form["md_banggia_id"];
        string md_phienbangia_id = context.Request.Form["md_phienbangia_id"];
        string md_phienbangia_id2 = md_phienbangia_id;
        string md_doitackinhdoanh_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == ma_dtkd).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
        string khmvtId = "";
        decimal dongiamua = 0;
        try
        {
            string id_parent = context.Request.Form["id_parent"];
            string id = context.Request.Form["id"];
            var object_ = db.c_donmuahang.Where(p => p.c_donmuahang_id == id).Take(1).FirstOrDefault();
            int count = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).Count();

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (ma_dtkd == "MUA NGOAI" & md_trangthai_id == "HIEULUC")
            {
                msg = "false#Lỗi:Không thể hiệu lực khi đối tác kinh doanh là \"" + ma_dtkd + "\".";
            }
            else if (count <= 0 & md_trangthai_id == "HIEULUC")
            {
                msg = "false#Lỗi:Đối tượng chưa có HHVT cần mua.";
            }
            else if (object_.tong_tienhang <= 0 & object_.tong_tatca <= 0 & md_trangthai_id == "HIEULUC")
            {
                msg = "false#Lỗi:Đối tượng chưa có tổng tiền hàng.";
            }
            else if (md_doitackinhdoanh_id == null)
            {
                msg = "false#Lỗi:Không tồn tại đối tác kinh doanh \"" + ma_dtkd + "\".";
            }
            else if (object_.md_trangthai_id != "SOANTHAO")
            {
                msg = "false#Lỗi:Đối tượng không phải 'Soạn Thảo' không thể chỉnh sửa.";
            }
            else if (md_trangthai_id != "HIEULUC" & md_trangthai_id != "SOANTHAO")
            {
                msg = "false#Lỗi:Đối tượng chỉ có thể 'Hiệu Lực'.";
            }

            foreach (var dmh_st in db.c_donmuahang.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id & s.c_kehoachmuavt_id == object_.c_kehoachmuavt_id).ToList())
            {
                foreach (var cdh_st in db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh_st.c_donmuahang_id).ToList())
                {
                    var cdh_obj = db.c_kehoachmuavt_cdh.Where(s => s.c_kehoachmuavt_id == dmh_st.c_kehoachmuavt_id & s.md_sanpham_id == cdh_st.md_sanpham_id).FirstOrDefault();
                    if (cdh_obj != null)
                    {
                        var sp_obj = db.md_sanpham.Where(s => s.md_sanpham_id == cdh_obj.md_sanpham_id).FirstOrDefault();
                        if (
                            (cdh_obj.sl_conlai + cdh_st.sl_dadat2.GetValueOrDefault(0) - cdh_st.saiso.GetValueOrDefault(0))
                            > cdh_obj.sl_duyet
                        )
                        {
                            decimal check_sl = cdh_obj.sl_duyet.Value - cdh_obj.sl_conlai.Value;
                            msg_err += string.Format(@"Mã sản phẩm ""{0}"" vượt quá SL cho phép (SL còn lại:""{1}"") <br>",
                                sp_obj.ma_sanpham, check_sl);
                        }
                    }
                }
            }

            if (msg_err.Length > 0 & msg.Length <= 0)
                msg = "false#Lỗi:" + msg_err;

            if (msg.Length <= 0)
            {
                khmvtId = object_.c_kehoachmuavt_id;
                md_phienbangia_id2 = object_.md_phienbangia_id;
                md_banggia bg = db.md_banggia.Where(s => s.md_banggia_id == md_banggia_id).Take(1).FirstOrDefault();
                md_phienbangia pbg = db.md_phienbangia.Where(s => s.md_banggia_id == bg.md_banggia_id & s.md_phienbangia_id == md_phienbangia_id).FirstOrDefault();

                if (bg == null)
                {
                    msg += "false#Lỗi:Nhà cung cấp \"" + ma_dtkd + "\" không có bảng giá.";
                }
                else if (pbg == null)
                {
                    md_phienbangia pbg1 = db.md_phienbangia.Where(s => s.md_phienbangia_id == md_phienbangia_id).FirstOrDefault();
                    msg += "false#Lỗi:Nhà cung cấp \"" + ma_dtkd + "\" không có phiên bảng giá \"" + pbg1.ten_phienbangia + "\" .";
                }

                var c_donmuahang_cdmhs = from a in db.c_donmuahang_cdmh
                                         join c in db.md_sanpham on a.md_sanpham_id equals c.md_sanpham_id
                                         where a.c_donmuahang_id == object_.c_donmuahang_id
                                         select new { a.c_donmuahang_cdmh_id, a.md_sanpham_id, c.ma_sanpham };

                //join b in db.md_giasanphams on a.md_sanpham_id equals b.md_sanpham_id
                //sanpham = cdmh.md_sanpham_id;
                //        dongiamua = cdmh.gia.Value;

                if (msg.Length <= 0)
                {
                    foreach (var cdmh in c_donmuahang_cdmhs.OrderBy(s => s.md_sanpham_id).ToList())
                    {
                        var gsp = db.md_giasanpham.Where(s => s.md_sanpham_id == cdmh.md_sanpham_id & s.md_phienbangia_id == pbg.md_phienbangia_id).FirstOrDefault();
                        if (gsp == null)
                        {
                            msg_er += "không có giá của sản phẩm \"" + cdmh.ma_sanpham + "\"<br>";
                        }
                        else { }
                    }

                    if (msg_er.Length > 0)
                    {
                        msg = "false#Lỗi:Nhà cung cấp \"" + ma_dtkd + "\"<br>" + msg_er;
                    }
                }

                if (msg.Length <= 0)
                {
                    //dang lam
                    object_.md_dongtien_id = bg.md_dongtien_id;
                    db.c_donmuahang_thue.RemoveRange(db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id));
                    db.SaveChanges();

                    foreach (var cdmh1 in db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).OrderBy(s => s.md_sanpham_id).ToList())
                    {
                        var gsp = db.md_giasanpham.Where(s => s.md_sanpham_id == cdmh1.md_sanpham_id & s.md_phienbangia_id == pbg.md_phienbangia_id).FirstOrDefault();
                        var thue_sp = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == cdmh1.thue).FirstOrDefault();
                        dongiamua = gsp.gia.Value;
                        if (md_phienbangia_id2 != md_phienbangia_id)
                        {
                            cdmh1.dongiamua = dongiamua;
                            cdmh1.giachuan = dongiamua;
                        }
                        else
                        {
                            dongiamua = (decimal)cdmh1.dongiamua.Value;
                        }

                        string md_thue_sanpham_id = "";
                        if (thue_sp != null)
                            md_thue_sanpham_id = thue_sp.md_thue_sanpham_id;
                        cdmh1.thue = md_thue_sanpham_id;
                        cdmh1.thanhtien = dongiamua * cdmh1.sl_dadat.Value;
                        dongiamua = 0;

                        cdmh1.nguoicapnhat = us.ad_user_id;
                        cdmh1.vaitrocapnhat = us.ad_role_id;
                        cdmh1.bophancapnhat = us.md_phongban_id;
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

                        thue.nguoitao = us.ad_user_id;
                        thue.vaitrotao = us.ad_role_id;
                        thue.bophantao = us.md_phongban_id;
                        thue.value_nguoitao = us.ma_user;
                        thue.value_vaitrotao = us.ten_role;
                        thue.value_bophantao = us.ten_phongban;

                        thue.nguoicapnhat = us.ad_user_id;
                        thue.vaitrocapnhat = us.ad_role_id;
                        thue.bophancapnhat = us.md_phongban_id;
                        thue.value_nguoicapnhat = us.ma_user;
                        thue.value_vaitrocapnhat = us.ten_role;
                        thue.value_bophancapnhat = us.ten_phongban;

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
                    var dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).FirstOrDefault();
                    var c_donmuahang_thues = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id);
                    List<string> id_notdel = new List<string>();
                    foreach (var thue_donhang_list in c_donmuahang_thues.Select(s => new { s.md_thue_sanpham_id, s.c_donmuahang_id }).Distinct().ToList())
                    {
                        var c_donmuahang_thueschild = c_donmuahang_thues.Where(s => s.md_thue_sanpham_id == thue_donhang_list.md_thue_sanpham_id);
                        c_donmuahang_thue dmh_thue = c_donmuahang_thueschild.Take(1).FirstOrDefault();

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
                    try { tong_tienhang = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.thanhtien.Value).Sum(); } catch { }
                    decimal tong_tienthue = decimal.Parse("0.00");
                    try { tong_tienthue = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.tong_tien_thue.Value).Sum(); } catch { }
                    decimal tong_tatca = tong_tienhang + tong_tienthue;
                    //--
                    string donvitinh = "VND";
                    md_dongtien dt = db.md_dongtien.Where(s => s.md_dongtien_id == dmh.md_dongtien_id).Take(1).FirstOrDefault();
                    if (dt != null) { donvitinh = dt.ma_iso; }
                    //--
                    var tth = VNN_ConvertMoney.convert((double)tong_tienhang, donvitinh).FirstOrDefault();
                    var ttc = VNN_ConvertMoney.convert((double)tong_tatca, donvitinh).FirstOrDefault();
                    dmh.tong_tienhang = (decimal)tth.Value;
                    dmh.tong_tatca = (decimal)ttc.Value;
                    dmh.chu_tong_tienhang = tth.Key;
                    dmh.chu_tong_tatca = ttc.Key;
                    db.SaveChanges();
                    //End cap nhat don mua hang
                    // cap nhat ke hoach mua vat tu
                    var kh = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == object_.c_kehoachmuavt_id & s.c_donmuavattu_id.Contains(object_.sochungtu)).FirstOrDefault();
                    if (kh != null & md_trangthai_id == "HIEULUC")
                    {
                        foreach (var cdh in db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == object_.c_donmuahang_id).ToList())
                        {
                            var cd = db.c_kehoachmuavt_cdh.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.c_kehoachmuavt_id == kh.c_kehoachmuavt_id).FirstOrDefault();
                            cd.sl_conlai += cdh.sl_dadat2;
                        }
                    }
                }
                if (msg.Length <= 0)
                {
                    string action = "edit";
                    string[] column_ex = { };
                    string ten_table = "c_donmuahang";
                    VNN_Function.SetFormValue("md_doitackinhdoanh_id", md_doitackinhdoanh_id);
                    VNN_Function.SetFormValue("md_banggia_id", md_banggia_id);

                    VNN_Function.SetFormValue("sctkehoach", "VNN_notpost");
                    VNN_Function.SetFormValue("tong_tienhang", "VNN_notpost");
                    VNN_Function.SetFormValue("chu_tong_tienhang", "VNN_notpost");
                    VNN_Function.SetFormValue("tong_tatca", "VNN_notpost");
                    VNN_Function.SetFormValue("chu_tong_tatca", "VNN_notpost");
                    VNN_Function.SetFormValue("md_dongtien_id", "VNN_notpost");
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                    db.SaveChanges();
                    msg = "true#Cập nhật thành công.";
                }
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }

        if(msg.LastIndexOf("false#") <= -1)
        {
            if(db.c_kehoachmuavt_cdh.Where(s=>
                s.c_kehoachmuavt_id == khmvtId &
                s.sl_conlai < s.sl_duyet
            ).Count() <= 0)
            {
                var kh = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == khmvtId).FirstOrDefault();
                if (kh != null)
                    kh.md_trangthai_id = "KETTHUC";
            }
            VNN_Function.loaddulieu_Auto(db, ma_module);
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
            string ten_table = "c_donmuahang";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                c_donmuahang object_ = db.c_donmuahang.Where(p => p.c_donmuahang_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.md_trangthai_id == "HIEULUC")
                {
                    msg_del = "Lỗi:Đơn mua hàng \"" + object_.sochungtu + "\"đã hiệu lực.";
                    msg += msg_del + "\n";
                }
                else if (object_.phieunhapkho != " " & object_.phieunhapkho != "" & object_.phieunhapkho != null)
                {
                    msg_del = "Lỗi:Đơn mua hàng \"" + object_.sochungtu + "\"đã tạo phiếu nhập kho.";
                    msg += msg_del + "\n";
                }

                if (msg_del.Length <= 0)
                {
                    string sct = object_.sochungtu;
                    db.c_donmuahang.Remove(object_);
                    //Cap nhat ke hoach dat hang NCC
                    c_kehoachdathang_dhncc dhncc = db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_dhncc_id == object_.c_kehoachdathang_dhncc_id).Take(1).FirstOrDefault();
                    c_kehoachmuavt khmvtt = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == object_.c_kehoachmuavt_id).Take(1).FirstOrDefault();
                    if (dhncc != null)
                    {
                        dhncc.chungtu = " ";
                        db.SaveChanges();

                        db = new EntityContext();
                        var c_kehoachdathang_dhcpxes = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id);
                        var c_kehoachdathang_dhnccs = db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id);
                        if (
                            c_kehoachdathang_dhcpxes.Count() == c_kehoachdathang_dhcpxes.Where(s => s.dongdathang == " ").Count() &
                            c_kehoachdathang_dhnccs.Count() == c_kehoachdathang_dhnccs.Where(s => s.chungtu == " ").Count()
                        )
                        {
                            c_kehoachdathang khdh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id).FirstOrDefault();
                            if (khdh != null)
                                khdh.trangthai = "SOANTHAO";
                        }
                        //db.SaveChanges();
                    }
                    else if (khmvtt != null)
                    {
                        khmvtt.c_donmuavattu_id = khmvtt.c_donmuavattu_id.Replace("," + sct, "").Replace(sct + ",", "").Replace(sct, "");
                        if (khmvtt.c_donmuavattu_id == "") { khmvtt.c_donmuavattu_id = " "; }
                    }
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