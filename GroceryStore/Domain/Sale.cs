using System.Collections.Generic;
using System.Linq;
using GroceryStore.Deals;
using GroceryStore.Interfaces;

namespace GroceryStore.Domain
{
    public class Sale
    {
        private readonly IProvideDeals _dealProvider;

        public Sale(IProvideDeals dealProvider = null)
        {
            _dealProvider = dealProvider ?? new DoNothingDealProvider();
            LineItems = new List<LineItem>();
        }

        public IList<LineItem> LineItems { get; }

        public decimal Total => LineItems.Sum(item => item.Subtotal);

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
                var lineItem = new LineItem(item, _dealProvider);
                LineItems.Add(lineItem);
            }
        }
    }
}
