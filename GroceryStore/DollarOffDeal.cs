namespace GroceryStore
{
    public class DollarOffDeal : IDeal
    {
        public decimal GetDiscount(int qty, decimal price)
        {
            return qty;
        }
    }
}