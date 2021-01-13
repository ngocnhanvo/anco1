using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoSanXuat_BangTongHopThanhToanTienHangSPHT : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    public HttpContext context = HttpContext.Current;
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[SX] Bảng Tổng Hợp Thanh Toán Tiền Hàng Sản Phẩm Hoàn Thành.repx";
        string nameRpt = "Tổng hợp tiền hàng SPHT {thang_nam}";
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
        tbl.Columns.Add("sum_tienhang", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        tbl.Rows[lastRow]["sum_tienhang"] = tbl.Compute("sum(tienhang)", string.Empty);
    }

    public string CreateSql(HttpContext context)
    {
        string thang = context.Request.QueryString["thang"];
        thang = thang.Length < 2 ? "0" + thang : thang;
		string nam = context.Request.QueryString["nam"];
		string px = context.Request.QueryString["px"];
		
		string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'01/{0}/{1} 00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);
            
            select
                A.*,
                A.tienhangTT - A.tientonHT as tienhang,
                N'Tháng {0}/năm {1}' as thang_nam
            from (
                select
	                A.px,
                    A.[tosx],
                    A.md_to_id,
                    A.sapxep,
                    isnull(A.tienhang1, 0) + isnull(A.tienhang2, 0) - isnull((
                        select sum(isnull(vtk.tienvtkhoan, 0) + isnull(vtk.tienvtvipham, 0)) 
                        from md_vattukhoan (nolock) vtk
                        where vtk.md_to_id = A.md_to_id and vtk.nam = {1} and thang = {0}
                    ), 0) as tienhangTT, 
                    isnull((
                        select 
                            sum(isnull(dh.soluong_layton, 0) * dh.gianhancong)
			            FROM 
				            md_vanchuyennoibo (nolock) xnb
				            left join md_vanchuyennoibo_dalayton (nolock) dh on xnb.md_vanchuyennoibo_id = dh.md_vanchuyennoibo_id
				            left join md_kho (nolock) kho on kho.md_kho_id = xnb.tukho
			            where 
				            xnb.loaichuyen = 'VANCNBCTKGH' 
				            and kho.md_to_id = A.md_to_id
				            and xnb.ngaychuyen between @tungay and @denngay
                            and xnb.md_trangthai_id = 'HIEULUC'
                            and dh.mota = 'DLT'
                    ), 0) as tientonHT
                from (
	                select px.ten_phanxuong as px
	                , tosx.ten_to as [tosx]
                    , tosx.md_to_id
                    , tosx.sapxep
	                , (
			            select 
				            sum(kgd.soluong_dichchuyen * kgd.gianhancong)
			            from 
				            md_kho_giaodich kgd
			            where 
				            kgd.ngaychuyen between @tungay and @denngay
				            and sanxuat = 2
				            and kieuchuyen = N'Xuất kho'
				            and md_to_id = tosx.md_to_id
	                ) as tienhang1
	                , (
		                select sum(cdh.soluong_dachuyen * cdh.gianhancong)
		                from md_vanchuyennoibo (nolock) xnb
			                left join md_vanchuyennoibo_cdvc (nolock) cdh on cdh.md_vanchuyennoibo_id = xnb.md_vanchuyennoibo_id
			                left join md_kho (nolock) kho on kho.md_kho_id = xnb.tukho
		                where 
			                ngaychuyen between @tungay and @denngay
			                and xnb.loaichuyen = 'VANCNBCTKGH'
			                and kho.md_to_id = tosx.md_to_id and isnull(kho.hangton, 0) = 0
	                ) as tienhang2
	                FROM md_phanxuong (nolock) px
	                left join md_phanxuong_to (nolock) tosx on tosx.md_phanxuong_id = px.md_phanxuong_id
                    where px.md_phanxuong_id = '{2}'
                )A        
            )A
            where A.tienhangTT -  A.tientonHT > 0
            order by A.sapxep
		"
        , thang
        , nam
        , px
        );
		return sql;
    }
}

