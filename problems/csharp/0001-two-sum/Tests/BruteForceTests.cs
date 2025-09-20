using Xunit;

namespace TwoSum.Tests;

public class BruteForceTests
{
    private readonly Solution _solution = new();

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void ValidInput_ReturnsCorrectIndices(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.BruteForce(nums, target);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 7)]
    [InlineData(new int[] { 5, 5 }, 11)]
    [InlineData(new int[] { -1, -2, -3 }, 10)]
    public void NoSolution_ReturnsMinusOneArray(int[] nums, int target)
    {
        // Act
        var result = _solution.BruteForce(nums, target);
        
        // Assert
        Assert.Equal(new int[] { -1, -1 }, result);
    }

    [Fact]
    public void MinimumArraySize_ReturnsCorrectIndices()
    {
        // Arrange
        var nums = new int[] { 1, 2 };
        var target = 3;
        var expected = new int[] { 0, 1 };
        
        // Act
        var result = _solution.BruteForce(nums, target);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { -3, 4, 3, 90 }, 0, new int[] { 0, 2 })]
    [InlineData(new int[] { -1, -2, -3, -4, -5 }, -8, new int[] { 2, 4 })]
    public void NegativeNumbers_ReturnsCorrectIndices(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.BruteForce(nums, target);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 4, 3, 2 }, 5, new int[] { 0, 1 })]  // Only 1 + 4 = 5
    [InlineData(new int[] { 1, 1, 1, 1 }, 2, new int[] { 0, 1 })]  // Multiple 1s but first pair returned
    public void DuplicateNumbers_ReturnsFirstValidPair(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.BruteForce(nums, target);
        
        // Assert
        Assert.Equal(expected, result);
    }
}