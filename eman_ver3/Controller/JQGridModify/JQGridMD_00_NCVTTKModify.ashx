<%@ WebHandler Language="C#" Class="JQGridMD_00_NCVTTKModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_NCVTTKModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_TinhNhuCauVatTu":
                var db = new EntityContext();
                this.CA_01_TinhNhuCauVatTu(context, db, null);
                break;
            case "CA_01_TaoYCMuaVT":
                this.CA_01_TaoYCMuaVT(context);
                break;
            default:
                break;
        }
    }
    public void CA_01_TaoYCMuaVT(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string[] vnn = context.Request.Form["id"].Split(',');
        int i = 1;
        foreach (var ncvt in db.c_nhucauvattu.Where(s => vnn.Contains(s.c_nhucauvattu_id)).ToList())
        {
            if (ncvt.c_yeucaumuavt_id != " ")
            {
                msg += "<div style='color:red'>Lỗi: Dòng \"" + ncvt.ten_nhucau + "\" đã có yêu cầu mua.</div>";
            }
            else if (ncvt.datinh_nhucau == false)
            {
                msg += "<div style='color:red'>Lỗi: Dòng \"" + ncvt.ten_nhucau + "\" chưa tính nhu cầu mua vật tư.</div>";
            }
            else
            {
                var dondhpxs_got = from a in db.c_nhucauvattu_dhpx
                                   join b in db.c_nhucauvattu on a.c_nhucauvattu_id equals b.c_nhucauvattu_id
                                   join c in db.md_dondathangphanxuong on a.md_dondathangphanxuong_id equals c.md_dondathangphanxuong_id
                                   where b.c_yeucaumuavt_id != " " & b.hoatdong == true & c.ngayhoanthanh >= ncvt.tungay & c.ngayhoanthanh <= ncvt.denngay
                                   select new { a.md_dondathangphanxuong_id, c.sochungtu, b.ten_nhucau };

                var dondhpxs_got_arr = dondhpxs_got.Distinct();
                var arr_got = new List<string>();
                foreach (var a in db.c_nhucauvattu_dhpx.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id).ToList())
                {
                    arr_got.Add(a.md_dondathangphanxuong_id);
                }
                int count_err = 0;
                foreach (var px_error in dondhpxs_got_arr.Where(s => arr_got.Contains(s.md_dondathangphanxuong_id)).ToList())
                {
                    msg += "<div style='color:red'>Lỗi: Dòng \"" + px_error.sochungtu + "\" đã có trong nhu cầu \"" + px_error.ten_nhucau + "\".</div>";
                    count_err = 1;
                }

                if (count_err <= 0)
                {
                    string sochungtu = VNN_VariablePublic.sochungtu(db, "YCM", i);
                    i++;
                    ncvt.c_yeucaumuavt_id = sochungtu;
                    var ycmvt = new c_yeucaumuavt()
                    {
                        c_yeucaumuavt_id = Helper.getNewId(),
                        c_nhucauvattu_id = ncvt.c_nhucauvattu_id,
                        c_kehoachmuavt_id = " ",
                        md_trangthai_id = "SOANTHAO",
                        sochungtu = sochungtu,
                        nguoiyeucau = "",
                        ngaycan = ncvt.ngayyeucau,
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

                    foreach (var ncvt_ycmvt in db.c_nhucauvattu_ycmvt.
                            Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id).ToList())
                    {
                        var ycmvt_cdh = new c_yeucaumuavt_cdh()
                        {
                            c_yeucaumuavt_cdh_id = Helper.getNewId(),
                            c_yeucaumuavt_id = ycmvt.c_yeucaumuavt_id,
                            md_sanpham_id = ncvt_ycmvt.md_sanpham_id,
                            md_donvitinhsanpham_id = ncvt_ycmvt.md_donvitinhsanpham_id,
                            soluong_yeucau = ncvt_ycmvt.soluong.Value,
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
                        db.c_yeucaumuavt_cdh.Add(ycmvt_cdh);
                    }
                    db.SaveChanges();
                    msg += "<div style='color:blue'>Đã tạo yêu cầu mua \"" + sochungtu + "\"</div>";
                }
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_TinhNhuCauVatTu(HttpContext context, EntityContext db, System.Data.Entity.DbContextTransaction transaction)
    {
        string msg = "", msg_success = "";
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string[] vnn = context.Request.Form["id"].Split(',');
        bool SingleFunc = false;
        if (transaction == null)
        {
            transaction = db.Database.BeginTransaction();
            SingleFunc = true;
        }

        try
        {
            foreach (var ncvt in db.c_nhucauvattu.Where(s => vnn.Contains(s.c_nhucauvattu_id)).ToList())
            {
                if (ncvt.c_yeucaumuavt_id != " ")
                {
                    msg = "<div style='color:red'>Lỗi: dòng \"" + ncvt.ten_nhucau + "\" đã lập yêu cầu mua vật tư.</div>";
                    break;
                }
                else
                {
                    //Lay ra tat ca don dat hang px da tao yeu cau mua vat tu
                    var dondhpxs_got = from a in db.c_nhucauvattu_dhpx
                                       join b in db.c_kehoachdathang_dhcpx on a.md_dondathangphanxuong_id equals b.c_kehoachdathang_dhcpx_id
                                       where b.tinh_ncvt == true
                                       select new { a.md_dondathangphanxuong_id };

                    var dondhpxs_got_arr = dondhpxs_got.Distinct();
                    var arr_got = new List<string>();
                    foreach (var a in dondhpxs_got_arr)
                    {
                        arr_got.Add(a.md_dondathangphanxuong_id);
                    }

                    //--Xoa du lieu
                    var dondhpxs = from a in db.c_kehoachdathang_dhcpx
                                   join b in db.c_kehoachdathang on a.c_kehoachdathang_id equals b.c_kehoachdathang_id
                                   where b.ngaykehoach >= ncvt.tungay & b.ngaykehoach <= ncvt.denngay
                                   & b.xulykehoach == true
                                   & (
                                       !arr_got.Contains(a.c_kehoachdathang_dhcpx_id)
                                       | db.c_kehoachdathang_dhcpx_vattu.
                                       Where(s =>
                                           s.c_kehoachdathang_dhcpx_id == a.c_kehoachdathang_dhcpx_id
                                           & s.sl_duyetmua != null
                                       ).Sum(s =>
                                           s.soluong
                                           - s.sl_giamhanngach
                                           - s.sl_duyetmua) > 0
                                   )
                                   select new { a.c_kehoachdathang_dhcpx_id };

                    int count_dondhpxs = db.c_nhucauvattu_dhpx.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id).Count();
                    if (count_dondhpxs <= 0)
                        db.c_nhucauvattu_dhpx.RemoveRange(db.c_nhucauvattu_dhpx.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id));

                    db.c_nhucauvattu_ddhpx.RemoveRange(db.c_nhucauvattu_ddhpx.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id));
                    db.c_nhucauvattu_ycmvt.RemoveRange(db.c_nhucauvattu_ycmvt.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id));
                    db.SaveChanges();
                    //--Tổng hợp đơn đặt hàng phân xưởng
                    if (count_dondhpxs <= 0)
                    {
                        foreach (var ddhpx in dondhpxs.ToList())
                        {
                            var khdhpx = db.c_kehoachdathang_dhcpx.Where(s =>
                                s.c_kehoachdathang_dhcpx_id == ddhpx.c_kehoachdathang_dhcpx_id).FirstOrDefault();
                            if (khdhpx != null)
                            {
                                var ncvt_dhpx = new c_nhucauvattu_dhpx()
                                {
                                    c_nhucauvattu_dhpx_id = Helper.getNewId(),
                                    c_nhucauvattu_id = ncvt.c_nhucauvattu_id,
                                    md_dondathangphanxuong_id = ddhpx.c_kehoachdathang_dhcpx_id,
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
                                db.c_nhucauvattu_dhpx.Add(ncvt_dhpx);
                                khdhpx.tinh_ncvt = true;
                                db.SaveChanges();
                            }
                        }
                    }
                    ncvt.datinh_nhucau = true;
                    db.SaveChanges();
                    msg_success += "<div style='color:blue'>Tính nhu cầu vật tư \"" + ncvt.ten_nhucau + "\" thành công</div>";
                }
            }
            if (msg.Length <= 0)
            {
                foreach (var ncvt_dhpx in db.c_nhucauvattu_dhpx.Where(s => vnn.Contains(s.c_nhucauvattu_id)).ToList())
                {
                    //--Tổng hợp dòng đặt hàng phân xưởng
                    foreach (var dhpx_cdh in db.c_kehoachdathang_dhcpx_cdh.
                            Where(s => s.c_kehoachdathang_dhcpx_id == ncvt_dhpx.md_dondathangphanxuong_id).ToList())
                    {
                        var ncvt_ddhpx_chk = db.c_nhucauvattu_ddhpx.
                                Where(s => s.md_sanpham_id == dhpx_cdh.md_sanpham_id &
                                s.c_nhucauvattu_id == ncvt_dhpx.c_nhucauvattu_id).Take(1).FirstOrDefault();
                        c_nhucauvattu_ddhpx ncvt_ddhpx = ncvt_ddhpx_chk;
                        if (ncvt_ddhpx_chk == null)
                        {
                            ncvt_ddhpx = new c_nhucauvattu_ddhpx();
                            ncvt_ddhpx.c_nhucauvattu_ddhpx_id = Helper.getNewId();
                            ncvt_ddhpx.soluong = dhpx_cdh.soluong;
                            ncvt_ddhpx.c_nhucauvattu_id = ncvt_dhpx.c_nhucauvattu_id;
                            ncvt_ddhpx.md_sanpham_id = dhpx_cdh.md_sanpham_id;
                            ncvt_ddhpx.md_donvitinhsanpham_id = dhpx_cdh.md_donvitinhsanpham_id;
                        }
                        else
                        {
                            ncvt_ddhpx.soluong += dhpx_cdh.soluong.Value;
                        }
                        ncvt_ddhpx.nguoitao = us.ad_user_id;
                        ncvt_ddhpx.vaitrotao = us.ad_role_id;
                        ncvt_ddhpx.bophantao = us.md_phongban_id;
                        ncvt_ddhpx.value_nguoitao = us.ma_user;
                        ncvt_ddhpx.value_vaitrotao = us.ten_role;
                        ncvt_ddhpx.value_bophantao = us.ten_phongban;
                        ncvt_ddhpx.nguoicapnhat = us.ad_user_id;
                        ncvt_ddhpx.vaitrocapnhat = us.ad_role_id;
                        ncvt_ddhpx.bophancapnhat = us.md_phongban_id;
                        ncvt_ddhpx.value_nguoicapnhat = us.ma_user;
                        ncvt_ddhpx.value_vaitrocapnhat = us.ten_role;
                        ncvt_ddhpx.value_bophancapnhat = us.ten_phongban;
                        ncvt_ddhpx.ngaytao = DateTime.Now;
                        ncvt_ddhpx.ngaycapnhat = DateTime.Now;
                        ncvt_ddhpx.mota = "";
                        ncvt_ddhpx.hoatdong = true;
                        if (ncvt_ddhpx_chk == null)
                        {
                            db.c_nhucauvattu_ddhpx.Add(ncvt_ddhpx);
                        }
                        db.SaveChanges();
                    }
                    //--Tổng hợp tổng vật tư đặt hàng phân xưởng
                    foreach (var dhpx_vt in db.c_kehoachdathang_dhcpx_vattu.
                            Where(s => s.c_kehoachdathang_dhcpx_id == ncvt_dhpx.md_dondathangphanxuong_id).ToList())
                    {
                        var sltd = dhpx_vt.soluong.GetValueOrDefault(0) - dhpx_vt.sl_giamhanngach.GetValueOrDefault(0) - dhpx_vt.sl_duyetmua.GetValueOrDefault(0);
                        if (sltd > 0)
                        {
                            var ncvt_ycmvt_chk = db.c_nhucauvattu_ycmvt.Where(s => s.md_sanpham_id == dhpx_vt.md_sanpham_id & s.c_nhucauvattu_id == ncvt_dhpx.c_nhucauvattu_id).Take(1).FirstOrDefault();
                            c_nhucauvattu_ycmvt ncvt_ycmvt = ncvt_ycmvt_chk;


                            if (ncvt_ycmvt_chk == null)
                            {
                                ncvt_ycmvt = new c_nhucauvattu_ycmvt();
                                ncvt_ycmvt.c_nhucauvattu_ycmvt_id = Helper.getNewId();
                                ncvt_ycmvt.c_nhucauvattu_id = ncvt_dhpx.c_nhucauvattu_id;
                                ncvt_ycmvt.md_sanpham_id = dhpx_vt.md_sanpham_id;
                                ncvt_ycmvt.md_donvitinhsanpham_id = dhpx_vt.md_donvitinhsanpham_id;
                                ncvt_ycmvt.soluong = sltd;
                            }
                            else
                            {
                                ncvt_ycmvt.soluong += sltd;
                            }
                            ncvt_ycmvt.nguoitao = us.ad_user_id;
                            ncvt_ycmvt.vaitrotao = us.ad_role_id;
                            ncvt_ycmvt.bophantao = us.md_phongban_id;
                            ncvt_ycmvt.value_nguoitao = us.ma_user;
                            ncvt_ycmvt.value_vaitrotao = us.ten_role;
                            ncvt_ycmvt.value_bophantao = us.ten_phongban;
                            ncvt_ycmvt.nguoicapnhat = us.ad_user_id;
                            ncvt_ycmvt.vaitrocapnhat = us.ad_role_id;
                            ncvt_ycmvt.bophancapnhat = us.md_phongban_id;
                            ncvt_ycmvt.value_nguoicapnhat = us.ma_user;
                            ncvt_ycmvt.value_vaitrocapnhat = us.ten_role;
                            ncvt_ycmvt.value_bophancapnhat = us.ten_phongban;
                            ncvt_ycmvt.ngaytao = DateTime.Now;
                            ncvt_ycmvt.ngaycapnhat = DateTime.Now;
                            ncvt_ycmvt.mota = "";
                            ncvt_ycmvt.hoatdong = true;
                            if (ncvt_ycmvt_chk == null)
                            {
                                db.c_nhucauvattu_ycmvt.Add(ncvt_ycmvt);
                            }
                            db.SaveChanges();
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            msg = string.Format(@"Lỗi: {0}", ex.Message);
        }

        if (SingleFunc == true)
        {
            if (msg.Length <= 0)
            {
                transaction.Commit();
                msg = msg_success;
            }
            else
                transaction.Rollback();

            transaction.Dispose();
            context.Response.Write(msg);
        }
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                var tungay = VNN_Config.setDateTime(context.Request.Form["tungay"]);
                var denngay = VNN_Config.setDateTime(context.Request.Form["denngay"]);
                var ngayyeucau = VNN_Config.setDateTime(context.Request.Form["ngayyeucau"]);

                if (tungay.IsDate() == false)
                    msg = string.Format(@"Trường ""Từ Ngày"" có giá trị sai");
                else if (denngay.IsDate() == false)
                    msg = string.Format(@"Trường ""Dến Ngày"" có giá trị sai");
                else if (ngayyeucau.IsDate() == false)
                    msg = string.Format(@"Trường ""Ngày yêu cầu"" có giá trị sai");

                if (msg.Length <= 0)
                {
                    var ncvt = new c_nhucauvattu();
                    ncvt.c_nhucauvattu_id = Helper.getNewId();
                    ncvt.ten_nhucau = context.Request.Form["ten_nhucau"];
                    ncvt.tungay = tungay;
                    ncvt.denngay = denngay;
                    ncvt.ngayyeucau = ngayyeucau;
                    ncvt.c_yeucaumuavt_id = " ";
                    ncvt.mota = context.Request.Form["mota"];
                    db.c_nhucauvattu.Add(ncvt);
                    db.SaveChanges();

                    VNN_Function.SetFormValue("id", ncvt.c_nhucauvattu_id);
                    CA_01_TinhNhuCauVatTu(context, db, transaction);

                    if (db.c_nhucauvattu_ycmvt.Where(s => s.c_nhucauvattu_id == ncvt.c_nhucauvattu_id).Count() <= 0)
                    {
                        msg = "Không có vật tư nào cần mua trong thời gian này.";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if(msg.Length <= 0)
            {
                msg = "true#Tạo nhu cầu mua vật tư thành công";
                transaction.Commit();
            }
            else
            {
                msg = "false#" + msg;
                transaction.Rollback();
            }

            transaction.Dispose();
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
            string object_ = db.c_nhucauvattu.Where(p => p.c_nhucauvattu_id == id).Select(s => s.c_nhucauvattu_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_nhucauvattu";
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
            string[] id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < id_del.Length; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                c_nhucauvattu object_ = db.c_nhucauvattu.Where(p => p.c_nhucauvattu_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.c_yeucaumuavt_id != " " & object_.c_yeucaumuavt_id != "")
                {
                    msg_del = "Lỗi: dòng \"" + object_.ten_nhucau + "\" đã tạo yêu cầu mua vật tư.";
                    msg += msg_del + "\n";
                }

                if (msg_del.Length <= 0)
                {
                    db.c_nhucauvattu.Remove(object_);
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
