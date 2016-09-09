![](https://raw.github.com/jlbarreda/Paravaly/master/ParavalyIcon.png)
# Paravaly

[![Build status](https://ci.appveyor.com/api/projects/status/elwd4rq970vk9l6r?svg=true)](https://ci.appveyor.com/project/jlbarreda/paravaly)

[![NuGet version](https://badge.fury.io/nu/Paravaly.svg)](https://www.nuget.org/packages/Paravaly)

A simple but flexible parameter validation library for .NET.

## How do I use it?
### A simple example
This will throw an `ArgumentException` if `text` is empty or whitespace; an `ArgumentNullException` if
`text` is null; and an `ArgumentOutOfRangeException` if `x` is not greater than zero. In this case,
validation stops at the first broken rule and the corresponding exception gets thrown.
```csharp
public void SomeMethod(string text, int x)
{
    Require
        .Parameter(nameof(text), text).IsNotNullOrWhiteSpace()
        .AndParameter(nameof(x), x).IsGreaterThan(0);
}
```
This does the same thing combining several validations for one parameter.
```csharp
public void SomeMethod(string text, int x)
{
    Require
        .Parameter(nameof(text), text)
            .IsNotNull()
            .IsNotEmpty()
            .IsNotWhiteSpace()
        .AndParameter(nameof(x), x)
            .IsGreaterThan(0);
}
```

### But I want to get all exceptions. not just the first one!
In that case you can use `RequireAll` for your validation, calling the `Apply` method at the end.
If one or more rules are broken, a `Paravaly.ParameterValidationException` will get thrown. This
exception inherits from  [AggregateException](https://msdn.microsoft.com/en-us/library/system.aggregateexception.aspx)
and it will contain all relevant exceptions.
```csharp
public void SomeMethod(string text, int x)
{
    RequireAll
        .Parameter(nameof(text), text).IsNotNullOrWhiteSpace()
        .AndParameter(nameof(x), x).IsGreaterThan(0)
        .Apply(); // Always call Apply when using RequireAll.
}
```
It's very important to call the `Apply` method at the end or the exception won't get thrown and validation
will fail silently.

### If the `nameof` operator is not available
You can use this syntax.
```csharp
public void SomeMethod(string text)
{
    Require.Parameter(new { text }, text).IsNotNull();
}
```
Just beware that it's a lot slower, but if performance is not an issue, it's better than hardcoded strings.

### What if I don't like the default error message?
You can pass custom error messages to all validations.
```csharp
public void SomeMethod(string text)
{
    Require.Parameter(nameof(text), text).IsNotNull("Some custom error message.");
}
```

### Can I add my own custom validations?
Yes you can. You can create a new extension if you plan on reusing your validation logic. This is
a sample custom rule for integer types.
```csharp
public static IValidatingParameter<int> IsLessThan100(this IParameter<int> parameter)
{
    return parameter.IsValid(
        p =>
        {
            if (p.Value >= 100)
            {
                p.Handle(new ArgumentOutOfRangeException(
                    p.Name,
                    p.Value,
                    "The parameter value must be less than 100."));
            }
        });
}
```
And you can use it just like any other validation rule.
```csharp
public void SomeMethod(int x)
{
    Require.Parameter(nameof(x), x).IsLessThan100();
}
```
If you need something quick for a one time thing, you can use the `IsValid` method directly.
```csharp
public void SomeMethod(int x)
{
    Require
        .Parameter(nameof(x), x)
            .IsValid(
                p =>
                {
                    if (p.Value < 100)
                    {
                        p.Handle(new ArgumentOutOfRangeException(
                            p.Name,
                            p.Value,
                            "The parameter value must be less than 100."));
                    }
                });
}
```

### Can I validate type parameters?
Yes, just use the `TypeParameter` method.
```csharp
public void SomeMethod<T>()
{
    Require.TypeParameter<T>().IsInterface();
}
```
If your type parameter's name is not 'T', you can specify the actual name.
```csharp
public void SomeMethod<TInterface, TEnum>()
{
    Require
		.TypeParameter<TInterface>(nameof(TInterface)).IsInterface()
		.AndTypeParameter<TEnum>(nameof(TEnum)).IsEnum();
}
```

### What if I want to disable validation (e.g. for unit testing) or I simply don't like using static methods?
You can inject one of the `IRequire` implementations instead of using the static methods. You can use
`Require` or `RequireAll` as you prefer for runtime, and the special class `RequireNothing` to disable validation.
```csharp
public MyClass(IRequire require)
{
    this.require = require;
}

private readonly IRequire require;

public void SomeMethod(string text)
{
    this.require.Parameter(nameof(text), text).IsNotNull();
}
```
All `IRequire` implementations are stateless, so it's safe to make them singletons.

## License
Licensed under the [Apache License, Version 2.0](https://opensource.org/licenses/Apache-2.0).
