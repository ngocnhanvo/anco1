using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PrintControllers_MD_00_BaoCaoSanXuat_BienBanKiemKeSPDoDangTheoTungMH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Biên Bản Kiểm Kê SP Dở Dang Theo Từng Mặt Hàng.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
        // Response.Write(sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
    {
        var da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        var ds = new DataSet();
        da.Fill(ds);
        var tbl = ds.Tables[0];
        if (tbl.Rows.Count > 0)
        {
            var infoPrint = PrintAnco2.GetInfoPrint();

            tbl.Columns.Add("sumTongSL", Type.GetType("System.Double"));
            tbl.Columns.Add("sumChuaSX", Type.GetType("System.Double"));
            tbl.Columns.Add("sumTKDuc", Type.GetType("System.Double"));
            tbl.Columns.Add("sumTKBanCat", Type.GetType("System.Double"));
            tbl.Columns.Add("sumTKMai", Type.GetType("System.Double"));
            tbl.Columns.Add("sumTKHoanTat", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSoSach", Type.GetType("System.Double"));

            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            var thang = tbl.Rows[0]["thang"] + "";
            var nam = tbl.Rows[0]["thang"] + "";
            tbl.Rows[0]["logo"] = infoPrint.logo;
            report.DisplayName = "Biên Bản Kiểm Kê SP Dở Dang Chi Tiết - " + thang + "-" + nam;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            //Footer
            int lastRow = tbl.Rows.Count - 1;

            tbl.Rows[lastRow]["sumTongSL"] = tbl.Compute("sum(tongSL)", string.Empty);
            tbl.Rows[lastRow]["sumChuaSX"] = tbl.Compute("sum(chuaSX)", string.Empty);
            tbl.Rows[lastRow]["sumTKDuc"] = tbl.Compute("sum(tKDuc)", string.Empty);
            tbl.Rows[lastRow]["sumTKBanCat"] = tbl.Compute("sum(tKBanCat)", string.Empty);
            tbl.Rows[lastRow]["sumTKMai"] = tbl.Compute("sum(tKMai)", string.Empty);
            tbl.Rows[lastRow]["sumTKHoanTat"] = tbl.Compute("sum(tKHoanTat)", string.Empty);
            tbl.Rows[lastRow]["sumSoSach"] = tbl.Compute("sum(soSach)", string.Empty);

            var tongSL_cell = report.Report.FindControl("tongSL", true);
            var chuaSX_cell = report.Report.FindControl("chuaSX", true);
            var tKDuc_cell = report.Report.FindControl("tKDuc", true);
            var tKBanCat_cell = report.Report.FindControl("tKBanCat", true);
            var tKMai_cell = report.Report.FindControl("tKMai", true);
            var tKHoanTat_cell = report.Report.FindControl("tKHoanTat", true);
            var soSach_cell = report.Report.FindControl("soSach", true);
            var sumTongSL_cell = report.Report.FindControl("sumTongSL", true);
            var sumChuaSX_cell = report.Report.FindControl("sumChuaSX", true);
            var sumTKDuc_cell = report.Report.FindControl("sumTKDuc", true);
            var sumTKBanCat_cell = report.Report.FindControl("sumTKBanCat", true);
            var sumTKMai_cell = report.Report.FindControl("sumTKMai", true);
            var sumTKHoanTat_cell = report.Report.FindControl("sumTKHoanTat", true);
            var sumSoSach_cell = report.Report.FindControl("sumSoSach", true);

            tongSL_cell.DataBindings[0].FormatString =
            chuaSX_cell.DataBindings[0].FormatString =
            tKDuc_cell.DataBindings[0].FormatString =
            tKBanCat_cell.DataBindings[0].FormatString =
            tKMai_cell.DataBindings[0].FormatString =
            tKHoanTat_cell.DataBindings[0].FormatString =
            soSach_cell.DataBindings[0].FormatString =
            sumTongSL_cell.DataBindings[0].FormatString =
            sumChuaSX_cell.DataBindings[0].FormatString =
            sumTKDuc_cell.DataBindings[0].FormatString =
            sumTKBanCat_cell.DataBindings[0].FormatString =
            sumTKMai_cell.DataBindings[0].FormatString =
            sumTKHoanTat_cell.DataBindings[0].FormatString =
            sumSoSach_cell.DataBindings[0].FormatString = sothapphan;

            var Title_cell = report.Report.FindControl("xrTableCell11", true);
            Title_cell.Text = string.Format(Title_cell.Text, thang, nam);

            report.DataSource = ds;
            report.DataAdapter = da;
            if (string.IsNullOrEmpty(inPDF))
                ReportViewer1.Report = report;
            else
                Helper.viewFile(report);
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public string CreateSql(HttpContext context)
    {
        var infoPrint = PrintAnco2.GetInfoPrint();
        string thang = context.Request.QueryString["thang"];
        thang = thang.Length < 2 ? "0" + thang : thang;
        string nam = context.Request.QueryString["nam"];
        string px = context.Request.QueryString["px"];
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and dhpx.donhang_thamchieu like N'{0}'", donhang);
        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham like N'{0}'", masp);
        string sql = string.Format(@"	 
            declare @thang nvarchar(32) = '{0}';
            declare @nam nvarchar(32) = '{1}';
            declare @px nvarchar(32) = '{2}', @tenPX nvarchar(32) = '';
            
            declare @tungay datetime = convert(datetime, N'01/'+ @thang +N'/'+ @nam + N' 00:00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);
            set @tenPX = (select ten_phanxuong from md_phanxuong where md_phanxuong_id = @px)
    
            select 
	            A.*,
                A.tongSL - A.slDaDuc - A.tKDuc as chuaSX,
	            (A.tKDuc + A.tKBanCat + A.tKMai + A.tKHoanTat) as soSach,
                @thang as thang,
                @nam as nam,
                @tenPX as px
            from (
                select 
                    A.mahang,
                    A.dvt,
                    A.tongSL,
                    sum(A.slDaDuc) as slDaDuc,
                    sum(A.tKDuc) as tKDuc,
                    sum(A.tKBanCat) as tKBanCat,
                    sum(A.tKMai) as tKMai,
                    sum(A.tKHoanTat) as tKHoanTat
                from (
	                select
		                sp.ma_sanpham as mahang,
		                dvtsp.ten_dvt as dvt,
                        tsx.stt,
		                isnull((
			                select 
				                sum(dhpxDH.tong_sl_dat - isnull(dhpxDH.sl_giamhanngach, 0))
			                from 
				                md_dondathangphanxuong_cdh dhpxDH
			                where 
				                dhpxDH.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
				                and cdh.macuoi like N'%' + dhpxDH.macuoi + '%'
		                ), 0) as tongSL,
		                (
                            case when tsx.stt = 0 
                            then (
                                case when isnull(cdh.sl_dahoanthanh, 0) > cdh.sl_chiato
                                then cdh.sl_chiato + isnull(cdh.sl_nhapkho, 0)
                                else isnull(cdh.sl_dahoanthanh, 0) + isnull(cdh.sl_nhapkho, 0)
                                end
                            ) 
                            else 0 
                            end
                        ) as slDaDuc,
		                (case when tsx.stt = 0 then isnull(cdh.sl_nhapkho, 0) else 0 end) as tKDuc,
		                (case when tsx.stt = 1 then isnull(cdh.sl_nhapkho, 0) else 0 end) as tKBanCat,
		                (case when tsx.stt = 2 then isnull(cdh.sl_nhapkho, 0) else 0 end) as tKMai,
		                (case when tsx.stt = 9999 then isnull(cdh.sl_nhapkho, 0) else 0 end) as tKHoanTat
	                FROM 
		                md_lenhsanxuat_tosx_cdh cdh
		                left join md_lenhsanxuat_tosx tsx on cdh.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
		                left join md_lenhsanxuat lsx on lsx.md_lenhsanxuat_id = tsx.md_lenhsanxuat_id
		                left join md_dondathangphanxuong dhpx on dhpx.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id
		                left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
		                left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
	                where 
		                1=1
		                and lsx.ngaydkgiaotp between @tungay and @denngay
		                and lsx.md_phanxuong_id = @px
                        {3} {4}
                )A
                group by 
                    A.mahang, A.dvt, A.tongSL
            )A
            order by A.mahang
		"
        , thang
        , nam
        , px
        , donhang
        , masp
        );
        return sql;
    }
}

