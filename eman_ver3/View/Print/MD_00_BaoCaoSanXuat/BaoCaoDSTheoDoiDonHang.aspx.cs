using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaovattu_BaoCaoDSTheoDoiDonHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Danh Sách Theo Dõi Đơn Hàng.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
        //Response.Write(sql);
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

            tbl.Columns.Add("sum_sldh", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["sum_sldh"] = tbl.Compute("sum(sldh)", string.Empty);
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;

            var sldh_cell = report.Report.FindControl("sldh", true);
            sldh_cell.DataBindings[0].FormatString = sothapphan;
            var sum_sldh_cell = report.Report.FindControl("sum_sldh", true);
            sum_sldh_cell.DataBindings[0].FormatString = sothapphan;

            report.DataSource = ds;
            report.DataAdapter = da;
            ReportViewer1.Report = report;
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
        string px = context.Request.QueryString["px"];
        string msp = context.Request.QueryString["msp"];
        string trangthai = context.Request.QueryString["trangthai"];

        DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);

        string sql = string.Format(@"	       
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59',103);
            declare @px nvarchar(MAX) = '{2}'
            declare @msp nvarchar(MAX) = '%{3}%'
            declare @tbl table (
	            donhang nvarchar(MAX),
	            ma_sanpham nvarchar(MAX),
	            sldh decimal(18,0),
	            giaoduc decimal(18,0),
	            dhduc decimal(18,0),
	            giaobancat decimal(18,0),
	            dhbancat decimal(18,0),
	            giaomai decimal(18,0),
	            dhmai decimal(18,0),
	            giaohoantat decimal(18,0),
	            dhhoantat decimal(18,0),
	            ngaybatdausx datetime
            )

            insert into @tbl
            select 
	            Q.donhang
	            , Q.ma_sanpham
	            , Q.sldh
	            , isnull(Q.giaoduc, 0) as giaoduc 
	            , isnull(Q.dhduc, 0) as dhduc
	            , isnull(Q.giaobancat, 0) as giaobancat
	            , isnull(Q.dhbancat, 0) as dhbancat
	            , isnull(Q.giaomai, 0) as giaomai
	            , isnull(Q.dhmai, 0) as dhmai
	            , isnull(Q.giaohoantat, 0) as giaohoantat
	            , isnull(Q.dhhoantat, 0) as dhhoantat
	            , Q.ngaybatdausx
            from (
	            select
		            dhpx.donhang_thamchieu as donhang
		            , sp.ma_sanpham
		            --duc
		            , (
			            select isnull(sl_dagiao, 0)
			            where tsx.stt = 0
		            ) as giaoduc
		            , (
			            select isnull(sl_chiato, 0)
			            where tsx.stt = 0
		            ) as dhduc
		            --ban cat
		            , (
			            select isnull(sl_dagiao, 0)
			            where tsx.stt = 1
		            ) as giaobancat
		            , (
			            select isnull(sl_chiato, 0)
			            where tsx.stt = 1
		            ) as dhbancat
		            --mai
		            , (
			            select isnull(sl_dagiao, 0)
			            where tsx.stt = 2
		            ) as giaomai
		            , (
			            select isnull(sl_chiato, 0)
			            where tsx.stt = 2
		            ) as dhmai
		            --hoan tat
		            , (
			            select isnull(sl_dagiao - isnull(sl_layton, 0), 0)
			            where tsx.stt = 9999
		            ) as giaohoantat
		            , (
			            select isnull(sl_chiato, 0)
			            where tsx.stt = 9999
		            ) as dhhoantat
		            , tsx.ngaybatdausx
		            , cdh.sl_dat as sldh
	            FROM md_lenhsanxuat (nolock) lsx
		            left join md_lenhsanxuat_tosx (nolock) tsx on tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
		            left join md_lenhsanxuat_tosx_cdh (nolock) cdh on cdh.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
		            left join md_sanpham (nolock) sp on sp.md_sanpham_id = cdh.md_sanpham_id
		            left join md_dondathangphanxuong (nolock) dhpx on dhpx.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id
	            WHERE 1=1
		            and cdh.md_sanpham_id = sp.md_sanpham_id
		            and lsx.ngayketthuc between @tungay and @denngay
		            and lsx.md_phanxuong_id = @px
                    and sp.ma_sanpham like @msp
            )Q
            
            select D.* 
            from (
                select C.*
                , (case when C.hoantat >= 1 then 'OK' else '-' end) as trangthai
                , (
	                select top 1 ngaybatdausx 
	                from @tbl 
	                where donhang = C.donhang and ma_sanpham = C.mahang and sldh = C.sldh
	                order by ngaybatdausx asc
                ) as ngaytrienkhai
                from (    
	                select B.*
	                , (case when B.dhhoantat > 0 then B.giaohoantat / B.dhhoantat else 1 end) as hoantat
	                from ( 
		                select 
			                A.donhang
			                , A.ma_sanpham as mahang
			                , A.sldh
			                , sum(isnull(A.giaoduc, 0)) as giaoduc 
			                , sum(isnull(A.dhduc, 0)) as dhduc
			                , sum(isnull(A.giaobancat, 0)) as giaobancat
			                , sum(isnull(A.dhbancat, 0)) as dhbancat
			                , sum(isnull(A.giaomai, 0)) as giaomai
			                , sum(isnull(A.dhmai, 0)) as dhmai
			                , sum(isnull(A.giaohoantat, 0)) as giaohoantat
			                , sum(isnull(A.dhhoantat, 0)) as dhhoantat
		                from @tbl A
		                group by A.donhang
			                , A.ma_sanpham
			                , A.sldh
	                )B
                )C
            )D
            where {4}
            order by D.donhang, D.mahang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , px
        , string.IsNullOrEmpty(msp) ? "-" : msp
        , string.IsNullOrEmpty(trangthai) ? "1=1" : string.Format("D.trangthai = N'{0}'", trangthai)
        );
        return sql;
    }
}

