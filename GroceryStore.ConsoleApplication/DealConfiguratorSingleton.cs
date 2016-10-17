using System;

namespace GroceryStore
{
    public class DealConfiguratorSingleton
    {
        private static readonly Lazy<IConfigureDeals> lazy = new Lazy<IConfigureDeals>(() => new DealConfigurator());

        public static IConfigureDeals Instance => lazy.Value;
    }
}