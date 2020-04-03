using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoTinhHinhXuatHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Báo Cáo Tình Hình Xuất Hàng.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
        //Response.Write(sql);
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

            tbl.Columns.Add("sum_dh", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_daxuat", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_conlai", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            report.DisplayName = "Đơn hàng chưa xuất";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;
            tbl.Rows[lastRow]["sum_dh"] = tbl.Compute("sum(dh)", string.Empty);
            tbl.Rows[lastRow]["sum_daxuat"] = tbl.Compute("sum(daxuat)", string.Empty);
            tbl.Rows[lastRow]["sum_conlai"] = tbl.Compute("sum(conlai)", string.Empty);

            var dh_cell = report.Report.FindControl("dh", true);
            dh_cell.DataBindings[0].FormatString = sothapphan;
            var daxuat_cell = report.Report.FindControl("daxuat", true);
            daxuat_cell.DataBindings[0].FormatString = sothapphan;
            var conlai_cell = report.Report.FindControl("conlai", true);
            conlai_cell.DataBindings[0].FormatString = sothapphan;

            var sum_dh_cell = report.Report.FindControl("sum_dh", true);
            sum_dh_cell.DataBindings[0].FormatString = sothapphan;
            var sum_daxuat_cell = report.Report.FindControl("sum_daxuat", true);
            sum_daxuat_cell.DataBindings[0].FormatString = sothapphan;
            var sum_conlai_cell = report.Report.FindControl("sum_conlai", true);
            sum_conlai_cell.DataBindings[0].FormatString = sothapphan;

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
        string tosx = context.Request.QueryString["tosx"];

        var tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        var den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59:59',103);

            select 
	            dsdh.so_po as donhang
	            , sp.ma_sanpham as mahang
	            , sp.mota_tiengviet as tensp
	            , dvtsp.ten_dvt as dvt
	            , (dh.sl_dathang - isnull(dh.sl_giamhanngach, 0)) as dh
	            , dh.sl_dagiao as daxuat
	            , dh.sl_conlai as conlai
	            , (
		            select top 1 xb.ngaychuyen
		            from md_xuatban xb
		            inner join md_xuatban_cdh cdh on cdh.md_xuatban_id = xb.md_xuatban_id
		            where cdh.md_sanpham_id = sp.md_sanpham_id
			            and cdh.sl_daxuat > 0
			            and cdh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
			            and xb.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
		            order by xb.ngaychuyen desc
	            ) as ngayxuat
                , N'Từ {0} đến {1}' as thang_nam
            from
	            c_danhsachdathang dsdh
	            left join c_dongdsdh dh on dh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
	            left join md_sanpham sp on sp.md_sanpham_id = dh.md_sanpham_id
	            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
            where
	            dsdh.md_trangthai_id = 'DAXULY'
	            and dh.han_giaohang between @tungay and @denngay
            order by
                dh.han_giaohang, dsdh.so_po
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , tosx
        );
        return sql;
    }
}

