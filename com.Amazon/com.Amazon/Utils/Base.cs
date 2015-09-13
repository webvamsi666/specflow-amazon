using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace com.Amazon
{
    [Binding]
    public class Base
    {
        private static FirefoxDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                return driver ?? (driver = new FirefoxDriver());
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Driver.Close();
            Driver.Quit();
            driver = null;
        }
    }
}
