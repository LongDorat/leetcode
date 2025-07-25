using System.Linq;

namespace ZigZag_Conversion.Tests;

public class CrossValidationTests : TestBase
{
    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("A", 1, "A")]
    [InlineData("ABC", 1, "ABC")]
    [InlineData("ABCDE", 4, "ABCED")]
    [InlineData("AB", 2, "AB")]
    [InlineData("ABCD", 2, "ACBD")]
    [InlineData("", 3, "")]
    [InlineData("", 1, "")]
    [InlineData("HELLO", 2, "HLOEL")]
    [InlineData("HELLOWORLD", 2, "HLOOLELWRD")]
    [InlineData("HELLOWORLD", 3, "HOLELWRDLO")]
    public void AllMethods_SameInput_ReturnSameResult(string s, int numRows, string expected)
    {
        // Act
        var resultRowByRow = _solution.Convert_RowByRow(s, numRows);
        var resultCalculate = _solution.Convert_Calculate(s, numRows);

        // Assert
        Assert.Equal(expected, resultRowByRow);
        Assert.Equal(expected, resultCalculate);
        Assert.Equal(resultRowByRow, resultCalculate);
    }

    [Theory]
    [InlineData("ABCDEFGHIJKLMNOP", 1)]
    [InlineData("ABCDEFGHIJKLMNOP", 5)]
    [InlineData("ABCDEFGHIJKLMNOP", 8)]
    public void AllMethods_SingleRowAndComplexPatterns_ReturnSameResult(string s, int numRows)
    {
        // Act
        var resultRowByRow = _solution.Convert_RowByRow(s, numRows);
        var resultCalculate = _solution.Convert_Calculate(s, numRows);

        // Assert
        Assert.Equal(resultRowByRow, resultCalculate);
    }

    [Fact]
    public void AllMethods_LongString_ReturnSameResult()
    {
        // Arrange
        string longString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Repeat(10); // 260 characters
        int numRows = 7;

        // Act
        var resultRowByRow = _solution.Convert_RowByRow(longString, numRows);
        var resultCalculate = _solution.Convert_Calculate(longString, numRows);

        // Assert
        Assert.Equal(resultRowByRow, resultCalculate);
        Assert.Equal(260, resultRowByRow.Length);
        Assert.Equal(260, resultCalculate.Length);
    }

    [Theory]
    [InlineData("Test.String,With-Special!Characters", 3)]
    [InlineData("MixedCase123Numbers", 4)]
    [InlineData("a", 10)] // Single character with many rows
    public void AllMethods_SpecialCases_ReturnSameResult(string s, int numRows)
    {
        // Act
        var resultRowByRow = _solution.Convert_RowByRow(s, numRows);
        var resultCalculate = _solution.Convert_Calculate(s, numRows);

        // Assert
        Assert.Equal(resultRowByRow, resultCalculate);
    }
}

public static class StringExtensions
{
    public static string Repeat(this string str, int count)
    {
        return string.Concat(Enumerable.Repeat(str, count));
    }
}
