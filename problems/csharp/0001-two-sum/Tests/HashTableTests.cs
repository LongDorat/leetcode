using Xunit;

namespace TwoSum.Tests;

public class HashTableTests
{
    private readonly Solution _solution = new();

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    public void ValidInput_ReturnsCorrectIndices(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.HashTable(nums, target);
        
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
        var result = _solution.HashTable(nums, target);
        
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
        var result = _solution.HashTable(nums, target);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { -3, 4, 3, 90 }, 0, new int[] { 0, 2 })]
    [InlineData(new int[] { -1, -2, -3, -4, -5 }, -8, new int[] { 2, 4 })]
    public void NegativeNumbers_ReturnsCorrectIndices(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.HashTable(nums, target);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 1, 4, 3, 2 }, 5, new int[] { 0, 1 })]  // Only 1 + 4 = 5
    [InlineData(new int[] { 1, 1, 1, 1 }, 2, new int[] { 0, 1 })]  // Multiple 1s but first pair returned
    public void DuplicateNumbers_ReturnsFirstValidPair(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.HashTable(nums, target);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void LargeArray_HandlesEfficiently()
    {
        // Arrange
        var nums = new int[1000];
        for (int i = 0; i < 1000; i++)
        {
            nums[i] = i + 1; // Fill with values 1, 2, 3, ..., 1000
        }
        nums[999] = 10000; // Now we have nums[499] = 500 and nums[998] = 500, so 500 + 500 = 1000
        var target = 10001;
        var expected = new int[] { 0, 999 }; // indices of the two 500s
        
        // Act
        var result = _solution.HashTable(nums, target);
        
        // Assert
        Assert.Equal(expected, result);
    }
}