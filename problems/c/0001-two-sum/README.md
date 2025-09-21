# [1. Two Sum](https://leetcode.com/problems/two-sum/)

## Problem Description

**Difficulty:** Easy  
**Topics:** Array, Hash Table  

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
Explanation: Because nums[1] + nums[2] == 6, we return [1, 2].
```

### Constraints:
- 2 <= nums.length <= 10^4
- -10^9 <= nums[i] <= 10^9
- -10^9 <= target <= 10^9
- Only one valid answer exists.

## Solution

### Approach 1: Brute Force

**Time Complexity:** O(n²)  
**Space Complexity:** O(1)

#### Algorithm:
1. Use nested loops to check every pair of elements
2. For each element at index i, check all elements at indices j > i
3. If nums[i] + nums[j] equals target, return indices [i, j]
4. Continue until a solution is found

#### Key Insights:
- Simple and straightforward approach
- No additional space required beyond the result array
- Checks all possible combinations systematically

### Approach 2: Two Pointers (with Sorting)

**Time Complexity:** O(n log n)  
**Space Complexity:** O(n)

#### Algorithm:
1. Create an array of value-index pairs to preserve original indices
2. Sort the pairs by their values
3. Use two pointers (left at start, right at end) to find the target sum
4. Move pointers based on current sum compared to target
5. Return the original indices when target sum is found

#### Key Insights:
- More efficient than brute force for larger arrays
- Requires additional space to store value-index pairs
- Sorting allows us to use two-pointer technique effectively

### Implementation

```c
/**
 * @brief Finds two numbers in the array that add up to the target
 * @param nums The input array of integers
 * @param numsSize The size of the input array
 * @param target The target sum
 * @param returnSize Pointer to store the size of the returned array
 * @returns Array containing the indices of the two numbers that sum to target
 * @note Time Complexity: O(n^2), Space Complexity: O(1)
 */
int *two_sum_brute_force(int *nums, int numsSize, int target, int *returnSize)
{
    *returnSize = 2;
    int *result = (int *)malloc(2 * sizeof(int));

    for (int i = 0; i < numsSize - 1; i++)
    {
        for (int j = i + 1; j < numsSize; j++)
        {
            if (nums[i] + nums[j] == target)
            {
                result[0] = i;
                result[1] = j;
                return result;
            }
        }
    }

    return result;
}

/**
 * @brief Finds two numbers in the array that add up to the target using two pointers approach
 * @param nums The input array of integers
 * @param numsSize The size of the input array
 * @param target The target sum
 * @param returnSize Pointer to store the size of the returned array
 * @returns Array containing the indices of the two numbers that sum to target
 * @note Time Complexity: O(n log n), Space Complexity: O(n)
 */
int *two_sum_two_pointers(int *nums, int numsSize, int target, int *returnSize)
{
    *returnSize = 2;
    int *result = (int *)malloc(2 * sizeof(int));

    NumIndex* pairs = (NumIndex*)malloc(numsSize * sizeof(NumIndex));
    for (int i = 0; i < numsSize; i++)
    {
        pairs[i].value = nums[i];
        pairs[i].index = i;
    }

    qsort(pairs, numsSize, sizeof(NumIndex), compare);

    int left = 0;
    int right = numsSize - 1;
    while (left < right)
    {
        int sum = pairs[left].value + pairs[right].value;

        if (sum == target)
        {
            result[0] = pairs[left].index;
            result[1] = pairs[right].index;
            free(pairs);
            return result;
        }

        if (sum < target)
        {
            left++;
        }
        else
        {
            right--;
        }
    }

    free(result);
    free(pairs);
    return NULL;
}
```

## Test Cases

The solution should be able to solve the following test cases:

- **Normal Cases**: 
  - Basic positive numbers: [2, 7, 11, 15] with target 9
  - Arrays with negative numbers: [-1, -2, -3, -4, -5] with target -8
  - Mixed positive and negative numbers: [-3, 4, 3, 90] with target 0
  - Arrays with duplicate values: [3, 3] with target 6
  - Large numbers: [1000000, 999999, 1] with target 1999999

- **Edge Cases**: 
  - Minimum array size (2 elements)
  - Arrays where the solution uses the first and last elements
  - Arrays with negative target values
  - Cross-validation testing between both implementations

## Related Problems

- [15. 3Sum](https://leetcode.com/problems/3sum/)
- [167. Two Sum II - Input Array Is Sorted](https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/)
- [170. Two Sum III - Data structure design](https://leetcode.com/problems/two-sum-iii-data-structure-design/)

---

**Status:** ✅ Solved  
**Date Solved:** September 21, 2025  
