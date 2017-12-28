using System.Collections.Generic;
using System.Web.Mvc;
using LunchSystem.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LunchSystem.Tests.Steps
{
    [Binding]
    public class MenuSteps
    {
        private static ChromeDriver _driver = new ChromeDriver();

        private readonly string _username;
        private readonly string _password;

        public MenuSteps()
        {
            _username = "Wuu";
            _password = "Wuu12345";
        }

        [Given(@"enter Lunch Website")]
        public void GivenIHaveEnteredWebsite()
        {
            _driver.Navigate().GoToUrl("http://localhost:50621");
        }

        [Given(@"login")]
        public void GivenLogin()
        {
            _driver.FindElementById("LoginUsername").SendKeys(_username);
            _driver.FindElementById("LoginPassword").SendKeys(_password);
            _driver.FindElementById("loginButton").Submit();
            
        }


        [Given(@"can see the menu")]
        public void GivenISeeTheMenu()
        {
            //
        }


        [Given(@"Key in '(.*)' in Name")]
        public void GivenIKeyInMyName(string userName)
        {
            _driver.FindElement(By.Id("MemberName")).SendKeys(userName);
        }

        [Given(@"Key in '(.*)' in Meal")]
        public void GivenIKeyIn(string meal)
        {
            _driver.FindElement(By.Id("Meal")).SendKeys(meal);
        }

        [Given(@"Key the money '(.*)' in Cost")]
        public void GivenIKeyTheMoney(int money)
        {
            _driver.FindElement(By.Id("Cost")).SendKeys(money.ToString());
        }

        [When(@"press Ok")]
        public void WhenIPressOk()
        {
            _driver.FindElementById("submit").Click();
        }

        [Then(@"able to see order list")]
        public void ThenIShouldAbleToSeeMyOrderList()
        {
            IList<IWebElement> rows = _driver.FindElementById("OrderTable").FindElements(By.TagName("tr"));
            var lastRow = rows[rows.Count - 1];
            Assert.AreEqual("Wuu Big Mac 90", lastRow.Text);
        }

        [After("Order")]
        public static void Close()
        {
            _driver.Quit();
        }
    }
}
