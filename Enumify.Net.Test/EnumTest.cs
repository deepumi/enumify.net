using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Enumify.Net.Test
{
    public class EnumsTest
    {
        [Fact]
        public void GetNames()
        {
            IList<string> numbers = Enums.GetNames<Number>();
            Assert.True(numbers.SequenceEqual(new[] { "One", "Two", "Three" }));
        }

        [Fact]
        public void GetName()
        {
            string name = Enums.GetName(DayOfWeek.Monday);
            Assert.Equal("Monday", name);
        }

        [Fact]
        public void GetValues()
        {
            IList<Number> numbers = Enums.GetValues<Number>();
            Assert.True(numbers.SequenceEqual(new[] { Number.One, Number.Two, Number.Three }));
        }

        [Fact]
        public void ConvertStringToEnum()
        {
            DayOfWeek result = Enums.Parse<DayOfWeek>("Monday");
            Assert.Equal(DayOfWeek.Monday, result);
        }

        [Fact]
        public void GetValuesAsReadOnlyList()
        {
            IList<Number> numbers = Enums.GetValues<Number>();
            Assert.True(numbers.IsReadOnly);
        }

        [Fact]
        public void TryParseNameNonFlags()
        {
            Assert.True(Enums.TryParse("One", out Number number));
            Assert.Equal(Number.One, number);

            Assert.False(Enums.TryParse("1", out number));
            Assert.Equal((Number)0, number);
            
            Assert.False(Enums.TryParse("foo", out number));
            Assert.Equal((Number)0, number);
        }

        [Fact]
        public void GetValuesCacheTest()
        {
            IList<Number> numbers = Enums.GetValues<Number>();
            IList<Number> numbers2 = Enums.GetValues<Number>();
            Assert.Equal(numbers.GetHashCode(), numbers2.GetHashCode());
        }

        [Fact]
        public void TryParseNameFlags()
        {
            Assert.True(Enums.TryParse("Flag24", out BitFlags result));

            Assert.Equal(BitFlags.Flag24, result);

            Assert.False(Enums.TryParse("1", out result));

            Assert.Equal((BitFlags)0, result);

            Assert.False(Enums.TryParse("rubbish", out result));

            Assert.Equal((BitFlags)0, result);

            Assert.False(Enums.TryParse("Flag2,Flag4", out result));

            Assert.Equal((BitFlags)0, result);
        }

        [Fact]
        public void ParseName()
        {
            Assert.Equal(Number.Two, Enums.Parse<Number>("Two"));
            
            Assert.Equal(BitFlags.Flag24, Enums.Parse<BitFlags>("Flag24"));
        }

        [Fact]
        public void GetUnderlyingType()
        {
            Assert.Equal(typeof(byte), Enums.GetUnderlyingType<ByteEnum>());
            Assert.Equal(typeof(int), Enums.GetUnderlyingType<Number>());
            Assert.Equal(typeof(long), Enums.GetUnderlyingType<Int64Enum>());
            Assert.Equal(typeof(ulong), Enums.GetUnderlyingType<UInt64Enum>());
        }

        [Fact]
        public void GetDescription()
        {
            Assert.Equal("First description", Number.One.GetDescription());
        }

        [Fact]
        public void GetNullDescription()
        {
            string nullDescription = Number.Two.GetDescription();
            Assert.Null(nullDescription);
        }

        [Fact]
        public void ParseDescription()
        {
            Assert.True(Enums.TryParseDescription("Third description", out Number number));
            Assert.Equal(Number.Three, number);
        }

        [Fact]
        public void ParseDuplicateDescription()
        {
            Assert.True(Enums.TryParseDescription("Duplicate description", out BitFlags result));
            Assert.Equal(BitFlags.Flag2, result);
        }

        [Fact]
        public void ParseMissingDescription()
        {
            Assert.False(Enums.TryParseDescription("Doesn't exist", out Number number));
        }

        [Fact]
        public void EnumToInt()
        {
            int value = DayOfWeek.Friday.ToInt();
            Assert.Equal(5, value);
        }

        [Fact]
        public void EnumToLong()
        {
            long value = Int64Enum.Max.ToLong();
            Assert.Equal(0x7FFFFFFFFFFFFFFF, value);
        }

        [Fact]
        public void EnumToUnSignedLong()
        {
            ulong value = UInt64Enum.BigValue.ToUnsignedLong();
            Assert.Equal(0xFFFFFFFFFFFFFFFF, value);
        }

        [Fact]
        public void EnumToByte()
        {
            byte value = ByteEnum.One.ToByte();
            Assert.Equal(1, value);
        }

        [Fact]
        public void IsDefinedAsString()
        {
            Assert.True(Enums.IsDefined<Number>("One"));
        }

        [Fact]
        public void IsDefinedAsInt()
        {
            Assert.True(Enums.IsDefined<Number>(1));
        }

        [Fact]
        public void IsDefinedAsLong()
        {
            Assert.True(Enums.IsDefined<Int64Enum>(0x7FFFFFFFFFFFFFFF));
        }

        [Fact]
        public void IsDefinedAsByte()
        {
            Assert.True(Enums.IsDefined<ByteEnum>(1));
        }
    }
}