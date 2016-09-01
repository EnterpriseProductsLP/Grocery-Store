namespace GroceryStore
{
    public interface IDeal
    {
        decimal GetDiscount(uint quantity, decimal price);
    }
}