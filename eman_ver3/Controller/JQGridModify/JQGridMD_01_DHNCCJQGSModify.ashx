<%@ WebHandler Language="C#" Class="JQGridMD_01_DHNCCJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DHNCCJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_TaoDonMuaHang":
                this.CA_01_TaoDonMuaHang(context);
                break;
            case "CA_01_DathangcPX":
                this.CA_01_DathangcPX(context);
                break;
            case "selectoption_px":
                this.selectoption_px(context);
                break;
            default:
                break;
        }
    }

    public void selectoption_px(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string md_sanpham_id = context.Request.QueryString["md_sanpham_id"];
        string id = context.Request.QueryString["id"];
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "";

        //str += firstnull ? string.Format("<option value=\"\"></option>") : "";

        foreach (md_phanxuong cn in db.md_phanxuong.Where(s => s.md_phanxuong_id != null & s.md_phanxuong_id != "" & s.md_phanxuong_id != "76A5412072EC46C48207308E85904765"))
        {
            string selected = "";
            str += string.Format("<option {2} value=\"{0}\">{1}</option>", cn.md_phanxuong_id, cn.ten_phanxuong, selected);
        }
        context.Response.Write(str);
    }

    public void CA_01_DathangcPX(HttpContext context)
    {
        string msg = "", msg_success = "";
        EntityContext db = new EntityContext();
        string[] vnn = context.Request.Form["id_sp"].Split(',');
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string id = context.Request.Form["id"];
        string id_sp = context.Request.Form["id_sp"];
        string md_phanxuong_id = context.Request.Form["md_phanxuong_id"];
        try
        {
            foreach (c_kehoachdathang_dhncc dhncc in db.c_kehoachdathang_dhncc.Where(s => vnn.Contains(s.c_kehoachdathang_dhncc_id)))
            {
                if (dhncc.chungtu != " " & dhncc.chungtu != "" & dhncc.chungtu != null)
                {
                    md_doitackinhdoanh dt = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dhncc.md_doitackinhdoanh_id).FirstOrDefault();
                    msg = "<div style='color:red'>Lỗi: Dòng \"" + dt.ten_dtkd + "\" đã tạo đơn mua hàng.</div>";
                }

                if (msg.Length <= 0)
                {
                    //Dat hang cho phan xuong
                    string id_new = Helper.getNewId();
                    c_kehoachdathang_dhcpx check_px = db.c_kehoachdathang_dhcpx.FirstOrDefault(s => s.md_phanxuong_id == md_phanxuong_id & s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id);
                    c_kehoachdathang_dhcpx dhcpx = check_px;
                    if (dhcpx == null)
                    {
                        dhcpx = new c_kehoachdathang_dhcpx();
                        dhcpx.c_kehoachdathang_dhcpx_id = Helper.getNewId();
                        dhcpx.dongdathang = " ";
                    }
                    else
                    {
                        id_new = dhcpx.c_kehoachdathang_dhcpx_id;
                    }

                    dhcpx.c_kehoachdathang_id = id;
                    dhcpx.md_phanxuong_id = md_phanxuong_id;
                    dhcpx.donhang = dhncc.donhang;
                    dhcpx.mota = " ";
                    dhcpx.sctdathang = dhncc.sctdathang;
                    c_danhsachdathang ds = db.c_danhsachdathang.Where(s => s.so_po == dhncc.donhang).FirstOrDefault();
                    dhcpx.ngayHTcham = ds.ngayhoanthanh;

                    //cac truong mac dinh dhncc
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

                    //------------
                    if (check_px == null)
                    {
                        dhcpx.ngaytao = DateTime.Now;
                        dhcpx.ngaycapnhat = DateTime.Now;
                        db.c_kehoachdathang_dhcpx.Add(dhcpx);
                    }
                    else
                    {
                        dhncc.ngaycapnhat = DateTime.Now;
                    }

                    //cac dong hang nha cung cap
                    string id_new1 = Helper.getNewId();
                    foreach (
                        c_kehoachdathang_dhncc_cdh abc in
                            db.c_kehoachdathang_dhncc_cdh.Where(
                                s => s.c_kehoachdathang_dhncc_id == dhncc.c_kehoachdathang_dhncc_id))
                    {
                        c_kehoachdathang_dhcpx_cdh check_ncc = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.md_sanpham_id == abc.md_sanpham_id & s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).FirstOrDefault();
                        c_kehoachdathang_dhcpx_cdh cdh = check_ncc;

                        if (cdh == null)
                        {
                            cdh = new c_kehoachdathang_dhcpx_cdh();
                            cdh.c_kehoachdathang_dhcpx_cdh_id = Helper.getNewId();
                            cdh.soluong = abc.soluong;
                        }
                        else
                        {
                            id_new1 = cdh.c_kehoachdathang_dhcpx_cdh_id;
                            cdh.soluong = cdh.soluong + abc.soluong;
                        }

                        cdh.c_kehoachdathang_id = dhcpx.c_kehoachdathang_id;
                        cdh.c_kehoachdathang_dhcpx_id = dhcpx.c_kehoachdathang_dhcpx_id;
                        cdh.md_sanpham_id = abc.md_sanpham_id;
                        cdh.macuoi = abc.macuoi;
                        cdh.md_donvitinhsanpham_id = abc.md_donvitinhsanpham_id;
                        md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == abc.md_sanpham_id).FirstOrDefault();
                        cdh.noigiaohang = sp.noigiaohang;
                        cdh.mota = " ";

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
                        cdh.hoatdong = true;

                        //Kiem tra
                        if (check_ncc == null)
                        {
                            cdh.ngaytao = DateTime.Now;
                            cdh.ngaycapnhat = DateTime.Now;
                            db.c_kehoachdathang_dhcpx_cdh.Add(cdh);
                        }
                        else
                        {
                            cdh.ngaycapnhat = DateTime.Now;
                        }
                    }
                    md_doitackinhdoanh dt = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dhncc.md_doitackinhdoanh_id).FirstOrDefault();
                    msg_success = "<div style='color:blue'>Dòng \"" + dt.ten_dtkd + "\" đã chuyển sang đặt hàng cho phân xưởng.</div>";
                }
                if (msg.Length <= 0)
                {
                    db.c_kehoachdathang_dhncc_cdh.RemoveRange(db.c_kehoachdathang_dhncc_cdh.Where(s => s.c_kehoachdathang_dhncc_id == id_sp));
                    db.c_kehoachdathang_dhncc.Remove(dhncc);
                    db.SaveChanges();
                    msg += msg_success;
                }
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void CA_01_TaoDonMuaHang(HttpContext context)
    {
        string msg = "", msg_success = "";
        EntityContext db = new EntityContext();
        string[] vnn = context.Request.Form["id"].Split(',');
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        int dem_sct = 0;

        foreach (var dhncc in db.c_kehoachdathang_dhncc.Where(s => vnn.Contains(s.c_kehoachdathang_dhncc_id)).ToList())
        {
            //Hieu luc tung don
            int countx = 0;
            int m = db.c_donmuahang.Where(s => s.c_kehoachdathang_dhncc_id == dhncc.c_kehoachdathang_dhncc_id & s.md_trangthai_id == "SOANTHAO").Count();
            countx += m;
            var dtkd = db.md_doitackinhdoanh.Where(s => s.md_doitackinhdoanh_id == dhncc.md_doitackinhdoanh_id).Take(1).FirstOrDefault();
            if (dhncc.chungtu != " ")
            {
                msg = "<div style='color:red'>Lỗi: Dòng \"" + dtkd.ma_dtkd + "\" đã tạo đơn mua hàng.</div>";
                break;
            }
            else if (dtkd.ma_dtkd.Contains("VinhGia"))
            {
                msg = "<div style='color:red'>Lỗi: Dòng \"" + dtkd.ma_dtkd + "\" không thể tạo đơn mua hàng.</div>";
                break;
            }
            else if (countx > 0)
            {
                msg = "<div style='color:red'>Đơn mua hàng trước chưa Hiệu Lực, không thể tạo phiếu mới.</div>";
                break;
            }
            else
            {
                c_kehoachdathang kh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id).FirstOrDefault();
                kh.trangthai = "HIEULUC";

                dem_sct++;
                string sochungtu = VNN_VariablePublic.sochungtu(db, "DMH", dem_sct);
                //Kiem tra bang gia
                var bg = db.md_banggia.Where(s => s.md_banggia_id == dhncc.banggia).Take(1).FirstOrDefault();
                md_phienbangia pbg = null;
                int gia = 0;
                //Kiem tra tap hop gia
                var thg = db.md_taphopgia.Where(s => s.hoatdong == true).OrderByDescending(s => s.nam).OrderByDescending(s => s.soky).Take(1).FirstOrDefault();
                if (bg != null)
                {
                    pbg = db.md_phienbangia.Where(s => s.md_banggia_id == dhncc.banggia & s.md_trangthai_id == "HIEULUC").Take(1).FirstOrDefault();
                    if(pbg != null)
                        gia = db.md_giasanpham.Where(s => s.md_phienbangia_id == pbg.md_phienbangia_id).Count();
                }

                if (thg != null & gia == 0)
                {
                    gia = db.md_taphopgia_cdh.Where(s => s.md_taphopgia_id == thg.md_taphopgia_id).Count();
                }

                if (bg == null & gia <= 0)
                {
                    if (bg == null)
                    {
                        msg += "<div style='color:red'>Lỗi:Nhà cung cấp \"" + dtkd.ma_dtkd + "\" không có bảng giá.</div>";
                        break;
                    }
                    else if (pbg == null)
                    {
                        msg += "<div style='color:red'>Lỗi:Nhà cung cấp \"" + dtkd.ma_dtkd + "\" không có phiên bảng giá.</div>";
                        break;
                    }
                    else if (gia <= 0)
                    {
                        msg += "<div style='color:red'>Lỗi:Nhà cung cấp \"" + dtkd.ma_dtkd + "\" không có giá sản phẩm.</div>";
                        break;
                    }
                }
                dhncc.chungtu = sochungtu;
                string id_new = Helper.getNewId();
                string md_dongtien_id = "", ma_iso_tiente = "";
                if (bg != null) { md_dongtien_id = bg.md_dongtien_id; }
                var dt = db.md_dongtien.Where(s => s.md_dongtien_id == md_dongtien_id).Take(1).FirstOrDefault();
                if (dt != null) { ma_iso_tiente = dt.ma_iso; }

                c_donmuahang dmh = new c_donmuahang();
                dmh.c_donmuahang_id = id_new;
                dmh.c_kehoachdathang_dhncc_id = dhncc.c_kehoachdathang_dhncc_id;
                dmh.md_trangthai_id = "SOANTHAO";
                dmh.sochungtu = sochungtu;
                dmh.phieunhapkho = " ";
                dmh.donhang_thamchieu = dhncc.donhang;
                dmh.huongdan_lamhang = "";
                dmh.ngaydonhang = DateTime.Now;
                dmh.ngaygiaohang = DateTime.Now.AddDays(4);
                dmh.diadiem_giaohang = "";
                dmh.md_doitackinhdoanh_id = dhncc.md_doitackinhdoanh_id;
                dmh.nguoilienhe = dtkd.daidien;

                if (dhncc != null & pbg != null)
                {
                    dmh.md_banggia_id = dhncc.banggia;
                    dmh.md_phienbangia_id = pbg.md_phienbangia_id;
                }

                dmh.md_dongtien_id = md_dongtien_id;
                dmh.tong_tienhang = 0;
                dmh.tong_tatca = 0;
                dmh.sctdathang = dhncc.sctdathang;
                dmh.chu_tong_tienhang = "Không " + ma_iso_tiente;
                dmh.chu_tong_tatca = "Không " + ma_iso_tiente;
                dmh.nguoitao = us.ad_user_id;
                dmh.vaitrotao = us.ad_role_id;
                dmh.bophantao = us.md_phongban_id;
                dmh.value_nguoitao = us.ma_user;
                dmh.value_vaitrotao = us.ten_role;
                dmh.value_bophantao = us.ten_phongban;
                dmh.nguoicapnhat = us.ad_user_id;
                dmh.vaitrocapnhat = us.ad_role_id;
                dmh.bophancapnhat = us.md_phongban_id;
                dmh.value_nguoicapnhat = us.ma_user;
                dmh.value_vaitrocapnhat = us.ten_role;
                dmh.value_bophancapnhat = us.ten_phongban;
                dmh.ngaytao = DateTime.Now;
                dmh.ngaycapnhat = DateTime.Now;
                dmh.mota = "";
                dmh.hoatdong = true;
                db.c_donmuahang.Add(dmh);

                foreach (var cdh_ncc in db.c_kehoachdathang_dhncc_cdh.Where(s => s.c_kehoachdathang_dhncc_id == dhncc.c_kehoachdathang_dhncc_id).ToList())
                {
                    var sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh_ncc.md_sanpham_id).FirstOrDefault();
                    decimal dongiamua = 0;
                    if (pbg != null)
                    {
                        var gia_sp = db.md_giasanpham.Where(s => s.md_phienbangia_id == pbg.md_phienbangia_id & s.md_sanpham_id == cdh_ncc.md_sanpham_id).Take(1).FirstOrDefault();
                        if (gia_sp != null)
                        {
                            dongiamua = gia_sp.gia.Value;
                        }
                        else if (gia_sp == null)
                        {
                            if (dtkd.ma_dtkd == "MUA NGOAI")
                            {
                                var gia_muangoai = (from a in db.md_giasanpham.Where(s => s.md_sanpham_id == cdh_ncc.md_sanpham_id)
                                                    join b in db.md_phienbangia on a.md_phienbangia_id equals b.md_phienbangia_id
                                                    join c in db.md_banggia on b.md_banggia_id equals c.md_banggia_id
                                                    where a.md_sanpham_id == cdh_ncc.md_sanpham_id & c.banggiaban == false
                                                    select new { a.gia, b.ngay_hieuluc }
                                                    ).OrderByDescending(s => s.ngay_hieuluc).Take(1);

                                if (gia_muangoai.Count() > 0)
                                {
                                    try
                                    {
                                        dongiamua = gia_muangoai.FirstOrDefault().gia.Value;
                                    }
                                    catch
                                    {
                                        dongiamua = 0;
                                    }
                                    string sql = string.Format(
                                    @"insert into md_giasanpham(
										[md_giasanpham_id]
									   ,[md_phienbangia_id]
									   ,[md_sanpham_id]
									   ,[gia]
									   ,[nguoitao]
									   ,[nguoicapnhat]
									   ,[ngaytao]
									   ,[ngaycapnhat]
									   ,[mota]
									   ,[hoatdong]) values(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{4}',getdate(),getdate(),N'',1)",
                                    Helper.getNewId(), pbg.md_phienbangia_id, cdh_ncc.md_sanpham_id, "" + dongiamua, us.ad_user_id);
                                    Mbg.Data.SqlClient.SqlHelper.ExcuteNonQuery(sql);
                                }
                                else
                                {
                                    msg += "<div style='color:red'>Lỗi:Nhà cung cấp \"<b>" + dtkd.ma_dtkd + "</b>\" không có giá của sản phẩm \"<b>" + sp.ma_sanpham + "</b>\"</div>";
                                }
                            }
                            else
                            {
                                msg += "<div style='color:red'>Lỗi:Nhà cung cấp \"<b>" + dtkd.ma_dtkd + "</b>\" không có giá của sản phẩm \"<b>" + sp.ma_sanpham + "</b>\"</div>";
                            }
                        }
                    }
                    else
                    {
                        var thg_cdh = db.md_taphopgia_cdh.Where(s => s.md_taphopgia_id == thg.md_taphopgia_id & s.md_sanpham_id == cdh_ncc.md_sanpham_id).FirstOrDefault();
                        if(thg_cdh != null)
                            dongiamua = thg_cdh.gia.Value;
                        else
                            msg += "<div style='color:red'>Lỗi:Nhà cung cấp \"<b>" + dtkd.ma_dtkd + "</b>\" không có giá của sản phẩm \"<b>" + sp.ma_sanpham + "</b>\"</div>";
                    }

                    var thue_sp = db.md_thue_sanpham.Where(s => s.md_thue_sanpham_id == sp.md_thue_sanpham_id).FirstOrDefault();
                    var cdmh = new c_donmuahang_cdmh();

                    cdmh.c_donmuahang_cdmh_id = Helper.getNewId();
                    cdmh.c_donmuahang_id = id_new;
                    cdmh.md_sanpham_id = cdh_ncc.md_sanpham_id;
                    cdmh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id;
                    cdmh.sl_dadat = cdh_ncc.soluong;
                    cdmh.sl_dadat2 = cdh_ncc.soluong;
                    cdmh.saiso = 0;
                    cdmh.sl_hanngach = 0;
                    cdmh.dongiamua = dongiamua;
                    cdmh.giachuan = dongiamua;
                    string md_thue_sanpham_id = "";
                    if (thue_sp != null)
                        md_thue_sanpham_id = thue_sp.md_thue_sanpham_id;
                    cdmh.thue = md_thue_sanpham_id;
                    cdmh.thanhtien = dongiamua * cdh_ncc.soluong.Value;
                    cdmh.nguoitao = us.ad_user_id;
                    cdmh.vaitrotao = us.ad_role_id;
                    cdmh.bophantao = us.md_phongban_id;
                    cdmh.value_nguoitao = us.ma_user;
                    cdmh.value_vaitrotao = us.ten_role;
                    cdmh.value_bophantao = us.ten_phongban;

                    cdmh.nguoicapnhat = us.ad_user_id;
                    cdmh.vaitrocapnhat = us.ad_role_id;
                    cdmh.bophancapnhat = us.md_phongban_id;
                    cdmh.value_nguoicapnhat = us.ma_user;
                    cdmh.value_vaitrocapnhat = us.ten_role;
                    cdmh.value_bophancapnhat = us.ten_phongban;

                    cdmh.ngaytao = DateTime.Now;
                    cdmh.ngaycapnhat = DateTime.Now;
                    cdmh.mota = "";
                    cdmh.hoatdong = true;
                    db.c_donmuahang_cdmh.Add(cdmh);

                    string id_news = Helper.getNewId();
                    //Tinh thue
                    var thue = new c_donmuahang_thue();
                    //--
                    decimal gt_thue = 0;
                    if (thue_sp != null)
                    {
                        gt_thue = thue_sp.giatri.Value;
                    }
                    thue.tong_tien_thue = cdmh.thanhtien * gt_thue / 100;
                    thue.tong_tien_chiu_thue = cdmh.thanhtien + thue.tong_tien_thue;
                    //--
                    thue.c_donmuahang_thue_id = id_news;
                    thue.c_donmuahang_id = cdmh.c_donmuahang_id;
                    thue.md_thue_sanpham_id = cdmh.thue;
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


                    if (cdmh.thue != "")
                    {
                        db.c_donmuahang_thue.Add(thue);
                    }
                }

                msg_success += "<div style='color:blue'>Tạo đơn mua hàng \"" + sochungtu + "\" thành công.</div>";

                //
                int dem_SLPX = db.c_kehoachdathang_dhcpx.Where(s => s.dongdathang == " " & s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id).Count();
                int dem_SLCC = db.c_kehoachdathang_dhncc.Where(s => s.chungtu == " " & s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id & s.c_kehoachdathang_dhncc_id != dhncc.c_kehoachdathang_dhncc_id).Count();
                c_kehoachdathang khdt = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhncc.c_kehoachdathang_id).FirstOrDefault();
                int dem_SL = dem_SLPX + dem_SLCC;
                if (dem_SL > 0)
                {
                    khdt.mota = "Còn \"" + dem_SL + "\" đơn hàng chưa đặt cho PX hoặc chưa cho NCC";
                    khdt.trangthai = "CHUAHET";
                }
                else
                {
                    khdt.mota = "";
                    khdt.trangthai = "DAHET";
                }
            }
            if (msg == "")
            {
                db.SaveChanges();
                msg = msg_success;
                //Start cap nhat Thue trong don mua hang
                foreach (c_donmuahang dmh in db.c_donmuahang.Where(s => vnn.Contains(s.c_kehoachdathang_dhncc_id)).ToList())
                {
                    var c_donmuahang_thues = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id);
                    //string id_notdel = "";
                    List<string> id_notdel_ = new List<string>();
                    foreach (var thue_donhang_list in c_donmuahang_thues.Select(s => new { s.md_thue_sanpham_id, s.c_donmuahang_id }).Distinct().ToList())
                    {
                        var c_donmuahang_thueschild = c_donmuahang_thues.Where(s => s.md_thue_sanpham_id == thue_donhang_list.md_thue_sanpham_id);
                        c_donmuahang_thue dmh_thue = c_donmuahang_thueschild.Take(1).FirstOrDefault();

                        dmh_thue.tong_tien_thue = c_donmuahang_thueschild.Select(s => s.tong_tien_thue).Sum();
                        dmh_thue.tong_tien_chiu_thue = c_donmuahang_thueschild.Select(s => s.tong_tien_chiu_thue).Sum();
                        //id_notdel += dmh_thue.c_donmuahang_thue_id + ",";
                        id_notdel_.Add(dmh_thue.c_donmuahang_thue_id);
                    }
                    foreach (c_donmuahang_thue dong_thue in c_donmuahang_thues.Where(s => !id_notdel_.Contains(s.c_donmuahang_thue_id)).ToList())
                    {
                        db.c_donmuahang_thue.Remove(dong_thue);
                    }
                }
                db.SaveChanges();
                //End cap nhat Thue trong don mua hang

                //Start cap nhat don mua hang
                foreach (c_donmuahang dmh in db.c_donmuahang.Where(s => vnn.Contains(s.c_kehoachdathang_dhncc_id)).ToList())
                {
                    decimal tong_tienhang = decimal.Parse("0.00");
                    try { tong_tienhang = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.thanhtien.Value).Sum(); } catch { }
                    decimal tong_tienthue = decimal.Parse("0.00");
                    try { tong_tienthue = db.c_donmuahang_thue.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Select(s => s.tong_tien_thue.Value).Sum(); } catch { }
                    decimal tong_tatca = tong_tienhang + tong_tienthue;
                    string donvitinh = "VND";
                    md_dongtien dt = db.md_dongtien.Where(s => s.md_dongtien_id == dmh.md_dongtien_id).Take(1).FirstOrDefault();
                    if (dt != null) { donvitinh = dt.ma_iso; }
                    var tth = VNN_ConvertMoney.convert((double)tong_tienhang, donvitinh).FirstOrDefault();
                    var ttc = VNN_ConvertMoney.convert((double)tong_tatca, donvitinh).FirstOrDefault();
                    dmh.tong_tienhang = (decimal)tth.Value;
                    dmh.tong_tatca = (decimal)ttc.Value;
                    dmh.chu_tong_tienhang = tth.Key;
                    dmh.chu_tong_tatca = ttc.Key;
                }
                db.SaveChanges();
                //End cap nhat don mua hang
            }
        }
        context.Response.Write(msg);
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
                string ten_table = "c_kehoachdathang_dhncc";
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
            string object_ = db.c_kehoachdathang_dhncc.Where(p => p.c_kehoachdathang_dhncc_id == id).Select(s => s.c_kehoachdathang_dhncc_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_kehoachdathang_dhncc";
                VNN_Function.SetFormValue("ma_dtkd", "VNN_notpost");
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", "VNN_notpost");
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
            string ten_table = "c_kehoachdathang_dhncc";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.c_kehoachdathang_dhncc.Where(p => p.c_kehoachdathang_dhncc_id == id_del_).Select(s => s.c_kehoachdathang_dhncc_id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    string action = "del";
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
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
}
