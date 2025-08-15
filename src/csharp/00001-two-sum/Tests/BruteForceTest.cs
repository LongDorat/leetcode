namespace TwoSum.Tests;

public class BruteForce : Test
{
    [Fact]
    public void ValidInput()
    {
        // Arrange
        var nums = new int[] { 2, 7, 11, 15 };
        var target = 9;
        var expected = new int[] { 0, 1 };

        // Act
        var result = _solutions.TwoSum_BruteForce(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void NoSolution()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3, 4 };
        var target = 10;
        var expected = new int[] { };

        // Act
        var result = _solutions.TwoSum_BruteForce(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void EmptyArray()
    {
        // Arrange
        var nums = new int[] { };
        var target = 5;
        var expected = new int[] { };

        // Act
        var result = _solutions.TwoSum_BruteForce(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void SingleElement()
    {
        // Arrange
        var nums = new int[] { 5 };
        var target = 5;
        var expected = new int[] { };

        // Act
        var result = _solutions.TwoSum_BruteForce(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void NegativeNumbers()
    {
        // Arrange
        var nums = new int[] { -3, 4, 3, 90 };
        var target = 0;
        var expected = new int[] { 0, 2 };

        // Act
        var result = _solutions.TwoSum_BruteForce(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}