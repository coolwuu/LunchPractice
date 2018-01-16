using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Dapper;
using LunchSystem.Interface;
using LunchSystem.Models;

namespace LunchSystem.Repo
{
    public class LunchRepository : ILunchRepository
    {
        private static string ConnStr = ConfigurationManager.AppSettings["LunchDB"];

        public IEnumerable<OrderModels> GetOrderedMeals()
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                var sql = @"SELECT OrderId,MemberName,Meal,Cost,CreatedOn,LastModifiedOn
                            FROM Orders WITH(NOLOCK)
                            WHERE DAY(createdon) = Day(GETDATE())";
                connection.Open();
                return connection.Query<OrderModels>(sql);
            }

        }

        public void Order(string memberName, string meal, string cost)
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                var sql = @"insert into Orders(MemberName,Meal,Cost)
                            Values( @memberName,@meal,@cost)";
                connection.Open();
                connection.Execute(sql, new
                {
                    memberName,
                    meal,
                    cost
                });
            }
        }

        public IEnumerable<OrdersSummaryViewModel> GetOrdersSummary()
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                var sql = @"SELECT Meal, COUNT(1) as [count], SUM(Cost) as Total
                            FROM orders WITH(NOLOCK)
                            WHERE DAY(createdon) = Day(getdate())
                            GROUP BY Meal
                            ORDER BY Meal";
                connection.Open();
                return connection.Query<OrdersSummaryViewModel>(sql);
            }
        }

        public void Login(string userName, string password)
        {
            var account = AccountIsValid(userName).First();
            if(account.Password != CryptoHelper.Encrypt(password))
                throw new Exception("Password incorrect!");

        }

        public void Register(string registerUsername, string registerPassword)
        {
            
            using (var connection = new SqlConnection(ConnStr))
            {
                connection.Open();
                try
                {
                    connection.Execute("dbo.[Lunch_Account_Register_17.12]", new
                    {
                        registerUsername,
                        registerPassword = CryptoHelper.Encrypt(registerPassword)
                    },commandType: CommandType.StoredProcedure);

                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                } 
            }
                
        }

        private static IEnumerable<AccountModels> AccountIsValid(string loginUserName)
        {

            using (var connection = new SqlConnection(ConnStr))
            {
                connection.Open();
                var result = connection.Query<AccountModels>("[dbo].[Lunch_Account_CheckAccountIsValid_17.12]", new
                {
                    loginUserName
                }, commandType: CommandType.StoredProcedure);

                if (!result.Any())
                {
                    throw new Exception("You need to register an account.");
                }
                return result;
            };

        }
    }

    internal static class CryptoHelper
    {
        private static readonly SHA256 Sha256 = new SHA256CryptoServiceProvider();

        public static string Encrypt(string password)
        {
            return Convert.ToBase64String(Sha256.ComputeHash(Encoding.Default.GetBytes(password)));
        }   
    }

}