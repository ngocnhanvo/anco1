using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaoketoan_BaoCaoTongHopNhapXuatTon : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KT] Báo Cáo Tổng Hợp Nhập Xuất Tồn.repx");
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

            tbl.Columns.Add("sum_tondauky", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_nhaptrongky", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_xuattrongky", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_toncuoiky", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));

            //Footer
            int lastRow = tbl.Rows.Count - 1;
            
            var sum_tondauky = tbl.Compute("Sum(tondauky)", string.Empty).ToString();
            var sum_nhaptrongky = tbl.Compute("Sum(nhaptrongky)", string.Empty).ToString();
            var sum_xuattrongky = tbl.Compute("Sum(xuattrongky)", string.Empty).ToString();
            var sum_toncuoiky = tbl.Compute("Sum(toncuoiky)", string.Empty).ToString();

            var tondauky_cell = report.Report.FindControl("tondauky", true);
            tondauky_cell.DataBindings[0].FormatString = sothapphan;
            var nhaptrongky_cell = report.Report.FindControl("nhaptrongky", true);
            nhaptrongky_cell.DataBindings[0].FormatString = sothapphan;
            var xuattrongky_cell = report.Report.FindControl("xuattrongky", true);
            xuattrongky_cell.DataBindings[0].FormatString = sothapphan;
            var toncuoiky_cell = report.Report.FindControl("toncuoiky", true);
            toncuoiky_cell.DataBindings[0].FormatString = sothapphan;
            var sum_tondauky_cell = report.Report.FindControl("sum_tondauky", true);
            sum_tondauky_cell.DataBindings[0].FormatString = sothapphan;
            var sum_nhaptrongky_cell = report.Report.FindControl("sum_nhaptrongky", true);
            sum_nhaptrongky_cell.DataBindings[0].FormatString = sothapphan;
            var sum_xuattrongky_cell = report.Report.FindControl("sum_xuattrongky", true);
            sum_xuattrongky_cell.DataBindings[0].FormatString = sothapphan;
            var sum_toncuoiky_cell = report.Report.FindControl("sum_toncuoiky", true);
            sum_toncuoiky_cell.DataBindings[0].FormatString = sothapphan;
            for(int i = 0; i < tbl.Rows.Count; i++)
            {
                DataRow row = tbl.Rows[i];
                //Header
                row["logo"] = infoPrint.logo;
                //Footer
                row["dd"] = infoPrint.dd;
                row["MM"] = infoPrint.MM;
                row["yyyy"] = infoPrint.yyyy;
                if ((decimal)row["tondauky"] == 0)
                    row["tondauky"] = DBNull.Value;
                if ((decimal)row["nhaptrongky"] == 0)
                    row["nhaptrongky"] = DBNull.Value;
                if ((decimal)row["xuattrongky"] == 0)
                    row["xuattrongky"] = DBNull.Value;
                if ((decimal)row["toncuoiky"] == 0)
                    row["toncuoiky"] = DBNull.Value;

                if (string.IsNullOrEmpty(sum_tondauky))
                    row["sum_tondauky"] = DBNull.Value;
                else
                    row["sum_tondauky"] = double.Parse(sum_tondauky);

                if (string.IsNullOrEmpty(sum_nhaptrongky))
                    row["sum_nhaptrongky"] = DBNull.Value;
                else
                    row["sum_nhaptrongky"] = double.Parse(sum_nhaptrongky);

                if (string.IsNullOrEmpty(sum_xuattrongky))
                    row["sum_xuattrongky"] = DBNull.Value;
                else
                    row["sum_xuattrongky"] = double.Parse(sum_xuattrongky);

                if (string.IsNullOrEmpty(sum_toncuoiky))
                    row["sum_toncuoiky"] = DBNull.Value;
                else
                    row["sum_toncuoiky"] = double.Parse(sum_toncuoiky);
            }
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
        string thang = context.Request.QueryString["thang"];
		string nam = context.Request.QueryString["nam"];
		string kho = context.Request.QueryString["kho"];
        thang = thang.Length < 2 ? "0" + thang : thang;
        
        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'01/{0}/{1} 00:00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(second ,23 * 60 * 60 + 59 * 60 + 59, @denngay);
            declare @ngaycuoikytruoc datetime = @tungay - 1;
            declare @namkytruoc int = year(@ngaycuoikytruoc);
            declare @thangkytruoc int = month(@ngaycuoikytruoc);
            declare @kho nvarchar(32) = '{2}';
            declare @tenkho nvarchar(MAX) = (select ten_kho from md_kho where md_kho_id = @kho);
            declare @tblKyHienTai table (
	            md_sanpham_id nvarchar(32)
                , md_donvitinhsanpham_id nvarchar(32)
	            , tondauky decimal(18, 4)
	            , nhaptrongky decimal(18, 4)
	            , xuattrongky decimal(18, 4)
            )

            insert into @tblKyHienTai
            select 
	            A.md_sanpham_id
	            , A.md_donvitinhsanpham_id
	            , sum(A.tondauky) as tondauky
	            , sum(A.nhaptrongky) as nhaptrongky
	            , sum(A.xuattrongky) as xuattrongky
            from (
	            select
		            ksp.md_sanpham_id
                    , kgd.md_donvitinhsanpham_id
		            , 0 as tondauky
		            , sum(isnull(kgd.soluong_dichchuyen, 0)) as nhaptrongky
		            , 0 as xuattrongky
	            FROM 
		            md_kho_sanpham ksp (nolock)
		            left join (
			            select 
				            kgd.soluong_dichchuyen
				            , kgd.md_kho_id
				            , kgd.md_sanpham_id
				            , kgd.md_donvitinhsanpham_id
			            from 
				            md_kho_giaodich kgd (nolock)
			            where
				            1=1
				            and kgd.md_kho_id = @kho
				            and kgd.kieuchuyen = N'Nhập kho'
				            and kgd.ngaychuyen between @tungay and @denngay
		            ) kgd on kgd.md_kho_id = ksp.md_kho_id and ksp.md_sanpham_id = kgd.md_sanpham_id
	            WHERE 
		            ksp.md_kho_id = @kho
	            GROUP BY
		            ksp.md_sanpham_id, kgd.md_donvitinhsanpham_id
	            union
	            select
		            ksp.md_sanpham_id
		            , kgd.md_donvitinhsanpham_id
		            , 0 as tondauky
		            , 0 as nhaptrongky
		            , sum(isnull(kgd.soluong_dichchuyen, 0)) as xuattrongky
	            FROM 
		            md_kho_sanpham ksp
		            left join (
			            select 
				            kgd.soluong_dichchuyen
				            , kgd.md_kho_id
				            , kgd.md_sanpham_id
				            , kgd.md_donvitinhsanpham_id
			            from 
				            md_kho_giaodich kgd (nolock)
			            where
				            1=1
				            and kgd.md_kho_id = @kho
				            and kgd.kieuchuyen = N'Xuất kho'
				            and kgd.ngaychuyen between @tungay and @denngay
		            ) kgd on kgd.md_kho_id = ksp.md_kho_id and ksp.md_sanpham_id = kgd.md_sanpham_id
	            WHERE 
		            ksp.md_kho_id = @kho
	            GROUP BY
		            ksp.md_sanpham_id, kgd.md_donvitinhsanpham_id
            )A
            GROUP BY
		            A.md_sanpham_id
		            , A.md_donvitinhsanpham_id
            
            select A.*
            , (A.tondauky + A.nhaptrongky - A.xuattrongky) as toncuoiky 
            , N'Kỳ {0}/{1}' as ky
            from 
            (
                select 
	                sp.ma_sanpham as ma_vthh
	                , sp.mota_tiengviet as ten_vthh
	                , dvtsp.ten_dvt as dvt
                    , @tenkho as kho
	                , isnull(
		                (
			                select isnull(sl_cuoiky, 0) 
			                from md_tonghopkho
			                where md_sanpham_id = a.md_sanpham_id 
			                and nam = @namkytruoc 
			                and soky = @thangkytruoc 
			                and md_kho_id = @kho
			                and md_donvitinhsanpham_id = a.md_donvitinhsanpham_id
		                ), 0) tondauky
	                , a.nhaptrongky
	                , a.xuattrongky 
                from 
	                @tblKyHienTai a
	                left join md_sanpham sp (nolock) on sp.md_sanpham_id = a.md_sanpham_id
	                left join md_donvitinhsanpham dvtsp (nolock) on dvtsp.md_donvitinhsanpham_id = a.md_donvitinhsanpham_id
            ) A        
            where A.tondauky + A.nhaptrongky + A.xuattrongky != 0 
            order by
	            A.ma_vthh
		"
        , thang
        , nam
        , kho
        );
		return sql;
    }
}

