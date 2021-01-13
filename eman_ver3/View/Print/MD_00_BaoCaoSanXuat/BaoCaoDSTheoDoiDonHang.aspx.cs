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
    public string logo = "", sothapphan = "", inPDF = "";
    public InfoPrint infoPrint = PrintAnco2.GetInfoPrint();
    public HttpContext context = HttpContext.Current;
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[SX] Danh Sách Theo Dõi Đơn Hàng.repx";
        string nameRpt = "Báo cáo theo dõi đơn hàng";
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
        tbl.Columns.Add("sum_slchiato", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_sllayton", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_sldalam", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_slconlai", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["sum_slchiato"] = tbl.Compute("sum(slchiato)", string.Empty);
        tbl.Rows[lastRow]["sum_sllayton"] = tbl.Compute("sum(sllayton)", string.Empty);
        tbl.Rows[lastRow]["sum_sldalam"] = tbl.Compute("sum(sldalam)", string.Empty);
        tbl.Rows[lastRow]["sum_slconlai"] = tbl.Compute("sum(slconlai)", string.Empty);
        tbl.Rows[lastRow]["sum_thanhtien"] = tbl.Compute("sum(thanhtien)", string.Empty);
        //slchiato
        var slchiato_cell = ReportViewer1.Report.Report.FindControl("slchiato", true);
        slchiato_cell.DataBindings[0].FormatString = sothapphan;
        var sum_slchiato_cell = ReportViewer1.Report.Report.FindControl("sum_slchiato", true);
        sum_slchiato_cell.DataBindings[0].FormatString = sothapphan;
        //sllayton
        var sllayton_cell = ReportViewer1.Report.Report.FindControl("sllayton", true);
        sllayton_cell.DataBindings[0].FormatString = sothapphan;
        var sum_sllayton_cell = ReportViewer1.Report.Report.FindControl("sum_sllayton", true);
        sum_sllayton_cell.DataBindings[0].FormatString = sothapphan;
        //sldalam
        var sldalam_cell = ReportViewer1.Report.Report.FindControl("sldalam", true);
        sldalam_cell.DataBindings[0].FormatString = sothapphan;
        var sum_sldalam_cell = ReportViewer1.Report.Report.FindControl("sum_sldalam", true);
        sum_sldalam_cell.DataBindings[0].FormatString = sothapphan;
        //slconlai
        var slconlai_cell = ReportViewer1.Report.Report.FindControl("slconlai", true);
        slconlai_cell.DataBindings[0].FormatString = sothapphan;
        var sum_slconlai_cell = ReportViewer1.Report.Report.FindControl("sum_slconlai", true);
        sum_slconlai_cell.DataBindings[0].FormatString = sothapphan;
    }

    public string CreateSql(HttpContext context)
    {
        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];
        string px = context.Request.QueryString["px"];
        string tosx = context.Request.QueryString["tosx"];
        string msp = context.Request.QueryString["msp"];
        string trangthai = context.Request.QueryString["trangthai"];
        string donhang = context.Request.QueryString["donhang"];
        string loaihang = context.Request.QueryString["loaihang"];

        DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
        //nhan
        string sql = string.Format(@"	       
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59',103);
            declare @px nvarchar(MAX) = '{2}'
            declare @tosx nvarchar(MAX) = '{5}'
            declare @msp nvarchar(MAX) = '%{3}%'
            declare @tenpx nvarchar(MAX) = (select ten_phanxuong from md_phanxuong where md_phanxuong_id = @px)
            declare @tento nvarchar(MAX) = (select ten_to from md_phanxuong_to where md_to_id = @tosx)
            select 
                Q2.*,
                N'Từ {0} đến {1}' as thang_nam,
                (
                    case
                        when
                            Q2.slconlai <= 0
                        then
                            'OK'
                        else
                            '-'
                    end
                ) as trangthai,
                (
                    case
                        when
                            (Q2.slconlai * Q2.dongia) < 0
                        then
                            0
                        else
                            (Q2.slconlai * Q2.dongia)
                    end
                ) as thanhtien
            from (
                select Q1.*,
                (
                    case
                        when 
                            Q1.sttHT = Q1.stt
                        then 
                            Q1.slchiato + Q1.sllayton - Q1.sldalam
                        else 
                            Q1.slchiato - Q1.sldalam
                    end
                ) as slconlai
                from (
                    select
	                    Q.loaihang,
                        Q.donhang,
	                    Q.mahang,
	                    Q.slchiato,
                        Q.sllayton,
                        Q.stt,
                        Q.sttHT,
                        (
                            case 
                                when Q.sldalam > Q.slchiato 
                                then (case when Q.sttHT = Q.stt then Q.sldalam else Q.slchiato end) 
                                else Q.sldalam 
                            end
                        ) as sldalam,
	                    Q.ngaytrienkhai,
                        Q.ngaygiaohang,
                        Q.dongia,
                        @tenpx as px,
                        @tento as tsx
                    from
                    (
	                    select
					        dhpx.donhang_thamchieu as donhang,
					        sp.ma_sanpham as mahang,
					        tsx.ngaybatdausx as ngaytrienkhai,
                            lsx.ngayketthuc as ngaygiaohang,
					        cdh.sl_chiato as slchiato,
                            nnl.code_cl as loaihang,
                            cdh.sl_nhapkho as sllayton,
					        tsx.stt,
                            (
                                select top 1 tsx2.stt
                                from md_lenhsanxuat_tosx (nolock) tsx2
		                        where 
                                    tsx2.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
                                    and tsx2.hoatdong = 1
                                order by tsx2.stt desc
                            ) as sttHT,
					        (
                                case 
                                    when tsx.stt = 0 
                                    then isnull(cdh.sl_dahoanthanh, 0) 
                                    else isnull(cdh.sl_dagiao, 0) 
                                end
                            ) as sldalam,
                            cdh.gianhancong as dongia
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
		                        md_chungloai (nolock) nnl 
		                        on nnl.md_chungloai_id = sp.md_nhomnangluc_id 
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
                            {6} {7}
                    )Q
                )Q1
            )Q2
            where
                1=1 {4}
            order by
	            Q2.ngaygiaohang, Q2.donhang, Q2.mahang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , px
        , string.IsNullOrEmpty(msp) ? "-" : msp
        , string.IsNullOrEmpty(trangthai) ? "" : trangthai == "OK" ? "and Q2.slconlai <= 0" : "and Q2.slconlai > 0"
        , tosx
        , string.IsNullOrEmpty(donhang) ? "" : string.Format("and dhpx.donhang_thamchieu = N'{0}'", donhang)
        , string.IsNullOrEmpty(loaihang) ? "" : string.Format("and nnl.code_cl = N'{0}'", loaihang)
        );
        return sql;
    }
}

