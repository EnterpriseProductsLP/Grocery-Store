﻿using GroceryStore.Interfaces;

namespace GroceryStore.Deals
{
    public abstract class BuySomeGetOneFreeDeal : IDeal
    {
        private readonly uint _countRequiredToGetFreeOne;

        protected BuySomeGetOneFreeDeal(uint countRequiredToGetFreeOne)
        {
            _countRequiredToGetFreeOne = countRequiredToGetFreeOne;
        }

        public decimal GetDiscount(uint quantity, decimal price)
        {
            // Warning disabled.  Loss of fraction is the intended behavior.
            // ReSharper disable once PossibleLossOfFraction
            return quantity/(_countRequiredToGetFreeOne + 1)*price;
        }
    }
}