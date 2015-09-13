using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace com.Amazon
{
    public class AmazonHomePage
    {
        public AmazonHomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#twotabsearchtextbox")]
        public IWebElement SearchField { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".a-size-medium.a-color-null.s-inline.s-access-title.a-text-normal")]
        public IList<IWebElement> ResultsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#nav-cart-count")]
        public IWebElement CartCount { get; set; }

        public void AssertBookFromResultsList(String bookName)
        {
            foreach (IWebElement option in ResultsList)
            {
                if (option.Text.Equals(bookName))
                {
                    Assert.IsTrue(option.Text.Equals(bookName));
                    break;
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        public void SelectBookFromList(String bookName)
        {
            foreach (IWebElement book in ResultsList)
            {
                if (book.Text.Contains(bookName))
                {
                    book.Click();
                    break;
                }
            }
        }
    }
}

