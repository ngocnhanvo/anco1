using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Web;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;
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

        FixLegacyXssfDimension((XSSFSheet)sheet, matrix.Rows.Count + 1, matrix.Columns.Count);

        string fileName = "BOM_HHVT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
        response.Clear();
        response.Buffer = true;
        response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);

        byte[] npoiBytes;
        using (var stream = new MemoryStream())
        {
            workbook.Write(stream);
            npoiBytes = stream.ToArray();
        }

        // NPOI 2.0.6 sinh package XLSX cu co 2 van de:
        // 1) ZIP64 cho workbook rat nho.
        // 2) docProps/custom.xml co namespace khong hop le voi Excel hien tai.
        // Dong goi lai ZIP thuong va bo custom properties do NPOI tu sinh.
        byte[] xlsxBytes = RewriteLegacyPackage(npoiBytes);
        response.OutputStream.Write(xlsxBytes, 0, xlsxBytes.Length);
        response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    private static byte[] RewriteLegacyPackage(byte[] source)
    {
        using (var input = new MemoryStream(source))
        using (var zipInput = new ZipInputStream(input))
        using (var output = new MemoryStream())
        {
            using (var zipOutput = new ZipOutputStream(output))
            {
                zipOutput.UseZip64 = UseZip64.Off;
                zipOutput.SetLevel(6);

                ZipEntry entry;
                while ((entry = zipInput.GetNextEntry()) != null)
                {
                    // NPOI 2.0.6 tu them Generator/Generator Version vao custom.xml,
                    // nhung XML nay lam Excel bao file-level validation/repair.
                    if (string.Equals(entry.Name, "docProps/custom.xml", StringComparison.OrdinalIgnoreCase))
                        continue;

                    byte[] entryBytes = ReadCurrentZipEntry(zipInput);
                    if (string.Equals(entry.Name, "_rels/.rels", StringComparison.OrdinalIgnoreCase))
                        entryBytes = RemoveCustomPropertiesRelationship(entryBytes);
                    else if (string.Equals(entry.Name, "[Content_Types].xml", StringComparison.OrdinalIgnoreCase))
                        entryBytes = RemoveCustomPropertiesContentType(entryBytes);

                    var newEntry = new ZipEntry(entry.Name);
                    if (entry.DateTime.Year >= 1980)
                        newEntry.DateTime = entry.DateTime;

                    zipOutput.PutNextEntry(newEntry);
                    zipOutput.Write(entryBytes, 0, entryBytes.Length);
                    zipOutput.CloseEntry();
                }

                zipOutput.Finish();
            }
            return output.ToArray();
        }
    }

    private static byte[] ReadCurrentZipEntry(ZipInputStream zipInput)
    {
        using (var data = new MemoryStream())
        {
            byte[] buffer = new byte[8192];
            int read;
            while ((read = zipInput.Read(buffer, 0, buffer.Length)) > 0)
                data.Write(buffer, 0, read);
            return data.ToArray();
        }
    }

    private static byte[] RemoveCustomPropertiesRelationship(byte[] xmlBytes)
    {
        var doc = LoadXml(xmlBytes);
        XmlNode root = doc.DocumentElement;
        if (root != null)
        {
            for (int i = root.ChildNodes.Count - 1; i >= 0; i--)
            {
                XmlNode node = root.ChildNodes[i];
                XmlAttribute type = node.Attributes == null ? null : node.Attributes["Type"];
                if (type != null && type.Value.EndsWith("/custom-properties", StringComparison.OrdinalIgnoreCase))
                    root.RemoveChild(node);
            }
        }
        return SaveXml(doc);
    }

    private static byte[] RemoveCustomPropertiesContentType(byte[] xmlBytes)
    {
        var doc = LoadXml(xmlBytes);
        XmlNode root = doc.DocumentElement;
        if (root != null)
        {
            for (int i = root.ChildNodes.Count - 1; i >= 0; i--)
            {
                XmlNode node = root.ChildNodes[i];
                XmlAttribute partName = node.Attributes == null ? null : node.Attributes["PartName"];
                if (partName != null && string.Equals(partName.Value, "/docProps/custom.xml", StringComparison.OrdinalIgnoreCase))
                    root.RemoveChild(node);
            }
        }
        return SaveXml(doc);
    }

    private static XmlDocument LoadXml(byte[] bytes)
    {
        var doc = new XmlDocument();
        doc.PreserveWhitespace = false;
        using (var stream = new MemoryStream(bytes))
            doc.Load(stream);
        return doc;
    }

    private static byte[] SaveXml(XmlDocument doc)
    {
        using (var stream = new MemoryStream())
        {
            var settings = new XmlWriterSettings
            {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = false,
                OmitXmlDeclaration = false
            };
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
                doc.Save(writer);
            return stream.ToArray();
        }
    }

    private static void FixLegacyXssfDimension(XSSFSheet sheet, int rowCount, int columnCount)
    {
        if (rowCount <= 0 || columnCount <= 0) return;
        try
        {
            MethodInfo getCtWorksheet = typeof(XSSFSheet).GetMethod("GetCTWorksheet", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            if (getCtWorksheet == null) return;
            object worksheet = getCtWorksheet.Invoke(sheet, null);
            if (worksheet == null) return;
            object dimension = GetMemberValue(worksheet, "dimension");
            if (dimension == null) return;
            SetMemberValue(dimension, "ref", "A1:" + ToExcelColumnName(columnCount) + rowCount);
        }
        catch { }
    }

    private static object GetMemberValue(object target, string name)
    {
        Type type = target.GetType();
        PropertyInfo property = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (property != null) return property.GetValue(target, null);
        FieldInfo field = type.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        return field == null ? null : field.GetValue(target);
    }

    private static void SetMemberValue(object target, string name, object value)
    {
        Type type = target.GetType();
        PropertyInfo property = type.GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (property != null && property.CanWrite) { property.SetValue(target, value, null); return; }
        FieldInfo field = type.GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        if (field != null) field.SetValue(target, value);
    }

    private static string ToExcelColumnName(int columnCount)
    {
        int value = columnCount;
        string result = string.Empty;
        while (value > 0) { value--; result = (char)('A' + (value % 26)) + result; value /= 26; }
        return result;
    }

    private static ICellStyle CreateHeaderStyle(XSSFWorkbook workbook)
    {
        ICellStyle style = workbook.CreateCellStyle();
        style.Alignment = HorizontalAlignment.Center;
        style.VerticalAlignment = VerticalAlignment.Center;
        style.BorderTop = BorderStyle.Thin; style.BorderBottom = BorderStyle.Thin;
        style.BorderLeft = BorderStyle.Thin; style.BorderRight = BorderStyle.Thin;
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
        style.BorderTop = BorderStyle.Thin; style.BorderBottom = BorderStyle.Thin;
        style.BorderLeft = BorderStyle.Thin; style.BorderRight = BorderStyle.Thin;
        return style;
    }

    private static ICellStyle CreateNumberStyle(XSSFWorkbook workbook)
    {
        ICellStyle style = workbook.CreateCellStyle();
        style.Alignment = HorizontalAlignment.Right;
        style.VerticalAlignment = VerticalAlignment.Center;
        style.BorderTop = BorderStyle.Thin; style.BorderBottom = BorderStyle.Thin;
        style.BorderLeft = BorderStyle.Thin; style.BorderRight = BorderStyle.Thin;
        style.DataFormat = workbook.CreateDataFormat().GetFormat("0.##########");
        return style;
    }
}
