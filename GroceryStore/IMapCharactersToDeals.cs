using System.Collections.Generic;

namespace GroceryStore
{
    public interface IMapCharactersToDeals
    {
        IEnumerable<DealMetadata> SupportedDeals { get; }

        IDeal GetDeal(char c);
    }
}