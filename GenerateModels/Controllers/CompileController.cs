using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Configuration;
using System.Web.Mvc;
using InfoDB;
namespace GenerateModels.Controllers
{
    public class CompileController : Controller
    {
        protected UpdateJSONData update;
        public CompileController()
        {
            update = new UpdateJSONData();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult WriteObject000()
        {
            string msg = "", link = "";
            List<string> modules = new List<string>();
            modules.Add("ad_menu");
            modules.Add("ad_module");
            modules.Add("ad_column");
            modules.Add("ad_case");
            modules.Add("ad_systemconfig");
            int status = 0;
            try
            {
                foreach(var module in modules)
                {
                    if (!string.IsNullOrEmpty(module))
                    {
                        update.WriteObject(module, 1);
                    }
                }

                string action = "/Controller/PublicFunction/CacheAction.ashx?oper=clear";
                callEMan(action);
                string urlEMan = WebConfigurationManager.AppSettings["urlEMan"];
                action = "/Controller/PublicFunction/CacheAction.aspx";
                link = urlEMan + action;
                status = 1;
                msg = "Compile successfully";
            }
            catch (Exception ex)
            {
                status = 0;
                msg = ex.Message;
            }

            var result = new { status, msg, link };
            return Json(result);
        }

        public void callEMan(string action)
        {
            string urlEMan = WebConfigurationManager.AppSettings["urlEMan"];
            string url = urlEMan + action;
            WebRequest request = WebRequest.Create(url);
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
        }

        public class JsonLoadColumn
        {
            public string Table { get; set; }
        }
    }
}