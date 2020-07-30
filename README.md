# EnumValueObject

The EnumValueObject is based on the `ValueObject` class from [here](https://github.com/vkhorikov/CSharpFunctionalExtensions) (credits to: [vkhorikov](https://github.com/vkhorikov)).
This library lets you create strong typed enums, which can only be in a valid state. Furthermore it allows you to define methods on top of your enum and computed property. See the sample section or the quick start tutorial below.

## Installation

Available on [![Nuget downloads](https://img.shields.io/nuget/v/LinkDotNet.EnumValueObject.svg)](https://www.nuget.org/packages/LinkDotNet.EnumValueObject/)

	PM> Install-Package LinkDotNet.EnumValueObject

## Type safety from beginning to end
With this `EnumValueObject` you can only create a valid state of the object itself. Imagine this small `EnumValueObject`

```csharp
public class Language : EnumValueObject<Language>
{
    public static readonly Language German = new Language("de");

    public static readonly Language English = new Language("en");

    protected Language(string key) : base(key)
    {
    }
}
```

To create an `EnumValueObject` you have to call the static `Create` method. Define your constructor always protected or private so that the consumer has to take the `Create` method.
```csharp
var languageResult = Language.Create("en");
```
This will return you a `Result` object. You can check with `languageResult.IsFailure` if we had an error (yes no exceptions). If not you can just access the `EnumValueObject` with `languageResult.Value`.

One downside of the regular `enum` struct is that you can just give it arbitrary values. The following example will not result in any error:
```csharp
public enum Language
{
    English = 0,
    German = 1,
}
...
var language = (Language)500;
```
With the `EnumValueObject` you will not receive a valid Result.

## Comparable to its key
If you have a valid `EnumValueObject` you can compare it in two ways:

1. Checking against the `EnumValueObject` itself
```csharp
if (language == Language.English)
{
    ...
}
```

2. Checking against the key
```csharp
if (language == "en")
{
    ...
}
```

The second option can come in handy if you need to test against direct user input.

## Extend your Enums
No need for extension methods. Because it is a normal `class` you can just define functions and also have properties which will make your life easier. Remember the `Language` example. Lets extend this a bit.

```csharp
public class Language : EnumValueObject<Language>
{
    public static readonly Language German = new Language("de", "€");

    public static readonly Language English = new Language("en", "£");

    public string Currency { get; }

    public Language(string key, string currency) : base(key)
    {
        Currency = currency;
    }
}
```

Once a valid `EnumValueObject` is created, you can just access those properties and work with it.
```csharp
var language = Language.Create("de").Result;
var currency = language.Currency; // €
```

## Database friendly
It is enough to store the key to the database. When the `EnumValueObject` is populated it will automatically set all the dependent properties (like the currency in the last example).