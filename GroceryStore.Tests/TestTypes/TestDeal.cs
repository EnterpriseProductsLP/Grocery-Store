using System;
using GroceryStore.Interfaces;

namespace GroceryStore.Tests.TestTypes
{
    internal class TestDeal : IDeal
    {
        public decimal GetDiscount(uint quantity, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}