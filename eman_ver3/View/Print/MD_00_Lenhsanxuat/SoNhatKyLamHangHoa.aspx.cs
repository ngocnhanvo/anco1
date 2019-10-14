using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Lenhsanxuat_SoNhatKyLamHangHoa : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Sổ Nhật Ký Làm Hàng Hóa.repx");
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
            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            var sum_soluong = tbl.Compute("Sum(soluong)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sum_soluong))
                tbl.Rows[lastRow]["sum_soluong"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_soluong"] = double.Parse(sum_soluong);

            var sum_soluong_cell = report.Report.FindControl("sum_soluong", true);
            sum_soluong_cell.DataBindings[0].FormatString = sothapphan;
            var soluong_cell = report.Report.FindControl("soluong", true);
            soluong_cell.DataBindings[0].FormatString = sothapphan;

            var tsx_cell = report.Report.FindControl("tsx", true);
            var withF = tsx_cell.WidthF;
            tsx_cell.WidthF = VNN_VariablePublic.GetWidthOfString(tbl.Rows[0]["tsx"].ToString(), "Tahoma", (float)11.5, true);
            var phanxuongText_cell = report.Report.FindControl("phanxuongText", true);
            phanxuongText_cell.LeftF = phanxuongText_cell.LeftF + tsx_cell.WidthF - withF;

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
        var us = VNN_Function.get_user(
            Security.id_taikhoan(context),
            Security.id_vaitro(context),
            Security.id_phongban(context));

        string md_lenhsanxuat_id = context.Request.QueryString["id"];
        md_lenhsanxuat_id = md_lenhsanxuat_id.Replace(",", "','");
        string oper = context.Request.QueryString["oper"];
        string sql = string.Format(@"
            select 
	            lsx.sochungtu as thegiaoviecsx
	            , dhpx.sochungtu as dhpx
	            , dhpx.donhang_thamchieu as ddh
	            , sp.ma_sanpham as ma_vthh
	            , dvtsp.ten_dvt as dvt
	            , cdh.sl_chiato as soluong
	            , (select ten_to from md_phanxuong_to where md_to_id = tsx.md_phanxuong_to_id) as tsx
	            , (select ten_phanxuong from md_phanxuong where md_phanxuong_id = tsx.md_phanxuong_id) as px
            from md_lenhsanxuat_tosx_cdh cdh
	            left join md_lenhsanxuat_tosx tsx on cdh.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
	            left join md_lenhsanxuat lsx on lsx.md_lenhsanxuat_id = tsx.md_lenhsanxuat_id
	            left join md_dondathangphanxuong dhpx on dhpx.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id
	            left join md_sanpham sp on cdh.md_sanpham_id = sp.md_sanpham_id
	            left join md_donvitinhsanpham dvtsp on cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
            where 1=1
	            and tsx.md_lenhsanxuat_tosx_id in ('{0}')
            order by sp.ma_sanpham asc
		"
        , md_lenhsanxuat_id
        );
        return sql;
    }
}