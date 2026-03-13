
using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;

namespace OfficeToPDF
{
    /// <summary>
    /// Handle conversion of Excel files
    /// </summary>
    /// 

    public class ExcelConverter : Converter, IDisposable
    {
        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.SuppressFinalize(this);
        }

        public class WebClientWithTimeout : System.Net.WebClient
        {
            public int Timeout { get; set; } = 5000; // mặc định 5 giây
            protected override System.Net.WebRequest GetWebRequest(Uri uri)
            {
                var request = base.GetWebRequest(uri);
                request.Timeout = Timeout;
                return request;
            }
        }

        public List<AvariablePrj.lstImage> lstImage { get; set; }
        public List<AvariablePrj.lstText> lstText { get; set; }
        public List<AvariablePrj.lstTextReplace> lstTextReplace { get; set; }
        public List<AvariablePrj.lstFormula> lstFormula { get; set; }
        public List<int> lstAutoSizeColumn { get; set; }
        public List<int> lstBlankRow { get; set; }
        public int? endRow { get; set; }
        public int? endColumn { get; set; }
        public float? sizeAddPDF { get; set; }
        public bool? landScape { get; set; }
        public string nameApp { get; set; }
        public ExcelConverter()
        {

        }

        public void resetEndRowAndClumn()
        {
            endRow = endRow.GetValueOrDefault(0) + 1;
            endColumn = endColumn.GetValueOrDefault(0) + 1;
        }

        // These are the properties we will extract from the first worksheet of any template document
        private static string[] templateProperties =
        {
            "BlackAndWhite", "BottomMargin", "CenterFooter", "CenterHeader",
            "CenterHorizontally", "CenterVertically", "DifferentFirstPageHeaderFooter",
            "Draft", "FirstPageNumber", "FitToPagesTall", "FitToPagesWide",
            "FooterMargin", "HeaderMargin", "LeftFooter", "LeftHeader",
            "LeftMargin", "OddAndEvenPagesHeaderFooter", "Order", "Orientation", "PaperSize", "PrintArea",
            "PrintGridlines", "PrintHeadings", "PrintNotes", "PrintTitleColumns", "PrintTitleRows",
            "RightFooter", "RightHeader", "RightMargin",
            "ScaleWithDocHeaderFooter", "TopMargin", "Zoom"
        };

        public string setSizePDF(string inputFile)
        {
            string msg = "";

            Application app = null;
            Workbooks workbooks = null;
            Workbook workbook = null;
            _Worksheet worksheet = null;

            Range excelCellrange = null;
            Characters chars = null;
            Font font = null;

            try
            {
                object oMissing = System.Reflection.Missing.Value;

                app = new Application();
                app.Caption = nameApp;
                app.DisplayAlerts = false;
                app.AskToUpdateLinks = false;
                app.AlertBeforeOverwriting = false;
                app.EnableLargeOperationAlert = false;
                app.Interactive = false;
                app.FeatureInstall = Microsoft.Office.Core.MsoFeatureInstall.msoFeatureInstallNone;
                app.WindowState = XlWindowState.xlMinimized;
                app.Visible = false;

                workbooks = app.Workbooks;

                workbook = workbooks.Open(
                    inputFile,
                    oMissing, false, oMissing, oMissing, oMissing,
                    true, oMissing, oMissing, oMissing, oMissing,
                    oMissing, false, oMissing, oMissing);

                worksheet = (_Worksheet)workbook.ActiveSheet;

                resetEndRowAndClumn();

                for (int i = 1; i <= endRow; i++)
                {
                    for (int j = 1; j <= endColumn; j++)
                    {
                        try
                        {
                            excelCellrange = (Range)worksheet.Cells[i, j];

                            string text = excelCellrange.Text?.ToString() ?? "";
                            int lengthText = text.Length;

                            for (int k = 1; k <= lengthText; k++)
                            {
                                try
                                {
                                    chars = excelCellrange.Characters[k, 1];
                                    font = chars.Font;

                                    float size = (float)font.Size;
                                    font.Size = size + sizeAddPDF;
                                }
                                finally
                                {
                                    ReleaseCOMObject(font);
                                    ReleaseCOMObject(chars);
                                    font = null;
                                    chars = null;
                                }
                            }
                        }
                        finally
                        {
                            ReleaseCOMObject(excelCellrange);
                            excelCellrange = null;
                        }
                    }
                }

                workbook.SaveAs(
                    inputFile,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing,
                    XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
            }
            catch (COMException ce)
            {
                msg = "COMException: " + ce;
            }
            catch (Exception e)
            {
                msg = "Exception: " + e;
            }
            finally
            {
                try
                {
                    if (workbook != null)
                    {
                        workbook.Saved = true;
                        CloseExcelWorkbook(workbook);
                        ReleaseCOMObject(workbook);
                        workbook = null;
                    }

                    if (workbooks != null)
                        workbooks.Close();

                    if (app != null)
                        app.Quit();
                }
                finally
                {
                    ReleaseCOMObject(font);
                    ReleaseCOMObject(chars);
                    ReleaseCOMObject(excelCellrange);

                    ReleaseCOMObject(worksheet);
                    ReleaseCOMObject(workbook);
                    ReleaseCOMObject(workbooks);
                    ReleaseCOMObject(app);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }

            return msg;
        }

        // Main conversion routine
        public string ConvertInterop(String inputFile, String outputFile, Hashtable options)
        {
            resetEndRowAndClumn();
            if (lstImage == null)
                lstImage = new List<AvariablePrj.lstImage>();

            if (lstText == null)
                lstText = new List<AvariablePrj.lstText>();

            if (lstTextReplace == null)
                lstTextReplace = new List<AvariablePrj.lstTextReplace>();

            if (lstAutoSizeColumn == null)
                lstAutoSizeColumn = new List<int>();

            if (lstBlankRow == null)
                lstBlankRow = new List<int>();

            var mimeTypeOutput = outputFile.Substring(outputFile.LastIndexOf(".") + 1);
            var msg = "";
            var source = new CancellationTokenSource();
            var token = source.Token;

            Application app = null;
            Workbooks workbooks = null;
            Workbook workbook = null;
            _Worksheet worksheet = null;
            Sheets allSheets = null;
            Window activeWindow = null;
            Windows wbWin = null;
            Object activeSheet = null;
            var task = new System.Threading.Tasks.Task(() =>
            {
                options = PDFBookmark.createOptions();
                Boolean running = false;

                Hashtable templatePageSetup = new Hashtable();

                String tmpFile = null;
                object oMissing = System.Reflection.Missing.Value;
                Boolean nowrite = false;
                try
                {
                    // Excel can be very slow to start up, so try to get the COM
                    // object a few times
                    int tries = 10;
                    app = new Application();

                    app.Caption = nameApp;
                    while (tries > 0)
                    {
                        try
                        {
                            // Try to set a property on the object
                            app.ScreenUpdating = false;
                        }
                        catch (COMException)
                        {
                            // Decrement the number of tries and have a bit of a snooze
                            tries--;
                            Thread.Sleep(500);
                            continue;
                        }
                        // Looks ok, so bail out of the loop
                        break;
                    }
                    if (tries == 0)
                    {
                        ReleaseCOMObject(app);
                        msg = Enum.GetName(typeof(ExitCode), ExitCode.ApplicationError);
                        source.Cancel();
                        throw new ArgumentException(msg);
                    }

                    //app.Visible = false;
                    app.DisplayAlerts = false;
                    app.AskToUpdateLinks = false;
                    app.AlertBeforeOverwriting = false;
                    app.EnableLargeOperationAlert = false;
                    //app.DisplayDocumentActionTaskPane = false;
                    app.Interactive = false;
                    //app.ScreenUpdating = false;
                    //app.CommandBars.ExecuteMso("HideRibbon");
                    app.FeatureInstall = Microsoft.Office.Core.MsoFeatureInstall.msoFeatureInstallNone;

                    var onlyActiveSheet = false;
                    Boolean activeSheetOnMaxRows = false;
                    Boolean includeProps = !false;
                    Boolean skipRecalculation = false;
                    Boolean showHeadings = false;
                    Boolean showFormulas = false;
                    Boolean isHidden = false;
                    Boolean screenQuality = false;
                    Boolean updateLinks = !false;
                    var passWord = "";
                    var writepassword = "";
                    var fallback_printer = "";
                    var printerO = "";
                    int maxRows = 0;
                    int worksheetNum = 0;
                    int sheetForConversionIdx = 0;
                    activeWindow = app.ActiveWindow;

                    var fmt = XlFileFormat.xlOpenXMLWorkbook;
                    var quality = XlFixedFormatQuality.xlQualityStandard;
                    if (isHidden)
                    {
                        // Try and at least minimise it
                        app.WindowState = XlWindowState.xlMinimized;
                        app.Visible = false;
                    }

                    String readPassword = "";
                    if (!String.IsNullOrEmpty(passWord))
                    {
                        readPassword = passWord;
                    }
                    Object oReadPass = (Object)readPassword;

                    String writePassword = "";
                    if (!String.IsNullOrEmpty(writepassword))
                    {
                        writePassword = writepassword;
                    }
                    Object oWritePass = (Object)writePassword;

                    // Check for password protection and no password
                    if (Converter.IsPasswordProtected(inputFile) && String.IsNullOrEmpty(readPassword))
                    {
                        Console.WriteLine("Unable to open password protected file");
                        msg = Enum.GetName(typeof(ExitCode), ExitCode.PasswordFailure);
                        source.Cancel();
                        throw new ArgumentException(msg);
                    }

                    app.EnableEvents = false;
                    workbooks = app.Workbooks;
                    // If we have no write password and we're attempting to open for writing, we might be
                    // caught out by an unexpected write password
                    var timeStart = DateTime.Now;
                    if (writePassword == "" && !nowrite)
                    {
                        oWritePass = (Object)"FAKEPASSWORD";
                        try
                        {
                            workbook = workbooks.Open(inputFile, updateLinks, nowrite, oMissing, oReadPass, oWritePass, true, oMissing, oMissing, oMissing, oMissing, oMissing, false, oMissing, oMissing);
                        }
                        catch (COMException)
                        {
                            // Attempt to open it in read-only mode
                            workbook = workbooks.Open(inputFile, updateLinks, true, oMissing, oReadPass, oWritePass, true, oMissing, oMissing, oMissing, oMissing, oMissing, false, oMissing, oMissing);
                        }
                    }
                    else
                    {
                        workbook = workbooks.Open(inputFile, updateLinks, nowrite, oMissing, oReadPass, oWritePass, true, oMissing, oMissing, oMissing, oMissing, oMissing, false, oMissing, oMissing);
                    }

                    // Add in a delay to let Excel sort itself out
                    AddCOMDelay(options);

                    // Unable to open workbook
                    if (workbook == null)
                    {
                        msg = Enum.GetName(typeof(ExitCode), ExitCode.FileOpenFailure);
                        throw new ArgumentException(msg);
                    }

                    if (app.EnableEvents)
                    {
                        workbook.RunAutoMacros(XlRunAutoMacro.xlAutoOpen);
                    }

                    // Get any template options
                    SetPageOptionsFromTemplate(app, workbooks, options, ref templatePageSetup);

                    // Get the sheets
                    allSheets = workbook.Sheets;
                    worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;

                    int countRPL = 50;
                    var lstColumnDels = new List<int>();
                    PageSetup ps = null;
                    Pages psP = null;
                    string psCount = "";
                    try
                    {
                        ps = worksheet.PageSetup;
                        psP = ps.Pages;
                        psCount = psP.Count.ToString();
                        ps.CenterHorizontally = true;
                        if (landScape.GetValueOrDefault(false))
                            ps.Orientation = XlPageOrientation.xlLandscape;
                    }
                    finally
                    {
                        ReleaseCOMObject(ps);
                        ReleaseCOMObject(psP);
                    }

                    if (lstTextReplace.Count > 0)
                    {
                        var cellsRep = worksheet.Cells;
                        try
                        {
                            foreach (var textReplace in lstTextReplace)
                            {
                                Range oRange = null;
                                Range oRangeWrap = null;
                                Range colRangeR = null;
                                Characters chars = null;
                                Range rows = null;
                                Font font = null;
                                try
                                {
                                    oRange = (Range)cellsRep[textReplace.row.Value + 1, textReplace.column.Value + 1];
                                    rows = oRange.Rows;
                                    font = oRange.Font;
                                    var cellValue = oRange.Value?.ToString() ?? "";
                                    int phStart = cellValue.LastIndexOf(textReplace.oldT);
                                    int phEnd = textReplace.oldT.Length;

                                    if (textReplace.newT == "{totalPage}")
                                        textReplace.newT = psCount;

                                    if (phStart > -1 & phEnd > -1)
                                    {
                                        if (textReplace.wrap_Mer.GetValueOrDefault(false))
                                        {
                                            oRange.Value = textReplace.newT;

                                            int cld = oRange.Column + countRPL;
                                            lstColumnDels.Add(cld);

                                            oRangeWrap = (Range)cellsRep[oRange.Row, cld];

                                            double columnWidth = 0;

                                            for (int i = oRange.Column; i < oRange.Column + textReplace.column_Mer; i++)
                                            {
                                                colRangeR = (Range)worksheet.Columns[i];
                                                columnWidth += (double)colRangeR.ColumnWidth;
                                                ReleaseCOMObject(colRangeR);
                                                colRangeR = null;
                                            }

                                            oRangeWrap.ColumnWidth = columnWidth;

                                            oRangeWrap.Font.Name = font.Name;
                                            oRangeWrap.Font.Size = font.Size;
                                            oRangeWrap.Orientation = oRange.Orientation;
                                            oRangeWrap.VerticalAlignment = oRange.VerticalAlignment;
                                            oRangeWrap.Font.Bold = font.Bold;
                                            oRangeWrap.Font.Italic = font.Italic;
                                            oRangeWrap.WrapText = oRange.WrapText;

                                            oRange.Copy(oRangeWrap);

                                            countRPL++;

                                            rows.AutoFit();
                                            var heightATF = rows.Height;
                                            oRange.RowHeight = Math.Ceiling(heightATF * 1.05);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                chars = oRange.Characters[phStart + 1, phEnd];
                                                chars.Insert(textReplace.newT);
                                            }
                                            catch (Exception ex)
                                            {
                                                chars = oRange.Characters[phStart + 1, phEnd];
                                                chars.Insert(ex.Message);
                                            }
                                        }
                                    }

                                    if (textReplace.oldT.StartsWith("{#"))
                                    {
                                        oRange.Value = textReplace.newT;
                                    }
                                }
                                catch
                                {
                                }
                                finally
                                {
                                    if (chars != null) ReleaseCOMObject(chars);
                                    if (oRangeWrap != null) ReleaseCOMObject(oRangeWrap);
                                    if (oRange != null) ReleaseCOMObject(oRange);
                                    if (rows != null) ReleaseCOMObject(rows);
                                    if (font != null) ReleaseCOMObject(font);
                                }
                            }
                        }
                        finally
                        {
                            ReleaseCOMObject(cellsRep);
                        }
                    }

                    Range rangeFm = null;
                    Range colRange = null;
                    foreach (var col in lstAutoSizeColumn)
                    {
                        try
                        {
                            rangeFm = (Range)worksheet.Cells[1, col + 1];
                            colRange = rangeFm.EntireColumn;

                            colRange.AutoFit();
                        }
                        catch (Exception ex)
                        {
                            string msg1 = ex.Message;
                        }
                        finally
                        {
                            if (colRange != null)
                            {
                                ReleaseCOMObject(colRange);
                                colRange = null;
                            }

                            if (rangeFm != null)
                            {
                                ReleaseCOMObject(rangeFm);
                                rangeFm = null;
                            }
                        }
                    }

                    //Range rowsATH = worksheet.Rows;
                    //Range rowRange = null;
                    //Range autoFitRange = null;

                    //var originalHeights = new Dictionary<int, double>();

                    //try
                    //{
                    //    // lưu height ban đầu
                    //    for (int i = 1; i <= endRow; i++)
                    //    {
                    //        rowRange = rowsATH[i];
                    //        originalHeights[i] = (double)rowRange.RowHeight;
                    //    }

                    //    // autofit
                    //    autoFitRange = rowsATH["1:" + endRow];
                    //    autoFitRange.AutoFit();

                    //    // kiểm tra height sau autofit
                    //    for (int i = 1; i <= endRow; i++)
                    //    {
                    //        rowRange = rowsATH[i];

                    //        if (lstBlankRow.Contains(i))
                    //        {
                    //            rowRange.RowHeight = originalHeights[i];
                    //        }
                    //        else
                    //        {
                    //            double newHeight = (double)rowRange.RowHeight;

                    //            if (newHeight < originalHeights[i])
                    //                rowRange.RowHeight = originalHeights[i];
                    //        }
                    //    }
                    //}
                    //finally
                    //{
                    //    if (autoFitRange != null) Marshal.ReleaseComObject(autoFitRange);
                    //    if (rowRange != null) Marshal.ReleaseComObject(rowRange);
                    //    Marshal.ReleaseComObject(rowsATH);
                    //}

                    colRange = null;
                    for (int i = lstColumnDels.Count - 1; i >= 0; i--)
                    {
                        try
                        {
                            var col = lstColumnDels[i];
                            colRange = (Range)worksheet.Columns[col];
                            colRange.Delete();
                        }
                        finally
                        {
                            if (colRange != null)
                            {
                                ReleaseCOMObject(colRange);
                                colRange = null;
                            }
                        }
                    }

                    if (lstText.Count > 0)
                    {
                        float widthBackUp = -1;
                        Shapes shapesRPL = worksheet.Shapes;
                        Range cellsRPL = worksheet.Cells;
                        try
                        {
                            foreach (var textInLine in lstText)
                            {
                                float leftTextPrev = -1, topTextPrev = 0, widthTextPrev = -1, heightTextPrev = 0;

                                if (textInLine.columnFPrev != null & textInLine.columnTPrev != null)
                                {
                                    string textRangePrev = "";
                                    var hasBoldPrev = false;
                                    double fontSizePrev = 12;
                                    string fontNamePrev = "Arial";

                                    for (var iCl = textInLine.columnFPrev; iCl <= textInLine.columnTPrev; iCl++)
                                    {
                                        Range oRange = null;
                                        Font font = null;

                                        try
                                        {
                                            oRange = (Range)cellsRPL[textInLine.row + 1, iCl + 1];

                                            widthTextPrev += (float)((double)oRange.Width);

                                            if (iCl == textInLine.columnFPrev)
                                            {
                                                leftTextPrev = (float)((double)oRange.Left);
                                                topTextPrev = (float)((double)oRange.Top - textInLine.top);
                                                heightTextPrev = (float)((double)oRange.Height);
                                                textRangePrev = (string)oRange.Value2;

                                                oRange.Value2 = "";

                                                font = oRange.Font;
                                                hasBoldPrev = (bool)font.Bold;
                                                fontSizePrev = (double)font.Size;
                                                fontNamePrev = (string)font.Name;
                                            }
                                        }
                                        finally
                                        {
                                            if (font != null) ReleaseCOMObject(font);
                                            if (oRange != null) ReleaseCOMObject(oRange);
                                        }
                                    }

                                    Shape textBoxPrev = null;
                                    Characters stringTextBoxPrev = null;
                                    TextFrame txtFrame = null;
                                    LineFormat txtLine = null;
                                    FillFormat txtFill = null;
                                    Font txtFont = null;
                                    try
                                    {
                                        textBoxPrev = shapesRPL.AddTextbox(
                                            Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,
                                            leftTextPrev, topTextPrev, widthTextPrev, heightTextPrev);

                                        txtFrame = textBoxPrev.TextFrame;
                                        txtLine = textBoxPrev.Line;
                                        txtFill = textBoxPrev.Fill;

                                        txtFrame.VerticalAlignment = XlVAlign.xlVAlignCenter;
                                        txtFrame.MarginLeft = 3;
                                        txtFrame.MarginRight = 2;

                                        if (string.IsNullOrEmpty(textRangePrev))
                                            textBoxPrev.Width = widthBackUp;
                                        else
                                            txtFrame.AutoSize = true;

                                        txtLine.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                                        txtFill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

                                        stringTextBoxPrev = txtFrame.Characters(Type.Missing, Type.Missing);
                                        txtFont = stringTextBoxPrev.Font;
                                        stringTextBoxPrev.Text = textRangePrev;
                                        txtFont.Name = fontNamePrev;
                                        txtFont.Bold = hasBoldPrev;
                                        txtFont.Size = fontSizePrev;

                                        if (textBoxPrev.Width < textInLine.minWidth)
                                            textBoxPrev.Width = (float)textInLine.minWidth;

                                        leftTextPrev = textBoxPrev.Left;
                                        widthTextPrev = textBoxPrev.Width;
                                        widthBackUp = widthTextPrev;
                                    }
                                    finally
                                    {
                                        ReleaseCOMObject(txtFont);
                                        ReleaseCOMObject(stringTextBoxPrev);
                                        ReleaseCOMObject(txtFrame);
                                        ReleaseCOMObject(txtLine);
                                        ReleaseCOMObject(txtFill);
                                        ReleaseCOMObject(textBoxPrev);
                                    }
                                }

                                float leftText = 0, topText = 0, widthText = 0, heightText = 0;
                                string textRange = "";
                                var hasBold = false;
                                double fontSize = 12;
                                string fontName = "Arial";

                                for (var iCl = textInLine.columnF; iCl <= textInLine.columnT; iCl++)
                                {
                                    Range oRange = null;
                                    Font font = null;

                                    try
                                    {
                                        oRange = (Range)cellsRPL[textInLine.row + 1, iCl + 1];

                                        widthText += (float)((double)oRange.Width);

                                        if (iCl == textInLine.columnF)
                                        {
                                            leftText = (float)((double)oRange.Left - textInLine.left);
                                            topText = (float)((double)oRange.Top - textInLine.top);
                                            heightText = (float)((double)oRange.RowHeight);

                                            textRange = (string)oRange.Text;

                                            oRange.Value2 = "";

                                            font = oRange.Font;
                                            hasBold = (bool)font.Bold;
                                            fontSize = (double)font.Size;
                                            fontName = (string)font.Name;
                                        }
                                    }
                                    finally
                                    {
                                        //if (font != null) ReleaseCOMObject(font);
                                        //if (oRange != null) ReleaseCOMObject(oRange);
                                    }
                                }

                                leftText = leftTextPrev <= -1 ? leftText : leftTextPrev + widthTextPrev;

                                Shape textBox = null;
                                Characters stringTextBox = null;
                                TextFrame TextFrame = null;
                                TextFrame2 TextFrame2 = null;
                                LineFormat Line = null;
                                FillFormat Fill = null;
                                try
                                {
                                    textBox = shapesRPL.AddTextbox(
                                        Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal,
                                        leftText, topText, widthText, heightText);
                                    TextFrame = textBox.TextFrame;
                                    TextFrame2 = textBox.TextFrame2;
                                    Line = textBox.Line;
                                    Fill = textBox.Fill;

                                    TextFrame.MarginLeft = 2;
                                    TextFrame.MarginRight = 2;
                                    TextFrame.MarginTop = 0;
                                    TextFrame.MarginBottom = 0;
                                    textBox.Height = heightText;

                                    TextFrame.VerticalAlignment = XlVAlign.xlVAlignCenter;
                                    TextFrame2.WordWrap = Microsoft.Office.Core.MsoTriState.msoCTrue;
                                    Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                                    Fill.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;

                                    stringTextBox = TextFrame.Characters(Type.Missing, Type.Missing);

                                    stringTextBox.Text = textRange;
                                    stringTextBox.Font.Name = fontName;
                                    stringTextBox.Font.Bold = hasBold;
                                    stringTextBox.Font.Size = fontSize;
                                }
                                finally
                                {
                                    ReleaseCOMObject(stringTextBox);
                                    ReleaseCOMObject(textBox);
                                    ReleaseCOMObject(TextFrame);
                                    ReleaseCOMObject(TextFrame2);
                                    ReleaseCOMObject(Line);
                                    ReleaseCOMObject(Fill);
                                }
                            }
                        }
                        finally
                        {
                            ReleaseCOMObject(shapesRPL);
                            ReleaseCOMObject(cellsRPL);
                        }
                    }

                    if (lstImage.Count > 0)
                    {
                        Shapes shapes = worksheet.Shapes;
                        Range cells = worksheet.Cells;
                        try
                        {
                            foreach (var image in lstImage)
                            {
                                System.Drawing.Image pictureR = null;
                                byte[] bytes = null;
                                string tempFile = "";

                                Shape pic = null;
                                Range oRange = null;
                                try
                                {
                                    oRange = (Range)cells[image.row + 1, image.column + 1];
                                    if (image.link.StartsWith("https://"))
                                    {
                                        try
                                        {
                                            var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(image.link);
                                            request.Timeout = 5000;
                                            request.ReadWriteTimeout = 5000;
                                            request.UserAgent = "Mozilla/5.0";

                                            using (var response = (System.Net.HttpWebResponse)request.GetResponse())
                                            using (var stream = response.GetResponseStream())
                                            using (var ms = new MemoryStream())
                                            {
                                                stream.CopyTo(ms);
                                                bytes = ms.ToArray();
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            oRange.Value = "IMG ERR: " + ex.Message;
                                        }

                                        if (bytes != null)
                                        {
                                            using (var ms = new MemoryStream(bytes))
                                            {
                                                pictureR = System.Drawing.Image.FromStream(ms);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        bytes = File.ReadAllBytes(image.link);
                                        using (var ms = new MemoryStream(bytes))
                                        {
                                            pictureR = System.Drawing.Image.FromStream(ms);
                                        }
                                    }

                                    if (pictureR != null)
                                    {
                                        float width = (float)((double)oRange.Width);
                                        float height = (float)((double)oRange.RowHeight);

                                        for (var iRan = image.column + 1; iRan <= image.columnLast; iRan++)
                                        {
                                            var oRangeBS = (Range)cells[image.row + 1, iRan + 1];
                                            width += (float)((double)oRangeBS.Width);
                                            ReleaseCOMObject(oRangeBS);
                                        }

                                        for (var iRan = image.row + 1; iRan <= image.rowLast; iRan++)
                                        {
                                            var oRangeBS = (Range)cells[iRan + 1, image.column + 1];
                                            height += (float)((double)oRangeBS.RowHeight);
                                            ReleaseCOMObject(oRangeBS);
                                        }

                                        float widthR = pictureR.Width;
                                        float heightR = pictureR.Height;
                                        float scale = 0.9f;
                                        float percent = Math.Min(width / widthR, height / heightR) * scale;

                                        var widthImg = (int)(widthR * percent);
                                        var heightImg = (int)(heightR * percent - 3.5);
                                        widthImg = widthImg > width ? (int)(width - 1) : widthImg;
                                        var rateColumnAndPicture = (width - widthImg) / 2;
                                        rateColumnAndPicture = rateColumnAndPicture <= 0 ? 0 : rateColumnAndPicture;

                                        var rateRowAndPicture = (height - heightImg) / 2;
                                        rateRowAndPicture = rateRowAndPicture <= 0 ? 2 : rateRowAndPicture;

                                        var Left = (float)((double)oRange.Left + rateColumnAndPicture);
                                        var Top = (float)((double)oRange.Top + rateRowAndPicture);

                                        if (image.leftIMG != null)
                                            Left = (float)((double)oRange.Left) + image.leftIMG.GetValueOrDefault(0);

                                        if (image.topIMG != null)
                                            Top = (float)((double)oRange.Top) + image.topIMG.GetValueOrDefault(0);

                                        if (image.widthIMG != null)
                                            widthImg = (int)image.widthIMG.GetValueOrDefault(0);

                                        if (image.heightIMG != null)
                                            heightImg = (int)image.heightIMG.GetValueOrDefault(0);

                                        tempFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".jpg");
                                        File.WriteAllBytes(tempFile, bytes);
                                        pic = shapes.AddPicture(tempFile, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, widthImg, heightImg);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(ex.ToString());
                                }
                                finally
                                {
                                    if (File.Exists(tempFile))
                                        File.Delete(tempFile);

                                    if (pictureR != null)
                                        pictureR.Dispose();

                                    ReleaseCOMObject(pic);
                                    ReleaseCOMObject(oRange);
                                }
                            }
                        }
                        finally
                        {
                            ReleaseCOMObject(shapes);
                            ReleaseCOMObject(cells);
                        }
                    }

                    // Try and avoid xls files raising a dialog
                    var temporaryStorageDir = Path.GetTempFileName();
                    File.Delete(temporaryStorageDir);
                    Directory.CreateDirectory(temporaryStorageDir);
                    // We will save as xlsb (binary format) since this doesn't raise some errors when processing
                    tmpFile = Path.Combine(temporaryStorageDir, Path.GetFileNameWithoutExtension(inputFile) + ".xlsb");
                    fmt = XlFileFormat.xlExcel12;

                    // Set up the print quality
                    if (screenQuality)
                    {
                        quality = XlFixedFormatQuality.xlQualityMinimum;
                    }

                    // If a worksheet has been specified, try and use just the one
                    if (worksheetNum > 0)
                    {
                        // Force us just to use the active sheet
                        onlyActiveSheet = true;
                        try
                        {
                            if (worksheetNum > allSheets.Count)
                            {
                                // Sheet count is too big
                                msg = Enum.GetName(typeof(ExitCode), ExitCode.WorksheetNotFound);
                                throw new ArgumentException(msg);
                            }
                            if (allSheets[worksheetNum] is _Worksheet)
                            {
                                ((_Worksheet)allSheets[worksheetNum]).Activate();
                                sheetForConversionIdx = ((_Worksheet)allSheets[worksheetNum]).Index;
                            }
                            else if (allSheets[worksheetNum] is _Chart)
                            {
                                ((_Chart)allSheets[worksheetNum]).Activate();
                                sheetForConversionIdx = ((_Chart)allSheets[worksheetNum]).Index;
                            }

                        }
                        catch (Exception)
                        {
                            msg = Enum.GetName(typeof(ExitCode), ExitCode.WorksheetNotFound);
                            throw new ArgumentException(msg);
                        }
                    }

                    if (showFormulas)
                    {
                        // Determine whether to show formulas
                        try
                        {
                            activeWindow.DisplayFormulas = true;
                        }
                        catch (Exception) { }
                    }

                    // Keep the windows hidden
                    if (isHidden)
                    {
                        wbWin = workbook.Windows;
                        if (null != wbWin)
                        {
                            if (wbWin.Count > 0)
                            {
                                //wbWin[1].Visible = false;
                            }
                        }
                        if (null != activeWindow)
                        {
                            activeWindow.Visible = false;
                        }
                    }

                    // Keep track of the active sheet
                    int activeSheetIdx = 1;
                    activeSheet = workbook.ActiveSheet;
                    if (activeSheet != null)
                    {
                        if (activeSheet is _Worksheet)
                        {
                            activeSheetIdx = ((Worksheet)activeSheet).Index;
                        }
                        else if (activeSheet is _Chart)
                        {
                            activeSheetIdx = ((Microsoft.Office.Interop.Excel.Chart)activeSheet).Index;
                        }
                    }

                    // Large excel files may simply not print reliably - if the excel_max_rows
                    // configuration option is set, then we must close up and forget about 
                    // converting the file. However, if a print area is set in one of the worksheets
                    // in the document, then assume the author knew what they were doing and
                    // use the print area.

                    // We may need to loop through all the worksheets in the document
                    // depending on the options given. If there are maximum row restrictions
                    // or formulas are being shown, then we need to loop through all the
                    // worksheets
                    if (maxRows > 0 || showFormulas || showHeadings)
                    {
                        var row_count_check_ok = true;
                        var found_rows = 0;
                        var found_worksheet = "";
                        bool[] rowCountOK = new bool[allSheets.Count + 1];

                        // Loop through all the sheets (worksheets and charts)
                        for (int wsIdx = 1; wsIdx <= allSheets.Count; wsIdx++)
                        {
                            var ws = allSheets.Item[wsIdx];
                            rowCountOK[wsIdx] = true;

                            // Skip anything that is not the active sheet
                            if (onlyActiveSheet)
                            {
                                // Have to be careful to treat _Worksheet and _Chart items differently
                                try
                                {
                                    // Get the index of the active sheet
                                    if (wsIdx != activeSheetIdx)
                                    {
                                        // If we are not the active sheet, then skip to the next
                                        ReleaseCOMObject(ws);
                                        continue;
                                    }
                                }
                                catch (Exception)
                                {
                                    if (ws != null)
                                    {
                                        ReleaseCOMObject(ws);
                                    }
                                    continue;
                                }
                                sheetForConversionIdx = wsIdx;
                            }

                            if (showHeadings && ws is _Worksheet)
                            {
                                PageSetup pageSetup = null;
                                try
                                {
                                    pageSetup = ((Worksheet)ws).PageSetup;
                                    pageSetup.PrintHeadings = true;

                                }
                                catch (Exception) { }
                                finally
                                {
                                    ReleaseCOMObject(pageSetup);
                                }
                            }

                            // If showing formulas, make things auto-fit
                            if (showFormulas && ws is _Worksheet)
                            {
                                Range cols = null;
                                try
                                {
                                    ((_Worksheet)ws).Activate();
                                    activeWindow.DisplayFormulas = true;
                                    cols = ((Worksheet)ws).Columns;
                                    cols.AutoFit();
                                }
                                catch (Exception) { }
                                finally
                                {
                                    ReleaseCOMObject(cols);
                                }
                            }

                            // If there is a maximum row count, make sure we check each worksheet
                            if (maxRows > 0 && ws is _Worksheet)
                            {
                                // Check for a print area
                                var pageSetup = ((Worksheet)ws).PageSetup;
                                var printArea = pageSetup.PrintArea;
                                ReleaseCOMObject(pageSetup);
                                if (string.IsNullOrEmpty(printArea))
                                {
                                    // There is no print area, check that the row count is <= to the
                                    // excel_max_rows value. Note that we can't just take the range last
                                    // row, as this may return a huge value, rather find the last non-blank
                                    // row.
                                    var row_count = 0;
                                    var range = ((Worksheet)ws).UsedRange;
                                    if (range != null)
                                    {
                                        var rows = range.Rows;
                                        if (rows != null && rows.Count > maxRows)
                                        {
                                            var cells2 = range.Cells;
                                            if (cells2 != null)
                                            {
                                                var cellSearch = cells2.Find("*", oMissing, oMissing, oMissing, oMissing, Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious, false, oMissing, oMissing);
                                                // Make sure we actually get some results, since the worksheet may be totally blank
                                                if (cellSearch != null)
                                                {
                                                    row_count = cellSearch.Row;
                                                    found_worksheet = ((Worksheet)ws).Name;
                                                }
                                                ReleaseCOMObject(cellSearch);
                                            }
                                            ReleaseCOMObject(cells2);
                                        }
                                        ReleaseCOMObject(rows);
                                    }
                                    ReleaseCOMObject(range);

                                    if (row_count > maxRows)
                                    {
                                        // Too many rows on this worksheet - mark the workbook as unprintable
                                        row_count_check_ok = false;
                                        rowCountOK[wsIdx] = false;
                                        found_rows = row_count;
                                        ReleaseCOMObject(ws);
                                        if (activeSheetOnMaxRows)
                                        {
                                            // Keep checking
                                            continue;
                                        }
                                        break;
                                    }
                                }
                            } // End of row check
                            ReleaseCOMObject(ws);
                        }

                        // Make sure we are not converting a document with too many rows
                        if (row_count_check_ok == false)
                        {
                            // We may want to try and convert the active sheet if it has not been included in the
                            // sheets with too many rows
                            bool bailOut = true;
                            if (activeSheetOnMaxRows && !onlyActiveSheet)
                            {
                                if (rowCountOK[activeSheetIdx])
                                {
                                    bailOut = false;
                                    sheetForConversionIdx = activeSheetIdx;
                                    onlyActiveSheet = true;
                                }
                            }
                            if (bailOut)
                            {
                                throw new Exception(String.Format("Too many rows to process ({0}) on worksheet {1}", found_rows, found_worksheet));
                            }
                        }
                    }

                    // Allow for re-calculation to be skipped
                    if (skipRecalculation)
                    {
                        app.Calculation = XlCalculation.xlCalculationManual;
                        app.CalculateBeforeSave = false;
                    }
                    else
                        app.Calculation = XlCalculation.xlCalculationAutomatic;

                    if (mimeTypeOutput == "pdf")
                    {
                        app.ScreenUpdating = false;
                        app.Calculation = XlCalculation.xlCalculationManual;
                        app.EnableEvents = false;

                        Range cell = null;
                        Range endUp = null;
                        Range usedRange = null;
                        Range usedRows = null;
                        Range startCell = null;
                        Range endCell = null;
                        Range emptyRange = null;

                        try
                        {
                            int maxRow = worksheet.Rows.Count;
                            int maxCol = worksheet.Columns.Count;
                            // lastRow
                            cell = (Range)worksheet.Cells[maxRow, 1];
                            endUp = cell.End[XlDirection.xlUp];
                            int lastRow = endUp.Row;

                            // UsedRange
                            usedRange = worksheet.UsedRange;
                            usedRows = usedRange.Rows;
                            int lastRowUsed = usedRange.Row + usedRows.Count - 1;

                            if (lastRowUsed < maxRow)
                            {
                                startCell = (Range)worksheet.Cells[lastRowUsed + 1, 1];
                                endCell = (Range)worksheet.Cells[maxRow, maxCol];

                                emptyRange = worksheet.get_Range(startCell, endCell);

                                emptyRange.ClearFormats();
                                emptyRange.ClearContents();
                                emptyRange.Delete();
                            }
                        }
                        finally
                        {
                            ReleaseCOMObject(emptyRange);
                            ReleaseCOMObject(endCell);
                            ReleaseCOMObject(startCell);
                            ReleaseCOMObject(usedRows);
                            ReleaseCOMObject(usedRange);
                            ReleaseCOMObject(endUp);
                            ReleaseCOMObject(cell);
                        }

                        workbook.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF,
                            outputFile, quality, includeProps, false, Type.Missing, Type.Missing, false, Type.Missing);

                        //var timeEnd = DateTime.Now;
                        //var totalsc = (timeEnd - timeStart).TotalSeconds;
                        //throw new Exception($"time:{(totalsc)}");
                    }
                    else
                    {
                        workbook.SaveAs(outputFile, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing);
                    }
                }
                catch (COMException ce)
                {
                    source.Cancel();
                    msg = "COMException: " + ce;
                }
                catch (Exception e)
                {
                    source.Cancel();
                    msg = "Exception: " + e;
                }
                finally
                {
                    if (workbook != null)
                    {
                        ReleaseCOMObject(activeSheet);
                        ReleaseCOMObject(activeWindow);
                        ReleaseCOMObject(wbWin);
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        // Excel sometimes needs a bit of a delay before we close in order to
                        // let things get cleaned up
                        workbook.Saved = true;
                        CloseExcelWorkbook(workbook);
                    }

                    if (!running)
                    {
                        if (workbooks != null)
                        {
                            workbooks.Close();
                        }

                        if (app != null)
                        {
                            ((Microsoft.Office.Interop.Excel._Application)app).Quit();
                        }
                    }

                    // Clean all the COM leftovers
                    ReleaseCOMObject(workbook);
                    ReleaseCOMObject(workbooks);
                    ReleaseCOMObject(app);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    if (tmpFile != null && File.Exists(tmpFile))
                    {
                        System.IO.File.Delete(tmpFile);
                        // Remove the temporary path to the temp file
                        Directory.Delete(Path.GetDirectoryName(tmpFile));
                    }

                    if (msg.Length > 0)
                        throw new Exception(msg);
                    else
                    {
                        while (!File.Exists(outputFile))
                        {
                            Thread.Sleep(2000);
                        }
                    }
                }
            }, token);

            var timeFist = DateTime.Now;
            var timeWait = 120000;
            int seconds = timeWait / 1000;
            task.Start();
            try
            {
                task.Wait(timeWait);
            }
            catch (Exception ex)
            {
                task.Dispose();
                msg = ex.ToString();
            }

            try
            {
                task.Dispose();
            }
            catch { }

            if ((DateTime.Now - timeFist).TotalSeconds >= seconds)
            {
                msg = string.Format(@"Timeout, limit to print is {0} seconds.", seconds);
                if (worksheet != null)
                {
                    Marshal.ReleaseComObject(worksheet);
                    worksheet = null;
                }

                if (workbook != null)
                {
                    workbook.Saved = true;
                    workbook.Close(false);
                    Marshal.ReleaseComObject(workbook);
                    workbook = null;
                }

                if (workbooks != null)
                {
                    Marshal.ReleaseComObject(workbooks);
                    workbooks = null;
                }

                if (app != null)
                {
                    app.Quit();
                    Marshal.ReleaseComObject(app);
                    app = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }

            return msg;
        }

        // Return true if there is a valid template option
        protected static bool HasTemplateOption(Hashtable options)
        {
            if (String.IsNullOrEmpty((string)options["template"]) ||
                !File.Exists((string)options["template"]) ||
                !System.Text.RegularExpressions.Regex.IsMatch((string)options["template"], @"^.*\.xl[st][mx]?$"))
            {
                return false;
            }
            return true;
        }

        // Read the first worksheet from a template document and extract and store
        // the page settings for later use
        protected static void SetPageOptionsFromTemplate(
    Application app,
    Workbooks workbooks,
    Hashtable options,
    ref Hashtable templatePageSetup)
        {
            if (!HasTemplateOption(options))
                return;

            Workbook template = null;
            Sheets templateSheets = null;
            object firstItem = null;
            PageSetup tps = null;

            try
            {
                template = workbooks.Open((string)options["template"]);
                AddCOMDelay(options);

                if (template == null)
                    return;

                // chạy macro nếu có
                if ((bool)options["excel_template_macros"])
                {
                    var eventsEnabled = app.EnableEvents;
                    app.EnableEvents = true;

                    template.RunAutoMacros(XlRunAutoMacro.xlAutoOpen);

                    app.EnableEvents = eventsEnabled;
                }

                templateSheets = template.Worksheets;

                if (templateSheets != null && templateSheets.Count > 0)
                {
                    firstItem = templateSheets[1];

                    if (firstItem is _Worksheet ws)
                    {
                        tps = ws.PageSetup;
                    }
                    else if (firstItem is _Chart chart)
                    {
                        tps = chart.PageSetup;
                    }

                    if (tps != null)
                    {
                        var tpsType = tps.GetType();

                        for (int i = 0; i < templateProperties.Length; i++)
                        {
                            var prop = tpsType.InvokeMember(
                                templateProperties[i],
                                System.Reflection.BindingFlags.GetProperty,
                                null,
                                tps,
                                null);

                            if (prop != null)
                            {
                                templatePageSetup[templateProperties[i]] = prop;
                            }
                        }
                    }
                }

                CloseExcelWorkbook(template);
            }
            finally
            {
                ReleaseCOMObject(tps);
                ReleaseCOMObject(firstItem);
                ReleaseCOMObject(templateSheets);
                ReleaseCOMObject(template);
            }
        }

        // Add in the required millisecond delay
        private static void AddCOMDelay(Hashtable options)
        {
            if ((int)options["excel_delay"] > 0)
            {
                Thread.Sleep((int)options["excel_delay"]);
            }
        }

        // Load stored worksheet properties into the page setup
        protected static void SetPageSetupProperties(Hashtable tps, PageSetup wps)
        {
            if (tps == null || tps.Count == 0)
            {
                return;
            }

            var wpsType = wps.GetType();
            for (int i = 0; i < templateProperties.Length; i++)
            {
                object[] value = { tps[templateProperties[i]] };
                try
                {
                    wpsType.InvokeMember(templateProperties[i], System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.SetProperty, Type.DefaultBinder, wps, value);
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to set property {0}", templateProperties[i]);
                }
            }
        }

        private static bool CloseExcelWorkbook(Workbook workbook)
        {
            int tries = 20;
            while (tries-- > 0)
            {
                try
                {
                    workbook.Close();
                    return true;
                }
                catch (COMException)
                {
                    Thread.Sleep(500);
                }
            }
            return false;
        }
    }
}
