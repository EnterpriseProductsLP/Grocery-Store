using System.Linq;
using FluentAssertions;
using GroceryStore.Deals;
using NUnit.Framework;

namespace GroceryStore.Tests.DealMappingTests
{
    [TestFixture]
    public class An_Instance_Of_DealMapping
    {
        private DealMapping _dealMapping;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dealMapping = new DealMapping();
        }

        [Test]
        public void Should_Return_An_Instance_Of_DollarOffDeal_When_Get_Deal_Is_Invoked_With_An_Input_Of_A()
        {
            var expectedDeal = _dealMapping.GetDeal(DealConstants.DollarOffDeal.Identifier);
            expectedDeal.Should().BeOfType<DollarOffDeal>();
        }

        [Test]
        public void Should_Return_An_Instance_Of_BuyTwoGetOneFreeDeal_When_GetDeal_Is_Invoked_With_An_Input_Of_C()
        {
            var expectedDeal = _dealMapping.GetDeal(DealConstants.BuyTwoGetOneFreeDeal.Identifier);
            expectedDeal.Should().BeOfType<BuyTwoGetOneFreeDeal>();
        }

        [Test]
        public void Should_Support_BuyTwoGetOneFreeDeal()
        {
            const string expectedDescription = DealConstants.BuyTwoGetOneFreeDeal.Description;
            var supportedDeal = _dealMapping.SupportedDeals.Single(x => x.Identifier == DealConstants.BuyTwoGetOneFreeDeal.Identifier);
            supportedDeal.Description.Should().Be(expectedDescription);
        }
    }
}
