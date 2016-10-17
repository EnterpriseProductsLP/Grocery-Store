namespace GroceryStore
{
    public interface IConfigureDeals : IProvideDeals
    {
        void AddDeal(string sku, IDeal dealProvider);

        void ClearDeals();

        void RemoveDeal(string sku);
    }
}