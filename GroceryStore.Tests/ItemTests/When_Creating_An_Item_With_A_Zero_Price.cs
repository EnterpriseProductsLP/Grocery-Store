using System;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.ItemTests
{
    [TestFixture]
    public class When_Creating_An_Item_With_A_Zero_Price
    {
        private Action _action;

        private Item _item;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _action = () => _item = new Item("sku", "name", 0);
        }

        [Test]
        public void An_Argument_Exception_Should_Be_Thrown()
        {
            var exceptionAssertions = _action.ShouldThrow<ArgumentException>();
            var argumentException = exceptionAssertions.And;
            argumentException.ParamName.Should().Be("price");
            argumentException.Message.Should()
                .Be($"An item cannot have a price of zero.\r\nParameter name: {argumentException.ParamName}");

            _item.Should().BeNull();
        }
    }
}