using System;
using TechTalk.SpecFlow;
using System.Threading;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace com.Amazon.steps
{
    [Binding]
    public class AmazonShopSteps : Steps
    {
        ProductDetailsPage _productDetailsPage = new ProductDetailsPage(Base.Driver);
        AmazonHomePage _homePage = new AmazonHomePage(Base.Driver);

        [Given(@"I am on Amazon home page")]
        public void GivenIAmOnAmazonHomePage()
        {
            Base.Driver.Navigate().GoToUrl("https://www.amazon.co.uk/");
            Base.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [When(@"I enter ""(.*)"" text into the search field")]
        public void WhenIEnterTextIntoTheSearchField(string bookName)
        {
            _homePage.SearchField.SendKeys(bookName);
        }

        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            _homePage.SearchField.Submit();
        }

        [Then(@"I should see my book ""(.*)"" in the results list")]
        public void ThenIShouldSeeMyBookInTheResultsList(string bookName)
        {
            _homePage.AssertBookFromResultsList(bookName);
        }

        [Given(@"I have nothing in my basket, it displays a total of ""(.*)""")]
        public void GivenIHaveNothingInMyBasketItDisplaysATotalOf(String cartCount)
        {
            Given("I am on Amazon home page");
            Assert.AreEqual(cartCount, _productDetailsPage.CartCount.Text);
        }

        [Given(@"I search for ""(.*)"" book in Amazon")]
        public void GivenISearchForBookInAmazon(string bookName)
        {
            _homePage.SearchField.SendKeys(bookName);
            _homePage.SearchField.Submit();
            _homePage.SelectBookFromList(bookName);
        }

        [Given(@"I see the details page of the ""(.*)""")]
        public void GivenISeeTheDetailsPageOfThe(string bookTitle)
        {
            Assert.AreEqual(bookTitle, _productDetailsPage.BookTitle.Text);
        }

        [Given(@"I should see the book is ""(.*)""")]
        public void GivenIShouldSeeTheBookIs(String inStock)
        {
            Assert.AreEqual(inStock, _productDetailsPage.InStockMessage.Text);
        }

        [Given(@"I add the book to the basket")]
        public void GivenIAddTheBookToTheBasket()
        {
            _productDetailsPage.AddToBasketButton.Click();
        }

        [Then(@"my basket should dispaly a total of ""(.*)""")]
        public void ThenMyBasketShouldDispalyATotalOf(String cartCount)
        {
            Assert.AreEqual(cartCount, _productDetailsPage.CartCount.Text);
        }
    }
}
