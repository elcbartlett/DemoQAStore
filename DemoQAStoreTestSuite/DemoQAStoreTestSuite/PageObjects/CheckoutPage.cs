using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQAStoreTestSuite.PageObjects
{
    public class CheckoutPage : BasePage
    {
        private readonly IWebDriver _driver;

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;

            if (_driver.Title != "Checkout | ONLINE STORE")
            {
                throw new Exception(
                    "Expected to be on checkout page but instead on " + _driver.Url);
            }
        }

        public CheckoutPage RemoveItemFromBasket()
        {
            _driver.FindElement(By.ClassName("checkout_cart"))
                    .FindElement(By.XPath(".//input[@value='Remove']"))
                    .Click();
          
            return this;
        }

        public CheckoutInfoPage Continue()
        {
            _driver.FindElement(By.ClassName("step2")).Click();

            return new CheckoutInfoPage(_driver);
        }
    }
}
