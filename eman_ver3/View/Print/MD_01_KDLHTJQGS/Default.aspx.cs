using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_01_TKJQGS_Default : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string c_danhsachdathang_id = context.Request.QueryString["id"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Phiếu yêu cầu kiểm tra kiêm sửa chữa hàng tồn.repx");
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
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public String CreateSql(HttpContext context)
    {
        string c_doichieuhangton_id = context.Request.QueryString["id"];
        string sql = string.Format(@"
		    select distinct
                isnull(dcht_dklht.sl_lay, 0) as sl_hang
                , dcht_dklht.sl_conlai as sl_ton
                , sp.ma_sanpham as ma
                , dcht.so_donhang as donhang
                , dcht.donhang_thamchieu as dhtc
		    from c_doichieuhangton_dklht dcht_dklht
			    left join c_doichieuhangton_cddh cddh on dcht_dklht.md_sanpham_id = cddh.md_sanpham_id
			    left join md_sanpham sp on dcht_dklht.md_sanpham_id = sp.md_sanpham_id
                left join c_doichieuhangton dcht on dcht.c_doichieuhangton_id = dcht_dklht.c_doichieuhangton_id
		    where 
                dcht_dklht.c_doichieuhangton_id = '{0}' 
                and dcht_dklht.sl_lay > 0
		    order by sp.ma_sanpham asc
		"
        , c_doichieuhangton_id);
        return sql;
    }
}