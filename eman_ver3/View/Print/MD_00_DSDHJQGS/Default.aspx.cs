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
    public string logo = "", sothapphan = "", inPDF = "";
    public string c_danhsachdathang_id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KH] Đơn đặt hàng từ ANCO.repx";
        string nameRpt = "Đơn đặt hàng từ ANCO";
        string sql = CreateSql(context);

        var task = new System.Threading.Tasks.Task(() =>
        {
            viewReport(sql);
        });

        PrintAnco2.exportDataWithType(task, sql, inPDF, nameTemp, nameRpt, ReportViewer1, true);
    }

    public void viewReport(string SqlQuery)
    {
        var tbl = ((DataSet)ReportViewer1.Report.DataSource).Tables[0];
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
        //Header

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
    }

    public string CreateSql(HttpContext context)
    {
        c_danhsachdathang_id = context.Request.QueryString["id"];
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
                left join md_doitackinhdoanh dtkd on dtkd.ma_dtkd = 'BP-XUONG AN CO 2'
	            left join c_dongdsdh ddsdh on dsdh.c_danhsachdathang_id = ddsdh.c_danhsachdathang_id
                left join md_sanpham sp on ddsdh.md_sanpham_id = sp.md_sanpham_id
                left join md_donvitinhsanpham dvt on sp.md_donvitinhsanpham_id = dvt.md_donvitinhsanpham_id
            where 1=1
                AND dsdh.c_danhsachdathang_id = N'{0}' order by sp.ma_sanpham asc"
            , c_danhsachdathang_id == null ? "" : c_danhsachdathang_id);
        return select;
    }
}