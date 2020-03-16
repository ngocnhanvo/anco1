using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_NhapkhotuNCC_PhieuNhapKho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KT] Phiếu Nhập Kho.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
        //Response.Write(sql);
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
            var soluong = report.Report.FindControl("soluong", true);
            soluong.DataBindings[0].FormatString = sothapphan;

            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            tbl.Columns.Add("dd_yeucau", Type.GetType("System.String"));
            tbl.Columns.Add("MM_yeucau", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy_yeucau", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            var ngaychuyen = tbl.Rows[0]["ngaychuyen"] as DateTime?;
            tbl.Rows[0]["dd"] = ngaychuyen.Value.ToString("dd");
            tbl.Rows[0]["MM"] = ngaychuyen.Value.ToString("MM");
            tbl.Rows[0]["yyyy"] = ngaychuyen.Value.ToString("yyyy");
            var ngaydenghi = tbl.Rows[0]["ngaydenghi"] as DateTime?;
            tbl.Rows[0]["dd_yeucau"] = ngaydenghi.Value.ToString("dd");
            tbl.Rows[0]["MM_yeucau"] = ngaydenghi.Value.ToString("MM");
            tbl.Rows[0]["yyyy_yeucau"] = ngaydenghi.Value.ToString("yyyy");
            report.DisplayName = tbl.Rows[0]["sct_lsx"] + "-RP010";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            var sumSL = tbl.Compute("Sum(soluong)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sumSL))
                tbl.Rows[lastRow]["sum_soluong"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_soluong"] = double.Parse(sumSL);

            var sumTT = tbl.Compute("Sum(thanhtien)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sumTT))
                tbl.Rows[lastRow]["sum_thanhtien"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_thanhtien"] = double.Parse(sumTT);

            var sum_soluong = report.Report.FindControl("sum_soluong", true);
            sum_soluong.DataBindings[0].FormatString = sothapphan;

            var kho_cell = report.Report.FindControl("khoxuat", true);
            var withF = kho_cell.WidthF;
            kho_cell.WidthF = VNN_VariablePublic.GetWidthOfString(tbl.Rows[0]["khoxuat"].ToString(), "Tahoma", (float)9.5, true);
            var theochitietsau_cell = report.Report.FindControl("theochitietsau", true);
            theochitietsau_cell.LeftF = theochitietsau_cell.LeftF + kho_cell.WidthF - withF;

            var yeucau = report.Report.FindControl("yeucau", true);
            withF = yeucau.WidthF;
            yeucau.WidthF = VNN_VariablePublic.GetWidthOfString(tbl.Rows[0]["yeucau"].ToString(), "Tahoma", (float)10, true);
            var pnNgayThangNam_cell = report.Report.FindControl("pnNgayThangNam", true);
            pnNgayThangNam_cell.LeftF = pnNgayThangNam_cell.LeftF + yeucau.WidthF - withF;

            var xrLabel43_cell = report.Report.FindControl("xrLabel43", true);
            xrLabel43_cell.Visible = false;
            var bophan_cell = report.Report.FindControl("bophan", true);
            bophan_cell.Visible = false;
            var xuatcho_cell = report.Report.FindControl("xuatcho", true);
            xuatcho_cell.WidthF = VNN_VariablePublic.GetWidthOfString(tbl.Rows[0]["xuatcho"].ToString(), "Tahoma", (float)10, true);
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
        var db = new EntityContext();
        string md_nhapkho_ncc_id = context.Request.QueryString["id"];
        string oper = context.Request.QueryString["oper"];
        string sql = string.Format(@"
		    select 
	            sp.ma_sanpham as ma_vthh 
	            , sp.mota_tiengviet as ten_vthh
	            , dvtsp.ten_dvt as dvt
	            , xb.sochungtu as sct_lsx 
	            , xb.ngaychuyen
	            , xb.ngaydenghi
	            , (select ten_dtkd from md_doitackinhdoanh where md_doitackinhdoanh_id = xb.md_doitackinhdoanh_id) as xuatcho
	            , null as bophan
	            , kho.ten_kho as khoxuat
	            , xb.mota as diengiai
	            , sum(nknb_cdh.sl_nhap) as soluong
	            , nknb_cdh.giatriVND as dongia
	            , sum(ceiling(nknb_cdh.giatriVND * nknb_cdh.sl_nhap)) as thanhtien
	            , xb.phieuXNNK as yeucau
            from md_nhapkho_ncc xb
	            left join md_nhapkho_ncc_dh nknb_cdh on xb.md_nhapkho_ncc_id = nknb_cdh.md_nhapkho_ncc_id
	            left join md_sanpham sp on nknb_cdh.md_sanpham_id = sp.md_sanpham_id
	            left join md_donvitinhsanpham dvtsp on nknb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
	            left join md_kho kho on xb.kho = kho.md_kho_id
            where 
	            nknb_cdh.md_nhapkho_ncc_id = '{0}'
	            and nknb_cdh.sl_nhap > 0
            group by
	            sp.ma_sanpham
	            , sp.mota_tiengviet
	            , dvtsp.ten_dvt
	            , xb.sochungtu
	            , xb.ngaychuyen
	            , xb.ngaydenghi
	            , xb.md_doitackinhdoanh_id
	            , kho.ten_kho
	            , xb.mota
	            , nknb_cdh.giatriVND
	            , xb.phieuXNNK
            order by sp.ma_sanpham asc
		"
        , md_nhapkho_ncc_id
        );
        return sql;
    }
}