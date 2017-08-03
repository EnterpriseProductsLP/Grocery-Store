using System;
using GroceryStore.Interfaces;

namespace GroceryStore.Deals
{
    public abstract class FixedDiscountDeal : IDeal
    {
        private readonly decimal _fixedDiscount;

        protected FixedDiscountDeal(decimal fixedDiscount)
        {
            _fixedDiscount = fixedDiscount;
        }

        public decimal GetDiscount(uint quantity, decimal price)
        {
            if (price < _fixedDiscount)
            {
                throw new InvalidOperationException("We're not in the business of giving away merchandise.");
            }

            return quantity * _fixedDiscount;
        }
    }
}