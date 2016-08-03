using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace GroceryStore
{
    public static class DealProvider
    {
        private static Dictionary<string, IDeal> deals = new Dictionary<string, IDeal>();

        public static void Clear()
        {
            deals.Clear();
            //throw new System.NotImplementedException();
        }

        public static void AddDeal(string sku, IDeal deal)
        {
            deals.Add(sku, deal);
            //throw new System.NotImplementedException();
        }

        public static IDeal GetDeal(string sku)
        {
            IDeal deal;
            if (deals.TryGetValue(sku, out deal))
            {
                return deal;
            }
            return null;
        }
    }

    public interface IDeal
    {
        decimal GetDiscount(int qty, decimal price);
    }

    public class DollarOffDeal : IDeal
    {
        public decimal GetDiscount(int qty, decimal price)
        {
            return qty;
        }
    }
}