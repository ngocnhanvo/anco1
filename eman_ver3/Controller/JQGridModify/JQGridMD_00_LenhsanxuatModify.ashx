<%@ WebHandler Language="C#" Class="JQGridMD_00_LenhsanxuatModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_LenhsanxuatModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_Taophieuxuatkho":
                this.CA_01_Taophieuxuatkho(context);
                break;
            case "CA_01_TinhTongVattu":
                this.CA_01_TinhTongVattu(context);
                break;
            case "CA_01_TaoPhieuXuatVattuTong":
                this.CA_01_TaoPhieuXuatVattuTong(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_TaoPhieuXuatVattuTong(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "";
        string id = context.Request.Form["id"];
        string[] nht = id.Split(',');
        string tao_xuatkho = "", md_xuatkhonb_id = "";
        int dem = 0;
        string sochungtu = "";
        //  try
        {
            var md_lenhsanxuats_dt = from a in db.md_lenhsanxuat
                                     join b in db.md_lenhsanxuat_tosx on a.md_lenhsanxuat_id equals b.md_lenhsanxuat_id
                                     join c in db.md_lenhsanxuat_vattu on b.md_lenhsanxuat_tosx_id equals c.md_lenhsanxuat_tosx_id
                                     join d in db.md_sanpham on c.md_sanpham_id equals d.md_sanpham_id
                                     join e in db.md_dondathangphanxuong on a.md_dondathangphanxuong_id equals e.md_dondathangphanxuong_id
                                     where nht.Contains(a.md_lenhsanxuat_id)
                                     select new
                                     {
                                         d.khoton,
                                         d.md_sanpham_id,
                                         c.soluong,
                                         c.sl_daxuat,
                                         d.md_donvitinhsanpham_id,
                                         d.mota_tiengviet,
                                         e.donhang_thamchieu,
                                         e.sctdathang,
                                         b.md_lenhsanxuat_tosx_id,
                                         a.md_lenhsanxuat_id,
                                         a.md_phanxuong_id,
                                         a.sochungtu,
                                         a.check_dtvt
                                     };
            int count = 0, countx = 0;
            foreach (var lsx in md_lenhsanxuats_dt)
            {
                int m = db.md_xuatkhonb.ToList().Where(s => s.chungtu_lenhsx.Contains(lsx.sochungtu) & s.trangthai == "SOANTHAO").Count();
                countx += m;
                if (lsx.check_dtvt == false)
                {
                    countx = 1;
                    break;
                }
            }
            if (countx > 0)
            {
                msg = "<div style='color:red'>Phiếu xuất vật tư trước chưa Hiệu Lực, không thể tạo phiếu mới.</div>";
            }
            else if (countx == 1)
            {
                msg = "<div style='color:red'>Tất cả vật tư đã được xuất hết hoặc chưa tính vật tư.</div>";
            }
            else
            {
                foreach (var lsx in md_lenhsanxuats_dt.OrderBy(s => s.khoton))
                {
                    if (tao_xuatkho != lsx.khoton)
                    {
                        md_xuatkhonb_id = Helper.getNewId();
                        sochungtu = VNN_VariablePublic.sochungtu(db, "PXK", 1);
                        count = 0;
                    }

                    if (lsx.soluong - lsx.sl_daxuat > 0)
                    {
                        count++;
                        md_xuatkhonb_cdh check = db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == md_xuatkhonb_id & s.md_sanpham_id == lsx.md_sanpham_id).FirstOrDefault();
                        md_xuatkhonb_cdh xknb_cdh = check;
                        if (check == null)
                        {
                            xknb_cdh = new md_xuatkhonb_cdh();
                            xknb_cdh.md_xuatkhonb_cdh_id = Helper.getNewId();
                            xknb_cdh.tong_sl_xuat = lsx.soluong - lsx.sl_daxuat;
                            xknb_cdh.md_xuatkhonb_id = md_xuatkhonb_id;
                            xknb_cdh.md_sanpham_id = lsx.md_sanpham_id;
                        }
                        else
                        {
                            xknb_cdh.tong_sl_xuat += lsx.soluong - lsx.sl_daxuat;
                        }
                        xknb_cdh.sl_daxuat = 0;
                        xknb_cdh.sl_xuat = 0;
                        xknb_cdh.md_donvitinhsanpham_id = lsx.md_donvitinhsanpham_id;
                        xknb_cdh.tenhang = lsx.mota_tiengviet;

                        xknb_cdh.nguoicapnhat = us.ad_user_id;
                        xknb_cdh.vaitrocapnhat = us.ad_role_id;
                        xknb_cdh.bophancapnhat = us.md_phongban_id;
                        xknb_cdh.value_nguoicapnhat = us.ma_user;
                        xknb_cdh.value_vaitrocapnhat = us.ten_role;
                        xknb_cdh.value_bophancapnhat = us.ten_phongban;
                        xknb_cdh.hoatdong = true;
                        if (check == null)
                        {
                            xknb_cdh.nguoitao = us.ad_user_id;
                            xknb_cdh.vaitrotao = us.ad_role_id;
                            xknb_cdh.bophantao = us.md_phongban_id;
                            xknb_cdh.value_nguoitao = us.ma_user;
                            xknb_cdh.value_vaitrotao = us.ten_role;
                            xknb_cdh.value_bophantao = us.ten_phongban;
                            xknb_cdh.ngaytao = DateTime.Now;
                            db.md_xuatkhonb_cdh.Add(xknb_cdh);
                        }
                        xknb_cdh.ngaycapnhat = DateTime.Now;
                        db.SaveChanges();
                    }


                    if (lsx.sl_daxuat != lsx.soluong)
                    {
                        dem++;
                        //string sochungtu = VNN_VariablePublic.sochungtu(db, "PXK", 1);
                        md_xuatkhonb xknb = null;
                        md_xuatkhonb check = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == md_xuatkhonb_id).FirstOrDefault();
                        if (check == null)
                        {
                            xknb = new md_xuatkhonb();
                            xknb.md_xuatkhonb_id = md_xuatkhonb_id;
                            xknb.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
                            xknb.md_lenhsanxuat_tosx_id = lsx.md_lenhsanxuat_tosx_id;
                            xknb.sochungtu = sochungtu;
                            xknb.donhang_thamchieu = lsx.donhang_thamchieu;
                            xknb.sctdathang = lsx.sctdathang;
                            xknb.chungtu_lenhsx = lsx.sochungtu;
                        }
                        else
                        {
                            xknb = check;
                            if (!xknb.md_lenhsanxuat_id.Contains(lsx.md_lenhsanxuat_id))
                            {
                                xknb.md_lenhsanxuat_id += "," + lsx.md_lenhsanxuat_id;
                            }
                            if (!xknb.md_lenhsanxuat_tosx_id.Contains(lsx.md_lenhsanxuat_tosx_id))
                            {
                                xknb.md_lenhsanxuat_tosx_id += "," + lsx.md_lenhsanxuat_tosx_id;
                            }
                            if (!xknb.donhang_thamchieu.Contains(lsx.donhang_thamchieu))
                            {
                                xknb.donhang_thamchieu += "," + lsx.donhang_thamchieu;
                            }
                            if (!xknb.sctdathang.Contains(lsx.sctdathang))
                            {
                                xknb.sctdathang += "," + lsx.sctdathang;
                            }
                            if (!xknb.sctdathang.Contains(lsx.sctdathang))
                            {
                                xknb.sctdathang += "," + lsx.sctdathang;
                            }
                            if (!xknb.chungtu_lenhsx.Contains(lsx.sochungtu))
                            {
                                xknb.chungtu_lenhsx += "," + lsx.sochungtu;
                            }
                        }

                        xknb.ngaychuyen = DateTime.Now;
                        xknb.tukho = lsx.khoton;
                        xknb.xuatden = lsx.md_phanxuong_id;
                        xknb.trangthai = "SOANTHAO";
                        xknb.bosung = 0;

                        xknb.nguoitao = us.ad_user_id;
                        xknb.vaitrotao = us.ad_role_id;
                        xknb.bophantao = us.md_phongban_id;
                        xknb.value_nguoitao = us.ma_user;
                        xknb.value_vaitrotao = us.ten_role;
                        xknb.value_bophantao = us.ten_phongban;
                        xknb.nguoicapnhat = us.ad_user_id;
                        xknb.vaitrocapnhat = us.ad_role_id;
                        xknb.bophancapnhat = us.md_phongban_id;
                        xknb.value_nguoicapnhat = us.ma_user;
                        xknb.value_vaitrocapnhat = us.ten_role;
                        xknb.value_bophancapnhat = us.ten_phongban;
                        xknb.hoatdong = true;
                        if (check == null)

                        {
                            xknb.ngaytao = DateTime.Now;
                            db.md_xuatkhonb.Add(xknb);
                            msg += "<div style='color:blue'>Tạo phiếu xuất kho \"" + sochungtu + "\" thành công.</div>";
                        }
                        xknb.ngaycapnhat = DateTime.Now;
                        db.SaveChanges();
                        tao_xuatkho = lsx.khoton;
                    }
                }
            }
            if (dem > 0)
            {
                db.SaveChanges();
            }
            else
            {
                msg = "<div style='color:red'>Tất cả vật tư đã được xuất hết hoặc chưa tính vật tư.</div>";
            }
        }
        // catch (Exception ex)
        {

            // msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void CA_01_TinhTongVattu(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string id = context.Request.Form["id"];
        string[] nht = id.Split(',');
        string msg = "";
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                foreach (var lsx in db.md_lenhsanxuat.Where(s => nht.Contains(s.md_lenhsanxuat_id)).ToList())
                {
                    if (lsx.md_trangthai_id == "KHDXL")
                    {
                        foreach (var tosx in db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id).ToList())
                        {
                            var check_count = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tosx.md_lenhsanxuat_tosx_id).ToList();
                            if (check_count.Count() > 0)
                            {

                                lsx.check_dtvt = true;
                                lsx.md_trangthai_id = "DAXL";
                                db.SaveChanges();
                            }
                            else
                            {
                                msg = "Dòng: \"" + lsx.sochungtu + "\" vẫn chưa chia tổ.";
                                break;
                            }
                        }
                    }
                    else
                    {
                        msg = string.Format(@"Dòng: ""{0}"" chưa được kế hoạch xử lý.", lsx.sochungtu);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = "<div style='color:blue'>Hiệu lực lệnh sản xuất thành công.</div>";
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"<div style='color:red'>Lỗi:{0}</div>", msg);
                transaction.Rollback();
            }
        }

        context.Response.Write(msg);
    }

    //vat tu
    public string add_to_vattu(EntityContext db, md_lenhsanxuat_tosx_cdh cdh, int i, User_TK us)
    {
        string id_new = Helper.getNewId();
        //lay bom san pham vat tu
        var bom = (from a in db.md_sanpham_bom
                   where a.md_sanpham_id == cdh.md_sanpham_id
                   select new { a.md_sanpham_bom_id }).FirstOrDefault();
        if (bom != null)
        {
            foreach (md_sanpham_bom_vattu bom_vattu in db.md_sanpham_bom_vattu.Where(s => s.md_sanpham_bom_id == bom.md_sanpham_bom_id))
            {
                //kiem tra
                md_lenhsanxuat_vattu chk_lsx_vt = db.md_lenhsanxuat_vattu.FirstOrDefault(s => s.md_sanpham_id == bom_vattu.md_sanpham_id & s.md_lenhsanxuat_tosx_id == cdh.md_lenhsanxuat_tosx_id);
                md_sanpham sp = db.md_sanpham.FirstOrDefault(s => s.md_sanpham_id == bom_vattu.md_sanpham_id);
                md_lenhsanxuat_vattu vattu = chk_lsx_vt;
                if (chk_lsx_vt == null)
                {
                    vattu = new md_lenhsanxuat_vattu();
                    vattu.md_lenhsanxuat_vattu_id = Helper.getNewId();
                    vattu.sl_daxuat = 0;
                    vattu.md_lenhsanxuat_id = "";
                    vattu.md_dondathangphanxuong_id = "";

                    vattu.md_sanpham_id = bom_vattu.md_sanpham_id;
                    vattu.md_lenhsanxuat_tosx_id = cdh.md_lenhsanxuat_tosx_id;
                    vattu.md_donvitinhsanpham_id = bom_vattu.md_donvitinhsanpham_id;
                    vattu.mota_tiengviet = sp.mota_tiengviet;
                    vattu.mota_tienganh = sp.mota_tienganh;
                    vattu.nguoitao = us.ad_user_id;
                    vattu.vaitrotao = us.ad_role_id;
                    vattu.bophantao = us.md_phongban_id;
                    vattu.value_nguoitao = us.ma_user;
                    vattu.value_vaitrotao = us.ten_role;
                    vattu.value_bophantao = us.ten_phongban;
                    vattu.bosung = false;
                    vattu.soluong = (decimal)bom_vattu.soluong * cdh.sl_tinhvattu;
                }
                else
                {
                    vattu.soluong += (decimal)bom_vattu.soluong * cdh.sl_tinhvattu;
                }

                vattu.nguoicapnhat = us.ad_user_id;
                vattu.vaitrocapnhat = us.ad_role_id;
                vattu.bophancapnhat = us.md_phongban_id;
                vattu.value_nguoicapnhat = us.ma_user;
                vattu.value_vaitrocapnhat = us.ten_role;
                vattu.value_bophancapnhat = us.ten_phongban;
                vattu.hoatdong = true;

                vattu.ngaytao = DateTime.Now;
                vattu.ngaycapnhat = DateTime.Now;
                if (chk_lsx_vt == null)
                {
                    db.md_lenhsanxuat_vattu.Add(vattu);
                }
                db.SaveChanges();
            }
        }
        return id_new;
    }

    public void CA_01_Taophieuxuatkho(HttpContext context)
    {
        var db = new EntityContext();
        string[] nht = context.Request.Form["id"].Split(',');
        string msg = "";
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                foreach (var lsx in db.md_lenhsanxuat.Where(s => nht.Contains(s.md_lenhsanxuat_id)).ToList())
                {
                    if (lsx.md_trangthai_id == "CHUAHOANTHANH")
                    {
                        var tsxDuc = db.md_lenhsanxuat_tosx.Where(
                            s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.stt == 0
                            ).FirstOrDefault();

                        var tsxHT = db.md_lenhsanxuat_tosx.Where(
                            s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            & s.stt == 9999
                            ).FirstOrDefault();

                        if(tsxHT != null)
                        {
                            if (string.IsNullOrEmpty(tsxHT.phieulayht))
                                msg = "Chưa lấy hàng tồn tổ Hoàn Tất";
                        }

                        if (tsxDuc != null & msg.Length <= 0)
                        {
                            if (string.IsNullOrEmpty(tsxDuc.phieulayht))
                                msg = "Chưa lấy hàng tồn tổ đầu tiên";
                        }

                        if (msg.Length > 0)
                            break;
                        else
                            lsx.md_trangthai_id = "KHDXL";
                    }
                    else
                    {
                        msg = string.Format(@"Lệnh sản xuất ""{0}"" đã được xử lý hàng tồn rồi.", lsx.sochungtu);
                        break;
                    }
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = "<div style='color:blue'>Xử lý lệnh sản xuất thành công.</div>";
                transaction.Commit();
            }
            else
            {
                msg = string.Format(@"<div style='color:red'>{0}</div>", msg);
                transaction.Rollback();
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
                string ten_table = "md_lenhsanxuat";
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
        string md_trangthai_id = context.Request.Form["md_trangthai_id"];
        DateTime? nht = VNN_Config.setDateTime(context.Request.Form["ngayhoanthanh"]);
        DateTime? ndkgtp = VNN_Config.setDateTime(context.Request.Form["ngaydkgiaotp"]);
        try
        {
            string id = context.Request.Form["id"];
            md_lenhsanxuat object_ = db.md_lenhsanxuat.Where(p => p.md_lenhsanxuat_id == id).FirstOrDefault();
            md_dondathangphanxuong ddhpx = db.md_dondathangphanxuong.Where(p => p.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).FirstOrDefault();
            if (object_ == null)
            {
                msg = @"false#Lỗi:Không tìm thấy đối tượng cần sửa.";
            }
            else if (ddhpx.md_trangthai_id != "HUY" & md_trangthai_id == "KETTHUC")
            {
                msg = @"false#Lỗi:Đơn đặt hàng phân xưởng " + ddhpx.sochungtu + " chưa 'Hủy'.";
            }
            else if (ddhpx.md_trangthai_id == "HUY" & md_trangthai_id == "HOANTHANH")
            {
                msg = @"false#Lỗi:Đơn đặt hàng phân xưởng " + ddhpx.sochungtu + " đã 'Hủy'.";
            }
            else if (
                    md_trangthai_id != object_.md_trangthai_id & md_trangthai_id != "KETTHUC")
            {
                msg = @"false#Lỗi:Chỉ có thể thay đổi trạng thái thành ""Kết Thúc""";
            }

            if (nht.Value.IsDate() == false)
                nht = null;
            if (ndkgtp.Value.IsDate() == false)
                nht = null;

            if (msg.Length <= 0)
            {
                object_.md_trangthai_id = md_trangthai_id;
                object_.ngayhoanthanh = nht;
                object_.ngaydkgiaotp = ndkgtp;
                object_.lydogiaosom_tre = context.Request.Form["lydogiaosom_tre"];
                object_.mota = context.Request.Form["mota"];
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
            string[] id_del = context.Request.Form["id"].Split(',');
            int count = id_del.Count();
            for (int i = 0; i < count; i++)
            {
                msg_del = "";
                var id_del_ = id_del[i];
                md_lenhsanxuat object_ = db.md_lenhsanxuat.Where(p => p.md_lenhsanxuat_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + ",";
                }
                else if (object_.md_trangthai_id != "CHUAHOANTHANH")
                {
                    msg_del = "Lỗi:Lệnh sản xuất \"" + object_.sochungtu + "\" đã hiệu lực.";
                    msg += msg_del + ",";
                }
                else if (db.md_lenhsanxuat_tosx.Where(s=>s.md_lenhsanxuat_id == object_.md_lenhsanxuat_id
                    & !string.IsNullOrEmpty(s.phieulayht)).Count() > 0)
                {
                    msg_del = "Lỗi:Lệnh sản xuất này đã được lấy hàng tồn.";
                    msg += msg_del + ",";
                }
                else
                {
                    db.md_lenhsanxuat.Remove(object_);
                    var dhpx = db.md_dondathangphanxuong.Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).Take(1).FirstOrDefault();
                    if (dhpx != null)
                    {
                        dhpx.md_trangthai_id = "SOANTHAO";
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