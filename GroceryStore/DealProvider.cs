using System.Collections.Generic;

namespace GroceryStore
{
    public static class DealProvider
    {
        private static readonly Dictionary<string, IDeal> Deals;

        static DealProvider()
        {
            Deals = new Dictionary<string, IDeal>();
        }

        public static void AddDeal(string sku, IDeal dealProvider)
        {
            RemoveDealIfOneExists(sku);

            Deals.Add(sku, dealProvider);
        }

        public static void ClearDeals()
        {
            Deals.Clear();
        }

        public static IDeal GetDeal(string sku)
        {
            IDeal dealProvider;
            return Deals.TryGetValue(sku, out dealProvider) ? dealProvider : null;
        }

        public static void RemoveDeal(string sku)
        {
            RemoveDealIfOneExists(sku);
        }

        private static void RemoveDealIfOneExists(string sku)
        {
            if (Deals.ContainsKey(sku))
            {
                Deals.Remove(sku);
            }
        }
    }
}
