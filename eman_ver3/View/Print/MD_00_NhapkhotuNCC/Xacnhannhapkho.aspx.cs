using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using System.Data;
using DataAcess;

public partial class PrintControllers_MD_00_NhapkhotuNCC_Xacnhannhapkho : System.Web.UI.Page
{
    public string logo = "", sothapphan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        phieuXNNhapVatTu report = new phieuXNNhapVatTu(sothapphan);
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
		string md_nhapkho_ncc_id = context.Request.QueryString["md_nhapkho_ncc_id"];
		string sql = string.Format(@"
		select sp.ma_sanpham as ma_vthh, 
        sp.mota_tiengviet as ten_vthh, 
		dvtsp.ten_dvt as dvt, 
        (nk_ncc_dh.sl_dadat - nk_ncc_dh.sl_hanngach) as duocnhap, 
        null as thucnhap,
		sp.quycachdonggoi as quycach, 
        nk_ncc_dh.giachuan as dongia,
        null as thanhtien,
		N'{1}' as dd, 
		N'{2}' as MM, 
		N'{3}' as yyyy,
        N'ANCO II' as kho, 
		dmh.sochungtu as sct_dmh, 
        dmh.ngaydonhang as dd_dmh, 
        dmh.ngaydonhang as MM_dmh, 
        dmh.ngaydonhang as yyyy_dmh, 
        dmh.donhang_thamchieu as sodonhang,
        dtkd.ma_dtkd as nhacungcap,
        N'{4}' as logo
		from c_donmuahang_cdmh nk_ncc_dh
		left join md_sanpham sp on nk_ncc_dh.md_sanpham_id = sp.md_sanpham_id
		left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
		left join c_donmuahang dmh on dmh.c_donmuahang_id = nk_ncc_dh.c_donmuahang_id
		left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
		where nk_ncc_dh.c_donmuahang_id = '{0}' order by sp.ma_sanpham asc", 
        md_nhapkho_ncc_id,
        DateTime.Now.ToString("dd"),
        DateTime.Now.ToString("MM"),
        DateTime.Now.ToString("yyyy"),
        infoPrint.logo
        );
		return sql;
    }
}

public class phieuXNNhapVatTu : DevExpress.XtraReports.UI.XtraReport
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
    private XRTableCell sct;
    private XRTableCell duocnhap;
    private XRTableCell dongia;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel22;
    private XRLabel xrLabel27;
    private XRLabel xrLabel26;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRLabel xrLabel25;
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
    private XRTableCell sum_duocnhap;
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
    private XRLabel phieugiaohang;
    private XRLabel xrLabel8;
    private XRLabel xrLabel7;
    private XRLabel xrLabel9;
    private XRLabel ncc2;
    private XRTableCell thucnhap;
    private XRTableCell thanhtien;
    private XRLabel xrLabel30;
    private XRLabel xrLabel24;
    private XRLabel xrLabel28;
    private XRTableCell sum_tongcong;
    private XRTableCell sum_thucxuat;
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
    private XRLabel xrLabel11;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel38;
    private XRLabel nhacungcap;
    private XRLabel xrLabel39;
    private XRLabel xrLabel41;
    private XRLabel sct_dmh;
    private XRLabel xrLabel43;
    private XRLabel sodonhang;
    private XRLabel kho;
    private XRLabel xrLabel49;
    private XRTableCell ghichu;
    private XRTableCell xrTableCell3;
    private XRLabel xrLabel40;
    private XRLabel xrLabel42;
    private XRLabel yy_dmh;
    private XRLabel dd_dmh;
    private XRLabel xrLabel54;
    private XRLabel MM_dmh;
    private XRLabel xrLabel56;
    private XRLabel xrLabel51;
    private XRLabel xrLabel52;
    private XRLabel xrLabel50;
    private XRLabel xrLabel48;
    private XRLabel xrLabel46;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public phieuXNNhapVatTu(string stp)
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
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma_vthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten_vthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.quycach = new DevExpress.XtraReports.UI.XRTableCell();
        this.dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.sct = new DevExpress.XtraReports.UI.XRTableCell();
        this.duocnhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.thucnhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.dongia = new DevExpress.XtraReports.UI.XRTableCell();
        this.thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel37 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel35 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_soluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_duocnhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_thucnhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_tongcong = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_thucxuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
        this.yy_dmh = new DevExpress.XtraReports.UI.XRLabel();
        this.dd_dmh = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel54 = new DevExpress.XtraReports.UI.XRLabel();
        this.MM_dmh = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel56 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel51 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel52 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel50 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel40 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel49 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel41 = new DevExpress.XtraReports.UI.XRLabel();
        this.sct_dmh = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel43 = new DevExpress.XtraReports.UI.XRLabel();
        this.sodonhang = new DevExpress.XtraReports.UI.XRLabel();
        this.kho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel39 = new DevExpress.XtraReports.UI.XRLabel();
        this.nhacungcap = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.dd = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel44 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
        this.MM = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel47 = new DevExpress.XtraReports.UI.XRLabel();
        this.yyyy = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.ncc2 = new DevExpress.XtraReports.UI.XRLabel();
        this.phieugiaohang = new DevExpress.XtraReports.UI.XRLabel();
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
            this.sct,
            this.duocnhap,
            this.thucnhap,
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
        this.ma_vthh.Weight = 0.306642316122694D;
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
        this.ten_vthh.Weight = 0.37445524718615536D;
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
        this.quycach.Weight = 0.3564897266757826D;
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
        this.dvt.Weight = 0.13195655509362975D;
        // 
        // sct
        // 
        this.sct.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sct.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sct.Multiline = true;
        this.sct.Name = "sct";
        this.sct.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.sct.StylePriority.UseBorders = false;
        this.sct.StylePriority.UseFont = false;
        this.sct.StylePriority.UsePadding = false;
        this.sct.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = this.sothapphan;
        this.sct.Summary = xrSummary2;
        this.sct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sct.Weight = 0.3060130414479042D;
        // 
        // duocnhap
        // 
        this.duocnhap.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.duocnhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "duocnhap", this.sothapphan)});
        this.duocnhap.Font = new System.Drawing.Font("Tahoma", 9F);
        this.duocnhap.Multiline = true;
        this.duocnhap.Name = "duocnhap";
        this.duocnhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.duocnhap.StylePriority.UseBorders = false;
        this.duocnhap.StylePriority.UseFont = false;
        this.duocnhap.StylePriority.UsePadding = false;
        this.duocnhap.StylePriority.UseTextAlignment = false;
        this.duocnhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.duocnhap.Weight = 0.30336730158220981D;
        // 
        // thucnhap
        // 
        this.thucnhap.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.thucnhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thucnhap", this.sothapphan)});
        this.thucnhap.Font = new System.Drawing.Font("Tahoma", 9F);
        this.thucnhap.Multiline = true;
        this.thucnhap.Name = "thucnhap";
        this.thucnhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.thucnhap.StylePriority.UseBorders = false;
        this.thucnhap.StylePriority.UseFont = false;
        this.thucnhap.StylePriority.UsePadding = false;
        this.thucnhap.StylePriority.UseTextAlignment = false;
        this.thucnhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.thucnhap.Weight = 0.28276405582188258D;
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
        this.dongia.Weight = 0.28276405582188913D;
        // 
        // thanhtien
        // 
        this.thanhtien.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
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
        this.thanhtien.Weight = 0.28276408458613655D;
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
        this.ghichu.Weight = 0.2739438156834183D;
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
            this.xrLabel20,
            this.xrLabel25,
            this.xrLabel23,
            this.xrLabel18,
            this.xrLabel29,
            this.xrLabel31});
        this.ReportFooter.HeightF = 209.5834F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel11
        // 
        this.xrLabel11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(493.5352F, 142.8333F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(165F, 23F);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.Text = "Lê Trọng Tài";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel37
        // 
        this.xrLabel37.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel37.LocationFloat = new DevExpress.Utils.PointFloat(658.5352F, 142.8334F);
        this.xrLabel37.Name = "xrLabel37";
        this.xrLabel37.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel37.SizeF = new System.Drawing.SizeF(139.5758F, 23F);
        this.xrLabel37.StylePriority.UseFont = false;
        this.xrLabel37.StylePriority.UseTextAlignment = false;
        this.xrLabel37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel36
        // 
        this.xrLabel36.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(328.5352F, 142.8334F);
        this.xrLabel36.Name = "xrLabel36";
        this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel36.SizeF = new System.Drawing.SizeF(165F, 23F);
        this.xrLabel36.StylePriority.UseFont = false;
        this.xrLabel36.StylePriority.UseTextAlignment = false;
        this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel35
        // 
        this.xrLabel35.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel35.LocationFloat = new DevExpress.Utils.PointFloat(148.8333F, 142.8334F);
        this.xrLabel35.Name = "xrLabel35";
        this.xrLabel35.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel35.SizeF = new System.Drawing.SizeF(179.1666F, 23F);
        this.xrLabel35.StylePriority.UseFont = false;
        this.xrLabel35.StylePriority.UseTextAlignment = false;
        this.xrLabel35.Text = "Đặng Thị Thu Hiền";
        this.xrLabel35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel30
        // 
        this.xrLabel30.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(73.1665F, 184.4168F);
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(725.8337F, 23F);
        this.xrLabel30.StylePriority.UseFont = false;
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        this.xrLabel30.Text = ": Người lập phiếu → Thủ kho → TBP vật tư → Giám đốc xưởng → Người giao hàng";
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel24
        // 
        this.xrLabel24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(515.5275F, 47.89581F);
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
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(515.5275F, 70.89584F);
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
        this.xrTable3.SizeF = new System.Drawing.SizeF(799.0002F, 25F);
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
            this.sum_soluong,
            this.sum_duocnhap,
            this.sum_thucnhap,
            this.sum_tongcong,
            this.sum_thucxuat,
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
        this.xrTableCell13.Weight = 1.0362908905686665D;
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
        this.xrTableCell20.Weight = 0.13179163549512268D;
        // 
        // sum_soluong
        // 
        this.sum_soluong.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_soluong.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_soluong.Multiline = true;
        this.sum_soluong.Name = "sum_soluong";
        this.sum_soluong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_soluong.StylePriority.UseBorders = false;
        this.sum_soluong.StylePriority.UseFont = false;
        this.sum_soluong.StylePriority.UsePadding = false;
        this.sum_soluong.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = this.sothapphan;
        xrSummary3.IgnoreNullValues = true;
        this.sum_soluong.Summary = xrSummary3;
        this.sum_soluong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_soluong.Weight = 0.30563054687659019D;
        // 
        // sum_duocnhap
        // 
        this.sum_duocnhap.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_duocnhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "duocnhap")});
        this.sum_duocnhap.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_duocnhap.Name = "sum_duocnhap";
        this.sum_duocnhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_duocnhap.StylePriority.UseBorders = false;
        this.sum_duocnhap.StylePriority.UseFont = false;
        this.sum_duocnhap.StylePriority.UsePadding = false;
        this.sum_duocnhap.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = this.sothapphan;
        xrSummary4.IgnoreNullValues = true;
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.sum_duocnhap.Summary = xrSummary4;
        this.sum_duocnhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_duocnhap.Weight = 0.30298813626765053D;
        // 
        // sum_thucnhap
        // 
        this.sum_thucnhap.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_thucnhap.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_thucnhap.Name = "sum_thucnhap";
        this.sum_thucnhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_thucnhap.StylePriority.UseBorders = false;
        this.sum_thucnhap.StylePriority.UseFont = false;
        this.sum_thucnhap.StylePriority.UsePadding = false;
        this.sum_thucnhap.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = this.sothapphan;
        xrSummary5.IgnoreNullValues = true;
        this.sum_thucnhap.Summary = xrSummary5;
        this.sum_thucnhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_thucnhap.Weight = 0.28241060759966446D;
        // 
        // sum_tongcong
        // 
        this.sum_tongcong.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_tongcong.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_tongcong.Multiline = true;
        this.sum_tongcong.Name = "sum_tongcong";
        this.sum_tongcong.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_tongcong.StylePriority.UseBorders = false;
        this.sum_tongcong.StylePriority.UseFont = false;
        this.sum_tongcong.StylePriority.UsePadding = false;
        this.sum_tongcong.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = this.sothapphan;
        xrSummary6.IgnoreNullValues = true;
        this.sum_tongcong.Summary = xrSummary6;
        this.sum_tongcong.Text = "x";
        this.sum_tongcong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.sum_tongcong.Weight = 0.28241060759959435D;
        // 
        // sum_thucxuat
        // 
        this.sum_thucxuat.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_thucxuat.Font = new System.Drawing.Font("Tahoma", 9F);
        this.sum_thucxuat.Name = "sum_thucxuat";
        this.sum_thucxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_thucxuat.StylePriority.UseBorders = false;
        this.sum_thucxuat.StylePriority.UseFont = false;
        this.sum_thucxuat.StylePriority.UsePadding = false;
        this.sum_thucxuat.StylePriority.UseTextAlignment = false;
        this.sum_thucxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_thucxuat.Weight = 0.28241063632794428D;
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
        this.xrTableCell3.Weight = 0.27360139191086996D;
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(669.639F, 47.89581F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(110F, 23F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "Người giao hàng";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel27
        // 
        this.xrLabel27.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(669.639F, 70.89584F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(110F, 23F);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.Text = "(Ký, họ tên)";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel26
        // 
        this.xrLabel26.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(355.0352F, 70.89584F);
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
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(355.0352F, 47.89581F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.Text = "TBP vật tư";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel20
        // 
        this.xrLabel20.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(174.7084F, 47.89581F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "Thủ kho";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel25
        // 
        this.xrLabel25.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(174.7084F, 70.89584F);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(130F, 23F);
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = "(Ký, họ tên)";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel23
        // 
        this.xrLabel23.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(21.62498F, 70.89584F);
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
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(21.62498F, 47.89581F);
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
        this.xrLabel31.LocationFloat = new DevExpress.Utils.PointFloat(3.000005F, 142.8333F);
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
            this.xrLabel46,
            this.yy_dmh,
            this.dd_dmh,
            this.xrLabel54,
            this.MM_dmh,
            this.xrLabel56,
            this.xrLabel51,
            this.xrLabel52,
            this.xrLabel50,
            this.xrLabel48,
            this.xrLabel40,
            this.xrLabel49,
            this.xrLabel41,
            this.sct_dmh,
            this.xrLabel43,
            this.sodonhang,
            this.kho,
            this.xrLabel39,
            this.nhacungcap,
            this.xrLabel38,
            this.xrLabel2,
            this.xrLabel1,
            this.dd,
            this.xrLabel44,
            this.xrLabel45,
            this.MM,
            this.xrLabel47,
            this.yyyy,
            this.xrLabel9,
            this.ncc2,
            this.phieugiaohang,
            this.xrLabel8,
            this.xrLabel4,
            this.xrTable4,
            this.xrLabel7});
        this.ReportHeader.HeightF = 201.6875F;
        this.ReportHeader.Name = "ReportHeader";
        this.ReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.ReportHeader.StylePriority.UsePadding = false;
        // 
        // xrLabel46
        // 
        this.xrLabel46.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(488.3332F, 132.6875F);
        this.xrLabel46.Name = "xrLabel46";
        this.xrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.xrLabel46.SizeF = new System.Drawing.SizeF(69.36865F, 22.99997F);
        this.xrLabel46.StylePriority.UseFont = false;
        this.xrLabel46.StylePriority.UsePadding = false;
        this.xrLabel46.StylePriority.UseTextAlignment = false;
        this.xrLabel46.Text = "của cơ sở:";
        this.xrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // yy_dmh
        // 
        this.yy_dmh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "yyyy_dmh", "{0:yyyy}")});
        this.yy_dmh.Font = new System.Drawing.Font("Tahoma", 9F);
        this.yy_dmh.LocationFloat = new DevExpress.Utils.PointFloat(451.1318F, 107.6874F);
        this.yy_dmh.Name = "yy_dmh";
        this.yy_dmh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.yy_dmh.SizeF = new System.Drawing.SizeF(36.7016F, 23F);
        this.yy_dmh.StylePriority.UseFont = false;
        this.yy_dmh.StylePriority.UseTextAlignment = false;
        this.yy_dmh.Text = "2019";
        this.yy_dmh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // dd_dmh
        // 
        this.dd_dmh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dd_dmh", "{0:dd}")});
        this.dd_dmh.Font = new System.Drawing.Font("Tahoma", 9F);
        this.dd_dmh.LocationFloat = new DevExpress.Utils.PointFloat(389.6185F, 107.6875F);
        this.dd_dmh.Name = "dd_dmh";
        this.dd_dmh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.dd_dmh.SizeF = new System.Drawing.SizeF(22F, 23F);
        this.dd_dmh.StylePriority.UseFont = false;
        this.dd_dmh.StylePriority.UseTextAlignment = false;
        this.dd_dmh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel54
        // 
        this.xrLabel54.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel54.LocationFloat = new DevExpress.Utils.PointFloat(412.3752F, 107.6874F);
        this.xrLabel54.Name = "xrLabel54";
        this.xrLabel54.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel54.SizeF = new System.Drawing.SizeF(8F, 23F);
        this.xrLabel54.StylePriority.UseFont = false;
        this.xrLabel54.StylePriority.UseTextAlignment = false;
        this.xrLabel54.Text = "/";
        this.xrLabel54.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // MM_dmh
        // 
        this.MM_dmh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MM_dmh", "{0:MM}")});
        this.MM_dmh.Font = new System.Drawing.Font("Tahoma", 9F);
        this.MM_dmh.LocationFloat = new DevExpress.Utils.PointFloat(420.3752F, 107.6875F);
        this.MM_dmh.Name = "MM_dmh";
        this.MM_dmh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.MM_dmh.SizeF = new System.Drawing.SizeF(22F, 23F);
        this.MM_dmh.StylePriority.UseFont = false;
        this.MM_dmh.StylePriority.UseTextAlignment = false;
        this.MM_dmh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel56
        // 
        this.xrLabel56.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel56.LocationFloat = new DevExpress.Utils.PointFloat(443.1318F, 107.6874F);
        this.xrLabel56.Name = "xrLabel56";
        this.xrLabel56.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel56.SizeF = new System.Drawing.SizeF(8F, 23F);
        this.xrLabel56.StylePriority.UseFont = false;
        this.xrLabel56.StylePriority.UseTextAlignment = false;
        this.xrLabel56.Text = "/";
        this.xrLabel56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel51
        // 
        this.xrLabel51.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel51.LocationFloat = new DevExpress.Utils.PointFloat(442.6316F, 132.6875F);
        this.xrLabel51.Name = "xrLabel51";
        this.xrLabel51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel51.SizeF = new System.Drawing.SizeF(8F, 23F);
        this.xrLabel51.StylePriority.UseFont = false;
        this.xrLabel51.StylePriority.UseTextAlignment = false;
        this.xrLabel51.Text = "/";
        this.xrLabel51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel52
        // 
        this.xrLabel52.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel52.LocationFloat = new DevExpress.Utils.PointFloat(419.875F, 132.6875F);
        this.xrLabel52.Name = "xrLabel52";
        this.xrLabel52.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel52.SizeF = new System.Drawing.SizeF(22F, 23F);
        this.xrLabel52.StylePriority.UseFont = false;
        this.xrLabel52.StylePriority.UseTextAlignment = false;
        this.xrLabel52.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel50
        // 
        this.xrLabel50.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel50.LocationFloat = new DevExpress.Utils.PointFloat(411.875F, 132.6875F);
        this.xrLabel50.Name = "xrLabel50";
        this.xrLabel50.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel50.SizeF = new System.Drawing.SizeF(8F, 23F);
        this.xrLabel50.StylePriority.UseFont = false;
        this.xrLabel50.StylePriority.UseTextAlignment = false;
        this.xrLabel50.Text = "/";
        this.xrLabel50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel48
        // 
        this.xrLabel48.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(389.1183F, 132.6875F);
        this.xrLabel48.Name = "xrLabel48";
        this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel48.SizeF = new System.Drawing.SizeF(22F, 23F);
        this.xrLabel48.StylePriority.UseFont = false;
        this.xrLabel48.StylePriority.UseTextAlignment = false;
        this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel40
        // 
        this.xrLabel40.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel40.LocationFloat = new DevExpress.Utils.PointFloat(258.4869F, 178.6875F);
        this.xrLabel40.Name = "xrLabel40";
        this.xrLabel40.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 2, 100F);
        this.xrLabel40.SizeF = new System.Drawing.SizeF(153.8818F, 23F);
        this.xrLabel40.StylePriority.UseFont = false;
        this.xrLabel40.StylePriority.UsePadding = false;
        this.xrLabel40.StylePriority.UseTextAlignment = false;
        this.xrLabel40.Text = "theo chi tiết sau:";
        this.xrLabel40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel49
        // 
        this.xrLabel49.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel49.LocationFloat = new DevExpress.Utils.PointFloat(493.5352F, 107.6875F);
        this.xrLabel49.Name = "xrLabel49";
        this.xrLabel49.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.xrLabel49.SizeF = new System.Drawing.SizeF(64.16663F, 22.99998F);
        this.xrLabel49.StylePriority.UseFont = false;
        this.xrLabel49.StylePriority.UsePadding = false;
        this.xrLabel49.StylePriority.UseTextAlignment = false;
        this.xrLabel49.Text = "ĐHTC:";
        this.xrLabel49.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel41
        // 
        this.xrLabel41.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel41.LocationFloat = new DevExpress.Utils.PointFloat(24.49989F, 107.6875F);
        this.xrLabel41.Name = "xrLabel41";
        this.xrLabel41.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 2, 100F);
        this.xrLabel41.SizeF = new System.Drawing.SizeF(185.6536F, 22.99999F);
        this.xrLabel41.StylePriority.UseFont = false;
        this.xrLabel41.StylePriority.UsePadding = false;
        this.xrLabel41.StylePriority.UseTextAlignment = false;
        this.xrLabel41.Text = "Căn cứ theo đơn mua HHVT số:";
        this.xrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // sct_dmh
        // 
        this.sct_dmh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sct_dmh")});
        this.sct_dmh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.sct_dmh.LocationFloat = new DevExpress.Utils.PointFloat(210.2019F, 107.6875F);
        this.sct_dmh.Name = "sct_dmh";
        this.sct_dmh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.sct_dmh.SizeF = new System.Drawing.SizeF(132.4999F, 22.99999F);
        this.sct_dmh.StylePriority.UseFont = false;
        this.sct_dmh.StylePriority.UseTextAlignment = false;
        this.sct_dmh.Text = "xuatcho";
        this.sct_dmh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel43
        // 
        this.xrLabel43.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel43.LocationFloat = new DevExpress.Utils.PointFloat(342.7018F, 107.6875F);
        this.xrLabel43.Name = "xrLabel43";
        this.xrLabel43.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.xrLabel43.SizeF = new System.Drawing.SizeF(46.41653F, 22.99999F);
        this.xrLabel43.StylePriority.UseFont = false;
        this.xrLabel43.StylePriority.UsePadding = false;
        this.xrLabel43.StylePriority.UseTextAlignment = false;
        this.xrLabel43.Text = "ngày";
        this.xrLabel43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // sodonhang
        // 
        this.sodonhang.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sodonhang")});
        this.sodonhang.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.sodonhang.LocationFloat = new DevExpress.Utils.PointFloat(557.7018F, 107.6875F);
        this.sodonhang.Name = "sodonhang";
        this.sodonhang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.sodonhang.SizeF = new System.Drawing.SizeF(238.7424F, 22.99999F);
        this.sodonhang.StylePriority.UseFont = false;
        this.sodonhang.StylePriority.UseTextAlignment = false;
        this.sodonhang.Text = "xuatcho";
        this.sodonhang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // kho
        // 
        this.kho.AutoWidth = true;
        this.kho.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "kho")});
        this.kho.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.kho.LocationFloat = new DevExpress.Utils.PointFloat(198.4868F, 178.6875F);
        this.kho.Name = "kho";
        this.kho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.kho.SizeF = new System.Drawing.SizeF(59.99995F, 23F);
        this.kho.StylePriority.UseFont = false;
        this.kho.StylePriority.UseTextAlignment = false;
        this.kho.Text = "khoxuat";
        this.kho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel39
        // 
        this.xrLabel39.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel39.LocationFloat = new DevExpress.Utils.PointFloat(25.00008F, 178.6875F);
        this.xrLabel39.Name = "xrLabel39";
        this.xrLabel39.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 2, 100F);
        this.xrLabel39.SizeF = new System.Drawing.SizeF(173.4868F, 23F);
        this.xrLabel39.StylePriority.UseFont = false;
        this.xrLabel39.StylePriority.UsePadding = false;
        this.xrLabel39.StylePriority.UseTextAlignment = false;
        this.xrLabel39.Text = "đã được giao và nhận tại kho:";
        this.xrLabel39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // nhacungcap
        // 
        this.nhacungcap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nhacungcap")});
        this.nhacungcap.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.nhacungcap.LocationFloat = new DevExpress.Utils.PointFloat(557.7018F, 132.6875F);
        this.nhacungcap.Name = "nhacungcap";
        this.nhacungcap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.nhacungcap.SizeF = new System.Drawing.SizeF(239.2426F, 23F);
        this.nhacungcap.StylePriority.UseFont = false;
        this.nhacungcap.StylePriority.UseTextAlignment = false;
        this.nhacungcap.Text = "ncc";
        this.nhacungcap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel38
        // 
        this.xrLabel38.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(451.6316F, 132.6875F);
        this.xrLabel38.Name = "xrLabel38";
        this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel38.SizeF = new System.Drawing.SizeF(36.7016F, 23F);
        this.xrLabel38.StylePriority.UseFont = false;
        this.xrLabel38.StylePriority.UseTextAlignment = false;
        this.xrLabel38.Text = "2019";
        this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(343.202F, 132.6875F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(45.91635F, 23F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UsePadding = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "ngày";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(110.8334F, 68.33331F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(99.32008F, 23F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UsePadding = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "........................";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
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
        this.xrLabel9.SizeF = new System.Drawing.SizeF(426.1317F, 23F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UsePadding = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Chúng tối, những người ký tên dưới đây xác nhận số lượng hàng của cơ sở:";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // ncc2
        // 
        this.ncc2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nhacungcap")});
        this.ncc2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.ncc2.LocationFloat = new DevExpress.Utils.PointFloat(451.6316F, 155.6875F);
        this.ncc2.Name = "ncc2";
        this.ncc2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ncc2.SizeF = new System.Drawing.SizeF(347.3686F, 23F);
        this.ncc2.StylePriority.UseFont = false;
        this.ncc2.StylePriority.UseTextAlignment = false;
        this.ncc2.Text = "ncc2";
        this.ncc2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // phieugiaohang
        // 
        this.phieugiaohang.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.phieugiaohang.LocationFloat = new DevExpress.Utils.PointFloat(258.4869F, 132.6875F);
        this.phieugiaohang.Name = "phieugiaohang";
        this.phieugiaohang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.phieugiaohang.SizeF = new System.Drawing.SizeF(84.21487F, 23F);
        this.phieugiaohang.StylePriority.UseFont = false;
        this.phieugiaohang.StylePriority.UseTextAlignment = false;
        this.phieugiaohang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Tahoma", 9F);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(25.0001F, 132.6875F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 2, 2, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(233.4867F, 23F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UsePadding = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Căn cứ theo phiếu giao hàng ( HĐ ) số:";
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
        this.xrTableCell11.Text = "PHIẾU XÁC NHẬN NHẬP VẬT TƯ";
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
        this.xrLabel3.Text = "MQL: SUP - 02";
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
        this.PageHeader.HeightF = 44.58333F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrLabel42
        // 
        this.xrLabel42.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel42.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel42.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel42.LocationFloat = new DevExpress.Utils.PointFloat(726.3397F, 0F);
        this.xrLabel42.Name = "xrLabel42";
        this.xrLabel42.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel42.SizeF = new System.Drawing.SizeF(72.66052F, 44.58333F);
        this.xrLabel42.StylePriority.UseBackColor = false;
        this.xrLabel42.StylePriority.UseBorders = false;
        this.xrLabel42.StylePriority.UseFont = false;
        this.xrLabel42.StylePriority.UseTextAlignment = false;
        this.xrLabel42.Text = "Ghi chú";
        this.xrLabel42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel17
        // 
        this.xrLabel17.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel17.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel17.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(576.3397F, 22.29167F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(75F, 22.29166F);
        this.xrLabel17.StylePriority.UseBackColor = false;
        this.xrLabel17.StylePriority.UseBorders = false;
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        this.xrLabel17.Text = "Đơn giá";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel16
        // 
        this.xrLabel16.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel16.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(501.3397F, 22.29167F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(75F, 22.29166F);
        this.xrLabel16.StylePriority.UseBackColor = false;
        this.xrLabel16.StylePriority.UseBorders = false;
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "Thực nhập";
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
        this.xrLabel12.SizeF = new System.Drawing.SizeF(81.33334F, 44.58333F);
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
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(110.8334F, 0F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(99.32002F, 44.58333F);
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
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(210.1535F, 0F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(94.55495F, 44.58333F);
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
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(304.7084F, 0F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(35F, 44.58333F);
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
        this.xrLabel19.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrLabel19.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(339.7084F, 0F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(386.6313F, 22.29166F);
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
        this.xrLabel32.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel32.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(339.7084F, 22.29167F);
        this.xrLabel32.Name = "xrLabel32";
        this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel32.SizeF = new System.Drawing.SizeF(81.1665F, 22.29166F);
        this.xrLabel32.StylePriority.UseBackColor = false;
        this.xrLabel32.StylePriority.UseBorders = false;
        this.xrLabel32.StylePriority.UseFont = false;
        this.xrLabel32.StylePriority.UseTextAlignment = false;
        this.xrLabel32.Text = "Chứng từ";
        this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel33
        // 
        this.xrLabel33.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel33.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel33.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel33.LocationFloat = new DevExpress.Utils.PointFloat(420.8749F, 22.29167F);
        this.xrLabel33.Name = "xrLabel33";
        this.xrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel33.SizeF = new System.Drawing.SizeF(80.46484F, 22.29166F);
        this.xrLabel33.StylePriority.UseBackColor = false;
        this.xrLabel33.StylePriority.UseBorders = false;
        this.xrLabel33.StylePriority.UseFont = false;
        this.xrLabel33.StylePriority.UseTextAlignment = false;
        this.xrLabel33.Text = "Được nhập";
        this.xrLabel33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel34
        // 
        this.xrLabel34.BackColor = System.Drawing.Color.Transparent;
        this.xrLabel34.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel34.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(651.3397F, 22.29167F);
        this.xrLabel34.Name = "xrLabel34";
        this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel34.SizeF = new System.Drawing.SizeF(75F, 22.29166F);
        this.xrLabel34.StylePriority.UseBackColor = false;
        this.xrLabel34.StylePriority.UseBorders = false;
        this.xrLabel34.StylePriority.UseFont = false;
        this.xrLabel34.StylePriority.UseTextAlignment = false;
        this.xrLabel34.Text = "Thành tiền";
        this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // phieuXNNhapVatTu
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

