using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoTHDoanhThuTheoDDH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Báo Cáo Tổng Hợp Doanh Thu Theo ĐĐH.repx");
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

            tbl.Columns.Add("sum_c51", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_c52", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_c53", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_c81CH", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_c81BG", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_c99", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_tongcong", Type.GetType("System.Double"));
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
            tbl.Rows[lastRow]["sum_c51"] = tbl.Compute("sum(c51)", string.Empty);
            tbl.Rows[lastRow]["sum_c52"] = tbl.Compute("sum(c52)", string.Empty);
            tbl.Rows[lastRow]["sum_c53"] = tbl.Compute("sum(c53)", string.Empty);
            tbl.Rows[lastRow]["sum_c81CH"] = tbl.Compute("sum(c81CH)", string.Empty);
            tbl.Rows[lastRow]["sum_c81BG"] = tbl.Compute("sum(c81BG)", string.Empty);
            tbl.Rows[lastRow]["sum_c99"] = tbl.Compute("sum(c99)", string.Empty);
            tbl.Rows[lastRow]["sum_tongcong"] = tbl.Compute("sum(tongcong)", string.Empty);

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
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and dsdh.so_po like N'{0}'", donhang);
        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham like N'{0}'", masp);
        var tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        var den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59:59',103);

            select 
	            A.*
	            , (isnull(A.c51, 0) + isnull(A.c52, 0) + isnull(A.c53, 0) + isnull(A.c81BG, 0) + isnull(A.c81CH, 0) + isnull(A.c99, 0)) as tongcong
	            from (
		            select 
			            dsdh.so_po as donhang
			            , dsdh.hangiaohang_po as ngayxonghang
			            , (
				            select sum((cdh.sl_dathang - isnull(cdh.sl_giamhanngach, 0)) * cdh.gianhap)
				            from c_dongdsdh cdh
				            inner join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
				            where
                                1=1
					            and cdh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
					            and substring(sp.ma_sanpham, 0, 3) = '51'
			            ) as c51
			            , (
				            select sum((cdh.sl_dathang - isnull(cdh.sl_giamhanngach, 0)) * cdh.gianhap)
				            from c_dongdsdh cdh
				            inner join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
				            where
                                1=1
					            and cdh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
					            and substring(sp.ma_sanpham, 0, 3) = '52'
			            ) as c52
			            , (
				            select sum((cdh.sl_dathang - isnull(cdh.sl_giamhanngach, 0)) * cdh.gianhap)
				            from c_dongdsdh cdh
				            inner join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
				            where
                                1=1
					            and cdh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
					            and substring(sp.ma_sanpham, 0, 3) = '53'
			            ) as c53
			            , (
				            select sum((cdh.sl_dathang - isnull(cdh.sl_giamhanngach, 0)) * cdh.gianhap)
				            from c_dongdsdh cdh
				            inner join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
				            where
                                1=1
					            and cdh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
					            and substring(sp.ma_sanpham, 0, 3) = '81'
					            and sp.ma_sanpham not like N'%F%'
			            ) as c81CH
			            , (
				            select sum((cdh.sl_dathang - isnull(cdh.sl_giamhanngach, 0)) * cdh.gianhap)
				            from c_dongdsdh cdh
				            inner join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
				            where
                                1=1
					            and cdh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
					            and substring(sp.ma_sanpham, 0, 3) = '81'
					            and sp.ma_sanpham like N'%F%'
			            ) as c81BG
			            , (
				            select sum((cdh.sl_dathang - isnull(cdh.sl_giamhanngach, 0)) * cdh.gianhap)
				            from c_dongdsdh cdh
				            inner join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
				            where
                                1=1
					            and cdh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
					            and substring(sp.ma_sanpham, 0, 3) = '99'
			            ) as c99
			            , N'Từ {0} đến {1}' as thang_nam
		            from
			            c_danhsachdathang dsdh
		            where
			            dsdh.trangthai = 'HIEULUC'
			            and dsdh.hangiaohang_po between @tungay and @denngay
                        {2}
            )A
            order by
                A.ngayxonghang, A.donhang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , donhang
        , masp
        );
        return sql;
    }
}

