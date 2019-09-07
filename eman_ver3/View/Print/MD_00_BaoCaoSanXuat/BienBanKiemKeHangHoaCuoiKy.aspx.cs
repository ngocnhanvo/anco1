using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoSanXuat_BangKeTienHangSPHT : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Biên Bản Kiểm Kê Hàng Hóa Cuối Kỳ.repx");
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

            tbl.Columns.Add("sum_slxuat", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;
            tbl.Rows[lastRow]["sum_thanhtien"] = tbl.Compute("sum(thanhtien)", string.Empty);
            tbl.Rows[lastRow]["sum_slxuat"] = tbl.Compute("sum(slxuat)", string.Empty);

            var slxuat_cell = report.Report.FindControl("slxuat", true);
            slxuat_cell.DataBindings[0].FormatString = sothapphan;

            var sum_slxuat_cell = report.Report.FindControl("slxuat", true);
            sum_slxuat_cell.DataBindings[0].FormatString = sothapphan;

            report.DataSource = ds;
            report.DataAdapter = da;
            ReportViewer1.Report = report;
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
		string tosx = context.Request.QueryString["tosx"];
		
		string sql = string.Format(@"	 
            declare @px nvarchar(32) = '872438a8a4544da495eff3918583f912';
            declare @tungay datetime = convert(datetime,N'01/08/2019 00:00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);

            select 
	            A.*
	            , (
		            select 
			            SUM(cdh.sl_daxuat) 
		            from 
			            md_xuatkhonb_cdh cdh
		            where 
			            cdh.lsx_to like N'%'+ A.thegiaoviec +'%'
			            and cdh.md_sanpham_id = A.md_sanpham_id
	            ) as toduc
            from
            (
	            select 
		            lsx.sochungtu as thegiaoviec
		            , sp.md_sanpham_id
		            , sp.ma_sanpham as ma_vthh
		            , dvtsp.ten_dvt as dvt
		            , cdh.sl_chiato as tongsl
	            from md_lenhsanxuat lsx
		            left join md_lenhsanxuat_tosx tsx on tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
		            left join md_lenhsanxuat_tosx_cdh cdh on tsx.md_lenhsanxuat_tosx_id = cdh.md_lenhsanxuat_tosx_id
		            left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id
	            where
		            lsx.md_trangthai_id = 'DAXL'
	            group by lsx.sochungtu, sp.md_sanpham_id, sp.ma_sanpham, cdh.sl_chiato, dvtsp.ten_dvt
            ) A
            order by A.thegiaoviec, A.ma_vthh
		"
        , thang
        , nam
        , tosx
        );
		return sql;
    }
}

