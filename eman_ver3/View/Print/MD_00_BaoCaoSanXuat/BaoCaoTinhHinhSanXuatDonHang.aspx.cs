using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaovattu_BaoCaoTinhHinhSanXuatDonHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Báo Cáo Tình Hình Sản Xuất Đơn Hàng.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
        //Response.Write(sql);
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

            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;

            var sltungdonhang_cell = report.Report.FindControl("sltungdonhang", true);
            sltungdonhang_cell.DataBindings[0].FormatString = sothapphan;

            var ttduc_cell = report.Report.FindControl("ttduc", true);
            var duc_cell = report.Report.FindControl("duc", true);
            var ttbancat_cell = report.Report.FindControl("ttbancat", true);
            var bancat_cell = report.Report.FindControl("bancat", true);
            var ttmai_cell = report.Report.FindControl("ttmai", true);
            var mai_cell = report.Report.FindControl("mai", true);
            var tthoantat_cell = report.Report.FindControl("tthoantat", true);
            var hoantat_cell = report.Report.FindControl("hoantat", true);

            if (tbl.Rows[0]["px"].ToString() == "Phân xưởng 1")
            {

            }
            else if (tbl.Rows[0]["px"].ToString() == "Phân xưởng 2")
            {
                ttbancat_cell.Text = ttbancat_cell.Text + " + " + ttmai_cell.Text;
                ttbancat_cell.WidthF = ttbancat_cell.WidthF + ttmai_cell.WidthF;
                bancat_cell.WidthF = ttbancat_cell.WidthF;
                ttmai_cell.Visible = false;
                mai_cell.Visible = false;
            }
            else
            {                
                ttbancat_cell.Visible = false;
                ttmai_cell.Visible = false;
                mai_cell.Visible = false;
                tthoantat_cell.Visible = false;

                var ducbd = duc_cell.DataBindings[0];
                duc_cell.DataBindings.Remove(ducbd);
                var hoantatbd = hoantat_cell.DataBindings[0];
                hoantat_cell.DataBindings.Remove(hoantatbd);
                var bancatbd = bancat_cell.DataBindings[0];
                bancat_cell.DataBindings.Remove(bancatbd);
                bancat_cell.DataBindings.AddRange(new XRBinding[] {
                    new XRBinding("Text", null, "hoantat", "{0:#,#0%}")
                });

                ttduc_cell.Text = "Sơn tĩnh điện";
                ttduc_cell.WidthF = ttduc_cell.WidthF + ttbancat_cell.WidthF + ttmai_cell.WidthF + tthoantat_cell.WidthF;
                bancat_cell.WidthF = ttduc_cell.WidthF;
            }

            report.DataSource = ds;
            report.DataAdapter = da;
            ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public string CreateSql(HttpContext context)
    {
        var infoPrint = PrintAnco2.GetInfoPrint();
        string tungay = context.Request.QueryString["tu"];
		string denngay = context.Request.QueryString["den"];
        string px = context.Request.QueryString["px"];
        DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
		DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
		
		string sql = string.Format(@"	       
        declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
        declare @denngay datetime = convert(datetime,N'{1} 23:59',103);
        select C.*
        , (case when C.hoantat >= 1 then 'OK' else '-' end) as ketqua
        from (    
	        select B.* 
	        , (case when B.dhduc > 0 then B.giaoduc / B.dhduc else 1 end) as duc
	        , (case when B.dhbancat > 0 then B.giaobancat / B.dhbancat else 1 end) as bancat
	        , (case when B.dhmai > 0 then B.giaomai / B.dhmai else 1 end) as mai
	        , (case when B.dhhoantat > 0 then B.giaohoantat / B.dhhoantat else 1 end) as hoantat
	        from ( 
			        select 
				        A.thegiaoviecsx
				        , A.chungloai
				        , (select ten_phanxuong from md_phanxuong where md_phanxuong_id = A.md_phanxuong_id) as px
				        , Sum(isnull(A.giaoduc, 0)) as giaoduc 
				        , Sum(isnull(A.dhduc, 0)) as dhduc
				        , Sum(isnull(A.giaobancat, 0)) as giaobancat
				        , Sum(isnull(A.dhbancat, 0)) as dhbancat
				        , Sum(isnull(A.giaomai, 0)) as giaomai
				        , Sum(isnull(A.dhmai, 0)) as dhmai
				        , Sum(isnull(A.giaohoantat, 0)) as giaohoantat
				        , Sum(isnull(A.dhhoantat, 0)) as dhhoantat
				        , (
					        select sum(tong_sl_dat) 
					        from md_dondathangphanxuong_cdh cdh, md_sanpham sp
					        where cdh.md_sanpham_id = sp.md_sanpham_id
						        and substring(sp.ma_sanpham, 0, 3) = A.chungloai
						        and cdh.md_dondathangphanxuong_id in (
							        select md_dondathangphanxuong_id
							        from md_dondathangphanxuong
							        where donhang_thamchieu = A.thegiaoviecsx
							        and md_phanxuong_id = A.md_phanxuong_id
						        )
				        ) as sltungdonhang
				        , A.ngaytheolsx
				        , A.ngaydkgiaotp
				        , A.ngayxindc
				        , A.lydo
			        from (
				        select
					        dhpx.donhang_thamchieu as thegiaoviecsx
					        , dhpx.md_phanxuong_id
					        --duc
					        , (
						        select isnull(sl_dagiao, 0)
						        where tsx.stt = 0
					        ) as giaoduc
					        , (
						        select isnull(sl_chiato, 0)
						        where tsx.stt = 0
					        ) as dhduc
					        --ban cat
					        , (
						        select isnull(sl_dagiao, 0)
						        where tsx.stt = 1
					        ) as giaobancat
					        , (
						        select isnull(sl_chiato, 0)
						        where tsx.stt = 1
					        ) as dhbancat
					        --mai
					        , (
						        select isnull(sl_dagiao, 0)
						        where tsx.stt = 2
					        ) as giaomai
					        , (
						        select isnull(sl_chiato, 0)
						        where tsx.stt = 2
					        ) as dhmai
					        --hoan tat
					        , (
						        select isnull(sl_dagiao - isnull(sl_layton, 0), 0)
						        where tsx.stt = 9999
					        ) as giaohoantat
					        , (
						        select isnull(sl_chiato, 0)
						        where tsx.stt = 9999
					        ) as dhhoantat
					        , lsx.ngayketthuc as ngaytheolsx
					        , lsx.ngaydkgiaotp
					        , (case when cast(lsx.ngayhoanthanh as date) != cast(lsx.ngaydkgiaotp as date) then lsx.ngayhoanthanh else null end) as ngayxindc
					        , lsx.lydogiaosom_tre as lydo
					        , substring(sp.ma_sanpham, 0, 3) as chungloai
				        FROM md_lenhsanxuat lsx
					        left join md_lenhsanxuat_tosx tsx on tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
					        left join md_lenhsanxuat_tosx_cdh cdh on cdh.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
					        left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
					        left join md_dondathangphanxuong dhpx on dhpx.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id
				        WHERE 1=1
					        and cdh.md_sanpham_id = sp.md_sanpham_id
					        and lsx.ngayketthuc between @tungay and @denngay
					        and lsx.md_phanxuong_id = '{2}'
			        )A

			        group by 
				        A.thegiaoviecsx
				        , A.ngaydkgiaotp
				        , A.ngayxindc
				        , A.ngaytheolsx
				        , A.lydo
				        , A.chungloai
				        , A.md_phanxuong_id
	        )B
        )C
        order by C.ngaytheolsx, C.thegiaoviecsx
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , px
        );
		return sql;
    }
}

