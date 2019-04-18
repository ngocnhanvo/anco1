<%@ WebHandler Language="C#" Class="JQGridMD_00_NTPXSXModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_NTPXSXModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_XL":
                this.CA_01_XL(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_XL(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        try
        {
            //Xu Ly nhap kho
            foreach (md_nhapkho_px px in db.md_nhapkho_px.Where(s => vnn.Contains(s.md_nhapkho_px_id)))
            {
                if (px.trangthai == "HIEULUC")
                {
                    msg += "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" đã hiệu lực.</div>";
                }

                var check_kho = db.md_nhapkho_px_dh.Where(s => s.check_kho == true & s.md_nhapkho_px_id == px.md_nhapkho_px_id);
                var check_ma = db.md_nhapkho_px_dh.Where(s => s.md_sanpham_id != null & s.md_nhapkho_px_id == px.md_nhapkho_px_id);
                string soluong_nhap = "0";
                int count_slnhap = 0;
                var md_nhapkho_px_cdh = db.md_nhapkho_px_dh.Where(s => s.md_nhapkho_px_id == px.md_nhapkho_px_id & (s.check_kho == null | s.check_kho == false));
                foreach (md_nhapkho_px_dh dh in md_nhapkho_px_cdh)
                {
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                    if (dh.check_kho != true)
                    {
                        if (px.md_kho_id == null & px.md_kho_id == " ")
                        {
                            msg += "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" chưa có kho hoặc phân xưởng đến.</div>";
                        }
                        else if (dh.sl_nhap < 0)
                        {
                            msg += "<div style='color:red'>Lỗi: Số lượng nhập của \"" + sp.ma_sanpham + "\" phải lớn hơn 0 .</div>";
                        }
                        else if (dh.sl_nhap >= 0)
                        {
                            count_slnhap++;
                        }

                        if (msg.Length <= 0)
                        {
                            if (dh.check_kho != true)
                            {
                                soluong_nhap = "" + dh.sl_nhap;
                                //--cap nhat so luong nhap
                                edit_nhap(db, dh, us);
                                //--cap nhat vao kho
                                add_kho(db, dh, px, us);
                                //--tao lich su nhap kho
                                string abc = add_kho_ls(db, dh, px, us);
                                if (abc.Length <= 0)
                                {
                                    msg_success += "<div style='color:blue'>Dòng \"" + px.sochungtu + " của \"" + sp.ma_sanpham + "\" đã nhập kho thành công, số lượng nhập là: \"" + soluong_nhap + "\"</div>";
                                }
                            }
                        }
                    }

                    if (md_nhapkho_px_cdh.Count() <= count_slnhap)
                    {
                        msg_success += "<div style='color:red'>Dòng \"" + px.sochungtu + " phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.</div>";
                    }
                    //Kiem tra de chuyen thanh Hieu Luc
                    if (msg.Length <= 0)
                    {
                        px.trangthai = "HIEULUC";
                        db.SaveChanges();
                    }
                    msg = msg_success + msg;
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
    public string edit_nhap(EntityContext db, md_nhapkho_px_dh dh, User_TK us)
    {
        string id_new = dh.md_nhapkho_px_id;
        md_nhapkho_px_dh check = db.md_nhapkho_px_dh.Where(s => s.md_nhapkho_px_id == dh.md_nhapkho_px_id & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_nhapkho_px_dh px_dh = check;
        md_nhapkho_px px = db.md_nhapkho_px.Where(s => s.md_nhapkho_px_id == px_dh.md_nhapkho_px_id).FirstOrDefault();
        if (dh.tong_sl_dat == (decimal)dh.sl_danhap + (decimal)dh.sl_nhap)
        {
            px_dh.check_kho = true;
        }
        if (dh.sl_nhap != 0)
        {
            px.trangthai = "CHUACHUYENHET";
        }
        px_dh.sl_danhap = dh.sl_nhap + dh.sl_danhap;
        px_dh.sl_nhap = dh.sl_nhap;

        px.ngaycapnhat = DateTime.Now;
        px_dh.ngaycapnhat = DateTime.Now;
        db.SaveChanges();
        return id_new;
    }

    //--cap nhat vao kho
    public string add_kho(EntityContext db, md_nhapkho_px_dh dh, md_nhapkho_px px, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_sanpham check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == px.md_kho_id & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;
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
        sp.md_kho_id = px.md_kho_id;
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

        //Kiem tra
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
        if (dh.sl_nhap > 0)
        {
            db.SaveChanges();
        }
        return id_new;
    }

    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_nhapkho_px_dh dh, md_nhapkho_px px, User_TK us)
    {
        string id_new = Helper.getNewId();
        string abc = "";
        if (dh.sl_nhap == 0)
        {
            abc = "abc";
        }
        else
        {
            md_kho_giaodich giao = new md_kho_giaodich();
            giao.md_kho_giaodich_id = id_new;
            giao.md_kho_id = px.md_kho_id;
            giao.md_sanpham_id = dh.md_sanpham_id;
            giao.soluong_dichchuyen = dh.sl_nhap;
            giao.ngaychuyen = DateTime.Now;
            giao.kieuchuyen = "Nhập kho";
            //giao.dongnhapxuat = px.sochungtu;
            //giao.dongkiemkho = "";
            //giao.dongvanchuyen = "";
            giao.dongsanxuat = px.sochungtu;

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
            dh.sl_nhap = 0;
            db.SaveChanges();
        }

        return abc;
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
                string ten_table = "md_nhapkho_px";
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
        string ten_kho = context.Request.Form["md_kho_id"];
        try
        {
            string id = context.Request.Form["id"];
            md_nhapkho_px object_ = db.md_nhapkho_px.Where(p => p.md_nhapkho_px_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.trangthai != "SOANTHAO")
            {
                msg = "false#Lỗi:Dòng " + object_.sochungtu + " đã nhập kho.";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_nhapkho_px";
                VNN_Function.SetFormValue("md_phanxuong_id", "VNN_notpost");
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
            string ten_table = "md_nhapkho_px";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                md_nhapkho_px object_ = db.md_nhapkho_px.Where(p => p.md_nhapkho_px_id == id_del_).Take(1).FirstOrDefault();
                if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "Lỗi:Đối tượng đã Hiệu Lực";
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "CHUACHUYENHET")
                {
                    msg_del = "Lỗi:Đối tượng trong trạng thái Chưa Chuyển Hết";
                    msg += msg_del + "\n";
                }
                else
                {
                    if (object_ == null)
                    {
                        msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                        msg += msg_del + "\n";
                    }
                    if (msg_del.Length <= 0)
                    {
                        /*  string action = "del";
                          string[] column_ex = { };
                          VNN_Function.SetFormValue("id", object_.md_nhapkho_px_id);
                          VNN_Function.Set_DefaultvalueColumn(context, action);
                          VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db); */
                        md_dondathangphanxuong a = db.md_dondathangphanxuong.Where(s => s.md_dondathangphanxuong_id == object_.md_dondathangphanxuong_id).FirstOrDefault();
                        a.phieunhapkho = " ";

                        foreach (md_nhapkho_px_dh b in db.md_nhapkho_px_dh.Where(s => s.md_nhapkho_px_id == object_.md_nhapkho_px_id))
                        {
                            foreach (md_dondathangphanxuong_cdh c in db.md_dondathangphanxuong_cdh.Where(s => s.md_dondathangphanxuong_id == a.md_dondathangphanxuong_id & s.md_sanpham_id == b.md_sanpham_id))
                            {
                                c.hanngach = c.hanngach + b.tong_sl_dat;
                            }
                        }
                        db.md_nhapkho_px.Remove(object_);
                        db.SaveChanges();
                    }
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