<%@ WebHandler Language="C#" Class="JQGridMD_02_PhieuXuatKhoVTModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_PhieuXuatKhoVTModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA01XuatKhoNB_MD02PhieuXuatKhoVT":
                this.CA01XuatKhoNB_MD02PhieuXuatKhoVT(context);
                break;
            default:
                break;
        }
    }

    public void CA01XuatKhoNB_MD02PhieuXuatKhoVT(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PXK", 1);
        try
        {
            //Xu Ly nhap kho
            foreach (md_xuatkhonb px in db.md_xuatkhonb.Where(s => vnn.Contains(s.md_xuatkhonb_id)))
            {
                if (px.trangthai == "HIEULUC")
                {
                    msg = "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" đã hiệu lực.</div>";
                    break;
                }

                var check_kho = db.md_xuatkhonb_cdh.Where(s => s.check_kho == true & s.md_xuatkhonb_id == px.md_xuatkhonb_id);
                var check_ma = db.md_xuatkhonb_cdh.Where(s => s.md_sanpham_id != null & s.md_xuatkhonb_id == px.md_xuatkhonb_id);
                string soluong_xuat = "0";
                foreach (md_xuatkhonb_cdh dh in db.md_xuatkhonb_cdh.Where(s => s.md_xuatkhonb_id == px.md_xuatkhonb_id))
                {
                    md_kho_sanpham kho = db.md_kho_sanpham.Where(s => s.md_kho_id == px.tukho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
                    decimal nhanvoi = 1;
                    md_donvitinhsanpham_cddv dvtsp_cddv = db.md_donvitinhsanpham_cddv.Where(s => s.md_donvitinhsanpham_id == dh.md_donvitinhsanpham_id
                    & s.md_dvtsp_id == sp.md_donvitinhsanpham_id).Take(1).FirstOrDefault();
                    if (dvtsp_cddv != null)
                        nhanvoi = dvtsp_cddv.nhanvoi.Value;

                    if (dh.check_kho != true)
                    {
                        if (px.tukho == null & px.xuatden == null | px.tukho == "" & px.xuatden == "")
                        {
                            msg += "<div style='color:red'>Lỗi: dòng \"" + px.sochungtu + "\" chưa có kho hoặc phân xưởng đến.</div>";
                        }
                        else if (kho == null)
                        {
                            msg += "<div style='color:red'>Lỗi: \"" + sp.ma_sanpham + "\" không có trong kho.</div>";
                        }
                        else if (dh.sl_xuat <= 0)
                        {
                            msg += "<div style='color:red'>Lỗi: Số lượng xuất của \"" + sp.ma_sanpham + "\" phải lớn hơn 0 .</div>";
                        }
                        else if (kho.soluong < dh.sl_xuat)
                        {
                            msg += "<div style='color:red'>Lỗi: Số lượng \"" + sp.ma_sanpham + "\" trong kho chỉ còn: \"" + kho.soluong + "\" .</div>";
                        }
                    }

                    if (msg.Length <= 0)
                    {
                        if (dh.check_kho != true)
                        {
                            soluong_xuat = "" + VNN_VariablePublic.autoRound(dh.sl_xuat.Value, 4);
                            //--cap nhat so luong xuat
                            edit_xuat(db, dh, us);
                            //--cap nhat vao kho
                            xuat_kho(db, dh, px, nhanvoi, us);
                            //--tao lich su nhap kho
                            add_kho_ls(db, dh, px, nhanvoi, us);
                            msg_success += "<div style='color:blue'>\"" + sp.ma_sanpham + "\" đã xuất kho thành công, số lượng xuất là: \"" + soluong_xuat + "\"</div>";
                        }
                    }
                }

                //Kiem tra de chuyen thanh Hieu Luc
                if (msg.Length <= 0)
                {
                    if (check_kho.Count() == check_ma.Count())
                    {
                        px.trangthai = "HIEULUC";
                        db.SaveChanges();
                    }
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
    public string edit_xuat(EntityContext db, md_xuatkhonb_cdh dh, User_TK us)
    {
        string id_new = dh.md_xuatkhonb_id;
        md_xuatkhonb xk = db.md_xuatkhonb.Where(s => s.md_xuatkhonb_id == dh.md_xuatkhonb_id).FirstOrDefault();
        if (dh.tong_sl_xuat == dh.sl_daxuat + dh.sl_xuat)
        {
            dh.check_kho = true;
        }
        md_lenhsanxuat_vattu vattu = db.md_lenhsanxuat_vattu.Where(s => s.md_sanpham_id == dh.md_sanpham_id & s.md_lenhsanxuat_id == xk.md_lenhsanxuat_id).FirstOrDefault();
        dh.sl_daxuat = dh.sl_xuat + dh.sl_daxuat;
        dh.ngaycapnhat = DateTime.Now;

        vattu.sl_daxuat = dh.sl_daxuat;
        xk.trangthai = "CHUACHUYENHET";
        xk.ngaycapnhat = DateTime.Now;

        db.SaveChanges();
        return id_new;
    }

    //xuat kho
    public string xuat_kho(EntityContext db, md_xuatkhonb_cdh dh, md_xuatkhonb px, decimal nhanvoi, User_TK us)
    {
        string id_new = dh.md_xuatkhonb_id;
        md_kho_sanpham check_khosp = db.md_kho_sanpham.Where(s => s.md_kho_id == px.tukho & s.md_sanpham_id == dh.md_sanpham_id).FirstOrDefault();
        md_kho_sanpham sp = check_khosp;

        id_new = sp.md_kho_sanpham_id;
        sp.soluong = sp.soluong - (dh.sl_xuat * nhanvoi);
        sp.ngaycapnhat = DateTime.Now;
        db.SaveChanges();
        return id_new;
    }
    //--tao lich su nhap kho
    public string add_kho_ls(EntityContext db, md_xuatkhonb_cdh dh, md_xuatkhonb px, decimal nhanvoi, User_TK us)
    {
        string id_new = Helper.getNewId();
        md_kho_giaodich giao = new md_kho_giaodich();
        giao.md_kho_giaodich_id = id_new;
        giao.md_kho_id = px.tukho;
        giao.md_sanpham_id = dh.md_sanpham_id;
        giao.soluong_dichchuyen = (dh.sl_xuat * nhanvoi);
        giao.ngaychuyen = DateTime.Now;
        giao.kieuchuyen = "Xuất kho";
        giao.dongnhapxuat = px.sochungtu;
        //giao.dongkiemkho = "";
        //giao.dongvanchuyen = "";
        //giao.dongsanxuat = px.sochungtu;

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

        //tra sl_dat e gia tri
        dh.sl_xuat = 0;
        db.SaveChanges();
        return id_new;
    }
    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string sochungtu = VNN_VariablePublic.sochungtu(db, "PXK", 1);
        string id = context.Request.Form["id"];
        try
        {
            string id_ = context.Request.Form["id_parent"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_xuatkhonb";
                //VNN_Function.SetFormValue("md_doitackinhdoanh_id", dtk.md_doitackinhdoanh_id);
                //VNN_Function.SetFormValue("diachi", dtk.diachi);
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
        //string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        try
        {
            //md_doitackinhdoanh dtk = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).FirstOrDefault();
            string id = context.Request.Form["id"];
            md_xuatkhonb object_ = db.md_xuatkhonb.Where(p => p.md_xuatkhonb_id == id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (object_.trangthai != "SOANTHAO")
            {
                msg = "false#Lỗi:Đối tượng đã xuất kho";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_xuatkhonb";
                //VNN_Function.SetFormValue("md_doitackinhdoanh_id", dtk.md_doitackinhdoanh_id);
                //VNN_Function.SetFormValue("diachi", dtk.diachi);
                VNN_Function.SetFormValue("sochungtu", "VNN_notpost");
                VNN_Function.SetFormValue("xuatden", "VNN_notpost");
                //VNN_Function.SetFormValue("sochungtu", "VNN_notpost");
                //VNN_Function.SetFormValue("sochungtu", "VNN_notpost");
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
            string ten_table = "md_xuatkhonb";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                md_xuatkhonb object_ = db.md_xuatkhonb.Where(p => p.md_xuatkhonb_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "<br>";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "Lỗi:\""+ object_.sochungtu +"\" đã hiệu lực ";
                    msg += msg_del + "<br>";
                }
				else if(db.md_vanchuyennoibo.Where(s=>s.chungtuthamchieu == object_.sochungtu).Count() > 0) {
					msg_del = "Lỗi:\""+ object_.sochungtu +"\" có phiếu vận chuyển nội bộ đang sử dụng, không thể xóa dòng này.";
                    msg += msg_del + "<br>";
				}

                if (msg_del.Length <= 0)
                {
                    foreach (md_lenhsanxuat dmh in db.md_lenhsanxuat.Where(s => s.phieuXK == object_.sochungtu))
                    {
                        dmh.phieuXK = " ";
                    }

                    foreach (md_lenhsanxuat_tosx_cdh lsx_to_cdh in db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == object_.md_lenhsanxuat_tosx_id))
                    {
                        md_xuatkhonb_sanpham xknb_sp = db.md_xuatkhonb_sanpham.Where(s => s.md_xuatkhonb_id == object_.md_xuatkhonb_id & s.md_sanpham_id == lsx_to_cdh.md_sanpham_id).FirstOrDefault();
                        if (xknb_sp != null)
                            lsx_to_cdh.sl_tinhvattu += xknb_sp.soluong;
                    }

                    foreach (md_nhapkhonb nknb in db.md_nhapkhonb.Where(s => s.md_xuatkhonb_id == object_.md_xuatkhonb_id))
                    {
                        nknb.md_xuatkhonb_id = null;
                    }
                    db.md_xuatkhonb.Remove(object_);
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