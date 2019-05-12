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
        TonKhoGT report = new TonKhoGT();
        String sql = this.CreateSql();
        this.viewReport(report, sql);
    }

    public void viewReport(XtraReport report, String SqlQuery)
    {
        SqlDataAdapter da = new SqlDataAdapter(SqlQuery, Mbg.Data.SqlClient.SqlHelper.GetConnection);
        DataSet ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            report.DataSource = ds;
            report.DataAdapter = da;
            ReportViewer1.Report = report;
        }
        else
        {
            Response.Write("<div align='center'><h1>Không có dữ liệu</h1></div>");
        }
    }

    public String CreateSql()
    {
		HttpContext context = HttpContext.Current;
		EntityContext db = new EntityContext();
		string ntc = context.Request.QueryString["ntc"];
		string ky_ = context.Request.QueryString["ky"];
		
		string md_namtaichinh_id = db.md_namtaichinh.Where(s => s.giatri.ToString() == ntc).Select(s => s.md_namtaichinh_id).FirstOrDefault();
		md_namtaichinh_ky ky = db.md_namtaichinh_ky.Where(s => s.md_namtaichinh_id == md_namtaichinh_id & s.soky.ToString() == ky_).FirstOrDefault();
		
		string gia = context.Request.QueryString["gia"];
		
		string kho = context.Request.QueryString["kho"];
		string where_ex = "";

		string sql = string.Format(@"
		SELECT A.ma_sp,
			   A.kho,
			   A.ten_sp,
			   A.dvt,
			   sum(isnull(A.sl_dauky,0)) AS sl,
			   sum(isnull(A.sl_nhaptrongky,0)) AS sl_nhap,
			   sum(isnull(A.sl_xuattrongky, 0)) AS sl_xuat,
			   sum(isnull(A.sl_cuoiky, 0)) AS sl_cuoi,
			   sum(isnull(A.sl_dauky * A.gia,0)) AS gt_sl,
			   sum(isnull((A.sl_nhaptrongky * A.gia),0)) AS gt_nhap,
			   sum(isnull(A.sl_xuattrongky * A.gia, 0)) AS gt_xuat,
			   sum(isnull(A.sl_cuoiky * A.gia, 0)) AS gt_cuoi,
			   isnull(A.gia, 0) AS dgbq,   
			   (N'Từ ngày ' + N'{1}' + N' đến ngày ' + N'{2}') AS ngay
		FROM
				(
					SELECT  sp.ma_sanpham AS ma_sp,
							sp.mota_tiengviet AS ten_sp,
							dvt.ten_dvt AS dvt,
							kho.ten_kho AS kho,
							isnull((SELECT top 1 thk.sl_dauky WHERE ky.ngaybatdau = CONVERT(datetime,N'{1}',103)), 0) AS sl_dauky,
							thk.sl_nhaptrongky AS sl_nhaptrongky,
							thk.sl_xuattrongky AS sl_xuattrongky,
							isnull((SELECT top 1 isnull(thk.sl_cuoiky, 0) WHERE ky.ngayketthuc = CONVERT(datetime,N'{2}' + N' 23:59',103)), 0) AS sl_cuoiky,
							isnull(sp.giabinhquan, 0) as gia
							   
					FROM md_tonghopkho thk
					LEFT JOIN md_kho kho ON thk.md_kho_id = kho.md_kho_id
					LEFT join md_sanpham sp ON thk.md_sanpham_id = sp.md_sanpham_id				
					LEFT JOIN md_donvitinhsanpham dvt ON dvt.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
					INNER join md_namtaichinh_ky ky ON ky.md_namtaichinh_ky_id = thk.md_namtaichinh_ky_id
					AND (ky.ngaybatdau >= CONVERT(datetime,N'{1}',103)
					  AND ky.ngayketthuc <= CONVERT(datetime,N'{2}' + N' 23:59',103))
					WHERE kho.md_kho_id = '{0}'
				)A
		GROUP BY A.ma_sp,
			 A.kho,
			 A.ten_sp,
			 A.dvt,
			 A.gia
		ORDER BY A.ma_sp
		", kho ,ky.ngaybatdau.Value.ToString("dd/MM/yyyy") ,ky.ngayketthuc.Value.ToString("dd/MM/yyyy"), gia);		
		return sql;
    }
}

/// <summary>
/// Summary description for TonKhoGT
/// </summary>
public class TonKhoGT : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private ReportFooterBand ReportFooter;
    private XRLabel ngay;
    private XRLabel xrLabel4;
    private XRLabel kho;
    private XRLabel xrLabel1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell ma_sp;
    private XRTableCell ten_sp;
    private XRTableCell dvt;
    private XRTableCell sl;
    private XRTableCell gt_sl;
    private XRTableCell sl_nhap;
    private XRTableCell gt_nhap;
    private XRTableCell sl_xuat;
    private XRTableCell gt_xuat;
    private XRTableCell sl_cuoi;
    private XRTableCell gt_cuoi;
    private XRTableCell dgbq;
    private XRLabel xrLabel16;
    private XRLabel xrLabel17;
    private XRLabel xrLabel18;
    private XRLabel xrLabel19;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell tong_sl;
    private XRTableCell tong_gt_sl;
    private XRTableCell tong_sl_nhap;
    private XRTableCell tong_gt_nhap;
    private XRTableCell tong_sl_xuat;
    private XRTableCell tong_gt_xuat;
    private XRTableCell tong_sl_cuoi;
    private XRTableCell tong_gt_cuoi;
    private XRTableCell tong_dgbq;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private PageHeaderBand PageHeader;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell7;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRLabel xrLabel6;
    private XRTableCell xrTableCell4;
    private XRLabel xrLabel7;
    private XRLabel xrLabel9;
    private XRLabel xrLabel8;
    private XRTableCell xrTableCell5;
    private XRLabel xrLabel10;
    private XRLabel xrLabel12;
    private XRLabel xrLabel11;
    private XRTableCell xrTableCell6;
    private XRLabel xrLabel13;
    private XRLabel xrLabel14;
    private XRLabel xrLabel15;
    private XRTableCell xrTableCell8;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public TonKhoGT()
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
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary10 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma_sp = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten_sp = new DevExpress.XtraReports.UI.XRTableCell();
        this.dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.gt_sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_nhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.gt_nhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_xuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.gt_xuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl_cuoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.gt_cuoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.dgbq = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.ngay = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.kho = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_gt_sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl_nhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_gt_nhap = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl_xuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_gt_xuat = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl_cuoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_gt_cuoi = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_dgbq = new DevExpress.XtraReports.UI.XRTableCell();
        this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
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
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(1.525879E-05F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(1150F, 25F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UsePadding = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell10,
            this.ma_sp,
            this.ten_sp,
            this.dvt,
            this.sl,
            this.gt_sl,
            this.sl_nhap,
            this.gt_nhap,
            this.sl_xuat,
            this.gt_xuat,
            this.sl_cuoi,
            this.gt_cuoi,
            this.dgbq});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseBorders = false;
        this.xrTableCell10.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell10.Summary = xrSummary1;
        this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell10.Weight = 0.11965663272237107D;
        // 
        // ma_sp
        // 
        this.ma_sp.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ma_sp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma_sp")});
        this.ma_sp.Name = "ma_sp";
        this.ma_sp.StylePriority.UseBorders = false;
        this.ma_sp.Weight = 0.38149188107032656D;
        // 
        // ten_sp
        // 
        this.ten_sp.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ten_sp.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ten_sp")});
        this.ten_sp.Name = "ten_sp";
        this.ten_sp.StylePriority.UseBorders = false;
        this.ten_sp.Weight = 0.969924719093758D;
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
        this.dvt.Weight = 0.17366288809959379D;
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
        this.sl.Weight = 0.21804507937923D;
        // 
        // gt_sl
        // 
        this.gt_sl.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.gt_sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "gt_sl", "{0:#,#0}")});
        this.gt_sl.Name = "gt_sl";
        this.gt_sl.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.gt_sl.StylePriority.UseBorders = false;
        this.gt_sl.StylePriority.UsePadding = false;
        this.gt_sl.StylePriority.UseTextAlignment = false;
        this.gt_sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.gt_sl.Weight = 0.349180271367682D;
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
        this.sl_nhap.Weight = 0.218045065670901D;
        // 
        // gt_nhap
        // 
        this.gt_nhap.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.gt_nhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "gt_nhap", "{0:#,#0}")});
        this.gt_nhap.Name = "gt_nhap";
        this.gt_nhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.gt_nhap.StylePriority.UseBorders = false;
        this.gt_nhap.StylePriority.UsePadding = false;
        this.gt_nhap.StylePriority.UseTextAlignment = false;
        this.gt_nhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.gt_nhap.Weight = 0.349173144540572D;
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
        this.sl_xuat.Weight = 0.21804532391757D;
        // 
        // gt_xuat
        // 
        this.gt_xuat.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.gt_xuat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "gt_xuat", "{0:#,#0}")});
        this.gt_xuat.Name = "gt_xuat";
        this.gt_xuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.gt_xuat.StylePriority.UseBorders = false;
        this.gt_xuat.StylePriority.UsePadding = false;
        this.gt_xuat.StylePriority.UseTextAlignment = false;
        this.gt_xuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.gt_xuat.Weight = 0.349172685738977D;
        // 
        // sl_cuoi
        // 
        this.sl_cuoi.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.sl_cuoi.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_cuoi", "{0:#,#0.00}")});
        this.sl_cuoi.Name = "sl_cuoi";
        this.sl_cuoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.sl_cuoi.StylePriority.UseBorders = false;
        this.sl_cuoi.StylePriority.UsePadding = false;
        this.sl_cuoi.StylePriority.UseTextAlignment = false;
        this.sl_cuoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl_cuoi.Weight = 0.218045094462122D;
        // 
        // gt_cuoi
        // 
        this.gt_cuoi.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.gt_cuoi.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "gt_cuoi", "{0:#,#0}")});
        this.gt_cuoi.Name = "gt_cuoi";
        this.gt_cuoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.gt_cuoi.StylePriority.UseBorders = false;
        this.gt_cuoi.StylePriority.UsePadding = false;
        this.gt_cuoi.StylePriority.UseTextAlignment = false;
        this.gt_cuoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.gt_cuoi.Weight = 0.349173259377584D;
        // 
        // dgbq
        // 
        this.dgbq.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)));
        this.dgbq.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dgbq", "{0:#,#0}")});
        this.dgbq.Name = "dgbq";
        this.dgbq.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.dgbq.StylePriority.UseBorders = false;
        this.dgbq.StylePriority.UsePadding = false;
        this.dgbq.StylePriority.UseTextAlignment = false;
        this.dgbq.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.dgbq.Weight = 0.40969158792721D;
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
            this.ngay,
            this.xrLabel4,
            this.kho,
            this.xrLabel1});
        this.ReportHeader.HeightF = 96.00001F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // ngay
        // 
        this.ngay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngay")});
        this.ngay.LocationFloat = new DevExpress.Utils.PointFloat(8.99995F, 73F);
        this.ngay.Multiline = true;
        this.ngay.Name = "ngay";
        this.ngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ngay.SizeF = new System.Drawing.SizeF(1141F, 23.00001F);
        this.ngay.StylePriority.UseTextAlignment = false;
        this.ngay.Text = "Từ ngày:                   Đến ngày:";
        this.ngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(8.99995F, 50.00001F);
        this.xrLabel4.Multiline = true;
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(1141F, 22.99999F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "SỔ TỔNG HỢP NHẬP XUẤT TỒN KHO";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // kho
        // 
        this.kho.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "kho")});
        this.kho.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.kho.LocationFloat = new DevExpress.Utils.PointFloat(257.9583F, 0F);
        this.kho.Multiline = true;
        this.kho.Name = "kho";
        this.kho.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.kho.SizeF = new System.Drawing.SizeF(892.0419F, 23F);
        this.kho.StylePriority.UseFont = false;
        this.kho.StylePriority.UseTextAlignment = false;
        this.kho.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        // 
        // xrLabel1
        // 
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(8.999939F, 2.026558E-06F);
        this.xrLabel1.Multiline = true;
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(248.9583F, 46.95834F);
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "CTY TNHH ANCO BINH DUONG\r\nXƯỞNG ANCO 2\r\nMã số thuế  :  3700318266";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel16,
            this.xrLabel17,
            this.xrLabel18,
            this.xrLabel19,
            this.xrTable3});
        this.ReportFooter.HeightF = 100F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel16
        // 
        this.xrLabel16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(712.5F, 62.74999F);
        this.xrLabel16.Multiline = true;
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(266F, 23F);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "Ban  Giám đốc\r\n";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel17
        // 
        this.xrLabel17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel17.LocationFloat = new DevExpress.Utils.PointFloat(437.4998F, 62.74999F);
        this.xrLabel17.Multiline = true;
        this.xrLabel17.Name = "xrLabel17";
        this.xrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel17.SizeF = new System.Drawing.SizeF(275.0001F, 23F);
        this.xrLabel17.StylePriority.UseFont = false;
        this.xrLabel17.StylePriority.UseTextAlignment = false;
        this.xrLabel17.Text = "Kế toán \r\n";
        this.xrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel18
        // 
        this.xrLabel18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel18.LocationFloat = new DevExpress.Utils.PointFloat(171.4999F, 62.75F);
        this.xrLabel18.Multiline = true;
        this.xrLabel18.Name = "xrLabel18";
        this.xrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel18.SizeF = new System.Drawing.SizeF(266F, 23F);
        this.xrLabel18.StylePriority.UseFont = false;
        this.xrLabel18.StylePriority.UseTextAlignment = false;
        this.xrLabel18.Text = "Người lập\r\n";
        this.xrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel19
        // 
        this.xrLabel19.LocationFloat = new DevExpress.Utils.PointFloat(900.6111F, 24.99999F);
        this.xrLabel19.Multiline = true;
        this.xrLabel19.Name = "xrLabel19";
        this.xrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel19.SizeF = new System.Drawing.SizeF(249.3888F, 23F);
        this.xrLabel19.StylePriority.UseTextAlignment = false;
        this.xrLabel19.Text = "Ngày .......  tháng ........ năm ......";
        this.xrLabel19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(1150F, 25F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell14,
            this.xrTableCell15,
            this.tong_sl,
            this.tong_gt_sl,
            this.tong_sl_nhap,
            this.tong_gt_nhap,
            this.tong_sl_xuat,
            this.tong_gt_xuat,
            this.tong_sl_cuoi,
            this.tong_gt_cuoi,
            this.tong_dgbq});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseBorders = false;
        this.xrTableCell11.Weight = 0.11965668989540951D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseBorders = false;
        this.xrTableCell14.Weight = 0.38149192509546437D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseBorders = false;
        this.xrTableCell15.StylePriority.UseFont = false;
        this.xrTableCell15.Text = "TỔNG CỘNG";
        this.xrTableCell15.Weight = 1.1435877709541535D;
        // 
        // tong_sl
        // 
        this.tong_sl.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl")});
        this.tong_sl.Multiline = true;
        this.tong_sl.Name = "tong_sl";
        this.tong_sl.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_sl.StylePriority.UseBorders = false;
        this.tong_sl.StylePriority.UsePadding = false;
        this.tong_sl.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:#,#0.00}";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl.Summary = xrSummary2;
        this.tong_sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl.Weight = 0.218044997952058D;
        // 
        // tong_gt_sl
        // 
        this.tong_gt_sl.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_gt_sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "gt_sl")});
        this.tong_gt_sl.Multiline = true;
        this.tong_gt_sl.Name = "tong_gt_sl";
        this.tong_gt_sl.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_gt_sl.StylePriority.UseBorders = false;
        this.tong_gt_sl.StylePriority.UsePadding = false;
        this.tong_gt_sl.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:#,#0}";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_gt_sl.Summary = xrSummary3;
        this.tong_gt_sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_gt_sl.Weight = 0.349180637522034D;
        // 
        // tong_sl_nhap
        // 
        this.tong_sl_nhap.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl_nhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_nhap")});
        this.tong_sl_nhap.Multiline = true;
        this.tong_sl_nhap.Name = "tong_sl_nhap";
        this.tong_sl_nhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_sl_nhap.StylePriority.UseBorders = false;
        this.tong_sl_nhap.StylePriority.UsePadding = false;
        this.tong_sl_nhap.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:#,#0.00}";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl_nhap.Summary = xrSummary4;
        this.tong_sl_nhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl_nhap.Weight = 0.218044883225746D;
        // 
        // tong_gt_nhap
        // 
        this.tong_gt_nhap.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_gt_nhap.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "gt_nhap")});
        this.tong_gt_nhap.Multiline = true;
        this.tong_gt_nhap.Name = "tong_gt_nhap";
        this.tong_gt_nhap.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_gt_nhap.StylePriority.UseBorders = false;
        this.tong_gt_nhap.StylePriority.UsePadding = false;
        this.tong_gt_nhap.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:#,#0}";
        xrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_gt_nhap.Summary = xrSummary5;
        this.tong_gt_nhap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_gt_nhap.Weight = 0.34917295076505D;
        // 
        // tong_sl_xuat
        // 
        this.tong_sl_xuat.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.tong_sl_xuat.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl_xuat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_xuat")});
        this.tong_sl_xuat.Multiline = true;
        this.tong_sl_xuat.Name = "tong_sl_xuat";
        this.tong_sl_xuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_sl_xuat.StylePriority.UseBorderDashStyle = false;
        this.tong_sl_xuat.StylePriority.UseBorders = false;
        this.tong_sl_xuat.StylePriority.UsePadding = false;
        this.tong_sl_xuat.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = "{0:#,#0.00}";
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl_xuat.Summary = xrSummary6;
        this.tong_sl_xuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl_xuat.Weight = 0.218045571928187D;
        // 
        // tong_gt_xuat
        // 
        this.tong_gt_xuat.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
        this.tong_gt_xuat.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_gt_xuat.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "gt_xuat")});
        this.tong_gt_xuat.Multiline = true;
        this.tong_gt_xuat.Name = "tong_gt_xuat";
        this.tong_gt_xuat.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_gt_xuat.StylePriority.UseBorderDashStyle = false;
        this.tong_gt_xuat.StylePriority.UseBorders = false;
        this.tong_gt_xuat.StylePriority.UsePadding = false;
        this.tong_gt_xuat.StylePriority.UseTextAlignment = false;
        xrSummary7.FormatString = "{0:#,#0}";
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_gt_xuat.Summary = xrSummary7;
        this.tong_gt_xuat.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_gt_xuat.Weight = 0.349172721645591D;
        // 
        // tong_sl_cuoi
        // 
        this.tong_sl_cuoi.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl_cuoi.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl_cuoi")});
        this.tong_sl_cuoi.Multiline = true;
        this.tong_sl_cuoi.Name = "tong_sl_cuoi";
        this.tong_sl_cuoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_sl_cuoi.StylePriority.UseBorders = false;
        this.tong_sl_cuoi.StylePriority.UsePadding = false;
        this.tong_sl_cuoi.StylePriority.UseTextAlignment = false;
        xrSummary8.FormatString = "{0:#,#0.00}";
        xrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl_cuoi.Summary = xrSummary8;
        this.tong_sl_cuoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl_cuoi.Weight = 0.218044884981748D;
        // 
        // tong_gt_cuoi
        // 
        this.tong_gt_cuoi.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_gt_cuoi.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "gt_cuoi")});
        this.tong_gt_cuoi.Multiline = true;
        this.tong_gt_cuoi.Name = "tong_gt_cuoi";
        this.tong_gt_cuoi.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_gt_cuoi.StylePriority.UseBorders = false;
        this.tong_gt_cuoi.StylePriority.UsePadding = false;
        this.tong_gt_cuoi.StylePriority.UseTextAlignment = false;
        xrSummary9.FormatString = "{0:#,#0}";
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_gt_cuoi.Summary = xrSummary9;
        this.tong_gt_cuoi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_gt_cuoi.Weight = 0.349173411432001D;
        // 
        // tong_dgbq
        // 
        this.tong_dgbq.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)
        | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_dgbq.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dgbq")});
        this.tong_dgbq.Multiline = true;
        this.tong_dgbq.Name = "tong_dgbq";
        this.tong_dgbq.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
        this.tong_dgbq.StylePriority.UseBorders = false;
        this.tong_dgbq.StylePriority.UsePadding = false;
        this.tong_dgbq.StylePriority.UseTextAlignment = false;
        xrSummary10.FormatString = "{0:#,#0}";
        xrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_dgbq.Summary = xrSummary10;
        this.tong_dgbq.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_dgbq.Weight = 0.409691834035538D;
        // 
        // PageHeader
        // 
        this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
        this.PageHeader.HeightF = 50F;
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
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(1150F, 50F);
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell8});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 3.125D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.Text = "STT";
        this.xrTableCell9.Weight = 0.10971077197355519D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseBorders = false;
        this.xrTableCell1.Text = "Mã VTHH";
        this.xrTableCell1.Weight = 0.34978210297970813D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseBorders = false;
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "Tên VTHH";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.88930418578253934D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.StylePriority.UsePadding = false;
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "ĐVT";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell3.Weight = 0.15922807589248042D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell7.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel5,
            this.xrLabel6});
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.StylePriority.UsePadding = false;
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell7.Weight = 0.520077341451892D;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.002502441F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(150.882F, 24.96684F);
        this.xrLabel3.StylePriority.UseBorders = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Tồn đầu";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 24.96933F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(57.99994F, 25.03067F);
        this.xrLabel5.StylePriority.UseBorders = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "SL";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel6
        // 
        this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(57.99993F, 24.96934F);
        this.xrLabel6.Name = "xrLabel6";
        this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel6.SizeF = new System.Drawing.SizeF(92.88F, 25.03066F);
        this.xrLabel6.StylePriority.UseBorders = false;
        this.xrLabel6.StylePriority.UseTextAlignment = false;
        this.xrLabel6.Text = "GT";
        this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel7,
            this.xrLabel9,
            this.xrLabel8});
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.StylePriority.UsePadding = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell4.Weight = 0.520070857578406D;
        // 
        // xrLabel7
        // 
        this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(5.435944E-05F, 0.002502441F);
        this.xrLabel7.Name = "xrLabel7";
        this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel7.SizeF = new System.Drawing.SizeF(150.88F, 24.9668F);
        this.xrLabel7.StylePriority.UseBorders = false;
        this.xrLabel7.StylePriority.UseTextAlignment = false;
        this.xrLabel7.Text = "Nhập";
        this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(58.00005F, 24.96935F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(92.88F, 25.03066F);
        this.xrLabel9.StylePriority.UseBorders = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "GT";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel8
        // 
        this.xrLabel8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(5.435944E-05F, 24.96931F);
        this.xrLabel8.Name = "xrLabel8";
        this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel8.SizeF = new System.Drawing.SizeF(58F, 25.03067F);
        this.xrLabel8.StylePriority.UseBorders = false;
        this.xrLabel8.StylePriority.UseTextAlignment = false;
        this.xrLabel8.Text = "SL";
        this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel10,
            this.xrLabel12,
            this.xrLabel11});
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.StylePriority.UsePadding = false;
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell5.Weight = 0.520070609467999D;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0.0001764297F, 0.002540588F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(150.8798F, 24.9668F);
        this.xrLabel10.StylePriority.UseBorders = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Xuất";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel12
        // 
        this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(58.00005F, 24.96931F);
        this.xrLabel12.Name = "xrLabel12";
        this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel12.SizeF = new System.Drawing.SizeF(92.88F, 25.03067F);
        this.xrLabel12.StylePriority.UseBorders = false;
        this.xrLabel12.StylePriority.UseTextAlignment = false;
        this.xrLabel12.Text = "GT";
        this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel11
        // 
        this.xrLabel11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(5.435944E-05F, 24.96935F);
        this.xrLabel11.Name = "xrLabel11";
        this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel11.SizeF = new System.Drawing.SizeF(58F, 25.03063F);
        this.xrLabel11.StylePriority.UseBorders = false;
        this.xrLabel11.StylePriority.UseTextAlignment = false;
        this.xrLabel11.Text = "SL";
        this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell6.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel13,
            this.xrLabel14,
            this.xrLabel15});
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.StylePriority.UsePadding = false;
        this.xrTableCell6.StylePriority.UseTextAlignment = false;
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        this.xrTableCell6.Weight = 0.520070639120032D;
        // 
        // xrLabel13
        // 
        this.xrLabel13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0.002540588F);
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(150.8799F, 24.96686F);
        this.xrLabel13.StylePriority.UseBorders = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "Tồn cuối";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(5.435944E-05F, 24.96935F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(58F, 25.03062F);
        this.xrLabel14.StylePriority.UseBorders = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "SL";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel15
        // 
        this.xrLabel15.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(57.99993F, 24.96939F);
        this.xrLabel15.Name = "xrLabel15";
        this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel15.SizeF = new System.Drawing.SizeF(92.88F, 25.03064F);
        this.xrLabel15.StylePriority.UseBorders = false;
        this.xrLabel15.StylePriority.UseTextAlignment = false;
        this.xrLabel15.Text = "GT";
        this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
        | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 5, 0, 100F);
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.StylePriority.UsePadding = false;
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "ĐGBQ";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell8.Weight = 0.375638234346437D;
        // 
        // TonKhoGT
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageHeader});
        this.Landscape = true;
        this.Margins = new System.Drawing.Printing.Margins(9, 10, 0, 0);
        this.PageHeight = 827;
        this.PageWidth = 1169;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "17.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}

