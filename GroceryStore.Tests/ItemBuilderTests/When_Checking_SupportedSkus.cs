// © Copyright 2012, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or 
// related documentation, is strictly prohibited, without written consent from Enterprise. 
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.

using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GroceryStore.Domain;
using NUnit.Framework;

namespace GroceryStore.Tests.ItemBuilderTests
{
    [TestFixture]
    public class When_Checking_SupportedSkus
    {
        private IList<string> _supportedSkus;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _supportedSkus = ItemBuilder.SupportedSkus.ToList();
        }

        [Test]
        public void The_Sku_For_Bananas_Is_Included()
        {
            _supportedSkus.Should().Contain("1245");
        }

        [Test]
        public void The_Sku_For_Pepto_Bismol_IsIncluded()
        {
            _supportedSkus.Should().Contain("99999");
        }

        [Test]
        public void The_Sku_For_RubberBands_Is_Included()
        {
            _supportedSkus.Should().Contain("839");
        }
    }
}