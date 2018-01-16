using System.Collections.Generic;
using LunchSystem.Models;

namespace LunchSystem.Interface
{
    public interface ILunchRepository
    {
        IEnumerable<OrderModels> GetOrderedMeals();

        void Order(string memberName, string meal, string cost);
        IEnumerable<OrdersSummaryViewModel> GetOrdersSummary();

        void Login(string userName, string password);
        void Register(string username, string password);
    }
}