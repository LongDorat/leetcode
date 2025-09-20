using Xunit;

namespace TwoSum.Tests;

/// <summary>
/// Cross-validation tests to ensure both BruteForce and HashTable methods produce identical results.
/// </summary>
public class CrossValidationTests
{
    private readonly Solution _solution = new Solution();

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9)]  // Only 2 + 7 = 9 (indices 0, 1)
    [InlineData(new int[] { 3, 2, 4 }, 6)]       // Only 2 + 4 = 6 (indices 1, 2)
    [InlineData(new int[] { 3, 3 }, 6)]          // Only 3 + 3 = 6 (indices 0, 1)
    [InlineData(new int[] { 1, 2 }, 3)]          // Only 1 + 2 = 3 (indices 0, 1)
    [InlineData(new int[] { -3, 4, 3, 90 }, 0)]  // Only -3 + 3 = 0 (indices 0, 2)
    [InlineData(new int[] { 1, 10, 23, 12 }, 13)]  // Only 1 + 12 = 13 (indices 0, 3)
    public void SameValidInput_ReturnIdenticalResults(int[] nums, int target)
    {
        // Act
        var bruteForceResult = _solution.BruteForce(nums, target);
        var hashTableResult = _solution.HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, 7)]
    [InlineData(new int[] { 5, 5 }, 11)]
    [InlineData(new int[] { -1, -2, -3 }, 10)]
    public void NoSolution_ReturnIdenticalMinusOneArrays(int[] nums, int target)
    {
        // Act
        var bruteForceResult = _solution.BruteForce(nums, target);
        var hashTableResult = _solution.HashTable(nums, target);

        // Assert
        Assert.Equal(new int[] { -1, -1 }, bruteForceResult);
        Assert.Equal(new int[] { -1, -1 }, hashTableResult);
        Assert.Equal(bruteForceResult, hashTableResult);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 1, 1 }, 2)]    // Multiple 1s, only one valid solution
    [InlineData(new int[] { 5, 5, 5, 5 }, 10)]   // Multiple 5s, only one valid solution  
    [InlineData(new int[] { 2, 3, 2 }, 4)]       // Only indices 0,2 give 2+2=4
    public void DuplicateNumbers_ReturnIdenticalResults(int[] nums, int target)
    {
        // Act
        var bruteForceResult = _solution.BruteForce(nums, target);
        var hashTableResult = _solution.HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
    }

    [Fact]
    public void LargeArray_ReturnIdenticalResults()
    {
        // Arrange - ensure only one valid solution exists
        var nums = new int[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 18, 21, 23, 21, 27, 29 };
        var target = 46; // Only 17 + 29 = 46 (indices 8, 14)

        // Act
        var bruteForceResult = _solution.BruteForce(nums, target);
        var hashTableResult = _solution.HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
        Assert.Equal(new int[] { 8, 14 }, bruteForceResult); // indices of 17 and 29
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 6, 8, 11 }, 9)] // Only 1 + 8 = 9 (indices 0, 3)
    [InlineData(new int[] { 1, 5, 7, 12, 15 }, 17)] // Only 5 + 12 = 17 (indices 1, 3)
    public void MixedPositiveNegative_ReturnIdenticalResults(int[] nums, int target)
    {
        // Act
        var bruteForceResult = _solution.BruteForce(nums, target);
        var hashTableResult = _solution.HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
    }
}