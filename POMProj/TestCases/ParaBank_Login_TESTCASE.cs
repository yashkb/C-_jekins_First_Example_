
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMProj.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace POMProj.TestCases
{
    [Parallelizable(ParallelScope.All)]
    
    internal class ParaBank_Login_TESTCASE
    {
        public IWebDriver driver = null;
        public string url = "https://parabank.parasoft.com/parabank/index.htm";
        public ExtentReports extent;
        string path = @"C:\TestReport\report.html";
        
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            extent = new ExtentReports();
            var spark = new ExtentSparkReporter(path);
            spark.Config.Theme = Theme.Dark;
            spark.Config.DocumentTitle = "MyReport";
            extent.AttachReporter(spark);

        }
        [Test]
        public void TC_001_A()
        {
            var test = extent.CreateTest("TC_001_A - Verify Text");
            ParaBank_Login_PAGE obj = new ParaBank_Login_PAGE(driver);
            var text = "Expected Tex";
            obj.assertText();
            if (text.Equals("Expected Text"))
            {
                test.Log(Status.Pass, "Text is correct");
            }
            else
            {
                test.Log(Status.Fail, "Text is not correct. Expected: 'Expected Text', Actual: '" + text + "'");
            }
        }
        [Test] 
        public void TC_002_B()
        {
            ParaBank_Login_PAGE obj = new ParaBank_Login_PAGE(driver);
            obj.login();
            var test = extent.CreateTest("TC_002 - Login ");
            test.Log(Status.Pass, "Login Success");
        }
        [TearDown] 
        public void TearDown()
        {
            
            driver.Dispose();
            extent.Flush();
        }

    }
}
