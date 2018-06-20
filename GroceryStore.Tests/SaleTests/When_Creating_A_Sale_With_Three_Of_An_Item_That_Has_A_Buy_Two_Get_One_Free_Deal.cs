using FluentAssertions;
using GroceryStore.Deals;
using GroceryStore.Domain;
using GroceryStore.Interfaces;
using NUnit.Framework;

namespace GroceryStore.Tests.SaleTests
{
    [TestFixture]
    public class When_Creating_A_Sale_With_Three_Of_An_Item_That_Has_A_Buy_Two_Get_One_Free_Deal
    {
        private IConfigureDeals _dealConfigurator;

        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dealConfigurator = new DealConfigurator();
            _dealConfigurator.AddDeal("1245", new BuyTwoGetOneFreeDeal());

            _sale = new Sale(_dealConfigurator, new ItemBuilder());
            _sale.AddItem("1245");
            _sale.AddItem("1245");
            _sale.AddItem("1245");
        }

        [Test]
        public void Total_Should_Be_The_Item_Price_Times_Two()
        {
            _sale.Total.Should().Be(2 * 1.25M);
        }
    }
}