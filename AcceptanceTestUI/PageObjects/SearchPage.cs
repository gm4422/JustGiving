using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTestUI.PageObjects
{
    public class SearchResultsPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "result")] private IList<IWebElement> _results;
        [FindsBy(How = How.TagName, Using = "h2")] private IWebElement _noResult;
        public SearchResultsPage()
        {
            Assert.IsTrue(Wait.Until(ExpectedConditions.TitleIs("Search - JustGiving")));
        }

        public int CountResults()
        {
           return _results.Count;

        }

        public string NoResultsText()
        {
            return _noResult.Text;
        }
    }
}
