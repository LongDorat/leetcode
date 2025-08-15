namespace TwoSum.Tests;

public class HashTable : Test
{
    [Fact]
    public void ValidInput()
    {
        // Arrange
        var nums = new int[] { 2, 7, 11, 15 };
        var target = 9;
        var expected = new int[] { 0, 1 };

        // Act
        var result = _solutions.TwoSum_HashTable(nums, target);

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
        var result = _solutions.TwoSum_HashTable(nums, target);

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
        var result = _solutions.TwoSum_HashTable(nums, target);

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
        var result = _solutions.TwoSum_HashTable(nums, target);

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
        var result = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void DuplicateNumbers()
    {
        // Arrange
        var nums = new int[] { 3, 3 };
        var target = 6;
        var expected = new int[] { 0, 1 };

        // Act
        var result = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void LargerArray()
    {
        // Arrange
        var nums = new int[] { 3, 2, 4, 15, 7, 11, 1 };
        var target = 9;
        var expected = new int[] { 1, 4 }; // indices of 2 and 7

        // Act
        var result = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TargetAtEnd()
    {
        // Arrange
        var nums = new int[] { 1, 2, 3, 4, 5 };
        var target = 9;
        var expected = new int[] { 3, 4 }; // indices of 4 and 5

        // Act
        var result = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ZeroTarget()
    {
        // Arrange
        var nums = new int[] { 0, 4, 3, 0 };
        var target = 0;
        var expected = new int[] { 0, 3 }; // indices of the two zeros

        // Act
        var result = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
    [InlineData(new int[] { -1, -2, -3, -4, -5 }, -8, new int[] { 2, 4 })]
    public void ParameterizedTests(int[] nums, int target, int[] expected)
    {
        // Act
        var result = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void HashCollisionScenario()
    {
        // Arrange - Test with numbers that might cause hash collisions
        var nums = new int[] { 16, 32, 48, 64, 17 };
        var target = 33;
        var expected = new int[] { 0, 4 }; // indices of 16 and 17

        // Act
        var result = _solutions.TwoSum_HashTable(nums, target);

        // Assert
        Assert.Equal(expected, result);
    }
}