using System;
using System.Collections.Generic;
using System.Linq;

using GroceryStore.Deals;
using GroceryStore.Domain;
using GroceryStore.Extensions;

namespace GroceryStore.ConsoleApplication
{
    internal class Program
    {

        private static bool _lastDiscountSkuWasValid;

        private static bool _lastDealTypeWasValid;
        private static bool _lastSkuWasValid;

        private static bool _running = true;

        private static Sale _sale = new Sale(DealConfiguratorSingleton.Instance);

        private static bool _configuringDeals = true;

        public static void Main()
        {
            Console.SetBufferSize(1000, 9999);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CancelKeyPress += ExitApplication;

            Run();
        }

        private static DealMetadata AddDealForSku(string sku, char dealType)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                _lastSkuWasValid = false;
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

        private static void AddItemToSale(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                _lastSkuWasValid = false;
                _sale = new Sale(DealConfiguratorSingleton.Instance);
                return;
            }

            _lastSkuWasValid = true;
            if (!ItemBuilder.SupportedSkus.Contains(sku))
            {
                _lastSkuWasValid = false;
                Console.Clear();
                Console.WriteLine($"The given SKU: {sku} is invalid.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }

            _sale.AddItem(sku);
        }

        private static void DealConfigurationLoop()
        {
            var sku = string.Empty;
            var dealMetaData = new DealMetadata(default(char), default(string));

            while (_configuringDeals)
            {
                Console.Write("Add a Discount [Y/N]?:  ");
                var input = Console.ReadKey().KeyChar;
                var validInputs = new List<char> { 'y', 'Y', 'n', 'N' };
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

        private static string EmptyIfNullOrWhitespace(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? string.Empty : s.Trim();
        }

        private static void ExitApplication(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{e.SpecialKey} detected.  Stopping register.");
            _running = false;
            e.Cancel = true;
            Environment.Exit(0);
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
            return EmptyIfNullOrWhitespace(sku);
        }

        private static string ReadSaleSku()
        {
            Console.Write("Scan product: ");
            var sku = Console.ReadLine();
            return EmptyIfNullOrWhitespace(sku);
        }

        private static void Run()
        {
            DealConfigurationLoop();

            SalesLoop();
        }

        private static void SalesLoop()
        {
            var sku = string.Empty;
            while (_running)
            {
                Console.Clear();
                WriteSale(sku);

                sku = ReadSaleSku();
                AddItemToSale(sku);
            }
        }

        private static void WriteDiscounts(string newSku, string newDescription)
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

        private static void WriteSale(string newSku)
        {
            if (_lastSkuWasValid)
            {
                Console.WriteLine($"Product scanned: {newSku}");
                Console.WriteLine();
            }

            if (!_sale.LineItems.Any())
            {
                return;
            }

            Console.WriteLine($"{"SKU",-8}{"Product",-16}{"Qty",-4}{"Subtotal",-8}");
            Console.WriteLine("------- --------------- --- --------");
            foreach (var lineItem in _sale.LineItems)
            {
                var itemSku = $"{lineItem.Sku,-8}";
                var itemName = $"{lineItem.Name,-16}";
                var itemQuantity = $"{lineItem.Quantity,-4}";
                var itemSubtotal = $"{lineItem.RawTotal.ToString("C"),-8}";
                Console.WriteLine(itemSku + itemName + itemQuantity + itemSubtotal);
            }

            Console.WriteLine();
            Console.WriteLine($"{"Sale Total",36}");
            Console.WriteLine($"{"----------",36}");
            Console.WriteLine($"{_sale.Total.ToString("C"),36}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
