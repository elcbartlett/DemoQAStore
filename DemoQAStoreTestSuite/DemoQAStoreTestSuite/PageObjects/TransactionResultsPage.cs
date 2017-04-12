using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQAStoreTestSuite.PageObjects
{
    public class TransactionResultsPage : BasePage
    {
        private readonly IWebDriver _driver;

        public TransactionResultsPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;

            if (_driver.Title != "Transaction Results | ONLINE STORE")
            {
                throw new Exception(
                    "Expected to be on transaction results page but instead on " + _driver.Url);
            }
        }

        public decimal GetTotalPrice()
        {
            var totalTextElement = _driver.FindElement(By.XPath("//p[text()[contains(.,'Total: ')]]"));
            var totalString = totalTextElement.Text.Split('$').Last();
            return decimal.Parse(totalString);
        }
    }



}

