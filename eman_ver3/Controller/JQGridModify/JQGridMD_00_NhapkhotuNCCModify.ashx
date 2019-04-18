<%@ WebHandler Language="C#" Class="JQGridMD_00_NhapkhotuNCCModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_NhapkhotuNCCModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_XLNKNCC":
                this.CA_01_XLNKNCC(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_XLNKNCC(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        int count_slnhap = 0;
        int dem_count = 0;
        try
        {
            var checkngayhethan = (from a in db.md_nhapkho_ncc_dh.Where(s => s.md_nhapkho_ncc_id == id).ToList()
                                   join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                                   where b.co_ngayhethan == true & a.ngay_hethan == null
                                   select b.ma_sanpham).ToList<string>();

            if (checkngayhethan.Count > 0)
            {
                msg += string.Format(@"
                    <div style='color:red'>
                        Những hàng hóa/vật tư chưa có hạn sử dụng:<br>
                        => {0}.
                    </div>", string.Join(",", checkngayhethan));
            }
            else
            {
                bool commit = true;
                using (var transaction = db.Database.BeginTransaction())
                {
                    //Xu Ly nhap kho
                    foreach (var px in db.md_nhapkho_ncc.Where(s => s.md_nhapkho_ncc_id == id).ToList())
                    {
                        string msgDT = "";
                        if (px.trangthai == "HIEULUC")
                        {
                            msgDT += "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" đã hiệu lực.</div>";
                            commit = false;
                        }
                        else
                        {
                            var check_kho = db.md_nhapkho_ncc_dh.Where(s => s.check_kho == true & s.md_nhapkho_ncc_id == px.md_nhapkho_ncc_id).ToList();
                            var check_ma = db.md_nhapkho_ncc_dh.Where(s => s.md_sanpham_id != null & s.md_nhapkho_ncc_id == px.md_nhapkho_ncc_id).ToList();

                            var md_nhapkho_ncc_dhs = db.md_nhapkho_ncc_dh
                                    .Where(s => s.md_nhapkho_ncc_id == px.md_nhapkho_ncc_id & (s.check_kho == null | s.check_kho == false)).ToList();
                            foreach (var dh in md_nhapkho_ncc_dhs)
                            {
                                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                                if (px.kho == null | px.kho == " ")
                                {
                                    msgDT += "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" chưa có kho đến.</div>";
                                }
                                else if (dh.sl_nhap > 0)
                                {
                                    try
                                    {
                                        count_slnhap++;
                                        decimal soluong_nhap = dh.sl_nhap.Value;
                                        //--cap nhat so luong nhap
                                        edit_nhap(db, dh, us);
                                        db.SaveChanges();
                                        //--cap nhat vao kho
                                        string khospId = add_kho(db, dh, px, us);
                                        db.SaveChanges();
                                        //--cap nhat vao kho hạn sử dụng
                                        add_kho_hsd(db, dh, px, us, khospId);
                                        db.SaveChanges();
                                        //--tao lich su nhap kho
                                        add_kho_ls(db, dh, px, us);
                                        db.SaveChanges();
                                        //--cap nhat gia tri binh quan gia quyen của sản phẩm
                                        add_kho_bqgq(db, dh, us);
                                        db.SaveChanges();

                                        msg_success += "<div style='color:blue'>Dòng \"" + px.sochungtu + " của \"" + sp.ma_sanpham + "\" đã nhập kho thành công, số lượng nhập là: \"" +
                                        VNN_VariablePublic.autoRound(soluong_nhap, 4) + "\"</div>";
                                    }
                                    catch (Exception ex)
                                    {
                                        msgDT += string.Format("<div style='color:red'>Lỗi: {0}</div>", ex.Message);
                                    }
                                }
                            }
                        }

                        if (count_slnhap <= 0)
                        {
                            msgDT += "<div style='color:red'>Dòng \"" + px.sochungtu + " phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.</div>";
                        }
                        //Kiem tra de chuyen thanh Hieu Luc
                        if (msgDT.Length <= 0)
                        {
                            msgDT = msg_success + msgDT;
                            px.trangthai = "HIEULUC";
                            db.SaveChanges();

                            foreach (var dmh_cdmh in db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == px.c_donmuahang_id).ToList())
                            {
                                if (dmh_cdmh.sl_dadat - dmh_cdmh.sl_hanngach > 0)
                                {
                                    dem_count = 1;
                                }
                            }

                            var dmh = db.c_donmuahang.Where(s => s.c_donmuahang_id == px.c_donmuahang_id).FirstOrDefault();
                            if (dem_count == 0)
                            {
                                dmh.md_trangthai_id = "DAXONG";
                            }
                            else if (dem_count == 1)
                            {
                                dmh.md_trangthai_id = "CHUAXONG";
                            }
                            db.SaveChanges();
                        }
                        else
                            commit = false;
                        msg += msgDT;
                    }

                    if (commit == true)
                    {
                        transaction.Commit();
                    }
                    else
                        transaction.Rollback();
                }
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    //--cap nhat so luong nhap
    public string edit_nhap(EntityContext db, md_nhapkho_ncc_dh dh, User_TK us)
    {
        string id_new = dh.md_nhapkho_ncc_id;
        md_nhapkho_ncc nk = db.md_nhapkho_ncc.Where(s => s.md_nhapkho_ncc_id == dh.md_nhapkho_ncc_id).FirstOrDefault();
        c_donmuahang_cdmh dmh_cdmh = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == nk.c_donmuahang_id & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        decimal sl_danhap = dh.sl_danhap.Value + dh.sl_nhap.Value;
        if (dmh_cdmh != null)
            dmh_cdmh.sl_hanngach += (decimal)dh.sl_nhap;

        if (dh.tong_sl_dat == (decimal)dh.sl_danhap + (decimal)dh.sl_nhap)
        {
            dh.check_kho = true;
            sl_danhap = dh.tong_sl_dat.Value;
        }

        dh.sl_danhap = dh.sl_nhap + dh.sl_danhap;
        nk.ngaycapnhat = DateTime.Now;

        foreach (var check_nk in db.md_nhapkho_ncc.
                Where(s => s.md_nhapkho_ncc_id != nk.md_nhapkho_ncc_id & s.c_donmuahang_id == nk.c_donmuahang_id & s.trangthai == "SOANTHAO").ToList())
        {
            foreach (var ck_dh in db.md_nhapkho_ncc_dh.
                    Where(s => s.md_nhapkho_ncc_id == check_nk.md_nhapkho_ncc_id & s.md_sanpham_id == dh.md_sanpham_id).ToList())
            {
                ck_dh.tong_sl_dat = ck_dh.tong_sl_dat - sl_danhap;
            }
        }
        return id_new;
    }

    //--cap nhat vao kho
    public string add_kho(EntityContext db, md_nhapkho_ncc_dh dh, md_nhapkho_ncc px, User_TK us)
    {
        string id_new = Helper.getNewId();
        var check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == px.kho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        var sp = check_khosp;
        if (sp == null)
        {
            sp = new md_kho_sanpham();
            sp.md_kho_sanpham_id = id_new;
            sp.soluong = dh.sl_nhap2;
        }
        else
        {
            id_new = sp.md_kho_sanpham_id;
            sp.soluong = dh.sl_nhap2 + sp.soluong;
        }
        sp.md_kho_id = px.kho;
        sp.md_sanpham_id = dh.md_sanpham_id;

        sp.nguoitao = us.ad_user_id;
        sp.vaitrotao = us.ad_role_id;
        sp.bophantao = us.md_phongban_id;
        sp.value_nguoitao = us.ma_user;
        sp.value_vaitrotao = us.ten_role;
        sp.value_bophantao = us.ten_phongban;
        sp.nguoicapnhat = us.ad_user_id;
        sp.vaitrocapnhat = us.ad_role_id;
        sp.bophancapnhat = us.md_phongban_id;
        sp.value_nguoicapnhat = us.ma_user;
        sp.value_vaitrocapnhat = us.ten_role;
        sp.value_bophancapnhat = us.ten_phongban;
        sp.hoatdong = true;
        if (check_khosp == null)
        {
            sp.ngaytao = DateTime.Now;
            sp.ngaycapnhat = DateTime.Now;
            db.md_kho_sanpham.Add(sp);
        }
        else
        {
            sp.ngaycapnhat = DateTime.Now;
        }
        return id_new;
    }

    public string add_kho_hsd(EntityContext db, md_nhapkho_ncc_dh dh, md_nhapkho_ncc px, User_TK us, string khospId)
    {
        string id_new = Helper.getNewId();
        var check_khospHSD = db.md_kho_sanpham_hansudung.
                Where(s =>
                    s.md_sanpham_id == dh.md_sanpham_id &
                    s.ngay_hethan.Value == dh.ngay_hethan.Value &
                    s.md_kho_sanpham_id == khospId).FirstOrDefault();
        var spHSD = check_khospHSD;
        if (check_khospHSD == null)
        {
            spHSD = new md_kho_sanpham_hansudung();
            spHSD.md_kho_sanpham_hansudung_id = id_new;
            spHSD.soluong = dh.sl_nhap2;
            spHSD.ngay_hethan = dh.ngay_hethan;
        }
        else
        {
            id_new = spHSD.md_kho_sanpham_hansudung_id;
            spHSD.soluong = dh.sl_nhap2 + spHSD.soluong;
        }
        spHSD.md_kho_sanpham_id = khospId;
        spHSD.md_sanpham_id = dh.md_sanpham_id;
        spHSD.nguoitao = us.ad_user_id;
        spHSD.vaitrotao = us.ad_role_id;
        spHSD.bophantao = us.md_phongban_id;
        spHSD.value_nguoitao = us.ma_user;
        spHSD.value_vaitrotao = us.ten_role;
        spHSD.value_bophantao = us.ten_phongban;
        spHSD.nguoicapnhat = us.ad_user_id;
        spHSD.vaitrocapnhat = us.ad_role_id;
        spHSD.bophancapnhat = us.md_phongban_id;
        spHSD.value_nguoicapnhat = us.ma_user;
        spHSD.value_vaitrocapnhat = us.ten_role;
        spHSD.value_bophancapnhat = us.ten_phongban;
        spHSD.hoatdong = true;
        if (check_khospHSD == null)
        {
            spHSD.ngaytao = DateTime.Now;
            spHSD.ngaycapnhat = DateTime.Now;
            db.md_kho_sanpham_hansudung.Add(spHSD);
        }
        else
        {
            spHSD.ngaycapnhat = DateTime.Now;
        }
        return id_new;
    }

    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_nhapkho_ncc_dh dh, md_nhapkho_ncc px, User_TK us)
    {
        string id_new = Helper.getNewId();
        string abc = "";
        if (dh.sl_nhap2 == 0)
        {
            abc = "abc";
        }
        else
        {
            var dvt = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
            var giao = new md_kho_giaodich();
            giao.md_kho_giaodich_id = id_new;
            giao.md_kho_id = px.kho;
            giao.md_sanpham_id = dh.md_sanpham_id;
            giao.soluong_dichchuyen = dh.sl_nhap2;
            giao.ngaychuyen = px.ngaychuyen;
            giao.kieuchuyen = "Nhập kho";
            giao.dongnhapxuat = px.sochungtu;
            giao.md_donvitinhsanpham_id = dvt.md_donvitinhsanpham_id;

            giao.nguoitao = us.ad_user_id;
            giao.vaitrotao = us.ad_role_id;
            giao.bophantao = us.md_phongban_id;
            giao.value_nguoitao = us.ma_user;
            giao.value_vaitrotao = us.ten_role;
            giao.value_bophantao = us.ten_phongban;
            giao.nguoicapnhat = us.ad_user_id;
            giao.vaitrocapnhat = us.ad_role_id;
            giao.bophancapnhat = us.md_phongban_id;
            giao.value_nguoicapnhat = us.ma_user;
            giao.value_vaitrocapnhat = us.ten_role;
            giao.value_bophancapnhat = us.ten_phongban;
            giao.hoatdong = true;
            giao.ngaytao = DateTime.Now;
            giao.ngaycapnhat = DateTime.Now;
            db.md_kho_giaodich.Add(giao);
            // dh.sl_nhap = 0;
        }
        return abc;
    }

    public void add_kho_bqgq(EntityContext db, md_nhapkho_ncc_dh dh, User_TK us)
    {
        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        if (sp != null)
        {
            decimal? tsl_trongkho = db.md_kho_sanpham.Where(s => s.md_sanpham_id == sp.md_sanpham_id).Select(s => s.soluong).Sum();
            decimal ve1 = (tsl_trongkho.GetValueOrDefault(0) - dh.sl_nhap2.GetValueOrDefault(0)) * sp.giabinhquan.GetValueOrDefault(0);
            decimal ve2 = dh.sl_nhap2.GetValueOrDefault(0) * dh.giatriVND.GetValueOrDefault(0);
            sp.giabinhquan = Math.Ceiling(((ve1 + ve2) / tsl_trongkho).GetValueOrDefault(0));
        }
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
                string ten_table = "md_nhapkho_ncc";
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
        try
        {
            string id = context.Request.Form["id"];
            md_nhapkho_ncc object_ = db.md_nhapkho_ncc.Where(p => p.md_nhapkho_ncc_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.trangthai != "SOANTHAO")
            {
                msg = "false#Lỗi:Đã nhập kho";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_nhapkho_ncc";
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
            string ten_table = "md_nhapkho_ncc";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            string c_donmuahang_id = "";
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_nhapkho_ncc object_ = db.md_nhapkho_ncc.Where(p => p.md_nhapkho_ncc_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                /*  if (object_.phieuXNNK != null & object_.phieuXNNK != "")
                  {
                      msg_del = "Lỗi:Phiếu nhập kho \"" + object_.sochungtu + "\" đã in xác nhận nhập hàng, không thể chỉnh sửa.";
                      msg += msg_del + "\n";
                  }*/
                else if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "Lỗi:Phiếu nhập kho \"" + object_.sochungtu + "\" đã \"Hiệu Lực\", không thể xóa.";
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    c_donmuahang_id += object_.c_donmuahang_id + ",";
                    /*foreach (md_nhapkho_ncc_dh nk_ncc_dh in db.md_nhapkho_ncc_dh.Where(s => s.md_nhapkho_ncc_id == object_.md_nhapkho_ncc_id))
                    {
                        c_donmuahang_cdmh dmh_cdmh = db.c_donmuahang_cdmh.Where(s => s.md_sanpham_id == nk_ncc_dh.md_sanpham_id & s.c_donmuahang_id == object_.c_donmuahang_id).Take(1).FirstOrDefault();
                        if (dmh_cdmh != null)
                            dmh_cdmh.sl_hanngach += nk_ncc_dh.tong_sl_dat;
                    }*/
                    db.md_nhapkho_ncc.Remove(object_);
                }
            }

            if (msg.Length <= 0)
            {
                db.SaveChanges();
                string[] vnn_donhang_id = c_donmuahang_id.Split(',');
                foreach (c_donmuahang dmh in db.c_donmuahang.Where(s => vnn_donhang_id.Contains(s.c_donmuahang_id)))
                {
                    if (db.md_nhapkho_ncc.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Count() <= 0)
                        dmh.phieunhapkho = " ";
                }
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