using System;
using System.Collections.Generic;
using System.Reflection;

namespace Enumify.Net.Cache
{
    internal static class DescriptionCache<T>
           where T : struct, Enum
    {
        internal static readonly Dictionary<T, string> ValueDictionary;

        static DescriptionCache()
        {
            var values = ValueCache<T>.Values;

            ValueDictionary = new Dictionary<T, string>(values.Count);

            for (var i = 0; i < values.Count; i++)
            {
                var desc = typeof(T).GetField(values[i].ToString())?.GetCustomAttribute<EnumDescriptionAttribute>()?.Description;

                if (desc == null) continue;

                ValueDictionary[values[i]] = desc;
            }
        }
    }
}