using System;
using TechTalk.SpecFlow;

namespace LunchSystem.Tests.Steps
{
    [Binding]
    public class RestaurantSteps
    {
        [Given(@"login to lunch system")]
        public void GivenLoginToLunchSystem()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"click restaurant tab")]
        public void WhenClickRestaurantTab()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I can see upload page")]
        public void ThenICanSeeUploadPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
