using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Automation.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation
{
    public static class AutomationExtensions
    {
        public static IWebDriver driver;
        public static void GoToPage(this ScreenBase t, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void DoSearch(this HomePage t, string text)
        {
            Actions action  = new Actions(driver);
            action.MoveToElement(t.SearhTextBox).Perform();
            t.SearhTextBox.SendKeys(text);
            Thread.Sleep(1000);
            action.MoveToElement(t.SearchButton).Perform();
            t.SearchButton.Click();
        }

        public static void ClickElement(IWebDriver driver, By element)
        {
            driver.FindElement(element).Click();
        }

        public static void SendKeys(IWebDriver driver, By element, string keys)
        {
            driver.FindElement(element).SendKeys(keys);
        }

        public static void SlowTypingValue(this IWebElement t, string text, int speed = 100)
        {
            foreach (var c in text)
            {
                t.SendKeys(c.ToString());
                Thread.Sleep(speed);
            }
        }

    }
}
