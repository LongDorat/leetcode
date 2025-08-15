namespace Longest_Palindromic_Substring.Tests;

public class CrossValidationTests : TestBase
{
    [Fact]
    public void AllMethods_SameInput_ReturnSameResult_Test1()
    {
        // Arrange
        string s = "babad";

        // Act
        string bruteForceResult = _solution.LongestPalindrome_BruteForce(s);
        string dynamicResult = _solution.LongestPalindrome_Dynamic(s);
        string expansionResult = _solution.LongestPalindrome_Expansion(s);
        string manacherResult = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal(bruteForceResult.Length, dynamicResult.Length);
        Assert.Equal(bruteForceResult.Length, expansionResult.Length);
        Assert.Equal(bruteForceResult.Length, manacherResult.Length);

        // All results should be valid palindromes of the same length
        Assert.True(IsPalindrome(bruteForceResult));
        Assert.True(IsPalindrome(dynamicResult));
        Assert.True(IsPalindrome(expansionResult));
        Assert.True(IsPalindrome(manacherResult));
    }

    [Fact]
    public void AllMethods_SameInput_ReturnSameResult_Test2()
    {
        // Arrange
        string s = "cbbd";

        // Act
        string bruteForceResult = _solution.LongestPalindrome_BruteForce(s);
        string dynamicResult = _solution.LongestPalindrome_Dynamic(s);
        string expansionResult = _solution.LongestPalindrome_Expansion(s);
        string manacherResult = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal(bruteForceResult.Length, dynamicResult.Length);
        Assert.Equal(bruteForceResult.Length, expansionResult.Length);
        Assert.Equal(bruteForceResult.Length, manacherResult.Length);

        // All results should be valid palindromes of the same length
        Assert.True(IsPalindrome(bruteForceResult));
        Assert.True(IsPalindrome(dynamicResult));
        Assert.True(IsPalindrome(expansionResult));
        Assert.True(IsPalindrome(manacherResult));
    }

    [Fact]
    public void AllMethods_SameInput_ReturnSameResult_Test3()
    {
        // Arrange
        string s = "a";

        // Act
        string bruteForceResult = _solution.LongestPalindrome_BruteForce(s);
        string dynamicResult = _solution.LongestPalindrome_Dynamic(s);
        string expansionResult = _solution.LongestPalindrome_Expansion(s);
        string manacherResult = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal(bruteForceResult, dynamicResult);
        Assert.Equal(bruteForceResult, expansionResult);
        Assert.Equal(bruteForceResult, manacherResult);
        Assert.Equal("a", bruteForceResult);
    }

    [Fact]
    public void AllMethods_SameInput_ReturnSameResult_Test4()
    {
        // Arrange
        string s = "racecar";

        // Act
        string bruteForceResult = _solution.LongestPalindrome_BruteForce(s);
        string dynamicResult = _solution.LongestPalindrome_Dynamic(s);
        string expansionResult = _solution.LongestPalindrome_Expansion(s);
        string manacherResult = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal(bruteForceResult, dynamicResult);
        Assert.Equal(bruteForceResult, expansionResult);
        Assert.Equal(bruteForceResult, manacherResult);
        Assert.Equal("racecar", bruteForceResult);
    }

    [Fact]
    public void AllMethods_SameInput_ReturnSameResult_Test5()
    {
        // Arrange
        string s = "abcdef";

        // Act
        string bruteForceResult = _solution.LongestPalindrome_BruteForce(s);
        string dynamicResult = _solution.LongestPalindrome_Dynamic(s);
        string expansionResult = _solution.LongestPalindrome_Expansion(s);
        string manacherResult = _solution.LongestPalindrome_Manacher(s);

        // Assert
        Assert.Equal(bruteForceResult.Length, dynamicResult.Length);
        Assert.Equal(bruteForceResult.Length, expansionResult.Length);
        Assert.Equal(bruteForceResult.Length, manacherResult.Length);
        Assert.Equal(1, bruteForceResult.Length); // Should be single character

        // All results should be valid palindromes of the same length
        Assert.True(IsPalindrome(bruteForceResult));
        Assert.True(IsPalindrome(dynamicResult));
        Assert.True(IsPalindrome(expansionResult));
        Assert.True(IsPalindrome(manacherResult));
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