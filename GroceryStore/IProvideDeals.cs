namespace GroceryStore
{
    public interface IProvideDeals
    {
        IDeal GetDeal(string sku);
    }
}