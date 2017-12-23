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
        public void GivenISeeTheLoginForm()
        {
            //
        }

        [Given(@"key in login id '(.*)'")]
        public void GivenIKeyInMyLoginId(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"key in Password '(.*)'")]
        public void GivenIKeyInMyPassword(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"press login")]
        public void WhenIPressLogin()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Should Popout HaventRegister error\.")]
        public void ThenShouldPopoutHaventRegisterError_()
        {
            ScenarioContext.Current.Pending();
        }

        [After("Login")]
        public void Close()
        {
            _driver.Quit();
        }
    }
}
