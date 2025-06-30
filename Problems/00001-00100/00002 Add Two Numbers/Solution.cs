using System.ComponentModel;

namespace Add_Two_Numbers;

public interface ISolution
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

public class ListNode(int val = 0, ListNode ?next = null)
{
    public int val = val;
    public ListNode ?next = next;
}

public class Solution : ISolution
{
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

        if (head.next == null)
        {
            return new ListNode(0);
        }
        return head.next;
    }
}