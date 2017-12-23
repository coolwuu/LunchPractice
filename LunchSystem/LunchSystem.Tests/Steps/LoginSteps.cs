﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LunchSystem.Tests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private ChromeDriver _driver = new ChromeDriver();

        [Given(@"Entered to Login Page")]
        public void GivenEnteredToLoginPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:50621/Login/Index");
        }

        [Given(@"see the login form")]
        public void GivenSeeTheLoginForm()
        {
            Assert.IsTrue(_driver.FindElement(By.Id("LoginForm")).Displayed);
        }

        [Given(@"key in login id '(.*)'")]
        public void GivenKeyInLoginId(string loginId)
        {
            _driver.FindElementById("LoginUserName").SendKeys(loginId);
        }

        [Given(@"key in Password '(.*)'")]
        public void GivenKeyInPassword(string password)
        {
            _driver.FindElementById("LoginPassword").SendKeys(password);
        }

        [When(@"press login")]
        public void WhenPressLogin()
        {
            _driver.FindElementById("LoginButton").Submit();
        }

        [Then(@"Should show need Register message")]
        public void ThenShouldShowNeedRegisterMessage()
        {
            ScenarioContext.Current.Pending();
        }

        //[After("Login")]
        //public void Close()
        //{
        //    _driver.Quit();
        //}
    }
}
