using System;
using System.Globalization;
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
}