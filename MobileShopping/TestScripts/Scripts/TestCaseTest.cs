using MobileShopping.GenericUtilities;
using MobileShopping.ObjectRepo;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShopping.TestScripts.Scripts
{
    [Parallelizable(ParallelScope.Children)]
    //runs all test in one class parallel
    public class TestCaseTest :BaseClass
    {
       [Test]
        [TestCase("rahulshettyacademy", "learning", "ind", "Success")]
        [TestCase("rahulshettyacademy", "learning", "ind", "Success")]
        [TestCase("rahulacademy", "learn", "ind", "Success")]
        [Parallelizable(ParallelScope.All)]
        //runs all data sets parallely

        public void dataProvider(string un, string pw, string locInitials, string sucessText)
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            LoginPage login = new LoginPage(driver.Value);
            login.validLogin(un, pw);
            wdu.waitForPageDisplay(driver.Value);
            ProductsPage productpage = new ProductsPage(driver.Value);
            IList<IWebElement> products = productpage.getCards();

            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(productpage.getCardTitle()).Text))

                {
                    product.FindElement(productpage.addToCartButton()).Click();
                }

            }
            productpage.checkout();

            CheckoutPage checkoutpage = new CheckoutPage(driver.Value);


            IList<IWebElement> checkoutCards = checkoutpage.getCards();

            for (int i = 0; i < checkoutCards.Count; i++)

            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);
            checkoutpage.checkOut();
            DeliveryLocationPage delivery = new DeliveryLocationPage(driver.Value);
            String confirmText = delivery.selectLocation(locInitials);
            StringAssert.Contains(sucessText, confirmText);
        }
       [Test,Category("smoke")]
        public void ValidLoginTesting()
        {
            LoginPage login = new LoginPage(driver.Value);
            login.validLogin(reader.extractData("username"), reader.extractData("password"));
            wdu.waitForPageDisplay(driver.Value);
            TestContext.Out.WriteLine(driver.Value.Title);
        }
    }
}
