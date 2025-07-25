# 6. Zigzag Conversion

## 📝 Problem Description

The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: (you may want to display this pattern in a fixed font for better legibility)

```
P   A   H   R
A P L S I I G
Y   I   R
```

And then read line by line: "PAHNAPLSIIGYIR"

Write the code that will take a string and make this conversion given a number of rows.

### Example 1:

```
Input: s = "PAYPALISHIRING", numRows = 3
Output: "PAHNAPLSIIGYIR"
Explanation: 
P   A   H   R
A P L S I I G
Y   I   R
```

### Example 2:

```
Input: s = "PAYPALISHIRING", numRows = 4
Output: "PINALSIGYAHRPI"
Explanation:
P     I    N
A   L S  I G
Y A   H R
P     I
```

### Example 3:

```
Input: s = "A", numRows = 1
Output: "A"
```

### Constraints:

- `1 <= s.length <= 1000`
- `s` consists of English letters (lower-case and upper-case), ',' and '.'
- `1 <= numRows <= 1000`

## 💡 Solution Approaches

### Approach 1: Row-by-Row Simulation

**Time Complexity:** O(n)  
**Space Complexity:** O(n)

This approach simulates the zigzag pattern by using an array of StringBuilder objects, one for each row. We iterate through the string and place each character in the appropriate row based on the current direction of movement (up or down).

```csharp
public string Convert_RowByRow(string s, int numRows)
{
    if (numRows == 1 || string.IsNullOrEmpty(s))
        return s;

    StringBuilder[] rows = new StringBuilder[numRows];
    for (int i = 0; i < numRows; i++)
        rows[i] = new StringBuilder();

    int currentRow = 0;
    bool goingDown = false;

    foreach (var c in s)
    {
        rows[currentRow].Append(c);

        if (currentRow == 0 || currentRow == numRows - 1)
            goingDown = !goingDown;

        currentRow += goingDown ? 1 : -1;
    }

    var result = new StringBuilder();
    foreach (var row in rows)
        result.Append(row);

    return result.ToString();
}
```

**Pros:** 
- Easy to understand and implement
- Directly simulates the zigzag pattern
- Clean and readable code

**Cons:** 
- Uses extra space for StringBuilder arrays
- Requires concatenation at the end

### Approach 2: Mathematical Calculation

**Time Complexity:** O(n)  
**Space Complexity:** O(1) (excluding output)

This approach calculates the positions of characters in the zigzag pattern mathematically without explicitly creating the pattern. It uses the periodicity of the zigzag pattern to determine which characters belong to each row.

```csharp
public string Convert_Calculate(string s, int numRows)
{
    if (numRows == 1 || string.IsNullOrEmpty(s)) return s;

    StringBuilder result = new();
    int period = numRows * 2 - 2;

    for (int row = 0; row < numRows; row++)
    {
        int increment = row * 2;
        for (int i = row; i < s.Length; i += increment)
        {
            result.Append(s[i]);

            if (increment != period)
                increment = period - increment;
        }
    }

    return result.ToString();
}
```

**Pros:**
- More space-efficient (no intermediate row storage)
- Mathematical approach, potentially faster
- Direct character positioning

**Cons:**
- More complex logic to understand
- Requires understanding of the zigzag pattern mathematics

## ⚡ Performance Analysis

| Approach | Time Complexity | Space Complexity | Notes |
|----------|----------------|------------------|-------|
| Row-by-Row Simulation | O(n) | O(n) | Direct simulation approach, easy to understand |
| Mathematical Calculation | O(n) | O(1) | More space-efficient, uses pattern mathematics |

## 🧪 Test Cases Covered

### Case 1: Standard Examples
- **Input:** "PAYPALISHIRING", numRows = 3
- **Output:** "PAHNAPLSIIGYIR"
- **Input:** "PAYPALISHIRING", numRows = 4  
- **Output:** "PINALSIGYAHRPI"

### Case 2: Edge Cases
- **Single Row:** numRows = 1 returns original string
- **Empty String:** Returns empty string
- **Short Strings:** Handles strings shorter than numRows

### Case 3: Various Row Configurations
- **Two Rows:** Simple alternating pattern
- **Multiple Rows:** Complex zigzag patterns
- **Large Input:** Performance testing with long strings

### Case 4: Cross-Validation Testing
- **Method Consistency:** All solution approaches return identical results for the same inputs
- **Special Characters:** Testing with mixed case, numbers, and special characters
- **Performance Validation:** Long string testing to ensure both approaches handle large inputs correctly
- **Edge Case Validation:** Single character with many rows, empty strings, and boundary conditions

## 🏷️ Metadata

- **Difficulty:** Medium
- **Tags:** String, Simulation
- **Source:** LeetCode Problem #6
