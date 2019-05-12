<%@ WebHandler Language="C#" Class="JQGridMD_00_TongHopGiaModify" %>
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

public class JQGridMD_00_TongHopGiaModify : IHttpHandler, System.Web.SessionState.IRequiresSessionState
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
            case "CA_01_TongHopGia":
                this.CA_01_TongHopGia(context);
                break;
            case "CA_01_ExportTongHopGia":
                this.CA_01_ExportTongHopGia(context);
                break;
            case "savefile":
                this.SaveFile(context);
                break;
            default:
                break;
        }
    }

    public void CA_01_ExportTongHopGia(HttpContext context)
    {
        string msg = "";
        EntityContext db = new EntityContext();
        string str = "Data Source=.;Initial Catalog=eMan;Persist Security Info=True;User ID=eMan;Password=edoc,123";
        string id = context.Request.Form["id"];
        try
        {
            SqlConnection cnn = Mbg.Data.SqlClient.SqlHelper.GetConnection;
            SqlCommand cmd = new SqlCommand(@" select
			thg.ten_taphop as ten_phienbangia,
			sp.ma_sanpham as md_sanpham_id,
			sp.mota_tiengviet as mota_tiengviet,
			cdh.quydoi as gia,
			convert(nvarchar,cdh.ngay_pbghl,103) as ngay_hieuluc,
			pbg.ten_phienbangia as ten_phienbangia
			from md_taphopgia thg
			left join md_taphopgia_cdh cdh on cdh.md_taphopgia_id = thg.md_taphopgia_id
			left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
			left join md_phienbangia pbg on pbg.md_phienbangia_id = cdh.md_phienbangia_id
			where thg.md_taphopgia_id = '" + id + "'order by thg.ten_taphop asc, sp.ma_sanpham asc", cnn);
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
        rTitle.CreateCell(0).SetCellValue("Tên bảng giá");
        //rTitle.CreateCell(3).SetCellValue("Mô tả");
        rTitle.CreateCell(1).SetCellValue("Mã vật tư / hàng hóa");
        rTitle.CreateCell(2).SetCellValue("Tên vật tư / hàng hóa");
        rTitle.CreateCell(3).SetCellValue("Giá");
        rTitle.CreateCell(4).SetCellValue("Ngày hiệu lực");
        rTitle.CreateCell(5).SetCellValue("Tên phiên bảng giá");
        for (int j = 0; j <= 5; j++)
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
        String saveAsFileName = String.Format("TongHopGia-{0}.xls", DateTime.Now.ToString("dd-MM-yyyy"));
        MemoryStream exportData = new MemoryStream();
        hsswb.Write(exportData);
        context.Response.ContentType = "application/vnd.ms-excel";
        context.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));
        context.Response.Clear();
        context.Response.BinaryWrite(exportData.GetBuffer());
        context.Response.End();
    }

    public void CA_01_TongHopGia(HttpContext context)
    {
        string msg = "";
        string id = context.Request.Form["id"];
        User_TK us = VNN_Function.get_user(Security.id_taikhoan(context), Security.id_vaitro(context), Security.id_phongban(context));
        var db = new EntityContext();
        var thg = db.md_taphopgia.Where(s => s.md_taphopgia_id == id).FirstOrDefault();
        if (thg == null)
        {
            msg = "<div style='color:red'>Không tìm thấy đối tượng đã chọn</div>";
        }
        else if (thg.md_trangthai_id == "HIEULUC")
        {
            msg = "<div style='color:red'>Đã hiệu lực, không thể thao tác</div>";
        }
        else
        {
            string ntcId = db.md_namtaichinh.Where(s => s.giatri + "" == thg.nam).Select(s => s.md_namtaichinh_id).FirstOrDefault();
            var ntc_ky = db.md_namtaichinh_ky.Where(s => s.md_namtaichinh_id == ntcId & s.soky == thg.soky).FirstOrDefault();
            var nkt_kytruoc = ntc_ky.ngaybatdau.Value;
            var ntc_kytruoc = db.md_namtaichinh_ky.Where(s => s.ngayketthuc == nkt_kytruoc).FirstOrDefault();
            string kytruoc_nbd = ntc_ky.ngaybatdau.Value.ToString("dd/MM/yyyy"),
                    kytruoc_nkt = ntc_ky.ngayketthuc.Value.ToString("dd/MM/yyyy"),
                    soky = "0";
            if (ntc_kytruoc != null)
            {
                kytruoc_nbd = ntc_kytruoc.ngaybatdau.Value.ToString("dd/MM/yyyy");
                kytruoc_nkt = ntc_kytruoc.ngayketthuc.Value.ToString("dd/MM/yyyy");
                soky = ntc_kytruoc.soky + "";
            }
            var dt_tygia = Mbg.Data.SqlClient.SqlHelper.GetData("select [dbo].[GET_TyGia](N'" + DateTime.Now.ToString("dd/MM/yyyy") + "')");
            string tygia = dt_tygia.Rows[0][0].ToString();

            string sql = string.Format(@"
				INSERT  into md_taphopgia_cdh
					( md_taphopgia_cdh_id ,
					  md_taphopgia_id ,
					  md_sanpham_id ,
					  gia ,
					  md_dongtien_id ,
					  ngay_pbghl ,
					  tygia ,
					  quydoi ,
					  md_banggia_id ,
					  md_phienbangia_id,
					  mota
					)
					( SELECT    A.md_taphopgia_cdh_id ,
								A.md_taphopgia_id ,
								A.md_sanpham_id ,
								A.gia ,
								A.md_dongtien_id ,
								A.ngaydonhang AS ngay ,
								A.tygia ,
								(CASE WHEN A.md_dongtien_id = '385ec93024915838c98ef66e58b02e9b'
												 THEN CONVERT(DECIMAL(18, 4), N'22400.00')
													  * A.gia
												 ELSE A.gia
											END) AS quydoi ,
								A.md_banggia_id ,
								A.md_phienbangia_id,
								A.sochungtu
					  FROM      ( SELECT    REPLACE(NEWID(), '-', '') AS md_taphopgia_cdh_id ,
											N'{2}' AS md_taphopgia_id ,
											cdmh.md_sanpham_id ,
											( CASE WHEN thue.giatri != 0
												   THEN cdmh.dongiamua * thue.giatri / 100
														+ cdmh.dongiamua
												   ELSE cdmh.dongiamua
											  END ) AS gia ,
											bg.md_dongtien_id ,
											dmh.ngaydonhang ,
											CONVERT(DECIMAL(18, 4), N'22400.00') AS tygia ,
											bg.md_banggia_id ,
											pbg.md_phienbangia_id ,
											dmh.sochungtu
								  FROM      c_donmuahang_cdmh cdmh
											INNER JOin c_donmuahang dmh ON dmh.c_donmuahang_id = cdmh.c_donmuahang_id
											INNER JOin md_banggia bg ON bg.md_banggia_id = dmh.md_banggia_id
											INNER join md_phienbangia pbg ON pbg.md_banggia_id = bg.md_banggia_id
											INNER JOin md_thue_sanpham thue ON thue.md_thue_sanpham_id = cdmh.thue
								  WHERE     dmh.ngaydonhang >= CONVERT(DATETIME, N'{0} 00:00', 103)
											AND dmh.ngaydonhang <= CONVERT(DATETIME, N'{1} 23:59', 103)
											AND cdmh.dongiamua IS NOT NULL
											AND dmh.md_trangthai_id != N'SOANTHAO'
								) A
					  UNION
					  SELECT    REPLACE(NEWID(), '-', '') AS md_taphopgia_cdh_id ,
								N'{2}' AS md_taphopgia_id ,
								thg_cdh.md_sanpham_id ,
								thg_cdh.gia ,
								thg_cdh.md_dongtien_id ,
								thg_cdh.ngay_pbghl AS ngay ,
								thg_cdh.tygia ,
								thg_cdh.quydoi ,
								thg_cdh.md_banggia_id ,
								thg_cdh.md_phienbangia_id ,
								thg_cdh.mota
					  FROM      md_taphopgia_cdh thg_cdh
								INNER JOin md_taphopgia thg ON thg_cdh.md_taphopgia_id = thg.md_taphopgia_id
					  UNION
					  SELECT    REPLACE(NEWID(), '-', '') ,
								N'{2}' ,
								gsp.md_sanpham_id ,
								gsp.gia ,
								bg.md_dongtien_id ,
								pbg.ngay_hieuluc AS ngay ,
								CONVERT(DECIMAL(18, 4), N'{3}') AS tygia ,
								( CASE WHEN bg.md_dongtien_id = '385ec93024915838c98ef66e58b02e9b'
									   THEN CONVERT(DECIMAL(18, 4), N'{3}') * gsp.gia
									   ELSE gsp.gia
								  END ) AS quydoi ,
								bg.md_banggia_id ,
								pbg.md_phienbangia_id ,
								pbg.mota
					  FROM      md_phienbangia pbg
								INNER join md_giasanpham gsp ON gsp.md_phienbangia_id = pbg.md_phienbangia_id
								INNER JOin md_banggia bg ON bg.md_banggia_id = pbg.md_banggia_id
					  WHERE     pbg.ngay_hieuluc >= CONVERT(DATETIME, N'{0} 00:00', 103)
								AND pbg.ngay_hieuluc <= CONVERT(DATETIME, N'{1} 23:59', 103)
								AND gsp.gia IS NOT NULL
					  UNION
					  SELECT    REPLACE(NEWID(), '-', '') ,
								N'{2}' ,
								thg_cdh.md_sanpham_id ,
								thg_cdh.gia ,
								thg_cdh.md_dongtien_id ,
								thg_cdh.ngay_pbghl ,
								thg_cdh.tygia ,
								thg_cdh.quydoi ,
								thg_cdh.md_banggia_id ,
								thg_cdh.md_phienbangia_id,
								thg_cdh.mota
					  FROM      md_taphopgia_cdh thg_cdh
								INNER JOin md_taphopgia thg ON thg_cdh.md_taphopgia_id = thg.md_taphopgia_id
					  WHERE     thg.soky = {4}
								AND thg.nam = '{5}'
					)
				",
                ntc_ky.ngaybatdau.Value.ToString("dd/MM/yyyy"),
                ntc_ky.ngayketthuc.Value.ToString("dd/MM/yyyy"),
                thg.md_taphopgia_id,
                tygia,
                soky,
                thg.nam
           );
            string ex = Mbg.Data.SqlClient.SqlHelper.ExcuteNonQuery2(sql);

            if (ex == "")
            {
                sql = string.Format(@"
				ALTER TABLE md_taphopgia_cdh DISABLE TRIGGER update_remove_md_taphopgia_cdh
				delete from md_taphopgia_cdh
				where md_taphopgia_cdh_id not in
				(	
					select md_taphopgia_cdh_id from md_taphopgia_cdh thg_cdh
					where 
					thg_cdh.md_taphopgia_id = '{0}' and
					thg_cdh.md_taphopgia_cdh_id = 
					(
						select top 1 md_taphopgia_cdh_id from md_taphopgia_cdh
						where md_sanpham_id = thg_cdh.md_sanpham_id and
						md_taphopgia_id = '{0}'
						order by ngay_pbghl desc
					)
				)
				and md_taphopgia_id = '{0}'
				ALTER TABLE md_taphopgia_cdh ENABLE TRIGGER update_remove_md_taphopgia_cdh
				", thg.md_taphopgia_id);
                Mbg.Data.SqlClient.SqlHelper.ExcuteNonQuery2(sql);
            }
            else
            {
                msg = "<div style='color:red'>" + ex + "</div>";
            }

            if (msg.Length <= 0)
            {
                thg.md_trangthai_id = "HIEULUC";
                db.SaveChanges();
                msg = "<div style='color:blue'>Thành công: đã hiệu lực phiếu \"" + thg.ten_taphop + "\"</div>";
            }
        }
        context.Response.Write(msg);
    }

    public void add(HttpContext context)
    {
        EntityContext db = new EntityContext();
        string msg = "", id_new = Helper.getNewId();
        string ma_module = context.Request.QueryString["ma_module"];
        string nam = context.Request.Form["nam"];
        string soky = context.Request.Form["soky"];
        try
        {
            string id = context.Request.Form["id"];
            md_taphopgia chk_thg = db.md_taphopgia.Where(s => s.nam == nam & s.soky.ToString() == soky).FirstOrDefault();
            md_namtaichinh ntc = db.md_namtaichinh.Where(s => s.md_namtaichinh_id == nam).FirstOrDefault();

            if (chk_thg != null)
            {
                msg = "false#Lỗi: Đã tập hợp giá của kỳ " + soky + " năm " + ntc.giatri + " rồi.";
            }

            if (msg.Length <= 0)
            {
                string action = "add";
                string[] column_ex = { "nam" };
                string ten_table = "md_taphopgia";
                VNN_Function.SetFormValue("nam", ntc.giatri.ToString());
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
        string nam = context.Request.Form["nam"];
        string ma_module = context.Request.QueryString["ma_module"];
        try
        {
            string id = context.Request.Form["id"];
            md_taphopgia object_ = db.md_taphopgia.Where(p => p.md_taphopgia_id == id).Take(1).FirstOrDefault();
            md_namtaichinh ntc = db.md_namtaichinh.Where(s => s.md_namtaichinh_id == nam).FirstOrDefault();

            if (object_ == null)
            {
                msg = "false#Lỗi:Không tìm thấy đối tượng cần sửa ";
            }

            if (msg.Length <= 0)
            {
                string action = "edit";
                string[] column_ex = { "nam" };
                string ten_table = "md_taphopgia";
                VNN_Function.SetFormValue("nam", ntc.giatri.ToString());
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
            string ten_table = "md_taphopgia";
            int count = context.Request.Form["id"].Split(',').Count();
            string[] id_del = new string[count];
            id_del = context.Request.Form["id"].Split(',');
            for (int i = 0; i < count; i++)
            {
                msg_del = ""; var id_del_ = id_del[i];
                md_taphopgia object_ = db.md_taphopgia.Where(p => p.md_taphopgia_id == id_del_).Take(1).FirstOrDefault();
                if (object_ == null)
                {
                    msg_del = "Lỗi:Không tìm thấy đối tượng cần xóa " + i;
                    msg += msg_del + "\n";
                }
                if (msg_del.Length <= 0)
                {
                    db.md_taphopgia_cdh.RemoveRange(db.md_taphopgia_cdh.Where(s => s.md_taphopgia_id == object_.md_taphopgia_id));
                    db.md_taphopgia.Remove(object_);
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