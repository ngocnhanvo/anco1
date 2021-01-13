using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaoketoan_BienBanKiemKeVatTuHH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] Biên Bản Kiểm Kê Vật Tư Hàng Hóa.repx";
        string nameRpt = "Biên Bản Kiểm Kê Vật Tư Hàng Hóa";
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
        tbl.Columns.Add("sumSLTTKiemKe2", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["sumSLTTKiemKe2"] = tbl.Compute("Sum(sLTTKiemKe2)", string.Empty);

        var sLTTKiemKe = ReportViewer1.Report.Report.FindControl("sLTTKiemKe", true);
        var sumSLTTKiemKe = ReportViewer1.Report.Report.FindControl("sumSLTTKiemKe", true);
        sLTTKiemKe.DataBindings[0].FormatString =
        sumSLTTKiemKe.DataBindings[0].FormatString = sothapphan;
    }

    public string CreateSql(HttpContext context)
    {
        string nnk = context.Request.QueryString["nnk"];
        string kho = context.Request.QueryString["kho"];
        DateTime nnkD = DateTime.ParseExact(nnk, "dd-MM-yyyy", null);
        string thang_nam = "Tại thời điểm ngày " + (nnkD.Day >= 10 ? nnkD.Day + "" : "0" + nnkD.Day)
            + " tháng " + (nnkD.Month >= 10 ? nnkD.Month + "" : "0" + nnkD.Month)
            + " năm " + nnkD.Year;
        
        string sql = string.Format(@"     
            declare @nnk datetime = convert(datetime,N'{0} 23:59:59',103);
            declare @kho nvarchar(32) = N'{1}';
            declare @thang_nam nvarchar(MAX) =  N'{2}'

            declare @tenKho nvarchar(MAX) = (select ten_kho from md_kho where md_kho_id = @kho)

            select 
	            A.*,
                null as sLTTKiemKe,
                @thang_nam as thang_nam
            from (
	            select
		            sp.ma_sanpham as maHang,
		            sp.mota_tiengviet as tenHang,
                    dvtsp.ten_dvt as dvt,
		            (
			            select sum(A.sl) as sl
			            from (
				            select (case when kieuchuyen = N'Nhập kho' then kgd.soluong_dichchuyen else 0 - kgd.soluong_dichchuyen end) as sl
				            from md_kho_giaodich kgd
				            where 
					            kgd.md_kho_id = ksp.md_kho_id
					            and kgd.md_sanpham_id = ksp.md_sanpham_id
					            and kgd.ngaychuyen <= @nnk
			            )A
		            ) as sLTTKiemKe2,
		            @tenKho as kho
	            FROM md_kho_sanpham ksp
		            left join md_sanpham sp on sp.md_sanpham_id = ksp.md_sanpham_id
                    left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
	            WHERE
		            ksp.md_kho_id = @kho
            )A
            where A.sLTTKiemKe2 > 0
            ORDER BY A.tenHang, A.dvt
		"
        , nnkD.ToString("dd/MM/yyyy")
        , kho
        , thang_nam
        );
		return sql;
    }
}

