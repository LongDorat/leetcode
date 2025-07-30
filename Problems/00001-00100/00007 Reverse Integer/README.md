# 7. Reverse Integer

## 📝 Problem Description

Given a signed 32-bit integer `x`, return `x` with its digits reversed. If reversing `x` causes the value to go outside the signed 32-bit integer range `[-2³¹, 2³¹ - 1]`, then return `0`.

**Assume the environment does not allow you to store 64-bit integers (signed or unsigned).**

### Example 1:

```
Input: x = 123
Output: 321
Explanation: The digits of 123 are reversed to get 321.
```

### Example 2:

```
Input: x = -123
Output: -321
Explanation: The digits of -123 are reversed to get -321.
```

### Example 3:

```
Input: x = 120
Output: 21
Explanation: The digits of 120 are reversed to get 021, which is 21.
```

### Example 4:

```
Input: x = 1534236469
Output: 0
Explanation: The reversed integer 9646324351 overflows the 32-bit signed integer range, so return 0.
```

### Constraints:

- `-2³¹ <= x <= 2³¹ - 1`

## 💡 Solution Approach

### Mathematical Approach

**Time Complexity:** O(log n)  
**Space Complexity:** O(1)

Extract digits one by one using modulo and division operations, building the reversed number while checking for overflow before it occurs.

```csharp
public int Reverse(int x)
{
    int result = 0;
    while (x != 0)
    {
        int digit = x % 10;
        x /= 10;

        if (result > int.MaxValue / 10 ||
            (result == int.MaxValue / 10 && digit > 7))
        {
            return 0;
        }
        if (result < int.MinValue / 10 ||
            (result == int.MinValue / 10 && digit < -8))
        {
            return 0;
        }

        result = result * 10 + digit;
    }

    return result;
}
```

**Key Points:**

- Handles negative numbers naturally through modulo and division operations
- Checks for overflow before it occurs by comparing against `int.MaxValue/10` and `int.MinValue/10`
- For boundary cases: max digit can be 7 for positive overflow, -8 for negative overflow
- Optimal space complexity using only constant extra variables

## ⚡ Performance Analysis

| Approach     | Time Complexity | Space Complexity | Notes                                                              |
| ------------ | --------------- | ---------------- | ------------------------------------------------------------------ |
| Mathematical | O(log n)        | O(1)             | Optimal solution using integer arithmetic with overflow protection |

## 🧪 Test Cases Covered

### Edge Cases:

- **Zero input:** `x = 0` → `0`
- **Single digit:** `x = 5` → `5`
- **Negative numbers:** `x = -123` → `-321`
- **Trailing zeros:** `x = 120` → `21`
- **Overflow cases:** `x = 1534236469` → `0`
- **Minimum integer:** `x = -2147483648` → `0`
- **Maximum boundaries:** `x = 1463847412` → `2147483641`

### Standard Cases:

- **Positive numbers:** `x = 123` → `321`
- **Large numbers:** `x = 1234567` → `7654321`

## 🏷️ Metadata

- **Difficulty:** Medium
- **Tags:** Math
- **Source:** [7. Reverse Integer](https://leetcode.com/problems/reverse-integer/)
