using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.ItemBuilderTests
{
    [TestFixture]
    public class When_Building_Rubber_Bands
    {
        private Item _item;
        
        private ItemBuilder _itemBuilder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _itemBuilder = new ItemBuilder();
            _item = _itemBuilder.BuildItem("839");
        }

        [Test]
        public void Name_Should_Be_Correct()
        {
            _item.Name.Should().Be("Rubber Bands");
        }

        [Test]
        public void Price_Should_Be_Correct()
        {
            _item.Price.Should().Be(10M);
        }

        [Test]
        public void Sku_Should_Be_Correct()
        {
            _item.Sku.Should().Be("839");
        }
    }
}