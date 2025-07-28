# 5. Longest Palindromic Substring

## 📝 Problem Description

Given a string `s`, return the longest palindromic substring in `s`.

A string is palindromic if it reads the same forward and backward.

### Example 1:

```
Input: s = "babad"
Output: "bab"
Explanation: "aba" is also a valid answer.
```

### Example 2:

```
Input: s = "cbbd"
Output: "bb"
```

### Constraints:

- `1 <= s.length <= 1000`
- `s` consist of only digits and English letters

## 💡 Solution Approaches

### Approach 1: Brute Force

**Time Complexity:** O(n³)  
**Space Complexity:** O(1)

Check all possible substrings and verify if each one is a palindrome. For each starting position, check all possible ending positions and validate palindrome property by comparing characters from both ends.

```csharp
public string LongestPalindrome_BruteForce(string s)
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
```

**Pros:** Simple and straightforward implementation  
**Cons:** Very inefficient for large inputs due to cubic time complexity

### Approach 2: Dynamic Programming

**Time Complexity:** O(n²)  
**Space Complexity:** O(n²)

Use a 2D DP table where `dp[i][j]` represents whether substring from index `i` to `j` is a palindrome. Build the solution bottom-up starting from single characters, then pairs, then longer substrings.

```csharp
public string LongestPalindrome_Dynamic(string s)
{
    if (String.IsNullOrEmpty(s))
        return "";

    int len = s.Length;
    bool[,] substringTable = new bool[len, len];
    int start = 0, maxLength = 1;

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
```

**Pros:** Better time complexity than brute force, clear logic flow  
**Cons:** Uses O(n²) extra space, still not optimal for time complexity

### Approach 3: Expand Around Centers (Optimal)

**Time Complexity:** O(n²)  
**Space Complexity:** O(1)

For each possible center (both single character and between two characters), expand outwards while characters match. This handles both odd and even length palindromes efficiently.

```csharp
public string LongestPalindrome_Expansion(string s)
{
    if (String.IsNullOrEmpty(s))
        return "";

    int start = 0, maxLength = 1;

    for (int i = 0; i < s.Length; i++)
    {
        // Try both odd-length and even-length palindromes
        for (int j = 0; j <= 1; j++)
        {
            int low = i, high = i + j;
            
            while (low >= 0 && high < s.Length && s[low] == s[high])
            {
                if (high - low + 1 > maxLength)
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
```

**Pros:** Optimal space complexity, intuitive approach, handles both odd/even palindromes elegantly  
**Cons:** Still O(n²) time complexity (though optimal for general case)

## ⚡ Performance Analysis

| Approach | Time Complexity | Space Complexity | Notes |
|----------|----------------|------------------|-------|
| Brute Force | O(n³) | O(1) | Checks all substrings and validates each palindrome |
| Dynamic Programming | O(n²) | O(n²) | Uses memoization to avoid redundant palindrome checks |
| Expand Around Centers | O(n²) | O(1) | Most practical solution with optimal space usage |

## 🧪 Test Cases Covered

### Case 1: Single character string
- Input: `"a"`
- Output: `"a"`
- Edge case handling

### Case 2: No palindrome longer than 1
- Input: `"abcdef"`
- Output: `"a"` (or any single character)
- Default case verification

### Case 3: Entire string is palindrome
- Input: `"racecar"`
- Output: `"racecar"`
- Full string palindrome detection

### Case 4: Even-length palindrome
- Input: `"cbbd"`
- Output: `"bb"`
- Even-length palindrome handling

### Case 5: Multiple palindromes of same length
- Input: `"babad"`
- Output: `"bab"` or `"aba"`
- Either valid answer acceptable

### Case 6: Empty string
- Input: `""`
- Output: `""`
- Edge case validation

## 🏷️ Metadata

- **Difficulty:** Medium
- **Tags:** String, Dynamic Programming
- **Source:** [5. Longest Palindromic Substring](https://leetcode.com/problems/longest-palindromic-substring/)