 <%@ WebHandler Language="C#" Class="JQGridMD_00_DSHangHoaModify" %>
using System;
using System.Data;
using System.Web;
using System.Linq;
using System.Data.SqlClient;
using DataAcess;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;

public class JQGridMD_00_DSHangHoaModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    EntityContext db = new EntityContext();
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
            case "CA_01_UpdateHH":
                this.CA_01_UpdateHH(context);
                break;
            case "CA_01_UpdateXT":
                this.CA_01_UpdateXT(context);
                break;
            case "selectoption_px":
                this.selectoption_px(context);
                break;
            case "selectoption_to":
                this.selectoption_to(context);
                break;
            case "selectoption":
                this.selectoption(context);
                break;
            case "savefile":
                this.SaveFile(context);
                break;
            case "CA_01_ExportHH":
                this.CA_01_ExportHH(context);
                break;
            default:
                break;
        }
    }

    public void selectoption(HttpContext context)
    {
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "<select>";

        str += firstnull ? string.Format("<option px=\"\" value=\"\"></option>") : "";
        foreach (md_phanxuong_to cn in db.md_phanxuong_to.OrderBy(s => s.ten_to).ToList())
        {
            str += string.Format("<option px=\"{2}\" value=\"{0}\">{1}</option>", cn.md_to_id, cn.ten_to, cn.md_phanxuong_id);
        }
        str += "</select>";
        context.Response.Write(str);
    }

    public void selectoption_px(HttpContext context)
    {
        string md_sanpham_id = context.Request.QueryString["md_sanpham_id"];
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "", input = "";

        str += firstnull ? string.Format("<option value=\"\"></option>") : "";

        string md_phanxuong_id = db.md_sanpham.Where(s => s.md_sanpham_id == md_sanpham_id).Select(s => s.md_phanxuong_id).FirstOrDefault();
        foreach (md_phanxuong cn in db.md_phanxuong.Where(s => s.md_phanxuong_id != null & s.md_phanxuong_id != "").ToList())
        {
            string selected = "";
            if (md_phanxuong_id == cn.md_phanxuong_id) { selected = "selected"; }
            str += string.Format("<option {2} value=\"{0}\">{1}</option>", cn.md_phanxuong_id, cn.ten_phanxuong, selected);
        }

        context.Response.Write(str);
    }

    public void selectoption_to(HttpContext context)
    {
        string md_sanpham_id = context.Request.QueryString["md_sanpham_id"];
        string md_phanxuong_id = context.Request.QueryString["md_phanxuong_id2"];
        bool firstnull = bool.Parse(context.Request.QueryString["firstnull"]);
        string str = "", input = "";

        str += firstnull ? string.Format("<option value=\"\"></option>") : "";

        string md_to_id = db.md_sanpham.Where(s => s.md_sanpham_id == md_sanpham_id).Select(s => s.md_to_id).FirstOrDefault();
        foreach (md_phanxuong_to cn in db.md_phanxuong_to.Where(s => s.md_phanxuong_id == md_phanxuong_id).OrderBy(s => s.ten_to).ToList())
        {
            string selected = "";
            if (md_to_id == cn.md_to_id) { selected = "selected"; }
            str += string.Format("<option {2} value=\"{0}\">{1}</option>", cn.md_to_id, cn.ten_to, selected);
        }

        context.Response.Write(str);
    }

    public void CA_01_UpdateXT(HttpContext context)
    {
        string msg = "";
        string md_sanpham_id = context.Request.Form["id"];
        string[] vnn = md_sanpham_id.Split(',');
        string md_phanxuong_id = context.Request.Form["md_phanxuong_id"];
        string md_to_id = context.Request.Form["md_to_id"];
        if (msg.Length <= 0)
        {
            foreach (md_sanpham sp in db.md_sanpham.Where(s => vnn.Contains(s.md_sanpham_id)).ToList())
            {
                sp.md_phanxuong_id = md_phanxuong_id;
                sp.md_to_id = md_to_id;
                db.md_sanpham.Add(sp);
                msg += sp.md_sanpham_id + " xuong hien tai : " + sp.md_phanxuong_id + " xuong moi : " + md_phanxuong_id + "\n";
            }
            msg = "true#Cập nhật thành công";
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string ma_dtkd = context.Request.Form["nhacungung"];
        string ma_sanpham = context.Request.Form["ma_sanpham"];
        try
        {
            string id = context.Request.QueryString["id"];
            md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == ma_dtkd).FirstOrDefault();
            int count = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham).Count();
            if (count > 0)
            {
                msg = "false#\"" + ma_sanpham + "\" đã tồn tại.";
            }
            else if (dtkd == null & ma_dtkd != "")
            {
                msg = "false#Không tìm thấy đối tác \"" + ma_dtkd + "\"";
            }
            else if (dtkd != null)
            {
                ma_dtkd = dtkd.md_doitackinhdoanh_id;
            }
            else
            {
                ma_dtkd = null;
            }

            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "trangthai", "md_doitackinhdoanh_id", "anco_check" };
                string ten_table = "md_sanpham";
                VNN_Function.SetFormValue("trangthai", "DHD");
                VNN_Function.SetFormValue("nhacungung", ma_dtkd);
                VNN_Function.SetFormValue("anco_check", "True");
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
        string msg = "";
        string ma_module = context.Request.QueryString["ma_module"];
        bool muangoai = bool.Parse(context.Request.Form["muangoai"]);
        string ma_dtkd = context.Request.Form["nhacungung"];
        //try
        {
            EntityContext db = new EntityContext();
            string id = context.Request.Form["id"];
            md_sanpham object_ = db.md_sanpham.Where(p => p.md_sanpham_id == id).Take(1).FirstOrDefault();
            md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == ma_dtkd).FirstOrDefault();

            if (dtkd == null & ma_dtkd != "")
            {
                msg = "false#Không tìm thấy đối tác \"" + ma_dtkd + "\"";
            }
            else if (dtkd != null)
            {
                ma_dtkd = dtkd.md_doitackinhdoanh_id;
            }
            else
            {
                ma_dtkd = "null";
            }

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "md_sanpham";
                VNN_Function.SetFormValue("muangoai", muangoai.ToString());
                VNN_Function.SetFormValue("nhacungung", ma_dtkd);
                VNN_Function.Set_DefaultvalueColumn(context, action);
                VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);
                VNN_Function.loaddulieu_Auto(db, ma_module);
                msg = "true#Cập nhật thành công.";
            }
        }
        //catch (Exception ex)
        {
            //msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void del(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "",  msg_del = "";
        string ma_module = context.Request.QueryString["ma_module"];
        //try
        {
            string ten_table = "md_sanpham";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                string object_ = db.md_sanpham.Where(p => p.md_sanpham_id == id_del_).Select(s => s.md_sanpham_id).Take(1).FirstOrDefault();
                int b = db.md_sanpham_bom_vattu.Where(s => s.md_sanpham_id == object_).Count();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                else if (b > 0)
                {
                    msg_del = "Lỗi:Đối tượng cần xóa đã được sử dụng.";
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
        //catch (Exception ex)
        {
            /* if (ex.Message.ToUpper().Contains("REFERENCE"))
             {
                 msg = "false#Lỗi: Đang được sử dụng, không thể xóa";
             }
             else
             {
                 msg = "false#Lỗi: " + ex.Message;
             }*/
        }
        context.Response.Write(msg);
    }

    /*nht*/
    public void CA_01_UpdateHH(HttpContext context)
    {
        string msg = "";
        EntityContext db = new EntityContext();
        string str = VNN_VariablePublic.connectString_Anco1(db);
        string start = context.Request.Form["start"];
        string end = context.Request.Form["end"];
        string check = context.Request.Form["check"];
        //try 
        {
            string ma_doanhnghiep = "VINHGIA";
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select sp.ma_sanpham, sp.mota_tiengviet, sp.mota_tienganh, dvt.ten_dvt, cl.tv_ngan, sp.l_inch, sp.w_inch, sp.h_inch, " +
            "sp.l_cm, sp.w_cm, sp.h_cm, sp.trongluong, sp.dientich, '' as ncc, N'KHO THÀNH PHẨM' as kmd, N'KHO TỒN THÀNH PHẨM' as kt, '' as xmd, '' as tmd, sp.ghichu, 0 as mngoai, 'VAT00' as thue, 0 as vt, 0 as btp, " +
            "1 as tp, N'KHO THÀNH PHẨM' as ngh, 0 as tktt " +
            "from md_sanpham sp with (nolock) inner join md_donvitinhsanpham dvt with (nolock) on sp.md_donvitinhsanpham_id = dvt.md_donvitinhsanpham_id " +
            "inner join md_chungloai cl with (nolock) on sp.md_chungloai_id = cl.md_chungloai_id " +
            "inner join md_doitackinhdoanh dtkd with (nolock) on dtkd.md_doitackinhdoanh_id = sp.nhacungung " +
            "where sp.hoatdong = 1 and dtkd.ma_dtkd = '" + ma_doanhnghiep + "' and sp.trangthai = 'DHD' " +
            "and sp.ngaytao >= convert(datetime,N'" + start + "',103) and sp.ngaytao <= convert(datetime,N'" + end + "',103) order by ma_sanpham asc ", cnn);
            cmd.CommandTimeout = 60;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (check == "true")
            {
                int nht = 0;
                for (nht = 0; nht < dt.Rows.Count; nht++)
                {
                    string ma_sanpham = dt.Rows[nht]["ma_sanpham"].ToString();
                    string id_new = Helper.getNewId(); ;

                    var query = from m in db.md_sanpham
                                where m.ma_sanpham == ma_sanpham & m.anco_check == true
                                select m;

                    var count = query.Count();

                    md_sanpham sanpham = db.md_sanpham.Where(s => s.ma_sanpham == ma_sanpham & s.anco_check == true).FirstOrDefault();
                    if (count <= 0)
                    {
                        sanpham = new md_sanpham();
                        sanpham.md_sanpham_id = id_new;
                        sanpham.trangthai = "SOANTHAO";
                        sanpham.ma_sanpham = dt.Rows[nht]["ma_sanpham"].ToString();
                    }

                    sanpham.mota_tiengviet = dt.Rows[nht]["mota_tiengviet"].ToString();
                    sanpham.mota_tienganh = dt.Rows[nht]["mota_tienganh"].ToString();
                    sanpham.md_chungloai_id = "";

                    string anco_dvt = dt.Rows[nht]["ten_dvt"].ToString();
                    string md_donvitinhsanpham_id = db.md_donvitinhsanpham.Where(s => s.ma_edi == anco_dvt).Select(s => s.md_donvitinhsanpham_id).Take(1).FirstOrDefault();
                    if (md_donvitinhsanpham_id != null)
                        sanpham.md_donvitinhsanpham_id = md_donvitinhsanpham_id;
                    else
                        sanpham.md_donvitinhsanpham_id = "";
                    sanpham.anco_check = true;
                    sanpham.hoatdong = true;

                    if (count <= 0)
                        db.md_sanpham.Add(sanpham);

                    db.SaveChanges();
                }

                EXport_EXHH(context, dt);
                msg = "<div style='color:blue'>Đã thêm " + dt.Rows.Count + " dòng từ ANCO.</div>";
            }
            else
            {
                EXport_EXHH(context, dt);
                msg = "<div style='color:blue'>Đã lấy về " + dt.Rows.Count + " dòng từ ANCO.</div>";
            }

            ad_systemconfig sys = db.ad_systemconfig.FirstOrDefault();
            sys.date_import = DateTime.Now;
            db.SaveChanges();
        }
        //catch(Exception ex)
        {
            //msg = "<div style='color:red'>Lỗi: "+ ex.Message +"</div>";
        }
        context.Response.Write(msg);
    }

    public void CA_01_ExportHH(HttpContext context)
    {
        string msg = "";
        EntityContext db = new EntityContext();
        string start = context.Request.Form["start"];
        string end = context.Request.Form["end"];
        //try
        {
            SqlConnection cnn = Mbg.Data.SqlClient.SqlHelper.GetConnection;
            SqlCommand cmd = new SqlCommand(@"
			 select
			 sp.ma_sanpham as ma_sanpham,
			 sp.mota_tiengviet as mota_tiengviet,
			 sp.mota_tienganh as mota_tienganh,
			 dvt_sp.ten_dvt as md_donvitinhsanpham_id,
			 cl.code_cl as tv_ngan,
			 sp.l_inch as l_inch,
			 sp.w_inch as w_inch,
			 sp.h_inch as h_inch,
			 sp.l_cm as l_cm,
			 sp.w_cm as w_cm,
			 sp.h_cm as h_cm,
			 sp.trongluong as trongluong,
			 sp.dientich as dientich,
			 dtkd.ma_dtkd as nhacungung,
			 kmd.ten_kho as khomacdinh,
			 kton.ten_kho as khoton,
			 px.ten_phanxuong as md_phanxuong_id,
			 pxt.ten_to as md_to_id,
			 sp.ghichu as ghichu,
			 thue.ten_thue_sanpham as md_thue_sanpham_id,
			 sp.noigiaohang as noigiaohang,
			 sp.sl_tonkho_toithieu as sl_tonkho_toithieu
			 from md_sanpham sp
			left join md_donvitinhsanpham dvt_sp on sp.md_donvitinhsanpham_id = dvt_sp.md_donvitinhsanpham_id
			left join md_phanxuong px on sp.md_phanxuong_id = px.md_phanxuong_id
			left join md_phanxuong_to pxt on sp.md_to_id = pxt.md_to_id
			left join md_kho kmd on sp.khomacdinh = kmd.md_kho_id
			left join md_kho kton on sp.khoton = kton.md_kho_id
			left join md_thue_sanpham thue on sp.md_thue_sanpham_id = thue.md_thue_sanpham_id
			left join md_doitackinhdoanh dtkd on sp.nhacungung = dtkd.md_doitackinhdoanh_id
			left join md_chungloai cl on sp.md_chungloai_id = cl.md_chungloai_id 
			where sp.hoatdong = 1 order by sp.ma_sanpham", cnn);
            cmd.CommandTimeout = 60;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EXport_EXHH(context, dt);
            msg = "<div style='color:blue'>Đã lấy về "+ dt.Rows.Count +" dòng</div>";
        }
        //catch(Exception ex)
        {
            //msg = "<div style='color:red'>Lỗi: "+ ex.Message +"</div>";
        }
        context.Response.Write(msg);
    }

    public void EXport_EXHH(HttpContext context, DataTable dt)
    {
        context.Session["hsswb"] = null;
        HSSFWorkbook hssfworkbook = new HSSFWorkbook();
        ISheet s1 = hssfworkbook.CreateSheet("Sheet1");
        IFont font12 = hssfworkbook.CreateFont();
        font12.FontHeightInPoints = 12;

        IFont font10 = hssfworkbook.CreateFont();
        font12.FontHeightInPoints = 8;

        IFont font12Bold = hssfworkbook.CreateFont();
        font12Bold.FontHeightInPoints = 12;
        font12Bold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

        IFont font10Bold = hssfworkbook.CreateFont();
        font10Bold.FontHeightInPoints = 8;
        font10Bold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

        IFont font16Bold = hssfworkbook.CreateFont();
        font16Bold.FontHeightInPoints = 16;
        font16Bold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

        IFont font12BoldItalic = hssfworkbook.CreateFont();
        font12BoldItalic.FontHeightInPoints = 12;
        font12BoldItalic.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
        font12BoldItalic.IsItalic = true;

        IFont font22Bold = hssfworkbook.CreateFont();
        font22Bold.FontHeightInPoints = 22;
        font22Bold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

        IFont font14Bold = hssfworkbook.CreateFont();
        font14Bold.FontHeightInPoints = 14;
        font14Bold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

        IFont font18Bold = hssfworkbook.CreateFont();
        font18Bold.FontHeightInPoints = 18;
        font18Bold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

        // Cell Style 
        ICellStyle styleCenter18Bold = hssfworkbook.CreateCellStyle();
        styleCenter18Bold.SetFont(font18Bold);
        styleCenter18Bold.VerticalAlignment = VerticalAlignment.Center;
        styleCenter18Bold.Alignment = HorizontalAlignment.Center;
        styleCenter18Bold.WrapText = true;

        ICellStyle styleTop14Bold = hssfworkbook.CreateCellStyle();
        styleTop14Bold.SetFont(font14Bold);
        styleTop14Bold.VerticalAlignment = VerticalAlignment.Top;
        styleTop14Bold.WrapText = true;

        ICellStyle styleCenter22Bold = hssfworkbook.CreateCellStyle();
        styleCenter22Bold.SetFont(font22Bold);
        styleCenter22Bold.VerticalAlignment = VerticalAlignment.Center;
        styleCenter22Bold.Alignment = HorizontalAlignment.Center;
        styleCenter22Bold.WrapText = true;

        ICellStyle styleCenter12Bold = hssfworkbook.CreateCellStyle();
        styleCenter12Bold.SetFont(font12Bold);
        styleCenter12Bold.VerticalAlignment = VerticalAlignment.Center;
        styleCenter12Bold.Alignment = HorizontalAlignment.Center;
        styleCenter12Bold.WrapText = true;

        ICellStyle styleCenter16Bold = hssfworkbook.CreateCellStyle();
        styleCenter16Bold.SetFont(font16Bold);
        styleCenter16Bold.VerticalAlignment = VerticalAlignment.Center;
        styleCenter16Bold.Alignment = HorizontalAlignment.Center;
        styleCenter16Bold.WrapText = true;

        ICellStyle styleRight12Bold = hssfworkbook.CreateCellStyle();
        styleRight12Bold.SetFont(font12Bold);
        styleRight12Bold.VerticalAlignment = VerticalAlignment.Center;
        styleRight12Bold.Alignment = HorizontalAlignment.Right;
        styleRight12Bold.WrapText = true;

        ICellStyle styleCenterBorder12Bold = hssfworkbook.CreateCellStyle();
        styleCenterBorder12Bold.SetFont(font10Bold);
        styleCenterBorder12Bold.VerticalAlignment = VerticalAlignment.Center;
        styleCenterBorder12Bold.Alignment = HorizontalAlignment.Center;
        styleCenterBorder12Bold.WrapText = true;

        ICellStyle styleBorder12Bold = hssfworkbook.CreateCellStyle();
        styleBorder12Bold.SetFont(font12Bold);
        styleBorder12Bold.VerticalAlignment = VerticalAlignment.Center;
        styleBorder12Bold.WrapText = true;
        styleBorder12Bold.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        styleBorder12Bold.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        styleBorder12Bold.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        styleBorder12Bold.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;

        ICellStyle styleCenterBorderBottom12 = hssfworkbook.CreateCellStyle();
        styleCenterBorderBottom12.SetFont(font12);
        styleCenterBorderBottom12.VerticalAlignment = VerticalAlignment.Center;
        styleCenterBorderBottom12.Alignment = HorizontalAlignment.Center;
        styleCenterBorderBottom12.WrapText = true;
        styleCenterBorderBottom12.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

        ICellStyle style12BoldItalic = hssfworkbook.CreateCellStyle();
        style12BoldItalic.SetFont(font12BoldItalic);
        style12BoldItalic.VerticalAlignment = VerticalAlignment.Center;
        style12BoldItalic.WrapText = true;

        ICellStyle styleCenter12 = hssfworkbook.CreateCellStyle();
        styleCenter12.SetFont(font12);
        styleCenter12.VerticalAlignment = VerticalAlignment.Center;
        styleCenter12.Alignment = HorizontalAlignment.Center;
        styleCenter12.WrapText = true;

        ICellStyle style12 = hssfworkbook.CreateCellStyle();
        style12.SetFont(font12);
        style12.VerticalAlignment = VerticalAlignment.Center;
        style12.WrapText = true;

        ICellStyle style12Bold = hssfworkbook.CreateCellStyle();
        style12Bold.SetFont(font12Bold);
        style12Bold.VerticalAlignment = VerticalAlignment.Center;
        style12Bold.WrapText = true;

        ICellStyle style12TopBold = hssfworkbook.CreateCellStyle();
        style12TopBold.SetFont(font12Bold);
        style12TopBold.VerticalAlignment = VerticalAlignment.Top;
        style12TopBold.WrapText = true;

        ICellStyle style12Top = hssfworkbook.CreateCellStyle();
        style12Top.SetFont(font12);
        style12Top.VerticalAlignment = VerticalAlignment.Top;
        style12Top.WrapText = true;

        ICellStyle styleBorder12 = hssfworkbook.CreateCellStyle();
        styleBorder12.SetFont(font12);
        styleBorder12.VerticalAlignment = VerticalAlignment.Center;
        styleBorder12.WrapText = true;
        styleBorder12.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        styleBorder12.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        styleBorder12.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        styleBorder12.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;

        ICellStyle styleBorderCenter12 = hssfworkbook.CreateCellStyle();
        styleBorderCenter12.SetFont(font12);
        styleBorderCenter12.VerticalAlignment = VerticalAlignment.Center;
        styleBorderCenter12.Alignment = HorizontalAlignment.Center;
        styleBorderCenter12.WrapText = true;
        styleBorderCenter12.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        styleBorderCenter12.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        styleBorderCenter12.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        styleBorderCenter12.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;

        ICellStyle styleNumber0Border12 = hssfworkbook.CreateCellStyle();
        styleNumber0Border12.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0");
        styleNumber0Border12.SetFont(font12);
        styleNumber0Border12.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0Border12.Alignment = HorizontalAlignment.Right;
        styleNumber0Border12.WrapText = true;
        styleNumber0Border12.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0Border12.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0Border12.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0Border12.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;


        ICellStyle styleNumber0i0Border12 = hssfworkbook.CreateCellStyle();
        styleNumber0i0Border12.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0.0");
        styleNumber0i0Border12.SetFont(font12);
        styleNumber0i0Border12.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0i0Border12.Alignment = HorizontalAlignment.Right;
        styleNumber0i0Border12.WrapText = true;
        styleNumber0i0Border12.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0i0Border12.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0i0Border12.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0i0Border12.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;

        ICellStyle styleNumber0i00Border12 = hssfworkbook.CreateCellStyle();
        styleNumber0i00Border12.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0.00");
        styleNumber0i00Border12.SetFont(font12);
        styleNumber0i00Border12.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0i00Border12.Alignment = HorizontalAlignment.Right;
        styleNumber0i00Border12.WrapText = true;
        styleNumber0i00Border12.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0i00Border12.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0i00Border12.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0i00Border12.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;


        ICellStyle styleNumber0i000Border12 = hssfworkbook.CreateCellStyle();
        styleNumber0i000Border12.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0.000");
        styleNumber0i000Border12.SetFont(font12);
        styleNumber0i000Border12.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0i000Border12.Alignment = HorizontalAlignment.Right;
        styleNumber0i000Border12.WrapText = true;
        styleNumber0i000Border12.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0i000Border12.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0i000Border12.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
        styleNumber0i000Border12.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;


        ICellStyle styleNumber012 = hssfworkbook.CreateCellStyle();
        styleNumber012.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0");
        styleNumber012.SetFont(font12);
        styleNumber012.VerticalAlignment = VerticalAlignment.Center;
        styleNumber012.Alignment = HorizontalAlignment.Right;
        styleNumber012.WrapText = true;


        ICellStyle styleNumber0i012 = hssfworkbook.CreateCellStyle();
        styleNumber0i012.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0.0");
        styleNumber0i012.SetFont(font12);
        styleNumber0i012.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0i012.Alignment = HorizontalAlignment.Right;
        styleNumber0i012.WrapText = true;


        ICellStyle styleNumber0i0012 = hssfworkbook.CreateCellStyle();
        styleNumber0i0012.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0.00");
        styleNumber0i0012.SetFont(font12);
        styleNumber0i0012.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0i0012.Alignment = HorizontalAlignment.Right;
        styleNumber0i0012.WrapText = true;

        ICellStyle styleNumber0i00012 = hssfworkbook.CreateCellStyle();
        styleNumber0i00012.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0.000");
        styleNumber0i00012.SetFont(font12);
        styleNumber0i00012.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0i00012.Alignment = HorizontalAlignment.Right;
        styleNumber0i00012.WrapText = true;


        ICellStyle styleNumber012Bold = hssfworkbook.CreateCellStyle();
        styleNumber012Bold.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0");
        styleNumber012Bold.SetFont(font12Bold);
        styleNumber012Bold.VerticalAlignment = VerticalAlignment.Center;
        styleNumber012Bold.Alignment = HorizontalAlignment.Right;
        styleNumber012Bold.WrapText = true;


        ICellStyle styleNumber0i012Bold = hssfworkbook.CreateCellStyle();
        styleNumber0i012Bold.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0.0");
        styleNumber0i012Bold.SetFont(font12Bold);
        styleNumber0i012Bold.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0i012Bold.Alignment = HorizontalAlignment.Right;
        styleNumber0i012Bold.WrapText = true;


        ICellStyle styleNumber0i0012Bold = hssfworkbook.CreateCellStyle();
        styleNumber0i0012Bold.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0.00");
        styleNumber0i0012Bold.SetFont(font12Bold);
        styleNumber0i0012Bold.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0i0012Bold.Alignment = HorizontalAlignment.Right;
        styleNumber0i0012Bold.WrapText = true;

        ICellStyle styleNumber0i00012Bold = hssfworkbook.CreateCellStyle();
        styleNumber0i00012Bold.DataFormat = NPOIUtils.GetDataFormat(hssfworkbook, "#,#0.000");
        styleNumber0i00012Bold.SetFont(font12Bold);
        styleNumber0i00012Bold.VerticalAlignment = VerticalAlignment.Center;
        styleNumber0i00012Bold.Alignment = HorizontalAlignment.Right;
        styleNumber0i00012Bold.WrapText = true;

        IPrintSetup print = s1.PrintSetup;
        print.PaperSize = (short)PaperSize.A4;
        print.Scale = (short)80;
        print.FitWidth = (short)1;
        print.FitHeight = (short)0;

        for (int i = 0; i < dt.Columns.Count; i++)
        {
            s1.SetColumnWidth(i, 5000);
        }

        IRow rTitle = s1.CreateRow(0);
        rTitle.CreateCell(0).SetCellValue("MÃ HÀNG");
        rTitle.CreateCell(1).SetCellValue("MÔ TẢ TV");
        rTitle.CreateCell(2).SetCellValue("MÔ TẢ TA");
        rTitle.CreateCell(3).SetCellValue("ĐVT");
        rTitle.CreateCell(4).SetCellValue("LOAI SP");
        rTitle.CreateCell(5).SetCellValue("L(inch)");
        rTitle.CreateCell(6).SetCellValue("W(inch)");
        rTitle.CreateCell(7).SetCellValue("H(inch)");
        rTitle.CreateCell(8).SetCellValue("L(cm)");
        rTitle.CreateCell(9).SetCellValue("W(cm)");
        rTitle.CreateCell(10).SetCellValue("H(cm)");
        rTitle.CreateCell(11).SetCellValue("Trọng lượng");
        rTitle.CreateCell(12).SetCellValue("D/TÍCH");
        rTitle.CreateCell(13).SetCellValue("Nhà cung ứng");
        rTitle.CreateCell(14).SetCellValue("Kho mặc định");
        rTitle.CreateCell(15).SetCellValue("Kho tồn");
        rTitle.CreateCell(16).SetCellValue("Xưởng mặc đinh");
        rTitle.CreateCell(17).SetCellValue("Tổ mặc định");
        rTitle.CreateCell(18).SetCellValue("Chi chú");
        rTitle.CreateCell(19).SetCellValue("Thuế");
        rTitle.CreateCell(20).SetCellValue("Nơi giao hàng");
        rTitle.CreateCell(21).SetCellValue("Tồn kho tối thiểu");

        for (int j = 0; j <= 21; j++)
        {
            rTitle.GetCell(j).CellStyle = styleCenterBorder12Bold;
        }

        /*rDetails.CreateCell(9).SetCellValue(row["ngaycongvan"].ToString() != "" ? DateTime.Parse(row["ngaycongvan"].ToString()).ToString("dd/MM/yyyy") : "");
		rDetails.CreateCell(10).SetCellValue(row["ngaybatdau"].ToString() != "" ? DateTime.Parse(row["ngaybatdau"].ToString()).ToString("dd/MM/yyyy") : "");
		rDetails.CreateCell(11).SetCellValue(row["ngayketthuc"].ToString() != "" ? DateTime.Parse(row["ngayketthuc"].ToString()).ToString("dd/MM/yyyy") : "");
		rDetails.CreateCell(12).SetCellValue(row["trichyeu"].ToString().Length > 32767 ? row["trichyeu"].ToString().Substring(32767) : row["trichyeu"].ToString());*/
        int dem_row = 1;
        foreach (DataRow row in dt.Rows)
        {
            IRow rDetails = s1.CreateRow(dem_row);
            for (int dem = 0; dem < dt.Columns.Count; dem++)
            {
                string noidung = row[dem].ToString();
                if(noidung == "True")
                    noidung = "1";
                else if(noidung == "False")
                    noidung = "0";
                rDetails.CreateCell(dem).SetCellValue(noidung);
                //rDetails.GetCell(dem).CellStyle = styleBorder12;
            }
            dem_row++;
        }
        context.Session["hsswb"] = hssfworkbook;
    }

    public void SaveFile(HttpContext context)
    {
        HSSFWorkbook hsswb = (HSSFWorkbook)context.Session["hsswb"];
        String saveAsFileName = String.Format("DanhSachHangHoaANCO-{0}.xls", DateTime.Now.ToString("dd-MM-yyyy"));
        MemoryStream exportData = new MemoryStream();
        hsswb.Write(exportData);
        context.Response.ContentType = "application/vnd.ms-excel";
        context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));
        context.Response.Clear();
        context.Response.BinaryWrite(exportData.GetBuffer());
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}