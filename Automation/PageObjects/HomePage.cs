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
    public class HomePage : ScreenBase
    {
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
           // PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = @"//*[@id=""id_q""]")]
        public IWebElement SearchTextBox;

        [FindsBy(How = How.XPath, Using = @"//*[@id=""header_search_form""]/div/div/span/button")]
        public IWebElement SearchButton;

        public void DoSearch(string text)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(SearchTextBox).Perform();
            SearchTextBox.SlowTypingValue(text);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            SearchButton.Click();
        }

        public bool isDisplayed()
        {
            return false;
        }

    }
}
