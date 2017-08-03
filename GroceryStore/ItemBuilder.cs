using System;

namespace GroceryStore
{
    public class ItemBuilder : IBuildItems
    {
        public Item BuildItem(string sku)
        {
            switch (sku)
            {
                case "839":
                    {
                        return new Item("839", "Rubber Bands", 10M);
                    }

                case "1245":
                    {
                        return new Item("1245", "Bananas", 1.25M);
                    }

                case "99999":
                    {
                        return new Item("99999", "Pepto Bismol", 4.88M);
                    }

                default:
                    {
                        throw new ArgumentException($"The given SKU: {sku} is invalid.");
                    }
            }
        }
    }
}