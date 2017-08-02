using System.Collections.Generic;
using GroceryStore.Deals;

namespace GroceryStore.Interfaces
{
    public interface IMapCharactersToDeals
    {
        IEnumerable<DealMetadata> SupportedDeals { get; }

        IDeal GetDeal(char c);
    }
}