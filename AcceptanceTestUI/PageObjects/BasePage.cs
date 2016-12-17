using System;
using AcceptanceTestUI.Setup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTestUI.PageObjects
{
   public class BasePage
   {
       public IWebDriver Driver = DriverManager.WebDriver;
       public WebDriverWait Wait;

        [FindsBy(How = How.Name, Using = "search")]
        private IWebElement Search;

        public BasePage()
       {
          PageFactory.InitElements(Driver,this);
          Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
       }
      
        public SearchResultsPage SearchForValue(string searchvalue)
        {
            Search.Click();
            Search.Clear();
            Search.SendKeys(searchvalue);
            Search.SendKeys(Keys.Enter);
            return new SearchResultsPage();
        }

    }
}
