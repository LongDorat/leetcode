using Microsoft.Extensions.DependencyInjection;

namespace ProblemName;

public class TestBase
{
    private readonly ISolution _solution;

    public TestBase()
    {
        var services = new ServiceCollection();
        services.AddTransient<ISolution, Solution>();

        var serviceProvider = services.BuildServiceProvider();
        _solution = serviceProvider.GetRequiredService<ISolution>();
    }
}