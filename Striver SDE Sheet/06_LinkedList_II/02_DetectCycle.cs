// ============================================================
// Problem: Detect Cycle in Linked List
// Topic: Linked List II
// ============================================================
// PROBLEM STATEMENT:
//   Given a linked list, determine if it has a cycle.
//
//   Input:  3→2→0→-4→(back to 2)
//   Output: true
// ============================================================

public class DetectCycle
{
    // APPROACH 1: OPTIMAL — Floyd's Cycle Detection (Tortoise & Hare)
    // Idea: Slow moves 1 step, fast moves 2 steps. If they meet → cycle.
    // Time: O(n)  |  Space: O(1)
    public bool Optimal(ListNode head)
    {
        ListNode slow = head, fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) return true;
        }

        return false;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Floyd's: slow=1step, fast=2steps. If they meet → cycle exists.
// - Why it works: fast gains 1 step per iteration, so they must meet in cycle.
// - If fast hits null → no cycle.
// - O(n) time, O(1) space.
// - Foundation for finding cycle start (Linked List Cycle II).
// ============================================================
