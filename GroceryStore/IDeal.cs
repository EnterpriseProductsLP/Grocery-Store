namespace GroceryStore
{
    public interface IDeal
    {
        decimal GetDiscount(int qty, decimal price);
    }
}