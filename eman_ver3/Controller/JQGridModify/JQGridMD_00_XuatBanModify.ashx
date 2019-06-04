<%@ WebHandler Language="C#" Class="JQGridMD_00_XuatBanModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_XuatBanModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_XuatBan":
                this.CA_01_XuatBan(context);
                break;
            case "CA_01_CopytuDonHang":
                this.CA_01_CopytuDonHang(context);
                break;
            case "CA_01_XacNhanXuatKho":
                this.CA_01_XacNhanXuatKho(context);
                break;
            default:
                break;
        }
    }
    public void CA_01_XacNhanXuatKho(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string md_xuatban_id = context.Request.QueryString["id"];
        string msg = "";
        md_xuatban xb = db.md_xuatban.Where(s=>s.md_xuatban_id == md_xuatban_id).Take(1).FirstOrDefault();
        if(xb != null) {
            if (xb.phieuXNNK == null | xb.phieuXNNK == "")
            {
                xb.phieuXNNK = xb.sochungtu.Replace("PXKXB","XNXK");
                db.SaveChanges();
                msg = "true";
            }
        }
        context.Response.Write(msg);
    }

    public void CA_01_CopytuDonHang(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string sct_dsdh = context.Request.Form["value_donhang"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PXKXB", 1);
        string msg = "";
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        var dsdh = db.c_danhsachdathang.Where(s => s.sochungtu == sct_dsdh).Take(1).FirstOrDefault();
        string id = Helper.getNewId();
        if (dsdh == null)
        {
            msg = "<div style='color:red'>Lỗi: Không tìm thấy đơn hàng \"" + sct_dsdh + "\"</div>";
        }
        else
        {
            string check_lsx_kho = db.md_xuatban.
                    Where(s=>s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id & s.trangthai == "SOANTHAO").
                    Select(s=>s.sochungtu).FirstOrDefault();
            if(check_lsx_kho != null & check_lsx_kho != "") {
                msg = "<div style='color:red'>Lỗi: Phiếu xuất kho \""+ check_lsx_kho +"\" chưa hiệu lực.</div>";
            }
            else {
                var don = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id).FirstOrDefault();
                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == don.md_sanpham_id).Take(1).FirstOrDefault();
                var dtkd = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == "ANCOTRADING").Take(1).FirstOrDefault();

                var xb = new md_xuatban();
                xb.md_xuatban_id = id;
                xb.sochungtu = sochungtu;
                xb.donhang_thamchieu = dsdh.so_po;
                xb.c_danhsachdathang_id = dsdh.c_danhsachdathang_id;
                xb.phieuXNNK = "";
                xb.ngaychuyen = DateTime.Now;
                xb.md_doitackinhdoanh_id = (dtkd != null ? dtkd.md_doitackinhdoanh_id : "");
                xb.diachi = (dtkd != null ? dtkd.diachi : "");
                xb.ngaydonhang = dsdh.hangiaohang_po;
                xb.trangthai = "SOANTHAO";
                xb.tukho = sp.khomacdinh;
                xb.sctdathang = dsdh.sochungtu;
                xb.nguoitao = us.ad_user_id;
                xb.vaitrotao = us.ad_role_id;
                xb.bophantao = us.md_phongban_id;
                xb.value_nguoitao = us.ma_user;
                xb.value_vaitrotao = us.ten_role;
                xb.value_bophantao = us.ten_phongban;

                xb.nguoicapnhat = us.ad_user_id;
                xb.vaitrocapnhat = us.ad_role_id;
                xb.bophancapnhat = us.md_phongban_id;
                xb.value_nguoicapnhat = us.ma_user;
                xb.value_vaitrocapnhat = us.ten_role;
                xb.value_bophancapnhat = us.ten_phongban;

                xb.ngaytao = DateTime.Now;
                xb.ngaycapnhat = DateTime.Now;
                xb.mota = "";
                xb.hoatdong = true;

                int count = 0;
                foreach (var ddsdh in db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id & s.sl_dathang > s.sl_hanngach))
                {
                    count++;
                    var sp1 = db.md_sanpham.Where(s => s.md_sanpham_id == ddsdh.md_sanpham_id).Take(1).FirstOrDefault();
                    var cdh_xb = new md_xuatban_cdh
                    {
                        md_xuatban_cdh_id = Helper.getNewId(),
                        md_xuatban_id = id,
                        md_sanpham_id = sp1.md_sanpham_id,
                        tong_sl_xuat = ddsdh.sl_dathang.Value - ddsdh.sl_hanngach.Value - ddsdh.sl_giamhanngach.GetValueOrDefault(0),
                        sl_daxuat = 0,
                        sl_xuat = 0,
                        md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
                        tenhang = sp1.mota_tiengviet,
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
                    db.md_xuatban_cdh.Add(cdh_xb);
                }

                if(count > 0)
                    db.md_xuatban.Add(xb);
                else
                    msg = "<div style='color:red'>Lỗi: Đơn hàng \"" + sct_dsdh + "\" đã xuất hết tất cả dòng hàng.</div>";
            }
        }

        if (msg.Length <= 0)
        {
            db.SaveChanges();
            msg = id + "#<div style='color:blue'>Tạo phiếu xuất kho \"" + sochungtu + "\" thành công.</div>";
        }
        context.Response.Write(msg);
    }

    public void CA_01_XuatBan(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        //string sochungtu = VNN_VariablePublic.sochungtu(db, "PXKXB", 1);
        int count_slxuat = 0;
        using (var transaction = db.Database.BeginTransaction())
        {
            try
            {
                //Xu Ly nhap kho
                foreach (md_xuatban px in db.md_xuatban.Where(s => vnn.Contains(s.md_xuatban_id)).ToList())
                {
                    if (px.trangthai == "HIEULUC")
                    {
                        msg = "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" đã hiệu lực.</div>";
                        break;
                    }

                    var check_kho = db.md_xuatban_cdh.Where(s => s.check_kho == true & s.md_xuatban_id == px.md_xuatban_id);
                    var check_ma = db.md_xuatban_cdh.Where(s => s.md_sanpham_id != null & s.md_xuatban_id == px.md_xuatban_id);
                    string soluong_xuat = "0";
                    var count = db.md_xuatban_cdh.Where(s => s.md_xuatban_id == px.md_xuatban_id & (s.check_kho == null | s.check_kho == false));
                    foreach (var dh in count.ToList())
                    {
                        //--
                        md_kho_sanpham kho = db.md_kho_sanpham.Where(s => s.md_kho_id == px.tukho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                        md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();

                        if (dh.check_kho != true)
                        {
                            if (px.tukho == null & px.md_doitackinhdoanh_id == null | px.tukho == "" & px.md_doitackinhdoanh_id == "")
                            {
                                msg += "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" chưa có kho hoặc phân xưởng đến.</div>";
                            }
                            else if (kho == null)
                            {
                                if (dh.sl_xuat > 0)
                                {
                                    msg += "<div style='color:red'>Lỗi: \"" + sp.ma_sanpham + "\" không có trong kho.</div>";
                                    count_slxuat++;
                                }
                            }
                            else if (kho.soluong < dh.sl_xuat)
                            {
                                msg += "<div style='color:red'>Lỗi: Số lượng \"" + sp.ma_sanpham + "\" trong kho chỉ còn: \"" + kho.soluong.Value.DropTrailingZeros() + "\" .</div>";
                            }
                            else if (dh.sl_xuat < 0)
                            {
                                msg += "<div style='color:red'>Lỗi: Số lượng xuất của \"" + sp.ma_sanpham + "\" phải lớn hơn 0 .</div>";
                            }
                        }

                        if (msg.Length <= 0 & dh.sl_xuat > 0)
                        {
                            count_slxuat++;
                            soluong_xuat = "" + dh.sl_xuat.GetValueOrDefault(0).DropTrailingZeros();
                            //--cap nhat so luong xuat
                            edit_xuat(db, dh, us);
                            //--cap nhat vao kho
                            xuat_kho(db, dh, px, us);
                            //--tao lich su nhap kho
                            add_kho_ls(db, dh, px, us);
                            msg_success += "<div style='color:blue'>Dòng \"" + px.sochungtu + " của \"" + sp.ma_sanpham + "\" đã xuất kho thành công, số lượng xuất là: \"" + soluong_xuat + "\"</div>";
                        }
                    }

                    if (msg.Length <= 0 & count_slxuat <= 0)
                    {
                        msg = "<div style='color:red'>Lỗi: Dòng \"" + px.sochungtu + "\" phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.</div>";
                    }

                    if (msg.Length <= 0)
                    {
                        px.trangthai = "HIEULUC";
                        db.SaveChanges();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                msg = "false#" + ex.Message;
            }

            if (msg.Length <= 0)
            {
                msg = msg_success + msg;
                transaction.Commit();
            }
            else
                transaction.Rollback();
        }
        context.Response.Write(msg);
    }
    //--cap nhat so luong xuat
    public string edit_xuat(EntityContext db, md_xuatban_cdh dh, User_TK us)
    {
        string id_new = dh.md_xuatban_id;
        md_xuatban xk = db.md_xuatban.Where(s => s.md_xuatban_id == dh.md_xuatban_id).FirstOrDefault();
        c_dongdsdh ddsdh = db.c_dongdsdh.Where(s=>s.c_danhsachdathang_id == xk.c_danhsachdathang_id & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        if(ddsdh != null)
            ddsdh.sl_hanngach += (decimal)dh.sl_xuat;

        decimal sl_daxuat = dh.sl_daxuat.Value + dh.sl_xuat.Value;
        if (dh.tong_sl_xuat.Value <= sl_daxuat)
        {
            sl_daxuat = dh.tong_sl_xuat.Value;
            dh.check_kho = true;
        }

        dh.sl_daxuat = dh.sl_xuat + dh.sl_daxuat;
        xk.ngaycapnhat = DateTime.Now;
        foreach(md_xuatban xb in db.md_xuatban.Where(s => s.md_xuatban_id != xk.md_xuatban_id & s.c_danhsachdathang_id == xk.c_danhsachdathang_id & s.trangthai == "SOANTHAO"))
        {
            foreach(md_xuatban_cdh xb_dh in db.md_xuatban_cdh.Where(s => s.md_xuatban_id ==xb.md_xuatban_id & s.md_sanpham_id == dh.md_sanpham_id))
            {
                xb_dh.tong_sl_xuat = xb_dh.tong_sl_xuat - sl_daxuat;
                xb_dh.sl_xuat = 0;
            }
        }
        return id_new;
    }

    //xuat kho
    public string xuat_kho(EntityContext db, md_xuatban_cdh dh, md_xuatban px, User_TK us)
    {
        string id_new = dh.md_xuatban_id;
        md_kho_sanpham check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == px.tukho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;

        id_new = sp.md_kho_sanpham_id;
        sp.soluong = sp.soluong - dh.sl_xuat;
        sp.ngaycapnhat = DateTime.Now;
        c_dongdsdh dsdh = db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == px.c_danhsachdathang_id & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        dsdh.sl_dagiao += dh.sl_xuat;
        dsdh.sl_conlai -= dh.sl_xuat;
        return id_new;
    }
    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_xuatban_cdh dh, md_xuatban px, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_giaodich giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = px.tukho;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = dh.sl_xuat;
        giao.ngaychuyen = px.ngaychuyen;
        giao.kieuchuyen = "Xuất kho";
        giao.dongnhapxuat = px.sochungtu;
        giao.md_donvitinhsanpham_id = dh.md_donvitinhsanpham_id;

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

        dh.sl_xuat = 0;
        return id_new;
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        string sctdathang = context.Request.Form["sctdathang"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PXKXB", 1);
        try
        {
            md_doitackinhdoanh dtk = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).FirstOrDefault();
            c_danhsachdathang dsdh = db.c_danhsachdathang.Where(s=>s.sochungtu == sctdathang).FirstOrDefault();
            string id = context.Request.Form["id"];
            if (md_dtk_id == null)
            {
                msg = "false#Lỗi: Đối tác  \"" + md_dtk_id + "\" không tồn tại.";
            }
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_xuatban";
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", dtk.md_doitackinhdoanh_id);
                VNN_Function.SetFormValue("diachi", dtk.diachi);
                VNN_Function.SetFormValue("sochungtu", sochungtu);
                VNN_Function.SetFormValue("c_danhsachdathang_id", dsdh.c_danhsachdathang_id);
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
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        try
        {
            md_doitackinhdoanh dtk = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).FirstOrDefault();
            string id = context.Request.Form["id"];
            md_xuatban object_ = db.md_xuatban.Where(p => p.md_xuatban_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.trangthai == "HIEULUC")
            {
                msg = "false#Lỗi:Đối tượng đã xuất kho.";
            }
            else if (dtk == null)
            {
                msg = "false#Lỗi:Mã đối tác \"" + md_dtk_id + "\" không tồn tại.";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_xuatban";
                VNN_Function.SetFormValue("md_doitackinhdoanh_id", dtk.md_doitackinhdoanh_id);
                VNN_Function.SetFormValue("diachi", dtk.diachi);
                VNN_Function.SetFormValue("sochungtu", "VNN_notpost");
                VNN_Function.SetFormValue("trangthai", "VNN_notpost");
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
        string msg = "",  msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "md_xuatban";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_xuatban object_ = db.md_xuatban.Where(p => p.md_xuatban_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "<br>";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "Lỗi:Đối tượng đã hiệu lực " + i;
                    msg += msg_del + "<br>";
                }
                else if(db.md_vanchuyennoibo.Where(s=>s.chungtuthamchieu == object_.sochungtu).Count() > 0) {
                    msg_del = "Lỗi:\""+ object_.sochungtu +"\" có phiếu vận chuyển nội bộ đang sử dụng, không thể xóa dòng này.";
                    msg += msg_del + "<br>";
                }

                if (msg_del.Length <= 0)
                {
                    db.md_xuatban.Remove(object_);
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