using System;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PrintControllers_MD_00_Xuatnoibo_LenhXuatKho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string file = Server.MapPath(Security.UrlBase() + "/ReportsStorage/[KT] Lệnh Xuất Kho.repx");
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
            var soluong = report.Report.FindControl("soluong", true);
            soluong.DataBindings[0].FormatString = sothapphan;
            var ghino = report.Report.FindControl("ghino", true);
            ghino.DataBindings[0].FormatString = sothapphan;
            var truno = report.Report.FindControl("truno", true);
            truno.DataBindings[0].FormatString = sothapphan;
            var tongcong = report.Report.FindControl("tongcong", true);
            tongcong.DataBindings[0].FormatString = sothapphan;
            var thucxuat = report.Report.FindControl("thucxuat", true);
            thucxuat.DataBindings[0].FormatString = sothapphan;

            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_tongcong", Type.GetType("System.Double"));
            tbl.Columns.Add("logo", Type.GetType("System.String"));
            tbl.Columns.Add("dd", Type.GetType("System.String"));
            tbl.Columns.Add("MM", Type.GetType("System.String"));
            tbl.Columns.Add("yyyy", Type.GetType("System.String"));
            //Header
            tbl.Rows[0]["logo"] = infoPrint.logo;
            var ngaydenghi = tbl.Rows[0]["ngaydenghi"] as DateTime?;
            tbl.Rows[0]["dd"] = ngaydenghi.Value.ToString("dd");
            tbl.Rows[0]["MM"] = ngaydenghi.Value.ToString("MM");
            tbl.Rows[0]["yyyy"] = ngaydenghi.Value.ToString("yyyy");
            report.DisplayName = tbl.Rows[0]["sct_lsx"] + "-RP001";
            //Footer
            int lastRow = tbl.Rows.Count - 1;
            tbl.Rows[lastRow]["sum_soluong"] = double.Parse(tbl.Compute("Sum(soluong)", string.Empty).ToString());
            tbl.Rows[lastRow]["sum_tongcong"] = double.Parse(tbl.Compute("Sum(tongcong)", string.Empty).ToString());
            var sum_soluong = report.Report.FindControl("sum_soluong", true);
            sum_soluong.DataBindings[0].FormatString = sothapphan;
            var sum_tongcong = report.Report.FindControl("sum_tongcong", true);
            sum_tongcong.DataBindings[0].FormatString = sothapphan;

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
        string md_xuatkhonb_id = context.Request.QueryString["id"];
        string bplvt = context.Request.QueryString["bplvt"];
        string oper = context.Request.QueryString["oper"];
        string sql = string.Format(@"
            declare @xuatcho nvarchar(MAX), @px nvarchar(MAX);
            select top 1 @xuatcho = ten_to, @px = md_phanxuong_id from md_phanxuong_to where md_to_id = '{1}';
            if(@xuatcho is null)
            begin
                set @xuatcho = (select top 1 ten_phongban from ad_department where md_phongban_id = '{1}');
            end
            else
            begin
                set @px = (select top 1 ten_phanxuong from md_phanxuong where md_phanxuong_id = @px);
            end
            
		    select 
                sp.ma_sanpham as ma_vthh
                , sp.mota_tiengviet as ten_vthh
                , sp.quycachdonggoi as quycach
		        , dvtsp.ten_dvt as dvt
                , xb.sochungtu as sct_lsx 
                , xb.ngaydenghi
                , @xuatcho as xuatcho
                , @px as bophan
                , kho.ten_kho as khoxuat
                , xb.mota as diengiai
                , sum(nknb_cdh.tong_sl_xuat) as soluong
                , sum(isnull(nknb_cdh.ghino, 0)) as ghino
                , sum(isnull(nknb_cdh.truno, 0)) as truno
                , null as thucxuat
                , sum(nknb_cdh.sl_muonxuat) as tongcong
		    from md_xuatkhonb xb
		        left join md_xuatkhonb_cdh nknb_cdh on xb.md_xuatkhonb_id = nknb_cdh.md_xuatkhonb_id
                left join md_sanpham sp on nknb_cdh.md_sanpham_id = sp.md_sanpham_id
                left join md_donvitinhsanpham dvtsp on nknb_cdh.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
                left join md_kho kho on xb.tukho = kho.md_kho_id
		    where 
                nknb_cdh.md_xuatkhonb_id = '{0}'
                and nknb_cdh.sl_muonxuat > 0
                and nknb_cdh.md_kho_id = '{1}'
            group by 
                sp.ma_sanpham
                , sp.mota_tiengviet
                , sp.quycachdonggoi
		        , dvtsp.ten_dvt
                , xb.sochungtu 
                , xb.ngaydenghi
                , kho.ten_kho
                , xb.mota
            order by sp.ma_sanpham asc
		"
        , md_xuatkhonb_id
        , bplvt
        );
        //
        return sql;
    }
}




