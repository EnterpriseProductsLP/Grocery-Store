using System;

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