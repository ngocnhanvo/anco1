using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BangDeNghiThanhToanTienLenContVaCongGhep : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    public HttpContext context = HttpContext.Current;
    protected void Page_Load(object sender, EventArgs e)
    {
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Bảng Đề Nghị Thanh Toán Tiền Lên Cont Và Tiền Công Ghép Với Cơ Sở Khác.repx";
        string nameRpt = "Bảng Đề Nghị Thanh Toán Tiền Lên Cont Và Tiền Công Ghép Với Cơ Sở Khác {thang_nam}";
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

        tbl.Columns.Add("sumLenCont", Type.GetType("System.Double"));
        tbl.Columns.Add("sumCongGhep", Type.GetType("System.Double"));
        tbl.Columns.Add("sumCong", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["sumLenCont"] = tbl.Compute("sum(lenCont)", string.Empty);
        tbl.Rows[lastRow]["sumCongGhep"] = tbl.Compute("sum(congGhep)", string.Empty);
        tbl.Rows[lastRow]["sumCong"] = tbl.Compute("sum(cong)", string.Empty);
    }

    public string CreateSql(HttpContext context)
    {
        string viewAll = context.Request.QueryString["viewAll"];
        string thang = context.Request.QueryString["thang"];
        thang = thang.Length < 2 ? "0" + thang : thang;
        string nam = context.Request.QueryString["nam"];
        string donhang = context.Request.QueryString["donhang"];
        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and xb.donhang_thamchieu like N'{0}'", donhang);
        viewAll = viewAll == "1" ? "" : "and (isnull(xb.tienlencong, 0) + isnull(xb.tiencongghep, 0)) > 0";
        string sql = string.Format(@"
            declare @tungay datetime = convert(datetime,N'01/{0}/{1} 00:00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);
            declare @thang_nam nvarchar(MAX) = N'Tháng {0}/{1}';   

            select
	            xb.donhang_thamchieu as donHang,
	            xb.ngaychuyen as ngayXuatHang,
	            isnull(xb.tienlencong, 0) as lenCont,
	            isnull(xb.tiencongghep, 0) as congGhep,
                (isnull(xb.tienlencong, 0) + isnull(xb.tiencongghep, 0)) as cong,
                @thang_nam as thang_nam
            from 
	            md_xuatban xb
            where 
	            xb.ngaychuyen between @tungay and @denngay
	            and xb.trangthai = 'HIEULUC'
                and isnull(xb.xuat_thanhly, 0) = 0
                {2}
                {3}
            order by
                xb.ngaychuyen, xb.donhang_thamchieu
		"
        , thang
        , nam
        , donhang
        , viewAll
        );
		return sql;
    }
}

