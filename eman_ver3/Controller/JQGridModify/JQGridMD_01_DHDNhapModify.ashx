<%@ WebHandler Language="C#" Class="JQGridMD_01_DHDNhapModify" %>
using System;
using System.Web;
using System.Linq;
using System.Data.Linq;
using DataAcess;
public class JQGridMD_01_DHDNhapModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_CapnhatSLNKNB":
                this.CA_01_CapnhatSLNKNB(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_CapnhatSLNKNB(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string sel_val = context.Request.Form["sel_val"];
        decimal slvc_case = decimal.Parse(context.Request.Form["slvc_case"]);
        string[] vnn = context.Request.Form["id"].Split(',');
        string msg = "";
        foreach (md_nhapkhonb_cdh nknb_cdh in db.md_nhapkhonb_cdh.Where(s => vnn.Contains(s.md_nhapkhonb_cdh_id)))
        {
             md_nhapkhonb vcnb = db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id == nknb_cdh.md_nhapkhonb_id).FirstOrDefault();
            if(vcnb.trangthai == "HIEULUC")
            {
                msg = "<div style='color:red'>Lỗi:Dòng " + vcnb.sochungtu + " đã Hiệu lực.</div>";
                break;
            }
            else {
                decimal sltd = nknb_cdh.tong_sl_dat.Value - nknb_cdh.sl_danhap.Value;
                if (sel_val == "0")
                {
                    nknb_cdh.sl_nhap = sltd;
                }
                else {
                    if (slvc_case <= sltd)
                    {
                        nknb_cdh.sl_nhap = slvc_case;
                    }
                    else
                    {
                        md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == nknb_cdh.md_sanpham_id).Take(1).FirstOrDefault();
                        msg = "<div style='color:red'>Lỗi: Dòng \"" + sp.ma_sanpham + "\" chỉ có thể chuyển tối đa là: " + VNN_VariablePublic.autoRound(sltd, 4) + "</div>";
                        break;
                    }
                }
            }
        }
        if (msg == "")
        {
            msg = "<div style='color:blue'>Cập nhật số lượng dự kiến nhập kho thành công</div>";
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
			decimal sl_nhap = decimal.Parse(context.Request.Form["sl_nhap"]);
            md_sanpham sp = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).FirstOrDefault();
			md_nhapkhonb nb = db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id == id).FirstOrDefault();
            md_nhapkhonb_cdh nht = db.md_nhapkhonb_cdh.Where(s => s.md_nhapkhonb_id == id & s.md_sanpham_id == sp.md_sanpham_id).FirstOrDefault();
            if (sp == null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" không tồn tại.";
            }
			else if (nht != null)
            {
                msg = "false#Lỗi: Sản phâm \"" + ma_sanpham + "\" đã tồn tại.";
            }
            else if (nb.trangthai == "HIEULUC")
            {
                msg = "false#Lỗi: Số chứng từ : " + nb.sochungtu + " đã hiệu lực,";
            }
            else if (sl_nhap < 0)
            {
                msg = "false#Lỗi: Số lượng nhập phải lớn hơn 0";
            }
			else if (sp.md_donvitinhsanpham_id != md_donvitinhsanpham_id)
            {
                md_donvitinhsanpham_cddv dvtsp_cddv = db.md_donvitinhsanpham_cddv.Where(s => s.md_donvitinhsanpham_id == md_donvitinhsanpham_id
                & s.md_dvtsp_id == sp.md_donvitinhsanpham_id & s.md_sanpham_id == sp.ma_sanpham).Take(1).FirstOrDefault();
                if (dvtsp_cddv != null){
					string ten_dvt = db.md_donvitinhsanpham.Where(s=>s.md_donvitinhsanpham_id == md_donvitinhsanpham_id).Select(s=>s.ten_dvt).FirstOrDefault();
					string ten_dvt2 = db.md_donvitinhsanpham.Where(s=>s.md_donvitinhsanpham_id == sp.md_donvitinhsanpham_id).Select(s=>s.ten_dvt).FirstOrDefault();	
                    nhanvoi = dvtsp_cddv.nhanvoi.Value;
					saiso = dvtsp_cddv.chiacho.Value * nhanvoi;
					if(saiso > dvtsp_cddv.saiso_toida.Value | saiso < 0)
						saiso = dvtsp_cddv.saiso_toida.Value;
					ghichu_donvi2 += "Nhập " + sl_nhap + " " + ten_dvt;
                    ghichu_donvi2 += "\n => 1 " + ten_dvt + " = " + VNN_VariablePublic.autoRound(nhanvoi, 4) + " " + ten_dvt2;
					ghichu_donvi2 += " (Sai số cho phép: " + VNN_VariablePublic.autoRound(dvtsp_cddv.chiacho.Value, 4) + " " + ten_dvt2 + ")";
					ghichu_donvi2 += "\n => "+ sl_nhap +" " + ten_dvt + " = " + VNN_VariablePublic.autoRound(sl_nhap * nhanvoi, 4) + " " + ten_dvt2;
					ghichu_donvi2 += " (Sai số cho phép: " + VNN_VariablePublic.autoRound(saiso, 4) + " " + ten_dvt2 + ")";
				}
                else {
                    msg = "false#Đơn vị tính đã chọn không thể quy đổi.";
                }
            }
			
			sl_nhap = sl_nhap * nhanvoi;
            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "md_nhapkhonb_id" };
                string ten_table = "md_nhapkhonb_cdh";
                VNN_Function.SetFormValue("md_nhapkhonb_id", id);
				VNN_Function.SetFormValue("ghichu_donvi2", ghichu_donvi2);
				VNN_Function.SetFormValue("tong_sl_dat", sl_nhap.ToString());
				VNN_Function.SetFormValue("sl_nhap", sl_nhap.ToString());
				VNN_Function.SetFormValue("md_donvitinhsanpham_id", sp.md_donvitinhsanpham_id);
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
        decimal tong_sl_dat = decimal.Parse(context.Request.Form["tong_sl_dat"]);
        decimal sl_nhap = decimal.Parse(context.Request.Form["sl_nhap"]);
        string md_donvitinhsanpham_id = context.Request.Form["md_donvitinhsanpham_id"];
        decimal nhanvoi = 1, saiso = 0;
        try
        {
            string id = context.Request.Form["id"];
            md_nhapkhonb_cdh object_ = db.md_nhapkhonb_cdh.Where(p => p.md_nhapkhonb_cdh_id == id).Take(1).FirstOrDefault();
            md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == object_.md_sanpham_id).FirstOrDefault();
			string ghichu_donvi2 = "";
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }
            else if (sl_nhap < 0)
            {
                msg = "false#Số lượng xuất phải lớn hớn 0";
            }
			else if (sp.md_donvitinhsanpham_id != md_donvitinhsanpham_id)
            {
                md_donvitinhsanpham_cddv dvtsp_cddv = db.md_donvitinhsanpham_cddv.Where(s => s.md_donvitinhsanpham_id == md_donvitinhsanpham_id
                & s.md_dvtsp_id == sp.md_donvitinhsanpham_id & s.md_sanpham_id == sp.ma_sanpham).Take(1).FirstOrDefault();
                if (dvtsp_cddv != null){
					string ten_dvt = db.md_donvitinhsanpham.Where(s=>s.md_donvitinhsanpham_id == md_donvitinhsanpham_id).Select(s=>s.ten_dvt).FirstOrDefault();
					string ten_dvt2 = db.md_donvitinhsanpham.Where(s=>s.md_donvitinhsanpham_id == sp.md_donvitinhsanpham_id).Select(s=>s.ten_dvt).FirstOrDefault();					
					nhanvoi = dvtsp_cddv.nhanvoi.Value;
					saiso = dvtsp_cddv.chiacho.Value * sl_nhap;
					if(saiso > dvtsp_cddv.saiso_toida.Value | saiso < 0)
						saiso = dvtsp_cddv.saiso_toida.Value;
					ghichu_donvi2 += "Nhập " + sl_nhap + " " + ten_dvt;
                    ghichu_donvi2 += "\n => 1 " + ten_dvt + " = " + VNN_VariablePublic.autoRound(nhanvoi, 4) + " " + ten_dvt2;
					ghichu_donvi2 += " (Sai số cho phép: " + VNN_VariablePublic.autoRound(dvtsp_cddv.chiacho.Value, 4) + " " + ten_dvt2 + ")";
					ghichu_donvi2 += "\n => "+ sl_nhap +" " + ten_dvt + " = " + VNN_VariablePublic.autoRound(sl_nhap * nhanvoi, 4) + " " + ten_dvt2;
					ghichu_donvi2 += " (Sai số cho phép: " + VNN_VariablePublic.autoRound(saiso, 4) + " " + ten_dvt2 + ")";
				}
                else {
                    msg = "false#Đơn vị tính đã chọn không thể quy đổi.";
                }
            }
			
			sl_nhap = sl_nhap * nhanvoi;
			if ((sl_nhap - saiso) > object_.tong_sl_dat)
            {
                msg = "false#Chỉ có thể xuất số lượng tối đa là: \"" + VNN_VariablePublic.autoRound(object_.tong_sl_dat.Value, 4) + "\"";
				msg += "<br> + Số lượng đang muốn xuất: \""+ VNN_VariablePublic.autoRound(sl_nhap, 4) +"\"";
				msg += "<br> + Độ sai lệch cho phép: \""+ VNN_VariablePublic.autoRound(saiso, 4) +"\"";
            }
			
            foreach (md_nhapkhonb ncc in db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id == object_.md_nhapkhonb_id))
            {
                if (ncc.trangthai == "HIEULUC")
                {
                    msg = "false#Đơn hàng đã hiệu lực !";
                }
			}
			if (msg.Length <= 0)
			{
				string action = "edit";
				string[] column_ex = { };
				string ten_table = "md_nhapkhonb_cdh";
				VNN_Function.SetFormValue("ghichu_donvi2", ghichu_donvi2);
				VNN_Function.SetFormValue("md_sanpham_id", "VNN_notpost");
				VNN_Function.SetFormValue("tenhang", "VNN_notpost");
				VNN_Function.SetFormValue("sl_nhap", sl_nhap.ToString());
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
        string msg = "",  msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string ten_table = "md_nhapkhonb_cdh";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                 msg_del = ""; var id_del_ = id_del[i];
                md_nhapkhonb_cdh object_ = db.md_nhapkhonb_cdh.Where(p => p.md_nhapkhonb_cdh_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                md_nhapkhonb nb = db.md_nhapkhonb.Where(s => s.md_nhapkhonb_id == object_.md_nhapkhonb_id).FirstOrDefault();
                if (nb.trangthai == "HIEULUC")
                {
                    msg_del = "false#Lỗi: Số chứng từ : " + nb.sochungtu + " đã hiệu lực,";
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    string action = "del";
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_.md_nhapkhonb_cdh_id);
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