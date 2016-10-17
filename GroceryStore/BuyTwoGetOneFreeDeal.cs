namespace GroceryStore
{
    [DealMetadata('c', "Buy two get one free.")]
    public class BuyTwoGetOneFreeDeal : BuySomeGetOneFreeDeal
    {
        public BuyTwoGetOneFreeDeal() : base(2)
        {
        }
    }
}