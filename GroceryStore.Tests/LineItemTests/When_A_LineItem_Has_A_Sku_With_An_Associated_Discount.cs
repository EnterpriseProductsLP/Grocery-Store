using FluentAssertions;

using NSubstitute;

using NUnit.Framework;

namespace GroceryStore.Tests.LineItemTests
{
    [TestFixture]
    public class When_A_LineItem_Has_A_Sku_With_An_Associated_Discount
    {
        private const decimal ExpectedDiscount = 1.25M;

        private const string Sku = "1245";

        private LineItem _lineItem;

        private IDeal _substituteDeal;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _substituteDeal = Substitute.For<IDeal>();
            _substituteDeal.GetDiscount(Arg.Any<uint>(), Arg.Any<decimal>()).Returns(ExpectedDiscount);
            DealProvider.AddDeal(Sku, _substituteDeal);

            _lineItem = new LineItem(ItemBuilder.BuildItem(Sku));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            DealProvider.ClearDeals();
        }

        [Test]
        public void Discount_Should_Be_Correct()
        {
            _lineItem.Discount.Should().Be(ExpectedDiscount);
        }

        [Test]
        public void IDeal_GetDiscount_Method_Is_Invoked()
        {
            _substituteDeal.Received().GetDiscount(_lineItem.Quantity, _lineItem.Price);
        }

        [Test]
        public void Quantity_Should_Be_Correct()
        {
            _lineItem.Quantity.Should().Be(1);
        }

        [Test]
        public void Subtotal_Should_Be_Raw_Total_Minus_Discount()
        {
            _lineItem.Subtotal.Should().Be(_lineItem.RawTotal - _lineItem.Discount);
        }
    }
}