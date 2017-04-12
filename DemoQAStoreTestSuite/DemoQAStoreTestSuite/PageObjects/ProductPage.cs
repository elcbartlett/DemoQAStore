using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQAStoreTestSuite.PageObjects
{
    public class ProductPage : BasePage
    {
        private readonly IWebDriver _driver;

        public ProductPage(IWebDriver driver, string productName) : base(driver)
        {
            _driver = driver;

            if (!_driver.Title.Contains(productName))
            {
                throw new Exception(
                    "Expected to be on product page but instead on " + _driver.Url);
            }
                //.Title != productName + " | ONLINE STORE" 
               // && _driver.Title != productName + "  | ONLINE STORE"
        }
        
        public ProductPage AddItemToBasket()
        {
            _driver.FindElement(By.Name("Buy")).Click();
            var waitTenSeconds = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            waitTenSeconds.Until(ExpectedConditions.ElementExists(By.LinkText("Continue Shopping")));
            _driver.FindElement(By.LinkText("Continue Shopping")).Click();

            waitTenSeconds.Until(
                ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("popup")));

            return this;
        }
 
    }
}
