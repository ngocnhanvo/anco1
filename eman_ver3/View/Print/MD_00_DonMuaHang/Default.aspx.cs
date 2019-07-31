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
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        donDatMuaVatTu report = new donDatMuaVatTu(sothapphan);
        String sql = this.CreateSql(context);
        this.viewReport(report, sql);
		//Response.Write(sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
    {
        SqlDataAdapter da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        DataSet ds = new DataSet();
        da.Fill(ds);

        var tbl = ds.Tables[0];
        if (tbl.Rows.Count > 0)
        {
            double sum_soluong = double.Parse(tbl.Compute("Sum(soluong)", string.Empty).ToString());
            double sum_thanhtien = double.Parse(tbl.Compute("Sum(thanhtien)", string.Empty).ToString());
            double sum_thue10 = sum_thanhtien * 10 / 100;
            double sum_tongcong = sum_thanhtien + sum_thue10;
            var arr = VNN_ConvertMoney.convert(sum_tongcong, "VND").FirstOrDefault();
            tbl.Columns.Add("sum_soluong", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thanhtien", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_thue10", Type.GetType("System.Double"));
            tbl.Columns.Add("sum_tongcong", Type.GetType("System.Double"));
            tbl.Columns.Add("bangchu", Type.GetType("System.String"));
            foreach(DataRow row in tbl.Rows)
            {
                row["sum_soluong"] = sum_soluong;
                row["sum_thanhtien"] = sum_thanhtien;
                row["sum_thue10"] = sum_thue10;
                row["sum_tongcong"] = arr.Value;
                row["bangchu"] = arr.Key;
            }
            
            report.DataSource = ds;
            report.DataAdapter = da;
            ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<h1>Không có dữ liệu</h1>");
        }
    }

    public String CreateSql(HttpContext context)
    {
        var infoPrint = PrintAnco2.GetInfoPrint();
        string c_donmuahang_id = context.Request.QueryString["id"];	
		string sql = string.Format(@"
		select 
            dmh.sochungtu as sct_dmvt
            , dmh.ngaygiaohang as thoihan_giaohang
		    , dtkd.ten_dtkd as ncc
            , dtkd.tel as sdt
            , dtkd.fax as fax
		    , sp.ma_sanpham as ma_vthh
            , sp.mota_tiengviet as ten_vthh
            , sp.quycachdonggoi as quycach
            , dvt.ten_dvt as dvt
		    , cdmh.sl_dadat as soluong
            , cdmh.dongiamua as dongia
            , cdmh.thanhtien as thanhtien
            , N'{1}' as dd
            , N'{2}' as MM
            , N'{3}' as yyyy
            , N'{4}' as logo
		from c_donmuahang dmh
		    left join c_donmuahang_cdmh cdmh on cdmh.c_donmuahang_id = dmh.c_donmuahang_id
		    left join md_sanpham sp on sp.md_sanpham_id = cdmh.md_sanpham_id
		    left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
		    left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
		    left join md_dongtien dt on dt.md_dongtien_id = dmh.md_dongtien_id
		    left join md_thue_sanpham thue on cdmh.thue = thue.md_thue_sanpham_id
		where dmh.c_donmuahang_id = '{0}'
		order by sp.ma_sanpham asc
		", 
        c_donmuahang_id,
        DateTime.Now.ToString("dd"),
        DateTime.Now.ToString("MM"),
        DateTime.Now.ToString("yyyy"),
        infoPrint.logo
        );
		return sql;
    }
}

public class donDatMuaVatTu : DevExpress.XtraReports.UI.XtraReport
{
    public string sothapphan { get; set; }
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell7;
    private XRTableCell ma_vthh;
    private XRTableCell ten_vthh;
    private XRTableCell quycach;
    private XRTableCell dvt;
    private XRTableCell soluong;
    private XRTableCell thanhtien;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel22;
    private XRLabel xrLabel27;
    private XRLabel xrLabel26;
    private XRLabel xrLabel21;
    private XRLabel xrLabel23;
    private XRLabel xrLabel18;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel4;
    private PageHeaderBand PageHeader;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell20;
    private XRTableCell sum_soluong;
    private XRTableCell sum_thucnhap;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell10;
    private XRPictureBox logo;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel9;
    private XRTableCell dongia;
    private XRLabel xrLabel30;
    private XRLabel xrLabel24;
    private XRLabel xrLabel28;
    private XRTableCell sum_thanhtien;
    private XRLabel xrLabel29;
    private XRLabel xrLabel16;
    private XRLabel xrLabel10;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRTableCell xrTableCell1;
    private XRLabel xrLabel37;
    private XRLabel xrLabel36;
    private XRLabel xrLabel35;
    private XRLabel xrLabel31;
    private XRLabel dd;
    private XRLabel xrLabel44;
    private XRLabel xrLabel45;
    private XRLabel MM;
    private XRLabel xrLabel47;
    private XRLabel yyyy;
    private XRLabel sct_dmvt;
    private XRLabel fax;
    private XRLabel xrLabel41;
    private XRLabel ncc;
    private XRTableCell ghichu;
    private XRTableCell xrTableCell3;
    private XRLabel xrLabel42;
    private XRLabel xrLabel46;
    private XRLabel sdt;
    private XRTableCell xrTableCell2;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell14;
    private XRTableCell sum_thue10;
    private XRTableCell xrTableCell16;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell sum_tongcong;
    private XRTableCell xrTableCell25;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell28;
    private XRTableCell bangchu;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell30;
    private XRTableCell thoihan_giaohang;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell31;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public donDatMuaVatTu(string stp)
    {
        this.sothapphan = stp;
        InitializeComponent();
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma_vthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten_vthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.quycach = new DevExpress.XtraReports.UI.XRTableCell();
        this.dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.soluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.dongia = new DevExpress.XtraReports.UI.XRTableCell();
        this.thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_soluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_thucnhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_thue10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_tongcong = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.bangchu = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.thoihan_giaohang = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.sdt = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
        this.ncc = new DevExpress.XtraReports.UI.XRLabel();
        this.fax = new DevExpress.XtraReports.UI.XRLabel();
        this.sct_dmvt = new DevExpress.XtraReports.UI.XRLabel();
        this.dd = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
        this.MM = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
        this.yyyy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.logo = new DevExpress.XtraReports.UI.XRPictureBox();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.HeightF = 25F;
        this.Detail.KeepTogether = true;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(799.0002F, 25F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.ma_vthh,
            this.ten_vthh,
            this.quycach,
            this.dvt,
            this.soluong,
            this.dongia,
            this.thanhtien,
            this.ghichu});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell7.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.StylePriority.UseFont = false;
        this.xrTableCell7.StylePriority.UsePadding = false;
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell7.Summary = xrSummary1;
        this.xrTableCell7.Text = "xrTableCell3";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 0.11122050848553416D;
        // 
        // ma_vthh
        // 
        this.ma_vthh.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.ma_vthh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma_vthh")});
        this.ma_vthh.Font = new System.Drawing.Font("Tahoma", 9F);
        this.ma_vthh.Name = "ma_vthh";
        this.ma_vthh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.ma_vthh.StylePriority.UseBorders = false;
        this.ma_vthh.StylePriority.UseFont = false;
        this.ma_vthh.StylePriority.UsePadding = false;
        this.ma_vthh.Weight = 0.33931738215577212D;
        // 
        // ten_vthh
        // 
        this.ten_vthh.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.ten_vthh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ten_vthh")});
        this.ten_vthh.Font = new System.Drawing.Font("Tahoma", 9F);
        this.ten_vthh.Name = "ten_vthh";
        this.ten_vthh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.ten_vthh.StylePriority.UseBorders = false;
        this.ten_vthh.StylePriority.UseFont = false;
        this.ten_vthh.StylePriority.UsePadding = false;
        this.ten_vthh.StylePriority.UseTextAlignment = false;
        this.ten_vthh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.ten_vthh.Weight = 0.575159008669671D;
        // 
        // quycach
        // 
        this.quycach.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.quycach.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "quycach")});
        this.quycach.Font = new System.Drawing.Font("Tahoma", 9F);
        this.quycach.Name = "quycach";
        this.quycach.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.quycach.StylePriority.UseBorders = false;
        this.quycach.StylePriority.UseFont = false;
        this.quycach.StylePriority.UsePadding = false;
        this.quycach.Weight = 0.41330700155002775D;
        // 
        // dvt
        // 
        this.dvt.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.dvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dvt")});
        this.dvt.Font = new System.Drawing.Font("Tahoma", 9F);
        this.dvt.Name = "dvt";
        this.dvt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.dvt.StylePriority.UseBorders = false;
        this.dvt.StylePriority.UseFont = false;
        this.dvt.StylePriority.UsePadding = false;
        this.dvt.StylePriority.UseTextAlignment = false;
        this.dvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.dvt.Weight = 0.14512807903891034D;
        // 
        // soluong
        // 
        this.soluong.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.soluong.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "soluong", this.sothapphan)});
        this.soluong.Font = new System.Drawing.Font("Tahoma", 9F);
        this.soluong.Multiline = true;
        this.soluong.Name = "soluong";
        this.soluong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.soluong.StylePriority.UseBorders = false;
        this.soluong.StylePriority.UseFont = false;
        this.soluong.StylePriority.UsePadding = false;
        this.soluong.StylePriority.UseTextAlignment = false;
        this.soluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.soluong.Weight = 0.30601271669399449D;
        // 
        // dongia
        // 
        this.dongia.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.dongia.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dongia", "{0:#,#0.####}")});
        this.dongia.Font = new System.Drawing.Font("Tahoma", 9F);
        this.dongia.Multiline = true;
        this.dongia.Name = "dongia";
        this.dongia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.dongia.StylePriority.UseBorders = false;
        this.dongia.StylePriority.UseFont = false;
        this.dongia.StylePriority.UsePadding = false;
        this.dongia.StylePriority.UseTextAlignment = false;
        this.dongia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.dongia.Weight = 0.37701872099271533D;
        // 
        // thanhtien
        // 
        this.thanhtien.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.thanhtien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thanhtien", "{0:#,#0.####}")});
        this.thanhtien.Font = new System.Drawing.Font("Tahoma", 9F);
        this.thanhtien.Multiline = true;
        this.thanhtien.Name = "thanhtien";
        this.thanhtien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.thanhtien.StylePriority.UseBorders = false;
        this.thanhtien.StylePriority.UseFont = false;
        this.thanhtien.StylePriority.UsePadding = false;
        this.thanhtien.StylePriority.UseTextAlignment = false;
        this.thanhtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.thanhtien.Weight = 0.37073505555421643D;
        // 
        // ghichu
        // 
        this.ghichu.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.ghichu.Font = new System.Drawing.Font("Tahoma", 9F);
        this.ghichu.Name = "ghichu";
        this.ghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.ghichu.StylePriority.UseBorders = false;
        this.ghichu.StylePriority.UseFont = false;
        this.ghichu.StylePriority.UsePadding = false;
        this.ghichu.StylePriority.UseTextAlignment = false;
        this.ghichu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.ghichu.Weight = 0.3744822353663948D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 8F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 0F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel37,
            this.xrLabel36,
            this.xrLabel35,
            this.xrLabel30,
            this.xrLabel24,
            this.xrLabel28,
            this.xrTable3,
            this.xrLabel22,
            this.xrLabel27,
            this.xrLabel26,
            this.xrLabel21,
            this.xrLabel23,
            this.xrLabel18,
            this.xrLabel29,
            this.xrLabel31});
        this.ReportFooter.HeightF = 356.6667F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel37
        // 
        this.xrLabel37.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(601.3397F, 282.9169F);
        this.xrLabel37.Name = "xrLabel37";
        this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel37.SizeF = new System.Drawing.SizeF(196.7712F, 23F);
        this.xrLabel37.StylePriority.UseFont = false;
        this.xrLabel37.StylePriority.UseTextAlignment = false;
        this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel36
        // 
        this.xrLabel36.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(390.4998F, 282.9169F);
        this.xrLabel36.Name = "xrLabel36";
        this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel36.SizeF = new System.Drawing.SizeF(168.2776F, 23F);
        this.xrLabel36.StylePriority.UseFont = false;
        this.xrLabel36.StylePriority.UseTextAlignment = false;
        this.xrLabel36.Text = "Lê Trọng Tài";
        this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel35
        // 
        this.xrLabel35.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(179.0354F, 282.9169F);
        this.xrLabel35.Name = "xrLabel35";
        this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel35.SizeF = new System.Drawing.SizeF(179.1666F, 23F);
        this.xrLabel35.StylePriority.UseFont = false;
        this.xrLabel35.StylePriority.UseTextAlignment = false;
        this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel30
        // 
        this.xrLabel30.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(73.1665F, 325.5003F);
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(725.8337F, 23F);
        this.xrLabel30.StylePriority.UseFont = false;
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        this.xrLabel30.Text = ": Người lập phiếu → Thủ kho → TBP vật tư → Giám đốc xưởng";
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel24
        // 
        this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(420.1731F, 187.9793F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "Giám đốc xưởng";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel28
        // 
        this.xrLabel28.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(420.1731F, 210.9793F);
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel28.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        this.xrLabel28.Text = "(Ký, họ tên)";
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3,
            this.xrTableRow1,
            this.xrTableRow5,
            this.xrTableRow6,
            this.xrTableRow7,
            this.xrTableRow8,
            this.xrTableRow9});
        this.xrTable3.SizeF = new System.Drawing.SizeF(799.0002F, 175F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell13,
            this.xrTableCell20,
            this.sum_soluong,
            this.sum_thucnhap,
            this.sum_thanhtien,
            this.xrTableCell3});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell1.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell1.StylePriority.UseBorders = false;
        this.xrTableCell1.StylePriority.UseFont = false;
        this.xrTableCell1.StylePriority.UsePadding = false;
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.11108107044090532D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell2.StylePriority.UseBorders = false;
        this.xrTableCell2.StylePriority.UseFont = false;
        this.xrTableCell2.StylePriority.UsePadding = false;
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.33889371156045289D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell13.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell13.StylePriority.UseBorders = false;
        this.xrTableCell13.StylePriority.UseFont = false;
        this.xrTableCell13.StylePriority.UsePadding = false;
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "Cộng";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell13.Weight = 0.98723047806800324D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell20.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell20.StylePriority.UseBorders = false;
        this.xrTableCell20.StylePriority.UseFont = false;
        this.xrTableCell20.StylePriority.UsePadding = false;
        this.xrTableCell20.StylePriority.UseTextAlignment = false;
        this.xrTableCell20.Text = "X";
        this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell20.Weight = 0.14494643775084509D;
        // 
        // sum_soluong
        // 
        this.sum_soluong.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_soluong.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sum_soluong", this.sothapphan)});
        this.sum_soluong.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_soluong.Name = "sum_soluong";
        this.sum_soluong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_soluong.StylePriority.UseBorders = false;
        this.sum_soluong.StylePriority.UseFont = false;
        this.sum_soluong.StylePriority.UsePadding = false;
        this.sum_soluong.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = this.sothapphan;
        xrSummary2.IgnoreNullValues = true;
        this.sum_soluong.Summary = xrSummary2;
        this.sum_soluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_soluong.Weight = 0.30563058182872871D;
        // 
        // sum_thucnhap
        // 
        this.sum_thucnhap.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_thucnhap.Font = new System.Drawing.Font("Tahoma", 8F);
        this.sum_thucnhap.Name = "sum_thucnhap";
        this.sum_thucnhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_thucnhap.StylePriority.UseBorders = false;
        this.sum_thucnhap.StylePriority.UseFont = false;
        this.sum_thucnhap.StylePriority.UsePadding = false;
        this.sum_thucnhap.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = this.sothapphan;
        xrSummary3.IgnoreNullValues = true;
        this.sum_thucnhap.Summary = xrSummary3;
        this.sum_thucnhap.Text = "X";
        this.sum_thucnhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.sum_thucnhap.Weight = 0.37654777953870378D;
        // 
        // sum_thanhtien
        // 
        this.sum_thanhtien.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_thanhtien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sum_thanhtien", "{0:#,#0.####}")});
        this.sum_thanhtien.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_thanhtien.Name = "sum_thanhtien";
        this.sum_thanhtien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_thanhtien.StylePriority.UseBorders = false;
        this.sum_thanhtien.StylePriority.UseFont = false;
        this.sum_thanhtien.StylePriority.UsePadding = false;
        this.sum_thanhtien.StylePriority.UseTextAlignment = false;
        this.sum_thanhtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_thanhtien.Weight = 0.37027143332642531D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell3.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.StylePriority.UsePadding = false;
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell3.Weight = 0.374014030572944D;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell9,
            this.xrTableCell14,
            this.sum_thue10,
            this.xrTableCell16});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell4.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.StylePriority.UsePadding = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 0.11108107044090532D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.StylePriority.UseFont = false;
        this.xrTableCell5.StylePriority.UsePadding = false;
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell5.Weight = 0.33889371156045289D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell6.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.StylePriority.UseFont = false;
        this.xrTableCell6.StylePriority.UsePadding = false;
        this.xrTableCell6.StylePriority.UseTextAlignment = false;
        this.xrTableCell6.Text = "Thuế VAT 10%";
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell6.Weight = 0.98723047806800324D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell8.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.StylePriority.UseFont = false;
        this.xrTableCell8.StylePriority.UsePadding = false;
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "X";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell8.Weight = 0.14494643775084509D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell9.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.StylePriority.UseFont = false;
        this.xrTableCell9.StylePriority.UsePadding = false;
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell9.Weight = 0.30563058182872871D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell14.Font = new System.Drawing.Font("Tahoma", 8F);
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell14.StylePriority.UseBorders = false;
        this.xrTableCell14.StylePriority.UseFont = false;
        this.xrTableCell14.StylePriority.UsePadding = false;
        this.xrTableCell14.StylePriority.UseTextAlignment = false;
        this.xrTableCell14.Text = "X";
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell14.Weight = 0.37654777953870378D;
        // 
        // sum_thue10
        // 
        this.sum_thue10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_thue10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sum_thue10", this.sothapphan)});
        this.sum_thue10.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_thue10.Name = "sum_thue10";
        this.sum_thue10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_thue10.StylePriority.UseBorders = false;
        this.sum_thue10.StylePriority.UseFont = false;
        this.sum_thue10.StylePriority.UsePadding = false;
        this.sum_thue10.StylePriority.UseTextAlignment = false;
        this.sum_thue10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_thue10.Weight = 0.37027143332642531D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell16.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell16.StylePriority.UseBorders = false;
        this.xrTableCell16.StylePriority.UseFont = false;
        this.xrTableCell16.StylePriority.UsePadding = false;
        this.xrTableCell16.StylePriority.UseTextAlignment = false;
        this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell16.Weight = 0.374014030572944D;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23,
            this.sum_tongcong,
            this.xrTableCell25});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell17.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell17.StylePriority.UseBorders = false;
        this.xrTableCell17.StylePriority.UseFont = false;
        this.xrTableCell17.StylePriority.UsePadding = false;
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell17.Weight = 0.11108107044090532D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell18.StylePriority.UseBorders = false;
        this.xrTableCell18.StylePriority.UseFont = false;
        this.xrTableCell18.StylePriority.UsePadding = false;
        this.xrTableCell18.StylePriority.UseTextAlignment = false;
        this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell18.Weight = 0.33889371156045289D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell19.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell19.StylePriority.UseBorders = false;
        this.xrTableCell19.StylePriority.UseFont = false;
        this.xrTableCell19.StylePriority.UsePadding = false;
        this.xrTableCell19.StylePriority.UseTextAlignment = false;
        this.xrTableCell19.Text = "Tổng cộng thanh toán";
        this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell19.Weight = 0.98723047806800324D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell21.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell21.StylePriority.UseBorders = false;
        this.xrTableCell21.StylePriority.UseFont = false;
        this.xrTableCell21.StylePriority.UsePadding = false;
        this.xrTableCell21.StylePriority.UseTextAlignment = false;
        this.xrTableCell21.Text = "X";
        this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell21.Weight = 0.14494643775084509D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell22.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell22.StylePriority.UseBorders = false;
        this.xrTableCell22.StylePriority.UseFont = false;
        this.xrTableCell22.StylePriority.UsePadding = false;
        this.xrTableCell22.StylePriority.UseTextAlignment = false;
        this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell22.Weight = 0.30563058182872871D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell23.Font = new System.Drawing.Font("Tahoma", 8F);
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell23.StylePriority.UseBorders = false;
        this.xrTableCell23.StylePriority.UseFont = false;
        this.xrTableCell23.StylePriority.UsePadding = false;
        this.xrTableCell23.StylePriority.UseTextAlignment = false;
        this.xrTableCell23.Text = "X";
        this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell23.Weight = 0.37654777953870378D;
        // 
        // sum_tongcong
        // 
        this.sum_tongcong.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_tongcong.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sum_tongcong", this.sothapphan)});
        this.sum_tongcong.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_tongcong.Name = "sum_tongcong";
        this.sum_tongcong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_tongcong.StylePriority.UseBorders = false;
        this.sum_tongcong.StylePriority.UseFont = false;
        this.sum_tongcong.StylePriority.UsePadding = false;
        this.sum_tongcong.StylePriority.UseTextAlignment = false;
        this.sum_tongcong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_tongcong.Weight = 0.37027143332642531D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell25.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell25.StylePriority.UseBorders = false;
        this.xrTableCell25.StylePriority.UseFont = false;
        this.xrTableCell25.StylePriority.UsePadding = false;
        this.xrTableCell25.StylePriority.UseTextAlignment = false;
        this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell25.Weight = 0.374014030572944D;
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell26,
            this.xrTableCell28,
            this.bangchu});
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell26.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell26.StylePriority.UseBorders = false;
        this.xrTableCell26.StylePriority.UseFont = false;
        this.xrTableCell26.StylePriority.UsePadding = false;
        this.xrTableCell26.StylePriority.UseTextAlignment = false;
        this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell26.Weight = 0.11108107044090532D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell28.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell28.StylePriority.UseBorders = false;
        this.xrTableCell28.StylePriority.UseFont = false;
        this.xrTableCell28.StylePriority.UsePadding = false;
        this.xrTableCell28.StylePriority.UseTextAlignment = false;
        this.xrTableCell28.Text = "Thành tiền (bằng chữ):";
        this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell28.Weight = 0.5479260388993008D;
        // 
        // bangchu
        // 
        this.bangchu.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.bangchu.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "bangchu")});
        this.bangchu.Font = new System.Drawing.Font("Tahoma", 9F);
        this.bangchu.Name = "bangchu";
        this.bangchu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.bangchu.StylePriority.UseBorders = false;
        this.bangchu.StylePriority.UseFont = false;
        this.bangchu.StylePriority.UsePadding = false;
        this.bangchu.StylePriority.UseTextAlignment = false;
        this.bangchu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.bangchu.Weight = 2.3496084137468021D;
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell27,
            this.xrTableCell30,
            this.thoihan_giaohang,
            this.xrTableCell32,
            this.xrTableCell31});
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell27.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell27.StylePriority.UseBorders = false;
        this.xrTableCell27.StylePriority.UseFont = false;
        this.xrTableCell27.StylePriority.UsePadding = false;
        this.xrTableCell27.StylePriority.UseTextAlignment = false;
        this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell27.Weight = 0.11108107044090532D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell30.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell30.StylePriority.UseBorders = false;
        this.xrTableCell30.StylePriority.UseFont = false;
        this.xrTableCell30.StylePriority.UsePadding = false;
        this.xrTableCell30.StylePriority.UseTextAlignment = false;
        this.xrTableCell30.Text = "Thời hạn giao hàng:";
        this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell30.Weight = 0.5479260388993008D;
        // 
        // thoihan_giaohang
        // 
        this.thoihan_giaohang.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thoihan_giaohang","{0:dd/MM/yyyy}")});
        this.thoihan_giaohang.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.thoihan_giaohang.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.thoihan_giaohang.Name = "thoihan_giaohang";
        this.thoihan_giaohang.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.thoihan_giaohang.StylePriority.UseBorders = false;
        this.thoihan_giaohang.StylePriority.UseFont = false;
        this.thoihan_giaohang.StylePriority.UsePadding = false;
        this.thoihan_giaohang.StylePriority.UseTextAlignment = false;
        this.thoihan_giaohang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.thoihan_giaohang.Weight = 0.92314488785406568D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell32.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell32.StylePriority.UseBorders = false;
        this.xrTableCell32.StylePriority.UseFont = false;
        this.xrTableCell32.StylePriority.UsePadding = false;
        this.xrTableCell32.StylePriority.UseTextAlignment = false;
        this.xrTableCell32.Text = "* Địa điểm giao hàng:";
        this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell32.Weight = 0.51061435244498288D;
        // 
        // xrTableCell31
        // 
        this.xrTableCell31.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell31.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell31.Name = "xrTableCell31";
        this.xrTableCell31.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell31.StylePriority.UseBorders = false;
        this.xrTableCell31.StylePriority.UseFont = false;
        this.xrTableCell31.StylePriority.UsePadding = false;
        this.xrTableCell31.StylePriority.UseTextAlignment = false;
        this.xrTableCell31.Text = "Kho Anco II";
        this.xrTableCell31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell31.Weight = 0.91584917344775341D;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrTableCell36});
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell34.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell34.StylePriority.UseBorders = false;
        this.xrTableCell34.StylePriority.UseFont = false;
        this.xrTableCell34.StylePriority.UsePadding = false;
        this.xrTableCell34.StylePriority.UseTextAlignment = false;
        this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell34.Weight = 0.11108107044090532D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell35.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell35.StylePriority.UseBorders = false;
        this.xrTableCell35.StylePriority.UseFont = false;
        this.xrTableCell35.StylePriority.UsePadding = false;
        this.xrTableCell35.StylePriority.UseTextAlignment = false;
        this.xrTableCell35.Text = "Hình thức thanh toán:";
        this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell35.Weight = 0.5479260388993008D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell36.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell36.StylePriority.UseBorders = false;
        this.xrTableCell36.StylePriority.UseFont = false;
        this.xrTableCell36.StylePriority.UsePadding = false;
        this.xrTableCell36.StylePriority.UseTextAlignment = false;
        this.xrTableCell36.Text = "Chuyển khoản";
        this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell36.Weight = 2.3496084137468021D;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37,
            this.xrTableCell38});
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell37.Font = new System.Drawing.Font("Tahoma", 7.8F);
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell37.StylePriority.UseBorders = false;
        this.xrTableCell37.StylePriority.UseFont = false;
        this.xrTableCell37.StylePriority.UsePadding = false;
        this.xrTableCell37.StylePriority.UseTextAlignment = false;
        this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell37.Weight = 0.11108107044090532D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTableCell38.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell38.StylePriority.UseBorders = false;
        this.xrTableCell38.StylePriority.UseFont = false;
        this.xrTableCell38.StylePriority.UsePadding = false;
        this.xrTableCell38.StylePriority.UseTextAlignment = false;
        this.xrTableCell38.Text = "* Lưu ý: Khi nhận được đặt hàng này, xin vui lòng xác nhận và fax lại cho công ty" +
" chúng tôi.";
        this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell38.Weight = 2.8975344526461031D;
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(623.7778F, 187.9793F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(155.8612F, 23.00002F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "Nhà cung cấp xác nhận";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel27
        // 
        this.xrLabel27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(623.7778F, 210.9793F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(155.8612F, 22.99998F);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.Text = "(Ký, họ tên)";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel26
        // 
        this.xrLabel26.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(210.1185F, 210.9793F);
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.StylePriority.UseTextAlignment = false;
        this.xrLabel26.Text = "(Ký, họ tên)";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel21
        // 
        this.xrLabel21.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(210.1185F, 187.9793F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.Text = "Trưởng BP vật tư";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel23
        // 
        this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(21.62498F, 210.9793F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(111.6666F, 23F);
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.Text = "(Ký, họ tên)";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel18
        // 
        this.xrLabel18.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(21.62498F, 187.9793F);
        this.xrLabel18.Multiline = true;
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(111.6666F, 23.00001F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "Người lập";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel29
        // 
        this.xrLabel29.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(0F, 325.5003F);
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel29.SizeF = new System.Drawing.SizeF(73.1665F, 23F);
        this.xrLabel29.StylePriority.UseFont = false;
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        this.xrLabel29.Text = "Lưu trình";
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel31
        // 
        this.xrLabel31.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(3.000005F, 282.9168F);
        this.xrLabel31.Name = "xrLabel31";
        this.xrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel31.SizeF = new System.Drawing.SizeF(145.8333F, 23F);
        this.xrLabel31.StylePriority.UseFont = false;
        this.xrLabel31.StylePriority.UseTextAlignment = false;
        this.xrLabel31.Text = "Nguyễn Ngọc Hải";
        this.xrLabel31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.sdt,
            this.xrLabel46,
            this.xrLabel41,
            this.ncc,
            this.fax,
            this.sct_dmvt,
            this.dd,
            this.xrLabel44,
            this.xrLabel45,
            this.MM,
            this.xrLabel47,
            this.yyyy,
            this.xrLabel9,
            this.xrLabel8,
            this.xrLabel4,
            this.xrTable4,
            this.xrLabel7});
        this.ReportHeader.HeightF = 181.6875F;
        this.ReportHeader.Name = "ReportHeader";
        this.ReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.ReportHeader.StylePriority.UsePadding = false;
        // 
        // sdt
        // 
        this.sdt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sdt")});
        this.sdt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.sdt.LocationFloat = new DevExpress.Utils.PointFloat(95.15345F, 132.6875F);
        this.sdt.Name = "sdt";
        this.sdt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.sdt.SizeF = new System.Drawing.SizeF(248.0486F, 22.99998F);
        this.sdt.StylePriority.UseFont = false;
        this.sdt.StylePriority.UseTextAlignment = false;
        this.sdt.Text = "xuatcho";
        this.sdt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel46
        // 
        this.xrLabel46.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(387.4998F, 132.6875F);
        this.xrLabel46.Name = "xrLabel46";
        this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.xrLabel46.SizeF = new System.Drawing.SizeF(69.36865F, 22.99997F);
        this.xrLabel46.StylePriority.UseFont = false;
        this.xrLabel46.StylePriority.UsePadding = false;
        this.xrLabel46.StylePriority.UseTextAlignment = false;
        this.xrLabel46.Text = "Fax:";
        this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel41
        // 
        this.xrLabel41.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(24.49989F, 107.6875F);
        this.xrLabel41.Name = "xrLabel41";
        this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 2, 100F);
        this.xrLabel41.SizeF = new System.Drawing.SizeF(60F, 22.99998F);
        this.xrLabel41.StylePriority.UseFont = false;
        this.xrLabel41.StylePriority.UsePadding = false;
        this.xrLabel41.StylePriority.UseTextAlignment = false;
        this.xrLabel41.Text = "Kính gửi:";
        this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // ncc
        // 
        this.ncc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ncc")});
        this.ncc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.ncc.LocationFloat = new DevExpress.Utils.PointFloat(84.49992F, 107.6875F);
        this.ncc.Name = "ncc";
        this.ncc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ncc.SizeF = new System.Drawing.SizeF(258.2019F, 22.99999F);
        this.ncc.StylePriority.UseFont = false;
        this.ncc.StylePriority.UseTextAlignment = false;
        this.ncc.Text = "xuatcho";
        this.ncc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // fax
        // 
        this.fax.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fax")});
        this.fax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.fax.LocationFloat = new DevExpress.Utils.PointFloat(456.8685F, 132.6875F);
        this.fax.Name = "fax";
        this.fax.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.fax.SizeF = new System.Drawing.SizeF(239.2426F, 23F);
        this.fax.StylePriority.UseFont = false;
        this.fax.StylePriority.UseTextAlignment = false;
        this.fax.Text = "ncc";
        this.fax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // sct_dmvt
        // 
        this.sct_dmvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sct_dmvt")});
        this.sct_dmvt.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sct_dmvt.LocationFloat = new DevExpress.Utils.PointFloat(112.8334F, 68.33331F);
        this.sct_dmvt.Name = "sct_dmvt";
        this.sct_dmvt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 0, 100F);
        this.sct_dmvt.SizeF = new System.Drawing.SizeF(99.32008F, 23F);
        this.sct_dmvt.StylePriority.UseFont = false;
        this.sct_dmvt.StylePriority.UsePadding = false;
        this.sct_dmvt.StylePriority.UseTextAlignment = false;
        this.sct_dmvt.Text = "........................";
        this.sct_dmvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // dd
        // 
        this.dd.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dd")});
        this.dd.Font = new System.Drawing.Font("Tahoma", 9F);
        this.dd.LocationFloat = new DevExpress.Utils.PointFloat(654.9444F, 69.33331F);
        this.dd.Name = "dd";
        this.dd.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.dd.SizeF = new System.Drawing.SizeF(20F, 23F);
        this.dd.StylePriority.UseFont = false;
        this.dd.StylePriority.UseTextAlignment = false;
        this.dd.Text = "...";
        this.dd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel44
        // 
        this.xrLabel44.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(623.7778F, 69.33331F);
        this.xrLabel44.Name = "xrLabel44";
        this.xrLabel44.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel44.SizeF = new System.Drawing.SizeF(31F, 23.00001F);
        this.xrLabel44.StylePriority.UseFont = false;
        this.xrLabel44.StylePriority.UseTextAlignment = false;
        this.xrLabel44.Text = "ngày";
        this.xrLabel44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel45
        // 
        this.xrLabel45.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(675.7777F, 69.33331F);
        this.xrLabel45.Name = "xrLabel45";
        this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel45.SizeF = new System.Drawing.SizeF(36F, 23.00001F);
        this.xrLabel45.StylePriority.UseFont = false;
        this.xrLabel45.StylePriority.UseTextAlignment = false;
        this.xrLabel45.Text = "tháng";
        this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // MM
        // 
        this.MM.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MM")});
        this.MM.Font = new System.Drawing.Font("Tahoma", 9F);
        this.MM.LocationFloat = new DevExpress.Utils.PointFloat(713.1108F, 69.33334F);
        this.MM.Name = "MM";
        this.MM.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.MM.SizeF = new System.Drawing.SizeF(20F, 23F);
        this.MM.StylePriority.UseFont = false;
        this.MM.StylePriority.UseTextAlignment = false;
        this.MM.Text = "...";
        this.MM.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel47
        // 
        this.xrLabel47.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(733.1108F, 69.33332F);
        this.xrLabel47.Name = "xrLabel47";
        this.xrLabel47.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel47.SizeF = new System.Drawing.SizeF(30F, 23.00001F);
        this.xrLabel47.StylePriority.UseFont = false;
        this.xrLabel47.StylePriority.UseTextAlignment = false;
        this.xrLabel47.Text = "năm";
        this.xrLabel47.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // yyyy
        // 
        this.yyyy.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "yyyy")});
        this.yyyy.Font = new System.Drawing.Font("Tahoma", 9F);
        this.yyyy.LocationFloat = new DevExpress.Utils.PointFloat(763.9444F, 68.33331F);
        this.yyyy.Name = "yyyy";
        this.yyyy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.yyyy.SizeF = new System.Drawing.SizeF(33F, 23.00001F);
        this.yyyy.StylePriority.UseFont = false;
        this.yyyy.StylePriority.UseTextAlignment = false;
        this.yyyy.Text = "20...";
        this.yyyy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(25.0001F, 155.6875F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 2, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(496.3396F, 23F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UsePadding = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Kính đề nghị Quý công ty cung cấp cho chúng tôi các mặt hàng theo chi tiết như sa" +
"u:";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(25.0001F, 132.6875F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 2, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(70.15335F, 23F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UsePadding = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Điện thoại:";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(532.4442F, 69.33331F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(90.51416F, 23.00001F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UsePadding = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Thuận An, ";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(798.9999F, 68.33331F);
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell10.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.logo});
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseBorders = false;
        this.xrTableCell10.Weight = 1.3829165013790503D;
        // 
        // logo
        // 
        this.logo.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.logo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("ImageUrl", null, "logo")});
        this.logo.LocationFloat = new DevExpress.Utils.PointFloat(2.999995F, 4.000005F);
        this.logo.Name = "logo";
        this.logo.SizeF = new System.Drawing.SizeF(131.2916F, 58.99999F);
        this.logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
        this.logo.StylePriority.UseBorders = false;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell11.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseBorders = false;
        this.xrTableCell11.StylePriority.UseFont = false;
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "ĐƠN ĐẶT MUA VẬT TƯ";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell11.Weight = 4.8166678383958983D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell12.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel3});
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseBorders = false;
        this.xrTableCell12.Weight = 1.7904150498734897D;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(1F, 23.00001F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(177.1527F, 22F);
        this.xrLabel5.StylePriority.UseBorders = false;
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UsePadding = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Ngày hiệu lực: 01/01/13";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel6.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(1.000061F, 45F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(177.1524F, 22F);
        this.xrLabel6.StylePriority.UseBorders = false;
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UsePadding = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "Lần sửa đổi: 01";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel3.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(1F, 1F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(177.1527F, 22F);
        this.xrLabel3.StylePriority.UseBorders = false;
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UsePadding = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "MQL: SUP - 09";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(25.0001F, 68.33331F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(85.83334F, 23F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Số chứng từ: ";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel42,
            this.xrLabel16,
            this.xrLabel10,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel32,
            this.xrLabel33});
        this.PageHeader.HeightF = 44.58333F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrLabel42
        // 
        this.xrLabel42.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel42.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel42.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(699.673F, 0F);
        this.xrLabel42.Name = "xrLabel42";
        this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel42.SizeF = new System.Drawing.SizeF(99.32721F, 44.58333F);
        this.xrLabel42.StylePriority.UseBackColor = false;
        this.xrLabel42.StylePriority.UseBorders = false;
        this.xrLabel42.StylePriority.UseFont = false;
        this.xrLabel42.StylePriority.UseTextAlignment = false;
        this.xrLabel42.Text = "Ghi chú";
        this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel16
        // 
        this.xrLabel16.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(601.3397F, 0F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(98.33331F, 44.58333F);
        this.xrLabel16.StylePriority.UseBackColor = false;
        this.xrLabel16.StylePriority.UseBorders = false;
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "Thành tiền";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel10
        // 
        this.xrLabel10.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0.0001017253F, 0F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(29.5F, 44.58333F);
        this.xrLabel10.StylePriority.UseBackColor = false;
        this.xrLabel10.StylePriority.UseBorders = false;
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Stt";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel12
        // 
        this.xrLabel12.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel12.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(29.5001F, 0F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(90F, 44.58333F);
        this.xrLabel12.StylePriority.UseBackColor = false;
        this.xrLabel12.StylePriority.UseBorders = false;
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "Mã VTHH";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel13
        // 
        this.xrLabel13.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel13.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(119.5001F, 0F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(152.5545F, 44.58333F);
        this.xrLabel13.StylePriority.UseBackColor = false;
        this.xrLabel13.StylePriority.UseBorders = false;
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "Tên VTHH";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel14
        // 
        this.xrLabel14.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel14.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(272.0546F, 0F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(109.625F, 44.58333F);
        this.xrLabel14.StylePriority.UseBackColor = false;
        this.xrLabel14.StylePriority.UseBorders = false;
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "Quy cách";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel15
        // 
        this.xrLabel15.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel15.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(381.6796F, 0F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(38.49359F, 44.58333F);
        this.xrLabel15.StylePriority.UseBackColor = false;
        this.xrLabel15.StylePriority.UseBorders = false;
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "Đvt";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel32
        // 
        this.xrLabel32.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel32.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(420.1732F, 0F);
        this.xrLabel32.Name = "xrLabel32";
        this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel32.SizeF = new System.Drawing.SizeF(81.1665F, 44.58333F);
        this.xrLabel32.StylePriority.UseBackColor = false;
        this.xrLabel32.StylePriority.UseBorders = false;
        this.xrLabel32.StylePriority.UseFont = false;
        this.xrLabel32.StylePriority.UseTextAlignment = false;
        this.xrLabel32.Text = "Số lượng";
        this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel33
        // 
        this.xrLabel33.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel33.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel33.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(501.3397F, 0F);
        this.xrLabel33.Name = "xrLabel33";
        this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel33.SizeF = new System.Drawing.SizeF(100F, 44.58333F);
        this.xrLabel33.StylePriority.UseBackColor = false;
        this.xrLabel33.StylePriority.UseBorders = false;
        this.xrLabel33.StylePriority.UseFont = false;
        this.xrLabel33.StylePriority.UseTextAlignment = false;
        this.xrLabel33.Text = "Đơn giá";
        this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // donDatMuaVatTu
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader,
            this.PageHeader});
        this.Margins = new System.Drawing.Printing.Margins(10, 18, 8, 0);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "17.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}

