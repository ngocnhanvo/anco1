using System;
using System.Linq;
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
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Phiếu Đề Nghị Sửa và Giao Nhận Hàng Tồn.repx");
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

            tbl.Columns.Add("sum_sl_denghigiao", Type.GetType("System.Double"));
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
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            var sum_sl_denghigiao = tbl.Compute("Sum(sl_denghigiao)", string.Empty).ToString();
            if (string.IsNullOrEmpty(sum_sl_denghigiao))
                tbl.Rows[lastRow]["sum_sl_denghigiao"] = DBNull.Value;
            else
                tbl.Rows[lastRow]["sum_sl_denghigiao"] = double.Parse(sum_sl_denghigiao);

            var sl_denghigiao_cell = report.Report.FindControl("sl_denghigiao", true);
            sl_denghigiao_cell.DataBindings[0].FormatString = sothapphan;
            var sum_sl_denghigiao_cell = report.Report.FindControl("sum_sl_denghigiao", true);
            sum_sl_denghigiao_cell.DataBindings[0].FormatString = sothapphan;
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

        string slchiato = "sl_chiato";
        if(us.ma_phongban == "PKH")
        {
            slchiato = "sl_chiato2";
        }
        string md_lenhsanxuat_id = context.Request.QueryString["id"];
        string oper = context.Request.QueryString["oper"];
        string sql = string.Format(@"
		    select 
                A.*
                , substring(A.cdcht, 0, len(A.cdcht) - 1) as congdoancanhoanthien
            from
            (
                select 
		            lsx.sochungtu
		            , lsx.ngayketthuc as ngayyeucauhoanthanh
		            , sp.ma_sanpham as ma_vthh
		            , dvtsp.ten_dvt as dvt
		            , lht.sl_layton as sl_denghigiao
		            , dhpx.donhang_thamchieu as theodonhang
		            , lht.mota as ghichu
		            , pxto.ten_to as tosx
		            , (
			            SELECT isnull(T.congdoan + ' + ','')
			            FROM md_phanxuong_to T
			            WHERE 
			            1 = 1
			            and T.md_phanxuong_id = lsx_tsx.md_phanxuong_id
			            and cast(T.sapxep as int) > cast(pxto.sapxep as int)
			            order by T.sapxep
			            FOR XML PATH(''), type
		            ).value('.','nvarchar(max)') as cdcht
		            , (select ten_phanxuong from md_phanxuong where lsx_tsx.md_phanxuong_id = md_phanxuong_id) as bophanyc
	            from md_lenhsanxuat lsx
		            left join md_dondathangphanxuong dhpx on lsx.md_dondathangphanxuong_id = dhpx.md_dondathangphanxuong_id
		            left join md_lenhsanxuat_tosx lsx_tsx on lsx_tsx.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
		            left join md_lenhsanxuat_tosx_dklht lht on lht.md_lenhsanxuat_tosx_id = lsx_tsx.md_lenhsanxuat_tosx_id
		            left join md_sanpham sp on lht.md_sanpham_id = sp.md_sanpham_id
		            left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
		            left join md_phanxuong_to pxto on pxto.md_to_id = lsx_tsx.md_phanxuong_to_id
	            where 1=1
		            and lsx_tsx.md_lenhsanxuat_id in ('{0}')
		            and lht.sl_layton > 0
            )A
            order by A.ma_vthh asc
		"
        , md_lenhsanxuat_id
        , slchiato
        );
        return sql;
    }
}