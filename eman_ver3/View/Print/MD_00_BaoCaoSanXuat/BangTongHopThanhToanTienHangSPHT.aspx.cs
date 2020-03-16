using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoSanXuat_BangTongHopThanhToanTienHangSPHT : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Bảng Tổng Hợp Thanh Toán Tiền Hàng Sản Phẩm Hoàn Thành.repx");
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

            tbl.Columns.Add("sum_tienhang", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            report.DisplayName = "Tổng hợp tiền hàng SPHT - " + tbl.Rows[0]["thang_nam"];
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;
            tbl.Rows[lastRow]["sum_tienhang"] = tbl.Compute("sum(tienhang)", string.Empty);
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
		
		string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'01/{0}/{1} 00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);
            select
	            A.px
                , A.tosx
	            , isnull(A.tienhang1, 0) + isnull(A.tienhang2, 0) as tienhang
	            , N'Tháng {0}/năm {1}' as thang_nam
            from (
	            select px.ten_phanxuong as px
	            , tosx.ten_to as [tosx]
                , tosx.sapxep
	            , (
		            select sum(
			            cdh.sl_daxuat * cdh.gianhancong
		            )
		            from md_xuatkhonb xnb (nolock)
			            left join md_xuatkhonb_cdh cdh (nolock) on cdh.md_xuatkhonb_id = xnb.md_xuatkhonb_id
			            left join md_kho kho (nolock) on kho.md_kho_id = xnb.tukho
		            where 
			            ngaychuyen between @tungay and @denngay
			            and xnb.bosung = 4
			            and kho.md_to_id = tosx.md_to_id and isnull(hangton, 0) = 0
	            ) as tienhang1
	            , (
		            select sum(
			            cdh.soluong_dachuyen * cdh.gianhancong
		            )
		            from md_vanchuyennoibo xnb (nolock)
			            left join md_vanchuyennoibo_cdvc cdh (nolock) on cdh.md_vanchuyennoibo_id = xnb.md_vanchuyennoibo_id
			            left join md_kho kho (nolock) on kho.md_kho_id = xnb.tukho
		            where 
			            ngaychuyen between @tungay and @denngay
			            and xnb.loaichuyen = 'VANCNBCTKGH'
			            and kho.md_to_id = tosx.md_to_id and isnull(hangton, 0) = 0
	            ) as tienhang2
	            FROM md_phanxuong px (nolock)
	            left join md_phanxuong_to tosx (nolock) on tosx.md_phanxuong_id = px.md_phanxuong_id
                where px.md_phanxuong_id = '{2}'
            )A
            where (isnull(A.tienhang1, 0) + isnull(A.tienhang2, 0)) > 0
            order by A.sapxep
		"
        , thang
        , nam
        , px
        );
		return sql;
    }
}

