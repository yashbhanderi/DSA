// ============================================================
// Problem: Add Two Numbers (Linked List)
// Topic: Linked List
// ============================================================
// PROBLEM STATEMENT:
//   Given two non-empty linked lists representing two non-negative
//   integers (digits stored in reverse order), add them and return
//   the sum as a linked list.
//
//   Input:  2→4→3 + 5→6→4  (342 + 465)
//   Output: 7→0→8           (807)
// ============================================================

public class AddTwoNumbers
{
    // APPROACH: Iterate both lists, handle carry
    // Idea: Process both lists simultaneously, adding corresponding
    //       digits along with carry. Create new nodes for result.
    // Time: O(max(m, n))  |  Space: O(max(m, n))
    public ListNode Optimal(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;
        int carry = 0;

        while (l1 != null || l2 != null || carry > 0)
        {
            int sum = carry;

            if (l1 != null) { sum += l1.val; l1 = l1.next; }
            if (l2 != null) { sum += l2.val; l2 = l2.next; }

            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;
        }

        return dummy.next;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Process digits one by one, track carry.
// - Continue while ANY list has nodes OR carry > 0.
// - New digit = (l1.val + l2.val + carry) % 10.
// - New carry = (l1.val + l2.val + carry) / 10.
// - Don't forget the final carry (e.g., 99 + 1 = 100).
// - Dummy node simplifies head handling.
// - Interview tip: Handle different lengths gracefully with null checks.
// ============================================================
