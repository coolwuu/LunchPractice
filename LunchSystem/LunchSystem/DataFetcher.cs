using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace LunchSystem
{
    public static class DataFetcher
    {
        private static string ConnStr = ConfigurationManager.AppSettings["LunchDB"];


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