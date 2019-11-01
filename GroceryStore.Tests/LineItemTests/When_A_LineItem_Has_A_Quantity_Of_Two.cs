using FluentAssertions;
using NUnit.Framework;

namespace GroceryStore.Tests.LineItemTests
{
    [TestFixture]
    public class When_A_LineItem_Has_A_Quantity_Of_Two
    {
        private LineItem _lineItem;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var item = new Item("sku", "name", 1);
            _lineItem = new LineItem(item);
            _lineItem.AddOne();
        }

        [Test]
        public void The_Quantity_Should_Be_Two()
        {
            _lineItem.Quantity.Should().Be(2);
        }

        [Test]
        public void The_RawTotal_Should_Be_Correct()
        {
            var expectedRawTotal = _lineItem.Price * _lineItem.Quantity;
            _lineItem.RawTotal.Should().Be(expectedRawTotal);
        }
    }
}
