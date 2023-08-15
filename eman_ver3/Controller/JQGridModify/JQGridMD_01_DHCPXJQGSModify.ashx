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
        string msg = "",id_new = Helper.getNewId();
        string id = context.Request.Form["id"];
        var kh = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == id).FirstOrDefault();
        if(kh == null)
        {
            msg = string.Format("<div class='error' style='color:red'>Kế hoạch không tồn tại.</div>");
        }
        else if(kh.trangthai != Helper.SOANTHAO)
        {
            msg = string.Format("<div class='error' style='color:red'>Kế hoạch không ở trạng thái Soạn Thảo.</div>");
        }
        else
        {
            var khdhpxs = db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_id == kh.c_kehoachdathang_id).ToList();

            foreach (var khpx in khdhpxs)
            {
                var dhpx = db.md_dondathangphanxuong.Where(s => s.c_kehoachdathang_dhcpx_id == khpx.c_kehoachdathang_dhcpx_id).FirstOrDefault();

                if(khpx.ngayBDSX == null)
                {
                    msg += string.Format(@"<div class='error' style='color:red'>Đơn hàng {0}, Quy trình {1} chưa có ngày bắt đầu sản xuất</div>",
                        dhpx.donhang_thamchieu,
                        db.md_phanxuong.Where(s => s.md_phanxuong_id == dhpx.md_phanxuong_id).Select(s => s.ten_phanxuong).FirstOrDefault());
                }
                else
                {
                    dhpx.ngay_hieuluc = khpx.ngayBDSX;
                    var lsx = db.md_lenhsanxuat.Where(s => s.md_dondathangphanxuong_id == dhpx.md_dondathangphanxuong_id).FirstOrDefault();
                    if(lsx != null)
                        lsx.md_trangthai_id = Helper.KHDXL;
                }
            }

            if (msg.Length <= 0)
            {
                kh.trangthai = "DAHET";

                var kht = db.c_kehoachdathangtong.Where(s => s.ten_kh == kh.nhomKH).FirstOrDefault();
                if (kht != null)
                {
                    kht.trangthai = Helper.DATSX;
                }

                db.SaveChanges();
                msg = string.Format("<div id='trangthaiKHT' tt='{0}' style='color:blue'>Triển khai sản xuất thành công.</div>", kh.trangthai);
            }
        }
        context.Response.Write(msg);
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
                object_.ngayBDSX = VNN_Config.setDateTime(context.Request.Form["ngayBDSX"]);
                object_.ngayHTcham = VNN_Config.setDateTime(context.Request.Form["ngayHTcham"]);
                var dmh = db.md_dondathangphanxuong.Where(s => s.c_kehoachdathang_dhcpx_id == object_.c_kehoachdathang_dhcpx_id).FirstOrDefault();
                if (dmh != null)
                {
                    if (dmh.md_trangthai_id == Helper.SOANTHAO)
                    {
                        if (ghichu.Trim().Length > 0)
                            object_.mota = DateTime.Now + "\n\n" + ghichu + "\n" + "__________________" + "\n\n" + object_.mota;

                        object_.hdlh = context.Request.Form["hdlh"];
                        object_.hdlhchung = context.Request.Form["hdlhchung"];
                        dmh.hdlh = object_.hdlh;
                        dmh.hdlhchung = object_.hdlhchung;
                        dmh.ngayketthuc = object_.ngayHTcham;
                        dmh.ngayhoanthanh = object_.ngayHTcham;
                        dmh.ngay_hieuluc = object_.ngayBDSX;
                        var lsx = db.md_lenhsanxuat.Where(s => s.md_dondathangphanxuong_id == dmh.md_dondathangphanxuong_id).FirstOrDefault();
                        if(lsx != null)
                        {
                            lsx.ngayketthuc = object_.ngayHTcham;
                            lsx.ngaydkgiaotp = object_.ngayHTcham;
                        }
                    }
                    else
                    {
                        msg = "false#Đơn đặt hàng đã hiệu lực.";
                    }
                }
                else
                {
                    if (ghichu.Trim().Length > 0)
                        object_.mota = DateTime.Now + "\n\n" + ghichu;

                    object_.hdlh = context.Request.Form["hdlh"];
                    object_.hdlhchung = context.Request.Form["hdlhchung"];
                    dmh.ngayketthuc = object_.ngayHTcham;
                    dmh.ngayhoanthanh = object_.ngayHTcham;
                }

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