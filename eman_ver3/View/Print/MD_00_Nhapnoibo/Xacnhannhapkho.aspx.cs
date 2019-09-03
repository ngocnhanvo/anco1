using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Nhapnoibo_Xacnhannhapkho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string c_danhsachdathang_id = context.Request.QueryString["id"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KT] Phiếu xác nhận nhập kho.repx");
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
            tbl.Columns.Add("sum_duocnhap", Type.GetType("System.Double"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            double sum_duocnhap = double.Parse(tbl.Compute("Sum(duocnhap)", string.Empty).ToString());
            tbl.Rows[lastRow]["sum_duocnhap"] = sum_duocnhap;
            //FormatString
            var duocnhap_cell = report.Report.FindControl("duocnhap", true);
            duocnhap_cell.DataBindings[0].FormatString = sothapphan;
            var sum_duocnhap_cell = report.Report.FindControl("sum_duocnhap", true);
            sum_duocnhap_cell.DataBindings[0].FormatString = sothapphan;

            
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
            , null as thucnhap
		    , sp.quycachdonggoi as quycach 
            , nk_ncc_dh.giatriVND as dongia
            , null as thanhtien
            , (select ten_kho from md_kho where md_kho_id = dmh.diadiem_giaohang) as kho
		    , dmh.sochungtu as sct_dmh
            , dmh.ngaydonhang as dd_dmh
            , dmh.ngaydonhang as MM_dmh
            , dmh.ngaydonhang as yyyy_dmh 
            , dmh.donhang_thamchieu as sodonhang
            , dtkd.ma_dtkd as nhacungcap
            , nk_ncc.phieuXNNK as sct_pxnnvt
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
