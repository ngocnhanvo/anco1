using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoCTDoanhThuTheoMHH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    public HttpContext context = HttpContext.Current;
    protected void Page_Load(object sender, EventArgs e)
    {
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Báo Cáo Chi Tiết Doanh Thu Theo MHH.repx";
        string nameRpt = "Chi tiết doanh thu theo mã hàng hóa {thang_nam}";
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

        tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["sum_soluong"] = tbl.Compute("sum(soluong)", string.Empty);
        tbl.Rows[lastRow]["sum_thanhtien"] = tbl.Compute("sum(thanhtien)", string.Empty);

        var soluong_cell = ReportViewer1.Report.Report.FindControl("soluong", true);
        var sum_soluong_cell = ReportViewer1.Report.Report.FindControl("sum_soluong", true);
        soluong_cell.DataBindings[0].FormatString =
        sum_soluong_cell.DataBindings[0].FormatString = sothapphan;
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
            
            select
                A.*
                , (A.dongia * A.soluong) as thanhtien
                , N'Từ {0} đến {1}' as thang_nam
            from (
	            select
		            sp.ma_sanpham as mahang
		            , sp.mota_tiengviet as tensp
		            , dvtsp.ten_dvt as dvt
                    , sum(dh.sl_dathang - isnull(dh.sl_giamhanngach, 0)) as soluong
		            , isnull(dh.gianhap, 0) as dongia
	            from 
		            c_dongdsdh dh
                    left join c_danhsachdathang dsdh on dh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
		            left join md_sanpham sp on sp.md_sanpham_id = dh.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
	            where 
		            dsdh.trangthai in ('HIEULUC','KETTHUC')
                    and dsdh.hangiaohang_po between @tungay and @denngay
                    {3}
	            group by
		            sp.ma_sanpham
                    , sp.md_donvitinhsanpham_id
                    , sp.md_sanpham_id
		            , sp.mota_tiengviet
		            , dvtsp.ten_dvt
		            , dh.gianhap
            )A
            where A.soluong > 0
            order by
	            A.mahang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , donhang
        , masp
        );
		return sql;
    }
}

