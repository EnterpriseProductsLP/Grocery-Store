using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class ItemBuilderTests
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
        public void CanGetItemForBananas()
        {
            var item = ItemBuilder.BuildItem(ItemData.Bananas.Sku);

            item.Name.Should().Be(ItemData.Bananas.Name);
            item.Price.Should().Be(ItemData.Bananas.Price);
            item.Sku.Should().Be(ItemData.Bananas.Sku);
        }

        [Test]
        public void CanGetItemForPeptoBismol()
        {
            var item = ItemBuilder.BuildItem(ItemData.PeptoBismol.Sku);

            item.Name.Should().Be(ItemData.PeptoBismol.Name);
            item.Price.Should().Be(ItemData.PeptoBismol.Price);
            item.Sku.Should().Be(ItemData.PeptoBismol.Sku);
        }

        [Test]
        public void CanGetItemForRubberBands()
        {
            var item = ItemBuilder.BuildItem(ItemData.RubberBands.Sku);

            item.Name.Should().Be(ItemData.RubberBands.Name);
            item.Price.Should().Be(ItemData.RubberBands.Price);
            item.Sku.Should().Be(ItemData.RubberBands.Sku);
        }
    }
}