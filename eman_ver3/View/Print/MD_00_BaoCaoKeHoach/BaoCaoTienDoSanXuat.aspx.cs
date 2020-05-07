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
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Báo Cáo Tiến Độ Sản Xuất.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
        // Response.Write(sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
    {
        var da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        var ds = new DataSet();
        da.Fill(ds);
        var tbl = ds.Tables[0];
        if (tbl.Rows.Count > 0)
        {
            var infoPrint = PrintAnco2.GetInfoPrint();

            tbl.Columns.Add("sumSldhpx", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSlltDuc", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSlltHT", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSlduc", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSlbancat", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSlmai", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSlhoantat", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            report.DisplayName = "Báo cáo tiến độ sản xuất";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;

            tbl.Rows[lastRow]["sumSldhpx"] = tbl.Compute("sum(sldhpx)", string.Empty);
            tbl.Rows[lastRow]["sumSlltDuc"] = tbl.Compute("sum(slltDuc)", string.Empty);
            tbl.Rows[lastRow]["sumSlltHT"] = tbl.Compute("sum(slltHT)", string.Empty);
            tbl.Rows[lastRow]["sumSlduc"] = tbl.Compute("sum(slduc)", string.Empty);
            tbl.Rows[lastRow]["sumSlbancat"] = tbl.Compute("sum(slbancat)", string.Empty);
            tbl.Rows[lastRow]["sumSlmai"] = tbl.Compute("sum(slmai)", string.Empty);
            tbl.Rows[lastRow]["sumSlhoantat"] = tbl.Compute("sum(slhoantat)", string.Empty);

            var sldhpx_cell = report.Report.FindControl("sldhpx", true);
            var slduc_cell = report.Report.FindControl("slduc", true);
            var slbancat_cell = report.Report.FindControl("slbancat", true);
            var slmai_cell = report.Report.FindControl("slmai", true);
            var slhoantat_cell = report.Report.FindControl("slhoantat", true);
            var sumSldhpx_cell = report.Report.FindControl("sumSldhpx", true);
            var sumSlduc_cell = report.Report.FindControl("sumSlduc", true);
            var sumSlbancat_cell = report.Report.FindControl("sumSlbancat", true);
            var sumSlmai_cell = report.Report.FindControl("sumSlmai", true);
            var sumSlhoantat_cell = report.Report.FindControl("sumSlhoantat", true);
            var sumSlltDuc_cell = report.Report.FindControl("sumSlltDuc", true);
            var sumSlltHT_cell = report.Report.FindControl("sumSlltHT", true);
            var slltDuc_cell = report.Report.FindControl("slltDuc", true);
            var slltHT_cell = report.Report.FindControl("slltHT", true);

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

            report.DataSource = ds;
            report.DataAdapter = da;
            if (string.IsNullOrEmpty(inPDF))
                ReportViewer1.Report = report;
            else
                Helper.viewFile(report);
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
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
	            isnull((
		            select 
			            sum(isnull(lht.sl_layton, 0))
		            from 
			            md_lenhsanxuat_tosx_dklht lht
		            where 
			            lht.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
			            and lht.md_sanpham_id = cdh.md_sanpham_id
			            and isnull(tsx.phieulayht, '') != ''
	            ), 0) as sllayton
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
	            and px.ma_phanxuong in ('PX1', 'PX2')
                {2}                
                {3}

            select 
	            A.*,
	            (case when A.sldhpx > 0 then (A.slduc + A.slltDuc + A.slltHT) / A.sldhpx * 100 else 0 end) as ptduc,
	            (case when A.sldhpx > 0 then (A.slbancat + A.slltHT) / A.sldhpx * 100 else 0 end) as ptbancat,
	            (case when A.sldhpx > 0 then (A.slmai + A.slltHT) / A.sldhpx * 100 else 0 end) as ptmai,
	            (case when A.sldhpx > 0 then A.slhoantat / A.sldhpx * 100 else 0 end) as pthoantat,
                N'Từ {0} đến {1}' as thang_nam
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
			        (
				        select sum(isnull(B.sllayton, 0))
				        from @tbl B
				        where 
					        B.mahang = A.mahang
					        and B.dhpx = A.dhpx
					        and B.px = A.px
                            and B.stt = 0
			        ) as slltDuc,
                    (
				        select sum(isnull(B.sllayton, 0))
				        from @tbl B
				        where 
					        B.mahang = A.mahang
					        and B.dhpx = A.dhpx
					        and B.px = A.px
                            and B.stt = 9999
			        ) as slltHT,
			        (
				        select sum(isnull(B.sldaHT, 0))
				        from @tbl B
				        where 
					        B.mahang = A.mahang
					        and B.dhpx = A.dhpx
					        and B.px = A.px
					        and B.stt = 0
			        ) as slduc,
			        (
				        select sum(isnull(B.sldaG, 0))
				        from @tbl B
				        where 
					        B.mahang = A.mahang
					        and B.dhpx = A.dhpx
					        and B.px = A.px
					        and B.stt = 1
			        ) as slbancat,
			        (
				        select sum(isnull(B.sldaG, 0))
				        from @tbl B
				        where 
					        B.mahang = A.mahang
					        and B.dhpx = A.dhpx
					        and B.px = A.px
					        and B.stt = (case when B.px = 'PX1' then 2 else 1 end)
			        ) as slmai,
			        (
				        select sum(isnull(B.sldaG, 0))
				        from @tbl B
				        where 
					        B.mahang = A.mahang
					        and B.dhpx = A.dhpx
					        and B.px = A.px
					        and B.stt = 9999
			        ) as slhoantat
		        from @tbl A
		        group by A.dhpx, A.mahang, A.ngayxonghang, A.px, A.sldhpx, A.mspDT, A.mspMS, A.mspBT
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

