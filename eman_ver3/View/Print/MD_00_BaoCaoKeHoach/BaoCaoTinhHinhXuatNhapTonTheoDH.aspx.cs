using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public partial class PrintControllers_MD_00_BaoCaoKeHoach_BaoCaoTinhHinhXuatNhapTonTheoDH : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        sothapphan = PrintAnco2.Replace0ToHyphen(sothapphan);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "(KH) Báo Cáo Tình Hình Xuất Nhập Tồn Theo Đơn Hàng.xls";
        string nameRpt = "Báo Cáo Tình Hình Xuất Nhập Tồn Theo Đơn Hàng";
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

    public string CreateSql(HttpContext context)
    {
        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];

        var tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
        var den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
        string donhang = context.Request.QueryString["donhang"];
        string masp = context.Request.QueryString["masp"];

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59:59',103);
            
            declare @tbl1 table (
	            ghiChu nvarchar(MAX),
	            donHang nvarchar(MAX),
	            maHang nvarchar(MAX),
	            spId nvarchar(MAX),
	            dvt nvarchar(MAX),
	            sldh decimal(18, 0)
            )

            insert into @tbl1
                select 
                    null as ghiChu,
	                dsdh.so_po as donHang, 
	                sp.ma_sanpham as maHang,
		            sp.md_sanpham_id,
	                dvtsp.ten_dvt as dvt,
	                (dh.sl_dathang - isnull(dh.sl_giamhanngach, 0)) as sldh
                from c_danhsachdathang dsdh
                left join c_dongdsdh dh on dh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
                left join md_sanpham sp on sp.md_sanpham_id = dh.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
                where 
                    dsdh.hangiaohang_po between @tungay and @denngay 
                    and dsdh.trangthai = 'HIEULUC' {2} {3}

            declare @tblSLDG table (
	            soluong_dichchuyen decimal(18, 0),
	            donHang nvarchar(MAX),
	            md_sanpham_id nvarchar(MAX)
            )

            insert into @tblSLDG
            select soluong_dichchuyen, kgd.mota, kgd.md_sanpham_id
            from md_kho_giaodich kgd
            where 
	            1=1
	            and kgd.mota in (select donHang from @tbl1)
	            and kgd.kieuchuyen = N'Nhập kho'
	            and charindex('PCTPDG/', kgd.dongvanchuyen) = 1
            
            declare @tblSLNK table (
	            soluong_dichchuyen decimal(18, 0),
	            donHang nvarchar(MAX),
	            md_sanpham_id nvarchar(MAX)
            )

            insert into @tblSLNK
            select soluong_dichchuyen, kgd.mota, kgd.md_sanpham_id
            from md_kho_giaodich kgd
            where 
	            1=1
	            and kgd.mota in (select donHang from @tbl1)
	            and kgd.kieuchuyen = N'Nhập kho'
	            and charindex('PVC/', kgd.dongvanchuyen) = 1
	            and sanxuat = 3

            declare @tblSLXK table (
	            soluong_dichchuyen decimal(18, 0),
	            donHang nvarchar(MAX),
	            md_sanpham_id nvarchar(MAX)
            )

            insert into @tblSLXK
            select soluong_dichchuyen, kgd.mota, kgd.md_sanpham_id
            from md_kho_giaodich kgd
            where 
	            1=1
	            and kgd.mota in (select donHang from @tbl1)
	            and kgd.kieuchuyen = N'Xuất kho'
	            and charindex('PXKXB/', kgd.dongnhapxuat) = 1


            select 
                m.*
            from (
                select 
	                m.*, 
	                N'Từ {0} đến {1}' as thang_nam,
                    ROW_NUMBER() OVER(ORDER BY m.donHang, m.maHang) as num,
	                isnull((select sum(isnull(soluong_dichchuyen, 0)) from @tblSLDG kgd where kgd.donHang = m.donHang and kgd.md_sanpham_id = m.spId), 0) as sldg,
		            isnull((select sum(isnull(soluong_dichchuyen, 0)) from @tblSLNK kgd where kgd.donHang = m.donHang and kgd.md_sanpham_id = m.spId), 0) as slnk,
		            isnull((select sum(isnull(soluong_dichchuyen, 0)) from @tblSLXK kgd where kgd.donHang = m.donHang and kgd.md_sanpham_id = m.spId), 0) as slxk
                from @tbl1 m
            ) m
            order by m.donHang, m.maHang
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , donhang
        , masp
        );
        return sql;
    }
}

