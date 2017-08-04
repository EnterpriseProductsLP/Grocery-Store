using FluentAssertions;
using GroceryStore.Deals;
using GroceryStore.Domain;
using NUnit.Framework;

namespace GroceryStore.Tests.SaleTests
{
    [TestFixture]
    public class When_A_Sale_Has_An_Item_That_Is_One_Dollar_Off
    {
        private DealConfigurator _dealConfigurator;
        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dealConfigurator = new DealConfigurator();
            _dealConfigurator.AddDeal("1245", new DollarOffDeal());
            _sale = new Sale(_dealConfigurator, new ItemBuilder());
            _sale.AddItem("1245");
        }

        [Test]
        public void The_Sale_Total_Should_Be_One_Dollar_Less_Than_The_Item_Price()
        {
            var itemBuilder = new ItemBuilder();
            var bananas = itemBuilder.BuildItem("1245");
            var priceOfBananas = bananas.Price;
            var expectedSaleTotal = priceOfBananas - 1M;
            _sale.Total.Should().Be(expectedSaleTotal);
        }
    }
}
