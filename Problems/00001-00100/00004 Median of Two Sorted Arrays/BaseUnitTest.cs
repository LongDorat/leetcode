using Microsoft.Extensions.DependencyInjection;

namespace Median_of_Two_Sorted_Arrays;

public abstract class BaseUnitTest
{
    protected readonly ISolution _solution;

    protected BaseUnitTest()
    {
        var services = new ServiceCollection();
        services.AddTransient<ISolution, Solution>();

        var serviceProvider = services.BuildServiceProvider();
        _solution = serviceProvider.GetRequiredService<ISolution>();
    }
}
