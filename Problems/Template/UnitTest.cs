using Microsoft.Extensions.DependencyInjection;

namespace ProblemName;

public class UnitTests
{
    private readonly ISolution _solution;

    public UnitTest()
    {
        var services = new ServiceCollection();
        services.AddTransient<ISolution, Solution>();

        var serviceProvider = services.BuildServiceProvider();
        _solution = serviceProvider.GetRequiredService<ISolution>();
    }

    [Fact]
    public void TestCase1()
    {
        // Arrange
        var solution = new Solution();

        // Act
        var result = solution.MethodName(input);

        // Assert
        Assert.Equal(expected, result);
    }
}