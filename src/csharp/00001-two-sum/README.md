# 1. Two Sum

## 📝 Problem Description

Given an array of integers `nums` and an integer `target`, return indices of the two numbers such that they add up to `target`.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

### Example 1:

```
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
```

### Example 2:

```
Input: nums = [3,2,4], target = 6
Output: [1,2]
```

### Example 3:

```
Input: nums = [3,3], target = 6
Output: [0,1]
```

### Constraints:

- `2 <= nums.length <= 10⁴`
- `-10⁹ <= nums[i] <= 10⁹`
- `-10⁹ <= target <= 10⁹`
- Only one valid answer exists

## 💡 Solution Approaches

### Approach 1: Brute Force

**Time Complexity:** O(n²)  
**Space Complexity:** O(1)

The brute force approach checks every possible pair of numbers in the array to see if they sum to the target. We use two nested loops where the outer loop fixes the first element and the inner loop searches for the complement.

```csharp
public int[] TwoSum_BruteForce(int[] nums, int target)
{
    if (nums.Length == 0 || nums.Length == 1)
        return [];

    for (int i = 0; i < nums.Length - 1; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[i] + nums[j] == target)
                return [i, j];
        }
    }
    return [];
}
```

**Pros:** Simple to understand and implement, requires no extra space  
**Cons:** Inefficient for large arrays due to quadratic time complexity

### Approach 2: Hash Table (Optimal)

**Time Complexity:** O(n)  
**Space Complexity:** O(n)

The hash table approach uses a dictionary to store numbers we've seen along with their indices. For each element, we calculate its complement (target - current number) and check if it exists in our hash table. If it does, we've found our pair!

```csharp
public int[] TwoSum_HashTable(int[] nums, int target)
{
    if (nums.Length == 0 || nums.Length == 1)
        return [];

    Dictionary<int, int> map = [];
    for (int i = 0; i < nums.Length; i++)
    {
        int argument = target - nums[i];
        if (map.TryGetValue(argument, out int index))
            return [index, i];
        map.TryAdd(nums[i], i);
    }
    return [];
}
```

**Pros:** Linear time complexity, single pass through the array  
**Cons:** Uses additional space for the hash table

## ⚡ Performance Analysis

| Approach | Time Complexity | Space Complexity | Notes |
|----------|----------------|------------------|-------|
| Brute Force | O(n²) | O(1) | Simple but inefficient for large inputs |
| Hash Table | O(n) | O(n) | Optimal solution with trade-off of space for time |

## 🧪 Test Cases Covered

### Case 1: Valid Input with Solution
- **Input:** `nums = [2, 7, 11, 15], target = 9`
- **Expected:** `[0, 1]`
- **Description:** Standard case where the first two elements sum to target

### Case 2: No Solution Available
- **Input:** `nums = [1, 2, 3, 4], target = 10`
- **Expected:** `[]`
- **Description:** No pair of numbers in array sum to target

### Case 3: Empty Array
- **Input:** `nums = [], target = 5`
- **Expected:** `[]`
- **Description:** Edge case with empty input array

### Case 4: Single Element
- **Input:** `nums = [5], target = 5`
- **Expected:** `[]`
- **Description:** Edge case with only one element (can't use same element twice)

### Case 5: Negative Numbers
- **Input:** `nums = [-3, 4, 3, 90], target = 0`
- **Expected:** `[0, 2]`
- **Description:** Test case with negative numbers where -3 + 3 = 0

## 🏷️ Metadata

- **Difficulty:** Easy
- **Tags:** Array, Hash Table
- **Source:** [1. Two Sum](https://leetcode.com/problems/two-sum/)
