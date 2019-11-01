﻿using FluentAssertions;
using GroceryStore.Deals;
using NUnit.Framework;

namespace GroceryStore.Tests.Deals.DollarOffDealTests
{
    [TestFixture]
    public class When_Quantity_Is_Two_And_Price_Is_Two_Dollars
    {
        private decimal _discount;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            const uint quantity = 2;
            const decimal price = 2M;
            var dollarOffDeal = new DollarOffDeal();
            _discount = dollarOffDeal.GetDiscount(quantity, price);
        }

        [Test]
        public void Discount_Should_Be_Two_Dollars()
        {
            _discount.Should().Be(2M);
        }
    }
}