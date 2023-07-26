using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MobileShopping.ObjectRepo
{
    internal class DeliveryLocationPage
    {
        public DeliveryLocationPage(IWebDriver driver)
        {
          
            PageFactory.InitElements(driver, this);
        }
        //  driver.FindElement(By.Id("country")).SendKeys("ind");
        //  driver.FindElement(By.LinkText("India")).Click();
        //driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
        //driver.FindElement(By.CssSelector("[value='Purchase']")).Click();
        //String confirText = driver.FindElement(By.CssSelector(".alert-success")).Text;


        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement countryText;

        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement countryName;
        [FindsBy(How = How.CssSelector, Using = "[value='Purchase']")]
        private IWebElement PurchaseButton;
        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement SucessText;

        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2']")]
        private IWebElement checkbox;


        public string selectLocation(String country)
        {
            countryText.SendKeys(country);
            countryName.Click();
            checkbox.Click();
            PurchaseButton.Click();
            String text = SucessText.Text;
            return text;
        }
        public void selectCountry()
        {
            countryName.Click();
        }
    }
}
