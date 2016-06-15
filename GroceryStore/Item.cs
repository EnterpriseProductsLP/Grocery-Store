using System;

namespace GroceryStore
{
    public class Item
    {
        public Item(string sku, string name, decimal price)
        {
            if (price <= 0M)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be greater than zero");
            }

            Sku = sku;
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public decimal Price { get; }

        public string Sku { get; }
    }
}