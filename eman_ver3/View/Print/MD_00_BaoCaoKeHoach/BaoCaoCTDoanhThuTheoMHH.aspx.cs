using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoCTDoanhThuTheoMHH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Báo Cáo Chi Tiết Doanh Thu Theo MHH.repx");
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

            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            report.DisplayName = "Chi tiết doanh thu theo mã hàng hóa";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;
            tbl.Rows[lastRow]["sum_soluong"] = tbl.Compute("sum(soluong)", string.Empty);
            tbl.Rows[lastRow]["sum_thanhtien"] = tbl.Compute("sum(thanhtien)", string.Empty);
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

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 00:00',103);
            select 
	            A.*
	            , (A.dongia * A.soluong) as thanhtien
                , N'Từ {0} đến {1}' as thang_nam
            from (
	            select
		            sp.ma_sanpham as mahang
		            , sp.mota_tiengviet as tensp
		            , dvtsp.ten_dvt as dvt
		            , sum(isnull(dsdh.sl_dagiao, 0)) as soluong
		            , isnull(dsdh.gianhap, 0) as dongia
	            from 
		            c_dongdsdh dsdh
		            left join md_sanpham sp on sp.md_sanpham_id = dsdh.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
	            where 
		            dsdh.sl_dagiao > 0
                    and dsdh.han_giaohang between @tungay and @denngay
	            group by
		            sp.ma_sanpham
		            , sp.mota_tiengviet
		            , dvtsp.ten_dvt
		            , dsdh.gianhap
            )A
            order by
	            A.mahang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        );
		return sql;
    }
}

