using System.Linq;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.SaleTests
{
    [TestFixture]
    public class When_Creating_A_Sale_With_One_Of_Each_Item
    {
        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _sale = new Sale(new ItemBuilder());
            _sale.AddItem("1245");
            _sale.AddItem("99999");
            _sale.AddItem("839");
        }

        [Test]
        public void Sale_Total_Should_Be_Correct()
        {
            const decimal saleTotalForOneOfEachItem = 1.25M + 4.88M + 10M;
            _sale.Total.Should().Be(saleTotalForOneOfEachItem);
        }

        [Test]
        public void There_Should_Be_Three_Line_Items()
        {
            _sale.LineItems.Count.Should().Be(3);
        }
    }
}