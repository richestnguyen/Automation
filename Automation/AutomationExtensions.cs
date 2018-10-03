using System;
using System.Threading;
using Automation.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

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
            action.MoveToElement(t.SearchTextBox).Perform();
            t.SearchTextBox.SendKeys(text);
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

        public static IWebElement WaitForElement(this IWebDriver t, By by, TimeSpan timeoutInSeconds)
        {
            if (timeoutInSeconds.Seconds > 0)
            {
                var wait = new WebDriverWait(t, TimeSpan.FromSeconds(timeoutInSeconds.Seconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return t.FindElement(by);
        }

    }
}
