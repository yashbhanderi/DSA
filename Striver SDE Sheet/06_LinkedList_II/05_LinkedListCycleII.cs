// ============================================================
// Problem: Linked List Cycle II (Find Start of Loop)
// Topic: Linked List II
// ============================================================
// PROBLEM STATEMENT:
//   Given a linked list with a cycle, find the node where the
//   cycle begins. Return null if no cycle.
//
//   Input:  3→2→0→-4→(back to 2)
//   Output: Node 2
// ============================================================

public class LinkedListCycleII
{
    // APPROACH: Floyd's — Phase 1 (detect) + Phase 2 (find start)
    // Idea: After slow & fast meet (Phase 1), reset slow to head.
    //       Move both one step at a time. They meet at cycle start.
    // Why: Distance from head to cycle start = distance from meeting point to cycle start.
    // Time: O(n)  |  Space: O(1)
    public ListNode Optimal(ListNode head)
    {
        ListNode slow = head, fast = head;

        // Phase 1: Detect cycle
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) break;
        }

        // No cycle
        if (fast == null || fast.next == null) return null;

        // Phase 2: Find cycle start
        slow = head;
        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }

        return slow;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Phase 1: Floyd's detection (slow=1, fast=2). Meet inside cycle.
// - Phase 2: Reset slow to head. Both move 1 step. Meeting = cycle start.
// - Math proof: Let d = distance head → cycle start, c = cycle length.
//   At meeting: slow = d + k, fast = d + k + mc. Since fast = 2*slow → d = mc - k.
//   So d steps from meeting point = cycle start.
// - O(n) time, O(1) space. Very commonly asked.
// ============================================================
