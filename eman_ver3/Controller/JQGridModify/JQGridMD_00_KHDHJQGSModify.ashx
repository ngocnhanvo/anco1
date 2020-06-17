<%@ WebHandler Language="C#" Class="JQGridMD_00_KHDHJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_KHDHJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_KHDHJQGS":
                this.CA_01_KHDHJQGS(context);
                break;
            case "CA_01_TYeuCau":
                this.CA_01_TYeuCau(context);
                break;
            case "CA_01_KH_ThayDoiTT":
                this.CA_01_KH_ThayDoiTT(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_KH_ThayDoiTT(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        string check_1 = context.Request.Form["check"];
        string[] vnn = id.Split(',');
        try
        {
            foreach (var dsdh in db.c_kehoachdathang.Where(s => vnn.Contains(s.c_kehoachdathang_id)).ToList())
            {
                if (dsdh.trangthai != "DAHET")
                {
                    if (check_1 == "1")
                    {
                        dsdh.trangthai = "DAHET";

                    }
                    else if (check_1 == "2")
                    {
                        dsdh.trangthai = "KETTHUC";
                    }
                    msg_success = "<div style='color:blue'> Chuyển đổi kế hoạch thành công.</div>";
                }
                else if (dsdh.trangthai != "KETTHUC")
                {
                    dsdh.trangthai = "SOANTHAO";
                    msg_success = "<div style='color:blue'> Chuyển đổi kế hoạch thành công.</div>";
                }
                else
                {
                    msg = "<div style='color:red'> Chuyển đổi thất bại, kế hoạch này đã kết thúc</div>";
                }
            }
            if (msg.Length <= 0)
            {
                db.SaveChanges();
                msg = msg_success;
            }
        }
        catch (Exception ex)
        {
            msg = string.Format(@"<div style='color:red'>{0}</div>", ex.Message);
        }
        context.Response.Write(msg);
    }

    private void CA_01_TYeuCau(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context),
        Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string sochungtu = VNN_VariablePublic.sochungtu(db, "YCM", 1);
        string id_new = Helper.getNewId();
        string sct_donhang = "", donhang_thamchieu = "";
        try
        {
            foreach (c_kehoachdathang kh in db.c_kehoachdathang.Where(s => vnn.Contains(s.c_kehoachdathang_id)))
            {
                int a = 0, b = 0;
                var check_dhcpx = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == kh.c_kehoachdathang_id);
                if (kh.trangthai != "HIEULUC")
                {
                    msg += "<div style='color:red'>Dòng \"" + kh.ten_kh + "\" chưa hiệu lực.</div>";
                    break;
                }
                else if (check_dhcpx.Count() <= 0)
                {
                    msg += "<div style='color:red'>Dòng \"" + kh.ten_kh + "\"không có dòng đặt hàng phân xưởng.</div>";
                    break;
                }
                foreach (c_yeucaumuavt ycmvt in db.c_yeucaumuavt.Where(s => s.c_kehoachdathang_id.Contains(kh.c_kehoachdathang_id)))
                {
                    b = 1;
                    msg += "<div style='color:red'>Dòng \"" + kh.ten_kh + "\" đã tạo yêu cầu mua vật tư \"" + ycmvt.sochungtu + "\".</div>";
                    break;
                }

                if (b == 0)
                {
                    foreach (c_kehoachdathang_dhcpx dhcpx in check_dhcpx)
                    {
                        foreach (c_kehoachdathang_dhcpx_cdh cdh in db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id))
                        {
                            md_sanpham_bom bom = db.md_sanpham_bom.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.trangthai == "HIEULUC").FirstOrDefault();
                            if (bom == null)
                            {
                                //msg += "<div style='color:red'>Dòng \"" + kh.ten_kh + "\" có sản phẩm không có BOM.</div>";
                                //break;
                            }
                            else
                            {
                                md_sanpham_bom_vattu vattu = db.md_sanpham_bom_vattu.Where(s => s.md_sanpham_bom_id == bom.md_sanpham_bom_id).FirstOrDefault();
                                if (a == 0)
                                {
                                    sct_donhang = kh.sodonhang + ", " + sct_donhang;
                                    donhang_thamchieu = kh.donhang_thamchieu + ", " + donhang_thamchieu;
                                    a = 1;
                                }
                                c_yeucaumuavt_cdh check = db.c_yeucaumuavt_cdh.Where(s => s.c_yeucaumuavt_id == id_new & s.md_sanpham_id == vattu.md_sanpham_id).FirstOrDefault();
                                c_yeucaumuavt_cdh vt_cdh = check;
                                if (vt_cdh == null)
                                {
                                    vt_cdh = new c_yeucaumuavt_cdh();
                                    vt_cdh.c_yeucaumuavt_cdh_id = Helper.getNewId();
                                    vt_cdh.soluong_yeucau = (decimal)vattu.soluong.Value * cdh.soluong.Value;
                                }
                                else
                                {
                                    vt_cdh.soluong_yeucau = vt_cdh.soluong_yeucau + ((decimal)vattu.soluong.Value * cdh.soluong.Value);
                                }
                                vt_cdh.c_yeucaumuavt_id = id_new;
                                vt_cdh.md_sanpham_id = vattu.md_sanpham_id;

                                vt_cdh.nguoitao = us.ad_user_id;
                                vt_cdh.vaitrotao = us.ad_role_id;
                                vt_cdh.bophantao = us.md_phongban_id;
                                vt_cdh.value_nguoitao = us.ma_user;
                                vt_cdh.value_vaitrotao = us.ten_role;
                                vt_cdh.value_bophantao = us.ten_phongban;
                                vt_cdh.nguoicapnhat = us.ad_user_id;
                                vt_cdh.vaitrocapnhat = us.ad_role_id;
                                vt_cdh.bophancapnhat = us.md_phongban_id;
                                vt_cdh.value_nguoicapnhat = us.ma_user;
                                vt_cdh.value_vaitrocapnhat = us.ten_role;
                                vt_cdh.value_bophancapnhat = us.ten_phongban;
                                vt_cdh.hoatdong = true;
                                if (check == null)
                                {
                                    vt_cdh.ngaytao = DateTime.Now;
                                    vt_cdh.ngaycapnhat = DateTime.Now;
                                    db.c_yeucaumuavt_cdh.Add(vt_cdh);
                                }
                                else
                                {
                                    vt_cdh.ngaycapnhat = DateTime.Now;
                                }
                                db.SaveChanges();
                            }
                            msg_success = "<div style='color:blue'>Tạo yêu cầu thành công</div>";
                        }
                    }
                }
            }
            if (msg.Length <= 0)
            {
                c_yeucaumuavt ycm = new c_yeucaumuavt();
                ycm.c_kehoachmuavt_id = " ";
                ycm.md_trangthai_id = "SOANTHAO";
                ycm.nguoiyeucau = "";
                ycm.sochungtu = sochungtu;
                ycm.c_yeucaumuavt_id = id_new;
                ycm.c_kehoachdathang_id = id;
                ycm.sct_donhang = sct_donhang;
                ycm.donhang_thamchieu = donhang_thamchieu;
                //ycm.sapxep = "";
                ycm.nguoitao = us.ad_user_id;
                ycm.vaitrotao = us.ad_role_id;
                ycm.bophantao = us.md_phongban_id;
                ycm.value_nguoitao = us.ma_user;
                ycm.value_vaitrotao = us.ten_role;
                ycm.value_bophantao = us.ten_phongban;
                ycm.nguoicapnhat = us.ad_user_id;
                ycm.vaitrocapnhat = us.ad_role_id;
                ycm.bophancapnhat = us.md_phongban_id;
                ycm.value_nguoicapnhat = us.ma_user;
                ycm.value_vaitrocapnhat = us.ten_role;
                ycm.value_bophancapnhat = us.ten_phongban;
                ycm.hoatdong = true;
                ycm.ngaytao = DateTime.Now;
                ycm.ngaycapnhat = DateTime.Now;
                db.c_yeucaumuavt.Add(ycm);

                db.SaveChanges();
                msg += msg_success + msg;
            }
            else
            {
                db.c_yeucaumuavt_cdh.RemoveRange(db.c_yeucaumuavt_cdh.Where(s => s.c_yeucaumuavt_id == id_new));
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }
    private void CA_01_KHDHJQGS(HttpContext context)
    {
        EntityContext db = new EntityContext();
        var pb = new Public();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context),
        Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string thoigianht = context.Request.Form["thoigianht"];
        string[] vnn = id.Split(',');
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var candat = from a in db.c_kehoachdathang_cdhcd
                             join b in db.c_kehoachdathang on a.c_kehoachdathang_id equals b.c_kehoachdathang_id
                             join c in db.md_sanpham on a.md_sanpham_id equals c.md_sanpham_id
                             join e in db.c_doichieuhangton on b.c_doichieuhangton_id equals e.c_doichieuhangton_id
                             select new
                             {
                                 a.md_phanxuong_id,
                                 a.md_sanpham_id,
                                 a.macuoi,
                                 a.noigiaohang,
                                 a.sl_phanphoi,
                                 a.sl_candat,
                                 a.md_doitackinhdoanh_id,
                                 b.c_kehoachdathang_id,
                                 b.donhang_thamchieu,
                                 b.sodonhang,
                                 b.mota,
                                 c.md_donvitinhsanpham_id,
                                 e.ngayhoanthanh
                             };

                foreach (var khdh in db.c_kehoachdathang.Where(s => vnn.Contains(s.c_kehoachdathang_id)).ToList())
                {
                    if (khdh.trangthai != "SOANTHAO")
                    {
                        msg += string.Format(@"<div style='color:red'>Dòng {0} không phải trạng thái 'Soạn Thảo'.</div>", khdh.ten_kh);
                    }
                    else if (db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id
                         & db.c_nhucauvattu_dhpx.Where(t => t.md_dondathangphanxuong_id == s.c_kehoachdathang_dhcpx_id).Count() > 0).Count() > 0)
                    {
                        msg += string.Format(@"<div style='color:red'>Dòng {0} đã tạo nhu cầu mua vật tư.</div>", khdh.ten_kh);
                    }

                    foreach (var dhcpx1 in db.c_kehoachdathang_cdhcd.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).ToList())
                    {
                        if (dhcpx1.md_phanxuong_id == "@md_phanxuong_id" | string.IsNullOrEmpty(dhcpx1.md_phanxuong_id))
                        {
                            dhcpx1.md_phanxuong_id = "";
                        }

                        if (dhcpx1.md_doitackinhdoanh_id == "@md_doitackinhdoanh_id" | string.IsNullOrEmpty(dhcpx1.md_doitackinhdoanh_id))
                        {
                            dhcpx1.md_doitackinhdoanh_id = "";
                        }
						
						string pxId = dhcpx1.md_phanxuong_id.Trim(), dtkdId = dhcpx1.md_doitackinhdoanh_id.Trim();
						
						var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dhcpx1.md_sanpham_id).FirstOrDefault();
						if(dhcpx1.sl_phanphoi == dhcpx1.sl_candat & pxId.Length < 1) {
							msg += string.Format(@"
                                <div style='color:red'>Dòng {0} không thể bỏ trống ""Phân xưởng sản xuất"".</div>",
                            sp == null ? "(unknown)" : sp.ma_sanpham);
						}
						else if(dhcpx1.sl_phanphoi == 0 & dtkdId.Length < 1) {
							msg += string.Format(@"
                                <div style='color:red'>Dòng {0} không thể bỏ trống ""Đối tác kinh doanh"".</div>",
                            sp == null ? "(unknown)" : sp.ma_sanpham);
						}
						else if(dhcpx1.sl_phanphoi != dhcpx1.sl_candat & pxId.Length < 1 & dtkdId.Length < 1) {
							msg += string.Format(@"
                                <div style='color:red'>Dòng {0} không thể bỏ trống ""Phân xưởng sản xuất"" và ""Đối tác kinh doanh"".</div>",
                            sp == null ? "(unknown)" : sp.ma_sanpham);
						}
                        else if (pxId.Length < 1 & dtkdId.Length < 1)
                        {
                            
                            msg += string.Format(@"
                                <div style='color:red'>Dòng {0} không thể bỏ trống một trong 2 dữ liêu: Đối tác kinh doanh và phân xưởng sản xuất.</div>",
                            sp == null ? "(unknown)" : sp.ma_sanpham);
                        }
                    }

                    if (msg.Length <= 0)
                    {
                        del_kehoachdathang(db, khdh.c_kehoachdathang_id);
                        //start
                        foreach (var item in candat.Where(s =>
                            s.c_kehoachdathang_id == khdh.c_kehoachdathang_id &
                            !string.IsNullOrEmpty(s.md_doitackinhdoanh_id) &
                            s.sl_phanphoi < s.sl_candat).ToList())
                        {
                            //--Them moi dong dat hang nha cung cap
                            add_mmuangoai(db, khdh.c_kehoachdathang_id, item.md_doitackinhdoanh_id,
                                item.donhang_thamchieu, item.ngayhoanthanh.Value, item.mota, item.sodonhang, thoigianht,
                                1, us);
                        }

                        foreach (var item in candat.Where(s =>
                            s.c_kehoachdathang_id == khdh.c_kehoachdathang_id &
                            !string.IsNullOrEmpty(s.md_phanxuong_id) & s.sl_phanphoi > 0).ToList())
                        {
                            //--Them moi dong dat hang cho phan xuong
                            add_phanxuong(db, khdh.c_kehoachdathang_id, item.md_phanxuong_id,
                            item.donhang_thamchieu, item.ngayhoanthanh.Value, item.mota, item.sodonhang, thoigianht,
                            1, us);
                        }

                        //end

                        //start
                        foreach (var dhcpx in db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).ToList())
                        {
                            foreach (var item in candat.Where(s =>
                                s.md_phanxuong_id == dhcpx.md_phanxuong_id &
                                s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id &
                                s.sl_phanphoi > 0).ToList())
                            {
                                //--Them moi cac dong hang cua phan xuong
                                add_phanxuong_cdh(db, dhcpx.c_kehoachdathang_id, dhcpx.c_kehoachdathang_dhcpx_id,
                                    item.md_sanpham_id, item.macuoi, item.md_donvitinhsanpham_id, item.sl_phanphoi.Value, item.mota,
                                    item.noigiaohang, 1, us, item.sodonhang);
                            }
                            var count = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id);
                            if (count.Count() == 0)
                            {
                                db.c_kehoachdathang_dhcpx.Remove(dhcpx);
                            }

                            foreach (var cdh in db.c_kehoachdathang_dhcpx_cdh.Where(s =>
                            s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).OrderBy(s => s.md_sanpham_id).ToList())
                            {
                                //--them cac dong dat hang phan xuong
                                pb.add_px_vattu(db, cdh, 1, us);
                            }
                        }
                        //end

                        //start
                        foreach (var dhnc in db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).ToList())
                        {
                            foreach (var item in candat.Where(s =>
                                s.md_doitackinhdoanh_id == dhnc.md_doitackinhdoanh_id &
                                s.c_kehoachdathang_id == dhnc.c_kehoachdathang_id &
                                s.sl_phanphoi < s.sl_candat).ToList())
                            {
                                //--Them moi cac dong hang cua mua ngoai
                                add_mmuangoai_chd(db, dhnc.c_kehoachdathang_id, dhnc.c_kehoachdathang_dhncc_id,
                                    item.md_sanpham_id,
                                    item.macuoi, item.md_donvitinhsanpham_id, item.sl_candat.Value, item.ngayhoanthanh.Value,
                                    item.mota, item.sl_phanphoi.Value,
                                    1, us);
                            }
                            var count = db.c_kehoachdathang_dhncc_cdh.Where(s => s.c_kehoachdathang_dhncc_id == dhnc.c_kehoachdathang_dhncc_id);
                            if (count.Count() == 0)
                            {
                                db.c_kehoachdathang_dhncc.Remove(dhnc);
                            }
                        }
                        //end
                        khdh.xulykehoach = true;
                        var dc = db.c_doichieuhangton.FirstOrDefault(s => s.c_doichieuhangton_id == khdh.c_doichieuhangton_id);
                        var ds = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == dc.c_danhsachdathang_id).FirstOrDefault();
                        ds.md_trangthai_id = "DAXULY";
                        db.SaveChanges();
                        if (msg.Length <= 0)
                        {
                            int dem_sl = db.c_kehoachdathang_cdhcd.Where(s => s.c_kehoachdathang_id == khdh.c_kehoachdathang_id).Count();
                            if (dem_sl <= 0)
                            {
                                khdh.trangthai = "DAHET";
                                khdh.xulykehoach = false;
                            }
                        }
                        db.SaveChanges();

                        msg_success += "<div style='color:blue'>Dòng \"" + khdh.ten_kh + "\" đã xử lý kế hoạch đặt hàng thành công.</div>";
                    }
                }
            }
            catch (Exception ex)
            {
                msg += string.Format(@"<div style='color:red'>Lỗi: {0}</div>", ex + "");
            }

            if (msg.Length <= 0)
            {
                msg = msg_success;
                transaction.Commit();
            }
            else
                transaction.Rollback();
        }

        db.Dispose();
        context.Response.Write(msg);
    }

    //Them cac dong hang cho dat hang nha cung cap 
    public string add_mmuangoai_chd(EntityContext db, string c_kehoachdathang_id, string c_kehoachdathang_dhncc_id, string md_sanpham_id, string macuoi, string md_donvitinhsanpham_id, decimal sl_candat, DateTime ngayhoanthanh, string mota, decimal sl_phanphoi, int i, User_TK us)
    {
        string id_new = Helper.getNewId();
        c_kehoachdathang_dhncc_cdh check_px = db.c_kehoachdathang_dhncc_cdh.FirstOrDefault(s => s.md_sanpham_id == md_sanpham_id & s.c_kehoachdathang_dhncc_id == c_kehoachdathang_dhncc_id);
        c_kehoachdathang_dhncc_cdh dhncc = check_px;
        if (check_px == null)
        {
            dhncc = new c_kehoachdathang_dhncc_cdh();
            dhncc.c_kehoachdathang_dhncc_cdh_id = Helper.getNewId();
        }
        else
        {
            id_new = dhncc.c_kehoachdathang_dhncc_cdh_id;
        }

        dhncc.c_kehoachdathang_id = c_kehoachdathang_id;
        dhncc.c_kehoachdathang_dhncc_id = c_kehoachdathang_dhncc_id;
        dhncc.md_sanpham_id = md_sanpham_id;
        dhncc.macuoi = macuoi;
        dhncc.md_donvitinhsanpham_id = md_donvitinhsanpham_id;
        dhncc.mota = mota;
        if (sl_candat - sl_phanphoi == 0)
        {
            dhncc.soluong = sl_candat;
        }
        else
        {
            dhncc.soluong = sl_candat - sl_phanphoi;
        }
        dhncc.ngaycan = ngayhoanthanh;

        dhncc.nguoitao = us.ad_user_id;
        dhncc.vaitrotao = us.ad_role_id;
        dhncc.bophantao = us.md_phongban_id;
        dhncc.value_nguoitao = us.ma_user;
        dhncc.value_vaitrotao = us.ten_role;
        dhncc.value_bophantao = us.ten_phongban;
        dhncc.nguoicapnhat = us.ad_user_id;
        dhncc.vaitrocapnhat = us.ad_role_id;
        dhncc.bophancapnhat = us.md_phongban_id;
        dhncc.value_nguoicapnhat = us.ma_user;
        dhncc.value_vaitrocapnhat = us.ten_role;
        dhncc.value_bophancapnhat = us.ten_phongban;
        dhncc.ngaytao = DateTime.Now;
        dhncc.ngaycapnhat = DateTime.Now;
        dhncc.hoatdong = true;

        //Kiem tra
        if (check_px == null)
        {
            dhncc.ngaytao = DateTime.Now;
            dhncc.ngaycapnhat = DateTime.Now;
            db.c_kehoachdathang_dhncc_cdh.Add(dhncc);
        }
        else
        {
            dhncc.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();
        return id_new;
    }

    //them cac dong mua hang nha cung cap
    public string add_mmuangoai(EntityContext db, string c_kehoachdathang_id, string md_doitackinhdoanh_id, string donhang_thamchieu, DateTime ngayhoanthanh, string mota, string sodonhang, string thoigianht, int i, User_TK us)
    {
        string id_new = Helper.getNewId();
        c_kehoachdathang_dhncc check_px = db.c_kehoachdathang_dhncc.FirstOrDefault(s => s.md_doitackinhdoanh_id == md_doitackinhdoanh_id & s.c_kehoachdathang_id == c_kehoachdathang_id);
        c_kehoachdathang_dhncc dhcpx = check_px;
        if (check_px == null)
        {
            dhcpx = new c_kehoachdathang_dhncc();
            dhcpx.c_kehoachdathang_dhncc_id = Helper.getNewId();
            dhcpx.chungtu = " ";
        }
        else
        {
            id_new = dhcpx.c_kehoachdathang_dhncc_id;
        }

        dhcpx.c_kehoachdathang_id = c_kehoachdathang_id;
        dhcpx.md_doitackinhdoanh_id = md_doitackinhdoanh_id;
        dhcpx.donhang = donhang_thamchieu;
        dhcpx.mota = mota;
        md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == md_doitackinhdoanh_id).FirstOrDefault();
        dhcpx.banggia = dtkd.md_banggia_id;
        dhcpx.sctdathang = sodonhang;
        dhcpx.thoihan_giaohang = ngayhoanthanh - TimeSpan.Parse(thoigianht);

        dhcpx.nguoitao = us.ad_user_id;
        dhcpx.vaitrotao = us.ad_role_id;
        dhcpx.bophantao = us.md_phongban_id;
        dhcpx.value_nguoitao = us.ma_user;
        dhcpx.value_vaitrotao = us.ten_role;
        dhcpx.value_bophantao = us.ten_phongban;
        dhcpx.nguoicapnhat = us.ad_user_id;
        dhcpx.vaitrocapnhat = us.ad_role_id;
        dhcpx.bophancapnhat = us.md_phongban_id;
        dhcpx.value_nguoicapnhat = us.ma_user;
        dhcpx.value_vaitrocapnhat = us.ten_role;
        dhcpx.value_bophancapnhat = us.ten_phongban;
        dhcpx.ngaytao = DateTime.Now;
        dhcpx.ngaycapnhat = DateTime.Now;
        dhcpx.hoatdong = true;

        //Kiem tra
        if (check_px == null)
        {
            dhcpx.ngaytao = DateTime.Now;
            dhcpx.ngaycapnhat = DateTime.Now;
            db.c_kehoachdathang_dhncc.Add(dhcpx);
        }
        else
        {
            dhcpx.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();
        return id_new;
    }


    //them cac dong hang cua phan xuong
    public string add_phanxuong_cdh(EntityContext db, string c_kehoachdathang_id, string c_kehoachdathang_dhcpx_id, string md_sanpham_id, string macuoi,
    string md_donvitinhsanpham_id, decimal sl_phanphoi, string mota, string noigiaohang, int i, User_TK us, string sodonhang)
    {
        //lay bom san pham vat tu
        string dsdhId = db.c_danhsachdathang.Where(s => s.sochungtu == sodonhang).Select(s => s.c_danhsachdathang_id).FirstOrDefault();
        string spBomId = db.c_dongdsdh.Where(s =>
                            s.md_sanpham_id == md_sanpham_id &
                            s.c_danhsachdathang_id == dsdhId)
                            .Select(s => s.md_sanpham_bom_id).FirstOrDefault();

        string id_new = Helper.getNewId();
        var check_px = db.c_kehoachdathang_dhcpx_cdh.FirstOrDefault(s => s.md_sanpham_id == md_sanpham_id & s.c_kehoachdathang_dhcpx_id == c_kehoachdathang_dhcpx_id);

        c_kehoachdathang_dhcpx_cdh dhcpx = check_px;
        if (check_px == null)
        {
            dhcpx = new c_kehoachdathang_dhcpx_cdh();
            dhcpx.c_kehoachdathang_dhcpx_cdh_id = Helper.getNewId();
        }
        else
        {
            id_new = dhcpx.c_kehoachdathang_dhcpx_cdh_id;
        }

        dhcpx.c_kehoachdathang_id = c_kehoachdathang_id;
        dhcpx.c_kehoachdathang_dhcpx_id = c_kehoachdathang_dhcpx_id;
        dhcpx.md_sanpham_id = md_sanpham_id;
        dhcpx.macuoi = macuoi;
        dhcpx.md_donvitinhsanpham_id = md_donvitinhsanpham_id;
        dhcpx.noigiaohang = noigiaohang;
        dhcpx.mota = mota;
        dhcpx.soluong = sl_phanphoi;
        dhcpx.md_sanpham_bom_id = spBomId;
        dhcpx.nguoitao = us.ad_user_id;
        dhcpx.vaitrotao = us.ad_role_id;
        dhcpx.bophantao = us.md_phongban_id;
        dhcpx.value_nguoitao = us.ma_user;
        dhcpx.value_vaitrotao = us.ten_role;
        dhcpx.value_bophantao = us.ten_phongban;
        dhcpx.nguoicapnhat = us.ad_user_id;
        dhcpx.vaitrocapnhat = us.ad_role_id;
        dhcpx.bophancapnhat = us.md_phongban_id;
        dhcpx.value_nguoicapnhat = us.ma_user;
        dhcpx.value_vaitrocapnhat = us.ten_role;
        dhcpx.value_bophancapnhat = us.ten_phongban;
        dhcpx.ngaytao = DateTime.Now;
        dhcpx.ngaycapnhat = DateTime.Now;
        dhcpx.hoatdong = true;

        //Kiem tra
        if (check_px == null)
        {
            dhcpx.ngaytao = DateTime.Now;
            dhcpx.ngaycapnhat = DateTime.Now;
            db.c_kehoachdathang_dhcpx_cdh.Add(dhcpx);
        }
        else
        {
            dhcpx.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();
        return id_new;
    }
    //them dat hang cho phan xuong
    public string add_phanxuong(EntityContext db, string c_kehoachdathang_id, string md_phanxuong_id, string donhang_thamchieu, DateTime ngayhoanthanh, string mota, string sodonhang, string thoigianht, int i, User_TK us)
    {
        string id_new = Helper.getNewId();
        c_kehoachdathang_dhcpx check_px = db.c_kehoachdathang_dhcpx.FirstOrDefault(s => s.md_phanxuong_id == md_phanxuong_id & s.c_kehoachdathang_id == c_kehoachdathang_id);
        c_kehoachdathang_dhcpx dhcpx = check_px;
        if (check_px == null)
        {
            dhcpx = new c_kehoachdathang_dhcpx();
            dhcpx.c_kehoachdathang_dhcpx_id = Helper.getNewId();
            dhcpx.dongdathang = " ";
        }
        else
        {
            id_new = dhcpx.c_kehoachdathang_dhcpx_id;
        }

        dhcpx.md_phanxuong_id = md_phanxuong_id;
        dhcpx.c_kehoachdathang_id = c_kehoachdathang_id;
        dhcpx.donhang = donhang_thamchieu;
        dhcpx.ngayHTcham = ngayhoanthanh;
        dhcpx.sctdathang = sodonhang;
        var dsdh = db.c_danhsachdathang.Where(s => s.sochungtu == dhcpx.sctdathang).FirstOrDefault();
        dhcpx.hdlh = dsdh.huongdanlamhang;
        dhcpx.hdlhchung = dsdh.huongdanlamhangchung;
        dhcpx.tinh_ncvt = false;

        dhcpx.nguoitao = us.ad_user_id;
        dhcpx.vaitrotao = us.ad_role_id;
        dhcpx.bophantao = us.md_phongban_id;
        dhcpx.value_nguoitao = us.ma_user;
        dhcpx.value_vaitrotao = us.ten_role;
        dhcpx.value_bophantao = us.ten_phongban;
        dhcpx.nguoicapnhat = us.ad_user_id;
        dhcpx.vaitrocapnhat = us.ad_role_id;
        dhcpx.bophancapnhat = us.md_phongban_id;
        dhcpx.value_nguoicapnhat = us.ma_user;
        dhcpx.value_vaitrocapnhat = us.ten_role;
        dhcpx.value_bophancapnhat = us.ten_phongban;
        dhcpx.ngaytao = DateTime.Now;
        dhcpx.ngaycapnhat = DateTime.Now;
        dhcpx.hoatdong = true;

        //Kiem tra
        if (check_px == null)
        {
            dhcpx.ngaytao = DateTime.Now;
            dhcpx.ngaycapnhat = DateTime.Now;
            db.c_kehoachdathang_dhcpx.Add(dhcpx);
        }
        else
        {
            dhcpx.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();
        return id_new;
    }

    //Xoa cac du lieu lien quan den lap ke hoach de doi chieu lai 
    public void del_kehoachdathang(EntityContext db, string kehoachdathang_id)
    {
        db.c_kehoachdathang_dhcpx.RemoveRange(db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == kehoachdathang_id));
        db.c_kehoachdathang_dhncc.RemoveRange(db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_id == kehoachdathang_id));
        db.SaveChanges();
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_kehoachdathang";
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

    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            string object_ = db.c_kehoachdathang.Where(p => p.c_kehoachdathang_id == id).Select(s => s.c_kehoachdathang_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_kehoachdathang";
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
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string[] id_del = context.Request.Form["id"].Split(',');
                int count = id_del.Count();
                for (int i = 0; i < count; i++)
                {
                    msg_del = "";
                    var id_del_ = id_del[i];
                    var object_ = db.c_kehoachdathang.Where(p => p.c_kehoachdathang_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg_del = "Lỗi dòng " + i + ": Không tìm thấy đối tượng cần xóa.";
                        msg += msg_del + "<br>";
                    }
                    else if (object_.trangthai != "SOANTHAO")
                    {
                        if (db.c_kehoachdathang_cdhcd.Where(s => s.c_kehoachdathang_id == object_.c_kehoachdathang_id).Count() > 0)
                        {
                            msg_del = "Lỗi:\"" + object_.ten_kh + "\" đã hiệu lực, không thể xóa.";
                            msg += msg_del + "<br>";
                        }
                    }
                    else if (db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == object_.c_kehoachdathang_id
                            & db.c_nhucauvattu_dhpx.Where(t => t.md_dondathangphanxuong_id == s.c_kehoachdathang_dhcpx_id).Count() > 0).Count() > 0)
                    {
                        msg += string.Format(@"<div style='color:red'>Dòng {0} đã tạo nhu cầu mua vật tư.</div>", object_.ten_kh);
                    }

                    if (msg_del.Length <= 0)
                    {
                        c_doichieuhangton dcht = db.c_doichieuhangton.Where(s => s.c_doichieuhangton_id == object_.c_doichieuhangton_id).Take(1).FirstOrDefault();
                        c_danhsachdathang ds = db.c_danhsachdathang.FirstOrDefault(s => s.c_danhsachdathang_id == dcht.c_danhsachdathang_id);
                        if (dcht != null)
                        {
                            dcht.kehoach = " ";
                            ds.md_trangthai_id = "DOICHIEUHANGTON";
                        }

                        db.c_kehoachdathang.Remove(object_);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "Lỗi: " + ex.Message;
            }

            if (msg.Length <= 0)
            {
                transaction.Commit();
                msg = "true#Xóa thành công.";
                VNN_Function.loaddulieu_Auto(db, ma_module);
            }
            else
            {
                msg = "false#" + msg;
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