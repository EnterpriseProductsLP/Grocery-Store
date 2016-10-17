namespace GroceryStore.Interfaces
{
    public interface IDeal
    {
        decimal GetDiscount(uint quantity, decimal price);
    }
}