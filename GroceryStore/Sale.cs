using System.Collections.Generic;
using System.Linq;
using GroceryStore.Discounts;

namespace GroceryStore
{
    public class Sale
    {
        private readonly DealConfigurator _dealConfigurator;

        private Sale()
        {
            LineItems = new List<LineItem>();
        }

        public Sale(DealConfigurator dealConfigurator) : this()
        {
            _dealConfigurator = dealConfigurator;
        }

        public IList<LineItem> LineItems { get; }

        public decimal Total => LineItems.Sum(item => item.RawTotal);

        public void AddItem(string sku)
        {
            var existingItem = LineItems.SingleOrDefault(lineItem => lineItem.Sku == sku);

            if (existingItem != null)
            {
                existingItem.AddOne();
            }
            else
            {
                var item = ItemBuilder.BuildItem(sku);
                var lineItem = new LineItem(item);
                LineItems.Add(lineItem);
            }
        }
    }
}
