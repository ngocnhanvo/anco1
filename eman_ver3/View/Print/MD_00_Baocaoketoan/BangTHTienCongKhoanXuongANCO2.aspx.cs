using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaoketoan_BangTHTienCongKhoanXuongANCO2 : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] Bảng Tổng Hợp Tiền Công Khoán Xưởng ANCO2.repx";
        string nameRpt = "Bảng Tổng Hợp Tiền Công Khoán Xưởng ANCO2";
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
        tbl.Columns.Add("tienBangChu", Type.GetType("System.String"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;

        var sumTienHang = double.Parse(tbl.Rows[lastRow]["sum_tienhang"] + "");
        var mney = VNN_ConvertMoney.convert(sumTienHang, "VND");
        tbl.Rows[lastRow]["tienBangChu"] = mney.Keys.FirstOrDefault();
        //var sLTTKiemKe = report.Report.FindControl("sLTTKiemKe", true);
        //var sumSLTTKiemKe = report.Report.FindControl("sumSLTTKiemKe", true);
        //sLTTKiemKe.DataBindings[0].FormatString =
        //sumSLTTKiemKe.DataBindings[0].FormatString = sothapphan;
    }

    public string CreateSql(HttpContext context)
    {
        string thang = context.Request.QueryString["thang"];
        thang = thang.Length < 2 ? "0" + thang : thang;
        string nam = context.Request.QueryString["nam"];

        string sql = string.Format(@"     
            
            declare @tungay datetime = convert(datetime,N'01/{0}/{1} 00:00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);
            declare @thang_nam nvarchar(MAX) = N'Kỳ ' + CONVERT (nvarchar(10), @tungay, 103) + ' - '+ CONVERT (nvarchar(10), @denngay, 103);            

            declare @toduc1 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'DUC1');
            declare @tobancat1 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'BC1');
            declare @tomai1 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'MAI1');
            declare @tohoantat1 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'HT1');

            declare @toduc1_62 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'DUC1_62');
            declare @tobancat1_62 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'BC1_62');
            declare @tomai1_62 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'MAI1_62');
            declare @tohoantat1_62 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'HT1_62');

            declare @toduc2 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'DUCS1');
            declare @tobancat2 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = N'BCS1');
            declare @tomai2 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = N'MAIS1');
            declare @tohoantat2 nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = 'HTS1');
            declare @tocatsoi nvarchar(150) = (select top 1 ten_phongban from ad_department where ma_phongban = N'TCS');
            declare @toSTD nvarchar(150) = (select top 1 ten_to from md_phanxuong_to where ma_to = N'TO1STĐ');
            
            select 
                A.*,
                A.tienHangPX1 + A.tienHangPX1_62 + A.tienHangPX2 + A.tienHangPXCS + A.tienHangPXSTD + A.tienHangTDG as sum_tienhang
            from (
                select 
                    A.*,
                    A.tienHangDuc1 + A.tienHangBC1 + A.tienHangMai1 + A.tienHangHT1 as tienHangPX1,
                    A.tienHangDuc1_62 + A.tienHangBC1_62 + A.tienHangMai1_62 + A.tienHangHT1_62 as tienHangPX1_62,
                    A.tienHangDuc2 + A.tienHangBC2 + A.tienHangMai2 + A.tienHangHT2 as tienHangPX2,
                    A.tienHangTCS as tienHangPXCS,
                    A.tienHangSTD as tienHangPXSTD,
                    A.tienCongKhoanDG + A.tienCongKhoanLC as tienHangTDG
                from (
                    select 
                        @toduc1 as toduc1,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @toduc1, 0) as tienHangDuc1,
                        @tobancat1 as tobancat1,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tobancat1, 0) as tienHangBC1,
                        @tomai1 as tomai1,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tomai1, 0) as tienHangMai1,
                        @tohoantat1 as tohoantat1,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tohoantat1, 0) as tienHangHT1,

                        @toduc1_62 as toduc1_62,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @toduc1_62, 0) as tienHangDuc1_62,
                        @tobancat1_62 as tobancat1_62,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tobancat1_62, 0) as tienHangBC1_62,
                        @tomai1_62 as tomai1_62,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tomai1_62, 0) as tienHangMai1_62,
                        @tohoantat1_62 as tohoantat1_62,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tohoantat1_62, 0) as tienHangHT1_62,
                        
                        @toduc2 as toduc2,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @toduc2, 0) as tienHangDuc2,
                        @tobancat2 as tobancat2,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tobancat2, 0) as tienHangBC2,
                        @tomai2 as tomai2,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tomai2, 0) as tienHangMai2,
                        @tohoantat2 as tohoantat2,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tohoantat2, 0) as tienHangHT2,
                        @tocatsoi as catsoi,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @tohoantat2, 1) as tienHangTCS,
                        @toSTD as toSTD,
                        [dbo].[GET_TienHangCuaTo](@tungay, @denngay, @toSTD, 0) as tienHangSTD,
                        isnull((
                            select
	                            sum(isnull(xb.tiencongDG, 0))
                            from 
	                            md_vanchuyennoibo xb
                            where 
	                            xb.ngaychuyen between @tungay and @denngay
	                            and xb.md_trangthai_id = 'HIEULUC'
	                            and xb.loaichuyen = 'VCTPDG'
                        ), 0) as tienCongKhoanDG,
                        isnull((
                            select
	                            sum((isnull(xb.tienlencong, 0) + isnull(xb.tiencongghep, 0)))
                            from 
	                            md_xuatban xb
                            where 
	                            xb.ngaychuyen between @tungay and @denngay
	                            and xb.trangthai = 'HIEULUC'
                                and isnull(xb.xuat_thanhly, 0) = 0
                        ), 0) as tienCongKhoanLC,
                        @thang_nam as thang_nam
                )A
            )A
		"
        , thang
        , nam
        );
		return sql;
    }
}

