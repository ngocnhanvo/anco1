using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PrintControllers_MD_00_XuatBanThanhLy_LenhXuatKho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KT] Lệnh Xuất Kho.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
        //Response.Write(sql);
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
            var soluong = report.Report.FindControl("soluong", true);
            soluong.DataBindings[0].FormatString = sothapphan;
            var ghino = report.Report.FindControl("ghino", true);
            ghino.DataBindings[0].FormatString = sothapphan;
            var truno = report.Report.FindControl("truno", true);
            truno.DataBindings[0].FormatString = sothapphan;
            var tongcong = report.Report.FindControl("tongcong", true);
            tongcong.DataBindings[0].FormatString = sothapphan;
            var thucxuat = report.Report.FindControl("thucxuat", true);
            thucxuat.DataBindings[0].FormatString = sothapphan;

            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_tongcong", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            var ngaydenghi = tbl.Rows[0]["ngaydenghi"] as DateTime?;
            tbl.Rows[0]["dd"] = ngaydenghi.Value.ToString("dd");
            tbl.Rows[0]["MM"] = ngaydenghi.Value.ToString("MM");
            tbl.Rows[0]["yyyy"] = ngaydenghi.Value.ToString("yyyy");
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["sum_soluong"] = double.Parse(tbl.Compute("Sum(soluong)", string.Empty).ToString());
            tbl.Rows[lastRow]["sum_tongcong"] = double.Parse(tbl.Compute("Sum(tongcong)", string.Empty).ToString());
            var sum_soluong = report.Report.FindControl("sum_soluong", true);
            sum_soluong.DataBindings[0].FormatString = sothapphan;
            var sum_tongcong = report.Report.FindControl("sum_tongcong", true);
            sum_tongcong.DataBindings[0].FormatString = sothapphan;
            this.ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public String CreateSql(HttpContext context)
    {
        string md_xuatban_id = context.Request.QueryString["id"];
        string oper = context.Request.QueryString["oper"];
        string sql = string.Format(@"
		    select 
                sp.ma_sanpham as ma_vthh 
                , sp.mota_tiengviet as ten_vthh
                , sp.quycachdonggoi as quycach
		        , dvtsp.ten_dvt as dvt
                , xb.sochungtu as sct_lsx
                , xb.ngaydenghi
                , null as xuatcho
                , null as bophan
                , kho.ten_kho as khoxuat
                , xb.mota as diengiai
                , nknb_cdh.tong_sl_xuat as soluong
                , 0 as ghino
                , 0 as truno
                , null as thucxuat
                , nknb_cdh.tong_sl_xuat as tongcong
		    from md_xuatban xb
		        left join md_xuatban_cdh nknb_cdh on xb.md_xuatban_id = nknb_cdh.md_xuatban_id
                left join md_sanpham sp on nknb_cdh.md_sanpham_id = sp.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on nknb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
                left join md_kho kho on xb.tukho = kho.md_kho_id
		    where 
                nknb_cdh.md_xuatban_id = '{0}'
                and nknb_cdh.tong_sl_xuat > 0
            order by sp.ma_sanpham asc
		"
        , md_xuatban_id
        );
        //
        return sql;
    }
}




