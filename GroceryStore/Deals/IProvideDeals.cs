namespace GroceryStore.Deals
{
    public interface IProvideDeals
    {
        IDeal GetDeal(string sku);
    }
}