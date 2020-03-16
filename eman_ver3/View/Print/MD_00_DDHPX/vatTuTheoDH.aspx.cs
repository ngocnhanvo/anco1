using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_DDHPX_vatTuTheoDH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] VT theo đơn đặt hàng phân xưởng.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
    {
        SqlDataAdapter da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        report.DataSource = ds;
        report.DataAdapter = da;
        var tbl = ds.Tables[0];
        if (tbl.Rows.Count > 0)
        {
            var infoPrint = PrintAnco2.GetInfoPrint();
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            report.DisplayName = tbl.Rows[0]["dhtc"] + "-RP018";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
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
        string md_dondathangphanxuong_id = context.Request.QueryString["id"];
		string dec = context.Request.QueryString["dec"];	
		string thous = context.Request.QueryString["thous"];
        string sql = string.Format(@"
		select getdate() as ngay
		, px.ten_phanxuong as xuong
		, ddhpx.sochungtu as so, ddhpx.sctdathang as dhso, ddhpx.donhang_thamchieu as dhtc
		, sp.ma_sanpham as ma , sp.mota_tiengviet as ten, dvt.ten_dvt as dvt
		, cdh.soluong as SL
		from md_dondathangphanxuong ddhpx
		left join md_dondathangphanxuong_vattu cdh on cdh.md_dondathangphanxuong_id = ddhpx.md_dondathangphanxuong_id
		left join md_phanxuong px on px.md_phanxuong_id = ddhpx.md_phanxuong_id
		left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
		left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id
		where ddhpx.md_dondathangphanxuong_id = '{0}'
		order by sp.ma_sanpham asc
		", md_dondathangphanxuong_id, dec, thous);
        return sql;
    }
}