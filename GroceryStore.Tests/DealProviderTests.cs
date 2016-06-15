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
            DealProvider.AddDeal<BuyTwoGetOneFreeDeal>(Sku);
            Action action = () => DealProvider.AddDeal<BuyTwoGetOneFreeDeal>(Sku);
            action.ShouldNotThrow();
        }

        [Test]
        public void AddDealShouldReplaceAnyExistingDealForTheGivenSku()
        {
            
            DealProvider.AddDeal<BuyTwoGetOneFreeDeal>(Sku);
            DealProvider.AddDeal<TestDeal>(Sku);
            var actualDeal = DealProvider.GetDeal(Sku);
            actualDeal.Should().BeOfType<TestDeal>();
        }

        [Test]
        public void GetDealReturnsAddedDealForTheGivenSku()
        {
            DealProvider.AddDeal<BuyTwoGetOneFreeDeal>(Sku);
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
            DealProvider.AddDeal<BuyTwoGetOneFreeDeal>(Sku);
            var currentDeal = DealProvider.GetDeal(Sku);
            currentDeal.Should().BeOfType<BuyTwoGetOneFreeDeal>();

            DealProvider.RemoveDeal(Sku);
            currentDeal = DealProvider.GetDeal(Sku);
            currentDeal.Should().BeNull();
        }
    }
}