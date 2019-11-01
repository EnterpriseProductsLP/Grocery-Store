using System;
using System.Reflection;

namespace GroceryStore.Deals
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