using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTestUI.PageObjects;
using AcceptanceTestUI.Setup;
using OpenQA.Selenium;

namespace AcceptanceTestUI.Navigate
{
    public class NavigatePage
    {
        private IWebDriver driver = DriverManager.WebDriver;

        public HomePage NavigateHomePage()
        {
            driver.Navigate().GoToUrl("https://www.justgiving.com/");    

            return new HomePage();
        }

    }
}
