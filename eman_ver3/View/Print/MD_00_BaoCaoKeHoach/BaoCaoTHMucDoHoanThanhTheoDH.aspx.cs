using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoTHMucDoHoanThanhTheoDH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Báo Cáo TH Mức Độ Hoàn Thành Theo ĐH.repx";
        string nameRpt = "Báo Cáo TH Mức Độ Hoàn Thành Theo ĐH";
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
        var infoPrint = PrintAnco2.GetInfoPrint();
        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];

        var tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        var den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        donhang = string.IsNullOrEmpty(donhang) ? "" : string.Format(@"and dhpx.donhang_thamchieu like N'{0}'", donhang);
        masp = string.IsNullOrEmpty(masp) ? "" : string.Format(@"and sp.ma_sanpham like N'{0}'", masp);

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 00:00',103);

            declare @tbl table (
	            dhpx nvarchar(32),
	            ngayxonghang datetime,
	            stt int,
	            masp nvarchar(32),
	            v2 decimal(18, 3),
	            px nvarchar(32),
	            sldl decimal(18, 0),
	            sldhpx decimal(18, 0),
	            sllt decimal(18, 0)
            )

            insert into @tbl
            select
	            dhpx.donhang_thamchieu,
	            lsx.ngayketthuc,
	            tsx.stt,
	            sp.ma_sanpham,
	            sp.v2,
	            px.ma_phanxuong,
	            (case 
                    when tsx.stt = 0 
                    then isnull(cdh.sl_dahoanthanh, 0)
                    when tsx.stt = 9999
                    then 
                        case 
                            when isnull(cdh.sl_dagiao, 0) > cdh.sl_nhapkho
                            then isnull(cdh.sl_dagiao, 0) - cdh.sl_nhapkho
                            else 0
                        end   
                    else isnull(cdh.sl_dagiao, 0) 
                end) sldl,
	            isnull((
		            select 
			            sum(dhpxDH.tong_sl_dat - isnull(dhpxDH.sl_giamhanngach, 0))
		            from 
			            md_dondathangphanxuong_cdh dhpxDH
		            where 
			            dhpxDH.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
			            and cdh.macuoi like N'%' + dhpxDH.macuoi + '%'
	            ), 0) as sldhpx,
	            cdh.sl_nhapkho as sllt
            from 
	            md_lenhsanxuat lsx
	            left join md_dondathangphanxuong dhpx on dhpx.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id
	            left join md_phanxuong px on dhpx.md_phanxuong_id = px.md_phanxuong_id
	            left join md_lenhsanxuat_tosx tsx on lsx.md_lenhsanxuat_id = tsx.md_lenhsanxuat_id
	            left join md_lenhsanxuat_tosx_cdh cdh on cdh.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
	            left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
            where 
	            1=1
	            and lsx.ngayketthuc between @tungay and @denngay
	            and px.ma_phanxuong in ('PX1', 'PX2')
                {2}          

            select 
	            A.*,
	            (case when A.cbmAll > 0 then (A.cbmDuc + A.cbmTonDuc + A.cbmTonHT)/A.cbmAll else 0 end) as duc,
	            (case when A.cbmAll > 0 then (A.cbmBancat + A.cbmTonHT)/A.cbmAll else 0 end) as bancat,
	            (case when A.cbmAll > 0 then (A.cbmMai + A.cbmTonHT)/A.cbmAll else 0 end) as mai,
	            (case when A.cbmAll > 0 then (A.cbmHoantat + A.cbmTonHT)/A.cbmAll else 0 end) as hoantat,
                 N'Từ {0} đến {1}' as thang_nam
            from (
	            select 
		            A.dhpx,
		            A.ngayxonghang,
                    (
			            select sum(B.v2 * B.sllt)
			            from @tbl B
			            where B.dhpx = A.dhpx and B.stt = 0	
		            ) as cbmTonDuc,
                    (
                        select sum(B.v2 * B.sllt)
			            from @tbl B
			            where B.dhpx = A.dhpx and B.stt = 9999
		            ) as cbmTonHT,
		            (
			            select sum(B.v2 * (B.sldl))
			            from @tbl B
			            where B.dhpx = A.dhpx and B.stt = 0	
		            ) as cbmDuc,
		            (
			            select sum(B.v2 * (B.sldl))
			            from @tbl B
			            where 
                            B.dhpx = A.dhpx 
                            and B.stt = (case when B.px = 'PX1' then 1 when B.px = 'PX2' then 2 else 1 end)	
		            ) as cbmBancat,
		            (
			            select sum(B.v2 * (B.sldl))
			            from @tbl B
			            where 
                            B.dhpx = A.dhpx
                            and B.stt = (case when B.px = 'PX1' then 2 when B.px = 'PX2' then 1 else 2 end)	
		            ) as cbmMai,
		            (
			            select sum(B.v2 * (B.sldl))
			            from @tbl B
			            where B.dhpx = A.dhpx and B.stt = 9999	
		            ) as cbmHoantat,
		            (
			            select sum(B.v2 * B.sldhpx)
			            from @tbl B
			            where B.dhpx = A.dhpx and B.stt = 0
		            ) as cbmAll
	            from @tbl A
	            group by A.dhpx, A.ngayxonghang
            )A
            order by A.ngayxonghang, A.dhpx
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , donhang
        , masp
        );
        return sql;
    }
}

