using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoTHKhoiLuongTheoDDH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Báo Cáo Tình Hinh Khối Lượng Theo ĐĐH.repx";
        string nameRpt = "Báo Cáo Tình Hinh Khối Lượng Theo ĐĐH {thang_nam}";
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
        tbl.Columns.Add("sum_dh51", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dl51", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_cl51", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dh52", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dl52", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_cl52", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dh53", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dl53", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_cl53", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dh81ch", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dl81ch", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_cl81ch", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dh81bg", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dl81bg", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_cl81bg", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dh99", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dl99", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_cl99", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dhTongcong", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_dlTongcong", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_clTongcong", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["sum_dh51"] = tbl.Compute("sum(dh51)", string.Empty);
        tbl.Rows[lastRow]["sum_dl51"] = tbl.Compute("sum(dl51)", string.Empty);
        tbl.Rows[lastRow]["sum_cl51"] = tbl.Compute("sum(cl51)", string.Empty);
        tbl.Rows[lastRow]["sum_dh52"] = tbl.Compute("sum(dh52)", string.Empty);
        tbl.Rows[lastRow]["sum_dl52"] = tbl.Compute("sum(dl52)", string.Empty);
        tbl.Rows[lastRow]["sum_cl52"] = tbl.Compute("sum(cl52)", string.Empty);
        tbl.Rows[lastRow]["sum_dh53"] = tbl.Compute("sum(dh53)", string.Empty);
        tbl.Rows[lastRow]["sum_dl53"] = tbl.Compute("sum(dl53)", string.Empty);
        tbl.Rows[lastRow]["sum_cl53"] = tbl.Compute("sum(cl53)", string.Empty);
        tbl.Rows[lastRow]["sum_dh81ch"] = tbl.Compute("sum(dh81ch)", string.Empty);
        tbl.Rows[lastRow]["sum_dl81ch"] = tbl.Compute("sum(dl81ch)", string.Empty);
        tbl.Rows[lastRow]["sum_cl81ch"] = tbl.Compute("sum(cl81ch)", string.Empty);
        tbl.Rows[lastRow]["sum_dh81bg"] = tbl.Compute("sum(dh81bg)", string.Empty);
        tbl.Rows[lastRow]["sum_dl81bg"] = tbl.Compute("sum(dl81bg)", string.Empty);
        tbl.Rows[lastRow]["sum_cl81bg"] = tbl.Compute("sum(cl81bg)", string.Empty);
        tbl.Rows[lastRow]["sum_dh99"] = tbl.Compute("sum(dh99)", string.Empty);
        tbl.Rows[lastRow]["sum_dl99"] = tbl.Compute("sum(dl99)", string.Empty);
        tbl.Rows[lastRow]["sum_cl99"] = tbl.Compute("sum(cl99)", string.Empty);
        tbl.Rows[lastRow]["sum_dhTongcong"] = tbl.Compute("sum(dhTongcong)", string.Empty);
        tbl.Rows[lastRow]["sum_dlTongcong"] = tbl.Compute("sum(dlTongcong)", string.Empty);
        tbl.Rows[lastRow]["sum_clTongcong"] = tbl.Compute("sum(clTongcong)", string.Empty);
        //
        var dh51_cell = ReportViewer1.Report.Report.FindControl("dh51", true);
        var dl51_cell = ReportViewer1.Report.Report.FindControl("dl51", true);
        var cl51_cell = ReportViewer1.Report.Report.FindControl("cl51", true);
        var dh52_cell = ReportViewer1.Report.Report.FindControl("dh52", true);
        var dl52_cell = ReportViewer1.Report.Report.FindControl("dl52", true);
        var cl52_cell = ReportViewer1.Report.Report.FindControl("cl52", true);
        var dh53_cell = ReportViewer1.Report.Report.FindControl("dh53", true);
        var dl53_cell = ReportViewer1.Report.Report.FindControl("dl53", true);
        var cl53_cell = ReportViewer1.Report.Report.FindControl("cl53", true);
        var dh81ch_cell = ReportViewer1.Report.Report.FindControl("dh81ch", true);
        var dl81ch_cell = ReportViewer1.Report.Report.FindControl("dl81ch", true);
        var cl81ch_cell = ReportViewer1.Report.Report.FindControl("cl81ch", true);
        var dh81bg_cell = ReportViewer1.Report.Report.FindControl("dh81bg", true);
        var dl81bg_cell = ReportViewer1.Report.Report.FindControl("dl81bg", true);
        var cl81bg_cell = ReportViewer1.Report.Report.FindControl("cl81bg", true);
        var dh99_cell = ReportViewer1.Report.Report.FindControl("dh99", true);
        var dl99_cell = ReportViewer1.Report.Report.FindControl("dl99", true);
        var cl99_cell = ReportViewer1.Report.Report.FindControl("cl99", true);
        var dhTongcong_cell = ReportViewer1.Report.Report.FindControl("dhTongcong", true);
        var dlTongcong_cell = ReportViewer1.Report.Report.FindControl("dlTongcong", true);
        var clTongcong_cell = ReportViewer1.Report.Report.FindControl("clTongcong", true);
        var sum_dh51_cell = ReportViewer1.Report.Report.FindControl("sum_dh51", true);
        var sum_dl51_cell = ReportViewer1.Report.Report.FindControl("sum_dl51", true);
        var sum_cl51_cell = ReportViewer1.Report.Report.FindControl("sum_cl51", true);
        var sum_dh52_cell = ReportViewer1.Report.Report.FindControl("sum_dh52", true);
        var sum_dl52_cell = ReportViewer1.Report.Report.FindControl("sum_dl52", true);
        var sum_cl52_cell = ReportViewer1.Report.Report.FindControl("sum_cl52", true);
        var sum_dh53_cell = ReportViewer1.Report.Report.FindControl("sum_dh53", true);
        var sum_dl53_cell = ReportViewer1.Report.Report.FindControl("sum_dl53", true);
        var sum_cl53_cell = ReportViewer1.Report.Report.FindControl("sum_cl53", true);
        var sum_dh81ch_cell = ReportViewer1.Report.Report.FindControl("sum_dh81ch", true);
        var sum_dl81ch_cell = ReportViewer1.Report.Report.FindControl("sum_dl81ch", true);
        var sum_cl81ch_cell = ReportViewer1.Report.Report.FindControl("sum_cl81ch", true);
        var sum_dh81bg_cell = ReportViewer1.Report.Report.FindControl("sum_dh81bg", true);
        var sum_dl81bg_cell = ReportViewer1.Report.Report.FindControl("sum_dl81bg", true);
        var sum_cl81bg_cell = ReportViewer1.Report.Report.FindControl("sum_cl81bg", true);
        var sum_dh99_cell = ReportViewer1.Report.Report.FindControl("sum_dh99", true);
        var sum_dl99_cell = ReportViewer1.Report.Report.FindControl("sum_dl99", true);
        var sum_cl99_cell = ReportViewer1.Report.Report.FindControl("sum_cl99", true);
        var sum_dhTongcong_cell = ReportViewer1.Report.Report.FindControl("sum_dhTongcong", true);
        var sum_dlTongcong_cell = ReportViewer1.Report.Report.FindControl("sum_dlTongcong", true);
        var sum_clTongcong_cell = ReportViewer1.Report.Report.FindControl("sum_clTongcong", true);
        dh51_cell.DataBindings[0].FormatString =
        dl51_cell.DataBindings[0].FormatString =
        cl51_cell.DataBindings[0].FormatString =
        dh52_cell.DataBindings[0].FormatString =
        dl52_cell.DataBindings[0].FormatString =
        cl52_cell.DataBindings[0].FormatString =
        dh53_cell.DataBindings[0].FormatString =
        dl53_cell.DataBindings[0].FormatString =
        cl53_cell.DataBindings[0].FormatString =
        dh81ch_cell.DataBindings[0].FormatString =
        dl81ch_cell.DataBindings[0].FormatString =
        cl81ch_cell.DataBindings[0].FormatString =
        dh81bg_cell.DataBindings[0].FormatString =
        dl81bg_cell.DataBindings[0].FormatString =
        cl81bg_cell.DataBindings[0].FormatString =
        dh99_cell.DataBindings[0].FormatString =
        dl99_cell.DataBindings[0].FormatString =
        cl99_cell.DataBindings[0].FormatString =
        dhTongcong_cell.DataBindings[0].FormatString =
        dlTongcong_cell.DataBindings[0].FormatString =
        clTongcong_cell.DataBindings[0].FormatString =
        sum_dh51_cell.DataBindings[0].FormatString =
        sum_dl51_cell.DataBindings[0].FormatString =
        sum_cl51_cell.DataBindings[0].FormatString =
        sum_dh52_cell.DataBindings[0].FormatString =
        sum_dl52_cell.DataBindings[0].FormatString =
        sum_cl52_cell.DataBindings[0].FormatString =
        sum_dh53_cell.DataBindings[0].FormatString =
        sum_dl53_cell.DataBindings[0].FormatString =
        sum_cl53_cell.DataBindings[0].FormatString =
        sum_dh81ch_cell.DataBindings[0].FormatString =
        sum_dl81ch_cell.DataBindings[0].FormatString =
        sum_cl81ch_cell.DataBindings[0].FormatString =
        sum_dh81bg_cell.DataBindings[0].FormatString =
        sum_dl81bg_cell.DataBindings[0].FormatString =
        sum_cl81bg_cell.DataBindings[0].FormatString =
        sum_dh99_cell.DataBindings[0].FormatString =
        sum_dl99_cell.DataBindings[0].FormatString =
        sum_cl99_cell.DataBindings[0].FormatString =
        sum_dhTongcong_cell.DataBindings[0].FormatString =
        sum_dlTongcong_cell.DataBindings[0].FormatString =
        sum_clTongcong_cell.DataBindings[0].FormatString = sothapphan;
    }

    public string CreateSql(HttpContext context)
    {
        var infoPrint = PrintAnco2.GetInfoPrint();
        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and dsdh.so_po like N'{0}'", donhang);
        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham like N'{0}'", masp);
        DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);

        string sql = string.Format(@"	       
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59',103);

            declare @tbl table (
	            donhang nvarchar(MAX)
	            , ngayxonghang datetime
	            , ma_sanpham nvarchar(MAX)
                , sp_tv nvarchar(MAX)
	            , v2 decimal(18,3)
	            , dh decimal(18,3)
	            , dl decimal(18,3)
	            , loaisp nvarchar(MAX)
                , cl decimal(18,3)
            )

            insert into @tbl
            select 
                A.*
                , A.dh - isnull(A.dl, 0) as cl
            from (
                select 
	                dsdh.so_po as donhang
	                , dsdh.hangiaohang_po as ngayxonghang
	                , sp.ma_sanpham
                    , sp.mota_tiengviet
	                , (case when dh.anco_check = 1 then dh.v2/dh.sl_dathang else dh.v2 end) as v2
	                , (isnull(dh.sl_dathang, 0) - isnull(dh.sl_giamhanngach, 0)) as dh
	                , (
		                select sum(isnull(soluong_dachuyen, 0)) 
		                from md_vanchuyennoibo_cdvc cdvc
		                inner join md_vanchuyennoibo vcnb on vcnb.md_vanchuyennoibo_id = cdvc.md_vanchuyennoibo_id
		                where 
			                cdvc.md_sanpham_id = dh.md_sanpham_id
			                and cdvc.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
			                and cdvc.tenhang = dsdh.so_po
			                and vcnb.loaichuyen = 'VANCNBCTKGH'
			                and cdvc.soluong_dachuyen > 0
	                ) as dl
	                , substring(sp.ma_sanpham, 0, 3) as loaisp
                from
	                c_danhsachdathang dsdh
	                left join c_dongdsdh dh on dh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
	                left join md_sanpham sp on sp.md_sanpham_id = dh.md_sanpham_id
                where
	                dsdh.trangthai in ('SOANTHAO','HIEULUC')
	                and dsdh.hangiaohang_po between @tungay and @denngay
                    {2}
            )A

            select
	            A.*,
	            (A.dh51 + A.dh52 + A.dh53 + A.dh81ch + A.dh81bg + A.dh99) as dhTongcong,
	            (A.dl51 + A.dl52 + A.dl53 + A.dl81ch + A.dl81bg + A.dl99) as dlTongcong,
	            (A.cl51 + A.cl52 + A.cl53 + A.cl81ch + A.cl81bg + A.cl99) as clTongcong,
                N'Từ {0} đến {1}' as thang_nam
            from ( 
	            select 
		            A.donhang,
                    A.ngayxonghang,
		            sum(isnull(A.dh51, 0)) as dh51,
		            sum(isnull(A.dl51, 0)) as dl51,
		            sum(isnull(A.cl51, 0)) as cl51,
		            sum(isnull(A.dh52, 0)) as dh52,
		            sum(isnull(A.dl52, 0)) as dl52,
		            sum(isnull(A.cl52, 0)) as cl52,
		            sum(isnull(A.dh53, 0)) as dh53,
		            sum(isnull(A.dl53, 0)) as dl53,
		            sum(isnull(A.cl53, 0)) as cl53,
		            sum(isnull(A.dh81ch, 0)) as dh81ch,
		            sum(isnull(A.dl81ch, 0)) as dl81ch,
		            sum(isnull(A.cl81ch, 0)) as cl81ch,
		            sum(isnull(A.dh81bg, 0)) as dh81bg,
		            sum(isnull(A.dl81bg, 0)) as dl81bg,
		            sum(isnull(A.cl81bg, 0)) as cl81bg,
		            sum(isnull(A.dh99, 0)) as dh99,
		            sum(isnull(A.dl99, 0)) as dl99,
		            sum(isnull(A.cl99, 0)) as cl99
	            from (
		            select 
			            a.donhang,
                        a.ngayxonghang,
			            (
				            select sum(a.v2 * a.dh)
				            where a.loaisp = '51'
			            ) as dh51,
			            (
				            select sum(a.v2 * a.dl)
				            where a.loaisp = '51'
			            )  as dl51,
			            (
				            select sum(a.v2 * a.cl)
				            where a.loaisp = '51'
			            )  as cl51,
			            (
				            select sum(a.v2 * a.dh)
				            where a.loaisp = '52'
			            ) as dh52,
			            (
				            select sum(a.v2 * a.dl)
				            where a.loaisp = '52'
			            )  as dl52,
			            (
				            select sum(a.v2 * a.cl)
				            where a.loaisp = '52'
			            )  as cl52,
			            (
				            select sum(a.v2 * a.dh)
				            where a.loaisp = '53'
			            ) as dh53,
			            (
				            select sum(a.v2 * a.dl)
				            where a.loaisp = '53'
			            )  as dl53,
			            (
				            select sum(a.v2 * a.cl)
				            where a.loaisp = '53'
			            )  as cl53,
			            (
				            select sum(a.v2 * a.dh)
				            where a.loaisp = '81' and a.ma_sanpham not like N'%F%' and a.sp_tv like N'Chậu%'
			            ) as dh81ch,
			            (
				            select sum(a.v2 * a.dl)
				            where a.loaisp = '81' and a.ma_sanpham not like N'%F%' and a.sp_tv like N'Chậu%'
			            )  as dl81ch,
			            (
				            select sum(a.v2 * a.cl)
				            where a.loaisp = '81' and a.ma_sanpham not like N'%F%' and a.sp_tv like N'Chậu%'
			            )  as cl81ch,
			            (
				            select sum(a.v2 * a.dh)
				            where a.loaisp = '81' and (a.ma_sanpham like N'%F%' or a.sp_tv like N'Kệ%')
			            ) as dh81bg,
			            (
				            select sum(a.v2 * a.dl)
				            where a.loaisp = '81' and (a.ma_sanpham like N'%F%' or a.sp_tv like N'Kệ%')
			            )  as dl81bg,
			            (
				            select sum(a.v2 * a.cl)
				            where a.loaisp = '81' and (a.ma_sanpham like N'%F%' or a.sp_tv like N'Kệ%')
			            )  as cl81bg,
			            (
				            select sum(a.v2 * a.dh)
				            where a.loaisp = '99'
			            ) as dh99,
			            (
				            select sum(a.v2 * a.dl)
				            where a.loaisp = '99'
			            )  as dl99,
			            (
				            select sum(a.v2 * a.cl)
				            where a.loaisp = '99'
			            )  as cl99
		            from
			            @tbl a
		            group by
			            a.loaisp, a.donhang, a.ma_sanpham, a.ngayxonghang, a.sp_tv
	            ) A
	            group by
		            A.donhang, A.ngayxonghang
            )A
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , donhang
        , masp
        );
        return sql;
    }
}

