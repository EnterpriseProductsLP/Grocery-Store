using System;

namespace GroceryStore.ConsoleApplication
{
    class Program
    {
        private static bool _lastSkuWasValid;

        private static bool _quit;

        private static Sale _sale = new Sale(new ItemBuilder());

        static void Main()
        {
            Console.SetBufferSize(1000, 9999);
            Console.ForegroundColor = ConsoleColor.White;
            Console.CancelKeyPress += ConsoleOnCancelKeyPress;

            Run();
        }

        private static void AddItemToSale(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                _lastSkuWasValid = false;
                _sale = new Sale(new ItemBuilder());
                return;
            }

            try
            {
                _lastSkuWasValid = true;
                _sale.AddItem(sku);
            }
            catch (ArgumentException ex)
            {
                if (ex.Message == $"The given SKU: {sku} is invalid.")
                {
                    _lastSkuWasValid = false;
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                }
            }
        }

        private static void ConsoleOnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"{e.SpecialKey} detected.  Stopping register.");
            _quit = true;
            e.Cancel = true;
            Environment.Exit(0);
        }

        private static void Run()
        {
            var sku = string.Empty;

            while (!_quit)
            {
                Console.Clear();
                WriteSale(sku);

                sku = ReadInput();
                AddItemToSale(sku);
            }
        }

        private static string ReadInput()
        {
            Console.Write("Scan product: ");
            var sku = Console.ReadLine();
            return string.IsNullOrWhiteSpace(sku) ? string.Empty : sku.Trim();
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

            Console.WriteLine($"{"SKU", -8}{"Product", -16}{"Qty", -4}{"Subtotal", -8}");
            Console.WriteLine("------- --------------- --- --------");
            foreach (var lineItem in _sale.LineItems)
            {
                var itemSku = $"{lineItem.Sku, -8}";
                var itemName = $"{lineItem.Name, -16}";
                var itemQuantity = $"{lineItem.Quantity, -4}";
                var itemSubtotal = $"{lineItem.RawTotal.ToString("C"), -8}";
                Console.WriteLine(itemSku + itemName + itemQuantity + itemSubtotal);
            }

            Console.WriteLine();
            Console.WriteLine($"{"Sale Total", 36}");
            Console.WriteLine($"{"----------", 36}");
            Console.WriteLine($"{_sale.Total.ToString("C"), 36}");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}