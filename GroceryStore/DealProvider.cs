using System.Collections.Generic;

namespace GroceryStore
{
    public static class DealProvider
    {
        private static readonly Dictionary<string, IProvideDeals> Deals;

        static DealProvider()
        {
            Deals = new Dictionary<string, IProvideDeals>();
        }

        public static void AddDeal(string sku, IProvideDeals dealProvider)
        {
            RemoveDealIfOneExists(sku);

            Deals.Add(sku, dealProvider);
        }

        public static void ClearDeals()
        {
            Deals.Clear();
        }

        public static IProvideDeals GetDeal(string sku)
        {
            IProvideDeals dealProvider;
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