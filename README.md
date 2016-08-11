![](https://raw.github.com/jlbarreda/Paravaly/ci/ParavalyIcon.png)
# Paravaly
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
        .Apply(); // Always call Apply when using Require.All.
}
```
It's very important to call the `Apply` method at the end or the exception won't get thrown and validation
will fail silently.
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
If you need something quick for a one time thing, you can use the IsValid method directly.
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
## License
Licensed under the [Apache License, Version 2.0](https://opensource.org/licenses/Apache-2.0).
