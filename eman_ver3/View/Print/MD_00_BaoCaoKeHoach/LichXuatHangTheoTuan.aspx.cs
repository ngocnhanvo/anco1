using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.Linq;
public partial class PrintControllers_MD_00_BaoCaoKeHoach_LichXuatHangTheoTuan : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] LỊCH XUÁT HÀNG THEO TUẦN.repx";
        string nameRpt = "LỊCH XUÁT HÀNG THEO TUẦN {ngayin}";
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
    }

    public String CreateSql(HttpContext context)
    {
        string id = context.Request.QueryString["id"];
        string date = context.Request.QueryString["ngayin"];
        string sql = $@"
            declare @date datetime = convert(datetime, N'{date}', 103)
		    declare @monday datetime = (SELECT DATEADD(wk, DATEDIFF(wk,0,@date), 0) MondayOfCurrentWeek)
            declare @sunday datetime = dateadd(SECOND, 23*60 *60 + 59*60 + 59, @monday + 6)

            select 
                format(@date, 'dd/MM/yyyy') as ngayin
	            , dsdh.nguoi_dathang as nvlh
	            , dsdh.so_po
	            , (
		            select STRING_AGG(A.sp1, ', ')
		            from (
			            select distinct top (1000) substring(cdh.sp1, 0, 3) as sp1 
                        from md_lenhsanxuat_tosx_cdh cdh 
                        where md_lenhsanxuat_id = lsx.md_lenhsanxuat_id and cdh.stt = 9999
                        order by substring(cdh.sp1, 0, 3)
                    )A
	            ) as chungloai
	            , (
		            select sum(cdh.sl_dat) 
                    from md_lenhsanxuat_tosx_cdh cdh 
                    where md_lenhsanxuat_id = lsx.md_lenhsanxuat_id and stt = 9999
	            ) as sl
	            , dsdh.cbm as cbmLe
	            , dsdh.cont20
	            , dsdh.cont40
	            , dsdh.cont40hc
	            , format(dsdh.ngayhieuluc, 'dd/MM/yyyy') as ngaydathang
	            , format(dsdh.hangiaohang_po, 'dd/MM/yyyy') as ngaygiaohang
	            , null as giahan
	            , dsdh.huongdanlamhang
	            , dsdh.huongdanlamhangchung
	            , (
		            select sum(cdh.sl_danhapkho) 
                    from md_lenhsanxuat_tosx_cdh cdh 
                    where md_lenhsanxuat_id = lsx.md_lenhsanxuat_id and stt = 9999
	            ) as tiendoNKTP
                , dsdh.reportKCS as kcsFN
                , null as ngaykhachkiem1
                , null as ngaykhachkiem2
                , null as ngaycoHDDG
                , null as ngaycoTSDG
                , null as tem
                , null as baobi
                , null as pallet
                , null as vtkhac
                , null as ngaybookCont
                , null as ngaythucteCont
                , null as ngayETD
            from 
	            c_danhsachdathang dsdh
	            left join md_lenhsanxuat lsx on lsx.donhang_thamchieu = dsdh.so_po
            where
	            dsdh.hangiaohang_po between @monday and @sunday
	            and isnull(dsdh.sanxuatton, 0) = 0
	            and isnull(dsdh.donhangtron, 0) = 0
	            and dsdh.trangthai = '{Helper.HIEULUC}'
		";
        return sql;
    }
}