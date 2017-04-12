using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQAStoreTestSuite
{
    public abstract class TestFixtureBase
    {
        protected IWebDriver _webDriver;

        [SetUp]
        public void SetUp()
        {
            _webDriver = new FirefoxDriver();
            //_webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _webDriver.Navigate().GoToUrl("http://store.demoqa.com");
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Dispose();
            _webDriver = null;
        }

    }
}
