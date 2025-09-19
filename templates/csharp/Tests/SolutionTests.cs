namespace Template.Tests;

// Declare the tests for one method in the Solution class. Other methods will have their own test file that are similarly structured.
public class ExampleMethodTests
{
    private readonly Solution _solution = new Solution();

    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 4)]
    [InlineData(3, 6)]
    [InlineData(-1, -2)]
    [InlineData(0, 0)]
    public void ExampleMethod_ShouldReturnDoubledValue(int input, int expected)
    {
        // Act
        var result = _solution.ExampleMethod(input);

        // Assert
        Assert.Equal(expected, result);
    }
}