namespace Longest_Palindromic_Substring;

public interface ISolution
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

public class Solution : ISolution
{
    public string LongestPalindrome_BruteForce(String s)
    {
        if (String.IsNullOrEmpty(s))
            return "";

        static bool IsPalindrome(string s, int low, int high)
        {
            while (low < high)
            {
                if (s[low] != s[high])
                    return false;
                low++;
                high--;
            }
            return true;
        }

        int start = 0, maxLength = 1;

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
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
        if (String.IsNullOrEmpty(s))
            return "";

        int len = s.Length;
        bool[,] substringTable = new bool[len, len];

        int start = 0, maxLength = 1;

        for (int i = 0; i < len; i++)
            substringTable[i, i] = true;

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

        for (int k = 3; k <= len; k++)
        {
            for (int i = 0; i < len - k + 1; i++)
            {
                int j = i + k - 1;
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
        if (String.IsNullOrEmpty(s))
            return "";

        int start = 0, maxLength = 1;
        
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j <= 1; j++)
            {
                int low = i, high = i + j;
                while (low >= 0 && high < s.Length)
                {
                    if (s[low] == s[high] && high - low + 1 > maxLength)
                    {
                        start = low;
                        maxLength = high - low + 1;
                    }
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