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
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = @"//*[@id=""lst-ib""]")]
        public IWebElement SearhTextBox;

        [FindsBy(How = How.XPath, Using = @".//*[@id='tsf']/div[2]/div[3]/center/input[1]")]
        public IWebElement SearchButton;

        public void DoSearch(string text)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(SearhTextBox).Perform();
            SearhTextBox.SlowTypingValue(text);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            action.SendKeys(Keys.Tab).Build().Perform();
            action.MoveToElement(SearchButton).Perform();
            SearchButton.Click();
        }

        public bool isDisplayed()
        {
            return false;
        }
    }
}
