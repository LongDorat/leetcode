# [1. Two Sum](https://leetcode.com/problems/two-sum/)

## Problem Description

**Difficulty:** Easy  
**Topics:** Array, Hash Table  

Given an array of integers `nums` and an integer `target`, return the indices of the two numbers such that they add up to `target`.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

### Example 1:
```
Input: [2, 7, 11, 15], target: 9
Output: [0, 1]
Explanation: nums[0] + nums[1] = 2 + 7 = 9
```

### Example 2:
```
Input: [3, 2, 4], target: 6
Output: [1, 2]
Explanation: nums[1] + nums[2] = 2 + 4 = 6
```

### Constraints:
- `2 <= nums.length <= 104`
- `-109 <= nums[i] <= 109`
- `-109 <= target <= 109`
- Only one valid answer exists.

## Solution

### Approach: Brute Force

**Time Complexity:** O(n^2)
**Space Complexity:** O(1)

#### Algorithm:
1. Iterate through each element in the array.
2. For each element, iterate through the remaining elements to find a pair that sums to the target.
3. If a pair is found, return their indices.

#### Key Insights:
- This approach has a high time complexity due to the nested loops.
- It is simple to implement and understand.
- It does not require any additional data structures.

### Implementation

```csharp
    public int[] BruteForce(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [-1, -1];
    }
```

### Approach: Hash Table

**Time Complexity:** O(n)
**Space Complexity:** O(n)

#### Algorithm:
1. Create a hash table to store the numbers and their indices.
2. Iterate through the array, and for each number, calculate its complement (target - current number).
3. Check if the complement exists in the hash table. If it does, return the indices of the current number and the complement.
4. If not, add the current number and its index to the hash table.
5. If no pair is found, return [-1, -1].

#### Key Insights:
- This approach significantly reduces the time complexity by using a hash table for constant-time lookups.
- It requires additional space for the hash table.

### Implementation

```csharp
    public int[] HashTable(int[] nums, int target)
    {
        Dictionary<int, int> hashTable = [];

        for (int i = 0; i < nums.Length; i++)
        {
            if (hashTable.ContainsKey(target - nums[i]))
            {
                return [hashTable[target - nums[i]], i];
            }
            hashTable.TryAdd(nums[i], i);
        }

        return [-1, -1];
    }
```

## Test Cases

The solution should be able to solve the following test cases:

- **Normal Cases**: 
  - Input: [2, 7, 11, 15], target: 9  
    Output: [0, 1]
  - Input: [3, 2, 4], target: 6  
    Output: [1, 2]
- **Edge Cases**: 
  - Input: [1, 2], target: 3  
    Output: [0, 1]
  - Input: [0, 0], target: 0  
    Output: [0, 1]

## Related Problems

- [15. 3Sum](https://leetcode.com/problems/3sum/)
- [167. Two Sum II - Input Array Is Sorted](https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/)
- [170. Two Sum III - Data structure design](https://leetcode.com/problems/two-sum-iii-data-structure-design/)
- [653. Two Sum IV - BST](https://leetcode.com/problems/two-sum-iv-bst/)

---

**Status:** Solved ✅  
**Date Solved:** 2024-10-01  
