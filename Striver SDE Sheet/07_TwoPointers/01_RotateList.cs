// ============================================================
// Problem: Rotate List
// Topic: Two Pointers
// ============================================================
// PROBLEM STATEMENT:
//   Rotate a linked list to the right by k places.
//   Input:  1→2→3→4→5, k = 2 → Output: 4→5→1→2→3
// ============================================================

public class RotateList
{
    // APPROACH: Find length, connect tail to head, break at new tail
    // Idea: Effective rotation = k % length. New tail is at (length - k - 1).
    //       Make it circular, then break at the new tail.
    // Time: O(n)  |  Space: O(1)
    public ListNode Optimal(ListNode head, int k)
    {
        if (head == null || head.next == null || k == 0) return head;

        // Find length and tail
        int len = 1;
        ListNode tail = head;
        while (tail.next != null) { len++; tail = tail.next; }

        k = k % len;
        if (k == 0) return head;

        // Make circular
        tail.next = head;

        // Find new tail (length - k - 1 steps from head)
        ListNode newTail = head;
        for (int i = 0; i < len - k - 1; i++)
            newTail = newTail.next;

        ListNode newHead = newTail.next;
        newTail.next = null;

        return newHead;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - k %= length (handle k > length). If k=0, no rotation needed.
// - Make circular (tail→head), walk (len-k-1) steps to find new tail.
// - Break the circle at new tail. New head = newTail.next.
// - O(n) time, O(1) space. Single traversal + partial traversal.
// ============================================================
