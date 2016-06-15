using System;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class ItemTests
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
            const string ExpectedName = "name";
            const decimal ExpectedPrice = 1M;
            const string ExpectedSku = "sku";

            var item = new Item(ExpectedSku, ExpectedName, ExpectedPrice);

            item.Name.Should().Be(ExpectedName);
            item.Price.Should().Be(ExpectedPrice);
            item.Sku.Should().Be(ExpectedSku);
        }

        [Test]
        public void PriceCannotBeNegative()
        {
            Item item = null;
            Action action = () => item = new Item("sku", "name", -1M);

            action.ShouldThrow<ArgumentException>();
            item.Should().BeNull();
        }

        [Test]
        public void PriceCannotBeZero()
        {
            Item item = null;
            Action action = () => item = new Item("sku", "name", 0M);

            action.ShouldThrow<ArgumentException>();
            item.Should().BeNull();
        }

    }
}