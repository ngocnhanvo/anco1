using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PrintControllers_MD_00_BaoCaoSanXuat_BaoCaoChiTietTinhHinhSXHH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Báo Cáo Chi Tiết Tình Hình Sản Xuất Hàng Hóa.repx");
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

            tbl.Columns.Add("sumSLCTDuc", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLLTDuc", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLDLDuc", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLCLDuc", Type.GetType("System.Double"));

            tbl.Columns.Add("sumSLCTBanCat", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLDLBanCat", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLCLBanCat", Type.GetType("System.Double"));

            tbl.Columns.Add("sumSLCTMai", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLDLMai", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLCLMai", Type.GetType("System.Double"));

            tbl.Columns.Add("sumSLCTHoanTat", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLLTHoanTat", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLDLHoanTat", Type.GetType("System.Double"));
            tbl.Columns.Add("sumSLCLHoanTat", Type.GetType("System.Double"));

            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header;
            tbl.Rows[0]["logo"] = infoPrint.logo;
            report.DisplayName = "Báo Cáo Chi Tiết Tình Hình Sản Xuất Hàng Hóa";
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            //Footer
            int lastRow = tbl.Rows.Count - 1;

            tbl.Rows[lastRow]["sumSLCTDuc"] = tbl.Compute("sum(sLCTDuc)", string.Empty);
            tbl.Rows[lastRow]["sumSLLTDuc"] = tbl.Compute("sum(sLLTDuc)", string.Empty);
            tbl.Rows[lastRow]["sumSLDLDuc"] = tbl.Compute("sum(sLDLDuc)", string.Empty);
            tbl.Rows[lastRow]["sumSLCLDuc"] = tbl.Compute("sum(sLCLDuc)", string.Empty);

            tbl.Rows[lastRow]["sumSLCTBanCat"] = tbl.Compute("sum(sLCTBanCat)", string.Empty);
            tbl.Rows[lastRow]["sumSLDLBanCat"] = tbl.Compute("sum(sLDLBanCat)", string.Empty);
            tbl.Rows[lastRow]["sumSLCLBanCat"] = tbl.Compute("sum(sLCLBanCat)", string.Empty);

            tbl.Rows[lastRow]["sumSLCTMai"] = tbl.Compute("sum(sLCTMai)", string.Empty);
            tbl.Rows[lastRow]["sumSLDLMai"] = tbl.Compute("sum(sLDLMai)", string.Empty);
            tbl.Rows[lastRow]["sumSLCLMai"] = tbl.Compute("sum(sLCLMai)", string.Empty);

            tbl.Rows[lastRow]["sumSLCTHoanTat"] = tbl.Compute("sum(sLCTHoanTat)", string.Empty);
            tbl.Rows[lastRow]["sumSLLTHoanTat"] = tbl.Compute("sum(sLLTHoanTat)", string.Empty);
            tbl.Rows[lastRow]["sumSLDLHoanTat"] = tbl.Compute("sum(sLDLHoanTat)", string.Empty);
            tbl.Rows[lastRow]["sumSLCLHoanTat"] = tbl.Compute("sum(sLCLHoanTat)", string.Empty);

            var sLCTDuc = report.Report.FindControl("sLCTDuc", true);
            var sLLTDuc = report.Report.FindControl("sLLTDuc", true);
            var sLDLDuc = report.Report.FindControl("sLDLDuc", true);
            var sLCLDuc = report.Report.FindControl("sLCLDuc", true);
            var sLCTBanCat = report.Report.FindControl("sLCTBanCat", true);
            var sLDLBanCat = report.Report.FindControl("sLDLBanCat", true);
            var sLCLBanCat = report.Report.FindControl("sLCLBanCat", true);
            var sLCTMai = report.Report.FindControl("sLCTMai", true);
            var sLDLMai = report.Report.FindControl("sLDLMai", true);
            var sLCLMai = report.Report.FindControl("sLCLMai", true);
            var sLCTHoanTat = report.Report.FindControl("sLCTHoanTat", true);
            var sLLTHoanTat = report.Report.FindControl("sLLTHoanTat", true);
            var sLDLHoanTat = report.Report.FindControl("sLDLHoanTat", true);
            var sLCLHoanTat = report.Report.FindControl("sLCLHoanTat", true);
            var sumSLCTDuc = report.Report.FindControl("sumSLCTDuc", true);
            var sumSLLTDuc = report.Report.FindControl("sumSLLTDuc", true);
            var sumSLDLDuc = report.Report.FindControl("sumSLDLDuc", true);
            var sumSLCLDuc = report.Report.FindControl("sumSLCLDuc", true);
            var sumSLCTBanCat = report.Report.FindControl("sumSLCTBanCat", true);
            var sumSLDLBanCat = report.Report.FindControl("sumSLDLBanCat", true);
            var sumSLCLBanCat = report.Report.FindControl("sumSLCLBanCat", true);
            var sumSLCTMai = report.Report.FindControl("sumSLCTMai", true);
            var sumSLDLMai = report.Report.FindControl("sumSLDLMai", true);
            var sumSLCLMai = report.Report.FindControl("sumSLCLMai", true);
            var sumSLCTHoanTat = report.Report.FindControl("sumSLCTHoanTat", true);
            var sumSLLTHoanTat = report.Report.FindControl("sumSLLTHoanTat", true);
            var sumSLDLHoanTat = report.Report.FindControl("sumSLDLHoanTat", true);
            var sumSLCLHoanTat = report.Report.FindControl("sumSLCLHoanTat", true);

            sLCTDuc.DataBindings[0].FormatString =
            sLLTDuc.DataBindings[0].FormatString =
            sLDLDuc.DataBindings[0].FormatString =
            sLCLDuc.DataBindings[0].FormatString =
            sLCTBanCat.DataBindings[0].FormatString =
            sLDLBanCat.DataBindings[0].FormatString =
            sLCLBanCat.DataBindings[0].FormatString =
            sLCTMai.DataBindings[0].FormatString =
            sLDLMai.DataBindings[0].FormatString =
            sLCLMai.DataBindings[0].FormatString =
            sLCTHoanTat.DataBindings[0].FormatString =
            sLLTHoanTat.DataBindings[0].FormatString =
            sLDLHoanTat.DataBindings[0].FormatString =
            sLCLHoanTat.DataBindings[0].FormatString =
            sumSLCTDuc.DataBindings[0].FormatString =
            sumSLLTDuc.DataBindings[0].FormatString =
            sumSLDLDuc.DataBindings[0].FormatString =
            sumSLCLDuc.DataBindings[0].FormatString =
            sumSLCTBanCat.DataBindings[0].FormatString =
            sumSLDLBanCat.DataBindings[0].FormatString =
            sumSLCLBanCat.DataBindings[0].FormatString =
            sumSLCTMai.DataBindings[0].FormatString =
            sumSLDLMai.DataBindings[0].FormatString =
            sumSLCLMai.DataBindings[0].FormatString =
            sumSLCTHoanTat.DataBindings[0].FormatString =
            sumSLLTHoanTat.DataBindings[0].FormatString =
            sumSLDLHoanTat.DataBindings[0].FormatString =
            sumSLCLHoanTat.DataBindings[0].FormatString = sothapphan;
            
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
        string px = context.Request.QueryString["px"];
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and dhpx.donhang_thamchieu like N'{0}'", donhang);
        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham like N'{0}'", masp);

        string sql = string.Format(@"	 
            declare @px nvarchar(32) = '{0}', @tenPX nvarchar(32) = '';
            set @tenPX = (select ten_phanxuong from md_phanxuong where md_phanxuong_id = @px)
      
            select 
	            A.*,
	            (case when A.sLCLDuc > 0 then '-' else 'OK' end) as tTDuc,
	            (case when A.sLCLBanCat > 0 then '-' else 'OK' end) as tTBanCat,
	            (case when A.sLCLMai > 0 then '-' else 'OK' end) as tTMai,
	            (case when A.sLCLHoanTat > 0 then '-' else 'OK' end) as tTHoanTat,
	            @tenPX as px
            from (
	            select
		            A.*,
		            (A.sLCTDuc + A.sLLTDuc - A.sLDLDuc) as sLCLDuc,
		            (A.sLCTBanCat - A.sLDLBanCat) as sLCLBanCat,
		            (A.sLCTMai - A.sLDLMai) as sLCLMai,
		            (A.sLCTHoanTat + A.sLLTHoanTat - A.sLDLHoanTat) as sLCLHoanTat
	            from (
		            select 
			            A.theGiaoViec,
			            A.mahang,
			            A.dvt,
			            A.nHTGKTP,
			            sum(A.sLCTDuc) as sLCTDuc,
			            sum(A.sLCTBanCat) as sLCTBanCat,
			            sum(A.sLCTMai) as sLCTMai,
			            sum(A.sLCTHoanTat) as sLCTHoanTat,
			            sum(A.sLLTDuc) as sLLTDuc,
			            sum(A.sLLTHoanTat) as sLLTHoanTat,
			            sum(A.sLDLDuc) as sLDLDuc,
			            sum(A.sLDLBanCat) as sLDLBanCat,
			            sum(A.sLDLMai) as sLDLMai,
			            sum(A.sLDLHoanTat) as sLDLHoanTat
		            from (
			            select 
				            dhpx.donhang_thamchieu as theGiaoViec,
				            sp.ma_sanpham as mahang,
				            dvtsp.ten_dvt as dvt,
				            lsx.ngaydkgiaotp as nHTGKTP,

				            (case when tsx.stt = 0 then cdh.sl_chiato else 0 end) as sLCTDuc,
				            (case when tsx.stt = 1 then cdh.sl_chiato else 0 end) as sLCTBanCat,
				            (case when tsx.stt = 2 then cdh.sl_chiato else 0 end) as sLCTMai,
				            (case when tsx.stt = 9999 then cdh.sl_chiato else 0 end) as sLCTHoanTat,
                
				            (case when tsx.stt = 0 then cdh.sl_nhapkho else 0 end) as sLLTDuc,
				            (case when tsx.stt = 9999 then cdh.sl_nhapkho else 0 end) as sLLTHoanTat,

				            (
					            case when tsx.stt = 0 
					            then (
						            case when isnull(cdh.sl_dahoanthanh, 0) > cdh.sl_chiato
						            then cdh.sl_chiato + isnull(cdh.sl_nhapkho, 0)
						            else isnull(cdh.sl_dahoanthanh, 0) + isnull(cdh.sl_nhapkho, 0)
						            end
					            )
					            else 0 
					            end
				            ) as sLDLDuc,
				            (
					            case when tsx.stt = 1
					            then (
						            case when isnull(cdh.sl_dagiao, 0) > cdh.sl_chiato
						            then cdh.sl_chiato
						            else isnull(cdh.sl_dagiao, 0)
						            end
					            )
					            else 0 
					            end
				            ) as sLDLBanCat,
				            (
					            case when tsx.stt = 2
					            then (
						            case when isnull(cdh.sl_dagiao, 0) > cdh.sl_chiato
						            then cdh.sl_chiato
						            else isnull(cdh.sl_dagiao, 0)
						            end
					            )
					            else 0 
					            end
				            ) as sLDLMai,
				            (
					            case when tsx.stt = 9999
					            then (
						            case when isnull(cdh.sl_dagiao, 0) - isnull(cdh.sl_nhapkho, 0) > cdh.sl_chiato
						            then cdh.sl_chiato + isnull(cdh.sl_nhapkho, 0)
						            else isnull(cdh.sl_dagiao, 0)
						            end
					            )
					            else 0 
					            end
				            ) as sLDLHoanTat
			            FROM 
				            md_lenhsanxuat_tosx_cdh cdh
				            left join md_lenhsanxuat_tosx tsx on cdh.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
				            left join md_lenhsanxuat lsx on lsx.md_lenhsanxuat_id = tsx.md_lenhsanxuat_id
				            left join md_dondathangphanxuong dhpx on dhpx.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id
				            left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
				            left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
			            where 
				            1=1
				            and lsx.md_phanxuong_id = @px
				            and lsx.md_trangthai_id in ('DAXL')
                            {1} {2}
		            )A
		            group by A.theGiaoViec, A.mahang, A.dvt, A.nHTGKTP
	            )A
            )A
            order by A.mahang, A.dvt
		"
        , px
        , donhang
        , masp
        );
        return sql;
    }
}

