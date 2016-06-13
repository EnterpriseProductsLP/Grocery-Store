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
        public void DefaultConstructorReturnsAnInstance()
        {
            Item item = null;
            Action action = () => item = new Item();

            action.ShouldNotThrow();
            item.Should().NotBeNull();
            item.Price.Should().Be(0M);
            item.Name.Should().Be(string.Empty);
            item.Sku.Should().Be(string.Empty);
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
    }
}
