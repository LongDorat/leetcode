namespace Longest_Substring_Without_Repeating_Characters.Tests.Units;

public class LengthOfLongestSubstringTests : TestBase
{
    [Fact]
    public void LengthOfLongestSubstring_EmptyString_ReturnsZero()
    {
        // Arrange
        string input = "";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_SingleCharacter_ReturnsOne()
    {
        // Arrange
        string input = "a";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_AllUniqueCharacters_ReturnsFullLength()
    {
        // Arrange
        string input = "abcdef";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_AllSameCharacters_ReturnsOne()
    {
        // Arrange
        string input = "aaaa";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_Example1_ReturnsThree()
    {
        // Arrange - "abcabcbb" -> "abc" has length 3
        string input = "abcabcbb";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_Example2_ReturnsOne()
    {
        // Arrange - "bbbbb" -> "b" has length 1
        string input = "bbbbb";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_Example3_ReturnsThree()
    {
        // Arrange - "pwwkew" -> "wke" has length 3
        string input = "pwwkew";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_WithSpaces_ReturnsCorrectLength()
    {
        // Arrange - " " (single space)
        string input = " ";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_WithSpecialCharacters_ReturnsCorrectLength()
    {
        // Arrange - "!@#$%^&*()"
        string input = "!@#$%^&*()";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_WithNumbers_ReturnsCorrectLength()
    {
        // Arrange - "1234512345"
        string input = "1234512345";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_LongestAtBeginning_ReturnsCorrectLength()
    {
        // Arrange - "abcdef" followed by repeating characters
        string input = "abcdefaa";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_LongestAtEnd_ReturnsCorrectLength()
    {
        // Arrange - repeating characters followed by "abcdef"
        string input = "aaabcdef";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void LengthOfLongestSubstring_LongestInMiddle_ReturnsCorrectLength()
    {
        // Arrange - "aa" + "bcdef" + "aa"
        string input = "aabcdefaa";

        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(6, result);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("a", 1)]
    [InlineData("ab", 2)]
    [InlineData("abc", 3)]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("dvdf", 3)]
    [InlineData("anviaj", 5)]
    [InlineData("tmmzuxt", 5)]
    public void LengthOfLongestSubstring_TheoryTest_ReturnsExpectedLength(string input, int expected)
    {
        // Act
        int result = _solution.LengthOfLongestSubstring(input);

        // Assert
        Assert.Equal(expected, result);
    }
}