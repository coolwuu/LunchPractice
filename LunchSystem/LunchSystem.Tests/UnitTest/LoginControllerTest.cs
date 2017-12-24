using System.Collections.Generic;
using System.Web.Mvc;
using LunchSystem.Controllers;
using LunchSystem.Interface;
using LunchSystem.Models;
using NSubstitute;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using FluentAssertions;

namespace LunchSystem.Tests.UnitTest
{
    [TestFixture]
    public class LoginControllerTest
    {
        [Test]
        public void LoginFailedWithRegisterMessage()
        {
            var controller = new LoginController();
            var viewmodel = new LoginViewModel()
            {
                
                LoginUsername = "Wuu",
                LoginPassword = "1234"
            };

            controller._lunchRepository = Substitute.For<ILunchRepository>();
            controller._lunchRepository.AccountIsValid(viewmodel.LoginUsername).Returns(false);
            var result = controller.Login(viewmodel) as ViewResult;
            Assert.AreEqual("You need to register an account.",viewmodel.Message);
            result.Should().NotBeNull();
            result.ViewName.Should().Be("Index");
        }
    }
}
