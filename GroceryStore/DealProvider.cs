using System.Collections.Generic;

namespace GroceryStore
{
    public static class DealProvider
    {
        private static readonly Dictionary<string, IDeal> deals;

        static DealProvider()
        {
            deals = new Dictionary<string, IDeal>();
        }

        public static void Clear()
        {
            deals.Clear();
        }

        public static void AddDeal(string sku, IDeal deal)
        {
            deals.Add(sku, deal);
        }

        public static IDeal GetDeal(string sku)
        {
            IDeal deal;
            return deals.TryGetValue(sku, out deal) ? deal : null;
        }
    }
}