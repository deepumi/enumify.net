using System;
using System.Collections.Generic; 

namespace Enumify.Net
{
    internal static class Extensions
    {
        internal static int FindIndex(this IList<string> items, string value, bool ignoreCase)
        { 
            for (var i = 0; i < items.Count; i++)
            {
                if (string.Equals(items[i], value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal))
                {
                    return i;
                }
            }

            return -1;
        }

        internal static TValue ConvertType<TValue>(this TValue value, Type type)
        {
            if (value.GetType() != type) return value;

            return (TValue)Convert.ChangeType(value, type);
        }
    } 
}