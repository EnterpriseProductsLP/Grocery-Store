using FluentAssertions;
using GroceryStore.Deals;
using NUnit.Framework;

namespace GroceryStore.Tests.DollarOffDealTests
{
    [TestFixture]
    public class When_Quantity_Is_One_And_Price_Is_Fifty_Cents
    {
        private decimal _discount;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            const uint quantity = 1;
            const decimal price = 0.5M;
            var dollarOffDeal = new DollarOffDeal();
            _discount = dollarOffDeal.GetDiscount(quantity, price);
        }

        [Test]
        public void Discount_Should_Be_Fity_Cents()
        {
            _discount.Should().Be(0.5M);
        }
    }
}