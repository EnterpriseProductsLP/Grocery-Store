using System;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class SaleTestss
    {
        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            DealProvider.ClearDeals();
            _sale = new Sale();
        }

        [Test]
        public void SaleWithThreeBananasAndBuyTwoGetOneFreeDealAppliedHasTheCorrectPrice()
        {
            DealProvider.AddDeal("1245", new BuySomeGetOneFreeDeal(2));
            this._sale.AddItem("1245");
            this._sale.AddItem("1245");
            this._sale.AddItem("1245");

            var bananas = this._sale.LineItems.Single(lineItem => lineItem.Sku == "1245");
            bananas.Quantity.Should().Be(3);

            this._sale.Total.Should().Be(2 * 1.25M);
        }
    }
}
