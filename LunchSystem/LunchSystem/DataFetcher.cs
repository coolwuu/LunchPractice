using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace LunchSystem
{
    public static class DataFetcher
    {
        private const string ConnStr = "Data Source=TI03BY20\\SQL2014;Initial Catalog=LunchDB;Persist Security Info=True;User ID=kiki;Password=kiki;Pooling=true;min pool size=4;max pool size=100;";
        public static IEnumerable<T> Query<T>(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            var result = conn.Query<T>(sql);
            conn.Close();
            return result;
        }

        public static void Execute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                conn.Execute(sql);
            }
        }
    }
}