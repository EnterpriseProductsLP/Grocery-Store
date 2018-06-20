using System;

using FluentAssertions;

using NUnit.Framework;

namespace GroceryStore.Tests.ItemBuilderTests
{
    [TestFixture]
    public class When_Building_For_An_Invalid_Sku
    {
        private ItemBuilder _itemBuilder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _itemBuilder = new ItemBuilder();
        }

        [Test]
        public void Build_Item_Should_Throw_An_ArgumentException()
        {
            _itemBuilder.Invoking(ib => ib.BuildItem("I_AM_NOT_A_VALID_SKU"))
                .Should().Throw<ArgumentException>()
                .WithMessage($"The given SKU: I_AM_NOT_A_VALID_SKU is invalid.");
        }
    }
}