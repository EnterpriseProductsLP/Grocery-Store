using System;
using System.Collections.Generic;
using System.Reflection;

namespace GroceryStore
{
    public class DealMapping : IMapCharactersToDeals
    {
        private IList<IDeal> _supportedDeals { get; set; }

        public DealMapping()
        {
            _supportedDeals = new List<IDeal>
            {
                new BuyTwoGetOneFreeDeal()
            };
        }

        public IEnumerable<DealMetadata> SupportedDeals
        {
            get
            {
                var supportedIdentifiers = new List<char>();
                foreach (var supportedDeals in _supportedDeals)
                {
                    var dealType = supportedDeals.GetType();
                    var dealMetadata = dealType.GetCustomAttribute<DealMetadata>();
                    if (dealMetadata == null)
                    {
                        throw new Exception($"The provided deal type {dealType.Name} does not have the required DealMetadata attribute.");
                    }

                    var identifier = dealMetadata.Identifier;
                    if (supportedIdentifiers.Contains(identifier))
                    {
                        throw new Exception($"This implementation of IMapCharactersToDeals contains supports more tha one deal with the given identifier:  {identifier}.");
                    }

                    supportedIdentifiers.Add(identifier);
                    yield return dealMetadata;
                }
            }
        }

        public IDeal GetDeal(char c)
        {
            throw new NotImplementedException();
        }
    }
}