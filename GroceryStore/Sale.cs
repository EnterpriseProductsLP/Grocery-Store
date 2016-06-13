using System.Collections.Generic;
using System.Linq;

using GroceryStore.Tests;

namespace GroceryStore
{
    public class Sale
    {
        public Sale()
        {
            Items = new List<SaleItem>();
        }

        public IList<SaleItem> Items { get; }

        public decimal Total => Items.Sum(item => item.Subtotal);

        public void AddItem(string sku)
        {
            var existingItem = Items.SingleOrDefault(saleItem => saleItem.Item.Sku == sku);

            if (existingItem != null)
            {
                existingItem.AddOne();
            }
            else
            {
                var item = ItemBuilder.BuildItem(sku);
                var saleItem = new SaleItem(item);
                Items.Add(saleItem);
            }
        }
    }
}