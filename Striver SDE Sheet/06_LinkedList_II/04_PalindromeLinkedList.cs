// ============================================================
// Problem: Palindrome Linked List
// Topic: Linked List II
// ============================================================
// PROBLEM STATEMENT:
//   Check if a singly linked list is a palindrome.
//
//   Input:  1→2→2→1  → Output: true
//   Input:  1→2       → Output: false
// ============================================================

public class PalindromeLinkedList
{
    // APPROACH 1: BRUTE FORCE — Copy to array, check with two pointers
    // Time: O(n)  |  Space: O(n)

    // APPROACH 2: OPTIMAL — Reverse second half in-place
    // Idea: Find middle (slow-fast), reverse second half,
    //       compare first and second halves.
    // Time: O(n)  |  Space: O(1)
    public bool Optimal(ListNode head)
    {
        if (head == null || head.next == null) return true;

        // Step 1: Find middle
        ListNode slow = head, fast = head;
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        // Step 2: Reverse second half (starting from slow.next)
        ListNode secondHalf = Reverse(slow.next);

        // Step 3: Compare both halves
        ListNode first = head, second = secondHalf;
        bool isPalin = true;
        while (second != null)
        {
            if (first.val != second.val) { isPalin = false; break; }
            first = first.next;
            second = second.next;
        }

        // Step 4: Restore (optional but good practice)
        slow.next = Reverse(secondHalf);

        return isPalin;
    }

    private ListNode Reverse(ListNode head)
    {
        ListNode prev = null, curr = head;
        while (curr != null)
        {
            ListNode next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }
        return prev;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Find middle → reverse second half → compare → optionally restore.
// - Use slow-fast to find middle (slow stops at first half's end).
// - O(n) time, O(1) space.
// - Restoring the list is good practice (asked sometimes in interviews).
// - Interview tip: Combine 3 linked list techniques: middle, reverse, compare.
// ============================================================
