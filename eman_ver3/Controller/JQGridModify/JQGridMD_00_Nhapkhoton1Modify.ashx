<%@ WebHandler Language="C#" Class="JQGridMD_00_Nhapkhoton1Modify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_00_Nhapkhoton1Modify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA01NhapKho_MD00Nhapkhoton1":
                this.CA01NhapKho_MD00Nhapkhoton1(context);
                break;
            default:
                break;
        }
    }

    public void CA01NhapKho_MD00Nhapkhoton1(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "", muti_ma = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNK", 1);
        int count_slnhap = 0;
        try
        {
            //Xu Ly nhap kho
            foreach (md_nhapkhoton nk in db.md_nhapkhoton.Where(s => s.md_nhapkhoton_id == id).ToList())
            {
                if (nk.trangthai == "HIEULUC")
                {
                    msg = "<div style='color:red'>Lỗi: dòng \"" + nk.sochungtu + "\" đã hiệu lực.</div>";
                    break;
                }
                foreach(md_nhapkhoton_cdh dh in db.md_nhapkhoton_cdh.Where(s => s.md_nhapkhoton_id == nk.md_nhapkhoton_id).ToList())
                {
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                    decimal nhanvoi = 1;
                    if (nk.denkho == null & nk.denkho == null | nk.denkho == "" & nk.denkho == "")
                    {
                        msg += "<div style='color:red'>Lỗi: dòng \"" + nk.sochungtu + "\" chưa có kho đến.</div>";
                    }
                    else if (dh.sl_nhap < 0)
                    {
                        msg += "<div style='color:red'>Lỗi: \"" + sp.ma_sanpham + "\" Số lượng nhập phải lớn hơn 0 .</div>";
                    }

                    if (msg.Length <= 0 & dh.sl_nhap > 0)
                    {
                        count_slnhap = 1;
                        decimal sl_nhap = dh.sl_nhap.Value;
                        //--cap nhat vao kho
                        nhap_kho(db, dh, nk, nhanvoi, us);
                        //--tao lich su nhap kho
                        add_kho_ls(db, dh, nk, nhanvoi, us);

                        msg_success += "<div style='color:blue'>Dòng \"" + nk.sochungtu + " của \"" + sp.ma_sanpham + "\" đã nhập kho thành công, số lượng nhập là: \"" + sl_nhap.DropTrailingZeros() + "\"</div>";
                    }
                }

                if (count_slnhap <= 0)
                {
                    msg += "<div style='color:red'>Dòng \"" + nk.sochungtu + " phải có ít nhất 1 dòng hàng có số lượng lớn hơn 0.</div>";
                }

                //Kiem tra de chuyen thanh Hieu Luc
                if (msg.Length <= 0)
                {
                    msg = msg_success + msg;
                    nk.trangthai = "HIEULUC";
                    db.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    //nhap kho
    public string nhap_kho(EntityContext db, md_nhapkhoton_cdh dh, md_nhapkhoton nk, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_sanpham check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == nk.denkho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;
        if (check_khosp == null)
        {
            sp = new md_kho_sanpham();
            sp.md_kho_sanpham_id = id_new;
            sp.soluong = (dh.sl_nhap * nhanvoi);
        }
        else
        {
            id_new = sp.md_kho_sanpham_id;
            sp.soluong += (dh.sl_nhap * nhanvoi);
        }
        sp.md_kho_id = nk.denkho;
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
        return id_new;
    }

    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_nhapkhoton_cdh dh, md_nhapkhoton nk, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_giaodich giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = nk.denkho;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = dh.sl_nhap * nhanvoi;
        giao.ngaychuyen = nk.ngaychuyen;
        giao.kieuchuyen = "Nhập kho";
        giao.dongnhapxuat = nk.sochungtu;
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

        dh.sl_danhap = dh.sl_nhap;
        return "";
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        //string md_lenhsanxuat_id = context.Request.Form["md_lenhsanxuat_id"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNKT", 1);
        // string lenhsanxuat_id = "", lenhsanxuat_tosx_id = "";
        //md_lenhsanxuat lsx = null;
        try
        {
            /*if (md_lenhsanxuat_id != null & md_lenhsanxuat_id != "" & md_lenhsanxuat_id != " ")
            {
                lsx = db.md_lenhsanxuat.Where(s => s.sochungtu == md_lenhsanxuat_id).FirstOrDefault();
                if (lsx != null)
                {
                    //md_lenhsanxuat_tosx sx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id).FirstOrDefault();
                    //lenhsanxuat_tosx_id = sx.md_lenhsanxuat_tosx_id;
                    lenhsanxuat_id = lsx.md_lenhsanxuat_id;
                    // msg = lsx.md_lenhsanxuat_id + "<>" + lenhsanxuat_id;
                }
                else
                    msg = "false#Lỗi: Lệnh sản xuất \"" + md_lenhsanxuat_id + "\" đã nhập không tồn tại";
            }*/
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                //if(lsx == null) 				
                //    msg = "false#Phải chọn 1 lệnh sản xuất.";
                // }
                //else {
                if( 1 + 1 ==2 ){
                    /* string check_lsx_kho = db.md_nhapkhoton.Where(s=>s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id & s.trangthai == "SOANTHAO").Select(s=>s.sochungtu).FirstOrDefault();
                     if(check_lsx_kho != null & check_lsx_kho != "") {
                            msg = "false#Phiếu nhập kho \""+ check_lsx_kho +"\" chưa hiệu lực.";
                     }
                     else {*/

                    string action = "add";
                    string[] column_ex = { "md_lenhsanxuat_tosx_id" };
                    string ten_table = "md_nhapkhoton";
                    //VNN_Function.SetFormValue("md_lenhsanxuat_id", lenhsanxuat_id);
                    VNN_Function.SetFormValue("sochungtu", sochungtu);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                    msg = "true#Thêm thành công." + "#" + id_new;
                    db.SaveChanges();
                    //}
                }
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
        string md_lenhsanxuat_id = context.Request.Form["md_lenhsanxuat_id"];
        try
        {
            string id = context.Request.Form["id"];
            md_nhapkhoton object_ = db.md_nhapkhoton.Where(p => p.md_nhapkhoton_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.trangthai == "HIEULUC")
            {
                msg = "false#Lỗi:Đối tượng đã nhập kho";
            }

            /*if (md_lenhsanxuat_id != null & md_lenhsanxuat_id != "")
            {
                md_lenhsanxuat lsx = db.md_lenhsanxuat.Where(s => s.sochungtu == md_lenhsanxuat_id).FirstOrDefault();
                md_lenhsanxuat_id = lsx.md_lenhsanxuat_id;
            }
            else {
                msg = "false#Không tìm thấy lệnh sản xuất \"" + md_lenhsanxuat_id + "\"";
            }*/


            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_nhapkhoton";
                VNN_Function.SetFormValue("md_lenhsanxuat_id", md_lenhsanxuat_id);
                VNN_Function.SetFormValue("sochungtu", "VNN_notpost");
                VNN_Function.SetFormValue("nhaptu", "VNN_notpost");
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
            string ten_table = "md_nhapkhoton";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_nhapkhoton object_ = db.md_nhapkhoton.Where(p => p.md_nhapkhoton_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "Lỗi:Đối tượng đã hiệu lực " + i;
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "CHUACHUYENHET")
                {
                    msg_del = "Lỗi:Đối tượng trong trạng thái Chưa Chuyển Hết";
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    /* foreach (md_lenhsanxuat_tosx_cdh lsx_to_cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == object_.md_lenhsanxuat_tosx_id))
                     {
                         md_nhapkhoton_cdh nknb_cdh = db.md_nhapkhoton_cdh.Where(s => s.md_nhapkhoton_id == object_.md_nhapkhoton_id & s.md_sanpham_id == lsx_to_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                         if (nknb_cdh != null)
                             lsx_to_cdh.sl_dahoanthanh -= nknb_cdh.tong_sl_dat;
                     }*/
                    object_.trangthai = "SOANTHAO";
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