using DataAcess;
using System;
using System.Globalization;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for Helper
/// </summary>
public static class Helper
{
    public static string getNewId()
    {
        return Guid.NewGuid().ToString().Replace("-", "");
    }

    public static System.Collections.Generic.Dictionary<string, string> pathReport(string name)
    {
        name = name.Replace("/", "-");
        var obj = new System.Collections.Generic.Dictionary<string, string>();
        obj["name"] = name;
        obj["link"] = HttpContext.Current.Server.MapPath("~/DEV_REPORT/pdfs/" + name);
        obj["linkView"] = Security.UrlBase() + "DEV_REPORT/pdfs/" + name;
        return obj;
    }

    public static System.Collections.Generic.Dictionary<string, string> pathImport(string name)
    {
        name = name.Replace("/", "-");
        var obj = new System.Collections.Generic.Dictionary<string, string>();
        obj["name"] = name;
        obj["link"] = HttpContext.Current.Server.MapPath("~/file_import/" + name);
        obj["linkView"] = Security.UrlBase() + "~/file_import/" + name;
        return obj;
    }

    public static string getConnectStrings(string ten_connectstring)
    {
        return System.Web.Configuration.WebConfigurationManager.ConnectionStrings[ten_connectstring].ConnectionString;
    }

    public static string getFilter(HttpContext context)
    {
        string filter = "";
        jqGridHelper.Filter f = new jqGridHelper.Filter();
        bool _search = bool.Parse(context.Request.QueryString["_search"]);
        if (_search)
        {
            String _filters = context.Request.QueryString["filters"];
            if (_filters != null & _filters != "")
            {
                f = jqGridHelper.Filter.CreateFilter(_filters);
                filter = f.ToScript();
            }
        }
        return filter;
    }

    public static int getPage(HttpContext context)
    {
        int kq = 1;
        if (VNN_Validate.check_number(context.Request.QueryString["page"], "int"))
        {
            kq = int.Parse(context.Request.QueryString["page"]);
        }
        return kq;
    }

    public static int Week_(DateTime? nullable)
    {
        if (nullable.HasValue)
        {
            GregorianCalendar gCalendar = new GregorianCalendar();
            int WeekNumber = gCalendar.GetWeekOfYear(nullable.Value, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return WeekNumber;
        }
        else
            return 0;
    }

    public static DateTime FirstDateOfWeekISO8601(int year, int weekOfYear)
    {
        DateTime jan1 = new DateTime(year, 1, 1);
        int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;
        DateTime firstThursday = jan1.AddDays(daysOffset);
        var cal = CultureInfo.CurrentCulture.Calendar;
        int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        var weekNum = weekOfYear;
        if (firstWeek == 1)
        {
            weekNum -= 1;
        }
        var result = firstThursday.AddDays(weekNum * 7);
        return result.AddDays(-3);
    }

    public static md_kho layKhoCuaTo(string pxId, string toId, EntityContext db)
    {
        return db.md_kho.Where(s =>
                                s.md_phanxuong_id == pxId
                                & s.md_to_id == toId
                                & s.hangton == false).FirstOrDefault();
    }

    public static decimal soLuongTonKhoThucTe(string khoId, string spId, EntityContext db)
    {
        var khosp = db.md_kho_sanpham.Where(s =>
            s.md_kho_id == khoId &
            s.md_sanpham_id == spId
        ).FirstOrDefault();

        return khosp == null ? 0 : khosp.soluong.GetValueOrDefault();
    }

    public static void downloadFiles(HttpContext context, string name, string link, int type)
    {
        string contentType = type == 0 ? "application/pdf" : "application/vnd.ms-excel";
        context.Response.Buffer = true;
        context.Response.Clear();
        context.Response.AddHeader("Content-Disposition", "attachment;filename=" + name);
        context.Response.AddHeader("content-length", new System.IO.FileInfo(link).Length.ToString());
        context.Response.ContentType = contentType;
        context.Response.Charset = "";
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.WriteFile(link);
        context.Response.End();
    }

    public static void viewFile(DevExpress.XtraReports.UI.XtraReport report)
    {
        var pathRp = pathReport(report.DisplayName + ".pdf");
        report.ExportToPdf(pathRp["link"]);

        string url = Security.UrlBase() + "ViewPDFPublic/index.aspx?url_pdf=" + pathRp["linkView"] + "?" + Guid.NewGuid();
        HttpContext.Current.Response.Redirect(url);
    }
}