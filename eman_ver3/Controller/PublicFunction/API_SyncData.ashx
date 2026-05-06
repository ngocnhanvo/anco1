<%@ WebHandler Language="C#" Class="API_SyncData" %>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAcess;
using Newtonsoft.Json;
using NLog;
using System.Reflection;
using System.Data.Entity;

public class API_SyncData : IHttpHandler
{
    private static Logger logger = LogManager.GetCurrentClassLogger();
    private class resultData
    {
        public bool? ok { get; set; }
        public List<ad_log_ancotrading> result { get; set; }
        public string msg { get; set; }
    }

    public void ProcessRequest(HttpContext context)
    {
        string msg = "";
        try
        {
            string formData = $"";
            formData += "oper=logs";
            formData += "&ncc=anco1";
            string link = $"{Helper.urlSync_ANCO}/Controllers/API_Data.ashx";
            msg = VNN_VariablePublic.GetModule(link, formData);
            if (string.IsNullOrWhiteSpace(msg))
            {
                msg = "Không kết nối được với ancotraing";
            }
            else
            {
                var json = JsonConvert.DeserializeObject<resultData>(msg);
                if (json.ok.GetValueOrDefault(false))
                {
                    using (var dball = new EntityContext())
                    {
                        foreach (var log in json.result)
                        {
                            log.ad_log_ancotrading_id = Helper.getNewId();
                            //dball.ad_log_ancotrading.Add(log);
                        }


                        //if (dball.ad_log_ancotrading.Local.Count > 0)
                        //    dball.SaveChanges();
                        //else
                        //    msg = "Không có log nào phát sinh";
                    }
                }
                else
                {
                    msg = json.msg;
                }
            }
        }
        catch (Exception ex)
        {
            msg = ex.ToString();
            logger.Info(msg);
        }

        context.Response.Write(msg);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}


