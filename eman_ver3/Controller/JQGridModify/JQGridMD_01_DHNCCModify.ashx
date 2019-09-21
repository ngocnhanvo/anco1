<%@ WebHandler Language="C#" Class="JQGridMD_01_DHNCCModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DHNCCModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_CapnhatSLNKNCC":
                this.CA_01_CapnhatSLNKNCC(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_CapnhatSLNKNCC(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        foreach (var nk_ncc_dh in db.md_nhapkho_ncc_dh.Where(s => vnn.Contains(s.md_nhapkho_ncc_dh_id)).ToList())
        {
            var vcnb = db.md_nhapkho_ncc.Where(s => s.md_nhapkho_ncc_id == nk_ncc_dh.md_nhapkho_ncc_id).FirstOrDefault();
            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == nk_ncc_dh.md_sanpham_id).Take(1).FirstOrDefault();
            if (vcnb.trangthai != "DANHAN")
            {
                msg = string.Format(@"<div style='color:red'>Lỗi:Dòng ""{0}"" không ở trạng thái ""Đã xác nhận"".</div>", vcnb.sochungtu);
                break;
            }
            else
            {
                decimal sltd = nk_ncc_dh.tong_sl_dat.Value - nk_ncc_dh.sl_danhap.Value;
                decimal tile = 1;
                if (sp.md_donvitinhsanpham_id != nk_ncc_dh.md_donvitinhsanpham_id)
                {
                    string idDMH = db.md_nhapkho_ncc.Where(s => s.md_nhapkho_ncc_id == nk_ncc_dh.md_nhapkho_ncc_id).Select(s => s.c_donmuahang_id).FirstOrDefault();
                    var donghang = db.c_donmuahang_cdmh.Where(s =>
                        s.c_donmuahang_id == idDMH &
                        s.md_sanpham_id == sp.md_sanpham_id).FirstOrDefault();
                    if (donghang != null)
                    {
                        tile = donghang.sl_dadat2.GetValueOrDefault(0) / donghang.sl_dadat.Value;
                    }
                    else
                    {
                        msg = "false#Không tìm thấy dòng mua hàng.";
                    }
                }

                if (sel_val == "0")
                {
                    nk_ncc_dh.sl_nhap = sltd;
                    //nk_ncc_dh.sl_muonnhap = sltd;
                    nk_ncc_dh.sl_nhap2 = nk_ncc_dh.sl_nhap * tile;
                }
                else
                {
                    if (slvc_case <= sltd)
                    {
                        nk_ncc_dh.sl_nhap = slvc_case;
                        //nk_ncc_dh.sl_muonnhap = slvc_case;
                        nk_ncc_dh.sl_nhap2 = nk_ncc_dh.sl_nhap * tile;
                    }
                    else
                    {
                        msg = "<div style='color:red'>Lỗi: Dòng \"" + sp.ma_sanpham + "\" chỉ có thể chuyển tối đa là: " + sltd.DropTrailingZeros() + "</div>";
                        break;
                    }
                }
            }
        }
        if (msg == "")
        {
            msg = "<div style='color:blue'>Cập nhật số lượng nhập kho thành công</div>";
            db.SaveChanges();
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
                string ten_table = "md_nhapkho_ncc_dh";
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
        var db = new EntityContext();
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        decimal tong_sl_dat = decimal.Parse(context.Request.Form["tong_sl_dat"]);
        decimal sl_nhap = decimal.Parse(context.Request.Form["sl_nhap"]);
        decimal sl_nhap2 = sl_nhap;
        
        try
        {
            string id = context.Request.Form["id"];
            var object_ = db.md_nhapkho_ncc_dh.Where(p => p.md_nhapkho_ncc_dh_id == id).Take(1).FirstOrDefault();
            var sp = db.md_sanpham.Where(s => s.md_sanpham_id == object_.md_sanpham_id).FirstOrDefault();
            var vcnb = db.md_nhapkho_ncc.Where(s => s.md_nhapkho_ncc_id == object_.md_nhapkho_ncc_id).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (vcnb.trangthai != "DANHAN")
            {
                msg = string.Format(@"false#Phiếu nhập kho không ở trạng thái ""Đã xác nhận""");
            }
            else if (sl_nhap < 0)
            {
                msg = "false#Số lượng nhập không được âm";
            }
            else if (sl_nhap > tong_sl_dat)
            {
                msg = "false#Số lượng thực nhập không được lớn hơn tổng số lượng";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { "sl_muonnhap2", "sl_nhap2" };
                string ten_table = "md_nhapkho_ncc_dh";
                VNN_Function.SetFormValue("md_sanpham_id", "VNN_notpost");
                VNN_Function.SetFormValue("tenhang", "VNN_notpost");
                VNN_Function.SetFormValue("sl_muonnhap", "VNN_notpost");
                VNN_Function.SetFormValue("sl_nhap", sl_nhap.ToString());
                VNN_Function.SetFormValue("sl_nhap2", sl_nhap2.ToString());
                VNN_Function.SetFormValue("md_donvitinhsanpham_id", "VNN_notpost");
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
            string ten_table = "md_nhapkho_ncc_dh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_nhapkho_ncc_dh object_ = db.md_nhapkho_ncc_dh.Where(p => p.md_nhapkho_ncc_dh_id == id_del_).Take(1).FirstOrDefault();
                md_nhapkho_ncc nk_ncc = null;
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else
                {
                    nk_ncc = db.md_nhapkho_ncc.Where(s => s.md_nhapkho_ncc_id == object_.md_nhapkho_ncc_id).Take(1).FirstOrDefault();
                    if (nk_ncc.phieuXNNK != null & nk_ncc.phieuXNNK != "")
                    {
                        msg_del = "Lỗi:Phiếu nhập kho \"" + nk_ncc.sochungtu + "\" đã in xác nhận nhập hàng, không thể chỉnh sửa.";
                        msg += msg_del + "\n";
                        break;
                    }
                }

                if (msg_del.Length <= 0)
                {

                    c_donmuahang_cdmh dmh_cdmh = db.c_donmuahang_cdmh.Where(s => s.md_sanpham_id == object_.md_sanpham_id & s.c_donmuahang_id == nk_ncc.c_donmuahang_id).Take(1).FirstOrDefault();
                    if (dmh_cdmh != null)
                        dmh_cdmh.sl_hanngach += object_.tong_sl_dat;

                    db.md_nhapkho_ncc_dh.Remove(object_);
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