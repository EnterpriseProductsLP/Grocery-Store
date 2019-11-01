using System;
using GroceryStore.Deals;

namespace GroceryStore.ConsoleApplication
{
    public class DealMappingSingleton
    {
        private static readonly Lazy<IMapCharactersToDeals> lazy = new Lazy<IMapCharactersToDeals>(() => new DealMapping());

        public static IMapCharactersToDeals Instance = lazy.Value;
    }
}
