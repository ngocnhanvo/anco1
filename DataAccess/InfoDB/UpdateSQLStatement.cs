using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace InfoDB
{
    public class UpdateSQLStatement : Infomation
    {
        List<string> lstModels;
        public UpdateSQLStatement()
        {
            lstModels = new List<string>();
        }

        public string WriteSQLAlterTableAddColumn(int? type)
        {
            var lst = new List<string>();
            lst.Add($"declare @dbname nvarchar(200) = (SELECT DB_NAME() AS[Current Database]);");
            lst.Add($"if (@dbname = '{InitialCatalog}')");
            lst.Add($"begin");
            lst.Add($"RAISERROR(N'Có thể bạn đã chọn nhầm DB để thực thi lệnh này', 16, 1)");
            lst.Add($"end");
            lst.Add($"else");
            lst.Add($"begin");
            lst.Add($@"SET NOCOUNT ON;");




            DataTable tables = getAllTable(null);
            foreach (DataRow table in tables.Rows)
            {
                var tableName = table["name"].ToString();

                string strTable = "";
                strTable += $"IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = '{tableName}')) begin ";
                strTable += $"CREATE TABLE {tableName}(idForCreateTable_____ int); ";
                strTable += $"end ";
                lst.Add($@"{strTable}");

                DataTable columnsInTable = getAllColumns(tableName, null);
                foreach (DataRow column in columnsInTable.Rows)
                {
                    var columnName = column["name"].ToString();
                    var columnType = column["DATA_TYPE"].ToString();
                    var columnLength = string.IsNullOrWhiteSpace(column["CHARACTER_MAXIMUM_LENGTH"] + "") ? "" : column["CHARACTER_MAXIMUM_LENGTH"] + "";
                    var columnNumberLength1 = string.IsNullOrWhiteSpace(column["NUMERIC_PRECISION"] + "") ? "" : column["NUMERIC_PRECISION"] + "";
                    var columnNumberLength2 = string.IsNullOrWhiteSpace(column["NUMERIC_SCALE"] + "") ? "" : column["NUMERIC_SCALE"] + "";

                    var lstTypeNotLength = new List<string>();
                    lstTypeNotLength.Add("int");
                    lstTypeNotLength.Add("bigint");
                    lstTypeNotLength.Add("datetime");
                    lstTypeNotLength.Add("float");
                    lstTypeNotLength.Add("ntext");
                    lstTypeNotLength.Add("bit");

                    if (lstTypeNotLength.Contains(columnType))
                        columnLength = "";
                    else
                    {
                        if (string.IsNullOrEmpty(columnLength))
                        {
                            if (string.IsNullOrEmpty(columnNumberLength1) | string.IsNullOrEmpty(columnNumberLength2))
                                columnLength = "";
                            else
                            {
                                columnLength = $"({columnNumberLength1},{columnNumberLength2})";
                            }
                        }
                        else
                        {
                            columnLength = $"({ (columnLength == "-1" ? "MAX" : columnLength) })";
                        }
                    }

                    var columnNull = (column["IS_NULLABLE"] + "") == "YES" ? "NULL" : "NOT NULL";
                    var columnKey = (column["COLUMN_KEY"] + "").StartsWith("PK_") ? true : false;
                    var uniqueKey = (column["COLUMN_KEY"] + "").StartsWith("UQ_") ? true : false;

                    string strColumn = "";
                    strColumn += $"IF(NOT EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'{columnName}' AND Object_ID = Object_ID(N'dbo.{tableName}'))) begin ";
                    strColumn += $"ALTER TABLE {tableName} ADD {columnName} {columnType}{columnLength} {columnNull}; ";
                    strColumn += $"end ";
                    strColumn += $"ELSE begin ";
                    strColumn += $"ALTER TABLE {tableName} alter column {columnName} {columnType}{columnLength} {columnNull}; ";
                    strColumn += $"end ";
                    lst.Add($@"{strColumn}");

                    string strKey = "";
                    if (columnKey)
                    {
                        strKey += $"IF (OBJECT_ID('dbo.[PK_{tableName}]', 'PK') IS NOT NULL) begin ";
                        strKey += $"ALTER TABLE {tableName} DROP CONSTRAINT [PK_{tableName}]; ";
                        strKey += $"ALTER TABLE {tableName} ADD CONSTRAINT [PK_{tableName}] PRIMARY KEY CLUSTERED ([{columnName}] ASC) ";
                        strKey += $"WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]; ";
                        strKey += $"end ";
                        strKey += $"ELSE begin ";
                        strKey += $"ALTER TABLE {tableName} ADD CONSTRAINT [PK_{tableName}] PRIMARY KEY CLUSTERED ([{columnName}] ASC) ";
                        strKey += $"WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]; ";
                        strKey += $"end ";
                    }
                    else if (uniqueKey)
                    {
                        strKey += $"IF (OBJECT_ID('dbo.[UQ_{tableName}_{columnName}]', 'UQ') IS NOT NULL) begin ";
                        strKey += $"ALTER TABLE {tableName} DROP CONSTRAINT [UQ_{tableName}_{columnName}]; ";
                        strKey += $"ALTER TABLE {tableName} ADD CONSTRAINT [UQ_{tableName}_{columnName}] UNIQUE ([{columnName}]) ";
                        strKey += $"end ";
                        strKey += $"ELSE begin ";
                        strKey += $"ALTER TABLE {tableName} ADD CONSTRAINT [UQ_{tableName}_{columnName}] UNIQUE ([{columnName}]) ";
                        strKey += $"end ";
                    }
                    lst.Add($@"{strKey}");
                }

                strTable = "";
                strTable += $"IF(EXISTS(SELECT 1 FROM sys.columns WHERE Name = N'idForCreateTable_____' AND Object_ID = Object_ID(N'dbo.{tableName}'))) begin ";
                strTable += $"ALTER TABLE {tableName} DROP COLUMN idForCreateTable_____ ";
                strTable += $"end ";
                lst.Add(strTable);
            }

            DataTable chkConstraintsAll = getALLCheckConstraints();
            foreach (DataRow check in chkConstraintsAll.Rows)
            {
                var tblName = check["tblName"].ToString();
                var chkName = check["chkName"].ToString();
                var definition = check["definition"].ToString();

                var strCheck = "";
                strCheck += $"IF(OBJECT_ID(N'dbo.[{chkName}]', 'C') is not null) ";
                strCheck += $"ALTER TABLE[dbo].[{tblName}] DROP CONSTRAINT[{chkName}]; ";

                strCheck += $"ALTER TABLE[dbo].[{tblName}] ";
                strCheck += $"WITH CHECK ADD CONSTRAINT[{chkName}] CHECK({definition}); ";

                strCheck += $"ALTER TABLE[dbo].[{tblName}] CHECK CONSTRAINT[{chkName}]; ";
                strCheck += $"EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'{chkName}' , @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'{tblName}', @level2type = N'CONSTRAINT', @level2name = N'{chkName}'; ";
                lst.Add(strCheck);
            }

            var tableAds = new List<string>();
            tableAds.Add("ad_menu");
            tableAds.Add("ad_module");
            tableAds.Add("ad_case");
            tableAds.Add("ad_column");
            tableAds.Add("ad_editstyle");
            tableAds.Add("ad_formatter");
            tableAds.Add("ad_import_ava");
            tableAds.Add("ad_import_column");
            tableAds.Add("ad_import_ex");
            tableAds.Add("ad_remove");
            tableAds.Add("ad_removeline");
            tableAds.Add("ad_selectoption");
            tableAds.Add("ad_avariableSQL");
            tableAds.Add("ad_selectop_save");

            foreach (var tableAd in tableAds)
            {
                string strTableAd = "";
                strTableAd += $"truncate table {tableAd}; ";
                strTableAd += $"insert into {tableAd} select * from {InitialCatalog}.dbo.{tableAd}; ";
                lst.Add(strTableAd);
            }

            lst.Add($"insert into ad_role select * from {InitialCatalog}.dbo.ad_role where {InitialCatalog}.dbo.ad_role.ad_role_id not in (select ad_role_id from ad_role);");
            lst.Add($"insert into ad_role_mmc select * from {InitialCatalog}.dbo.ad_role_mmc where {InitialCatalog}.dbo.ad_role_mmc.ad_role_mmc_id not in (select ad_role_mmc_id from ad_role_mmc);");
            lst.Add($"insert into ad_role_mmcol select * from {InitialCatalog}.dbo.ad_role_mmcol where {InitialCatalog}.dbo.ad_role_mmcol.ad_role_mmcol_id not in (select ad_role_mmcol_id from ad_role_mmcol);");
            lst.Add($"insert into ad_role_where select * from {InitialCatalog}.dbo.ad_role_where where {InitialCatalog}.dbo.ad_role_where.ad_role_where_id not in (select ad_role_where_id from ad_role_where);");
            lst.Add($"insert into ad_user select * from {InitialCatalog}.dbo.ad_user where {InitialCatalog}.dbo.ad_user.ad_user_id not in (select ad_user_id from ad_user);");
            lst.Add($"insert into ad_user_mmc select * from {InitialCatalog}.dbo.ad_user_mmc where {InitialCatalog}.dbo.ad_user_mmc.ad_user_mmc_id not in (select ad_user_mmc_id from ad_user_mmc);");
            lst.Add($"insert into ad_user_role select * from {InitialCatalog}.dbo.ad_user_role where {InitialCatalog}.dbo.ad_user_role.ad_user_role_id not in (select ad_user_role_id from ad_user_role);");
            lst.Add($"insert into ad_department select * from {InitialCatalog}.dbo.ad_department where {InitialCatalog}.dbo.ad_department.md_phongban_id not in (select md_phongban_id from ad_department);");

            lst.Add($@"SET NOCOUNT OFF;");
            lst.Add($"end");

            string filepath = "";
            filepath = $"{AppDomain.CurrentDomain.BaseDirectory}";
            filepath += $"\\App_Data\\from{InitialCatalog}.sql";

            if (!File.Exists(filepath))
            {
                StreamWriter w = new StreamWriter(filepath, false, Encoding.UTF8);
                w.Flush();
                w.Close();
            }

            File.WriteAllText(filepath, string.Join(Environment.NewLine, lst));

            return filepath;
        }
    }
}
