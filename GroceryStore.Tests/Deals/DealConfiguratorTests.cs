using System;
using System.Collections.Generic;
using FluentAssertions;
using GroceryStore.Deals;
using NUnit.Framework;

namespace GroceryStore.Tests.Deals
{
    [TestFixture]
    public class DealConfiguratorTests
    {
        [SetUp]
        public void SetUp()
        {
            _dealConfigurator = new DealConfigurator();
        }

        private const string Sku = "sku";

        private DealConfigurator _dealConfigurator;

        [Test]
        public void AddDealDoesNotThrowIfCalledTwiceForTheSameSku()
        {
            _dealConfigurator.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            Action action = () => _dealConfigurator.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            action.Should().NotThrow();
        }

        [Test]
        public void AddDealShouldReplaceAnyExistingDealForTheGivenSku()
        {
            _dealConfigurator.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            _dealConfigurator.AddDeal(Sku, new TestDeal());
            var actualDeal = _dealConfigurator.GetDeal(Sku);
            actualDeal.Should().BeOfType<TestDeal>();
        }

        [Test]
        public void GetConfiguredDealsContainsMetadataForConfiguredDealsS()
        {
            var deal = new BuyTwoGetOneFreeDeal();
            var metaData = deal.GetMetadata();
            _dealConfigurator.AddDeal(Sku, deal);
            var expectedValue = new KeyValuePair<string, DealMetadata>(Sku, metaData);
            _dealConfigurator.ConfiguredDeals.Should().Contain(expectedValue);
        }


        [Test]
        public void GetDealReturnsAddedDealForTheGivenSku()
        {
            _dealConfigurator.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            var actualDeal = _dealConfigurator.GetDeal(Sku);
            actualDeal.Should().BeOfType<BuyTwoGetOneFreeDeal>();
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
            action.Should().NotThrow();
        }

        [Test]
        public void RemoveDealShouldRemoveTheDealForTheGivenSku()
        {
            _dealConfigurator.AddDeal(Sku, new BuyTwoGetOneFreeDeal());
            var currentDeal = _dealConfigurator.GetDeal(Sku);
            currentDeal.Should().BeOfType<BuyTwoGetOneFreeDeal>();

            _dealConfigurator.RemoveDeal(Sku);
            currentDeal = _dealConfigurator.GetDeal(Sku);
            currentDeal.Should().BeOfType<DoNothingDeal>();
        }
    }
}