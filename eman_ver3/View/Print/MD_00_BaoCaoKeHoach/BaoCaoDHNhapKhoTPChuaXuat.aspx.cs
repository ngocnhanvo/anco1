using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoDHNhapKhoTPChuaXuat : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Báo Cáo Đơn Hàng Nhập Kho TP Chưa Xuất.repx";
        string nameRpt = "Báo Cáo Đơn Hàng Nhập Kho TP Chưa Xuất {thang_nam}";
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
	            A.slDH - A.slDXK as slCL,
                @thangNam as thang_nam
            from (
	            select distinct
		            dsdh.so_po as tenDH,
		            sp.ma_sanpham as maHang,
		            dvtsp.ten_dvt as dvt,
		            dh.sl_dathang - isnull(dh.sl_giamhanngach, 0) as slDHCP,
                    isnull((
		                select sum(isnull(cdvc.soluong_dachuyen, 0))
		                from md_vanchuyennoibo_cdvc cdvc
		                where cdvc.tenhang = dsdh.so_po
			                and cdvc.md_sanpham_id = sp.md_sanpham_id
			                and cdvc.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
                            and isnull(cdvc.lsx_to,'') != ''
	                ), 0) as slDH,
		            dh.sl_dagiao as slDXK
	            from 
		            md_kho_giaodich kgd
		            left join c_danhsachdathang dsdh on kgd.mota = dsdh.so_po
		            left join c_dongdsdh dh on dh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
		            left join md_sanpham sp on sp.md_sanpham_id = dh.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
	            where 
		            dongvanchuyen like N'PVC/%'
		            and sanxuat = 3
		            and kgd.md_sanpham_id = dh.md_sanpham_id
		            and kgd.kieuchuyen = N'Nhập kho'
                    and dsdh.trangthai != 'KETTHUC'
                    and kgd.ngaychuyen between @tungay and @denngay
                    {2} {3}
            )A
            where A.slDH - A.slDXK > 0
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

