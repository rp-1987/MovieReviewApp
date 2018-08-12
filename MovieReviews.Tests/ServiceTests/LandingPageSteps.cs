using System;
using TechTalk.SpecFlow;

namespace MovieReviews.Tests
{
    [Binding]
    public class LandingPageSteps
    {
        [Given(@"I have reached login page")]
        public void GivenIHaveReachedLoginPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I check all the movies")]
        public void WhenICheckAllTheMovies()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should view all the movies")]
        public void ThenIShouldViewAllTheMovies()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
