using System;
using System.Collections.Generic;
using GroceryStore.Extensions;
using GroceryStore.Interfaces;

namespace GroceryStore.Deals
{
    public class DealMapping : IMapCharactersToDeals
    {
        private readonly IDictionary<char, IDeal> _mappedDeals;

        private readonly IList<IDeal> _supportedDeals;

        public DealMapping()
        {
            _supportedDeals = new List<IDeal>
            {
                new DollarOffDeal(),
                new BuyTwoGetOneFreeDeal()
            };

            _mappedDeals = new Dictionary<char, IDeal>();
            foreach (var deal in _supportedDeals)
            {
                var identifier = deal.GetMetadata().Identifier;
                _mappedDeals.Add(identifier, deal);
            }
        }

        public IEnumerable<DealMetadata> SupportedDeals
        {
            get
            {
                var supportedIdentifiers = new List<char>();
                foreach (var deal in _supportedDeals)
                {
                    var metadata = deal.GetMetadata();
                    if (supportedIdentifiers.Contains(metadata.Identifier))
                    {
                        throw new Exception($"This implementation of IMapCharactersToDeals contains supports more tha one deal with the given identifier:  {metadata.Identifier}.");
                    }
                    supportedIdentifiers.Add(metadata.Identifier);

                    yield return metadata;
                }
            }
        }

        public IDeal GetDeal(char c)
        {
            IDeal deal;
            return _mappedDeals.TryGetValue(c, out deal)
                ? deal
                : new DoNothingDeal();
        }
    }
}