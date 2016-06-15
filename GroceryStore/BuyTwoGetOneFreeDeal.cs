namespace GroceryStore
{
    public class BuyTwoGetOneFreeDeal : IProvideDeals
    {
        public decimal GetDiscount(uint quantity, decimal price)
        {
            if (quantity < 3)
            {
                return 0;
            }

            var workingQuantity = quantity;
            while (workingQuantity % 3 != 0)
            {
                workingQuantity -= 1;
            }

            return ApplyDiscount(quantity, price);
        }

        private decimal ApplyDiscount(uint quantity, decimal price)
        {
            return quantity / 3 * price;
        }
    }
}
