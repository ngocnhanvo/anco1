using DataAcess;
using System;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
/// <summary>
/// Summary description for Helper
/// </summary>
public static class Helper
{
    public static string[] mimeTypes = { ".jpg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".pdf" }; 
    public static string VNN_notpost = "VNN_notpost";
    public static string SOANTHAO = "SOANTHAO";
    public static string DANHAN = "DANHAN";
    public static string HIEULUC = "HIEULUC";
    public static string HUYBO = "HUYBO";
    public static string KETTHUC = "KETTHUC";
    public static string CHUAHOANTHANH = "CHUAHOANTHANH";
    public static string HOANTHANH = "HOANTHANH";
    public static string KHDXL = "KHDXL";
    public static string MUAVT = "MUAVT";
    public static string MUATP = "MUATP";
    public static string BANTP = "BANTP";
    public static string NHANCONG = "NHANCONG";
    public static string ChoTTP = "ChoTTP";
    public static string DaXLTTP = "DaXLTTP";
    public static string ChoTBTP = "ChoTBTP";
    public static string DaXLTBTP = "DaXLTBTP";
    public static string DATNCC = "DATNCC";
    public static string DATSX = "DATSX";
    public static string DATHET = "DATHET";
    public static string DaNhapHang = "DaNhapHang";
    public static string ChoDG = "ChoDG";
    public static string DaDongGoi = "DaDongGoi";
    public static string ChoXH = "ChoXH";
    public static string DaXuatHang = "DaXuatHang";

    public static string CHODUYET = "CHODUYET";
    public static string DADUYET = "DADUYET";

    public static string TUCHOI = "TUCHOI";
    public static string NhapKho = "Nhập kho";
    public static string XuatKho = "Xuất kho";

    public static string KHOTRON = System.Web.Configuration.WebConfigurationManager.AppSettings["KHOTRON"];
    public static string KHOTONTHO = System.Web.Configuration.WebConfigurationManager.AppSettings["KHOTONTHO"];
    public static string KHOTONTP = System.Web.Configuration.WebConfigurationManager.AppSettings["KHOTONTP"];
    public static string KhoThoChoHoanThien = System.Web.Configuration.WebConfigurationManager.AppSettings["KhoThoChoHoanThien"];
    public static string KhoHangSauHoanThien = System.Web.Configuration.WebConfigurationManager.AppSettings["KhoHangSauHoanThien"];
    public static string KHOTP = System.Web.Configuration.WebConfigurationManager.AppSettings["KHOTP"];
    public static string KHOVT = System.Web.Configuration.WebConfigurationManager.AppSettings["KHOVT"];

    public static dynamic getInfoDB()
    {
        var builder = new System.Data.SqlClient.SqlConnectionStringBuilder(Mbg.Data.SqlClient.SqlHelper.connectionString);
        return new System.Collections.Generic.Dictionary<string, string>
    {
        { "server", builder.DataSource },
        { "database", builder.InitialCatalog }
    };
    }

    public static void removeFileWithPath(string path)
    {
        if (System.IO.File.Exists(path))
            System.IO.File.Delete(path);
    }

    public static void removeDirectoryWithPath(string path)
    {
        if (System.IO.Directory.Exists(path))
        {
            var filesLost = new System.IO.DirectoryInfo(path).GetFiles("*");
            foreach (var file in filesLost)
                System.IO.File.Delete(file.FullName);
            System.IO.Directory.Delete(path);
        }
    }
    public static string convertJsonStringToImage(string json, string folder, string name)
    {
        if (!(json.StartsWith("{") & json.EndsWith("}")))
        {
            if (json == "removeImage")
            {
                string pathimg = ExcuteSignalRStatic.mapPathSignalR(string.Format("~/{0}/{1}.jpg", folder, name));
                removeFileWithPath(pathimg);
                return pathimg;
            }
            else
                return "";
        }

        var jsonHA = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        string mimeType = jsonHA["name"];
        var indexMimeType = mimeType.LastIndexOf(".");
        mimeType = indexMimeType <= -1 ? "" : mimeType.Substring(indexMimeType).ToLower();
        if (!new string[] { ".png", ".jpg" }.Contains(mimeType))
            throw new FormatException("Chỉ chấp nhận hình ảnh có định dạng .jpg hoặc .png");

        string imageBase64 = jsonHA["data"];
        var indexBase64 = imageBase64.IndexOf(",");
        imageBase64 = indexBase64 <= -1 ? "" : imageBase64.Substring(indexBase64 + 1);

        string path = "";
        if (!string.IsNullOrWhiteSpace(mimeType))
        {
            var bytes = Convert.FromBase64String(imageBase64);
            path = ExcuteSignalRStatic.mapPathSignalR("~/" + folder + "/" + name);
            using (var imageFile = new System.IO.FileStream(path + mimeType, System.IO.FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();

                var isJPEG = mimeType == ".jpg";
                if (!isJPEG)
                {
                    var myImage = System.Drawing.Image.FromStream(imageFile);
                    myImage.Save(path + ".jpg");
                    myImage.Dispose();
                }

                imageFile.Close();
                imageFile.Dispose();

                if (!isJPEG)
                {
                    System.IO.File.Delete(path + mimeType);
                }
            }
        }
        return path;
    }

    public static string getNewId()
    {
        return Guid.NewGuid().ToString().Replace("-", "");
    }

    public static string EncodeHTML_VNN(string a)
    {
        if (a == null)
        {
            a = "";
        }
        a = a.Replace("&", "%26");
        a = a.Replace("+", "%2B");
        a = a.Replace("&", "%26");
        a = a.Replace("+", "%2B");
        return a;
    }

    public static bool checkBrower(HttpContext context)
    {
        var userAgent = context.Request.UserAgent.removeAllSpaceOrTrimText(true).ToLower();
        var oks = new string[] { "chrome" };
        var result = false;
        foreach (var ok in oks)
        {
            if (userAgent.Contains(ok))
                result = true;
        }
        return result;
    }

    public static System.Collections.Generic.Dictionary<string, string> pathReport(string name)
    {
        name = name.Replace("/", "-");
        var obj = new System.Collections.Generic.Dictionary<string, string>();
        obj["name"] = name;
        obj["link"] = HttpContext.Current.Server.MapPath("~/DEV_REPORT/pdfs/" + name);
        obj["linkView"] = EncodeHTML_VNN(Security.UrlBase() + "DEV_REPORT/pdfs/" + name);
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

    public static string getFilterP(HttpContext context)
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
                filter = f.ToScriptP();
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
        return db.md_kho.Where(s => s.md_to_id == pxId & s.hangton == false).FirstOrDefault();
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
        if (report != null)
        {
            var pathRp = pathReport(report.DisplayName + ".pdf");
            report.ExportToPdf(pathRp["link"]);

            string url = Security.UrlBase() + "ViewPDFPublic/index.aspx?url_pdf=" + pathRp["linkView"] + "&remove=true&zoom=page-width&id=" + Guid.NewGuid();
            HttpContext.Current.Response.Redirect(url);
        }
    }

    public static dynamic setDefaultValueWhenInsertOrUpdate(dynamic a, User_TK us, bool edit)
    {
        if (!edit)
        {
            a.ngaytao = DateTime.Now;

            a.nguoitao = us.ad_user_id;
            a.value_nguoitao = us.ma_user;

            a.bophantao = us.md_phongban_id;
            a.value_bophantao = us.ten_phongban;

            a.vaitrotao = us.ad_role_id;
            a.value_vaitrotao = us.ten_role;
        }
        
        a.ngaycapnhat = DateTime.Now;
        
        a.nguoicapnhat = us.ad_user_id;

        a.value_nguoicapnhat = us.ma_user;
        
        a.bophancapnhat = us.md_phongban_id;

        a.value_bophancapnhat = us.ten_phongban;
        
        a.vaitrocapnhat = us.ad_role_id;

        a.value_vaitrocapnhat = us.ten_role;
        
        return a;
    }
}