using System;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class DealProviderTests
    {
        private const string Sku = "sku";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            DealProvider.ClearDeals();
        }

        [Test]
        public void AddDealDoesNotThrowIfCalledTwiceForTheSameSku()
        {
            DealProvider.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            Action action = () => DealProvider.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            action.ShouldNotThrow();
        }

        [Test]
        public void AddDealShouldReplaceAnyExistingDealForTheGivenSku()
        {
            
            DealProvider.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            DealProvider.AddDeal(Sku, new TestDeal());
            var actualDeal = DealProvider.GetDeal(Sku);
            actualDeal.Should().BeOfType<TestDeal>();
        }

        [Test]
        public void GetDealReturnsAddedDealForTheGivenSku()
        {
            DealProvider.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            var actualDeal = DealProvider.GetDeal(Sku);
            actualDeal.Should().BeOfType<BuySomeGetOneFreeDeal>();
        }

        [Test]
        public void GetDealReturnsNullWhenThereIsNoDealForTheGivenSku()
        {
            var actualDeal = DealProvider.GetDeal(Sku);
            actualDeal.Should().BeNull();
        }

        [Test]
        public void RemoveDealDoesNotThrowIfThereIsNoDealForTheGivenSku()
        {
            Action action = () => DealProvider.RemoveDeal(Sku);
            action.ShouldNotThrow();
        }

        [Test]
        public void RemoveDealShouldRemoveTheDealForTheGivenSku()
        {
            DealProvider.AddDeal(Sku, new BuySomeGetOneFreeDeal(2));
            var currentDeal = DealProvider.GetDeal(Sku);
            currentDeal.Should().BeOfType<BuySomeGetOneFreeDeal>();

            DealProvider.RemoveDeal(Sku);
            currentDeal = DealProvider.GetDeal(Sku);
            currentDeal.Should().BeNull();
        }
    }
}