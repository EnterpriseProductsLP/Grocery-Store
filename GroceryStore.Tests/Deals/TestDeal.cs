using System;
using GroceryStore.Deals;

namespace GroceryStore.Tests.Deals
{
    internal class TestDeal : IDeal
    {
        public decimal GetDiscount(uint quantity, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}