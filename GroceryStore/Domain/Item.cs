﻿using System;

namespace GroceryStore.Domain
{
    public class Item
    {
        public Item(string sku, string name, decimal price)
        {
            if (price < 0)
            {
                throw new ArgumentException("An item cannot have a negative price.", nameof(price));
            }

            if (price == 0)
            {
                throw new ArgumentException("An item cannot have a price of zero.", nameof(price));
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