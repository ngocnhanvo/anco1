using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaoketoan_BaoCaoXuatNhapTonGiaTri : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "(KT) BÁO CÁO XUẤT NHẬP TỒN (Giá trị).repx";
        string nameRpt = "BÁO CÁO XUẤT NHẬP TỒN (Có giá trị) {ngayin}";
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
        if (tbl.Rows.Count > 0)
        {

        }
    }

    public String CreateSql(HttpContext context)
    {
        string donhanghuy = System.IO.File.ReadAllText(ExcuteSignalRStatic.mapPathSignalR("~/App_Data/JsonData/0_donhanghuy.txt"));
        donhanghuy = donhanghuy.Replace("\r\n", "',N'");
        string tu = context.Request.QueryString["tu"].removeAllSpaceOrTrimText(true).Replace("-", "/");
        string den = context.Request.QueryString["den"].removeAllSpaceOrTrimText(true).Replace("-", "/");
        //Kho
        string khoId = context.Request.QueryString["kho"].removeAllSpaceOrTrimText(true);
        string kho = khoId.Replace("'", "''");
        if (!string.IsNullOrWhiteSpace(kho))
        {
            kho = $@"and kgd.md_kho_id = N'{kho}'";
        }

        //San pham
        string masp = context.Request.QueryString["masp"].removeAllSpaceOrTrimText(true).Replace("'", "''");
        if (!string.IsNullOrWhiteSpace(masp))
            masp = $@"and sp.ma_sanpham = N'{masp}'";

        var fmtDate = "dd/MM/yyyy";
        string sql = $@"
		    declare @tu datetime = convert(datetime, N'{tu} 00:00:00', 103)
            declare @dauky datetime = convert(datetime, N'01/'+ cast(Month(@tu) as nvarchar(2)) +'/'+ cast(year(@tu) as nvarchar(4)) +' 00:00:00', 103)
            declare @den datetime = convert(datetime, N'{den} 23:59:59', 103)
            declare @tenkho nvarchar(MAX) = (select ten_kho from md_kho where md_kho_id = '{khoId}')

            declare @tbl table (
	            ngaychuyen datetime,
	            maVTHH nvarchar(MAX),
	            tenVTHH nvarchar(MAX),
	            dvt nvarchar(MAX),
	            dg decimal(18,4),
	            sldk decimal(18,4),
	            slntk decimal(18,4),
	            slxtk decimal(18,4),
	            rank_no int
            )

            insert into @tbl
            select 
	            A.*,
	            RANK () OVER (partition by A.maVTHH ORDER BY (case when dg > 0 then 0 else 1 end), ngaychuyen desc) AS Rank_no 
            from (
	            select distinct
		            kgd.ngaychuyen,
		            sp.ma_sanpham as maVTHH,
		            sp.mota_tiengviet as tenVTHH,
		            dvtsp.ten_dvt as dvt,
		            isnull(cdh.dongiamua, 0) as dg,
		            (case when kgd.kieuchuyen = N'{Helper.XuatKho}' then 0 - kgd.soluong_dichchuyen else kgd.soluong_dichchuyen end) as sldk,
		            0 as slntk,
		            0 as slxtk
	            from md_kho_giaodich kgd
		            left join md_sanpham sp on sp.md_sanpham_id = kgd.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
		            left join c_donmuahang dmh on dmh.sochungtu = kgd.mota
		            left join c_donmuahang_cdmh cdh on cdh.c_donmuahang_id = dmh.c_donmuahang_id and cdh.md_sanpham_id = kgd.md_sanpham_id
	            where
		            1=1
		            and kgd.ngaychuyen < @dauky
		            and kgd.soluong_dichchuyen > 0
                    and isnull(kgd.donhang,'') not like N'%,%'
                    and isnull(kgd.donhang,'') not in (N'{donhanghuy}')
                    {masp} {kho}

	            union all

	            select distinct
		            kgd.ngaychuyen,
		            sp.ma_sanpham as maVTHH,
		            sp.mota_tiengviet as tenVTHH,
		            dvtsp.ten_dvt as dvt,
		            isnull(cdh.dongiamua, 0) as dg,
		            0 as sldk,
		            (case when kgd.kieuchuyen = N'{Helper.XuatKho}' then 0 else kgd.soluong_dichchuyen end) as slntk,
		            (case when kgd.kieuchuyen = N'{Helper.XuatKho}' then kgd.soluong_dichchuyen else 0 end) as slxtk
	            from md_kho_giaodich kgd
		            left join md_sanpham sp on sp.md_sanpham_id = kgd.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
		            left join c_donmuahang dmh on dmh.sochungtu = kgd.mota
		            left join c_donmuahang_cdmh cdh on cdh.c_donmuahang_id = dmh.c_donmuahang_id and cdh.md_sanpham_id = kgd.md_sanpham_id
	            where
		            1=1
		            and kgd.ngaychuyen between @tu and @den
		            and kgd.soluong_dichchuyen > 0
                    and isnull(kgd.donhang,'') not like N'%,%'
                    and isnull(kgd.donhang,'') not in (N'{donhanghuy}')
                    {masp} {kho}
            )A

            select
                format(getdate(), '{fmtDate}') as ngayin,
	            format(@tu, '{fmtDate}') as tungay,
	            format(@den, '{fmtDate}') as denngay,
                A.maVTHH,
	            A.tenVTHH,
	            A.dvt,
	            A.dg,
                sum(A.sldk) as tonDK,
	            sum(A.slntk) as nhapTK,
	            sum(A.slxtk) as xuatTK,
                @tenkho as kho,
                null as po
            from (
                select distinct
	                A.maVTHH,
	                A.tenVTHH,
	                A.dvt,
	                B.dg,
                    A.sldk,
                    A.slntk,
                    A.slxtk
                from @tbl A
                outer apply (select dg from @tbl where rank_no = 1 and maVTHH = A.maVTHH)B
            )A
            group by A.maVTHH, A.tenVTHH, A.dvt, A.dg
            order by A.maVTHH
		";

        //throw new Exception(sql);
        return sql;
    }
}

