using System.Collections.Generic;

namespace GroceryStore.Deals
{
    public interface IConfigureDeals : IProvideDeals
    {
        IDictionary<string, DealMetadata> ConfiguredDeals { get; }

        void AddDeal(string sku, IDeal dealProvider);
    }
}