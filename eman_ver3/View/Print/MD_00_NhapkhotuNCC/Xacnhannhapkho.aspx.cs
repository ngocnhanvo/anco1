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
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

public partial class PrintControllers_MD_00_NhapkhotuNCC_Xacnhannhapkho : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityContext db = new EntityContext();
        rptPhieuXNNhapKhoNCC report = new rptPhieuXNNhapKhoNCC();
        String sql = this.CreateSql();
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

    public String CreateSql()
    {
		HttpContext context = HttpContext.Current;
		EntityContext db = new EntityContext();
		string md_nhapkho_ncc_id = context.Request.QueryString["md_nhapkho_ncc_id"];
		string khoden = context.Request.QueryString["khoden"];
		c_donmuahang dmh = db.c_donmuahang.Where(s=>s.c_donmuahang_id == md_nhapkho_ncc_id).Take(1).FirstOrDefault(); 
		md_doitackinhdoanh dtkd = db.md_doitackinhdoanh.Where(s=>s.md_doitackinhdoanh_id == dmh.md_doitackinhdoanh_id).Take(1).FirstOrDefault();
		//N'Chúng tôi, những người ký tên bên dưới xác nhận hàng dưới đây đã được giao và nhận tại {4} theo chi tiết sau'
		string sql = string.Format(@"
		select sp.ma_sanpham as ma_vthh, sp.mota_tiengviet as ten_vthh, 
		dvtsp.ten_dvt as dvt, [dbo].[autoround]((nk_ncc_dh.sl_dadat - nk_ncc_dh.sl_hanngach), ',' , '.') as duocnhap, '' as thucnhap,
		'' as quycach, 
		N'{1}' as today, N'{2}' as sochungtu, N'{3}' as ma_dtkd, N'Chúng tôi, những người ký tên bên dưới xác nhận hàng dưới đây đã được giao và nhận tại {4} theo chi tiết sau' as khoden, 
		N'{5}' as sct_dmvt, N'{6}' as ngaymuahang, dmh.donhang_thamchieu as dhtc
		from c_donmuahang_cdmh nk_ncc_dh
		left join md_sanpham sp on nk_ncc_dh.md_sanpham_id = sp.md_sanpham_id
		left join md_donvitinhsanpham dvtsp on sp.md_donvitinhsanpham_id = dvtsp.md_donvitinhsanpham_id
		left join c_donmuahang dmh on dmh.c_donmuahang_id = nk_ncc_dh.c_donmuahang_id
		where nk_ncc_dh.c_donmuahang_id = '{0}' order by sp.ma_sanpham asc
		",md_nhapkho_ncc_id, DateTime.Now.ToString("dd-MM-yyyy"), "", dtkd.ten_dtkd, khoden, dmh.sochungtu,
		dmh.ngaydonhang.Value.ToString("dd-MM-yyyy"));
		return sql;
    }
}

/// <summary>
/// Summary description for rptPhieuXNNhapKhoNCC
/// </summary>
public class rptPhieuXNNhapKhoNCC : DevExpress.XtraReports.UI.XtraReport
{
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
    private XRTableCell duocnhap;
    private XRTableCell thucnhap;
    private XRTableCell ghichu;
    private ReportFooterBand ReportFooter;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell20;
    private XRTableCell sum_soluong;
    private XRTableCell sum_dongia;
    private XRTableCell sum_thanhtien;
    private XRLabel xrLabel26;
    private XRLabel xrLabel21;
    private XRLabel xrLabel20;
    private XRLabel xrLabel25;
    private XRLabel xrLabel23;
    private XRLabel xrLabel18;
    private XRLabel xrLabel9;
    private ReportHeaderBand ReportHeader;
    private XRLabel khoden;
    private XRLabel today;
    private XRLabel xrLabel4;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel sochungtu;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel ma_dtkd;
    private XRLabel xrLabel15;
    private XRLabel xrLabel14;
    private XRLabel ngaymuahang;
    private XRLabel xrLabel11;
    private XRLabel xrLabel10;
    private XRLabel xrLabel28;
    private XRLabel xrLabel24;
    private XRLabel xrLabel19;
    private XRLabel sct_dmvt;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell2;
    private XRLabel xrLabel17;
    private XRLabel xrLabel16;
    private XRLabel xrLabel12;
    private XRTableCell xrTableCell9;
    private XRLabel xrLabel22;
    private XRLabel xrLabel27;
    private XRLabel xrLabel29;
    private XRLabel xrLabel36;
    private XRLabel xrLabel3;
    private XRLabel dhtc;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rptPhieuXNNhapKhoNCC()
    {
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
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma_vthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten_vthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.quycach = new DevExpress.XtraReports.UI.XRTableCell();
        this.dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.duocnhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.thucnhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.ghichu = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_soluong = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_dongia = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.dhtc = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel36 = new DevExpress.XtraReports.UI.XRLabel();
        this.sct_dmvt = new DevExpress.XtraReports.UI.XRLabel();
        this.ma_dtkd = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.ngaymuahang = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.khoden = new DevExpress.XtraReports.UI.XRLabel();
        this.today = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.sochungtu = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(4.499849F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(795.5002F, 25F);
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
            this.duocnhap,
            this.thucnhap,
            this.ghichu});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.StylePriority.UsePadding = false;
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell7.Summary = xrSummary1;
        this.xrTableCell7.Text = "xrTableCell3";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 0.137815660234961D;
        // 
        // ma_vthh
        // 
        this.ma_vthh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma_vthh")});
        this.ma_vthh.Name = "ma_vthh";
        this.ma_vthh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.ma_vthh.StylePriority.UsePadding = false;
        this.ma_vthh.Weight = 0.401415117735925D;
        // 
        // ten_vthh
        // 
        this.ten_vthh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ten_vthh")});
        this.ten_vthh.Name = "ten_vthh";
        this.ten_vthh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.ten_vthh.StylePriority.UsePadding = false;
        this.ten_vthh.StylePriority.UseTextAlignment = false;
        this.ten_vthh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.ten_vthh.Weight = 0.581493338501656D;
        // 
        // quycach
        // 
        this.quycach.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "quycach")});
        this.quycach.Name = "quycach";
        this.quycach.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.quycach.StylePriority.UsePadding = false;
        this.quycach.Weight = 0.601866987225009D;
        // 
        // dvt
        // 
        this.dvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dvt")});
        this.dvt.Name = "dvt";
        this.dvt.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.dvt.StylePriority.UsePadding = false;
        this.dvt.StylePriority.UseTextAlignment = false;
        this.dvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.dvt.Weight = 0.209215994063713D;
        // 
        // duocnhap
        // 
        this.duocnhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "duocnhap")});
        this.duocnhap.Name = "duocnhap";
        this.duocnhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.duocnhap.StylePriority.UsePadding = false;
        this.duocnhap.StylePriority.UseTextAlignment = false;
        this.duocnhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.duocnhap.Weight = 0.295370491356243D;
        // 
        // thucnhap
        // 
        this.thucnhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thucnhap")});
        this.thucnhap.Name = "thucnhap";
        this.thucnhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.thucnhap.StylePriority.UsePadding = false;
        this.thucnhap.StylePriority.UseTextAlignment = false;
        this.thucnhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.thucnhap.Weight = 0.32607430235297D;
        // 
        // ghichu
        // 
        this.ghichu.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ghichu")});
        this.ghichu.Name = "ghichu";
        this.ghichu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.ghichu.StylePriority.UsePadding = false;
        this.ghichu.Weight = 0.29460037783523896D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 3F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.HeightF = 2F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel22,
            this.xrLabel27,
            this.xrLabel28,
            this.xrLabel24,
            this.xrLabel19,
            this.xrLabel26,
            this.xrLabel21,
            this.xrLabel20,
            this.xrLabel25,
            this.xrLabel23,
            this.xrLabel18,
            this.xrLabel9,
            this.xrTable3});
        this.ReportFooter.HeightF = 189.5833F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(238.1667F, 125.8541F);
        this.xrLabel22.Multiline = true;
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(125.2222F, 23F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "NV kiểm tra vật tư";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel27
        // 
        this.xrLabel27.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(238.1667F, 148.8541F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(125.2222F, 23F);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.Text = "(Ký, họ tên)";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel28
        // 
        this.xrLabel28.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
        this.xrLabel28.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
        this.xrLabel28.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(4.50016F, 84.56253F);
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel28.SizeF = new System.Drawing.SizeF(795.4999F, 23.00001F);
        this.xrLabel28.StylePriority.UseBorderDashStyle = false;
        this.xrLabel28.StylePriority.UseBorders = false;
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.StylePriority.UsePadding = false;
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
        // 
        // xrLabel24
        // 
        this.xrLabel24.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
        this.xrLabel24.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
        this.xrLabel24.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(4.50016F, 61.5625F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(795.4999F, 23.00002F);
        this.xrLabel24.StylePriority.UseBorderDashStyle = false;
        this.xrLabel24.StylePriority.UseBorders = false;
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UsePadding = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
        // 
        // xrLabel19
        // 
        this.xrLabel19.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
        this.xrLabel19.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
        this.xrLabel19.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(160.625F, 38.56252F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(639.3751F, 23.00001F);
        this.xrLabel19.StylePriority.UseBorderDashStyle = false;
        this.xrLabel19.StylePriority.UseBorders = false;
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.StylePriority.UsePadding = false;
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
        // 
        // xrLabel26
        // 
        this.xrLabel26.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(673.7015F, 148.8541F);
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
        this.xrLabel21.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(673.7015F, 125.8541F);
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(114.5833F, 23F);
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.Text = "Người giao hàng";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel20
        // 
        this.xrLabel20.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(467.0972F, 125.8541F);
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "Thủ kho";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel25
        // 
        this.xrLabel25.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(467.0972F, 148.8541F);
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = "(Ký, họ tên)";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel23
        // 
        this.xrLabel23.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic);
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(55.12495F, 148.8541F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.Text = "(Ký, họ tên)";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel18
        // 
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(55.12495F, 125.8541F);
        this.xrLabel18.Multiline = true;
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(100F, 23F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "Người lập";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(4.500008F, 38.56249F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(156.125F, 23.00001F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UsePadding = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Đánh giá chất lượng vật tư:";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(4.5F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(795.5001F, 25F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13,
            this.xrTableCell20,
            this.sum_soluong,
            this.sum_dongia,
            this.sum_thanhtien});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell13.StylePriority.UseFont = false;
        this.xrTableCell13.StylePriority.UsePadding = false;
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "Tổng cộng";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell13.Weight = 1.72259048900425D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell20.StylePriority.UsePadding = false;
        this.xrTableCell20.Weight = 0.209215880128175D;
        // 
        // sum_soluong
        // 
        this.sum_soluong.Name = "sum_soluong";
        this.sum_soluong.Weight = 0.29537043217656D;
        // 
        // sum_dongia
        // 
        this.sum_dongia.Name = "sum_dongia";
        this.sum_dongia.Weight = 0.326074267434365D;
        // 
        // sum_thanhtien
        // 
        this.sum_thanhtien.Name = "sum_thanhtien";
        this.sum_thanhtien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sum_thanhtien.StylePriority.UsePadding = false;
        this.sum_thanhtien.Weight = 0.29460045350255742D;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.dhtc,
            this.xrLabel29,
            this.xrLabel36,
            this.sct_dmvt,
            this.ma_dtkd,
            this.xrLabel15,
            this.xrLabel14,
            this.ngaymuahang,
            this.xrLabel11,
            this.xrLabel10,
            this.khoden,
            this.today,
            this.xrLabel4,
            this.xrLabel1,
            this.xrLabel2,
            this.sochungtu,
            this.xrLabel5,
            this.xrLabel6,
            this.xrLabel7});
        this.ReportHeader.HeightF = 130.8127F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(517.4862F, 61.81253F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(60F, 23F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UsePadding = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "ĐHTC: ";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // dhtc
        // 
        this.dhtc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dhtc")});
        this.dhtc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.dhtc.LocationFloat = new DevExpress.Utils.PointFloat(577.4862F, 61.81254F);
        this.dhtc.Name = "dhtc";
        this.dhtc.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.dhtc.SizeF = new System.Drawing.SizeF(222.5139F, 23.00002F);
        this.dhtc.StylePriority.UseFont = false;
        this.dhtc.StylePriority.UsePadding = false;
        this.dhtc.StylePriority.UseTextAlignment = false;
        this.dhtc.Text = "ANCO1";
        this.dhtc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel29
        // 
        this.xrLabel29.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(606.25F, 0F);
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel29.SizeF = new System.Drawing.SizeF(193.75F, 38.54168F);
        this.xrLabel29.StylePriority.UseFont = false;
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        this.xrLabel29.Text = "Mẫu: 010/AC1";
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel36
        // 
        this.xrLabel36.LocationFloat = new DevExpress.Utils.PointFloat(2.708705F, 0.3125032F);
        this.xrLabel36.Multiline = true;
        this.xrLabel36.Name = "xrLabel36";
        this.xrLabel36.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel36.SizeF = new System.Drawing.SizeF(198.2498F, 37.49999F);
        this.xrLabel36.StylePriority.UseTextAlignment = false;
        this.xrLabel36.Text = "CTY ANCO BÌNH DƯƠNG\r\nXƯỞNG ANCO 1\r\n";
        this.xrLabel36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // sct_dmvt
        // 
        this.sct_dmvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sct_dmvt")});
        this.sct_dmvt.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.sct_dmvt.LocationFloat = new DevExpress.Utils.PointFloat(171.0001F, 61.81262F);
        this.sct_dmvt.Name = "sct_dmvt";
        this.sct_dmvt.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sct_dmvt.SizeF = new System.Drawing.SizeF(174.6805F, 23.00002F);
        this.sct_dmvt.StylePriority.UseFont = false;
        this.sct_dmvt.StylePriority.UsePadding = false;
        this.sct_dmvt.StylePriority.UseTextAlignment = false;
        this.sct_dmvt.Text = "Số:";
        this.sct_dmvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // ma_dtkd
        // 
        this.ma_dtkd.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma_dtkd")});
        this.ma_dtkd.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ma_dtkd.LocationFloat = new DevExpress.Utils.PointFloat(577.4861F, 84.81255F);
        this.ma_dtkd.Multiline = true;
        this.ma_dtkd.Name = "ma_dtkd";
        this.ma_dtkd.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.ma_dtkd.SizeF = new System.Drawing.SizeF(222.514F, 23.00003F);
        this.ma_dtkd.StylePriority.UseFont = false;
        this.ma_dtkd.StylePriority.UsePadding = false;
        this.ma_dtkd.StylePriority.UseTextAlignment = false;
        this.ma_dtkd.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel15
        // 
        this.xrLabel15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(517.4862F, 84.81255F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(60F, 23.00002F);
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UsePadding = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "NCC: ";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(392.1668F, 84.81252F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(125.3193F, 23.00002F);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UsePadding = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // ngaymuahang
        // 
        this.ngaymuahang.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngaymuahang", "{0:dd/MM/yyyy}")});
        this.ngaymuahang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ngaymuahang.LocationFloat = new DevExpress.Utils.PointFloat(392.1668F, 61.81253F);
        this.ngaymuahang.Name = "ngaymuahang";
        this.ngaymuahang.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.ngaymuahang.SizeF = new System.Drawing.SizeF(125.3193F, 23.00001F);
        this.ngaymuahang.StylePriority.UseFont = false;
        this.ngaymuahang.StylePriority.UsePadding = false;
        this.ngaymuahang.StylePriority.UseTextAlignment = false;
        this.ngaymuahang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(345.6808F, 84.81264F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(46.48605F, 23.00002F);
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UsePadding = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.Text = "Ngày: ";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(345.6807F, 61.81262F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(46.48608F, 23.00001F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UsePadding = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Ngày: ";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // khoden
        // 
        this.khoden.AutoWidth = true;
        this.khoden.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "khoden")});
        this.khoden.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.khoden.LocationFloat = new DevExpress.Utils.PointFloat(1.37516F, 107.8126F);
        this.khoden.Name = "khoden";
        this.khoden.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.khoden.SizeF = new System.Drawing.SizeF(798.6249F, 23.00002F);
        this.khoden.StylePriority.UseFont = false;
        this.khoden.StylePriority.UsePadding = false;
        this.khoden.StylePriority.UseTextAlignment = false;
        this.khoden.Text = "s";
        this.khoden.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // today
        // 
        this.today.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "today", "{0:dd/MM/yyyy}")});
        this.today.LocationFloat = new DevExpress.Utils.PointFloat(678.2501F, 38.8125F);
        this.today.Name = "today";
        this.today.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.today.SizeF = new System.Drawing.SizeF(121.7499F, 23.00001F);
        this.today.StylePriority.UseTextAlignment = false;
        this.today.Text = "today";
        this.today.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(628.2501F, 38.81256F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(50F, 23.00001F);
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Ngày in";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1.375167F, 61.81253F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(169.6249F, 23.00002F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UsePadding = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "Căn cứ theo ĐĐM vật tư số:";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel2.ForeColor = System.Drawing.Color.RoyalBlue;
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(200.9585F, 0.3125F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(405.2915F, 37.49999F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseForeColor = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "PHIẾU XÁC NHẬN NHẬP KHO";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // sochungtu
        // 
        this.sochungtu.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sochungtu")});
        this.sochungtu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.sochungtu.LocationFloat = new DevExpress.Utils.PointFloat(348.8058F, 38.81251F);
        this.sochungtu.Name = "sochungtu";
        this.sochungtu.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sochungtu.SizeF = new System.Drawing.SizeF(234.3054F, 23.00002F);
        this.sochungtu.StylePriority.UseFont = false;
        this.sochungtu.StylePriority.UsePadding = false;
        this.sochungtu.StylePriority.UseTextAlignment = false;
        this.sochungtu.Text = "ANCO1";
        this.sochungtu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(1.375167F, 84.81252F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(205.0416F, 23.00002F);
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UsePadding = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Căn cứ theo phiếu giao hàng(HĐ):";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(238.8056F, 38.81257F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(110.0002F, 23.00001F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UsePadding = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "Số:";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(206.4168F, 84.81252F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(139.2638F, 23.00001F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UsePadding = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 46F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(4.500166F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(795.4999F, 46F);
        this.xrTable1.StylePriority.UseBackColor = false;
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell5,
            this.xrTableCell4,
            this.xrTableCell6,
            this.xrTableCell3,
            this.xrTableCell2,
            this.xrTableCell9});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseBorders = false;
        this.xrTableCell1.Text = "STT";
        this.xrTableCell1.Weight = 0.137987225369137D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Text = "Mã VTHH";
        this.xrTableCell5.Weight = 0.401913377902641D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Text = "Tên VTHH / Mô tả";
        this.xrTableCell4.Weight = 0.582217598070405D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Text = "Quy cách";
        this.xrTableCell6.Weight = 0.602616506178568D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Text = "ĐVT";
        this.xrTableCell3.Weight = 0.209476425523556D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel17,
            this.xrLabel16,
            this.xrLabel12});
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.Weight = 0.62221833073842D;
        // 
        // xrLabel17
        // 
        this.xrLabel17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(82.50662F, 22.99999F);
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(91.08344F, 23F);
        this.xrLabel17.StylePriority.UseBorders = false;
        this.xrLabel17.Text = "Thực nhập";
        // 
        // xrLabel16
        // 
        this.xrLabel16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(0F, 22.99998F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(82.5069F, 23F);
        this.xrLabel16.StylePriority.UseBorders = false;
        this.xrLabel16.Text = "Được nhập";
        // 
        // xrLabel12
        // 
        this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(5.340576E-05F, 0F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(173.5902F, 23F);
        this.xrLabel12.StylePriority.UseBorders = false;
        this.xrLabel12.Text = "Số lượng";
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Text = "Ghi chú";
        this.xrTableCell9.Weight = 0.29496659352900351D;
        // 
        // rptPhieuXNNhapKhoNCC
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader,
            this.PageHeader});
        this.Margins = new System.Drawing.Printing.Margins(24, 26, 3, 2);
        this.Version = "17.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}

