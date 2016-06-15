namespace GroceryStore
{
    public interface IProvideDeals
    {
        decimal GetDiscount(uint quantity, decimal price);
    }
}