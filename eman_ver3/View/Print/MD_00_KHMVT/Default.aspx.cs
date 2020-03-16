using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
public partial class PrintControllers_MD_01_MD_00_KHMVT_Default : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[VT] Phiếu yêu cầu mua vật tư.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql, context);
    }

    public void viewReport(XtraReport report, string SqlQuery, HttpContext context)
    {
        SqlDataAdapter da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        report.DataSource = ds;
        report.DataAdapter = da;
        var tbl = ds.Tables[0];
        if (tbl.Rows.Count > 0)
        {
            var infoPrint = PrintAnco2.GetInfoPrint();
            var sl_tonkho = report.Report.FindControl("sl_tonkho", true);
            sl_tonkho.DataBindings[0].FormatString = sothapphan;
            var sl_theobom = report.Report.FindControl("sl_theobom", true);
            sl_theobom.DataBindings[0].FormatString = sothapphan;
            var sl_dutru = report.Report.FindControl("sl_dutru", true);
            sl_dutru.DataBindings[0].FormatString = sothapphan;
            var sl_yeucau = report.Report.FindControl("sl_yeucau", true);
            sl_yeucau.DataBindings[0].FormatString = sothapphan;

            tbl.Columns.Add("sum_tonkho", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_theobom", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_dutru", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_yeucau", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            report.DisplayName = "Phiếu yêu cầu mua VT";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["sum_tonkho"] = double.Parse(tbl.Compute("Sum(sl_tonkho)", string.Empty).ToString());
            tbl.Rows[lastRow]["sum_theobom"] = double.Parse(tbl.Compute("Sum(sl_theobom)", string.Empty).ToString());
            tbl.Rows[lastRow]["sum_dutru"] = double.Parse(tbl.Compute("Sum(sl_dutru)", string.Empty).ToString());
            tbl.Rows[lastRow]["sum_yeucau"] = double.Parse(tbl.Compute("Sum(sl_yeucau)", string.Empty).ToString());
            var sum_tonkho = report.Report.FindControl("sum_tonkho", true);
            sum_tonkho.DataBindings[0].FormatString = sothapphan;
            var sum_theobom = report.Report.FindControl("sum_theobom", true);
            sum_theobom.DataBindings[0].FormatString = sothapphan;
            var sum_dutru = report.Report.FindControl("sum_dutru", true);
            sum_dutru.DataBindings[0].FormatString = sothapphan;
            var sum_yeucau = report.Report.FindControl("sum_yeucau", true);
            sum_yeucau.DataBindings[0].FormatString = sothapphan;
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

    public String CreateSql(HttpContext context)
    {
        var us = VNN_Function.get_user(
            Security.id_taikhoan(context),
            Security.id_vaitro(context),
            Security.id_phongban(context));

        var db = new EntityContext();
        var infoPrint = PrintAnco2.GetInfoPrint();
        string c_kehoachmuavt_id = context.Request.QueryString["id"];
        string sct = db.c_kehoachmuavt.Where(s => s.c_kehoachmuavt_id == c_kehoachmuavt_id).Select(s => s.sochungtu).FirstOrDefault();
        var dhtcs = (from ncvt_dhpx in db.c_nhucauvattu_dhpx
                     join dhpx in db.c_kehoachdathang_dhcpx on ncvt_dhpx.md_dondathangphanxuong_id equals dhpx.c_kehoachdathang_dhcpx_id
                     join khdh in db.c_kehoachdathang on dhpx.c_kehoachdathang_id equals khdh.c_kehoachdathang_id
                     join c in db.c_yeucaumuavt on ncvt_dhpx.c_nhucauvattu_id equals c.c_nhucauvattu_id
                     where c.c_kehoachmuavt_id.Contains(sct)
                     select khdh.donhang_thamchieu).OrderBy(s=>s).ToList();

        string dhtcsStr = string.Join(", ", dhtcs);
        string sql = string.Format(@"
		    select 
                sp.ma_sanpham as ma_vthh 
                , N'{2}' as nguoilapphieu
                , isnull(khmvt.bophanyc_value, khmvt.value_bophantao) as bophanyc
                , sp.mota_tiengviet as ten_vthh 
                , sp.quycachdonggoi as quycach
                , dvt.ten_dvt as dvt 
		        , cdh.sl_can as sl_theobom 
		        , cdh.sl_tonkho 
		        , isnull(cdh.sl_canthem, 0) as sl_dutru 
		        , (cdh.sl_can + isnull(cdh.sl_canthem, 0)) as sl_yeucau
		        , cdh.sl_duyet
		        , cdh.ngayphaico as ngay_dkgiao
                , khmvt.ten_kehoach as sct_khmvt
                , N'{1}' as diengiai
	            , (
                    SELECT 
                        isnull(kho.ten_kho + ',' + char(10), '')
	                FROM c_kehoachmuavt_dklht dklht
	                    inner join md_kho kho on dklht.md_kho_id = kho.md_kho_id
	                WHERE 
                        dklht.md_sanpham_id = cdh.md_sanpham_id 
                        and dklht.c_kehoachmuavt_id = cdh.c_kehoachmuavt_id
	                FOR XML PATH(''),type
                ).value('.','nvarchar(max)') as khoton
		     from c_kehoachmuavt_cdh cdh
		        left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
		        left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
		        left join c_kehoachmuavt khmvt on khmvt.c_kehoachmuavt_id = cdh.c_kehoachmuavt_id 
		     where
                cdh.c_kehoachmuavt_id = '{0}' 
             order by sp.ma_sanpham"
             , c_kehoachmuavt_id
             , dhtcsStr
             , us.hoten
        );
        return sql;

    }
}

