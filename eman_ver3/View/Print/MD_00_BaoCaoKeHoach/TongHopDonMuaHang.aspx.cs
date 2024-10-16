using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_TongHopDonMuaHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Tổng hợp đơn mua hàng.repx";
        string nameRpt = "TỔNG HỢP ĐƠN MUA HÀNG {ngayin}";
        string sql = CreateSql(context);

        var task = new System.Threading.Tasks.Task(() =>
        {
            viewReport(sql);
        });

        PrintAnco2.exportDataWithType(task, sql, inPDF, nameTemp, nameRpt, ReportViewer1, true);
    }

    public void viewReport(String SqlQuery)
    {
        var tbl = ((DataSet)ReportViewer1.Report.DataSource).Tables[0];
        if (tbl.Rows.Count > 0)
        {
        }
    }

    public String CreateSql(HttpContext context)
    {
        string tu = context.Request.QueryString["tu"].removeAllSpaceOrTrimText(true).Replace("-", "/");
        string den = context.Request.QueryString["den"].removeAllSpaceOrTrimText(true).Replace("-", "/");
        string dtkd = context.Request.QueryString["dtkd"].removeAllSpaceOrTrimText(true).Replace("'", "''");
        if (!string.IsNullOrWhiteSpace(dtkd))
            dtkd = $@"and dtkd.ma_dtkd = N'{dtkd}'";

        var fmtDate = "dd/MM/yyyy";
        string sql = $@"
		    declare @tu datetime = convert(datetime, N'{tu} 00:00:00', 103)
            declare @den datetime = convert(datetime, N'{den} 23:59:59', 103)

            select
	            format(getdate(), '{fmtDate}') as ngayin,
	            format(@tu, '{fmtDate}') as tungay,
	            format(@den, '{fmtDate}') as denngay,
	            dtkd.ma_dtkd as maNCC,
	            dmh.sochungtu as dmh,
	            sp.ma_sanpham as maVTHH,
	            sp.mota_tiengviet as tenVTHH,
	            dvtsp.ten_dvt as dvt,
	            cdh.dongiamua as dongia,
	            cdh.sl_dadat as slDMH,
	            cdh.sl_hanngach as slDG
            from c_donmuahang dmh
                left join c_donmuahang_cdmh cdh on cdh.c_donmuahang_id = dmh.c_donmuahang_id
	            left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
	            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
	            left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
            where
	            1=1
                and dmh.md_trangthai_id not in ('SOANTHAO', 'DANHAN')
	            and dmh.ngaygiaohang between @tu and @den
                {dtkd}
            order by
	            dmh.sochungtu, sp.ma_sanpham
		";

        return sql;
    }
}

