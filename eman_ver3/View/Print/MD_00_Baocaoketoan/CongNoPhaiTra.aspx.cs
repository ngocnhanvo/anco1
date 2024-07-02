using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.Linq;
public partial class PrintControllers_MD_00_Baocaoketoan_CongNoPhaiTra : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] CÔNG NỢ PHẢI TRẢ.repx";
        string nameRpt = "CÔNG NỢ PHẢI TRẢ {ngayin}";
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
            var tendtkds = tbl.AsEnumerable().Select(s => s.Field<string>("tenDTKD")).Distinct().ToList();
            if (tendtkds.Count > 1)
            {
                tbl.Rows[0]["tenDTKD"] = "";
            }
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
	            ncc.sochungtu as sct,
	            format(ncc.ngaychuyen, '{fmtDate}') as ngaynk,
	            kh.donhang_thamchieu as donhang,
	            dtkd.ma_dtkd as maDTKD,
                dtkd.ten_dtkd as tenDTKD,
	            sp.ma_sanpham as maVTHH,
	            sp.mota_tiengviet as tenVTHH,
	            dvtsp.ten_dvt as dvt,
	            dmhDH.sl_dadat as sldh,
	            dh.sl_nhap as slnk,
	            dmhDH.dongiamua as dongia,
	            thue.giatri/100 as vat,
	            FLOOR(dmhDH.dongiamua * dh.sl_nhap) as thanhtien,
	            FLOOR(FLOOR(dmhDH.dongiamua * dh.sl_nhap) + FLOOR(dmhDH.dongiamua * dh.sl_nhap) * thue.giatri / 100) as thanhtienThue,
                ROW_NUMBER() OVER (PARTITION BY dtkd.ma_dtkd ORDER BY dtkd.ma_dtkd ASC) AS cr
            from md_nhapkho_ncc ncc
	            left join c_donmuahang dmh on dmh.c_donmuahang_id = ncc.c_donmuahang_id
	            left join c_donmuahang_cdmh dmhDH on dmhDH.c_donmuahang_id = ncc.c_donmuahang_id
	            left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
	            left join md_nhapkho_ncc_dh dh on dh.md_nhapkho_ncc_id = ncc.md_nhapkho_ncc_id
	            left join c_kehoachdathang kh on kh.c_kehoachdathang_id = dmh.c_kehoachdathang_dhncc_id
	            left join md_sanpham sp on sp.md_sanpham_id = dh.md_sanpham_id
	            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
	            left join md_thue_sanpham thue on thue.md_thue_sanpham_id = dmhDH.thue
            where
	            dmhDH.md_sanpham_id = dh.md_sanpham_id
	            and ncc.trangthai in ('{Helper.HIEULUC}')
	            and ncc.ngaychuyen between @tu and @den
                and dh.sl_nhap > 0
                {dtkd}
            order by
	            dtkd.ma_dtkd, ncc.ngaychuyen, sp.ma_sanpham
		";
        return sql;
    }
}