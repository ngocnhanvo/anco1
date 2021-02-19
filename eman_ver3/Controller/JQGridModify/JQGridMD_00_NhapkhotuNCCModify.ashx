<%@ WebHandler Language="C#" Class="JQGridMD_00_NhapkhotuNCCModify" %>
using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
public class JQGridMD_00_NhapkhotuNCCModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_XLNKNCC":
                this.CA_01_XLNKNCC(context);
                break;
            case "CA_01_XacNhanNKNCC":
                this.CA_01_XacNhanNKNCC(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_XacNhanNKNCC(HttpContext context)
    {
        string msg = "";
        context.Response.Write(msg);
    }

    public void CA_01_XLNKNCC(HttpContext context)
    {
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        int count_slnhap = 0;

        using (var transaction = db.Database.BeginTransaction())
        {
            //Xu Ly nhap kho
            foreach (var px in db.md_nhapkho_ncc.Where(s => s.md_nhapkho_ncc_id == id).ToList())
            {
                if (px.trangthai == "HIEULUC")
                {
                    msg += "Lỗi: dòng \"" + px.sochungtu + "\" đã hiệu lực.</div>";
                    break;
                }
                else if (string.IsNullOrEmpty(px.kho) | px.kho == " ")
                {
                    msg += "Lỗi: dòng \"" + px.sochungtu + "\" chưa có kho đến.";
                    break;
                }
                else if(px.trangthai != "DANHAN")
                {
                    msg += string.Format(@"Lỗi: dòng ""{0}"" cần ở trạng thái ""Đã Xác Nhận"".", px.sochungtu);
                    break;
                }
                else
                {
                    var md_nhapkho_ncc_dhs = db.md_nhapkho_ncc_dh
                            .Where(s => s.md_nhapkho_ncc_id == px.md_nhapkho_ncc_id & s.sl_nhap > 0).ToList();
                    foreach (var dh in md_nhapkho_ncc_dhs)
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                        try
                        {
                            count_slnhap++;
                            decimal soluong_nhap = dh.sl_nhap.Value;
                            //--cap nhat so luong nhap
                            edit_nhap(db, dh, px, userTK);
                            db.SaveChanges();
                            //--cap nhat vao kho
                            string khospId = add_kho(db, dh, px, userTK);
                            db.SaveChanges();
                            //--cap nhat vao kho hạn sử dụng
                            add_kho_hsd(db, dh, px, userTK, khospId);
                            db.SaveChanges();
                            //--tao lich su nhap kho
                            add_kho_ls(db, dh, px, userTK);
                            db.SaveChanges();
                            //--cap nhat gia tri binh quan gia quyen của sản phẩm
                            add_kho_bqgq(db, dh, sp, px.kho, userTK);
                            db.SaveChanges();

                            msg_success += "<div>Dòng \"" + px.sochungtu + " của \"" + sp.ma_sanpham + "\" đã nhập kho thành công, số lượng nhập là: \"" + soluong_nhap.DropTrailingZeros() + "\"</div>";
                        }
                        catch (Exception ex)
                        {
                            msg += string.Format("<div style='color:red'>Lỗi: {0}</div>", ex + "");
                            break;
                        }
                    }
                }

                if (count_slnhap <= 0)
                {
                    msg += "Dòng \"" + px.sochungtu + " phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.";
                }
                //Kiem tra de chuyen thanh Hieu Luc
                if (msg.Length <= 0)
                {
                    px.trangthai = "HIEULUC";
                    db.SaveChanges();

                    var dmhs = db.c_donmuahang.Where(s => px.c_donmuahang_id.Contains(s.c_donmuahang_id)).ToList();
                    foreach (var dmh in dmhs)
                    {
                        var cdhs = db.c_donmuahang_cdmh.Where(s => s.c_donmuahang_id == dmh.c_donmuahang_id).Where(s=>s.sl_dadat > s.sl_hanngach).Count();
                        if (cdhs <= 0)
                            dmh.md_trangthai_id = "DAXONG";
                        else
                            dmh.md_trangthai_id = "CHUAXONG";
                    }
                    db.SaveChanges();
                }
            }

            if (msg.Length <= 0)
            {
                msg = string.Format("<div style='color:blue'>{0}</div>", msg_success);
                transaction.Commit();
            }
            else
            {
                msg = string.Format("<div style='color:red'>{0}</div>", msg);
                transaction.Rollback();
            }
        }
        context.Response.Write(msg);
    }

    //--cap nhat so luong nhap
    public string edit_nhap(EntityContext db, md_nhapkho_ncc_dh dh, md_nhapkho_ncc nk, User_TK us)
    {
        string id_new = dh.md_nhapkho_ncc_id;
        var dmh_cdmh = db.c_donmuahang_cdmh.Where(s =>
            s.c_donmuahang_id == dh.c_donmuahang_id
            & s.md_sanpham_id == dh.md_sanpham_id
        ).FirstOrDefault();

        if (dmh_cdmh != null)
            dmh_cdmh.sl_hanngach += dh.sl_nhap.GetValueOrDefault(0);

        dh.sl_danhap = dh.sl_nhap.GetValueOrDefault(0);
        nk.ngaycapnhat = DateTime.Now;

        foreach (var check_nk in db.md_nhapkho_ncc.
                Where(s => s.md_nhapkho_ncc_id != nk.md_nhapkho_ncc_id
                    & s.c_donmuahang_id.Contains(dh.c_donmuahang_id)
                    & new string[] { "SOANTHAO", "DANHAN" }.Contains(s.trangthai)).ToList())
        {
            var ck_dh = db.md_nhapkho_ncc_dh.
                    Where(s =>
                        s.md_nhapkho_ncc_id == check_nk.md_nhapkho_ncc_id
                        & s.c_donmuahang_id == dh.c_donmuahang_id
                        & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();

            if(ck_dh != null)
            {
                ck_dh.tong_sl_dat = ck_dh.tong_sl_dat - dh.sl_nhap;
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
            sp.soluong = dh.sl_nhap;
        }
        else
        {
            id_new = sp.md_kho_sanpham_id;
            sp.soluong = dh.sl_nhap + sp.soluong;
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
            spHSD.soluong = dh.sl_nhap;
            spHSD.ngay_hethan = dh.ngay_hethan;
        }
        else
        {
            id_new = spHSD.md_kho_sanpham_hansudung_id;
            spHSD.soluong = dh.sl_nhap + spHSD.soluong;
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
        if (dh.sl_nhap == 0)
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
            giao.soluong_dichchuyen = dh.sl_nhap;
            giao.ngaychuyen = px.ngaychuyen;
            giao.kieuchuyen = "Nhập kho";
            giao.dongnhapxuat = px.sochungtu;
            giao.md_donvitinhsanpham_id = dvt.md_donvitinhsanpham_id;
            giao.mota = dh.so_dmh;

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

    public void add_kho_bqgq(EntityContext db, md_nhapkho_ncc_dh dh, md_sanpham sp, string kho, User_TK us)
    {
        //if (sp != null)
        //{
        //    decimal? tsl_trongkho = db.md_kho_sanpham.Where(s => s.md_sanpham_id == sp.md_sanpham_id & s.md_kho_id == kho).Select(s => s.soluong).Sum();
        //    decimal ve1 = (tsl_trongkho.GetValueOrDefault(0) - dh.sl_nhap.GetValueOrDefault(0)) * sp.giabinhquan.GetValueOrDefault(0);
        //    decimal ve2 = dh.sl_nhap.GetValueOrDefault(0) * dh.giatriVND.GetValueOrDefault(0);
        //    sp.giabinhquan = Math.Ceiling(((ve1 + ve2) / tsl_trongkho).GetValueOrDefault(0));
        //}
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
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                string id = context.Request.Form["id"];
                var object_ = db.md_nhapkho_ncc.Where(p => p.md_nhapkho_ncc_id == id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg = "Lỗi:Không tìm thấy đối tượng cần sửa ";
                }
                else if (!new string[] { "SOANTHAO", "DANHAN" }.Contains(object_.trangthai))
                {
                    msg = "Lỗi:Đã nhập kho";
                }
                else
                {
                    VNN_Function.SetFormValue(object_.nameof(s => s.trangthai), "VNN_notpost");
                    object_ = entityFunc.updateDataInEntity(object_, object_.GetType(), context);
                    object_ = Helper.setDefaultValueWhenInsertOrUpdate(object_, userTK, true);
                    db.SaveChanges();
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
                var ids = context.Request.Form["id"].Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                foreach (var id_del_ in ids)
                {
                    var object_ = db.md_nhapkho_ncc.Where(p => p.md_nhapkho_ncc_id == id_del_).Take(1).FirstOrDefault();
                    if (object_ == null)
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Không tìm thấy đối tượng cần xóa.", id_del_);
                    }
                    else if (object_.trangthai == "HIEULUC")
                    {
                        msg += string.Format(@"<br><b>{0}</b>: Đã được ""Hiệu Lực"".", object_.sochungtu);
                    }
                    else
                    {
                        VNN_Function.Write_log(context, ma_module, null, oper, "PNKNCC:" + object_.sochungtu, db);
                        object_.trangthai = "SOANTHAO";
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            if(msg.Length <= 0)
            {
                msg = @"true#Trả phiếu nhập kho đã chọn về ""Soạn Thảo"" thành công.";
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