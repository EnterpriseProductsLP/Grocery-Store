using System.Collections.Generic;
using System.Linq;

namespace GroceryStore
{
    public class Sale
    {
        private readonly IBuildItems _itemBuilder;

        public Sale(IBuildItems itemBuilder)
        {
            _itemBuilder = itemBuilder;
            LineItems = new List<LineItem>();
        }

        public IList<LineItem> LineItems { get; }

        public decimal Total => LineItems.Sum(item => item.RawTotal);

        public void AddItem(string sku)
        {
            var existingItem = LineItems.SingleOrDefault(lineItem => lineItem.Sku == sku);

            if (existingItem != null)
            {
                existingItem.AddOne();
            }
            else
            {
                var item = _itemBuilder.BuildItem(sku);
                var lineItem = new LineItem(item);
                LineItems.Add(lineItem);
            }
        }
    }
}
