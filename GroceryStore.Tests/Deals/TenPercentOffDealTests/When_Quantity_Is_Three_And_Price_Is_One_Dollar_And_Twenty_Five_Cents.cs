using FluentAssertions;
using GroceryStore.Deals;
using NUnit.Framework;

namespace GroceryStore.Tests.Deals.TenPercentOffDealTests
{
    [TestFixture]
    public class When_Quantity_Is_Three_And_Price_Is_One_Dollar_And_Twenty_Five_Cents
    {
        private decimal _discount;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            const uint quantity = 3;
            const decimal price = 1.25M;
            var tenPercentDiscountDeal = new TenPercentDiscountDeal();
            _discount = tenPercentDiscountDeal.GetDiscount(quantity, price);
        }

        [Test]
        public void Discount_Should_Be_Thirty_Eight_Cents()
        {
            _discount.Should().Be(0.38M);
        }
    }
}