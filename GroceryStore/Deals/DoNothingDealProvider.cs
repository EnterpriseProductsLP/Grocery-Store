namespace GroceryStore.Deals
{
    public class DoNothingDealProvider : IProvideDeals
    {
        public IDeal GetDeal(string sku)
        {
            return new DoNothingDeal();
        }
    }
}