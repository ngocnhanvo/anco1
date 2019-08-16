using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PrintControllers_MD_01_DHCPXJQGS_Default : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string c_danhsachdathang_id = context.Request.QueryString["id"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Đơn đặt hàng phân xưởng.repx");
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
        string c_kehoachdathang_dhcpx_id = context.Request.QueryString["id"];
        string sql = string.Format(@"
		select 
            getdate() as ngay
            , px.ten_phanxuong as xuong
            , dhcpx.sctdathang as dhso
            , dhcpx.donhang as dhtc
		    , (case when  SUBSTRING(sp.ma_sanpham,10,1) != 'F' then SUBSTRING(sp.ma_sanpham,0,9) + '.jpg' else SUBSTRING(sp.ma_sanpham,0,12) + '.jpg' end) as pic
		    , ddhpx.sochungtu as so
		    , sp.ma_sanpham as ma 
            , sp.mota_tiengviet as ten 
            , dvt.ten_dvt as dvt
            , dhcpx_cdh.noigiaohang as noigiaohang 
            , dhcpx_cdh.soluong as SL		
		    , dhcpx.ngayHTcham as ngaycham 
            , dhcpx.mota as hdlh
            , dhcpx.hdlh as huongdanlamhang
            , dhcpx.hdlhchung as huongdanlamhangchung
		from c_kehoachdathang_dhcpx dhcpx
		    left join md_dondathangphanxuong ddhpx on ddhpx.c_kehoachdathang_dhcpx_id = dhcpx.c_kehoachdathang_dhcpx_id
		    left join c_kehoachdathang_dhcpx_cdh dhcpx_cdh on dhcpx_cdh.c_kehoachdathang_dhcpx_id = dhcpx.c_kehoachdathang_dhcpx_id
		    left join md_phanxuong px on px.md_phanxuong_id = dhcpx.md_phanxuong_id
		    left join md_sanpham sp on sp.md_sanpham_id = dhcpx_cdh.md_sanpham_id
		    left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = dhcpx_cdh.md_donvitinhsanpham_id
		    left join c_danhsachdathang dsdh on dsdh.sochungtu = dhcpx.sctdathang
		where 
            dhcpx.c_kehoachdathang_dhcpx_id = '{0}' 
        order by sp.ma_sanpham asc"
        , c_kehoachdathang_dhcpx_id);
        return sql;

    }
}
