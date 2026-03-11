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

        [HttpPost]
        public string excel(Models.ExportRequest req)
        {
            string msg = "";
            try
            {
                using (var excelConvert = new OfficeToPDF.ExcelConverter())
                {
                    excelConvert.lstText = null;
                    excelConvert.lstImage = req.lstImage;
                    excelConvert.lstTextReplace = req.lstTextReplace;
                    excelConvert.lstAutoSizeColumn = req.lstAutoSizeColumn;

                    excelConvert.endRow = req.endrow;
                    excelConvert.endColumn = req.endColumn;
                    msg = excelConvert.ConvertInterop(req.urlExcel, req.urlFN, null);
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