using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace com.Amazon.steps
{
    [Binding]
    public class AmazonShopSteps : Steps
    {
        #region "Object creation & instantiation"
        ProductDetailsPage _productDetailsPage = new ProductDetailsPage(Base.Driver);
        AmazonHomePage _homePage = new AmazonHomePage(Base.Driver);
        #endregion

        [Given(@"I am on Amazon home page")]
        public void GivenIAmOnAmazonHomePage()
        {
            Base.GoToUrl("https://www.amazon.co.uk/");
        }

        [When(@"I enter ""(.*)"" name into the search field")]
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
          Assert.IsTrue(_homePage.AssertBookFromResultsList(bookName)); 
        }

        [Given(@"I have nothing in my basket, it displays a total of ""(.*)""")]
        public void GivenIHaveNothingInMyBasketItDisplaysATotalOf(String cartCount)
        {
            Given("I am on Amazon home page");
            Assert.AreEqual(cartCount, _productDetailsPage.CartCount.Text);
        }

        [When(@"I search for a ""(.*)"" in Amazon")]
        public void WhenISearchForAInAmazon(string bookName)
        {
            _homePage.SearchField.SendKeys(bookName);
            _homePage.SearchField.Submit();
            _homePage.SelectBookFromList(bookName);
        }

        [When(@"I see the details page of the ""(.*)""")]
        public void WhenISeeTheDetailsPageOfThe(string bookTitle)
        {
            Assert.AreEqual(bookTitle, _productDetailsPage.BookTitle.Text);
        }

        [When(@"I should see the book is ""(.*)""")]
        public void WhenIShouldSeeTheBookIs(String inStock)
        {
            Assert.AreEqual(inStock, _productDetailsPage.InStockMessage.Text);
        }

        [When(@"I add the book to the basket")]
        public void WhenIAddTheBookToTheBasket()
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
