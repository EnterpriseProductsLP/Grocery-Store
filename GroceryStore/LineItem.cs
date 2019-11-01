using GroceryStore.Deals;

namespace GroceryStore
{
    public class LineItem
    {
        private readonly IDeal _deal;

        public LineItem(Item item, IProvideDeals dealProvider = null)
        {
            Item = item;
            _deal = dealProvider == null ? new DoNothingDeal() : dealProvider.GetDeal(Sku);
            AddOne();
        }

        public decimal Discount => _deal.GetDiscount(Quantity, Price);

        private Item Item { get; }

        public string Name => Item.Name;

        public decimal Price => Item.Price;

        public uint Quantity { get; private set; }

        public decimal RawTotal => Quantity * Item.Price;

        public string Sku => Item.Sku;

        public decimal Subtotal => RawTotal - Discount;

        public void AddOne()
        {
            Quantity += 1;
        }
    }
}