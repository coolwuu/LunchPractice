using System.Collections.Generic;
using System.Web.Mvc;
using LunchSystem.Controllers;
using LunchSystem.Interface;
using LunchSystem.Models;
using NSubstitute;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace LunchSystem.Tests.UnitTest
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void IndexWithOrderedMeals()
        {
            var controller = new HomeController();

            controller.LunchRepository = Substitute.For<ILunchRepository>();
            controller.LunchRepository.GetOrderedMeals().Returns(new List<OrderModels>{new OrderModels{Cost = 90, Meal = "Big Mac", MemberName = "Kiki"}});

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model); // add additional checks on the Model
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Index");
        }
    }
}
