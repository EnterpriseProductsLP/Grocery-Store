namespace GroceryStore.Deals
{
    [DealMetadata(DealConstants.DollarOffDeal.Identifier, DealConstants.DollarOffDeal.Description)]
    public class DollarOffDeal : FixedDiscountDeal
    {
        public DollarOffDeal() : base(1M)
        {
        }
    }
}