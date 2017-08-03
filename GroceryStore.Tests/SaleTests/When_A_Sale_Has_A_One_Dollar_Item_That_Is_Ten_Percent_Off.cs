using System;
using FluentAssertions;
using GroceryStore.Deals;
using GroceryStore.Domain;
using NUnit.Framework;

namespace GroceryStore.Tests.SaleTests
{
    [TestFixture]
    public class When_A_Sale_Has_An_Item_That_Is_Ten_Percent_Off
    {
        private DealConfigurator _dealConfigurator;
        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Arrange ----------------------------------------------------------------
            // 1. Item configured with a 10% discount.
            _dealConfigurator = new DealConfigurator();
            _dealConfigurator.AddDeal("1245", new TenPercentDiscountDeal());

            // 2. A sale
            _sale = new Sale(_dealConfigurator);
            // ------------------------------------------------------------------------
            
            // Act --------------------------------------------------------------------
            // 1. Add an item with the ten percent discount to the sale.
            _sale.AddItem("1245");
        }

        [Test]
        public void The_Sale_Total_Should_Be_90_Percent_Of_The_Item_Price()
        {
            var bananas = ItemBuilder.BuildItem("1245");
            var priceOfBananas = bananas.Price;
            var expectedSaleTotal = Math.Round(priceOfBananas * 0.9M, 2);
            _sale.Total.Should().Be(expectedSaleTotal);
        }
    }
}