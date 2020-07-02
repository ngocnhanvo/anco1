using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoSanXuat_BangDeNghiTruTienCongKhoanHangTon : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Bảng Đề Nghị Trừ Tiền Công Khoán Hàng Tồn.repx");
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

            tbl.Columns.Add("sum_sltru", Type.GetType("System.Double"));
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
            report.DisplayName = "Bảng đề nghị trừ tiền hàng tồn - " + tbl.Rows[0]["thang_nam"];
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["sum_thanhtien"] = tbl.Compute("sum(thanhtien)", string.Empty);
            tbl.Rows[lastRow]["sum_sltru"] = tbl.Compute("sum(sltru)", string.Empty);

            var sltru_cell = report.Report.FindControl("sltru", true);
            sltru_cell.DataBindings[0].FormatString = sothapphan;

            var sum_sltru_cell = report.Report.FindControl("sum_sltru", true);
            sum_sltru_cell.DataBindings[0].FormatString = sothapphan;

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
	            C.px
	            , C.tsx
                , C.sochungtu
                , C.ngaychungtu
	            , C.ma_hhvt
                , C.ten_hhvt
	            , C.dvt
	            , C.dongia
                , C.ghichu
	            , sum(C.sltru) as sltru
	            , sum(C.thanhtien) as thanhtien
                , N'Tháng {0}/năm {1}' as thang_nam
            from (
	            select 
		            B.*
		            , (B.sltru * B.dongia) as thanhtien
	            from (
		            select
			            px.ten_phanxuong as px
			            , tsx.ten_to as tsx
			            , sp.ma_sanpham as ma_hhvt
                        , sp.mota_tiengviet as ten_hhvt
			            , dvtsp.ten_dvt as dvt
			            , A.sltru
			            , A.dongia
                        , A.sochungtu
                        , A.ngaychungtu
                        , (
                            select donhang_thamchieu 
                            from md_dondathangphanxuong
                            where md_dondathangphanxuong_id = 
                            (
	                            select md_dondathangphanxuong_id 
	                            from md_lenhsanxuat
	                            where sochungtu = A.lsx
                            )
                        ) as ghichu
		            from (
			            select
				            kho.md_to_id
                            , xnb.sochungtu
                            , xnb.ngaychuyen as ngaychungtu
				            , dh.soluong_layton as sltru
                            , dh.gianhancong as dongia
				            , dh.md_sanpham_id
				            , dh.md_donvitinhsanpham_id
                            , dh.lsx
			            FROM 
				            md_vanchuyennoibo (nolock) xnb
				            left join md_vanchuyennoibo_dalayton (nolock) dh on xnb.md_vanchuyennoibo_id = dh.md_vanchuyennoibo_id
				            left join md_kho (nolock) kho on kho.md_kho_id = xnb.tukho
			            where 
				            xnb.loaichuyen = 'VANCNBCTKGH' 
				            and kho.md_to_id = @tosx
				            and xnb.ngaychuyen between @tungay and @denngay
				            and isnull(dh.soluong_layton, 0) > 0
                            and xnb.md_trangthai_id = 'HIEULUC'
		            )A
		            left join md_sanpham sp on sp.md_sanpham_id = A.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = A.md_donvitinhsanpham_id
		            left join md_phanxuong_to tsx on tsx.md_to_id = A.md_to_id
		            left join md_phanxuong px on px.md_phanxuong_id = tsx.md_phanxuong_id
	            )B
            )C
            where C.sltru > 0
            group by C.dongia, C.dvt, C.ma_hhvt, C.ten_hhvt, C.px, C.tsx, C.ngaychungtu, C.sochungtu, C.ghichu
            order by C.ngaychungtu, C.ma_hhvt
		"
        , thang
        , nam
        , tosx
        );
		return sql;
    }
}

