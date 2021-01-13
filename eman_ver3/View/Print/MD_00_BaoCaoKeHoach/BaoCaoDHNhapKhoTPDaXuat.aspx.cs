using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoDHNhapKhoTPDaXuat : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Báo Cáo Đơn Hàng Nhập Kho TP Đã Xuất.repx";
        string nameRpt = "Báo Cáo Đơn Hàng Nhập Kho TP Đã Xuất {thang_nam}";
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
        tbl.Columns.Add("sumSLDH", Type.GetType("System.Double"));
        tbl.Columns.Add("sumSLDXK", Type.GetType("System.Double"));
        tbl.Columns.Add("sumSLCL", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["sumSLDH"] = tbl.Compute("sum(slDH)", string.Empty);
        tbl.Rows[lastRow]["sumSLDXK"] = tbl.Compute("sum(slDXK)", string.Empty);
        tbl.Rows[lastRow]["sumSLCL"] = tbl.Compute("sum(slCL)", string.Empty);

        var slDH = ReportViewer1.Report.Report.FindControl("slDH", true);
        var slDXK = ReportViewer1.Report.Report.FindControl("slDXK", true);
        var slCL = ReportViewer1.Report.Report.FindControl("slCL", true);
        var sumSLDH = ReportViewer1.Report.Report.FindControl("sumSLDH", true);
        var sumSLDXK = ReportViewer1.Report.Report.FindControl("sumSLDXK", true);
        var sumSLCL = ReportViewer1.Report.Report.FindControl("sumSLCL", true);
        slDH.DataBindings[0].FormatString =
        slDXK.DataBindings[0].FormatString =
        slCL.DataBindings[0].FormatString =
        sumSLDH.DataBindings[0].FormatString =
        sumSLDXK.DataBindings[0].FormatString =
        sumSLCL.DataBindings[0].FormatString = sothapphan;
    }

    public string CreateSql(HttpContext context)
    {
        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];

        var tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        var den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and dsdh.so_po like N'{0}'", donhang);
        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham like N'{0}'", masp);

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 00:00',103);
            declare @thangNam nvarchar(MAX) = N'Từ {0} đến {1}';             

            select 
	            A.*,
	            A.slDH - A.slDXK as slCL
            from (
	            select 
		            A.tenDH,
		            sp.ma_sanpham as maHang,
		            dvtsp.ten_dvt as dvt,
		            dh.sl_dathang - isnull(dh.sl_giamhanngach, 0) as slDH,
		            (
			            select sum(kgd.soluong_dichchuyen)
			            from md_kho_giaodich (nolock) kgd
			            where 
				            1=1
				            and kgd.mota = A.tenDH
				            and kgd.md_sanpham_id = A.md_sanpham_id
				            and kgd.md_donvitinhsanpham_id = A.md_donvitinhsanpham_id
				            and dongnhapxuat like N'PXKXB/%'
				            and kgd.ngaychuyen <= @denngay
		            ) as slDXK
	            from (
		            select
			            kgd.mota as tenDH,
			            kgd.md_sanpham_id,
			            kgd.md_donvitinhsanpham_id
		            from 
			            md_kho_giaodich (nolock) kgd
		            where 
			            dongnhapxuat like N'PXKXB/%'
			            and kgd.ngaychuyen between @tungay and @denngay
		            group by
			            kgd.mota,
			            kgd.md_sanpham_id,
			            kgd.md_donvitinhsanpham_id
	            )A
	            left join c_danhsachdathang (nolock) dsdh on A.tenDH = dsdh.so_po
	            left join c_dongdsdh (nolock) dh on dh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
	            left join md_sanpham (nolock) sp on sp.md_sanpham_id = dh.md_sanpham_id
	            left join md_donvitinhsanpham (nolock) dvtsp on dvtsp.md_donvitinhsanpham_id = A.md_donvitinhsanpham_id
	            where
		            A.md_sanpham_id = dh.md_sanpham_id
                    {2} {3}
            )A
            where 1=1
            order by A.tenDH, A.maHang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , donhang
        , masp
        );
        return sql;
    }
}

