using System.ComponentModel;

namespace Add_Two_Numbers;

public interface ISolutions
{
    /// <summary>
    /// Given two non-empty linked lists representing two non-negative integers, where each node contains a single digit, this method adds the two numbers and returns the sum as a linked list.
    /// The digits are stored in reverse order, meaning that the 1's digit is at the head of the list.
    /// Each of the two numbers does not contain any leading zero, except the number 0.
    /// </summary>
    /// <param name="l1">Store the first linked list</param>
    /// <param name="l2">Store the second linked list</param>
    /// <returns> Return the sum linked list </returns>
    /// <remarks>Time Complexity: O(max(m, n)), Space Complexity: O(max(m, n))</remarks>
    ListNode AddTwoNumbers(ListNode l1, ListNode l2);
}

public class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;
}

public class Solutions : ISolutions
{
    public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        // Create dummy head to simplify list construction
        ListNode head = new(0);
        ListNode current = head;
        int carry = 0; // Track carry-over from addition

        // Continue while there are digits to process or carry exists
        while (l1 != null || l2 != null || carry > 0)
        {
            int sum = carry; // Start with any carry from previous addition

            // Add digit from first number if available
            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next; // Move to next digit
            }

            // Add digit from second number if available
            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next; // Move to next digit
            }

            // Calculate new carry (1 if sum >= 10, 0 otherwise)
            carry = sum / 10;
            // Create new node with the ones digit of sum
            current.next = new ListNode(sum % 10);
            current = current.next; // Move to next position in result
        }

        // Handle edge case where result would be empty (should not happen with valid input)
        if (head.next == null)
        {
            return new ListNode(0);
        }
        return head.next; // Return actual result, skip dummy head
    }
}