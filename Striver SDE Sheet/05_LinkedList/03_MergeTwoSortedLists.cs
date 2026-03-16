// ============================================================
// Problem: Merge Two Sorted Lists
// Topic: Linked List
// ============================================================
// PROBLEM STATEMENT:
//   Merge two sorted linked lists into one sorted linked list.
//
//   Input:  1→2→4, 1→3→4
//   Output: 1→1→2→3→4→4
// ============================================================

public class MergeTwoSortedLists
{
    // APPROACH 1: OPTIMAL — Two pointers with dummy node
    // Idea: Use a dummy head. Compare current nodes of both lists,
    //       attach the smaller one. Continue until one list exhausts.
    // Time: O(m + n)  |  Space: O(1)
    public ListNode Optimal(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode(0);
        ListNode current = dummy;

        while (l1 != null && l2 != null)
        {
            if (l1.val <= l2.val)
            {
                current.next = l1;
                l1 = l1.next;
            }
            else
            {
                current.next = l2;
                l2 = l2.next;
            }
            current = current.next;
        }

        // Attach remaining nodes
        current.next = l1 ?? l2;

        return dummy.next;
    }

    // APPROACH 2: Recursive
    // Time: O(m + n)  |  Space: O(m + n) stack
    public ListNode Recursive(ListNode l1, ListNode l2)
    {
        if (l1 == null) return l2;
        if (l2 == null) return l1;

        if (l1.val <= l2.val)
        {
            l1.next = Recursive(l1.next, l2);
            return l1;
        }
        else
        {
            l2.next = Recursive(l1, l2.next);
            return l2;
        }
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Dummy node technique: Avoids special-casing the head pointer.
// - Compare heads, take smaller, advance that list's pointer.
// - Attach remaining list when one exhausts.
// - O(m+n) time, O(1) space (iterative). Foundation for Merge K Lists.
// - Interview tip: Always use dummy node for cleaner linked list code.
// ============================================================
