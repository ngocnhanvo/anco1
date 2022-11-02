using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.Linq;
public partial class PrintControllers_MD_00_LenhSanXuat_PhieuDeNghiNhanPhoiSoi : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[SX] Phiếu Đề Nghị Nhận Phôi Sợi.repx";
        string nameRpt = "Phiếu Đề Nghị Nhận Phôi Sợi {donhang}";
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
        tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
        //Header

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        var sum_soluong = tbl.Compute("Sum(soluong)", string.Empty).ToString();
        if (string.IsNullOrEmpty(sum_soluong))
            tbl.Rows[lastRow]["sum_soluong"] = DBNull.Value;
        else
            tbl.Rows[lastRow]["sum_soluong"] = double.Parse(sum_soluong);

        var sum_soluong_cell = ReportViewer1.Report.Report.FindControl("sum_soluong", true);
        sum_soluong_cell.DataBindings[0].FormatString = sothapphan;
        var soluong_cell = ReportViewer1.Report.Report.FindControl("soluong", true);
        soluong_cell.DataBindings[0].FormatString = sothapphan;
    }

    public String CreateSql(HttpContext context)
    {
        var db = new EntityContext();
        var us = VNN_Function.get_user(
            Security.id_taikhoan(context),
            Security.id_vaitro(context),
            Security.id_phongban(context));
        string id = context.Request.QueryString["id"];
        string md_lenhsanxuat_id = db.md_lenhsanxuat_tosx.Where(s => s.md_lenhsanxuat_tosx_id == id).Select(s=>s.md_lenhsanxuat_id).FirstOrDefault();

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