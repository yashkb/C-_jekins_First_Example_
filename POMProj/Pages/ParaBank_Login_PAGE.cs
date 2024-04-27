using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using POMProj.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace POMProj.Pages
{
    [TestFixture]
    internal class ParaBank_Login_PAGE 
    {
        public IWebDriver _driver;
        public string url = "https://parabank.parasoft.com/parabank/index.htm";
        public String name = "Yash";
        public ParaBank_Login_PAGE(IWebDriver driver) 
        {
            _driver = driver;
        }
        

        public void assertText()
        {
            IWebElement head2 = _driver.FindElement(By.CssSelector("div[id='leftPanel'] h2"));
            Console.WriteLine(head2.Text);
            String actual = head2.Text;
            if (head2.Displayed)
            {
                Console.WriteLine("Yes");
            }
            //Assert.That(actual, Is.EqualTo("Customer Login"));
            Assert.That(actual, Does.Contain("Customer"));
            Console.WriteLine("String print"+name);
        }

        public void login()
        {
            IWebElement username = _driver.FindElement(By.CssSelector("input[name='username']"));
            IWebElement password = _driver.FindElement(By.CssSelector("input[name='password']"));
            username.SendKeys("SachinTen");
            password.SendKeys("Sachin@123");
            IWebElement loginBtn = _driver.FindElement(By.CssSelector("input[value='Log In']"));
            loginBtn.Click();
        }

       


    }
}
