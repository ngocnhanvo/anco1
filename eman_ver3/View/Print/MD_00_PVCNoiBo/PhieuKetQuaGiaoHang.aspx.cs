using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.Linq;
public partial class PrintControllers_MD_00_PVCNoiBo_PhieuKetQuaGiaoHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        inPDF = context.Request.QueryString["inPDF"];
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Phiếu Kết Quả Giao Hàng.repx");
        string nameTemp = "[SX] Phiếu Kết Quả Giao Hàng.repx";
        string nameRpt = "Phiếu Kết Quả Giao Hàng";
        string sql = CreateSql(context);

        var task = new System.Threading.Tasks.Task(() =>
        {
            viewReport(sql);
        });

        PrintAnco2.exportDataWithType(task, sql, inPDF, nameTemp, nameRpt, ReportViewer1, true);
    }

    public void viewReport(String SqlQuery)
    {
        var tbl = ((DataSet)ReportViewer1.Report.DataSource).Tables[0];

        tbl.Columns.Add("sum_giao", Type.GetType("System.Double"));
        tbl.Columns.Add("dd_yeucau", Type.GetType("System.String"));
        tbl.Columns.Add("MM_yeucau", Type.GetType("System.String"));
        tbl.Columns.Add("yyyy_yeucau", Type.GetType("System.String"));
        DateTime? ngaydenghi = tbl.Rows[0]["ngaydenghi"] as DateTime?;
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["dd_yeucau"] ="";
        tbl.Rows[lastRow]["MM_yeucau"] = "";
        tbl.Rows[lastRow]["yyyy_yeucau"] = ngaydenghi.Value.ToString("yyyy");

        var sum_giao = tbl.Compute("Sum(giao)", string.Empty).ToString();
        if (string.IsNullOrEmpty(sum_giao))
            tbl.Rows[lastRow]["sum_giao"] = DBNull.Value;
        else
            tbl.Rows[lastRow]["sum_giao"] = double.Parse(sum_giao);

        var sum_giao_cell = ReportViewer1.Report.Report.FindControl("sum_giao", true);
        sum_giao_cell.DataBindings[0].FormatString = sothapphan;
        var giao_cell = ReportViewer1.Report.Report.FindControl("giao", true);
        giao_cell.DataBindings[0].FormatString = sothapphan;
    }

    public String CreateSql(HttpContext context)
    {
        string md_vanchuyennoibo_id = context.Request.QueryString["id"];
        string oper = context.Request.QueryString["oper"];
        var db = new EntityContext();
        var countLHT = db.md_vanchuyennoibo_dalayton.Where(s => s.md_vanchuyennoibo_id == md_vanchuyennoibo_id).Sum(s=>s.soluong_layton);
        string chuy = countLHT > 0 ? "N'*** Đơn hàng có lấy hàng tồn'" : "''";
        string sql = string.Format(@"
		    select 
                sp.ma_sanpham as ma_hhvt 
                , sp.mota_tiengviet as ten_hhvt
		        , dvtsp.ten_dvt as dvt
                , xb.donhang_thamchieu as sct_donhang
                , xb.donhang_thamchieu as thegiaoviec
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
				, nknb_cdh.mota as ghichu
                , {1} as chuy
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
        , chuy
        );
        return sql;
    }
}




