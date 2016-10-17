using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace GroceryStore.Tests
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
        public void Should_Support_BuyTwoGetOneFreeDeal()
        {
            var expectedDescription = "Buy two get one free.";

            var supportedDeal = _dealMapping.SupportedDeals.Single(x => x.Identifier == 'c');
            supportedDeal.Description.Should().Be(expectedDescription);
        }
    }
}