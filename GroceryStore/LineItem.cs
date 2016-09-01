namespace GroceryStore
{
    public class LineItem
    {
        public LineItem(Item item)
        {
            Item = item;
            AddOne();
        }

        private Item Item { get; }

        public int Quantity { get; private set; }

        public decimal RawTotal => Quantity * Item.Price;

        public string Sku => Item.Sku;

        public string Name => Item.Name;

        public decimal Price => Item.Price;

        public void AddOne()
        {
            Quantity += 1;
        }
    }
}