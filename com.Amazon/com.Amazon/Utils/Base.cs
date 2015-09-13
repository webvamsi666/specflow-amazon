using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

// This is the helper class that will provide an instance of WebDriver and perform clean up activity at the end

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

        public static void GoToUrl(String url)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
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
