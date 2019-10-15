using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaovattu_BaoCaoTinhHinhSanXuatTuanDonHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Báo Cáo Tình Hình Sản Xuất Tuần Đơn Hàng.repx");
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

            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;

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
        DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
		DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
		
		string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59',103);
            select 
	            A.donhang as thegiaoviecsx
	            , Sum(isnull(A.nlduc, 0)) as nlduc
	            , Sum(isnull(A.banduc, 0)) as banduc
	            , Sum(isnull(A.bancat, 0)) as bancat
	            , Sum(isnull(A.mai, 0)) as mai
	            , Sum(isnull(A.hoantat, 0)) as hoantat
	            , (
		            select ngaygiao from md_lenhsanxuat_tosx where stt = 0 and md_lenhsanxuat_id = A.md_lenhsanxuat_id
	            ) as ngaygiaoduc
	            , (
		            select ngaygiao from md_lenhsanxuat_tosx where stt = 1 and md_lenhsanxuat_id = A.md_lenhsanxuat_id
	            ) as ngaygiaobancat
	            , (
		            select ngaygiao from md_lenhsanxuat_tosx where stt = 2 and md_lenhsanxuat_id = A.md_lenhsanxuat_id
	            ) as ngaygiaomai
	            , (
		            select ngaygiao from md_lenhsanxuat_tosx where stt = 9999 and md_lenhsanxuat_id = A.md_lenhsanxuat_id
	            ) as ngaygiaohoantat
                , A.ngaytheolsx
	            , A.thoigiansx
	            , A.ngaydkgiaotp
	            , A.ngayxindc
	            , A.lydo
	            , N'Tuần ' + cast(A.tuanthu as varchar(3)) as tuanthu
                , DATEADD(dd, -(DATEPART(dw, A.ngaytuan)-2), A.ngaytuan) as nbdt
	            , DATEADD(dd, 7-(DATEPART(dw, A.ngaytuan)), A.ngaytuan) as nktt
                , @tungay as tungay
                , @denngay as denngay
            from (
	            select
		            dhpx.donhang_thamchieu as donhang
		            , lsx.md_lenhsanxuat_id
		            --duc
		            , (
			            select 
				            sum(isnull(sl_dahoanthanh, 0)) / sum(isnull(sl_chiato, 0)) 
			            from 
				            md_lenhsanxuat_tosx_cdh
			            where 
				            md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
				            and tsx.stt = 0
		            ) as nlduc
		            , (
			            select 
				            sum(isnull(sl_dagiao, 0)) / sum(isnull(sl_chiato, 0)) 
			            from 
				            md_lenhsanxuat_tosx_cdh
			            where 
				            md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
				            and tsx.stt = 0
		            ) as banduc
		            --ban cat
		            , (
			            select 
				            sum(isnull(sl_dagiao, 0)) / sum(isnull(sl_chiato, 0)) 
			            from 
				            md_lenhsanxuat_tosx_cdh
			            where 
				            md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
				            and tsx.stt = 1
		            ) as bancat
		            --mai
		            , (
			            select 
				            sum(isnull(sl_dagiao, 0)) / sum(isnull(sl_chiato, 0)) 
			            from 
				            md_lenhsanxuat_tosx_cdh
			            where 
				            md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
				            and tsx.stt = 2
		            ) as mai
		            --hoan tat
		            , (
			            select 
				            sum(isnull(sl_dagiao, 0)) / sum(isnull(sl_chiato, 0)) 
			            from 
				            md_lenhsanxuat_tosx_cdh
			            where 
				            md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
				            and tsx.stt = 9999
		            ) as hoantat
                    , lsx.ngayketthuc as ngaytheolsx
		            , lsx.ngayketthuc - 7 as thoigiansx
		            , lsx.ngaydkgiaotp
		            , lsx.ngayhoanthanh as ngayxindc
		            , lsx.lydogiaosom_tre as lydo
		            , DATEPART(wk, isnull(lsx.ngayhoanthanh, lsx.ngaydkgiaotp)) as tuanthu
                    , isnull(lsx.ngayhoanthanh, lsx.ngaydkgiaotp) as ngaytuan
	            FROM md_lenhsanxuat lsx
		            left join md_dondathangphanxuong dhpx on dhpx.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id
		            left join md_lenhsanxuat_tosx tsx on tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
	            WHERE lsx.md_trangthai_id = N'DAXL'
		            AND isnull(lsx.ngayhoanthanh, lsx.ngaydkgiaotp) between @tungay and @denngay
		            and lsx.md_phanxuong_id = '{2}'
            )A
            group by 
	            A.donhang
	            , A.ngaydkgiaotp
	            , A.ngayxindc
                , A.ngaytheolsx
	            , A.thoigiansx
	            , A.lydo
	            , A.tuanthu
                , A.ngaytuan
	            , A.md_lenhsanxuat_id
            order by A.tuanthu, A.donhang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , px
        );
		return sql;
    }
}

