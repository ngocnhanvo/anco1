<%@ WebHandler Language="C#" Class="JQGridMD_02_TSXcacdonghangModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_02_TSXcacdonghangModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "load_sanpham":
                this.load_sanpham(context);
                break;
            case "CA_01_CapnhatSPtrongToSX":
                this.CA_01_CapnhatSPtrongToSX(context);
                break;
            case "CA_01_BoSungSLChiaTo":
                this.CA_01_BoSungSLChiaTo(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_BoSungSLChiaTo(HttpContext context)
    {
        var db = new EntityContext();
        string sl_bosung = context.Request.Form["sl_bosung"];
        string id_parent = context.Request.Form["id_parent"];
        string id = context.Request.Form["id"];
        string msg= "";
        var lsx_tosx_cdh = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_cdh_id == id).Take(1).FirstOrDefault();
        var lsx_tosx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id_parent).Take(1).FirstOrDefault();
        var lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == lsx_tosx.md_lenhsanxuat_id).Take(1).FirstOrDefault();
        var dhpx_cdh = db.md_dondathangphanxuong_cdh.Where(s =>
            s.md_sanpham_id == lsx_tosx_cdh.md_sanpham_id &
            s.md_dondathangphanxuong_id == lsx.md_dondathangphanxuong_id
        ).Take(1).FirstOrDefault();

        decimal soluong_bosung = 0, sl_gioihan = dhpx_cdh.tong_sl_dat.Value - dhpx_cdh.sl_chiato.Value;
        try {
            soluong_bosung = decimal.Parse(sl_bosung);
        }
        catch {
            soluong_bosung = -1;
        }
        if (soluong_bosung > sl_gioihan) {
            if(sl_gioihan == 0)
                msg = "Lỗi: Dòng đang chọn không thể bổ sung thêm số lượng chia tổ.";
            else
                msg = "Lỗi: Dòng đang chọn chỉ có thể bổ sung tối đa là: \"" + sl_gioihan + "\"";
        } else if (soluong_bosung == 0) {
            msg = "Lỗi: Số lượng bổ sung phải lớn hơn 0";
        } else if (soluong_bosung < 0) {
            msg = "Lỗi: Số lượng bổ sung không phải là số.";
        }
        else {
            lsx_tosx_cdh.sl_chiato += soluong_bosung;
            dhpx_cdh.sl_chiato += soluong_bosung;
            lsx_tosx_cdh.sl_tinhvattu += soluong_bosung;
            db.SaveChanges();
            msg = "<div style='color:blue'>Bổ sung số lượng chia tổ thành công.</div>";
        }
        context.Response.Write(msg);
    }

    public void load_sanpham(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string id = context.Request.QueryString["id_parent"];
        string html = "";
        md_lenhsanxuat_tosx lsx_tosx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).Take(1).FirstOrDefault();
        md_lenhsanxuat lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == lsx_tosx.md_lenhsanxuat_id).Take(1).FirstOrDefault();
        var md_lenhsanxuat_tosx_cdh = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == id);
        int taophieu_xuatkho = db.md_xuatkhonb.Where(s=>s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id).Count();
        if(taophieu_xuatkho <= 0) {
            taophieu_xuatkho = db.md_nhapkhonb.Where(s=>s.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id).Count();
        }
        html += "<table style='width:100%;border: 1px solid #3A3535;background-color: #A2CBFF;'>";
        html += "<tr><td style='width:20px'><input type='button' class='btn_slchiato' value='Chọn' /></td><td>SL chia tổ = SL đặt hàng</td></tr>";
        html += "<tr><td><input type='button' class='btn_slchiato1' value='Chọn'/></td><td>SL chia tổ = <input class='input_soluong input_sl_chiato2' style='width:80px;text-align:right;' type='text' value='0'/></td></tr>";
        html += "</table>";

        html += "<table style='width:100%'>";
        html += "<tr><th style='border: 1px solid #E3D892;'><input type='checkbox' class='checkall_slchiato' name='checkall_slchiato' /></th><th>Mã sản phẩm</th><th>SL đặt hàng</th><th>SL chia tổ</th></tr>";
        var sp_dhpx = from a in db.md_lenhsanxuat_tosx_cdh
                      join b in db.md_sanpham on a.md_sanpham_id equals b.md_sanpham_id
                      where a.md_lenhsanxuat_tosx_id == lsx_tosx.md_lenhsanxuat_tosx_id
                      select new { b.md_sanpham_id, b.ma_sanpham, a.sl_dat, a.sl_giamhanngach, a.sl_chiato };

        foreach (var sp in sp_dhpx.OrderBy(s => s.ma_sanpham).ToList())
        {
            var lsx_tosx_cdh = md_lenhsanxuat_tosx_cdh.Where(s => s.md_sanpham_id == sp.md_sanpham_id).Take(1).FirstOrDefault();
            string checked_ = "";
            decimal sl_chiato = 0, sl_danhapkho = 0;
            if (lsx_tosx_cdh != null)
            {
                checked_ = "checked";
                sl_chiato = lsx_tosx_cdh.sl_chiato.Value;
                sl_danhapkho = lsx_tosx_cdh.sl_danhapkho.Value;
            }
            html += "<tr>";
            if(sl_danhapkho > 0 | taophieu_xuatkho > 0)
                html += "<td style='text-align:center;'><input class='chk_tosx nhan_disable' disabled type='checkbox' " + checked_ + " value='" + sp.md_sanpham_id + "' /></td>";
            else
                html += "<td style='text-align:center;'><input class='chk_tosx' type='checkbox' " + checked_ + " value='" + sp.md_sanpham_id + "' /></td>";

            html += "<td style='text-align:center;color:blue'>" + sp.ma_sanpham + "</td>";
            html += "<td style='text-align:center;color:blue'>" + (sp.sl_dat - sp.sl_giamhanngach.GetValueOrDefault(0)).Value.DropTrailingZeros() + "</td>";

            if(sl_danhapkho > 0 | taophieu_xuatkho > 0)
                html += "<td><input disabled class='nhan_disable input_soluong input_" + sp.md_sanpham_id + "' style='width:90px;text-align:right;' type='text' value='" + Math.Round(sl_chiato, 0) + "'/></td>";
            else
                html += "<td><input class='input_soluong input_" + sp.md_sanpham_id + "' style='width:90px;text-align:right;' type='text' value='" + Math.Round(sl_chiato, 0) + "'/></td>";

            html += "</tr>";
        }
        html += "</table>";
        context.Response.Write(html);
    }

    public void CA_01_CapnhatSPtrongToSX(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string[] vnn = context.Request.Form["id_sel"].Split(',');
        string[] vnn_slchiato = context.Request.Form["value_slchiato"].Split(',');
        string id = context.Request.Form["id"];
        string msg = "";
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        md_lenhsanxuat_tosx lsx_tosx = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).Take(1).FirstOrDefault();
        md_lenhsanxuat lsx = db.md_lenhsanxuat.Where(s => s.md_lenhsanxuat_id == lsx_tosx.md_lenhsanxuat_id).Take(1).FirstOrDefault();
        int sx = db.md_lenhsanxuat_tosx_cdh.Where(s => s.sl_dahoanthanh > 0 & s.md_lenhsanxuat_tosx_id == lsx_tosx.md_lenhsanxuat_tosx_id).Count();
        if (lsx.md_trangthai_id == "HOANTHANH" | lsx.md_trangthai_id == "DAXL" |lsx.md_trangthai_id == "KETTHUC" )
        {
            msg = "<div style='color:red'>Lệnh sản xuất \"" + lsx.sochungtu + "\" đã xử lý, không thể chỉnh sửa.</div>";
        }
        else if(sx > 0)
        {
            msg = "<div style='color:red'>Lệnh sản xuất \"" + lsx.sochungtu + "\" có sản phẩm đã hoàn thành, không thể chỉnh sửa.</div>";
        }

        if (msg.Length <= 0)
        {
            var md_lenhsanxuat_tosx_cdh = db.md_lenhsanxuat_tosx_cdh.Where(s => s.md_lenhsanxuat_tosx_id == id);
            foreach (md_lenhsanxuat_tosx_cdh lsx_tsx_cdh in md_lenhsanxuat_tosx_cdh.ToList())
            {
                db.md_lenhsanxuat_tosx_cdh.Remove(lsx_tsx_cdh);
            }

            for (int i = 0; i < vnn.Length; i++)
            {
                string vnnI = vnn[i];
                var sp = db.md_sanpham.Where(s => s.md_sanpham_id == vnnI).Take(1).FirstOrDefault();
                if (sp != null)
                {
                    md_dondathangphanxuong_cdh dhpx_cdh = db.md_dondathangphanxuong_cdh.Where(s => s.md_sanpham_id == sp.md_sanpham_id & s.md_dondathangphanxuong_id == lsx.md_dondathangphanxuong_id).Take(1).FirstOrDefault();
                    decimal sl_chiato = 0, sl_gioihan = dhpx_cdh.tong_sl_dat.Value - dhpx_cdh.sl_chiato.Value;
                    try { sl_chiato = decimal.Parse(vnn_slchiato[i]); } catch { sl_chiato = -1; }
                    if (sl_chiato > sl_gioihan)
                    {
                        msg = "Lỗi: Sản phẩm \"" + sp.ma_sanpham + "\" chỉ có thể chia tối đa là: \"" + sl_gioihan + "\"";
                        break;
                    }
                    else if (sl_chiato == 0)
                    {
                        msg = "Lỗi: Sản phẩm \"" + sp.ma_sanpham + "\" phải chia số lượng lớn hơn 0";
                        break;
                    }
                    else if (sl_chiato < 0)
                    {
                        msg = "Lỗi: Sản phẩm \"" + sp.ma_sanpham + "\", số lượng chia không phải là số.";
                        break;
                    }

                    string macuoi = dhpx_cdh.macuoi;
                    dhpx_cdh.sl_chiato += sl_chiato;
                    md_lenhsanxuat_tosx_cdh lsx_tosx_cdh = new md_lenhsanxuat_tosx_cdh()
                    {
                        md_lenhsanxuat_tosx_cdh_id = Helper.getNewId(),
                        md_lenhsanxuat_tosx_id = lsx_tosx.md_lenhsanxuat_tosx_id,
                        md_sanpham_id = dhpx_cdh.md_sanpham_id,
                        noigiaohang = dhpx_cdh.noigiaohang,
                        sl_dat = dhpx_cdh.tong_sl_dat,
                        sl_chiato = sl_chiato,
                        sl_tinhvattu = sl_chiato,
                        sl_hoanthanh = 0,
                        sl_dahoanthanh = 0,
                        sl_nhapkho = 0,
                        sl_danhapkho = 0,
                        macuoi = macuoi,
                        md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
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
                    db.md_lenhsanxuat_tosx_cdh.Add(lsx_tosx_cdh);
                }
            }

            if (msg.Length <= 0)
            {


                //db.md_lenhsanxuat_vattu.RemoveRange(db.md_lenhsanxuat_vattu.Where(s=>s.md_lenhsanxuat_tosx_id == lsx_tosx.md_lenhsanxuat_tosx_id));
                db.SaveChanges();
                var cdhsx = from a in db.md_lenhsanxuat_tosx_cdh
                            join b in db.md_lenhsanxuat_tosx on a.md_lenhsanxuat_tosx_id equals b.md_lenhsanxuat_tosx_id
                            where b.md_lenhsanxuat_id == lsx.md_lenhsanxuat_id
                            select new { a.md_lenhsanxuat_tosx_cdh_id };
                if(cdhsx.Count() > 0)
                    lsx.md_trangthai_id = "CHUAHOANTHANH";
                else
                    lsx.md_trangthai_id = "CHUAHOANTHANH";
                db.SaveChanges();
                msg = "<div style='color:blue'>Chia tổ cho lệnh sản xuất \"" + lsx.sochungtu + "\" thành công.</div>";
            }
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
            string id = context.Request.Form["id"];
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { };
                string ten_table = "md_lenhsanxuat_tosx_cdh";
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        string mathaydoi = context.Request.Form["mathaydoi"];
        string mota = context.Request.Form["mota"];
        string id = context.Request.Form["id"];
        md_sanpham spmoi = null;
        try
        {
            var object_ = db.md_lenhsanxuat_tosx_cdh.Where(p => p.md_lenhsanxuat_tosx_cdh_id == id).Take(1).FirstOrDefault();

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else
            {
                spmoi = db.md_sanpham.Where(s => s.ma_sanpham == mathaydoi).FirstOrDefault();
                if(!string.IsNullOrEmpty(mathaydoi) & spmoi == null)
                {
                    msg = "false#Không tìm thấy mã sản phẩm cần thay đổi";
                }
                else if(object_.md_donvitinhsanpham_id != spmoi.md_donvitinhsanpham_id)
                {
                    msg = "false#Không cùng đơn vị tính";
                }
            }

            if (msg.Length <= 0)
            {
                object_.mota = mota;
                object_.mathaydoi = mathaydoi;
                db.SaveChanges();
                VNN_Function.loaddulieu_Auto(db, ma_module);
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
            string ten_table = "md_lenhsanxuat_tosx_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.md_lenhsanxuat_tosx_cdh.Where(p => p.md_lenhsanxuat_tosx_cdh_id == id_del_).Select(s => s.md_lenhsanxuat_tosx_cdh_id).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    string action = "del";
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
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