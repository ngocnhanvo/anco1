using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaovattu_BaoCaoSoSanhDonGiaMuaVatTu : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[VT] Báo Cáo So Sanh Đơn Giá Mua Vật Tư.repx");
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
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;
            var sum_soluong = tbl.Compute("Sum(soluong)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sum_soluong))
                tbl.Rows[lastRow]["sum_soluong"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_soluong"] = double.Parse(sum_soluong);

            var sum_thanhtien = tbl.Compute("Sum(thanhtien)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sum_thanhtien))
                tbl.Rows[lastRow]["sum_thanhtien"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_thanhtien"] = double.Parse(sum_thanhtien);

            var soluong_cell = report.Report.FindControl("soluong", true);
           soluong_cell.DataBindings[0].FormatString = sothapphan;

            var sum_soluong_cell = report.Report.FindControl("sum_soluong", true);
            sum_soluong_cell.DataBindings[0].FormatString = sothapphan;

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
        string tungay = context.Request.QueryString["tu"];
		string denngay = context.Request.QueryString["den"];
		DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
		DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
		string kho = context.Request.QueryString["kho"];
        string mavt = context.Request.QueryString["mavt"].Trim();
        string tenvt = context.Request.QueryString["tenvt"].Trim();
        string madtkd = context.Request.QueryString["madtkd"].Trim();
        string tendtkd = context.Request.QueryString["tendtkd"].Trim();

        mavt = mavt.Length > 0 ? string.Format(" AND sp.ma_sanpham = N'{0}'", mavt) : "";
        tenvt = tenvt.Length > 0 ? string.Format(" AND sp.mota_tiengviet like N'%{0}%'", tenvt) : "";
        madtkd = madtkd.Length > 0 ? string.Format(" AND nkncc.md_doitackinhdoanh_id = (select top 1 md_doitackinhdoanh_id from md_doitackinhdoanh where ma_dtkd = N'{0}')", madtkd) : "";
        tendtkd = tendtkd.Length > 0 ? string.Format(" AND nkncc.ten_dtkd like N'%{0}%'", tendtkd) : "";
        string sql = string.Format(@"
        declare @tungay datetime = convert(datetime,N'{1} 00:00',103);
        declare @denngay datetime = convert(datetime,N'{2} 23:59',103);
		select
            nkncc.sochungtu as sophieu
            , nkncc.ngaychuyen as ngayphieu
            , nkncc.ten_dtkd as ncc
            , sp.ma_sanpham as ma_vthh
            , sp.mota_tiengviet as ten_vthh
            , sp.quycachdonggoi as quycach
            , dvtsp.ten_dvt as dvt
            , dh.sl_danhap as soluong
            , dh.giatriVND as dongia
            , (dh.sl_danhap * dh.giatriVND) as thanhtien
            , kho.ten_kho as kho
            , @tungay as tungay
            , @denngay as denngay
		FROM md_nhapkho_ncc nkncc
            left join md_nhapkho_ncc_dh dh on dh.md_nhapkho_ncc_id = nkncc.md_nhapkho_ncc_id
            left join md_sanpham sp on dh.md_sanpham_id = sp.md_sanpham_id
            left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
		    left join md_kho kho on kho.md_kho_id = nkncc.kho
        WHERE nkncc.trangthai = N'HIEULUC'
		    AND nkncc.kho = '{0}'
		    AND nkncc.ngaychuyen >= @tungay
		    AND nkncc.ngaychuyen <= @denngay
            AND isnull(sp.vattu, 0) = 1
            AND isnull(sp.vattu, 0) = 1
            {3}
            {4}
            {5}
            {6}
		ORDER BY nkncc.ngaychuyen desc, nkncc.sochungtu asc, sp.ma_sanpham asc
		"
        , kho
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , mavt
        , tenvt
        , madtkd
        , tendtkd
        );
		return sql;
    }
}

