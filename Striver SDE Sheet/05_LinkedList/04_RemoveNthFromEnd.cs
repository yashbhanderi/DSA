// ============================================================
// Problem: Remove Nth Node From End of List
// Topic: Linked List
// ============================================================
// PROBLEM STATEMENT:
//   Remove the nth node from the end of the list and return head.
//
//   Input:  1→2→3→4→5, n = 2
//   Output: 1→2→3→5
// ============================================================

public class RemoveNthFromEnd
{
    // APPROACH 1: BRUTE FORCE — Two passes (count + remove)
    // Time: O(L) — two passes  |  Space: O(1)
    public ListNode BruteForce(ListNode head, int n)
    {
        int len = 0;
        ListNode temp = head;
        while (temp != null) { len++; temp = temp.next; }

        if (n == len) return head.next; // remove head

        temp = head;
        for (int i = 1; i < len - n; i++) temp = temp.next;
        temp.next = temp.next.next;
        return head;
    }

    // APPROACH 2: OPTIMAL — One pass with two pointers
    // Idea: Move fast pointer n steps ahead. Then move both.
    //       When fast reaches end, slow is at (n+1)th from end.
    // Time: O(L) — single pass  |  Space: O(1)
    public ListNode Optimal(ListNode head, int n)
    {
        ListNode dummy = new ListNode(0, head);
        ListNode slow = dummy, fast = dummy;

        // Move fast n+1 steps ahead
        for (int i = 0; i <= n; i++)
            fast = fast.next;

        // Move both until fast reaches end
        while (fast != null)
        {
            slow = slow.next;
            fast = fast.next;
        }

        // slow is now right before the node to delete
        slow.next = slow.next.next;

        return dummy.next;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Two pointers with n-step gap. When fast hits null, slow is right before target.
// - Use dummy node to handle edge case of removing head.
// - Fast moves n+1 ahead (not n), so slow stops BEFORE the target.
// - Single pass, O(1) space.
// - Interview tip: Dummy node is key for edge cases.
// ============================================================
