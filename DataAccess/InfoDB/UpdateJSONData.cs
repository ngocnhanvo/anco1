using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace InfoDB
{
    public class UpdateJSONData : Infomation
    {
        List<string> lstModels;
        public UpdateJSONData()
        {
            lstModels = new List<string>();
        }

        public string WriteObject(string table, int? type)
        {
            DataTable tables = getValueTable(table);
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
            foreach (DataRow row_ in tables.Rows)
            {
                Dictionary<string, object> item = new Dictionary<string, object>();
                foreach (DataColumn column_ in tables.Columns)
                {
                    item[column_.ColumnName] = row_[column_.ColumnName];
                }
                lst.Add(item);
            }
            //Dictionary<string, object> itemTT = new Dictionary<string, object>();
            //itemTT["Count"] = lst.Count;
            //lst.Add(itemTT);
            string filepath = "";
            if (type == 1)
            {
                filepath = $"{AppDomain.CurrentDomain.BaseDirectory}";
                filepath = filepath.Replace("\\GenerateModels\\", "");
                filepath = filepath.Replace("\\Publish_GenerateModels\\", "");
                filepath += $"\\eman_ver3\\App_Data\\JsonData\\{table}.json";
            }
            else
            {
                filepath = $"{AppDomain.CurrentDomain.BaseDirectory}";
                filepath += $"\\App_Data\\JsonData.json";
            }
            WriteJson(filepath, lst);

            return filepath;
        }

        private void WriteJson(string filepath, List<Dictionary<string, object>> lst)
        {
            if (!File.Exists(filepath))
            {
                StreamWriter w = new StreamWriter(filepath, false, Encoding.UTF8);
                w.Flush();
                w.Close();
            }

            string Content = JsonConvert.SerializeObject(lst, Formatting.Indented);
            File.WriteAllText(filepath, Content);
        }

        public string BetweenStrings(string text, string start, string end)
        {
            String result = "";
            try
            {
                int pFrom = text.IndexOf(start) + start.Length;
                int pTo = text.LastIndexOf(end);

                result = text.Substring(pFrom, pTo - pFrom);
            }
            catch { }
            return result.Trim();
        }
    }
}
