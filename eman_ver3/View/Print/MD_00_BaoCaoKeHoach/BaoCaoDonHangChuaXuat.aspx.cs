using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoDonHangChuaXuat : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Báo Cáo Đơn Hàng Chưa Xuất.repx";
        string nameRpt = "Báo Cáo Đơn Hàng Chưa Xuất {thang_nam}";
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
        tbl.Columns.Add("sum_dh", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_daxuat", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_conlai", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;

        tbl.Rows[lastRow]["sum_dh"] = tbl.Compute("sum(dh)", string.Empty);
        tbl.Rows[lastRow]["sum_daxuat"] = tbl.Compute("sum(daxuat)", string.Empty);
        tbl.Rows[lastRow]["sum_conlai"] = tbl.Compute("sum(conlai)", string.Empty);

        var dh_cell = ReportViewer1.Report.Report.FindControl("dh", true);
        dh_cell.DataBindings[0].FormatString = sothapphan;
        var daxuat_cell = ReportViewer1.Report.Report.FindControl("daxuat", true);
        daxuat_cell.DataBindings[0].FormatString = sothapphan;
        var conlai_cell = ReportViewer1.Report.Report.FindControl("conlai", true);
        conlai_cell.DataBindings[0].FormatString = sothapphan;

        var sum_dh_cell = ReportViewer1.Report.Report.FindControl("sum_dh", true);
        sum_dh_cell.DataBindings[0].FormatString = sothapphan;
        var sum_daxuat_cell = ReportViewer1.Report.Report.FindControl("sum_daxuat", true);
        sum_daxuat_cell.DataBindings[0].FormatString = sothapphan;
        var sum_conlai_cell = ReportViewer1.Report.Report.FindControl("sum_conlai", true);
        sum_conlai_cell.DataBindings[0].FormatString = sothapphan;
    }

    public string CreateSql(HttpContext context)
    {
        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and dsdh.so_po like N'{0}'", donhang);
        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham like N'{0}'", masp);
        var tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        var den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59:59',103);

            select 
	            dsdh.so_po as donhang
	            , sp.ma_sanpham as mahang
	            , sp.mota_tiengviet as tensp
	            , dvtsp.ten_dvt as dvt
	            , (dh.sl_dathang - isnull(dh.sl_giamhanngach, 0)) as dh
	            , dh.sl_dagiao as daxuat
	            , dh.sl_conlai as conlai
	            , (
		            select top 1 xb.ngaychuyen
		            from md_xuatban xb
		            inner join md_xuatban_cdh cdh on cdh.md_xuatban_id = xb.md_xuatban_id
		            where cdh.md_sanpham_id = sp.md_sanpham_id
			            and cdh.sl_daxuat > 0
			            and cdh.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
			            and xb.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
		            order by xb.ngaychuyen desc
	            ) as ngayxuat
                , N'Từ {0} đến {1}' as thang_nam
            from
	            c_danhsachdathang dsdh
	            left join c_dongdsdh dh on dh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
	            left join md_sanpham sp on sp.md_sanpham_id = dh.md_sanpham_id
	            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
            where
	            dsdh.md_trangthai_id = 'DAXULY'
	            and dh.sl_conlai > 0
	            and dh.han_giaohang between @tungay and @denngay
                {2} {3}
            order by
                dh.han_giaohang, dsdh.so_po
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , donhang
        , masp
        );
		return sql;
    }
}

