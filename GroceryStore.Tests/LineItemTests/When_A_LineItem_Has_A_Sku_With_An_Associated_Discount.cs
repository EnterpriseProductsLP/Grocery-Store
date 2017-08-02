using GroceryStore.Discounts;
using NSubstitute;
using NUnit.Framework;

namespace GroceryStore.Tests.LineItemTests
{
    [TestFixture]
    public class When_A_LineItem_Has_A_Sku_With_An_Associated_Discount
    {
        private IDeal _substituteDeal;
        private IProvideDeals _substituteDealProvider;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _substituteDeal = Substitute.For<IDeal>();
            _substituteDeal.GetDiscount(Arg.Any<uint>(), Arg.Any<decimal>()).Returns(1.00M);

            _substituteDealProvider = Substitute.For<IProvideDeals>();
            _substituteDealProvider.GetD
        }
}