using System;

namespace GroceryStore.Tests
{
    internal class TestDeal : IDeal
    {
        public decimal GetDiscount(uint quantity, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}