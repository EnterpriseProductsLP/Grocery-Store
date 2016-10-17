using System;
using System.Linq;
using GroceryStore.Domain;

namespace GroceryStore.ConsoleApplication
{
    internal class Program
    {
        private static bool _lastDealTypeWasValid;

        private static bool _lastDiscountSkuWasValid;

        private static bool _lastSkuWasValid;

        private static bool _running = true;

        private static Sale _sale = new Sale(DealConfiguratorSingleton.Instance);

        private static readonly bool _configuringDeals = true;

        private static void Main()
        {
            Console.CancelKeyPress += ExitApplication;

            Run();
        }

        private static void AddDealForSku(string sku, char dealType)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                _lastSkuWasValid = false;
                return;
            }

            if (string.IsNullOrWhiteSpace(dealType.ToString()))
            {
                _lastDealTypeWasValid = false;
                return;
            }

            _lastDiscountSkuWasValid = true;
            _lastDealTypeWasValid = true;

            if (!ItemBuilder.SupportedSkus.Contains(sku))
            {
                _lastDiscountSkuWasValid = false;
                Console.Clear();
                Console.WriteLine($"The given SKU: {sku} is invalid.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            if (!DealMappingSingleton.Instance.SupportedDeals.Select(x => x.Identifier).ToList().Contains(dealType))
            {
                _lastDealTypeWasValid = false;
                Console.Clear();
                Console.WriteLine($"The given deal type: '{sku}' is invalid.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }

            var deal = DealMappingSingleton.Instance.GetDeal(dealType);
            DealConfiguratorSingleton.Instance.AddDeal(sku, deal);
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
            var dealType = ' ';

            while (_configuringDeals)
            {
                Console.Clear();
                WriteDiscounts(sku, dealType);

                sku = ReadDiscountSku();
                dealType = ReadDiscountDealType();
                AddDealForSku(sku, dealType);

                // Console.Write("Add a Discount [Y/N]?:  ");
                // var input = Console.ReadLine();
                // var inputIsValid = new List<string> { "y", "Y", "n", "N" }.Contains(input);

                // if (!inputIsValid)
                // {
                // Console.WriteLine("Input invalid.  Please enter 'y', 'n', 'Y', or 'N'");
                // Console.WriteLine("Press any key to continue...");
                // Console.ReadLine();
                // continue;
                // }

                // Console.WriteLine("What SKU should this discount apply to?:  ");
                // input = Console.ReadLine()
            }
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
            throw new NotImplementedException();
        }

        private static string ReadDiscountSku()
        {
            throw new NotImplementedException();
        }

        private static string ReadSaleSku()
        {
            Console.Write("Scan product: ");
            var sku = Console.ReadLine();
            return string.IsNullOrWhiteSpace(sku) ? string.Empty : sku.Trim();
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

        private static void WriteDiscounts(string sku, char dealType)
        {
            if (_lastDiscountSkuWasValid && _lastDealTypeWasValid)
            {
                Console.WriteLine($"Product scanned: {sku}");
                Console.WriteLine();
            }

            if (_sale.LineItems.Count <= 0)
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

        private static void WriteSale(string sku)
        {
            if (_lastSkuWasValid)
            {
                Console.WriteLine($"Product scanned: {sku}");
                Console.WriteLine();
            }

            if (_sale.LineItems.Count <= 0)
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