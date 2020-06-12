using System;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Lenhsanxuat_TheoGiaoViecSanXuat : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[SX] Thẻ Giao Việc Sản Xuất.repx");
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
            tbl.Columns.Add("sum_slton", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            tbl.Columns.Add("dd_yeucau", Type.GetType("System.String"));
            tbl.Columns.Add("MM_yeucau", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy_yeucau", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            tbl.Rows[0]["dd"] = infoPrint.dd;
            tbl.Rows[0]["MM"] = infoPrint.MM;
            tbl.Rows[0]["yyyy"] = infoPrint.yyyy;
            report.DisplayName = tbl.Rows[0]["donhang"] + "";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            var sumSL = tbl.Compute("Sum(soluong)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sumSL))
                tbl.Rows[lastRow]["sum_soluong"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_soluong"] = double.Parse(sumSL);

            var sumLT = tbl.Compute("Sum(slton)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sumLT))
                tbl.Rows[lastRow]["sum_slton"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_slton"] = double.Parse(sumLT);

            var soluong = report.Report.FindControl("soluong", true);
            var slton = report.Report.FindControl("slton", true);
            var sum_soluong = report.Report.FindControl("sum_soluong", true);
            var sum_slton = report.Report.FindControl("sum_slton", true);

            soluong.DataBindings[0].FormatString =
            slton.DataBindings[0].FormatString =
            sum_soluong.DataBindings[0].FormatString =
            sum_slton.DataBindings[0].FormatString = sothapphan;

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

    public String CreateSql(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(
            Security.id_taikhoan(context),
            Security.id_vaitro(context),
            Security.id_phongban(context));

        string slchiato = "sl_chiato";
        if (us.ma_phongban == "PKH")
        {
            slchiato = "sl_chiato2";
        }
        string md_nhapkho_ncc_id = context.Request.QueryString["id"];
        string oper = context.Request.QueryString["oper"];
        string sql = string.Format(@"
		    select 
                lsx.sochungtu
	            , dhpx.sochungtu as sct_dhpx
	            , dhpx.donhang_thamchieu as donhang
	            , (select ten_to from md_phanxuong_to where lsx_tsx.md_phanxuong_to_id = md_to_id) as tosx
	            , (select ten_phanxuong from md_phanxuong where lsx_tsx.md_phanxuong_id = md_phanxuong_id) as px
	            , lsx_tsx.mota as diengiai
	            , sp.ma_sanpham as ma_vthh
	            , sp.mota_tiengviet as ten_vthh
	            , dvtsp.ten_dvt as dvt
	            , lsx_tsx_cdh.{1} as soluong
				, lsx_tsx_cdh.sl_nhapkho as slton
                , (case when lsx_tsx.stt != 9999 
                    then
                        (case when isnull(lsx_tsx_cdh.sl_dahoanthanh, 0) > lsx_tsx_cdh.sl_chiato
                            then lsx_tsx_cdh.sl_chiato
                            else isnull(lsx_tsx_cdh.sl_dahoanthanh, 0)
                        end) 
                            - 
                        (case when isnull(lsx_tsx_cdh.sl_dagiao, 0) > lsx_tsx_cdh.sl_chiato
                            then lsx_tsx_cdh.sl_chiato
                            else isnull(lsx_tsx_cdh.sl_dagiao, 0)
                        end) 
                    else 
                        (case when isnull(lsx_tsx_cdh.sl_dahoanthanh, 0) - isnull(lsx_tsx_cdh.sl_nhapkho, 0) > lsx_tsx_cdh.sl_chiato
                            then lsx_tsx_cdh.sl_chiato + isnull(lsx_tsx_cdh.sl_nhapkho, 0)
                            else isnull(lsx_tsx_cdh.sl_dahoanthanh, 0)
                        end) 
                            - 
                        (case when isnull(lsx_tsx_cdh.sl_dagiao, 0) - isnull(lsx_tsx_cdh.sl_nhapkho, 0) > lsx_tsx_cdh.sl_chiato
                            then lsx_tsx_cdh.sl_chiato + isnull(lsx_tsx_cdh.sl_nhapkho, 0)
                            else isnull(lsx_tsx_cdh.sl_dagiao, 0)
                        end)
                end) as sltonCancel
	            , lsx_tsx.ngaybatdausx as ngaysanxuat
	            , lsx_tsx.ngaydkht as ngayhoanthanh
	            , lsx_tsx_cdh.mota as ghichu
	            , dhpx.hdlh as huongdanlamhang
            from md_lenhsanxuat lsx
	            left join md_dondathangphanxuong dhpx on lsx.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
                left join md_lenhsanxuat_tosx lsx_tsx on lsx_tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
                left join md_lenhsanxuat_tosx_cdh lsx_tsx_cdh on lsx_tsx_cdh.md_lenhsanxuat_tosx_id = lsx_tsx.md_lenhsanxuat_tosx_id
                left join md_sanpham sp on lsx_tsx_cdh.md_sanpham_id = sp.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
            where 1=1
                and lsx_tsx.md_lenhsanxuat_tosx_id in ('{0}')
                and lsx_tsx_cdh.{1} > 0
            order by sp.ma_sanpham asc
		"
        , md_nhapkho_ncc_id
        , slchiato
        );
        return sql;
    }
}