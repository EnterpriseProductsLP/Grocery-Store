namespace GroceryStore.ConsoleApplication
{
    public static class StringExtensions
    {
        internal static string EmptyIfNullOrWhitespace(this string s)
        {
            return string.IsNullOrWhiteSpace(s) ? string.Empty : s.Trim();
        }

    }
}