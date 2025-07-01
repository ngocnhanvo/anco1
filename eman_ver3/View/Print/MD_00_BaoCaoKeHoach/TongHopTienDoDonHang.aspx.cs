using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_TongHopTienDoDonHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "(GD) Tổng hợp tiến độ đơn hàng.repx";
        string nameRpt = "TỔNG HỢP TIẾN ĐỘ ĐƠN HÀNG {ngayin}";
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

        var fmtDate = Helper.fmtDate;
        string sql = $@"
		    declare @tu datetime = convert(datetime, N'{tu} 00:00:00', 103)
            declare @den datetime = convert(datetime, N'{den} 23:59:59', 103)
            declare @fmtD nvarchar(10) = '{fmtDate}';

            select
                format(getdate(), @fmtD) as ngayin,
                format(@tu, @fmtD) as tungay,
                format(@den, @fmtD) as denngay,
	            A.*,
	            isnull(tho.tontho, 0) as tontho,
	            isnull(tho.sltho, 0) as sltho,
	            isnull(tho.sltho2, 0) as sltho2
            from (
	            select
		            dmh.so_po as donhang,
		            sp.ma_sanpham as maVTHH,
		            sp.mota_tiengviet as tenVTHH,
		            dvtsp.ten_dvt as dvt,
		            sum(cdh.sl_dat - isnull(cdh.sl_giamhanngach, 0)) as sldh,
		            sum(isnull(cdh.sl_nhapkho, 0)) as tontp,
		            sum(isnull(cdh.sl_danhapkho, 0)) as sltp,
		            sum(cdh.sl_dat - isnull(cdh.sl_giamhanngach, 0) - isnull(cdh.sl_danhapkho, 0)) as sltp2
	            from c_danhsachdathang dmh
		            left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
		            left join md_lenhsanxuat lsx on lsx.donhang_thamchieu = dmh.so_po
		            left join md_lenhsanxuat_tosx_cdh cdh on cdh.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id and cdh.stt = 9999
		            left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
	            where
		            1=1
		            and dmh.hangiaohang_po between @tu and @den
		            and dmh.anco_check = 1
                    {dtkd}
	            group by
		            cdh.md_sanpham_id, 
		            dmh.so_po,
		            sp.ma_sanpham, 
		            sp.mota_tiengviet, 
		            dvtsp.ten_dvt
            )A
            outer apply (
	            select 
		            sum(isnull(cdh.sl_nhapkho, 0)) as tontho, 
		            sum(isnull(cdh.sl_danhapkho, 0)) as sltho,
		            sum(isnull(cdh.sl_chiato, 0) - isnull(cdh.sl_danhapkho, 0)) as sltho2
	            from md_lenhsanxuat lsx
	            inner join md_lenhsanxuat_tosx_cdh cdh on cdh.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
                inner join md_sanpham spc on spc.md_sanpham_id = cdh.md_sanpham_id
	            where
		            lsx.donhang_thamchieu = A.donhang
		            and cdh.stt = 9998
		            and cdh.macuoi = A.maVTHH
                    and spc.vattu = 0
	            group by
		            cdh.macuoi
            ) tho
            order by
                A.donhang, A.maVTHH
		";

        return sql;
    }
}

