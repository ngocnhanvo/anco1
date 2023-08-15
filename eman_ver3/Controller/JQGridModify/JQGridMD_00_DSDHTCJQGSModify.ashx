e<%@ WebHandler Language="C#" Class="JQGridMD_00_DSDHTCJQGSModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
using System.Collections.Generic;
using Newtonsoft.Json;
public class JQGridMD_00_DSDHTCJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    public partial class VNN
    {
        public string dauma { get; set; }
        public decimal? tongCBM { get; set; }
        public decimal? cbmDatDuoc { get; set; }
        public int tuan { get; set; }
        public int nam { get; set; }
        public DateTime ngaydukien { get; set; }
        public DateTime ngayketthuc { get; set; }
    }

    List<VNN> vNNs = new List<VNN>();
    Public pub = new Public();

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
            case "CA01UpdateDSX_MD00DSDHTCJQGS":
                this.CA01UpdateDSX_MD00DSDHTCJQGS(context);
                break;
            case "CA01DCHT_MD00DSDHTCJQGS": // Hieu Luc
                this.CA01DCHT_MD00DSDHTCJQGS(context);
                break;
            case "CA_01_CopyDonHang":
                this.CA_01_CopyDonHang(context);
                break;
            case "CA_01_HuyBoDonHangTN":
                this.CA_01_HuyBoDonHangTN(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_HuyBoDonHangTN(HttpContext context)
    {
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        string check_1 = context.Request.Form["check"];
        string[] vnn = id.Split(',');
        try
        {
            foreach (var dsdh in db.c_danhsachdathang.Where(s => vnn.Contains(s.c_danhsachdathang_id)).ToList())
            {
                if (dsdh.trangthai != "DANHAN" & dsdh.trangthai != "SOANTHAO")
                {
                    if (check_1 == "1")
                    {
                        dsdh.trangthai = "HUYBO";
                        msg_success = "<div style='color:blue'> Hủy bỏ đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "2")
                    {
                        dsdh.trangthai = "KETTHUC";
                        msg_success = "<div style='color:blue'> Kết thúc đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "3" & dsdh.anco_check == false)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Khởi động lại đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "3" & dsdh.anco_check == true)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Khởi động lại đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "4" & dsdh.anco_check == false)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Kích hoạt đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "4" & dsdh.anco_check == true)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Kích hoạt đơn hàng thành công.</div>";
                    }
                }
                else
                {
                    msg = "<div style='color:red'>Đơn hàng chưa hiệu lực.</div>";
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
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void CA_01_CopyDonHang(HttpContext context)
    {
        string msg = "";
        string id = context.Request.Form["id"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "DSDH", 1);
        var dsdh = db.c_danhsachdathang.Where(s => s.c_danhsachdathang_id == id).FirstOrDefault();
        if (dsdh == null)
        {
            msg = "<div style='color:red'>Lỗi: Không tìm thấy đơn hàng đã chọn.</div>" + "###" + "";
        }
        else
        {
            string id_new = Helper.getNewId();
            var dsdh_new = dsdh.Clone();
            dsdh_new.c_danhsachdathang_id = id_new;
            dsdh_new.sochungtu = sochungtu;
            dsdh_new.so_po = sochungtu;
            dsdh_new.trangthai = "SOANTHAO";
            dsdh_new.md_trangthai_id = "HIEULUC";
            db.c_danhsachdathang.Add(dsdh_new);

            foreach (var dongdsdh in db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).ToList())
            {
                var dongdsdh_new = dongdsdh.Clone();
                dongdsdh_new.c_dongdsdh_id = Helper.getNewId();
                dongdsdh_new.c_danhsachdathang_id = id_new;
                dongdsdh_new.sl_giamhanngach = 0;
                dongdsdh_new.sl_conlai = dongdsdh_new.sl_dathang - dongdsdh_new.sl_giamhanngach;
                db.c_dongdsdh.Add(dongdsdh_new);
            }

            foreach (var pdh in db.c_phidathang.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).ToList())
            {
                var pdh_new = pdh.Clone();
                pdh_new.c_phidathang_id = Helper.getNewId();
                pdh_new.c_danhsachdathang_id = id_new;
                db.c_phidathang.Add(pdh_new);
            }
            db.SaveChanges();
            msg = "<div style='color:blue'>Tạo mới đơn hàng \"" + sochungtu + "\" thành công.</div>" + "###" + id_new;
        }
        context.Response.Write(msg);
    }

    public void CA01DCHT_MD00DSDHTCJQGS(HttpContext context)
    {
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        var dsdhIds = new List<string>();
        var dchtIds = new List<string>();

        try
        {
            foreach (var dsdh in db.c_danhsachdathang.
                    Where(s => vnn.Contains(s.c_danhsachdathang_id)).
                    OrderByDescending(s => s.ngaylap).ToList())
            {
                if (dsdh.trangthai == Helper.HIEULUC)
                {
                    msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã hiệu lực.</div>";
                }
                else if (dsdh.trangthai == "DAGUI")
                {
                    msg += string.Format(@"<div style='color:red'>Lỗi:Đơn hàng ""{0}"" chưa nhận hàng.</div>", dsdh.sochungtu);
                }
                else if (dsdh.trangthai == "HUYBO")
                {
                    msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã hủy.</div>";
                }
                else if (dsdh.trangthai == "KETTHUC")
                {
                    msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã kết thúc.</div>";
                }
                else
                {
                    VNN_Function.SetFormValue("id", dsdh.c_danhsachdathang_id);
                    string msgTNL = "";
                    if (msgTNL.ToLower().Contains("Hủy bắt lỗi khi năng lực không đủ."))
                    {
                        msg += "<div style='color:red'>Lỗi:không đủ năng lực để nhận Đơn hàng " + dsdh.sochungtu + " .</div>";
                        msg += msgTNL;
                    }
                    else
                    {
                        var hieulucthanhcong = false;
                        var dchtExist = db.c_doichieuhangton.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).Take(1).FirstOrDefault();
                        if (dchtExist != null)
                        {
                            dchtIds.Add(dchtExist.c_doichieuhangton_id);
                            hieulucthanhcong = true;
                        }
                        else
                        {
                            string id_dc = Helper.getNewId();
                            dchtIds.Add(id_dc);
                            var dc = new c_doichieuhangton
                            {
                                c_doichieuhangton_id = id_dc,
                                c_danhsachdathang_id = dsdh.c_danhsachdathang_id,
                                so_donhang = dsdh.sochungtu,
                                ten_donhang = "KHDH-" + dsdh.sochungtu,
                                donhang_thamchieu = dsdh.so_po,
                                kehoach = " ",
                                doichieuht = true,
                                phieuhangton = " ",
                                ngaykehoach = DateTime.Now,
                                ngayhoanthanh = dsdh.ngayhoanthanh,
                                hoatdong = true
                            };
                            dc = Helper.setDefaultValueWhenInsertOrUpdate(dc, userTK, false);
                            db.c_doichieuhangton.Add(dc);

                            //tao cac dong don hang
                            foreach (var ddsdh in db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).ToList())
                            {
                                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == ddsdh.md_sanpham_id).FirstOrDefault();
                                if (sp == null)
                                {
                                    msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " chưa có dữ liệu của hàng hóa.</div>";
                                }

                                var cddh = new c_doichieuhangton_cddh
                                {
                                    c_doichieuhangton_cddh_id = Helper.getNewId(),
                                    c_doichieuhangton_id = id_dc,
                                    md_sanpham_id = ddsdh.md_sanpham_id,
                                    md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
                                    mota_tiengviet = sp.mota_tiengviet,
                                    mota_tienganh = sp.mota_tienganh,
                                    sl_dathang = ddsdh.sl_dathang,
                                    sl_giamhanngach = ddsdh.sl_giamhanngach,
                                    mota = dsdh.mota,
                                    hoatdong = true
                                };
                                cddh = Helper.setDefaultValueWhenInsertOrUpdate(cddh, userTK, false);
                                db.c_doichieuhangton_cddh.Add(cddh);

                                var dkdh = new c_doichieuhangton_dkdh
                                {
                                    c_doichieuhangton_dkdh_id = Helper.getNewId(),
                                    c_doichieuhangton_id = id_dc,
                                    md_sanpham_id = ddsdh.md_sanpham_id,
                                    md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
                                    sl_dathang = ddsdh.sl_dathang,
                                    sl_giamhanngach = ddsdh.sl_giamhanngach,
                                    sl_conlai = 0,
                                    sl_dat = ddsdh.sl_dathang - ddsdh.sl_giamhanngach.GetValueOrDefault(0),
                                    sl_dathang_cp = ddsdh.sl_dathang,
                                    mota = dsdh.mota,
                                    macuoi = sp.ma_sanpham,
                                    macuoi_id = sp.md_sanpham_id,
                                    issanpham = true,
                                    hoatdong = true
                                };
                                dkdh = Helper.setDefaultValueWhenInsertOrUpdate(dkdh, userTK, false);
                                db.c_doichieuhangton_dkdh.Add(dkdh);
                            }
                            db.SaveChanges();
                            if (dsdh.anco_check == true)
                            {
                                dsdhIds.Add(dsdh.c_danhsachdathang_id);
                            }

                            hieulucthanhcong = true;
                        }

                        if(hieulucthanhcong)
                        {
                            dsdh.trangthai = Helper.HIEULUC;
                            dsdh.md_trangthai_id = "CHUAXULY";
                            dsdh.dg_nangluc = true;
                            msg_success += "<div style='color:blue'>Đơn hàng " + dsdh.sochungtu + " được hiệu lực thành công.</div>";
                        }
                    }
                }
            }

            if (msg.Length <= 0)
            {
                db.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }

        if (msg.Length <= 0)
        {
            var pub = new Public();
            pub.LapKeHoachDatHang(db, userTK, dchtIds);

            var khdhs = db.c_kehoachdathang.Where(s => dchtIds.Contains(s.c_doichieuhangton_id)).ToList();

            var khdhIds = khdhs.Select(s => s.c_kehoachdathang_id).ToList();
            var khpxs = db.c_kehoachdathang_dhcpx.Where(s => khdhIds.Contains(s.c_kehoachdathang_id)).ToList();
            var khpxsDSX = (from a in khpxs
                            join b in khdhs on a.c_kehoachdathang_id equals b.c_kehoachdathang_id
                            join c in db.c_danhsachdathang on b.sodonhang equals c.sochungtu
                            orderby a.md_phanxuong_id, c.hangiaohang_po ascending
                            select new { khdhpx = a, c.sanxuatton }).ToList();

            var msgDT = "";
            foreach(var item in khpxsDSX)
            {
                var khpx = item.khdhpx;
                pub.CA_01_TDDHPX(db, userTK, "MD_01_DHCPXJQGS", khpx.c_kehoachdathang_dhcpx_id, "false");
            }

            if (msgDT.Contains("error"))
            {
                msg = msgDT;
                foreach (var dsdh in db.c_danhsachdathang.
                    Where(s => vnn.Contains(s.c_danhsachdathang_id)).ToList())
                {
                    dsdh.trangthai = Helper.SOANTHAO;
                }

                foreach(var kh in khdhs)
                {
                    kh.hoatdong = false;
                }
                db.SaveChanges();
            }
            else
            {
                foreach(var kh in khdhs)
                {
                    kh.hoatdong = true;
                }
                msg = msg_success;
                db.SaveChanges();

                foreach (var item in khpxsDSX)
                {
                    var khpx = item.khdhpx;
                    var sxt = item.sanxuatton.GetValueOrDefault(false);

                    var dhpx = db.md_dondathangphanxuong.Where(s => s.sochungtu == khpx.dongdathang).FirstOrDefault();
                    if (dhpx != null)
                    {
                        var lsx = db.md_lenhsanxuat.Where(s => s.md_dondathangphanxuong_id == dhpx.md_dondathangphanxuong_id).FirstOrDefault();

                        var tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id & s.stt == 9999 & (string.IsNullOrEmpty(s.phieulayhttp) | s.phieulayhttp == "")).FirstOrDefault();

                        if (tsx != null)
                        {
                            if (sxt)
                            {
                                tsx.hoatdong = false;
                                tsx.tinhhangtontp = true;
                                tsx.tinhhangton = true;
                                tsx.phieulayhttp = null;
                            }
                            else
                            {
                                pub.tinhHangTonKhoTheoLSX(db, userTK, tsx.md_lenhsanxuat_tosx_id);
                            }
                        }

                        if (sxt)
                        {
                            var tsxTho = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id & s.stt == 9998 & (string.IsNullOrEmpty(s.phieulayhttp) | s.phieulayhttp == "")).FirstOrDefault();
                            if (tsxTho != null)
                            {
                                tsxTho.tinhhangton = true;
                                tsxTho.phieulayht = null;
                                foreach(var cdh in db.md_lenhsanxuat_tosx_cdh.Where(s=>s.md_lenhsanxuat_tosx_id == tsxTho.md_lenhsanxuat_tosx_id).ToList())
                                {
                                    cdh.sl_datncc = 0;
                                }
                            }
                            lsx.sxton = true;
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        context.Response.Write(msg);
    }

    public void CA01UpdateDSX_MD00DSDHTCJQGS(HttpContext context)
    {
        string msg = "";
        string[] vnn = context.Request.Form["id"].Split(',');
        string thoigiansx = context.Request.Form["thoigiansx"];
        string thoigianht = context.Request.Form["thoigianht"];
        foreach (var dsdh in db.c_danhsachdathang.Where(s => vnn.Contains(s.c_danhsachdathang_id)).ToList())
        {
            if (dsdh.trangthai == "HIEULUC")
            {
                msg += "<div style='color:red'>Lỗi: Dòng " + dsdh.sochungtu + " đã hiệu lực.</div>";
            }
            else if (dsdh.trangthai == "HUYBO")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã hủy.</div>";
            }
            else if (dsdh.trangthai == "KETTHUC")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã kết thúc.</div>";
            }
            else if (dsdh.trangthai != "DANHAN")
            {
                msg += "<div style='color:red'>Lỗi: Dòng " + dsdh.sochungtu + " chưa được xác nhận.</div>";
            }
            else
            {
                dsdh.thoigiansx = int.Parse(thoigiansx);
                dsdh.ngaybatdau = dsdh.hangiaohang_po - TimeSpan.Parse(thoigiansx) - TimeSpan.Parse(thoigianht);
                dsdh.ngayhoanthanh = dsdh.hangiaohang_po - TimeSpan.Parse(thoigianht);
                db.SaveChanges();
                msg += "<div style='color:blue'>Dòng " + dsdh.sochungtu + " đã cập nhật thời gian sản xuất thành công.</div>";
            }
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["khachhang"];
        string so_po = context.Request.Form["so_po"].Trim();

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string sochungtu = VNN_VariablePublic.sochungtu(db, "DSDH", 1);
                //int thoigiansx = int.Parse(context.Request.Form["thoigiansx"]);
                //int thoigianht = int.Parse(context.Request.Form["thoigianht"]);
                DateTime ngaylap = VNN_Config.setDateTime(context.Request.Form["ngaylap"]);
                DateTime hangiaohang_po = VNN_Config.setDateTime(context.Request.Form["hangiaohang_po"]);
                string dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
                string id = context.Request.QueryString["id"];
                //DateTime ngaybatdau = hangiaohang_po.AddDays(0 - thoigiansx);
                DateTime ngayhoanthanh = hangiaohang_po.AddDays(-10);
                if (ngaylap == null)
                {
                    msg = "Lỗi:Chưa có ngày lập đơn hàng.";
                }
                else if (hangiaohang_po == null)
                {
                    msg = "Lỗi:Chưa có hạng giao hàng.";
                }
                else if (string.IsNullOrEmpty(so_po.Trim()))
                {
                    msg = string.Format(@"Lỗi:Số đơn hàng không thể để trống.");
                }
                else
                {
                    var countPO = db.c_danhsachdathang.Where(s => s.so_po == so_po).Count();
                    if (countPO > 0)
                        msg = string.Format(@"Lỗi:Số đơn hàng đã tồn tại.");
                }
                if (msg.Length <= 0)
                {
                    var object_ = new c_danhsachdathang();
                    object_.c_danhsachdathang_id = id_new;
                    object_.md_trangthai_id = Helper.HIEULUC;
                    //object_.ngaybatdau = ngaybatdau;
                    object_.ngayhoanthanh = ngayhoanthanh;
                    object_.anco_check = false;
                    object_.md_doitackinhdoanh_id = dtk_id;
                    VNN_Function.SetFormValue(object_.nameof(s=>s.ngayhoanthanh), ngayhoanthanh.ToString(VNN_Config.get_FormatDate()));
                    VNN_Function.SetFormValue(object_.nameof(s=>s.sochungtu), sochungtu);
                    //VNN_Function.SetFormValue(object_.nameof(s=>s.thoigiansx), thoigiansx.ToString());
                    object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, false);
                    object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    db.c_danhsachdathang.Add(object_);
                    db.SaveChanges();
                }
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

    public void edit(HttpContext context)
    {
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["khachhang"];
        string so_po = context.Request.Form["so_po"].Trim();
        string trangthai = context.Request.Form["trangthai"];

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                //int thoigiansx = int.Parse(context.Request.Form["thoigiansx"]);
                string id = context.Request.Form["id"];
                var object_ = db.c_danhsachdathang.Where(p => p.c_danhsachdathang_id == id).FirstOrDefault();
                int count = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).Count();
                string dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa.";
                }
                else if (object_.trangthai == "HUYBO")
                {
                    msg += "Lỗi:Đơn hàng " + object_.sochungtu + " đã hủy.";
                }
                else if (string.IsNullOrEmpty(so_po))
                {
                    msg = string.Format(@"Lỗi:Số đơn hàng không thể để trống.");
                }
                else
                {
                    var countPO = db.c_danhsachdathang.Where(s => s.so_po == so_po & s.c_danhsachdathang_id != object_.c_danhsachdathang_id).Count();
                    if (countPO > 0)
                        msg = string.Format(@"Lỗi:Số đơn hàng đã tồn tại.");
                }
                int thoigianht = int.Parse(context.Request.Form["thoigianht"]);
                DateTime ngaylap = VNN_Config.setDateTime(context.Request.Form["ngaylap"]);
                DateTime hangiaohang_po = VNN_Config.setDateTime(context.Request.Form["hangiaohang_po"]);
                //DateTime ngaybatdau = hangiaohang_po.AddDays(0 - thoigiansx);
                DateTime ngayhoanthanh = hangiaohang_po.AddDays(-10);

                if (msg.Length <= 0)
                {
                    if (object_.trangthai == Helper.HIEULUC)
                    {
                        object_.khachhang = md_dtk_id;
                        object_.md_doitackinhdoanh_id = dtk_id;
                        //object_.thoigiansx = thoigiansx;
                        object_.diachigiaohang = context.Request.Form["diachigiaohang"];
                        db.SaveChanges();
                    }
                    else
                    {
                        //object_.ngaybatdau = ngaybatdau;
                        object_.ngayhoanthanh = ngayhoanthanh;
                        VNN_Function.SetFormValue(object_.nameof(s => s.trangthai), "VNN_notpost");
                        //VNN_Function.SetFormValue(object_.nameof(s => s.thoigiansx), thoigiansx.ToString());
                        object_.md_doitackinhdoanh_id = dtk_id;
                        VNN_Function.SetFormValue(object_.nameof(s => s.sochungtu), "VNN_notpost");
                        VNN_Function.SetFormValue(object_.nameof(s => s.so_po), so_po);
                        object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                        object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Cập nhật thành công");
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
                    var object_ = db.c_danhsachdathang.Where(p => p.c_danhsachdathang_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else if (new string[] { "HIEULUC", "HUYBO", "KETTHUC" }.Contains(object_.trangthai))
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Không thể xóa khi đang trong trạng thái ""Hiệu Lực"", ""Hủy"" hoặc ""Kết Thúc"".", object_.sochungtu, object_.so_po);
                    }
                    else if (!new string[] { "HIEULUC", "SOANTHAO" }.Contains(object_.md_trangthai_id))
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Không thể xóa khi đang triển khai.", object_.sochungtu, object_.so_po);
                    }
                    else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).Count() > 0)
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Đã tạo phiếu giảm hạn ngạch.", object_.sochungtu, object_.so_po);
                    }
                    //else if (object_.dg_nangluc.GetValueOrDefault(false))
                    //{
                    //    msg += string.Format(@"<br><b>{0} ({1})</b>: Đã từng hiệu lực không thể xóa.", object_.sochungtu, object_.so_po);
                    //}
                    else
                    {
                        VNN_Function.Write_log(context, ma_module, null, oper, "MĐH:" + object_.sochungtu + ", TĐH:" + object_.so_po, db);
                        db.c_danhsachdathang.Remove(object_);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format(@"true#Xóa các đơn hàng đã chọn thành công");
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