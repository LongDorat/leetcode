# 8. String to Integer (atoi)

## 📝 Problem Description

Implement the `myAtoi(string s)` function, which converts a string to a 32-bit signed integer (similar to C/C++'s `atoi` function).

The algorithm for `myAtoi(string s)` is as follows:

1. Read in and ignore any leading whitespace.
2. Check if the next character (if not already at the end of the string) is `'-'` or `'+'`. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
3. Read in next the characters until the next non-digit character or the end of the input is reached. The rest of the string is ignored.
4. Convert these digits into an integer (i.e. `"123"` -> `123`, `"0032"` -> `32`). If no digits were read, then the integer is `0`. Change the sign as necessary (from step 2).
5. If the integer is out of the 32-bit signed integer range `[-2³¹, 2³¹ - 1]`, then clamp the integer so that it remains in the range. Specifically, integers less than `-2³¹` should be clamped to `-2³¹`, and integers greater than `2³¹ - 1` should be clamped to `2³¹ - 1`.
6. Return the integer as the final result.

### Example 1:

```
Input: s = "42"
Output: 42
Explanation: The underlined characters are what is read in, the caret is the current reader position.
Step 1: "42" (no characters read because there is no leading whitespace)
         ^
Step 2: "42" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "42" (characters "42" are read in)
           ^
The parsed integer is 42.
Since 42 is in the range [-2³¹, 2³¹ - 1], the final result is 42.
```

### Example 2:

```
Input: s = "   -42"
Output: -42
Explanation:
Step 1: "   -42" (leading whitespace is read and ignored)
            ^
Step 2: "   -42" ('-' is read, so the result should be negative)
             ^
Step 3: "   -42" ("42" is read in)
               ^
The parsed integer is -42.
Since -42 is in the range [-2³¹, 2³¹ - 1], the final result is -42.
```

### Example 3:

```
Input: s = "4193 with words"
Output: 4193
Explanation:
Step 1: "4193 with words" (no characters read because there is no leading whitespace)
         ^
Step 2: "4193 with words" (no characters read because there is neither a '-' nor '+')
         ^
Step 3: "4193 with words" ("4193" is read in; reading stops because the next character is a non-digit)
             ^
The parsed integer is 4193.
Since 4193 is in the range [-2³¹, 2³¹ - 1], the final result is 4193.
```

### Constraints:

- `0 <= s.length <= 200`
- `s` consists of English letters (lower-case and upper-case), digits (0-9), ' ', '+', '-', and '.'.

## 💡 Solution Approaches

### Approach: State Machine with Overflow Detection

**Time Complexity:** O(n)  
**Space Complexity:** O(1)

This approach implements a state machine that processes the string character by character, handling each step of the algorithm systematically:

1. **Whitespace handling**: Skip leading whitespace
2. **Sign detection**: Check for '+' or '-' signs
3. **Digit processing**: Convert valid digits while checking for overflow
4. **Overflow protection**: Prevent integer overflow by checking bounds before multiplication

```csharp
public int myAtoi(string s)
{
    if (string.IsNullOrEmpty(s))
        return 0;

    s = s.Trim();
    
    if (string.IsNullOrEmpty(s))
        return 0;

    int index = 0;
    bool isNegative = false;
    
    // Handle sign
    if (s[index] == '-')
    {
        isNegative = true;
        index++;
    }
    else if (s[index] == '+')
        index++;

    int result = 0;
    while (index < s.Length && s[index] >= '0' && s[index] <= '9')
    {
        int digit = s[index] - '0';

        // Check for overflow before adding the digit
        if (!isNegative && (result > int.MaxValue / 10 || 
            (result == int.MaxValue / 10 && digit > 7)))
        {
            return int.MaxValue;
        }
        else if (isNegative && (result > -(int.MinValue / 10) || 
            (result == -(int.MinValue / 10) && digit > 8)))
        {
            return int.MinValue;
        }

        result = result * 10 + digit;
        index++;
    }

    return isNegative ? -result : result;
}
```

**Pros:** 
- Linear time complexity
- Constant space usage
- Handles all edge cases including overflow
- Clean, readable implementation

**Cons:** 
- Requires careful overflow boundary calculations
- Multiple edge cases to handle correctly

## ⚡ Performance Analysis

| Approach | Time Complexity | Space Complexity | Notes |
|----------|----------------|------------------|-------|
| State Machine | O(n) | O(1) | Where n is the length of the input string |

## 🧪 Test Cases Covered

### Basic Cases:
- `"42"` → `42` (simple positive number)
- `"   -42"` → `-42` (negative with leading whitespace)
- `"4193 with words"` → `4193` (stops at first non-digit)

### Edge Cases:
- `""` → `0` (empty string)
- `"   "` → `0` (whitespace only)
- `"words and 987"` → `0` (no leading digits)
- `"+-42"` → `0` (invalid sign combination)

### Overflow Cases:
- `"91283472332"` → `2147483647` (positive overflow)
- `"-91283472332"` → `-2147483648` (negative overflow)

### Sign Handling:
- `"+42"` → `42` (explicit positive sign)
- `"-0"` → `0` (negative zero)
- `"0000123"` → `123` (leading zeros)

## 🏷️ Metadata

- **Difficulty:** Medium
- **Tags:** String, State Machine
- **Source:** [8. String to Integer (atoi)](https://leetcode.com/problems/string-to-integer-atoi/)
