using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoDonHangNhapKhoTP : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Báo Cáo Đơn Hàng Nhập Kho Thành Phẩm.repx");
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

            tbl.Columns.Add("sum_slDonHang", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_slNhapKho", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_slConLai", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            report.DisplayName = "Báo cáo tiến độ sản xuất";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;

            tbl.Rows[lastRow]["sum_slDonHang"] = tbl.Compute("sum(slDonHang)", string.Empty);
            tbl.Rows[lastRow]["sum_slNhapKho"] = tbl.Compute("sum(slNhapKho)", string.Empty);
            tbl.Rows[lastRow]["sum_slConLai"] = tbl.Compute("sum(slConLai)", string.Empty);

            var slDonHang_cell = report.Report.FindControl("slDonHang", true);
            var slNhapKho_cell = report.Report.FindControl("slNhapKho", true);
            var slConLai_cell = report.Report.FindControl("slConLai", true);
            var sum_slDonHang_cell = report.Report.FindControl("sum_slDonHang", true);
            var sum_slNhapKho_cell = report.Report.FindControl("sum_slNhapKho", true);
            var sum_slConLai_cell = report.Report.FindControl("sum_slConLai", true);

            slDonHang_cell.DataBindings[0].FormatString =
            slNhapKho_cell.DataBindings[0].FormatString =
            slConLai_cell.DataBindings[0].FormatString =
            sum_slDonHang_cell.DataBindings[0].FormatString =
            sum_slNhapKho_cell.DataBindings[0].FormatString =
            sum_slConLai_cell.DataBindings[0].FormatString = sothapphan;

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
        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];

        var tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        var den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and dsdh.so_po like N'{0}'", donhang);
        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham like N'{0}'", masp);

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 00:00',103);
            
            select 
                A.*,
                (A.slDonHang - A.slNhapKho) as slConLai,
                N'Từ {0} đến {1}' as thang_nam
            from (
                select 
	                dsdh.so_po as tenDonHang, 
	                sp.ma_sanpham as maHang,
	                dvtsp.ten_dvt as dvt,
	                (dh.sl_dathang - isnull(dh.sl_giamhanngach, 0)) as slDonHang,
	                isnull((
		                select sum(isnull(cdvc.soluong_dachuyen, 0))
		                from md_vanchuyennoibo_cdvc cdvc
		                where cdvc.tenhang = dsdh.so_po
			                and cdvc.md_sanpham_id = sp.md_sanpham_id
			                and cdvc.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
	                ), 0) as slNhapKho
                from c_danhsachdathang dsdh
                left join c_dongdsdh dh on dh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
                left join md_sanpham sp on sp.md_sanpham_id = dh.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
                where 
                    dsdh.hangiaohang_po between @tungay and @denngay
                    {2}
                    {3}
            )A
            order by A.tenDonHang, A.maHang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , donhang
        , masp
        );
        return sql;
    }
}

