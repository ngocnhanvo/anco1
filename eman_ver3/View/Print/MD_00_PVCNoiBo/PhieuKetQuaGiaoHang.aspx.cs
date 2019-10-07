using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.Linq;
public partial class PrintControllers_MD_00_PVCNoiBo_PhieuKetQuaGiaoHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Phiếu Kết Quả Giao Hàng.repx");
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

            tbl.Columns.Add("sum_giao", Type.GetType("System.Double"));
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
            DateTime? ngaydenghi = tbl.Rows[0]["ngaydenghi"] as DateTime?;
            tbl.Rows[lastRow]["dd"] = ngaydenghi.Value.ToString("dd");
            tbl.Rows[lastRow]["MM"] = ngaydenghi.Value.ToString("MM");
            tbl.Rows[lastRow]["yyyy"] = ngaydenghi.Value.ToString("yyyy");

            var sum_giao = tbl.Compute("Sum(giao)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sum_giao))
                tbl.Rows[lastRow]["sum_giao"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_giao"] = double.Parse(sum_giao);

            var sum_giao_cell = report.Report.FindControl("sum_giao", true);
            sum_giao_cell.DataBindings[0].FormatString = sothapphan;
            var giao_cell = report.Report.FindControl("giao", true);
            giao_cell.DataBindings[0].FormatString = sothapphan;
            this.ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public String CreateSql(HttpContext context)
    {
        string md_vanchuyennoibo_id = context.Request.QueryString["id"];
        string oper = context.Request.QueryString["oper"];

        string sql = string.Format(@"
		    select 
                sp.ma_sanpham as ma_hhvt 
                , sp.mota_tiengviet as ten_hhvt
		        , dvtsp.ten_dvt as dvt
                , xb.donhang_thamchieu as sct_donhang
                , xb.chungtu_lenhsx as sct_lsx 
                , xb.ngaydenghi
                , isnull(
                    (select top 1 ten_to from md_phanxuong_to where kho.md_to_id = md_to_id),
                    (select top 1 ten_phongban from ad_department where xb.md_to_id = md_phongban_id)
                ) as tsx
                , (select top 1 ten_phanxuong from md_phanxuong where kho.md_phanxuong_id = md_phanxuong_id) as px
                , kho2.ten_kho as kho
                , xb.mota as diengiai
                , nknb_cdh.soluong_muonchuyen as giao
		    from md_vanchuyennoibo xb
		        left join md_vanchuyennoibo_cdvc nknb_cdh on xb.md_vanchuyennoibo_id = nknb_cdh.md_vanchuyennoibo_id
                left join md_sanpham sp on nknb_cdh.md_sanpham_id = sp.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on nknb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
                left join md_kho kho on xb.tukho = kho.md_kho_id
                left join md_kho kho2 on xb.denkho = kho2.md_kho_id
		    where 
                nknb_cdh.md_vanchuyennoibo_id = '{0}'
                and nknb_cdh.soluong_muonchuyen > 0
            order by sp.ma_sanpham asc
		"
        , md_vanchuyennoibo_id
        );
        return sql;
    }
}




