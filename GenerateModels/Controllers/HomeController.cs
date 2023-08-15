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
    public class HomeController : Controller
    {
        protected UpdateEntityFramework update;
        public HomeController()
        {
            update = new UpdateEntityFramework();
        }

        public ActionResult Index()
        {
            IEnumerable<SelectListItem> items = update.getAllTable(null).AsEnumerable().Select(row => new SelectListItem { Value = row["value"].ToString(), Text = row["name"].ToString() });
            var tables = items;
            ViewData["TableAllColumn"] = tables;
            ViewData["Table1Column"] = tables;

            List<SelectListItem> lst2 = new List<SelectListItem>();
            ViewData["Column1Column"] = lst2 as IEnumerable<SelectListItem>;

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
        public JsonResult WriteObject000()
        {
            string msg = "";
            int status = 0;
            try
            {
                update.WriteAllObject();
                status = 1;
                msg = "Update model for all tables successfully";
            }
            catch (Exception ex)
            {
                status = 0;
                msg = ex.Message;
            }

            var result = new { status = status, msg = msg };
            return Json(result);
        }

        [HttpPost]
        public JsonResult WriteObject001(JsonLoadColumn model)
        {
            string msg = "";
            int status = 0;
            try
            {
                update.WriteOneObject(model.Table);
                status = 1;
                msg = "Update model for 1 table successfully";
            }
            catch (Exception ex)
            {
                status = 0;
                msg = ex.Message;
            }

            var result = new { status = status, msg = msg };
            return Json(result);
        }

        public class JsonLoadColumn
        {
            public string Table { get; set; }
        }
    }
}