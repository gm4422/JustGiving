using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using AcceptanceTestUI.Setup;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AcceptanceTestUI.Hooks
{
    [Binding]
    public sealed class SpecflowHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
           if  (ScenarioContext.Current.ScenarioInfo.Tags.Contains("Chrome")) new DriverManager().SetWebdriver("Chrome");
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("IE")) new DriverManager().SetWebdriver("IE");

        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                ITakesScreenshot takesScreenshot = DriverManager.WebDriver as ITakesScreenshot;

                var screenshot = takesScreenshot.GetScreenshot();

                var dateNow = DateTime.Now.ToString(("yyyyMMdd"));

                string screenshotFilePath = @"c:\temp\" + $"{ScenarioContext.Current.ScenarioInfo.Title}_{dateNow} _screenshot.png";

                screenshot.SaveAsFile(screenshotFilePath, ImageFormat.Png);

                Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
            }

            new DriverManager().WebDriverQuit();
        }
    }
}
