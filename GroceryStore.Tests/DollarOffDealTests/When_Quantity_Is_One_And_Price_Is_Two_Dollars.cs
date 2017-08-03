using FluentAssertions;
using GroceryStore.Deals;
using NUnit.Framework;

namespace GroceryStore.Tests.DollarOffDealTests
{
    [TestFixture]
    public class When_Quantity_Is_One_And_Price_Is_Two_Dollars
    {
        private decimal _discount;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            const uint quantity = 1;
            const decimal price = 2M;
            var dollarOffDeal = new DollarOffDeal();
            _discount = dollarOffDeal.GetDiscount(quantity, price);
        }

        [Test]
        public void Discount_Should_Be_One_Dollar()
        {
            _discount.Should().Be(1M);
        }
    }
}