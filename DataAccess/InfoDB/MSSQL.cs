using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace InfoDB
{
    public class MSSQL
    {
        // Lay chuoi ket noi trong web.config
        // Tao va tra ve doi tuong SqlConnection
        public string nameDB = "";
        public Infomation info;
        public MSSQL()
        {
            info = new Infomation();
            this.nameDB = info.InitialCatalog;
        }


        public SqlConnection GetConnection
        {
            get
            {
                string connectionString = info.getConnectStr2();
                SqlConnection cnn = new SqlConnection(connectionString);
                return cnn;
            }
        }

        public void close_connection()
        {
            GetConnection.Close();
        }

        public SqlCommand CreateCommand(String sql, params object[] nameValue)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection);
            Command.CommandType = CommandType.Text;
            for (int i = 0; i < nameValue.Length; i += 2)
            {
                Command.Parameters.AddWithValue(nameValue[i].ToString(), nameValue[i + 1].ToString());
            }
            return Command;
        }

        public SqlCommand CreateCommand(String sql, bool procdure, params object[] nameValue)
        {
            SqlCommand Command = new SqlCommand(sql, GetConnection);
            Command.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < nameValue.Length; i += 2)
            {
                Command.Parameters.AddWithValue(nameValue[i].ToString(), nameValue[i + 1].ToString());
            }
            return Command;
        }

        public DataTable Fill(DataTable dt, String sql, params object[] nameValue)
        {
            SqlCommand cmd = CreateCommand(sql, nameValue);
            cmd.CommandTimeout = 60;
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable Fill(DataTable dt, String sql, bool procdure, params object[] nameValue)
        {
            SqlCommand cmd = CreateCommand(sql, true, nameValue);
            cmd.CommandTimeout = 60;
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable GetData(String sql, params object[] nameValue)
        {
            return Fill(new DataTable(), sql, nameValue);
        }

        public DataTable GetDataFromProcedure(String sql, params object[] nameValue)
        {
            return Fill(new DataTable(), sql, true, nameValue);
        }

        public int ExcuteNonQuery(String sql, params object[] nameValue)
        {
            SqlCommand cmd = CreateCommand(sql, nameValue);
            cmd.CommandTimeout = 60;
            cmd.Connection.Open();
            int rows = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return rows;
        }

        public string ExcuteNonQuery2(String sql, params object[] nameValue)
        {
            string a = "";
            SqlCommand cmd = CreateCommand(sql, nameValue);
            cmd.CommandTimeout = 60;
            cmd.Connection.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                a = ex.Message;
            }
            cmd.Connection.Close();
            return a;
        }

        public int ExcuteNonProcedure(String sql, params object[] nameValue)
        {
            SqlCommand cmd = CreateCommand(sql, true, nameValue);
            cmd.CommandTimeout = 60;
            cmd.Connection.Open();
            int rows = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return rows;
        }

        public SqlDataReader ExecuteReader(String sql, params object[] nameValue)
        {
            SqlCommand cmd = CreateCommand(sql, nameValue);
            cmd.CommandTimeout = 60;
            cmd.Connection.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            return rd;
        }

        // Lấy một giá trị đơn dựa vào câu lệnh sql và danh sách tham số
        public object ExecuteScalar(String sql, params object[] parameters)
        {
            SqlCommand cmd = CreateCommand(sql, parameters);
            cmd.CommandTimeout = 50000;
            cmd.Connection.Open();
            object value = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return value;
        }

        // Lấy một giá trị đơn dựa vào câu lệnh sql và danh sách tham số
        public object ExecuteScalarProcedure(String sql, params object[] parameters)
        {
            SqlCommand cmd = CreateCommand(sql, true, parameters);
            cmd.CommandTimeout = 60;
            cmd.Connection.Open();
            object value = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return value;
        }

        public string GetNewId()
        {
            string str = (string)ExecuteScalar("select replace(newid(), '-', '')");
            return str;
        }
    }
}

