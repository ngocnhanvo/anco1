using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace InfoDB
{
    public class UpdateEntityFramework : Infomation
    {
        List<string> lstModels;
        public UpdateEntityFramework()
        {
            lstModels = new List<string>();
        }

        public void WriteAllObject()
        {
            DataTable tables = getAllTable(null);
            List<string> lst = new List<string>();
            foreach (DataRow row_table in tables.Rows)
            {
                string tableName = row_table["value"].ToString();
                WriteObject1Table(tableName);
            }
            RewriteModelsDB();
            //autoInclude();
        }

        public void WriteOneObject(string table)
        {
            DataTable tables = getAllTable(table);

            foreach (DataRow row_table in tables.Rows)
            {
                string tableName = row_table["value"].ToString();
                WriteObject1Table(tableName);
            }
            RewriteModelsDB();
            //autoInclude();
        }

        public void RewriteModelsDB()
        {
            string DbSet = "", modelBuilder = "";
            DataTable tables = getAllTable(null);
            foreach (DataRow row_table in tables.Rows)
            {
                string tableName = row_table["value"].ToString();
                string tableFix = fixTable(tableName);

                string entityModel = "", keyModel = "";
                DataTable columns = getAllColumns(tableName, null);
                foreach (DataRow row_column in columns.Rows)
                {
                    string ten_column = row_column[2].ToString(),
                        null_column = row_column[3].ToString(),
                        loai_column = row_column[4].ToString(),
                        key = row_column[5].ToString(),
                        length = row_column[6].ToString();

                    string columnFix = fixColumn(ten_column);

                    if (loai_column == "decimal" | loai_column == "numeric")
                    {
                        entityModel += $@"
                            modelBuilder.Entity<{tableFix}>()
                            .Property(p => p.{columnFix})
                            .HasColumnName(""{ten_column}"")
                            .HasColumnType(""{loai_column}"").HasPrecision(18, 4);";
                    }
                    else
                    {
                        entityModel += $@"
                            modelBuilder.Entity<{tableFix}>()
                            .Property(p => p.{columnFix})
                            .HasColumnName(""{ten_column}"")
                            .HasColumnType(""{loai_column}"");";
                    }
                    

                    //if (!string.IsNullOrEmpty(length))
                    //{
                    //    entityModel += $@".HasMaxLength({length});";
                    //}
                    //else
                    //{
                    //    entityModel += $@";";
                    //}

                    if (key.ToUpper().Contains("PK_"))
                    {
                        string systemType = getSystemTypes(loai_column, null_column);
                        entityModel += $@"
                            modelBuilder.Entity<{tableFix}>().HasKey<{systemType}>(p => p.{columnFix});";
                        keyModel = "Yes";
                    }
                }

                if (!string.IsNullOrEmpty(keyModel))
                {
                    modelBuilder += $@"
                        modelBuilder.Entity<{tableFix}>().ToTable(""{tableName}"");
                        {entityModel}
                    ";

                    DbSet += $@"
                            public virtual DbSet<{tableFix}> {tableFix} {{ get; set; }}
                        ";
                }
                else
                {
                    modelBuilder += $@"
                            //Unable to generate entity type for table 'dbo.{tableName}'. table have no primary key
                        ";

                    DbSet += $@"
                            //Unable to generate DBset for table 'dbo.{tableName}'. table have no primary key
                        ";
                }
                lstModels.Add(tableFix);
            }
            string Parent = $@"
            using System;
            using System.Data.Entity;
            using System.Data.Entity.ModelConfiguration.Conventions;
            namespace DataAcess
            {{
                public partial class EntityContext : DbContext
                {{
                    public EntityContext() : base(""edoc2014ConnectionString"")
                    {{
                    }}

                    {DbSet}
                    internal object Set()
                    {{
                        throw new NotImplementedException();
                    }}
                
                
                    protected override void OnModelCreating(DbModelBuilder modelBuilder)
                    {{
                        {modelBuilder}
                    }}
                }}
            }}
            ";

            string filepath = $"{System.AppDomain.CurrentDomain.BaseDirectory}";
            filepath = filepath.Replace("\\GenerateModels\\", "");
            filepath = filepath.Replace("\\Publish_GenerateModels\\", "");
            filepath += $"\\eman_ver3\\App_Code\\EntityFramework\\EntityContext.cs";
            Writelinq(filepath, Parent, new List<string>());
        }

        public string fixColumn(string column)
        {
            column = column.Replace(" ", "_");

            int number;
            bool success = int.TryParse(column.Substring(0, 1), out number);
            if (success == true)
            {
                column = "_" + column;
            }

            List<string> exceptionStr = new List<string>();
            exceptionStr.Add("fixed");
            exceptionStr.Add("string");
            exceptionStr.Add("int");
            if (exceptionStr.Contains(column))
            {
                column = "@" + column;
            }

            return column;
        }

        public string fixTable(string table)
        {
            table = table.Replace(" ", "_");

            int number;
            bool success = int.TryParse(table.Substring(0, 1), out number);
            if (success == true)
            {
                table = "_" + table;
            }
            return table;
        }

        public void WriteObject1Table(string table)
        {
            DataTable columns = getAllColumns(table, null);
            string tableFix = fixTable(table);
            string Detail = "";

            List<string> lst = new List<string>();
            foreach (DataRow row_column in columns.Rows)
            {
                string ten_column = row_column[2].ToString(),
                    null_column = row_column[3].ToString(),
                    loai_column = row_column[4].ToString();

                string columnFix = fixColumn(ten_column);

                if (loai_column == "tinyint")
                    loai_column = "bit";
                string systemType = getSystemTypes(loai_column, null_column);

                string v = $@"
                        #region {tableFix}_{columnFix}_wintaFN
                        //Code_{tableFix}_{columnFix}_wintaFN
                        #endregion {tableFix}_{columnFix}_wintaFN
                        public {systemType} {columnFix} {{ get; set; }}
                ";
                Detail += v + "\n\t\t\t\t\t\t";

                lst.Add($"{tableFix}_{columnFix}_wintaFN");
            }


            string Parent = $@"
                using System;
                using System.Collections.Generic;
                using System.ComponentModel.DataAnnotations.Schema;
                namespace DataAcess
                {{
                    public partial class {tableFix}
                    {{
                        {Detail}
                    }}
                }}
            ";



            string filepath = $"{System.AppDomain.CurrentDomain.BaseDirectory}";
            filepath = filepath.Replace("\\GenerateModels\\", "");
            filepath = filepath.Replace("\\Publish_GenerateModels\\", "");
            filepath += $"\\eman_ver3\\App_Code\\EntityFramework\\Objects\\{tableFix}.cs";
            Writelinq(filepath, Parent, lst);
        }

        private void Writelinq(string filepath, string kq, List<string> lst)
        {
            if (!File.Exists(filepath))
            {
                StreamWriter w = new StreamWriter(filepath, false, Encoding.UTF8);
                w.Flush();
                w.Close();
            }

            string oldContent = File.ReadAllText(filepath, Encoding.UTF8);
            foreach (string value in lst)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    string start = $"#region {value}";
                    string end = $"#endregion {value}";
                    string save = BetweenStrings(oldContent, start, end);

                    kq = kq.Replace($"//Code_{value}", save);
                }
            }
            File.WriteAllText(filepath, kq);
        }

        private void autoInclude()
        {
            string filepath = $"{System.AppDomain.CurrentDomain.BaseDirectory}";
            filepath = filepath.Replace("\\GenerateModels\\", "");
            filepath = filepath.Replace("\\Publish_GenerateModels\\", "");
            filepath += $"\\DataAccess\\Models\\Models.csproj";

            string oldContent = File.ReadAllText(filepath, Encoding.UTF8);
            string newContent = "";
            foreach (string table in lstModels)
            {
                if (!oldContent.Contains($@"Include=""Objects\{table}.cs"""))
                {
                    newContent += $@"<Compile Include=""Objects\{table}.cs"" />" + "\n";
                }
            }

            if (newContent != "")
            {
                newContent = "<!--Start Compile Winta-->\n" + newContent;
                oldContent = oldContent.Replace("<!--Start Compile Winta-->", newContent);
            }
            File.WriteAllText(filepath, oldContent);
        }

        public string getSystemTypes(string DBtypes, string nullAble)
        {
            string kq = "";
            if (DBtypes.Equals("varchar") | DBtypes.Equals("mediumtext") | DBtypes.Equals("longtext"))
            {
                kq = "string";
            }
            else if (DBtypes.Equals("datetime") | DBtypes.Equals("date") |
                DBtypes.Equals("datetime2") | DBtypes.Equals("smalldatetime")
                )
            {
                kq = "DateTime";
            }
            else if (DBtypes.Equals("datetimeoffset"))
            {
                kq = "DateTimeOffset";
            }
            else if (DBtypes.Equals("bit") | DBtypes.Equals("tinyint"))
            {
                kq = "bool";
            }
            else if (DBtypes.Equals("int") | DBtypes.Equals("smallint"))
            {
                kq = "int";
            }
            else if (DBtypes.Equals("bigint"))
            {
                kq = "long";
            }
            else if (DBtypes.Equals("decimal") | DBtypes.Equals("numeric") | DBtypes.Equals("money"))
            {
                kq = "Decimal";
            }
            else if (DBtypes.Equals("float") | DBtypes.Equals("double"))
            {
                kq = "Double";
            }
            else if (DBtypes.Equals("time"))
            {
                kq = "TimeSpan";
            }
            else if (DBtypes.Equals("image"))
            {
                kq = "byte[]";
            }
            else
            {
                kq = "string";
            }

            if (nullAble != "NO")
            {
                if (!"string".Contains(kq.ToLower()))
                {
                    if (kq != "byte[]")
                    {
                        kq = kq + "?";
                    }
                }
            }
            return kq;
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
