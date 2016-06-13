using System;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class SaleItemTests
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
            SaleItem saleItem = null;
            var item = new Item("sku", "name", 1M);
            Action action = () => saleItem = new SaleItem(item);

            action.ShouldNotThrow();
            saleItem.Should().NotBeNull();
            saleItem.Item.Should().Be(item);
            saleItem.Quantity.Should().Be(1);
            saleItem.Subtotal.Should().Be(1M);
        }
    }
}
