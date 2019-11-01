using System;
using System.Linq;
using GroceryStore.Inventory;

namespace GroceryStore.ConsoleApplication
{
    internal class Program
    {

        private static bool _lastSkuWasValid;

        private static bool _running = true;

        private static Sale _sale = new Sale(DealConfiguratorSingleton.Instance, new ItemBuilder());

        public static void Main()
        {
            Console.SetBufferSize(1000, 9999);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CancelKeyPress += ExitApplication;

            Run();
        }

        private static void AddItemToSale(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                _lastSkuWasValid = false;
                _sale = new Sale(DealConfiguratorSingleton.Instance, new ItemBuilder());
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
                return;
            }

            _sale.AddItem(sku);
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

        private static string ReadSaleSku()
        {
            Console.Write("Scan product: ");
            var sku = Console.ReadLine();
            return sku.EmptyIfNullOrWhitespace();
        }

        private static void Run()
        {
            var consoleDealConfigurator = new ConsoleDealConfigurator();
            consoleDealConfigurator.ConfigureDeals();

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

            Console.WriteLine($"{"SKU",-8}{"Product",-16}{"Qty",-4}{"Raw Total",-10}{"Discount",-9}{"Subtotal",-8}");
            Console.WriteLine("------- --------------- --- --------- -------- --------");
            foreach (var lineItem in _sale.LineItems)
            {
                var itemSku = $"{lineItem.Sku,-8}";
                var itemName = $"{lineItem.Name,-16}";
                var itemQuantity = $"{lineItem.Quantity,-4}";
                var itemRawTotal = $"{lineItem.RawTotal,-10:C}";
                var itemDiscount = $"{lineItem.Discount,-9:C}";
                var itemSubtotal = $"{lineItem.Subtotal,-8:C}";
                Console.WriteLine(itemSku + itemName + itemQuantity + itemRawTotal + itemDiscount + itemSubtotal);
            }

            Console.WriteLine();
            Console.WriteLine($"{"Sale Total",36}");
            Console.WriteLine($"{"----------",36}");
            Console.WriteLine($"{_sale.Total,36:C}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
