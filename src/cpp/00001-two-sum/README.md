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

- `2 <= nums.length <= 10^4`
- `-10^9 <= nums[i] <= 10^9`
- `-10^9 <= target <= 10^9`
- Only one valid answer exists.

## 💡 Solution Approaches

### Approach 1: Brute Force

**Time Complexity:** O(n²)  
**Space Complexity:** O(1)

The most straightforward approach is to check every pair of numbers in the array to see if they sum to the target.

```cpp
std::vector<int> BruteForce(std::vector<int> nums, int target)
{
    if (nums.size() < 2)
        return {};

    for (int i = 0; i < nums.size() - 1; i++)
    {
        for (int j = i + 1; j < nums.size(); j++)
        {
            if (nums[i] + nums[j] == target)
            {
                return {i, j};
            }
        }
    }
    return {};
}
```

**Pros:** Simple to understand and implement, no extra space needed  
**Cons:** Inefficient for large arrays due to quadratic time complexity

### Approach 2: Hash Map (Optimal)

**Time Complexity:** O(n)  
**Space Complexity:** O(n)

Use a hash map to store numbers we've seen and their indices. For each number, check if its complement (target - current number) exists in the hash map.

```cpp
std::vector<int> HashMap(std::vector<int> nums, int target)
{
    if (nums.size() < 2)
        return {};

    std::unordered_map<int, int> map;

    for(int i = 0; i < nums.size(); i++)
    {
        if(map.find(target - nums[i]) != map.end())
            return {map[target - nums[i]], i};

        map[nums[i]] = i;
    }
    return {};
}
```

**Pros:** Optimal time complexity, single pass through array  
**Cons:** Uses additional space for the hash map

## ⚡ Performance Analysis

| Approach | Time Complexity | Space Complexity | Notes |
|----------|----------------|------------------|-------|
| Brute Force | O(n²) | O(1) | Simple but slow for large inputs |
| Hash Map | O(n) | O(n) | Optimal solution, trades space for time |

## 🧪 Test Cases Covered

### Basic Cases:
- **Standard case**: `nums = [2,7,11,15], target = 9` → `[0,1]`
- **Target at end**: `nums = [3,2,4], target = 6` → `[1,2]`
- **Same numbers**: `nums = [3,3], target = 6` → `[0,1]`

### Edge Cases:
- **Empty array**: `nums = [], target = 0` → `[]`
- **Single element**: `nums = [5], target = 5` → `[]`
- **No solution**: `nums = [1,2,3,4], target = 10` → `[]`

### Special Cases:
- **Negative numbers**: `nums = [-1,-2,-3,-4,-5], target = -8` → `[2,4]`
- **Mixed positive/negative**: `nums = [-3,4,3,90], target = 0` → `[0,2]`
- **Large numbers**: `nums = [1000000,2000000,3000000], target = 5000000` → `[1,2]`

## 🏷️ Metadata

- **Difficulty:** Easy
- **Tags:** Array, Hash Table
- **Source:** [1. Two Sum](https://leetcode.com/problems/two-sum/)
