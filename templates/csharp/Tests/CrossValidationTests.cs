namespace Template.Tests;

// Declare the tests for cross-validation problems if there are more than one method in the Solution class.
public class CrossValidationTests
{
    private readonly Solution _solution = new Solution();

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(3, 6)]
    [InlineData(-1, -2)]
    [InlineData(0, 0)]
    public void ShouldReturnDoubledValue(int input, int expected)
    {
        // Act
        var result1 = _solution.ExampleMethod(input);
        // var result2 = _solution.AnotherMethod(input);

        // Assert
        Assert.Equal(expected, result1);
        // Assert.Equal(expected, result2);
        // Assert.Equal(result1, result2);
    }
}