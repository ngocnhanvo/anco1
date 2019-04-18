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

public partial class PrintControllers_MD_00_BaoCaoXNTon_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityContext db = new EntityContext();
        TonKhoSL report = new TonKhoSL();
        String sql = this.CreateSql();
        this.viewReport(report, sql);
		//Response.Write(sql);
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
		
		string ntc = context.Request.QueryString["ntc"];
		string ky_ = context.Request.QueryString["ky"];
		
		string md_namtaichinh_id = db.md_namtaichinh.Where(s => s.giatri.ToString() == ntc).Select(s => s.md_namtaichinh_id).FirstOrDefault();
		md_namtaichinh_ky ky = db.md_namtaichinh_ky.Where(s => s.md_namtaichinh_id == md_namtaichinh_id & s.soky.ToString() == ky_).FirstOrDefault();
		
		string kho = context.Request.QueryString["kho"];
		string where_ex = "";

		string sql = string.Format(@"
		select A.ma_sp, A.kho, A.ten_sp, A.dvt, sum(isnull(A.sl_dauky,0)) as sl, 
		sum(isnull(A.sl_nhaptrongky,0)) as sl_nhap, sum(isnull(A.sl_xuattrongky, 0)) as sl_xuat,
		sum(isnull(A.sl_cuoiky, 0)) as sl_cuoi, (N'Từ ngày ' + N'{1}' + N' đến ngày ' + N'{2}') as ngay
		from (
		SELECT	sp.ma_sanpham AS ma_sp,
				sp.mota_tiengviet AS ten_sp,
				dvt.ten_dvt AS dvt,
				kho.ten_kho AS kho,
				isnull((select top 1 thk.sl_dauky where ky.ngaybatdau = CONVERT(datetime,N'{1}',103)), 0) as sl_dauky,
				thk.sl_nhaptrongky as sl_nhaptrongky,
				thk.sl_xuattrongky as sl_xuattrongky,
				isnull((select top 1 isnull(thk.sl_cuoiky, 0) where ky.ngayketthuc = CONVERT(datetime,N'{2}' + N' 23:59',103)), 0) as sl_cuoiky

		FROM md_tonghopkho thk
		LEFT JOIN md_kho kho ON thk.md_kho_id = kho.md_kho_id
		LEFT join md_sanpham sp ON thk.md_sanpham_id = sp.md_sanpham_id
		LEFT JOIN md_donvitinhsanpham dvt ON dvt.md_donvitinhsanpham_id = thk.md_donvitinhsanpham_id
		inner join md_namtaichinh_ky ky on ky.md_namtaichinh_ky_id = thk.md_namtaichinh_ky_id 
		and (
			ky.ngaybatdau >= CONVERT(datetime,N'{1}',103) and
			ky.ngayketthuc <= CONVERT(datetime,N'{2}' + N' 23:59',103)
		)
		WHERE kho.md_kho_id = '{0}'
		)A
		group by A.ma_sp, A.kho, A.ten_sp, A.dvt
		order by A.ma_sp
		",kho ,ky.ngaybatdau.Value.ToString("dd/MM/yyyy") ,ky.ngayketthuc.Value.ToString("dd/MM/yyyy"));		
		return sql;
    }
}

/// <summary>
/// Summary description for TonKhoSL
/// </summary>
public class TonKhoSL : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel kho;
    private XRLabel xrLabel4;
    private XRLabel ngay;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell ma_sp;
    private XRTableCell ten_sp;
    private XRTableCell dvt;
    private XRTableCell sl;
    private XRTableCell sl_nhap;
    private XRTableCell sl_xuat;
    private XRTableCell sl_cuoi;
    private ReportFooterBand ReportFooter;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell tong_sl;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRTableCell tong_sl_nhap;
    private XRTableCell tong_sl_xuat;
    private XRTableCell tong_sl_cuoi;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public TonKhoSL()
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
        string resourceFileName = "rpt_socongnochi.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma_sp = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten_sp = new DevExpress.XtraReports.UI.XRTableCell();
        this.dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_nhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_xuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_cuoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.kho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.ngay = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl_nhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl_xuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl_cuoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
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
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(1.000015F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(807F, 25F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UsePadding = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.ma_sp,
            this.ten_sp,
            this.dvt,
            this.sl,
            this.sl_nhap,
            this.sl_xuat,
            this.sl_cuoi});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell9.Summary = xrSummary1;
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell9.Weight = 0.17246227634309364D;
        // 
        // ma_sp
        // 
        this.ma_sp.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ma_sp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma_sp")});
        this.ma_sp.Name = "ma_sp";
        this.ma_sp.StylePriority.UseBorders = false;
        this.ma_sp.Weight = 0.40335214965986721D;
        // 
        // ten_sp
        // 
        this.ten_sp.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ten_sp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ten_sp")});
        this.ten_sp.Name = "ten_sp";
        this.ten_sp.StylePriority.UseBorders = false;
        this.ten_sp.Weight = 1.0992287139858183D;
        // 
        // dvt
        // 
        this.dvt.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.dvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dvt")});
        this.dvt.Name = "dvt";
        this.dvt.StylePriority.UseBorders = false;
        this.dvt.StylePriority.UseTextAlignment = false;
        this.dvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.dvt.Weight = 0.16158026557964389D;
        // 
        // sl
        // 
        this.sl.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl", "{0:#,#0.00}")});
        this.sl.Name = "sl";
        this.sl.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.sl.StylePriority.UseBorders = false;
        this.sl.StylePriority.UsePadding = false;
        this.sl.StylePriority.UseTextAlignment = false;
        this.sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl.Weight = 0.29244995937147972D;
        // 
        // sl_nhap
        // 
        this.sl_nhap.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.sl_nhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_nhap", "{0:#,#0.00}")});
        this.sl_nhap.Name = "sl_nhap";
        this.sl_nhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.sl_nhap.StylePriority.UseBorders = false;
        this.sl_nhap.StylePriority.UsePadding = false;
        this.sl_nhap.StylePriority.UseTextAlignment = false;
        this.sl_nhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_nhap.Weight = 0.30028216434346544D;
        // 
        // sl_xuat
        // 
        this.sl_xuat.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.sl_xuat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_xuat", "{0:#,#0.00}")});
        this.sl_xuat.Name = "sl_xuat";
        this.sl_xuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.sl_xuat.StylePriority.UseBorders = false;
        this.sl_xuat.StylePriority.UsePadding = false;
        this.sl_xuat.StylePriority.UseTextAlignment = false;
        this.sl_xuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_xuat.Weight = 0.31594571267341642D;
        // 
        // sl_cuoi
        // 
        this.sl_cuoi.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.sl_cuoi.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_cuoi", "{0:#,#0.00}")});
        this.sl_cuoi.Name = "sl_cuoi";
        this.sl_cuoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.sl_cuoi.StylePriority.UseBorders = false;
        this.sl_cuoi.StylePriority.UsePadding = false;
        this.sl_cuoi.StylePriority.UseTextAlignment = false;
        this.sl_cuoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_cuoi.Weight = 0.28853324128212904D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 1F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel2,
            this.kho,
            this.xrLabel4,
            this.ngay});
        this.ReportHeader.HeightF = 97.99999F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel1
        // 
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(1F, 2F);
        this.xrLabel1.Multiline = true;
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(248.9583F, 46.95834F);
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "CTY TNHH ANCO BINH DUONG\r\nXƯỞNG ANCO 1\r\nMã số thuế  :  3700318266";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(529.5001F, 1.999998F);
        this.xrLabel2.Multiline = true;
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(96.87494F, 36.54167F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "TÊN KHO:";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // kho
        // 
        this.kho.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "kho")});
        this.kho.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.kho.LocationFloat = new DevExpress.Utils.PointFloat(626.3751F, 1.999998F);
        this.kho.Multiline = true;
        this.kho.Name = "kho";
        this.kho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.kho.SizeF = new System.Drawing.SizeF(181.6249F, 36.54168F);
        this.kho.StylePriority.UseFont = false;
        this.kho.StylePriority.UseTextAlignment = false;
        this.kho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(1.000016F, 52F);
        this.xrLabel4.Multiline = true;
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(807F, 23F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "SỔ TỔNG HỢP NHẬP XUẤT TỒN KHO";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // ngay
        // 
        this.ngay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngay")});
        this.ngay.LocationFloat = new DevExpress.Utils.PointFloat(1.000016F, 74.99999F);
        this.ngay.Multiline = true;
        this.ngay.Name = "ngay";
        this.ngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ngay.SizeF = new System.Drawing.SizeF(807F, 23F);
        this.ngay.StylePriority.UseTextAlignment = false;
        this.ngay.Text = "Từ ngày:                   Đến ngày:";
        this.ngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9});
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(1.000015F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(807F, 25F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UsePadding = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.tong_sl,
            this.tong_sl_nhap,
            this.tong_sl_xuat,
            this.tong_sl_cuoi});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseBorders = false;
        this.xrTableCell10.Weight = 0.17246227419861093D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseBorders = false;
        this.xrTableCell11.Weight = 0.40335217343617613D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseBorders = false;
        this.xrTableCell12.StylePriority.UseFont = false;
        this.xrTableCell12.Text = "TỔNG CỘNG";
        this.xrTableCell12.Weight = 1.2608090738860185D;
        // 
        // tong_sl
        // 
        this.tong_sl.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl")});
        this.tong_sl.Name = "tong_sl";
        this.tong_sl.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_sl.StylePriority.UseBorders = false;
        this.tong_sl.StylePriority.UsePadding = false;
        this.tong_sl.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:#,#0.00}";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl.Summary = xrSummary2;
        this.tong_sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl.Weight = 0.29244972168611094D;
        // 
        // tong_sl_nhap
        // 
        this.tong_sl_nhap.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl_nhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_nhap")});
        this.tong_sl_nhap.Name = "tong_sl_nhap";
        this.tong_sl_nhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_sl_nhap.StylePriority.UseBorders = false;
        this.tong_sl_nhap.StylePriority.UsePadding = false;
        this.tong_sl_nhap.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:#,#0.00}";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl_nhap.Summary = xrSummary3;
        this.tong_sl_nhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl_nhap.Weight = 0.30028195484812192D;
        // 
        // tong_sl_xuat
        // 
        this.tong_sl_xuat.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl_xuat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_xuat")});
        this.tong_sl_xuat.Name = "tong_sl_xuat";
        this.tong_sl_xuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_sl_xuat.StylePriority.UseBorders = false;
        this.tong_sl_xuat.StylePriority.UsePadding = false;
        this.tong_sl_xuat.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:#,#0.00}";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl_xuat.Summary = xrSummary4;
        this.tong_sl_xuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl_xuat.Weight = 0.31594596262656549D;
        // 
        // tong_sl_cuoi
        // 
        this.tong_sl_cuoi.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl_cuoi.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_cuoi")});
        this.tong_sl_cuoi.Name = "tong_sl_cuoi";
        this.tong_sl_cuoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_sl_cuoi.StylePriority.UseBorders = false;
        this.tong_sl_cuoi.StylePriority.UsePadding = false;
        this.tong_sl_cuoi.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:#,#0.00}";
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl_cuoi.Summary = xrSummary5;
        this.tong_sl_cuoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl_cuoi.Weight = 0.28853337738361623D;
        // 
        // xrLabel6
        // 
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(558.6113F, 25.50001F);
        this.xrLabel6.Multiline = true;
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(249.3888F, 23F);
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "Ngày .......  tháng ........ năm ......";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0.9999695F, 48.5F);
        this.xrLabel7.Multiline = true;
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(266F, 23F);
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Người lập\r\n";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel8
        // 
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(266.9999F, 48.49999F);
        this.xrLabel8.Multiline = true;
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(275.0001F, 23F);
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Kế toán \r\n";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel9
        // 
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(542.0001F, 48.49999F);
        this.xrLabel9.Multiline = true;
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(266F, 23F);
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Ban  Giám đốc\r\n";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 25F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(807.0001F, 25F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UsePadding = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.Text = "STT";
        this.xrTableCell8.Weight = 0.15812714584020859D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseBorders = false;
        this.xrTableCell1.Text = "Mã VTHH";
        this.xrTableCell1.Weight = 0.36982529865201819D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseBorders = false;
        this.xrTableCell2.Text = "Tên VTHH";
        this.xrTableCell2.Weight = 1.0078601352436922D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.Text = "ĐVT";
        this.xrTableCell3.Weight = 0.14814972499427381D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.Text = "Tồn đầu";
        this.xrTableCell7.Weight = 0.26814112088074932D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.Text = "Nhập";
        this.xrTableCell4.Weight = 0.27532233940628631D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.Text = "Xuất";
        this.xrTableCell5.Weight = 0.289684345839877D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.Text = "Tồn cuối";
        this.xrTableCell6.Weight = 0.26455075094742159D;
        // 
        // TonKhoSL
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageHeader});
        this.Margins = new System.Drawing.Printing.Margins(7, 12, 1, 100);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "15.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}
