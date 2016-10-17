namespace GroceryStore
{
    public class DealConfigurator : DealProvider, IConfigureDeals
    {
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