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

public partial class PrintControllers_MD_01_ToSanXuat_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityContext db = new EntityContext();
        LenhSanXuat report = new LenhSanXuat();
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
		string md_lenhsanxuat_id = context.Request.QueryString["id"];	
		string dec = context.Request.QueryString["dec"];	
		string thous = context.Request.QueryString["thous"];	
		string sql = string.Format(@"
		select getdate() as ngay
		,N'Số: '+ lsx.sochungtu as so,dcht.sochungtu + char(13) + char(13) + dcht.donhang_thamchieu as dhtc, lsx.ngaylap as batdau, lsx.ngayketthuc as ketthuc, tosx.ngaydkht as hoantat
		, sp.ma_sanpham as ma, sp.mota_tiengviet as ten, dvt.ten_dvt as dvt, sp.noigiaohang as noigiaohang
		, dbo.autoround(tosx_cdh.sl_dat, '{1}', '{2}') as sl_dat
		, dbo.autoround(tosx_cdh.sl_chiato, '{1}', '{2}') as sl_chia
		, px.ten_phanxuong as xuong ,px_to.ten_to as tosx
		 from md_lenhsanxuat_tosx tosx
		 left join md_lenhsanxuat lsx on lsx.md_lenhsanxuat_id = tosx.md_lenhsanxuat_id
		 left join md_lenhsanxuat_tosx_cdh tosx_cdh on tosx_cdh.md_lenhsanxuat_tosx_id = tosx.md_lenhsanxuat_tosx_id
		 left join md_sanpham sp on sp.md_sanpham_id = tosx_cdh.md_sanpham_id
		 left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = tosx_cdh.md_donvitinhsanpham_id
		 left join md_phanxuong px on px.md_phanxuong_id = lsx.md_phanxuong_id
		 left join md_phanxuong_to px_to on px_to.md_to_id = tosx.md_phanxuong_to_id
		 left join md_dondathangphanxuong dcht on dcht.md_dondathangphanxuong_id = lsx.md_dondathangphanxuong_id
		 where tosx.md_lenhsanxuat_id = '{0}' order by sp.ma_sanpham asc
		",md_lenhsanxuat_id, dec, thous);
		return sql;
    }
}

/// <summary>
/// Summary description for LenhSanXuat
/// </summary>
public class LenhSanXuat : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel18;
    private XRLabel ketthuc;
    private XRLabel hoantat;
    private XRLabel xrLabel16;
    private XRLabel batdau;
    private XRLabel xrLabel12;
    private XRLabel xrLabel10;
    private XRLabel xuong;
    private XRLabel xrLabel8;
    private XRLabel so;
    private XRLabel ngay;
    private XRLabel xrLabel3;
    private XRLabel xrLabel2;
    private XRLabel dhtc;
    private XRLabel xrLabel22;
    private XRLabel xrLabel4;
    private XRLabel tosx;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel23;
    private XRLabel xrLabel24;
    private XRLabel xrLabel25;
    private XRLabel xrLabel26;
    private XRLabel xrLabel28;
    private XRLabel xrLabel7;
    private XRLabel xrLabel11;
    private XRLabel xrLabel13;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell1;
    private XRTableCell ma;
    private XRTableCell ten;
    private XRTableCell noigiaohang;
    private XRTableCell dvt;
    private XRTableCell sl_dat;
    private XRTableCell sl_chia;
    private XRTableCell xrTableCell8;
    private XRLabel xrLabel6;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public LenhSanXuat()
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
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten = new DevExpress.XtraReports.UI.XRTableCell();
        this.noigiaohang = new DevExpress.XtraReports.UI.XRTableCell();
        this.dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_dat = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_chia = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.tosx = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.ketthuc = new DevExpress.XtraReports.UI.XRLabel();
        this.hoantat = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.batdau = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xuong = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.so = new DevExpress.XtraReports.UI.XRLabel();
        this.ngay = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.dhtc = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.Detail.HeightF = 25F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable1
        // 
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(749.9999F, 25F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UsePadding = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.ma,
            this.ten,
            this.noigiaohang,
            this.dvt,
            this.sl_dat,
            this.sl_chia,
            this.xrTableCell8});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell1.Summary = xrSummary1;
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.445833282470703D;
        // 
        // ma
        // 
        this.ma.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma")});
        this.ma.Name = "ma";
        this.ma.Weight = 1.05778495788574D;
        // 
        // ten
        // 
        this.ten.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ten")});
        this.ten.Name = "ten";
        this.ten.Weight = 1.89408992767334D;
        // 
        // noigiaohang
        // 
        this.noigiaohang.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "noigiaohang")});
        this.noigiaohang.Name = "noigiaohang";
        this.noigiaohang.Weight = 1.0395849418640153D;
        // 
        // dvt
        // 
        this.dvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dvt")});
        this.dvt.Name = "dvt";
        this.dvt.StylePriority.UseTextAlignment = false;
        this.dvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.dvt.Weight = 0.38541411399841274D;
        // 
        // sl_dat
        // 
        this.sl_dat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_dat")});
        this.sl_dat.Name = "sl_dat";
        this.sl_dat.StylePriority.UseTextAlignment = false;
        this.sl_dat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_dat.Weight = 0.85645968914032011D;
        // 
        // sl_chia
        // 
        this.sl_chia.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_chia")});
        this.sl_chia.Name = "sl_chia";
        this.sl_chia.StylePriority.UseTextAlignment = false;
        this.sl_chia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_chia.Weight = 0.72833310842514054D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.Weight = 1.0924993681907613D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 0F;
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
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel6,
            this.xrLabel4,
            this.tosx,
            this.xrLabel1,
            this.xrLabel18,
            this.ketthuc,
            this.hoantat,
            this.xrLabel16,
            this.batdau,
            this.xrLabel12,
            this.xrLabel10,
            this.xuong,
            this.xrLabel8,
            this.so,
            this.ngay,
            this.xrLabel3,
            this.xrLabel2,
            this.dhtc,
            this.xrLabel22});
        this.ReportHeader.HeightF = 191.5208F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel6
        // 
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel6.Multiline = true;
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(193.75F, 38.54167F);
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "CTY ANCO BÌNH DƯƠNG\r\nXƯỞNG ANCO 1\r\n";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(32.27096F, 99.6042F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(27.08333F, 24.99998F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Tổ:";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // tosx
        // 
        this.tosx.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tosx")});
        this.tosx.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.tosx.LocationFloat = new DevExpress.Utils.PointFloat(59.35429F, 99.6042F);
        this.tosx.Name = "tosx";
        this.tosx.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.tosx.SizeF = new System.Drawing.SizeF(310.4166F, 24.99998F);
        this.tosx.StylePriority.UseFont = false;
        this.tosx.StylePriority.UseTextAlignment = false;
        this.tosx.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 14F);
        this.xrLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(193.75F, 0F);
        this.xrLabel1.Multiline = true;
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(425F, 28.08333F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseForeColor = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "LỆNH SẢN XUẤT";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel18
        // 
        this.xrLabel18.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(381.2291F, 124.6041F);
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(101.0416F, 25F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "- Ngày kết thúc:";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // ketthuc
        // 
        this.ketthuc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ketthuc", "{0:dd/MM/yyyy}")});
        this.ketthuc.Font = new System.Drawing.Font("Arial", 9F);
        this.ketthuc.LocationFloat = new DevExpress.Utils.PointFloat(482.2707F, 124.6041F);
        this.ketthuc.Name = "ketthuc";
        this.ketthuc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ketthuc.SizeF = new System.Drawing.SizeF(267.7293F, 24.99999F);
        this.ketthuc.StylePriority.UseFont = false;
        this.ketthuc.StylePriority.UseTextAlignment = false;
        this.ketthuc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // hoantat
        // 
        this.hoantat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "hoantat", "{0:dd/MM/yyyy}")});
        this.hoantat.Font = new System.Drawing.Font("Arial", 9F);
        this.hoantat.LocationFloat = new DevExpress.Utils.PointFloat(167.6873F, 150.8958F);
        this.hoantat.Name = "hoantat";
        this.hoantat.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.hoantat.SizeF = new System.Drawing.SizeF(202.0835F, 24.99998F);
        this.hoantat.StylePriority.UseFont = false;
        this.hoantat.StylePriority.UseTextAlignment = false;
        this.hoantat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel16
        // 
        this.xrLabel16.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(32.27085F, 150.8958F);
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(135.4165F, 24.99998F);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "- Ngày DK hoàn thành:";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // batdau
        // 
        this.batdau.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "batdau", "{0:dd/MM/yyyy}")});
        this.batdau.Font = new System.Drawing.Font("Arial", 9F);
        this.batdau.LocationFloat = new DevExpress.Utils.PointFloat(178.104F, 124.6041F);
        this.batdau.Name = "batdau";
        this.batdau.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.batdau.SizeF = new System.Drawing.SizeF(191.6668F, 25F);
        this.batdau.StylePriority.UseFont = false;
        this.batdau.StylePriority.UseTextAlignment = false;
        this.batdau.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel12
        // 
        this.xrLabel12.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(32.27072F, 124.6041F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(145.8333F, 25F);
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "- Ngày lập lệnh sản xuất:";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(381.2293F, 99.6041F);
        this.xrLabel10.Multiline = true;
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(62.5F, 24.99999F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "ĐĐHTC:\n\nĐHTC:";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xuong
        // 
        this.xuong.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "xuong")});
        this.xuong.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xuong.LocationFloat = new DevExpress.Utils.PointFloat(123.9375F, 74.60422F);
        this.xuong.Name = "xuong";
        this.xuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xuong.SizeF = new System.Drawing.SizeF(245.8333F, 24.99998F);
        this.xuong.StylePriority.UseFont = false;
        this.xuong.StylePriority.UseTextAlignment = false;
        this.xuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(32.27085F, 74.60422F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(91.66667F, 24.99998F);
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Phân xưởng:";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // so
        // 
        this.so.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "so")});
        this.so.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.so.LocationFloat = new DevExpress.Utils.PointFloat(269.5833F, 29.1667F);
        this.so.Name = "so";
        this.so.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.so.SizeF = new System.Drawing.SizeF(287.5F, 26.04165F);
        this.so.StylePriority.UseFont = false;
        this.so.StylePriority.UseTextAlignment = false;
        this.so.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // ngay
        // 
        this.ngay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngay", "{0:dd/MM/yyyy}")});
        this.ngay.Font = new System.Drawing.Font("Arial", 9F);
        this.ngay.LocationFloat = new DevExpress.Utils.PointFloat(640.75F, 28.125F);
        this.ngay.Name = "ngay";
        this.ngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ngay.SizeF = new System.Drawing.SizeF(109.2499F, 27.08335F);
        this.ngay.StylePriority.UseFont = false;
        this.ngay.StylePriority.UseTextAlignment = false;
        this.ngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(590.75F, 29.1667F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(50F, 27.08335F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Ngày:";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(675F, 0F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(75F, 28.125F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.Text = "MẪU: /KH";
        // 
        // dhtc
        // 
        this.dhtc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dhtc")});
        this.dhtc.Font = new System.Drawing.Font("Arial", 9F);
        this.dhtc.LocationFloat = new DevExpress.Utils.PointFloat(443.7293F, 99.60411F);
        this.dhtc.Multiline = true;
        this.dhtc.Name = "dhtc";
        this.dhtc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.dhtc.SizeF = new System.Drawing.SizeF(306.2706F, 25F);
        this.dhtc.StylePriority.UseFont = false;
        this.dhtc.StylePriority.UseTextAlignment = false;
        this.dhtc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(0F, 175.8958F);
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(750.0001F, 15.625F);
        this.xrLabel22.StylePriority.UseFont = false;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel23,
            this.xrLabel24,
            this.xrLabel25,
            this.xrLabel26,
            this.xrLabel28,
            this.xrLabel7,
            this.xrLabel11,
            this.xrLabel13});
        this.PageHeader.HeightF = 30.625F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrLabel23
        // 
        this.xrLabel23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel23.BorderColor = System.Drawing.Color.Black;
        this.xrLabel23.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel23.CanGrow = false;
        this.xrLabel23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel23.ForeColor = System.Drawing.Color.Black;
        this.xrLabel23.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel23.Name = "xrLabel23";
        this.xrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel23.SizeF = new System.Drawing.SizeF(44.58333F, 30.625F);
        this.xrLabel23.StylePriority.UseBackColor = false;
        this.xrLabel23.StylePriority.UseBorderColor = false;
        this.xrLabel23.StylePriority.UseBorderDashStyle = false;
        this.xrLabel23.StylePriority.UseBorders = false;
        this.xrLabel23.StylePriority.UseBorderWidth = false;
        this.xrLabel23.StylePriority.UseFont = false;
        this.xrLabel23.StylePriority.UseForeColor = false;
        this.xrLabel23.StylePriority.UsePadding = false;
        this.xrLabel23.StylePriority.UseTextAlignment = false;
        this.xrLabel23.Text = "STT";
        this.xrLabel23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel24
        // 
        this.xrLabel24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel24.BorderColor = System.Drawing.Color.Black;
        this.xrLabel24.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel24.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel24.CanGrow = false;
        this.xrLabel24.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel24.ForeColor = System.Drawing.Color.Black;
        this.xrLabel24.LocationFloat = new DevExpress.Utils.PointFloat(44.58332F, 0F);
        this.xrLabel24.Name = "xrLabel24";
        this.xrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel24.SizeF = new System.Drawing.SizeF(105.7785F, 30.625F);
        this.xrLabel24.StylePriority.UseBackColor = false;
        this.xrLabel24.StylePriority.UseBorderColor = false;
        this.xrLabel24.StylePriority.UseBorderDashStyle = false;
        this.xrLabel24.StylePriority.UseBorders = false;
        this.xrLabel24.StylePriority.UseBorderWidth = false;
        this.xrLabel24.StylePriority.UseFont = false;
        this.xrLabel24.StylePriority.UseForeColor = false;
        this.xrLabel24.StylePriority.UsePadding = false;
        this.xrLabel24.StylePriority.UseTextAlignment = false;
        this.xrLabel24.Text = "Mã Hàng";
        this.xrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel25
        // 
        this.xrLabel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel25.BorderColor = System.Drawing.Color.Black;
        this.xrLabel25.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel25.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel25.CanGrow = false;
        this.xrLabel25.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel25.ForeColor = System.Drawing.Color.Black;
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(150.9791F, 0F);
        this.xrLabel25.Multiline = true;
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(188.7917F, 30.625F);
        this.xrLabel25.StylePriority.UseBackColor = false;
        this.xrLabel25.StylePriority.UseBorderColor = false;
        this.xrLabel25.StylePriority.UseBorderDashStyle = false;
        this.xrLabel25.StylePriority.UseBorders = false;
        this.xrLabel25.StylePriority.UseBorderWidth = false;
        this.xrLabel25.StylePriority.UseFont = false;
        this.xrLabel25.StylePriority.UseForeColor = false;
        this.xrLabel25.StylePriority.UsePadding = false;
        this.xrLabel25.StylePriority.UseTextAlignment = false;
        this.xrLabel25.Text = "Tên Hàng";
        this.xrLabel25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel26
        // 
        this.xrLabel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel26.BorderColor = System.Drawing.Color.Black;
        this.xrLabel26.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel26.CanGrow = false;
        this.xrLabel26.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel26.ForeColor = System.Drawing.Color.Black;
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(443.7293F, 0F);
        this.xrLabel26.Multiline = true;
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(38.54141F, 30.625F);
        this.xrLabel26.StylePriority.UseBackColor = false;
        this.xrLabel26.StylePriority.UseBorderColor = false;
        this.xrLabel26.StylePriority.UseBorderDashStyle = false;
        this.xrLabel26.StylePriority.UseBorders = false;
        this.xrLabel26.StylePriority.UseBorderWidth = false;
        this.xrLabel26.StylePriority.UseFont = false;
        this.xrLabel26.StylePriority.UseForeColor = false;
        this.xrLabel26.StylePriority.UsePadding = false;
        this.xrLabel26.StylePriority.UseTextAlignment = false;
        this.xrLabel26.Text = "ĐVT";
        this.xrLabel26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel28
        // 
        this.xrLabel28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel28.BorderColor = System.Drawing.Color.Black;
        this.xrLabel28.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel28.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel28.CanGrow = false;
        this.xrLabel28.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel28.ForeColor = System.Drawing.Color.Black;
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(482.2707F, 0F);
        this.xrLabel28.Multiline = true;
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel28.SizeF = new System.Drawing.SizeF(85.64597F, 30.625F);
        this.xrLabel28.StylePriority.UseBackColor = false;
        this.xrLabel28.StylePriority.UseBorderColor = false;
        this.xrLabel28.StylePriority.UseBorderDashStyle = false;
        this.xrLabel28.StylePriority.UseBorders = false;
        this.xrLabel28.StylePriority.UseBorderWidth = false;
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.StylePriority.UseForeColor = false;
        this.xrLabel28.StylePriority.UsePadding = false;
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        this.xrLabel28.Text = "SL đặt hàng";
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel7
        // 
        this.xrLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel7.BorderColor = System.Drawing.Color.Black;
        this.xrLabel7.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel7.CanGrow = false;
        this.xrLabel7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.ForeColor = System.Drawing.Color.Black;
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(567.9167F, 0F);
        this.xrLabel7.Multiline = true;
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(72.83331F, 30.625F);
        this.xrLabel7.StylePriority.UseBackColor = false;
        this.xrLabel7.StylePriority.UseBorderColor = false;
        this.xrLabel7.StylePriority.UseBorderDashStyle = false;
        this.xrLabel7.StylePriority.UseBorders = false;
        this.xrLabel7.StylePriority.UseBorderWidth = false;
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseForeColor = false;
        this.xrLabel7.StylePriority.UsePadding = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "SL chia tổ";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel11
        // 
        this.xrLabel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel11.BorderColor = System.Drawing.Color.Black;
        this.xrLabel11.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel11.CanGrow = false;
        this.xrLabel11.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel11.ForeColor = System.Drawing.Color.Black;
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(339.7708F, 0F);
        this.xrLabel11.Multiline = true;
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(103.9585F, 30.625F);
        this.xrLabel11.StylePriority.UseBackColor = false;
        this.xrLabel11.StylePriority.UseBorderColor = false;
        this.xrLabel11.StylePriority.UseBorderDashStyle = false;
        this.xrLabel11.StylePriority.UseBorders = false;
        this.xrLabel11.StylePriority.UseBorderWidth = false;
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UseForeColor = false;
        this.xrLabel11.StylePriority.UsePadding = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.Text = "Nơi giao hàng";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel13
        // 
        this.xrLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel13.BorderColor = System.Drawing.Color.Black;
        this.xrLabel13.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel13.CanGrow = false;
        this.xrLabel13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel13.ForeColor = System.Drawing.Color.Black;
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(640.75F, 0F);
        this.xrLabel13.Multiline = true;
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(109.2499F, 30.625F);
        this.xrLabel13.StylePriority.UseBackColor = false;
        this.xrLabel13.StylePriority.UseBorderColor = false;
        this.xrLabel13.StylePriority.UseBorderDashStyle = false;
        this.xrLabel13.StylePriority.UseBorders = false;
        this.xrLabel13.StylePriority.UseBorderWidth = false;
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseForeColor = false;
        this.xrLabel13.StylePriority.UsePadding = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "Ghi chú";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // LenhSanXuat
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.PageHeader});
        this.Margins = new System.Drawing.Printing.Margins(34, 43, 0, 0);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "17.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}