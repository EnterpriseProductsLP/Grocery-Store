using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.LineItemTests
{
    [TestFixture]
    public class When_A_LineItem_Is_Instantiated_With_The_Parameterized_Constructor
    {
        private Item _item;

        private LineItem _lineItem;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _item = new Item("sku", "name", 1M);
            _lineItem = new LineItem(_item);
        }

        [Test]
        public void Name_Should_Be_The_Item_Name()
        {
            _lineItem.Name.Should().Be(_item.Name);
        }

        [Test]
        public void Price_Should_Be_The_Item_Price()
        {
            _lineItem.Price.Should().Be(_item.Price);
        }

        [Test]
        public void Sku_Should_Be_The_Item_Sku()
        {
            _lineItem.Sku.Should().Be(_item.Sku);
        }
    }
}