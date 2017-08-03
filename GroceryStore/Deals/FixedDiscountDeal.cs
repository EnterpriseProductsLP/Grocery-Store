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
                return quantity * price;
            }

            return quantity * _fixedDiscount;
        }
    }
}