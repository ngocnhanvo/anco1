<%@ WebHandler Language="C#" Class="JQGridMD_00_DDHPXModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_DDHPXModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_TPNKPX":
                this.CA_01_TPNKPX(context);
                break;
            case "CA_01_TaoYCMVT_BPKH":
                this.CA_01_TaoYCMVT_BPKH(context);
                break;
            case "load_sanpham":
                this.load_sanpham(context);
                break;
            case "CA_01_TachDDH":
                this.CA_01_TachDDH(context);
                break;
            default:
                break;
        }
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

    public void CA_01_TachDDH(HttpContext context)
    {
        string msg = "";
        EntityContext db = new EntityContext();
        string id = context.Request.Form["id"];
        string[] nht = id.Split(',');
        foreach (md_dondathangphanxuong dsdh in db.md_dondathangphanxuong.Where(s => nht.Contains(s.md_dondathangphanxuong_id)).ToList())
        {
            string sochungtu = VNN_VariablePublic.sochungtu(db, "DDHPX", 1);
            if (dsdh.md_trangthai_id == "HIEULUC")
            {
                msg = "<div style='color:red'>Lỗi:Đơn đặt hàng đã Hiệu Lực.</div>";
            }
            else
            {
                string id_new = Helper.getNewId();
                md_dondathangphanxuong dsdh_new = Clone(dsdh);
                dsdh_new.md_dondathangphanxuong_id = id_new;
                dsdh_new.sochungtu = sochungtu;
                dsdh_new.md_trangthai_id = "SOANTHAO";
                db.md_dondathangphanxuong.Add(dsdh_new);

                foreach (md_dondathangphanxuong_cdh dongdsdh in db.md_dondathangphanxuong_cdh.Where(s => s.md_dondathangphanxuong_id == dsdh.md_dondathangphanxuong_id).ToList())
                {
                    md_dondathangphanxuong_cdh dongdsdh_new = Clone(dongdsdh);
                    dongdsdh_new.md_dondathangphanxuong_cdh_id = Helper.getNewId();
                    dongdsdh_new.md_dondathangphanxuong_id = id_new;
                    dongdsdh_new.tong_sl_dat = dongdsdh.tong_sl_dat / 2;
                    dongdsdh_new.hanngach = dongdsdh.hanngach / 2;
                    //cap nhat đđhpx cũ
                    dongdsdh.tong_sl_dat = dongdsdh.tong_sl_dat / 2;
                    dongdsdh.hanngach = dongdsdh.hanngach / 2;
                    db.md_dondathangphanxuong_cdh.Add(dongdsdh_new);
                }

                foreach (md_dondathangphanxuong_vattu vattu in db.md_dondathangphanxuong_vattu.Where(s => s.md_dondathangphanxuong_id == dsdh.md_dondathangphanxuong_id).ToList())
                {
                    md_dondathangphanxuong_vattu dongdsdh_new = Clone(vattu);
                    dongdsdh_new.md_dondathangphanxuong_vattu_id = Helper.getNewId();
                    dongdsdh_new.md_dondathangphanxuong_id = id_new;
                    dongdsdh_new.soluong = vattu.soluong / 2;
                    dongdsdh_new.sl_hanngach = vattu.sl_hanngach / 2;
                    //cap nhat đđhpx cũ
                    vattu.soluong = vattu.soluong / 2;
                    vattu.sl_hanngach = vattu.sl_hanngach / 2;
                    db.md_dondathangphanxuong_vattu.Add(dongdsdh_new);
                }

                db.SaveChanges();
                msg = "<div style='color:blue'>Tạo mới kế hoạch \"" + sochungtu + "\" thành công.</div>" + "###" + id_new;
            }
            context.Response.Write(msg);
        }
    }
    public void load_sanpham(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string id = context.Request.QueryString["id"];
        string html = "";
        html += "<table style='width:100%'>";
        html += "<th style='border: 1px solid #CC3;'><input type='checkbox' class='chk_tosx_all'/></th><th>Mã sản phẩm</th><th>Mã cuối</th><th>Hạn ngạch</th><th>SL nhập</th>";
        var sp_dmh = from a in db.md_dondathangphanxuong_cdh
                     join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                     where a.md_dondathangphanxuong_id == id
                     select new { b.md_sanpham_id, b.ma_sanpham, a.macuoi, a.hanngach };

        foreach (var sp in sp_dmh.OrderBy(s => s.ma_sanpham))
        {
            html += "<tr>";
            if (sp.hanngach <= 0)
                html += "<td><input class='chk_tosx nhan_disable' disabled type='checkbox' value='" + sp.md_sanpham_id + "' /></td>";
            else
                html += "<td><input class='chk_tosx' type='checkbox' value='" + sp.md_sanpham_id + "' /></td>";

            html += "<td style='text-align:center;color:blue'>" + sp.ma_sanpham + "</td>";
            html += "<td style='text-align:center;color:blue'>" + sp.macuoi + "</td>";
            html += "<td style='text-align:center;color:blue'>" + VNN_VariablePublic.autoRound(sp.hanngach.Value, 4) + "</td>";

            html += "<td align=center><input disabled class='nhan_disable input_soluong input_" + sp.md_sanpham_id + "' style='width:120px;text-align:right;' type='text' value='" + VNN_VariablePublic.autoRound(sp.hanngach.Value, 4) + "'/></td>";
            html += "</tr>";
        }
        html += "</table>";
        context.Response.Write(html);
    }

    public void CA_01_TPNKPX(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn_slchiato = context.Request.Form["value_slchiato"].Split(',');
        string[] vnn_sel = context.Request.Form["id_sel"].Split(',');
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNK", 1);
        //string[] vnn = id.Split(',');
        //  try
        {
            foreach (md_dondathangphanxuong dhpx in db.md_dondathangphanxuong.Where(s => s.md_dondathangphanxuong_id == id).ToList())
            {
                md_nhapkho_px px = db.md_nhapkho_px.Where(s => s.md_dondathangphanxuong_id == dhpx.md_dondathangphanxuong_id & s.donhang_thamchieu == dhpx.sochungtu).FirstOrDefault();
                if (px != null)
                {
                    msg += "<div style='color:red'>" + "Phiếu nhập kho của " + dhpx.sochungtu + " đã tồn tại!!</div>";
                }
                else if (dhpx.md_trangthai_id != "HIEULUC")
                {
                    msg += "<div style='color:red'>lỗi: Dòng \"" + dhpx.sochungtu + "\" chưa hiệu lực.</div>";
                }
                else
                {
                    //tạo phiếu
                    //md_nhapkho_px check_kho = db.md_nhapkho_px.Where(s => s.md_dondathangphanxuong_id == dhpx.md_dondathangphanxuong_id & s.md_phanxuong_id == dhpx.md_phanxuong_id).FirstOrDefault();
                    md_nhapkho_px px1 = new md_nhapkho_px();
                    // px1 = new md_nhapkho_px();
                    px1.md_nhapkho_px_id = Helper.getNewId();

                    px1.trangthai = "SOANTHAO";
                    px1.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id;
                    px1.md_phanxuong_id = dhpx.md_phanxuong_id;
                    px1.sochungtu = dhpx.sochungtu;
                    px1.donhang_thamchieu = dhpx.donhang_thamchieu;
                    px1.phieunhapkho = sochungtu;
                    px1.md_kho_id = " ";
                    dhpx.phieunhapkho = sochungtu;
                    px1.sctdathang = dhpx.sctdathang;

                    px1.nguoitao = us.ad_user_id;
                    px1.vaitrotao = us.ad_role_id;
                    px1.bophantao = us.md_phongban_id;
                    px1.value_nguoitao = us.ma_user;
                    px1.value_vaitrotao = us.ten_role;
                    px1.value_bophantao = us.ten_phongban;
                    px1.nguoicapnhat = us.ad_user_id;
                    px1.vaitrocapnhat = us.ad_role_id;
                    px1.bophancapnhat = us.md_phongban_id;
                    px1.value_nguoicapnhat = us.ma_user;
                    px1.value_vaitrocapnhat = us.ten_role;
                    px1.value_bophancapnhat = us.ten_phongban;
                    px1.hoatdong = true;

                    //Kiem tra
                    px1.ngaytao = DateTime.Now;
                    px1.ngaycapnhat = DateTime.Now;
                    db.md_nhapkho_px.Add(px1);

                    //--
                    for (int i = 0; i < vnn_sel.Count() - 1; i++)
                    {
                        //md_dondathangphanxuong_cdh dhpx_cdh = db.md_dondathangphanxuong_cdh.Where(s => vnn_slchiato.Contains(s.md_sanpham_id) & s.md_dondathangphanxuong_id == dhpx.md_dondathangphanxuong_id).Take(1).FirstOrDefault();
                        md_dondathangphanxuong_cdh cdh = db.md_dondathangphanxuong_cdh.Where(s => s.md_dondathangphanxuong_id == dhpx.md_dondathangphanxuong_id & vnn_sel[i] == s.md_sanpham_id).FirstOrDefault();
                        md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == cdh.md_sanpham_id).FirstOrDefault();

                        decimal sl_chia = 0, sl_gioihan = cdh.hanngach.Value;

                        try { sl_chia = decimal.Parse(vnn_slchiato[i]); } catch { sl_chia = -1; }
                        if (sl_chia > sl_gioihan)
                        {
                            msg = "Lỗi: Sản phẩm \"" + sp.ma_sanpham + "\" chỉ có thể chia tối đa là: \"" + sl_gioihan + "\"";
                            break;
                        }
                        else if (sl_chia == 0)
                        {
                            msg = "Lỗi: Sản phẩm \"" + sp.ma_sanpham + "\" phải chia số lượng lớn hơn 0";
                            break;
                        }
                        else if (sl_chia < 0)
                        {
                            msg = "Lỗi: Sản phẩm \"" + sp.ma_sanpham + "\", số lượng chia không phải là số.";
                            break;
                        }

                        md_nhapkho_px_dh dh = dh = new md_nhapkho_px_dh();
                        dh.md_nhapkho_px_dh_id = Helper.getNewId();
                        dh.check_kho = false;
                        dh.md_nhapkho_px_id = px1.md_nhapkho_px_id;
                        dh.md_sanpham_id = cdh.md_sanpham_id;
                        dh.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id;
                        dh.tong_sl_dat = sl_chia;
                        //dh.khoden = sp.khomacdinh;
                        dh.sl_nhap = 0;
                        dh.sl_danhap = 0;

                        cdh.hanngach = cdh.tong_sl_dat - sl_chia;

                        dh.nguoitao = us.ad_user_id;
                        dh.vaitrotao = us.ad_role_id;
                        dh.bophantao = us.md_phongban_id;
                        dh.value_nguoitao = us.ma_user;
                        dh.value_vaitrotao = us.ten_role;
                        dh.value_bophantao = us.ten_phongban;
                        dh.nguoicapnhat = us.ad_user_id;
                        dh.vaitrocapnhat = us.ad_role_id;
                        dh.bophancapnhat = us.md_phongban_id;
                        dh.value_nguoicapnhat = us.ma_user;
                        dh.value_vaitrocapnhat = us.ten_role;
                        dh.value_bophancapnhat = us.ten_phongban;
                        dh.hoatdong = true;
                        //Kiem tra
                        dh.ngaytao = DateTime.Now;
                        dh.ngaycapnhat = DateTime.Now;
                        db.md_nhapkho_px_dh.Add(dh);

                    }
                }
                msg_success += "<div style='color:blue'>" + "Dòng " + dhpx.sochungtu + " đã tạo phiếu nhập kho \"" + sochungtu + "\" thành công.</div>";
            }

            if (msg.Length <= 0)
            {
                msg = msg_success;
                db.SaveChanges();
            }
        }
        //  catch (Exception ex)
        {
            // msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void CA_01_TaoYCMVT_BPKH(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string sochungtu = VNN_VariablePublic.sochungtu(db, "YCM", 1);
        string msg = "";
        string[] vnn = context.Request.Form["id"].Split(',');
        c_yeucaumuavt ycmvt = new c_yeucaumuavt()
        {
            c_yeucaumuavt_id = Helper.getNewId(),
            c_nhucauvattu_id = " ",
            c_kehoachmuavt_id = " ",
            md_trangthai_id = "SOANTHAO",
            sochungtu = sochungtu,
            nguoiyeucau = "",
            ngaycan = DateTime.Now,
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
        db.c_yeucaumuavt.Add(ycmvt);

        foreach (md_dondathangphanxuong dhpx in db.md_dondathangphanxuong.Where(s => vnn.Contains(s.md_dondathangphanxuong_id)).ToList())
        {
            if (dhpx.md_trangthai_id != "HIEULUC")
                msg += "<div style='color:red'>" + "Dòng \"" + dhpx.sochungtu + "\" chưa hiệu lực.</div>";
            else
            {
                dhpx.yeucaumuavattu = sochungtu;
                foreach (md_dondathangphanxuong_vattu dhpx_vt in db.md_dondathangphanxuong_vattu.Where(s => s.md_dondathangphanxuong_id == dhpx.md_dondathangphanxuong_id).ToList())
                {
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == dhpx_vt.md_sanpham_id).FirstOrDefault();
                    c_yeucaumuavt_cdh ycmvt_cdh = new c_yeucaumuavt_cdh()
                    {
                        c_yeucaumuavt_cdh_id = Helper.getNewId(),
                        c_yeucaumuavt_id = ycmvt.c_yeucaumuavt_id,
                        md_sanpham_id = dhpx_vt.md_sanpham_id,
                        soluong_yeucau = (decimal)dhpx_vt.soluong.Value,
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

                    if (sp.khuon != true)
                    {
                        db.c_yeucaumuavt_cdh.Add(ycmvt_cdh);
                    }
                }
            }
        }

        if (msg.Length <= 0)
        {
            db.SaveChanges();
            msg = "<div style='color:blue'>" + "Tạo yêu cầu mua vật tư \"" + sochungtu + "\" thành công.</div>";
            string id_notdel = "";
            var c_yeucaumuavt_cdh = db.c_yeucaumuavt_cdh.Where(s => s.c_yeucaumuavt_id == ycmvt.c_yeucaumuavt_id);
            foreach (string md_sanpham_id in c_yeucaumuavt_cdh.Select(s => s.md_sanpham_id).Distinct().ToList())
            {
                c_yeucaumuavt_cdh ycmvt_cdh = c_yeucaumuavt_cdh.Where(s => s.md_sanpham_id == md_sanpham_id).Take(1).FirstOrDefault();
                ycmvt_cdh.soluong_yeucau = c_yeucaumuavt_cdh.Where(s => s.md_sanpham_id == md_sanpham_id).Select(s => s.soluong_yeucau).Sum();
                id_notdel += ycmvt_cdh.c_yeucaumuavt_cdh_id + ",";
            }
            string[] arr_id_notdel = id_notdel.Split(',');
            foreach (c_yeucaumuavt_cdh ycmvt_cdh_del in c_yeucaumuavt_cdh.Where(s => !arr_id_notdel.Contains(s.c_yeucaumuavt_cdh_id)).ToList())
            {
                db.c_yeucaumuavt_cdh.Remove(ycmvt_cdh_del);
            }
            db.SaveChanges();
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
            string id_parent = context.Request.Form["id_parent"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_dondathangphanxuong";
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
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_trangthai_id = context.Request.Form["md_trangthai_id"];
        string ngay_hieuluc = context.Request.Form["ngay_hieuluc"];
        string sctdathang = "", donhang_thamchieu = "";
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string sochungtu = VNN_VariablePublic.sochungtu(db, "LSX", 1);
                string id_parent = context.Request.Form["id_parent"];
                string id = context.Request.Form["id"];
                var object_ = db.md_dondathangphanxuong.Where(p => p.md_dondathangphanxuong_id == id).Take(1).FirstOrDefault();
                var dsdh = db.c_danhsachdathang.FirstOrDefault(s => s.sochungtu == object_.sctdathang);
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if ((object_.md_trangthai_id == "SOANTHAO" | object_.md_trangthai_id == "KETTHUC") & md_trangthai_id == "HUY")
                {
                    msg = string.Format(@"Lỗi: Dòng {0} không thể hủy.", object_.sochungtu);
                }
                else if (object_.md_trangthai_id == "SOANTHAO" & md_trangthai_id == "KETTHUC")
                {
                    msg = string.Format(@"Lỗi: Dòng {0} không thể kết thúc.", object_.sochungtu);
                }
                else if (object_.md_trangthai_id == "HIEULUC" & md_trangthai_id == "SOANTHAO")
                {
                    msg = string.Format(@"Lỗi: Dòng {0} không thể Hiệu lực.", object_.sochungtu);
                }
                else if (object_.md_trangthai_id == "HUY" & md_trangthai_id == "HIEULUC")
                {
                    msg = "Lỗi: Dòng " + object_.sochungtu + " đã Hủy không thể Hiệu lực lại.";
                }
                else if (string.IsNullOrEmpty(ngay_hieuluc))
                {
                    msg = "Lỗi: Hãy chọn ngày bắt đầu sản xuất.";
                }

                if (msg.Length <= 0)
                {
                    sctdathang = object_.sctdathang;
                    donhang_thamchieu = object_.donhang_thamchieu;
                    string old_trangthai_id = object_.md_trangthai_id;
                    object_.md_trangthai_id = md_trangthai_id;
                    object_.ngay_hieuluc = VNN_Config.setDateTime(ngay_hieuluc);
                    object_.mota = context.Request.Form["mota"];
                    db.SaveChanges();

                    if (md_trangthai_id == "HIEULUC" & old_trangthai_id == "SOANTHAO")
                    {
                        var lsxId = Helper.getNewId();
                        var px_to_ = db.md_phanxuong_to.
                                Where(s => s.md_phanxuong_id == object_.md_phanxuong_id).OrderBy(s=>s.sapxep).ToList();
                        var tdt = "";
                        var countPXT = px_to_.Count;
                        foreach (var ddh in db.md_dondathangphanxuong.
                                Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).ToList())
                        {
                            var lsx = new md_lenhsanxuat();
                            lsx.md_lenhsanxuat_id = lsxId;
                            lsx.md_dondathangphanxuong_id = ddh.md_dondathangphanxuong_id;
                            lsx.md_phanxuong_id = ddh.md_phanxuong_id;
                            lsx.md_trangthai_id = "CHUAHOANTHANH";
                            lsx.sochungtu = sochungtu;
                            lsx.ngaylap = DateTime.Now;
                            lsx.ngayketthuc = ddh.ngayketthuc;
                            lsx.phieuXK = " ";

                            lsx.nguoitao = us.ad_user_id;
                            lsx.vaitrotao = us.ad_role_id;
                            lsx.bophantao = us.md_phongban_id;
                            lsx.value_nguoitao = us.ma_user;
                            lsx.value_vaitrotao = us.ten_role;
                            lsx.value_bophantao = us.ten_phongban;
                            lsx.nguoicapnhat = us.ad_user_id;
                            lsx.vaitrocapnhat = us.ad_role_id;
                            lsx.bophancapnhat = us.md_phongban_id;
                            lsx.value_nguoicapnhat = us.ma_user;
                            lsx.value_vaitrocapnhat = us.ten_role;
                            lsx.value_bophancapnhat = us.ten_phongban;
                            lsx.ngaytao = DateTime.Now;
                            lsx.ngaycapnhat = DateTime.Now;
                            lsx.hoatdong = true;
                            if (countPXT == 1)
                                lsx.md_trangthai_id = "CHUAHOANTHANH";
                            db.md_lenhsanxuat.Add(lsx);
                            db.SaveChanges();
                            foreach (var px_to in px_to_.Select((s, index) => new { s.md_phanxuong_id, s.md_to_id, s.sapxep, index }))
                            {
                                var tosx = new md_lenhsanxuat_tosx();
                                tosx.md_lenhsanxuat_tosx_id = Helper.getNewId();
                                tosx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
                                tosx.md_phanxuong_to_id = px_to.md_to_id;
                                tosx.md_phanxuong_id = px_to.md_phanxuong_id;
                                tosx.ngaydkht = lsx.ngayketthuc;
                                tosx.check_hoanthanh = false;
                                tosx.sapxep = px_to.sapxep;
                                tosx.stt = px_to.index + 1 == countPXT ? 9999 : px_to.index;
                                tosx.nguoitao = us.ad_user_id;
                                tosx.vaitrotao = us.ad_role_id;
                                tosx.bophantao = us.md_phongban_id;
                                tosx.value_nguoitao = us.ma_user;
                                tosx.value_vaitrotao = us.ten_role;
                                tosx.value_bophantao = us.ten_phongban;
                                tosx.nguoicapnhat = us.ad_user_id;
                                tosx.vaitrocapnhat = us.ad_role_id;
                                tosx.bophancapnhat = us.md_phongban_id;
                                tosx.value_nguoicapnhat = us.ma_user;
                                tosx.value_vaitrocapnhat = us.ten_role;
                                tosx.value_bophancapnhat = us.ten_phongban;
                                tosx.ngaytao = DateTime.Now;
                                tosx.ngaycapnhat = DateTime.Now;
                                tosx.hoatdong = true;
                                db.md_lenhsanxuat_tosx.Add(tosx);
                                db.SaveChanges();
                                tdt = px_to.index == 0 ? px_to.md_to_id : tdt;
                            }
                        }

                        var lsxTSX = db.md_lenhsanxuat_tosx.
                                Where(s => s.md_lenhsanxuat_id == lsxId);
                        foreach (var px_to in lsxTSX
                                .OrderBy(s => s.sapxep)
                                .ToList())
                        {
                            foreach (var dhpx_cdh in db.md_dondathangphanxuong_cdh.
                                                Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id)
                                                .ToList())
                            {
                                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dhpx_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                                string ma_caiTemp = sp.ma_sanpham.Substring(0, 9) + "{0}" + sp.ma_sanpham.Substring(11);
                                string bo = sp.ma_sanpham.Substring(9, 2);
                                string bo_lon = db.md_sanpham.Where(s => s.ma_sanpham.StartsWith(sp.ma_sanpham.Substring(0, 9) + "S")).Select(s => s.ma_sanpham.Substring(9, 2)).FirstOrDefault();
                                string mdBoId = db.md_bo.Where(s => s.ma_bo == bo & s.ma_bo_cha == bo_lon).Select(s => s.md_bo_id).FirstOrDefault();
                                var bocais = db.md_bo_chitiet.Where(s => s.md_bo_id == mdBoId).OrderByDescending(s => s.md_bo_detail).Select(s=>s.md_bo_detail).ToList();
                                if (bocais.Count <= 0)
                                    bocais.Add(bo);
                                foreach (var bocai in bocais)
                                {
                                    string ma_cai = string.Format(ma_caiTemp, bocai);
                                    string ma_bo = string.Format(ma_caiTemp, bo);
                                    var spCai = db.md_sanpham.
                                            Where(s => s.ma_sanpham == ma_cai).
                                            Select(s => new { s.md_sanpham_id, s.md_donvitinhsanpham_id, s.ma_sanpham }).
                                            FirstOrDefault();
                                    var lsx_tosx_cdh = db.md_lenhsanxuat_tosx_cdh.Where(s =>
                                        s.md_sanpham_id == spCai.md_sanpham_id &
                                        s.md_lenhsanxuat_tosx_id == px_to.md_lenhsanxuat_tosx_id).FirstOrDefault();
                                    var addLSX = lsx_tosx_cdh;
                                    if (lsx_tosx_cdh == null)
                                    {
                                        lsx_tosx_cdh = new md_lenhsanxuat_tosx_cdh();
                                        lsx_tosx_cdh.md_lenhsanxuat_tosx_cdh_id = Helper.getNewId();
                                        lsx_tosx_cdh.md_lenhsanxuat_tosx_id = px_to.md_lenhsanxuat_tosx_id;
                                        lsx_tosx_cdh.md_sanpham_id = spCai.md_sanpham_id;
                                        lsx_tosx_cdh.noigiaohang = dhpx_cdh.noigiaohang;
                                        lsx_tosx_cdh.sl_hoanthanh = 0;
                                        lsx_tosx_cdh.sl_nhapkho = 0;
                                        lsx_tosx_cdh.sl_danhapkho = 0;
                                        lsx_tosx_cdh.macuoi = ma_bo;
                                        lsx_tosx_cdh.md_donvitinhsanpham_id = spCai.md_donvitinhsanpham_id;
                                        lsx_tosx_cdh.nguoitao = us.ad_user_id;
                                        lsx_tosx_cdh.vaitrotao = us.ad_role_id;
                                        lsx_tosx_cdh.bophantao = us.md_phongban_id;
                                        lsx_tosx_cdh.value_nguoitao = us.ma_user;
                                        lsx_tosx_cdh.value_vaitrotao = us.ten_role;
                                        lsx_tosx_cdh.value_bophantao = us.ten_phongban;

                                        lsx_tosx_cdh.nguoicapnhat = us.ad_user_id;
                                        lsx_tosx_cdh.vaitrocapnhat = us.ad_role_id;
                                        lsx_tosx_cdh.bophancapnhat = us.md_phongban_id;
                                        lsx_tosx_cdh.value_nguoicapnhat = us.ma_user;
                                        lsx_tosx_cdh.value_vaitrocapnhat = us.ten_role;
                                        lsx_tosx_cdh.value_bophancapnhat = us.ten_phongban;

                                        lsx_tosx_cdh.ngaytao = DateTime.Now;
                                        lsx_tosx_cdh.ngaycapnhat = DateTime.Now;
                                        lsx_tosx_cdh.mota = "";
                                        lsx_tosx_cdh.hoatdong = true;
                                    }

                                    decimal? sltd = dhpx_cdh.tong_sl_dat - dhpx_cdh.sl_hoanthanh.GetValueOrDefault(0) - dhpx_cdh.sl_giamhanngach.GetValueOrDefault(0);
                                    lsx_tosx_cdh.sl_dat = lsx_tosx_cdh.sl_dat.GetValueOrDefault(0) + sltd;
                                    lsx_tosx_cdh.sl_chiato = lsx_tosx_cdh.sl_chiato.GetValueOrDefault(0) + sltd;
                                    lsx_tosx_cdh.sl_tinhvattu = lsx_tosx_cdh.sl_tinhvattu.GetValueOrDefault(0) + sltd;
                                    lsx_tosx_cdh.sl_dahoanthanh = 0;
                                    if (!lsx_tosx_cdh.macuoi.Contains(ma_bo))
                                        lsx_tosx_cdh.macuoi += "," + ma_bo;
                                    if (addLSX == null)
                                    {
                                        db.md_lenhsanxuat_tosx_cdh.Add(lsx_tosx_cdh);
                                    }
                                    db.SaveChanges();

                                    var bomSP = (from a in db.md_sanpham_bom.
                                            Where(s => s.md_sanpham_id == spCai.md_sanpham_id &
                                            s.md_phanxuong_id == object_.md_phanxuong_id &
                                            s.md_to_id == px_to.md_phanxuong_to_id)
                                                 join b in db.md_sanpham_bom_vattu on a.md_sanpham_bom_id equals b.md_sanpham_bom_id
                                                 orderby a.ngay_hieuluc descending
                                                 select new { b.md_sanpham_id, b.md_donvitinhsanpham_id, b.soluong }).ToList();

                                    if (bomSP.Count > 0)
                                    {
                                        foreach (var vattusp in bomSP)
                                        {
                                            var vtlsxto = db.md_lenhsanxuat_tosx_vattu.Where(s =>
                                               s.md_sanpham_id == vattusp.md_sanpham_id &
                                               s.md_lenhsanxuat_tosx_id == px_to.md_lenhsanxuat_tosx_id).FirstOrDefault();
                                            var addVTLSX = vtlsxto;
                                            if (addVTLSX == null)
                                            {
                                                vtlsxto = new md_lenhsanxuat_tosx_vattu();
                                                vtlsxto.md_lenhsanxuat_tosx_vattu_id = Helper.getNewId();
                                                vtlsxto.md_lenhsanxuat_tosx_id = px_to.md_lenhsanxuat_tosx_id;
                                                vtlsxto.md_sanpham_id = vattusp.md_sanpham_id;
                                                vtlsxto.md_donvitinhsanpham_id = vattusp.md_donvitinhsanpham_id;
                                                vtlsxto.sl_hanngach = 0;
                                                vtlsxto.sl_giamhanngach = 0;
                                            }
                                            vtlsxto.soluong = vtlsxto.soluong.GetValueOrDefault(0) + (decimal)vattusp.soluong.GetValueOrDefault(0) * lsx_tosx_cdh.sl_dat.GetValueOrDefault(0);
                                            if (addVTLSX == null)
                                                db.md_lenhsanxuat_tosx_vattu.Add(vtlsxto);
                                            db.SaveChanges();
                                        }
                                    }
                                    else
                                    {
                                        string err = string.Format(@"<br>HHVT ""{0}"" chưa có BOM cho tổ ""{2} - {1}""",
                                            spCai.ma_sanpham,
                                            db.md_phanxuong.Where(s=>s.md_phanxuong_id == px_to.md_phanxuong_id).Select(s=>s.ten_phanxuong).FirstOrDefault(),
                                            db.md_phanxuong_to.Where(s=>s.md_to_id == px_to.md_phanxuong_to_id).Select(s=>s.ten_to).FirstOrDefault());
                                        if (!msg.Contains(err)) {
                                            msg += err;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (msg.Length <= 0)
                    {
                        if (md_trangthai_id == "HUY" & object_.md_trangthai_id == "HIEULUC")
                        {
                            var lsx_2 = db.md_lenhsanxuat.Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).FirstOrDefault();
                            lsx_2.md_trangthai_id = "KETTHUC";
                        }
                        db.SaveChanges();
                        msg_success = "Cập nhật thành công.";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = "true#" + msg_success;
                transaction.Commit();
            }
            else
            {
                msg = "false#" + msg;
                transaction.Rollback();
            }
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
            string ten_table = "md_dondathangphanxuong";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = "";
                var id_del_ = id_del[i];
                var object_ = db.md_dondathangphanxuong.Where(p => p.md_dondathangphanxuong_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.md_trangthai_id != "SOANTHAO")
                {
                    msg_del = "Lỗi: Dòng \"" + object_.sochungtu + "\" không ở trạng thái soạn thảo, không thể xóa";
                    msg += msg_del + "\n";
                }
                else
                {
                    int countPXTo = db.md_hanngachPXTo
                            .Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).Count();
                    if (countPXTo > 0)
                    {
                        msg_del += string.Format(@"Lỗi: Đơn đặt hàng PX ""{0}"" đã tạo phiếu giảm hạn ngạch", object_.sochungtu);
                        msg += msg_del + "\n";
                    }
                }

                if (msg_del.Length <= 0)
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

                    //
                    foreach (c_kehoachdathang_dhcpx dhcpx_ in db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == object_.c_kehoachdathang_dhcpx_id).ToList())
                    {
                        c_kehoachdathang khdh_ = db.c_kehoachdathang.Where(s => s.c_kehoachdathang_id == dhcpx_.c_kehoachdathang_id).FirstOrDefault();
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
                        /*else
                        {
                            khdh_.mota = "";
                            khdh_.trangthai = "DAHET";
                        }*/
                    }
                    db.SaveChanges();
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