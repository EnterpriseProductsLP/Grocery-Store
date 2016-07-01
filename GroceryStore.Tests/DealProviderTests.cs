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
            DealProvider.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            Action action = () => DealProvider.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            action.ShouldNotThrow();
        }

        [Test]
        public void AddDealShouldReplaceAnyExistingDealForTheGivenSku()
        {
            
            DealProvider.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            DealProvider.AddDeal(Sku, new TestDeal());
            var actualDeal = DealProvider.GetDeal(Sku);
            actualDeal.Should().BeOfType<TestDeal>();
        }

        [Test]
        public void GetDealReturnsAddedDealForTheGivenSku()
        {
            DealProvider.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            var actualDeal = DealProvider.GetDeal(Sku);
            actualDeal.Should().BeOfType<BuyTwoGetOneFreeDeal>();
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
            DealProvider.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            var currentDeal = DealProvider.GetDeal(Sku);
            currentDeal.Should().BeOfType<BuyTwoGetOneFreeDeal>();

            DealProvider.RemoveDeal(Sku);
            currentDeal = DealProvider.GetDeal(Sku);
            currentDeal.Should().BeNull();
        }
    }
}