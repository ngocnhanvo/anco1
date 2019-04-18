<%@ WebHandler Language="C#" Class="JQGridMD_00_DSDHJQGSModify" %>
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
public class JQGridMD_00_DSDHJQGSModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA01DSAncotrading_MD00DSDHJQGS":
                this.CA01DSAncotrading_MD00DSDHJQGS(context);
                break;
            case "CA_01_UpdateDSX":
                this.CA_01_UpdateDSX(context);
                break;
            case "CA_01_DCHT":
                this.CA_01_DCHT(context);
                break;
            case "CA_01_HuyBoDonHangAnco":
                this.CA_01_HuyBoDonHangAnco(context);
                break;
            case "CA_01_Export_DH_Ancotrading":
                this.CA_01_Export_DH_Ancotrading(context);
                break;
            case "savefile":
                this.SaveFile(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_Export_DH_Ancotrading(HttpContext context)
    {
        string msg = "";
        EntityContext db = new EntityContext();
        string str = "Data Source=.;Initial Catalog=eMan;Persist Security Info=True;User ID=eMan;Password=edoc,123";
        string id = context.Request.Form["id"];
        string start = context.Request.Form["start"];
        string end = context.Request.Form["end"];
        try
        {
            SqlConnection cnn = Mbg.Data.SqlClient.SqlHelper.GetConnection;
            SqlCommand cmd = new SqlCommand(" select b.so_po,sp.ma_sanpham,a.gianhap " +
            "from c_dongdsdh a " +
            "left join c_danhsachdathang b on b.c_danhsachdathang_id = a.c_danhsachdathang_id " +
            "left join md_sanpham sp on sp.md_sanpham_id = a.md_sanpham_id " +
            "where b.anco_check = 1 and b.hangiaohang_po >= convert(datetime,N'" + start + "',103) " +
            "and b.hangiaohang_po <= convert(datetime,N'" + end + "',103)	order by b.so_po asc, sp.ma_sanpham asc", cnn);
            cmd.CommandTimeout = 60;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            EXport_PBanGia(context, dt);
            msg = "<div style='color:blue'>Đã lấy về " + dt.Rows.Count + " dòng</div>";
        }
        catch (Exception ex)
        {
            msg = "<div style='color:red'>Lỗi: " + ex.Message + "</div>";
        }
        context.Response.Write(msg);
    }

    public void EXport_PBanGia(HttpContext context, DataTable dt)
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
            if (i == 0 | i == 1)
            {
                s1.SetColumnWidth(i, 10000);
            }
            else
            {
                s1.SetColumnWidth(i, 5000);
            }
        }

        IRow rTitle = s1.CreateRow(0);
        rTitle.CreateCell(0).SetCellValue("Số đơn hàng");
        //rTitle.CreateCell(3).SetCellValue("Mô tả");
        rTitle.CreateCell(1).SetCellValue("Mã vật tư / hàng hóa");
        rTitle.CreateCell(2).SetCellValue("Giá");

        for (int j = 0; j <= 2; j++)
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
                if (noidung == "True")
                    noidung = "1";
                else if (noidung == "False")
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
        String saveAsFileName = String.Format("DH_DH_Ancotrading-{0}.xls", DateTime.Now.ToString("dd-MM-yyyy"));
        MemoryStream exportData = new MemoryStream();
        hsswb.Write(exportData);
        context.Response.ContentType = "application/vnd.ms-excel";
        context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));
        context.Response.Clear();
        context.Response.BinaryWrite(exportData.GetBuffer());
        context.Response.End();
    }

    public void CA_01_HuyBoDonHangAnco(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        string check_1 = context.Request.Form["check"];
        string[] vnn = id.Split(',');
        try
        {
            foreach (c_danhsachdathang dsdh in db.c_danhsachdathang.Where(s => vnn.Contains(s.c_danhsachdathang_id)))
            {
                if (dsdh.trangthai != "DANHAN" & dsdh.trangthai != "SOANTHAO")
                {
                    if (check_1 == "1")
                    {
                        dsdh.trangthai = "HUYBO";
                        msg_success = "<div style='color:blue'> Hủy bỏ đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "2")
                    {
                        dsdh.trangthai = "KETTHUC";
                        msg_success = "<div style='color:blue'> Kết thúc đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "3" & dsdh.anco_check == false)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Khởi động lại đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "3" & dsdh.anco_check == true)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Khởi động lại đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "4" & dsdh.anco_check == false)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Kích hoạt đơn hàng thành công.</div>";
                    }
                    else if (check_1 == "4" & dsdh.anco_check == true)
                    {
                        dsdh.trangthai = "HIEULUC";
                        msg_success = "<div style='color:blue'>Kích hoạt đơn hàng thành công.</div>";
                    }
                }
                else
                {
                    msg = "<div style='color:red'>Đơn hàng chưa hiệu lực.</div>";
                }
            }
            if (msg.Length <= 0)
            {
                db.SaveChanges();
                msg = msg_success;
            }
        }
        catch (Exception ex)
        {
            msg = "false#" + ex.Message;
        }
        context.Response.Write(msg);
    }

    public void CA_01_DCHT(HttpContext context)
    {
        EntityContext db = new EntityContext();
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        string msg = "", msg_success = "";
        string id = context.Request.Form["id"];
        string[] vnn = id.Split(',');
        foreach (c_danhsachdathang dsdh in db.c_danhsachdathang.Where(s => vnn.Contains(s.c_danhsachdathang_id)).OrderByDescending(s => s.ngaylap))
        {
            if (dsdh.trangthai == "DAGUI" | dsdh.trangthai == "")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " chưa được xác nhận .</div>";
            }
            else if (dsdh.trangthai == "HIEULUC")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã hiệu lực.</div>";
            }
            else if (dsdh.trangthai == "HUYBO")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã hủy.</div>";
            }
            else if (dsdh.trangthai == "KETTHUC")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã kết thúc.</div>";
            }
            else if (dsdh.md_trangthai_id != "HIEULUC")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã được đối chiếu hàng tồn.</div>";
            }
            else
            {
                string id_dc = Helper.getNewId();
                c_doichieuhangton dc = new c_doichieuhangton
                {
                    c_doichieuhangton_id = id_dc,
                    c_danhsachdathang_id = dsdh.c_danhsachdathang_id,
                    so_donhang = dsdh.sochungtu,
                    ten_donhang = "KHDH-" + dsdh.so_po,
                    donhang_thamchieu = dsdh.so_po,
                    kehoach = " ",
                    doichieuht = false,
                    phieuhangton = " ",
                    ngaykehoach = DateTime.Now,
                    ngayhoanthanh = dsdh.ngayhoanthanh,

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
                    hoatdong = true
                };
                db.c_doichieuhangton.Add(dc);

                //tao cac dong don hang
                foreach (c_dongdsdh ddsdh in db.c_dongdsdh.Where(s => s.c_danhsachdathang_id == dsdh.c_danhsachdathang_id))
                {
                    md_sanpham sp = db.md_sanpham.Where(s => s.md_sanpham_id == ddsdh.md_sanpham_id).FirstOrDefault();
                    if (sp == null)
                    {
                        msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " chưa có dữ liệu của hàng hóa.</div>";
                    }
                    else if (sp.trangthai == "NHD")
                    {
                        msg += "<div style='color:red'>Lỗi:Mã hàng hóa " + sp.ma_sanpham + " đang có trạng thái \"Ngưng hoạt động\".</div>";
                    }


                    c_doichieuhangton_cddh cddh = new c_doichieuhangton_cddh
                    {
                        c_doichieuhangton_cddh_id = Helper.getNewId(),
                        c_doichieuhangton_id = id_dc,
                        md_sanpham_id = ddsdh.md_sanpham_id,
                        md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id,
                        mota_tiengviet = sp.mota_tiengviet,
                        mota_tienganh = sp.mota_tienganh,
                        sl_dathang = ddsdh.sl_dathang,
                        mota = dsdh.mota,

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
                        hoatdong = true
                    };
                    db.c_doichieuhangton_cddh.Add(cddh);
                }

                string str = VNN_VariablePublic.connectString_Anco(db);
                SqlConnection cnn = new SqlConnection(str);

                //disable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
                SqlCommand cmd = new SqlCommand(@"
				ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateGoiHDLH
				ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateSLDaDatTrenPO
				", cnn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                //update c_danhsachdathang
                cmd = new SqlCommand(@"
				update c_danhsachdathang set trangthai = 'DAHIEULUC' where c_danhsachdathang_id = '" + dsdh.c_danhsachdathang_id + "'"
                , cnn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                //enable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
                cmd = new SqlCommand(@"
				ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateGoiHDLH
				ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateSLDaDatTrenPO
				", cnn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                //dsdh.md_trangthai_id = "DATAO";
                dsdh.trangthai = "HIEULUC";
                msg_success += "<div style='color:blue'>Đơn hàng " + dsdh.sochungtu + " được hiệu lực thành công.</div>";
            }
        }
        if (msg.Length <= 0)
        {
            db.SaveChanges();
            msg = msg_success;
        }
        context.Response.Write(msg);
    }

    public void CA_01_UpdateDSX(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string[] vnn = context.Request.Form["id"].Split(',');
        string thoigiansx = context.Request.Form["thoigiansx"];
        string thoigianht = context.Request.Form["thoigianht"];
        foreach (c_danhsachdathang dsdh in db.c_danhsachdathang.Where(s => vnn.Contains(s.c_danhsachdathang_id)))
        {
            if (dsdh.trangthai == "HIEULUC")
            {
                msg += "<div style='color:red'>Lỗi: Dòng " + dsdh.sochungtu + " đã hiệu lực.</div>";
            }
            else if (dsdh.trangthai == "HUYBO")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã hủy.</div>";
            }
            else if (dsdh.trangthai == "KETTHUC")
            {
                msg += "<div style='color:red'>Lỗi:Đơn hàng " + dsdh.sochungtu + " đã kết thúc.</div>";
            }
            else if (dsdh.trangthai != "DANHAN")
            {
                msg += "<div style='color:red'>Lỗi: Dòng " + dsdh.sochungtu + " chưa được xác nhận.</div>";
            }
            else
            {
                dsdh.thoigiansx = int.Parse(thoigiansx);
                dsdh.ngaybatdau = dsdh.hangiaohang_po - TimeSpan.Parse(thoigiansx) - TimeSpan.Parse(thoigianht);
                dsdh.ngayhoanthanh = dsdh.hangiaohang_po - TimeSpan.Parse(thoigianht);
                db.SaveChanges();
                msg += "<div style='color:blue'>Dòng " + dsdh.sochungtu + " đã cập nhật thời gian sản xuất thành công.</div>";
            }
        }
        context.Response.Write(msg);
    }

    public void CA01DSAncotrading_MD00DSDHJQGS(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "";
        string id = context.Request.Form["id"];
        string thoigiansx = context.Request.Form["thoigiansx"];
        string thoigianht = context.Request.Form["thoigianht"];
        string[] vnn = id.Split(',');

        foreach (c_danhsachdathang dsdh1 in db.c_danhsachdathang.Where(s => vnn.Contains(s.c_danhsachdathang_id)).OrderByDescending(s => s.ngaylap))
        {
            string msg_er = "";
            string str_insert = "";
            string str = VNN_VariablePublic.connectString_Anco1(db);
            SqlConnection cnn = new SqlConnection(str);

            if (dsdh1.trangthai == "HUYBO")
            {
                msg_er += "<div style='color:red'>Lỗi: Đơn hàng " + dsdh1.sochungtu + " đã hủy.</div>";
            }
            else if (dsdh1.trangthai == "DANHAN")
            {
                msg_er += "<div style='color:red'>Lỗi: Đơn hàng " + dsdh1.sochungtu + " đã nhận hàng.</div>";
            }
            else if (dsdh1.trangthai == "KETTHUC")
            {
                msg_er += "<div style='color:red'>Lỗi: Đơn hàng " + dsdh1.sochungtu + " đã kết thúc.</div>";
            }
            else if (dsdh1.trangthai == "HIEULUC")
            {
                msg_er += "<div style='color:red'>Lỗi: Đơn hàng " + dsdh1.sochungtu + " đã hiệu lực.</div>";
            }
            else if (dsdh1.md_trangthai_id == "DOICHIEUHANGTON")
            {
                msg_er += "<div style='color:red'>Lỗi: Dòng " + dsdh1.sochungtu + " đã đối chiếu hàng tồn.</div>";
            }
            else
            {
                //lay du lieu dong danh sach dat hang
                SqlCommand cmd = new SqlCommand(@"select 
				ddsdh.c_dongdsdh_id,
				ddsdh.c_danhsachdathang_id,
				ddsdh.c_dongdonhang_id,
				(select ma_sanpham from md_sanpham where ddsdh.md_sanpham_id = md_sanpham_id) as md_sanpham_id,
				ddsdh.mota_tiengviet,
				ddsdh.mota_tienganh,
				ddsdh.ma_sanpham_khach,
				ddsdh.md_doitackinhdoanh_id,
				ddsdh.huongdan_dathang,
				ddsdh.han_giaohang,
				ddsdh.tem_dan,
				isnull(ddsdh.sl_conlai, 0) as sl_dathang,
				0 as sl_dagiao,
				ddsdh.sl_conlai,
				ddsdh.gianhap,
				ddsdh.sothutu,
				ddsdh.ngaytao,
				ddsdh.nguoitao,
				ddsdh.ngaycapnhat,
				ddsdh.nguoicapnhat,
				ddsdh.mota,
				ddsdh.hoatdong,
				ddsdh.md_donggoi_id,
				ddsdh.sl_inner,
				ddsdh.l1,
				ddsdh.w1,
				ddsdh.h1,
				ddsdh.sl_outer,
				ddsdh.l2,
				ddsdh.w2,
				ddsdh.h2,
				ddsdh.v2,
				ddsdh.sl_cont,
				ddsdh.vd,
				ddsdh.vn,
				ddsdh.vl,
				ddsdh.ghichu_vachngan,
				ddsdh.sl_huy,
				dvt_i.ten_dvt as dvt_inner,
				dvt_o.ten_dvt as dvt_outer
				from c_dongdsdh ddsdh 
				left join c_dongdonhang ddh on ddsdh.c_dongdonhang_id = ddh.c_dongdonhang_id
				left join md_donggoi dg on ddsdh.md_donggoi_id = dg.md_donggoi_id
				left join md_donvitinh dvt_i on dg.dvt_inner = dvt_i.md_donvitinh_id
				left join md_donvitinh dvt_o on dg.dvt_outer = dvt_o.md_donvitinh_id
				where ddsdh.sl_conlai > 0 and ddsdh.c_danhsachdathang_id = '" + dsdh1.c_danhsachdathang_id + "'", cnn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                int count_col = 0;
                string sql_column = "(";
                string sql_values = "(";
                foreach (System.Data.DataColumn col in dt.Columns)
                {
                    count_col++;
                    sql_column += col.ColumnName + ",";
                }

                if (sql_column != "(") { sql_column += "anco_check, sl_hanngach" + ")"; }

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    string c_dongdsdh_id = row[0].ToString();
                    c_dongdsdh dsdh = db.c_dongdsdh.Where(s => s.c_dongdsdh_id == c_dongdsdh_id).FirstOrDefault();
                    if (dsdh == null)
                    {
                        string sql_insert = "insert into c_dongdsdh" + sql_column + " values(";
                        for (int i = 0; i < count_col; i++)
                        {
                            string cell_value = row[i].ToString();
                            if (cell_value == null | cell_value == "")
                            {
                                sql_insert += "NULL,";
                            }
                            else
                            {
                                string c_val = cell_value;
                                cell_value = cell_value.Replace("'", "''");
                                if (i == 3)
                                {
                                    System.Data.DataTable tbl = Mbg.Data.SqlClient.SqlHelper.GetData("select md_sanpham_id from md_sanpham where ma_sanpham = N'" + cell_value + "'");
                                    if (tbl.Rows.Count > 0)
                                        sql_insert += "N'" + tbl.Rows[0][0] + "',";
                                    else
                                        msg_er += "<div style='color:red'>Lỗi:Sản phẩm \"" + c_val + "\" không có trong danh sách hàng hóa.</div>";
                                }
                                else
                                {
                                    sql_insert += "N'" + cell_value + "',";
                                }
                            }
                        }
                        sql_insert += "1,0)";
                        str_insert += sql_insert + "\n";
                    }
                }

                if (dt.Rows.Count <= 0)
                {
                    msg_er += "<div style='color:red'>Lỗi: Đơn hàng \"" + dsdh1.sochungtu + "\" đã được giao hết.</div>";
                }
            }

            if (msg_er.Length <= 0 & str_insert != "")
            {
                Mbg.Data.SqlClient.SqlHelper.ExcuteNonQuery(str_insert);
                //lay du lieu tu Cac khoan phi
                string str1 = VNN_VariablePublic.connectString_Anco(db);
                SqlConnection cnn1 = new SqlConnection(str1);
                SqlCommand cmd1 = new SqlCommand(@"select * from c_phidathang where c_danhsachdathang_id = '" + dsdh1.c_danhsachdathang_id + "'", cnn1);
                DataTable dt1 = new DataTable();
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                da1.Fill(dt1);

                int count_col1 = 0;
                string sql_column1 = "(";
                string sql_values1 = "(";
                foreach (System.Data.DataColumn col in dt1.Columns)
                {
                    count_col1++;
                    sql_column1 += col.ColumnName + ",";
                }

                if (sql_column1 != "(") { sql_column1 += "anco_check" + ")"; }

                foreach (System.Data.DataRow row in dt1.Rows)
                {
                    string c_phidathang_id = row[0].ToString();
                    c_phidathang dsdh2 = db.c_phidathang.Where(s => s.c_phidathang_id == c_phidathang_id).FirstOrDefault();
                    if (dsdh2 == null)
                    {
                        string sql_insert = "insert into c_phidathang" + sql_column1 + " values(";
                        for (int i = 0; i < count_col1; i++)
                        {
                            string cell_value = row[i].ToString();
                            if (cell_value == null | cell_value == "")
                            {
                                sql_insert += "NULL,";
                            }
                            else
                            {
                                sql_insert += "N'" + cell_value.Replace("'", "''") + "',";
                            }
                        }
                        sql_insert += "1)";
                        Mbg.Data.SqlClient.SqlHelper.ExcuteNonQuery(sql_insert);
                    }
                }

                //disable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
                SqlCommand cmd = new SqlCommand(@"
				ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateGoiHDLH
				ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateSLDaDatTrenPO
				", cnn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                //update c_danhsachdathang
                cmd = new SqlCommand(@"
				update c_danhsachdathang set trangthai = 'DANHAN' where c_danhsachdathang_id = '" + dsdh1.c_danhsachdathang_id + "'"
                , cnn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                //enable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
                cmd = new SqlCommand(@"
				ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateGoiHDLH
				ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateSLDaDatTrenPO
				", cnn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                dsdh1.trangthai = "DANHAN";
                dsdh1.thoigiansx = int.Parse(thoigiansx);
                dsdh1.ngaybatdau = dsdh1.hangiaohang_po - TimeSpan.Parse(thoigiansx) - TimeSpan.Parse(thoigianht);
                dsdh1.ngayhoanthanh = dsdh1.hangiaohang_po - TimeSpan.Parse(thoigianht);
                db.SaveChanges();
                msg += "<div style='color:blue'>Đơn hàng \"" + dsdh1.sochungtu + "\" đã xác nhận thành công.</div>";
            }
            else
            {
                msg += msg_er;
            }
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string md_dtk_id = context.Request.Form["md_doitackinhdoanh_id"];
        string sochungtu = context.Request.Form["sochungtu"];
        DateTime ngaybatdau = VNN_Config.setDateTime(context.Request.Form["ngaybatdau"]);
        DateTime ngaylap = VNN_Config.setDateTime(context.Request.Form["ngaylap"]);
        int thoigiansx = int.Parse(context.Request.Form["thoigiansx"]);
        DateTime hangiaohang_po = VNN_Config.setDateTime(context.Request.Form["hangiaohang_po"]);
        try
        {
            ngaybatdau = hangiaohang_po - TimeSpan.Parse(thoigiansx.ToString());
            md_dtk_id = db.md_doitackinhdoanh.Where(s => s.ma_dtkd == md_dtk_id).Select(s => s.md_doitackinhdoanh_id).FirstOrDefault();
            string id = context.Request.QueryString["id"];
            if (msg.Length <= 0)
            {
                if (ngaybatdau == DateTime.MinValue)
                {
                    VNN_Function.SetFormValue("ngaybatdau", null);
                }
                if (ngaylap == DateTime.MinValue)
                {
                    VNN_Function.SetFormValue("ngaylap", null);
                }
                if (hangiaohang_po == DateTime.MinValue)
                {
                    VNN_Function.SetFormValue("hangiaohang_po", null);
                }
                if (sochungtu == null)
                {
                    sochungtu = VNN_VariablePublic.sochungtu(db, "DSDH", 1);
                }
                if (msg.Length <= 0)
                {
                    string action = "add";
                    string[] column_ex = { "md_trangthai_id" };
                    VNN_Function.SetFormValue("md_doitackinhdoanh_id", md_dtk_id);
                    VNN_Function.SetFormValue("sochungtu", sochungtu);
                    VNN_Function.SetFormValue("ngaybatdau", ngaybatdau.ToString(VNN_Config.get_FormatDate()));
                    string ten_table = "c_danhsachdathang";
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, id_new, ten_table, action, column_ex, db);
                    VNN_Function.loaddulieu_Auto(db, ma_module);
                    msg = "true#Thêm thành công." + "#" + id_new;
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
        try
        {
            string id = context.Request.QueryString["id"];
            string object_ = db.c_danhsachdathang.Where(p => p.c_danhsachdathang_id.Equals(context.Request.Form["id"])).Select(s => s.c_danhsachdathang_id).Take(1).FirstOrDefault();
            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { };
                string ten_table = "c_danhsachdathang";
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
            string ten_table = "c_danhsachdathang";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                var object_ = db.c_danhsachdathang.Where(p => p.c_danhsachdathang_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi dòng " + i + ": Không tìm thấy đối tượng cần xóa.";
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "HUYBO")
                {
                    msg_del = "<div style='color:red'>Lỗi:Đơn hàng " + object_.sochungtu + " đã hủy.</div>";
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "KETTHUC")
                {
                    msg_del = "<div style='color:red'>Lỗi:Đơn hàng " + object_.sochungtu + " đã kết thúc.</div>";
                    msg += msg_del + "\n";
                }
                else if (object_.trangthai == "HIEULUC")
                {
                    msg_del = "<div style='color:red'>Lỗi:Đơn hàng " + object_.sochungtu + " đã hiệu lực.</div>";
                    msg += msg_del + "\n";
                }
                else if (object_.md_trangthai_id != "HIEULUC")
                {
                    msg_del = "Lỗi dòng: " + i + ":Đã hiệu lực không thể xóa.";
                    msg += msg_del + "\n";
                }
                else if (db.md_hanngach.Where(s => s.c_danhsachdathang_id == object_.c_danhsachdathang_id).Count() > 0)
                {
                    msg_del = string.Format(@"Lỗi:Đơn hàng ""{0}"" đã tạo phiếu giảm hạn ngạch.", object_.sochungtu);
                    msg += msg_del + "<br>";
                }
                else
                {
                    string action = "del";
                    string[] column_ex = { };
                    VNN_Function.SetFormValue("id", object_.c_danhsachdathang_id);
                    VNN_Function.Set_DefaultvalueColumn(context, action);
                    VNN_Function.Modify_Function(context, ma_module, null, ten_table, action, column_ex, db);

                    string str = VNN_VariablePublic.connectString_Anco(db);
                    SqlConnection cnn = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand(@"select * from c_dongdsdh where c_danhsachdathang_id = '" + object_.c_danhsachdathang_id + "'", cnn);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //disable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
                    cmd = new SqlCommand(@"
						ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateGoiHDLH
						ALTER TABLE c_danhsachdathang DISABLE TRIGGER updateSLDaDatTrenPO
						", cnn);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    //update c_danhsachdathang
                    cmd = new SqlCommand(@"
						update c_danhsachdathang set trangthai = 'CHUAGUI' where c_danhsachdathang_id = '" + object_.c_danhsachdathang_id + "'"
                    , cnn);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    //enable 2 procedure updateGoiHDLH va updateSLDaDatTrenPO
                    cmd = new SqlCommand(@"
						ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateGoiHDLH
						ALTER TABLE c_danhsachdathang ENABLE TRIGGER updateSLDaDatTrenPO
						", cnn);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
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