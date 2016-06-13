namespace GroceryStore
{
    public class Item
    {
        public Item(string sku, string name, decimal price)
        {
            Sku = sku;
            Name = name;
            Price = price;
        }

        public string Name { get; }

        public decimal Price { get; }

        public string Sku { get; }
    }
}