namespace GroceryStore
{
    internal class DoNothingDeal : IDeal
    {
        public decimal GetDiscount(uint quantity, decimal price)
        {
            return 0;
        }
    }
}