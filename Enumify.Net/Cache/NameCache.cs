using System;
using System.Collections.Generic;

namespace Enumify.Net.Cache
{
    internal static class NameCache<T>
           where T : struct, Enum
    {
        internal static readonly IList<string> Names = Enum.GetNames(typeof(T));
    }
}