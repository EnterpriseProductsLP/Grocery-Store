using System.Collections.Generic;

namespace GroceryStore.Discounts
{
    public interface IProvideDeals
    {
        void AddDeal(string sku, IDeal discountProvider);
        IDeal GetDeal(string sku);
    }

    public class DealConfigurator : IProvideDeals
    {
        private readonly Dictionary<string, IDeal> Deals;

        public DealConfigurator()
        {
            Deals = new Dictionary<string, IDeal>();
        }
        
        public void AddDeal(string sku, IDeal discountProvider)
        {
            Deals.Add(sku, discountProvider);
        }

        public IDeal GetDeal(string sku)
        {
            return Deals[sku];
        }
    }
}