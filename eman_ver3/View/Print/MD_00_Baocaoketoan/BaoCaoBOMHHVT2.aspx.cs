using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DataAcess;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public partial class PrintControllers_MD_00_Baocaoketoan_BaoCaoBOMHHVT2 : System.Web.UI.Page
{
    public string logo = "", sothapphan = "", inPDF = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        sothapphan = PrintAnco2.GetDecimal(context.Request.QueryString["stp"], 1);
        inPDF = context.Request.QueryString["inPDF"];
        string nameTemp = "[KT] BOM HHVT mới nhất.repx";
        string nameRpt = "BOM HHVT mới nhất {ngayin}";
        string sql = CreateSql(context);

        var task = new System.Threading.Tasks.Task(() => { viewReport(sql); });
        PrintAnco2.exportDataWithType(task, sql, inPDF, nameTemp, nameRpt, ReportViewer1, true);
    }

    public void viewReport(String SqlQuery)
    {
        var report = ReportViewer1.Report;
        var ds = report.DataSource as DataSet;
        if (ds == null || ds.Tables.Count == 0) return;

        var matrix = BuildMatrix(ds.Tables[0]);
        report.DataSource = matrix;
        BuildMatrixLayout(report, matrix);
    }

    private DataTable BuildMatrix(DataTable source)
    {
        var result = new DataTable("BOMHHVT2");
        result.Columns.Add("MAHH", typeof(string));
        if (source == null || source.Rows.Count == 0) return result;

        var vatTus = source.AsEnumerable()
            .Where(r => !r.IsNull("maVT"))
            .Select(r => Convert.ToString(r["maVT"]).Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .OrderBy(x => x, StringComparer.OrdinalIgnoreCase)
            .ToList();

        foreach (var maVT in vatTus) result.Columns.Add(maVT, typeof(decimal));

        var hangHoas = source.AsEnumerable()
            .GroupBy(r => new
            {
                MaHH = Convert.ToString(r["maHH"]),
                GroupOrder = Convert.ToInt32(r["group_order"]),
                SortType = Convert.ToInt32(r["sort_type"]),
                SortOrder = Convert.ToInt32(r["sort_order"])
            })
            .OrderBy(g => g.Key.GroupOrder)
            .ThenBy(g => g.Key.SortType)
            .ThenBy(g => g.Key.SortOrder)
            .ThenBy(g => g.Key.MaHH, StringComparer.OrdinalIgnoreCase);

        foreach (var hangHoa in hangHoas)
        {
            var row = result.NewRow();
            row["MAHH"] = hangHoa.Key.MaHH;
            foreach (var maVT in vatTus) row[maVT] = 0m;

            foreach (var item in hangHoa)
            {
                if (item.IsNull("maVT") || item.IsNull("sl")) continue;
                string maVT = Convert.ToString(item["maVT"]).Trim();
                if (!result.Columns.Contains(maVT)) continue;
                row[maVT] = Convert.ToDecimal(row[maVT]) + Convert.ToDecimal(item["sl"]);
            }
            result.Rows.Add(row);
        }
        return result;
    }

    private void BuildMatrixLayout(XtraReport report, DataTable matrix)
    {
        report.Bands.Clear();
        var pageHeader = new PageHeaderBand { HeightF = 30f };
        var detail = new DetailBand { HeightF = 24f };
        report.Bands.Add(pageHeader);
        report.Bands.Add(detail);

        float maHHWidth = 145f;
        float vatTuWidth = 82f;
        float totalWidth = maHHWidth + Math.Max(0, matrix.Columns.Count - 1) * vatTuWidth;
        report.PaperKind = System.Drawing.Printing.PaperKind.Custom;
        report.PageWidth = (int)Math.Ceiling(totalWidth + 40f);
        report.PageHeight = 827;
        report.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);

        var headerTable = new XRTable
        {
            LocationF = new DevExpress.Utils.PointFloat(0f, 0f),
            WidthF = totalWidth,
            HeightF = 30f,
            Borders = BorderSide.All
        };
        var headerRow = new XRTableRow();
        headerTable.Rows.Add(headerRow);

        var detailTable = new XRTable
        {
            LocationF = new DevExpress.Utils.PointFloat(0f, 0f),
            WidthF = totalWidth,
            HeightF = 24f,
            Borders = BorderSide.All
        };
        var detailRow = new XRTableRow();
        detailTable.Rows.Add(detailRow);

        foreach (DataColumn column in matrix.Columns)
        {
            float width = column.ColumnName == "MAHH" ? maHHWidth : vatTuWidth;
            var headerCell = new XRTableCell
            {
                Text = column.ColumnName,
                WidthF = width,
                Font = new Font("Arial", 8f, FontStyle.Bold),
                TextAlignment = TextAlignment.MiddleCenter,
                Padding = new PaddingInfo(3, 3, 2, 2)
            };
            headerRow.Cells.Add(headerCell);

            var detailCell = new XRTableCell
            {
                WidthF = width,
                Font = new Font("Arial", 8f),
                Padding = new PaddingInfo(3, 3, 2, 2),
                TextAlignment = column.ColumnName == "MAHH" ? TextAlignment.MiddleLeft : TextAlignment.MiddleRight
            };

            if (column.ColumnName == "MAHH")
                detailCell.DataBindings.Add("Text", null, column.ColumnName);
            else
                detailCell.DataBindings.Add("Text", null, column.ColumnName, "{0:0.##########}");

            detailRow.Cells.Add(detailCell);
        }

        pageHeader.Controls.Add(headerTable);
        detail.Controls.Add(detailTable);
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        var matrix = ReportViewer1.Report.DataSource as DataTable;
        if (matrix == null) throw new Exception("Không tìm thấy dữ liệu ma trận BOM để xuất Excel.");

        // HSSF là định dạng XLS và giới hạn 256 cột. Cột đầu là MAHH.
        if (matrix.Columns.Count > 256)
            throw new Exception("Báo cáo có " + matrix.Columns.Count + " cột, vượt giới hạn 256 cột của định dạng XLS hiện có. Cần dùng XLSX cho bộ dữ liệu này.");

        var workbook = new HSSFWorkbook();
        var sheet = workbook.CreateSheet("BOM HHVT");

        var headerFont = workbook.CreateFont();
        headerFont.Boldweight = (short)FontBoldWeight.Bold;

        var headerStyle = workbook.CreateCellStyle();
        headerStyle.SetFont(headerFont);
        headerStyle.Alignment = HorizontalAlignment.Center;
        headerStyle.VerticalAlignment = VerticalAlignment.Center;
        headerStyle.BorderBottom = BorderStyle.Thin;
        headerStyle.BorderTop = BorderStyle.Thin;
        headerStyle.BorderLeft = BorderStyle.Thin;
        headerStyle.BorderRight = BorderStyle.Thin;

        var textStyle = workbook.CreateCellStyle();
        textStyle.BorderBottom = BorderStyle.Thin;
        textStyle.BorderTop = BorderStyle.Thin;
        textStyle.BorderLeft = BorderStyle.Thin;
        textStyle.BorderRight = BorderStyle.Thin;

        var numberStyle = workbook.CreateCellStyle();
        numberStyle.Alignment = HorizontalAlignment.Right;
        numberStyle.BorderBottom = BorderStyle.Thin;
        numberStyle.BorderTop = BorderStyle.Thin;
        numberStyle.BorderLeft = BorderStyle.Thin;
        numberStyle.BorderRight = BorderStyle.Thin;
        numberStyle.DataFormat = workbook.CreateDataFormat().GetFormat("0.##########");

        var header = sheet.CreateRow(0);
        for (int c = 0; c < matrix.Columns.Count; c++)
        {
            var cell = header.CreateCell(c);
            cell.SetCellValue(matrix.Columns[c].ColumnName);
            cell.CellStyle = headerStyle;
        }

        for (int r = 0; r < matrix.Rows.Count; r++)
        {
            var excelRow = sheet.CreateRow(r + 1);
            for (int c = 0; c < matrix.Columns.Count; c++)
            {
                var cell = excelRow.CreateCell(c);
                if (c == 0)
                {
                    cell.SetCellValue(Convert.ToString(matrix.Rows[r][c]));
                    cell.CellStyle = textStyle;
                }
                else
                {
                    cell.SetCellValue(Convert.ToDouble(matrix.Rows[r][c]));
                    cell.CellStyle = numberStyle;
                }
            }
        }

        sheet.CreateFreezePane(1, 1);
        sheet.SetColumnWidth(0, 22 * 256);
        for (int c = 1; c < matrix.Columns.Count; c++) sheet.SetColumnWidth(c, 14 * 256);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename=BOM_HHVT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls");
        workbook.Write(Response.OutputStream);
        Response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    public String CreateSql(HttpContext context)
    {
        string khoValue = context.Request.QueryString["kho"].removeAllSpaceOrTrimText(true).Replace("'", "''");
        string maspValue = context.Request.QueryString["masp"].removeAllSpaceOrTrimText(true).Replace("'", "''");
        string kho = string.IsNullOrWhiteSpace(khoValue) ? "" : $@"and sp.khomacdinh = N'{khoValue}'";
        string masp = string.IsNullOrWhiteSpace(maspValue) ? "" : $@"and sp.ma_sanpham = N'{maspValue}'";
        var ngayin = DateTime.Now.ToString(Helper.fmtDate);

        string sql = $@"
SET NOCOUNT ON;
DROP TABLE IF EXISTS #HangReport;
DROP TABLE IF EXISTS #TPGroup;
DROP TABLE IF EXISTS #BTPGroup;
DROP TABLE IF EXISTS #TP_BTP;
DROP TABLE IF EXISTS #RootTP;
DROP TABLE IF EXISTS #BomMoiNhat;

SELECT x.md_sanpham_bom_id, x.md_sanpham_id, x.ten_phienban, x.ngay_hieuluc
INTO #BomMoiNhat
FROM (
    SELECT b.md_sanpham_bom_id, b.md_sanpham_id, b.ten_phienban, b.ngay_hieuluc,
        ROW_NUMBER() OVER (PARTITION BY b.md_sanpham_id ORDER BY b.ngay_hieuluc DESC, b.md_sanpham_bom_id DESC) AS rn
    FROM md_sanpham_bom b
    WHERE ISNULL(b.ten_phienban, '') <> ''
) x
WHERE x.rn = 1;
CREATE UNIQUE CLUSTERED INDEX IX_BomMoiNhat ON #BomMoiNhat(md_sanpham_id);

SELECT x.md_sanpham_id, x.ma_sanpham, ROW_NUMBER() OVER (ORDER BY x.ma_sanpham) AS root_order
INTO #RootTP
FROM (
    SELECT sp.md_sanpham_id, sp.ma_sanpham
    FROM md_sanpham sp
    INNER JOIN #BomMoiNhat bom ON bom.md_sanpham_id = sp.md_sanpham_id
    WHERE sp.sanpham = 1
        {kho}
        {masp}
        AND NOT EXISTS (
            SELECT 1
            FROM #BomMoiNhat parentBom
            INNER JOIN md_sanpham parent ON parent.md_sanpham_id = parentBom.md_sanpham_id
            INNER JOIN md_sanpham_bom_vattu parentItem ON parentItem.md_sanpham_bom_id = parentBom.md_sanpham_bom_id
            WHERE parentItem.md_sanpham_id = sp.md_sanpham_id
                AND parent.md_sanpham_id <> sp.md_sanpham_id
                AND parent.sanpham = 1
        )
) x;
CREATE UNIQUE CLUSTERED INDEX IX_RootTP ON #RootTP(md_sanpham_id);

SELECT tp.md_sanpham_id AS tp_id, tp.ma_sanpham AS ma_tp, tp.root_order,
    btp.md_sanpham_id AS btp_id, btp.ma_sanpham AS ma_btp
INTO #TP_BTP
FROM #RootTP tp
INNER JOIN #BomMoiNhat bom ON bom.md_sanpham_id = tp.md_sanpham_id
INNER JOIN md_sanpham_bom_vattu bvt ON bvt.md_sanpham_bom_id = bom.md_sanpham_bom_id
INNER JOIN md_sanpham btp ON btp.md_sanpham_id = bvt.md_sanpham_id
WHERE btp.ban_thanhpham = 1 AND ISNULL(btp.vattu, 0) = 0;

SELECT btp_id, ma_btp, MIN(root_order) AS group_order
INTO #BTPGroup FROM #TP_BTP GROUP BY btp_id, ma_btp;

SELECT x.tp_id, MIN(g.group_order) AS group_order
INTO #TPGroup
FROM #TP_BTP x INNER JOIN #BTPGroup g ON g.btp_id = x.btp_id
GROUP BY x.tp_id;

CREATE TABLE #HangReport
(
    md_sanpham_id NVARCHAR(32) NOT NULL,
    ma_sanpham NVARCHAR(255),
    group_order INT NOT NULL,
    sort_type INT NOT NULL,
    sort_order INT NOT NULL
);

INSERT INTO #HangReport (md_sanpham_id, ma_sanpham, group_order, sort_type, sort_order)
SELECT tp.md_sanpham_id, tp.ma_sanpham, ISNULL(g.group_order, tp.root_order), 0, tp.root_order
FROM #RootTP tp LEFT JOIN #TPGroup g ON g.tp_id = tp.md_sanpham_id;

INSERT INTO #HangReport (md_sanpham_id, ma_sanpham, group_order, sort_type, sort_order)
SELECT g.btp_id, g.ma_btp, g.group_order, 1, 999999 FROM #BTPGroup g;

;WITH BomTree AS
(
    SELECT hr.md_sanpham_id AS report_id, hr.ma_sanpham AS ma_goc,
        hr.group_order, hr.sort_type, hr.sort_order,
        child.md_sanpham_id AS child_id, child.ma_sanpham AS ma_con, child.mota_tiengviet,
        CAST(bvt.soluong AS DECIMAL(38,10)) AS sl_tich_luy,
        child.sanpham, child.ban_thanhpham, child.vattu,
        CAST(N'|' + hr.md_sanpham_id + N'|' + child.md_sanpham_id + N'|' AS NVARCHAR(MAX)) AS id_path
    FROM #HangReport hr
    INNER JOIN #BomMoiNhat bom ON bom.md_sanpham_id = hr.md_sanpham_id
    INNER JOIN md_sanpham_bom_vattu bvt ON bvt.md_sanpham_bom_id = bom.md_sanpham_bom_id
    INNER JOIN md_sanpham child ON child.md_sanpham_id = bvt.md_sanpham_id

    UNION ALL

    SELECT bt.report_id, bt.ma_goc, bt.group_order, bt.sort_type, bt.sort_order,
        child.md_sanpham_id, child.ma_sanpham, child.mota_tiengviet,
        CAST(bt.sl_tich_luy * bvt.soluong AS DECIMAL(38,10)),
        child.sanpham, child.ban_thanhpham, child.vattu,
        CAST(bt.id_path + child.md_sanpham_id + N'|' AS NVARCHAR(MAX))
    FROM BomTree bt
    INNER JOIN md_sanpham parent ON parent.md_sanpham_id = bt.child_id
    INNER JOIN #BomMoiNhat bom ON bom.md_sanpham_id = parent.md_sanpham_id
    INNER JOIN md_sanpham_bom_vattu bvt ON bvt.md_sanpham_bom_id = bom.md_sanpham_bom_id
    INNER JOIN md_sanpham child ON child.md_sanpham_id = bvt.md_sanpham_id
    WHERE parent.ban_thanhpham = 1 AND parent.vattu = 1
        AND CHARINDEX(N'|' + child.md_sanpham_id + N'|', bt.id_path) = 0
),
VatTuCuoi AS
(
    SELECT bt.*
    FROM BomTree bt
    LEFT JOIN #BomMoiNhat childBom ON childBom.md_sanpham_id = bt.child_id
    WHERE (bt.vattu = 1 AND ISNULL(bt.ban_thanhpham, 0) = 0)
       OR (bt.ban_thanhpham = 1 AND bt.vattu = 1 AND childBom.md_sanpham_bom_id IS NULL)
),
KetQua AS
(
    SELECT report_id, ma_goc, group_order, sort_type, sort_order,
        child_id AS vat_tu_id, ma_con AS ma_vattu,
        MAX(mota_tiengviet) AS ten_vattu,
        CAST(SUM(sl_tich_luy) AS DECIMAL(38,10)) AS soluong
    FROM VatTuCuoi
    GROUP BY report_id, ma_goc, group_order, sort_type, sort_order, child_id, ma_con
)
SELECT N'{ngayin}' AS ngayin,
    ma_goc AS maHH, ma_vattu AS maVT, ten_vattu AS tenVT, soluong AS sl,
    group_order, sort_type, sort_order
FROM KetQua
ORDER BY group_order, sort_type, sort_order, ma_goc, ma_vattu
OPTION (MAXRECURSION 100);
";
        return sql;
    }
}
