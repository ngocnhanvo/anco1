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
            logo = urlBase + "/" + ttc.logo,
        };
    }
}

public class InfoPrint
{
    public string logo { get; set; }
}
