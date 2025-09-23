namespace AddTwoNumbers;

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    /// <summary>
    /// Adds two numbers represented as linked lists and returns the sum as a linked list.
    /// Each node contains a single digit, and digits are stored in reverse order.
    /// </summary>
    /// <param name="l1">The first number as a linked list.</param>
    /// <param name="l2">The second number as a linked list.</param>
    /// <returns>The sum as a linked list in reverse order.</returns>
    /// <remarks> Time Complexity: O(max(m,n)), Space Complexity: O(max(m,n)) where m and n are the lengths of l1 and l2 </remarks>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode? currentL1 = l1;
        ListNode? currentL2 = l2;
        ListNode result = new();
        ListNode? currentResult = result;

        int carry = 0;
        while (currentL1 != null && currentL2 != null)
        {
            int currentSum = currentL1.val + currentL2.val + carry;

            currentResult.val = currentSum % 10;
            carry = currentSum / 10;

            currentL1 = currentL1.next;
            currentL2 = currentL2.next;

            if (currentL1 != null || currentL2 != null || carry > 0)
            {
                currentResult.next = new ListNode();
                currentResult = currentResult.next;
            }
        }

        while (currentL1 == null && currentL2 != null)
        {
            int currentSum = currentL2.val + carry;

            currentResult.val = currentSum % 10;
            carry = currentSum / 10;

            currentL2 = currentL2.next;

            if (currentL2 != null || carry != 0)
            {
                currentResult.next = new ListNode();
                currentResult = currentResult.next;
            }
        }

        while (currentL2 == null && currentL1 != null)
        {
            int currentSum = currentL1.val + carry;

            currentResult.val = currentSum % 10;
            carry = currentSum / 10;

            currentL1 = currentL1.next;

            if (currentL1 != null || carry != 0)
            {
                currentResult.next = new ListNode();
                currentResult = currentResult.next;
            }
        }

        if (carry != 0) currentResult.val = carry;

        return result;
    }
}