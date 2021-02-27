# Logging Output with dotnet test and xUnit

Add the following to your test class.

``` csharp
        private readonly ITestOutputHelper output;

        public ConstructorTests(ITestOutputHelper output)
        {
            this.output = output;
        }
```

Run the tests as follows:

``` powershell
dotnet watch test --logger:"console;verbosity=detailed"
```