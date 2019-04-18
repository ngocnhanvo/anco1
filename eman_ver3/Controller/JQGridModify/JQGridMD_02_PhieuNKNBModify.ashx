<%@ WebHandler Language="C#" Class="JQGridMD_02_PhieuNKNBModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_PhieuNKNBModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA01NhapKho_MD02PhieuNKNB":
                this.CA01NhapKho_MD02PhieuNKNB(context);
                break;
            default:
                break;
        }
    }

    public void CA01NhapKho_MD02PhieuNKNB(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNK", 1);
        bool check_hieuluc = bool.Parse(context.Request.Form["check_hieuluc"]);
        try
        {
            //Xu Ly nhap kho
            foreach (md_nhapkhonb nk in db.md_nhapkhonb.Where(s => vnn.Contains(s.md_nhapkhonb_id)))
            {
                if (nk.trangthai == "HIEULUC")
                {
                    msg = "<div style='color:red'>Lỗi: dòng \"" + nk.sochungtu + "\" đã hiệu lực.</div>";
                    break;
                }

                var check_kho = db.md_nhapkhonb_cdh.Where(s => s.check_kho == true & s.md_nhapkhonb_id == nk.md_nhapkhonb_id);
                var check_ma = db.md_nhapkhonb_cdh.Where(s => s.md_sanpham_id != null & s.md_nhapkhonb_id == nk.md_nhapkhonb_id);
                string soluong_xuat = "0";
                foreach (md_nhapkhonb_cdh dh in db.md_nhapkhonb_cdh.Where(s => s.md_nhapkhonb_id == nk.md_nhapkhonb_id))
                {
                    //md_kho_sanpham kho = db.md_kho_sanpham.Where(s => s.md_kho_id == nk.denkho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                    decimal nhanvoi = 1;
                    md_donvitinhsanpham_cddv dvtsp_cddv = db.md_donvitinhsanpham_cddv.Where(s => s.md_donvitinhsanpham_id == dh.md_donvitinhsanpham_id
                    & s.md_dvtsp_id == sp.md_donvitinhsanpham_id).Take(1).FirstOrDefault();
                    if (dvtsp_cddv != null)
                        nhanvoi = dvtsp_cddv.nhanvoi.Value;

                    if (dh.check_kho != true)
                    {
                        if (nk.denkho == null & nk.denkho == null | nk.denkho == "" & nk.denkho == "")
                        {
                            msg += "<div style='color:red'>Lỗi: dòng \"" + nk.sochungtu + "\" chưa có kho hoặc phân xưởng đến.</div>";
                        }
                        else if (dh.sl_nhap < 0)
                        {
                            msg += "<div style='color:red'>Lỗi: Số lượng nhập của \"" + sp.ma_sanpham + "\" phải lớn hơn 0 .</div>";
                        }
                    }

                    if (msg.Length <= 0)
                    {
                        if (dh.check_kho != true)
                        {
                            soluong_xuat = "" + dh.sl_nhap;
                            //--cap nhat so luong xuat
                            edit_nhap(db, dh, us);
                            //--cap nhat vao kho
                            nhap_kho(db, dh, nk, nhanvoi, us);
                            //--tao lich su nhap kho
                            add_kho_ls(db, dh, nk, nhanvoi, us);
                            msg_success += "<div style='color:blue'>\"" + sp.ma_sanpham + "\" đã nhập kho thành công, số lượng nhập là: \"" + soluong_xuat + "\"</div>";
                        }
                    }
                }

                //Kiem tra de chuyen thanh Hieu Luc
                if (msg.Length <= 0)
                {
                    if (check_hieuluc == true)
                    {
                        nk.trangthai = "HIEULUC";
                    }
                    else if (check_kho.Count() == check_ma.Count())
                    {
                        nk.trangthai = "HIEULUC";
                    }
                    db.SaveChanges();
                }

                msg = msg_success + msg;
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }
    //--cap nhat so luong xuat
    public string edit_nhap(EntityContext db, md_nhapkhonb_cdh dh, User_TK us)
    {
        string id_new = dh.md_nhapkhonb_id;
        md_nhapkhonb xk = db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id == dh.md_nhapkhonb_id).FirstOrDefault();
        if (dh.tong_sl_dat == dh.sl_danhap + dh.sl_nhap)
        {
            dh.check_kho = true;
        }
        dh.sl_danhap = dh.sl_nhap + dh.sl_danhap;
        dh.ngaycapnhat = DateTime.Now;

        xk.trangthai = "CHUACHUYENHET";
        xk.ngaycapnhat = DateTime.Now;

        db.SaveChanges();
        return id_new;
    }

    //nhap kho
    public string nhap_kho(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb nk, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_sanpham check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == nk.denkho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;
        if (sp == null)
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
        db.SaveChanges();
        return id_new;
    }

    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_nhapkhonb_cdh dh, md_nhapkhonb nk, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_giaodich giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = nk.denkho;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = dh.sl_nhap * nhanvoi;
        giao.ngaychuyen = DateTime.Now;
        giao.kieuchuyen = "Nhập kho";
        giao.dongnhapxuat = nk.sochungtu;
        //giao.dongkiemkho = "";
        //giao.dongvanchuyen = "";
        //giao.dongsanxuat = nk.sochungtu;

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

        if (dh.sl_nhap > 0)
        {
            db.SaveChanges();
        }
        return id_new;

    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PNK", 1);
        try
        {
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_nhapkhonb";
                VNN_Function.SetFormValue("sochungtu", sochungtu);
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
            string id = context.Request.Form["id"];
            md_nhapkhonb object_ = db.md_nhapkhonb.Where(p => p.md_nhapkhonb_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.trangthai != "SOANTHAO")
            {
                msg = "false#Lỗi:Đối tượng đã nhập kho";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_nhapkhonb";
                VNN_Function.SetFormValue("sochungtu", "VNN_notpost");
                VNN_Function.SetFormValue("nhaptu", "VNN_notpost");
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
            string ten_table = "md_nhapkhonb";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                md_nhapkhonb object_ = db.md_nhapkhonb.Where(p => p.md_nhapkhonb_id == id_del_).Take(1).FirstOrDefault();
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
					foreach(md_lenhsanxuat_tosx_cdh lsx_to_cdh in db.md_lenhsanxuat_tosx_cdh.Where(s=>s.md_lenhsanxuat_tosx_id == object_.md_lenhsanxuat_tosx_id)) {
						md_nhapkhonb_cdh nknb_cdh = db.md_nhapkhonb_cdh.Where(s=>s.md_nhapkhonb_id == object_.md_nhapkhonb_id & s.md_sanpham_id == lsx_to_cdh.md_sanpham_id).Take(1).FirstOrDefault();
						if(nknb_cdh != null)
							lsx_to_cdh.sl_dahoanthanh -= nknb_cdh.tong_sl_dat;
					}
					db.md_nhapkhonb.Remove(object_);
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