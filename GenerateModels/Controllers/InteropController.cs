using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Configuration;
using System.Web.Mvc;

namespace GenerateModels.Controllers
{
    public class InteropController : Controller
    {
        public InteropController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public string excel()
        {
            string msg = "";
            Models.ExportRequest req = null;
            try
            {
                Request.InputStream.Position = 0;
                string body;
                using (var reader = new StreamReader(Request.InputStream, Encoding.UTF8))
                {
                    body = reader.ReadToEnd();
                    req = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.ExportRequest>(body);
                    if (req == null)
                        throw new Exception("Invalid JSON body");

                    using (var excelConvert = new OfficeToPDF.ExcelConverter())
                    {
                        excelConvert.lstText = req.lstText;
                        excelConvert.lstImage = req.lstImage;
                        excelConvert.lstTextReplace = req.lstTextReplace;
                        excelConvert.lstAutoSizeColumn = req.lstAutoSizeColumn;
                        excelConvert.lstBlankRow = req.lstBlankRow;
                        excelConvert.nameApp = req.nameApp;
                        excelConvert.ghostscript = req.ghostscript;
                        excelConvert.endRow = req.endrow;
                        excelConvert.endColumn = req.endColumn;
                        msg = excelConvert.ConvertInterop(req.urlExcel, req.urlFN, null);
                    }
                }
            }
            catch(Exception ex)
            {
                msg = ex.ToString();
            }

            return msg;
        }
    }
}