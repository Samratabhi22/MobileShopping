using AngleSharp.Html.Dom.Events;
using MobileShopping.GenericUtilities;
using MobileShopping.ObjectRepo;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MobileShopping.TestScripts.Scripts
{
    [Parallelizable(ParallelScope.Children)]
    public class OpenForcefullLinkTest : BaseClass
    {
       [Test]
       public void validateForcefulLink()
        {
            IWebElement blinkingElement=driver.Value.FindElement(By.CssSelector("a[class='blinkingText']"));
            Actions act = new Actions(driver.Value);
            //control will be on child tab 
            act.Click(blinkingElement).Perform();

            //control will be on child tab 
            //act.KeyDown(Keys.Control).KeyDown(Keys.Shift).Click(blinkingElement).Perform();

            //control will be on parent tab                                  
            // act.KeyDown(Keys.Control).Click(blinkingElement).Perform();

            //control will be on childWindow
            // act.KeyDown(Keys.Shift).Click(blinkingElement).Perform();
            TestContext.Out.WriteLine(driver.Value.Title);

           
        }

       [Test,Category("adhoc")]
        public void InvalidLoginTesting()
        {
            LoginPage login = new LoginPage(driver.Value);
            login.validLogin(reader.extractData("username_wrong"), reader.extractData("password_wrong"));
           // wdu.waitForPageDisplay(driver);
            TestContext.Out.WriteLine(driver.Value.Title);    
        }



    }
}
