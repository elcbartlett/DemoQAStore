using DemoQAStoreTestSuite.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQAStoreTestSuite
{
    [TestFixture]
    public class CheckoutTests : TestFixtureBase
    {
        [Test,
        Description("Given I have an item in Basket " +
                    "When I checkout " +
                    "Then I am presented with a summary of my order")]
        public void CheckoutSummary()
        {
            //Arrange
            HomePage homePage = new HomePage(_webDriver);
            ProductPage productPage = homePage.ViewProduct();
            productPage.AddItemToBasket();
            CheckoutPage checkoutPage = productPage.ViewBasket();
            CheckoutInfoPage checkoutInfoPage = checkoutPage.Continue();

            //Act
            checkoutInfoPage.FillInDetails();
            TransactionResultsPage transactionResultsPage = checkoutInfoPage.Purchase();

            //Assert
            Assert.Greater(transactionResultsPage.GetTotalPrice(), 0);
            
        }

    }
}
