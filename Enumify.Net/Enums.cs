namespace Enumify.Net
{
    using System;
    using System.Collections.Generic;
    using Cache;

    /// <summary>
    /// A lightweight type safety library for enum type values and description.
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// Returns an array of enum constant values.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <returns></returns>
        public static IList<T> GetValues<T>() where T : struct, Enum => ValueCache<T>.Values;

        /// <summary>
        /// Returns an array of enum constant names.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <returns></returns>
        public static IList<string> GetNames<T>() where T : struct, Enum => NameCache<T>.Names;

        /// <summary>
        /// Returns constant name from Enum value.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum value.</param>
        /// <returns></returns>
        public static string GetName<T>(this T value) where T : struct, Enum =>
            Enum.GetName(NullableUnderlyingTypeCache<T>.TypeCache, value);

        /// <summary>
        /// Returns an enum description from a specified enum.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum value.</param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value) where T : struct, Enum
        {
            var dict = DescriptionCache<T>.ValueDictionary;

            if (dict.ContainsKey(value)) return dict[value];

            return default;
        }

        /// <summary>
        /// Parses description text attribute from a specified enum. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="description">Description text.</param>
        /// <param name="value">Enum value.</param>
        /// <returns></returns>
        public static bool TryParseDescription<T>(string description, out T value) where T : struct, Enum
        {
            var dict = DescriptionCache<T>.ValueDictionary;

            foreach (var i in dict)
            {
                if (string.Equals(i.Value, description, StringComparison.OrdinalIgnoreCase))
                {
                    value = i.Key;
                    return true;
                }
            }

            value = default;

            return false;
        }

        /// <summary>
        /// Convert a string value to enum type.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">A string containing an enum to convert.</param>
        /// <param name="ignoreCase">Ignore their case. Default is true.</param>
        /// <returns></returns>
        public static T Parse<T>(string value, bool ignoreCase = true) where T : struct, Enum
        {
            var index = NameCache<T>.Names.FindIndex(value, ignoreCase);

            if (index < 0) return default;

            return ValueCache<T>.Values[index];
        }

        /// <summary>
        /// Parses an enum from a String. A return value indicates whether the conversion succeeded.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">A string containing an enum to convert.</param>
        /// <param name="result">Enum type.</param>
        /// <param name="ignoreCase">Ignore their case. Default is true.</param>
        /// <returns></returns>
        public static bool TryParse<T>(string value, out T result, bool ignoreCase = true) where T : struct, Enum
        {
            var index = NameCache<T>.Names.FindIndex(value, ignoreCase);

            if (index == -1)
            {
                result = default;
                return false;
            }

            result = ValueCache<T>.Values[index];

            return true;
        }

        /// <summary>
        /// Returns Boolean whether a specified enum name exist in the enum type.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Value.</param>
        /// <param name="ignoreCase">Ignore their case. Default is true.</param>
        /// <returns></returns>
        public static bool IsDefined<T>(string value, bool ignoreCase = true) where T : struct, Enum =>
            NameCache<T>.Names.FindIndex(value, ignoreCase) != -1;

        /// <summary>
        /// Returns Boolean whether a specified integer value exist in the enum type.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum integer value.</param>
        /// <returns></returns>
        public static bool IsDefined<T>(int value) where T : struct, Enum =>
            value.ConvertType(UnderlyingTypeCache<T>.TypeCache) == value;

        /// <summary>
        /// Returns Boolean whether a specified long value exist in the enum type.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum long value.</param>
        /// <returns></returns>
        public static bool IsDefined<T>(long value) where T : struct, Enum =>
            value.ConvertType(UnderlyingTypeCache<T>.TypeCache) == value;

        /// <summary>
        /// Returns Boolean whether a specified short value exist in the enum type.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum short value.</param>
        /// <returns></returns>
        public static bool IsDefined<T>(short value) where T : struct, Enum =>
            value.ConvertType(UnderlyingTypeCache<T>.TypeCache) == value;

        /// <summary>
        /// Returns Boolean whether a specified byte value exist in the enum type.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum byte value.</param>
        /// <returns></returns>
        public static bool IsDefined<T>(byte value) where T : struct, Enum =>
            value.ConvertType(UnderlyingTypeCache<T>.TypeCache) == value;

        /// <summary>
        /// Returns the underlying type of enum.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <returns></returns>
        public static Type GetUnderlyingType<T>() where T : struct, Enum => UnderlyingTypeCache<T>.TypeCache;
    }
}