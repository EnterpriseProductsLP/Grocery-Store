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
            Action action = () => _sale.AddItem(ItemData.Bananas.Sku);
            action.ShouldNotThrow();
            _sale.LineItems.Count.Should().Be(1);

            var lineItem = _sale.LineItems.Single();
            lineItem.Quantity.Should().Be(1);
            lineItem.Subtotal.Should().Be(ItemData.Bananas.Price);
            _sale.Total.Should().Be(ItemData.Bananas.Price);
        }

        [Test]
        public void SaleWithOneOfEachItemHasTheCorrectPrice()
        {
            _sale.AddItem(ItemData.Bananas.Sku);
            _sale.AddItem(ItemData.PeptoBismol.Sku);
            _sale.AddItem(ItemData.RubberBands.Sku);

            var bananas = _sale.LineItems.Single(lineItem => lineItem.Item.Sku == ItemData.Bananas.Sku);
            var peptoBismol = _sale.LineItems.Single(lineItem => lineItem.Item.Sku == ItemData.PeptoBismol.Sku);
            var rubberBands = _sale.LineItems.Single(lineItem => lineItem.Item.Sku == ItemData.RubberBands.Sku);
            var expectedTotal = ItemData.Bananas.Price + ItemData.PeptoBismol.Price + ItemData.RubberBands.Price;

            _sale.LineItems.Count.Should().Be(3);
            _sale.Total.Should().Be(expectedTotal);

            bananas.Subtotal.Should().Be(ItemData.Bananas.Price);
            peptoBismol.Subtotal.Should().Be(ItemData.PeptoBismol.Price);
            rubberBands.Subtotal.Should().Be(ItemData.RubberBands.Price);
        }

        [Test]
        public void SaleWithTwoOfEachItemHasTheCorrectPrice()
        {
            _sale.AddItem(ItemData.Bananas.Sku);
            _sale.AddItem(ItemData.Bananas.Sku);

            _sale.AddItem(ItemData.PeptoBismol.Sku);
            _sale.AddItem(ItemData.PeptoBismol.Sku);

            _sale.AddItem(ItemData.RubberBands.Sku);
            _sale.AddItem(ItemData.RubberBands.Sku);

            var bananas = _sale.LineItems.Single(lineItem => lineItem.Item.Sku == ItemData.Bananas.Sku);
            var peptoBismol = _sale.LineItems.Single(lineItem => lineItem.Item.Sku == ItemData.PeptoBismol.Sku);
            var rubberBands = _sale.LineItems.Single(lineItem => lineItem.Item.Sku == ItemData.RubberBands.Sku);
            var expectedTotal = 2 * ItemData.Bananas.Price + 2 * ItemData.PeptoBismol.Price
                                + 2 * ItemData.RubberBands.Price;

            _sale.LineItems.Count.Should().Be(3);
            _sale.Total.Should().Be(expectedTotal);

            bananas.Subtotal.Should().Be(2 * ItemData.Bananas.Price);
            peptoBismol.Subtotal.Should().Be(2 * ItemData.PeptoBismol.Price);
            rubberBands.Subtotal.Should().Be(2 * ItemData.RubberBands.Price);
        }
    }
}