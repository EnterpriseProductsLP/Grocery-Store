namespace GroceryStore.Discounts
{
    public interface IDeal
    {
        decimal GetDiscount(uint quantity, decimal price);
    }
}