# 1. Two Sum

## 📝 Problem Description

Given an array of integers `nums` and an integer `target`, return indices of the two numbers such that they add up to `target`.

You may assume that each input would have **exactly one solution**, and you may not use the same element twice.

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

- `2 <= nums.length <= 10^4`
- `-10^9 <= nums[i] <= 10^9`
- `-10^9 <= target <= 10^9`
- Only one valid answer exists.

## 💡 Solution Approaches

### Approach 1: Brute Force

**Time Complexity:** O(n²)
**Space Complexity:** O(1)

The simplest approach is to check every pair of numbers:

```csharp
public int[] TwoSum(int[] nums, int target)
{
    for (int i = 0; i < nums.Length; i++)
    {
        for (int j = i + 1; j < nums.Length; j++)
        {
            if (nums[i] + nums[j] == target)
            {
                return [i, j];
            }
        }
    }
    return [];
}
```

**Pros:** Simple and straightforward
**Cons:** Inefficient for large arrays

### Approach 2: Hash Map (Optimal)

**Time Complexity:** O(n)
**Space Complexity:** O(n)

Use a hash map to store numbers we've seen and their indices:

```csharp
public int[] TwoSum(int[] nums, int target)
{
    var map = new Dictionary<int, int>();
  
    for (int i = 0; i < nums.Length; i++)
    {
        int complement = target - nums[i];
  
        if (map.ContainsKey(complement))
        {
            return [map[complement], i];
        }
  
        map[nums[i]] = i;
    }
  
    return [];
}
```

**Pros:** Optimal time complexity
**Cons:** Uses extra space

## 🧠 Algorithm Explanation

### Hash Map Approach (Step by Step):

1. **Initialize**: Create an empty hash map to store `value -> index` mappings
2. **Iterate**: For each number in the array:
   - Calculate the complement: `complement = target - current_number`
   - Check if the complement exists in our hash map
   - If found: return the indices `[map[complement], current_index]`
   - If not found: store the current number and its index in the map
3. **Return**: The problem guarantees a solution exists, so we'll always find it

### Why This Works:

- We're looking for two numbers that sum to the target
- If we know one number, we can calculate what the other must be
- The hash map allows us to check if we've seen the required complement in O(1) time

## ⚡ Performance Analysis

| Approach    | Time Complexity | Space Complexity | Best Case | Worst Case |
| ----------- | --------------- | ---------------- | --------- | ---------- |
| Brute Force | O(n²)          | O(1)             | O(1)      | O(n²)     |
| Hash Map    | O(n)            | O(n)             | O(1)      | O(n)       |

## 💻 Current Status

- [X] Basic structure created
- [X] Algorithm implementation pending
- [X] Unit tests pending
- [X] Performance optimization pending

## 📋 Metadata

- **Data Structures**: Array, Hash Table
- **Algorithms**: Hash Map lookup, Two pointers (alternative approach)
- **Concepts**: Time/Space complexity trade-offs
- **Difficulty**: Easy
- **Company Tags**: Amazon, Google, Microsoft, Facebook, Apple

---

**LeetCode Link:** [1. Two Sum](https://leetcode.com/problems/two-sum/)
