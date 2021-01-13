using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_XuatBan_phieuGiaoHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Phiếu giao hàng.repx";
        string nameRpt = "Phiếu giao hàng {so_po}";
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
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
    }

    public String CreateSql(HttpContext context)
    {
        string md_xuatban_id = context.Request.QueryString["id"];
        string sql = string.Format(@"
		select 
            sp.ma_sanpham as ma 
            , sp.mota_tiengviet as ten 
		    , dvtsp.ten_dvt as dvt
            , xb_cdh.sl_muonxuat as slgiao
            , xb.sochungtu as so
            , xb.sctdathang as sct_donhang
            , xb.donhang_thamchieu as so_po
            , xb.diachi as diadiemgiaohang
            , xb.mota as diengiai
		from md_xuatban_cdh xb_cdh
            left join md_xuatban xb on xb.md_xuatban_id = xb_cdh.md_xuatban_id
		    left join md_sanpham sp on xb_cdh.md_sanpham_id = sp.md_sanpham_id
		    left join md_donvitinhsanpham dvtsp on xb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
		where 
            xb_cdh.md_xuatban_id = '{0}' 
        order by sp.ma_sanpham asc
		", md_xuatban_id
        );
        return sql;
    }
}
