# utilities
.Net Core utilities

So I'm tired of writing the same code to do validation of parameters passed to functions, so I thought I'd try a more expressive approach using fluent semantics.

This lets me write code like:
```csharp
public void MyFunc(int value)
{
    Validate
        .Parameter(value)
        .Is((v) => (value >= 1) && (value <= 100));

    // do something with value
}
```

Better still:
```csharp
public void MyFunc(int value)
{
    Validate
        .Parameter(value)
        .Named(nameof(value))
        .IsInRange(1, 100);

    // do something with validated value
}
```

This may not save a lot of code, but I think it is much more expressive when compared to
```csharp
public void MyFunc(int value)
{
    if ((value < 1) || ( value > 100)) then
        throw new ArgumentException($"{nameof(value)} must be in the range 1 to 100");

    // do something with validated value
}
```
