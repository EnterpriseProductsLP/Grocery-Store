using System.Collections.Generic;

namespace GroceryStore.Deals
{
    public interface IMapCharactersToDeals
    {
        IEnumerable<DealMetadata> SupportedDeals { get; }

        IDeal GetDeal(char c);
    }
}