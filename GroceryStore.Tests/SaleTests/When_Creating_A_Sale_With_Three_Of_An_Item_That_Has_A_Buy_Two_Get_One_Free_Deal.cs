using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.SaleTests
{
    [TestFixture]
    class When_Creating_A_Sale_With_Three_Of_An_Item_That_Has_A_Buy_Two_Get_One_Free_Deal
    {
        private Sale _sale;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DealProvider.AddDeal("1245", new BuySomeGetOneFreeDeal(2));

            _sale = new Sale();
            _sale.AddItem("1245");
            _sale.AddItem("1245");
            _sale.AddItem("1245");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DealProvider.ClearDeals();
        }

        [Test]
        public void Total_Should_Be_The_Item_Price_Times_Two()
        {
            _sale.Total.Should().Be(2 * 1.25M);
        }
    }
}