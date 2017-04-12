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
    public class BasketTests : TestFixtureBase
    {
        [Test,
        Description("Given I am on the site for the first time" +
                    "Then the basket is empty")]
        public void FirstTimeVisitingSiteBasketShouldBeEmpty()
        {
            //Arrange
            HomePage homePage = new HomePage(_webDriver);

            //Assert
            Assert.IsTrue(homePage.IsBasketEmpty());
        }

        [Test,
        Description("Given I am on the site for the first time" +
                    "Then I should not be logged in")]
        public void FirstTimeVisitingSiteUserShouldNotBeLoggedIn()
        {
            //Arrange
            HomePage homePage = new HomePage(_webDriver);

            //Assert
            Assert.IsFalse(homePage.IsUserLoggedIn());
        }

        [Test,
        Description("Given I am view a product " +
                    "When I add item to basket " +
                    "Then item is added to the basket")]
        public void AddItemToBasket()
        {
            //Arrange
            HomePage homePage = new HomePage(_webDriver);
            ProductPage productPage = homePage.ViewProduct();

            //Act
            productPage.AddItemToBasket();

            //Assert
            productPage.VerifyBasketCount(1);

        }

        [Test,
        Description("Given I have added an item to the basket " +
                    "When I request the item is removed " +
                    "Then the item is removed from the basket")]
        public void RemoveItemFromBasket()
        {
            //Arrange
            HomePage homePage = new HomePage(_webDriver);
            ProductPage productPage = homePage.ViewProduct();
            productPage.AddItemToBasket();
            CheckoutPage checkoutPage = productPage.ViewBasket();

            //Act
            checkoutPage.RemoveItemFromBasket();

            //Assert
            Assert.IsTrue(checkoutPage.IsBasketEmpty());

        } 
    }
}
