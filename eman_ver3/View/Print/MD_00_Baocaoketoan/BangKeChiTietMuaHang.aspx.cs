using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_Baocaoketoan_BangKeChiTietMuaHang : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] Bảng Kê Chi Tiết Mua Hàng.repx";
        string nameRpt = "Bảng Kê Chi Tiết Mua Hàng {tungay} - {denngay}";
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
        tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_thuegtgt", Type.GetType("System.Double"));
        tbl.Columns.Add("sum_tongthanhtoan", Type.GetType("System.Double"));
        tbl.Columns.Add("sumGroup_soluong", Type.GetType("System.Double"));
        tbl.Columns.Add("sumGroup_thanhtien", Type.GetType("System.Double"));
        tbl.Columns.Add("sumGroup_thuegtgt", Type.GetType("System.Double"));
        tbl.Columns.Add("sumGroup_tongthanhtoan", Type.GetType("System.Double"));
        //Footer
        int lastRow = tbl.Rows.Count - 1;
            
        var sum_soluong = tbl.Compute("Sum(soluong)", string.Empty).ToString();
        var sum_thanhtien = tbl.Compute("Sum(thanhtien)", string.Empty).ToString();
        var sum_thuegtgt = tbl.Compute("Sum(thuegtgt)", string.Empty).ToString();
        var sum_tongthanhtoan = tbl.Compute("Sum(tongthanhtoan)", string.Empty).ToString();

        var soluong_cell = ReportViewer1.Report.Report.FindControl("soluong", true);
        soluong_cell.DataBindings[0].FormatString = sothapphan;
        var sumGroup_soluong_cell = ReportViewer1.Report.Report.FindControl("sumGroup_soluong", true);
        sumGroup_soluong_cell.DataBindings[0].FormatString = sothapphan;
        var sum_soluong_cell = ReportViewer1.Report.Report.FindControl("sum_soluong", true);
        sum_soluong_cell.DataBindings[0].FormatString = sothapphan;
        //Group 1
        string group_sochungtu = "";
        for(int i = 0; i < tbl.Rows.Count; i++)
        {
            DataRow row = tbl.Rows[i];
            //Header

            //Footer
            if (string.IsNullOrEmpty(sum_soluong))
                row["sum_soluong"] = DBNull.Value;
            else
                row["sum_soluong"] = double.Parse(sum_soluong);

            if (string.IsNullOrEmpty(sum_thanhtien))
                row["sum_thanhtien"] = DBNull.Value;
            else
                row["sum_thanhtien"] = double.Parse(sum_thanhtien);

            if (string.IsNullOrEmpty(sum_thuegtgt))
                row["sum_thuegtgt"] = DBNull.Value;
            else
                row["sum_thuegtgt"] = double.Parse(sum_thuegtgt);

            if (string.IsNullOrEmpty(sum_tongthanhtoan))
                row["sum_tongthanhtoan"] = DBNull.Value;
            else
                row["sum_tongthanhtoan"] = double.Parse(sum_tongthanhtoan);

            string sochungtu = row["sochungtu"].ToString();
            if(group_sochungtu != sochungtu)
            {
                string value = tbl.Compute("Sum(soluong)", string.Format("[sochungtu] = '{0}'", sochungtu)).ToString();
                if (string.IsNullOrEmpty(value))
                    row["sumGroup_soluong"] = DBNull.Value;
                else
                    row["sumGroup_soluong"] = decimal.Parse(value);

                value = tbl.Compute("Sum(thanhtien)", string.Format("[sochungtu] = '{0}'", sochungtu)).ToString();
                if (string.IsNullOrEmpty(value))
                    row["sumGroup_thanhtien"] = DBNull.Value;
                else
                    row["sumGroup_thanhtien"] = decimal.Parse(value);

                value = tbl.Compute("Sum(thuegtgt)", string.Format("[sochungtu] = '{0}'", sochungtu)).ToString();
                if (string.IsNullOrEmpty(value))
                    row["sumGroup_thuegtgt"] = DBNull.Value;
                else
                    row["sumGroup_thuegtgt"] = decimal.Parse(value);

                value = tbl.Compute("Sum(tongthanhtoan)", string.Format("[sochungtu] = '{0}'", sochungtu)).ToString();
                if (string.IsNullOrEmpty(value))
                    row["sumGroup_tongthanhtoan"] = DBNull.Value;
                else
                    row["sumGroup_tongthanhtoan"] = decimal.Parse(value);
                group_sochungtu = sochungtu;
            }
        }
    }

    public string CreateSql(HttpContext context)
    {
        string tungay = context.Request.QueryString["tu"];
		string denngay = context.Request.QueryString["den"];
		DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
		DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
		string kho = context.Request.QueryString["kho"];
	    string dtkd = context.Request.QueryString["dtkd"];

        if (!string.IsNullOrEmpty(dtkd))
            dtkd = string.Format("and dtkd.ma_dtkd = N'{0}'", dtkd);

        string sql = string.Format(@"	 
            declare @tungay datetime = convert(datetime,N'{0} 00:00',103);
            declare @denngay datetime = convert(datetime,N'{1} 23:59',103);
            select distinct
                ncc.sochungtu
	            , ncc.ngaychuyen as ngay
	            , (select sochungtu from c_donmuahang where c_donmuahang_id = ncc.c_donmuahang_id) as donhangmua
	            , dtkd.ten_dtkd as nhacungcap
	            , sp.ma_sanpham as ma_vthh
                , sp.mota_tiengviet as ten_vthh
	            , dh.sl_nhap2 as soluong
	            , dh.giatriVND as dongia
	            , (dh.giatriVND * dh.sl_nhap2) as thanhtien
	            , (dh.giatriVND * dh.sl_nhap2 * isnull(thue.giatri, 0) / 100) as thuegtgt
	            , (dh.giatriVND * dh.sl_nhap2 + dh.giatriVND * dh.sl_nhap2 * isnull(thue.giatri, 0) / 100) as tongthanhtoan
	            , dvtsp.ten_dvt as dvt
                , N'{0}' as tungay
                , N'{1}' as denngay
            FROM md_nhapkho_ncc ncc
                left join md_nhapkho_ncc_dh dh on ncc.md_nhapkho_ncc_id = dh.md_nhapkho_ncc_id
                left join md_sanpham sp on dh.md_sanpham_id = sp.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on dh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
                left join md_doitackinhdoanh dtkd on ncc.md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id
                left join md_thue_sanpham thue on dh.thue = thue.md_thue_sanpham_id
            WHERE ncc.trangthai != N'SOANTHAO'
	            AND ncc.ngaychuyen >= @tungay
	            AND ncc.ngaychuyen <= @denngay
                AND dh.sl_nhap2 > 0
                {2}
            ORDER BY ncc.sochungtu asc, sp.ma_sanpham asc
		"
        , tu.ToString("dd/MM/yyyy")
        , den.ToString("dd/MM/yyyy")
        , dtkd
        );
		return sql;
    }
}

