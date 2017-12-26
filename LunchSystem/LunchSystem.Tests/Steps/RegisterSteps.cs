using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LunchSystem.Tests.Steps
{
    [Binding]
    public class RegisterSteps
    {
        private static ChromeDriver _driver = new ChromeDriver();

        [Given(@"Entered to Login Page for Register")]
        public void GivenEnteredToLoginPageForRegister()
        {
            _driver.Navigate().GoToUrl("http://localhost:50621/Account/Index");
        }

        [When(@"click on register tab")]
        public void WhenClickOnRegisterForm()
        {
            _driver.FindElement(By.Id("registerLink")).Click();
            
        }

        [Then(@"can see register form")]
        public void ThenCanSeeRegisterForm()
        {
            Assert.IsEmpty(_driver.FindElement(By.Id("VerifyPassword")).Text);
        }

        [AfterFeature("RegisterSteps")]
        public static void Close()
        {
            _driver.Quit();
        }
    }
}
