using Microsoft.Extensions.DependencyInjection;

namespace Longest_Substring_Without_Repeating_Characters.Tests;

public abstract class TestBase
{
    protected readonly ISolution _solution;

    protected TestBase()
    {
        var services = new ServiceCollection();
        services.AddTransient<ISolution, Solution>();

        var serviceProvider = services.BuildServiceProvider();
        _solution = serviceProvider.GetRequiredService<ISolution>();
    }
}
