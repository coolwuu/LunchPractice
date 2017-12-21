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
            return DataFetcher.Query<Order>("SELECT OrderId,MemberName,Meal,Cost,CreatedOn,LastModifiedOn \r\nFROM Orders WITH(NOLOCK)\r\nWHERE DAY(createdon) = Day(getdate())");
        }

        public void Order(string memberName, string meal, string cost)
        {
            DataFetcher.Execute($"insert into Orders(MemberName,Meal,Cost) \r\n select '{memberName}','{meal}',{cost}");
        }

        public IEnumerable<OrdersSummary> GetOrdersSummary()
        {
            return DataFetcher.Query<OrdersSummary>(
                "SELECT Meal, COUNT(1) as [count], SUM(Cost) as Total\r\n" +
                "FROM orders WITH(NOLOCK)\r\n" +
                "WHERE DAY(createdon) = Day(getdate())\r\n" +
                "GROUP BY Meal\r\n" +
                "ORDER BY Meal");
        }
    }
}