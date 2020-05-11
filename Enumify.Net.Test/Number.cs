using System;

namespace Enumify.Net.Test
{
    enum Number
    {
        [EnumDescription("First description")]
        One = 1,
        Two = 2,
        [EnumDescription("Third description")]
        Three = 3
    }

    [Flags]
    enum BitFlags
    {
        Flag1 = 1,
        [EnumDescription("Duplicate description")]
        Flag2 = 2,
        [EnumDescription("Duplicate description")]
        Flag4 = 4,
        Flag24 = Flag2 | Flag4
    }

    [Flags]
    public enum Int64Enum : long
    {
        MinusOne = -1,
        Zero = 0,
        Max = 0x7FFFFFFFFFFFFFFF
    }

    [Flags]
    public enum UInt64Enum : ulong
    {
        Zero = 0,
        BigValue = 0xFFFFFFFFFFFFFFFF
    }

    public enum ByteEnum : byte
    {
        One = 1,
        Two = 2
    }
}
