using System;
using GroceryStore.Deals;

namespace GroceryStore.ConsoleApplication
{
    public class DealConfiguratorSingleton
    {
        private static readonly Lazy<IConfigureDeals> Lazy = new Lazy<IConfigureDeals>(() => new DealConfigurator());

        public static IConfigureDeals Instance => Lazy.Value;
    }
}
