using AventStack.ExtentReports;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileShopping.GenericUtilities
{
    public class WebDriverUtility 
    {
        IWebDriver driver;
        WebDriverWait wait;
        public void maximizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public void implicitWait(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public void waitForPageDisplay(IWebDriver driver)

        {

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
        }
        public void waitForCountryList(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            \751
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));

        }
        public MediaEntityModelProvider captureScreenShot(IWebDriver driver,string testMethod)
        {
            ITakesScreenshot takesScreenshot =  (ITakesScreenshot)(driver);
           string screenshot= takesScreenshot.GetScreenshot().AsBase64EncodedString;
           return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, testMethod).Build();
        }
       

    }
}
