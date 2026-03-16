// ============================================================
// Problem: Reverse Linked List
// Topic: Linked List
// ============================================================
// PROBLEM STATEMENT:
//   Given the head of a singly linked list, reverse it and return
//   the new head.
//
//   Input:  1 → 2 → 3 → 4 → 5
//   Output: 5 → 4 → 3 → 2 → 1
// ============================================================

using System;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null) { this.val = val; this.next = next; }
}

public class ReverseLinkedList
{
    // APPROACH 1: OPTIMAL (Iterative) — Three pointers
    // Idea: Use prev, curr, next pointers. Reverse each link.
    // Time: O(n)  |  Space: O(1)
    public ListNode Iterative(ListNode head)
    {
        ListNode prev = null, curr = head;

        while (curr != null)
        {
            ListNode next = curr.next; // save next
            curr.next = prev;          // reverse link
            prev = curr;               // advance prev
            curr = next;               // advance curr
        }

        return prev; // new head
    }

    // APPROACH 2: OPTIMAL (Recursive)
    // Idea: Reverse the rest of the list, then fix the link.
    // Time: O(n)  |  Space: O(n) stack space
    public ListNode Recursive(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        ListNode newHead = Recursive(head.next);
        head.next.next = head; // reverse the link
        head.next = null;      // remove old link

        return newHead;
    }
}

// ============================================================
// QUICK REVISION NOTES:
// - Iterative: 3 pointers (prev, curr, next). Reverse each link one by one.
// - Recursive: Recurse to end, then fix links on the way back.
// - Both O(n) time. Iterative is O(1) space, recursive is O(n) stack.
// - Foundation for many other problems (reverse in k-groups, palindrome check, etc).
// - Interview tip: Draw the pointer movements step by step.
// ============================================================
