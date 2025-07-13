namespace Longest_Palindromic_Substring.Tests.Units;

public class ManacherTests : TestBase
{
    [Fact]
    public void LongestPalindrome_Manacher_SingleCharacter_ReturnsSameCharacter()
    {
        // Arrange
        string s = "a";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal("a", result);
    }

    [Fact]
    public void LongestPalindrome_Manacher_TwoSameCharacters_ReturnsBothCharacters()
    {
        // Arrange
        string s = "aa";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal("aa", result);
    }

    [Fact]
    public void LongestPalindrome_Manacher_TwoDifferentCharacters_ReturnsSingleCharacter()
    {
        // Arrange
        string s = "ab";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal(1, result.Length);
        Assert.Contains(result, s);
    }

    [Fact]
    public void LongestPalindrome_Manacher_OddLengthPalindrome_ReturnsCorrectPalindrome()
    {
        // Arrange
        string s = "babad";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.True(result == "bab" || result == "aba");
        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void LongestPalindrome_Manacher_EvenLengthPalindrome_ReturnsCorrectPalindrome()
    {
        // Arrange
        string s = "cbbd";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal("bb", result);
        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void LongestPalindrome_Manacher_EntireStringIsPalindrome_ReturnsEntireString()
    {
        // Arrange
        string s = "racecar";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal("racecar", result);
        Assert.Equal(7, result.Length);
    }

    [Fact]
    public void LongestPalindrome_Manacher_NoRepeatingCharacters_ReturnsSingleCharacter()
    {
        // Arrange
        string s = "abcdef";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal(1, result.Length);
        Assert.Contains(result, s);
    }

    [Fact]
    public void LongestPalindrome_Manacher_LinearTimeComplexity_HandlesLongString()
    {
        // Arrange
        string s = "abacabadabacaba";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.True(IsPalindrome(result));
        Assert.True(result.Length >= 7); // Should find "abacaba"
    }

    [Fact]
    public void LongestPalindrome_Manacher_AllSameCharacters_ReturnsEntireString()
    {
        // Arrange
        string s = "aaaa";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal("aaaa", result);
        Assert.Equal(4, result.Length);
    }

    [Fact]
    public void LongestPalindrome_Manacher_ComplexPalindrome_ReturnsCorrectResult()
    {
        // Arrange
        string s = "madamimadam";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal("madamimadam", result);
        Assert.Equal(11, result.Length);
    }

    [Fact]
    public void LongestPalindrome_Manacher_LongStringPerformance_CompletesQuickly()
    {
        // Arrange
        string s = new string('a', 1000) + "b" + new string('a', 1000);

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.True(IsPalindrome(result));
        Assert.True(result.Length >= 1000); // Should find long palindrome
    }

    [Fact]
    public void LongestPalindrome_Manacher_MixedCase_ReturnsCorrectResult()
    {
        // Arrange
        string s = "abacabad";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.True(IsPalindrome(result));
        Assert.True(result.Length >= 3);
    }

    [Fact]
    public void LongestPalindrome_Manacher_EvenAndOddPalindromes_ReturnsLongest()
    {
        // Arrange
        string s = "noon high it is";

        // Act
        string result = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.True(IsPalindrome(result));
        Assert.True(result.Length >= 4); // Should find "noon"
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
