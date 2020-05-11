using System;

namespace Enumify.Net.Cache
{
    internal static class UnderlyingTypeCache<T>
         where T : struct, Enum
    {
        internal static readonly Type TypeCache = Enum.GetUnderlyingType(typeof(T));
    }
}