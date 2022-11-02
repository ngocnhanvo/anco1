using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoSanXuat_BangKeTienHangCatSoi : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    public HttpContext context = HttpContext.Current;
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[SX] Bảng Kê Tiền Hàng Sản Phẩm Hoàn Thành.repx";
        string nameRpt = "Bảng kê tiền hàng cát sợi {thang_nam}";
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
        tbl.Columns.Add("sum_slxuat", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
        tbl.Columns.Add("tongtientt", Type.GetType("System.Double"));
        tbl.Columns.Add("sotienbangchu", Type.GetType("System.String"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        var tongtt = tbl.Compute("sum(thanhtien)", string.Empty).ToString();
        var tienvtkhoan = tbl.Rows[lastRow]["tienvtkhoan"].ToString();
        var tienvtvipham = tbl.Rows[lastRow]["tienvtvipham"].ToString();

        tbl.Rows[lastRow]["sum_thanhtien"] = tongtt;
        tbl.Rows[lastRow]["sum_slxuat"] = tbl.Compute("sum(slxuat)", string.Empty);

        var tongtientt = Convert.ToDouble(string.IsNullOrEmpty(tongtt) ? "0" : tongtt)
            - Convert.ToDouble(string.IsNullOrEmpty(tienvtkhoan) ? "0" : tienvtkhoan)
            - Convert.ToDouble(string.IsNullOrEmpty(tienvtvipham) ? "0" : tienvtvipham);
        tbl.Rows[lastRow]["tongtientt"] = tongtientt;

        var kqDic = VNN_ConvertMoney.convert(tongtientt, "VND").FirstOrDefault();
        tbl.Rows[lastRow]["sotienbangchu"] = kqDic.Key;

        var slxuat_cell = ReportViewer1.Report.Report.FindControl("slxuat", true);
        slxuat_cell.DataBindings[0].FormatString = sothapphan;

        var sum_slxuat_cell = ReportViewer1.Report.Report.FindControl("slxuat", true);
        sum_slxuat_cell.DataBindings[0].FormatString = sothapphan;

        var labelTitle = ReportViewer1.Report.Report.FindControl("xrLabel2", true);
        labelTitle.Text = "BẢNG KÊ TIỀN HÀNG CÁT SỢI";

        var labelPX = ReportViewer1.Report.Report.FindControl("xrLabel1", true);
        labelPX.Visible = false;
        var PX = ReportViewer1.Report.Report.FindControl("px", true);
        PX.Visible = false;
        var labelTo = ReportViewer1.Report.Report.FindControl("xrLabel9", true);
        labelTo.Text = "Bộ phận:";
    }

    public string CreateSql(HttpContext context)
    {
        string thang = context.Request.QueryString["thang"];
        thang = thang.Length < 2 ? "0" + thang : thang;
        string nam = context.Request.QueryString["nam"];
        string tosx = context.Request.QueryString["tosx"];

        string sql = string.Format(@"	 
            declare @tosx1 nvarchar(32) = (select top 1 md_to_id from md_phanxuong_to where ma_to = 'DUC1');
			declare @tosx1_1 nvarchar(32) = (select top 1 md_to_id from md_phanxuong_to where ma_to = 'DUC1_62');
            declare @tosx2 nvarchar(32) = (select top 1 md_to_id from md_phanxuong_to where ma_to = 'DUCS1');
            declare @tungay datetime = convert(datetime,N'01/{0}/{1} 00:00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);
            declare @tienvtkhoan decimal(18, 2), @tienvtvipham decimal(18, 2)
            select top 1 @tienvtkhoan = tienvtkhoan, @tienvtvipham = tienvtvipham 
            from md_vattukhoan where md_to_id = 'ToCatSoi' and nam = cast('{1}' as int) and thang = cast('{0}' as int)
            
            select 
                C.sctPXK
                , C.thegiaoviecsx
                , C.ngaychungtu
	            , C.px
	            , C.tsx
	            , C.ma_hhvt
	            , C.dvt
	            , C.dongia
                , C.ghichu
	            , sum(C.slxuat) as slxuat
	            , sum(C.thanhtien) as thanhtien
                , N'Tháng {0}/năm {1}' as thang_nam
                , @tienvtkhoan as tienvtkhoan
                , @tienvtvipham as tienvtvipham
            from (
	            select 
		            B.*
		            , (B.slxuat * B.dongia) as thanhtien
	            from (
		            select
                        A.sctPXK
			            , A.thegiaoviecsx
                        , A.ngaychungtu
			            , N'Cát Sợi' as tsx
			            , '' as px
			            , sp.ma_sanpham as ma_hhvt
			            , dvtsp.ten_dvt as dvt
			            , A.slxuat
			            , A.dongia
                        , A.ghichu
		            from (
			            select
                            xnb.sochungtu as sctPXK
				            , dh.tenhang as thegiaoviecsx
                            , xnb.ngaychuyen as ngaychungtu
				            , kho.md_to_id
				            , dh.sl_daxuat as slxuat
				            , xnb.phienbangiaNC
				            , dh.md_sanpham_id
				            , dh.md_donvitinhsanpham_id
                            , gsp.gia as dongia
                            , substring(dh.lsx_to,0, 13) as ghichu
			            FROM 
				            md_xuatkhonb xnb (nolock)
				            left join md_xuatkhonb_cdh dh (nolock) on xnb.md_xuatkhonb_id = dh.md_xuatkhonb_id
				            left join md_kho kho (nolock) on kho.md_kho_id = xnb.tukho
				            left join md_giasanpham (nolock) gsp on gsp.md_sanpham_id = dh.md_sanpham_id
                                and gsp.md_phienbangia_id = (
					                select top 1 md_phienbangia_id 
					                from md_phienbangia
					                where 
						                ten_phienbangia like N'%BG CAT SOI ANCO 2%'
						                and ngay_hieuluc <= xnb.ngaychuyen
                                    order by ngay_hieuluc desc
				                ) 
			            where 
				            xnb.bosung = 4 
				            and kho.md_to_id in (@tosx1, @tosx1_1, @tosx2)
				            and xnb.ngaychuyen between @tungay and @denngay
				            and dh.sl_daxuat is not null
                        union
			            select
                            xnb.sochungtu as sctPXK
				            , dh.tenhang as thegiaoviecsx
                            , xnb.ngaychuyen as ngaychungtu
				            , xnb.md_to_id
				            , dh.soluong_dachuyen as slxuat
				            , xnb.phienbangiaNC
				            , dh.md_sanpham_id
				            , dh.md_donvitinhsanpham_id
                            , gsp.gia as dongia
                            , substring(dh.lsx_to,0, 13) as ghichu
			            FROM 
				            md_vanchuyennoibo xnb (nolock)
				            left join md_vanchuyennoibo_cdvc dh (nolock) on xnb.md_vanchuyennoibo_id = dh.md_vanchuyennoibo_id
				            left join md_giasanpham (nolock) gsp on gsp.md_sanpham_id = dh.md_sanpham_id
                                and gsp.md_phienbangia_id = (
					                select top 1 md_phienbangia_id 
					                from md_phienbangia
					                where 
						                ten_phienbangia like N'%BG CAT SOI ANCO 2%'
						                and ngay_hieuluc <= xnb.ngaychuyen	
                                    order by ngay_hieuluc desc
				                ) 
			            where 
				            xnb.loaichuyen = 'VANCNBCTKGH' 
				            and xnb.md_to_id in (@tosx1, @tosx1_1, @tosx2)
				            and xnb.ngaychuyen between @tungay and @denngay
				            and dh.soluong_dachuyen is not null
		            )A
		            left join md_sanpham sp on sp.md_sanpham_id = A.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = A.md_donvitinhsanpham_id
	            )B
            )C
            where C.slxuat > 0
            group by C.dongia, C.dvt, C.ma_hhvt, C.px, C.tsx, C.thegiaoviecsx, C.ngaychungtu, C.sctPXK, C.ghichu
            order by C.ngaychungtu, C.ma_hhvt, C.thegiaoviecsx
		"
        , thang
        , nam
        , tosx
        );
        return sql;
    }
}

