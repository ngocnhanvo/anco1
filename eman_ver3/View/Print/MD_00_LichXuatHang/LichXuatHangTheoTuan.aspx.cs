using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.Linq;
public partial class PrintControllers_MD_00_LichXuatHang_LichXuatHangTheoTuan : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] LỊCH XUÁT HÀNG.repx";
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
        string fmt = "dd/MM/yyyy";
        string sql = $@"
            declare @date datetime = convert(datetime, N'{date}', 103)
		    declare @monday datetime = (SELECT DATEADD(wk, DATEDIFF(wk,0,@date), 0) MondayOfCurrentWeek)
            declare @sunday datetime = dateadd(SECOND, 23*60 *60 + 59*60 + 59, @monday + 6)

            select 
                format(@date, '{fmt}') as ngayin
                , null as tuan_nam
	            , isnull(dsdh.nhanVienLH, dsdh.nguoi_dathang) as nvlh
	            , dsdh.so_po
	            , dsdh.chungloai
	            , (
		            select sum(cdh.sl_dat) 
                    from md_lenhsanxuat_tosx_cdh cdh 
                    where md_lenhsanxuat_id = lsx.md_lenhsanxuat_id and stt = 9999
	            ) as sl
	            , (case when isnull(cont20, 0) + isnull(cont40, 0) + isnull(cont40hc, 0) + isnull(cont45hc, 0) > 0 then 0 else dsdh.cbm end) as cbmLe
	            , dsdh.cont20
	            , dsdh.cont40
	            , dsdh.cont40hc
                , dsdh.cont45hc
                , dsdh.cbm as cbmTong
	            , format(dsdh.ngayhieuluc, 'dd/MM/yyyy') as ngaydathang
	            , format(dsdh.hangiaohang_po, 'dd/MM/yyyy') as ngaygiaohang
                , format(dsdh.giahangngaygiao, 'dd/MM/yyyy') as giahan
                , null as tau1
                , null as tau2
                , null as khachkiem
                , null as ngayTTkcs
	            , null as chiHaTT
                , null as anhDungTT
                , null as ghichu1
                , null as ngayHDTBBTT
                , null as ghichu2
                , null as ngayXNTSDGTT
                , dsdh.ngayDKduTP
                , dsdh.ngayNKTPcuoicung
                , null as ngayDKduTho
                , null as ngayNKTHOcuoicung
                , null as ngayTTDDH
                , dsdh.ngaycoHDDG as ngayDGDB
                , null as formKYC
	            , dsdh.huongdanlamhang
	            , dsdh.huongdanlamhangchung
	            , null as tiendo
                , null as ghichu3
                , dsdh.ngayktDG
            from 
	            c_danhsachdathang dsdh
	            left join md_lenhsanxuat lsx on lsx.donhang_thamchieu = dsdh.so_po
            where
	            dsdh.hangiaohang_po between @monday and @sunday
	            and isnull(dsdh.sanxuatton, 0) = 0
	            and isnull(dsdh.donhangtron, 0) = 0
	            and dsdh.trangthai != 'DAGUI'
		";
        return sql;
    }
}