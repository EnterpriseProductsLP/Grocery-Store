using System.Collections.Generic;
using GroceryStore.Extensions;
using GroceryStore.Interfaces;

namespace GroceryStore.Deals
{
    public class DealConfigurator : DealProvider, IConfigureDeals
    {
        public IEnumerable<DealMetadata> ConfiguredDeals
        {
            get
            {
                foreach (var deal in Deals.Values)
                {
                    yield return deal.GetMetadata();
                }
            }
        }

        public void AddDeal(string sku, IDeal dealProvider)
        {
            RemoveDealIfOneExists(sku);

            Deals.Add(sku, dealProvider);
        }

        public void ClearDeals()
        {
            Deals.Clear();
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