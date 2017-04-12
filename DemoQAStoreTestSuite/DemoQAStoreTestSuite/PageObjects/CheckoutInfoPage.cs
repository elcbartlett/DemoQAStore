using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQAStoreTestSuite.PageObjects
{
    public class CheckoutInfoPage : BasePage
    {
        private readonly IWebDriver _driver;

        public CheckoutInfoPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;

            if (_driver.Title != "Checkout | ONLINE STORE"
                && !_driver.FindElements(By.XPath(".//h2[text()='Calculate Shipping Price']")).Any())
            {
                throw new Exception(
                    "Expected to be on checkout info page but instead on " + _driver.Url);
            }
        }

        public CheckoutInfoPage FillInDetails()
        {
            var waitForTenSeconds = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            waitForTenSeconds.Until(ExpectedConditions.ElementIsVisible(By.Id("wpsc_checkout_form_9")));

            _driver.FindElement(By.Id("wpsc_checkout_form_9")).SendKeys("test@test.com");
            _driver.FindElement(By.Id("wpsc_checkout_form_2")).SendKeys("Ted");
            _driver.FindElement(By.Id("wpsc_checkout_form_3")).SendKeys("Tester");
            _driver.FindElement(By.Id("wpsc_checkout_form_4")).SendKeys("12 Test Road");
            _driver.FindElement(By.Id("wpsc_checkout_form_5")).SendKeys("Test City");
            _driver.FindElement(By.Id("wpsc_checkout_form_6")).SendKeys("Test");

            SelectElement select = new SelectElement(_driver.FindElement(By.Id("wpsc_checkout_form_7")));
            select.SelectByText("United Kingdom");

            _driver.FindElement(By.Id("wpsc_checkout_form_18")).SendKeys("07900123456");

            var billingAddressIsSame = _driver.FindElement(By.Id("shippingSameBilling"));
            if (billingAddressIsSame.GetAttribute("value") == "false")
            {
                billingAddressIsSame.Click();
            }
            return this;
        }

        public TransactionResultsPage Purchase()
        {
            _driver.FindElement(By.ClassName("input-button-buy"))
                    .FindElement(By.Name("submit"))
                    .Click();

            return new TransactionResultsPage(_driver);
        }
    }
}

