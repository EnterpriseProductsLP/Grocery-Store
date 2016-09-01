using System;
using System.Linq;
using System.Threading.Tasks;

using FluentAssertions;

using NSubstitute;

using NUnit.Framework;

namespace GroceryStore.Tests
{
    [TestFixture]
    public class LineItemTestss
    {
        private readonly decimal[] _prices = { 1.25M, 10M, 4.88M };

        private readonly Func<LineItem, bool> _rawTotalEqualsQuantityTimesPrice =
            li => li.RawTotal == li.Quantity * li.Price;

        private readonly Func<LineItem, bool> _subtotalEqualsRawTotalMinusDiscount =
            li => li.Subtotal == li.RawTotal - li.Discount;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ParameterizedConstructorReturnsAnInstanceWithCorrectValues()
        {
            LineItem lineItem = null;
            var item = new Item("sku", "name", 1M);
            Action action = () => lineItem = new LineItem(item);

            action.ShouldNotThrow();
            lineItem.Should().NotBeNull();
            lineItem.Name.Should().Be(item.Name);
            lineItem.Price.Should().Be(item.Price);
            lineItem.Sku.Should().Be(item.Sku);
            lineItem.Quantity.Should().Be(1);
            lineItem.Subtotal.Should().Be(1M);
        }

        [Test]
        public void SubtotalReturnsQuantityTimesPrice()
        {
            var item = new Item("sku", "name", 1M);
            var lineItem = new LineItem(item);
            lineItem.AddOne();

            lineItem.Should().NotBeNull();
            lineItem.Quantity.Should().Be(2);
            lineItem.Subtotal.Should().Be(2M);
        }

        [Test]
        public void DiscountEqualsZeroWithBuyTwoGetOneFreeDealAndQuantityLessThanThree()
        {
            Parallel.For(
                1,
                3,
                i =>
                    {
                        var quantity = (uint)i;
                        foreach (var price in _prices)
                        {
                            var item = new Item("sku", "name", price);

                            var substituteDeal = Substitute.For<IDeal>();
                            substituteDeal.GetDiscount(quantity, item.Price).Returns(0);

                            var lineItemStub = new LineItem(item);
                            var lineItemUnderTest = new LineItem(item);

                            lineItemStub.SetQuantity(quantity);
                            lineItemUnderTest.SetQuantity(quantity);

                            var expectedDiscount = lineItemStub.Discount;
                            var actualDiscount = lineItemUnderTest.Discount;

                            actualDiscount.Should().Be(expectedDiscount);
                            _rawTotalEqualsQuantityTimesPrice(lineItemUnderTest).Should().BeTrue();
                            _subtotalEqualsRawTotalMinusDiscount(lineItemUnderTest).Should().BeTrue();
                        }
                    });
        }

        [Test]
        public void DiscountEqualsQuantityDividedByThreeTimesPriceWithBuyTwoGetOneFreeDealAndQuantityDivisibleByThree()
        {
            // We're only testing numbers not divisible by three
            var quantities = Enumerable.Range(0, 1000).Where(i => i % 3 == 0).ToList();

            Parallel.ForEach(
                quantities,
                i =>
                    {
                        var quantity = (uint)i;
                        var freeQuantity = quantity / 3;

                        foreach (var price in _prices)
                        {
                            var item = new Item("sku", "name", price);
                            var substituteDealDiscount = freeQuantity * item.Price;

                            var substituteDeal = Substitute.For<IDeal>();
                            substituteDeal.GetDiscount(quantity, item.Price).Returns(substituteDealDiscount);

                            var lineItemStub = new LineItem(item);
                            var lineItemUnderTest = new LineItem(item);

                            lineItemStub.SetQuantity(quantity);
                            lineItemUnderTest.SetQuantity(quantity);

                            var expectedDiscount = lineItemStub.Discount;
                            var actualDiscount = lineItemUnderTest.Discount;

                            actualDiscount.Should().Be(expectedDiscount);
                            _rawTotalEqualsQuantityTimesPrice(lineItemUnderTest).Should().BeTrue();
                            _subtotalEqualsRawTotalMinusDiscount(lineItemUnderTest).Should().BeTrue();
                        }
                    });
        }

        [Test]
        public void DiscountEqualsQuantityMinusOneDividedByThreeTimesPriceWithBuyTwoGetOneFreeDealAndQuantityNotDivisibleByThree()
        {
            // We're only testing numbers not divisible by three
            var quantities = Enumerable.Range(0, 1000).Where(i => i % 3 != 0).ToList();

            Parallel.ForEach(
                quantities,
                i =>
                    {
                        var quantity = (uint)i;
                        var workingQuantity = quantity;
                        while (workingQuantity % 3 != 0)
                        {
                            workingQuantity -= 1;
                        }

                        var freeQuantity = workingQuantity / 3;

                        foreach (var price in _prices)
                        {
                            var item = new Item("sku", "name", price);
                            var substituteDealDiscount = freeQuantity * item.Price;

                            var substituteDeal = Substitute.For<IDeal>();
                            substituteDeal.GetDiscount(quantity, item.Price).Returns(substituteDealDiscount);

                            var lineItemStub = new LineItem(item);
                            var lineItemUnderTest = new LineItem(item);

                            lineItemStub.SetQuantity(quantity);
                            lineItemUnderTest.SetQuantity(quantity);

                            var expectedDiscount = lineItemStub.Discount;
                            var actualDiscount = lineItemUnderTest.Discount;

                            actualDiscount.Should().Be(expectedDiscount);
                            _rawTotalEqualsQuantityTimesPrice(lineItemUnderTest).Should().BeTrue();
                            _subtotalEqualsRawTotalMinusDiscount(lineItemUnderTest).Should().BeTrue();
                        }
                    });
        }

        [Test]
        public void WithoutDealDiscountAlwaysEqualsZero()
        {
            Parallel.For(
                1,
                25,
                i =>
                    {
                        foreach (var price in _prices)
                        {
                            var item = new Item("sku", "name", price);
                            var lineItem = new LineItem(item);
                            lineItem.SetQuantity(i);

                            var actual = lineItem.Discount;

                            actual.Should().Be(0);
                            _rawTotalEqualsQuantityTimesPrice(lineItem).Should().BeTrue();
                            _subtotalEqualsRawTotalMinusDiscount(lineItem).Should().BeTrue();
                        }
                    });
        }
    }
}