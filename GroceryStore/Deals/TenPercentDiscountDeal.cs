using System;
using GroceryStore.Interfaces;

namespace GroceryStore.Deals
{
    public class TenPercentDiscountDeal : IDeal
    {
        public decimal GetDiscount(uint quantity, decimal price)
        {
            var rawDiscount = (quantity * price) * 0.1M;
            var decimalDiscount = Math.Round(rawDiscount, 2, MidpointRounding.AwayFromZero);
            return decimalDiscount;
        }
    }
}