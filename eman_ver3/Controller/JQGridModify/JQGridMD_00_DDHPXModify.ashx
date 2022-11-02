<%@ WebHandler Language="C#" Class="JQGridMD_00_DDHPXModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_DDHPXModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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

    public void CA_01_TachDDH(HttpContext context)
    {
        string msg = "";
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
                md_dondathangphanxuong dsdh_new = dsdh.Clone();
                dsdh_new.md_dondathangphanxuong_id = id_new;
                dsdh_new.sochungtu = sochungtu;
                dsdh_new.md_trangthai_id = "SOANTHAO";
                db.md_dondathangphanxuong.Add(dsdh_new);

                foreach (md_dondathangphanxuong_cdh dongdsdh in db.md_dondathangphanxuong_cdh.Where(s => s.md_dondathangphanxuong_id == dsdh.md_dondathangphanxuong_id).ToList())
                {
                    md_dondathangphanxuong_cdh dongdsdh_new = dongdsdh.Clone();
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
                    md_dondathangphanxuong_vattu dongdsdh_new = vattu.Clone();
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

                    px1.nguoitao = userTK.ad_user_id;
                    px1.vaitrotao = userTK.ad_role_id;
                    px1.bophantao = userTK.md_phongban_id;
                    px1.value_nguoitao = userTK.ma_user;
                    px1.value_vaitrotao = userTK.ten_role;
                    px1.value_bophantao = userTK.ten_phongban;
                    px1.nguoicapnhat = userTK.ad_user_id;
                    px1.vaitrocapnhat = userTK.ad_role_id;
                    px1.bophancapnhat = userTK.md_phongban_id;
                    px1.value_nguoicapnhat = userTK.ma_user;
                    px1.value_vaitrocapnhat = userTK.ten_role;
                    px1.value_bophancapnhat = userTK.ten_phongban;
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

                        dh.nguoitao = userTK.ad_user_id;
                        dh.vaitrotao = userTK.ad_role_id;
                        dh.bophantao = userTK.md_phongban_id;
                        dh.value_nguoitao = userTK.ma_user;
                        dh.value_vaitrotao = userTK.ten_role;
                        dh.value_bophantao = userTK.ten_phongban;
                        dh.nguoicapnhat = userTK.ad_user_id;
                        dh.vaitrocapnhat = userTK.ad_role_id;
                        dh.bophancapnhat = userTK.md_phongban_id;
                        dh.value_nguoicapnhat = userTK.ma_user;
                        dh.value_vaitrocapnhat = userTK.ten_role;
                        dh.value_bophancapnhat = userTK.ten_phongban;
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
            nguoitao = userTK.ad_user_id,
            vaitrotao = userTK.ad_role_id,
            bophantao = userTK.md_phongban_id,
            value_nguoitao = userTK.ma_user,
            value_vaitrotao = userTK.ten_role,
            value_bophantao = userTK.ten_phongban,
            nguoicapnhat = userTK.ad_user_id,
            vaitrocapnhat = userTK.ad_role_id,
            bophancapnhat = userTK.md_phongban_id,
            value_nguoicapnhat = userTK.ma_user,
            value_vaitrocapnhat = userTK.ten_role,
            value_bophancapnhat = userTK.ten_phongban,
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
                        nguoitao = userTK.ad_user_id,
                        vaitrotao = userTK.ad_role_id,
                        bophantao = userTK.md_phongban_id,
                        value_nguoitao = userTK.ma_user,
                        value_vaitrotao = userTK.ten_role,
                        value_bophantao = userTK.ten_phongban,
                        nguoicapnhat = userTK.ad_user_id,
                        vaitrocapnhat = userTK.ad_role_id,
                        bophancapnhat = userTK.md_phongban_id,
                        value_nguoicapnhat = userTK.ma_user,
                        value_vaitrocapnhat = userTK.ten_role,
                        value_bophancapnhat = userTK.ten_phongban,
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
        string msg = "", msg_success = "", msgEX = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string md_trangthai_id = context.Request.Form["md_trangthai_id"];
        string ngay_hieuluc = context.Request.Form["ngay_hieuluc"];
        bool kiemtragia = (context.Request.Form["kiemtragia"] + "").ToLower() == "true";
        string sctdathang = "", donhang_thamchieu = "";
        //using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                var lsxTsxIds = new Dictionary<string, string>();
                string sochungtu = VNN_VariablePublic.sochungtu(db, "LSX", 1);
                string id_parent = context.Request.Form["id_parent"];
                string id = context.Request.Form["id"];
                var object_ = db.md_dondathangphanxuong.Where(p => p.md_dondathangphanxuong_id == id).Take(1).FirstOrDefault();
                var dsdh = db.c_danhsachdathang.FirstOrDefault(s => s.sochungtu == object_.sctdathang);

                md_phanxuong pxuongXL = null;
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
                else if(object_.md_trangthai_id == "KETTHUC")
                {
                    msg = "Lỗi: Dòng " + object_.sochungtu + " đã kết thúc.";
                }
                else if (string.IsNullOrEmpty(ngay_hieuluc))
                {
                    msg = "Lỗi: Hãy chọn ngày bắt đầu sản xuất.";
                }
                else
                {
                    pxuongXL = db.md_phanxuong.Where(s => s.md_phanxuong_id == object_.md_phanxuong_id).FirstOrDefault();
                    var pxDT = db.md_phanxuong_to.Where(s => s.md_phanxuong_id == pxuongXL.md_phanxuong_id).OrderBy(s=>s.sapxep).FirstOrDefault();
                    if (!pxDT.ma_to.StartsWith(userTK.ma_phongban))
                    {
                        msg = string.Format("Lỗi: Đơn đặt hàng thuộc <b>{0}</b>, bộ phận hiện tại của tài khoản là <b>{1}</b>.", pxDT.ten_to, userTK.ten_phongban);
                    }
                }

                if (msg.Length <= 0)
                {
                    sctdathang = object_.sctdathang;
                    donhang_thamchieu = object_.donhang_thamchieu;
                    string old_trangthai_id = object_.md_trangthai_id;
                    object_.md_trangthai_id = md_trangthai_id;
                    object_.ngay_hieuluc = VNN_Config.setDateTime(ngay_hieuluc);
                    object_.mota = context.Request.Form["mota"];
                    object_.hdlh = context.Request.Form["hdlh"];
                    object_.hdlhchung = context.Request.Form["hdlhchung"];

                    if (msg.Length <= 0)
                    {
                        System.Linq.Expressions.Expression<Func<md_lenhsanxuat, bool>> conditionLSX =
                                s=> s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id;

                        var lsxs = db.md_lenhsanxuat.Where(conditionLSX).ToList();

                        var lsxsLocal = db.md_lenhsanxuat.Local.AsQueryable().Where(conditionLSX).ToList();

                        var lsx_2 = lsxsLocal.FirstOrDefault();

                        if (md_trangthai_id == "HIEULUC")
                        {
                            lsx_2.bophantao = userTK.md_phongban_id;
                            lsx_2.md_trangthai_id = "DAXL";
                        }

                        if (md_trangthai_id == "HUY" & object_.md_trangthai_id == "HIEULUC")
                        {
                            lsx_2.md_trangthai_id = "KETTHUC";
                        }

                        if (msg.Length <= 0)
                        {
                            db.SaveChanges();
                            msg_success = "Cập nhật thành công.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if(string.IsNullOrEmpty(msgEX))
                    msg = ex.Message;
                else
                    msg = msgEX;
            }

            if (msg.Length <= 0)
            {
                msg = "true#" + msg_success;
                //transaction.Commit();
            }
            else
            {
                msg = "false#" + msg;
                //transaction.Rollback();
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
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.md_dondathangphanxuong.Where(p => p.md_dondathangphanxuong_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else if (object_.md_trangthai_id != "SOANTHAO")
                    {
                        msg += string.Format(@"<br><b>{0} ({1})</b>: Chỉ có thể xóa khi ở trạng thái ""Soạn Thảo"".", object_.sochungtu, object_.donhang_thamchieu);
                    }
                    else
                    {
                        int countPXTo = db.md_hanngachPXTo.Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).Count();
                        if (countPXTo > 0)
                        {
                            msg += string.Format(@"<br><b>{0} ({1})</b>: Đã tạo phiếu giảm hạn ngạch.", object_.sochungtu, object_.donhang_thamchieu);
                        }
                        else
                        {
                            var dhcpx = db.c_kehoachdathang_dhcpx.FirstOrDefault(s => s.c_kehoachdathang_dhcpx_id == object_.c_kehoachdathang_dhcpx_id);
                            if (dhcpx != null)
                                dhcpx.dongdathang = " ";

                            VNN_Function.Write_log(context, ma_module, null, oper, "DDHPX:" + object_.sochungtu + ", DHTC:" + object_.donhang_thamchieu, db);
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
                            foreach (var dhcpx_ in db.c_kehoachdathang_dhcpx.Where(s => s.c_kehoachdathang_dhcpx_id == object_.c_kehoachdathang_dhcpx_id).ToList())
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
                            }
                            db.SaveChanges();
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
                msg = string.Format(@"true#Xóa đơn đặt hàng phân xưởng đã chọn thành công");
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