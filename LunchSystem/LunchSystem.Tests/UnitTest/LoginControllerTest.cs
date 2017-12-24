using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LunchSystem.Controllers;
using LunchSystem.Interface;
using LunchSystem.Models;
using NSubstitute;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;

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

            controller.LunchRepository = Substitute.For<ILunchRepository>();
            controller.LunchRepository.When(x => x.AccountIsValid(viewmodel.LoginUsername)).Do( x => throw new Exception("You need to register an account."));
            var result = controller.Login(viewmodel) as ViewResult;
            Assert.AreEqual("You need to register an account.",viewmodel.Message);
            result.Should().NotBeNull();
            result.ViewName.Should().Be("Index");
        }
    }
}
