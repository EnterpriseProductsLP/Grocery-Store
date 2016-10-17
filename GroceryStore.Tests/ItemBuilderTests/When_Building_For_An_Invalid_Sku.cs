using System;

using FluentAssertions;
using GroceryStore.Domain;
using NUnit.Framework;

namespace GroceryStore.Tests.ItemBuilderTests
{
    [TestFixture]
    public class When_Building_For_An_Invalid_Sku
    {
        private Action _action;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _action = () => ItemBuilder.BuildItem("I_AM_NOT_A_VALID_SKU");
        }

        [Test]
        public void Build_Item_Should_Throw_An_ArgumentException()
        {
            _action.ShouldThrow<ArgumentException>();
        }
    }
}