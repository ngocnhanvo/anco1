using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Xml.Linq;
using System.Linq;
namespace InfoDB
{
    public class Infomation
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public Infomation()
        {
            if (string.IsNullOrEmpty(DataSource) |
                string.IsNullOrEmpty(InitialCatalog) |
                string.IsNullOrEmpty(UserID) |
                string.IsNullOrEmpty(Password)
            )
            {
                string filepath = $"{System.AppDomain.CurrentDomain.BaseDirectory}";
                filepath = filepath.Replace($"\\GenerateModels\\", "");
                filepath = filepath.Replace($"\\Publish_GenerateModels\\", "");
                filepath = filepath.Replace($"\\eman_ver3\\", "");

                filepath += $"\\eman_ver3\\Web.config";
                var xmlStr = File.ReadAllText(filepath);
                var str = XElement.Parse(xmlStr);
                var result = str.Elements("connectionStrings");
                foreach (var a in result)
                {
                    var result2 = a.Elements("add");
                    foreach (var b in result2)
                    {
                        var name = b.Attribute("name").Value;
                        var connectionString = b.Attribute("connectionString").Value;

                        if (name == "edoc2014ConnectionString")
                        {
                            string[] lstStr = connectionString.Split(';');
                            foreach (string c in lstStr)
                            {
                                if (c.Contains("Data Source="))
                                {
                                    DataSource = c.Replace("Data Source=", "");
                                }
                                else if (c.Contains("Initial Catalog="))
                                {
                                    InitialCatalog = c.Replace("Initial Catalog=", "");
                                }
                                else if (c.Contains("User ID="))
                                {
                                    UserID = c.Replace("User ID=", "");
                                }
                                else if (c.Contains("Password="))
                                {
                                    Password = c.Replace("Password=", "");
                                }
                            }
                        }
                    }
                }
            }
        }

        public string getConnectStr()
        {
            string connecStr = $@"Data Source={DataSource};Initial Catalog={InitialCatalog}; User ID={UserID};Password={Password};Persist Security Info=True";
            return connecStr;
        }

        public string getConnectStr2()
        {
            var ProviderConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = DataSource,
                InitialCatalog = InitialCatalog,
                IntegratedSecurity = false,
                UserID = UserID,
                Password = Password,
                ConnectTimeout = 30
            }.ConnectionString;
            return ProviderConnectionString;
        }

        public DataTable getAllTable(string table)
        {
            string whereEx = "";
            if (!string.IsNullOrEmpty(table))
            {
                whereEx = $"and TABLE_NAME = N'{table}'";
            }

            MSSQL mssqlDB = new MSSQL();
            string sql_table = $@"
                SELECT 
                    TABLE_NAME as value, 
                    TABLE_NAME as name 
                FROM [{InitialCatalog}].INFORMATION_SCHEMA.TABLES 
                WHERE TABLE_TYPE = 'BASE TABLE' {whereEx}
                ORDER BY TABLE_NAME asc";
            var dt = mssqlDB.GetData(sql_table);
            return dt;
        }

        public DataTable getAllColumns(string table, string column)
        {
            string whereEx = "";
            if (!string.IsNullOrEmpty(column))
            {
                whereEx = $"and col.column_name = N'{column}'";
            }

            MSSQL mssqlDB = new MSSQL();
            string sql_table = $@"
                select 
                col.column_name as value,
                col.column_name as name,
                col.column_name, 
                col.IS_NULLABLE, 
                col.DATA_TYPE, 
                ku.CONSTRAINT_NAME as COLUMN_KEY, 
                col.CHARACTER_MAXIMUM_LENGTH,
                COLUMNPROPERTY(object_id(col.TABLE_SCHEMA + '.' + col.TABLE_NAME), col.COLUMN_NAME, 'IsIdentity') as Isidentity
                from [{InitialCatalog}].information_schema.columns as col
                left join [{InitialCatalog}].INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS ku on ku.table_name = col.table_name and ku.column_name = col.column_name
                WHERE col.table_name = N'{table}' {whereEx}
                order by col.column_name
            ";
            var dt = mssqlDB.GetData(sql_table);
            return dt;
        }

        public DataTable getValueTable(string table)
        {
            string sql = string.Format("select * from {0} with (nolock)", table);
            MSSQL mssqlDB = new MSSQL();
            var dt = mssqlDB.GetData(sql);
            return dt;
        }
    }
}
