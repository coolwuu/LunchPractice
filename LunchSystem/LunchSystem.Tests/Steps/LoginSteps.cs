using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace LunchSystem.Tests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private static ChromeDriver _driver = new ChromeDriver();
        private static string validLoginId;
        private static string validPassword;
        private static string invalidPassword;
        private static string unregisteredLoginId;

        public LoginSteps()
        {
            validLoginId = "TestWuu";
            validPassword = "Wuu12345";
            invalidPassword = "1234";
            unregisteredLoginId = "Wuu";
        }

        [Given(@"Entered to Login Page")]
        public void GivenEnteredToLoginPage()
        {
            _driver.Navigate().GoToUrl("http://localhost:50621/Account/Index");
        }

        [Given(@"see the login form")]
        public void GivenSeeTheLoginForm()
        {
            Assert.IsTrue(_driver.FindElement(By.Id("LoginForm")).Displayed);
        }

        [Given(@"key in Unregistered login id")]
        public void GivenKeyInUnregisteredLoginId()
        {
            _driver.FindElementById("LoginUsername").SendKeys(unregisteredLoginId);
        }

        [Given(@"key in login id")]
        public void GivenKeyInLoginId()
        {
            _driver.FindElementById("LoginUsername").SendKeys(validLoginId);
        }

        [Given(@"key in Password")]
        public void GivenKeyInPassword()
        {
            _driver.FindElementById("LoginPassword").SendKeys(validPassword);
        }

        [Given(@"key in Correct Password")]
        public void GivenKeyInCorrectPassword()
        {
            _driver.FindElementById("LoginPassword").SendKeys(validPassword);
        }

        [Given(@"key in Wrong Password")]
        public void GivenKeyInWrongPassword()
        {
            _driver.FindElementById("LoginPassword").SendKeys(invalidPassword);
        }

        [When(@"press login")]
        public void WhenPressLogin()
        {
            _driver.FindElementById("loginButton").Submit();
        }

        [Then(@"Should show need Register message")]
        public void ThenShouldShowNeedRegisterMessage()
        {
            var errorMessage = "You need to register an account.";
            Assert.AreEqual(errorMessage, _driver.FindElementById("errorMessage").Text);
        }

        [Then(@"Should show wrong password message")]
        public void ThenShouldShowWrongPasswordMessage()
        {
            var errorMessage = "Password incorrect!";
            Assert.AreEqual(errorMessage, _driver.FindElementById("errorMessage").Text);
        }

        [Then(@"Should redirect to Home Index")]
        public void ThenShouldRedirectToHomeIndex()
        {
            Assert.AreEqual("http://localhost:50621/Home", _driver.Url);
        }

        [AfterFeature()]
        public static void Close()
        {
            _driver.Quit();
        }
    }
}
