using System;
using System.Data;
using DataAcess;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.UI;

public partial class PrintControllers_MD_00_DSDHJQGS_Default : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        string c_danhsachdathang_id = context.Request.QueryString["id"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KH] Đơn đặt hàng từ ANCO.repx");
        var report = XtraReport.FromFile(file, true);
        string sql = CreateSql(c_danhsachdathang_id);
        viewReport(report, sql, c_danhsachdathang_id);
    }

    public void viewReport(XtraReport report, string SqlQuery, string c_danhsachdathang_id)
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
            var db = new EntityContext();
            var varCong = db.c_phidathang.Where(tg => tg.c_danhsachdathang_id == c_danhsachdathang_id && tg.isphicong == true);
            var varTru = db.c_phidathang.Where(gi => gi.c_danhsachdathang_id == c_danhsachdathang_id && gi.isphicong == false);
            var diengiaiCong = string.Join(", ", varCong.Select(s => s.mota).ToList());
            var diengiaiTru = string.Join(", ", varTru.Select(s => s.mota).ToList());
            var sumCong = varCong.Sum(s => s.sotien).GetValueOrDefault(0);
            var sumTru = varTru.Sum(s => s.sotien).GetValueOrDefault(0);

            var sumTT = double.Parse(tbl.Compute("Sum(thanhtien)", string.Empty).ToString());
            var discount = double.Parse(tbl.Rows[0]["discountdecimal"].ToString());
            var sumTTcoDis = sumTT * discount / 100;
            var sumTTcoDiscoPhi = sumTT - sumTTcoDis + (double)sumCong - (double)sumTru;
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
            tbl.Columns.Add("tongcong", Type.GetType("System.Double"));
            tbl.Rows[lastRow]["tongcong"] = sumTT;
            tbl.Columns.Add("discount", Type.GetType("System.Double"));
            tbl.Rows[lastRow]["discount"] = sumTTcoDis;
            tbl.Columns.Add("diengiaitang", Type.GetType("System.String"));
            tbl.Rows[lastRow]["diengiaitang"] = diengiaiCong + " ( + )";
            tbl.Columns.Add("diengiaigiam", Type.GetType("System.String"));
            tbl.Rows[lastRow]["diengiaigiam"] = diengiaiTru + " ( - )";
            tbl.Columns.Add("giatritang", Type.GetType("System.Double"));
            tbl.Rows[lastRow]["giatritang"] = sumCong;
            tbl.Columns.Add("giatrigiam", Type.GetType("System.Double"));
            tbl.Rows[lastRow]["giatrigiam"] = sumTru;
            tbl.Columns.Add("tongtiendatru", Type.GetType("System.Double"));
            tbl.Rows[lastRow]["tongtiendatru"] = sumTTcoDiscoPhi;
            tbl.Columns.Add("money", Type.GetType("System.String"));
            tbl.Rows[lastRow]["money"] = VNN_ConvertMoney.convert(sumTTcoDiscoPhi, "VND").FirstOrDefault().Key;
            ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public string CreateSql(string c_danhsachdathang_id)
    {
        string select = String.Format(@"
            select 
	            dsdh.sochungtu
                , dsdh.so_po
                , dsdh.ngaylap
                , dsdh.hangiaohang_po
                , dtkd.ten_dtkd
                , dtkd.tel
                , dtkd.fax
	            , sp.ma_sanpham
				, (case when  SUBSTRING(sp.ma_sanpham,10,1) != 'F' then SUBSTRING(sp.ma_sanpham,0,9) + '.jpg' else SUBSTRING(sp.ma_sanpham,0,12) + '.jpg' end) as pic
				, ddsdh.ma_sanpham_khach
                , ddsdh.mota_tiengviet
                , dvt.ma_edi
                , ddsdh.sl_dathang
                , ddsdh.gianhap
                , (ddsdh.sl_dathang * ddsdh.gianhap) as thanhtien
                , dsdh.huongdanlamhang as hdlh
                , dsdh.huongdanlamhangchung as hdlhchung
                , ddsdh.huongdan_dathang
	            , dsdh.diachigiaohang
                , 0 as sl_cont
                , '' as loai_cont
                , isnull(dsdh.discount, 0) as discountdecimal
                , (cast(ddsdh.sl_inner as nvarchar) + ' ' + ddsdh.dvt_inner) as dginner
                , (cast(ddsdh.sl_outer as nvarchar) + ' ' + ddsdh.dvt_outer) as dgouter
                , (select hoten from ad_user where ad_user_id = dsdh.nguoitao) as nguoitao
				, sp.mota as ghichu
                , sp.trongluong
                , (case when dsdh.anco_check = 1 then ddsdh.v2 else ddsdh.v2 * ddsdh.sl_dathang end) as v2
            from 
	            c_danhsachdathang dsdh
                , md_doitackinhdoanh dtkd
                , md_sanpham sp
	            , c_dongdsdh ddsdh
                , md_donvitinhsanpham dvt
            where 1=1
	            and dtkd.ma_dtkd = 'ANCO2'
	            AND dsdh.c_danhsachdathang_id = ddsdh.c_danhsachdathang_id
	            AND ddsdh.md_sanpham_id = sp.md_sanpham_id
	            AND sp.md_donvitinhsanpham_id = dvt.md_donvitinhsanpham_id
                AND dsdh.c_danhsachdathang_id = N'{0}' order by sp.ma_sanpham asc"
            , c_danhsachdathang_id == null ? "" : c_danhsachdathang_id);
        return select;
    }
}