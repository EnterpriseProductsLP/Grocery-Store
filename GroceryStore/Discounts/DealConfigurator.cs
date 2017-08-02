using System.Collections.Generic;

namespace GroceryStore.Discounts
{
    public class DealConfigurator
    {
        private readonly Dictionary<string, IProvideDiscounts> Deals;

        public DealConfigurator()
        {
            Deals = new Dictionary<string, IProvideDiscounts>();
        }
        
        public void AddDeal(string sku, IProvideDiscounts discountProvider)
        {
            Deals.Add(sku, discountProvider);
        }

        public IProvideDiscounts GetDeal(string sku)
        {
            return Deals[sku];
        }
    }
}