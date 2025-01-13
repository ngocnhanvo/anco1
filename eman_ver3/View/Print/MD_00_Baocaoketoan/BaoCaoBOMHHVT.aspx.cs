using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaoketoan_BaoCaoBOMHHVT : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] BOM HHVT mới nhất.repx";
        string nameRpt = "BOM HHVT mới nhất {ngayin}";
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
    }

    public String CreateSql(HttpContext context)
    {
        string kho = context.Request.QueryString["kho"].removeAllSpaceOrTrimText(true).Replace("'", "''");
        if (!string.IsNullOrWhiteSpace(kho))
            kho = $@"and sp.khomacdinh = N'{kho}'";
        //San pham
        string masp = context.Request.QueryString["masp"].removeAllSpaceOrTrimText(true).Replace("'", "''");
        if (!string.IsNullOrWhiteSpace(masp))
            masp = $@"and sp.ma_sanpham = N'{masp}'";

        var fmtDate = "dd/MM/yyyy";
        string sql = $@"          
            select 
                format(getdate(), '{fmtDate}') as ngayin,
	            A.maHH,
	            A.phienban,
	            bvtsp.ma_sanpham as maVT,
	            bvt.soluong as sl
            from (
	            select A.*
	            from (
		            select
			            sp.ma_sanpham as maHH,
			            bom.ten_phienban as phienban,
			            bom.md_sanpham_bom_id,
			            RANK () OVER (partition by sp.ma_sanpham ORDER BY bom.ngay_hieuluc desc) AS Rank_no
		            from md_sanpham sp
			            left join md_sanpham_bom bom on bom.md_sanpham_id = sp.md_sanpham_id
		            where
			            1=1
			            and (sp.sanpham = 1 or sp.ban_thanhpham = 1)
                        {kho} {masp}
	            )A
	            where A.Rank_no = 1 and isnull(A.phienban,'') != ''
            )A 
	            left join md_sanpham_bom_vattu bvt on bvt.md_sanpham_bom_id = A.md_sanpham_bom_id
	            left join md_sanpham bvtsp on bvtsp.md_sanpham_id = bvt.md_sanpham_id
            where
	            1=1
            order by
	            A.maHH, A.phienban, bvtsp.ma_sanpham
		";

        return sql;
    }
}

