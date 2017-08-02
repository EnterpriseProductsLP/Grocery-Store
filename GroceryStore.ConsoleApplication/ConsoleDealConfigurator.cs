using System;
using System.Collections.Generic;
using System.Linq;
using GroceryStore.Deals;
using GroceryStore.Domain;
using GroceryStore.Extensions;

namespace GroceryStore.ConsoleApplication
{
    internal class ConsoleDealConfigurator
    {
        private static bool _configuringDeals = true;
        private static bool _lastDealTypeWasValid;
        private static bool _lastDiscountSkuWasValid;

        public void ConfigureDeals()
        {
            var sku = string.Empty;
            var dealMetaData = new DealMetadata(default(char), default(string));

            while (_configuringDeals)
            {
                Console.Write("Add a Discount [Y/N]?:  ");
                var input = Console.ReadKey().KeyChar;
                var validInputs = new List<char> {'y', 'Y', 'n', 'N'};
                var inputIsValid = validInputs.Contains(input);

                if (!inputIsValid)
                {
                    Console.Clear();
                    Console.WriteLine("Input invalid.  Please enter 'y', 'n', 'Y', or 'N'");
                    continue;
                }

                if (input == 'n' || input == 'N')
                {
                    _configuringDeals = false;
                    continue;
                }

                Console.Clear();
                WriteDiscounts(sku, dealMetaData.Description);

                sku = ReadDiscountSku();
                var dealType = ReadDiscountDealType();
                dealMetaData = AddDealForSku(sku, dealType);
            }
        }
        
        private static DealMetadata AddDealForSku(string sku, char dealType)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                _lastDiscountSkuWasValid = false;
                return null;
            }

            if (string.IsNullOrWhiteSpace(dealType.ToString()))
            {
                _lastDealTypeWasValid = false;
                return null;
            }

            _lastDiscountSkuWasValid = true;
            _lastDealTypeWasValid = true;

            if (!ItemBuilder.SupportedSkus.Contains(sku))
            {
                _lastDiscountSkuWasValid = false;
                Console.Clear();
                Console.WriteLine($"The given SKU: {sku} is invalid.");
            }

            if (!DealMappingSingleton.Instance.SupportedDeals.Select(x => x.Identifier).ToList().Contains(dealType))
            {
                _lastDealTypeWasValid = false;
                Console.Clear();
                Console.WriteLine($"The given deal type: '{sku}' is invalid.");
            }

            if (_lastDiscountSkuWasValid == false || _lastDealTypeWasValid == false)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return null;
            }

            var deal = DealMappingSingleton.Instance.GetDeal(dealType);
            DealConfiguratorSingleton.Instance.AddDeal(sku, deal);
            return deal.GetMetadata();
        }

        private static char ReadDiscountDealType()
        {
            var dealTypes = DealMappingSingleton.Instance.SupportedDeals.Select(x => x.Identifier.ToString());
            var joinedDealTypes = string.Join("/", dealTypes);

            Console.Write($"Enter deal type [{joinedDealTypes}]: ");
            return Console.ReadKey().KeyChar;
        }

        private static string ReadDiscountSku()
        {
            Console.Write("Enter SKU: ");
            var sku = Console.ReadLine();
            return sku.EmptyIfNullOrWhitespace();
        }

        private void WriteDiscounts(string newSku, string newDescription)
        {
            if (_lastDiscountSkuWasValid && _lastDealTypeWasValid)
            {
                Console.WriteLine($"{newDescription} applied to item: {newSku}");
                Console.WriteLine();
            }

            if (!DealConfiguratorSingleton.Instance.ConfiguredDeals.Any())
            {
                return;
            }

            Console.WriteLine($"{"SKU",-8}{"Applied Discount",-28}");
            Console.WriteLine("------- ----------------------------");
            foreach (var configuredDeal in DealConfiguratorSingleton.Instance.ConfiguredDeals)
            {
                var itemSku = $"{configuredDeal.Key,-8}";
                var dealDescription = $"{configuredDeal.Value.Description,-28}";
                Console.WriteLine(itemSku + dealDescription);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }


    }
}
