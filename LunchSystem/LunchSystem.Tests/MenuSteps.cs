using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LunchSystem.Tests
{
    [Binding]
    public class MenuSteps
    {
        private ChromeDriver _driver = new ChromeDriver();

        [Given(@"I have entered Website")]
        public void GivenIHaveEnteredWebsite()
        {
            _driver.Navigate().GoToUrl("http://localhost:50621/");
        }

        [Given(@"I see the menu")]
        public void GivenISeeTheMenu()
        {
            //
        }

        [Given(@"I Key in my name '(.*)'")]
        public void GivenIKeyInMyName(string userName)
        {
            _driver.FindElement(By.Id("MemberName")).SendKeys(userName);
        }

        [Given(@"I Key in '(.*)'")]
        public void GivenIKeyIn(string meal)
        {
            _driver.FindElement(By.Id("Meal")).SendKeys(meal);
        }

        [Given(@"I Key the money '(.*)'")]
        public void GivenIKeyTheMoney(int money)
        {
            _driver.FindElement(By.Id("Cost")).SendKeys(money.ToString());
        }

        [When(@"I press Ok")]
        public void WhenIPressOk()
        {
            _driver.FindElementById("submit").Click();
        }

        [Then(@"I should able to see my order list")]
        public void ThenIShouldAbleToSeeMyOrderList()
        {
            IList<IWebElement> rows = _driver.FindElementById("OrderTable").FindElements(By.TagName("tr"));
            Assert.AreEqual("Wuu Big Mac 90", rows[rows.Count-1].Text);
        }

        [After("Order")]
        public void Close()
        {
            _driver.Quit();
        }
    }
}
