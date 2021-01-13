using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaoketoan_BangKeXuatKhoVatTu : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] Bảng Kê Xuất Kho Vật Tư.repx";
        string nameRpt = "Bảng Kê Xuất Kho Vật Tư";
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
        tbl.Columns.Add("sumSoLuong", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["sumSoLuong"] = tbl.Compute("Sum(soLuong)", string.Empty);

        var soLuong = ReportViewer1.Report.Report.FindControl("soLuong", true);
        var sumSoLuong = ReportViewer1.Report.Report.FindControl("sumSoLuong", true);
        soLuong.DataBindings[0].FormatString =
        sumSoLuong.DataBindings[0].FormatString = sothapphan;
    }

    public string CreateSql(HttpContext context)
    {
        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];
        DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
        string bophan = context.Request.QueryString["bophan"];
        string bophanN = context.Request.QueryString["bophanN"];
        string masp = context.Request.QueryString["masp"];

        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham = N'{0}'", masp);

        string sql = string.Format(@"
            
            declare @tungay datetime = convert(datetime,N'{0} 00:00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59:59',103);
            declare @boPhanId nvarchar(MAX) = N'{2}';
            declare @boPhan nvarchar(32) =  (select ten_to from md_phanxuong_to where md_to_id = @boPhanId)
            set @boPhan = (case when isnull(@boPhan, '') = '' then (select ten_phongban from ad_department where md_phongban_id = @boPhanId) else @bophan end)
            declare @phanXuongId nvarchar(32) = (select md_phanxuong_id from md_phanxuong_to where md_to_id = @boPhanId);
            declare @phanXuong nvarchar(MAX) = (select ten_phanxuong from md_phanxuong where md_phanxuong_id = @phanXuongId);
            
            select 
                A.*
                , @boPhan as boPhan
                , @phanXuong as phanXuong
            from (
                select
	                A.sochungtu as soChungTu
	                , A.ngaychuyen as ngayThangNam
                    , A.mota as ghiChu
	                , sp.ma_sanpham as maVTHH
	                , sp.mota_tiengviet as tenVTHH
	                , dvtsp.ten_dvt as dvt
	                , sum(isnull(cdh.sl_thucxuat, 0)) as soLuong
                from 
	                md_xuatkhonb_cdh cdh
                inner join (
	                select
		                xk.md_xuatkhonb_id
		                , xk.sochungtu
		                , xk.ngaychuyen
                        , xk.mota
	                from md_xuatkhonb (nolock) xk
	                where 
		                xk.trangthai = 'HIEULUC'
		                and xk.bosung <= 2
                        and xk.ngaychuyen between @tungay and @denngay
                )A on cdh.md_xuatkhonb_id = A.md_xuatkhonb_id
                left join md_sanpham (nolock) sp on sp.md_sanpham_id = cdh.md_sanpham_id
                left join md_donvitinhsanpham (nolock) dvtsp on dvtsp.md_donvitinhsanpham_id = cdh.md_donvitinhsanpham_id
                where
	                cdh.sl_thucxuat > 0
                    and cdh.md_kho_id = @boPhanId
                    {4}
                group by
	                A.sochungtu, A.ngaychuyen, sp.ma_sanpham, sp.mota_tiengviet, dvtsp.ten_dvt, A.mota
            )A
            order by
	            A.soChungTu, A.ngayThangNam, A.maVTHH
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , bophan
        , bophanN
        , masp
        );
		return sql;
    }
}

