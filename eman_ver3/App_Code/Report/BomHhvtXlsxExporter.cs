using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using ICSharpCode.SharpZipLib.Zip;

public static class BomHhvtXlsxExporter
{
    private const string MainNs = "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
    private const string RelNs = "http://schemas.openxmlformats.org/officeDocument/2006/relationships";
    private const int FixedColumnCount = 4;
    private const int HeaderRowCount = 4;

    public static void Export(HttpResponse response, DataTable matrix)
    {
        if (matrix == null) throw new ArgumentNullException("matrix");
        if (matrix.Columns.Count > 16384)
            throw new InvalidOperationException("Excel XLSX chi ho tro toi da 16,384 cot.");
        if (matrix.Rows.Count + HeaderRowCount > 1048576)
            throw new InvalidOperationException("Excel XLSX chi ho tro toi da 1,048,576 dong.");

        byte[] xlsxBytes = BuildPackage(matrix);
        string fileName = "BOM_HHVT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

        response.Clear();
        response.Buffer = true;
        response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        response.OutputStream.Write(xlsxBytes, 0, xlsxBytes.Length);
        response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    private static byte[] BuildPackage(DataTable matrix)
    {
        using (var output = new MemoryStream())
        {
            using (var zip = new ZipOutputStream(output))
            {
                zip.UseZip64 = UseZip64.Off;
                zip.SetLevel(6);

                WriteEntry(zip, "[Content_Types].xml", BuildContentTypes());
                WriteEntry(zip, "_rels/.rels", BuildRootRelationships());
                WriteEntry(zip, "xl/workbook.xml", BuildWorkbook());
                WriteEntry(zip, "xl/_rels/workbook.xml.rels", BuildWorkbookRelationships());
                WriteEntry(zip, "xl/styles.xml", BuildStyles());
                WriteEntry(zip, "xl/worksheets/sheet1.xml", BuildSheet(matrix));

                zip.Finish();
            }
            return output.ToArray();
        }
    }

    private static void WriteEntry(ZipOutputStream zip, string name, byte[] data)
    {
        var entry = new ZipEntry(name);
        entry.DateTime = DateTime.Now;
        zip.PutNextEntry(entry);
        zip.Write(data, 0, data.Length);
        zip.CloseEntry();
    }

    private static byte[] BuildContentTypes()
    {
        return Utf8(
            "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
            "<Types xmlns=\"http://schemas.openxmlformats.org/package/2006/content-types\">" +
            "<Default Extension=\"rels\" ContentType=\"application/vnd.openxmlformats-package.relationships+xml\"/>" +
            "<Default Extension=\"xml\" ContentType=\"application/xml\"/>" +
            "<Override PartName=\"/xl/workbook.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml\"/>" +
            "<Override PartName=\"/xl/styles.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml\"/>" +
            "<Override PartName=\"/xl/worksheets/sheet1.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml\"/>" +
            "</Types>");
    }

    private static byte[] BuildRootRelationships()
    {
        return Utf8(
            "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
            "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
            "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument\" Target=\"xl/workbook.xml\"/>" +
            "</Relationships>");
    }

    private static byte[] BuildWorkbook()
    {
        return Utf8(
            "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
            "<workbook xmlns=\"" + MainNs + "\" xmlns:r=\"" + RelNs + "\">" +
            "<sheets><sheet name=\"BOM HHVT\" sheetId=\"1\" r:id=\"rId1\"/></sheets>" +
            "</workbook>");
    }

    private static byte[] BuildWorkbookRelationships()
    {
        return Utf8(
            "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
            "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">" +
            "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet\" Target=\"worksheets/sheet1.xml\"/>" +
            "<Relationship Id=\"rId2\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles\" Target=\"styles.xml\"/>" +
            "</Relationships>");
    }

    private static byte[] BuildStyles()
    {
        return Utf8(
            "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
            "<styleSheet xmlns=\"" + MainNs + "\">" +
            "<numFmts count=\"1\"><numFmt numFmtId=\"164\" formatCode=\"0.##########\"/></numFmts>" +
            "<fonts count=\"2\">" +
                "<font><sz val=\"11\"/><name val=\"Calibri\"/><family val=\"2\"/><scheme val=\"minor\"/></font>" +
                "<font><b/><sz val=\"11\"/><name val=\"Calibri\"/><family val=\"2\"/><scheme val=\"minor\"/></font>" +
            "</fonts>" +
            "<fills count=\"2\"><fill><patternFill patternType=\"none\"/></fill><fill><patternFill patternType=\"gray125\"/></fill></fills>" +
            "<borders count=\"2\">" +
                "<border><left/><right/><top/><bottom/><diagonal/></border>" +
                "<border><left style=\"thin\"/><right style=\"thin\"/><top style=\"thin\"/><bottom style=\"thin\"/><diagonal/></border>" +
            "</borders>" +
            "<cellStyleXfs count=\"1\"><xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\"/></cellStyleXfs>" +
            "<cellXfs count=\"4\">" +
                "<xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\" xfId=\"0\"/>" +
                "<xf numFmtId=\"0\" fontId=\"1\" fillId=\"0\" borderId=\"1\" xfId=\"0\" applyFont=\"1\" applyBorder=\"1\" applyAlignment=\"1\"><alignment horizontal=\"center\" vertical=\"center\"/></xf>" +
                "<xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"1\" xfId=\"0\" applyBorder=\"1\" applyAlignment=\"1\"><alignment horizontal=\"left\" vertical=\"center\"/></xf>" +
                "<xf numFmtId=\"164\" fontId=\"0\" fillId=\"0\" borderId=\"1\" xfId=\"0\" applyNumberFormat=\"1\" applyBorder=\"1\" applyAlignment=\"1\"><alignment horizontal=\"right\" vertical=\"center\"/></xf>" +
            "</cellXfs>" +
            "<cellStyles count=\"1\"><cellStyle name=\"Normal\" xfId=\"0\" builtinId=\"0\"/></cellStyles>" +
            "</styleSheet>");
    }

    private static byte[] BuildSheet(DataTable matrix)
    {
        var settings = new XmlWriterSettings
        {
            Encoding = new UTF8Encoding(false),
            Indent = false,
            OmitXmlDeclaration = false
        };

        using (var stream = new MemoryStream())
        using (var writer = XmlWriter.Create(stream, settings))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("worksheet", MainNs);

            int lastRow = matrix.Rows.Count + HeaderRowCount;
            writer.WriteStartElement("dimension", MainNs);
            writer.WriteAttributeString("ref", "A1:" + ToExcelColumnName(matrix.Columns.Count) + lastRow);
            writer.WriteEndElement();

            writer.WriteStartElement("sheetViews", MainNs);
            writer.WriteStartElement("sheetView", MainNs);
            writer.WriteAttributeString("workbookViewId", "0");
            writer.WriteStartElement("pane", MainNs);
            writer.WriteAttributeString("xSplit", FixedColumnCount.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("ySplit", HeaderRowCount.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("topLeftCell", "E5");
            writer.WriteAttributeString("activePane", "bottomRight");
            writer.WriteAttributeString("state", "frozen");
            writer.WriteEndElement();
            writer.WriteStartElement("selection", MainNs);
            writer.WriteAttributeString("pane", "bottomRight");
            writer.WriteAttributeString("activeCell", "E5");
            writer.WriteAttributeString("sqref", "E5");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteStartElement("sheetFormatPr", MainNs);
            writer.WriteAttributeString("defaultRowHeight", "15");
            writer.WriteEndElement();

            writer.WriteStartElement("cols", MainNs);
            for (int c = 0; c < matrix.Columns.Count; c++)
            {
                writer.WriteStartElement("col", MainNs);
                string index = (c + 1).ToString(CultureInfo.InvariantCulture);
                writer.WriteAttributeString("min", index);
                writer.WriteAttributeString("max", index);
                writer.WriteAttributeString("width", GetColumnWidth(c));
                writer.WriteAttributeString("customWidth", "1");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement("sheetData", MainNs);
            WriteMaterialHeaderRow(writer, matrix, 1, "M\u00c3 VT", "MaVT");
            WriteMaterialHeaderRow(writer, matrix, 2, "T\u00caN VT", "TenVT");
            WriteMaterialHeaderRow(writer, matrix, 3, "\u0110VT", "DvtVT");
            WriteItemHeaderRow(writer, matrix);
            for (int r = 0; r < matrix.Rows.Count; r++)
                WriteDataRow(writer, matrix, matrix.Rows[r], r + HeaderRowCount + 1);
            writer.WriteEndElement();

            writer.WriteStartElement("pageMargins", MainNs);
            writer.WriteAttributeString("left", "0.7");
            writer.WriteAttributeString("right", "0.7");
            writer.WriteAttributeString("top", "0.75");
            writer.WriteAttributeString("bottom", "0.75");
            writer.WriteAttributeString("header", "0.3");
            writer.WriteAttributeString("footer", "0.3");
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return stream.ToArray();
        }
    }

    private static string GetColumnWidth(int columnIndex)
    {
        if (columnIndex == 0) return "22";
        if (columnIndex == 1) return "36";
        if (columnIndex == 2) return "12";
        if (columnIndex == 3) return "16";
        return "14";
    }

    private static void WriteMaterialHeaderRow(XmlWriter writer, DataTable matrix, int rowNumber, string label, string propertyName)
    {
        writer.WriteStartElement("row", MainNs);
        writer.WriteAttributeString("r", rowNumber.ToString(CultureInfo.InvariantCulture));

        WriteInlineStringCell(writer, "D" + rowNumber, 1, label);
        for (int c = FixedColumnCount; c < matrix.Columns.Count; c++)
        {
            string value = GetColumnProperty(matrix.Columns[c], propertyName);
            WriteInlineStringCell(writer, ToExcelColumnName(c + 1) + rowNumber, 1, value);
        }

        writer.WriteEndElement();
    }

    private static void WriteItemHeaderRow(XmlWriter writer, DataTable matrix)
    {
        const int rowNumber = 4;
        writer.WriteStartElement("row", MainNs);
        writer.WriteAttributeString("r", rowNumber.ToString(CultureInfo.InvariantCulture));

        for (int c = 0; c < FixedColumnCount && c < matrix.Columns.Count; c++)
            WriteInlineStringCell(writer, ToExcelColumnName(c + 1) + rowNumber, 1, matrix.Columns[c].ColumnName);

        for (int c = FixedColumnCount; c < matrix.Columns.Count; c++)
            WriteBlankCell(writer, ToExcelColumnName(c + 1) + rowNumber, 1);

        writer.WriteEndElement();
    }

    private static void WriteDataRow(XmlWriter writer, DataTable matrix, DataRow row, int rowNumber)
    {
        writer.WriteStartElement("row", MainNs);
        writer.WriteAttributeString("r", rowNumber.ToString(CultureInfo.InvariantCulture));

        WriteInlineStringCell(writer, "A" + rowNumber, 2, Convert.ToString(row[0]));
        WriteInlineStringCell(writer, "B" + rowNumber, 2, Convert.ToString(row[1]));
        WriteInlineStringCell(writer, "C" + rowNumber, 2, Convert.ToString(row[2]));

        if (row.IsNull(3))
            WriteBlankCell(writer, "D" + rowNumber, 3);
        else
            WriteNumberCell(writer, "D" + rowNumber, 3, Convert.ToDecimal(row[3]));

        for (int c = FixedColumnCount; c < matrix.Columns.Count; c++)
        {
            decimal value = row.IsNull(c) ? 0m : Convert.ToDecimal(row[c]);
            WriteNumberCell(writer, ToExcelColumnName(c + 1) + rowNumber, 3, value);
        }

        writer.WriteEndElement();
    }

    private static string GetColumnProperty(DataColumn column, string key)
    {
        object value = column.ExtendedProperties[key];
        return value == null ? string.Empty : Convert.ToString(value);
    }

    private static void WriteInlineStringCell(XmlWriter writer, string reference, int styleIndex, string value)
    {
        writer.WriteStartElement("c", MainNs);
        writer.WriteAttributeString("r", reference);
        writer.WriteAttributeString("s", styleIndex.ToString(CultureInfo.InvariantCulture));
        writer.WriteAttributeString("t", "inlineStr");
        writer.WriteStartElement("is", MainNs);
        writer.WriteStartElement("t", MainNs);
        writer.WriteAttributeString("xml", "space", "http://www.w3.org/XML/1998/namespace", "preserve");
        writer.WriteString(value ?? string.Empty);
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndElement();
    }

    private static void WriteNumberCell(XmlWriter writer, string reference, int styleIndex, decimal value)
    {
        writer.WriteStartElement("c", MainNs);
        writer.WriteAttributeString("r", reference);
        writer.WriteAttributeString("s", styleIndex.ToString(CultureInfo.InvariantCulture));
        writer.WriteStartElement("v", MainNs);
        writer.WriteString(value.ToString("0.##########", CultureInfo.InvariantCulture));
        writer.WriteEndElement();
        writer.WriteEndElement();
    }

    private static void WriteBlankCell(XmlWriter writer, string reference, int styleIndex)
    {
        writer.WriteStartElement("c", MainNs);
        writer.WriteAttributeString("r", reference);
        writer.WriteAttributeString("s", styleIndex.ToString(CultureInfo.InvariantCulture));
        writer.WriteEndElement();
    }

    private static byte[] Utf8(string text)
    {
        return new UTF8Encoding(false).GetBytes(text);
    }

    private static string ToExcelColumnName(int columnNumber)
    {
        int value = columnNumber;
        string result = string.Empty;
        while (value > 0)
        {
            value--;
            result = (char)('A' + (value % 26)) + result;
            value /= 26;
        }
        return result;
    }
}
