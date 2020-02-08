using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Lenhsanxuat_PhieuDeNghiSuaVaGiaoNhanHangTon : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Phiếu Đề Nghị Nhận Phôi Sợi.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(context);
        viewReport(report, sql);
        //Response.Write(sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
    {
        SqlDataAdapter da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        report.DataSource = ds;
        report.DataAdapter = da;
        var tbl = ds.Tables[0];
        if (tbl.Rows.Count > 0)
        {
            var infoPrint = PrintAnco2.GetInfoPrint();
            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            var sum_soluong = tbl.Compute("Sum(soluong)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sum_soluong))
                tbl.Rows[lastRow]["sum_soluong"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_soluong"] = double.Parse(sum_soluong);

            var sum_soluong_cell = report.Report.FindControl("sum_soluong", true);
            sum_soluong_cell.DataBindings[0].FormatString = sothapphan;
            var soluong_cell = report.Report.FindControl("soluong", true);
            soluong_cell.DataBindings[0].FormatString = sothapphan;
            this.ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public String CreateSql(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(
            Security.id_taikhoan(context),
            Security.id_vaitro(context),
            Security.id_phongban(context));

        string md_lenhsanxuat_id = context.Request.QueryString["id"];
        md_lenhsanxuat_id = md_lenhsanxuat_id.Replace(",", "','");
        string oper = context.Request.QueryString["oper"];
  //      string sql = string.Format(@"
  //          select 
	 //           lsx.sochungtu
	 //           , lsx.ngayketthuc as ngayyeucauhoanthanh
	 //           , dhpx.donhang_thamchieu as donhang
	 //           , sp.ma_sanpham as ma_vthh
	 //           , dvtsp.ten_dvt as dvt
	 //           , cdh.tong_sl_dat as soluong
  //          from md_lenhsanxuat lsx
	 //           left join md_dondathangphanxuong dhpx on lsx.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
	 //           left join md_dondathangphanxuong_cdh cdh on cdh.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
	 //           left join md_sanpham sp on cdh.md_sanpham_id = sp.md_sanpham_id
	 //           left join md_donvitinhsanpham dvtsp on cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
  //          where 1=1
	 //           and lsx.md_lenhsanxuat_id in ('{0}')

  //          order by dhpx.donhang_thamchieu asc, sp.ma_sanpham asc
		//"
  //      , md_lenhsanxuat_id
  //      );

        string sql = string.Format(@"
            select 
	            lsx.sochungtu
	            , lsx.ngayketthuc as ngayyeucauhoanthanh
	            , dhpx.donhang_thamchieu as donhang
	            , sp.ma_sanpham as ma_vthh
	            , dvtsp.ten_dvt as dvt
	            , cdh.sl_chiato as soluong
            from md_lenhsanxuat lsx
	            left join md_dondathangphanxuong dhpx on lsx.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
	            left join md_lenhsanxuat_tosx tsx on tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
                left join md_lenhsanxuat_tosx_cdh cdh on cdh.md_lenhsanxuat_tosx_id = tsx.md_lenhsanxuat_tosx_id
	            left join md_sanpham sp on cdh.md_sanpham_id = sp.md_sanpham_id
	            left join md_donvitinhsanpham dvtsp on cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
            where 1=1
	            and lsx.md_lenhsanxuat_id in ('{0}')
                and tsx.stt = 0
                and cdh.sl_chiato > 0
                and cdh.nhanphoisoi = 1
            order by dhpx.donhang_thamchieu asc, sp.ma_sanpham asc
		"
        , md_lenhsanxuat_id
        );
        return sql;
    }
}