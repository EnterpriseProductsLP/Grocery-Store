using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.SaleTests
{
    [TestFixture]
    public class When_Creating_A_Sale_With_Two_Of_Each_Item
    {
        private LineItem _bananas;

        private LineItem _peptoBismol;

        private LineItem _rubberBands;

        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sale = new Sale();
            _sale.AddItem("1245");
            _sale.AddItem("1245");

            _sale.AddItem("99999");
            _sale.AddItem("99999");

            _sale.AddItem("839");
            _sale.AddItem("839");

            _bananas = _sale.LineItems.Single(lineItem => lineItem.Sku == "1245");
            _peptoBismol = _sale.LineItems.Single(lineItem => lineItem.Sku == "99999");
            _rubberBands = _sale.LineItems.Single(lineItem => lineItem.Sku == "839");
        }

        [Test]
        public void Raw_Total_For_Bananas_Should_Be_Correct()
        {
            _bananas.RawTotal.Should().Be(2 * 1.25M);
        }

        [Test]
        public void Raw_Total_For_Pepto_Bismol_Should_Be_Correct()
        {
            _peptoBismol.RawTotal.Should().Be(2 * 4.88M);
        }

        [Test]
        public void Raw_Total_For_Rubber_Bands_Should_Be_Correct()
        {
            _rubberBands.RawTotal.Should().Be(2 * 10M);
        }

        [Test]
        public void Sale_Total_Should_Be_Correct()
        {
            const decimal priceForTwoOfEachItem = 2 * (1.25M + 4.88M + 10M);
            _sale.Total.Should().Be(priceForTwoOfEachItem);
        }

        [Test]
        public void There_Should_Be_Three_Line_Items()
        {
            _sale.LineItems.Count.Should().Be(3);
        }
    }
}