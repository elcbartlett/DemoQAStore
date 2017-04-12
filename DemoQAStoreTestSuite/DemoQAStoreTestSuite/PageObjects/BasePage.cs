using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQAStoreTestSuite.PageObjects
{
    

    public abstract class BasePage
    {
        private readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool IsBasketEmpty()
        {
            return GetBasketCount() == 0;
        }

        public int GetBasketCount()
        {
            return int.Parse(_driver.FindElement(By.ClassName("count")).Text);
        }

        public void VerifyBasketCount(int expectedBasketCount)
        {
            var waitForTenSeconds =
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            Assert.IsTrue(waitForTenSeconds.Until(
                webdriver => GetBasketCount() == expectedBasketCount));
        }

        public CheckoutPage ViewBasket()
        {
            var waitForTenSeconds =
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            _driver.FindElement(By.ClassName("cart_icon")).Click();

            return new CheckoutPage(_driver);
        }

    }
}
