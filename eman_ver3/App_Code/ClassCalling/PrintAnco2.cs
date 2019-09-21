using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAcess;

public class PrintAnco2
{
    public static InfoPrint GetInfoPrint()
    {
        var context = HttpContext.Current;
        var json = new ADmin_JSON();
        var ttc = json.ad_systemconfigJSON().FirstOrDefault();
        string urlBase = Security.UrlBase();
        return new InfoPrint
        {
            logo = urlBase + "/" + ttc.logo + "?ver=1",
            dd = DateTime.Now.ToString("dd"),
            MM = DateTime.Now.ToString("MM"),
            yyyy = DateTime.Now.ToString("yyyy"),
        };
    }

    public static string GetDecimal(string sothapphan, int type)
    {
        switch (sothapphan)
        {
            case "1":
                sothapphan = "#,#0.0";
                break;
            case "2":
                sothapphan = "#,#0.00";
                break;
            case "3":
                sothapphan = "#,#0.000";
                break;
            case "4":
                sothapphan = "#,#0.0000";
                break;
            case "5":
                sothapphan = "#,#0.####";
                break;
        }

        if (type == 1)
        {
            sothapphan = string.Format("{{0:{0}}}", sothapphan);
        }
        return sothapphan;
    }
}
public class InfoPrint
{
    public string logo { get; set; }
    public string dd { get; set; }
    public string MM { get; set; }
    public string yyyy { get; set; }
}
