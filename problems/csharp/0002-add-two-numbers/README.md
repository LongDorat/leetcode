# [2. Add Two Numbers](https://leetcode.com/problems/add-two-numbers/)

## Problem Description

**Difficulty:** Medium  
**Topics:** Linked List, Math, Recursion  

You are given two **non-empty** linked lists representing two non-negative integers. The digits are stored in **reverse order**, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

### Example 1:
```
Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
```

### Example 2:
```
Input: l1 = [0], l2 = [0]
Output: [0]
Explanation: 0 + 0 = 0.
```

### Example 3:
```
Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
Explanation: 9999999 + 9999 = 10009998.
```

### Constraints:
- The number of nodes in each linked list is in the range `[1, 100]`.
- `0 <= Node.val <= 9`
- It is guaranteed that the list represents a number that does not have leading zeros.

## Solution

### Approach: Iterative Addition with Carry

**Time Complexity:** O(max(m,n))  
**Space Complexity:** O(max(m,n))

#### Algorithm:
1. Initialize pointers for both input lists and create a result list
2. Traverse both lists simultaneously, adding corresponding digits with any carry from previous addition
3. Handle remaining digits when one list is longer than the other
4. Handle final carry if it exists after processing all digits
5. Return the result linked list

#### Key Insights:
- Since digits are stored in reverse order, we can add from left to right (least significant to most significant)
- We need to track carry from each addition operation
- Handle cases where lists have different lengths
- Don't forget to handle the final carry if it exists

#### Implementation

```csharp
// See Solution.cs for the complete implementation
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // Implementation uses iterative approach with carry handling
        // Processes both lists simultaneously and handles edge cases
    }
}
```

## Test Cases

The solution handles the following test cases:

- **Normal Cases**: Adding numbers of equal length, different lengths, with and without carry
- **Edge Cases**: Single digit numbers, numbers with multiple carries, maximum constraints

### Test Coverage:
- Basic addition without carry: `342 + 465 = 807`
- Addition with multiple carries: `999 + 9999 = 10998`
- Single digit addition: `0 + 0 = 0`
- Different length lists with carry propagation

## Related Problems

- [1. Two Sum](https://leetcode.com/problems/two-sum/)
- [43. Multiply Strings](https://leetcode.com/problems/multiply-strings/)
- [445. Add Two Numbers II](https://leetcode.com/problems/add-two-numbers-ii/)

---

**Status:** ✅ Solved  
**Date Solved:** September 23, 2025  
