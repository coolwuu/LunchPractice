using System.Collections.Generic;
using LunchSystem.Models;

namespace LunchSystem.Interface
{
    public interface ILunchRepository
    {
        IEnumerable<Order> GetOrderedMeals();

        void Order(string memberName, string meal, string cost);
        IEnumerable<OrdersSummaryViewModel> GetOrdersSummary();
        void AccountIsValid(string loginUserName);
    }
}