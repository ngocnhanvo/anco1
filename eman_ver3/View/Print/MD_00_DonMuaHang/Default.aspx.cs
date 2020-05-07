using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_DonMuaHang_Default : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[VT] Đơn đặt mua vật tư.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
    {
        SqlDataAdapter da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        DataSet ds = new DataSet();
        da.Fill(ds);

        var tbl = ds.Tables[0];
        if (tbl.Rows.Count > 0)
        {
            var infoPrint = PrintAnco2.GetInfoPrint();
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            tbl.Columns.Add("thueVatText", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            double sum_soluong = double.Parse(tbl.Compute("Sum(soluong)", string.Empty).ToString());
            double sum_thanhtien = double.Parse(tbl.Compute("Sum(thanhtien)", string.Empty).ToString());
            double thueVAT = double.Parse(tbl.Rows[0]["thueVAT"].ToString());
            double sum_thue10 = Math.Ceiling(sum_thanhtien * thueVAT / 100);
            double sum_tongcong = sum_thanhtien + sum_thue10;
            var arr = VNN_ConvertMoney.convert(sum_tongcong, "VND").FirstOrDefault();
            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thue10", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_tongcong", Type.GetType("System.Double"));
            tbl.Columns.Add("bangchu", Type.GetType("System.String"));
            tbl.Rows[lastRow]["sum_soluong"] = sum_soluong;
            tbl.Rows[lastRow]["sum_thanhtien"] = sum_thanhtien;
            tbl.Rows[lastRow]["sum_thue10"] = sum_thue10;
            tbl.Rows[lastRow]["sum_tongcong"] = arr.Value;
            tbl.Rows[lastRow]["bangchu"] = arr.Key;
            tbl.Rows[lastRow]["thueVatText"] = "Thuế VAT " + thueVAT + "%";
            //FormatString
            var soluong_cell = report.Report.FindControl("soluong", true);
            soluong_cell.DataBindings[0].FormatString = sothapphan;
            var sum_soluong_cell = report.Report.FindControl("sum_soluong", true);
            sum_soluong_cell.DataBindings[0].FormatString = sothapphan;
            //Output
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

    public String CreateSql(HttpContext context)
    {
        var infoPrint = PrintAnco2.GetInfoPrint();
        string c_donmuahang_id = context.Request.QueryString["id"];	
		string sql = string.Format(@"
        declare @httt nvarchar(MAX) = (select top 1 ten from md_hinhthucthanhtoan order by sapxep asc)
		select 
            dmh.so_donmuahang as sct_dmvt
            , dmh.ngaygiaohang as thoihan_giaohang
            , dmh.ngaythanhtoan as thoihanthanhtoan
            , (select ten_kho from md_kho where md_kho_id = dmh.diadiem_giaohang) as diadiem_giaohang
		    , dtkd.ten_dtkd as ncc
            , dtkd.tel as sdt
            , dtkd.fax as fax
		    , sp.ma_sanpham as ma_vthh
            , sp.mota_tiengviet as ten_vthh
            , sp.quycachdonggoi as quycach
            , dvt.ten_dvt as dvt
		    , cdmh.sl_dadat as soluong
            , cdmh.dongiamua as dongia
            , CEILING(cdmh.thanhtien) as thanhtien
            , thue.giatri as thueVAT
            , isnull(dmh.hinhthucthanhtoan, @httt) as hinhthucthanhtoan
            , (case when isnull(dmh.mota,'') = '' then N'Không có.' else dmh.mota end) as diengiai
		from c_donmuahang dmh
		    left join c_donmuahang_cdmh cdmh on cdmh.c_donmuahang_id = dmh.c_donmuahang_id
		    left join md_sanpham sp on sp.md_sanpham_id = cdmh.md_sanpham_id
		    left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
		    left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
		    left join md_dongtien dt on dt.md_dongtien_id = dmh.md_dongtien_id
		    left join md_thue_sanpham thue on cdmh.thue = thue.md_thue_sanpham_id
		where dmh.c_donmuahang_id = '{0}'
		order by sp.ma_sanpham asc
		", 
        c_donmuahang_id
        );
		return sql;
    }
}

