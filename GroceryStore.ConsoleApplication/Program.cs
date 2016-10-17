using System;

namespace GroceryStore.ConsoleApplication
{
    class Program
    {
        private static bool _lastSkuWasValid;

        private static bool _running = true;

        private static Sale _sale = new Sale();

        private static readonly bool _configuringDeals = true;

        static void Main()
        {
            Console.CancelKeyPress += ConsoleOnCancelKeyPress;

            Run();
        }

        private static void AddDiscount(string sku, string dealType)
        {
            throw new NotImplementedException();
        }

        private static void AddItemToSale(string sku)
        {
            if (string.IsNullOrWhiteSpace(sku))
            {
                _lastSkuWasValid = false;
                _sale = new Sale();
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
            _running = false;
            e.Cancel = true;
            Environment.Exit(0);
        }

        private static void Run()
        {
            DealLoop();

            SalesLoop();
        }

        private static void DealLoop()
        {
            var sku = string.Empty;
            var dealType = string.Empty;

            while (_configuringDeals)
            {
                Console.Clear();
                WriteDiscounts(sku, dealType);

                sku = ReadDiscountSku();
                dealType = ReadDiscountDealType();
                AddDiscount(sku, dealType);

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

        private static string ReadDiscountDealType()
        {
            throw new NotImplementedException();
        }

        private static string ReadDiscountSku()
        {
            throw new NotImplementedException();
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

        private static string ReadSaleSku()
        {
            Console.Write("Scan product: ");
            var sku = Console.ReadLine();
            return string.IsNullOrWhiteSpace(sku) ? string.Empty : sku.Trim();
        }

        private static void WriteDiscounts(string sku, string dealType)
        {
            throw new NotImplementedException();
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