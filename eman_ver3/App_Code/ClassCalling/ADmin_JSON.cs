using System;
using System.Linq;
using System.Collections.Generic;
using DataAcess;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Text;

public class ADmin_JSON
{
    public string urlData { get; set; }
     
    public ADmin_JSON()
    {

    }

    public void ClearCache(HttpContext context)
    {
        List<string> modules = new List<string>();
        modules.Add("ad_menu");
        modules.Add("ad_module");
        modules.Add("ad_column");
        modules.Add("ad_case");
        modules.Add("ad_role_mmc");
        modules.Add("ad_systemconfig");
        modules.Add("ad_user_mmc");
        foreach (var module in modules)
        {
            context.Cache.Remove(module);
        }
    }

    public void ClearCache(HttpContext context, string name)
    {
        context.Cache.Remove(name);
    }

    public List<Dictionary<string, object>> ReadJSON()
    {
        HttpContext context = HttpContext.Current;
        string url = context.Server.MapPath(Security.UrlBase() + "App_Data/JsonData/" + urlData + ".json");
        string json = File.ReadAllText(url);
        List<Dictionary<string, object>> items = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
        return items;
    }

    public List<ad_column> ad_columnJSON()
    {
        urlData = typeof(ad_column).Name;
        object cache = HttpContext.Current.Cache.Get(urlData);
        var jsonData = new List<ad_column>();

        if (cache == null)
        {
            jsonData = JsonConvert.DeserializeObject<List<ad_column>>(ReadStringJSON());
            HttpContext.Current.Cache.Insert(urlData, jsonData);
        }
        else
        {
            jsonData = cache as List<ad_column>;
        }
        return jsonData;
    }

    public List<ad_systemconfig> ad_systemconfigJSON()
    {
        urlData = typeof(ad_systemconfig).Name;
        object cache = HttpContext.Current.Cache.Get(urlData);
        List<ad_systemconfig> ad_systemconfigs = null;

        if (cache == null)
        {
            var items = ReadJSON();
            ad_systemconfigs = items.Select(s => new ad_systemconfig
            {
                ad_systemconfig_id = s["ad_systemconfig_id"].ToString(),
                connectstring_anco = s["connectstring_anco"].ToString(),
                date_import = DateTime.Parse(s["date_import"].ToString()),
                diachi = s["diachi"].ToString(),
                domain = s["domain"].ToString(),
                emailserver = s["emailserver"].ToString(),
                email_hotro = s["email_hotro"].ToString(),
                fax = s["fax"].ToString(),
                format_so = s["format_so"].ToString(),
                logo = s["logo"].ToString(),
                logo_trangchu = s["logo_trangchu"].ToString(),
                mausac = s["mausac"].ToString(),
                passemail = s["passemail"].ToString(),
                phone = s["phone"].ToString(),
                port = s["port"].ToString(),
                taikhoanemail = s["taikhoanemail"].ToString(),
                tencongty = s["tencongty"].ToString(),
                format_ngay = s["format_ngay"].ToString(),
                soluong_grid = int.Parse(s["soluong_grid"].ToString()),
                soluong_grid_2 = s["soluong_grid_2"].ToString(),
                ten_canhbao = s["ten_canhbao"].ToString(),
                ten_connectstring = s["ten_canhbao"].ToString(),
                ten_db = s["ten_db"].ToString(),
                ten_linq = s["ten_linq"].ToString(),
                url_lichtuan = s["url_lichtuan"].ToString(),
                url_linq = s["url_linq"].ToString(),
                website = s["website"].ToString()
            }).ToList();
            HttpContext.Current.Cache.Insert(urlData, ad_systemconfigs);
        }
        else
        {
            ad_systemconfigs = cache as List<ad_systemconfig>;
        }
        return ad_systemconfigs;
    }

    public List<ad_module> ad_moduleJSON()
    {
        urlData = typeof(ad_module).Name;
        object cache = HttpContext.Current.Cache.Get(urlData);
        List<ad_module> ad_modules = new List<ad_module>(); ;

        if (cache == null)
        {
            var items = ReadJSON();
            foreach(var s in items)
            {
                var item = new ad_module();
                item.ad_module_id = s["ad_module_id"].ToString();
                item.ad_menu_id = s["ad_menu_id"].ToString();
                if (s["capmodule"] != null)
                    item.capmodule = s.ContainsKey("capmodule") ? int.Parse(s["capmodule"].ToString()) : 0;
                if(s["double_click"] != null)
                    item.double_click = s["double_click"].ToString();
                item.from_sql = s.ContainsKey("from_sql") ? s["from_sql"].ToString() : "";
                if (s["header_grid"] != null)
                    item.header_grid = s.ContainsKey("header_grid") ? s["header_grid"].ToString() : "";
                item.hoatdong = s["hoatdong"].ToString().ToLower() == "true";
                item.Join_sql = s.ContainsKey("Join_sql") ? s["Join_sql"].ToString() : "";
                item.loaithuake = s.ContainsKey("loaithuake") ? s["loaithuake"] + "" : "";
                item.loai_module = s.ContainsKey("loai_module") ? s["loai_module"].ToString() : "";
                item.ma_menu = s.ContainsKey("ma_menu") ? s["ma_menu"].ToString() : "";
                item.ma_module = s.ContainsKey("ma_module") ? s["ma_module"].ToString() : "";
                item.ma_modulecha = s.ContainsKey("ma_modulecha") ? s["ma_modulecha"].ToString() : "";
                if (s["mutil_select"] != null)
                    item.mutil_select = s.ContainsKey("mutil_select") ? s["mutil_select"].ToString().ToLower() == "true" : false;
                item.nguoicapnhat = s.ContainsKey("nguoicapnhat") ? s["nguoicapnhat"].ToString() : "";
                item.nguoitao = s.ContainsKey("nguoitao") ? s["nguoitao"].ToString() : "";
                item.orderby_sql = s["orderby_sql"].ToString();
                if (s["procedure_sql"] != null)
                    item.procedure_sql = s["procedure_sql"].ToString();
                item.row_count = s["row_count"].ToString().ToLower() == "true";
                item.sapxep = s["sapxep"].ToString();
                item.select_sql = s["select_sql"].ToString();
                if (s["soluong_mod"] != null)
                    item.soluong_mod = !string.IsNullOrEmpty(s["soluong_mod"].ToString()) ? int.Parse(s["soluong_mod"].ToString()) : 0;
                item.ten_module = s["ten_module"].ToString();
                item.thuake = s["thuake"].ToString();
                item.url = s["url"].ToString();
                item.vaitrocapnhat = s["vaitrocapnhat"].ToString();
                item.vaitrotao = s["vaitrotao"].ToString();
                item.where_sql = s["where_sql"].ToString();
                if (item != null)
                {
                    ad_modules.Add(item);
                }
            }
            HttpContext.Current.Cache.Insert(urlData, ad_modules);
        }
        else
        {
            ad_modules = cache as List<ad_module>;
        }
        return ad_modules;
    }

    public List<ad_selectoption> ad_selectoptionJSON()
    {
        urlData = typeof(ad_selectoption).Name;
        object cache = HttpContext.Current.Cache.Get(urlData);
        List<ad_selectoption> ad_selectoptions = new List<ad_selectoption>();

        if (cache == null)
        {
            var items = ReadJSON();
            foreach(var s in items)
            {
                var item = new ad_selectoption();
                item.ad_selectoption_id = s["ad_selectoption_id"].ToString();
                item.display_member = s["display_member"].ToString();
                item.from_sql = s["from_sql"].ToString();
                item.hoatdong = s["hoatdong"].ToString().ToLower() == "true";
                item.ma_selectoption = s["ma_selectoption"].ToString();
                item.value_selectoption = s["value_selectoption"].ToString();
                if(s["mota"] != null)
                    item.mota = s["mota"].ToString();
                item.orderby_sql = s["orderby_sql"].ToString();
                item.sapxep = s["sapxep"].ToString();
                item.select_sql = s["select_sql"].ToString();
                item.ten_selectoption = s["ten_selectoption"].ToString();
                item.where_sql = s["where_sql"].ToString();

                if (item != null)
                    ad_selectoptions.Add(item);
            }
            HttpContext.Current.Cache.Insert(urlData, ad_selectoptions);
        }
        else
        {
            ad_selectoptions = cache as List<ad_selectoption>;
        }
        return ad_selectoptions;
    }

    public List<ad_case> ad_caseJSON()
    {
        urlData = typeof(ad_case).Name;
        object cache = HttpContext.Current.Cache.Get(urlData);
        List<ad_case> ad_cases = new List<ad_case>();
        if (cache == null)
        {
            var items = ReadJSON();
            foreach (var s in items)
            {
                var item = new ad_case();
                item.ad_case_id = s["ad_case_id"].ToString();
                item.ad_module_id = s["ad_module_id"].ToString();
                item.canhgiua = s["canhgiua"].ToString().ToLower() == "true";
                if(s["docaoForm"] != null)
                    item.docaoForm = s["docaoForm"].ToString();
                if (s["dodaiForm"] != null)
                    item.dodaiForm = s["dodaiForm"].ToString();
                item.hamxuly = s["hamxuly"].ToString();
                item.hidden_modify = s["hidden_modify"].ToString().ToLower() == "true";
                item.hoatdong = s["hoatdong"].ToString().ToLower() == "true";
                item.id_parent = s["id_parent"].ToString().ToLower() == "true";
                item.isview = s["isview"].ToString().ToLower() == "true";
                item.logo = s["logo"].ToString();
                item.ma_case = s["ma_case"].ToString();
                item.ma_menu = s["ma_menu"].ToString();
                item.ma_module = s["ma_module"].ToString();
                item.mota = s["mota"].ToString();
                item.sapxep = s["sapxep"].ToString();
                item.ten_case = s["ten_case"].ToString();
                if(s["thuake"] != null)
                    item.thuake = s["thuake"].ToString();
                if (s["tieude"] != null)
                    item.tieude = s["tieude"].ToString();

                if (item != null)
                    ad_cases.Add(item);
                HttpContext.Current.Cache.Insert(urlData, ad_cases);
            }
        }
        else
        {
            ad_cases = cache as List<ad_case>;
        }
        return ad_cases;
    }

    public List<ad_role_mmc> ad_role_mmcJSON()
    {
        urlData = typeof(ad_role_mmc).Name;
        object cache = HttpContext.Current.Cache.Get(urlData);
        List<ad_role_mmc> ad_role_mmcs = null;

        if (cache == null)
        {
            var items = ReadJSON();
            ad_role_mmcs = items.Select(s => new ad_role_mmc
            {
                ad_role_mmc_id = s["ad_role_mmc_id"].ToString(),
                ad_case_id = s["ad_case_id"].ToString(),
                ad_menu_id = s["ad_menu_id"].ToString(),
                ad_module_id = s["ad_module_id"].ToString(),
                ad_role_id = s["ad_role_id"].ToString(),
            }).ToList();
            HttpContext.Current.Cache.Insert(urlData, ad_role_mmcs);
        }
        else
        {
            ad_role_mmcs = cache as List<ad_role_mmc>;
        }
        return ad_role_mmcs;
    }

    public List<ad_menu> ad_menuJSON()
    {
        urlData = typeof(ad_menu).Name;
        object cache = HttpContext.Current.Cache.Get(urlData);
        List<ad_menu> ad_menus = new List<ad_menu>();

        if (cache == null)
        {
            var items = ReadJSON();
            foreach(var s in items) {
                var item = new ad_menu();
                item.ad_menu_id = s["ad_menu_id"].ToString();
                item.capmenu = !string.IsNullOrEmpty(s["capmenu"].ToString()) ? int.Parse(s["capmenu"].ToString()) : 0;
                item.loai_menu = s["loai_menu"].ToString();
                item.logo = s["logo"].ToString();
                item.ma_menucha = s["ma_menucha"].ToString();
                if(s["ma_module_count"] != null)
                    item.ma_module_count = s["ma_module_count"].ToString();
                item.ten_menu = s["ten_menu"].ToString();
                item.url = s["url"].ToString();
                item.hoatdong = s["hoatdong"].ToString().ToLower() == "true";
                item.ma_menu = s["ma_menu"].ToString();
                item.sapxep = s["sapxep"].ToString();

                if (item != null)
                    ad_menus.Add(item);
            }
            HttpContext.Current.Cache.Insert(urlData, ad_menus);
        }
        else
        {
            ad_menus = cache as List<ad_menu>;
        }
        return ad_menus;
    }

    public List<md_ghinotruno> md_ghinotrunoJSON()
    {
        urlData = typeof(md_ghinotruno).Name;
        var md_ghinotrunos = new List<md_ghinotruno>();
        var items = ReadJSON();
        foreach (var s in items)
        {
            var item = new md_ghinotruno();
            item.md_ghinotruno_id = s["md_ghinotruno_id"].ToString();
            item.md_to_id = s["md_to_id"].ToString();
            item.tosx = s["tosx"].ToString();
            item.md_sanpham_id = s["md_sanpham_id"].ToString();
            item.sanpham_val = s["sanpham_val"] + "";
            item.sanpham_dvt = s["sanpham_dvt"] + "";
            item.slno = !string.IsNullOrEmpty(s["slno"].ToString()) ? decimal.Parse(s["slno"].ToString()) : 0;
            
            item.hoatdong = true;
            item.ngaytao = DateTime.Parse(s["ngaytao"].ToString());
            item.nguoitao = s["nguoitao"].ToString();
            item.value_nguoitao = s["value_nguoitao"].ToString();

            if (item != null)
                md_ghinotrunos.Add(item);
        }
        return md_ghinotrunos;
    }

    public List<ad_user_mmc> ad_user_mmcJSON()
    {
        urlData = typeof(ad_user_mmc).Name;
        object cache = HttpContext.Current.Cache.Get(urlData);
        var jsonData = new List<ad_user_mmc>();

        if (cache == null)
        {
            jsonData = JsonConvert.DeserializeObject<List<ad_user_mmc>>(ReadStringJSON());
            HttpContext.Current.Cache.Insert(urlData, jsonData);
        }
        else
        {
            jsonData = cache as List<ad_user_mmc>;
        }
        return jsonData;
    }

    public string ReadStringJSON()
    {
        HttpContext context = HttpContext.Current;
        string url = ExcuteSignalRStatic.mapPathSignalR("~/App_Data/JsonData/" + urlData + ".json");
        string json = File.ReadAllText(url);
        return json;
    }

    #region Modify
    public void WriteJson()
    {
        string select = string.Format("select * from {0} (nolock)", urlData);
        DataTable tables = Mbg.Data.SqlClient.SqlHelper.GetData(select);
        List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
        foreach (DataRow row_ in tables.Rows)
        {
            Dictionary<string, object> item = new Dictionary<string, object>();
            foreach (DataColumn column_ in tables.Columns)
            {
                item[column_.ColumnName] = row_[column_.ColumnName].ToString();
            }
            lst.Add(item);
        }

        HttpContext context = HttpContext.Current;
        string filepath = context.Server.MapPath(Security.UrlBase() + "App_Data/JsonData/" + urlData + ".json");
        if (!File.Exists(filepath))
        {
            StreamWriter w = new StreamWriter(filepath, false, Encoding.UTF8);
            w.Flush();
            w.Close();
        }
        string Content = JsonConvert.SerializeObject(lst, Formatting.Indented);
        File.WriteAllText(filepath, Content);
        context.Cache.Remove(urlData);
    }

    public void WriteJson(string jsonData)
    {
        HttpContext context = HttpContext.Current;
        string filepath = context.Server.MapPath(Security.UrlBase() + "App_Data/JsonData/" + urlData + ".json");
        if (!File.Exists(filepath))
        {
            StreamWriter w = new StreamWriter(filepath, false, Encoding.UTF8);
            w.Flush();
            w.Close();
        }
        File.WriteAllText(filepath, jsonData);
        context.Cache.Remove(urlData);
    }

    public void WriteJson(List<dynamic> jsonData)
    {
        var data = JsonConvert.SerializeObject(jsonData);
        HttpContext context = HttpContext.Current;
        string filepath = context.Server.MapPath(Security.UrlBase() + "App_Data/JsonData/" + urlData + ".json");
        if (!File.Exists(filepath))
        {
            StreamWriter w = new StreamWriter(filepath, false, Encoding.UTF8);
            w.Flush();
            w.Close();
        }
        File.WriteAllText(filepath, data);
        context.Cache.Remove(urlData);
    }
    #endregion
}