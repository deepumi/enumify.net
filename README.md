# Enumify.Net
A lightweight type safety library for enum type values and description.

## Nuget
Install [Enumify.Net](https://www.nuget.org/packages/Enumify.Net/) via [Nuget](https://www.nuget.org/packages/Enumify.Net/)
```csharp
PM> Install-Package Enumify.Net

## API usage

```csharp
//Convert a string value to enum type.
DayOfWeek saturday = Enums.Parse<DayOfWeek>("Saturday");

//Get values
IList<DayOfWeek> values = Enums.GetValues<DayOfWeek>();

//Get Description.
string desc = Number.One.GetDescription();

//Parse Description.
bool result = Enums.TryParseDescription("Third description", out Number number);
 

public enum Number {
    One = 1,[EnumDescription("First description")]
    Two = 2,[EnumDescription("Third description")]
    Three = 3
}

```
