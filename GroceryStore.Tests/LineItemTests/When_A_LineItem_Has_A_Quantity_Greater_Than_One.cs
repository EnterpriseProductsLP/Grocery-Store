using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.LineItemTests
{
    [TestFixture]
    public class When_A_LineItem_Has_A_Quantity_Greater_Than_One
    {
        private Item _item;

        private LineItem _lineItem;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _item = new Item("sku", "name", 1M);
        }

        [SetUp]
        public void SetUp()
        {
            _lineItem = new LineItem(_item);
        }

        [Test]
        public void All_Properties_Should_Be_Correct()
        {
            for (var i = 0; i < 100; i++)
            {
                var expectedQuantity = i + 2;

                Quantity_Should_Be_Correct(expectedQuantity);
                Raw_Total_Should_Be_Price_Times_Quantity(expectedQuantity);
            }
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

        private void Quantity_Should_Be_Correct(int i)
        {
            {
                _lineItem.AddOne();
                _lineItem.Quantity.Should().Be(i);
            }
        }

        private void Raw_Total_Should_Be_Price_Times_Quantity(int quantity)
        {
            _lineItem.RawTotal.Should().Be(_item.Price * quantity);
        }
    }
}