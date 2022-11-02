using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoTienDoSanXuat : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Báo Cáo Tiến Độ Sản Xuất.repx";
        string nameRpt = "Báo Cáo Tiến Độ Sản Xuất";
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
        tbl.Columns.Add("sumSldhpx", Type.GetType("System.Double"));
        tbl.Columns.Add("sumSlltDuc", Type.GetType("System.Double"));
        tbl.Columns.Add("sumSlltHT", Type.GetType("System.Double"));
        tbl.Columns.Add("sumSlduc", Type.GetType("System.Double"));
        tbl.Columns.Add("sumSlbancat", Type.GetType("System.Double"));
        tbl.Columns.Add("sumSlmai", Type.GetType("System.Double"));
        tbl.Columns.Add("sumSlhoantat", Type.GetType("System.Double"));

        //Header
;
        //Footer
        int lastRow = tbl.Rows.Count - 1;

        tbl.Rows[lastRow]["sumSldhpx"] = tbl.Compute("sum(sldhpx)", string.Empty);
        tbl.Rows[lastRow]["sumSlltDuc"] = tbl.Compute("sum(slltDuc)", string.Empty);
        tbl.Rows[lastRow]["sumSlltHT"] = tbl.Compute("sum(slltHT)", string.Empty);
        tbl.Rows[lastRow]["sumSlduc"] = tbl.Compute("sum(slduc)", string.Empty);
        tbl.Rows[lastRow]["sumSlbancat"] = tbl.Compute("sum(slbancat)", string.Empty);
        tbl.Rows[lastRow]["sumSlmai"] = tbl.Compute("sum(slmai)", string.Empty);
        tbl.Rows[lastRow]["sumSlhoantat"] = tbl.Compute("sum(slhoantat)", string.Empty);

        var sldhpx_cell = ReportViewer1.Report.Report.FindControl("sldhpx", true);
        var slduc_cell = ReportViewer1.Report.Report.FindControl("slduc", true);
        var slbancat_cell = ReportViewer1.Report.Report.FindControl("slbancat", true);
        var slmai_cell = ReportViewer1.Report.Report.FindControl("slmai", true);
        var slhoantat_cell = ReportViewer1.Report.Report.FindControl("slhoantat", true);
        var sumSldhpx_cell = ReportViewer1.Report.Report.FindControl("sumSldhpx", true);
        var sumSlduc_cell = ReportViewer1.Report.Report.FindControl("sumSlduc", true);
        var sumSlbancat_cell = ReportViewer1.Report.Report.FindControl("sumSlbancat", true);
        var sumSlmai_cell = ReportViewer1.Report.Report.FindControl("sumSlmai", true);
        var sumSlhoantat_cell = ReportViewer1.Report.Report.FindControl("sumSlhoantat", true);
        var sumSlltDuc_cell = ReportViewer1.Report.Report.FindControl("sumSlltDuc", true);
        var sumSlltHT_cell = ReportViewer1.Report.Report.FindControl("sumSlltHT", true);
        var slltDuc_cell = ReportViewer1.Report.Report.FindControl("slltDuc", true);
        var slltHT_cell = ReportViewer1.Report.Report.FindControl("slltHT", true);

        slltDuc_cell.DataBindings[0].FormatString =
        slltHT_cell.DataBindings[0].FormatString =
        sumSlltDuc_cell.DataBindings[0].FormatString =
        sumSlltHT_cell.DataBindings[0].FormatString =
        sldhpx_cell.DataBindings[0].FormatString =
        slduc_cell.DataBindings[0].FormatString =
        slbancat_cell.DataBindings[0].FormatString =
        slmai_cell.DataBindings[0].FormatString =
        slhoantat_cell.DataBindings[0].FormatString =
        sumSldhpx_cell.DataBindings[0].FormatString =
        sumSlduc_cell.DataBindings[0].FormatString =
        sumSlbancat_cell.DataBindings[0].FormatString =
        sumSlmai_cell.DataBindings[0].FormatString =
        sumSlhoantat_cell.DataBindings[0].FormatString = sothapphan;
    }

    public string CreateSql(HttpContext context)
    {
        var infoPrint = PrintAnco2.GetInfoPrint();
        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];

        var tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        var den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and dhpx.donhang_thamchieu like N'{0}'", donhang);
        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham like N'{0}'", masp);

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 00:00',103);

            declare @tbl table (
	            dhpx nvarchar(32),
	            mahang nvarchar(32),
	            ngayxonghang datetime,
	            stt int,
	            sldaHT decimal(18, 0),
	            sldaG decimal(18, 0),
	            mspDT nvarchar(10),
	            mspBT nvarchar(2),
	            mspMS nvarchar(2),
	            px nvarchar(32),
	            sldhpx decimal(18, 0),
	            sllayton decimal(18, 0)
            )

            insert into @tbl
            select
	            dhpx.donhang_thamchieu as dhpx,
	            sp.ma_sanpham as mahang,
	            lsx.ngayketthuc as ngayxonghang,
	            tsx.stt,
	            cdh.sl_dahoanthanh,
	            cdh.sl_dagiao,
	            substring(sp.ma_sanpham, 0, 9), 
	            substring(sp.ma_sanpham, 10, 2),
	            substring(sp.ma_sanpham, 13, 2),
	            px.ma_phanxuong as px,
	            isnull((
		            select 
			            sum(dhpxDH.tong_sl_dat - isnull(dhpxDH.sl_giamhanngach, 0))
		            from 
			            md_dondathangphanxuong_cdh dhpxDH
		            where 
			            dhpxDH.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
			            and cdh.macuoi like N'%' + dhpxDH.macuoi + '%'
	            ), 0) as sldhpx,
	            cdh.sl_nhapkho as sllayton
            from 
	            md_lenhsanxuat_tosx_cdh cdh
	            left join md_lenhsanxuat_tosx tsx on cdh.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
	            left join md_lenhsanxuat lsx on lsx.md_lenhsanxuat_id = tsx.md_lenhsanxuat_id
	            left join md_dondathangphanxuong dhpx on dhpx.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id
	            left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
	            left join md_phanxuong px on tsx.md_phanxuong_id = px.md_phanxuong_id
            where 
	            1=1
	            and lsx.ngayketthuc between @tungay and @denngay
	            and px.ma_phanxuong in ('PX1', 'PX1_62', 'PX2')
                {2}                
                {3}
            
            select 
                A.*,
                (case when A.sldhpx > 0 then (A.slhoantat + A.slltHT) / A.sldhpx * 100 else 0 end) as pthoantat,
                N'Từ {0} đến {1}' as thang_nam
            from (
                select 
	                A.*,
                    (case when A.slhoantatCP >= A.slltHT then A.slhoantatCP - A.slltHT else 0 end) as slhoantat,
	                (case when A.sldhpx > 0 then (A.slduc + A.slltDuc + A.slltHT) / A.sldhpx * 100 else 0 end) as ptduc,
	                (case when A.sldhpx > 0 then (A.slbancat + A.slltHT) / A.sldhpx * 100 else 0 end) as ptbancat,
	                (case when A.sldhpx > 0 then (A.slmai + A.slltHT) / A.sldhpx * 100 else 0 end) as ptmai
	            from ( 
		            select 
			            A.dhpx,
			            A.mahang,
			            A.ngayxonghang,
			            A.px,
			            A.sldhpx,
			            A.mspDT, 
			            A.mspMS, 
			            A.mspBT,
			            isnull((
				            select sum(isnull(B.sllayton, 0))
				            from @tbl B
				            where 
					            B.mahang = A.mahang
					            and B.dhpx = A.dhpx
					            and B.px = A.px
                                and B.stt = 0
			            ), 0) as slltDuc,
                        isnull((
				            select sum(isnull(B.sllayton, 0))
				            from @tbl B
				            where 
					            B.mahang = A.mahang
					            and B.dhpx = A.dhpx
					            and B.px = A.px
                                and B.stt = 9999
			            ), 0) as slltHT,
			            isnull((
				            select sum(isnull(B.sldaHT, 0))
				            from @tbl B
				            where 
					            B.mahang = A.mahang
					            and B.dhpx = A.dhpx
					            and B.px = A.px
					            and B.stt = 0
			            ), 0) as slduc,
			            isnull((
				            select sum(isnull(B.sldaG, 0))
				            from @tbl B
				            where 
					            B.mahang = A.mahang
					            and B.dhpx = A.dhpx
					            and B.px = A.px
					            and B.stt = 1
			            ), 0) as slbancat,
			            isnull((
				            select sum(isnull(B.sldaG, 0))
				            from @tbl B
				            where 
					            B.mahang = A.mahang
					            and B.dhpx = A.dhpx
					            and B.px = A.px
					            and B.stt = 2
			            ), 0) as slmai,
			            isnull((
				            select sum(isnull(B.sldaG, 0))
				            from @tbl B
				            where 
					            B.mahang = A.mahang
					            and B.dhpx = A.dhpx
					            and B.px = A.px
					            and B.stt = 9999
			            ), 0) as slhoantatCP
		            from @tbl A
		            group by A.dhpx, A.mahang, A.ngayxonghang, A.px, A.sldhpx, A.mspDT, A.mspMS, A.mspBT
                )A
            )A
            order by A.ngayxonghang, A.dhpx, A.px, A.mspDT, A.mspMS, A.mspBT
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , donhang
        , masp
        );
        return sql;
    }
}

