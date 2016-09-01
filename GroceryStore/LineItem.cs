namespace GroceryStore
{
    public class LineItem
    {
        private readonly IDeal _deal;

        public LineItem(Item item)
        {
            _deal = DealProvider.GetDeal(item.Sku);
            Item = item;
            AddOne();
        }

        public decimal Discount => _deal.GetDiscount(Quantity, Item.Price);

        public string Name => Item.Name;

        public decimal Price => Item.Price;

        public uint Quantity { get; private set; }

        public decimal RawTotal => Quantity * Item.Price;

        public string Sku => Item.Sku;

        public decimal Subtotal => RawTotal - Discount;

        private Item Item { get; }

        public void AddOne()
        {
            Quantity += 1;
        }
    }
}