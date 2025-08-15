namespace Longest_Palindromic_Substring.Tests.Units;

public class DynamicTests : TestBase
{
    [Fact]
    public void LongestPalindrome_Dynamic_SingleCharacter_ReturnsSameCharacter()
    {
        // Arrange
        string s = "a";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.Equal("a", result);
    }

    [Fact]
    public void LongestPalindrome_Dynamic_TwoSameCharacters_ReturnsBothCharacters()
    {
        // Arrange
        string s = "aa";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.Equal("aa", result);
    }

    [Fact]
    public void LongestPalindrome_Dynamic_TwoDifferentCharacters_ReturnsSingleCharacter()
    {
        // Arrange
        string s = "ab";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.Equal(1, result.Length);
        Assert.Contains(result, s);
    }

    [Fact]
    public void LongestPalindrome_Dynamic_OddLengthPalindrome_ReturnsCorrectPalindrome()
    {
        // Arrange
        string s = "babad";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.True(result == "bab" || result == "aba");
        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void LongestPalindrome_Dynamic_EvenLengthPalindrome_ReturnsCorrectPalindrome()
    {
        // Arrange
        string s = "cbbd";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.Equal("bb", result);
        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void LongestPalindrome_Dynamic_EntireStringIsPalindrome_ReturnsEntireString()
    {
        // Arrange
        string s = "racecar";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.Equal("racecar", result);
        Assert.Equal(7, result.Length);
    }

    [Fact]
    public void LongestPalindrome_Dynamic_NoRepeatingCharacters_ReturnsSingleCharacter()
    {
        // Arrange
        string s = "abcdef";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.Equal(1, result.Length);
        Assert.Contains(result, s);
    }

    [Fact]
    public void LongestPalindrome_Dynamic_LongPalindrome_ReturnsCorrectPalindrome()
    {
        // Arrange
        string s = "abacabad";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.True(IsPalindrome(result));
        Assert.True(result.Length >= 3); // Should find "aba" or longer
    }

    [Fact]
    public void LongestPalindrome_Dynamic_MultiplePalindromes_ReturnsLongest()
    {
        // Arrange
        string s = "abacabadabacaba";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.True(IsPalindrome(result));
        Assert.True(result.Length >= 7); // Should find "abacaba"
    }

    [Fact]
    public void LongestPalindrome_Dynamic_AllSameCharacters_ReturnsEntireString()
    {
        // Arrange
        string s = "aaaa";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.Equal("aaaa", result);
        Assert.Equal(4, result.Length);
    }

    [Fact]
    public void LongestPalindrome_Dynamic_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string s = "";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.Equal("", result);
    }

    [Fact]
    public void LongestPalindrome_Dynamic_ComplexPalindrome_ReturnsCorrectResult()
    {
        // Arrange
        string s = "bananas";

        // Act
        string result = _solution.LongestPalindrome_Dynamic(s);

        // Assert
        Assert.True(IsPalindrome(result));
        Assert.True(result.Length >= 3); // Should find "ana" or "anan"
    }

    private static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return true;

        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            if (s[left] != s[right])
                return false;
            left++;
            right--;
        }
        return true;
    }
}