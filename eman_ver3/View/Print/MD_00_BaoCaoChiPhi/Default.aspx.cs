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
        scnTongHop report = new scnTongHop();
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
		//string ntc = context.Request.QueryString["ntc"];
		//string ky_ = context.Request.QueryString["ky"];
		string xuong = context.Request.QueryString["xuong"];
		string gia = context.Request.QueryString["gia"];
		
		//string md_namtaichinh_id = db.md_namtaichinh.Where(s => s.giatri.ToString() == ntc).Select(s => s.md_namtaichinh_id).FirstOrDefault();
		//md_namtaichinh_ky ky = db.md_namtaichinh_ky.Where(s => s.md_namtaichinh_id == md_namtaichinh_id & s.soky.ToString() == ky_).FirstOrDefault();
		//ky.ngaybatdau.Value.ToString("dd/MM/yyyy"), ky.ngayketthuc.Value.ToString("dd/MM/yyyy")
		string tungay = context.Request.QueryString["tu"];
		string denngay = context.Request.QueryString["den"];
		
		DateTime tu = DateTime.ParseExact(tungay, "dd-MM-yyyy", null);
		DateTime den = DateTime.ParseExact(denngay, "dd-MM-yyyy", null);
		
		if(xuong != null & xuong != "") {
			xuong = "and px.md_phanxuong_id = '"+ xuong +"'";
		}
		else {
			xuong = "";
		}
		
		string sql = string.Format(@"
		Select 
		sum(B.chi_phi_nc_co) as chi_phi_nc_co,
		sum(B.chi_phi_nvl_co) as chi_phi_nvl_co,
		sum(B.chi_phi_nc_co) + sum(B.chi_phi_nvl_co) as tong_co,
		N'Từ ngày: ' + N'{0}' + N' đến ngày: ' + N'{1}' AS ngay,
		N'Phân xưởng: ' + B.t_xuong AS xuong
		from
		(
			SELECT sum(A.sl * A.gia) as chi_phi_nc_co, 0 as chi_phi_nvl_co, A.ten_phanxuong as t_xuong
			from (
				select nknb_cdh.sl_danhap as sl, px.ten_phanxuong,
				(select top 1 gsp.gia
				from md_giasanpham gsp
				inner join md_phienbangia pbg on pbg.md_phienbangia_id = gsp.md_phienbangia_id
				inner join md_banggia bg on bg.md_banggia_id = pbg.md_banggia_id
				where bg.tuychon = 'NHANCONG'
				and pbg.md_trangthai_id = 'HIEULUC'
				and sp.md_sanpham_id = gsp.md_sanpham_id) as gia
				from md_nhapkhonb nknb
				LEFT join md_nhapkhonb_cdh nknb_cdh ON nknb.md_nhapkhonb_id = nknb_cdh.md_nhapkhonb_id
				INNER JOIN (
				select px2.md_phanxuong_id as md_phanxuong_id, px2.ten_phanxuong as ten_phanxuong
				from md_phanxuong px2 
				union 
				select px2.md_phongban_id as md_phanxuong_id, px2.ten_phongban as ten_phanxuong 
				from ad_department px2 
				)px on nknb.nhaptu = px.md_phanxuong_id
				LEFT join md_sanpham sp ON nknb_cdh.md_sanpham_id = sp.md_sanpham_id
				where nknb.ngaychuyen >= convert(datetime,N'{0} 00:00',103)
				and nknb.ngaychuyen <= convert(datetime,N'{1} 23:59',103)
				and nknb.trangthai = 'HIEULUC'
				and px.md_phanxuong_id = '{2}'
				and nknb_cdh.sl_danhap > 0
			) as A
			Group by A.ten_phanxuong
			union
			SELECT 0 as chi_phi_nc_co, sum(A.sl * A.gia) as chi_phi_nvl_co , A.ten_phanxuong as t_xuong
			FROM
			(
				SELECT sp.ma_sanpham AS ma_vthh, nknb_cdh.sl_daxuat AS sl, px.ten_phanxuong , 
				sp.giabinhquan AS gia
				FROM md_xuatkhonb nknb
				LEFT JOIN md_xuatkhonb_cdh nknb_cdh ON nknb.md_xuatkhonb_id = nknb_cdh.md_xuatkhonb_id  
				INNER JOIN (
				select px2.md_phanxuong_id as md_phanxuong_id, px2.ten_phanxuong as ten_phanxuong
				from md_phanxuong px2 
				union 
				select px2.md_phongban_id as md_phanxuong_id, px2.ten_phongban as ten_phanxuong 
				from ad_department px2 
				)px on nknb.xuatden = px.md_phanxuong_id
				LEFT join md_sanpham sp ON nknb_cdh.md_sanpham_id = sp.md_sanpham_id
				WHERE nknb.ngaychuyen >= convert(datetime,N'{0} 00:00',103)
				AND nknb.ngaychuyen <= convert(datetime,N'{1} 23:59',103)
				AND nknb.trangthai = 'HIEULUC'
				{2}
				AND nknb_cdh.sl_daxuat > 0
				and (select count(*) from md_sanpham_bom_vattu where md_sanpham_id = sp.md_sanpham_id) > 0
			) AS A
			Group by A.ten_phanxuong
		) as B
		Group by B.t_xuong
		",tu.ToString("dd/MM/yyyy"), den.ToString("dd/MM/yyyy"), xuong, gia);
		return sql;
    }
}

/// <summary>
/// Summary description for scnTongHop
/// </summary>
public class scnTongHop : DevExpress.XtraReports.UI.XtraReport
{
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private ReportHeaderBand ReportHeader;
    private XRLabel xrLabel1;
    private XRLabel xrLabel2;
    private XRLabel ngay;
    private XRTable xrTable2;
    private XRTableRow xrTableRow2;
    private XRTableCell muc;
    private XRTableCell ten_muc;
    private XRTableCell no;
    private XRTableCell co;
    private XRTableCell lai_lo;
    private XRTableRow xrTableRow4;
    private XRTableCell xrTableCell4;
    private XRTableCell xrTableCell7;
    private XRTableCell nhap_hang_no;
    private XRTableCell nhap_hang_co;
    private XRTableCell nhap_hang_lai_lo;
    private XRTableRow xrTableRow5;
    private XRTableCell xrTableCell11;
    private XRTableCell xrTableCell13;
    private XRTableCell xrTableCell14;
    private XRTableCell xrTableCell15;
    private XRTableCell xrTableCell16;
    private XRTableRow xrTableRow6;
    private XRTableCell xrTableCell17;
    private XRTableCell xrTableCell18;
    private XRTableCell chi_phi_nc_no;
    private XRTableCell chi_phi_nc_co;
    private XRTableCell chi_phi_nc_lai_lo;
    private XRTableRow xrTableRow7;
    private XRTableCell xrTableCell22;
    private XRTableCell xrTableCell23;
    private XRTableCell chi_phi_nvl_no;
    private XRTableCell chi_phi_nvl_co;
    private XRTableCell chi_phi_nvl_lai_lo;
    private XRTableRow xrTableRow8;
    private XRTableCell xrTableCell27;
    private XRTableCell xrTableCell28;
    private XRTableCell chi_phi_khac_no;
    private XRTableCell chi_phi_khac_co;
    private XRTableCell chi_phi_khac_lai_lo;
    private XRTableRow xrTableRow9;
    private XRTableCell xrTableCell32;
    private XRTableCell xrTableCell33;
    private XRTableCell xrTableCell34;
    private XRTableCell xrTableCell35;
    private XRTableCell xrTableCell36;
    private XRTableRow xrTableRow10;
    private XRTableCell xrTableCell37;
    private XRTableCell xrTableCell38;
    private XRTableCell xrTableCell39;
    private XRTableCell xrTableCell40;
    private XRTableCell xrTableCell41;
    private XRTableRow xrTableRow11;
    private XRTableCell xrTableCell42;
    private XRTableCell xrTableCell43;
    private XRTableCell xrTableCell44;
    private XRTableCell xrTableCell45;
    private XRTableCell xrTableCell46;
    private XRTableRow xrTableRow3;
    private XRTableCell xrTableCell12;
    private XRTableCell tong_no;
    private XRTableCell tong_co;
    private XRTableCell tong_lai_lo;
    private XRTable xrTable1;
    private XRTableRow xrTableRow1;
    private XRTableCell xrTableCell6;
    private XRTableCell xrTableCell5;
    private XRTableCell xrTableCell1;
    private XRTableCell xrTableCell2;
    private XRTableCell xrTableCell3;
    private GroupHeaderBand GroupHeader1;
    private XRLabel xuong;
    private ReportFooterBand ReportFooter;
    private XRLabel xrLabel5;
    private XRLabel xrLabel4;
    private XRLabel xrLabel3;
    private XRLabel xrLabel10;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public scnTongHop()
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
        this.muc = new DevExpress.XtraReports.UI.XRTableCell();
        this.ten_muc = new DevExpress.XtraReports.UI.XRTableCell();
        this.no = new DevExpress.XtraReports.UI.XRTableCell();
        this.co = new DevExpress.XtraReports.UI.XRTableCell();
        this.lai_lo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
        this.nhap_hang_no = new DevExpress.XtraReports.UI.XRTableCell();
        this.nhap_hang_co = new DevExpress.XtraReports.UI.XRTableCell();
        this.nhap_hang_lai_lo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
        this.chi_phi_nc_no = new DevExpress.XtraReports.UI.XRTableCell();
        this.chi_phi_nc_co = new DevExpress.XtraReports.UI.XRTableCell();
        this.chi_phi_nc_lai_lo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
        this.chi_phi_nvl_no = new DevExpress.XtraReports.UI.XRTableCell();
        this.chi_phi_nvl_co = new DevExpress.XtraReports.UI.XRTableCell();
        this.chi_phi_nvl_lai_lo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell28 = new DevExpress.XtraReports.UI.XRTableCell();
        this.chi_phi_khac_no = new DevExpress.XtraReports.UI.XRTableCell();
        this.chi_phi_khac_co = new DevExpress.XtraReports.UI.XRTableCell();
        this.chi_phi_khac_lai_lo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow9 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell33 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell34 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell35 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell36 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow10 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell37 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell38 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell39 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell40 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell41 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow11 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell42 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell43 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell44 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell45 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell46 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_no = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_co = new DevExpress.XtraReports.UI.XRTableCell();
        this.tong_lai_lo = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
        this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
        this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
        this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
        this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
        this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
        this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
        this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
        this.ngay = new DevExpress.XtraReports.UI.XRLabel();
        this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
        this.xuong = new DevExpress.XtraReports.UI.XRLabel();
        this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
        this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
        this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        // 
        // Detail
        // 
        this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrTable1});
        this.Detail.Dpi = 100F;
        this.Detail.HeightF = 218.1447F;
        this.Detail.Name = "Detail";
        this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // xrTable2
        // 
        this.xrTable2.Borders = DevExpress.XtraPrinting.BorderSide.None;
        this.xrTable2.Dpi = 100F;
        this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(3.963045E-05F, 26.7758F);
        this.xrTable2.Name = "xrTable2";
        this.xrTable2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow4,
            this.xrTableRow5,
            this.xrTableRow6,
            this.xrTableRow7,
            this.xrTableRow8,
            this.xrTableRow9,
            this.xrTableRow10,
            this.xrTableRow11,
            this.xrTableRow3});
        this.xrTable2.SizeF = new System.Drawing.SizeF(754F, 191.3689F);
        this.xrTable2.StylePriority.UseBorders = false;
        this.xrTable2.StylePriority.UsePadding = false;
        this.xrTable2.StylePriority.UseTextAlignment = false;
        this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrTableRow2
        // 
        this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.muc,
            this.ten_muc,
            this.no,
            this.co,
            this.lai_lo});
        this.xrTableRow2.Dpi = 100F;
        this.xrTableRow2.Name = "xrTableRow2";
        this.xrTableRow2.Weight = 1D;
        // 
        // muc
        // 
        this.muc.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.muc.Dpi = 100F;
        this.muc.Name = "muc";
        this.muc.StylePriority.UseBorders = false;
        this.muc.StylePriority.UseTextAlignment = false;
        xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
        this.muc.Summary = xrSummary1;
        this.muc.Text = "I/";
        this.muc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.muc.Weight = 0.346475678336298D;
        // 
        // ten_muc
        // 
        this.ten_muc.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.ten_muc.Dpi = 100F;
        this.ten_muc.Name = "ten_muc";
        this.ten_muc.StylePriority.UseBorders = false;
        this.ten_muc.StylePriority.UseTextAlignment = false;
        this.ten_muc.Text = "DOANH THU";
        this.ten_muc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.ten_muc.Weight = 0.84901023826432764D;
        // 
        // no
        // 
        this.no.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.no.Dpi = 100F;
        this.no.Name = "no";
        this.no.StylePriority.UseBorders = false;
        this.no.StylePriority.UseTextAlignment = false;
        this.no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.no.Weight = 0.53484516370009083D;
        // 
        // co
        // 
        this.co.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.co.Dpi = 100F;
        this.co.Name = "co";
        this.co.StylePriority.UseBorders = false;
        this.co.StylePriority.UseTextAlignment = false;
        this.co.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.co.Weight = 0.44850799990544848D;
        // 
        // lai_lo
        // 
        this.lai_lo.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.lai_lo.Dpi = 100F;
        this.lai_lo.Name = "lai_lo";
        this.lai_lo.StylePriority.UseBorders = false;
        this.lai_lo.StylePriority.UseTextAlignment = false;
        this.lai_lo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.lai_lo.Weight = 0.40665558222613912D;
        // 
        // xrTableRow4
        // 
        this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell4,
            this.xrTableCell7,
            this.nhap_hang_no,
            this.nhap_hang_co,
            this.nhap_hang_lai_lo});
        this.xrTableRow4.Dpi = 100F;
        this.xrTableRow4.Name = "xrTableRow4";
        this.xrTableRow4.Weight = 1D;
        // 
        // xrTableCell4
        // 
        this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell4.Dpi = 100F;
        this.xrTableCell4.Name = "xrTableCell4";
        this.xrTableCell4.StylePriority.UseBorders = false;
        this.xrTableCell4.StylePriority.UseTextAlignment = false;
        this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell4.Weight = 0.346475678336298D;
        // 
        // xrTableCell7
        // 
        this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell7.Dpi = 100F;
        this.xrTableCell7.Name = "xrTableCell7";
        this.xrTableCell7.StylePriority.UseBorders = false;
        this.xrTableCell7.StylePriority.UseTextAlignment = false;
        this.xrTableCell7.Text = "Doanh thu nhập hàng của xưởng";
        this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell7.Weight = 0.84901023826432764D;
        // 
        // nhap_hang_no
        // 
        this.nhap_hang_no.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.nhap_hang_no.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nhap_hang_no", "{0:#,#0.00}")});
        this.nhap_hang_no.Dpi = 100F;
        this.nhap_hang_no.Name = "nhap_hang_no";
        this.nhap_hang_no.StylePriority.UseBorders = false;
        this.nhap_hang_no.StylePriority.UseTextAlignment = false;
        this.nhap_hang_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.nhap_hang_no.Weight = 0.53484516370009083D;
        // 
        // nhap_hang_co
        // 
        this.nhap_hang_co.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.nhap_hang_co.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nhap_hang_co", "{0:#,#0.00}")});
        this.nhap_hang_co.Dpi = 100F;
        this.nhap_hang_co.Name = "nhap_hang_co";
        this.nhap_hang_co.StylePriority.UseBorders = false;
        this.nhap_hang_co.StylePriority.UseTextAlignment = false;
        this.nhap_hang_co.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.nhap_hang_co.Weight = 0.44850799990544848D;
        // 
        // nhap_hang_lai_lo
        // 
        this.nhap_hang_lai_lo.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.nhap_hang_lai_lo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nhap_hang_lai_lo", "{0:#,#0.00}")});
        this.nhap_hang_lai_lo.Dpi = 100F;
        this.nhap_hang_lai_lo.Name = "nhap_hang_lai_lo";
        this.nhap_hang_lai_lo.StylePriority.UseBorders = false;
        this.nhap_hang_lai_lo.StylePriority.UseTextAlignment = false;
        this.nhap_hang_lai_lo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.nhap_hang_lai_lo.Weight = 0.40665558222613912D;
        // 
        // xrTableRow5
        // 
        this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell11,
            this.xrTableCell13,
            this.xrTableCell14,
            this.xrTableCell15,
            this.xrTableCell16});
        this.xrTableRow5.Dpi = 100F;
        this.xrTableRow5.Name = "xrTableRow5";
        this.xrTableRow5.Weight = 1D;
        // 
        // xrTableCell11
        // 
        this.xrTableCell11.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell11.Dpi = 100F;
        this.xrTableCell11.Name = "xrTableCell11";
        this.xrTableCell11.StylePriority.UseBorders = false;
        this.xrTableCell11.StylePriority.UseTextAlignment = false;
        this.xrTableCell11.Text = "II/";
        this.xrTableCell11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell11.Weight = 0.346475678336298D;
        // 
        // xrTableCell13
        // 
        this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell13.Dpi = 100F;
        this.xrTableCell13.Name = "xrTableCell13";
        this.xrTableCell13.StylePriority.UseBorders = false;
        this.xrTableCell13.StylePriority.UseTextAlignment = false;
        this.xrTableCell13.Text = "CHI PHÍ";
        this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell13.Weight = 0.84901023826432764D;
        // 
        // xrTableCell14
        // 
        this.xrTableCell14.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell14.Dpi = 100F;
        this.xrTableCell14.Name = "xrTableCell14";
        this.xrTableCell14.StylePriority.UseBorders = false;
        this.xrTableCell14.StylePriority.UseTextAlignment = false;
        this.xrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell14.Weight = 0.53484516370009083D;
        // 
        // xrTableCell15
        // 
        this.xrTableCell15.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell15.Dpi = 100F;
        this.xrTableCell15.Name = "xrTableCell15";
        this.xrTableCell15.StylePriority.UseBorders = false;
        this.xrTableCell15.StylePriority.UseTextAlignment = false;
        this.xrTableCell15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell15.Weight = 0.44850799990544848D;
        // 
        // xrTableCell16
        // 
        this.xrTableCell16.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell16.Dpi = 100F;
        this.xrTableCell16.Name = "xrTableCell16";
        this.xrTableCell16.StylePriority.UseBorders = false;
        this.xrTableCell16.StylePriority.UseTextAlignment = false;
        this.xrTableCell16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell16.Weight = 0.40665558222613912D;
        // 
        // xrTableRow6
        // 
        this.xrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell17,
            this.xrTableCell18,
            this.chi_phi_nc_no,
            this.chi_phi_nc_co,
            this.chi_phi_nc_lai_lo});
        this.xrTableRow6.Dpi = 100F;
        this.xrTableRow6.Name = "xrTableRow6";
        this.xrTableRow6.Weight = 1D;
        // 
        // xrTableCell17
        // 
        this.xrTableCell17.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell17.Dpi = 100F;
        this.xrTableCell17.Name = "xrTableCell17";
        this.xrTableCell17.StylePriority.UseBorders = false;
        this.xrTableCell17.StylePriority.UseTextAlignment = false;
        this.xrTableCell17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell17.Weight = 0.346475678336298D;
        // 
        // xrTableCell18
        // 
        this.xrTableCell18.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell18.Dpi = 100F;
        this.xrTableCell18.Name = "xrTableCell18";
        this.xrTableCell18.StylePriority.UseBorders = false;
        this.xrTableCell18.StylePriority.UseTextAlignment = false;
        this.xrTableCell18.Text = "Chi phí nhân công";
        this.xrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell18.Weight = 0.84901023826432764D;
        // 
        // chi_phi_nc_no
        // 
        this.chi_phi_nc_no.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.chi_phi_nc_no.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "chi_phi_nc_no", "{0:#,#0.00}")});
        this.chi_phi_nc_no.Dpi = 100F;
        this.chi_phi_nc_no.Name = "chi_phi_nc_no";
        this.chi_phi_nc_no.StylePriority.UseBorders = false;
        this.chi_phi_nc_no.StylePriority.UseTextAlignment = false;
        this.chi_phi_nc_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.chi_phi_nc_no.Weight = 0.53484516370009083D;
        // 
        // chi_phi_nc_co
        // 
        this.chi_phi_nc_co.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.chi_phi_nc_co.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "chi_phi_nc_co", "{0:#,#0.00}")});
        this.chi_phi_nc_co.Dpi = 100F;
        this.chi_phi_nc_co.Name = "chi_phi_nc_co";
        this.chi_phi_nc_co.StylePriority.UseBorders = false;
        this.chi_phi_nc_co.StylePriority.UseTextAlignment = false;
        this.chi_phi_nc_co.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.chi_phi_nc_co.Weight = 0.44850799990544848D;
        // 
        // chi_phi_nc_lai_lo
        // 
        this.chi_phi_nc_lai_lo.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.chi_phi_nc_lai_lo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "chi_phi_nc_lai_lo", "{0:#,#0.00}")});
        this.chi_phi_nc_lai_lo.Dpi = 100F;
        this.chi_phi_nc_lai_lo.Name = "chi_phi_nc_lai_lo";
        this.chi_phi_nc_lai_lo.StylePriority.UseBorders = false;
        this.chi_phi_nc_lai_lo.StylePriority.UseTextAlignment = false;
        this.chi_phi_nc_lai_lo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.chi_phi_nc_lai_lo.Weight = 0.40665558222613912D;
        // 
        // xrTableRow7
        // 
        this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell22,
            this.xrTableCell23,
            this.chi_phi_nvl_no,
            this.chi_phi_nvl_co,
            this.chi_phi_nvl_lai_lo});
        this.xrTableRow7.Dpi = 100F;
        this.xrTableRow7.Name = "xrTableRow7";
        this.xrTableRow7.Weight = 1D;
        // 
        // xrTableCell22
        // 
        this.xrTableCell22.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell22.Dpi = 100F;
        this.xrTableCell22.Name = "xrTableCell22";
        this.xrTableCell22.StylePriority.UseBorders = false;
        this.xrTableCell22.StylePriority.UseTextAlignment = false;
        this.xrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell22.Weight = 0.346475678336298D;
        // 
        // xrTableCell23
        // 
        this.xrTableCell23.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell23.Dpi = 100F;
        this.xrTableCell23.Name = "xrTableCell23";
        this.xrTableCell23.StylePriority.UseBorders = false;
        this.xrTableCell23.StylePriority.UseTextAlignment = false;
        this.xrTableCell23.Text = "Chi phí NVL sản xuất";
        this.xrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell23.Weight = 0.84901023826432764D;
        // 
        // chi_phi_nvl_no
        // 
        this.chi_phi_nvl_no.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.chi_phi_nvl_no.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "chi_phi_nvl_no", "{0:#,#0.00}")});
        this.chi_phi_nvl_no.Dpi = 100F;
        this.chi_phi_nvl_no.Name = "chi_phi_nvl_no";
        this.chi_phi_nvl_no.StylePriority.UseBorders = false;
        this.chi_phi_nvl_no.StylePriority.UseTextAlignment = false;
        this.chi_phi_nvl_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.chi_phi_nvl_no.Weight = 0.53484516370009083D;
        // 
        // chi_phi_nvl_co
        // 
        this.chi_phi_nvl_co.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.chi_phi_nvl_co.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "chi_phi_nvl_co", "{0:#,#0.00}")});
        this.chi_phi_nvl_co.Dpi = 100F;
        this.chi_phi_nvl_co.Name = "chi_phi_nvl_co";
        this.chi_phi_nvl_co.StylePriority.UseBorders = false;
        this.chi_phi_nvl_co.StylePriority.UseTextAlignment = false;
        this.chi_phi_nvl_co.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.chi_phi_nvl_co.Weight = 0.44850799990544848D;
        // 
        // chi_phi_nvl_lai_lo
        // 
        this.chi_phi_nvl_lai_lo.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.chi_phi_nvl_lai_lo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "chi_phi_nvl_lai_lo", "{0:#,#0.00}")});
        this.chi_phi_nvl_lai_lo.Dpi = 100F;
        this.chi_phi_nvl_lai_lo.Name = "chi_phi_nvl_lai_lo";
        this.chi_phi_nvl_lai_lo.StylePriority.UseBorders = false;
        this.chi_phi_nvl_lai_lo.StylePriority.UseTextAlignment = false;
        this.chi_phi_nvl_lai_lo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.chi_phi_nvl_lai_lo.Weight = 0.40665558222613912D;
        // 
        // xrTableRow8
        // 
        this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell27,
            this.xrTableCell28,
            this.chi_phi_khac_no,
            this.chi_phi_khac_co,
            this.chi_phi_khac_lai_lo});
        this.xrTableRow8.Dpi = 100F;
        this.xrTableRow8.Name = "xrTableRow8";
        this.xrTableRow8.Weight = 1D;
        // 
        // xrTableCell27
        // 
        this.xrTableCell27.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell27.Dpi = 100F;
        this.xrTableCell27.Name = "xrTableCell27";
        this.xrTableCell27.StylePriority.UseBorders = false;
        this.xrTableCell27.StylePriority.UseTextAlignment = false;
        this.xrTableCell27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell27.Weight = 0.346475678336298D;
        // 
        // xrTableCell28
        // 
        this.xrTableCell28.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell28.Dpi = 100F;
        this.xrTableCell28.Name = "xrTableCell28";
        this.xrTableCell28.StylePriority.UseBorders = false;
        this.xrTableCell28.StylePriority.UseTextAlignment = false;
        this.xrTableCell28.Text = "Chi phí khác";
        this.xrTableCell28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell28.Weight = 0.84901023826432764D;
        // 
        // chi_phi_khac_no
        // 
        this.chi_phi_khac_no.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.chi_phi_khac_no.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "chi_phi_khac_no", "{0:#,#0.00}")});
        this.chi_phi_khac_no.Dpi = 100F;
        this.chi_phi_khac_no.Name = "chi_phi_khac_no";
        this.chi_phi_khac_no.StylePriority.UseBorders = false;
        this.chi_phi_khac_no.StylePriority.UseTextAlignment = false;
        this.chi_phi_khac_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.chi_phi_khac_no.Weight = 0.53484516370009083D;
        // 
        // chi_phi_khac_co
        // 
        this.chi_phi_khac_co.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.chi_phi_khac_co.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "chi_phi_khac_co", "{0:#,#0.00}")});
        this.chi_phi_khac_co.Dpi = 100F;
        this.chi_phi_khac_co.Name = "chi_phi_khac_co";
        this.chi_phi_khac_co.StylePriority.UseBorders = false;
        this.chi_phi_khac_co.StylePriority.UseTextAlignment = false;
        this.chi_phi_khac_co.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.chi_phi_khac_co.Weight = 0.44850799990544848D;
        // 
        // chi_phi_khac_lai_lo
        // 
        this.chi_phi_khac_lai_lo.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.chi_phi_khac_lai_lo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "chi_phi_khac_lai_lo", "{0:#,#0.00}")});
        this.chi_phi_khac_lai_lo.Dpi = 100F;
        this.chi_phi_khac_lai_lo.Name = "chi_phi_khac_lai_lo";
        this.chi_phi_khac_lai_lo.StylePriority.UseBorders = false;
        this.chi_phi_khac_lai_lo.StylePriority.UseTextAlignment = false;
        this.chi_phi_khac_lai_lo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.chi_phi_khac_lai_lo.Weight = 0.40665558222613912D;
        // 
        // xrTableRow9
        // 
        this.xrTableRow9.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell32,
            this.xrTableCell33,
            this.xrTableCell34,
            this.xrTableCell35,
            this.xrTableCell36});
        this.xrTableRow9.Dpi = 100F;
        this.xrTableRow9.Name = "xrTableRow9";
        this.xrTableRow9.Weight = 1D;
        // 
        // xrTableCell32
        // 
        this.xrTableCell32.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell32.Dpi = 100F;
        this.xrTableCell32.Name = "xrTableCell32";
        this.xrTableCell32.StylePriority.UseBorders = false;
        this.xrTableCell32.StylePriority.UseTextAlignment = false;
        this.xrTableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell32.Weight = 0.346475678336298D;
        // 
        // xrTableCell33
        // 
        this.xrTableCell33.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell33.Dpi = 100F;
        this.xrTableCell33.Name = "xrTableCell33";
        this.xrTableCell33.StylePriority.UseBorders = false;
        this.xrTableCell33.StylePriority.UseTextAlignment = false;
        this.xrTableCell33.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell33.Weight = 0.84901023826432764D;
        // 
        // xrTableCell34
        // 
        this.xrTableCell34.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell34.Dpi = 100F;
        this.xrTableCell34.Name = "xrTableCell34";
        this.xrTableCell34.StylePriority.UseBorders = false;
        this.xrTableCell34.StylePriority.UseTextAlignment = false;
        this.xrTableCell34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell34.Weight = 0.53484516370009083D;
        // 
        // xrTableCell35
        // 
        this.xrTableCell35.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell35.Dpi = 100F;
        this.xrTableCell35.Name = "xrTableCell35";
        this.xrTableCell35.StylePriority.UseBorders = false;
        this.xrTableCell35.StylePriority.UseTextAlignment = false;
        this.xrTableCell35.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell35.Weight = 0.44850799990544848D;
        // 
        // xrTableCell36
        // 
        this.xrTableCell36.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell36.Dpi = 100F;
        this.xrTableCell36.Name = "xrTableCell36";
        this.xrTableCell36.StylePriority.UseBorders = false;
        this.xrTableCell36.StylePriority.UseTextAlignment = false;
        this.xrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell36.Weight = 0.40665558222613912D;
        // 
        // xrTableRow10
        // 
        this.xrTableRow10.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell37,
            this.xrTableCell38,
            this.xrTableCell39,
            this.xrTableCell40,
            this.xrTableCell41});
        this.xrTableRow10.Dpi = 100F;
        this.xrTableRow10.Name = "xrTableRow10";
        this.xrTableRow10.Weight = 1D;
        // 
        // xrTableCell37
        // 
        this.xrTableCell37.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell37.Dpi = 100F;
        this.xrTableCell37.Name = "xrTableCell37";
        this.xrTableCell37.StylePriority.UseBorders = false;
        this.xrTableCell37.StylePriority.UseTextAlignment = false;
        this.xrTableCell37.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell37.Weight = 0.346475678336298D;
        // 
        // xrTableCell38
        // 
        this.xrTableCell38.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell38.Dpi = 100F;
        this.xrTableCell38.Name = "xrTableCell38";
        this.xrTableCell38.StylePriority.UseBorders = false;
        this.xrTableCell38.StylePriority.UseTextAlignment = false;
        this.xrTableCell38.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell38.Weight = 0.84901023826432764D;
        // 
        // xrTableCell39
        // 
        this.xrTableCell39.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell39.Dpi = 100F;
        this.xrTableCell39.Name = "xrTableCell39";
        this.xrTableCell39.StylePriority.UseBorders = false;
        this.xrTableCell39.StylePriority.UseTextAlignment = false;
        this.xrTableCell39.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell39.Weight = 0.53484516370009083D;
        // 
        // xrTableCell40
        // 
        this.xrTableCell40.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell40.Dpi = 100F;
        this.xrTableCell40.Name = "xrTableCell40";
        this.xrTableCell40.StylePriority.UseBorders = false;
        this.xrTableCell40.StylePriority.UseTextAlignment = false;
        this.xrTableCell40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell40.Weight = 0.44850799990544848D;
        // 
        // xrTableCell41
        // 
        this.xrTableCell41.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell41.Dpi = 100F;
        this.xrTableCell41.Name = "xrTableCell41";
        this.xrTableCell41.StylePriority.UseBorders = false;
        this.xrTableCell41.StylePriority.UseTextAlignment = false;
        this.xrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell41.Weight = 0.40665558222613912D;
        // 
        // xrTableRow11
        // 
        this.xrTableRow11.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell42,
            this.xrTableCell43,
            this.xrTableCell44,
            this.xrTableCell45,
            this.xrTableCell46});
        this.xrTableRow11.Dpi = 100F;
        this.xrTableRow11.Name = "xrTableRow11";
        this.xrTableRow11.Weight = 1D;
        // 
        // xrTableCell42
        // 
        this.xrTableCell42.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell42.Dpi = 100F;
        this.xrTableCell42.Name = "xrTableCell42";
        this.xrTableCell42.StylePriority.UseBorders = false;
        this.xrTableCell42.StylePriority.UseTextAlignment = false;
        this.xrTableCell42.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell42.Weight = 0.346475678336298D;
        // 
        // xrTableCell43
        // 
        this.xrTableCell43.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell43.Dpi = 100F;
        this.xrTableCell43.Name = "xrTableCell43";
        this.xrTableCell43.StylePriority.UseBorders = false;
        this.xrTableCell43.StylePriority.UseTextAlignment = false;
        this.xrTableCell43.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
        this.xrTableCell43.Weight = 0.84901023826432764D;
        // 
        // xrTableCell44
        // 
        this.xrTableCell44.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell44.Dpi = 100F;
        this.xrTableCell44.Name = "xrTableCell44";
        this.xrTableCell44.StylePriority.UseBorders = false;
        this.xrTableCell44.StylePriority.UseTextAlignment = false;
        this.xrTableCell44.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell44.Weight = 0.53484516370009083D;
        // 
        // xrTableCell45
        // 
        this.xrTableCell45.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell45.Dpi = 100F;
        this.xrTableCell45.Name = "xrTableCell45";
        this.xrTableCell45.StylePriority.UseBorders = false;
        this.xrTableCell45.StylePriority.UseTextAlignment = false;
        this.xrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell45.Weight = 0.44850799990544848D;
        // 
        // xrTableCell46
        // 
        this.xrTableCell46.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell46.Dpi = 100F;
        this.xrTableCell46.Name = "xrTableCell46";
        this.xrTableCell46.StylePriority.UseBorders = false;
        this.xrTableCell46.StylePriority.UseTextAlignment = false;
        this.xrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.xrTableCell46.Weight = 0.40665558222613912D;
        // 
        // xrTableRow3
        // 
        this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12,
            this.tong_no,
            this.tong_co,
            this.tong_lai_lo});
        this.xrTableRow3.Dpi = 100F;
        this.xrTableRow3.Name = "xrTableRow3";
        this.xrTableRow3.Weight = 1D;
        // 
        // xrTableCell12
        // 
        this.xrTableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTableCell12.Dpi = 100F;
        this.xrTableCell12.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTableCell12.Name = "xrTableCell12";
        this.xrTableCell12.StylePriority.UseBorders = false;
        this.xrTableCell12.StylePriority.UseFont = false;
        this.xrTableCell12.StylePriority.UseTextAlignment = false;
        this.xrTableCell12.Text = "Tổng cộng";
        this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        this.xrTableCell12.Weight = 1.1954859427013278D;
        // 
        // tong_no
        // 
        this.tong_no.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_no.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tong_no", "{0:#,#0.00}")});
        this.tong_no.Dpi = 100F;
        this.tong_no.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.tong_no.Name = "tong_no";
        this.tong_no.StylePriority.UseBorders = false;
        this.tong_no.StylePriority.UseTextAlignment = false;
        this.tong_no.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_no.Weight = 0.5348451899223533D;
        // 
        // tong_co
        // 
        this.tong_co.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_co.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tong_co", "{0:#,#0.00}")});
        this.tong_co.Dpi = 100F;
        this.tong_co.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.tong_co.Name = "tong_co";
        this.tong_co.StylePriority.UseBorders = false;
        this.tong_co.StylePriority.UseTextAlignment = false;
        this.tong_co.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_co.Weight = 0.44850799990544837D;
        // 
        // tong_lai_lo
        // 
        this.tong_lai_lo.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.tong_lai_lo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tong_lai_lo", "{0:#,#0.00}")});
        this.tong_lai_lo.Dpi = 100F;
        this.tong_lai_lo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.tong_lai_lo.Name = "tong_lai_lo";
        this.tong_lai_lo.StylePriority.UseBorders = false;
        this.tong_lai_lo.StylePriority.UseTextAlignment = false;
        this.tong_lai_lo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
        this.tong_lai_lo.Weight = 0.40665552990317133D;
        // 
        // xrTable1
        // 
        this.xrTable1.BackColor = System.Drawing.Color.LightGray;
        this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
        this.xrTable1.Dpi = 100F;
        this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
        this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
        this.xrTable1.Name = "xrTable1";
        this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
        this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
        this.xrTable1.SizeF = new System.Drawing.SizeF(754F, 26.77577F);
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
            this.xrTableCell6,
            this.xrTableCell5,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3});
        this.xrTableRow1.Dpi = 100F;
        this.xrTableRow1.Name = "xrTableRow1";
        this.xrTableRow1.Weight = 1D;
        // 
        // xrTableCell6
        // 
        this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell6.Dpi = 100F;
        this.xrTableCell6.Name = "xrTableCell6";
        this.xrTableCell6.StylePriority.UseBorders = false;
        this.xrTableCell6.Text = "MỤC";
        this.xrTableCell6.Weight = 0.346475678336298D;
        // 
        // xrTableCell5
        // 
        this.xrTableCell5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell5.Dpi = 100F;
        this.xrTableCell5.Name = "xrTableCell5";
        this.xrTableCell5.StylePriority.UseBorders = false;
        this.xrTableCell5.Text = "TÊN KHOẢN MỤC";
        this.xrTableCell5.Weight = 0.84901023826432764D;
        // 
        // xrTableCell1
        // 
        this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell1.Dpi = 100F;
        this.xrTableCell1.Name = "xrTableCell1";
        this.xrTableCell1.StylePriority.UseBorders = false;
        this.xrTableCell1.Text = "PHÁT SINH NỢ";
        this.xrTableCell1.Weight = 0.53484516370009083D;
        // 
        // xrTableCell2
        // 
        this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
        this.xrTableCell2.Dpi = 100F;
        this.xrTableCell2.Name = "xrTableCell2";
        this.xrTableCell2.StylePriority.UseBorders = false;
        this.xrTableCell2.Text = "PHÁT SINH CÓ";
        this.xrTableCell2.Weight = 0.44850799990544848D;
        // 
        // xrTableCell3
        // 
        this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                    | DevExpress.XtraPrinting.BorderSide.Right)));
        this.xrTableCell3.Dpi = 100F;
        this.xrTableCell3.Name = "xrTableCell3";
        this.xrTableCell3.StylePriority.UseBorders = false;
        this.xrTableCell3.Text = "LÃI/LỖ";
        this.xrTableCell3.Weight = 0.40665558222613912D;
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
        this.BottomMargin.HeightF = 20F;
        this.BottomMargin.Name = "BottomMargin";
        this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
        this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
        // 
        // ReportHeader
        // 
        this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel2,
            this.ngay});
        this.ReportHeader.Dpi = 100F;
        this.ReportHeader.HeightF = 98.07114F;
        this.ReportHeader.Name = "ReportHeader";
        // 
        // xrLabel1
        // 
        this.xrLabel1.Dpi = 100F;
        this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 2.185886F);
        this.xrLabel1.Multiline = true;
        this.xrLabel1.Name = "xrLabel1";
        this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 0, 100F);
        this.xrLabel1.SizeF = new System.Drawing.SizeF(249.8397F, 51.93911F);
        this.xrLabel1.StylePriority.UsePadding = false;
        this.xrLabel1.Text = "CTY TNHH ANCO BINH DUONG\r\nXƯỞNG ANCO 1\r\nMã số thuế  :  3700318266";
        // 
        // xrLabel2
        // 
        this.xrLabel2.Dpi = 100F;
        this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 54.12499F);
        this.xrLabel2.Multiline = true;
        this.xrLabel2.Name = "xrLabel2";
        this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 0, 100F);
        this.xrLabel2.SizeF = new System.Drawing.SizeF(754F, 20.68912F);
        this.xrLabel2.StylePriority.UseFont = false;
        this.xrLabel2.StylePriority.UsePadding = false;
        this.xrLabel2.StylePriority.UseTextAlignment = false;
        this.xrLabel2.Text = "SỔ TỔNG HỢP CHI PHI SẢN XUẤT TRỰC TIẾP";
        this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
        // 
        // ngay
        // 
        this.ngay.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ngay")});
        this.ngay.Dpi = 100F;
        this.ngay.LocationFloat = new DevExpress.Utils.PointFloat(0F, 74.81409F);
        this.ngay.Multiline = true;
        this.ngay.Name = "ngay";
        this.ngay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.ngay.SizeF = new System.Drawing.SizeF(753.9999F, 23.00001F);
        this.ngay.StylePriority.UseTextAlignment = false;
        this.ngay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // GroupHeader1
        // 
        this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xuong});
        this.GroupHeader1.Dpi = 100F;
        this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("xuong", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
        this.GroupHeader1.HeightF = 44.66667F;
        this.GroupHeader1.Name = "GroupHeader1";
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
        this.xuong.SizeF = new System.Drawing.SizeF(754F, 44.66667F);
        this.xuong.StylePriority.UseFont = false;
        this.xuong.StylePriority.UseTextAlignment = false;
        this.xuong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // ReportFooter
        // 
        this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel10});
        this.ReportFooter.Dpi = 100F;
        this.ReportFooter.HeightF = 72.5F;
        this.ReportFooter.Name = "ReportFooter";
        // 
        // xrLabel5
        // 
        this.xrLabel5.Dpi = 100F;
        this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 23F);
        this.xrLabel5.Multiline = true;
        this.xrLabel5.Name = "xrLabel5";
        this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel5.SizeF = new System.Drawing.SizeF(249.3888F, 25F);
        this.xrLabel5.StylePriority.UseTextAlignment = false;
        this.xrLabel5.Text = "Người lập\r\n";
        this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel4
        // 
        this.xrLabel4.Dpi = 100F;
        this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(249.3887F, 23F);
        this.xrLabel4.Multiline = true;
        this.xrLabel4.Name = "xrLabel4";
        this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel4.SizeF = new System.Drawing.SizeF(255.2224F, 25F);
        this.xrLabel4.StylePriority.UseTextAlignment = false;
        this.xrLabel4.Text = "Kế toán \r\n";
        this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel3
        // 
        this.xrLabel3.Dpi = 100F;
        this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(504.6111F, 23F);
        this.xrLabel3.Multiline = true;
        this.xrLabel3.Name = "xrLabel3";
        this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel3.SizeF = new System.Drawing.SizeF(249.3889F, 24.99999F);
        this.xrLabel3.StylePriority.UseTextAlignment = false;
        this.xrLabel3.Text = "Ban  Giám đốc\r\n";
        this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // xrLabel10
        // 
        this.xrLabel10.Dpi = 100F;
        this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(535.2678F, 0F);
        this.xrLabel10.Multiline = true;
        this.xrLabel10.Name = "xrLabel10";
        this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
        this.xrLabel10.SizeF = new System.Drawing.SizeF(218.7323F, 23F);
        this.xrLabel10.StylePriority.UseTextAlignment = false;
        this.xrLabel10.Text = "Ngày .......  tháng ........ năm ......";
        this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
        // 
        // scnTongHop
        // 
        this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.GroupHeader1,
            this.ReportFooter});
        this.Margins = new System.Drawing.Printing.Margins(35, 38, 0, 20);
        this.PageHeight = 1169;
        this.PageWidth = 827;
        this.PaperKind = System.Drawing.Printing.PaperKind.A4;
        this.Version = "16.1";
        ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion
}