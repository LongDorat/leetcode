using Microsoft.Extensions.DependencyInjection;

namespace TwoSum.Tests;

public abstract class Test
{
    protected readonly ISolutions _solutions;

    public Test()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<ISolutions, Solutions>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        _solutions = serviceProvider.GetRequiredService<ISolutions>();
    }
}