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
            tbl.Columns.Add("sum_sldalam", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_slconlai", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["sum_sldh"] = tbl.Compute("sum(sldh)", string.Empty);
            tbl.Rows[lastRow]["sum_sldalam"] = tbl.Compute("sum(sldalam)", string.Empty);
            tbl.Rows[lastRow]["sum_slconlai"] = tbl.Compute("sum(slconlai)", string.Empty);
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;
            //sldh
            var sldh_cell = report.Report.FindControl("sldh", true);
            sldh_cell.DataBindings[0].FormatString = sothapphan;
            var sum_sldh_cell = report.Report.FindControl("sum_sldh", true);
            sum_sldh_cell.DataBindings[0].FormatString = sothapphan;
            //sldalam
            var sldalam_cell = report.Report.FindControl("sldalam", true);
            sldalam_cell.DataBindings[0].FormatString = sothapphan;
            var sum_sldalam_cell = report.Report.FindControl("sum_sldalam", true);
            sum_sldalam_cell.DataBindings[0].FormatString = sothapphan;
            //slconlai
            var slconlai_cell = report.Report.FindControl("slconlai", true);
            slconlai_cell.DataBindings[0].FormatString = sothapphan;
            var sum_slconlai_cell = report.Report.FindControl("sum_slconlai", true);
            sum_slconlai_cell.DataBindings[0].FormatString = sothapphan;
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
        string tosx = context.Request.QueryString["tosx"];
        string msp = context.Request.QueryString["msp"];
        string trangthai = context.Request.QueryString["trangthai"];
        string donhang = context.Request.QueryString["donhang"];

        DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);

        string sql = string.Format(@"	       
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59',103);
            declare @px nvarchar(MAX) = '{2}'
            declare @tosx nvarchar(MAX) = '{5}'
            declare @msp nvarchar(MAX) = '%{3}%'
            declare @tenpx nvarchar(MAX) = (select ten_phanxuong from md_phanxuong where md_phanxuong_id = @px)
            declare @tento nvarchar(MAX) = (select ten_to from md_phanxuong_to where md_to_id = @tosx)
            select
                QQ.*,
				(QQ.sldh - QQ.sldalam) as slconlai,
				(case when QQ.sldh <= QQ.sldalam then 'OK' else '-' end) as trangthai,
                @tenpx as px,
                @tento as tsx
            from (
                select
	                Q.donhang,
	                Q.mahang,
	                (case when Q.stt = Q.sttHT then Q.sldh2 else Q.sldh end) as sldh,
	                Q.sldalam,
	                Q.ngaytrienkhai,
                    Q.ngaygiaohang 
                from
                (
	                select
						dhpx.donhang_thamchieu as donhang,
						sp.ma_sanpham as mahang,
						tsx.ngaybatdausx as ngaytrienkhai,
                        lsx.ngayketthuc as ngaygiaohang,
						cdh.sl_chiato as sldh,
						(
                            cdh.sl_chiato + 
                            (
                                select isnull(lht.sl_layton, 0) from md_lenhsanxuat_tosx_dklht lht
                                where lht.md_lenhsanxuat_tosx_id = cdh.md_lenhsanxuat_tosx_id
                                and lht.md_sanpham_id = cdh.md_sanpham_id
                                and isnull(tsx.phieulayht,'') != ''
                            )
                        ) as sldh2,
						(
							select top 1 stt
							from md_lenhsanxuat_tosx
							where md_lenhsanxuat_id = tsx.md_lenhsanxuat_id
							and hoatdong = 1
							order by stt desc
						) as sttHT,
						tsx.stt,
						(case when tsx.stt = 0 then isnull(cdh.sl_dahoanthanh, 0) else isnull(cdh.sl_dagiao, 0) end) as sldalam
	                FROM
	                md_lenhsanxuat (nolock) lsx 
	                left join
		                md_lenhsanxuat_tosx (nolock) tsx 
		                on tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id 
	                left join
		                md_lenhsanxuat_tosx_cdh (nolock) cdh 
		                on cdh.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id 
	                left join
		                md_sanpham (nolock) sp 
		                on sp.md_sanpham_id = cdh.md_sanpham_id 
	                left join
		                md_dondathangphanxuong (nolock) dhpx 
		                on dhpx.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id 
	                WHERE
	                1 = 1 
	                and cdh.md_sanpham_id = sp.md_sanpham_id 
	                and lsx.ngayketthuc between @tungay and @denngay 
	                and lsx.md_phanxuong_id = @px 
	                and tsx.md_phanxuong_to_id = @tosx 
	                and sp.ma_sanpham like @msp 
                ) Q
            )QQ
            where
                {4} {6}
            order by
	             QQ.ngaygiaohang, QQ.donhang, QQ.mahang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , px
        , string.IsNullOrEmpty(msp) ? "-" : msp
        , string.IsNullOrEmpty(trangthai) ? "1=1" : string.Format("QQ.trangthai = N'{0}'", trangthai)
        , tosx
        , string.IsNullOrEmpty(donhang) ? "" : string.Format("and QQ.donhang = N'{0}'", donhang)
        );
        return sql;
    }
}

