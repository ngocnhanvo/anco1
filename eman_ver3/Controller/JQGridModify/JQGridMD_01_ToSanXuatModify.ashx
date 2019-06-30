<%@ WebHandler Language="C#" Class="JQGridMD_01_ToSanXuatModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_ToSanXuatModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "load_to":
                this.load_to(context);
                break;
            case "CA_01_CapnhatToSX":
                this.CA_01_CapnhatToSX(context);
                break;
            case "CA_01_TinhVatTuCanSX":
                this.CA_01_TinhVatTuCanSX(context);
                break;
            case "CA_01_TaoPhieuXuatkhoNB":
                this.CA_01_TaoPhieuXuatkhoNB(context);
                break;
            case "CA_01_TaoPhieuNKNB":
                this.CA_01_TaoPhieuNKNB(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_TaoPhieuNKNB(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string id = context.Request.Form["id"];
        md_lenhsanxuat_tosx object_ = db.md_lenhsanxuat_tosx.Where(p => p.md_lenhsanxuat_tosx_id == id).Take(1).FirstOrDefault();
        string msg = "";
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNK", 1);
        int count_slnhapkho = 0;

        int countx = 0;
        int m = db.md_nhapkhonb.Where(s => s.md_lenhsanxuat_tosx_id.Contains(object_.md_lenhsanxuat_tosx_id) & s.trangthai == "SOANTHAO").Count();
        countx += m;
        if (object_ == null)
        {
            msg = "<div style='color:red'>Không tìm thấy đối tương, hãy làm mới lưới dữ liệu.</div>";
        }
        else if (countx > 0)
        {
            msg = "<div style='color:red'>Phiếu nhập kho trước chưa Hiệu Lực, không thể tạo phiếu mới.</div>";
        }
        else
        {
            string tao_nhapkho = "", md_nhapkhonb_id = Helper.getNewId();
            md_lenhsanxuat lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == object_.md_lenhsanxuat_id).Take(1).FirstOrDefault();
            md_dondathangphanxuong ddhpx = db.md_dondathangphanxuong.Where(s => s.md_dondathangphanxuong_id == lsx.md_dondathangphanxuong_id).Take(1).FirstOrDefault();
            User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
            var md_lenhsanxuat_tosx_cdhs = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == object_.md_lenhsanxuat_tosx_id);
            foreach (md_lenhsanxuat_tosx_cdh lsx_to_cdh in md_lenhsanxuat_tosx_cdhs)
            {
                md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == lsx_to_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                lsx_to_cdh.sl_dahoanthanh += lsx_to_cdh.sl_nhapkho;
                decimal sl_toida = lsx_to_cdh.sl_dahoanthanh.Value - lsx_to_cdh.sl_chiato.Value;
                if (sl_toida > 0)
                {
                    msg += "<div style='color:red'>Dòng \"" + sp.ma_sanpham + "\" chỉ có thể nhập kho tối đa \"" + VNN_VariablePublic.autoRound(sl_toida, 4) + "\"</div>";
                }
                else if (lsx_to_cdh.sl_dahoanthanh <= 0)
                {
                    count_slnhapkho++;
                }
                else
                {
                    if (tao_nhapkho == "")
                    {
                        md_nhapkhonb nknb = new md_nhapkhonb
                        {
                            md_nhapkhonb_id = md_nhapkhonb_id,
                            md_lenhsanxuat_id = object_.md_lenhsanxuat_id,
                            md_lenhsanxuat_tosx_id = object_.md_lenhsanxuat_tosx_id,
                            sochungtu = sochungtu,
                            ngaychuyen = DateTime.Now,
                            nhaptu = lsx.md_phanxuong_id,
                            denkho = sp.khomacdinh,
                            donhang_thamchieu = ddhpx.donhang_thamchieu,
                            trangthai = "SOANTHAO",
                            sctdathang = ddhpx.sctdathang,
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
                            hoatdong = true,

                            ngaytao = DateTime.Now,
                            ngaycapnhat = DateTime.Now
                        };
                        db.md_nhapkhonb.Add(nknb);
                        tao_nhapkho = "1";
                    }

                    md_nhapkhonb_cdh nknb_cdh = new md_nhapkhonb_cdh
                    {
                        md_nhapkhonb_cdh_id = Helper.getNewId(),
                        md_nhapkhonb_id = md_nhapkhonb_id,
                        md_sanpham_id = lsx_to_cdh.md_sanpham_id,
                        tong_sl_dat = lsx_to_cdh.sl_dat - lsx_to_cdh.sl_danhapkho,
                        sl_danhap = 0,
                        sl_nhap = lsx_to_cdh.sl_dahoanthanh - lsx_to_cdh.sl_danhapkho,
                        md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
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
                        hoatdong = true,

                        ngaytao = DateTime.Now,
                        ngaycapnhat = DateTime.Now
                    };
                    db.md_nhapkhonb_cdh.Add(nknb_cdh);
                }
                lsx_to_cdh.sl_nhapkho = 0;
            }

            if (md_lenhsanxuat_tosx_cdhs.Count() <= count_slnhapkho)
            {
                msg = "<div style='color:red'>Phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.</div>";
            }
        }

        if (msg.Length <= 0)
        {
            db.SaveChanges();
            msg = "<div style='color:blue'>Tạo phiếu nhập kho \"" + sochungtu + "\" thành công.</div>";
        }
        context.Response.Write(msg);
    }

    public void CA_01_TaoPhieuXuatkhoNB(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string id = context.Request.Form["id"];
        md_lenhsanxuat_tosx object_ = db.md_lenhsanxuat_tosx.Where(p => p.md_lenhsanxuat_tosx_id == id).FirstOrDefault();
        string msg = "";
        int check = int.Parse(context.Request.Form["check"]);
        bool check_ = true;
        if (check == 1)
        {
            check_ = false;
        }
        int countx = 0;
        int m = db.md_xuatkhonb.ToList().Where(s => s.md_lenhsanxuat_tosx_id.Contains(object_.md_lenhsanxuat_tosx_id) & s.trangthai == "SOANTHAO").Count();
        countx += m;

        if (object_ == null)
        {
            msg = "<div style='color:red'>Không tìm thấy đối tương, hãy làm mới lưới dữ liệu.</div>";
        }
        else if (db.md_lenhsanxuat_vattu.Where(s => s.md_lenhsanxuat_tosx_id == object_.md_lenhsanxuat_tosx_id & s.bosung == check_).Count() <= 0)
        {
            msg = "<div style='color:red'>Chưa có tổng vật tư cần cho tổ</div>";
        }
        else if (countx > 0)
        {
            msg = "<div style='color:red'>Phiếu xuất vật tư trước chưa Hiệu Lực, không thể tạo phiếu mới.</div>";
        }
        else
        {
            string tao_xuatkho = "123", md_xuatkhonb_id = "";
            md_lenhsanxuat lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == object_.md_lenhsanxuat_id).Take(1).FirstOrDefault();
            md_dondathangphanxuong ddhpx = db.md_dondathangphanxuong.Where(s => s.md_dondathangphanxuong_id == lsx.md_dondathangphanxuong_id).Take(1).FirstOrDefault();
            User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
            int dem = 0;

            var md_lenhsanxuat_vattus = from a in db.md_lenhsanxuat_vattu
                                        join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                                        where a.md_lenhsanxuat_tosx_id == object_.md_lenhsanxuat_tosx_id & a.bosung == check_
                                        orderby b.khoton
                                        select new
                                        {
                                            b.khoton,
                                            a.md_sanpham_id,
                                            a.soluong,
                                            a.sl_daxuat,
                                            b.md_donvitinhsanpham_id,
                                            b.mota_tiengviet
                                        };
            foreach (var lsx_vt in md_lenhsanxuat_vattus)
            {
                int count = 0;
                md_xuatkhonb xknb = null;
                if (tao_xuatkho != lsx_vt.khoton)
                {
                    md_xuatkhonb_id = Helper.getNewId();
                }

                if (lsx_vt.soluong - lsx_vt.sl_daxuat > 0)
                {
                    count++;
                    md_xuatkhonb_cdh xknb_cdh = new md_xuatkhonb_cdh
                    {
                        md_xuatkhonb_cdh_id = Helper.getNewId(),
                        md_xuatkhonb_id = md_xuatkhonb_id,
                        md_sanpham_id = lsx_vt.md_sanpham_id,
                        tong_sl_xuat = lsx_vt.soluong - lsx_vt.sl_daxuat,
                        sl_daxuat = 0,
                        sl_xuat = 0,
                        md_donvitinhsanpham_id = lsx_vt.md_donvitinhsanpham_id,
                        tenhang = lsx_vt.mota_tiengviet,
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
                        hoatdong = true,

                        ngaytao = DateTime.Now,
                        ngaycapnhat = DateTime.Now
                    };
                    db.md_xuatkhonb_cdh.Add(xknb_cdh);
                }

                if (tao_xuatkho != lsx_vt.khoton)
                {
                    if (count > 0)
                    {
                        dem++;
                        string sochungtu = VNN_VariablePublic.sochungtu(db, "PXK", 1);
                        int nht = 0;
                        if (check_ == true)
                        {
                            nht = 1;
                        }
                        xknb = new md_xuatkhonb
                        {
                            md_xuatkhonb_id = md_xuatkhonb_id,
                            md_lenhsanxuat_id = lsx.md_lenhsanxuat_id,
                            md_lenhsanxuat_tosx_id = object_.md_lenhsanxuat_tosx_id,
                            sochungtu = sochungtu,
                            donhang_thamchieu = ddhpx.donhang_thamchieu,
                            ngaychuyen = DateTime.Now,
                            tukho = lsx_vt.khoton,
                            xuatden = lsx.md_phanxuong_id,
                            trangthai = "SOANTHAO",
                            bosung = nht,
                            sctdathang = ddhpx.sctdathang,
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
                            hoatdong = true,

                            ngaytao = DateTime.Now,
                            ngaycapnhat = DateTime.Now
                        };

                        db.md_xuatkhonb.Add(xknb);
                        tao_xuatkho = lsx_vt.khoton;
                        msg += "<div style='color:blue'>Tạo phiếu xuất kho \"" + sochungtu + "\" thành công.</div>";
                    }
                }
            }

            if (dem > 0)
            {
                db.SaveChanges();
            }
            else
            {
                msg = "<div style='color:red'>Tất cả vật tư đã được xuất hết.</div>";
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_TinhVatTuCanSX(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string id = context.Request.Form["id"];
        string msg = "";
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        md_lenhsanxuat_tosx lsx_to = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).Take(1).FirstOrDefault();
        if (lsx_to == null)
        {
            msg = "<div style='color:red'>Lỗi: Không tìm tháy đối tượng.</div>";
        }
        else
        {
            //db.md_lenhsanxuat_vattu.RemoveRange(db.md_lenhsanxuat_vattu.Where(s => s.md_lenhsanxuat_tosx_id == id));
            foreach (md_lenhsanxuat_vattu lsx_vt in db.md_lenhsanxuat_vattu.Where(s => s.md_lenhsanxuat_tosx_id == id))
            {
                lsx_vt.soluong = 0;
            }
            db.SaveChanges();

            foreach (md_lenhsanxuat_tosx_cdh lsx_to_cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == id))
            {
                if (lsx_to_cdh.sl_tinhvattu > 0)
                {
                    add_to_vattu(db, lsx_to_cdh, 1, us);
                }
            }

            if (db.md_lenhsanxuat_vattu.Where(s => s.md_lenhsanxuat_tosx_id == id).Count() <= 0)
            {
                msg = "<div style='color:red'>Đã tạo phiếu xuất kho đủ cho số lượng chia tổ.</div>";
            }
            else
            {
                msg = "<div style='color:blue'>Tính vật tư cho tổ thành công.</div>";
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
                   where a.md_sanpham_id == cdh.md_sanpham_id & a.trangthai == "HIEULUC"
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

    public void load_to(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string id = context.Request.QueryString["id_parent"];
        string html = "";
        md_lenhsanxuat lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == id).Take(1).FirstOrDefault();
        var md_lenhsanxuat_tosx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == id);
        html += "<table>";
        foreach (var px_to in db.md_phanxuong_to.
                Where(s => s.md_phanxuong_id == lsx.md_phanxuong_id).OrderBy(s => s.sapxep))
        {
            md_lenhsanxuat_tosx lsx_to = md_lenhsanxuat_tosx.Where(s => s.md_phanxuong_to_id == px_to.md_to_id).Take(1).FirstOrDefault();
            int count_lsx_to_cdh = 0;
            string checked_ = "";
            if (lsx_to != null)
            {
                checked_ = "checked";
                count_lsx_to_cdh = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == lsx_to.md_lenhsanxuat_tosx_id).Count();
            }

            html += "<tr>";
            if (count_lsx_to_cdh > 0)
                html += "<td><input class='chk_tosx nhan_disable' disabled type='checkbox' " + checked_ + " value='" + px_to.md_to_id + "' /></td>";
            else
                html += "<td><input class='chk_tosx' type='checkbox' " + checked_ + " value='" + px_to.md_to_id + "' /></td>";
            html += "<td>" + px_to.ten_to + "</td>";
            html += "</tr>";
        }
        html += "</table>";
        context.Response.Write(html);
    }

    public void CA_01_CapnhatToSX(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string[] vnn = context.Request.Form["id_sel"].Split(',');
        string id = context.Request.Form["id"];
        string msg = "";
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        md_lenhsanxuat lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == id).Take(1).FirstOrDefault();
        if (lsx.md_trangthai_id == "HOANTHANH")
        {
            msg = "<div style='color:red'>Lệnh sản xuất \"" + lsx.sochungtu + "\" đã hoàn thành, không thể chỉnh sửa.</div>";
        }

        if (msg.Length <= 0)
        {
            var md_lenhsanxuat_tosx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == id);
            db.md_lenhsanxuat_tosx.RemoveRange(md_lenhsanxuat_tosx.Where(s => !vnn.Contains(s.md_phanxuong_to_id)));
            foreach (md_phanxuong_to px_to in db.md_phanxuong_to.Where(s => vnn.Contains(s.md_to_id)))
            {
                md_lenhsanxuat_tosx chk_lsxtosx = md_lenhsanxuat_tosx.Where(s => s.md_phanxuong_to_id == px_to.md_to_id).Take(1).FirstOrDefault();
                if (chk_lsxtosx == null)
                {
                    md_lenhsanxuat_tosx lsx_tosx = new md_lenhsanxuat_tosx()
                    {
                        md_lenhsanxuat_tosx_id = Helper.getNewId(),
                        md_lenhsanxuat_id = lsx.md_lenhsanxuat_id,
                        md_phanxuong_to_id = px_to.md_to_id,
                        md_phanxuong_id = px_to.md_phanxuong_id,
                        ngaydkht = lsx.ngayketthuc,
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

                        ngaytao = DateTime.Now,
                        ngaycapnhat = DateTime.Now,
                        mota = "",
                        hoatdong = true
                    };
                    db.md_lenhsanxuat_tosx.Add(lsx_tosx);
                }
            }
            db.SaveChanges();
            msg = "<div style='color:blue'>Cập nhật tổ cho lệnh sản xuất \"" + lsx.sochungtu + "\" thành công.</div>";
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
                string ten_table = "md_lenhsanxuat_tosx";
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
        string ngayhoanthanh = context.Request.Form["ngayhoanthanh"];
        string mota = context.Request.Form["mota"];
        bool check_hoanthanh = false;
        try
        {
            string id = context.Request.Form["id"];
            md_lenhsanxuat_tosx object_ = db.md_lenhsanxuat_tosx.Where(p => p.md_lenhsanxuat_tosx_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else
            {
                md_lenhsanxuat lsx = db.md_lenhsanxuat.Where(p => p.md_lenhsanxuat_id.Equals(object_.md_lenhsanxuat_id)).Take(1).FirstOrDefault();
                if (lsx.md_trangthai_id == "HOANTHANH")
                {
                    msg = "false#Lỗi: lệnh sản xuất \"" + lsx.sochungtu + "\" đã hoàn thành, không thể chỉnh sửa.";
                }
            }

            if (!string.IsNullOrEmpty(ngayhoanthanh) & ngayhoanthanh != " ")
            {
                check_hoanthanh = true;
                object_.ngayhoanthanh = VNN_Config.setDateTime(context.Request.Form["ngayhoanthanh"]);
            }
            else
            {
                object_.ngayhoanthanh = null;
            }

            if (msg.Length <= 0)
            {
                object_.ngaydkht = VNN_Config.setDateTime(context.Request.Form["ngaydkht"]);
                
                object_.check_hoanthanh = check_hoanthanh;
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
            string ten_table = "md_lenhsanxuat_tosx";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.md_lenhsanxuat_tosx.Where(p => p.md_lenhsanxuat_tosx_id == id_del_).Select(s => s.md_lenhsanxuat_tosx_id).Take(1).FirstOrDefault();
                int ncc = db.md_xuatkhonb.Where(s => s.md_lenhsanxuat_tosx_id == object_).Count();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (ncc > 0)
                {
                    msg_del = "Lỗi:Đã tạo phiếu xuất kho không thể xóa " + i;
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