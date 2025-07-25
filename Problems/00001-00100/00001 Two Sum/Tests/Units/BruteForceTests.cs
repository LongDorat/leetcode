namespace Two_Sum.Tests.Units;

public class BruteForceTests : TestBase
{
    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { -1, -2, -3, -4, -5 }, -8, new int[] { 2, 4 })]
    [InlineData(new int[] { 0, 4, 3, 0 }, 0, new int[] { 0, 3 })]
    public void BruteForceSolution_ValidInput_ReturnsCorrectIndices(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solution.TwoSum_BruteForce(nums, target);

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
        var result = _solution.TwoSum_BruteForce(nums, target);

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
        var result = _solution.TwoSum_BruteForce(nums, target);

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
        var result = _solution.TwoSum_BruteForce(nums, target);

        // Assert
        Assert.Empty(result);
    }
}
