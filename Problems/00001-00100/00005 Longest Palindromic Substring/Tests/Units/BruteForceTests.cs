namespace Longest_Palindromic_Substring.Tests.Units;

public class BruteForceTests : TestBase
{
    [Fact]
    public void LongestPalindrome_BruteForce_SingleCharacter_ReturnsSameCharacter()
    {
        // Arrange
        string s = "a";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.Equal("a", result);
    }

    [Fact]
    public void LongestPalindrome_BruteForce_TwoSameCharacters_ReturnsBothCharacters()
    {
        // Arrange
        string s = "aa";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.Equal("aa", result);
    }

    [Fact]
    public void LongestPalindrome_BruteForce_TwoDifferentCharacters_ReturnsSingleCharacter()
    {
        // Arrange
        string s = "ab";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.Equal(1, result.Length);
        Assert.Contains(result, s);
    }

    [Fact]
    public void LongestPalindrome_BruteForce_OddLengthPalindrome_ReturnsCorrectPalindrome()
    {
        // Arrange
        string s = "babad";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.True(result == "bab" || result == "aba");
        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void LongestPalindrome_BruteForce_EvenLengthPalindrome_ReturnsCorrectPalindrome()
    {
        // Arrange
        string s = "cbbd";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.Equal("bb", result);
        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void LongestPalindrome_BruteForce_EntireStringIsPalindrome_ReturnsEntireString()
    {
        // Arrange
        string s = "racecar";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.Equal("racecar", result);
        Assert.Equal(7, result.Length);
    }

    [Fact]
    public void LongestPalindrome_BruteForce_NoRepeatingCharacters_ReturnsSingleCharacter()
    {
        // Arrange
        string s = "abcdef";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.Equal(1, result.Length);
        Assert.Contains(result, s);
    }

    [Fact]
    public void LongestPalindrome_BruteForce_LongPalindrome_ReturnsCorrectPalindrome()
    {
        // Arrange
        string s = "abacabad";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.True(IsPalindrome(result));
        Assert.True(result.Length >= 3); // Should find "aba" or longer
    }

    [Fact]
    public void LongestPalindrome_BruteForce_MultiplePalindromes_ReturnsLongest()
    {
        // Arrange
        string s = "abacabadabacaba";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.True(IsPalindrome(result));
        Assert.True(result.Length >= 7); // Should find "abacaba"
    }

    [Fact]
    public void LongestPalindrome_BruteForce_AllSameCharacters_ReturnsEntireString()
    {
        // Arrange
        string s = "aaaa";

        // Act
        string result = _solution.LongestPalindrome_BruteForce(s);

        // Assert
        Assert.Equal("aaaa", result);
        Assert.Equal(4, result.Length);
    }

    private static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return false;
        
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
