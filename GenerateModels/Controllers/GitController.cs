using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Configuration;
using System.Web.Mvc;
using InfoDB;
namespace GenerateModels.Controllers
{
    public class GitController : Controller
    {
        protected UpdateJSONData update;
        public GitController()
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
            var filepath = $"{AppDomain.CurrentDomain.BaseDirectory}";
            filepath = filepath.Replace("\\GenerateModels\\", "");
            filepath = filepath.Replace("\\Publish_GenerateModels\\", "");
            filepath += $"\\eman_ver3\\extension\\pull_code.bat";

            string output = RunExternalExe(filepath);
            var result = new { status = 1, msg = output, link = "" };
            return Json(result);
        }

        [HttpPost]
        public JsonResult WriteObject001()
        {
            var filepath = $"{AppDomain.CurrentDomain.BaseDirectory}";
            filepath = filepath.Replace("\\GenerateModels\\", "");
            filepath = filepath.Replace("\\Publish_GenerateModels\\", "");
            filepath += $"\\eman_ver3\\extension\\stash_code.bat";

            string output = RunExternalExe(filepath);
            var result = new { status = 1, msg = output, link = "" };
            return Json(result);
        }

        public string RunExternalExe(string filename, string arguments = null)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = filename;
            process.StartInfo.Verb = "runas";
            process.EnableRaisingEvents = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            
            var stdOutput = new StringBuilder();
            process.OutputDataReceived += (sender, args) => stdOutput.AppendLine(args.Data);
            process.ErrorDataReceived += (sender, args) => stdOutput.AppendLine(args.Data);
            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();
            return stdOutput.ToString();
        }
    }
}