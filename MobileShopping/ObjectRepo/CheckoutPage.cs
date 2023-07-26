using System;
using System.Collections.Generic;
using OpenQA.Selenium;

using SeleniumExtras.PageObjects;

namespace MobileShopping.ObjectRepo
{
    internal class CheckoutPage
    {
        // IWebDriver driver;
        //driver.FindElements(By.CssSelector("h4 a"));
        public CheckoutPage(IWebDriver driver)
        {
            //  this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //By.CssSelector(".btn-success")
        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-success']")]
        private IWebElement checkoutButton;


        public IList<IWebElement> getCards()

        {

            return checkoutCards;
        }

        public void checkOut()
        {
            checkoutButton.Click();
            //object of next page


        }
    }
}
