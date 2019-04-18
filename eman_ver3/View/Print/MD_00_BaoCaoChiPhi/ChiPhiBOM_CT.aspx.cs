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

public partial class PrintControllers_ChiPhiBOM_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityContext db = new EntityContext();
        rptTienCongKhoan report = new rptTienCongKhoan();
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
        string gia = context.Request.QueryString["gia"];

        string tungay = context.Request.QueryString["tu"];
        string denngay = context.Request.QueryString["den"];

        DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);

        DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);

        /* string ntc = context.Request.QueryString["ntc"];
        string ky_ = context.Request.QueryString["ky"];
		
        string md_namtaichinh_id = db.md_namtaichinh.Where(s => s.giatri.ToString() == ntc).Select(s => s.md_namtaichinh_id).FirstOrDefault();
        md_namtaichinh_ky ky = db.md_namtaichinh_ky.Where(s => s.md_namtaichinh_id == md_namtaichinh_id & s.soky.ToString() == ky_).FirstOrDefault();
        ky.ngaybatdau.Value.ToString("dd/MM/yyyy"), ky.ngayketthuc.Value.ToString("dd/MM/yyyy") */
        string md_phanxuong_id = context.Request.QueryString["xuong"];
        string where_ex = "";
		if(md_phanxuong_id != null & md_phanxuong_id != "")
			md_phanxuong_id = " and px.md_phanxuong_id = '"+ md_phanxuong_id +"' ";
		else
			md_phanxuong_id = "";
        
		string sql = string.Format(@"		
		SELECT N'Từ ngày: ' + N'{0}' + N' đến ngày: ' + N'{1}' AS ngay,
				N'Phân xưởng: ' + A.xuong AS xuong,
				A.ma_vthh AS ma_vthh,
				A.sl AS sl,
				A.ten_dvt AS ten_dvt,
				A.gia AS dg_nc,
				(A.sl * A.gia) AS thanhtien
		FROM
		( SELECT px.ten_phanxuong AS xuong,
				sp.ma_sanpham AS ma_vthh,
				sum(nknb_cdh.sl_daxuat) AS sl,
				dvt.ten_dvt AS ten_dvt,
				( SELECT top 1 bg.quydoi
					FROM md_taphopgia gsp
					INNER JOIN md_taphopgia_cdh bg ON bg.md_taphopgia_id = gsp.md_taphopgia_id
					WHERE gsp.md_taphopgia_id = '{3}'
					AND gsp.md_trangthai_id = 'HIEULUC'
					AND sp.md_sanpham_id = bg.md_sanpham_id) AS gia
		FROM md_xuatkhonb nknb
			LEFT JOIN md_xuatkhonb_cdh nknb_cdh ON nknb.md_xuatkhonb_id = nknb_cdh.md_xuatkhonb_id
			LEFT join md_lenhsanxuat lsx ON nknb.md_lenhsanxuat_id = lsx.md_lenhsanxuat_id
			LEFT join md_lenhsanxuat_tosx lsx_tosx ON nknb.md_lenhsanxuat_tosx_id = lsx_tosx.md_lenhsanxuat_tosx_id
			--LEFT join md_phanxuong_to px_to ON px_to.md_to_id = lsx_tosx.md_phanxuong_to_id
			INNER JOIN (
				select px2.md_phanxuong_id as md_phanxuong_id, px2.ten_phanxuong as ten_phanxuong
				from md_phanxuong px2 
				union 
				select px2.md_phongban_id as md_phanxuong_id, px2.ten_phongban as ten_phanxuong 
				from md_phongban px2 
			)px on nknb.xuatden = px.md_phanxuong_id
			LEFT join md_sanpham sp ON nknb_cdh.md_sanpham_id = sp.md_sanpham_id
			LEFT JOIN md_donvitinhsanpham dvt ON dvt.md_donvitinhsanpham_id = nknb_cdh.md_donvitinhsanpham_id
		WHERE nknb.ngaychuyen >= convert(datetime,N'{0} 00:00',103)
			AND nknb.ngaychuyen <= convert(datetime,N'{1} 23:59' ,103)
			AND nknb.trangthai = 'HIEULUC'
			{2}
			AND nknb_cdh.sl_daxuat > 0
			AND nknb.bosung = '0'
			group by px.ten_phanxuong, sp.ma_sanpham, dvt.ten_dvt, sp.md_sanpham_id ) AS A
		WHERE A.ma_vthh IN
		(SELECT sp.ma_sanpham
		FROM md_sanpham_bom_vattu vt
		LEFT join md_sanpham sp ON vt.md_sanpham_id = sp.md_sanpham_id
		GROUP BY sp.ma_sanpham)
		ORDER BY A.ma_vthh ASC
		", tu.ToString("dd/MM/yyyy"), den.ToString("dd/MM/yyyy"), md_phanxuong_id, gia);
        return sql;
    }
}

/// <summary>
/// Summary description for rptTienCongKhoan
/// </summary>
public partial class rptTienCongKhoan : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell ma_vthh;
    private XRTableCell ten_dvt;
    private XRTableCell sl;
    private XRTableCell dg_nc;
    private XRTableCell thanhtien;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel16;
    private XRLabel xrLabel14;
    private XRLabel xrLabel13;
    private XRLabel xrLabel10;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell tong_sl;
    private XRTableCell xrTableCell17;
    private XRTableCell tong_thanhtien;
    private XRLabel xrLabel3;
    private XRLabel xrLabel4;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell21;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel2;
    private XRLabel xrLabel1;
    private XRLabel ngay;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell19;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell7;
    private XRLabel xuong;
    private GroupFooterBand GroupFooter1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell9;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rptTienCongKhoan()
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
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary5 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary6 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary7 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary8 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary9 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ma_vthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten_dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.dg_nc = new DevExpress.XtraReports.UI.XRTableCell();
        this.thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel16 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.ngay = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xuong = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.Detail.Dpi = 100F;
        this.Detail.Font = new System.Drawing.Font("Arial", 9.75F);
        this.Detail.HeightF = 29.16667F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.StylePriority.UseFont = false;
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable3
        // 
        this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTable3.Dpi = 100F;
        this.xrTable3.Font = new System.Drawing.Font("Arial", 9.75F);
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(802.67F, 29.16667F);
        this.xrTable3.StylePriority.UseBorders = false;
        this.xrTable3.StylePriority.UseFont = false;
        this.xrTable3.StylePriority.UseTextAlignment = false;
        this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell20,
            this.ma_vthh,
            this.ten_dvt,
            this.sl,
            this.dg_nc,
            this.thanhtien});
        this.xrTableRow3.Dpi = 100F;
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell20.Dpi = 100F;
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.StylePriority.UseBorders = false;
        this.xrTableCell20.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell20.Summary = xrSummary1;
        this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell20.Weight = 0.14696898129239239D;
        // 
        // ma_vthh
        // 
        this.ma_vthh.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ma_vthh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma_vthh")});
        this.ma_vthh.Dpi = 100F;
        this.ma_vthh.Font = new System.Drawing.Font("Arial", 9.75F);
        this.ma_vthh.Name = "ma_vthh";
        this.ma_vthh.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.ma_vthh.StylePriority.UseBorders = false;
        this.ma_vthh.StylePriority.UseFont = false;
        this.ma_vthh.StylePriority.UsePadding = false;
        this.ma_vthh.StylePriority.UseTextAlignment = false;
        this.ma_vthh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.ma_vthh.Weight = 0.4256488535410608D;
        // 
        // ten_dvt
        // 
        this.ten_dvt.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ten_dvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ten_dvt")});
        this.ten_dvt.Dpi = 100F;
        this.ten_dvt.Font = new System.Drawing.Font("Arial", 9.75F);
        this.ten_dvt.Name = "ten_dvt";
        this.ten_dvt.StylePriority.UseBorders = false;
        this.ten_dvt.StylePriority.UseFont = false;
        this.ten_dvt.StylePriority.UseTextAlignment = false;
        this.ten_dvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.ten_dvt.Weight = 0.14223851209361912D;
        // 
        // sl
        // 
        this.sl.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl", "{0:#,#.#}")});
        this.sl.Dpi = 100F;
        this.sl.Font = new System.Drawing.Font("Arial", 9.75F);
        this.sl.Name = "sl";
        this.sl.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.sl.StylePriority.UseBorders = false;
        this.sl.StylePriority.UseFont = false;
        this.sl.StylePriority.UsePadding = false;
        this.sl.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:#,#.#}";
        this.sl.Summary = xrSummary2;
        this.sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sl.Weight = 0.27339289940475242D;
        // 
        // dg_nc
        // 
        this.dg_nc.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.dg_nc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "dg_nc", "{0:#,#0.00}")});
        this.dg_nc.Dpi = 100F;
        this.dg_nc.Font = new System.Drawing.Font("Arial", 9.75F);
        this.dg_nc.Name = "dg_nc";
        this.dg_nc.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.dg_nc.StylePriority.UseBorders = false;
        this.dg_nc.StylePriority.UseFont = false;
        this.dg_nc.StylePriority.UsePadding = false;
        this.dg_nc.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:#,#.#}";
        this.dg_nc.Summary = xrSummary3;
        this.dg_nc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.dg_nc.Weight = 0.38321381387557896D;
        // 
        // thanhtien
        // 
        this.thanhtien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thanhtien", "{0:#,#0.00}")});
        this.thanhtien.Dpi = 100F;
        this.thanhtien.Font = new System.Drawing.Font("Arial", 9.75F);
        this.thanhtien.Name = "thanhtien";
        this.thanhtien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.thanhtien.StylePriority.UseFont = false;
        this.thanhtien.StylePriority.UsePadding = false;
        this.thanhtien.StylePriority.UseTextAlignment = false;
        this.thanhtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.thanhtien.Weight = 0.48981158721946738D;
        // 
        // TopMargin
        // 
        this.TopMargin.Dpi = 100F;
        this.TopMargin.Font = new System.Drawing.Font("Arial", 9.75F);
        this.TopMargin.HeightF = 0F;
        this.TopMargin.Name = "TopMargin";
        this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 5, 100F);
        this.TopMargin.StylePriority.UseFont = false;
        this.TopMargin.StylePriority.UsePadding = false;
        this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // BottomMargin
        // 
        this.BottomMargin.Dpi = 100F;
        this.BottomMargin.Font = new System.Drawing.Font("Arial", 9.75F);
        this.BottomMargin.HeightF = 16F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.StylePriority.UseFont = false;
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel4,
            this.xrLabel3,
            this.xrTable4,
            this.xrLabel16,
            this.xrLabel14,
            this.xrLabel13,
            this.xrLabel10});
        this.ReportFooter.Dpi = 100F;
        this.ReportFooter.HeightF = 201.0417F;
        this.ReportFooter.KeepTogether = true;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel4
        // 
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 52.95834F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(160.6F, 23F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Người lập";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(554.6108F, 29.16667F);
        this.xrLabel3.Multiline = true;
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(249.3888F, 23F);
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Ngày .......  tháng ........ năm ......";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable4
        // 
        this.xrTable4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTable4.Dpi = 100F;
        this.xrTable4.Font = new System.Drawing.Font("Arial", 9.75F);
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(802.67F, 29.16667F);
        this.xrTable4.StylePriority.UseBorders = false;
        this.xrTable4.StylePriority.UseFont = false;
        this.xrTable4.StylePriority.UseTextAlignment = false;
        this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell21,
            this.tong_sl,
            this.xrTableCell17,
            this.tong_thanhtien});
        this.xrTableRow4.Dpi = 100F;
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell21
        // 
        this.xrTableCell21.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell21.Dpi = 100F;
        this.xrTableCell21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell21.Name = "xrTableCell21";
        this.xrTableCell21.StylePriority.UseBorders = false;
        this.xrTableCell21.StylePriority.UseFont = false;
        this.xrTableCell21.StylePriority.UseTextAlignment = false;
        this.xrTableCell21.Text = "Tổng cộng";
        this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell21.Weight = 1.1706833237591114D;
        // 
        // tong_sl
        // 
        this.tong_sl.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl")});
        this.tong_sl.Dpi = 100F;
        this.tong_sl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.tong_sl.Name = "tong_sl";
        this.tong_sl.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.tong_sl.StylePriority.UseBorders = false;
        this.tong_sl.StylePriority.UseFont = false;
        this.tong_sl.StylePriority.UsePadding = false;
        this.tong_sl.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:#,#.#}";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_sl.Summary = xrSummary4;
        this.tong_sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_sl.Weight = 0.44772146423727854D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell17.Dpi = 100F;
        this.xrTableCell17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell17.StylePriority.UseBorders = false;
        this.xrTableCell17.StylePriority.UseFont = false;
        this.xrTableCell17.StylePriority.UsePadding = false;
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        xrSummary5.FormatString = "{0:#,#.#}";
        this.xrTableCell17.Summary = xrSummary5;
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell17.Weight = 0.62756950792291255D;
        // 
        // tong_thanhtien
        // 
        this.tong_thanhtien.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_thanhtien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thanhtien")});
        this.tong_thanhtien.Dpi = 100F;
        this.tong_thanhtien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.tong_thanhtien.Name = "tong_thanhtien";
        this.tong_thanhtien.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.tong_thanhtien.StylePriority.UseBorders = false;
        this.tong_thanhtien.StylePriority.UseFont = false;
        this.tong_thanhtien.StylePriority.UsePadding = false;
        this.tong_thanhtien.StylePriority.UseTextAlignment = false;
        xrSummary6.FormatString = "{0:#,#0.00}";
        xrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.tong_thanhtien.Summary = xrSummary6;
        this.tong_thanhtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_thanhtien.Weight = 0.80213912786770725D;
        // 
        // xrLabel16
        // 
        this.xrLabel16.Dpi = 100F;
        this.xrLabel16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel16.LocationFloat = new DevExpress.Utils.PointFloat(643.3996F, 52.95834F);
        this.xrLabel16.Multiline = true;
        this.xrLabel16.Name = "xrLabel16";
        this.xrLabel16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel16.SizeF = new System.Drawing.SizeF(160.6F, 23F);
        this.xrLabel16.StylePriority.UseFont = false;
        this.xrLabel16.StylePriority.UseTextAlignment = false;
        this.xrLabel16.Text = "Ban Giám Đốc\r";
        this.xrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel14
        // 
        this.xrLabel14.Dpi = 100F;
        this.xrLabel14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(482.7996F, 52.95834F);
        this.xrLabel14.Name = "xrLabel14";
        this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel14.SizeF = new System.Drawing.SizeF(160.6F, 23F);
        this.xrLabel14.StylePriority.UseFont = false;
        this.xrLabel14.StylePriority.UseTextAlignment = false;
        this.xrLabel14.Text = "Quản đốc PX";
        this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel13
        // 
        this.xrLabel13.Dpi = 100F;
        this.xrLabel13.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(322.1996F, 52.95834F);
        this.xrLabel13.Multiline = true;
        this.xrLabel13.Name = "xrLabel13";
        this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel13.SizeF = new System.Drawing.SizeF(160.6F, 23F);
        this.xrLabel13.StylePriority.UseFont = false;
        this.xrLabel13.StylePriority.UseTextAlignment = false;
        this.xrLabel13.Text = "Thống kê";
        this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Dpi = 100F;
        this.xrLabel10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(161.5996F, 52.95834F);
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(160.6F, 23F);
        this.xrLabel10.StylePriority.UseFont = false;
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Kế toán";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrLabel1,
            this.ngay});
        this.ReportHeader.Dpi = 100F;
        this.ReportHeader.HeightF = 105.8558F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel2
        // 
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(1.000182F, 51.93911F);
        this.xrLabel2.Multiline = true;
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(802.9998F, 30.91669F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "SỔ CHI PHÍ NVL CÓ TRONG BOM";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
        // ngay
        // 
        this.ngay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngay")});
        this.ngay.Dpi = 100F;
        this.ngay.LocationFloat = new DevExpress.Utils.PointFloat(1.000182F, 82.8558F);
        this.ngay.Multiline = true;
        this.ngay.Name = "ngay";
        this.ngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ngay.SizeF = new System.Drawing.SizeF(802.9995F, 22.99999F);
        this.ngay.StylePriority.UseTextAlignment = false;
        this.ngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xuong});
        this.GroupHeader1.Dpi = 100F;
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("xuong", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.GroupHeader1.HeightF = 100F;
        this.GroupHeader1.Name = "GroupHeader1";
        this.GroupHeader1.RepeatEveryPage = true;
        // 
        // xrTable1
        // 
        this.xrTable1.BackColor = System.Drawing.Color.LightGray;
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Dpi = 100F;
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 50F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(802.6662F, 50F);
        this.xrTable1.StylePriority.UseBackColor = false;
        this.xrTable1.StylePriority.UseBorders = false;
        this.xrTable1.StylePriority.UseFont = false;
        this.xrTable1.StylePriority.UseForeColor = false;
        this.xrTable1.StylePriority.UsePadding = false;
        this.xrTable1.StylePriority.UseTextAlignment = false;
        this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell7});
        this.xrTableRow1.Dpi = 100F;
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell19.Dpi = 100F;
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseBorders = false;
        this.xrTableCell19.Text = "STT";
        this.xrTableCell19.Weight = 0.13287469003072727D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell1.Dpi = 100F;
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseBorders = false;
        this.xrTableCell1.Text = "MÃ VTHH";
        this.xrTableCell1.Weight = 0.38482253878448242D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell2.Dpi = 100F;
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseBorders = false;
        this.xrTableCell2.Text = "ĐVT";
        this.xrTableCell2.Weight = 0.12858872335605925D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell3.Dpi = 100F;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.Text = "SL";
        this.xrTableCell3.Weight = 0.24717672008089789D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell4.Dpi = 100F;
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.Text = "ĐƠN GIÁ";
        this.xrTableCell4.Weight = 0.3464758028833872D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell7.Dpi = 100F;
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.Text = "THÀNH TIỀN";
        this.xrTableCell7.Weight = 0.44284409673243597D;
        // 
        // xuong
        // 
        this.xuong.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "xuong")});
        this.xuong.Dpi = 100F;
        this.xuong.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xuong.LocationFloat = new DevExpress.Utils.PointFloat(0.3333282F, 0F);
        this.xuong.Multiline = true;
        this.xuong.Name = "xuong";
        this.xuong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xuong.SizeF = new System.Drawing.SizeF(802.9995F, 50F);
        this.xuong.StylePriority.UseFont = false;
        this.xuong.StylePriority.UseTextAlignment = false;
        this.xuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // GroupFooter1
        // 
        this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
        this.GroupFooter1.Dpi = 100F;
        this.GroupFooter1.HeightF = 29.16667F;
        this.GroupFooter1.Name = "GroupFooter1";
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTable2.Dpi = 100F;
        this.xrTable2.Font = new System.Drawing.Font("Arial", 9.75F);
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(802.67F, 29.16667F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UseFont = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell9});
        this.xrTableRow2.Dpi = 100F;
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell5.Dpi = 100F;
        this.xrTableCell5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.StylePriority.UseFont = false;
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.Text = "Tổng cộng";
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell5.Weight = 1.1706833237591114D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sl")});
        this.xrTableCell6.Dpi = 100F;
        this.xrTableCell6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.StylePriority.UseFont = false;
        this.xrTableCell6.StylePriority.UsePadding = false;
        this.xrTableCell6.StylePriority.UseTextAlignment = false;
        xrSummary7.FormatString = "{0:#,#.#}";
        xrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell6.Summary = xrSummary7;
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell6.Weight = 0.44772146423727854D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell8.Dpi = 100F;
        this.xrTableCell8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.StylePriority.UseFont = false;
        this.xrTableCell8.StylePriority.UsePadding = false;
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        xrSummary8.FormatString = "{0:#,#.#}";
        this.xrTableCell8.Summary = xrSummary8;
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell8.Weight = 0.62756950792291255D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "thanhtien")});
        this.xrTableCell9.Dpi = 100F;
        this.xrTableCell9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.StylePriority.UseFont = false;
        this.xrTableCell9.StylePriority.UsePadding = false;
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        xrSummary9.FormatString = "{0:#,#0.00}";
        xrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
        this.xrTableCell9.Summary = xrSummary9;
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell9.Weight = 0.80213912786770725D;
        // 
        // rptTienCongKhoan
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader,
            this.GroupHeader1,
            this.GroupFooter1});
        this.Margins = new System.Drawing.Printing.Margins(8, 15, 0, 16);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "16.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}