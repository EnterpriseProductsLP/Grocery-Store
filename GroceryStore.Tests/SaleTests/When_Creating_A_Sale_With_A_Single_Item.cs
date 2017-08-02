using System.Linq;

using FluentAssertions;
using GroceryStore.Domain;
using NUnit.Framework;

namespace GroceryStore.Tests.SaleTests
{
    [TestFixture]
    public class When_Creating_A_Sale_With_A_Single_Item
    {
        private LineItem _lineItem;

        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sale = new Sale();
            _sale.AddItem("1245");
            _lineItem = _sale.LineItems.Single();
        }

        [Test]
        public void There_Should_Only_Be_One_LineItem()
        {
            _sale.LineItems.Count.Should().Be(1);
        }

        [Test]
        public void Sale_Total_Should_Be_Correct()
        {
            _sale.Total.Should().Be(1.25M);
        }

        [Test]
        public void LineItem_Quantity_Should_Be_One()
        {
            _lineItem.Quantity.Should().Be(1);
        }

        [Test]
        public void LineItem_Raw_Total_Should_Be_Correct()
        {
            _lineItem.RawTotal.Should().Be(1.25M);
        }
    }
}