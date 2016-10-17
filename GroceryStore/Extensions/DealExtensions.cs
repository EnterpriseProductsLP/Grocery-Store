using System;
using System.Reflection;
using GroceryStore.Deals;
using GroceryStore.Interfaces;

namespace GroceryStore.Extensions
{
    public static class DealExtensions
    {
        public static DealMetadata GetMetadata(this IDeal deal)
        {
            var dealType = deal.GetType();
            var dealMetadata = dealType.GetCustomAttribute<DealMetadata>();
            if (dealMetadata == null)
            {
                throw new Exception($"The provided deal type {dealType.Name} does not have the required DealMetadata attribute.");
            }

            return dealMetadata;
        }
    }
}