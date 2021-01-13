using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_XuatBan_phieuYeuCauVaXacNhanXuatHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string c_danhsachdathang_id = context.Request.QueryString["id"];

        string nameTemp = "[KH] Phiếu yêu cầu và xác nhận xuất hàng.repx";
        string nameRpt = "Phiếu yêu cầu và xác nhận xuất hàng {ct_dh}";
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
            A.*
            , (A.slpo - A.sldaxuat) as slyeucau
        from (
            select 
                sp.ma_sanpham as masoanco
                , donghang.ma_sanpham_khach as makhach
                , sp.mota_tiengviet as mota 
		        , dvtsp.ten_dvt as dvt
                , (cast(donghang.sl_outer as nvarchar(MAX)) + ' ' + donghang.dvt_outer) as donggoi
                , (donghang.sl_dathang - isnull(donghang.sl_giamhanngach, 0)) as slpo
                , isnull(donghang.sl_dagiao, 0) as sldaxuat
                , xb.donhang_thamchieu as ct_dh
                , xb.sctdathang as ct_dsdh
                , dsdh.diachigiaohang as noigiaohang
                , N'CTY TNHH ANCƠ BÌNH DƯƠNG 2' as ten_dtkd
                , GETDATE() as ngaylap
                , dsdh.huongdanlamhang as dacdiemhanghoa
                , dsdh.huongdanlamhangchung as huongdankhac
		    from md_xuatban_cdh xb_cdh
                left join md_xuatban xb on xb.md_xuatban_id = xb_cdh.md_xuatban_id
		        left join md_sanpham sp on xb_cdh.md_sanpham_id = sp.md_sanpham_id
		        left join md_donvitinhsanpham dvtsp on xb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
                left join c_danhsachdathang dsdh on dsdh.c_danhsachdathang_id = xb.c_danhsachdathang_id
                left join c_dongdsdh donghang on donghang.c_danhsachdathang_id = dsdh.c_danhsachdathang_id and donghang.md_sanpham_id = xb_cdh.md_sanpham_id
		    where 
                xb_cdh.md_xuatban_id = '{0}'
        )A 
        order by A.masoanco asc
		", md_xuatban_id
        );
        return sql;
    }
}
