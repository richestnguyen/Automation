using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.PageObjects
{
    public class ResultPage
    {

        private IWebDriver driver;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);            
        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"rso\"]/div/div/div[1]/div/div/h3/a")]
        private IWebElement FirstResult;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"rso\"]/div/div/div[2]/div/div/h3/a")]
        private IWebElement SecondResult;

        public void ClickOnFirstResultLink(int index)
        {
            string xpath = $"//*[@id=\"rso\"]/div/div/div[{index}]/div/div/h3/a";
            driver.FindElement(By.XPath(xpath)).Click();
        }


    }
}
