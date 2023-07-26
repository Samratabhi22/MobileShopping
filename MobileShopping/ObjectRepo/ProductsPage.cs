using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace MobileShopping.ObjectRepo
{
    internal class ProductsPage
    {
        By cardTitle = By.CssSelector(".card-title a");
        By addToCart = By.CssSelector(".card-footer button");
        public ProductsPage(IWebDriver driver)
        {
            
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.PartialLinkText, Using = "Checkout")]
        private IWebElement checkoutButton;


        public IList<IWebElement> getCards()
        {

            return cards;
        }

        public By getCardTitle()
        {

            return cardTitle;
        }

        public void checkout()
        {

            checkoutButton.Click();
        }

        public By addToCartButton()
        {

            return addToCart;
        }









    }
}
