using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BangDeNghiThanhToanTienCongDongGoi : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    public InfoPrint infoPrint = PrintAnco2.GetInfoPrint();
    public HttpContext context = HttpContext.Current;
    protected void Page_Load(object sender, EventArgs e)
    {
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Bảng Đề Nghị Thanh Toán Tiền Công Đóng Gói.repx";
        string nameRpt = "Bảng Đề Nghị Thanh Toán Tiền Công Đóng Gói {thang_nam}";
        string sql = CreateSql(context);

        var task = new System.Threading.Tasks.Task(() =>
        {
            viewReport(sql);
        });

        PrintAnco2.exportDataWithType(task, sql, inPDF, nameTemp, nameRpt, ReportViewer1, true);
    }

    public void viewReport(String SqlQuery)
    {
        var tbl = ((DataSet)ReportViewer1.Report.DataSource).Tables[0];

        tbl.Columns.Add("sumSoTien", Type.GetType("System.Double"));
        tbl.Columns.Add("sumCong", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["sumSoTien"] = tbl.Compute("sum(soTien)", string.Empty);
    }

    public string CreateSql(HttpContext context)
    {
        string thang = context.Request.QueryString["thang"];
        thang = thang.Length < 2 ? "0" + thang : thang;
        string nam = context.Request.QueryString["nam"];
        string donhang = context.Request.QueryString["donhang"];
        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and xb.donhang_thamchieu like N'{0}'", donhang);

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'01/{0}/{1} 00:00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);
            declare @thang_nam nvarchar(MAX) = N'Tháng {0}/{1}';   

            select
	            xb.donhang_thamchieu as donHang,
	            xb.ngaychuyen as ngayDGXong,
	            isnull(xb.tiencongDG, 0) as soTien,
                @thang_nam as thang_nam
            from 
	            md_vanchuyennoibo xb
            where 
	            xb.ngaychuyen between @tungay and @denngay
	            and xb.md_trangthai_id = 'HIEULUC'
	            and xb.loaichuyen = 'VCTPDG'
                and isnull(xb.tiencongDG, 0) > 0
                {2}
            order by
                xb.ngaychuyen, xb.donhang_thamchieu
		"
        , thang
        , nam
        , donhang
        );
		return sql;
    }
}

