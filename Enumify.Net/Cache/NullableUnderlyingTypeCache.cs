using System;

namespace Enumify.Net.Cache
{
    internal static class NullableUnderlyingTypeCache<T>
        where T : struct, Enum
    {
        internal static readonly Type TypeCache = GetNullableUnderlyingType();

        private static Type GetNullableUnderlyingType()
        {
           var enumType = typeof(T);

           return Nullable.GetUnderlyingType(enumType) ?? enumType;
        }
    }
}