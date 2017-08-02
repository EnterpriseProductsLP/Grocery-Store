using System;

namespace GroceryStore.Deals
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DealMetadata : Attribute
    {
        public DealMetadata(char identifier, string description)
        {
            Identifier = identifier;
            Description = description;
        }

        public string Description { get; }

        public char Identifier { get; }
    }
}