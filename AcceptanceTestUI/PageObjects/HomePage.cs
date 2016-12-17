using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcceptanceTestUI.Setup;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace AcceptanceTestUI.PageObjects
{
   public class HomePage : BasePage
    {
       public HomePage()
       {
             Assert.IsTrue(Wait.Until(ExpectedConditions.TitleIs("Online fundraising donations and ideas - JustGiving")));
        }

    }
}
