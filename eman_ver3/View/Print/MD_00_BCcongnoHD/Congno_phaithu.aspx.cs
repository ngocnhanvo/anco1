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

public partial class PrintControllers_Congno_phaithu_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityContext db = new EntityContext();
        rpt_socongnothu report = new rpt_socongnothu();
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
		
		//string tungay = context.Request.QueryString["tungay"];
		//string denngay = context.Request.QueryString["denngay"];
		
		string ntc = context.Request.QueryString["ntc"];
		string ky_ = context.Request.QueryString["ky"];
		string dtkd = context.Request.QueryString["dtkd"];
		if(dtkd != "") {
			dtkd = " and dtkd.ma_dtkd = N'" + dtkd + "'";
		}
		/*string md_namtaichinh_id = db.md_namtaichinh.Where(s => s.giatri.ToString() == ntc).Select(s => s.md_namtaichinh_id).FirstOrDefault();
		md_namtaichinh_ky ky = db.md_namtaichinh_ky.Where(s => s.md_namtaichinh_id == md_namtaichinh_id & s.soky.ToString() == ky_).FirstOrDefault();
		*/
		string dec = context.Request.QueryString["dec"];
		string thous = context.Request.QueryString["thous"];
		string sql = string.Format(@"
		select xb.sochungtu as cel_sopxk, xb.ngaychuyen as cel_ngayxk, dsdh.so_po as cel_donhang,
		dsdh.ngaylap as cel_ngaydonhang, dsdh.nguoi_phutrach as cel_nguoipt, sp.ma_sanpham as cel_mavthh,
		dvt_sp.ten_dvt as cel_dvt, xb_cdh.sl_daxuat as cel_sl, ddsdh.gianhap as cel_dongia,
		(ddsdh.gianhap * xb_cdh.sl_daxuat) as cel_thanhtien, (N'Tên khách hàng: ' + dtkd.ten_dtkd) as lbl_tenkh, 
		(N'Từ ngày ' + convert(nvarchar,convert(datetime,N'{0}',103), 103) + N' đến ngày ' + convert(nvarchar,convert(datetime,N'{1}',103), 103)) as lbl_tungaydenngay
		from md_xuatban_cdh xb_cdh
		inner join md_xuatban xb on xb.md_xuatban_id = xb_cdh.md_xuatban_id
		inner join c_danhsachdathang dsdh on dsdh.c_danhsachdathang_id = xb.c_danhsachdathang_id
		inner join c_dongdsdh ddsdh on ddsdh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id
		left join md_sanpham sp on sp.md_sanpham_id = xb_cdh.md_sanpham_id
		left join md_donvitinhsanpham dvt_sp on dvt_sp.md_donvitinhsanpham_id = xb_cdh.md_donvitinhsanpham_id
		inner join [ancotrading].[dbo].c_donhang dh on dh.c_donhang_id = dsdh.c_donhang_id
		inner join [ancotrading].[dbo].md_doitackinhdoanh dtkd on dtkd.md_doitackinhdoanh_id = dh.md_doitackinhdoanh_id 
		where xb.trangthai = 'HIEULUC' and ddsdh.md_sanpham_id = xb_cdh.md_sanpham_id
		and xb_cdh.sl_daxuat > 0 and xb.ngaychuyen >= convert(datetime,N'{0} 00:00',103) and xb.ngaychuyen <= convert(datetime,N'{1} 23:59',103) {2}
		group by dtkd.ten_dtkd, xb.sochungtu, xb.ngaychuyen, dsdh.so_po, dsdh.ngaylap, dsdh.nguoi_phutrach,
		sp.ma_sanpham, dvt_sp.ten_dvt, xb_cdh.sl_daxuat, ddsdh.gianhap
		order by dtkd.ten_dtkd asc, xb.sochungtu asc
		", ky_, ntc, dtkd);
		return sql;
    }
}

/// <summary>
/// Summary description for rpt_socongnothu
/// </summary>
public class rpt_socongnothu : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private XRTable xrTable3;
    private XRTableRow xrTableRow3;
    private XRTableCell cel_sopxk;
    private XRTableCell cel_ngayxk;
    private XRTableCell cel_donhang;
    private XRTableCell cel_ngaydonhang;
    private XRTableCell cel_nguoipt;
    private XRTableCell cel_mavthh;
    private XRTableCell cel_dvt;
    private XRTableCell cel_sl;
    private XRTableCell cel_dongia;
    private XRTableCell cel_thanhtien;
    private GroupHeaderBand GroupHeader1;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell7;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell3;
    private XRLabel lbl_tenkh;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell8;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell9;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell16;
    private XRTableCell xrTableCell10;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell12;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private ReportFooterBand ReportFooter;
    private XRTable xrTable4;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell28;
    private XRTableCell xrTableCell29;
    private XRTableCell xrTableCell30;
    private XRLabel xrLabel9;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel3;
    private XRLabel xrLabel5;
    private XRLabel lbl_tungaydenngay;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel xrLabel4;
    private XRTable xrTable5;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell23;
    private XRTableCell xrTableCell24;
    private XRTableCell sum_sl;
    private XRTableCell sum_dongia;
    private XRTableCell sum_thanhtien;
    private XRTableCell xrTableCell20;
    private XRTableCell xrTableCell18;
    private XRTableCell xrTableCell19;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public rpt_socongnothu()
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
        string resourceFileName = "rpt_socongnothu.resx";
        DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
        DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
        this.Detail = new DevExpress.XtraReports.UI.DetailBand();
        this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.cel_sopxk = new DevExpress.XtraReports.UI.XRTableCell();
        this.cel_ngayxk = new DevExpress.XtraReports.UI.XRTableCell();
        this.cel_donhang = new DevExpress.XtraReports.UI.XRTableCell();
        this.cel_ngaydonhang = new DevExpress.XtraReports.UI.XRTableCell();
        this.cel_nguoipt = new DevExpress.XtraReports.UI.XRTableCell();
        this.cel_mavthh = new DevExpress.XtraReports.UI.XRTableCell();
        this.cel_dvt = new DevExpress.XtraReports.UI.XRTableCell();
        this.cel_sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.cel_dongia = new DevExpress.XtraReports.UI.XRTableCell();
        this.cel_thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.lbl_tenkh = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrTable5 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell24 = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_sl = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_dongia = new DevExpress.XtraReports.UI.XRTableCell();
        this.sum_thanhtien = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell29 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell30 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.lbl_tungaydenngay = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
        this.Detail.HeightF = 35F;
        this.Detail.KeepTogether = true;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable3
        // 
        this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable3.Name = "xrTable3";
        this.xrTable3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
        this.xrTable3.SizeF = new System.Drawing.SizeF(820F, 35F);
        this.xrTable3.StylePriority.UsePadding = false;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell20,
            this.cel_sopxk,
            this.cel_ngayxk,
            this.cel_donhang,
            this.cel_ngaydonhang,
            this.cel_nguoipt,
            this.cel_mavthh,
            this.cel_dvt,
            this.cel_sl,
            this.cel_dongia,
            this.cel_thanhtien});
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // cel_sopxk
        // 
        this.cel_sopxk.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_sopxk.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_sopxk")});
        this.cel_sopxk.Name = "cel_sopxk";
        this.cel_sopxk.StylePriority.UseBorders = false;
        this.cel_sopxk.StylePriority.UseTextAlignment = false;
        this.cel_sopxk.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cel_sopxk.Weight = 0.62431108115642986D;
        // 
        // cel_ngayxk
        // 
        this.cel_ngayxk.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_ngayxk.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_ngayxk", "{0:dd/MM/yy}")});
        this.cel_ngayxk.Name = "cel_ngayxk";
        this.cel_ngayxk.StylePriority.UseBorders = false;
        this.cel_ngayxk.StylePriority.UseTextAlignment = false;
        this.cel_ngayxk.Text = "02/07/16";
        this.cel_ngayxk.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cel_ngayxk.Weight = 0.67609525002364834D;
        // 
        // cel_donhang
        // 
        this.cel_donhang.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_donhang.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_donhang")});
        this.cel_donhang.Name = "cel_donhang";
        this.cel_donhang.StylePriority.UseBorders = false;
        this.cel_donhang.StylePriority.UseTextAlignment = false;
        this.cel_donhang.Text = "DMH/00205/16";
        this.cel_donhang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cel_donhang.Weight = 0.61763273389893569D;
        // 
        // cel_ngaydonhang
        // 
        this.cel_ngaydonhang.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_ngaydonhang.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_ngaydonhang", "{0:dd/MM/yy}")});
        this.cel_ngaydonhang.Name = "cel_ngaydonhang";
        this.cel_ngaydonhang.StylePriority.UseBorders = false;
        this.cel_ngaydonhang.StylePriority.UseTextAlignment = false;
        this.cel_ngaydonhang.Text = "01/07/16";
        this.cel_ngaydonhang.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cel_ngaydonhang.Weight = 0.67609532971063446D;
        // 
        // cel_nguoipt
        // 
        this.cel_nguoipt.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_nguoipt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_nguoipt")});
        this.cel_nguoipt.Name = "cel_nguoipt";
        this.cel_nguoipt.StylePriority.UseBorders = false;
        this.cel_nguoipt.StylePriority.UseTextAlignment = false;
        this.cel_nguoipt.Text = "Người PT";
        this.cel_nguoipt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cel_nguoipt.Weight = 0.8203999688931195D;
        // 
        // cel_mavthh
        // 
        this.cel_mavthh.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_mavthh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_mavthh")});
        this.cel_mavthh.Name = "cel_mavthh";
        this.cel_mavthh.StylePriority.UseBorders = false;
        this.cel_mavthh.StylePriority.UseTextAlignment = false;
        this.cel_mavthh.Text = "MÃ VTHH";
        this.cel_mavthh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.cel_mavthh.Weight = 1.0194494762489597D;
        // 
        // cel_dvt
        // 
        this.cel_dvt.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_dvt.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_dvt")});
        this.cel_dvt.Name = "cel_dvt";
        this.cel_dvt.StylePriority.UseBorders = false;
        this.cel_dvt.StylePriority.UseTextAlignment = false;
        this.cel_dvt.Text = "ĐVT";
        this.cel_dvt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.cel_dvt.Weight = 0.35793280356887258D;
        // 
        // cel_sl
        // 
        this.cel_sl.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_sl", "{0:#,#}")});
        this.cel_sl.Name = "cel_sl";
        this.cel_sl.StylePriority.UseBorders = false;
        this.cel_sl.StylePriority.UseTextAlignment = false;
        this.cel_sl.Text = "SỐ LƯỢNG";
        this.cel_sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.cel_sl.Weight = 0.8176793257407281D;
        // 
        // cel_dongia
        // 
        this.cel_dongia.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_dongia.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_dongia", "{0:#,#}")});
        this.cel_dongia.Name = "cel_dongia";
        this.cel_dongia.StylePriority.UseBorders = false;
        this.cel_dongia.StylePriority.UseTextAlignment = false;
        this.cel_dongia.Text = "ĐƠN GIÁ";
        this.cel_dongia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.cel_dongia.Weight = 0.99287481267173261D;
        // 
        // cel_thanhtien
        // 
        this.cel_thanhtien.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.cel_thanhtien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_thanhtien", "{0:#,#}")});
        this.cel_thanhtien.Name = "cel_thanhtien";
        this.cel_thanhtien.StylePriority.UseBorders = false;
        this.cel_thanhtien.StylePriority.UseTextAlignment = false;
        this.cel_thanhtien.Text = "THÀNH TIỀN";
        this.cel_thanhtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.cel_thanhtien.Weight = 1.2219237215069416D;
        // 
        // TopMargin
        // 
        this.TopMargin.HeightF = 4.499976F;
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
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.lbl_tenkh,
            this.xrTable1});
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("lbl_tenkh", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.GroupHeader1.HeightF = 80F;
        this.GroupHeader1.KeepTogether = true;
        this.GroupHeader1.Name = "GroupHeader1";
        this.GroupHeader1.RepeatEveryPage = true;
        // 
        // xrTable2
        // 
        this.xrTable2.BackColor = System.Drawing.Color.LightGray;
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0.0001430511F, 30.00001F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
        this.xrTable2.SizeF = new System.Drawing.SizeF(819.9998F, 25F);
        this.xrTable2.StylePriority.UseBackColor = false;
        this.xrTable2.StylePriority.UsePadding = false;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell18,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7,
            this.xrTableCell2,
            this.xrTableCell1,
            this.xrTableCell3});
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.StylePriority.UseFont = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.Text = "PXK";
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 1.3004063513055124D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.StylePriority.UseFont = false;
        this.xrTableCell5.StylePriority.UseTextAlignment = false;
        this.xrTableCell5.Text = "ĐƠN HÀNG";
        this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell5.Weight = 2.1141282690806973D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.StylePriority.UseFont = false;
        this.xrTableCell6.StylePriority.UseTextAlignment = false;
        this.xrTableCell6.Text = "MÃ VTHH";
        this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell6.Weight = 1.019449467923039D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.StylePriority.UseFont = false;
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "ĐVT";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell7.Weight = 0.35793287903484078D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseBorders = false;
        this.xrTableCell2.StylePriority.UseFont = false;
        this.xrTableCell2.StylePriority.UseTextAlignment = false;
        this.xrTableCell2.Text = "SỐ LƯỢNG";
        this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell2.Weight = 0.81768070541230642D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseBorders = false;
        this.xrTableCell1.StylePriority.UseFont = false;
        this.xrTableCell1.StylePriority.UseTextAlignment = false;
        this.xrTableCell1.Text = "ĐƠN GIÁ";
        this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell1.Weight = 0.99287441951617239D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.StylePriority.UseFont = false;
        this.xrTableCell3.StylePriority.UseTextAlignment = false;
        this.xrTableCell3.Text = "THÀNH TIỀN";
        this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell3.Weight = 1.2219236364005979D;
        // 
        // lbl_tenkh
        // 
        this.lbl_tenkh.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "lbl_tenkh")});
        this.lbl_tenkh.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.lbl_tenkh.LocationFloat = new DevExpress.Utils.PointFloat(0.0001271566F, 0F);
        this.lbl_tenkh.Name = "lbl_tenkh";
        this.lbl_tenkh.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lbl_tenkh.SizeF = new System.Drawing.SizeF(819.9998F, 30.00001F);
        this.lbl_tenkh.StylePriority.UseFont = false;
        this.lbl_tenkh.StylePriority.UseTextAlignment = false;
        this.lbl_tenkh.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTable1
        // 
        this.xrTable1.BackColor = System.Drawing.Color.LightGray;
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 55F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(820F, 25F);
        this.xrTable1.StylePriority.UseBackColor = false;
        this.xrTable1.StylePriority.UsePadding = false;
        // 
        // xrTableRow1
        // 
        this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell19,
            this.xrTableCell8,
            this.xrTableCell15,
            this.xrTableCell9,
            this.xrTableCell17,
            this.xrTableCell16,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14});
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell8
        // 
        this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell8.Name = "xrTableCell8";
        this.xrTableCell8.StylePriority.UseBorders = false;
        this.xrTableCell8.StylePriority.UseFont = false;
        this.xrTableCell8.StylePriority.UseTextAlignment = false;
        this.xrTableCell8.Text = "Số";
        this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell8.Weight = 0.62431106219246757D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell15.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseBorders = false;
        this.xrTableCell15.StylePriority.UseFont = false;
        this.xrTableCell15.StylePriority.UseTextAlignment = false;
        this.xrTableCell15.Text = "Ngày";
        this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell15.Weight = 0.67609528795157259D;
        // 
        // xrTableCell9
        // 
        this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell9.Name = "xrTableCell9";
        this.xrTableCell9.StylePriority.UseBorders = false;
        this.xrTableCell9.StylePriority.UseFont = false;
        this.xrTableCell9.StylePriority.UseTextAlignment = false;
        this.xrTableCell9.Text = "Số";
        this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell9.Weight = 0.61763292353855836D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell17.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseBorders = false;
        this.xrTableCell17.StylePriority.UseFont = false;
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        this.xrTableCell17.Text = "Ngày";
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell17.Weight = 0.67609529178270988D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell16.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseBorders = false;
        this.xrTableCell16.StylePriority.UseFont = false;
        this.xrTableCell16.StylePriority.UseTextAlignment = false;
        this.xrTableCell16.Text = "Người PT";
        this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell16.Weight = 0.82039974132557281D;
        // 
        // xrTableCell10
        // 
        this.xrTableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell10.Name = "xrTableCell10";
        this.xrTableCell10.StylePriority.UseBorders = false;
        this.xrTableCell10.Weight = 1.0194494762489594D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseBorders = false;
        this.xrTableCell11.Weight = 0.35793280356887264D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseBorders = false;
        this.xrTableCell12.StylePriority.UseFont = false;
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.Weight = 0.81767932574072766D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseBorders = false;
        this.xrTableCell13.Weight = 0.99287420582494157D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseBorders = false;
        this.xrTableCell14.Weight = 1.2219243283537329D;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable5,
            this.xrTable4,
            this.xrLabel9});
        this.ReportFooter.HeightF = 135.8333F;
        this.ReportFooter.KeepTogether = true;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrTable5
        // 
        this.xrTable5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable5.Name = "xrTable5";
        this.xrTable5.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow5});
        this.xrTable5.SizeF = new System.Drawing.SizeF(820F, 47.5F);
        this.xrTable5.StylePriority.UsePadding = false;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell23,
            this.xrTableCell24,
            this.sum_sl,
            this.sum_dongia,
            this.sum_thanhtien});
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell23.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.StylePriority.UseBorders = false;
        this.xrTableCell23.StylePriority.UseFont = false;
        this.xrTableCell23.StylePriority.UseTextAlignment = false;
        this.xrTableCell23.Text = "Tổng cộng";
        this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell23.Weight = 4.7625029067961639D;
        // 
        // xrTableCell24
        // 
        this.xrTableCell24.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell24.Name = "xrTableCell24";
        this.xrTableCell24.StylePriority.UseBorders = false;
        this.xrTableCell24.StylePriority.UseTextAlignment = false;
        this.xrTableCell24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell24.Weight = 0.35793335327996145D;
        // 
        // sum_sl
        // 
        this.sum_sl.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_sl.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_sl")});
        this.sum_sl.Name = "sum_sl";
		this.sum_sl.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.sum_sl.StylePriority.UseBorders = false;
        this.sum_sl.StylePriority.UseTextAlignment = false;
        xrSummary2.FormatString = "{0:#,#.00}";
        xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.sum_sl.Summary = xrSummary2;
        this.sum_sl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_sl.Weight = 0.81767932752796957D;
        // 
        // sum_dongia
        // 
        this.sum_dongia.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.sum_dongia.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_dongia")});
		this.sum_dongia.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.sum_dongia.Name = "sum_dongia";
        this.sum_dongia.StylePriority.UseBorders = false;
        this.sum_dongia.StylePriority.UseTextAlignment = false;
        xrSummary3.FormatString = "{0:#,#.00}";
        xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.sum_dongia.Summary = xrSummary3;
        this.sum_dongia.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_dongia.Weight = 0.99287420582494146D;
        // 
        // sum_thanhtien
        // 
        this.sum_thanhtien.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
		this.sum_thanhtien.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
        this.sum_thanhtien.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cel_thanhtien")});
        this.sum_thanhtien.Name = "sum_thanhtien";
        this.sum_thanhtien.StylePriority.UseBorders = false;
        this.sum_thanhtien.StylePriority.UseTextAlignment = false;
        xrSummary4.FormatString = "{0:#,#.00}";
        xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.sum_thanhtien.Summary = xrSummary4;
        this.sum_thanhtien.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.sum_thanhtien.Weight = 1.2219240249303374D;
        // 
        // xrTable4
        // 
        this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0.0001589457F, 96.3333F);
        this.xrTable4.Name = "xrTable4";
        this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow4});
        this.xrTable4.SizeF = new System.Drawing.SizeF(819.9998F, 25F);
        this.xrTable4.StylePriority.UseTextAlignment = false;
        this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell28,
            this.xrTableCell29,
            this.xrTableCell30});
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.StylePriority.UseFont = false;
        this.xrTableCell28.StylePriority.UseTextAlignment = false;
        this.xrTableCell28.Text = "Người lập";
        this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell28.Weight = 1.3249808893747315D;
        // 
        // xrTableCell29
        // 
        this.xrTableCell29.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell29.Name = "xrTableCell29";
        this.xrTableCell29.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 20, 0, 0, 100F);
        this.xrTableCell29.StylePriority.UseFont = false;
        this.xrTableCell29.StylePriority.UsePadding = false;
        this.xrTableCell29.StylePriority.UseTextAlignment = false;
        this.xrTableCell29.Text = "Kế toán";
        this.xrTableCell29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell29.Weight = 1D;
        // 
        // xrTableCell30
        // 
        this.xrTableCell30.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell30.Name = "xrTableCell30";
        this.xrTableCell30.StylePriority.UseFont = false;
        this.xrTableCell30.StylePriority.UseTextAlignment = false;
        this.xrTableCell30.Text = "Ban giám đốc";
        this.xrTableCell30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell30.Weight = 1.6898570830825084D;
        // 
        // xrLabel9
        // 
        this.xrLabel9.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(535.834F, 47.5F);
        this.xrLabel9.Name = "xrLabel9";
        this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel9.SizeF = new System.Drawing.SizeF(284.1658F, 48.8333F);
        this.xrLabel9.StylePriority.UseFont = false;
        this.xrLabel9.StylePriority.UseTextAlignment = false;
        this.xrLabel9.Text = "Ngày ......... tháng .......... năm ..........";
        this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel3,
            this.xrLabel5,
            this.lbl_tungaydenngay,
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel4});
        this.ReportHeader.HeightF = 117.9584F;
        this.ReportHeader.KeepTogether = true;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel3
        // 
        this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 39.75F);
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(84.375F, 21.875F);
        this.xrLabel3.StylePriority.UseFont = false;
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Mã số thuế  : ";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel5
        // 
        this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 61.62501F);
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(820F, 31.33334F);
        this.xrLabel5.StylePriority.UseFont = false;
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "SỔ CHI TIẾT CÔNG NỢ - PHẢI THU";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // lbl_tungaydenngay
        // 
        this.lbl_tungaydenngay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "lbl_tungaydenngay")});
        this.lbl_tungaydenngay.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.lbl_tungaydenngay.LocationFloat = new DevExpress.Utils.PointFloat(0.0001430511F, 92.95834F);
        this.lbl_tungaydenngay.Name = "lbl_tungaydenngay";
        this.lbl_tungaydenngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.lbl_tungaydenngay.SizeF = new System.Drawing.SizeF(819.9998F, 23F);
        this.lbl_tungaydenngay.StylePriority.UseFont = false;
        this.lbl_tungaydenngay.StylePriority.UseTextAlignment = false;
        this.lbl_tungaydenngay.Text = "từ ngày đến ngày";
        this.lbl_tungaydenngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel1
        // 
        this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(238.5417F, 19.875F);
        this.xrLabel1.StylePriority.UseFont = false;
        this.xrLabel1.StylePriority.UseTextAlignment = false;
        this.xrLabel1.Text = "CTY TNHH ANCO BINH DUONG";
        this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel2
        // 
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 19.875F);
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(238.5417F, 19.875F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "XƯỞNG ANCO 1";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 11F);
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(84.375F, 39.75F);
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(154.1667F, 21.875F);
        this.xrLabel4.StylePriority.UseFont = false;
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "3700318266";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell18.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.StylePriority.UseBorders = false;
        this.xrTableCell18.StylePriority.UseFont = false;
        this.xrTableCell18.Text = "STT";
        this.xrTableCell18.Weight = 0.32851808968620755D;
        // 
        // xrTableCell19
        // 
        this.xrTableCell19.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell19.Name = "xrTableCell19";
        this.xrTableCell19.StylePriority.UseBorders = false;
        this.xrTableCell19.Weight = 0.32851937183125862D;
        // 
        // xrTableCell20
        // 
        this.xrTableCell20.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell20.Name = "xrTableCell20";
        this.xrTableCell20.StylePriority.UseBorders = false;
        this.xrTableCell20.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
        this.xrTableCell20.Summary = xrSummary1;
        this.xrTableCell20.Text = "xrTableCell20";
        this.xrTableCell20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell20.Weight = 0.32851931493937192D;
        // 
        // rpt_socongnothu
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.ReportFooter,
            this.ReportHeader});
        this.Margins = new System.Drawing.Printing.Margins(4, 3, 4, 100);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "12.2";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable5)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}