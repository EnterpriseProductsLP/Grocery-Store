using FluentAssertions;
using GroceryStore.Deals;
using NUnit.Framework;

namespace GroceryStore.Tests.TenPercentOffDealTests
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
            var tenPercentDiscountDeal = new TenPercentDiscountDeal();
            _discount = tenPercentDiscountDeal.GetDiscount(quantity, price);
        }

        [Test]
        public void Discount_Should_Be_Five_Cents()
        {
            _discount.Should().Be(0.05M);
        }
    }
}