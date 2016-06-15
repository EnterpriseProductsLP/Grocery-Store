using System;
using System.Collections.Generic;

namespace GroceryStore
{
    public static class DealProvider
    {
        private static readonly Dictionary<string, Type> Deals;

        static DealProvider()
        {
            Deals = new Dictionary<string, Type>();
        }

        public static void AddDeal<T>(string sku) where T : IProvideDeals, new()
        {
            RemoveDealIfOneExists(sku);

            Deals.Add(sku, typeof(T));
        }

        public static void ClearDeals()
        {
            Deals.Clear();
        }

        public static IProvideDeals GetDeal(string sku)
        {
            Type type;
            if (!Deals.TryGetValue(sku, out type))
            {
                return null;
            }

            var assemblyName = type.Assembly.GetName().Name;
            var typeName = type.FullName;
            var instanceHandle = Activator.CreateInstance(assemblyName, typeName);
            return (IProvideDeals)instanceHandle.Unwrap();
        }

        public static void RemoveDeal(string sku)
        {
            RemoveDealIfOneExists(sku);
        }

        private static void RemoveDealIfOneExists(string sku)
        {
            if (Deals.ContainsKey(sku))
            {
                Deals.Remove(sku);
            }
        }
    }
}