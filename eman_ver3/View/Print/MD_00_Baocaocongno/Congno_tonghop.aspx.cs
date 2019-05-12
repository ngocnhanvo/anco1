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

public partial class PrintControllers_Congno_tonghop_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EntityContext db = new EntityContext();
        rpt_congnotonghop report = new rpt_congnotonghop();
        String sql = this.CreateSql();
        this.viewReport(report, sql);
		//Response.Write(sql);
    }
	
	public int get_kycuoi(md_namtaichinh_ky ky,EntityContext db, int kytru) {
		md_namtaichinh_ky ky2 = db.md_namtaichinh_ky.Where(s => s.md_namtaichinh_id == ky.md_namtaichinh_id & s.soky == ky.soky - kytru).FirstOrDefault();
		if(ky2 != null) {
			md_tonghopcongno thcn = db.md_tonghopcongno.FirstOrDefault(s => s.md_namtaichinh_ky_id == ky2.md_namtaichinh_ky_id);
			if(thcn == null) {
				kytru = kytru + 1;
				kytru = get_kycuoi(ky, db, kytru);
			}
		}
		return kytru;
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
		string md_lenhsanxuat_id = context.Request.QueryString["id"];	
		string dec = context.Request.QueryString["dec"];	
		string thous = context.Request.QueryString["thous"];
		
		string ntc = context.Request.QueryString["ntc"];
		string ky_ = context.Request.QueryString["ky"];
		string dtkd = context.Request.QueryString["dtkd"];
		if(dtkd != "") {
			dtkd = " where C.ma_khncc = N'" + dtkd + "'";
		}
		DateTime denngay = DateTime.ParseExact(ntc ,"dd-MM-yyyy", null);
		string md_namtaichinh_id = db.md_namtaichinh.Where(s => s.giatri.ToString() == ntc).Select(s => s.md_namtaichinh_id).FirstOrDefault();
		md_namtaichinh_ky ky = db.md_namtaichinh_ky.Where(s => s.ngaybatdau <= denngay & s.ngayketthuc >= denngay & s.soky == denngay.Month).FirstOrDefault();
		int kytru = get_kycuoi(ky, db, 1);
		md_namtaichinh_ky ky2 = db.md_namtaichinh_ky.Where(s => s.md_namtaichinh_id == ky.md_namtaichinh_id & s.soky == ky.soky - kytru).FirstOrDefault();
		string thang = "", md_namtaichinh_ky_id = "";
		if(ky2 != null) {
			thang = "" + ky2.soky + 1;
			if(ky2.soky + 1 < 10) {
				thang = "0" + (ky2.soky + 1);
			}
			md_namtaichinh_ky_id = ky2.md_namtaichinh_ky_id;
		}
		else {
			thang = "" + denngay.Month;
			if(denngay.Month < 10) {
				thang = "0" + denngay.Month;
			}
		}
			
		/*string sql = string.Format(@"
		select 
		(sum(thcn.nocuoiky) + sum(thcn.nocuoiky_usd * thcn.tygia)) as psn,
		(sum(thcn.cocuoiky) + sum(thcn.cocuoiky_usd * thcn.tygia)) as psc,
		thcn.ma_dtkd as ma_khncc,
		thcn.ma_dtkd as ten_khncc
		from md_tonghopcongno thcn
		where thcn.md_namtaichinh_ky_id = N'{0}'
		group by thcn.ma_dtkd
		order by thcn.ma_dtkd
		", ky.md_namtaichinh_ky_id);*/
		// inner join c_danhsachdathang dh on dh.c_donhang_id = dsdh.c_donhang_id
		// inner join md_doitackinhdoanh dtkd on dh.md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id
		
		string sql = string.Format(@"
		SELECT distinct T.* from( 
		select sum(C.psn) as psc, sum(C.psc) as psn, C.ma_khncc, C.ten_khncc ,
				(N'Từ ngày ' + convert(nvarchar,convert(datetime,N'{0}',103), 103) + N' đến ngày ' + convert(nvarchar,convert(datetime,N'{1}',103), 103)) as lbl_tungaydenngay
		from( 
			select newid() as id, (sum(thcn.nocuoiky) + sum(thcn.nocuoiky_usd * thcn.tygia)) as psn, 
			(sum(thcn.cocuoiky) + sum(thcn.cocuoiky_usd * thcn.tygia)) as psc, 
			thcn.ma_dtkd as ma_khncc, 
			thcn.ten_dtkd as ten_khncc 
			from md_tonghopcongno thcn WITH (NOLOCK)
			where thcn.md_namtaichinh_ky_id = N'{2}' group by thcn.ma_dtkd, thcn.ten_dtkd 
			
			union 
			select newid() as id, 0 as psn, sum(A.tt) as psc, A.ma_dtkd, A.ten_dtkd 
			from ( select (ddsdh.gianhap * xb_cdh.sl_daxuat) as tt, dtkd.ma_dtkd, dtkd.ten_dtkd 
			from md_xuatban_cdh xb_cdh  WITH (NOLOCK)
			inner join md_xuatban xb WITH (NOLOCK) on xb.md_xuatban_id = xb_cdh.md_xuatban_id 
			inner join c_danhsachdathang dsdh WITH (NOLOCK) on dsdh.c_danhsachdathang_id = xb.c_danhsachdathang_id
			inner join c_dongdsdh ddsdh WITH (NOLOCK) on ddsdh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id				
			inner join md_doitackinhdoanh dtkd WITH (NOLOCK) on xb.md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id	
			where xb.trangthai = 'HIEULUC' 
			and ddsdh.md_sanpham_id = xb_cdh.md_sanpham_id 
			and xb.ngaychuyen >= CONVERT(datetime,N'{0} 00:00',103) 
			and xb.ngaychuyen <= CONVERT(datetime,N'{1} 23:59',103) ) A group by A.ma_dtkd, A.ten_dtkd 			
			union 
			select newid() as id, (B.ttusd * B.tygia + B.ttvnd) as psn, 0 as psc, B.ma_dtkd, B.ten_dtkd 
			from ( 
				select 
				sum(isnull( (case when A.giatri = 0 then A.ttusd * A.tygia else (A.ttusd * A.tygia) + (A.ttusd * A.tygia * A.giatri / 100) end)  ,0)) as ttusd, 
				sum(isnull( (case when A.giatri = 0 then A.ttvnd else A.ttvnd + (A.ttvnd * A.giatri / 100) end) ,0)) as ttvnd,
				A.tygia, A.ma_dtkd, A.ten_dtkd 
				from ( 
					select 
                    (case when bg.md_dongtien_id = '385ec93024915838c98ef66e58b02e9b' then dmh_cdh.dongiamua * nkncc_dh.sl_danhap else 0 end) as ttusd, 
					(case when bg.md_dongtien_id = '385ec93024915838c98ef66e58b02e9b' then 0 else dmh_cdh.dongiamua * nkncc_dh.sl_danhap end)
					as ttvnd, dmh.tygiaVND as tygia, dtkd.ma_dtkd, dtkd.ten_dtkd, thue.giatri
					from md_nhapkho_ncc_dh nkncc_dh WITH (NOLOCK)
					INNER join md_nhapkho_ncc nkncc WITH (NOLOCK) on nkncc_dh.md_nhapkho_ncc_id = nkncc.md_nhapkho_ncc_id
					INNER join c_donmuahang_cdmh dmh_cdh WITH (NOLOCK) on nkncc.c_donmuahang_id = dmh_cdh.c_donmuahang_id
					INNER JOIN md_thue_sanpham thue WITH (NOLOCK) on thue.md_thue_sanpham_id = dmh_cdh.thue
					INNER join c_donmuahang dmh WITH (NOLOCK) on dmh.c_donmuahang_id = dmh_cdh.c_donmuahang_id
					INNER join md_doitackinhdoanh dtkd WITH (NOLOCK) on dmh.md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id  
					INNER join md_phienbangia pbg WITH (NOLOCK) on pbg.md_phienbangia_id = dmh.md_phienbangia_id
					INNER join md_banggia bg WITH (NOLOCK) on bg.md_banggia_id = pbg.md_banggia_id
					INNer join md_dongtien dt WITH (NOLOCK) on dt.md_dongtien_id = bg.md_dongtien_id
					where nkncc.trangthai = 'HIEULUC'
					AND dmh_cdh.md_sanpham_id = nkncc_dh.md_sanpham_id
					AND nkncc_dh.sl_danhap > 0
					and dmh_cdh.md_sanpham_id = nkncc_dh.md_sanpham_id 
					and nkncc.ngaychuyen >= CONVERT(datetime,N'{0} 00:00',103) 
					and nkncc.ngaychuyen <= CONVERT(datetime,N'{1} 23:59',103) 
				)A group by A.ma_dtkd, A.ten_dtkd, A.tygia
			)B 
		)C 
		{3}
		group by C.ma_khncc, C.ten_khncc 
		union all
		select sum(C.psn) as psc, sum(C.psc) as psn, C.ma_khncc, C.ten_khncc ,
				(N'Từ ngày ' + convert(nvarchar,convert(datetime,N'{0}',103), 103) + N' đến ngày ' + convert(nvarchar,convert(datetime,N'{1}',103), 103)) as lbl_tungaydenngay
		from( 
			select newid() as id, (sum(thcn.nocuoiky) + sum(thcn.nocuoiky_usd * thcn.tygia)) as psn, 
			(sum(thcn.cocuoiky) + sum(thcn.cocuoiky_usd * thcn.tygia)) as psc, 
			thcn.ma_dtkd as ma_khncc, 
			thcn.ten_dtkd as ten_khncc 
			from md_tonghopcongno thcn WITH (NOLOCK)
			where thcn.md_namtaichinh_ky_id = N'{2}' group by thcn.ma_dtkd, thcn.ten_dtkd 
			
			union 
			select newid() as id, 0 as psn, sum(A.tt) as psc, A.ma_dtkd, A.ten_dtkd 
			from ( select (ddsdh.gianhap * xb_cdh.sl_daxuat) as tt, dtkd.ma_dtkd, dtkd.ten_dtkd 
			from md_xuatban_cdh xb_cdh WITH (NOLOCK)
			inner join md_xuatban xb WITH (NOLOCK) on xb.md_xuatban_id = xb_cdh.md_xuatban_id 
			inner join c_danhsachdathang dsdh WITH (NOLOCK) on dsdh.c_danhsachdathang_id = xb.c_danhsachdathang_id
			inner join c_dongdsdh ddsdh WITH (NOLOCK) on ddsdh.c_danhsachdathang_id = dsdh.c_danhsachdathang_id				
			inner join md_doitackinhdoanh dtkd WITH (NOLOCK) on xb.md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id	
			where xb.trangthai = 'HIEULUC' 
			and ddsdh.md_sanpham_id = xb_cdh.md_sanpham_id 
			and xb.ngaychuyen >= CONVERT(datetime,N'{0} 00:00',103) 
			and xb.ngaychuyen <= CONVERT(datetime,N'{1} 23:59',103) ) A group by A.ma_dtkd, A.ten_dtkd 			
			union 
			select newid() as id, (B.ttusd * B.tygia + B.ttvnd) as psn, 0 as psc, B.ma_dtkd, B.ten_dtkd 
			from ( 
				select 
				sum(isnull( (case when A.giatri = 0 then A.ttusd * A.tygia else (A.ttusd * A.tygia) + (A.ttusd * A.tygia * A.giatri / 100) end)  ,0)) as ttusd, 
				sum(isnull( (case when A.giatri = 0 then A.ttvnd else A.ttvnd + (A.ttvnd * A.giatri / 100) end) ,0)) as ttvnd,
				A.tygia, A.ma_dtkd, A.ten_dtkd 
				from ( 
					select (case when bg.md_dongtien_id = '385ec93024915838c98ef66e58b02e9b' then dmh_cdh.dongiamua * nkncc_dh.sl_danhap else 0 end) as ttusd, 
					(case when bg.md_dongtien_id = '385ec93024915838c98ef66e58b02e9b' then 0 else dmh_cdh.dongiamua * nkncc_dh.sl_danhap end)
					as ttvnd, dmh.tygiaVND as tygia, dtkd.ma_dtkd, dtkd.ten_dtkd, thue.giatri
					from md_nhapkho_ncc_dh nkncc_dh  WITH (NOLOCK)
					INNER join md_nhapkho_ncc nkncc WITH (NOLOCK) on nkncc_dh.md_nhapkho_ncc_id = nkncc.md_nhapkho_ncc_id
					INNER join c_donmuahang_cdmh dmh_cdh WITH (NOLOCK) on nkncc.c_donmuahang_id = dmh_cdh.c_donmuahang_id
					INNER JOIN md_thue_sanpham thue WITH (NOLOCK) on thue.md_thue_sanpham_id = dmh_cdh.thue
					INNER join c_donmuahang dmh WITH (NOLOCK) on dmh.c_donmuahang_id = dmh_cdh.c_donmuahang_id
					INNER join md_doitackinhdoanh dtkd WITH (NOLOCK) on dmh.md_doitackinhdoanh_id = dtkd.md_doitackinhdoanh_id  
					INNER join md_phienbangia pbg WITH (NOLOCK) on pbg.md_phienbangia_id = dmh.md_phienbangia_id
					INNER join md_banggia bg WITH (NOLOCK) on bg.md_banggia_id = pbg.md_banggia_id
					INNer join md_dongtien dt WITH (NOLOCK) on dt.md_dongtien_id = bg.md_dongtien_id
					where nkncc.trangthai = 'HIEULUC'
					AND dmh_cdh.md_sanpham_id = nkncc_dh.md_sanpham_id
					AND nkncc_dh.sl_danhap > 0
					and dmh_cdh.md_sanpham_id = nkncc_dh.md_sanpham_id 
					and nkncc.ngaychuyen >= CONVERT(datetime,N'{0} 00:00',103) 
					and nkncc.ngaychuyen <= CONVERT(datetime,N'{1} 23:59',103) 
				)A group by A.ma_dtkd, A.ten_dtkd, A.tygia
			)B 
		)C 
		{3}
		group by C.ma_khncc, C.ten_khncc
		)T
		order by T.ma_khncc, T.ten_khncc
		", ky_, ntc, "12345", dtkd);
		//",denngay.ToString("01-"+ thang +"-yyyy"), ntc, "12345", dtkd);
		
		return sql;
    }

    /// <summary>
    /// Summary description for rpt_congnotonghop
    /// </summary>
    public class rpt_congnotonghop : DevExpress.XtraReports.UI.XtraReport
    {
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private XRTable xrTable3;
        private XRTableRow xrTableRow3;
        private XRTableCell ma_khncc;
        private XRTableCell ten_khncc;
        private XRTableCell psn;
        private XRTableCell psc;
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
        private XRTable xrTable1;
        private XRTableRow xrTableRow1;
        private XRTableCell xrTableCell2;
        private XRTableCell xrTableCell6;
        private XRTableCell sum_psn;
        private XRTableCell sum_psc;
        private XRTableCell xrTableCell8;
        private PageHeaderBand PageHeader;
        private XRTable xrTable2;
        private XRTableRow xrTableRow2;
        private XRTableCell xrTableCell7;
        private XRTableCell xrTableCell4;
        private XRTableCell xrTableCell5;
        private XRTableCell xrTableCell1;
        private XRTableCell xrTableCell3;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public rpt_congnotonghop()
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
            string resourceFileName = "rpt_congnotonghop.resx";
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.ma_khncc = new DevExpress.XtraReports.UI.XRTableCell();
            this.ten_khncc = new DevExpress.XtraReports.UI.XRTableCell();
            this.psn = new DevExpress.XtraReports.UI.XRTableCell();
            this.psc = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sum_psn = new DevExpress.XtraReports.UI.XRTableCell();
            this.sum_psc = new DevExpress.XtraReports.UI.XRTableCell();
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
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
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
            this.xrTableCell8,
            this.ma_khncc,
            this.ten_khncc,
            this.psn,
            this.psc});
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // ma_khncc
            // 
            this.ma_khncc.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.ma_khncc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ma_khncc")});
            this.ma_khncc.Name = "ma_khncc";
            this.ma_khncc.StylePriority.UseBorders = false;
            this.ma_khncc.StylePriority.UseTextAlignment = false;
            this.ma_khncc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.ma_khncc.Weight = 1.3224447352641613D;
            // 
            // ten_khncc
            // 
            this.ten_khncc.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.ten_khncc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ten_khncc")});
            this.ten_khncc.Name = "ten_khncc";
            this.ten_khncc.StylePriority.UseBorders = false;
            this.ten_khncc.StylePriority.UseTextAlignment = false;
            this.ten_khncc.Text = "01/07/16";
            this.ten_khncc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.ten_khncc.Weight = 2.84847283812936D;
            // 
            // psn
            // 
            this.psn.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.psn.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "psn", "{0:#,#0}")});
            this.psn.Name = "psn";
            this.psn.StylePriority.UseBorders = false;
            this.psn.StylePriority.UseTextAlignment = false;
            this.psn.Text = "SỐ LƯỢNG";
            this.psn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.psn.Weight = 1.7697773807200199D;
            // 
            // psc
            // 
            this.psc.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.psc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "psc", "{0:#,#0}")});
            this.psc.Name = "psc";
            this.psc.StylePriority.UseBorders = false;
            this.psc.StylePriority.UseTextAlignment = false;
            this.psc.Text = "THÀNH TIỀN";
            this.psc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.psc.Weight = 1.7908189550283609D;
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
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xrTable4,
            this.xrLabel9});
            this.ReportFooter.HeightF = 108.8333F;
            this.ReportFooter.KeepTogether = true;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrTable1
            // 
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(820F, 35F);
            this.xrTable1.StylePriority.UsePadding = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell6,
            this.sum_psn,
            this.sum_psc});
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.StylePriority.UseBorders = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 1.743844644481634D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "Tổng cộng";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.Weight = 2.84847283812936D;
            // 
            // sum_psn
            // 
            this.sum_psn.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.sum_psn.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "psn")});
            this.sum_psn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.sum_psn.Name = "sum_psc";
            this.sum_psn.StylePriority.UseBorders = false;
            this.sum_psn.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:#,#0}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.sum_psn.Summary = xrSummary2;
            this.sum_psn.Text = "[psn]";
            this.sum_psn.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.sum_psn.Weight = 1.7697773807200199D;
            // 
            // sum_psc
            // 
            this.sum_psc.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.sum_psc.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "psc")});
            this.sum_psc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.sum_psc.Name = "sum_psc";
            this.sum_psc.StylePriority.UseBorders = false;
            this.sum_psc.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:#,#0}";
            xrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.sum_psc.Summary = xrSummary3;
            this.sum_psc.Text = "sum_psc";
            this.sum_psc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.sum_psc.Weight = 1.7908189550283609D;
            // 
            // xrTable4
            // 
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0.0001589457F, 83.8333F);
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
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(535.834F, 35F);
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
            this.ReportHeader.HeightF = 115.9583F;
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
            this.xrLabel5.Text = "SỔ TỔNG HỢP CÔNG NỢ";
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
            this.xrLabel2.Text = "XƯỞNG ANCO 2";
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
            // xrTableCell8
            // 
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell8.Summary = xrSummary1;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell8.Weight = 0.42139990921747278D;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.PageHeader.HeightF = 25F;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.LightGray;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
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
            this.xrTableCell7,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell1,
            this.xrTableCell3});
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBorders = false;
            this.xrTableCell7.StylePriority.UseFont = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "STT";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 0.42139885641622121D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBorders = false;
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "MÃ KH/NCC";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 1.3224448697919367D;
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
            this.xrTableCell5.Text = "TÊN KH/NCC";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell5.Weight = 2.8484727489826525D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseBorders = false;
            this.xrTableCell1.StylePriority.UseFont = false;
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "PHÁT SINH NỢ";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 1.7697792902651388D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.StylePriority.UseBorders = false;
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.Text = "PHÁT SINH CÓ (ĐÃ BAO GỒM VAT)";
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 1.7908180529034263D;
            // 
            // rpt_congnotonghop
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter,
            this.ReportHeader,
            this.PageHeader});
            this.Margins = new System.Drawing.Printing.Margins(4, 3, 4, 100);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "12.2";
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
    }
}

