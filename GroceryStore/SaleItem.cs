namespace GroceryStore.Tests
{
    public class SaleItem
    {
        private readonly Item _item;

        private int _quantity;

        public SaleItem(Item item)
        {
            _item = item;
            AddOne();
        }

        public int Quantity => _quantity;

        public decimal Subtotal => Quantity * _item.Price;

        public Item Item => _item;

        public void AddOne()
        {
            _quantity += 1;
        }
    }
}