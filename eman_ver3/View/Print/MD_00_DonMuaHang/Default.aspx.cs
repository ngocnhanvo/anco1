using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_DonMuaHang_Default : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[VT] Đơn mua hàng hóa vật tư.repx";
        string nameRpt = "Đơn mua hàng hóa vật tư {ngaylap}";
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
        //Header
        tbl.Columns.Add("vat1", Type.GetType("System.String"));
        tbl.Columns.Add("vat2", Type.GetType("System.Double"));
        tbl.Columns.Add("tongtien", Type.GetType("System.Double"));

        //Footer
        int lastRow = tbl.Rows.Count - 1;
        decimal sum_soluong = decimal.Parse(tbl.Compute("Sum(sl)", string.Empty).ToString());
        decimal sum_thanhtien = decimal.Parse(tbl.Compute("Sum(thanhtien)", string.Empty).ToString());
        var thues = tbl.AsEnumerable().Select(s => new { lt = s.Field<decimal>("loaiThue"), tt = s.Field<decimal>("thanhtien") }).ToList();
        var thuesStr = string.Join(",", thues.Select(s=>s.lt).Distinct().OrderBy(s => s));
        var thueGT = Math.Ceiling(thues.Select(s => s.tt * s.lt / 100).Sum());
        var tongtien = Math.Ceiling(sum_thanhtien + thueGT);
        foreach (DataRow row in tbl.Rows)
        {
            row["vat1"] = thuesStr;
            row["vat2"] = thueGT;
            row["tongtien"] = tongtien;
            row["loaiCT"] = Helper.arrLoaiCT_DMH[(int)row["loai"]];
        }
        
        //var arr = VNN_ConvertMoney.convert(sum_tongcong, "VND").FirstOrDefault();
    }

    public String CreateSql(HttpContext context)
    {
        string c_donmuahang_id = context.Request.QueryString["id"];
        string sql = $@"
            declare @httt nvarchar(MAX) = (select top 1 ten from md_hinhthucthanhtoan order by sapxep asc)
		    select 
                dmh.so_donmuahang as sochungtu
                , N'' as loaiCT
                , FORMAT(dmh.ngaydonhang, 'dd/MM/yyyy') as ngaylap
                , FORMAT(dmh.ngaygiaohang, 'dd/MM/yyyy') as ngaygiaohang
                , dmh.ngaythanhtoan
                , dmh.diadiem_giaohang as noigiaohang
		        , dtkd.ten_dtkd as tenNCC
                , dtkd.diachi
		        , sp.ma_sanpham as maVTHH
                , sp.mota_tiengviet as tenVTHH
                , sp.quycachdonggoi as quycach
                , dvt.ten_dvt as dvt
		        , cdmh.sl_dadat as sl
                , cdmh.dongiamua as dongia
                , CEILING(cdmh.thanhtien) as thanhtien
                , thue.giatri as loaiThue
                , isnull(dmh.hinhthucthanhtoan, @httt) as hinhthucthanhtoan
                , dktt.ten_dieukien as dktt
                , isnull(dmh.mota,'') as ghichu
                , (
                    case 
                        when isnull(sp.sanpham, 0) = 1 and isnull(sp.ban_thanhpham, 0) = 0
                        then 2
                        when isnull(sp.sanpham, 0) = 0 and isnull(sp.ban_thanhpham, 0) = 1
                        then 1
                        else 0
                    end
                ) loai
		    from c_donmuahang dmh
		        left join c_donmuahang_cdmh cdmh on cdmh.c_donmuahang_id = dmh.c_donmuahang_id
		        left join md_sanpham sp on sp.md_sanpham_id = cdmh.md_sanpham_id
		        left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
		        left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
		        left join md_dongtien dt on dt.md_dongtien_id = dmh.md_dongtien_id
		        left join md_thue_sanpham thue on cdmh.thue = thue.md_thue_sanpham_id
                left join md_dieukienthanhtoan dktt on dktt.md_dieukienthanhtoan_id = dmh.md_dieukienthanhtoan_id
		    where dmh.c_donmuahang_id = '{c_donmuahang_id}'
		    order by sp.ma_sanpham asc
        ";

		return sql;
    }
}

