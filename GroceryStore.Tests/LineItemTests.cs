using System;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class LineItemTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ParameterizedConstructorReturnsAnInstanceWithCorrectValues()
        {
            LineItem lineItem = null;
            var item = new Item("sku", "name", 1M);
            Action action = () => lineItem = new LineItem(item);

            action.ShouldNotThrow();
            lineItem.Should().NotBeNull();
            lineItem.Name.Should().Be(item.Name);
            lineItem.Price.Should().Be(item.Price);
            lineItem.Sku.Should().Be(item.Sku);
            lineItem.Quantity.Should().Be(1);
            lineItem.RawTotal.Should().Be(1M);
        }

        [Test]
        public void SubtotalReturnsQuantityTimesPrice()
        {
            var item = new Item("sku", "name", 1M);
            var lineItem = new LineItem(item);
            lineItem.AddOne();

            lineItem.Should().NotBeNull();
            lineItem.Quantity.Should().Be(2);
            lineItem.RawTotal.Should().Be(2M);
        }
    }
}