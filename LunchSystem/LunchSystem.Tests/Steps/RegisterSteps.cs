using System;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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

        // Scenario: Register failed with same username exist message

        [Given(@"click on register tab")]
        public void GivenClickOnRegisterTab()
        {
            _driver.FindElement(By.Id("registerLink")).Click();
        }

        [Given(@"can see register form")]
        public void GivenCanSeeRegisterForm()
        {
            Assert.IsEmpty(_driver.FindElement(By.Id("VerifyPassword")).Text);
        }

        [Given(@"key in invalid register information")]
        public void GivenKeyInRegisterInformation()
        {
            var registerName = "Wuu";
            var password = "12345";

            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            IWebElement element = wait.Until<IWebElement>((d) => d.FindElement(By.Id("RegisterUsername")));
            element.SendKeys(registerName);
            _driver.FindElementById("RegisterPassword").SendKeys(password);
            _driver.FindElementById("VerifyPassword").SendKeys(password);
        }
        [When(@"press Register")]
        public void WhenPressRegister()
        {
            _driver.FindElementById("registerButton").Submit();
        }

        [Then(@"should show '(.*)'")]
        public void ThenShouldShow(string errorMessage)
        {
            Assert.AreEqual("Same username exists! Please use a different username.", _driver.FindElementById("errorMessage").Text);
        }


        [AfterTestRun]
        public static void Close()
        {
            _driver.Quit();
        }
    }
}
