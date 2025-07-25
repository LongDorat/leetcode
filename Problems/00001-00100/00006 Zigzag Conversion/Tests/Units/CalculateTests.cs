using System.Linq;

namespace ZigZag_Conversion.Tests.Units;

public class CalculateTests : TestBase
{
    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("A", 1, "A")]
    [InlineData("ABC", 1, "ABC")]
    [InlineData("ABCDE", 4, "ABCED")]
    [InlineData("AB", 2, "AB")]
    [InlineData("ABCD", 2, "ACBD")]
    public void Convert_Calculate_ValidInput_ReturnsCorrectZigzagConversion(string s, int numRows, string expected)
    {
        // Act
        var result = _solution.Convert_Calculate(s, numRows);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("", 3, "")]
    [InlineData("", 1, "")]
    public void Convert_Calculate_EmptyString_ReturnsEmptyString(string s, int numRows, string expected)
    {
        // Act
        var result = _solution.Convert_Calculate(s, numRows);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("A", 1)]
    [InlineData("ABCDEFGHIJKLMNOP", 1)]
    public void Convert_Calculate_SingleRow_ReturnsOriginalString(string s, int numRows)
    {
        // Act
        var result = _solution.Convert_Calculate(s, numRows);

        // Assert
        Assert.Equal(s, result);
    }

    [Theory]
    [InlineData("HELLO", 2, "HLOEL")]
    [InlineData("HELLOWORLD", 2, "HLOOLELWRD")]
    [InlineData("HELLOWORLD", 3, "HOLELWRDLO")]
    public void Convert_Calculate_TwoAndThreeRows_ReturnsCorrectPattern(string s, int numRows, string expected)
    {
        // Act
        var result = _solution.Convert_Calculate(s, numRows);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Convert_Calculate_LongString_HandlesLargeInput()
    {
        // Arrange
        string longString = new string('A', 1000);
        int numRows = 5;

        // Act
        var result = _solution.Convert_Calculate(longString, numRows);

        // Assert
        Assert.Equal(1000, result.Length);
        Assert.All(result, c => Assert.Equal('A', c));
    }

    [Theory]
    [InlineData("Test.String,With-Special!Characters", 3)]
    [InlineData("MixedCase123Numbers", 4)]
    [InlineData("abcDEF123!@#", 5)]
    public void Convert_Calculate_SpecialCharacters_HandlesCorrectly(string s, int numRows)
    {
        // Act
        var result = _solution.Convert_Calculate(s, numRows);

        // Assert
        Assert.Equal(s.Length, result.Length);
        Assert.True(result.All(c => s.Contains(c)));
    }

    [Theory]
    [InlineData("ABCDEFGHIJKLMNOP", 6)]
    [InlineData("ABCDEFGHIJKLMNOP", 8)]
    [InlineData("ABCDEFGHIJKLMNOP", 16)]
    public void Convert_Calculate_ComplexPatterns_ReturnsValidResult(string s, int numRows)
    {
        // Act
        var result = _solution.Convert_Calculate(s, numRows);

        // Assert
        Assert.Equal(s.Length, result.Length);
        Assert.True(result.All(c => s.Contains(c)));
    }
}