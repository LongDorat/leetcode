namespace ProblemNamespace.Tests;

public abstract class TestBase
{
    protected readonly ISolutions _solution;

    protected TestBase()
    {
        var services = new ServiceCollection();
        services.AddTransient<ISolutions, Solutions>();

        var serviceProvider = services.BuildServiceProvider();
        _solution = serviceProvider.GetRequiredService<ISolutions>();
    }
}