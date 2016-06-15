using System;

namespace GroceryStore.Tests
{
    internal class TestDeal : IProvideDeals
    {
        public decimal GetDiscount(uint quantity, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}