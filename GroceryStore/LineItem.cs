namespace GroceryStore
{
    public class LineItem
    {
        public LineItem(Item item)
        {
            Item = item;
            AddOne();
        }

        public Item Item { get; }

        public int Quantity { get; private set; }

        public decimal Subtotal => Quantity * Item.Price;

        public void AddOne()
        {
            Quantity += 1;
        }
    }
}