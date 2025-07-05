# 2. Add Two Numbers

## 📝 Problem Description

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
```

### Example 3:

```
Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
Explanation: 9999999 + 9999 = 10009998
```

### Constraints:

- The number of nodes in each linked list is in the range `[1, 100]`.
- `0 <= Node.val <= 9`
- It is guaranteed that the list represents a number that does not have leading zeros.

## 💡 Solution Approaches

### Approach 1: Simulation with Carry

**Time Complexity:** O(max(m, n))
**Space Complexity:** O(max(m, n))

Where m and n are the lengths of the two linked lists.

The optimal approach simulates elementary math addition with carry:

```csharp
public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
{
    ListNode head = new(0);
    ListNode current = head;
    int carry = 0;

    while (l1 != null || l2 != null || carry > 0)
    {
        int sum = carry;

        if (l1 != null)
        {
            sum += l1.val;
            l1 = l1.next;
        }

        if (l2 != null)
        {
            sum += l2.val;
            l2 = l2.next;
        }

        carry = sum / 10;
        current.next = new ListNode(sum % 10);
        current = current.next;
    }

    return head.next;
}
```

**Pros:** Efficient single-pass solution
**Cons:** Requires understanding of carry propagation

### Alternative Approach: Convert to Integers (Not Recommended)

**Time Complexity:** O(max(m, n))
**Space Complexity:** O(max(m, n))

```csharp
// This approach has limitations with very large numbers
public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    long num1 = LinkedListToNumber(l1);
    long num2 = LinkedListToNumber(l2);
    long sum = num1 + num2;
    return NumberToLinkedList(sum);
}
```

**Pros:** Conceptually simpler
**Cons:** Integer overflow for large numbers, inefficient

## ⚡ Performance Analysis

| Approach    | Time Complexity | Space Complexity | Best Case   | Worst Case  |
| ----------- | --------------- | ---------------- | ----------- | ----------- |
| Simulation  | O(max(m,n))     | O(max(m,n))      | O(min(m,n)) | O(max(m,n)) |
| Convert Int | O(max(m,n))     | O(max(m,n))      | O(max(m,n)) | O(max(m,n)) |

### Space Complexity Notes:

- Output linked list requires O(max(m,n)) or O(max(m,n)+1) space
- Only O(1) extra space needed for variables (carry, sum, pointers)

## 🧪 Test Cases Covered

### Edge Cases:
- Single digit each: `[5]` + `[5]` → `[0,1]` (with carry)
- Zero values: `[0]` + `[0]` → `[0]`
- One list longer: `[9,9]` + `[1]` → `[0,0,1]`
- Maximum carry propagation: `[9,9,9,9,9,9,9]` + `[9,9,9,9]` → `[8,9,9,9,0,0,0,1]`

### Normal Cases:
- Example 1: `[2,4,3]` + `[5,6,4]` → `[7,0,8]` (342 + 465 = 807)
- Example 2: `[0]` + `[0]` → `[0]`
- Example 3: `[9,9,9,9,9,9,9]` + `[9,9,9,9]` → `[8,9,9,9,0,0,0,1]`

### Carry Scenarios:
- No carry: `[1,2,3]` + `[4,5,6]` → `[5,7,9]`
- Carry in middle: `[2,4,3]` + `[5,6,4]` → `[7,0,8]`
- Final carry: `[5]` + `[5]` → `[0,1]`
- Multiple carries: `[9,9]` + `[9,9,9]` → `[8,9,0,1]`

### Length Variations:
- Equal length: `[1,2]` + `[3,4]` → `[4,6]`
- First longer: `[1,2,3]` + `[4,5]` → `[5,7,3]`
- Second longer: `[1,2]` + `[3,4,5]` → `[4,6,5]`

### Special Values:
- All nines: `[9,9,9]` + `[9,9,9]` → `[8,9,9,1]`
- Leading zeros result: `[1]` + `[9,9,9]` → `[0,0,0,1]`
- Single nodes: `[2]` + `[8]` → `[0,1]`

## 💻 Current Status

- [X] Algorithm implementation completed
- [X] Unit tests implemented
- [X] Edge cases covered
- [X] Performance optimized

## 🏷️ Metadata

- **Difficulty**: Medium
- **Tags**: Linked List, Math, Recursion
- **Source**: [2. Add Two Numbers](https://leetcode.com/problems/add-two-numbers/)
