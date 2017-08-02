namespace GroceryStore.Interfaces
{
    public interface IProvideDeals
    {
        IDeal GetDeal(string sku);
    }
}