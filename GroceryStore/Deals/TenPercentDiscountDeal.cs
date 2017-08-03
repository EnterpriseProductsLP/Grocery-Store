namespace GroceryStore.Deals
{
    [DealMetadata(DealConstants.TenPercentDiscountDeal.Identifier, DealConstants.TenPercentDiscountDeal.Description)]
    public class TenPercentDiscountDeal : PercentageOffDeal
    {
        public TenPercentDiscountDeal() : base(0.1M)
        {
        }
    }
}