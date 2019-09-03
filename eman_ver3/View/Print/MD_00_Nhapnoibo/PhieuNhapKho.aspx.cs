using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Nhapnoibo_PhieuNhapKho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
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
            yeucau.WidthF = VNN_VariablePublic.GetWidthOfString(tbl.Rows[0]["yeucau"].ToString(), "Tahoma", (float)9.5, true);
            var pnNgayThangNam_cell = report.Report.FindControl("pnNgayThangNam", true);
            pnNgayThangNam_cell.LeftF = pnNgayThangNam_cell.LeftF + yeucau.WidthF - withF;

            this.ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public String CreateSql(HttpContext context)
    {
        var db = new EntityContext();
        string md_nhapkhonb_id = context.Request.QueryString["id"];
        string oper = context.Request.QueryString["oper"];
        var xk = db.md_nhapkhonb.FirstOrDefault(s => s.md_nhapkhonb_id == md_nhapkhonb_id);
        string khonhap = "null";
        if (xk.bosung == 4)
        {
            khonhap = "(select top 1 ten_kho from md_kho where md_to_id = xb.md_to_id and isnull(hangton, 0) = 0)";
        }
        string sql = string.Format(@"
		    select 
                sp.ma_sanpham as ma_vthh 
                , sp.mota_tiengviet as ten_vthh
		        , dvtsp.ten_dvt as dvt
                , xb.sochungtu as sct_lsx 
                , xb.ngaychuyen as ngaychuyen
                , xb.ngaydenghi
                , isnull(
                    (select top 1 ten_to from md_phanxuong_to where xb.md_to_id = md_to_id),
                    (select top 1 ten_phongban from ad_department where xb.md_to_id = md_phongban_id)
                ) as xuatcho
                , (select top 1 ten_phanxuong from md_phanxuong where xb.md_phanxuong_id = md_phanxuong_id) as bophan
                , kho.ten_kho as khoxuat
                , xb.mota as diengiai
                , nknb_cdh.sl_nhap as soluong
                , null as dongia
                , null as thanhtien
                , {1} as khonhap
                , xb.sochungtu as yeucau
		    from md_nhapkhonb xb
		        left join md_nhapkhonb_cdh nknb_cdh on xb.md_nhapkhonb_id = nknb_cdh.md_nhapkhonb_id
                left join md_sanpham sp on nknb_cdh.md_sanpham_id = sp.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on nknb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
                left join md_kho kho on xb.denkho = kho.md_kho_id
		    where 
                nknb_cdh.md_nhapkhonb_id = '{0}'
                and nknb_cdh.sl_muonnhap > 0
            order by sp.ma_sanpham asc
		"
        , md_nhapkhonb_id
        , khonhap
        );
        return sql;
    }
}