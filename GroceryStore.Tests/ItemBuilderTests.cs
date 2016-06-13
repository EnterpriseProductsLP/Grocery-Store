using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class ItemBuilderTests
    {
        [Test]
        public void CanGetItemForBananas()
        {
            // Act
            var item = ItemBuilder.BuildItem(ItemData.Bananas.Sku);

            // Assert
            item.Name.Should().Be(ItemData.Bananas.Name);
            item.Price.Should().Be(ItemData.Bananas.Price);
            item.Sku.Should().Be(ItemData.Bananas.Sku);
        }

        [Test]
        public void CanGetItemForPeptoBismol()
        {
            // Act
            var item = ItemBuilder.BuildItem(ItemData.PeptoBismol.Sku);

            // Assert
            item.Name.Should().Be(ItemData.PeptoBismol.Name);
            item.Price.Should().Be(ItemData.PeptoBismol.Price);
            item.Sku.Should().Be(ItemData.PeptoBismol.Sku);
        }

        [Test]
        public void CanGetItemForRubberBands()
        {
            // Act
            var item = ItemBuilder.BuildItem(ItemData.RubberBands.Sku);

            // Assert
            item.Name.Should().Be(ItemData.RubberBands.Name);
            item.Price.Should().Be(ItemData.RubberBands.Price);
            item.Sku.Should().Be(ItemData.RubberBands.Sku);
        }
    }
}