using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoDB;
using Newtonsoft.Json;
namespace GenerateModels.Controllers
{
    public class JsonController : Controller
    {
        protected UpdateJSONData update;
        public JsonController()
        {
            update = new UpdateJSONData();
        }

        public ActionResult Index()
        {
            IEnumerable<SelectListItem> items = update.getAllTable(null).AsEnumerable().Select(row => new SelectListItem { Value = row["value"].ToString(), Text = row["name"].ToString() });
            var tables = items;
            ViewData["TableAllColumn"] = tables;
            return View();
        }

        [HttpPost]
        public JsonResult LoadColumn(JsonLoadColumn model)
        {
            string tableName = model.Table;
            var table = update.getAllColumns(tableName, null);
            List<Dictionary<string, object>> items = table.AsEnumerable().Select(row => table.Columns.Cast<DataColumn>().ToDictionary(
                column => column.ColumnName,
                column => row[column]
            )).ToList();
            return Json(items);
        }

        [HttpPost]
        public JsonResult WriteObject001(JsonLoadColumn model)
        {
            string msg = "", link = "";
            int status = 0;
            try
            {
                link = update.WriteObject(model.Table, 0);
                status = 1;
                msg = "Create json for 1 table successfully";
            }
            catch (Exception ex)
            {
                status = 0;
                msg = ex.Message;
            }

            var result = new { status, msg, link };
            return Json(result);
        }

        [HttpGet]
        public FileResult Download(string link)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(link);
            string fileName = "JsonData.json";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public class JsonLoadColumn
        {
            public string Table { get; set; }
        }
    }
}