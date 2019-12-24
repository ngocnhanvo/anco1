using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoSanXuat_BangKeTienHangSPHT : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Bảng Kê Tiền Hàng Sản Phẩm Hoàn Thành.repx");
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

            tbl.Columns.Add("sum_slxuat", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;
            tbl.Rows[lastRow]["sum_thanhtien"] = tbl.Compute("sum(thanhtien)", string.Empty);
            tbl.Rows[lastRow]["sum_slxuat"] = tbl.Compute("sum(slxuat)", string.Empty);

            var slxuat_cell = report.Report.FindControl("slxuat", true);
            slxuat_cell.DataBindings[0].FormatString = sothapphan;

            var sum_slxuat_cell = report.Report.FindControl("slxuat", true);
            sum_slxuat_cell.DataBindings[0].FormatString = sothapphan;

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
        string thang = context.Request.QueryString["thang"];
        thang = thang.Length < 2 ? "0" + thang : thang;
		string nam = context.Request.QueryString["nam"];
		string tosx = context.Request.QueryString["tosx"];
		
		string sql = string.Format(@"	 
            declare @tosx nvarchar(32) = '{2}';
            declare @tungay datetime = convert(datetime,N'01/{0}/{1} 00:00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);

            select 
                C.thegiaoviecsx
	            C.px
	            , C.tsx
	            , C.ma_hhvt
	            , C.dvt
	            , C.dongia
	            , sum(C.slxuat) as slxuat
	            , sum(C.thanhtien) as thanhtien
                , N'Tháng {0}/năm {1}' as thang_nam
            from (
	            select 
		            B.*
		            , (B.slxuat * B.dongia) as thanhtien
	            from (
		            select
			            A.thegiaoviecsx
			            , px.ten_phanxuong as px
			            , tsx.ten_to as tsx
			            , sp.ma_sanpham as ma_hhvt
			            , dvtsp.ten_dvt as dvt
			            , A.slxuat
			            , A.dongia
		            from (
			            select
				            dh.tenhang as thegiaoviecsx
				            , kho.md_to_id
				            , dh.sl_daxuat as slxuat
				            , xnb.phienbangiaNC
				            , dh.md_sanpham_id
				            , dh.md_donvitinhsanpham_id
                            , dh.gianhancong as dongia
			            FROM 
				            md_xuatkhonb xnb (nolock)
				            left join md_xuatkhonb_cdh dh (nolock) on xnb.md_xuatkhonb_id = dh.md_xuatkhonb_id
				            left join md_kho kho (nolock) on kho.md_kho_id = xnb.tukho
			            where 
				            xnb.bosung = 4 
				            and kho.md_to_id = @tosx
				            and xnb.ngaychuyen between @tungay and @denngay
				            and dh.sl_daxuat is not null
			            union all
			            select
				            xnb.sochungtu
				            , kho.md_to_id
				            , dh.soluong_dachuyen as slxuat
				            , xnb.phienbangiaNC
				            , dh.md_sanpham_id
				            , dh.md_donvitinhsanpham_id
                            , dh.gianhancong as dongia
			            FROM 
				            md_vanchuyennoibo xnb (nolock)
				            left join md_vanchuyennoibo_cdvc dh (nolock) on xnb.md_vanchuyennoibo_id = dh.md_vanchuyennoibo_id
				            left join md_kho kho (nolock) on kho.md_kho_id = xnb.tukho
			            where 
				            xnb.loaichuyen = 'VANCNBCTKGH' 
				            and kho.md_to_id = @tosx
				            and xnb.ngaychuyen between @tungay and @denngay
				            and dh.soluong_dachuyen is not null
		            )A
		            left join md_sanpham sp on sp.md_sanpham_id = A.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = A.md_donvitinhsanpham_id
		            left join md_phanxuong_to tsx on tsx.md_to_id = A.md_to_id
		            left join md_phanxuong px on px.md_phanxuong_id = tsx.md_phanxuong_id
	            )B
            )C
            where C.slxuat > 0
            group by C.dongia, C.dvt, C.ma_hhvt, C.px, C.tsx, C.thegiaoviecsx
            order by C.ma_hhvt
		"
        , thang
        , nam
        , tosx
        );
		return sql;
    }
}

