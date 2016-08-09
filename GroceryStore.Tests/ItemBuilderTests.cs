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
            var item = ItemBuilder.BuildItem("1245");

            item.Name.Should().Be("Bananas");
            item.Price.Should().Be(1.25M);
            item.Sku.Should().Be("1245");
        }

        [Test]
        public void CanGetItemForPeptoBismol()
        {
            var item = ItemBuilder.BuildItem("99999");

            item.Name.Should().Be("Pepto Bismol");
            item.Price.Should().Be(4.88M);
            item.Sku.Should().Be("99999");
        }

        [Test]
        public void CanGetItemForRubberBands()
        {
            var item = ItemBuilder.BuildItem("839");

            item.Name.Should().Be("Rubber Bands");
            item.Price.Should().Be(10M);
            item.Sku.Should().Be("839");
        }
    }
}