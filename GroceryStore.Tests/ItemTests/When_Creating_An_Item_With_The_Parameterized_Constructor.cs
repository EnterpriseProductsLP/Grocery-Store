using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.ItemTests
{
    [TestFixture]
    public class When_Creating_An_Item_With_The_Parameterized_Constructor
    {
        private const string ItemName = "name";

        private const decimal ItemPrice = 1M;

        private const string ItemSku = "sku";

        private Item _item;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _item = new Item(ItemSku, ItemName, ItemPrice);
        }

        [Test]
        public void Name_Should_Be_Correct()
        {
            _item.Name.Should().Be(ItemName);
        }

        [Test]
        public void Price_Should_Be_Correct()
        {
            _item.Price.Should().Be(ItemPrice);
        }

        [Test]
        public void Sku_Should_Be_Correct()
        {
            _item.Sku.Should().Be(ItemSku);
        }
    }
}