using System;
using System.Runtime.CompilerServices;

namespace Enumify.Net
{
    /// <summary>
    /// Enum extensions class.   
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Convert enum to 32 bit integer value.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum valu.</param>
        /// <returns></returns>
        public static int ToInt<T>(this T value)
           where T : struct, Enum => Unsafe.As<T, int>(ref value);

        /// <summary>
        /// Convert enum to 64 bit integer value.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum valu.</param>
        /// <returns></returns>
        public static long ToLong<T>(this T value)
         where T : struct, Enum => Unsafe.As<T, long>(ref value);

        /// <summary>
        /// Convert enum to unsigned 64 bit integer value.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum valu.</param>
        /// <returns></returns>
        public static ulong ToUnsignedLong<T>(this T value)
         where T : struct, Enum => Unsafe.As<T, ulong>(ref value);

        /// <summary>
        /// Convert enum to 16 bit integer value.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum valu.</param>
        /// <returns></returns>
        public static short ToShort<T>(this T value)
         where T : struct, Enum => Unsafe.As<T, short>(ref value);


        /// <summary>
        /// Convert enum to byte type value.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum valu.</param>
        /// <returns></returns>
        public static byte ToByte<T>(this T value)
         where T : struct, Enum => Unsafe.As<T, byte>(ref value);

        /// <summary>
        /// Convert enum to short byte value.
        /// </summary>
        /// <typeparam name="T">Enum type.</typeparam>
        /// <param name="value">Enum valu.</param>
        /// <returns></returns>
        public static sbyte ToShortByte<T>(this T value)
         where T : struct, Enum => Unsafe.As<T, sbyte>(ref value);
    }
}