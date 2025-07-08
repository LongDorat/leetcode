# 3. Longest Substring Without Repeating Characters

## 📝 Problem Description

Given a string `s`, find the length of the **longest substring** without repeating characters.

### Example 1:

```
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
```

### Example 2:

```
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
```

### Example 3:

```
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
```

### Constraints:

- `0 <= s.length <= 5 * 10^4`
- `s` consists of English letters, digits, symbols and spaces.

## 💡 Solution Approaches

### Approach 1: Brute Force

**Time Complexity:** O(n³)
**Space Complexity:** O(min(m, n))

Check all possible substrings and find the longest one without repeating characters:

```csharp
public int LengthOfLongestSubstring(string s)
{
    int maxLength = 0;
    
    for (int i = 0; i < s.Length; i++)
    {
        for (int j = i; j < s.Length; j++)
        {
            if (AllUnique(s, i, j))
            {
                maxLength = Math.Max(maxLength, j - i + 1);
            }
        }
    }
    
    return maxLength;
}

private bool AllUnique(string s, int start, int end)
{
    var seen = new HashSet<char>();
    for (int i = start; i <= end; i++)
    {
        if (seen.Contains(s[i]))
            return false;
        seen.Add(s[i]);
    }
    return true;
}
```

**Pros:** Simple and straightforward
**Cons:** Very inefficient for large strings

### Approach 2: Sliding Window with HashSet

**Time Complexity:** O(2n) = O(n)
**Space Complexity:** O(min(m, n))

Use two pointers and a HashSet to maintain a sliding window:

```csharp
public int LengthOfLongestSubstring(string s)
{
    var seen = new HashSet<char>();
    int left = 0, maxLength = 0;
    
    for (int right = 0; right < s.Length; right++)
    {
        while (seen.Contains(s[right]))
        {
            seen.Remove(s[left]);
            left++;
        }
        
        seen.Add(s[right]);
        maxLength = Math.Max(maxLength, right - left + 1);
    }
    
    return maxLength;
}
```

**Pros:** Better time complexity than brute force
**Cons:** Still involves some backtracking with the left pointer

### Approach 3: Optimized Sliding Window with HashMap (Optimal)

**Time Complexity:** O(n)
**Space Complexity:** O(min(m, n))

Use a HashMap to store character indices and skip characters more efficiently:

```csharp
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
```

**Pros:** Optimal time complexity with single pass
**Cons:** Uses extra space for the HashMap

## ⚡ Performance Analysis

| Approach                    | Time Complexity | Space Complexity | Best Case | Worst Case |
| --------------------------- | --------------- | ---------------- | --------- | ---------- |
| Brute Force                 | O(n³)           | O(min(m,n))      | O(1)      | O(n³)      |
| Sliding Window (HashSet)    | O(2n)           | O(min(m,n))      | O(n)      | O(2n)      |
| Optimized Sliding Window    | O(n)            | O(min(m,n))      | O(n)      | O(n)       |

Where:
- `n` = length of the string
- `m` = size of the character set (constant for ASCII/Unicode)

## 🧪 Test Cases Covered

### Edge Cases:
- Empty string: `""` → `0`
- Single character: `"a"` → `1`
- All unique characters: `"abcdef"` → `6`
- All same characters: `"aaaa"` → `1`

### Normal Cases:
- Example 1: `"abcabcbb"` → `3` (substring: "abc")
- Example 2: `"bbbbb"` → `1` (substring: "b")
- Example 3: `"pwwkew"` → `3` (substring: "wke")

### Special Characters:
- With spaces: `" "` → `1`
- With symbols: `"!@#$%^&*()"` → `10`
- With numbers: `"1234512345"` → `5`

### Position Variations:
- Longest at beginning: `"abcdefaa"` → `6`
- Longest at end: `"aaabcdef"` → `6`
- Longest in middle: `"aabcdefaa"` → `6`

## 🏷️ Metadata

- **Difficulty**: Medium
- **Tags**: Hash Table, String, Sliding Window
- **Source**: [3. Longest Substring Without Repeating Characters](https://leetcode.com/problems/longest-substring-without-repeating-characters/)
