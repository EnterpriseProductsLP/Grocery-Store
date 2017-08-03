using System;
using System.Collections.Generic;

namespace GroceryStore.Domain
{
    public static class ItemBuilder
    {
        public static Item BuildItem(string sku)
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

        public static IEnumerable<string> SupportedSkus
        {
            get
            {
                yield return "839";
                yield return "1245";
                yield return "99999";
            }
        }
    }
}