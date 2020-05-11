using System;
using System.Collections.Generic;

namespace Enumify.Net.Cache
{
    internal static class ValueCache<T>
           where T : struct, Enum
    {
        internal static readonly IList<T> Values = Enum.GetValues(typeof(T)) as T[];
    }
}