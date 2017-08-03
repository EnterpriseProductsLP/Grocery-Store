using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.SaleTests
{
    [TestFixture]
    public class When_Creating_A_Sale_With_A_Single_Item
    {
        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sale = new Sale(new ItemBuilder());
            _sale.AddItem("1245");
        }

        [Test]
        public void Sale_Total_Should_Be_Correct()
        {
            _sale.Total.Should().Be(1.25M);
        }

        [Test]
        public void There_Should_Be_One_Line_Items()
        {
            _sale.LineItems.Count.Should().Be(1);
        }
    }
}