namespace GroceryStore.Inventory
{
    public interface IBuildItems
    {
        Item BuildItem(string sku);
    }
}