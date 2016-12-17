using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace AcceptanceTestUI.Setup
{
    public class DriverManager
    {
        public static IWebDriver WebDriver;

        public void SetWebdriver(string browserToTest)
        {
            switch (browserToTest)
            {
                case "Chrome":
                    WebDriver = new ChromeDriver();
                    break;
                case "IE":
                      WebDriver = new InternetExplorerDriver();
                    break;
            }

        }

        public void WebDriverQuit()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }

    }
}
