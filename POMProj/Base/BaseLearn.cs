using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMProj.Base
{
    internal class BaseLearn
    {
        [ThreadStatic]
        public IWebDriver _driver;
        public string baseUrl = "https://parabank.parasoft.com/parabank/index.htm";
        [SetUp] 
        public virtual void SetUp() 
        {
            Console.WriteLine("Driver Setup");
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(baseUrl);
        }
        [TearDown]
        public virtual void TearDown()
        {
            Console.WriteLine("Driver Disposed");
            _driver.Dispose();
        }


    }
}
