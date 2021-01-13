using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.Linq;
public partial class PrintControllers_MD_00_Xuatnoibo_PhieuChuyenKho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];

        string nameTemp = "[KT] Phiếu Xuất Kho Kiêm Phiếu Chuyển Kho Nội Bộ.repx";
        string nameRpt = "Phiếu Xuất Kho Kiêm Phiếu Chuyển Kho Nội Bộ {sct_lsx}";
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
        var soluong = ReportViewer1.Report.Report.FindControl("soluong", true);
        soluong.DataBindings[0].FormatString = sothapphan;

        tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
        tbl.Columns.Add("dd_yeucau", Type.GetType("System.String"));
        tbl.Columns.Add("MM_yeucau", Type.GetType("System.String"));
        tbl.Columns.Add("yyyy_yeucau", Type.GetType("System.String"));
        //Header
        DateTime? ngaychuyen = tbl.Rows[0]["ngaychuyen"] as DateTime?;
        tbl.Rows[0]["dd"] = ngaychuyen.Value.ToString("dd");
        tbl.Rows[0]["MM"] = ngaychuyen.Value.ToString("MM");
        tbl.Rows[0]["yyyy"] = ngaychuyen.Value.ToString("yyyy");
        DateTime? ngaydenghi = tbl.Rows[0]["ngaydenghi"] as DateTime?;
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
        if(string.IsNullOrEmpty(sumTT))
            tbl.Rows[lastRow]["sum_thanhtien"] =  DBNull.Value;
        else
            tbl.Rows[lastRow]["sum_thanhtien"] = double.Parse(sumTT);

        var sum_soluong = ReportViewer1.Report.Report.FindControl("sum_soluong", true);
        sum_soluong.DataBindings[0].FormatString = sothapphan;
    }

    public String CreateSql(HttpContext context)
    {
        var db = new EntityContext();
        string md_vanchuyennoibo_id = context.Request.QueryString["id"];
        string oper = context.Request.QueryString["oper"];
        var xk = db.md_vanchuyennoibo.FirstOrDefault(s => s.md_vanchuyennoibo_id == md_vanchuyennoibo_id);
        string khonhap = "null";

        string sql = string.Format(@"
		    select 
                sp.ma_sanpham as ma_vthh 
                , sp.mota_tiengviet as ten_vthh
		        , dvtsp.ten_dvt as dvt
                , xb.sochungtu as sct_lsx 
                , xb.ngaychuyen
                , xb.ngaydenghi
                , isnull(
                    (select top 1 ten_to from md_phanxuong_to where kho2.md_to_id = md_to_id),
                    (select top 1 ten_phongban from ad_department where xb.md_to_id = md_phongban_id)
                ) as xuatcho
                , (select top 1 ten_phanxuong from md_phanxuong where kho2.md_phanxuong_id = md_phanxuong_id) as bophan
                , kho.ten_kho as khoxuat
                , kho2.ten_kho as khonhap
                , xb.mota as diengiai
                , nknb_cdh.soluong_dichchuyen as soluong
                , null as dongia
                , null as thanhtien
                , xb.sochungtu as yeucau
		    from md_vanchuyennoibo xb
		        left join md_vanchuyennoibo_cdvc nknb_cdh on xb.md_vanchuyennoibo_id = nknb_cdh.md_vanchuyennoibo_id
                left join md_sanpham sp on nknb_cdh.md_sanpham_id = sp.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on nknb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
                left join md_kho kho on xb.tukho = kho.md_kho_id
                left join md_kho kho2 on xb.denkho = kho2.md_kho_id
		    where 
                nknb_cdh.md_vanchuyennoibo_id = '{0}'
                and nknb_cdh.soluong_dichchuyen > 0
            order by sp.ma_sanpham asc
		"
        , md_vanchuyennoibo_id
        , khonhap
        );
        return sql;
    }
}




