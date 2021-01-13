using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Nhapkhoton1_PhieuNhapKho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] Phiếu Nhập Kho.repx";
        string nameRpt = "Phiếu Nhập Kho {sct_lsx}";
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

        var sum_soluong = ReportViewer1.Report.Report.FindControl("sum_soluong", true);
        sum_soluong.DataBindings[0].FormatString = sothapphan;

        var kho_cell = ReportViewer1.Report.Report.FindControl("khoxuat", true);
        var withF = kho_cell.WidthF;
        kho_cell.WidthF = VNN_VariablePublic.GetWidthOfString(tbl.Rows[0]["khoxuat"].ToString(), "Tahoma", (float)9.5, true);
        var theochitietsau_cell = ReportViewer1.Report.Report.FindControl("theochitietsau", true);
        theochitietsau_cell.LeftF = theochitietsau_cell.LeftF + kho_cell.WidthF - withF;

        var yeucau = ReportViewer1.Report.Report.FindControl("yeucau", true);
        withF = yeucau.WidthF;
        yeucau.WidthF = VNN_VariablePublic.GetWidthOfString(tbl.Rows[0]["yeucau"].ToString(), "Tahoma", (float)9.5, true);
        var pnNgayThangNam_cell = ReportViewer1.Report.Report.FindControl("pnNgayThangNam", true);
        pnNgayThangNam_cell.LeftF = pnNgayThangNam_cell.LeftF + yeucau.WidthF - withF;
    }

    public String CreateSql(HttpContext context)
    {
        var db = new EntityContext();
        string md_nhapkhoton_id = context.Request.QueryString["id"];
        string oper = context.Request.QueryString["oper"];
        string sql = string.Format(@"
		    select 
                sp.ma_sanpham as ma_vthh 
                , sp.mota_tiengviet as ten_vthh
		        , dvtsp.ten_dvt as dvt
                , xb.sochungtu as sct_lsx 
                , xb.ngaychuyen as ngaychuyen
                , xb.ngaydenghi
                , null xuatcho
                , null as bophan
                , kho.ten_kho as khoxuat
                , xb.mota as diengiai
                , nknb_cdh.sl_nhap as soluong
                , null as dongia
                , null as thanhtien
                , null as khonhap
                , xb.sochungtu as yeucau
		    from md_nhapkhoton xb
		        left join md_nhapkhoton_cdh nknb_cdh on xb.md_nhapkhoton_id = nknb_cdh.md_nhapkhoton_id
                left join md_sanpham sp on nknb_cdh.md_sanpham_id = sp.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on nknb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
                left join md_kho kho on xb.denkho = kho.md_kho_id
		    where 
                nknb_cdh.md_nhapkhoton_id = '{0}'
                and nknb_cdh.sl_nhap > 0
            order by sp.ma_sanpham asc
		"
        , md_nhapkhoton_id
        );
        return sql;
    }
}