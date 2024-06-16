using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;
using System.Linq;
public partial class PrintControllers_MD_00_LenhSanXuatKH_lenhSanXuat : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] LỆNH SẢN XUẤT.repx";
        string nameRpt = "LỆNH SẢN XUẤT {ngaylap}";
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
        var btp = ((bool?)tbl.Rows[0]["ban_thanhpham"]).GetValueOrDefault(false);
        
        if(tbl.Rows.Count > 0)
            tbl.Rows[0]["loaiCT"] = btp ? Helper.arrLoaiCT_LSX[0] : Helper.arrLoaiCT_LSX[1];
    }

    public String CreateSql(HttpContext context)
    {
        string id = context.Request.QueryString["id"];
        string sql = $@"
		    declare @id nvarchar(32)= '{id}'
            select
                N'' as loaiCT,
	            lsx.sochungtu,
                pb.ten_phongban as xuongSX,
	            kho.ten_kho as khonhap,
	            format(lsx.ngaytao, 'dd/MM/yyyy') as ngaylap,
	            format(lsx.ngayhoanthanh, 'dd/MM/yyyy') as ngayhoanthanh,
	            sp.ma_sanpham as maVTHH,
                sp.mota_tiengviet as tenVTHH,
                sp.ban_thanhpham,
                dvt.ten_dvt as dvt,
	            sum(cdh.sl_dat) as sx,
                sum(isnull(cdh.sl_danhapkho, 0)) as dg,
	            sum(cdh.sl_dat - isnull(cdh.sl_danhapkho, 0)) as cl,
	            lsx.donhang as dh_gc,
                lsx.mota
            from md_lenhsanxuat2 lsx
                left join md_lenhsanxuat_tosx_cdh cdh on cdh.lsxCT = lsx.sochungtu
                left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
                left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
	            left join ad_department pb on pb.md_phongban_id = lsx.xuongPhu
	            left join md_kho kho on kho.md_kho_id = pb.md_kho_id
            where
                1=1
                and lsx.md_lenhsanxuat2_id = @id
            group by
	            lsx.sochungtu,
				pb.ten_phongban,
	            kho.ten_kho,
	            lsx.ngaytao,
	            lsx.ngayhoanthanh,
	            sp.ma_sanpham,
                sp.ban_thanhpham,
                sp.mota_tiengviet,
                dvt.ten_dvt,
	            lsx.donhang,
                lsx.mota
            order by
	            sp.ma_sanpham
		";
        return sql;
    }
}