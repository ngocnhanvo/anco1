<%@ WebHandler Language="C#" Class="JQGridMD_01_DHCPXJQGSModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
using DevExpress.Data.Mask;

public class JQGridMD_01_DHCPXJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public EntityContext db = new EntityContext();
    public EntityFunction entityFunc = new EntityFunction();
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
            foreach (c_kehoachdathang_dhcpx dhcpx in db.c_kehoachdathang_dhcpx.Where(s => vnn.Contains(s.c_kehoachdathang_dhcpx_id)).ToList())
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
                    dhncc.nguoitao = userTK.ad_user_id;
                    dhncc.vaitrotao = userTK.ad_role_id;
                    dhncc.bophantao = userTK.md_phongban_id;
                    dhncc.value_nguoitao = userTK.ma_user;
                    dhncc.value_vaitrotao = userTK.ten_role;
                    dhncc.value_bophantao = userTK.ten_phongban;
                    dhncc.nguoicapnhat = userTK.ad_user_id;
                    dhncc.vaitrocapnhat = userTK.ad_role_id;
                    dhncc.bophancapnhat = userTK.md_phongban_id;
                    dhncc.value_nguoicapnhat = userTK.ma_user;
                    dhncc.value_vaitrocapnhat = userTK.ten_role;
                    dhncc.value_bophancapnhat = userTK.ten_phongban;
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

                    foreach (c_kehoachdathang_dhcpx_cdh abc in db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).ToList())
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

                        cdh.nguoitao = userTK.ad_user_id;
                        cdh.vaitrotao = userTK.ad_role_id;
                        cdh.bophantao = userTK.md_phongban_id;
                        cdh.value_nguoitao = userTK.ma_user;
                        cdh.value_vaitrotao = userTK.ten_role;
                        cdh.value_bophantao = userTK.ten_phongban;
                        cdh.nguoicapnhat = userTK.ad_user_id;
                        cdh.vaitrocapnhat = userTK.ad_role_id;
                        cdh.bophancapnhat = userTK.md_phongban_id;
                        cdh.value_nguoicapnhat = userTK.ma_user;
                        cdh.value_vaitrocapnhat = userTK.ten_role;
                        cdh.value_bophancapnhat = userTK.ten_phongban;
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
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string id_px = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                foreach (var dhcpx in db.c_kehoachdathang_dhcpx.Where(s => vnn.Contains(s.c_kehoachdathang_dhcpx_id)).ToList())
                {
                    if (dhcpx.md_phanxuong_id == "" || dhcpx.md_phanxuong_id == null || dhcpx.md_phanxuong_id == " ")
                    {
                        msg = "<div style='color:red'>Dòng " + dhcpx.donhang + " chưa có phân xưởng không thể tạo</div>";
                        break;
                    }
                    //khai bao
                    var px = db.md_phanxuong.FirstOrDefault(s => s.md_phanxuong_id == dhcpx.md_phanxuong_id);
                    if (px.ten_phanxuong == "PX.KẾ HOẠCH")
                    {
                        msg = "<div style='color:red'>Dòng " + dhcpx.donhang + " không thể tạo đơn hàng cho phân xưởng cho " + px.ten_phanxuong + ".</div>";
                        break;
                    }
                    var c_kehoachdathang_dhcpx_cdhs = db.c_kehoachdathang_dhcpx_cdh.Where(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id);
                    if (dhcpx.dongdathang != " ")
                    {
                        msg += "<div style='color:red'>Dòng " + px.ten_phanxuong + " của " + dhcpx.donhang + " đã tạo đơn!!</div>";
                    }

                    foreach (var dh_dkpx in db.c_kehoachdathang_dhcpx_cdh.Where(s =>
                         s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id).ToList())
                    {
                        if (
                                db.md_sanpham_bom_vattu.Where(t =>
                                   t.md_sanpham_bom_id == dh_dkpx.md_sanpham_bom_id
                                ).Count() <= 0
                        )
                        {
                            msg += "<div style='color:red'>Dòng " + dh_dkpx.macuoi + " chưa có vật tư trong BOM!!</div>";
                        }
                    }
                    if (msg.Length <= 0)
                    {
                        //--them dong don dat hang phan xuong
                        id_px = add_px(db, dhcpx, 1, userTK);

                        //start
                        var ddh = db.md_dondathangphanxuong.FirstOrDefault(s => s.c_kehoachdathang_dhcpx_id == dhcpx.c_kehoachdathang_dhcpx_id);
                        foreach (var dhcpx_cdh in c_kehoachdathang_dhcpx_cdhs.ToList())
                        {
                            add_px_cd(db, ddh.md_dondathangphanxuong_id, dhcpx_cdh.md_sanpham_id, dhcpx_cdh.noigiaohang, dhcpx_cdh.soluong.Value, dhcpx_cdh.md_donvitinhsanpham_id, dhcpx_cdh.mota, 1, userTK);
                        }
                        //end

                        //start 
                        add_px_vattu(db, dhcpx.c_kehoachdathang_dhcpx_id, id_px, userTK);
                        //end                

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
                        msg_success += "<div style='color:blue'>" + px.ten_phanxuong + " của " + dhcpx.donhang + " đã tạo đơn thành công.</div>";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = msg_success;
                transaction.Commit();
            }
            else
                transaction.Rollback();
        }
        context.Response.Write(msg);
    }

    //vat tu
    public void add_px_vattu(EntityContext db, string c_kehoachdathang_dhcpx_id, string md_dondathangphanxuong_id, User_TK us)
    {
        foreach (var bom_vattu in db.c_kehoachdathang_dhcpx_vattu.Where(s => s.c_kehoachdathang_dhcpx_id == c_kehoachdathang_dhcpx_id & s.soluong > 0).ToList())
        {
            var vattu = new md_dondathangphanxuong_vattu();
            vattu.md_dondathangphanxuong_vattu_id = Helper.getNewId();
            vattu.soluong = bom_vattu.soluong;
            vattu.sl_hanngach = 0;
            vattu.md_sanpham_id = bom_vattu.md_sanpham_id;
            vattu.md_dondathangphanxuong_id = md_dondathangphanxuong_id;
            vattu.md_donvitinhsanpham_id = bom_vattu.md_donvitinhsanpham_id;
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
            vattu.ngaytao = DateTime.Now;
            vattu.ngaycapnhat = DateTime.Now;
            db.md_dondathangphanxuong_vattu.Add(vattu);
        }
        db.SaveChanges();
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

        int so_ngay = 0;
        var ngaydksxes = from aa in db.md_dondathangphanxuong_cdh
                         join bb in db.md_sanpham on aa.md_sanpham_id equals bb.md_sanpham_id
                         join cc in db.md_chungloai on bb.md_nhomnangluc_id equals cc.md_chungloai_id
                         where aa.md_dondathangphanxuong_id == ddh.md_dondathangphanxuong_id
                         select new { cc.songaysx };

        if (dhcpx.donhang.Contains("_SR-"))
        {
            ddh.ngay_hieuluc = dhcpx.ngayHTcham.Value.AddDays(-15);
        }
        else
        {
            if (ngaydksxes.Count() > 0)
            {
                var dsnsx = ngaydksxes.OrderByDescending(s => s.songaysx).FirstOrDefault();
                if (dsnsx != null)
                {
                    ddh.ngay_hieuluc = dhcpx.ngayHTcham.Value.AddDays(0 - dsnsx.songaysx.Value);
                    so_ngay = dsnsx.songaysx.Value;
                }
            }
            else
                ddh.ngay_hieuluc = dhcpx.ngayHTcham.Value.AddDays(-40);
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
        ddh.hdlh = dhcpx.hdlh;
        ddh.hdlhchung = dhcpx.hdlhchung;
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
        string msg = "";
        context.Response.Write(msg);
    }

    public void edit(HttpContext context)
    {
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_phanxuong_id = context.Request.Form["md_phanxuong_id"];
        string mota = context.Request.Form["mota"];
        string ghichu = context.Request.Form["ghichu"];
        try
        {
            string id = context.Request.Form["id"];
            var object_ = db.c_kehoachdathang_dhcpx.Where(p => p.c_kehoachdathang_dhcpx_id == id).FirstOrDefault();

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                var dmh = db.md_dondathangphanxuong.Where(s => s.c_kehoachdathang_dhcpx_id == object_.c_kehoachdathang_dhcpx_id).FirstOrDefault();
                if (dmh != null)
                {
                    if (ghichu.Trim().Length > 0)
                        object_.mota = DateTime.Now + "\n\n" + ghichu + "\n" + "__________________" + "\n\n" + object_.mota;
                    else
                        object_.mota = DateTime.Now + "\n\n" + ghichu;
                }
                else
                {
                    object_.mota = DateTime.Now + "\n\n" + ghichu;
                    object_.hdlh = context.Request.Form["hdlh"];
                    object_.hdlhchung = context.Request.Form["hdlhchung"];
                }
                object_.ngayHTcham = VNN_Config.setDateTime(context.Request.Form["ngayHTcham"]);
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
        string msg = "";
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