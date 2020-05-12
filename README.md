# Enumify.Net
A lightweight type safety library for enum type values and description.

## Nuget
Install [Enumify.Net](https://www.nuget.org/packages/Enumify.Net/) via [Nuget](https://www.nuget.org/packages/Enumify.Net/)

```csharp
PM> Install-Package Enumify.Net
```

## Platform Support
*  netstandard 2.1, netstandard 2.0
*  netcoreapp 3.1, netcoreapp 3.0, netcoreapp 2.2, netcoreapp 2.1, netcoreapp 2.0, 
*  NetFramework 4.8.0

## API usage
```csharp

//Convert a string value to enum type.
DayOfWeek saturday = Enums.Parse<DayOfWeek>("Saturday");

//Get Values
IList<DayOfWeek> values = Enums.GetValues<DayOfWeek>();

//Get Names
IList<string> names = Enums.GetNames<DayOfWeek>();

//Get Name
string name = DayOfWeek.Saturday.GetName();

//Parses an enum from a string.
bool result = Enums.TryParse("Saturday", out DayOfWeek day);

Assert.True(Enums.TryParse("One", out Number number));
Assert.Equal(Number.One, number);

Assert.False(Enums.TryParse("1", out number));
Assert.Equal((Number)0, number);

Assert.False(Enums.TryParse("foo", out number));
Assert.Equal((Number)0, number);

//Returns Boolean whether a specified enum name exist in the enum type.
bool isDefinedAsString = Enums.IsDefined<Number>("One");
bool isDefinedAsInt = Enums.IsDefined<Number>(1);
bool isDefinedAsLong = Enums.IsDefined<Int64Enum>(0x7FFFFFFFFFFFFFFF);
bool isDefinedAsByte = Enums.IsDefined<ByteEnum>(1);

//Get Enum Description.
string desc = Number.One.GetDescription();

//Parse Enum Description.
bool result = Enums.TryParseDescription("Third description", out Number number);
 

public enum Number
{
    [EnumDescription("First description")]
    One = 1,
    
    Two = 2,
    
    [EnumDescription("Third description")]
    Three = 3
}

 [Flags]
 public enum Int64Enum : long
 {
     MinusOne = -1,
     Zero = 0,
     Max = 0x7FFFFFFFFFFFFFFF
 }
 
 //Get underlying type.
 Assert.Equal(typeof(byte), Enums.GetUnderlyingType<ByteEnum>());
 Assert.Equal(typeof(int), Enums.GetUnderlyingType<Number>());
 Assert.Equal(typeof(long), Enums.GetUnderlyingType<Int64Enum>());
 Assert.Equal(typeof(ulong), Enums.GetUnderlyingType<UInt64Enum>());
 
```

Please check out more samples in the [Unit test app](https://github.com/deepumi/enumify.net/blob/deepumi-readme-update/Enumify.Net.Test/EnumTest.cs).
