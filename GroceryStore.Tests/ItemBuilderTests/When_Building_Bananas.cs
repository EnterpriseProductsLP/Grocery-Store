using FluentAssertions;
using GroceryStore.Domain;
using NUnit.Framework;

namespace GroceryStore.Tests.ItemBuilderTests
{
    [TestFixture]
    public class When_Building_Bananas
    {
        private Item _item;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _item = ItemBuilder.BuildItem("1245");
        }

        [Test]
        public void Name_Should_Be_Correct()
        {
            _item.Name.Should().Be("Bananas");
        }

        [Test]
        public void Price_Should_Be_Correct()
        {
            _item.Price.Should().Be(1.25M);
        }

        [Test]
        public void Sku_Should_Be_Correct()
        {
            _item.Sku.Should().Be("1245");
        }
    }
}