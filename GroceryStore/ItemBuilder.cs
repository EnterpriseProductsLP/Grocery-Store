using System;

namespace GroceryStore
{
    public static class ItemBuilder
    {
        public static Item BuildItem(string sku)
        {
            switch (sku)
            {
                case "1245":
                    {
                        return new Item("1245", "Bananas", 1.25M);
                    }

                case "99999":
                    {
                        return new Item("99999", "Pepto Bismol", 4.88M);
                    }

                case "839":
                    {
                        return new Item("839", "Rubber Bands", 10M);
                    }

                default:
                    {
                        throw new ArgumentException($"The give sku: {sku} is invalid.");
                    }
            }
        }
    }
}