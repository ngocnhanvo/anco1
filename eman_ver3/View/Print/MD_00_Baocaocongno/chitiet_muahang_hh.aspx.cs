using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using DataAcess;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using HSSFUtils;
using NPOI.HSSF;
using NPOI.HSSF.Util;
using NPOI.DDF;
using NPOI.HSSF.Model;
using NPOI.HSSF.Record;
using NPOI.HSSF.Record.Aggregates;
using NPOI.HSSF.Record.AutoFilter;

public partial class PrintControllers_chitiet_muahang_hh_Default : System.Web.UI.Page
{
    public EntityContext db = new EntityContext();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
		string md_lenhsanxuat_id = context.Request.QueryString["id"];	
		string dec = context.Request.QueryString["dec"];	
		string thous = context.Request.QueryString["thous"];
		
		string ntc = context.Request.QueryString["ntc"];
		string ky_ = context.Request.QueryString["ky"];
		string dtkd = context.Request.QueryString["dtkd"];
		
		if(dtkd != "") {
			dtkd = " and dtkd.ma_dtkd = N'" + dtkd + "'";
		}
		
		string thang = "", md_namtaichinh_ky_id = "";
		
		string sql = string.Format(@"
			SELECT
				   A.cel_donhang AS donmua,
				   A.cel_ngaydonhang AS ngay_donmua,
				   A.cel_mavthh AS mahh,
				   A.cel_dvt AS dvt,
				   A.cel_sl AS sl,
				   A.lbl_tenkh AS ncc,
				   A.cel_dongia AS dongia,
				   (A.cel_dongia * A.cel_sl) AS thanhtien,
				   CONVERT(decimal(18, 2), (((A.cel_dongia * A.cel_sl * A.vat)/100))) as vat,
				   (((A.cel_dongia * A.cel_sl * A.vat)/100) + (A.cel_dongia * A.cel_sl)) as tongtien,
				   A.cel_tenvthh AS tenhh,
				   A.ma_dtkd as ma_dtkd,
				   N'VNĐ' as tiente,
				   convert(datetime,N'{0} 00:00',103) as tungay,
				   convert(datetime,N'{1} 23:59',103) as denngay
			FROM
			  (SELECT dmh.sochungtu AS cel_donhang,
					  dmh.ngaydonhang AS cel_ngaydonhang,
					  sp.ma_sanpham AS cel_mavthh,
					  sp.mota_tiengviet AS cel_tenvthh,
					  dvt_sp.ten_dvt AS cel_dvt,
					  dmh_cdh.sl_hanngach AS cel_sl,
					  CONVERT(decimal(18, 2), thue.giatri) AS vat,
					  (CASE
						   WHEN bg.md_dongtien_id = '385ec93024915838c98ef66e58b02e9b' THEN (dmh_cdh.dongiamua * [dbo].[GET_TyGia](convert(nvarchar, dmh.ngaydonhang, 103)))
						   ELSE dmh_cdh.dongiamua
					   END) AS cel_dongia,
					  (dtkd.ten_dtkd) AS lbl_tenkh,
					  dtkd.ma_dtkd as ma_dtkd
			   from c_donmuahang dmh
			   INNER join c_donmuahang_cdmh dmh_cdh ON dmh_cdh.c_donmuahang_id = dmh.c_donmuahang_id
			   INNER JOIN md_thue_sanpham thue ON thue.md_thue_sanpham_id = dmh_cdh.thue
			   INNER join md_phienbangia pbg ON dmh.md_phienbangia_id = pbg.md_phienbangia_id
			   INNER join md_banggia bg ON pbg.md_banggia_id = bg.md_banggia_id
			   LEFT join md_sanpham sp ON sp.md_sanpham_id = dmh_cdh.md_sanpham_id
			   LEFT JOIN md_donvitinhsanpham dvt_sp ON dvt_sp.md_donvitinhsanpham_id = sp.md_donvitinhsanpham_id
			   INNER join md_doitackinhdoanh dtkd ON dtkd.md_doitackinhdoanh_id = dmh.md_doitackinhdoanh_id
			   WHERE (dmh.md_trangthai_id = 'DAXONG' or dmh.md_trangthai_id = 'KETTHUC')
				 AND dmh.ngaydonhang >= convert(datetime,N'{0} 00:00',103)
				 AND dmh.ngaydonhang <= convert(datetime,N'{1} 23:59',103)
				 {2}
			   GROUP BY dtkd.ten_dtkd,
						dtkd.ma_dtkd,
						dmh.sochungtu,
						dmh.ngaydonhang,
						sp.ma_sanpham,
						dmh_cdh.sl_hanngach,
						dvt_sp.ten_dvt,
						dmh_cdh.dongiamua,
						bg.md_dongtien_id,
						sp.mota_tiengviet,
						thue.giatri) A
			ORDER BY A.lbl_tenkh ASC,
					 A.cel_mavthh ASC,
					 A.cel_donhang ASC
			", ky_, ntc, dtkd);		
        System.Data.DataTable dt = Mbg.Data.SqlClient.SqlHelper.GetData(sql);
        //Response.Write(sql);

        if (dt.Rows.Count != 0)
		{
			HSSFWorkbook hssfworkbook = this.CreateWorkBookPO(dt);
			String saveAsFileName = String.Format("chitiet_muahang{0}.xls", DateTime.Now);
			this.SaveFile(hssfworkbook, saveAsFileName);
		}
		else
		{
			Response.Write("<h3 align='center'>Báo cáo không có dữ liệu</h3>");
		}
    }
	
	public HSSFWorkbook CreateWorkBookPO(DataTable dt)
    {
        HSSFWorkbook hssfworkbook = new HSSFWorkbook();
        ISheet s1 = hssfworkbook.CreateSheet("Sheet1");
        HSSFSheet hssfsheet = (HSSFSheet)s1;

        Excel_Format ex_fm = new Excel_Format(hssfworkbook);
		//--
        ICellStyle celltext = ex_fm.getcell(12, false, true, "", "L", "T");
		//--
        ICellStyle cellBold = ex_fm.getcell(11, true, true, "", "L", "T");
		//-- 
		ICellStyle cellHeader = ex_fm.getcell(11, false, true, "", "C", "T");
		//-- 
		ICellStyle cellHeader_n = ex_fm.getcell(16, true, true, "", "C", "T");
		//--
		ICellStyle celln = ex_fm.getcell2(11, false, false, "", "R", "c", "#,##0.00");
		//--
		ICellStyle cellnn_r = ex_fm.getcell(11, false, false, "", "R", "T");
		//--
		ICellStyle border_n = ex_fm.getcell2(11, false, false, "LRBT", "R", "T", "#,##0.0");
		//--
		ICellStyle border_nt = ex_fm.getcell2(11, false, false, "LRBT", "R", "T", "#,##0.0");
		//--
		ICellStyle border_n1 = ex_fm.getcell2(11, false, false, "LRBT", "R", "T", "#,##0.00");
		//--
		ICellStyle border_n2 = ex_fm.getcell2(11, false, false, "LRBT", "R", "T", "#,##");
		//--
		ICellStyle border = ex_fm.getcell(11, false, false, "LRBT", "L", "T");
		//--
		ICellStyle border_r = ex_fm.getcell(11, false, false, "LRBT", "R", "T");
		//--
		ICellStyle border_tt = ex_fm.getcell(11, false, false, "LRBT", "C", "T");
		//--
		ICellStyle borderWrap = ex_fm.getcell(11, true, true, "LRBT", "C", "T");
        //--
        int heigh = 22;
        int row = 0;
        //set A1 - A3
        string[] a = { "CHI TIẾT MUA HÀNG" };
        for (int i = 0; i < a.Count(); i++)
        {
            s1.CreateRow(row).CreateCell(0).SetCellValue(a[i]);
            s1.AddMergedRegion(new CellRangeAddress(row, row, 0, 7));
            s1.GetRow(row).HeightInPoints = heigh;
            if (i == 0)
            {
                s1.GetRow(row).HeightInPoints = 30;
                s1.GetRow(row).GetCell(0).CellStyle = cellHeader_n;
            }
            row++;
        }
        //--

        //set F4 - F5
        string[] b = { "Từ ngày:", "Đến ngày:" };
        string[] b_value = { "tungay", "denngay" };
        for (int i = 0; i < b.Count(); i++)
        {
            s1.CreateRow(row).CreateCell(6).SetCellValue(b[i]);
            s1.GetRow(row).GetCell(6).CellStyle = celltext;
			s1.GetRow(row).CreateCell(7).SetCellValue(DateTime.Parse(dt.Rows[0][b_value[i]].ToString()).ToString("dd/MM/yyyy"));
            s1.GetRow(row).GetCell(7).CellStyle = celltext;
            s1.GetRow(row).HeightInPoints = heigh;
            row++;
        }
		
		string ncc = "", ma_sanpham = "";
		int vitri_tu_mhh = 0, vitri_den_mhh = 0, vitri_tong_hh = 0, vitri_tong_ncc = 0, check_end = 0;
		int nht = 0;
		for (nht = 0; nht < dt.Rows.Count; nht++)
        {	
			if(ma_sanpham != dt.Rows[nht]["mahh"].ToString())
			{
				//tinh tong cong
				if(vitri_tu_mhh > 0)
				{
					if(vitri_den_mhh <= 0)
						vitri_den_mhh = vitri_tu_mhh;
					else
						vitri_den_mhh = row;

					s1.CreateRow(row).CreateCell(0).SetCellValue("");
					s1.GetRow(row).GetCell(0).CellStyle = borderWrap;
					s1.CreateRow(row).CreateCell(6).SetCellValue("Tổng:");
					s1.GetRow(row).GetCell(6).CellStyle = borderWrap;
					s1.GetRow(row).CreateCell(7).CellFormula = String.Format("SUM(H{0}:H{1})",vitri_tu_mhh+1,vitri_den_mhh);
					s1.GetRow(row).GetCell(7).CellStyle = border_nt;
					s1.GetRow(row).HeightInPoints = heigh;					
					row++;					
				}
			}
			else
			{
				vitri_den_mhh = row;
			}
			
			//NCC
			if(ncc != dt.Rows[nht]["ncc"].ToString())
			{
				ncc = dt.Rows[nht]["ncc"].ToString();
				string[] c = { "Nhà cung cấp:" };
				string[] c_value = { "ncc" };
				for (int i = 0; i < c.Count(); i++)
				{
					s1.CreateRow(row).CreateCell(1).SetCellValue(c[i]);
					s1.GetRow(row).GetCell(1).CellStyle = celltext;
					s1.GetRow(row).CreateCell(2).SetCellValue(dt.Rows[nht][c_value[i]].ToString());
					s1.GetRow(row).GetCell(2).CellStyle = celltext;
					s1.GetRow(row).HeightInPoints = heigh;
					s1.AddMergedRegion(new CellRangeAddress(row, row, 2, 7));			
				}
				row++;
			}
			else
			{
				ncc = dt.Rows[nht]["ncc"].ToString();
			}
			//HH/VT
			if(ma_sanpham != dt.Rows[nht]["mahh"].ToString())
			{
				//bat dau ma_hh moi
				ma_sanpham = dt.Rows[nht]["mahh"].ToString();
				string[] c = { "Mã HH/VT:" };
				string[] c_value = { "mahh" };
				for (int i = 0; i < c.Count(); i++)
				{
					s1.CreateRow(row).CreateCell(1).SetCellValue(c[i]);
					s1.GetRow(row).GetCell(1).CellStyle = celltext;
					s1.GetRow(row).CreateCell(2).SetCellValue(dt.Rows[nht][c_value[i]].ToString());
					s1.GetRow(row).GetCell(2).CellStyle = celltext;
					s1.GetRow(row).HeightInPoints = heigh;
					s1.AddMergedRegion(new CellRangeAddress(row, row, 2, 7));
				}
				row++;
				// set A13 - All
				// -- Header
				int cell = 0;
				string[] d = { "Đơn hàng", "Ngày đơn hàng", "Số lượng", "ĐVT", "Đơn giá", "thành tiền", "VAT", "Tổng tiền" };
				IRow rowColumnHeader = s1.CreateRow(row);
				rowColumnHeader.HeightInPoints = 30;
				for (int i = 0; i < d.Count(); i++)
				{
					int with = 5000;
					if(d[i] == "ĐVT")
						with = 2500;
					rowColumnHeader.CreateCell(cell).SetCellValue(d[i]);
					rowColumnHeader.GetCell(i).CellStyle = borderWrap;
					s1.SetColumnWidth(cell, with);
					cell++;
				}	
				row++;
				vitri_tu_mhh = row;
			}
			else
			{
				//tiep tuc ma_hh
				ma_sanpham = dt.Rows[nht]["mahh"].ToString();
				vitri_den_mhh = row;
			}
			// -- Details
			// create column
			// create detail row		
			string[] e_value = { "donmua", "ngay_donmua", "sl", "dvt", "dongia", "thanhtien", "vat","tongtien" };
			IRow row_t = s1.CreateRow(row); row_t.HeightInPoints = 22;
			//
			int cell_t = 0;
			for (int j = 0; j < e_value.Count(); j++)
			{
				if(e_value[j] == "donmua" | e_value[j] == "dvt" )
				{
					row_t.CreateCell(cell_t).SetCellValue(dt.Rows[nht][e_value[j]].ToString());
					row_t.GetCell(cell_t).CellStyle = border; 
				}					
				else if(e_value[j] == "sl" | e_value[j] == "dongia" | e_value[j] == "thanhtien" | e_value[j] == "vat" | e_value[j] == "tongtien")
				{
					row_t.CreateCell(cell_t).SetCellValue(double.Parse(dt.Rows[nht][e_value[j]].ToString()));
					row_t.GetCell(cell_t).CellStyle = border_n; 
				}
				else
				{
					row_t.CreateCell(cell_t).SetCellValue(DateTime.Parse(dt.Rows[nht][e_value[j]].ToString()).ToString("dd/MM/yyyy"));
					row_t.GetCell(cell_t).CellStyle = border_tt; 
				}
				cell_t++;
			}
			row++;
		}
		if(nht == dt.Rows.Count)
		{
			s1.CreateRow(row).CreateCell(0).SetCellValue("");
			s1.GetRow(row).GetCell(0).CellStyle = borderWrap;
			s1.CreateRow(row).CreateCell(6).SetCellValue("Tổng:");
			s1.GetRow(row).GetCell(6).CellStyle = borderWrap;
			s1.GetRow(row).CreateCell(7).CellFormula = String.Format("SUM(H{0}:H{1})",vitri_tu_mhh+1,vitri_den_mhh);
			s1.GetRow(row).GetCell(7).CellStyle = border_nt;
			s1.GetRow(row).HeightInPoints = heigh;				
		}
		row++;
		
        #region Format Print Excel

        s1.PrintSetup.PaperSize = (short)PaperSize.A4;
        s1.FitToPage = true;
        s1.PrintSetup.FitWidth = 1;
        s1.PrintSetup.FitHeight = 0;
        s1.SetMargin(MarginType.TopMargin, 0.75);
        s1.SetMargin(MarginType.BottomMargin, 0.75);
        s1.SetMargin(MarginType.LeftMargin, 0.23);
        s1.SetMargin(MarginType.RightMargin, 0.23);
        s1.SetMargin(MarginType.HeaderMargin, 0.31);
        s1.SetMargin(MarginType.FooterMargin, 0.31);
        hssfworkbook.SetPrintArea(
            hssfworkbook.GetSheetIndex(s1.SheetName), //sheet index
            0, //start column
            6, //end column
            0, //start row
            row + 1
        );
        #endregion

        return hssfworkbook;
    }

    public void SaveFile(HSSFWorkbook hsswb, String saveAsFileName)
    {
        MemoryStream exportData = new MemoryStream();
        hsswb.Write(exportData);

        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", saveAsFileName));
        Response.Clear();
        Response.BinaryWrite(exportData.GetBuffer());
        Response.End();
    }
}