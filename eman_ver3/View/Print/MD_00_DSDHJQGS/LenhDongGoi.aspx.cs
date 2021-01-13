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
    public string logo = "", sothapphan = "", inPDF = "";
    public string c_danhsachdathang_id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Lệnh đóng gói.repx";
        string nameRpt = "Lệnh đóng gói {sochungtu}";
        string sql = CreateSql(context);

        var task = new System.Threading.Tasks.Task(() =>
        {
            viewReport(sql);
        });

        PrintAnco2.exportDataWithType(task, sql, inPDF, nameTemp, nameRpt, ReportViewer1, true);
    }

    public void viewReport(string SqlQuery)
    {
        var tbl = ((DataSet)ReportViewer1.Report.DataSource).Tables[0];
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
        //Header

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
    }

    public string CreateSql(HttpContext context)
    {
        c_danhsachdathang_id = context.Request.QueryString["id"];
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