using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_DDHPX_Default : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[SX] Đơn đặt hàng phân xưởng.repx";
        string nameRpt = "Đơn đặt hàng phân xưởng {dhtc}";
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

    public string CreateSql(HttpContext context)
    {
        string md_dondathangphanxuong_id = context.Request.QueryString["id"];
        string sql = string.Format(@"
		select getdate() as ngay
		,  (case when  SUBSTRING(sp.ma_sanpham,10,1) != 'F' then SUBSTRING(sp.ma_sanpham,0,9) + '.jpg' else SUBSTRING(sp.ma_sanpham,0,12) + '.jpg' end) as pic
		, px.ten_phanxuong as xuong
		, ddhpx.sochungtu as so, ddhpx.sctdathang as dhso, ddhpx.donhang_thamchieu as dhtc
		, sp.ma_sanpham as ma , sp.mota_tiengviet as ten, dvt.ten_dvt as dvt
		, (cdh.tong_sl_dat - isnull(cdh.sl_giamhanngach, 0)) as SL, cdh.noigiaohang as noigiaohang
		, ddhpx.ngayhoanthanh as ngaycham
		, ddhpx.hdlh as huongdanlamhang
		, ddhpx.hdlhchung as hdlhChung
		, dhcpx.mota as hdlh
		from md_dondathangphanxuong ddhpx with (nolock)
		left join md_dondathangphanxuong_cdh cdh with (nolock) on cdh.md_dondathangphanxuong_id = ddhpx.md_dondathangphanxuong_id
		left join md_phanxuong px with (nolock) on px.md_phanxuong_id = ddhpx.md_phanxuong_id
		left join md_sanpham sp with (nolock) on sp.md_sanpham_id = cdh.md_sanpham_id
		left join md_donvitinhsanpham dvt with (nolock) on dvt.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id
		left join c_danhsachdathang dsdh with (nolock) on dsdh.sochungtu = ddhpx.sctdathang
		left join c_kehoachdathang_dhcpx dhcpx with (nolock) on dhcpx.c_kehoachdathang_dhcpx_id = ddhpx.c_kehoachdathang_dhcpx_id
		where ddhpx.md_dondathangphanxuong_id = '{0}'
		order by sp.ma_sanpham asc
		", md_dondathangphanxuong_id);
        return sql;
    }
}