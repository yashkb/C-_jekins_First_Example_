using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMProj.Base;
using POMProj.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMProj.TestCases
{
    [TestFixture]
    
    internal class googleTESTCASE 
    {
        
        IWebDriver driver;
        ExtentSparkReporter spark;
        ExtentReports extent;
        string path = @"C:\TestReport\report_V2.html";
        //ExtentTest test;
        

        [SetUp]
        public void setUp() 
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.google.com/";
            extent = new ExtentReports();
            spark = new ExtentSparkReporter(path);
            extent.AttachReporter(spark);

        }

        

        [Test] 
        public void TC_001_SearchGoogle()
        {
            var test = extent.CreateTest("TC_001_Search");
            var obj = new GooglePage(driver);
            obj.enterValue("Yash");
            obj.clickSearch();
            string acutal_Text = obj.getSearchBoxValue();
            Console.WriteLine("Actual txt"+acutal_Text);

            Assert.That(acutal_Text, Does.Contain("Yash"));
            test.Log(Status.Pass,"Text Match");
        }
        [Test]
        public void TC_002_Navigate()
        {
            var test = extent.CreateTest("TC_002-Navigation Actions");
            var obj = new GooglePage(driver);
            obj.navigateCheck();
            test.Log(Status.Pass, "Naivation Actions");
        }
        [Test]
        public void TC_003_Attribute()
        {
            var obj = new GooglePage(driver);
            obj.getAttribute();
        }

        [Test]
        
        public void TC_004_DDT_Test()
        {
            var obj = new GooglePage(driver);
            obj.multipleSearch();
            obj.waitForSearch();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            extent.Flush();
        }
    }
}
