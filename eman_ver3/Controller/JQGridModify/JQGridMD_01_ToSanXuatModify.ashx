<%@ WebHandler Language="C#" Class="JQGridMD_01_ToSanXuatModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
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
            case "CA_01_LapPhieuLayHangTonLSX":
                this.CA_01_LapPhieuLayHangTonLSX(context);
                break;
            case "CA_01_TinhHangTonKhoLSX":
                this.CA_01_TinhHangTonKhoLSX(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_TinhHangTonKhoLSX(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string id = context.Request.Form["id"];
        var ksp = from a in db.md_kho_sanpham
                  join b in db.md_kho on a.md_kho_id equals b.md_kho_id
                  where b.hangton == true
                  select new { a.md_kho_id, b.md_to_id, a.md_sanpham_id, a.soluong };

        string msg = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).FirstOrDefault();
                var lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id).FirstOrDefault();
                var khdhpxId = db.md_dondathangphanxuong.Where(s => s.md_dondathangphanxuong_id == lsx.md_dondathangphanxuong_id).Select(s => s.c_kehoachdathang_dhcpx_id).FirstOrDefault();
                if (lsx.md_trangthai_id != "CHUAHOANTHANH")
                {
                    msg = @"Chỉ có thể tính hàng tồn khi LSX ở trạng thái ""Đang xử lý""";
                }
                else if (!string.IsNullOrEmpty(tsx.phieulayht))
                {
                    msg = @"Đã lấy hàng tồn, không được tính lại.";
                }
                else
                {
                    db.md_lenhsanxuat_tosx_dklht.RemoveRange(db.md_lenhsanxuat_tosx_dklht.Where(s => s.md_lenhsanxuat_tosx_id == id));
                    db.SaveChanges();
                    foreach (var cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == id).ToList())
                    {
                        var lht = new md_lenhsanxuat_tosx_dklht();
                        lht.md_lenhsanxuat_tosx_dklht_id = Helper.getNewId();
                        lht.md_lenhsanxuat_tosx_id = cdh.md_lenhsanxuat_tosx_id;
                        lht.md_sanpham_id = cdh.md_sanpham_id;
                        lht.macuoi = cdh.macuoi;
                        lht.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id;
                        var kspSLT = ksp.Where(s => s.md_sanpham_id == cdh.md_sanpham_id & s.md_to_id == tsx.md_phanxuong_to_id).ToList();
                        lht.sl_lsx = cdh.sl_dat;
                        lht.sl_tonkho = kspSLT.Sum(s => s.soluong.GetValueOrDefault(0));
                        lht.sl_layton = db.c_kehoachdathang_dhcpx_hanngach.Where(s => s.c_kehoachdathang_dhcpx_id == khdhpxId
                            & s.md_sanpham_id == cdh.md_sanpham_id & s.md_to_id == tsx.md_phanxuong_to_id).Select(s => s.soluong).FirstOrDefault();
                        lht.ngaytao = DateTime.Now;
                        lht.ngaycapnhat = DateTime.Now;
                        lht.nguoitao = us.ad_user_id;
                        lht.nguoicapnhat = us.ad_user_id;
                        lht.value_nguoitao = us.ma_user;
                        lht.value_nguoicapnhat = us.ma_user;
                        db.md_lenhsanxuat_tosx_dklht.Add(lht);
                    }
                    tsx.tinhhangton = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = string.Format("<div style='color:blue'>Tính hàng tồn thành công.</div>");
                transaction.Commit();
            }
            else
            {
                msg = string.Format("<div class='error' style='color:red'>Lỗi:{0}.</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_LapPhieuLayHangTonLSX(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string id = context.Request.Form["id"];
        string msg = "";
        var ids = new List<string>();

        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var tsx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).FirstOrDefault();
                var lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == tsx.md_lenhsanxuat_id).FirstOrDefault();
                var dhpx = db.md_dondathangphanxuong.Where(s => s.md_dondathangphanxuong_id == lsx.md_dondathangphanxuong_id).FirstOrDefault();
                var kho = db.md_kho.Where(s => s.md_to_id == tsx.md_phanxuong_to_id & s.hangton == true).FirstOrDefault();
                string toLayHTId = "", toLayHT = "";
                var tsx2 = db.md_lenhsanxuat_tosx.Where(s =>
                        s.stt > tsx.stt
                        & s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                    ).OrderBy(s => s.stt).Take(1).FirstOrDefault();

                md_kho kho2 = null;
                if(tsx2 != null)
                {
                    kho2 = Helper.layKhoCuaTo(tsx2.md_phanxuong_id, tsx2.md_phanxuong_to_id, db);
                    toLayHTId = tsx2.md_phanxuong_to_id;
                    toLayHT = db.md_phanxuong_to.Where(s => s.md_to_id == toLayHTId).Select(s => s.ten_to).FirstOrDefault();
                }
                else
                {
                    kho2 = Helper.layKhoCuaTo(tsx.md_phanxuong_id, tsx.md_phanxuong_to_id, db);
                    toLayHTId = tsx.md_phanxuong_to_id;
                    toLayHT = db.md_phanxuong_to.Where(s => s.md_to_id == toLayHTId).Select(s => s.ten_to).FirstOrDefault();
                }

                if (lsx.md_trangthai_id != "CHUAHOANTHANH")
                {
                    msg = @"Chỉ có thể tính hàng tồn khi LSX ở trạng thái ""Đang xử lý"".";
                }
                else if (!string.IsNullOrEmpty(tsx.phieulayht))
                {
                    msg = @"LSX đã lấy hàng tồn cho tổ.";
                }
                else
                {
                    var listLHT = new List<md_lenhsanxuat_tosx_dklht>();
                    foreach (var tsx_ in db.md_lenhsanxuat_tosx.Where(s =>
                        s.stt <= tsx.stt
                        & s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                    ).OrderByDescending(s => s.stt).ToList())
                    {
                        foreach (var cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == tsx_.md_lenhsanxuat_tosx_id).ToList())
                        {
                            var lht = db.md_lenhsanxuat_tosx_dklht.Where(s =>
                                s.md_sanpham_id == cdh.md_sanpham_id
                                & s.md_lenhsanxuat_tosx_id == tsx.md_lenhsanxuat_tosx_id
                                & s.sl_layton > 0
                            ).FirstOrDefault();
                            if (lht != null)
                            {
                                var slTonKho = db.md_kho_sanpham.Where(s =>
                                    s.md_kho_id == kho.md_kho_id
                                    & s.md_sanpham_id == cdh.md_sanpham_id
                                    ).Sum(s => s.soluong);

                                if (lht.sl_tonkho == slTonKho)
                                {
                                    cdh.sl_chiato = cdh.sl_chiato.GetValueOrDefault(0) - lht.sl_layton.GetValueOrDefault(0);
                                    if(cdh.sl_chiato < 0)
                                    {
                                        cdh.sl_laytondu = 0 - cdh.sl_chiato;
                                        cdh.sl_chiato = 0;
                                    }
                                    listLHT.Add(lht);
                                }
                                else
                                {
                                    string masp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).Select(s => s.ma_sanpham).FirstOrDefault();
                                    msg = string.Format(@"Hàng hóa ""{0}"" đã thay đổi số lượng tồn kho.<br>", masp);
                                }
                            }
                        }
                    }
                    db.SaveChanges();
                    if (msg.Length <= 0)
                    {
                        if (listLHT.Sum(s => s.sl_layton.GetValueOrDefault(0)) > 0)
                        {
                            string sochungtu = VNN_VariablePublic.sochungtu(db, "PVC", 1);
                            var vcnb = new md_vanchuyennoibo();
                            vcnb.md_vanchuyennoibo_id = Helper.getNewId();
                            vcnb.md_trangthai_id = "DANHAN";
                            vcnb.sochungtu = sochungtu;
                            vcnb.c_doichieuhangton_id = " ";
                            vcnb.tukho = kho.md_kho_id;
                            vcnb.denkho = kho2.md_kho_id;
                            vcnb.loaichuyen = "VANCNBTC";
                            vcnb.chungtuthamchieu = "";
                            vcnb.sctdathang = dhpx.sctdathang;
                            vcnb.donhang_thamchieu = dhpx.donhang_thamchieu;
                            vcnb.ngaydenghi = DateTime.Now;
                            vcnb.ngaychuyen = DateTime.Now;
                            vcnb.nguoitao = us.ad_user_id;
                            vcnb.nguoicapnhat = us.ad_user_id;
                            vcnb.value_nguoitao = us.ma_user;
                            vcnb.value_nguoicapnhat = us.ma_user;
                            vcnb.ngaytao = DateTime.Now;
                            vcnb.ngaycapnhat = DateTime.Now;
                            vcnb.bophantao = us.md_phongban_id;
                            db.md_vanchuyennoibo.Add(vcnb);
                            db.SaveChanges();

                            foreach (var lht in listLHT.Distinct().Where(s => s.sl_layton > 0))
                            {
                                var cdvc = new md_vanchuyennoibo_cdvc();
                                cdvc.md_vanchuyennoibo_cdvc_id = Helper.getNewId();
                                cdvc.md_vanchuyennoibo_id = vcnb.md_vanchuyennoibo_id;
                                cdvc.md_sanpham_id = lht.md_sanpham_id;
                                cdvc.md_donvitinhsanpham_id = lht.md_donvitinhsanpham_id;
                                cdvc.lsxId = lsx.md_lenhsanxuat_id;
                                cdvc.soluong_dachuyen = 0;
                                cdvc.soluong_toida = lht.sl_layton;
                                cdvc.soluong_muonchuyen = lht.sl_layton;
                                cdvc.soluong_dichchuyen = lht.sl_layton;
                                cdvc.ngaytao = DateTime.Now;
                                cdvc.ngaycapnhat = DateTime.Now;
                                cdvc.bophantao = us.md_phongban_id;
                                cdvc.nguoitao = us.ad_user_id;
                                cdvc.nguoicapnhat = us.ad_user_id;
                                cdvc.value_nguoitao = us.ma_user;
                                cdvc.value_nguoicapnhat = us.ma_user;
                                db.md_vanchuyennoibo_cdvc.Add(cdvc);
                            }
                            tsx.phieulayht = sochungtu;
                            tsx.tolaytonId = toLayHTId;
                            tsx.tolayton = toLayHT;
                            db.SaveChanges();
                            ids.Add(vcnb.md_vanchuyennoibo_id);
                        }
                        else
                        {
                            msg = "Tổng số lượng lấy hàng tồn phải lớn hơn 0.";
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
                msg = string.Format("<div style='color:blue'>Tính hàng tồn thành công.</div>");
                transaction.Commit();

                if (ids.Count > 0)
                {
                    string formData = "";
                    formData += string.Format(@"oper=CA_01_XuLyVanChuyen");
                    formData += string.Format(@"&id={0}", string.Join(",", ids));
                    VNN_VariablePublic.GetModule("/Controller/JQGridModify/JQGridMD_00_PVCNoiBoModify.ashx", formData);
                }
            }
            else
            {
                msg = string.Format("<div class='error' style='color:red'>Lỗi:{0}.</div>", msg);
                transaction.Rollback();
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
        try
        {
            string id = context.Request.Form["id"];
            var object_ = db.md_lenhsanxuat_tosx.Where(p => p.md_lenhsanxuat_tosx_id == id).Take(1).FirstOrDefault();
            var ngaybdsx = VNN_Config.setDateTime(context.Request.Form["ngaybatdausx"]);
            var ngaydkht = VNN_Config.setDateTime(context.Request.Form["ngaydkht"]);
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.ngayhoanthanh != null)
            {
                msg = "false#Lỗi: Đã hoàn thành, không thể chỉnh sửa.";
            }
            else if (ngaybdsx.IsDate() == false)
            {
                msg = "false#Lỗi: Ngày bắt đầu sản xuất không đúng định dạng.";
            }
            else if (ngaydkht.IsDate() == false)
            {
                msg = "false#Lỗi: Ngày dự kiến hoàn thành không đúng định dạng.";
            }

            if (!string.IsNullOrEmpty(ngayhoanthanh) & ngayhoanthanh != " ")
            {
                var ngayht = VNN_Config.setDateTime(ngayhoanthanh);
                if (ngayht.IsDate() == false)
                {
                    msg = "false#Lỗi: Ngày hoàn thành không đúng định dạng.";
                }
                else
                {
                    object_.ngayhoanthanh = ngayht;
                    object_.check_hoanthanh = true;
                }
            }
            else
            {
                object_.ngayhoanthanh = null;
            }

            if (msg.Length <= 0)
            {
                object_.ngaybatdausx = ngaybdsx;
                object_.ngaydkht = ngaydkht;
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