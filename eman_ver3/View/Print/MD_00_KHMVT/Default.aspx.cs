using System;
using System.Collections.Generic;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;

public partial class PrintControllers_MD_01_MD_00_KHMVT_Default : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        phieuYeuCauMuaVatTu report = new phieuYeuCauMuaVatTu(sothapphan);
        String sql = this.CreateSql(context);
        this.viewReport(report, sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
    {
        SqlDataAdapter da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        report.DataSource = ds;
        report.DataAdapter = da;
        ReportViewer1.Report = report;
    }

    public String CreateSql(HttpContext context)
    {
        var infoPrint = PrintAnco2.GetInfoPrint();
        string c_kehoachmuavt_id = context.Request.QueryString["id"];
        string sql = string.Format(@"
		select 
            sp.ma_sanpham as ma_vthh, 
            sp.mota_tiengviet as ten_vthh, 
            sp.quycachdonggoi as quycach, 
            dvt.ten_dvt as dvt, 
		    cdh.sl_can as sl_theobom, 
		    cdh.sl_tonkho, 
		    cdh.sl_canthem as sl_dutru, 
		    cdh.sl_denghi as sl_yeucau,
		    cdh.sl_duyet,
		    cdh.ngayphaico as ngay_dkgiao,
            khmvt.sochungtu as sct_khmvt,
            N'{1}' as dd,
            N'{2}' as MM, 
            N'{3}' as yyyy,
            N'{4}' as logo,
	        (
                SELECT isnull(kho.ten_kho + ',' + char(10), '')
	            FROM c_kehoachmuavt_dklht dklht
	            inner join md_kho kho on dklht.md_kho_id = kho.md_kho_id
	            WHERE dklht.md_sanpham_id = cdh.md_sanpham_id and dklht.c_kehoachmuavt_id = cdh.c_kehoachmuavt_id
	            FOR XML PATH(''),type
            ).value('.','nvarchar(max)') as khoton
		 from c_kehoachmuavt_cdh cdh
		 left join md_sanpham sp on sp.md_sanpham_id = cdh.md_sanpham_id
		 left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
		 left join c_kehoachmuavt khmvt on khmvt.c_kehoachmuavt_id = cdh.c_kehoachmuavt_id 
		 where cdh.c_kehoachmuavt_id = '{0}' order by sp.ma_sanpham",
        c_kehoachmuavt_id,
        DateTime.Now.ToString("dd"),
        DateTime.Now.ToString("MM"),
        DateTime.Now.ToString("yyyy"),
        infoPrint.logo
        );
        return sql;

    }
}

public class phieuYeuCauMuaVatTu : DevExpress.XtraReports.UI.XtraReport
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
    private XRTableCell khoton;
    private XRTableCell sl_tonkho;
    private XRTableCell sl_dutru;
    private ReportFooterBand ReportFooter;
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
    private XRTableCell cancel_soluong;
    private XRTableCell sum_tonkho;
    private XRTableCell sum_theobom;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell10;
    private XRPictureBox logo;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRTableCell sl_theobom;
    private XRTableCell sl_yeucau;
    private XRLabel xrLabel30;
    private XRLabel xrLabel24;
    private XRLabel xrLabel28;
    private XRTableCell sum_dutru;
    private XRTableCell sum_duyet;
    private XRLabel xrLabel29;
    private XRLabel xrLabel17;
    private XRLabel xrLabel16;
    private XRLabel xrLabel10;
    private XRLabel xrLabel12;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRLabel xrLabel19;
    private XRLabel xrLabel32;
    private XRLabel xrLabel33;
    private XRLabel xrLabel34;
    private XRTableCell xrTableCell1;
    private XRLabel xrLabel36;
    private XRLabel xrLabel31;
    private XRLabel dd;
    private XRLabel xrLabel44;
    private XRLabel xrLabel45;
    private XRLabel MM;
    private XRLabel xrLabel47;
    private XRLabel yyyy;
    private XRLabel xrLabel11;
    private XRLabel sct_khmvt;
    private XRLabel xrLabel41;
    private XRTableCell sl_duyet;
    private XRTableCell xrTableCell3;
    private XRLabel xrLabel42;
    private XRTableCell ngay_dkgiao;
    private XRTableCell sum_yeucau;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRLabel xrLabel2;
    private XRLabel xrLabel38;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public phieuYeuCauMuaVatTu(string stp)
    {
        sothapphan = stp;
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
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma_vthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten_vthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.quycach = new DevExpress.XtraReports.UI.XRTableCell();
        this.dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.khoton = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_tonkho = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_theobom = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_dutru = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_yeucau = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_duyet = new DevExpress.XtraReports.UI.XRTableCell();
        this.ngay_dkgiao = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.cancel_soluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_tonkho = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_theobom = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_dutru = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_yeucau = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_duyet = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
        this.sct_khmvt = new DevExpress.XtraReports.UI.XRLabel();
        this.dd = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
        this.MM = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
        this.yyyy = new DevExpress.XtraReports.UI.XRLabel();
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
        this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel42 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
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
        this.xrTable2.SizeF = new System.Drawing.SizeF(1141F, 25F);
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
            this.khoton,
            this.sl_tonkho,
            this.sl_theobom,
            this.sl_dutru,
            this.sl_yeucau,
            this.sl_duyet,
            this.ngay_dkgiao});
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
        this.ma_vthh.Weight = 0.39131342357927396D;
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
        this.ten_vthh.Weight = 0.77823043791447366D;
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
        this.quycach.Weight = 0.5057799842612074D;
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
        this.dvt.Weight = 0.15709100111577751D;
        // 
        // khoton
        // 
        this.khoton.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.khoton.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "khoton")});
        this.khoton.Font = new System.Drawing.Font("Tahoma", 9F);
        this.khoton.Multiline = true;
        this.khoton.Name = "khoton";
        this.khoton.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.khoton.StylePriority.UseBorders = false;
        this.khoton.StylePriority.UseFont = false;
        this.khoton.StylePriority.UsePadding = false;
        this.khoton.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = this.sothapphan;
        this.khoton.Summary = xrSummary2;
        this.khoton.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.khoton.Weight = 0.34863882645902478D;
        // 
        // sl_tonkho
        // 
        this.sl_tonkho.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sl_tonkho.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_tonkho", this.sothapphan)});
        this.sl_tonkho.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sl_tonkho.Multiline = true;
        this.sl_tonkho.Name = "sl_tonkho";
        this.sl_tonkho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.sl_tonkho.StylePriority.UseBorders = false;
        this.sl_tonkho.StylePriority.UseFont = false;
        this.sl_tonkho.StylePriority.UsePadding = false;
        this.sl_tonkho.StylePriority.UseTextAlignment = false;
        this.sl_tonkho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_tonkho.Weight = 0.34685723656969292D;
        // 
        // sl_theobom
        // 
        this.sl_theobom.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sl_theobom.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_theobom", this.sothapphan)});
        this.sl_theobom.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sl_theobom.Multiline = true;
        this.sl_theobom.Name = "sl_theobom";
        this.sl_theobom.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.sl_theobom.StylePriority.UseBorders = false;
        this.sl_theobom.StylePriority.UseFont = false;
        this.sl_theobom.StylePriority.UsePadding = false;
        this.sl_theobom.StylePriority.UseTextAlignment = false;
        this.sl_theobom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_theobom.Weight = 0.34685727646198855D;
        // 
        // sl_dutru
        // 
        this.sl_dutru.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sl_dutru.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_dutru", this.sothapphan)});
        this.sl_dutru.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sl_dutru.Multiline = true;
        this.sl_dutru.Name = "sl_dutru";
        this.sl_dutru.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.sl_dutru.StylePriority.UseBorders = false;
        this.sl_dutru.StylePriority.UseFont = false;
        this.sl_dutru.StylePriority.UsePadding = false;
        this.sl_dutru.StylePriority.UseTextAlignment = false;
        this.sl_dutru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_dutru.Weight = 0.3468575066359012D;
        // 
        // sl_yeucau
        // 
        this.sl_yeucau.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sl_yeucau.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_yeucau", this.sothapphan)});
        this.sl_yeucau.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sl_yeucau.Multiline = true;
        this.sl_yeucau.Name = "sl_yeucau";
        this.sl_yeucau.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.sl_yeucau.StylePriority.UseBorders = false;
        this.sl_yeucau.StylePriority.UseFont = false;
        this.sl_yeucau.StylePriority.UsePadding = false;
        this.sl_yeucau.StylePriority.UseTextAlignment = false;
        this.sl_yeucau.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_yeucau.Weight = 0.34685727662174604D;
        // 
        // sl_duyet
        // 
        this.sl_duyet.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sl_duyet.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_duyet", this.sothapphan)});
        this.sl_duyet.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sl_duyet.Name = "sl_duyet";
        this.sl_duyet.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.sl_duyet.StylePriority.UseBorders = false;
        this.sl_duyet.StylePriority.UseFont = false;
        this.sl_duyet.StylePriority.UsePadding = false;
        this.sl_duyet.StylePriority.UseTextAlignment = false;
        this.sl_duyet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_duyet.Weight = 0.34813694129139222D;
        // 
        // ngay_dkgiao
        // 
        this.ngay_dkgiao.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.ngay_dkgiao.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngay_dkgiao", "{0:dd/MM/yyyy}")});
        this.ngay_dkgiao.Font = new System.Drawing.Font("Tahoma", 9F);
        this.ngay_dkgiao.Name = "ngay_dkgiao";
        this.ngay_dkgiao.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.ngay_dkgiao.StylePriority.UseBorders = false;
        this.ngay_dkgiao.StylePriority.UseFont = false;
        this.ngay_dkgiao.StylePriority.UsePadding = false;
        this.ngay_dkgiao.StylePriority.UseTextAlignment = false;
        this.ngay_dkgiao.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.ngay_dkgiao.Weight = 0.27394381582200683D;
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
            this.xrLabel11,
            this.xrLabel36,
            this.xrLabel30,
            this.xrLabel24,
            this.xrLabel28,
            this.xrTable3,
            this.xrLabel26,
            this.xrLabel21,
            this.xrLabel23,
            this.xrLabel18,
            this.xrLabel29,
            this.xrLabel31});
        this.ReportFooter.HeightF = 209.5834F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel11
        // 
        this.xrLabel11.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(954.0078F, 142.8333F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(165F, 23F);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel36
        // 
        this.xrLabel36.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(495.2018F, 142.8333F);
        this.xrLabel36.Name = "xrLabel36";
        this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel36.SizeF = new System.Drawing.SizeF(165F, 23F);
        this.xrLabel36.StylePriority.UseFont = false;
        this.xrLabel36.StylePriority.UseTextAlignment = false;
        this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel30
        // 
        this.xrLabel30.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(73.1665F, 184.4168F);
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(1067.833F, 23F);
        this.xrLabel30.StylePriority.UseFont = false;
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        this.xrLabel30.Text = ": Người lập phiếu → TBP vật tư → Giám đốc";
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel24
        // 
        this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(976.0001F, 47.89581F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "Giám đốc";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel28
        // 
        this.xrLabel28.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(976.0001F, 70.89584F);
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
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(1141F, 25F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell13,
            this.xrTableCell20,
            this.cancel_soluong,
            this.sum_tonkho,
            this.sum_theobom,
            this.sum_dutru,
            this.sum_yeucau,
            this.sum_duyet,
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
        this.xrTableCell1.Text = "X";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.11108107044090532D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell13.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell13.StylePriority.UseBorders = false;
        this.xrTableCell13.StylePriority.UseFont = false;
        this.xrTableCell13.StylePriority.UsePadding = false;
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "Tổng cộng";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell13.Weight = 1.6732301919000698D;
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
        this.xrTableCell20.Weight = 0.15689465032402505D;
        // 
        // cancel_soluong
        // 
        this.cancel_soluong.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cancel_soluong.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cancel_soluong.Multiline = true;
        this.cancel_soluong.Name = "cancel_soluong";
        this.cancel_soluong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.cancel_soluong.StylePriority.UseBorders = false;
        this.cancel_soluong.StylePriority.UseFont = false;
        this.cancel_soluong.StylePriority.UsePadding = false;
        this.cancel_soluong.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = this.sothapphan;
        xrSummary3.IgnoreNullValues = true;
        this.cancel_soluong.Summary = xrSummary3;
        this.cancel_soluong.Text = "X";
        this.cancel_soluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cancel_soluong.Weight = 0.3482032384736794D;
        // 
        // sum_tonkho
        // 
        this.sum_tonkho.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_tonkho.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_tonkho", this.sothapphan)});
        this.sum_tonkho.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_tonkho.Multiline = true;
        this.sum_tonkho.Name = "sum_tonkho";
        this.sum_tonkho.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_tonkho.StylePriority.UseBorders = false;
        this.sum_tonkho.StylePriority.UseFont = false;
        this.sum_tonkho.StylePriority.UsePadding = false;
        this.sum_tonkho.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = this.sothapphan;
        xrSummary4.IgnoreNullValues = true;
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.sum_tonkho.Summary = xrSummary4;
        this.sum_tonkho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_tonkho.Weight = 0.34642348113557508D;
        // 
        // sum_theobom
        // 
        this.sum_theobom.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_theobom.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_theobom")});
        this.sum_theobom.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_theobom.Multiline = true;
        this.sum_theobom.Name = "sum_theobom";
        this.sum_theobom.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_theobom.StylePriority.UseBorders = false;
        this.sum_theobom.StylePriority.UseFont = false;
        this.sum_theobom.StylePriority.UsePadding = false;
        this.sum_theobom.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = this.sothapphan;
        xrSummary5.IgnoreNullValues = true;
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.sum_theobom.Summary = xrSummary5;
        this.sum_theobom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_theobom.Weight = 0.34642368611819063D;
        // 
        // sum_dutru
        // 
        this.sum_dutru.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_dutru.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_dutru")});
        this.sum_dutru.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_dutru.Multiline = true;
        this.sum_dutru.Name = "sum_dutru";
        this.sum_dutru.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_dutru.StylePriority.UseBorders = false;
        this.sum_dutru.StylePriority.UseFont = false;
        this.sum_dutru.StylePriority.UsePadding = false;
        this.sum_dutru.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = this.sothapphan;
        xrSummary6.IgnoreNullValues = true;
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.sum_dutru.Summary = xrSummary6;
        this.sum_dutru.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.sum_dutru.Weight = 0.34642397414651427D;
        // 
        // sum_yeucau
        // 
        this.sum_yeucau.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_yeucau.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_yeucau")});
        this.sum_yeucau.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_yeucau.Multiline = true;
        this.sum_yeucau.Name = "sum_yeucau";
        this.sum_yeucau.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_yeucau.StylePriority.UseBorders = false;
        this.sum_yeucau.StylePriority.UseFont = false;
        this.sum_yeucau.StylePriority.UsePadding = false;
        this.sum_yeucau.StylePriority.UseTextAlignment = false;
        xrSummary7.FormatString = this.sothapphan;
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.sum_yeucau.Summary = xrSummary7;
        this.sum_yeucau.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_yeucau.Weight = 0.34642374432014661D;
        // 
        // sum_duyet
        // 
        this.sum_duyet.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_duyet.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_duyet")});
        this.sum_duyet.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_duyet.Multiline = true;
        this.sum_duyet.Name = "sum_duyet";
        this.sum_duyet.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_duyet.StylePriority.UseBorders = false;
        this.sum_duyet.StylePriority.UseFont = false;
        this.sum_duyet.StylePriority.UsePadding = false;
        this.sum_duyet.StylePriority.UseTextAlignment = false;
        xrSummary8.FormatString = this.sothapphan;
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.sum_duyet.Summary = xrSummary8;
        this.sum_duyet.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_duyet.Weight = 0.34770178238521277D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrTableCell3.Multiline = true;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.StylePriority.UsePadding = false;
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "X";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell3.Weight = 0.27360139191088095D;
        // 
        // xrLabel26
        // 
        this.xrLabel26.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(515.5275F, 70.89584F);
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
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(515.5275F, 47.89581F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.Text = "TBP vật tư";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel23
        // 
        this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(50.79165F, 70.89584F);
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
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(50.79165F, 47.89581F);
        this.xrLabel18.Multiline = true;
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(111.6666F, 23.00001F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "Người lập phiếu";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel29
        // 
        this.xrLabel29.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))));
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(0F, 184.4168F);
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
        this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(38.00011F, 142.8333F);
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
            this.xrLabel8,
            this.xrLabel9,
            this.xrLabel2,
            this.xrLabel41,
            this.sct_khmvt,
            this.dd,
            this.xrLabel44,
            this.xrLabel45,
            this.MM,
            this.xrLabel47,
            this.yyyy,
            this.xrLabel4,
            this.xrTable4,
            this.xrLabel7});
        this.ReportHeader.HeightF = 156.6875F;
        this.ReportHeader.Name = "ReportHeader";
        this.ReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.ReportHeader.StylePriority.UsePadding = false;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(24.49989F, 133.6875F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 2, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(62.29169F, 22.99998F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UsePadding = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Diễn giải:";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel9
        // 
        this.xrLabel9.AutoWidth = true;
        this.xrLabel9.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(86.79159F, 133.6875F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(676.3192F, 22.99998F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UsePadding = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "................................................................................." +
".........................................................................";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel2
        // 
        this.xrLabel2.AutoWidth = true;
        this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(134.2916F, 107.6875F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(628.8192F, 22.99999F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UsePadding = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "................................................................................." +
".............................................................";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel41
        // 
        this.xrLabel41.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(24.49989F, 107.6875F);
        this.xrLabel41.Name = "xrLabel41";
        this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 2, 100F);
        this.xrLabel41.SizeF = new System.Drawing.SizeF(109.7917F, 22.99998F);
        this.xrLabel41.StylePriority.UseFont = false;
        this.xrLabel41.StylePriority.UsePadding = false;
        this.xrLabel41.StylePriority.UseTextAlignment = false;
        this.xrLabel41.Text = "Bộ phận yêu cầu:";
        this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // sct_khmvt
        // 
        this.sct_khmvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sct_khmvt")});
        this.sct_khmvt.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sct_khmvt.LocationFloat = new DevExpress.Utils.PointFloat(123.8334F, 68.33331F);
        this.sct_khmvt.Name = "sct_khmvt";
        this.sct_khmvt.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 0, 100F);
        this.sct_khmvt.SizeF = new System.Drawing.SizeF(391.6941F, 23F);
        this.sct_khmvt.StylePriority.UseFont = false;
        this.sct_khmvt.StylePriority.UsePadding = false;
        this.sct_khmvt.StylePriority.UseTextAlignment = false;
        this.sct_khmvt.Text = "........................";
        this.sct_khmvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // dd
        // 
        this.dd.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dd")});
        this.dd.Font = new System.Drawing.Font("Tahoma", 9F);
        this.dd.LocationFloat = new DevExpress.Utils.PointFloat(927.0001F, 69.99998F);
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
        this.xrLabel44.LocationFloat = new DevExpress.Utils.PointFloat(895.8334F, 69.99998F);
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
        this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(947.8333F, 69.99998F);
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
        this.MM.LocationFloat = new DevExpress.Utils.PointFloat(985.1664F, 70.00001F);
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
        this.xrLabel47.LocationFloat = new DevExpress.Utils.PointFloat(1006.166F, 69.99998F);
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
        this.yyyy.LocationFloat = new DevExpress.Utils.PointFloat(1037F, 68.99997F);
        this.yyyy.Name = "yyyy";
        this.yyyy.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.yyyy.SizeF = new System.Drawing.SizeF(33F, 23.00001F);
        this.yyyy.StylePriority.UseFont = false;
        this.yyyy.StylePriority.UseTextAlignment = false;
        this.yyyy.Text = "20...";
        this.yyyy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Tahoma", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(804.4998F, 69.99998F);
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
        this.xrTable4.SizeF = new System.Drawing.SizeF(1141F, 68.33331F);
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
        this.xrTableCell10.Weight = 1.04222444476604D;
        // 
        // logo
        // 
        this.logo.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.logo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("ImageUrl", null, "logo")});
        this.logo.LocationFloat = new DevExpress.Utils.PointFloat(8.999995F, 4.000005F);
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
        this.xrTableCell11.Text = "PHIẾU YÊU CẦU MUA VẬT TƯ";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell11.Weight = 5.6125307629555765D;
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
        this.xrTableCell12.Weight = 1.3352441819268215D;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrLabel5.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(4.524879F, 23.00001F);
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
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(4.524986F, 44.99999F);
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
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(4.524879F, 1F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(177.1527F, 22F);
        this.xrLabel3.StylePriority.UseBorders = false;
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UsePadding = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "MQL: SUP - 07";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(38.0001F, 68.33331F);
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
            this.xrLabel38,
            this.xrLabel42,
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel10,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel15,
            this.xrLabel19,
            this.xrLabel32,
            this.xrLabel33,
            this.xrLabel34});
        this.PageHeader.HeightF = 45.29167F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrLabel38
        // 
        this.xrLabel38.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel38.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel38.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(515.5275F, 0F);
        this.xrLabel38.Name = "xrLabel38";
        this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel38.SizeF = new System.Drawing.SizeF(92.47253F, 45.29167F);
        this.xrLabel38.StylePriority.UseBackColor = false;
        this.xrLabel38.StylePriority.UseBorders = false;
        this.xrLabel38.StylePriority.UseFont = false;
        this.xrLabel38.StylePriority.UseTextAlignment = false;
        this.xrLabel38.Text = "Kho tồn";
        this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel42
        // 
        this.xrLabel42.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel42.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel42.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(1068.339F, 0F);
        this.xrLabel42.Name = "xrLabel42";
        this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel42.SizeF = new System.Drawing.SizeF(72.66052F, 45.29167F);
        this.xrLabel42.StylePriority.UseBackColor = false;
        this.xrLabel42.StylePriority.UseBorders = false;
        this.xrLabel42.StylePriority.UseFont = false;
        this.xrLabel42.StylePriority.UseTextAlignment = false;
        this.xrLabel42.Text = "Ngày dự kiến giao";
        this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel17
        // 
        this.xrLabel17.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(884.0001F, 22.29167F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(92F, 23F);
        this.xrLabel17.StylePriority.UseBackColor = false;
        this.xrLabel17.StylePriority.UseBorders = false;
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        this.xrLabel17.Text = "Yêu cầu";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel16
        // 
        this.xrLabel16.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(792.0001F, 22.29167F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(92F, 23F);
        this.xrLabel16.StylePriority.UseBackColor = false;
        this.xrLabel16.StylePriority.UseBorders = false;
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "Dự trữ";
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
        this.xrLabel10.SizeF = new System.Drawing.SizeF(29.5F, 45.29167F);
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
        this.xrLabel12.SizeF = new System.Drawing.SizeF(103.7915F, 45.29167F);
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
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(133.2916F, 0F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(206.2019F, 45.29167F);
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
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(339.7084F, 0F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(134.1524F, 45.29167F);
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
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(473.8608F, 0F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(41.66663F, 45.29167F);
        this.xrLabel15.StylePriority.UseBackColor = false;
        this.xrLabel15.StylePriority.UseBorders = false;
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "Đvt";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel19
        // 
        this.xrLabel19.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(608.0001F, 0F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(459.9999F, 22.29166F);
        this.xrLabel19.StylePriority.UseBackColor = false;
        this.xrLabel19.StylePriority.UseBorders = false;
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.Text = "Số lượng";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel32
        // 
        this.xrLabel32.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel32.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(608F, 22.29F);
        this.xrLabel32.Name = "xrLabel32";
        this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel32.SizeF = new System.Drawing.SizeF(92F, 23F);
        this.xrLabel32.StylePriority.UseBackColor = false;
        this.xrLabel32.StylePriority.UseBorders = false;
        this.xrLabel32.StylePriority.UseFont = false;
        this.xrLabel32.StylePriority.UseTextAlignment = false;
        this.xrLabel32.Text = "Tồn kho";
        this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel33
        // 
        this.xrLabel33.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel33.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel33.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(700F, 22.29F);
        this.xrLabel33.Name = "xrLabel33";
        this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel33.SizeF = new System.Drawing.SizeF(92F, 23F);
        this.xrLabel33.StylePriority.UseBackColor = false;
        this.xrLabel33.StylePriority.UseBorders = false;
        this.xrLabel33.StylePriority.UseFont = false;
        this.xrLabel33.StylePriority.UseTextAlignment = false;
        this.xrLabel33.Text = "Theo BOM";
        this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel34
        // 
        this.xrLabel34.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel34.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel34.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(976.0001F, 22.29167F);
        this.xrLabel34.Name = "xrLabel34";
        this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel34.SizeF = new System.Drawing.SizeF(92F, 23F);
        this.xrLabel34.StylePriority.UseBackColor = false;
        this.xrLabel34.StylePriority.UseBorders = false;
        this.xrLabel34.StylePriority.UseFont = false;
        this.xrLabel34.StylePriority.UseTextAlignment = false;
        this.xrLabel34.Text = "SL Duyệt";
        this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // phieuYeuCauMuaVatTu
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader,
            this.PageHeader});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(10, 18, 8, 0);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "17.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}