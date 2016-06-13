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
            LineItems lineItems = null;
            var item = new Item("sku", "name", 1M);
            Action action = () => lineItems = new LineItems(item);

            action.ShouldNotThrow();
            lineItems.Should().NotBeNull();
            lineItems.Item.Should().Be(item);
            lineItems.Quantity.Should().Be(1);
            lineItems.Subtotal.Should().Be(1M);
        }

        [Test]
        public void SubtotalReturnsQuantityTimesPrice()
        {
            var item = new Item("sku", "name", 1M);
            var lineItem = new LineItems(item);
            lineItem.AddOne();

            lineItem.Should().NotBeNull();
            lineItem.Item.Should().Be(item);
            lineItem.Quantity.Should().Be(2);
            lineItem.Subtotal.Should().Be(2M);
        }
    }
}