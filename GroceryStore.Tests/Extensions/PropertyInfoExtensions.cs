using System.Globalization;
using System.Reflection;

namespace GroceryStore.Tests
{
    public static class PropertyInfoExtensions
    {
        public static void SetPrivateProperty<T, TValue>(
            this T obj,
            string propertyName,
            TValue value,
            BindingFlags invokeAttr,
            Binder binder,
            object[] index,
            CultureInfo culture)
        {
            typeof(T).GetProperty(propertyName).SetValue(obj, value, invokeAttr, binder, index, culture);
        }
    }

    public static class LineItemExtensions
    {
        public static void SetQuantity(this LineItem lineItem, int quantity)
        {
            lineItem.SetPrivateProperty(
                "Quantity",
                (uint)quantity,
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                null,
                null);
        }

        public static void SetQuantity(this LineItem lineItem, uint quantity)
        {
            lineItem.SetPrivateProperty(
                "Quantity",
                quantity,
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                null,
                null);
        }
    }
}