using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.Linq;
public partial class PrintControllers_MD_00_Baocaoketoan_TienNhanCongSX : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] Tiền nhân công sản xuất.repx";
        string nameRpt = "Tiền nhân công sản xuất {ngayin}";
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
        string donhanghuy = System.IO.File.ReadAllText(ExcuteSignalRStatic.mapPathSignalR("~/App_Data/JsonData/0_donhanghuy.txt"));
        donhanghuy = donhanghuy.Replace("\r\n", "',N'");
        string tu = context.Request.QueryString["tu"].removeAllSpaceOrTrimText(true).Replace("-", "/");
        string den = context.Request.QueryString["den"].removeAllSpaceOrTrimText(true).Replace("-", "/");

        //Bo Phan
        string boPhan = context.Request.QueryString["boPhan"].removeAllSpaceOrTrimText(true).Replace("'", "''");
        string boPhanSel = boPhan;
        if (!string.IsNullOrWhiteSpace(boPhan))
            boPhan = $@"and (pb.md_phongban_id = N'{boPhan}' or pbCha1.md_phongban_id = N'{boPhan}' or pbCha2.md_phongban_id = N'{boPhan}')";
        //San pham
        string masp = context.Request.QueryString["masp"].removeAllSpaceOrTrimText(true).Replace("'", "''");
        if (!string.IsNullOrWhiteSpace(masp))
            masp = $@"and sp.ma_sanpham = N'{masp}'";

        var fmtDate = Helper.fmtDate;
        var ngayin = DateTime.Now.ToString(fmtDate);
        var tuStr = tu.ToNullableDateTime(fmtDate).Value.ToString(fmtDate);
        var denStr = den.ToNullableDateTime(fmtDate).Value.ToString(fmtDate);
        string sql = $@"
		    DECLARE @tu DATETIME = CONVERT(DATETIME, N'{tu} 00:00:00', 103)
            DECLARE @den DATETIME = CONVERT(DATETIME, N'{den} 23:59:59', 103)

            DECLARE @pbSel NVARCHAR(MAX) = (
                SELECT ten_phongban 
                FROM ad_department 
                WHERE md_phongban_id = '{boPhanSel}'
            )

            ;WITH data AS (
                select
	                nk.sochungtu,
	                nk.ngayhieuluc,
	                nk.donhang_thamchieu,
	                sp.ma_sanpham,
	                cdh.sl_nhap,
	                gsp.gia,
	                pb.ten_phongban as px
                from 
	                md_nhapkhonb nk
	                left join md_nhapkhonb_cdh cdh on cdh.md_nhapkhonb_id = nk.md_nhapkhonb_id
	                left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
	                left join md_lenhsanxuat2 lsx on lsx.sochungtu = nk.chungtu_lenhsx
	                left join ad_department pb on pb.md_phongban_id = lsx.xuongPhu
                    LEFT JOIN ad_department pbCha1 ON pbCha1.md_phongban_id = pb.phongbanChaId
                    LEFT JOIN ad_department pbCha2 ON pbCha2.md_phongban_id = pbCha1.phongbanChaId
	                left join md_banggia bg on bg.lienket_bg = pb.ma_phongban and bg.tuychon = 'NHANCONG'
	                OUTER APPLY (
                        SELECT TOP 1 pbi.md_phienbangia_id
                        FROM md_phienbangia pbi
                        WHERE pbi.md_banggia_id = bg.md_banggia_id
                          AND pbi.ngay_hieuluc <= GETDATE()
                        ORDER BY pbi.ngay_hieuluc DESC
                    ) pbg_top
	                left join md_giasanpham gsp on gsp.md_phienbangia_id = pbg_top.md_phienbangia_id
                where
	                nk.trangthai = N'{Helper.HIEULUC}'
                    AND nk.ngayhieuluc BETWEEN @tu AND @den {boPhan} {masp}
            )

            SELECT
                N'{ngayin}' ngayin,
                N'{tuStr}' tungay,
                N'{denStr}' denngay,
                sochungtu,
	            ngayhieuluc,
	            donhang_thamchieu,
	            ma_sanpham,
	            sl_nhap,
	            gia,
	            px
            FROM 
                data
            order by 
	            ngayhieuluc,
	            sochungtu,
	            ma_sanpham
		";

        //throw new Exception(sql);
        return sql;
    }
}