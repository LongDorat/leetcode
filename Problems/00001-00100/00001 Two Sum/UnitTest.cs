using Microsoft.Extensions.DependencyInjection;

namespace Two_Sum;

public class UnitTest
{
    private readonly ISolution _solution;

    public UnitTest()
    {
        var services = new ServiceCollection();
        services.AddTransient<ISolution, Solution>();

        var serviceProvider = services.BuildServiceProvider();
        _solution = serviceProvider.GetRequiredService<ISolution>();
    }

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { -1, -2, -3, -4, -5 }, -8, new int[] { 2, 4 })]
    [InlineData(new int[] { 0, 4, 3, 0 }, 0, new int[] { 0, 3 })]
    public void BruteForceSolution_ValidInput_ReturnsCorrectIndices(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.BruteForceSolution(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { -1, -2, -3, -4, -5 }, -8, new int[] { 2, 4 })]
    [InlineData(new int[] { 0, 4, 3, 0 }, 0, new int[] { 0, 3 })]
    public void HashMapSolution_ValidInput_ReturnsCorrectIndices(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.HashMapSolution(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void BruteForceSolution_NoSolutionExists_ReturnsEmptyArray()
    {
        // Arrange
        int[] nums = { 1, 2, 3, 4 };
        int target = 10;

        // Act
        var result = _solution.BruteForceSolution(nums, target);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void HashMapSolution_NoSolutionExists_ReturnsEmptyArray()
    {
        // Arrange
        int[] nums = { 1, 2, 3, 4 };
        int target = 10;

        // Act
        var result = _solution.HashMapSolution(nums, target);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void BruteForceSolution_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] nums = { };
        int target = 5;

        // Act
        var result = _solution.BruteForceSolution(nums, target);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void HashMapSolution_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] nums = { };
        int target = 5;

        // Act
        var result = _solution.HashMapSolution(nums, target);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void BruteForceSolution_SingleElement_ReturnsEmptyArray()
    {
        // Arrange
        int[] nums = { 5 };
        int target = 5;

        // Act
        var result = _solution.BruteForceSolution(nums, target);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void HashMapSolution_SingleElement_ReturnsEmptyArray()
    {
        // Arrange
        int[] nums = { 5 };
        int target = 5;

        // Act
        var result = _solution.HashMapSolution(nums, target);

        // Assert
        Assert.Empty(result);
    }

    [Theory]
    [InlineData(new int[] { 1, 5, 3, 2, 9, 8 }, 10, new int[] { 0, 4 })]
    [InlineData(new int[] { 15, 2, 7, 8 }, 9, new int[] { 1, 2 })]
    public void BothSolutions_SameInput_ReturnSameResult(int[] nums, int target, int[] expected)
    {
        // Act
        var bruteForceResult = _solution.BruteForceSolution(nums, target);
        var hashMapResult = _solution.HashMapSolution(nums, target);

        // Assert
        Assert.Equal(expected, bruteForceResult);
        Assert.Equal(expected, hashMapResult);
        Assert.Equal(bruteForceResult, hashMapResult);
    }
}
