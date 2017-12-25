using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using LunchSystem.Controllers;
using LunchSystem.Interface;
using LunchSystem.Models;
using NSubstitute;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using FluentAssertions;
using Moq;
using NSubstitute.ExceptionExtensions;

namespace LunchSystem.Tests.UnitTest
{
    [TestFixture]
    public class LoginControllerTest
    {
        public LoginController Controller;
        [SetUp]
        public void SetUp()
        {
            Controller = new LoginController();
        }

        [Test]
        public void LoginFailedWithRegisterMessage()
        {
            var viewModel = new LoginViewModel()
            {

                LoginUsername = "LoginFailAccount",
                LoginPassword = "1234"
            };

            SetILunchRepositoryWithThrewException(viewModel);
            var result = Controller.Login(viewModel) as ViewResult;

            Assert.AreEqual("You need to register an account.", viewModel.Message);
            result.Should().NotBeNull();
            result.ViewName.Should().Be("Index");
        }

        [Test]
        public void LoginSuccessWithRedirectToIndex()
        {

            var viewModel = new LoginViewModel()
            {

                LoginUsername = "Wuu",
                LoginPassword = "Wuu12345"
            };

            SetControllerContext();
            SetILunchRepository();

            var result = Controller.Login(viewModel) as RedirectToRouteResult;

            Assert.IsTrue((bool?) Controller.Session["auth"]);
            result.Should().NotBeNull();
            result?.RouteValues["controller"].Should().Be("Home");
            result?.RouteValues["action"].Should().Be("Index");
        }

        private void SetILunchRepository()
        {
            Controller.LunchRepository = Substitute.For<ILunchRepository>();
        }

        private void SetControllerContext()
        {
            var controllerContext = Substitute.For<ControllerContext>();
            controllerContext.HttpContext.Session["auth"].Returns(true);
            Controller.ControllerContext = controllerContext;
        }

        private void SetILunchRepositoryWithThrewException(LoginViewModel viewModel)
        {
            Controller.LunchRepository = Substitute.For<ILunchRepository>();
            Controller.LunchRepository.When(x => x.Login(viewModel.LoginUsername, viewModel.LoginPassword))
                .Do(x => throw new Exception("You need to register an account."));
        }
    }
}
