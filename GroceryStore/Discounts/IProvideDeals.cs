namespace GroceryStore.Discounts
{
    public interface IProvideDeals
    {
        void AddDeal(string sku, IDeal discountProvider);
        IDeal GetDeal(string sku);
    }
}