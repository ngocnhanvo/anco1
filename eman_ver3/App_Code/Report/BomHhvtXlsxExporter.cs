using System;
using System.Data;
using System.IO;
using System.Web;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

public static class BomHhvtXlsxExporter
{
    public static void Export(HttpResponse response, DataTable matrix)
    {
        var workbook = new XSSFWorkbook();
        var sheet = workbook.CreateSheet("BOM HHVT");

        ICellStyle headerStyle = CreateHeaderStyle(workbook);
        ICellStyle textStyle = CreateTextStyle(workbook);
        ICellStyle numberStyle = CreateNumberStyle(workbook);

        IRow header = sheet.CreateRow(0);
        for (int c = 0; c < matrix.Columns.Count; c++)
        {
            ICell cell = header.CreateCell(c, CellType.String);
            cell.SetCellValue(matrix.Columns[c].ColumnName);
            cell.CellStyle = headerStyle;
        }

        for (int r = 0; r < matrix.Rows.Count; r++)
        {
            DataRow sourceRow = matrix.Rows[r];
            IRow row = sheet.CreateRow(r + 1);

            ICell codeCell = row.CreateCell(0, CellType.String);
            codeCell.SetCellValue(Convert.ToString(sourceRow[0]));
            codeCell.CellStyle = textStyle;

            for (int c = 1; c < matrix.Columns.Count; c++)
            {
                ICell cell = row.CreateCell(c, CellType.Numeric);
                cell.SetCellValue(sourceRow.IsNull(c) ? 0d : Convert.ToDouble(sourceRow[c]));
                cell.CellStyle = numberStyle;
            }
        }

        // Freeze dong tieu de va cot MAHH. Vung cuon bat dau tu B2.
        sheet.CreateFreezePane(1, 1);
        sheet.SetColumnWidth(0, 22 * 256);
        for (int c = 1; c < matrix.Columns.Count; c++)
            sheet.SetColumnWidth(c, 14 * 256);

        string fileName = "BOM_HHVT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
        response.Clear();
        response.Buffer = true;
        response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

        using (var stream = new MemoryStream())
        {
            workbook.Write(stream);
            byte[] bytes = stream.ToArray();
            response.OutputStream.Write(bytes, 0, bytes.Length);
        }

        response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    private static ICellStyle CreateHeaderStyle(XSSFWorkbook workbook)
    {
        ICellStyle style = workbook.CreateCellStyle();
        style.Alignment = HorizontalAlignment.Center;
        style.VerticalAlignment = VerticalAlignment.Center;
        style.BorderTop = BorderStyle.Thin;
        style.BorderBottom = BorderStyle.Thin;
        style.BorderLeft = BorderStyle.Thin;
        style.BorderRight = BorderStyle.Thin;

        IFont font = workbook.CreateFont();
        font.Boldweight = (short)FontBoldWeight.Bold;
        style.SetFont(font);
        return style;
    }

    private static ICellStyle CreateTextStyle(XSSFWorkbook workbook)
    {
        ICellStyle style = workbook.CreateCellStyle();
        style.Alignment = HorizontalAlignment.Left;
        style.VerticalAlignment = VerticalAlignment.Center;
        style.BorderTop = BorderStyle.Thin;
        style.BorderBottom = BorderStyle.Thin;
        style.BorderLeft = BorderStyle.Thin;
        style.BorderRight = BorderStyle.Thin;
        return style;
    }

    private static ICellStyle CreateNumberStyle(XSSFWorkbook workbook)
    {
        ICellStyle style = workbook.CreateCellStyle();
        style.Alignment = HorizontalAlignment.Right;
        style.VerticalAlignment = VerticalAlignment.Center;
        style.BorderTop = BorderStyle.Thin;
        style.BorderBottom = BorderStyle.Thin;
        style.BorderLeft = BorderStyle.Thin;
        style.BorderRight = BorderStyle.Thin;
        style.DataFormat = workbook.CreateDataFormat().GetFormat("0.##########");
        return style;
    }
}
