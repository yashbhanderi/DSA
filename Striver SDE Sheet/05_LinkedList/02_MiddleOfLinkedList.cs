// ============================================================
// Problem: Middle of Linked List
// Topic: Linked List
// ============================================================
// PROBLEM STATEMENT:
//   Find the middle node of a linked list. If two middle nodes,
//   return the second one.
//
//   Input:  1 → 2 → 3 → 4 → 5
//   Output: Node 3
// ============================================================

public class MiddleOfLinkedList
{
    // APPROACH 1: BRUTE FORCE — Count nodes, then traverse to middle
    // Time: O(n) — two passes  |  Space: O(1)
    public ListNode BruteForce(ListNode head)
    {
        int count = 0;
        ListNode temp = head;
        while (temp != null) { count++; temp = temp.next; }

        temp = head;
        for (int i = 0; i < count / 2; i++) temp = temp.next;
        return temp;
    }

    // APPROACH 2: OPTIMAL — Slow and Fast Pointers (Tortoise & Hare)
    // Idea: slow moves 1 step, fast moves 2 steps.
    //       When fast reaches end, slow is at middle.
    // Time: O(n) — single pass  |  Space: O(1)
    public ListNode Optimal(ListNode head)
    {
        ListNode slow = head, fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Tortoise & Hare: slow=1step, fast=2steps. Slow lands on middle.
// - For even-length: returns 2nd middle (e.g., 4 in [1,2,3,4,5,6]).
// - To get 1st middle (even case): check fast.next?.next != null.
// - Single pass, O(1) space.
// - This pattern is foundation for cycle detection, palindrome check, etc.
// ============================================================
