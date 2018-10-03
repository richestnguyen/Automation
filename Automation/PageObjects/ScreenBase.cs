using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Automation.PageObjects
{
    public class ScreenBase
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        public void ClickOnElementWhenClickable(IWebElement element)
        {
            element.Click();
        }
    }
}
