﻿using FluentAssertions;
using GroceryStore.Discounts;
using NUnit.Framework;

namespace GroceryStore.Tests.SaleTests
{
    [TestFixture]
    public class When_Creating_A_Sale_With_A_Single_Item_That_Has_A_Dollar_Off_Deal_Applied
    {
        private DealConfigurator _dealConfigurator;

        private Sale _sale;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dealConfigurator = new DealConfigurator();
            _dealConfigurator.AddDeal("1245", new DollarOffDeal());

            _sale = new Sale(_dealConfigurator);
            _sale.AddItem("1245");
        }

        [Test]
        public void Total_Should_Be_The_Item_Price_Minus_One_Dollar()
        {
            _sale.Total.Should().Be(1.25M - 1);
        }
    }
}