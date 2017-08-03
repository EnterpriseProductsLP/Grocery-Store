using System;
using GroceryStore.Interfaces;

namespace GroceryStore.Deals
{
    public abstract class PercentageOffDeal : IDeal
    {
        private readonly decimal _discountPercent;

        protected PercentageOffDeal(decimal discountPercent)
        {
            _discountPercent = discountPercent;
        }

        public decimal GetDiscount(uint quantity, decimal price)
        {
            var rawDiscount = (quantity * price) * _discountPercent;
            var roundedDiscount = Math.Round(rawDiscount, 2, MidpointRounding.AwayFromZero);
            return roundedDiscount;
        }
    }
    
    public class TenPercentDiscountDeal : PercentageOffDeal
    {
        public TenPercentDiscountDeal() : base(0.1M)
        {
        }
    }
}