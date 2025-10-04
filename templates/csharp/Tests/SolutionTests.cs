namespace Template.Tests;

public class ExampleMethodTests
{
    [Fact]
    public void ReturnsExpectedResult()
    {
        // Arrange
        var example = new Solution();

        // Act
        var result = example.ExampleMethod(4);

        // Assert
        Assert.Equal(8, result);
    }
}