using System;
using FluentAssertions;
using GroceryStore.Deals;
using NUnit.Framework;

namespace GroceryStore.Tests.Deals.DollarOffDealTests
{
    [TestFixture]
    public class When_Discount_Is_Greater_Than_Price
    {
        private DollarOffDeal _dollarOffDeal;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dollarOffDeal = new DollarOffDeal();
        }

        [Test]
        public void Invoking_Get_Discount_Throws_An_InvalidOperationException()
        {
            const uint quantity = 1;
            const decimal price = 0.5M;
            Action tryingToGetDiscountForPriceLessThanOneDollar = () => _dollarOffDeal.GetDiscount(quantity, price);
            tryingToGetDiscountForPriceLessThanOneDollar.Should().Throw<InvalidOperationException>();
        }
    }
}