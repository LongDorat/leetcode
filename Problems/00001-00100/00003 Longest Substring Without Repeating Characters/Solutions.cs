namespace Longest_Substring_Without_Repeating_Characters;

public interface ISolutions
{
    /// <summary>
    /// Finds the length of the longest substring without repeating characters.
    /// </summary>
    /// <param name="s">
    /// The input string to analyze for the longest substring without repeating characters.
    /// If the string is empty, the method should return 0.
    /// </param>
    /// <returns>
    /// Return the length of the longest substring without repeating characters.
    /// If the input string is empty, return 0.
    /// </returns>
    /// <remarks>Time Complexity: O(n), Space Complexity: O(min(m, n))</remarks>
    int LengthOfLongestSubstring(string s);
}

public class Solutions : ISolutions
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        int left = 0;
        int right = 0;
        Dictionary<char, int> charIndex = [];
        int longestSubstring = 0;

        while (right < s.Length)
        {
            char currentChar = s[right];

            if (charIndex.TryGetValue(currentChar, out int value) && value >= left)
            {
                left = value + 1;
            }

            charIndex[currentChar] = right;

            longestSubstring = Math.Max(longestSubstring, right - left + 1);

            right++;
        }

        return longestSubstring;
    }
}
