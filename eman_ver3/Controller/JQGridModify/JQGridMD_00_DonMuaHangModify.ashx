<%@ WebHandler Language="C#" Class="JQGridMD_00_DonMuaHangModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_DonMuaHangModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
    public JQGridMD_00_DonMuaHangClass classFunc = new JQGridMD_00_DonMuaHangClass();
    User_TK userTK = null;

    public string oper = "vnn";
    public void ProcessRequest(HttpContext context)
    {
        if (Security.id_taikhoan(context) != "")
        {
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
        string id = context.Request.Form["id"];
        string khoNH = context.Request.Form["kho"];
        string sochungtu = "";
        string msg = "";

        var ids = id.Split(',');
        var dmhs = db.c_donmuahang.Where(s => ids.Contains(s.c_donmuahang_id)).OrderByDescending(s=>s.sochungtu).ToList();
        //check nhap kho
        string add_master = "";
        string dmhids = string.Join(",", dmhs.Select(s => s.c_donmuahang_id));
        string dmhsdmhs = string.Join("\n", dmhs.Select(s => s.so_donmuahang));
        string dmhdhtcs = string.Join("\n", dmhs.Select(s => s.donhang_thamchieu).Distinct());
        string dmhscts = string.Join("\n", dmhs.Select(s => s.sctdathang).Distinct());

        //using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                sochungtu = VNN_VariablePublic.sochungtu(db, "PNKNCC", 1);
                var ngh = VNN_Config.setDateTime(context.Request.Form["ngh"]);
                foreach (var dmh in dmhs)
                {
                    int countx = db.md_nhapkho_ncc.Where(s => s.c_donmuahang_id.Contains(dmh.c_donmuahang_id) & s.trangthai != "HIEULUC").Count();

                    if (dmh == null)
                    {
                        msg = "Lỗi: Không tìm thấy đơn mua hàng đã chọn.";
                        break;
                    }
                    else if (dmh.md_trangthai_id != "HIEULUC" & dmh.md_trangthai_id != "CHUAXONG")
                    {
                        msg = "Lỗi: Đơn mua hàng chưa \"Hiệu lực\" hoặc \"Đã nhập hết\".";
                        break;
                    }
                    else if (countx > 0)
                    {
                        msg = string.Format(@"Lỗi: Phiếu nhập kho của ĐMH {0} chưa Hiệu Lực, không thể tạo phiếu mới. {1}", dmh.so_donmuahang, countx);
                        break;
                    }
                    else
                    {
                        if (add_master == "")
                        {
                            var dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dmh.md_doitackinhdoanh_id).FirstOrDefault();
                            if (dtkd == null)
                            {
                                msg = string.Format(@"Không tìm thấy NCC của đơn mua hàng {0}.", dmh.so_donmuahang);
                                break;
                            }

                            add_master = Helper.getNewId();
                            var nk_ncc = new md_nhapkho_ncc
                            {
                                md_nhapkho_ncc_id = add_master,
                                c_donmuahang_id = dmhids,
                                sochungtu = sochungtu,
                                donhang_thamchieu = dmhdhtcs,
                                so_donmuahang = dmhsdmhs,
                                ngaydenghi = ngh,
                                ngaygiaohang = ngh,
                                kho = khoNH,
                                trangthai = "SOANTHAO",
                                check_hieuluc = false,
                                md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id,
                                ten_dtkd = dtkd.ten_dtkd,
                                sctdathang = dmhscts,
                                nguoidung = dtkd.daidien,
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
                                hoatdong = true,
                                ketoan = true
                            };
                            db.md_nhapkho_ncc.Add(nk_ncc);
                        }

                        foreach (var dmh_cdmh in db.c_donmuahang_cdmh.Where(s =>
                            s.c_donmuahang_id == dmh.c_donmuahang_id
                            & s.sl_dadat > s.sl_hanngach).ToList())
                        {
                            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dmh_cdmh.md_sanpham_id).FirstOrDefault();
                            decimal tile = dmh_cdmh.sl_dadat2.GetValueOrDefault(0) / dmh_cdmh.sl_dadat.Value;

                            decimal slthaythe = dmh_cdmh.sl_dadat.Value - dmh_cdmh.sl_hanngach.GetValueOrDefault(0);
                            if (tile > 0)
                                slthaythe = slthaythe * tile;

                            if (sp != null)
                            {
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
                                    sl_nhap = tslDat,
                                    sl_nhap2 = slthaythe,
                                    sl_muonnhap = tslDat,
                                    sl_muonnhap2 = slthaythe,
                                    thue = dmh_cdmh.thue,
                                    giatriVND = dmh_cdmh.dongiamua.GetValueOrDefault(0).NgoaiTeToiVND(dmh.md_dongtien_id, dmh.ngaydonhang, db),
                                    ngay_hethan = null,
                                    so_dmh = dmh.so_donmuahang,
                                    c_donmuahang_id = dmh.c_donmuahang_id,
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
                                    hoatdong = true
                                };
                                db.md_nhapkho_ncc_dh.Add(nk_ncc_dh);
                            }
                        }

                        if (dmh.phieunhapkho == " ")
                            dmh.phieunhapkho = "Đã tạo phiếu";
                    }
                }

                if(msg.Length <= 0)
                    db.SaveChanges();
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                //transaction.Commit();
                msg = "<div style='color:blue'>Tạo phiếu nhập kho từ NCC: \"" + sochungtu + "\" thành công</div>";
                msg += string.Format(@"<input id='sctnew' type='hidden' value='{0}'/>", add_master);
            }
            else
            {
                //transaction.Rollback();
                msg = "<div class='error' style='color:red'>" + msg + "</div>";
            }
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id_parent = context.Request.Form["id_parent"];
                var object_ = new c_donmuahang();
                object_.c_donmuahang_id = id_new;
                object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                db.c_donmuahang.Add(object_);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Thêm mới thành công#{0}", id_new);
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

    //nht
    public void edit(HttpContext context)
    {
        string msg = "", msg_er = "", msg_err = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_trangthai_id = context.Request.Form["md_trangthai_id"];
        string ma_dtkd = context.Request.Form["md_doitackinhdoanh_id"];
        string md_banggia_id = context.Request.Form["md_banggia_id"];
        string md_phienbangia_id = context.Request.Form["md_phienbangia_id"];
        string md_phienbangia_id2 = md_phienbangia_id;
        string md_doitackinhdoanh_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == ma_dtkd).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
        string khmvtId = "";

        using (var transaction = db.Database.BeginTransaction())
        {
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
                else if (!new string[] { "SOANTHAO", "HIEULUC" }.Contains(md_trangthai_id)  & object_.md_trangthai_id == "SOANTHAO")
                {
                    msg = "false#Lỗi:Đối tượng chỉ có thể 'Hiệu Lực'.";
                }

                if (object_.md_trangthai_id == "HIEULUC")
                {
                    var ngaythanhtoan = VNN_Config.setDateTime(context.Request.Form["ngaythanhtoan"]);
                    if (ngaythanhtoan.IsDate() == true)
                        object_.ngaythanhtoan = ngaythanhtoan;
                    else
                        msg = "false#Lỗi: Ngày thanh toán không đúng định dạng.";

                    object_.diadiem_giaohang = context.Request.Form["diadiem_giaohang"];
                    if (msg.Length <= 0)
                        msg = @"true#Đã cập nhật ""Ngày thành toán"" và ""địa điểm giao hàng""";
                }
                else if (object_.md_trangthai_id == "SOANTHAO")
                {
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
                        var bg = db.md_banggia.Where(s => s.md_banggia_id == md_banggia_id).Take(1).FirstOrDefault();
                        var pbg = db.md_phienbangia.Where(s => s.md_banggia_id == bg.md_banggia_id & s.md_phienbangia_id == md_phienbangia_id).FirstOrDefault();

                        if (bg == null)
                        {
                            msg += "false#Lỗi:Nhà cung cấp \"" + ma_dtkd + "\" không có bảng giá.";
                        }
                        else if (pbg == null)
                        {
                            var pbg1 = db.md_phienbangia.Where(s => s.md_phienbangia_id == md_phienbangia_id).FirstOrDefault();
                            msg += "false#Lỗi:Nhà cung cấp \"" + ma_dtkd + "\" không có phiên bảng giá \"" + pbg1.ten_phienbangia + "\" .";
                        }

                        var c_donmuahang_cdmhs = from a in db.c_donmuahang_cdmh
                                                 join c in db.md_sanpham on a.md_sanpham_id equals c.md_sanpham_id
                                                 where a.c_donmuahang_id == object_.c_donmuahang_id
                                                 select new { a.c_donmuahang_cdmh_id, a.md_sanpham_id, c.ma_sanpham };

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
                            object_.md_dongtien_id = bg.md_dongtien_id;
                            //Tính Thuế
                            classFunc.TinhThueDonHang(object_, userTK, md_phienbangia_id, md_phienbangia_id2, db);

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
                            db.SaveChanges();
                        }

                        if (msg.Length <= 0)
                        {
                            VNN_Function.SetFormValue(object_.nameof(s => s.md_doitackinhdoanh_id), md_doitackinhdoanh_id);
                            VNN_Function.SetFormValue(object_.nameof(s => s.md_banggia_id), md_banggia_id);

                            VNN_Function.SetFormValue(object_.nameof(s => s.huongdan_lamhang), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.phieunhapkho), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.donhang_thamchieu), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.sctkehoach), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.md_dongtien_id), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.c_kehoachmuavt_id), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.tong_tienhang), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.chu_tong_tienhang), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.tong_tatca), "VNN_notpost");
                            VNN_Function.SetFormValue(object_.nameof(s => s.chu_tong_tatca), "VNN_notpost");
                            object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                            object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                            db.SaveChanges();
                        }
                    }
                }

                object_.mota = context.Request.Form["mota"];

                if (db.c_kehoachmuavt_cdh.Where(s =>
                     s.c_kehoachmuavt_id == khmvtId &
                     s.sl_conlai < s.sl_duyet
                ).Count() <= 0)
                {
                    var kh = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == khmvtId).FirstOrDefault();
                    if (kh != null)
                        kh.md_trangthai_id = "KETTHUC";
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.Message;
            }

            if (msg.LastIndexOf("false#") <= -1)
            {
                transaction.Commit();
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
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
                var ids = context.Request.Form["id"].Split(',').Where(s=>!string.IsNullOrWhiteSpace(s)).ToList();

                foreach (var id_del_ in ids)
                {
                    var object_ = db.c_donmuahang.Where(p => p.c_donmuahang_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else if (object_.md_trangthai_id == "HIEULUC")
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Không thể xóa khi đẫ ""Hiệu Lực"".", object_.sochungtu, object_.so_donmuahang);
                    }
                    else if (!string.IsNullOrWhiteSpace(object_.phieunhapkho))
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Đã tạo phiếu nhập kho.", object_.sochungtu, object_.so_donmuahang);
                    }
                    else
                    {
                        string sct = object_.sochungtu;
                        string c_kehoachdathang_dhncc_id = object_.c_kehoachdathang_dhncc_id;
                        string c_kehoachmuavt_id = object_.c_kehoachmuavt_id;
                        VNN_Function.Write_log(context, ma_module, null, oper, "MĐMH:" + object_.sochungtu + ", TĐMH:" + object_.so_donmuahang, db);
                        db.c_donmuahang.Remove(object_);
                        db.SaveChanges();
                        //Cap nhat ke hoach dat hang NCC
                        var dhncc = db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_dhncc_id == c_kehoachdathang_dhncc_id).Take(1).FirstOrDefault();
                        var khmvtt = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == c_kehoachmuavt_id).Take(1).FirstOrDefault();
                        if (dhncc != null)
                        {
                            dhncc.chungtu = " ";
                            db.SaveChanges();

                            var c_kehoachdathang_dhcpxes = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id);
                            var c_kehoachdathang_dhnccs = db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id);
                            if (
                                c_kehoachdathang_dhcpxes.Count() == c_kehoachdathang_dhcpxes.Where(s => s.dongdathang == " ").Count() &
                                c_kehoachdathang_dhnccs.Count() == c_kehoachdathang_dhnccs.Where(s => s.chungtu == " ").Count()
                            )
                            {
                                var khdh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id).FirstOrDefault();
                                if (khdh != null)
                                    khdh.trangthai = "SOANTHAO";
                            }
                            db.SaveChanges();
                        }
                        else if (khmvtt != null)
                        {
                            khmvtt.c_donmuavattu_id = khmvtt.c_donmuavattu_id.Replace("," + sct, "").Replace(sct + ",", "").Replace(sct, "");
                            if (khmvtt.c_donmuavattu_id == "") { khmvtt.c_donmuavattu_id = " "; }
                            db.SaveChanges();
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
                msg = string.Format(@"true#Xóa các đơn mua hàng đã chọn thành công");
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