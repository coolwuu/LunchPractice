using System.Collections.Generic;
using System.Data;
using LunchSystem.Interface;
using LunchSystem.Models;

namespace LunchSystem.Repo
{
    public class LunchRepository : ILunchRepository
    {
        public IEnumerable<Order> GetOrderedMeals()
        {
            var sql = @"SELECT OrderId,MemberName,Meal,Cost,CreatedOn,LastModifiedOn
                        FROM Orders WITH(NOLOCK)
                        WHERE DAY(createdon) = Day(GETDATE())";
            return DataFetcher.Query<Order>(sql);
        }

        public void Order(string memberName, string meal, string cost)
        {
            DataFetcher.Execute($"insert into Orders(MemberName,Meal,Cost) \r\n select '{memberName}','{meal}',{cost}");
        }

        public IEnumerable<OrdersSummary> GetOrdersSummary()
        {
            var sql = @"SELECT Meal, COUNT(1) as [count], SUM(Cost) as Total
                        FROM orders WITH(NOLOCK)
                        WHERE DAY(createdon) = Day(getdate())
                        GROUP BY Meal
                        ORDER BY Meal";
            return DataFetcher.Query<OrdersSummary>(sql);
        }
    }
}