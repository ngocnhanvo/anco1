using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_XuatBan_phieuGiaoHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string c_danhsachdathang_id = context.Request.QueryString["id"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Phiếu giao hàng.repx");
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
        string md_xuatban_id = context.Request.QueryString["id"];
        string sql = string.Format(@"
		select 
            sp.ma_sanpham as ma 
            , sp.mota_tiengviet as ten 
		    , dvtsp.ten_dvt as dvt
            , xb_cdh.sl_muonxuat as slgiao
            , xb.sochungtu as so
            , xb.sctdathang as sct_donhang
            , xb.donhang_thamchieu as so_po
            , xb.diachi as diadiemgiaohang
            , xb.mota as diengiai
		from md_xuatban_cdh xb_cdh
            left join md_xuatban xb on xb.md_xuatban_id = xb_cdh.md_xuatban_id
		    left join md_sanpham sp on xb_cdh.md_sanpham_id = sp.md_sanpham_id
		    left join md_donvitinhsanpham dvtsp on xb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
		where 
            xb_cdh.md_xuatban_id = '{0}' 
        order by sp.ma_sanpham asc
		", md_xuatban_id
        );
        return sql;
    }
}
