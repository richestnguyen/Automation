using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using Shouldly;

namespace Automation
{
    public static class CheckingExtensions
    {
        public static void TitleBarShouldBe(this ScreenBase t, string screenUrl) 
        {
            t.driver.Title.ShouldBe(screenUrl);
        } 

        //public static ValidateElementIsPresent(IWebDriver driver, By element)
        //{
        //    driver.FindElement(element).Displayed.ShouldBe(true);
        //}

        //public static ValidateTextInElement(IWebDriver driver, By element, String text)
        //{
        //    driver.FindElement(element).Text.ShouldBe(text);
        //} 
    }
}
