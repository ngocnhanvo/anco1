<%@ WebHandler Language="C#" Class="JQGridMD_01_CDHDXuatKModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_CDHDXuatKModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_CapnhatSLXBan":
                this.CA_01_CapnhatSLXBan(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_CapnhatSLXBan(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        foreach (var xb_cdh in db.md_xuatban_cdh.Where(s => vnn.Contains(s.md_xuatban_cdh_id)).ToList())
        {
            var vcnb = db.md_xuatban.Where(s => s.md_xuatban_id == xb_cdh.md_xuatban_id).FirstOrDefault();
            if(vcnb.trangthai == "HIEULUC")
            {
                msg = "<div style='color:red'>Lỗi:Dòng " + vcnb.sochungtu + " đã Hiệu lực.</div>";
                break;
            }
            else {
                decimal sltd = xb_cdh.tong_sl_xuat.Value - xb_cdh.sl_daxuat.Value;
                if (sel_val == "0")
                {
                    xb_cdh.sl_xuat = sltd;
                }
                else {
                    if (slvc_case <= sltd)
                    {
                        xb_cdh.sl_xuat = slvc_case;
                    }
                    else
                    {
                        var sp = db.md_sanpham.Where(s => s.md_sanpham_id == xb_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                        msg = "<div style='color:red'>Lỗi: Dòng \"" + sp.ma_sanpham + "\" chỉ có thể chuyển tối đa là: " + sltd.DropTrailingZeros() + "</div>";
                        break;
                    }
                }
            }
        }
        if (msg.Length <= 0)
        {
            msg = "<div style='color:blue'>Cập nhật số lượng dự kiến xuất kho thành công</div>";
            db.SaveChanges();
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_sanpham = context.Request.Form["md_sanpham_id"];
        string md_donvitinhsanpham_id = context.Request.Form["md_donvitinhsanpham_id"];

        decimal nhanvoi = 1, saiso = 0;
        try
        {
            string ghichu_donvi2 = "";
            string id = context.Request.Form["id_parent"];
            decimal sl_xuat = decimal.Parse(context.Request.Form["sl_xuat"]);
            var sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
            var nb = db.md_xuatban.Where(s => s.md_xuatban_id == id).FirstOrDefault();

            var nht = db.md_xuatban_cdh.Where(s => s.md_xuatban_id == id & s.md_sanpham_id == sp.md_sanpham_id).FirstOrDefault();
            var kho_sp = db.md_kho_sanpham.Where(s => s.md_sanpham_id == sp.md_sanpham_id).FirstOrDefault();
            if (nb.trangthai == "HIEULUC")
            {
                msg = "false#Lỗi: Số chứng từ : " + nb.sochungtu + " đã hiệu lực,";
            }
            else if (sp == null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" không tồn tại.";
            }
            else if (nht != null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" đã tồn tại.";
            }
            else if(kho_sp == null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" không có trong kho.";
            }
            else if(kho_sp.soluong < sl_xuat)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" số lượng trong kho không đủ.";
            }
            else if (sl_xuat < 0)
            {
                msg = "false#Lỗi: Số lượng xuất phải lớn hơn 0";
            }
            else if (sp.md_donvitinhsanpham_id != md_donvitinhsanpham_id)
            {
                var dvtsp_cddv = db.md_donvitinhsanpham_cddv.Where(s => s.md_donvitinhsanpham_id == md_donvitinhsanpham_id
                & s.md_dvtsp_id == sp.md_donvitinhsanpham_id & s.md_sanpham_id == sp.ma_sanpham).Take(1).FirstOrDefault();
                if (dvtsp_cddv != null){
                    string ten_dvt = db.md_donvitinhsanpham.Where(s=>s.md_donvitinhsanpham_id == md_donvitinhsanpham_id).Select(s=>s.ten_dvt).FirstOrDefault();
                    string ten_dvt2 = db.md_donvitinhsanpham.Where(s=>s.md_donvitinhsanpham_id == sp.md_donvitinhsanpham_id).Select(s=>s.ten_dvt).FirstOrDefault();
                    nhanvoi = dvtsp_cddv.nhanvoi.Value;
                    saiso = dvtsp_cddv.chiacho.Value * sl_xuat;
                    if(saiso > dvtsp_cddv.saiso_toida.Value | saiso < 0)
                        saiso = dvtsp_cddv.saiso_toida.Value;
                    ghichu_donvi2 += "Xuất " + sl_xuat + " " + ten_dvt;
                    ghichu_donvi2 += "\n => 1 " + ten_dvt + " = " + nhanvoi.DropTrailingZeros() + " " + ten_dvt2;
                    ghichu_donvi2 += " (Sai số cho phép: " + dvtsp_cddv.chiacho.Value.DropTrailingZeros() + " " + ten_dvt2 + ")";
                    ghichu_donvi2 += "\n => "+ sl_xuat +" " + ten_dvt + " = " + (sl_xuat * nhanvoi).DropTrailingZeros() + " " + ten_dvt2;
                    ghichu_donvi2 += " (Sai số cho phép: " + saiso.DropTrailingZeros() + " " + ten_dvt2 + ")";
                }
                else {
                    msg = "false#Đơn vị tính đã chọn không thể quy đổi.";
                }
            }

            sl_xuat = sl_xuat * nhanvoi;
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "md_xuatban_id", "md_donvitinhsanpham_id2", "sl_xuat2", "saiso" };
                string ten_table = "md_xuatban_cdh";
                VNN_Function.SetFormValue("md_xuatban_id", id);
                VNN_Function.SetFormValue("ghichu_donvi2", ghichu_donvi2);
                VNN_Function.SetFormValue("tong_sl_xuat", sl_xuat.ToString());
                VNN_Function.SetFormValue("sl_xuat", sl_xuat.ToString());
                VNN_Function.SetFormValue("sl_xuat2", (sl_xuat * nhanvoi).ToString());
                VNN_Function.SetFormValue("saiso", saiso.ToString());
                VNN_Function.SetFormValue("md_donvitinhsanpham_id", sp.md_donvitinhsanpham_id);
                VNN_Function.SetFormValue("md_donvitinhsanpham_id2", sp.md_donvitinhsanpham_id);
                VNN_Function.SetFormValue("md_sanpham_id", sp.md_sanpham_id);
                VNN_Function.SetFormValue("tenhang", sp.mota_tiengviet);
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
        decimal tong_sl_xuat = decimal.Parse(context.Request.Form["tong_sl_xuat"]);
        decimal sl_xuat = decimal.Parse(context.Request.Form["sl_xuat"]);
        string md_donvitinhsanpham_id = context.Request.Form["md_donvitinhsanpham_id"];
        decimal nhanvoi = 1, saiso = 0;
        try
        {
            string id = context.Request.Form["id"];
            var object_ = db.md_xuatban_cdh.Where(p => p.md_xuatban_cdh_id == id).Take(1).FirstOrDefault();
            var xnb = db.md_xuatban.Where(p => p.md_xuatban_id == object_.md_xuatban_id).Take(1).FirstOrDefault();
            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == object_.md_sanpham_id).FirstOrDefault();
            string ghichu_donvi2 = "";
            string ten_dvt = db.md_donvitinhsanpham.
                    Where(s=>s.md_donvitinhsanpham_id == md_donvitinhsanpham_id).Select(s=>s.ten_dvt).FirstOrDefault();
            string ten_dvt2 = db.md_donvitinhsanpham.
                    Where(s=>s.md_donvitinhsanpham_id == object_.md_donvitinhsanpham_id).Select(s=>s.ten_dvt).FirstOrDefault();

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (sl_xuat <= 0)
            {
                msg = "false#Số lượng xuất phải lớn hớn 0";
            }
            else if (object_.md_donvitinhsanpham_id != md_donvitinhsanpham_id)
            {
                var dvtsp_cddv = db.md_donvitinhsanpham_cddv.
                        Where(s =>
                            s.md_donvitinhsanpham_id == md_donvitinhsanpham_id
                            & s.md_dvtsp_id == sp.md_donvitinhsanpham_id
                            & s.md_sanpham_id == sp.ma_sanpham
                        ).Take(1).FirstOrDefault();

                if (dvtsp_cddv != null)
                {
                    nhanvoi = dvtsp_cddv.nhanvoi.Value;
                    saiso = dvtsp_cddv.chiacho.Value * sl_xuat;
                    if (saiso > dvtsp_cddv.saiso_toida.Value | saiso < 0)
                        saiso = dvtsp_cddv.saiso_toida.Value;
                    ghichu_donvi2 += "=> 1 " + ten_dvt + " = " + nhanvoi.DropTrailingZeros() + " " + ten_dvt2;
                    ghichu_donvi2 += " (Sai số cho phép: " + dvtsp_cddv.chiacho.Value.DropTrailingZeros() + " " + ten_dvt2 + ")";
                    if (sl_xuat > 1)
                    {
                        ghichu_donvi2 += "\n=> " + sl_xuat + " " + ten_dvt + " = " + (sl_xuat * nhanvoi).DropTrailingZeros() + " " + ten_dvt2;
                        ghichu_donvi2 += " (Sai số cho phép: " + saiso.DropTrailingZeros() + " " + ten_dvt2 + ")";
                    }
                }
                else
                {
                    msg = "false#Đơn vị tính đã chọn không thể quy đổi.";
                }
            }

            if ((sl_xuat * nhanvoi - saiso) > object_.tong_sl_xuat)
            {
                msg = string.Format(@"false#Chỉ có thể xuất số lượng tối đa là: ""{0} {1}""",
                    object_.tong_sl_xuat.Value.DropTrailingZeros(), ten_dvt2);
                msg += string.Format(@"<br> + Số lượng đang muốn xuất: ""{0} {1}""",
                    (sl_xuat * nhanvoi).DropTrailingZeros(), ten_dvt2);
                msg += string.Format(@"<br> + Độ sai lệch cho phép: ""{0} {1}""",
                    saiso.DropTrailingZeros(), ten_dvt2);
            }

            foreach (var ncc in db.md_xuatban.Where(s => s.md_xuatban_id == object_.md_xuatban_id).ToList())
            {
                if (ncc.trangthai == "HIEULUC")
                {
                    msg = "false#Phiếu xuất kho đã hiệu lực !";
                }
            }
            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { "sl_xuat2", "saiso" };
                string ten_table = "md_xuatban_cdh";
                VNN_Function.SetFormValue("ghichu_donvi2", ghichu_donvi2);
                VNN_Function.SetFormValue("md_sanpham_id", "VNN_notpost");
                VNN_Function.SetFormValue("tenhang", "VNN_notpost");
                VNN_Function.SetFormValue("sl_xuat", sl_xuat.ToString());
                VNN_Function.SetFormValue("sl_xuat2", (sl_xuat*nhanvoi).ToString());
                VNN_Function.SetFormValue("sl_muonxuat", "VNN_notpost");
                VNN_Function.SetFormValue("saiso", saiso.ToString());

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
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                var object_ = db.md_xuatban_cdh.Where(p => p.md_xuatban_cdh_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "<br>";
                }
                else {
                    var nb = db.md_xuatban.Where(s => s.md_xuatban_id == object_.md_xuatban_id).FirstOrDefault();
                    var xnb_cdhs = from a in db.md_vanchuyennoibo_cdvc
                                   join b in db.md_vanchuyennoibo on a.md_vanchuyennoibo_id equals b.md_vanchuyennoibo_id
                                   where  b.chungtuthamchieu == nb.sochungtu & a.md_sanpham_id == object_.md_sanpham_id
                                   select new { a.md_vanchuyennoibo_cdvc_id };
                    if (nb.trangthai == "HIEULUC") {
                        msg_del = "false#Lỗi: Số chứng từ : " + nb.sochungtu + " đã hiệu lực,";
                        msg += msg_del + "<br>";
                    }
                    else if(xnb_cdhs.Count() > 0) {
                        msg_del = "Lỗi:\""+ nb.sochungtu +"\" có phiếu vận chuyển nội bộ đang sử dụng dòng hàng này.";
                        msg += msg_del + "<br>";
                    }
                }

                if (msg_del.Length <= 0)
                {
                    db.md_xuatban_cdh.Remove(object_);
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