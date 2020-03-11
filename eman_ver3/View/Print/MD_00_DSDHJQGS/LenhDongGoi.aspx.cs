using System;
using System.Data;
using DataAcess;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.UI;

public partial class PrintControllers_MD_00_DSDHJQGS_LenhDongGoi : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string c_danhsachdathang_id = context.Request.QueryString["id"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Lệnh đóng gói.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(c_danhsachdathang_id);
        viewReport(report, sql, c_danhsachdathang_id);
    }

    public void viewReport(XtraReport report, string SqlQuery, string c_danhsachdathang_id)
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
            var db = new EntityContext();
            var varCong = db.c_phidathang.Where(tg => tg.c_danhsachdathang_id == c_danhsachdathang_id && tg.isphicong == true);
            var varTru = db.c_phidathang.Where(gi => gi.c_danhsachdathang_id == c_danhsachdathang_id && gi.isphicong == false);
            var diengiaiCong = string.Join(", ", varCong.Select(s => s.mota).ToList());
            var diengiaiTru = string.Join(", ", varTru.Select(s => s.mota).ToList());
            var sumCong = varCong.Sum(s => s.sotien).GetValueOrDefault(0);
            var sumTru = varTru.Sum(s => s.sotien).GetValueOrDefault(0);

            var sumSLDH = double.Parse(tbl.Compute("Sum(slDH)", string.Empty).ToString());
            var sumSLTPTK = double.Parse(tbl.Compute("Sum(slTPTK)", string.Empty).ToString());
            var sumSLTPSX = double.Parse(tbl.Compute("Sum(slTPSX)", string.Empty).ToString());
            //var sumSLTPDG = double.Parse(tbl.Compute("Sum(slTPDG)", string.Empty).ToString());
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
            tbl.Columns.Add("sumSLDH", Type.GetType("System.Double"));
            tbl.Rows[lastRow]["sumSLDH"] = sumSLDH;
            tbl.Columns.Add("sumSLTPTK", Type.GetType("System.Double"));
            tbl.Rows[lastRow]["sumSLTPTK"] = sumSLTPTK;
            tbl.Columns.Add("sumSLTPSX", Type.GetType("System.String"));
            tbl.Rows[lastRow]["sumSLTPSX"] = sumSLTPSX;
            //tbl.Columns.Add("sumSLTPDG", Type.GetType("System.String"));
            //tbl.Rows[lastRow]["sumSLTPDG"] = sumSLTPDG;
            ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public string CreateSql(string c_danhsachdathang_id)
    {
        string select = String.Format(@"
            select 
	            sp.ma_sanpham as maSP
                , ddsdh.ma_sanpham_khach as maKhach
                , sp.mota_tiengviet as tenSP
                , dvt.ten_dvt as dvt
                , ddsdh.sl_dathang - isnull(ddsdh.sl_giamhanngach, 0) as slDH
                , 0 as slTPTK
                , ddsdh.sl_dathang - isnull(ddsdh.sl_giamhanngach, 0) as slTPSX
                , (cast(ddsdh.sl_inner as nvarchar(MAX)) + ' ' + ddsdh.dvt_inner) as [inner]
                , (cast(ddsdh.sl_outer as nvarchar(MAX)) + ' ' + ddsdh.dvt_outer) as [master]
                , null as slTPDG
                , ddsdh.han_giaohang as thGH
                , null as ghiChu
                , dsdh.so_po as sochungtu
            from 
	            c_danhsachdathang dsdh
                , md_sanpham sp
	            , c_dongdsdh ddsdh
                , md_donvitinhsanpham dvt
            where 1=1
	            AND dsdh.c_danhsachdathang_id = ddsdh.c_danhsachdathang_id
	            AND ddsdh.md_sanpham_id = sp.md_sanpham_id
	            AND sp.md_donvitinhsanpham_id = dvt.md_donvitinhsanpham_id
                AND dsdh.c_danhsachdathang_id = N'{0}' 
            order by 
                sp.ma_sanpham asc"
            , c_danhsachdathang_id == null ? "" : c_danhsachdathang_id);
        return select;
    }
}