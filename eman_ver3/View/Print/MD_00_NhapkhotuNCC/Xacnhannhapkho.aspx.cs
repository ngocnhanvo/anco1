using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_NhapkhotuNCC_Xacnhannhapkho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string c_danhsachdathang_id = context.Request.QueryString["id"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[VT] Phiếu xác nhận nhập kho vật tư.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
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
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            tbl.Columns.Add("dd_yeucau", Type.GetType("System.String"));
            tbl.Columns.Add("MM_yeucau", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy_yeucau", Type.GetType("System.String"));
            tbl.Columns.Add("sum_duocnhap", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_slsct", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thucnhap", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            var ngaydenghi = tbl.Rows[0]["ngaydenghi"] as DateTime?;
            tbl.Rows[0]["dd"] = ngaydenghi.Value.ToString("dd");
            tbl.Rows[0]["MM"] = ngaydenghi.Value.ToString("MM");
            tbl.Rows[0]["yyyy"] = ngaydenghi.Value.ToString("yyyy");
            var ngaygiaohang = tbl.Rows[0]["ngaygiaohang"] as DateTime?;
            if (ngaygiaohang != null)
            {
                tbl.Rows[0]["dd_yeucau"] = ngaygiaohang.Value.ToString("dd");
                tbl.Rows[0]["MM_yeucau"] = ngaygiaohang.Value.ToString("MM");
                tbl.Rows[0]["yyyy_yeucau"] = ngaygiaohang.Value.ToString("yyyy");
            }
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            double sum_duocnhap = double.Parse(tbl.Compute("Sum(duocnhap)", string.Empty).ToString());
            double sum_slsct = double.Parse(tbl.Compute("Sum(slsct)", string.Empty).ToString());
            double sum_thucnhap = double.Parse(tbl.Compute("Sum(thucnhap)", string.Empty).ToString());
            double sum_thanhtien = double.Parse(tbl.Compute("Sum(thanhtien)", string.Empty).ToString());
            tbl.Rows[lastRow]["sum_duocnhap"] = sum_duocnhap;
            tbl.Rows[lastRow]["sum_slsct"] = sum_slsct;
            tbl.Rows[lastRow]["sum_thucnhap"] = sum_thucnhap;
            tbl.Rows[lastRow]["sum_thanhtien"] = sum_thanhtien;
            //FormatString
            var duocnhap_cell = report.Report.FindControl("duocnhap", true);
            duocnhap_cell.DataBindings[0].FormatString = sothapphan;
            var sum_duocnhap_cell = report.Report.FindControl("sum_duocnhap", true);
            sum_duocnhap_cell.DataBindings[0].FormatString = sothapphan;

            var slsct_cell = report.Report.FindControl("slsct", true);
            slsct_cell.DataBindings[0].FormatString = sothapphan;
            var sum_slsct_cell = report.Report.FindControl("sum_slsct", true);
            sum_slsct_cell.DataBindings[0].FormatString = sothapphan;

            var thucnhap_cell = report.Report.FindControl("thucnhap", true);
            thucnhap_cell.DataBindings[0].FormatString = sothapphan;
            var sum_thucnhap_cell = report.Report.FindControl("sum_thucnhap", true);
            sum_thucnhap_cell.DataBindings[0].FormatString = sothapphan;

            var kho_cell = report.Report.FindControl("kho", true);
            var withF = kho_cell.WidthF;
            kho_cell.WidthF = VNN_VariablePublic.GetWidthOfString(tbl.Rows[0]["kho"].ToString(), "Tahoma", (float)9.5, true);
            var theochitietsau_cell = report.Report.FindControl("theochitietsau", true);
            theochitietsau_cell.LeftF = theochitietsau_cell.LeftF + kho_cell.WidthF - withF;
            ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public String CreateSql(HttpContext context)
    {
        var infoPrint = PrintAnco2.GetInfoPrint();
		string md_nhapkho_ncc_id = context.Request.QueryString["md_nhapkho_ncc_id"];
		string sql = string.Format(@"
		select 
            sp.ma_sanpham as ma_vthh
            , sp.mota_tiengviet as ten_vthh
		    , dvtsp.ten_dvt as dvt
            , nk_ncc_dh.tong_sl_dat as duocnhap
            , isnull(nk_ncc_dh.sl_nhap, 0) as thucnhap
            , nk_ncc_dh.sl_muonnhap as slsct
            , (isnull(nk_ncc_dh.sl_nhap, 0) * nk_ncc_dh.giatriVND) as thanhtien
		    , sp.quycachdonggoi as quycach 
            , nk_ncc_dh.giatriVND as dongia
            , null as thanhtien
            , (select ten_kho from md_kho where md_kho_id = nk_ncc.kho) as kho
		    , dmh.so_donmuahang as sct_dmh
            , dmh.ngaydonhang as dd_dmh
            , dmh.ngaydonhang as MM_dmh
            , dmh.ngaydonhang as yyyy_dmh 
            , dmh.donhang_thamchieu as sodonhang
            , dtkd.ten_dtkd as nhacungcap
            , nk_ncc.phieuXNNK as sct_pxnnvt
            , nk_ncc.phieugiaohang
            , nk_ncc.ngaygiaohang
            , nk_ncc.ngaydenghi
		from md_nhapkho_ncc_dh nk_ncc_dh
            inner join md_nhapkho_ncc nk_ncc on nk_ncc.md_nhapkho_ncc_id = nk_ncc_dh.md_nhapkho_ncc_id
		    left join md_sanpham sp on nk_ncc_dh.md_sanpham_id = sp.md_sanpham_id
		    left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
		    inner join c_donmuahang dmh on dmh.c_donmuahang_id = nk_ncc.c_donmuahang_id
		    left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
		where 
            nk_ncc_dh.md_nhapkho_ncc_id = '{0}' 
        order by sp.ma_sanpham asc"
        , md_nhapkho_ncc_id
        );
		return sql;
    }
}
