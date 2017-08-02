using FluentAssertions;
using GroceryStore.Discounts;
using NUnit.Framework;

namespace GroceryStore.Tests.DealConfiguratorTests
{
    [TestFixture]
    public class When_The_Deal_Configurator_Has_A_Single_Deal_Added
    {
        private DealConfigurator _dealConfigurator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _dealConfigurator = new DealConfigurator();
            _dealConfigurator.AddDeal("SKU", new TestDeal());
        }
        
        [Test]
        public void The_GetDeal_Method_Returns_The_Associated_Deal()
        {
            var actualDeal = _dealConfigurator.GetDeal("SKU");
            actualDeal.Should().BeOfType<TestDeal>();
        }
    }
    
    public class TestDeal : IDeal
    {
    }
}