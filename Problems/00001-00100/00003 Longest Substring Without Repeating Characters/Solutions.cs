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
        // Handle empty string edge case
        if (string.IsNullOrEmpty(s))
            return 0;

        int left = 0;  // Left boundary of sliding window
        int right = 0; // Right boundary of sliding window
        Dictionary<char, int> charIndex = []; // Maps character to its most recent index
        int longestSubstring = 0; // Track the maximum length found

        // Sliding window approach: expand right, shrink left when duplicate found
        while (right < s.Length)
        {
            char currentChar = s[right];

            /* If current character was seen before and is within current window,
               move left pointer to just after the previous occurrence */
            if (charIndex.TryGetValue(currentChar, out int value) && value >= left)
            {
                left = value + 1; // Shrink window from left
            }

            // Update the most recent index of current character
            charIndex[currentChar] = right;

            // Update maximum length if current window is larger
            longestSubstring = Math.Max(longestSubstring, right - left + 1);

            right++; // Expand window to the right
        }

        return longestSubstring;
    }
}
