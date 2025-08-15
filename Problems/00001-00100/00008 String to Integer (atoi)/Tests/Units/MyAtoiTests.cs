namespace String_to_Integer.Tests.Units;

public class MyAtoiTests : TestBase
{
    [Theory]
    [InlineData("42", 42)]
    [InlineData("   -42", -42)]
    [InlineData("4193 with words", 4193)]
    [InlineData("words and 987", 0)]
    [InlineData("-91283472332", int.MinValue)]
    [InlineData("91283472332", int.MaxValue)]
    [InlineData("", 0)]
    [InlineData("   ", 0)]
    [InlineData("0", 0)]
    [InlineData("-0", 0)]
    [InlineData("+0", 0)]
    [InlineData("00000-42a1234", 0)]
    [InlineData("0032", 32)]
    [InlineData("   +0 123", 0)]
    public void MyAtoi_ValidInput_ReturnsCorrectInteger(string input, int expected)
    {
        // Act
        var result = _solution.myAtoi(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void MyAtoi_NullString_ReturnsZero()
    {
        // Arrange
        string? input = null;

        // Act
        var result = _solution.myAtoi(input!);

        // Assert
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("2147483647", int.MaxValue)] // Max int value
    [InlineData("2147483648", int.MaxValue)] // Overflow
    [InlineData("99999999999999999999", int.MaxValue)] // Large overflow
    public void MyAtoi_PositiveOverflow_ReturnsMaxValue(string input, int expected)
    {
        // Act
        var result = _solution.myAtoi(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("-2147483648", int.MinValue)] // Min int value
    [InlineData("-21474836482", int.MinValue)] // Underflow to min
    [InlineData("-99999999999999999999", int.MinValue)] // Large underflow
    public void MyAtoi_NegativeUnderflow_ReturnsMinValue(string input, int expected)
    {
        // Act
        var result = _solution.myAtoi(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("+42", 42)]
    [InlineData("+123", 123)]
    [InlineData("+0", 0)]
    [InlineData("+-42", 0)] // Invalid: multiple signs
    [InlineData("-+42", 0)] // Invalid: multiple signs
    public void MyAtoi_SignHandling_ReturnsCorrectResult(string input, int expected)
    {
        // Act
        var result = _solution.myAtoi(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abc", 0)]
    [InlineData("", 0)]
    [InlineData("   ", 0)]
    [InlineData("+-", 0)]
    [InlineData("+", 0)]
    [InlineData("-", 0)]
    [InlineData("   +", 0)]
    [InlineData("   -", 0)]
    public void MyAtoi_InvalidInput_ReturnsZero(string input, int expected)
    {
        // Act
        var result = _solution.myAtoi(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("   123", 123)] // Leading whitespace
    [InlineData("123   ", 123)] // Should stop at space after digits
    [InlineData("  +123  ", 123)] // Whitespace around positive number
    [InlineData("  -123  ", -123)] // Whitespace around negative number
    public void MyAtoi_WhitespaceHandling_ReturnsCorrectResult(string input, int expected)
    {
        // Act
        var result = _solution.myAtoi(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123abc", 123)] // Stop at first non-digit
    [InlineData("123.45", 123)] // Stop at decimal point
    [InlineData("123e5", 123)] // Stop at scientific notation
    [InlineData("123-45", 123)] // Stop at minus after digits
    [InlineData("123+45", 123)] // Stop at plus after digits
    public void MyAtoi_StopAtNonDigit_ReturnsNumberBeforeNonDigit(string input, int expected)
    {
        // Act
        var result = _solution.myAtoi(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("0000123", 123)] // Leading zeros
    [InlineData("000", 0)] // All zeros
    [InlineData("-000123", -123)] // Leading zeros with negative
    [InlineData("+000123", 123)] // Leading zeros with positive
    public void MyAtoi_LeadingZeros_ReturnsCorrectResult(string input, int expected)
    {
        // Act
        var result = _solution.myAtoi(input);

        // Assert
        Assert.Equal(expected, result);
    }
}
