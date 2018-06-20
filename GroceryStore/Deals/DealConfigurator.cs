using System.Collections.Generic;

using GroceryStore.Extensions;
using GroceryStore.Interfaces;

namespace GroceryStore.Deals
{
    public class DealConfigurator : DealProvider, IConfigureDeals
    {
        public IDictionary<string, DealMetadata> ConfiguredDeals
        {
            get
            {
                var configuredDeals = new Dictionary<string, DealMetadata>();
                foreach (var deal in Deals)
                {
                    var sku = deal.Key;
                    var metaData = deal.Value.GetMetadata();
                    configuredDeals.Add(sku, metaData);
                }

                return configuredDeals;
            }
        }

        public void AddDeal(string sku, IDeal dealProvider)
        {
            RemoveDealIfOneExists(sku);

            Deals.Add(sku, dealProvider);
        }

        public void RemoveDeal(string sku)
        {
            RemoveDealIfOneExists(sku);
        }

        private void RemoveDealIfOneExists(string sku)
        {
            if (Deals.ContainsKey(sku))
            {
                Deals.Remove(sku);
            }
        }
    }
}