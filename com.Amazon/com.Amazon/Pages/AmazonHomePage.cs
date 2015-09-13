using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

// This is a Pageobject pattern file for Amazon home Page

namespace com.Amazon
{
    public class AmazonHomePage
    {
        public AmazonHomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region "Page Elements"
        [FindsBy(How = How.CssSelector, Using = "#twotabsearchtextbox")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".a-size-medium.a-color-null.s-inline.s-access-title.a-text-normal")]
        public IList<IWebElement> ResultsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#nav-cart-count")]
        public IWebElement CartCount { get; set; }
        #endregion

        #region "Page methods"
        public Boolean AssertBookFromResultsList(String bookName)
        {
            foreach (IWebElement book in ResultsList)
            {
                if (book.Text.Equals(bookName))
                {
                    return true;            
                }
            }
            return false;
        }

        public void SelectBookFromList(String bookName)
        {
            foreach (IWebElement book in ResultsList)
            {
                if (book.Text.Contains(bookName))
                {
                    book.Click();
                    return;
                }
            }
        }
        #endregion
    }
}

