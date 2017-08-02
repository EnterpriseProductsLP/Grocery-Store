namespace GroceryStore.Deals
{
    [DealMetadata(DealConstants.BuyTwoGetOneFreeDeal.Identifier, DealConstants.BuyTwoGetOneFreeDeal.Description)]
    public class BuyTwoGetOneFreeDeal : BuySomeGetOneFreeDeal
    {
        public BuyTwoGetOneFreeDeal() : base(2)
        {
        }
    }
}