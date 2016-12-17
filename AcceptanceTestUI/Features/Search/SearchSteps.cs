using TechTalk.SpecFlow;
using AcceptanceTestUI.Navigate;
using AcceptanceTestUI.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcceptanceTestUI.Features.Search
{
    [Binding]
    public sealed class SearchSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            new NavigatePage().NavigateHomePage();
        }

        [When(@"I enter ""(.*)"" in the search bar")]
        public void WhenIEnterInTheSearchBar(string searchvalue)
        {
            new BasePage().SearchForValue(searchvalue);
        }

        [Then(@"I expect more than 1 result to come back on the Search result page")]
        public void ThenIExpectMoreThanResultToComeBackOnTheSearchResultPage()
        {
          var resultcount =  new SearchResultsPage().CountResults();
            Assert.IsTrue(resultcount > 0);
        }

        [Then(@"I expect No results to be displayed on the Search result page")]
        public void ThenIExpectNoResultsToBeDisplayedOnTheSearchResultPage()
        {
            var resultcount = new SearchResultsPage().CountResults();
            Assert.IsTrue(resultcount == 0);

            Assert.IsTrue(new SearchResultsPage().NoResultsText().Contains("No results"));
        }
    }
}
