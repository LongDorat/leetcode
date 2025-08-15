namespace Reverse_Integer.Tests.Units;

public class ReverseTests : TestBase
{
    [Theory]
    [InlineData(123, 321)]
    [InlineData(-123, -321)]
    [InlineData(120, 21)]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(-1, -1)]
    [InlineData(10, 1)]
    [InlineData(100, 1)]
    [InlineData(1000, 1)]
    [InlineData(54321, 12345)]
    [InlineData(-54321, -12345)]
    public void Reverse_ValidInput_ReturnsReversedInteger(int input, int expected)
    {
        // Act
        var result = _solution.Reverse(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1534236469)] // Would reverse to 9646324351, which overflows int.MaxValue
    [InlineData(-1563847412)] // Would reverse to -2147483651, which underflows int.MinValue
    public void Reverse_OverflowInput_ReturnsZero(int input)
    {
        // Act
        var result = _solution.Reverse(input);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Reverse_IntMaxValue_ReturnsZero()
    {
        // Arrange
        int input = int.MaxValue; // 2147483647

        // Act
        var result = _solution.Reverse(input);

        // Assert - Reversed would be 7463847412, which overflows
        Assert.Equal(0, result);
    }

    [Fact]
    public void Reverse_IntMinValue_ReturnsZero()
    {
        // Arrange
        int input = int.MinValue; // -2147483648

        // Act
        var result = _solution.Reverse(input);

        // Assert - Reversed would be -8463847412, which underflows
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData(1000000003, 3000000001)] // This should overflow and return 0
    [InlineData(-1000000003, -3000000001)] // This should underflow and return 0
    public void Reverse_LargeNumbers_ReturnsZeroOnOverflow(int input, long expectedIfNoOverflow)
    {
        // Act
        var result = _solution.Reverse(input);

        // Assert
        // Since expectedIfNoOverflow exceeds int range, should return 0
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData(7, 7)]
    [InlineData(8, 8)]
    [InlineData(9, 9)]
    [InlineData(-7, -7)]
    [InlineData(-8, -8)]
    [InlineData(-9, -9)]
    public void Reverse_SingleDigitNumbers_ReturnsSameNumber(int input, int expected)
    {
        // Act
        var result = _solution.Reverse(input);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1200, 21)]
    [InlineData(12000, 21)]
    [InlineData(120000, 21)]
    [InlineData(-1200, -21)]
    [InlineData(-12000, -21)]
    public void Reverse_NumbersWithTrailingZeros_RemovesLeadingZerosFromResult(int input, int expected)
    {
        // Act
        var result = _solution.Reverse(input);

        // Assert
        Assert.Equal(expected, result);
    }
}