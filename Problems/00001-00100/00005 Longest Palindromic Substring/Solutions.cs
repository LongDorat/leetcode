namespace Longest_Palindromic_Substring;

public interface ISolutions
{
    /// <summary>
    /// Problem description
    /// </summary>
    /// <param name="parameters">Parameters for the method</param>
    /// <returns>Return type description</returns>
    /// <remarks>Time Complexity: O(?), Space Complexity: O(?)</remarks>
    string LongestPalindrome_BruteForce(String s);
    string LongestPalindrome_Dynamic(string s);
    string LongestPalindrome_Expansion(string s);
    string LongestPalindrome_Manacher(string s);
}

public class Solutions : ISolutions
{
    public string LongestPalindrome_BruteForce(String s)
    {
        // Handle empty string edge case
        if (String.IsNullOrEmpty(s))
            return "";

        // Helper function to check if substring is palindrome
        static bool IsPalindrome(string s, int low, int high)
        {
            // Check characters from outside towards center
            while (low < high)
            {
                if (s[low] != s[high])
                    return false;
                low++;
                high--;
            }
            return true;
        }

        int start = 0, maxLength = 1; // Track longest palindrome found

        // Check all possible substrings
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                // If current substring is palindrome and longer than previous max
                if (IsPalindrome(s, i, j) && (j - i + 1) > maxLength)
                {
                    start = i;
                    maxLength = j - i + 1;
                }
            }
        }

        return s.Substring(start, maxLength);
    }

    public string LongestPalindrome_Dynamic(string s)
    {
        // Handle empty string edge case
        if (String.IsNullOrEmpty(s))
            return "";

        int len = s.Length;
        // DP table: substringTable[i,j] = true if substring from i to j is palindrome
        bool[,] substringTable = new bool[len, len];

        int start = 0, maxLength = 1; // Track longest palindrome found

        // All single characters are palindromes
        for (int i = 0; i < len; i++)
            substringTable[i, i] = true;

        // Check for palindromes of length 2
        for (int i = 0; i < len - 1; i++)
            if (s[i] == s[i + 1])
            {
                substringTable[i, i + 1] = true;
                if (maxLength < 2)
                {
                    start = i;
                    maxLength = 2;
                }
            }

        // Check for palindromes of length 3 and above
        for (int k = 3; k <= len; k++) // k is the length of substring
        {
            for (int i = 0; i < len - k + 1; i++)
            {
                int j = i + k - 1; // End index of substring

                /* A substring is palindrome if:
                   1. First and last characters match
                   2. Inner substring is also palindrome */
                if (s[i] == s[j] && substringTable[i + 1, j - 1])
                {
                    substringTable[i, j] = true;
                    if (k > maxLength)
                    {
                        start = i;
                        maxLength = k;
                    }
                }
            }
        }

        return s.Substring(start, maxLength);
    }

    public string LongestPalindrome_Expansion(string s)
    {
        // Handle empty string edge case
        if (String.IsNullOrEmpty(s))
            return "";

        int start = 0, maxLength = 1; // Track longest palindrome found

        // For each possible center, expand outwards to find palindromes
        for (int i = 0; i < s.Length; i++)
        {
            /* Try both odd-length (center at i) and even-length (center between i and i+1) palindromes.
               j=0: odd-length palindrome centered at i
               j=1: even-length palindrome centered between i and i+1 */
            for (int j = 0; j <= 1; j++)
            {
                int low = i, high = i + j; // Set initial boundaries

                // Expand outwards while characters match and indices are valid
                while (low >= 0 && high < s.Length && s[low] == s[high])
                {
                    // If current palindrome is longer than previous max
                    if (high - low + 1 > maxLength)
                    {
                        start = low;
                        maxLength = high - low + 1;
                    }
                    // Expand outwards
                    low--;
                    high++;
                }
            }
        }

        return s.Substring(start, maxLength);
    }

    //TODO: Implement Manacher's algorithm
    public string LongestPalindrome_Manacher(string s)
    {
        return "";
    }
}