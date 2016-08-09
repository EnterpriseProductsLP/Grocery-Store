using System;
using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class SaleTests
    {
        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            _sale = new Sale();
        }

        [Test]
        public void CallingAddItemResultsInTheItemWithTheAppropriateSkuBeingAddedToTheSale()
        {
            Action action = () => _sale.AddItem("1245");
            action.ShouldNotThrow();
            _sale.LineItems.Count.Should().Be(1);

            var lineItem = _sale.LineItems.Single();
            lineItem.Quantity.Should().Be(1);
            lineItem.Subtotal.Should().Be(1.25M);
            _sale.Total.Should().Be(1.25M);
        }

        [Test]
        public void SaleWithOneOfEachItemHasTheCorrectPrice()
        {
            _sale.AddItem("1245");
            _sale.AddItem("99999");
            _sale.AddItem("839");

            var bananas = _sale.LineItems.Single(lineItem => lineItem.Sku == "1245");
            var peptoBismol = _sale.LineItems.Single(lineItem => lineItem.Sku == "99999");
            var rubberBands = _sale.LineItems.Single(lineItem => lineItem.Sku == "839");
            var expectedTotal = 1.25M + 4.88M + 10M;

            _sale.LineItems.Count.Should().Be(3);
            _sale.Total.Should().Be(expectedTotal);

            bananas.Subtotal.Should().Be(1.25M);
            peptoBismol.Subtotal.Should().Be(4.88M);
            rubberBands.Subtotal.Should().Be(10M);
        }

        [Test]
        public void SaleWithTwoOfEachItemHasTheCorrectPrice()
        {
            _sale.AddItem("1245");
            _sale.AddItem("1245");

            _sale.AddItem("99999");
            _sale.AddItem("99999");

            _sale.AddItem("839");
            _sale.AddItem("839");

            var bananas = _sale.LineItems.Single(lineItem => lineItem.Sku == "1245");
            var peptoBismol = _sale.LineItems.Single(lineItem => lineItem.Sku == "99999");
            var rubberBands = _sale.LineItems.Single(lineItem => lineItem.Sku == "839");
            var expectedTotal = (2 * 1.25M) + (2 * 4.88M)
                                + (2 * 10M);

            _sale.LineItems.Count.Should().Be(3);
            _sale.Total.Should().Be(expectedTotal);

            bananas.Subtotal.Should().Be(2 * 1.25M);
            peptoBismol.Subtotal.Should().Be(2 * 4.88M);
            rubberBands.Subtotal.Should().Be(2 * 10M);
        }
    }
}