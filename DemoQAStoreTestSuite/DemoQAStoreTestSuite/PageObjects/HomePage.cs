using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQAStoreTestSuite.PageObjects
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;

            if (_driver.Title != "ONLINE STORE | Toolsqa Dummy Test site")
                throw new Exception(
                    "Expected to be on home page but instead on " + _driver.Url);
        }

        public bool IsUserLoggedIn()
        {
            return _driver.FindElements(By.Id("account_logout")).Count() == 1;
        }

        public ProductPage ViewProduct()
        {
            var productLink = 
                _driver.FindElement(By.ClassName("footer_featured"))
                       .FindElements(By.TagName("li"))
                       .First()
                       .FindElement(By.TagName("a"));

            var productName = productLink.GetAttribute("title");

            productLink.Click();
                        
            return new ProductPage(_driver, productName);
        }

    }
}
