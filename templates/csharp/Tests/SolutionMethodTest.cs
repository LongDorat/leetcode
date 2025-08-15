namespace TemplateProject.Tests;

public class SolutionMethodTest : Test
{
    [Fact]
    public void TestSolutionMethod()
    {
        // Arrange
        var input = new ParameterType();
        var expected = new ReturnType();

        // Act
        var result = _solutions.SolutionName(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
