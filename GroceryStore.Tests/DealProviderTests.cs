using System;

using FluentAssertions;

using GroceryStore.Tests.TestTypes;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class DealProviderTests
    {
        private const string Sku = "sku";

        private DealConfigurator _dealConfigurator;

        [SetUp]
        public void SetUp()
        {
            _dealConfigurator = new DealConfigurator();
            _dealConfigurator.ClearDeals();
        }

        [Test]
        public void AddDealDoesNotThrowIfCalledTwiceForTheSameSku()
        {
            _dealConfigurator.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            Action action = () => _dealConfigurator.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            action.ShouldNotThrow();
        }

        [Test]
        public void AddDealShouldReplaceAnyExistingDealForTheGivenSku()
        {
            _dealConfigurator.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            _dealConfigurator.AddDeal(Sku, new TestDeal());
            var actualDeal = _dealConfigurator.GetDeal(Sku);
            actualDeal.Should().BeOfType<TestDeal>();
        }

        [Test]
        public void GetDealReturnsAddedDealForTheGivenSku()
        {
            _dealConfigurator.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            var actualDeal = _dealConfigurator.GetDeal(Sku);
            actualDeal.Should().BeOfType<BuySomeGetOneFreeDeal>();
        }

        [Test]
        public void GetDealReturnsNullWhenThereIsNoDealForTheGivenSku()
        {
            var actualDeal = _dealConfigurator.GetDeal(Sku);
            actualDeal.Should().BeOfType<DoNothingDeal>();
        }

        [Test]
        public void RemoveDealDoesNotThrowIfThereIsNoDealForTheGivenSku()
        {
            Action action = () => _dealConfigurator.RemoveDeal(Sku);
            action.ShouldNotThrow();
        }

        [Test]
        public void RemoveDealShouldRemoveTheDealForTheGivenSku()
        {
            _dealConfigurator.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            var currentDeal = _dealConfigurator.GetDeal(Sku);
            currentDeal.Should().BeOfType<BuySomeGetOneFreeDeal>();

            _dealConfigurator.RemoveDeal(Sku);
            currentDeal = _dealConfigurator.GetDeal(Sku);
            currentDeal.Should().BeOfType<DoNothingDeal>();
        }
    }
}