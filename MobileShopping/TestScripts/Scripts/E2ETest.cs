
using MobileShopping.GenericUtilities;
using MobileShopping.ObjectRepo;
using NUnit.Framework;
using OpenQA.Selenium;


namespace MobileShopping.TestScripts.Scripts
{
    [Parallelizable(ParallelScope.Self)]
    public class E2ETest : BaseClass
    {
        [Test,Category("regression")]
        
        public void EndToEndRegression()
        {
            //fetching data from Json
            String[] expectedProducts = reader.extractDataArray("products");
            String[] actualProducts = new string[2];
            LoginPage login = new LoginPage(driver.Value);
            login.validLogin(reader.extractData("username"), reader.extractData("password"));
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
            

           IList <IWebElement> checkoutCards = checkoutpage.getCards();

            for (int i = 0; i < checkoutCards.Count; i++)

            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);
            checkoutpage.checkOut();
            DeliveryLocationPage delivery=new DeliveryLocationPage(driver.Value);
            String confirmText = delivery.selectLocation(reader.extractData("locInitials"));
           StringAssert.Contains(reader.extractData("sucessText"), confirmText);
        }

     //running through DeveloperPowershell 
     // dotnet test MobileShopping.csproj --filter TestCategory=smoke --% -- TestRunParameters.Parameter(name=\"browserName\", value=\"Chrome\")

    }
}
 