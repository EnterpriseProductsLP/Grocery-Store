namespace GroceryStore
{
    public class LineItem
    {
        private readonly IProvideDeals _dealProvider;

        public LineItem(Item item, IProvideDeals dealProvider)
        {
            _dealProvider = dealProvider;
            Item = item;
            AddOne();
        }

        public Item Item { get; }

        public uint Quantity { get; private set; }

        public decimal RawTotal => Quantity * Item.Price;

        public decimal Subtotal => RawTotal - Discount;

        public decimal Discount => _dealProvider?.GetDiscount(Quantity, Item.Price) ?? 0;

        public void AddOne()
        {
            Quantity += 1;
        }
    }
}