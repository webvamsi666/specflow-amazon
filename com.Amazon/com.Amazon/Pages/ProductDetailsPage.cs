using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace com.Amazon
{
    public class ProductDetailsPage
    {
        public ProductDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#productTitle")]
        public IWebElement BookTitle { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".a-size-medium.a-color-success")]
        public IWebElement InStockMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#add-to-cart-button")]
        public IWebElement AddToBasketButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#nav-cart-count")]
        public IWebElement CartCount { get; set; }
    }
}

