using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Xml;

public static class BomHhvtSpreadsheetMlExporter
{
    private const string SpreadsheetNs = "urn:schemas-microsoft-com:office:spreadsheet";
    private const string ExcelNs = "urn:schemas-microsoft-com:office:excel";

    public static void Export(HttpResponse response, DataTable matrix)
    {
        var output = new StringBuilder();
        var settings = new XmlWriterSettings
        {
            Encoding = Encoding.UTF8,
            Indent = false,
            OmitXmlDeclaration = false
        };

        using (var writer = XmlWriter.Create(output, settings))
        {
            writer.WriteStartDocument();
            writer.WriteProcessingInstruction("mso-application", "progid=\"Excel.Sheet\"");
            writer.WriteStartElement("Workbook", SpreadsheetNs);
            writer.WriteAttributeString("xmlns", "ss", null, SpreadsheetNs);
            writer.WriteAttributeString("xmlns", "x", null, ExcelNs);

            WriteStyles(writer);

            writer.WriteStartElement("Worksheet", SpreadsheetNs);
            writer.WriteAttributeString("ss", "Name", SpreadsheetNs, "BOM HHVT");
            WriteTable(writer, matrix);
            WriteFrozenPanes(writer);
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
        }

        response.Clear();
        response.Buffer = true;
        response.Charset = "utf-8";
        response.ContentEncoding = Encoding.UTF8;
        response.ContentType = "application/vnd.ms-excel";
        response.AddHeader("Content-Disposition", "attachment; filename=BOM_HHVT_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xml");
        response.Write(output.ToString());
        response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    private static void WriteStyles(XmlWriter writer)
    {
        writer.WriteStartElement("Styles", SpreadsheetNs);
        WriteStyle(writer, "Header", true, "Center", "General");
        WriteStyle(writer, "Text", false, "Left", "General");
        WriteStyle(writer, "Number", false, "Right", "0.##########");
        writer.WriteEndElement();
    }

    private static void WriteStyle(XmlWriter writer, string id, bool bold, string horizontal, string numberFormat)
    {
        writer.WriteStartElement("Style", SpreadsheetNs);
        writer.WriteAttributeString("ss", "ID", SpreadsheetNs, id);

        writer.WriteStartElement("Alignment", SpreadsheetNs);
        writer.WriteAttributeString("ss", "Horizontal", SpreadsheetNs, horizontal);
        writer.WriteAttributeString("ss", "Vertical", SpreadsheetNs, "Center");
        writer.WriteEndElement();

        writer.WriteStartElement("Font", SpreadsheetNs);
        if (bold) writer.WriteAttributeString("ss", "Bold", SpreadsheetNs, "1");
        writer.WriteEndElement();

        writer.WriteStartElement("NumberFormat", SpreadsheetNs);
        writer.WriteAttributeString("ss", "Format", SpreadsheetNs, numberFormat);
        writer.WriteEndElement();
        writer.WriteEndElement();
    }

    private static void WriteTable(XmlWriter writer, DataTable matrix)
    {
        writer.WriteStartElement("Table", SpreadsheetNs);
        writer.WriteAttributeString("ss", "ExpandedColumnCount", SpreadsheetNs, matrix.Columns.Count.ToString(CultureInfo.InvariantCulture));
        writer.WriteAttributeString("ss", "ExpandedRowCount", SpreadsheetNs, (matrix.Rows.Count + 1).ToString(CultureInfo.InvariantCulture));

        for (int c = 0; c < matrix.Columns.Count; c++)
        {
            writer.WriteStartElement("Column", SpreadsheetNs);
            writer.WriteAttributeString("ss", "Width", SpreadsheetNs, c == 0 ? "120" : "72");
            writer.WriteEndElement();
        }

        writer.WriteStartElement("Row", SpreadsheetNs);
        foreach (DataColumn column in matrix.Columns)
            WriteCell(writer, "Header", "String", column.ColumnName);
        writer.WriteEndElement();

        foreach (DataRow row in matrix.Rows)
        {
            writer.WriteStartElement("Row", SpreadsheetNs);
            WriteCell(writer, "Text", "String", Convert.ToString(row[0]));
            for (int c = 1; c < matrix.Columns.Count; c++)
            {
                decimal value = row.IsNull(c) ? 0m : Convert.ToDecimal(row[c]);
                WriteCell(writer, "Number", "Number", value.ToString(CultureInfo.InvariantCulture));
            }
            writer.WriteEndElement();
        }

        writer.WriteEndElement();
    }

    private static void WriteCell(XmlWriter writer, string styleId, string type, string value)
    {
        writer.WriteStartElement("Cell", SpreadsheetNs);
        writer.WriteAttributeString("ss", "StyleID", SpreadsheetNs, styleId);
        writer.WriteStartElement("Data", SpreadsheetNs);
        writer.WriteAttributeString("ss", "Type", SpreadsheetNs, type);
        writer.WriteString(value ?? string.Empty);
        writer.WriteEndElement();
        writer.WriteEndElement();
    }

    private static void WriteFrozenPanes(XmlWriter writer)
    {
        writer.WriteStartElement("WorksheetOptions", ExcelNs);
        writer.WriteStartElement("FreezePanes", ExcelNs); writer.WriteEndElement();
        writer.WriteStartElement("FrozenNoSplit", ExcelNs); writer.WriteEndElement();
        writer.WriteElementString("SplitHorizontal", ExcelNs, "1");
        writer.WriteElementString("TopRowBottomPane", ExcelNs, "1");
        writer.WriteElementString("SplitVertical", ExcelNs, "1");
        writer.WriteElementString("LeftColumnRightPane", ExcelNs, "1");
        writer.WriteElementString("ActivePane", ExcelNs, "0");
        writer.WriteEndElement();
    }
}
