<%@ WebHandler Language="C#" Class="JQGridMD_01_DHCPXJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
using DevExpress.Data.Mask;

public class JQGridMD_01_DHCPXJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_TDDHPX":
                this.CA_01_TDDHPX(context);
                break;
            case "CA_01_Dathangncc":
                this.CA_01_Dathangncc(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_Dathangncc(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context),
        Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string id_sp = context.Request.Form["id_sp"];
        string[] vnn = context.Request.Form["id_sp"].Split(',');
        string ma_dtkd = context.Request.Form["ma_dtkd"];
        md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == ma_dtkd).Take(1).FirstOrDefault();
        if (dtkd == null)
        {
            msg = "<div style='color:red'>Lỗi: Không tìm thấy đối tác \"" + ma_dtkd + "\".</div>";
        }
        try
        {
            foreach (c_kehoachdathang_dhcpx dhcpx in db.c_kehoachdathang_dhcpx.Where(s => vnn.Contains(s.c_kehoachdathang_dhcpx_id)))
            {
                md_phanxuong px = db.md_phanxuong.Where(s => s.md_phanxuong_id == dhcpx.md_phanxuong_id).FirstOrDefault();
                if (dhcpx.dongdathang != " " & dhcpx.dongdathang != "" & dhcpx.dongdathang != null)
                {
                    msg = "<div style='color:red'>Lỗi: Dòng \"" + px.ten_phanxuong + "\" đã tạo đơn đặt hàng PX .</div>";
                }

                if (msg.Length <= 0)
                {
                    //Dat hang nha cung cap
                    string id_new = Helper.getNewId();
                    c_kehoachdathang_dhncc check_px = db.c_kehoachdathang_dhncc.FirstOrDefault(s => s.md_doitackinhdoanh_id == dtkd.md_doitackinhdoanh_id & s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id);
                    c_kehoachdathang_dhncc dhncc = check_px;
                    if (dhncc == null)
                    {
                        dhncc = new c_kehoachdathang_dhncc();
                        dhncc.c_kehoachdathang_dhncc_id = Helper.getNewId();
                        dhncc.chungtu = " ";
                    }
                    else
                    {
                        id_new = dhncc.c_kehoachdathang_dhncc_id;
                    }

                    dhncc.c_kehoachdathang_id = id;
                    dhncc.md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id;
                    dhncc.donhang = dhcpx.donhang;
                    dhncc.mota = " ";
                    dhncc.banggia = dtkd.md_banggia_id;
                    dhncc.sctdathang = dhcpx.sctdathang;
                    //dhncc.mota = dhcpx.mota;

                    //cac truong mac dinh dhncc
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

                    //------------
                    if (check_px == null)
                    {
                        dhncc.ngaytao = DateTime.Now;
                        dhncc.ngaycapnhat = DateTime.Now;
                        db.c_kehoachdathang_dhncc.Add(dhncc);
                    }
                    else
                    {
                        dhncc.ngaycapnhat = DateTime.Now;
                    }

                    //cac dong hang nha cung cap

                    foreach (c_kehoachdathang_dhcpx_cdh abc in db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id))
                    {
                        string id_new1 = Helper.getNewId();
                        c_kehoachdathang_dhncc_cdh check_ncc = db.c_kehoachdathang_dhncc_cdh.Where(s => s.md_sanpham_id == abc.md_sanpham_id & s.c_kehoachdathang_dhncc_id == dhncc.c_kehoachdathang_dhncc_id).FirstOrDefault();
                        c_kehoachdathang_dhncc_cdh cdh = check_ncc;

                        if (cdh == null)
                        {
                            cdh = new c_kehoachdathang_dhncc_cdh();
                            cdh.c_kehoachdathang_dhncc_cdh_id = Helper.getNewId();
                            cdh.soluong = abc.soluong;
                        }
                        else
                        {
                            id_new1 = cdh.c_kehoachdathang_dhncc_cdh_id;
                            cdh.soluong = cdh.soluong + abc.soluong;
                        }

                        cdh.c_kehoachdathang_id = dhncc.c_kehoachdathang_id;
                        cdh.c_kehoachdathang_dhncc_id = dhncc.c_kehoachdathang_dhncc_id;
                        cdh.md_sanpham_id = abc.md_sanpham_id;
                        cdh.macuoi = abc.macuoi;
                        cdh.md_donvitinhsanpham_id = abc.md_donvitinhsanpham_id;
                        cdh.mota = " ";

                        c_danhsachdathang dsdh = db.c_danhsachdathang.Where(s => s.so_po == dhcpx.donhang).FirstOrDefault();
                        cdh.ngaycan = dsdh.ngayhoanthanh;

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
                            db.c_kehoachdathang_dhncc_cdh.Add(cdh);
                        }
                        else
                        {
                            cdh.ngaycapnhat = DateTime.Now;
                        }
                    }
                    msg_success = "<div style='color:blue'>Dòng \"" + px.ten_phanxuong + "\" đã chuyển sang đặt hàng nhà cung cấp.</div>";
                }
                if (msg.Length <= 0)
                {
                    db.c_kehoachdathang_dhcpx_cdh.RemoveRange(db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == id_sp));
                    db.c_kehoachdathang_dhcpx.Remove(dhcpx);
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

    public void CA_01_TDDHPX(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context),
        Security.id_phongban(context));
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string id_px = "";
        try
        {
            foreach (var dhcpx in db.c_kehoachdathang_dhcpx.Where(s => vnn.Contains(s.c_kehoachdathang_dhcpx_id)).ToList())
            {
                if (dhcpx.md_phanxuong_id == "" || dhcpx.md_phanxuong_id == null || dhcpx.md_phanxuong_id == " ")
                {
                    msg += "<div style='color:red'>Dòng " + dhcpx.donhang + " chưa có phân xưởng không thể tạo</div>";
                    break;
                }
                //khai bao
                var px = db.md_phanxuong.FirstOrDefault(s => s.md_phanxuong_id == dhcpx.md_phanxuong_id);
                if (px.ten_phanxuong == "PX.KẾ HOẠCH")
                {
                    msg += "<div style='color:red'>Dòng " + dhcpx.donhang + " không thể tạo đơn hàng cho phân xưởng cho " + px.ten_phanxuong + ".</div>";
                    break;
                }
                var c_kehoachdathang_dhcpx_cdhs = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id);
                //kiem tra ma san pham co trong BOM 
                int bom = 0;
                string msg_fail = "";
                foreach (var dhcpx_cdh_ in c_kehoachdathang_dhcpx_cdhs.ToList())
                {
                    bom = (from a in db.md_sanpham_bom where a.md_sanpham_id == dhcpx_cdh_.md_sanpham_id & a.trangthai == "HIEULUC" select new { a.md_sanpham_bom_id }).Count();
                    if (bom <= 0)
                    {
                        var sp = db.md_sanpham.FirstOrDefault(s => s.md_sanpham_id == dhcpx_cdh_.md_sanpham_id);
                        msg_fail += "<div style='color:red'>Sản phẩm <b>\"" + sp.ma_sanpham + "\"</b> của dòng \"" + px.ten_phanxuong + "\" không có BOM !!!</div>";
                    }
                }
                //check Đơn đặt hàng cho xưỡng
                if (dhcpx.dongdathang != " ")
                {
                    msg += "<div style='color:red'>Dòng " + px.ten_phanxuong + " của " + dhcpx.donhang + " đã tạo đơn!!</div>";
                }
                else if (bom < c_kehoachdathang_dhcpx_cdhs.Count())
                {
                    msg = msg_fail;
                }

                if (msg.Length <= 0)
                {
                    //--them dong don dat hang phan xuong
                    id_px += add_px(db, dhcpx, 1, us) + ",";

                    //start
                    var ddh = db.md_dondathangphanxuong.FirstOrDefault(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id);
                    foreach (var dhcpx_cdh in c_kehoachdathang_dhcpx_cdhs.ToList())
                    {
                        //--them cac dong dat hang phan xuong
                        add_px_cd(db, ddh.md_dondathangphanxuong_id, dhcpx_cdh.md_sanpham_id, dhcpx_cdh.noigiaohang, dhcpx_cdh.soluong.Value, dhcpx_cdh.md_donvitinhsanpham_id, dhcpx_cdh.mota, 1, us);
                    }
                    //end

                    //start
                    foreach (var cdh in db.md_dondathangphanxuong_cdh.Where(s => s.md_dondathangphanxuong_id == ddh.md_dondathangphanxuong_id).OrderBy(s => s.md_sanpham_id).ToList())
                    {
                        //--them cac dong dat hang phan xuong
                        add_px_vattu(db, cdh, 1, us);
                    }
                    //end                
                    msg += "<div style='color:blue'>" + px.ten_phanxuong + " của " + dhcpx.donhang + " đã tạo đơn thành công.</div>";

                    int dem_SLPX = db.c_kehoachdathang_dhcpx.Where(s => s.dongdathang == " " & s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id & s.c_kehoachdathang_dhcpx_id != dhcpx.c_kehoachdathang_dhcpx_id).Count();
                    int dem_SLCC = db.c_kehoachdathang_dhncc.Where(s => s.chungtu == " " & s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id).Count();
                    var khdt = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id).FirstOrDefault();
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
                    db.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            int count = id_px.Split(',').Length;
            string[] id_del = new string[count];
            id_del = id_px.Split(',');
            for (int i = 0; i < count; i++)
            {
                var id_del_ = id_del[i];
                var object_ = db.md_dondathangphanxuong.Where(p => p.md_dondathangphanxuong_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                }
                else if (object_.md_trangthai_id == "HIEULUC")
                {
                }
                else
                {
                    var dhcpx = db.c_kehoachdathang_dhcpx.FirstOrDefault(s => s.c_kehoachdathang_dhcpx_id == object_.c_kehoachdathang_dhcpx_id);
                    if (dhcpx != null)
                        dhcpx.dongdathang = " ";

                    db.md_dondathangphanxuong.Remove(object_);
                    db.SaveChanges();
                    var c_kehoachdathang_dhcpxes = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id);
                    var c_kehoachdathang_dhnccs = db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id);
                    if (
                        c_kehoachdathang_dhcpxes.Count() == c_kehoachdathang_dhcpxes.Where(s => s.dongdathang == " ").Count() &
                        c_kehoachdathang_dhnccs.Count() == c_kehoachdathang_dhnccs.Where(s => s.chungtu == " ").Count()
                    )
                    {
                        var khdh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id).FirstOrDefault();
                        if (khdh != null)
                            khdh.trangthai = "SOANTHAO";
                    }
                    //--
                    foreach (var dhcpx_ in db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == object_.c_kehoachdathang_dhcpx_id).ToList())
                    {
                        var khdh_ = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhcpx_.c_kehoachdathang_id).FirstOrDefault();
                        // dem SL don dat hang chua tao
                        int dem_SLPX = db.c_kehoachdathang_dhcpx.Where(s => s.dongdathang == " " & s.c_kehoachdathang_id == khdh_.c_kehoachdathang_id).Count();
                        int dem_SLCC = db.c_kehoachdathang_dhncc.Where(s => s.chungtu == " " & s.c_kehoachdathang_id == khdh_.c_kehoachdathang_id).Count();
                        // dem tong SL don hang
                        int dem_SLPX_ = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == khdh_.c_kehoachdathang_id).Count();
                        int dem_SLCC_ = db.c_kehoachdathang_dhncc.Where(s => s.c_kehoachdathang_id == khdh_.c_kehoachdathang_id).Count();

                        int dem_SL = dem_SLPX + dem_SLCC;
                        //
                        int dem_SL_ = dem_SLPX_ + dem_SLCC_;
                        if (dem_SL == dem_SL_)
                        {
                            khdh_.trangthai = "SOANTHAO";
                            khdh_.mota = " ";
                        }
                        else if (dem_SL > 0)
                        {
                            khdh_.mota = "Còn \"" + dem_SL + "\" đơn hàng chưa đặt cho PX hoặc chưa cho NCC";
                            khdh_.trangthai = "CHUAHET";
                        }
                    }
                    VNN_VariablePublic.sochungtu_(db, "DDHPX", 1);
                    db.SaveChanges();
                }
            }
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    //vat tu
    public string add_px_vattu(EntityContext db, md_dondathangphanxuong_cdh cdh, int i, User_TK us)
    {
        string id_new = Helper.getNewId();
        //lay bom san pham vat tu
        var bom = (from a in db.md_sanpham_bom
                   where a.md_sanpham_id == cdh.md_sanpham_id & a.trangthai == "HIEULUC"
                   select new { a.md_sanpham_bom_id }).FirstOrDefault();

        var ngaydksxes = (from a in db.md_dondathangphanxuong_cdh
                          join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                          join c in db.md_chungloai on b.md_nhomnangluc_id equals c.md_chungloai_id
                          where a.md_dondathangphanxuong_id == cdh.md_dondathangphanxuong_id
                          select new { c.songaysx }).OrderByDescending(s => s.songaysx).FirstOrDefault();

        foreach (var bom_vattu in db.md_sanpham_bom_vattu.Where(s => s.md_sanpham_bom_id == bom.md_sanpham_bom_id & s.soluong > 0).ToList())
        {
            //kiem tra          
            var check_px = db.md_dondathangphanxuong_vattu.Where(s => s.md_sanpham_id == bom_vattu.md_sanpham_id & s.md_dondathangphanxuong_id == cdh.md_dondathangphanxuong_id).FirstOrDefault();
            var vattu = check_px;

            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == bom_vattu.md_sanpham_id).FirstOrDefault();
            if (sp.vattu == true)
            {
                if (vattu == null)
                {
                    vattu = new md_dondathangphanxuong_vattu();
                    vattu.md_dondathangphanxuong_vattu_id = Helper.getNewId();
                    vattu.soluong = (decimal)bom_vattu.soluong * cdh.tong_sl_dat;
                    vattu.sl_hanngach = 0;
                }
                else
                {
                    id_new = vattu.md_dondathangphanxuong_vattu_id;
                    vattu.soluong = vattu.soluong + ((decimal)bom_vattu.soluong * cdh.tong_sl_dat);
                }

                //if (sp.vattu == true)
                //{
                //    vattu.soluong = Math.Ceiling((decimal)(((decimal)bom_vattu.soluong * cdh.tong_sl_dat) / ngaydksxes.songaysx));
                //}

                vattu.md_sanpham_id = bom_vattu.md_sanpham_id;

                vattu.md_dondathangphanxuong_id = cdh.md_dondathangphanxuong_id;
                vattu.md_dondathangphanxuong_cdh_id = cdh.md_dondathangphanxuong_cdh_id;
                vattu.md_donvitinhsanpham_id = bom_vattu.md_donvitinhsanpham_id;
                vattu.mota_tiengviet = sp.mota_tiengviet;

                vattu.nguoitao = us.ad_user_id;
                vattu.vaitrotao = us.ad_role_id;
                vattu.bophantao = us.md_phongban_id;
                vattu.value_nguoitao = us.ma_user;
                vattu.value_vaitrotao = us.ten_role;
                vattu.value_bophantao = us.ten_phongban;
                vattu.nguoicapnhat = us.ad_user_id;
                vattu.vaitrocapnhat = us.ad_role_id;
                vattu.bophancapnhat = us.md_phongban_id;
                vattu.value_nguoicapnhat = us.ma_user;
                vattu.value_vaitrocapnhat = us.ten_role;
                vattu.value_bophancapnhat = us.ten_phongban;
                vattu.hoatdong = true;

                //Kiem tra
                if (check_px == null)
                {
                    vattu.ngaytao = DateTime.Now;
                    vattu.ngaycapnhat = DateTime.Now;
                    db.md_dondathangphanxuong_vattu.Add(vattu);
                }
                else
                {
                    vattu.ngaycapnhat = DateTime.Now;
                }
                db.SaveChanges();
            }
        }
        return id_new;
    }
    //cac dong
    public string add_px_cd(EntityContext db, string md_dondathangphanxuong_id, string md_sanpham_id, string noigiaohang, decimal soluong, string md_donvitinhsanpham_id, string mota, int i, User_TK us)
    {
        string id_new = Helper.getNewId();
        //kiem tra
        md_dondathangphanxuong_cdh check_px = db.md_dondathangphanxuong_cdh.Where(s => s.md_sanpham_id == md_sanpham_id & s.md_dondathangphanxuong_id == md_dondathangphanxuong_id).FirstOrDefault();
        md_dondathangphanxuong_cdh cdh = check_px;

        c_kehoachdathang_dhcpx_cdh dhcpx = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.md_sanpham_id == md_sanpham_id & s.md_donvitinhsanpham_id == md_donvitinhsanpham_id).FirstOrDefault();
        if (check_px == null)
        {
            cdh = new md_dondathangphanxuong_cdh();
            cdh.md_dondathangphanxuong_cdh_id = Helper.getNewId();
        }
        else
        {
            id_new = cdh.md_dondathangphanxuong_id;
        }
        cdh.md_dondathangphanxuong_id = md_dondathangphanxuong_id;
        cdh.md_sanpham_id = md_sanpham_id;
        cdh.tong_sl_dat = soluong;
        cdh.hanngach = cdh.tong_sl_dat;
        cdh.sl_chiato = 0;
        cdh.sl_hoanthanh = 0;
        cdh.md_donvitinhsanpham_id = md_donvitinhsanpham_id;
        cdh.noigiaohang = noigiaohang;
        cdh.macuoi = dhcpx.macuoi;

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
        cdh.hoatdong = true;

        //Kiem tra
        if (check_px == null)
        {
            cdh.ngaytao = DateTime.Now;
            cdh.ngaycapnhat = DateTime.Now;
            db.md_dondathangphanxuong_cdh.Add(cdh);
        }
        else
        {
            cdh.ngaycapnhat = DateTime.Now;
        }
        db.SaveChanges();
        return id_new;
    }

    //them dong don dat hang
    public string add_px(EntityContext db, c_kehoachdathang_dhcpx dhcpx, int i, User_TK us)
    {
        int dem_sct = 0;
        dem_sct++;
        string sochungtu = VNN_VariablePublic.sochungtu(db, "DDHPX", dem_sct);
        c_kehoachdathang_dhcpx a = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).FirstOrDefault();
        a.dongdathang = sochungtu;
        c_kehoachdathang b = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == a.c_kehoachdathang_id).FirstOrDefault();
        b.trangthai = "HIEULUC";
        string id_new = Helper.getNewId();
        //kiem tra
        md_dondathangphanxuong check_px = db.md_dondathangphanxuong.Where(s => s.md_phanxuong_id == dhcpx.md_phanxuong_id & s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).FirstOrDefault();
        md_dondathangphanxuong ddh = check_px;

        if (check_px == null)
        {
            ddh = new md_dondathangphanxuong();
            ddh.md_dondathangphanxuong_id = id_new;
        }
        else
        {
            id_new = ddh.md_dondathangphanxuong_id;
        }
        ddh.md_trangthai_id = "SOANTHAO";
        ddh.c_kehoachdathang_dhcpx_id = dhcpx.c_kehoachdathang_dhcpx_id;
        ddh.md_phanxuong_id = dhcpx.md_phanxuong_id;
        ddh.donhang_thamchieu = dhcpx.donhang;
        ddh.ngayhoanthanh = dhcpx.ngayHTcham;
        ddh.ngayketthuc = dhcpx.ngayHTcham;
        ddh.sochungtu = sochungtu;
        ddh.yeucaumuavattu = " ";
        ddh.sctdathang = dhcpx.sctdathang;

        ddh.nguoitao = us.ad_user_id;
        ddh.vaitrotao = us.ad_role_id;
        ddh.bophantao = us.md_phongban_id;
        ddh.value_nguoitao = us.ma_user;
        ddh.value_vaitrotao = us.ten_role;
        ddh.value_bophantao = us.ten_phongban;
        ddh.nguoicapnhat = us.ad_user_id;
        ddh.vaitrocapnhat = us.ad_role_id;
        ddh.bophancapnhat = us.md_phongban_id;
        ddh.value_nguoicapnhat = us.ma_user;
        ddh.value_vaitrocapnhat = us.ten_role;
        ddh.value_bophancapnhat = us.ten_phongban;
        ddh.hoatdong = true;

        //Kiem tra
        if (check_px == null)
        {
            ddh.ngaytao = DateTime.Now;
            ddh.ngaycapnhat = DateTime.Now;
            db.md_dondathangphanxuong.Add(ddh);
        }
        else
        {
            ddh.ngaycapnhat = DateTime.Now;
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
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "c_kehoachdathang_dhcpx";
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

    public static T Clone<T>(T source)
    {
        var dcs = new System.Runtime.Serialization.DataContractSerializer(typeof(T));
        using (var ms = new System.IO.MemoryStream())
        {
            dcs.WriteObject(ms, source);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            return (T)dcs.ReadObject(ms);
        }
    }

    public void edit(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_phanxuong_id = context.Request.Form["md_phanxuong_id"];
        string mota = context.Request.Form["mota"];
        string ghichu = context.Request.Form["ghichu"];
        try
        {
            string id = context.Request.Form["id"];
            c_kehoachdathang_dhcpx object_ = db.c_kehoachdathang_dhcpx.Where(p => p.c_kehoachdathang_dhcpx_id == id).FirstOrDefault();

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            /*else if(object_.dongdathang != "" & object_.dongdathang != " " & object_.dongdathang != null)
            {
                msg = "false#Lỗi đã tạo đơn đặt hàng không thể sửa.";
            }*/

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_kehoachdathang_dhcpx";
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);

                md_dondathangphanxuong dmh = null;
                dmh = db.md_dondathangphanxuong.Where(s => s.c_kehoachdathang_dhcpx_id == object_.c_kehoachdathang_dhcpx_id).FirstOrDefault();
                if (dmh != null)
                {
                    if (dmh.md_trangthai_id == "HIEULUC")
                    {
                        if (ghichu.Trim().Length > 0)
                            object_.mota = DateTime.Now + "\n\n" + ghichu + "\n" + "__________________" + "\n\n" + object_.mota;
                    }
                    else
                    {
                        object_.mota = DateTime.Now + "\n\n" + ghichu;
                    }
                }
                else
                {
                    object_.mota = DateTime.Now + "\n\n" + ghichu;
                }

                /*c_kehoachdathang_dhcpx object_1 = db.c_kehoachdathang_dhcpx.FirstOrDefault(s => s.c_kehoachdathang_id == id & s.md_phanxuong_id == md_phanxuong_id);
                if(object_1 != null)
                {
                    decimal soluong = 0;
                    int i = 0;
                    string id_kehoachdathang_dhcpx = "",c_kehoachdathang_id = "";;
                    foreach (c_kehoachdathang_dhcpx_cdh cdh_px in db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == object_.c_kehoachdathang_dhcpx_id))
                    {
                        c_kehoachdathang_dhcpx dhcpx = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == cdh_px.c_kehoachdathang_dhcpx_id).FirstOrDefault();
                        soluong = cdh_px.soluong.Value;
                        c_kehoachdathang_id = dhcpx.c_kehoachdathang_id;
                            if (i == 0)
                            {
                                c_kehoachdathang_dhcpx dhcpx_check = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == dhcpx.c_kehoachdathang_id &
                                s.md_phanxuong_id == md_phanxuong_id & s.dongdathang == " ").Take(1).FirstOrDefault();
                                if (dhcpx_check == null)
                                {
                                    id_kehoachdathang_dhcpx = Helper.getNewId();
                                    c_kehoachdathang_dhcpx dhcpx_new = Clone(dhcpx);
                                    dhcpx_new.c_kehoachdathang_dhcpx_id = id_kehoachdathang_dhcpx;
                                    dhcpx_new.md_phanxuong_id = md_phanxuong_id;
                                    db.c_kehoachdathang_dhcpx.Add(dhcpx_new);
                                }
                                else {
                                    id_kehoachdathang_dhcpx = dhcpx_check.c_kehoachdathang_dhcpx_id;
                                }
                            }
                            //--
                            c_kehoachdathang_dhcpx_cdh cdh_dhcpx_check = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == id_kehoachdathang_dhcpx
                            & s.md_sanpham_id == cdh_px.md_sanpham_id).Take(1).FirstOrDefault();
                            if (cdh_dhcpx_check == null)
                            {
                                c_kehoachdathang_dhcpx_cdh cdh_px_new = Clone(cdh_px);
                                cdh_px_new.c_kehoachdathang_dhcpx_cdh_id = Helper.getNewId();
                                cdh_px_new.c_kehoachdathang_dhcpx_id = id_kehoachdathang_dhcpx;
                                cdh_px_new.soluong = soluong;
                                cdh_px_new.ngaycapnhat = null;
                                db.c_kehoachdathang_dhcpx_cdh.Add(cdh_px_new);
                            }
                            else {
                                cdh_dhcpx_check.soluong += soluong;
                            }
                            //--
                            cdh_px.soluong -= soluong;
                            i = 1;
                    }
                    if (msg.Length <= 0)
                    {
                        md_phanxuong px = db.md_phanxuong.Where(s => s.md_phanxuong_id == md_phanxuong_id).FirstOrDefault();
                        msg = "<div style='color:blue'>Đặt hàng  \"" + px.ten_phanxuong + "\" thành công.</div>";
                        db.SaveChanges();
                        foreach (c_kehoachdathang_dhcpx dhcpx in db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == c_kehoachdathang_id))
                        {
                            decimal tong_soluong = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).Select(s => s.soluong.Value).Sum();
                            if (tong_soluong <= 0)
                            {
                                db.c_kehoachdathang_dhcpx.Remove(dhcpx);
                            }
                            else {
                                foreach (c_kehoachdathang_dhcpx_cdh dhcpx_cdh in db.c_kehoachdathang_dhcpx_cdh.Where(s => s.soluong <= 0))
                                {
                                    db.c_kehoachdathang_dhcpx_cdh.Remove(dhcpx_cdh);
                                }
                            }
                        }
                    }				
                }*/
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
            string ten_table = "c_kehoachdathang_dhcpx";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.c_kehoachdathang_dhcpx.Where(p => p.c_kehoachdathang_dhcpx_id == id_del_).Select(s => s.c_kehoachdathang_dhcpx_id).Take(1).FirstOrDefault();
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