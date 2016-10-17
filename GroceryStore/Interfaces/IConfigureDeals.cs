using System.Collections.Generic;
using GroceryStore.Deals;

namespace GroceryStore.Interfaces
{
    public interface IConfigureDeals : IProvideDeals
    {
        IEnumerable<DealMetadata> ConfiguredDeals { get; }

        void AddDeal(string sku, IDeal dealProvider);

        void ClearDeals();

        void RemoveDeal(string sku);
    }
}