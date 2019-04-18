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
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityContext db = new EntityContext();
        donMuaVatTu report = new donMuaVatTu();
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
		string c_donmuahang_id = context.Request.QueryString["id"];	
		string sql = string.Format(@"
		select getdate() as ngay
		, dtkd.ten_dtkd as doitac, dtkd.tel as dienthoai, dtkd.fax as fax, dtkd.daidien as daidien
		, sp.ma_sanpham as ma, sp.mota_tiengviet as ten, dvt.ten_dvt as dvt, dmh.mota as kiemtra, khmvt.ten_kehoach as khmvt
		, dbo.autoround(round(cdmh.sl_dadat , 2, 1), ',', '.') as SL, cdmh.dongiamua as dongia,cdmh.thanhtien as thanhtien
		, N'Số : ' + dmh.sochungtu as so, dmh.chu_tong_tatca as tienchu, dmh.donhang_thamchieu as dcht
		, dmh.ngaygiaohang as thoigian, dmh.diadiem_giaohang as diadiem
		, thue.ten_thue_sanpham as vat, (cdmh.thanhtien * thue.giatri) / 100 as tien_thue,  dmh.tong_tatca as tong_tien_hang
		, dt.ma_iso as dongtien, cdmh.mota as mota
		 from c_donmuahang dmh
		 left join c_kehoachmuavt khmvt on dmh.sctkehoach = khmvt.sochungtu
		 left join c_donmuahang_cdmh cdmh on cdmh.c_donmuahang_id = dmh.c_donmuahang_id
		 left join md_sanpham sp on sp.md_sanpham_id = cdmh.md_sanpham_id
		 left join md_donvitinhsanpham dvt on dvt.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
		 left join md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
		 left join md_dongtien dt on dt.md_dongtien_id = dmh.md_dongtien_id
		 left join c_danhsachdathang dsdh on dsdh.sochungtu = dmh.sctdathang
		 left join md_thue_sanpham thue on cdmh.thue = thue.md_thue_sanpham_id
		 where dmh.c_donmuahang_id = '{0}'
		 order by sp.ma_sanpham asc
		",c_donmuahang_id);
		return sql;
    }
}

/// <summary>
/// Summary description for donMuaVatTu
/// </summary>
public class donMuaVatTu : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel2;
    private XRLabel xrLabel7;
    private XRLabel xrLabel9;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel11;
    private XRLabel xrLabel12;
    private XRLabel xrLabel28;
    private XRLabel xrLabel26;
    private XRLabel xrLabel25;
    private XRLabel xrLabel24;
    private XRLabel xrLabel23;
    private XRLabel xrLabel10;
    private XRLabel dienthoai;
    private XRLabel xrLabel14;
    private XRLabel fax;
    private XRLabel doitac;
    private XRLabel xrLabel19;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell4;
    private XRTableCell tong_sl;
    private XRTableCell xrTableCell5;
    private XRTableCell tong_tien;
    private XRLabel xrLabel34;
    private XRLabel diadiem;
    private XRLabel thoigian;
    private XRLabel xrLabel30;
    private XRLabel xrLabel38;
    private XRLabel xrLabel62;
    private XRLabel xrLabel45;
    private XRLabel xrLabel48;
    private XRLabel xrLabel6;
    private XRLabel dongtien;
    private XRTableCell xrTableCell9;
    private XRLabel xrLabel8;
    private XRLabel xrLabel13;
    private XRLabel xrLabel15;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel20;
    private XRRichText kiemtra;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell tt;
    private XRTableCell ma;
    private XRTableCell ten;
    private XRTableCell dvt;
    private XRTableCell SL;
    private XRTableCell dongia;
    private XRTableCell thanhtien;
    private XRTableCell vat;
    private XRTableCell tien_thue;
    private XRTableCell xrTableCell3;
    private XRLabel xrLabel21;
    private XRLabel xrLabel5;
    private XRTableCell tong_tien_thue;
    private XRTableCell xrTableCell6;
    private XRLabel xrLabel27;
    private XRLabel tong_tien_hang;
    private XRLabel xrLabel29;
    private XRLabel xrLabel22;
    private XRLabel xrLabel4;
    private XRLabel so;
    private XRLabel xrLabel3;
    private XRLabel ngay;
    private XRLabel dcht;
    private XRLabel xrLabel1;
    private XRLabel xrLabel32;
    private XRLabel khmvt;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public donMuaVatTu()
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
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.tt = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten = new DevExpress.XtraReports.UI.XRTableCell();
        this.dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.SL = new DevExpress.XtraReports.UI.XRTableCell();
        this.dongia = new DevExpress.XtraReports.UI.XRTableCell();
        this.thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.vat = new DevExpress.XtraReports.UI.XRTableCell();
        this.tien_thue = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel32 = new DevExpress.XtraReports.UI.XRLabel();
        this.khmvt = new DevExpress.XtraReports.UI.XRLabel();
        this.so = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.ngay = new DevExpress.XtraReports.UI.XRLabel();
        this.dcht = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.dongtien = new DevExpress.XtraReports.UI.XRLabel();
        this.doitac = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.fax = new DevExpress.XtraReports.UI.XRLabel();
        this.dienthoai = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
        this.tong_tien_hang = new DevExpress.XtraReports.UI.XRLabel();
        this.kiemtra = new DevExpress.XtraReports.UI.XRRichText();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel62 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel45 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel48 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel38 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel34 = new DevExpress.XtraReports.UI.XRLabel();
        this.diadiem = new DevExpress.XtraReports.UI.XRLabel();
        this.thoigian = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_tien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_tien_thue = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel28 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel26 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.kiemtra)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.Detail.HeightF = 50F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable1
        // 
        this.xrTable1.Font = new System.Drawing.Font("Arial", 9.75F);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(773F, 50F);
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UsePadding = false;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tt,
            this.ma,
            this.ten,
            this.dvt,
            this.SL,
            this.dongia,
            this.thanhtien,
            this.vat,
            this.tien_thue,
            this.xrTableCell3});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // tt
        // 
        this.tt.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tt.Name = "tt";
        this.tt.StylePriority.UseBorders = false;
        this.tt.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tt.Summary = xrSummary1;
        this.tt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.tt.Weight = 0.158568111586023D;
        // 
        // ma
        // 
        this.ma.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.ma.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma")});
        this.ma.Name = "ma";
        this.ma.StylePriority.UseBorders = false;
        this.ma.StylePriority.UseTextAlignment = false;
        this.ma.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.ma.Weight = 0.376218939766785D;
        // 
        // ten
        // 
        this.ten.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.ten.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ten")});
        this.ten.Name = "ten";
        this.ten.StylePriority.UseBorders = false;
        this.ten.StylePriority.UseTextAlignment = false;
        this.ten.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.ten.Weight = 0.48430695144373048D;
        // 
        // dvt
        // 
        this.dvt.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.dvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dvt")});
        this.dvt.Name = "dvt";
        this.dvt.StylePriority.UseBorders = false;
        this.dvt.StylePriority.UseTextAlignment = false;
        this.dvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.dvt.Weight = 0.10738623804014115D;
        // 
        // SL
        // 
        this.SL.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.SL.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SL")});
        this.SL.Name = "SL";
        this.SL.StylePriority.UseBorders = false;
        this.SL.StylePriority.UseTextAlignment = false;
        this.SL.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.SL.Weight = 0.227651395557446D;
        // 
        // dongia
        // 
        this.dongia.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.dongia.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dongia", "{0:#,#0.00}")});
        this.dongia.Name = "dongia";
        this.dongia.StylePriority.UseBorders = false;
        this.dongia.StylePriority.UseTextAlignment = false;
        this.dongia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.dongia.Weight = 0.26526776912554417D;
        // 
        // thanhtien
        // 
        this.thanhtien.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.thanhtien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thanhtien", "{0:#,#0.00}")});
        this.thanhtien.Name = "thanhtien";
        this.thanhtien.StylePriority.UseBorders = false;
        this.thanhtien.StylePriority.UseTextAlignment = false;
        this.thanhtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.thanhtien.Weight = 0.36482970681602234D;
        // 
        // vat
        // 
        this.vat.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.vat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "vat")});
        this.vat.Name = "vat";
        this.vat.StylePriority.UseBorders = false;
        this.vat.StylePriority.UseTextAlignment = false;
        this.vat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.vat.Weight = 0.16133128994490154D;
        // 
        // tien_thue
        // 
        this.tien_thue.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tien_thue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tien_thue", "{0:#,#0.00}")});
        this.tien_thue.Name = "tien_thue";
        this.tien_thue.StylePriority.UseBorders = false;
        this.tien_thue.StylePriority.UseTextAlignment = false;
        this.tien_thue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tien_thue.Weight = 0.24748345216899667D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "mota")});
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell3.Weight = 0.35626052879583364D;
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
            this.xrLabel32,
            this.khmvt,
            this.so,
            this.xrLabel3,
            this.ngay,
            this.dcht,
            this.xrLabel1,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel20,
            this.xrLabel16,
            this.xrLabel6,
            this.dongtien,
            this.doitac,
            this.xrLabel19,
            this.xrLabel14,
            this.fax,
            this.dienthoai,
            this.xrLabel10,
            this.xrLabel9,
            this.xrLabel7,
            this.xrLabel2});
        this.ReportHeader.HeightF = 237.9146F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel32
        // 
        this.xrLabel32.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel32.LocationFloat = new DevExpress.Utils.PointFloat(186F, 166.6459F);
        this.xrLabel32.Name = "xrLabel32";
        this.xrLabel32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel32.SizeF = new System.Drawing.SizeF(76.08263F, 22.99998F);
        this.xrLabel32.StylePriority.UseFont = false;
        this.xrLabel32.StylePriority.UseTextAlignment = false;
        this.xrLabel32.Text = " KH mua VT:";
        this.xrLabel32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // khmvt
        // 
        this.khmvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "khmvt")});
        this.khmvt.Font = new System.Drawing.Font("Arial", 9F);
        this.khmvt.LocationFloat = new DevExpress.Utils.PointFloat(262.0826F, 166.6459F);
        this.khmvt.Name = "khmvt";
        this.khmvt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.khmvt.SizeF = new System.Drawing.SizeF(373.9174F, 22.99998F);
        this.khmvt.StylePriority.UseFont = false;
        this.khmvt.StylePriority.UseTextAlignment = false;
        this.khmvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // so
        // 
        this.so.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "so")});
        this.so.Font = new System.Drawing.Font("Arial", 9F);
        this.so.LocationFloat = new DevExpress.Utils.PointFloat(206.0638F, 143.1459F);
        this.so.Name = "so";
        this.so.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.so.SizeF = new System.Drawing.SizeF(384.4358F, 19.99998F);
        this.so.StylePriority.UseFont = false;
        this.so.StylePriority.UseTextAlignment = false;
        this.so.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(614.278F, 143.6459F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(71.43036F, 22.99997F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Ngày:";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // ngay
        // 
        this.ngay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngay", "{0:dd/MM/yyyy}")});
        this.ngay.Font = new System.Drawing.Font("Arial", 9F);
        this.ngay.LocationFloat = new DevExpress.Utils.PointFloat(685.7083F, 143.6459F);
        this.ngay.Name = "ngay";
        this.ngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ngay.SizeF = new System.Drawing.SizeF(87.29169F, 22.99997F);
        this.ngay.StylePriority.UseFont = false;
        this.ngay.StylePriority.UseTextAlignment = false;
        this.ngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // dcht
        // 
        this.dcht.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dcht")});
        this.dcht.Font = new System.Drawing.Font("Arial", 9F);
        this.dcht.LocationFloat = new DevExpress.Utils.PointFloat(46.25008F, 166.6459F);
        this.dcht.Name = "dcht";
        this.dcht.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.dcht.SizeF = new System.Drawing.SizeF(128.4646F, 22.99997F);
        this.dcht.StylePriority.UseFont = false;
        this.dcht.StylePriority.UseTextAlignment = false;
        this.dcht.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 166.6459F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(46.25008F, 22.99998F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "ĐHTC:";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel17
        // 
        this.xrLabel17.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
        this.xrLabel17.ForeColor = System.Drawing.Color.Black;
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(195.1533F, 0F);
        this.xrLabel17.Multiline = true;
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(432.1519F, 38.54167F);
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.StylePriority.UseForeColor = false;
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        this.xrLabel17.Text = "ANCO COMPANY LIMITED";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel18
        // 
        this.xrLabel18.Font = new System.Drawing.Font("Arial", 11F);
        this.xrLabel18.ForeColor = System.Drawing.Color.Black;
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38.54168F);
        this.xrLabel18.Multiline = true;
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(773.0002F, 41.19786F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseForeColor = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "3B/2, 1B Hamlet, An Phu Ward, Thuan An Dist., Binh Duong Province, Vietnam\r\nTel.:" +
" (84-650) 3740 973   Fax:  (84–650) 3740 621  Email: anco@ancopottery.com\r\n";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel20
        // 
        this.xrLabel20.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel20.LocationFloat = new DevExpress.Utils.PointFloat(0F, 79.73951F);
        this.xrLabel20.Multiline = true;
        this.xrLabel20.Name = "xrLabel20";
        this.xrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel20.SizeF = new System.Drawing.SizeF(773.0002F, 23.42711F);
        this.xrLabel20.StylePriority.UseFont = false;
        this.xrLabel20.StylePriority.UseTextAlignment = false;
        this.xrLabel20.Text = "_______________________________________________________________________________";
        this.xrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel16
        // 
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(1.403292F, 0F);
        this.xrLabel16.Multiline = true;
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(193.75F, 38.54167F);
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "CTY ANCO BÌNH DƯƠNG\r\nXƯỞNG ANCO 1\r\n";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(655.4999F, 214.9146F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(37.83344F, 22.99996F);
        this.xrLabel6.StylePriority.UseFont = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "ĐVT:";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // dongtien
        // 
        this.dongtien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dongtien")});
        this.dongtien.Font = new System.Drawing.Font("Arial", 9F);
        this.dongtien.LocationFloat = new DevExpress.Utils.PointFloat(693.3333F, 214.9146F);
        this.dongtien.Name = "dongtien";
        this.dongtien.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.dongtien.SizeF = new System.Drawing.SizeF(79.66675F, 22.99997F);
        this.dongtien.StylePriority.UseFont = false;
        this.dongtien.StylePriority.UseTextAlignment = false;
        this.dongtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // doitac
        // 
        this.doitac.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "doitac")});
        this.doitac.Font = new System.Drawing.Font("Arial", 9F);
        this.doitac.LocationFloat = new DevExpress.Utils.PointFloat(64.70864F, 191.9144F);
        this.doitac.Name = "doitac";
        this.doitac.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.doitac.SizeF = new System.Drawing.SizeF(361.3749F, 22.99997F);
        this.doitac.StylePriority.UseFont = false;
        this.doitac.StylePriority.UseTextAlignment = false;
        this.doitac.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel19
        // 
        this.xrLabel19.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(0.9999593F, 191.9144F);
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(63.70867F, 22.99998F);
        this.xrLabel19.StylePriority.UseFont = false;
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.Text = "Kính gửi:";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(629.875F, 191.9144F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(30.12509F, 22.99997F);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "Fax:";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // fax
        // 
        this.fax.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fax")});
        this.fax.Font = new System.Drawing.Font("Arial", 9F);
        this.fax.LocationFloat = new DevExpress.Utils.PointFloat(660.0001F, 191.9144F);
        this.fax.Name = "fax";
        this.fax.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.fax.SizeF = new System.Drawing.SizeF(113F, 22.99997F);
        this.fax.StylePriority.UseFont = false;
        this.fax.StylePriority.UseTextAlignment = false;
        this.fax.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // dienthoai
        // 
        this.dienthoai.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dienthoai")});
        this.dienthoai.Font = new System.Drawing.Font("Arial", 9F);
        this.dienthoai.LocationFloat = new DevExpress.Utils.PointFloat(516.8751F, 191.9144F);
        this.dienthoai.Name = "dienthoai";
        this.dienthoai.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.dienthoai.SizeF = new System.Drawing.SizeF(112.9999F, 22.99997F);
        this.dienthoai.StylePriority.UseFont = false;
        this.dienthoai.StylePriority.UseTextAlignment = false;
        this.dienthoai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(440.9167F, 191.9144F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(75.95844F, 22.99997F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Điện thoại:";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(2.000046F, 214.9144F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(653.4998F, 22.99998F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Kính đề nghị quí công ty cung cấp cho chúng tôi các mặt hàng theo chi tiết sau:";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
        this.xrLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(192)))));
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 103.1666F);
        this.xrLabel7.Multiline = true;
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(773.0002F, 38.54168F);
        this.xrLabel7.StylePriority.UseFont = false;
        this.xrLabel7.StylePriority.UseForeColor = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "PHIẾU MUA VẬT TƯ";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(627.3052F, 0F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(145.6948F, 38.54168F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "Mẫu: 002/AC1";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel29,
            this.xrLabel22,
            this.xrLabel4,
            this.xrLabel27,
            this.tong_tien_hang,
            this.kiemtra,
            this.xrLabel13,
            this.xrLabel15,
            this.xrLabel62,
            this.xrLabel45,
            this.xrLabel48,
            this.xrLabel38,
            this.xrLabel34,
            this.diadiem,
            this.thoigian,
            this.xrLabel30,
            this.xrTable2});
        this.ReportFooter.HeightF = 143.3824F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel29
        // 
        this.xrLabel29.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel29.LocationFloat = new DevExpress.Utils.PointFloat(603.2501F, 112.2699F);
        this.xrLabel29.Multiline = true;
        this.xrLabel29.Name = "xrLabel29";
        this.xrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel29.SizeF = new System.Drawing.SizeF(169.7501F, 18.27F);
        this.xrLabel29.StylePriority.UseFont = false;
        this.xrLabel29.StylePriority.UseTextAlignment = false;
        this.xrLabel29.Text = "(Ký, họ tên)";
        this.xrLabel29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel22
        // 
        this.xrLabel22.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel22.LocationFloat = new DevExpress.Utils.PointFloat(411.5638F, 112.2699F);
        this.xrLabel22.Multiline = true;
        this.xrLabel22.Name = "xrLabel22";
        this.xrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel22.SizeF = new System.Drawing.SizeF(191.6863F, 18.27F);
        this.xrLabel22.StylePriority.UseFont = false;
        this.xrLabel22.StylePriority.UseTextAlignment = false;
        this.xrLabel22.Text = "(Ký, họ tên)";
        this.xrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(206.0638F, 112.2699F);
        this.xrLabel4.Multiline = true;
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(205.5F, 18.27F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "(Ký, họ tên)";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel27
        // 
        this.xrLabel27.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
        this.xrLabel27.LocationFloat = new DevExpress.Utils.PointFloat(455.3136F, 25F);
        this.xrLabel27.Name = "xrLabel27";
        this.xrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel27.SizeF = new System.Drawing.SizeF(147.9365F, 23F);
        this.xrLabel27.StylePriority.UseFont = false;
        this.xrLabel27.StylePriority.UseTextAlignment = false;
        this.xrLabel27.Text = "Tổng tiền hàng : ";
        this.xrLabel27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // tong_tien_hang
        // 
        this.tong_tien_hang.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tong_tien_hang", "{0:#,#0.00}")});
        this.tong_tien_hang.Font = new System.Drawing.Font("Arial", 11F);
        this.tong_tien_hang.LocationFloat = new DevExpress.Utils.PointFloat(603.2501F, 25F);
        this.tong_tien_hang.Name = "tong_tien_hang";
        this.tong_tien_hang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.tong_tien_hang.SizeF = new System.Drawing.SizeF(169.7499F, 22.99999F);
        this.tong_tien_hang.StylePriority.UseFont = false;
        this.tong_tien_hang.StylePriority.UseTextAlignment = false;
        this.tong_tien_hang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // kiemtra
        // 
        this.kiemtra.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "kiemtra")});
        this.kiemtra.Font = new System.Drawing.Font("Times New Roman", 9.75F);
        this.kiemtra.LocationFloat = new DevExpress.Utils.PointFloat(96.49982F, 70.9999F);
        this.kiemtra.Name = "kiemtra";
        this.kiemtra.SizeF = new System.Drawing.SizeF(645.8336F, 23F);
        // 
        // xrLabel13
        // 
        this.xrLabel13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 93.9999F);
        this.xrLabel13.Multiline = true;
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(205.5F, 18.27F);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "Xác nhận nhà cung cấp";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel15
        // 
        this.xrLabel15.Font = new System.Drawing.Font("Arial", 9F);
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 112.2699F);
        this.xrLabel15.Multiline = true;
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(205.5F, 18.27F);
        this.xrLabel15.StylePriority.UseFont = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "(Ký, họ tên)";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel62
        // 
        this.xrLabel62.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel62.LocationFloat = new DevExpress.Utils.PointFloat(603.2501F, 93.99989F);
        this.xrLabel62.Multiline = true;
        this.xrLabel62.Name = "xrLabel62";
        this.xrLabel62.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel62.SizeF = new System.Drawing.SizeF(169.7499F, 18.27F);
        this.xrLabel62.StylePriority.UseFont = false;
        this.xrLabel62.StylePriority.UseTextAlignment = false;
        this.xrLabel62.Text = "Ban Giám Đốc";
        this.xrLabel62.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel45
        // 
        this.xrLabel45.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel45.LocationFloat = new DevExpress.Utils.PointFloat(206.0638F, 93.9999F);
        this.xrLabel45.Multiline = true;
        this.xrLabel45.Name = "xrLabel45";
        this.xrLabel45.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel45.SizeF = new System.Drawing.SizeF(205.5F, 18.27F);
        this.xrLabel45.StylePriority.UseFont = false;
        this.xrLabel45.StylePriority.UseTextAlignment = false;
        this.xrLabel45.Text = "NV đặt hàng";
        this.xrLabel45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel48
        // 
        this.xrLabel48.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel48.LocationFloat = new DevExpress.Utils.PointFloat(411.5638F, 93.99989F);
        this.xrLabel48.Multiline = true;
        this.xrLabel48.Name = "xrLabel48";
        this.xrLabel48.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel48.SizeF = new System.Drawing.SizeF(191.6863F, 18.27F);
        this.xrLabel48.StylePriority.UseFont = false;
        this.xrLabel48.StylePriority.UseTextAlignment = false;
        this.xrLabel48.Text = "TP.Kế hoạch";
        this.xrLabel48.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel38
        // 
        this.xrLabel38.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel38.LocationFloat = new DevExpress.Utils.PointFloat(0F, 70.99991F);
        this.xrLabel38.Name = "xrLabel38";
        this.xrLabel38.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel38.SizeF = new System.Drawing.SizeF(96.49982F, 22.99997F);
        this.xrLabel38.StylePriority.UseFont = false;
        this.xrLabel38.StylePriority.UseTextAlignment = false;
        this.xrLabel38.Text = "HDLH Cơ Bản:";
        this.xrLabel38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel34
        // 
        this.xrLabel34.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel34.LocationFloat = new DevExpress.Utils.PointFloat(0.9998958F, 47.99995F);
        this.xrLabel34.Name = "xrLabel34";
        this.xrLabel34.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel34.SizeF = new System.Drawing.SizeF(134.0001F, 22.99997F);
        this.xrLabel34.StylePriority.UseFont = false;
        this.xrLabel34.StylePriority.UseTextAlignment = false;
        this.xrLabel34.Text = "Địa điểm giao hàng:";
        this.xrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // diadiem
        // 
        this.diadiem.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "diadiem")});
        this.diadiem.Font = new System.Drawing.Font("Arial", 9F);
        this.diadiem.LocationFloat = new DevExpress.Utils.PointFloat(136.3335F, 47.99994F);
        this.diadiem.Name = "diadiem";
        this.diadiem.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.diadiem.SizeF = new System.Drawing.SizeF(421.5564F, 22.99997F);
        this.diadiem.StylePriority.UseFont = false;
        this.diadiem.StylePriority.UseTextAlignment = false;
        this.diadiem.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // thoigian
        // 
        this.thoigian.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thoigian", "{0:dd/MM/yyyy}")});
        this.thoigian.Font = new System.Drawing.Font("Arial", 9F);
        this.thoigian.LocationFloat = new DevExpress.Utils.PointFloat(135F, 24.99998F);
        this.thoigian.Name = "thoigian";
        this.thoigian.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.thoigian.SizeF = new System.Drawing.SizeF(92.14001F, 22.99997F);
        this.thoigian.StylePriority.UseFont = false;
        this.thoigian.StylePriority.UseTextAlignment = false;
        this.thoigian.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrLabel30
        // 
        this.xrLabel30.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel30.LocationFloat = new DevExpress.Utils.PointFloat(0.9999838F, 24.99999F);
        this.xrLabel30.Name = "xrLabel30";
        this.xrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel30.SizeF = new System.Drawing.SizeF(134F, 22.99997F);
        this.xrLabel30.StylePriority.UseFont = false;
        this.xrLabel30.StylePriority.UseTextAlignment = false;
        this.xrLabel30.Text = "Thời gian giao hàng :";
        this.xrLabel30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable2
        // 
        this.xrTable2.Font = new System.Drawing.Font("Arial", 9F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(773F, 25F);
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UsePadding = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell7,
            this.xrTableCell4,
            this.tong_sl,
            this.xrTableCell5,
            this.tong_tien,
            this.xrTableCell9,
            this.tong_tien_thue,
            this.xrTableCell6});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.StylePriority.UseFont = false;
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "Tổng cộng :";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 1.1613585649694895D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.Weight = 0.12237724979034942D;
        // 
        // tong_sl
        // 
        this.tong_sl.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SL")});
        this.tong_sl.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.tong_sl.Name = "tong_sl";
        this.tong_sl.StylePriority.UseBorders = false;
        this.tong_sl.StylePriority.UseFont = false;
        this.tong_sl.StylePriority.UseTextAlignment = false;
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl.Summary = xrSummary2;
        this.tong_sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl.Weight = 0.25943130154745786D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.Weight = 0.30229887712332265D;
        // 
        // tong_tien
        // 
        this.tong_tien.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_tien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thanhtien")});
        this.tong_tien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.tong_tien.Name = "tong_tien";
        this.tong_tien.StylePriority.UseBorders = false;
        this.tong_tien.StylePriority.UseFont = false;
        this.tong_tien.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:#,#0.00}";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_tien.Summary = xrSummary3;
        this.tong_tien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_tien.Weight = 0.415759567724802D;
        this.tong_tien.SummaryGetResult += new DevExpress.XtraReports.UI.SummaryGetResultHandler(this.tong_tien_SummaryGetResult);
        this.tong_tien.SummaryReset += new System.EventHandler(this.tong_tien_SummaryReset);
        this.tong_tien.SummaryRowChanged += new System.EventHandler(this.tong_tien_SummaryRowChanged);
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.Weight = 0.18385297206276868D;
        // 
        // tong_tien_thue
        // 
        this.tong_tien_thue.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_tien_thue.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tien_thue")});
        this.tong_tien_thue.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.tong_tien_thue.Name = "tong_tien_thue";
        this.tong_tien_thue.StylePriority.UseBorders = false;
        this.tong_tien_thue.StylePriority.UseFont = false;
        this.tong_tien_thue.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:#,#0.00}";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_tien_thue.Summary = xrSummary4;
        this.tong_tien_thue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_tien_thue.Weight = 0.28203213360812207D;
        this.tong_tien_thue.SummaryGetResult += new DevExpress.XtraReports.UI.SummaryGetResultHandler(this.tong_tien_thue_SummaryGetResult);
        this.tong_tien_thue.SummaryReset += new System.EventHandler(this.tong_tien_thue_SummaryReset);
        this.tong_tien_thue.SummaryRowChanged += new System.EventHandler(this.tong_tien_thue_SummaryRowChanged);
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.Weight = 0.40599386368500756D;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.xrLabel28,
            this.xrLabel26,
            this.xrLabel25,
            this.xrLabel24,
            this.xrLabel23,
            this.xrLabel8,
            this.xrLabel21,
            this.xrLabel5,
            this.xrLabel11});
        this.PageHeader.HeightF = 30.625F;
        this.PageHeader.Name = "PageHeader";
        // 
        // xrLabel12
        // 
        this.xrLabel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel12.BorderColor = System.Drawing.Color.Black;
        this.xrLabel12.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel12.CanGrow = false;
        this.xrLabel12.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel12.ForeColor = System.Drawing.Color.Black;
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(380.7304F, 0F);
        this.xrLabel12.Multiline = true;
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(74.58322F, 30.625F);
        this.xrLabel12.StylePriority.UseBackColor = false;
        this.xrLabel12.StylePriority.UseBorderColor = false;
        this.xrLabel12.StylePriority.UseBorderDashStyle = false;
        this.xrLabel12.StylePriority.UseBorders = false;
        this.xrLabel12.StylePriority.UseBorderWidth = false;
        this.xrLabel12.StylePriority.UseFont = false;
        this.xrLabel12.StylePriority.UseForeColor = false;
        this.xrLabel12.StylePriority.UsePadding = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "Đơn giá";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
        this.xrLabel28.LocationFloat = new DevExpress.Utils.PointFloat(316.7235F, 0F);
        this.xrLabel28.Multiline = true;
        this.xrLabel28.Name = "xrLabel28";
        this.xrLabel28.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel28.SizeF = new System.Drawing.SizeF(64.00693F, 30.625F);
        this.xrLabel28.StylePriority.UseBackColor = false;
        this.xrLabel28.StylePriority.UseBorderColor = false;
        this.xrLabel28.StylePriority.UseBorderDashStyle = false;
        this.xrLabel28.StylePriority.UseBorders = false;
        this.xrLabel28.StylePriority.UseBorderWidth = false;
        this.xrLabel28.StylePriority.UseFont = false;
        this.xrLabel28.StylePriority.UseForeColor = false;
        this.xrLabel28.StylePriority.UsePadding = false;
        this.xrLabel28.StylePriority.UseTextAlignment = false;
        this.xrLabel28.Text = "Số lượng";
        this.xrLabel28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
        this.xrLabel26.LocationFloat = new DevExpress.Utils.PointFloat(286.5305F, 0F);
        this.xrLabel26.Multiline = true;
        this.xrLabel26.Name = "xrLabel26";
        this.xrLabel26.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel26.SizeF = new System.Drawing.SizeF(30.19293F, 30.625F);
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
        this.xrLabel25.LocationFloat = new DevExpress.Utils.PointFloat(150.3618F, 0F);
        this.xrLabel25.Multiline = true;
        this.xrLabel25.Name = "xrLabel25";
        this.xrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel25.SizeF = new System.Drawing.SizeF(136.1688F, 30.625F);
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
        // xrLabel8
        // 
        this.xrLabel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel8.BorderColor = System.Drawing.Color.Black;
        this.xrLabel8.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel8.CanGrow = false;
        this.xrLabel8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel8.ForeColor = System.Drawing.Color.Black;
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(672.8331F, 0F);
        this.xrLabel8.Multiline = true;
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(100.1671F, 30.625F);
        this.xrLabel8.StylePriority.UseBackColor = false;
        this.xrLabel8.StylePriority.UseBorderColor = false;
        this.xrLabel8.StylePriority.UseBorderDashStyle = false;
        this.xrLabel8.StylePriority.UseBorders = false;
        this.xrLabel8.StylePriority.UseBorderWidth = false;
        this.xrLabel8.StylePriority.UseFont = false;
        this.xrLabel8.StylePriority.UseForeColor = false;
        this.xrLabel8.StylePriority.UsePadding = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Ghi chú";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel21
        // 
        this.xrLabel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel21.BorderColor = System.Drawing.Color.Black;
        this.xrLabel21.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel21.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel21.CanGrow = false;
        this.xrLabel21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel21.ForeColor = System.Drawing.Color.Black;
        this.xrLabel21.LocationFloat = new DevExpress.Utils.PointFloat(603.2501F, 0F);
        this.xrLabel21.Multiline = true;
        this.xrLabel21.Name = "xrLabel21";
        this.xrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel21.SizeF = new System.Drawing.SizeF(69.58295F, 30.625F);
        this.xrLabel21.StylePriority.UseBackColor = false;
        this.xrLabel21.StylePriority.UseBorderColor = false;
        this.xrLabel21.StylePriority.UseBorderDashStyle = false;
        this.xrLabel21.StylePriority.UseBorders = false;
        this.xrLabel21.StylePriority.UseBorderWidth = false;
        this.xrLabel21.StylePriority.UseFont = false;
        this.xrLabel21.StylePriority.UseForeColor = false;
        this.xrLabel21.StylePriority.UsePadding = false;
        this.xrLabel21.StylePriority.UseTextAlignment = false;
        this.xrLabel21.Text = "Tiền thuế";
        this.xrLabel21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel5
        // 
        this.xrLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(187)))));
        this.xrLabel5.BorderColor = System.Drawing.Color.Black;
        this.xrLabel5.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrLabel5.CanGrow = false;
        this.xrLabel5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
        this.xrLabel5.ForeColor = System.Drawing.Color.Black;
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(557.89F, 0F);
        this.xrLabel5.Multiline = true;
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(45.36011F, 30.625F);
        this.xrLabel5.StylePriority.UseBackColor = false;
        this.xrLabel5.StylePriority.UseBorderColor = false;
        this.xrLabel5.StylePriority.UseBorderDashStyle = false;
        this.xrLabel5.StylePriority.UseBorders = false;
        this.xrLabel5.StylePriority.UseBorderWidth = false;
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseForeColor = false;
        this.xrLabel5.StylePriority.UsePadding = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Thuế";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(455.3136F, 0F);
        this.xrLabel11.Multiline = true;
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(102.5763F, 30.625F);
        this.xrLabel11.StylePriority.UseBackColor = false;
        this.xrLabel11.StylePriority.UseBorderColor = false;
        this.xrLabel11.StylePriority.UseBorderDashStyle = false;
        this.xrLabel11.StylePriority.UseBorders = false;
        this.xrLabel11.StylePriority.UseBorderWidth = false;
        this.xrLabel11.StylePriority.UseFont = false;
        this.xrLabel11.StylePriority.UseForeColor = false;
        this.xrLabel11.StylePriority.UsePadding = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.Text = "Thành tiền";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // donMuaVatTu
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageHeader});
        this.Margins = new System.Drawing.Printing.Margins(28, 26, 0, 0);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "17.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.kiemtra)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    decimal totalUnits = 0;
    decimal totalUnits1 = 0;
    decimal totalUnits2 = 0;

    private void tong_tien_SummaryRowChanged(object sender, EventArgs e)
    {
        //totalUnits += Convert.ToDecimal(GetCurrentColumnValue("thanhtien"));
    }

    private void tong_tien_SummaryReset(object sender, EventArgs e)
    {
        //totalUnits = 0;
    }

    private void tong_tien_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
    {
        //e.Result = VNN_VariablePublic.autoRound(totalUnits, 4);
        // e.Handled = true;
    }

    private void tong_tien_thue_SummaryRowChanged(object sender, EventArgs e)
    {
        // totalUnits1 += Convert.ToDecimal(GetCurrentColumnValue("thanhtien"));
    }

    private void tong_tien_thue_SummaryReset(object sender, EventArgs e)
    {
        //totalUnits1 = 0;
    }

    private void tong_tien_thue_SummaryGetResult(object sender, SummaryGetResultEventArgs e)
    {
        // e.Result = VNN_VariablePublic.autoRound(totalUnits, 4);
        //   e.Handled = true;
    }
}

