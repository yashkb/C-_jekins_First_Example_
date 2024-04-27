using CsvHelper;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using POMProj.Base;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMProj.Pages
{
    internal class GooglePage
    {
        
        public  static IWebDriver _driver = null;
        
        public GooglePage(IWebDriver driver)
        {
            _driver = driver;
            
        }
        public IWebElement searchBox => _driver.FindElement(By.Name("q"));
        
        

        public void enterValue(string value)
        {
            searchBox.SendKeys(value);
        }
        public void clickSearch()
        {
            Actions actions = new Actions(_driver);
            actions.KeyDown(Keys.Enter);
            
        }
        public string getSearchBoxValue()
        {
            WebDriverWait wait = new WebDriverWait(_driver,TimeSpan.FromSeconds(10));
            IWebElement searchBox_on_Main_Page = _driver.FindElement(By.Id("APjFqb"));
            wait.Until(ExpectedConditions.ElementToBeClickable(searchBox_on_Main_Page));
            string text = searchBox_on_Main_Page.GetAttribute("value");

            Console.WriteLine("Str "+text);
            return text;
        }

        public void navigateCheck()
        {
            
            enterValue("Abc");
            clickSearch();
            _driver.Navigate().Back(); 
        }

        public void getAttribute()
        {
            enterValue("Virat");
            clickSearch();
        }

        public void multipleSearch()
        {
            IWebElement search = _driver.FindElement(By.Name("q"));
            search.SendKeys("A");
            Actions actions = new Actions(_driver);
            actions.KeyDown(Keys.Enter);
            Console.WriteLine("Multipl Search Ended");
        }
        public static string filePath = @"C:\TestReport\ddt\ddt_data.xlsx";
        public static IEnumerable<TestCaseData> GetTestData()
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
            {
                foreach (var record in csv.GetRecords<dynamic>())
                {
                    yield return new TestCaseData(record);
                }
            }
        }
        public void waitForSearch()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("APjFqb")));
            Console.WriteLine("Multipl Search Wait");
        }
        
    }
}
