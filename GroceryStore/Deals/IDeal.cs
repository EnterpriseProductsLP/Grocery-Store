namespace GroceryStore.Deals
{
    public interface IDeal
    {
        decimal GetDiscount(uint quantity, decimal price);
    }
}