namespace GroceryStore
{
    public class DoNothingDealProvider : IProvideDeals
    {
        public IDeal GetDeal(string sku)
        {
            return new DoNothingDeal();
        }
    }
}