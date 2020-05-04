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
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Báo Cáo Chi Tiết Doanh Thu Theo MHH.repx");
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

            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            report.DisplayName = "Chi tiết doanh thu theo mã hàng hóa";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;
            tbl.Rows[lastRow]["sum_soluong"] = tbl.Compute("sum(soluong)", string.Empty);
            tbl.Rows[lastRow]["sum_thanhtien"] = tbl.Compute("sum(thanhtien)", string.Empty);

            var soluong_cell = report.Report.FindControl("soluong", true);
            var sum_soluong_cell = report.Report.FindControl("sum_soluong", true);
            soluong_cell.DataBindings[0].FormatString =
            sum_soluong_cell.DataBindings[0].FormatString = sothapphan;
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
	                A.mahang,
		            A.tensp,
		            A.dvt,
                    sum(A.soluong2) as soluong,
                    A.dongia
                from (
	                select
		                sp.ma_sanpham as mahang
		                , sp.mota_tiengviet as tensp
		                , dvtsp.ten_dvt as dvt
                        , isnull((
		                    select sum(isnull(soluong_dachuyen, 0)) 
		                    from md_vanchuyennoibo_cdvc cdvc
		                    inner join md_vanchuyennoibo vcnb on vcnb.md_vanchuyennoibo_id = cdvc.md_vanchuyennoibo_id
		                    where 
			                    cdvc.md_sanpham_id = sp.md_sanpham_id
			                    and cdvc.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
			                    and vcnb.loaichuyen = 'VANCNBCTKGH'
			                    and cdvc.soluong_dachuyen > 0
                                and cdvc.tenhang = dsdh.so_po
	                    ), 0) as soluong2
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
                        , dsdh.so_po
                )A
                group by
                    A.mahang,
                    A.tensp,
                    A.dvt,
                    A.dongia
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

