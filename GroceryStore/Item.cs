namespace GroceryStore
{
    public class Item
    {
        private string _name;

        private decimal _price;

        private string _sku;

        public Item()
        {
            _name = string.Empty;
            _sku = string.Empty;
        }

        public Item(string sku, string name, decimal price)
        {
            _sku = sku;
            _name = name;
            _price = price;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public decimal Price
        {
            get
            {
                return _price;
            }
        }

        public string Sku
        {
            get
            {
                return _sku;
            }
        }
    }
}