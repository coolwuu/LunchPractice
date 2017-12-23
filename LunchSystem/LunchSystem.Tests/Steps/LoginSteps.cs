using TechTalk.SpecFlow;

namespace LunchSystem.Tests.Steps
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I see the login form")]
        public void GivenISeeTheLoginForm()
        {
            //
        }

        [Given(@"I key in my login id '(.*)'")]
        public void GivenIKeyInMyLoginId(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I key in my Password '(.*)'")]
        public void GivenIKeyInMyPassword(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Should Popout HaventRegister error\.")]
        public void ThenShouldPopoutHaventRegisterError_()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
