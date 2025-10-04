namespace Template.Tests;

// This is where you would add tests for multiple solutions or cross-validation scenarios.
// For demonstration purposes, we'll only have one method here.
// In reality, you would implement tests that validate the consistency between different solutions.
public class CrossValidationTests
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