using System;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.ItemTests
{
    [TestFixture]
    public class When_Creating_An_Item_With_A_Negative_Price
    {
        private Action _action;

        private Item _item;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _action = () => _item = new Item("sku", "name", -1M);
        }

        [Test]
        public void An_Argument_Exception_Should_Be_Thrown()
        {
            const string paranName = "price";

            _action.Should().Throw<ArgumentException>()
                .WithMessage($"An item cannot have a negative price.\r\nParameter name: {paranName}")
                .And.ParamName.Should().Be(paranName);

            _item.Should().BeNull();
        }
    }
}