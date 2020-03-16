using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_BaoCaoSanXuat_BangKeTienHangSPHT : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Bảng Kê Tiền Hàng Sản Phẩm Hoàn Thành.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
        // Response.Write(sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
    {
        var da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        var ds = new DataSet();
        da.Fill(ds);
        var tbl = ds.Tables[0];
        if (tbl.Rows.Count > 0)
        {
            var infoPrint = PrintAnco2.GetInfoPrint();

            tbl.Columns.Add("sum_slxuat", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("tongtientt", Type.GetType("System.Double"));
            tbl.Columns.Add("sotienbangchu", Type.GetType("System.String"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            report.DisplayName = "Bảng kê tiền hàng SPHT - " + tbl.Rows[0]["thang_nam"];
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["dd"] = infoPrint.dd;
            tbl.Rows[lastRow]["MM"] = infoPrint.MM;
            tbl.Rows[lastRow]["yyyy"] = infoPrint.yyyy;
            var tongtt = tbl.Compute("sum(thanhtien)", string.Empty).ToString();
            var tienvtkhoan = tbl.Rows[lastRow]["tienvtkhoan"].ToString();
            var tienvtvipham = tbl.Rows[lastRow]["tienvtvipham"].ToString();
            var tienhangton = tbl.Rows[lastRow]["tienhangton"].ToString();

            tbl.Rows[lastRow]["sum_thanhtien"] = tongtt;
            tbl.Rows[lastRow]["sum_slxuat"] = tbl.Compute("sum(slxuat)", string.Empty);

            var tongtientt = Convert.ToDouble(string.IsNullOrEmpty(tongtt) ? "0" : tongtt)
                - Convert.ToDouble(string.IsNullOrEmpty(tienvtkhoan) ? "0" : tienvtkhoan)
                - Convert.ToDouble(string.IsNullOrEmpty(tienvtvipham) ? "0" : tienvtvipham)
                - Convert.ToDouble(string.IsNullOrEmpty(tienhangton) ? "0" : tienhangton);

            tbl.Rows[lastRow]["tongtientt"] = tongtientt;

            var kqDic = VNN_ConvertMoney.convert(tongtientt, "VND").FirstOrDefault();
            tbl.Rows[lastRow]["sotienbangchu"] = kqDic.Key;

            var slxuat_cell = report.Report.FindControl("slxuat", true);
            slxuat_cell.DataBindings[0].FormatString = sothapphan;

            var sum_slxuat_cell = report.Report.FindControl("slxuat", true);
            sum_slxuat_cell.DataBindings[0].FormatString = sothapphan;

            var ma_to = tbl.Rows[lastRow]["ma_to"].ToString();
            if (ma_to != "HT1" & ma_to != "HTS1")
            {
                var cellTTHT = report.Report.FindControl("cellTTHT", true);
                cellTTHT.Text = "";

                //var celltienhangton = report.Report.FindControl("tienhangton", true);
                //celltienhangton.Dispose();

                //var xrTableCell65 = report.Report.FindControl("xrTableCell65", true);
                //xrTableCell65.Dispose();
            }
            report.DataSource = ds;
            report.DataAdapter = da;
            if (string.IsNullOrEmpty(inPDF))
                ReportViewer1.Report = report;
            else
                Helper.viewFile(report);
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public string CreateSql(HttpContext context)
    {
        var infoPrint = PrintAnco2.GetInfoPrint();
        string thang = context.Request.QueryString["thang"];
        thang = thang.Length < 2 ? "0" + thang : thang;
        string nam = context.Request.QueryString["nam"];
        string tosx = context.Request.QueryString["tosx"];

        string sql = string.Format(@"	 
            declare @tosx nvarchar(32) = '{2}';
            declare @tungay datetime = convert(datetime,N'01/{0}/{1} 00:00:00',103);
            declare @denngay datetime = DATEADD(month, ((YEAR(@tungay) - 1900) * 12) + MONTH(@tungay), -1);
            set @denngay = DATEADD(SECOND, 23*3600 + 59 * 60 + 59, @denngay);
            declare @tienvtkhoan decimal(18, 2), @tienvtvipham decimal(18, 2)
            select top 1 @tienvtkhoan = tienvtkhoan, @tienvtvipham = tienvtvipham 
            from md_vattukhoan where md_to_id = @tosx and nam = cast('{1}' as int) and thang = cast('{0}' as int)
            declare @truhangton decimal(18, 0) = (
                select 
                    sum(A.soluong_layton * A.gianhancong)
                from (
                    select 
                        dh.gianhancong
                        , dh.soluong_layton
                        , dh.lsx
                        , dh.md_sanpham_id
                        , ROW_NUMBER() OVER(PARTITION BY dh.lsx, dh.md_sanpham_id ORDER BY xnb.ngaychuyen ASC) as row
			        FROM 
				        md_vanchuyennoibo (nolock) xnb
				        left join md_vanchuyennoibo_dalayton (nolock) dh on xnb.md_vanchuyennoibo_id = dh.md_vanchuyennoibo_id
				        left join md_kho (nolock) kho on kho.md_kho_id = xnb.tukho
			        where 
				        xnb.loaichuyen = 'VANCNBCTKGH' 
				        and kho.md_to_id = @tosx
				        and xnb.ngaychuyen between @tungay and @denngay
                        and isnull(dh.soluong_layton, 0) > 0
                        and xnb.md_trangthai_id = 'HIEULUC'
                )A
                where A.row = 1
            )

            select 
                C.sctPXK
                , C.thegiaoviecsx
                , C.ngaychungtu
	            , C.px
	            , C.tsx
                , C.ma_to
	            , C.ma_hhvt
	            , C.dvt
	            , C.dongia
                , C.ghichu
	            , sum(C.slxuat) as slxuat
	            , sum(C.thanhtien) as thanhtien
                , N'Tháng {0}/năm {1}' as thang_nam
                , @tienvtkhoan as tienvtkhoan
                , @tienvtvipham as tienvtvipham
                , @truhangton as tienhangton
            from (
	            select 
		            B.*
		            , (B.slxuat * B.dongia) as thanhtien
	            from (
		            select
                        A.sctPXK
			            , A.thegiaoviecsx
                        , A.ngaychungtu
			            , px.ten_phanxuong as px
			            , tsx.ten_to as tsx
                        , tsx.ma_to
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
                            , dh.gianhancong as dongia
                            , substring(dh.lsx_to,0, 13) as ghichu
			            FROM 
				            md_xuatkhonb xnb (nolock)
				            left join md_xuatkhonb_cdh dh (nolock) on xnb.md_xuatkhonb_id = dh.md_xuatkhonb_id
				            left join md_kho kho (nolock) on kho.md_kho_id = xnb.tukho
			            where 
				            xnb.bosung = 4 
				            and kho.md_to_id = @tosx
				            and xnb.ngaychuyen between @tungay and @denngay
				            and dh.sl_daxuat is not null
			            union all
			            select
                            xnb.sochungtu as sctPXK
				            , dh.tenhang as thegiaoviecsx
                            , xnb.ngaychuyen as ngaychungtu
				            , kho.md_to_id
				            , dh.soluong_dachuyen as slxuat
				            , xnb.phienbangiaNC
				            , dh.md_sanpham_id
				            , dh.md_donvitinhsanpham_id
                            , dh.gianhancong as dongia
                            , substring(dh.lsx_to,0, 13) as ghichu
			            FROM 
				            md_vanchuyennoibo (nolock) xnb
				            left join md_vanchuyennoibo_cdvc (nolock) dh on xnb.md_vanchuyennoibo_id = dh.md_vanchuyennoibo_id
				            left join md_kho kho (nolock) on kho.md_kho_id = xnb.tukho
			            where 
				            xnb.loaichuyen = 'VANCNBCTKGH' 
				            and kho.md_to_id = @tosx
				            and xnb.ngaychuyen between @tungay and @denngay
				            and isnull(dh.soluong_dachuyen, 0) > 0
		            )A
		            left join md_sanpham sp on sp.md_sanpham_id = A.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = A.md_donvitinhsanpham_id
		            left join md_phanxuong_to tsx on tsx.md_to_id = A.md_to_id
		            left join md_phanxuong px on px.md_phanxuong_id = tsx.md_phanxuong_id
	            )B
            )C
            where C.slxuat > 0
            group by C.dongia, C.dvt, C.ma_hhvt, C.px, C.tsx, C.ma_to, C.thegiaoviecsx, C.ngaychungtu, C.sctPXK, C.ghichu
            order by C.ngaychungtu, C.ma_hhvt, C.thegiaoviecsx
		"
        , thang
        , nam
        , tosx
        );
        return sql;
    }
}

