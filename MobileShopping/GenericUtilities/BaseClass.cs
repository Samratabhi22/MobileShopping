using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace MobileShopping.GenericUtilities
{

    public class BaseClass
    {
       public WebDriverUtility wdu = new WebDriverUtility();
        public JsonReader reader = new JsonReader();
        //public IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void oneTimeLaunch()
        {
            //string workingDirectory = Environment.CurrentDirectory;
            //TestContext.Out.WriteLine(workingDirectory);
            //string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            //TestContext.Out.WriteLine(projectDirectory);
            // string reportPath = projectDirectory + "Results\\Reports\\index.html";
            string reportPath = "C:\\Users\\Hp\\source\\repos\\MobileShopping\\MobileShopping\\Results\\Reports\\index.html";
            TestContext.Out.WriteLine(reportPath);
            var htmlReporter=new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name","Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("OS Name", "Microsoft Windows 10 Pro");
            extent.AddSystemInfo("QA Name", "Abhishek Kumar");

        }
        String browserName;
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver> ();
        
        [SetUp]
        public void launchBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.MethodName);
            browserName = TestContext.Parameters["browserName"];
            if (browserName == null)
            {
                browserName = ConfigurationManager.AppSettings["browser"];
            }
            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;


                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver.Value = new EdgeDriver();
                    break;

                default:
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver();
                    break;

            }
            wdu.maximizeWindow(driver.Value);
            wdu.implicitWait(driver.Value);
            driver.Value.Url = "https://rahulshettyacademy.com/loginpagePractise/";
           
        }
        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime dateTime = DateTime.Now;
            string screenShotName = "Screenshot_" + dateTime.ToString("hh_mm_ss") + ".png";
            if(status==TestStatus.Failed)
            {
                test.Fail("Test failed",wdu.captureScreenShot(driver.Value, screenShotName));
                test.Log(Status.Fail,"test failed with logTrace "+stackTrace);
            }
            else if(status==TestStatus.Skipped)
            {
                test.Skip("Test got skipped");
                test.Log(Status.Skip,"failed with logTrace "+stackTrace);
            }
            else
            {
                test.Pass("Test Passed");
                test.Log(Status.Pass);
            }
            extent.Flush();
            driver.Value.Quit();
        }
        

        [OneTimeTearDown]
        public void closeBrowser()
        {
           //driver.Value.Quit();  
        }

    }
}
