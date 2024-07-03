using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaoketoan_BangKeXuatKho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] BẢNG KÊ XUẤT KHO.repx";
        string nameRpt = "BẢNG KÊ XUẤT KHO {ngayin}";
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
        if (tbl.Rows.Count > 0)
        {
            var khos = tbl.AsEnumerable().Select(s => s.Field<string>("kho")).Distinct().ToList();
            if (khos.Count > 1)
            {
                tbl.Rows[0]["kho"] = "";
            }
        }
    }

    public String CreateSql(HttpContext context)
    {
        string tu = context.Request.QueryString["tu"].removeAllSpaceOrTrimText(true).Replace("-", "/");
        string den = context.Request.QueryString["den"].removeAllSpaceOrTrimText(true).Replace("-", "/");
        string kho = context.Request.QueryString["kho"].removeAllSpaceOrTrimText(true).Replace("'", "''");
        if (!string.IsNullOrWhiteSpace(kho))
            kho = $@"and kh.md_kho_id = N'{kho}'";

        var fmtDate = "dd/MM/yyyy";
        string sql = $@"
		    declare @tu datetime = convert(datetime, N'{tu} 00:00:00', 103)
            declare @den datetime = convert(datetime, N'{den} 23:59:59', 103)

            select
	            format(getdate(), '{fmtDate}') as ngayin,
	            format(@tu, '{fmtDate}') as tungay,
	            format(@den, '{fmtDate}') as denngay,
	            kgd.dongnhapxuat as sct,
	            format(kgd.ngaychuyen, '{fmtDate}') as nxk,
                kh.ten_kho as kho,
                pb.ten_phongban as bophan,
	            sp.ma_sanpham as maVTHH,
	            sp.mota_tiengviet as tenVTHH,
	            dvtsp.ten_dvt as dvt,
	            kgd.soluong_dichchuyen as soluong
            from md_kho_giaodich kgd
                left join md_kho kh on kh.md_kho_id = kgd.md_kho_id
	            left join md_sanpham sp on sp.md_sanpham_id = kgd.md_sanpham_id
	            left join md_donvitinhsanpham dvtsp on dvtsp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
                left join md_xuatnoibo xnb on xnb.sochungtu = kgd.dongnhapxuat
                left join ad_department pb on pb.md_phongban_id = xnb.xuatden
                left join ad_department pbCha on pbCha.md_phongban_id = pb.phongbanChaId
            where
	            1=1
                and kgd.kieuchuyen = N'{Helper.XuatKho}'
	            and kgd.ngaychuyen between @tu and @den
                and kgd.soluong_dichchuyen > 0
                and kgd.dongnhapxuat not like 'PVC%'
                {kho}
            order by
	            kgd.ngaychuyen, sp.ma_sanpham
		";

        return sql;
    }
}

