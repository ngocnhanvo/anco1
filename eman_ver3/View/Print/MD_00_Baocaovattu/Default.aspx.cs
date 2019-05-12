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

public partial class PrintControllers_MD_00_Baocaovattu_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityContext db = new EntityContext();
        Baocaovattu report = new Baocaovattu();
        String sql = this.CreateSql();
        this.viewReport(report, sql);
		// Response.Write(sql);
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
		
		string tungay = context.Request.QueryString["tu"];
		string denngay = context.Request.QueryString["den"];
		
		DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
	
		DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
		
		/* string ntc = context.Request.QueryString["ntc"];
		string ky_ = context.Request.QueryString["ky"];
		
		string md_namtaichinh_id = db.md_namtaichinh.Where(s => s.giatri.ToString() == ntc).Select(s => s.md_namtaichinh_id).FirstOrDefault();
		md_namtaichinh_ky ky = db.md_namtaichinh_ky.Where(s => s.md_namtaichinh_id == md_namtaichinh_id & s.soky.ToString() == ky_).FirstOrDefault(); */
		//ky.ngaybatdau.Value.ToString("dd/MM/yyyy"), ky.ngayketthuc.Value.ToString("dd/MM/yyyy")
			
		string phanxuong = context.Request.QueryString["phanxuong"];
		if(phanxuong != null & phanxuong != "") {
			phanxuong = "AND ddhpx.md_phanxuong_id = '"+ phanxuong +"'";
		}
		else {
			phanxuong = "";
		}
		
		string sql = string.Format(@"						 
		SELECT 
		(N'PHÂN XƯỞNG: ' + px.ten_phanxuong) as xuong,
		(N'Từ ngày ' + N'{1}' + N' đến ngày ' + N'{2}') as ngay,
		ddhpx.donhang_thamchieu as dhtc,
		ddhpx.ngayhoanthanh as ngayht,
		sp.ma_sanpham AS ma_sp,
		ddhpx_vt.mota_tiengviet AS ten_sp,
		dvt.ten_dvt AS dvt,
		round(ddhpx_vt.soluong,4) AS sl,
		ddhpx_vt.sl_hanngach AS sl_daxuat,
		ddhpx_vt.soluong - ddhpx_vt.sl_hanngach AS sl_conlai
		FROM md_dondathangphanxuong_vattu ddhpx_vt
		INNER JOIN md_dondathangphanxuong ddhpx ON ddhpx.md_dondathangphanxuong_id = ddhpx_vt.md_dondathangphanxuong_id
		LEFT join md_sanpham sp ON sp.md_sanpham_id = ddhpx_vt.md_sanpham_id
		LEFT JOIN md_donvitinhsanpham dvt ON dvt.md_donvitinhsanpham_id = ddhpx_vt.md_donvitinhsanpham_id
		LEFT join md_phanxuong px ON px.md_phanxuong_id = ddhpx.md_phanxuong_id
        LEFT join c_danhsachdathang dsdh ON dsdh.sochungtu = ddhpx.sctdathang
		WHERE ddhpx.md_trangthai_id != N'SOANTHAO'
		{0}
		AND dsdh.ngaylap >= convert(datetime,N'{1} 00:00',103)
		AND dsdh.ngaylap <= convert(datetime,N'{2} 23:59',103)
		ORDER BY ddhpx.ngayhoanthanh asc, ddhpx.donhang_thamchieu asc, sp.ma_sanpham asc
		", phanxuong,tu.ToString("dd/MM/yyyy"), den.ToString("dd/MM/yyyy"));
		return sql;
    }
}

/// <summary>
/// Summary description for Baocaovattu
/// </summary>
public class Baocaovattu : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel ngay;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell dhtc;
    private XRTableCell ngayht;
    private XRTableCell ma_sp;
    private XRTableCell ten_sp;
    private XRTableCell dvt;
    private XRTableCell sl_daxuat;
    private XRTableCell sl_conlai;
    private XRTableCell sl;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRLabel xrLabel6;
    private XRLabel xrLabel7;
    private XRLabel xrLabel8;
    private XRLabel xrLabel9;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell10;
    private PageHeaderBand PageHeader;
    private XRLabel xrLabel3;
    private XRTableCell xrTableCell18;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell7;
    private XRLabel xuong;
    private GroupFooterBand GroupFooter1;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell25;
    private XRTableCell xrTableCell26;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public Baocaovattu()
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
        string resourceFileName = "Baocaovattu.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.dhtc = new DevExpress.XtraReports.UI.XRTableCell();
        this.ngayht = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma_sp = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten_sp = new DevExpress.XtraReports.UI.XRTableCell();
        this.dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_daxuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_conlai = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.ngay = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xuong = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell25 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell26 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.Detail.Dpi = 100F;
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
        this.xrTable2.Dpi = 100F;
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(7.629395E-06F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(799.9999F, 25F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.dhtc,
            this.ngayht,
            this.ma_sp,
            this.ten_sp,
            this.dvt,
            this.sl,
            this.sl_daxuat,
            this.sl_conlai});
        this.xrTableRow2.Dpi = 100F;
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell9.Dpi = 100F;
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell9.Summary = xrSummary1;
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell9.Weight = 0.13216081442131544D;
        // 
        // dhtc
        // 
        this.dhtc.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.dhtc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dhtc")});
        this.dhtc.Dpi = 100F;
        this.dhtc.Name = "dhtc";
        this.dhtc.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.dhtc.StylePriority.UseBorders = false;
        this.dhtc.StylePriority.UsePadding = false;
        this.dhtc.StylePriority.UseTextAlignment = false;
        this.dhtc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.dhtc.Weight = 0.46806371965950277D;
        // 
        // ngayht
        // 
        this.ngayht.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ngayht.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngayht", "{0:dd/MM/yyyy}")});
        this.ngayht.Dpi = 100F;
        this.ngayht.Name = "ngayht";
        this.ngayht.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.ngayht.StylePriority.UseBorders = false;
        this.ngayht.StylePriority.UsePadding = false;
        this.ngayht.StylePriority.UseTextAlignment = false;
        this.ngayht.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.ngayht.Weight = 0.24071846714462747D;
        // 
        // ma_sp
        // 
        this.ma_sp.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ma_sp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma_sp")});
        this.ma_sp.Dpi = 100F;
        this.ma_sp.Name = "ma_sp";
        this.ma_sp.StylePriority.UseBorders = false;
        this.ma_sp.StylePriority.UseTextAlignment = false;
        this.ma_sp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.ma_sp.Weight = 0.38302356264332466D;
        // 
        // ten_sp
        // 
        this.ten_sp.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ten_sp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ten_sp")});
        this.ten_sp.Dpi = 100F;
        this.ten_sp.Name = "ten_sp";
        this.ten_sp.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.ten_sp.StylePriority.UseBorders = false;
        this.ten_sp.StylePriority.UsePadding = false;
        this.ten_sp.Weight = 0.62058428736905835D;
        // 
        // dvt
        // 
        this.dvt.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.dvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dvt")});
        this.dvt.Dpi = 100F;
        this.dvt.Name = "dvt";
        this.dvt.StylePriority.UseBorders = false;
        this.dvt.StylePriority.UseTextAlignment = false;
        this.dvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.dvt.Weight = 0.13867030776272457D;
        // 
        // sl
        // 
        this.sl.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl", "{0:#,#0.00}")});
        this.sl.Dpi = 100F;
        this.sl.Name = "sl";
        this.sl.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.sl.StylePriority.UseBorders = false;
        this.sl.StylePriority.UsePadding = false;
        this.sl.StylePriority.UseTextAlignment = false;
        this.sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl.Weight = 0.24524481634107043D;
        // 
        // sl_daxuat
        // 
        this.sl_daxuat.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.sl_daxuat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_daxuat", "{0:#,#0.00}")});
        this.sl_daxuat.Dpi = 100F;
        this.sl_daxuat.Name = "sl_daxuat";
        this.sl_daxuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.sl_daxuat.StylePriority.UseBorders = false;
        this.sl_daxuat.StylePriority.UsePadding = false;
        this.sl_daxuat.StylePriority.UseTextAlignment = false;
        this.sl_daxuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_daxuat.Weight = 0.25789796047281982D;
        // 
        // sl_conlai
        // 
        this.sl_conlai.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.sl_conlai.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_conlai", "{0:#,#0.00}")});
        this.sl_conlai.Dpi = 100F;
        this.sl_conlai.Name = "sl_conlai";
        this.sl_conlai.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.sl_conlai.StylePriority.UseBorders = false;
        this.sl_conlai.StylePriority.UsePadding = false;
        this.sl_conlai.StylePriority.UseTextAlignment = false;
        this.sl_conlai.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_conlai.Weight = 0.25686624407080533D;
        // 
        // TopMargin
        // 
        this.TopMargin.Dpi = 100F;
        this.TopMargin.HeightF = 0F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Dpi = 100F;
        this.BottomMargin.HeightF = 148.9583F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ngay,
            this.xrLabel2,
            this.xrLabel1});
        this.ReportHeader.Dpi = 100F;
        this.ReportHeader.HeightF = 118.6282F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // ngay
        // 
        this.ngay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngay")});
        this.ngay.Dpi = 100F;
        this.ngay.LocationFloat = new DevExpress.Utils.PointFloat(0.9999591F, 72.62823F);
        this.ngay.Multiline = true;
        this.ngay.Name = "ngay";
        this.ngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ngay.SizeF = new System.Drawing.SizeF(799.0001F, 23F);
        this.ngay.StylePriority.UseTextAlignment = false;
        this.ngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(4.415158E-06F, 51.93911F);
        this.xrLabel2.Multiline = true;
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(800F, 20.68912F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UsePadding = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "BÁO CÁO VẬT TƯ THEO ĐƠN HÀNG";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel1.Multiline = true;
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(249.8397F, 51.93911F);
        this.xrLabel1.StylePriority.UsePadding = false;
        this.xrLabel1.Text = "CTY TNHH ANCO BINH DUONG\r\nXƯỞNG ANCO 1\r\nMã số thuế  :  3700318266";
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrTable3,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrLabel9});
        this.ReportFooter.Dpi = 100F;
        this.ReportFooter.HeightF = 100F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel3
        // 
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(401.9999F, 48.00002F);
        this.xrLabel3.Multiline = true;
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(198F, 23F);
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Xưởng Sản xuất";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.Dpi = 100F;
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(1.525879E-05F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(799.9999F, 25F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.xrTableCell17,
            this.xrTableCell18,
            this.xrTableCell19,
            this.xrTableCell20,
            this.xrTableCell21,
            this.xrTableCell22,
            this.xrTableCell23,
            this.xrTableCell24});
        this.xrTableRow3.Dpi = 100F;
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell10.Dpi = 100F;
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseBorders = false;
        this.xrTableCell10.StylePriority.UseTextAlignment = false;
        this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell10.Weight = 0.13216077124464454D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell17.Dpi = 100F;
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseBorders = false;
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell17.Weight = 0.46806373732054773D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell18.Dpi = 100F;
        this.xrTableCell18.Multiline = true;
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrTableCell18.StylePriority.UseBorders = false;
        this.xrTableCell18.StylePriority.UsePadding = false;
        this.xrTableCell18.StylePriority.UseTextAlignment = false;
        this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell18.Weight = 0.24071846685389575D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell19.Dpi = 100F;
        this.xrTableCell19.Multiline = true;
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseBorders = false;
        this.xrTableCell19.StylePriority.UseTextAlignment = false;
        this.xrTableCell19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell19.Weight = 0.3831009473554467D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell20.Dpi = 100F;
        this.xrTableCell20.Multiline = true;
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrTableCell20.StylePriority.UseBorders = false;
        this.xrTableCell20.StylePriority.UsePadding = false;
        this.xrTableCell20.Weight = 0.61930285858500767D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell21.Dpi = 100F;
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.StylePriority.UseBorders = false;
        this.xrTableCell21.StylePriority.UseTextAlignment = false;
        this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell21.Weight = 0.13986788222823685D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell22.Dpi = 100F;
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.xrTableCell22.StylePriority.UseBorders = false;
        this.xrTableCell22.StylePriority.UsePadding = false;
        this.xrTableCell22.StylePriority.UseTextAlignment = false;
        this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell22.Weight = 0.24641068315506365D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell23.Dpi = 100F;
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.xrTableCell23.StylePriority.UseBorders = false;
        this.xrTableCell23.StylePriority.UsePadding = false;
        this.xrTableCell23.StylePriority.UseTextAlignment = false;
        this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell23.Weight = 0.25675043929138835D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell24.Dpi = 100F;
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.xrTableCell24.StylePriority.UseBorders = false;
        this.xrTableCell24.StylePriority.UsePadding = false;
        this.xrTableCell24.StylePriority.UseTextAlignment = false;
        this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell24.Weight = 0.25685436768953152D;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Dpi = 100F;
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(550.6113F, 25F);
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
        this.xrLabel7.Dpi = 100F;
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(2.000088F, 48F);
        this.xrLabel7.Multiline = true;
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(200F, 23F);
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Người lập\r\n";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Dpi = 100F;
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(202.0001F, 48.00002F);
        this.xrLabel8.Multiline = true;
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(200F, 23F);
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "Kế toán \r\n";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Dpi = 100F;
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(599.9999F, 48.00002F);
        this.xrLabel9.Multiline = true;
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(200F, 23F);
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Ban  Giám đốc\r\n";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // PageHeader
        // 
        this.PageHeader.Dpi = 100F;
        this.PageHeader.HeightF = 0F;
        this.PageHeader.Name = "PageHeader";
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xuong});
        this.GroupHeader1.Dpi = 100F;
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("xuong", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.GroupHeader1.HeightF = 62.63689F;
        this.GroupHeader1.Name = "GroupHeader1";
        this.GroupHeader1.RepeatEveryPage = true;
        // 
        // xrTable1
        // 
        this.xrTable1.BackColor = System.Drawing.Color.Silver;
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Dpi = 100F;
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23.5F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(800F, 39.13689F);
        this.xrTable1.StylePriority.UseBackColor = false;
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.xrTableCell6,
            this.xrTableCell5,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell15,
            this.xrTableCell4,
            this.xrTableCell7});
        this.xrTableRow1.Dpi = 100F;
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell8.Dpi = 100F;
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.Text = "STT";
        this.xrTableCell8.Weight = 0.1321608191444057D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell6.Dpi = 100F;
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.Text = "ĐHTC";
        this.xrTableCell6.Weight = 0.46807449520535588D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell5.Dpi = 100F;
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.Text = "Ngày HT";
        this.xrTableCell5.Weight = 0.2407064930644906D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell1.Dpi = 100F;
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseBorders = false;
        this.xrTableCell1.Text = "Mã VTHH";
        this.xrTableCell1.Weight = 0.38303104319594433D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell2.Dpi = 100F;
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseBorders = false;
        this.xrTableCell2.Text = "Tên VTHH";
        this.xrTableCell2.Weight = 0.62057813223999014D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell3.Dpi = 100F;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.Text = "ĐVT";
        this.xrTableCell3.Weight = 0.13866360813491496D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell15.Dpi = 100F;
        this.xrTableCell15.Multiline = true;
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseBorders = false;
        this.xrTableCell15.Text = "TỔNG SL";
        this.xrTableCell15.Weight = 0.24525137444278455D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell4.Dpi = 100F;
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.Text = "SL ĐÃ XUẤT";
        this.xrTableCell4.Weight = 0.25791081263130322D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell7.Dpi = 100F;
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.Text = "SL CÒN LẠI";
        this.xrTableCell7.Weight = 0.25685374632433705D;
        // 
        // xuong
        // 
        this.xuong.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "xuong")});
        this.xuong.Dpi = 100F;
        this.xuong.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xuong.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xuong.Multiline = true;
        this.xuong.Name = "xuong";
        this.xuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xuong.SizeF = new System.Drawing.SizeF(800.0001F, 23.00001F);
        this.xuong.StylePriority.UseFont = false;
        this.xuong.StylePriority.UseTextAlignment = false;
        this.xuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4});
        this.GroupFooter1.Dpi = 100F;
        this.GroupFooter1.HeightF = 25F;
        this.GroupFooter1.Name = "GroupFooter1";
        // 
        // xrTable4
        // 
        this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable4.Dpi = 100F;
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(799.9999F, 25F);
        this.xrTable4.StylePriority.UseBorders = false;
        this.xrTable4.StylePriority.UseTextAlignment = false;
        this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell16,
            this.xrTableCell25,
            this.xrTableCell26,
            this.xrTableCell27,
            this.xrTableCell28});
        this.xrTableRow4.Dpi = 100F;
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell11.Dpi = 100F;
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseBorders = false;
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell11.Weight = 0.13216077124464454D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell12.Dpi = 100F;
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseBorders = false;
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell12.Weight = 0.46806373732054773D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell13.Dpi = 100F;
        this.xrTableCell13.Multiline = true;
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrTableCell13.StylePriority.UseBorders = false;
        this.xrTableCell13.StylePriority.UsePadding = false;
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell13.Weight = 0.24071846685389575D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell14.Dpi = 100F;
        this.xrTableCell14.Multiline = true;
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseBorders = false;
        this.xrTableCell14.StylePriority.UseTextAlignment = false;
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell14.Weight = 0.38310094735544664D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell16.Dpi = 100F;
        this.xrTableCell16.Multiline = true;
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
        this.xrTableCell16.StylePriority.UseBorders = false;
        this.xrTableCell16.StylePriority.UsePadding = false;
        this.xrTableCell16.Weight = 0.61930285858500767D;
        // 
        // xrTableCell25
        // 
        this.xrTableCell25.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell25.Dpi = 100F;
        this.xrTableCell25.Name = "xrTableCell25";
        this.xrTableCell25.StylePriority.UseBorders = false;
        this.xrTableCell25.StylePriority.UseTextAlignment = false;
        this.xrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell25.Weight = 0.1398676729363536D;
        // 
        // xrTableCell26
        // 
        this.xrTableCell26.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell26.Dpi = 100F;
        this.xrTableCell26.Name = "xrTableCell26";
        this.xrTableCell26.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.xrTableCell26.StylePriority.UseBorders = false;
        this.xrTableCell26.StylePriority.UsePadding = false;
        this.xrTableCell26.StylePriority.UseTextAlignment = false;
        this.xrTableCell26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell26.Weight = 0.24639472464896486D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell27.Dpi = 100F;
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.xrTableCell27.StylePriority.UseBorders = false;
        this.xrTableCell27.StylePriority.UsePadding = false;
        this.xrTableCell27.StylePriority.UseTextAlignment = false;
        this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell27.Weight = 0.25676660708937044D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell28.Dpi = 100F;
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.xrTableCell28.StylePriority.UseBorders = false;
        this.xrTableCell28.StylePriority.UsePadding = false;
        this.xrTableCell28.StylePriority.UseTextAlignment = false;
        this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell28.Weight = 0.25685436768953152D;
        // 
        // Baocaovattu
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageHeader,
            this.GroupHeader1,
            this.GroupFooter1});
        this.Margins = new System.Drawing.Printing.Margins(13, 14, 0, 149);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "16.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}