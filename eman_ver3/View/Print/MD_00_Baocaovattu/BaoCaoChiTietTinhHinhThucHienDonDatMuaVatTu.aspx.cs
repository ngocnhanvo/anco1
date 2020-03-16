using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaovattu_baoCaoChiTietTinhHinhThucHienDonDatMuaVatTu : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[VT] Báo Cáo Chi Tiết Tình Hình Thực Hiện Đơn Đặt Mua Vật Tư.repx");
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

            tbl.Columns.Add("sum_sldonhang", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_sldanhan", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_slconlai", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            report.DisplayName = "Chi tiết tình hình thực hiện đơn mua VT";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            var sum_sldonhang = tbl.Compute("Sum(sl_donhang)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sum_sldonhang))
                tbl.Rows[lastRow]["sum_sldonhang"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_sldonhang"] = double.Parse(sum_sldonhang);

            var sum_sldanhan = tbl.Compute("Sum(sl_danhan)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sum_sldanhan))
                tbl.Rows[lastRow]["sum_sldanhan"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_sldanhan"] = double.Parse(sum_sldanhan);

            var sum_slconlai = tbl.Compute("Sum(sl_conlai)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sum_slconlai))
                tbl.Rows[lastRow]["sum_slconlai"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_slconlai"] = double.Parse(sum_slconlai);

            var sl_donhang_cell = report.Report.FindControl("sl_donhang", true);
            sl_donhang_cell.DataBindings[0].FormatString = sothapphan;
            var sl_danhan_cell = report.Report.FindControl("sl_danhan", true);
            sl_danhan_cell.DataBindings[0].FormatString = sothapphan;
            var sl_conlai_cell = report.Report.FindControl("sl_conlai", true);
            sl_conlai_cell.DataBindings[0].FormatString = sothapphan;

            var sumgroup_sldonhang_cell = (XRTableCell)report.Report.FindControl("sumgroup_sldonhang", true);
            sumgroup_sldonhang_cell.Summary.FormatString = sothapphan;
            var sumgroup_sldanhan_cell = (XRTableCell)report.Report.FindControl("sumgroup_sldanhan", true);
            sumgroup_sldanhan_cell.Summary.FormatString = sothapphan;
            var sumgroup_slconlai_cell = (XRTableCell)report.FindControl("sumgroup_slconlai", false);
            sumgroup_slconlai_cell.Summary.FormatString = sothapphan;

            var sum_sldonhang_cell = report.Report.FindControl("sum_sldonhang", true);
            sum_sldonhang_cell.DataBindings[0].FormatString = sothapphan;
            var sum_sldanhan_cell = report.Report.FindControl("sum_sldanhan", true);
            sum_sldanhan_cell.DataBindings[0].FormatString = sothapphan;
            var sum_slconlai_cell = report.Report.FindControl("sum_slconlai", true);
            sum_slconlai_cell.DataBindings[0].FormatString = sothapphan;

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
		DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
		DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
		string kho = context.Request.QueryString["kho"];
        string mavt = context.Request.QueryString["mavt"].Trim();
        string tenvt = context.Request.QueryString["tenvt"].Trim();
        string madtkd = context.Request.QueryString["madtkd"].Trim();
        string tendtkd = context.Request.QueryString["tendtkd"].Trim();

        mavt = mavt.Length > 0 ? string.Format(" AND sp.ma_sanpham = N'{0}'", mavt) : "";
        tenvt = tenvt.Length > 0 ? string.Format(" AND sp.mota_tiengviet like N'%{0}%'", tenvt) : "";
        madtkd = madtkd.Length > 0 ? string.Format(" AND dtkd.ma_dtkd = N'{0}'", madtkd) : "";
        tendtkd = tendtkd.Length > 0 ? string.Format(" AND dtkd.ten_dtkd like N'%{0}%'", tendtkd) : "";

        string sql = string.Format(@"	 
        declare @tungay datetime = convert(datetime,N'{1} 00:00',103);
        declare @denngay datetime = convert(datetime,N'{2} 23:59',103);
		select
            dtkd.ten_dtkd as ncc
            , dmh.sochungtu as sophieu
            , sp.ma_sanpham as ma_vthh
            , sp.mota_tiengviet as ten_vthh
            , sp.quycachdonggoi as quycach
            , dvtsp.ten_dvt as dvt
            , dh.sl_dadat as sl_donhang
            , dh.sl_hanngach as sl_danhan
            , (dh.sl_dadat - dh.sl_hanngach) as sl_conlai
            , dmh.ngaygiaohang
            , (
                SELECT isnull(nkncc.sochungtu + ',' + char(13), '')
	            FROM md_nhapkho_ncc nkncc
	            WHERE nkncc.c_donmuahang_id = dmh.c_donmuahang_id
	            FOR XML PATH(''),type
            ).value('.','nvarchar(max)') as phieunhapkho
            , @tungay as tungay
            , @denngay as denngay
		FROM c_donmuahang dmh
            left join c_donmuahang_cdmh dh on dh.c_donmuahang_id = dmh.c_donmuahang_id
            left join md_sanpham sp on dh.md_sanpham_id = sp.md_sanpham_id
            left join md_donvitinhsanpham dvtsp on dh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
            left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
        WHERE dmh.md_trangthai_id != N'SOANTHAO'
		    AND dmh.ngaydonhang >= @tungay
		    AND dmh.ngaydonhang <= @denngay
		    AND isnull(sp.vattu, 0) = 1
            {3}
            {4}
            {5}
            {6}
		ORDER BY dmh.sochungtu asc, sp.ma_sanpham asc
		"
        , ""
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , mavt
        , tenvt
        , madtkd
        , tendtkd
        );
		return sql;
    }
}

