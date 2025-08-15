using Microsoft.Extensions.DependencyInjection;

namespace TemplateProject.Tests;

public abstract class Test
{
    private readonly ISolutions _solutions;

    public Test()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<ISolutions, Solutions>();
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        _solutions = serviceProvider.GetRequiredService<ISolutions>();
    }
}
