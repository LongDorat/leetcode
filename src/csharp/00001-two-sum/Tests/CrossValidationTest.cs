namespace TwoSum.Tests;

public class CrossValidation : Test
{
    [Fact]
    public void BothApproaches_ValidInput_SameResult()
    {
        // Arrange
        var nums = new int[] { 2, 7, 11, 15 };
        var target = 9;

        // Act
        var bruteForceResult = _solutions.TwoSum_BruteForce(nums, target);
        var hashTableResult = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
    }

    [Fact]
    public void BothApproaches_NoSolution_SameResult()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3, 4 };
        var target = 10;

        // Act
        var bruteForceResult = _solutions.TwoSum_BruteForce(nums, target);
        var hashTableResult = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
        Assert.Empty(bruteForceResult);
        Assert.Empty(hashTableResult);
    }

    [Fact]
    public void BothApproaches_EmptyArray_SameResult()
    {
        // Arrange
        var nums = new int[] { };
        var target = 5;

        // Act
        var bruteForceResult = _solutions.TwoSum_BruteForce(nums, target);
        var hashTableResult = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
        Assert.Empty(bruteForceResult);
        Assert.Empty(hashTableResult);
    }

    [Fact]
    public void BothApproaches_SingleElement_SameResult()
    {
        // Arrange
        var nums = new int[] { 5 };
        var target = 5;

        // Act
        var bruteForceResult = _solutions.TwoSum_BruteForce(nums, target);
        var hashTableResult = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
        Assert.Empty(bruteForceResult);
        Assert.Empty(hashTableResult);
    }

    [Fact]
    public void BothApproaches_NegativeNumbers_SameResult()
    {
        // Arrange
        var nums = new int[] { -3, 4, 3, 90 };
        var target = 0;

        // Act
        var bruteForceResult = _solutions.TwoSum_BruteForce(nums, target);
        var hashTableResult = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
    }

    [Fact]
    public void BothApproaches_DuplicateNumbers_SameResult()
    {
        // Arrange
        var nums = new int[] { 3, 3 };
        var target = 6;

        // Act
        var bruteForceResult = _solutions.TwoSum_BruteForce(nums, target);
        var hashTableResult = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
        Assert.Equal(new int[] { 0, 1 }, bruteForceResult);
    }

    [Fact]
    public void BothApproaches_LargerArray_SameResult()
    {
        // Arrange
        var nums = new int[] { 3, 2, 4, 15, 7, 11, 1 };
        var target = 9;

        // Act
        var bruteForceResult = _solutions.TwoSum_BruteForce(nums, target);
        var hashTableResult = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
    }

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9)]
    [InlineData(new int[] { 3, 2, 4 }, 6)]
    [InlineData(new int[] { 3, 3 }, 6)]
    [InlineData(new int[] { -1, -2, -3, -4, -5 }, -8)]
    public void BothApproaches_ParameterizedTests_SameResult(int[] nums, int target)
    {
        // Act
        var bruteForceResult = _solutions.TwoSum_BruteForce(nums, target);
        var hashTableResult = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(bruteForceResult, hashTableResult);
    }
}