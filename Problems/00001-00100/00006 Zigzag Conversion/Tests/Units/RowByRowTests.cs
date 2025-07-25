namespace ZigZag_Conversion.Tests.Units;

public class RowByRowTests : TestBase
{
    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("A", 1, "A")]
    [InlineData("ABC", 1, "ABC")]
    [InlineData("ABCDE", 4, "ABCED")]
    [InlineData("AB", 2, "AB")]
    [InlineData("ABCD", 2, "ACBD")]
    public void Convert_ValidInput_ReturnsCorrectZigzagConversion(string s, int numRows, string expected)
    {
        // Act
        var result = _solution.Convert_RowByRow(s, numRows);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", 3, "")]
    [InlineData("", 1, "")]
    public void Convert_EmptyString_ReturnsEmptyString(string s, int numRows, string expected)
    {
        // Act
        var result = _solution.Convert_RowByRow(s, numRows);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("A", 1)]
    [InlineData("ABCDEFGHIJKLMNOP", 1)]
    public void Convert_SingleRow_ReturnsOriginalString(string s, int numRows)
    {
        // Act
        var result = _solution.Convert_RowByRow(s, numRows);

        // Assert
        Assert.Equal(s, result);
    }

    [Theory]
    [InlineData("HELLO", 2, "HLOEL")]
    [InlineData("HELLOWORLD", 2, "HLOOLELWRD")]
    [InlineData("HELLOWORLD", 3, "HOLELWRDLO")]
    public void Convert_TwoAndThreeRows_ReturnsCorrectPattern(string s, int numRows, string expected)
    {
        // Act
        var result = _solution.Convert_RowByRow(s, numRows);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Convert_LongString_HandlesLargeInput()
    {
        // Arrange
        string longString = new string('A', 1000);
        int numRows = 5;

        // Act
        var result = _solution.Convert_RowByRow(longString, numRows);

        // Assert
        Assert.Equal(1000, result.Length);
        Assert.All(result, c => Assert.Equal('A', c));
    }
}
