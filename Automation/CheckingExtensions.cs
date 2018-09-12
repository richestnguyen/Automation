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
    }
}
